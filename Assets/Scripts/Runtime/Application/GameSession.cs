using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace Meowblade
{
    public sealed class GameSession
    {
        private readonly ISaveRepository _saveRepository;
        private readonly IClock _clock;
        private GameSaveData _save;
        private float _productionAccumulator;
        private float _autoSaveAccumulator;
        private bool _initialized;

        public event Action StateChanged;
        public event Action<string> ToastRequested;

        public GameSaveData SaveData { get { return _save; } }
        public string OfflineSummary { get; private set; }
        public bool IsInitialized { get { return _initialized; } }

        public GameSession(ISaveRepository saveRepository, IClock clock)
        {
            _saveRepository = saveRepository ?? throw new ArgumentNullException("saveRepository");
            _clock = clock ?? throw new ArgumentNullException("clock");
        }

        public void Initialize()
        {
            _save = _saveRepository.Load() ?? GameSaveData.CreateDefault();
            EnsureStateIsValid();
            OfflineSummary = ApplyOfflineProduction();
            _save.lastSaveUnixSeconds = _clock.UtcNowUnixSeconds;
            _initialized = true;
            SaveNow();
            RaiseChanged();
        }

        public void Tick(float deltaTime)
        {
            if (!_initialized || deltaTime <= 0f)
            {
                return;
            }

            _productionAccumulator += deltaTime;
            while (_productionAccumulator >= GameBalance.ProductionTickSeconds)
            {
                _productionAccumulator -= GameBalance.ProductionTickSeconds;
                ProcessProduction(GameBalance.ProductionTickSeconds);
            }

            _autoSaveAccumulator += deltaTime;
            if (_autoSaveAccumulator >= 30f)
            {
                _autoSaveAccumulator = 0f;
                SaveNow();
            }
        }

        public int GetResource(ResourceId id)
        {
            return GetResourceData(id).amount;
        }

        public int GetCapacity(ResourceId id)
        {
            return GameBalance.Capacity(id);
        }

        public int AddResource(ResourceId id, int amount)
        {
            if (amount <= 0)
            {
                return 0;
            }

            ResourceAmountData data = GetResourceData(id);
            int free = Mathf.Max(0, GetCapacity(id) - data.amount);
            int added = Mathf.Min(free, amount);
            data.amount += added;
            if (added > 0)
            {
                RaiseChanged();
            }

            return added;
        }

        public bool CanAfford(ResourceCost[] costs)
        {
            if (costs == null)
            {
                return true;
            }

            for (int i = 0; i < costs.Length; i++)
            {
                if (GetResource(costs[i].Resource) < costs[i].Amount)
                {
                    return false;
                }
            }

            return true;
        }

        public bool TrySpend(ResourceCost[] costs)
        {
            if (!CanAfford(costs))
            {
                Toast("材料不足");
                return false;
            }

            for (int i = 0; i < costs.Length; i++)
            {
                GetResourceData(costs[i].Resource).amount -= costs[i].Amount;
            }

            RaiseChanged();
            return true;
        }

        public int GetWorkers(StationId id)
        {
            return GetAllocationData(id).workers;
        }

        public int GetAssignedWorkerTotal()
        {
            int total = 0;
            foreach (StationId station in GameBalance.AllStations)
            {
                total += GetWorkers(station);
            }

            return total;
        }

        public float GetRatePerMinute(StationId id)
        {
            return GetRatePerMinute(id, GetWorkers(id));
        }

        public float GetRatePerMinute(StationId id, int workers)
        {
            return GameBalance.BaseRatePerMinute(id) * Mathf.Max(0, workers) * _save.globalProductionMultiplier;
        }

        public float GetProgress(StationId id)
        {
            return Mathf.Clamp01(GetProgressData(id).progress);
        }

        public WorkstationStatus GetStationStatus(StationId id)
        {
            if (GetWorkers(id) <= 0)
            {
                return WorkstationStatus.NoWorker;
            }

            ResourceId output = GameBalance.StationOutput(id);
            if (GetResource(output) >= GetCapacity(output))
            {
                return WorkstationStatus.WaitingStorage;
            }

            return WorkstationStatus.Producing;
        }

        public bool TryApplyAllocation(int cardboardWorkers, int fishWorkers, int partWorkers)
        {
            int[] values = { cardboardWorkers, fishWorkers, partWorkers };
            int total = 0;
            for (int i = 0; i < values.Length; i++)
            {
                if (values[i] < 0 || values[i] > GameBalance.TotalWorkers)
                {
                    Toast("单个岗位的猫猫数量不合法");
                    return false;
                }

                total += values[i];
            }

            if (total > GameBalance.TotalWorkers)
            {
                Toast("工人猫总数不能超过 3");
                return false;
            }

            GetAllocationData(StationId.Cardboard).workers = cardboardWorkers;
            GetAllocationData(StationId.Fish).workers = fishWorkers;
            GetAllocationData(StationId.Parts).workers = partWorkers;
            SaveNow();
            RaiseChanged();
            Toast("分工已确认，猫猫正在换岗");
            return true;
        }

        public HeroArmyData GetArmy(HeroId heroId)
        {
            for (int i = 0; i < _save.armies.Count; i++)
            {
                if (_save.armies[i].heroId == heroId)
                {
                    return _save.armies[i];
                }
            }

            HeroArmyData army = new HeroArmyData(heroId, GameBalance.MaxKittens(heroId), 0);
            _save.armies.Add(army);
            return army;
        }

        public int GetKittenCount(HeroId heroId, KittenStatus status)
        {
            int count = 0;
            List<KittenSlotData> kittens = GetArmy(heroId).kittens;
            for (int i = 0; i < kittens.Count; i++)
            {
                if (kittens[i].status == status)
                {
                    count++;
                }
            }

            return count;
        }

        public bool TryHealOne(HeroId heroId)
        {
            HeroArmyData army = GetArmy(heroId);
            KittenSlotData target = null;
            for (int i = 0; i < army.kittens.Count; i++)
            {
                if (army.kittens[i].status == KittenStatus.Injured)
                {
                    target = army.kittens[i];
                    break;
                }
            }

            if (target == null)
            {
                Toast("这支军团没有受伤小猫");
                return false;
            }

            if (!TrySpend(GameBalance.HealKittenCosts))
            {
                return false;
            }

            target.status = KittenStatus.Ready;
            SaveNow();
            RaiseChanged();
            Toast("小猫包扎完成，重新归队！");
            return true;
        }

        public bool TryRecruitOne(HeroId heroId)
        {
            HeroArmyData army = GetArmy(heroId);
            KittenSlotData target = null;
            for (int i = 0; i < army.kittens.Count; i++)
            {
                if (army.kittens[i].status == KittenStatus.Empty)
                {
                    target = army.kittens[i];
                    break;
                }
            }

            if (target == null)
            {
                Toast("这支军团编制已经满了");
                return false;
            }

            if (!TrySpend(GameBalance.RecruitKittenCosts))
            {
                return false;
            }

            target.status = KittenStatus.Ready;
            SaveNow();
            RaiseChanged();
            Toast("新小猫从纸箱里跳出来了！");
            return true;
        }

        public bool TryCraftAndEquipCape()
        {
            if (!_save.stageOneCleared)
            {
                Toast("通关普通关后解锁纸箱侠披风");
                return false;
            }

            if (_save.cardboardCapeCrafted)
            {
                _save.cardboardCapeEquipped = true;
                SaveNow();
                RaiseChanged();
                Toast("纸箱侠披风已装备");
                return true;
            }

            if (!TrySpend(GameBalance.CraftCapeCosts))
            {
                return false;
            }

            _save.cardboardCapeCrafted = true;
            _save.cardboardCapeEquipped = true;
            SaveNow();
            RaiseChanged();
            Toast("纸箱侠披风制作完成，受到伤害 -20%！");
            return true;
        }

        public int GetFormationHero(int slotIndex)
        {
            if (slotIndex < 0 || slotIndex >= _save.formationSlots.Count)
            {
                return -1;
            }

            return _save.formationSlots[slotIndex];
        }

        public void MoveHeroToSlot(HeroId heroId, int targetSlot)
        {
            if (targetSlot < 0 || targetSlot >= 6)
            {
                return;
            }

            int heroValue = (int)heroId;
            int oldSlot = _save.formationSlots.IndexOf(heroValue);
            int targetHero = _save.formationSlots[targetSlot];

            if (oldSlot == targetSlot)
            {
                return;
            }

            if (oldSlot >= 0)
            {
                _save.formationSlots[oldSlot] = targetHero;
            }

            _save.formationSlots[targetSlot] = heroValue;
            SaveNow();
            RaiseChanged();
        }

        public StageId SuggestedStage
        {
            get { return _save.stageOneCleared ? StageId.BoxOverlord : StageId.AlleyRaid; }
        }

        public bool IsStageUnlocked(StageId stage)
        {
            return stage == StageId.AlleyRaid || _save.stageOneCleared;
        }

        public void CommitBattleResult(BattleResult result)
        {
            if (result == null || !result.Victory)
            {
                return;
            }

            for (int i = 0; i < result.InjuredKittens.Count; i++)
            {
                InjuredKitten injury = result.InjuredKittens[i];
                HeroArmyData army = GetArmy(injury.HeroId);
                if (injury.SlotIndex >= 0 && injury.SlotIndex < army.kittens.Count &&
                    army.kittens[injury.SlotIndex].status == KittenStatus.Ready)
                {
                    army.kittens[injury.SlotIndex].status = KittenStatus.Injured;
                }
            }

            if (result.StageId == StageId.AlleyRaid)
            {
                if (!_save.stageOneCleared)
                {
                    _save.stageOneCleared = true;
                    AddResource(ResourceId.Cardboard, 10);
                    AddResource(ResourceId.MysticPart, 3);
                }
                else
                {
                    AddResource(ResourceId.Cardboard, 2);
                }
            }
            else if (result.StageId == StageId.BoxOverlord)
            {
                if (!_save.bossCleared)
                {
                    _save.bossCleared = true;
                    _save.globalProductionMultiplier = GameBalance.BossProductionMultiplier;
                    _save.homeVisualLevel = 2;
                    AddResource(ResourceId.DriedFish, 12);
                }
                else
                {
                    AddResource(ResourceId.DriedFish, 3);
                }
            }

            SaveNow();
            RaiseChanged();
        }

        public string BuildArmySummary(HeroId heroId)
        {
            int ready = GetKittenCount(heroId, KittenStatus.Ready);
            int injured = GetKittenCount(heroId, KittenStatus.Injured);
            int empty = GetKittenCount(heroId, KittenStatus.Empty);
            return string.Format("可用 {0}/{1}  ·  受伤 {2}  ·  空缺 {3}", ready, GameBalance.MaxKittens(heroId), injured, empty);
        }

        public void SaveNow()
        {
            if (_save == null)
            {
                return;
            }

            _save.lastSaveUnixSeconds = _clock.UtcNowUnixSeconds;

            try
            {
                _saveRepository.Save(_save);
            }
            catch (Exception exception)
            {
                Debug.LogError("Game save failed: " + exception);
            }
        }

        public void ResetSave()
        {
            _save = GameSaveData.CreateDefault();
            OfflineSummary = string.Empty;
            SaveNow();
            RaiseChanged();
            Toast("存档已重置");
        }

        private void ProcessProduction(float deltaTime)
        {
            bool anyChanged = false;
            foreach (StationId station in GameBalance.AllStations)
            {
                int workers = GetWorkers(station);
                StationProgressData progress = GetProgressData(station);
                ResourceId output = GameBalance.StationOutput(station);
                ResourceAmountData resource = GetResourceData(output);
                int capacity = GetCapacity(output);

                if (workers <= 0 || resource.amount >= capacity)
                {
                    progress.progress = Mathf.Min(progress.progress, 0.999f);
                    continue;
                }

                float ratePerSecond = GetRatePerMinute(station, workers) / 60f;
                progress.progress += deltaTime * ratePerSecond;
                int wholeUnits = Mathf.FloorToInt(progress.progress);
                if (wholeUnits <= 0)
                {
                    continue;
                }

                int free = capacity - resource.amount;
                int added = Mathf.Min(free, wholeUnits);
                resource.amount += added;
                progress.progress -= wholeUnits;
                if (added < wholeUnits || resource.amount >= capacity)
                {
                    progress.progress = Mathf.Min(progress.progress, 0.999f);
                }

                anyChanged |= added > 0;
            }

            if (anyChanged)
            {
                RaiseChanged();
            }
        }

        private string ApplyOfflineProduction()
        {
            long now = _clock.UtcNowUnixSeconds;
            if (_save.lastSaveUnixSeconds <= 0)
            {
                return string.Empty;
            }

            long rawElapsed = now - _save.lastSaveUnixSeconds;
            int elapsed = (int)Math.Min(Math.Max(rawElapsed, 0L), (long)GameBalance.MaxOfflineSeconds);
            if (elapsed < 5)
            {
                return string.Empty;
            }

            StringBuilder builder = new StringBuilder();
            builder.AppendLine(string.Format("离线 {0}分{1}秒，猫猫没有停工：", elapsed / 60, elapsed % 60));
            bool any = false;

            foreach (StationId station in GameBalance.AllStations)
            {
                int workers = GetWorkers(station);
                if (workers <= 0)
                {
                    continue;
                }

                ResourceId resourceId = GameBalance.StationOutput(station);
                int theoretical = Mathf.FloorToInt(elapsed * GetRatePerMinute(station, workers) / 60f);
                int before = GetResource(resourceId);
                int added = AddResource(resourceId, theoretical);
                int overflow = theoretical - added;
                if (added > 0 || overflow > 0)
                {
                    any = true;
                    builder.Append(string.Format("{0} +{1}", GameBalance.ResourceName(resourceId), added));
                    if (overflow > 0 || before + theoretical >= GetCapacity(resourceId))
                    {
                        builder.Append("（已满仓）");
                    }

                    builder.AppendLine();
                }
            }

            return any ? builder.ToString().TrimEnd() : string.Empty;
        }

        private void EnsureStateIsValid()
        {
            if (_save == null)
            {
                _save = GameSaveData.CreateDefault();
                return;
            }

            if (_save.resources == null) _save.resources = new List<ResourceAmountData>();
            if (_save.allocations == null) _save.allocations = new List<StationAllocationData>();
            if (_save.productionProgress == null) _save.productionProgress = new List<StationProgressData>();
            if (_save.armies == null) _save.armies = new List<HeroArmyData>();
            if (_save.formationSlots == null) _save.formationSlots = new List<int>();

            foreach (ResourceId resource in GameBalance.AllResources)
            {
                ResourceAmountData data = GetResourceData(resource);
                data.amount = Mathf.Clamp(data.amount, 0, GetCapacity(resource));
            }

            foreach (StationId station in GameBalance.AllStations)
            {
                GetAllocationData(station).workers = Mathf.Clamp(GetAllocationData(station).workers, 0, GameBalance.TotalWorkers);
                GetProgressData(station).progress = Mathf.Clamp(GetProgressData(station).progress, 0f, 0.999f);
            }

            if (GetAssignedWorkerTotal() > GameBalance.TotalWorkers)
            {
                GetAllocationData(StationId.Cardboard).workers = 1;
                GetAllocationData(StationId.Fish).workers = 1;
                GetAllocationData(StationId.Parts).workers = 1;
            }

            foreach (HeroId hero in GameBalance.AllHeroes)
            {
                HeroArmyData army = GetArmy(hero);
                if (army.kittens == null)
                {
                    army.kittens = new List<KittenSlotData>();
                }

                int max = GameBalance.MaxKittens(hero);
                while (army.kittens.Count < max)
                {
                    army.kittens.Add(new KittenSlotData(army.kittens.Count, KittenStatus.Empty));
                }

                if (army.kittens.Count > max)
                {
                    army.kittens.RemoveRange(max, army.kittens.Count - max);
                }
            }

            while (_save.formationSlots.Count < 6) _save.formationSlots.Add(-1);
            if (_save.formationSlots.Count > 6) _save.formationSlots.RemoveRange(6, _save.formationSlots.Count - 6);

            EnsureHeroInFormation(HeroId.CardboardKnight, 3);
            EnsureHeroInFormation(HeroId.FishHunter, 0);
            EnsureHeroInFormation(HeroId.YarnMage, 4);
            _save.globalProductionMultiplier = Mathf.Max(1f, _save.globalProductionMultiplier);
            _save.homeVisualLevel = Mathf.Max(1, _save.homeVisualLevel);
        }

        private void EnsureHeroInFormation(HeroId hero, int fallbackSlot)
        {
            int heroValue = (int)hero;
            if (_save.formationSlots.Contains(heroValue))
            {
                return;
            }

            if (_save.formationSlots[fallbackSlot] < 0)
            {
                _save.formationSlots[fallbackSlot] = heroValue;
                return;
            }

            int empty = _save.formationSlots.IndexOf(-1);
            if (empty >= 0)
            {
                _save.formationSlots[empty] = heroValue;
            }
        }

        private ResourceAmountData GetResourceData(ResourceId id)
        {
            for (int i = 0; i < _save.resources.Count; i++)
            {
                if (_save.resources[i].id == id)
                {
                    return _save.resources[i];
                }
            }

            ResourceAmountData data = new ResourceAmountData(id, 0);
            _save.resources.Add(data);
            return data;
        }

        private StationAllocationData GetAllocationData(StationId id)
        {
            for (int i = 0; i < _save.allocations.Count; i++)
            {
                if (_save.allocations[i].id == id)
                {
                    return _save.allocations[i];
                }
            }

            StationAllocationData data = new StationAllocationData(id, 0);
            _save.allocations.Add(data);
            return data;
        }

        private StationProgressData GetProgressData(StationId id)
        {
            for (int i = 0; i < _save.productionProgress.Count; i++)
            {
                if (_save.productionProgress[i].id == id)
                {
                    return _save.productionProgress[i];
                }
            }

            StationProgressData data = new StationProgressData(id, 0f);
            _save.productionProgress.Add(data);
            return data;
        }

        private void RaiseChanged()
        {
            Action handler = StateChanged;
            if (handler != null)
            {
                handler();
            }
        }

        private void Toast(string message)
        {
            Action<string> handler = ToastRequested;
            if (handler != null)
            {
                handler(message);
            }
        }
    }
}
