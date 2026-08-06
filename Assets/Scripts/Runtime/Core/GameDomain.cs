using System;
using System.Collections.Generic;
using UnityEngine;

namespace Meowblade
{
    public enum ResourceId
    {
        Cardboard = 0,
        DriedFish = 1,
        MysticPart = 2
    }

    public enum StationId
    {
        Cardboard = 0,
        Fish = 1,
        Parts = 2
    }

    public enum HeroId
    {
        CardboardKnight = 0,
        FishHunter = 1,
        YarnMage = 2
    }

    public enum KittenStatus
    {
        Empty = 0,
        Ready = 1,
        Injured = 2
    }

    public enum StageId
    {
        AlleyRaid = 0,
        BoxOverlord = 1
    }

    public enum WorkstationStatus
    {
        Producing = 0,
        NoWorker = 1,
        WaitingStorage = 2
    }

    [Serializable]
    public sealed class ResourceAmountData
    {
        public ResourceId id;
        public int amount;

        public ResourceAmountData(ResourceId resourceId, int value)
        {
            id = resourceId;
            amount = value;
        }
    }

    [Serializable]
    public sealed class StationAllocationData
    {
        public StationId id;
        public int workers;

        public StationAllocationData(StationId stationId, int value)
        {
            id = stationId;
            workers = value;
        }
    }

    [Serializable]
    public sealed class StationProgressData
    {
        public StationId id;
        public float progress;

        public StationProgressData(StationId stationId, float value)
        {
            id = stationId;
            progress = value;
        }
    }

    [Serializable]
    public sealed class KittenSlotData
    {
        public int slotIndex;
        public KittenStatus status;

        public KittenSlotData(int index, KittenStatus value)
        {
            slotIndex = index;
            status = value;
        }
    }

    [Serializable]
    public sealed class HeroArmyData
    {
        public HeroId heroId;
        public List<KittenSlotData> kittens = new List<KittenSlotData>();

        public HeroArmyData(HeroId id, int maxKittens, int readyKittens)
        {
            heroId = id;
            for (int i = 0; i < maxKittens; i++)
            {
                kittens.Add(new KittenSlotData(i, i < readyKittens ? KittenStatus.Ready : KittenStatus.Empty));
            }
        }
    }

    [Serializable]
    public sealed class GameSaveData
    {
        public int saveVersion = 1;
        public long lastSaveUnixSeconds;
        public List<ResourceAmountData> resources = new List<ResourceAmountData>();
        public List<StationAllocationData> allocations = new List<StationAllocationData>();
        public List<StationProgressData> productionProgress = new List<StationProgressData>();
        public List<HeroArmyData> armies = new List<HeroArmyData>();
        public List<int> formationSlots = new List<int>();
        public bool stageOneCleared;
        public bool bossCleared;
        public bool cardboardCapeCrafted;
        public bool cardboardCapeEquipped;
        public float globalProductionMultiplier = 1f;
        public int homeVisualLevel = 1;

        public static GameSaveData CreateDefault()
        {
            GameSaveData data = new GameSaveData();
            data.resources.Add(new ResourceAmountData(ResourceId.Cardboard, 4));
            data.resources.Add(new ResourceAmountData(ResourceId.DriedFish, 4));
            data.resources.Add(new ResourceAmountData(ResourceId.MysticPart, 0));

            data.allocations.Add(new StationAllocationData(StationId.Cardboard, 1));
            data.allocations.Add(new StationAllocationData(StationId.Fish, 1));
            data.allocations.Add(new StationAllocationData(StationId.Parts, 1));

            data.productionProgress.Add(new StationProgressData(StationId.Cardboard, 0f));
            data.productionProgress.Add(new StationProgressData(StationId.Fish, 0f));
            data.productionProgress.Add(new StationProgressData(StationId.Parts, 0f));

            data.armies.Add(new HeroArmyData(HeroId.CardboardKnight, 3, 2));
            data.armies.Add(new HeroArmyData(HeroId.FishHunter, 3, 3));
            data.armies.Add(new HeroArmyData(HeroId.YarnMage, 2, 2));

            // BackTop, FrontTop, BackMiddle, FrontMiddle, BackBottom, FrontBottom.
            data.formationSlots.Add((int)HeroId.FishHunter);
            data.formationSlots.Add(-1);
            data.formationSlots.Add(-1);
            data.formationSlots.Add((int)HeroId.CardboardKnight);
            data.formationSlots.Add((int)HeroId.YarnMage);
            data.formationSlots.Add(-1);
            data.lastSaveUnixSeconds = DateTimeOffset.UtcNow.ToUnixTimeSeconds();
            return data;
        }
    }

    public struct ResourceCost
    {
        public ResourceId Resource;
        public int Amount;

        public ResourceCost(ResourceId resource, int amount)
        {
            Resource = resource;
            Amount = amount;
        }
    }

    public struct CombatStats
    {
        public float MaxHp;
        public float Attack;
        public float Defense;
        public float AttackInterval;
        public float CritChance;
        public float CritMultiplier;
        public float MoveSpeed;
        public float AttackRange;

        public CombatStats(
            float maxHp,
            float attack,
            float defense,
            float attackInterval,
            float critChance,
            float critMultiplier,
            float moveSpeed,
            float attackRange)
        {
            MaxHp = maxHp;
            Attack = attack;
            Defense = defense;
            AttackInterval = attackInterval;
            CritChance = critChance;
            CritMultiplier = critMultiplier;
            MoveSpeed = moveSpeed;
            AttackRange = attackRange;
        }
    }

    public static class GameDisplay
    {
        public const int ReferenceWidth = 1920;
        public const int ReferenceHeight = 1080;
        public const float ReferenceAspect = 16f / 9f;

        public static Vector2 ReferenceResolution
        {
            get { return new Vector2(ReferenceWidth, ReferenceHeight); }
        }
    }

    public static class GameBalance
    {
        public const int TotalWorkers = 3;
        public const float ProductionTickSeconds = 0.2f;
        public const int MaxOfflineSeconds = 1800;
        public const float BossProductionMultiplier = 1.3f;

        public static readonly ResourceCost[] HealKittenCosts =
        {
            new ResourceCost(ResourceId.Cardboard, 2),
            new ResourceCost(ResourceId.DriedFish, 3)
        };

        public static readonly ResourceCost[] RecruitKittenCosts =
        {
            new ResourceCost(ResourceId.Cardboard, 4),
            new ResourceCost(ResourceId.DriedFish, 6)
        };

        public static readonly ResourceCost[] CraftCapeCosts =
        {
            new ResourceCost(ResourceId.Cardboard, 8),
            new ResourceCost(ResourceId.MysticPart, 3)
        };

        public static IEnumerable<ResourceId> AllResources
        {
            get
            {
                yield return ResourceId.Cardboard;
                yield return ResourceId.DriedFish;
                yield return ResourceId.MysticPart;
            }
        }

        public static IEnumerable<StationId> AllStations
        {
            get
            {
                yield return StationId.Cardboard;
                yield return StationId.Fish;
                yield return StationId.Parts;
            }
        }

        public static IEnumerable<HeroId> AllHeroes
        {
            get
            {
                yield return HeroId.CardboardKnight;
                yield return HeroId.FishHunter;
                yield return HeroId.YarnMage;
            }
        }

        public static string ResourceName(ResourceId id)
        {
            switch (id)
            {
                case ResourceId.Cardboard: return "纸板";
                case ResourceId.DriedFish: return "鱼干";
                case ResourceId.MysticPart: return "奇箱零件";
                default: return id.ToString();
            }
        }

        public static string ResourceGlyph(ResourceId id)
        {
            switch (id)
            {
                case ResourceId.Cardboard: return "▣";
                case ResourceId.DriedFish: return "◆";
                case ResourceId.MysticPart: return "✦";
                default: return "●";
            }
        }

        public static Color ResourceColor(ResourceId id)
        {
            switch (id)
            {
                case ResourceId.Cardboard: return new Color(0.78f, 0.55f, 0.31f);
                case ResourceId.DriedFish: return new Color(0.95f, 0.58f, 0.27f);
                case ResourceId.MysticPart: return new Color(0.43f, 0.78f, 0.86f);
                default: return Color.white;
            }
        }

        public static int Capacity(ResourceId id)
        {
            switch (id)
            {
                case ResourceId.Cardboard: return 60;
                case ResourceId.DriedFish: return 50;
                case ResourceId.MysticPart: return 30;
                default: return 0;
            }
        }

        public static ResourceId StationOutput(StationId id)
        {
            switch (id)
            {
                case StationId.Cardboard: return ResourceId.Cardboard;
                case StationId.Fish: return ResourceId.DriedFish;
                case StationId.Parts: return ResourceId.MysticPart;
                default: return ResourceId.Cardboard;
            }
        }

        public static string StationName(StationId id)
        {
            switch (id)
            {
                case StationId.Cardboard: return "纸箱回收角";
                case StationId.Fish: return "小鱼干厨房";
                case StationId.Parts: return "奇箱拆解台";
                default: return id.ToString();
            }
        }

        public static string StationAction(StationId id)
        {
            switch (id)
            {
                case StationId.Cardboard: return "抓纸箱 · 撕胶带 · 压纸板";
                case StationId.Fish: return "烘鱼干 · 推小碗 · 忍住偷吃";
                case StationId.Parts: return "拨齿轮 · 追弹簧 · 拍按钮";
                default: return string.Empty;
            }
        }

        public static float BaseRatePerMinute(StationId id)
        {
            switch (id)
            {
                case StationId.Cardboard: return 12f;
                case StationId.Fish: return 10f;
                case StationId.Parts: return 6f;
                default: return 0f;
            }
        }

        public static string HeroName(HeroId id)
        {
            switch (id)
            {
                case HeroId.CardboardKnight: return "纸箱侠";
                case HeroId.FishHunter: return "小鱼干";
                case HeroId.YarnMage: return "毛线球";
                default: return id.ToString();
            }
        }

        public static string HeroRole(HeroId id)
        {
            switch (id)
            {
                case HeroId.CardboardKnight: return "前排防御 · 嘲讽护盾";
                case HeroId.FishHunter: return "后排单体 · 低血收割";
                case HeroId.YarnMage: return "后排范围 · 减速控制";
                default: return string.Empty;
            }
        }

        public static Color HeroColor(HeroId id)
        {
            switch (id)
            {
                case HeroId.CardboardKnight: return new Color(0.83f, 0.61f, 0.35f);
                case HeroId.FishHunter: return new Color(0.96f, 0.45f, 0.30f);
                case HeroId.YarnMage: return new Color(0.58f, 0.42f, 0.82f);
                default: return Color.gray;
            }
        }

        public static int MaxKittens(HeroId id)
        {
            return id == HeroId.YarnMage ? 2 : 3;
        }

        public static CombatStats HeroStats(HeroId id)
        {
            switch (id)
            {
                case HeroId.CardboardKnight:
                    return new CombatStats(420f, 34f, 32f, 1.3f, 0.05f, 1.5f, 1.35f, 0.85f);
                case HeroId.FishHunter:
                    return new CombatStats(250f, 54f, 12f, 1.0f, 0.15f, 1.7f, 1.25f, 4.6f);
                case HeroId.YarnMage:
                    return new CombatStats(230f, 30f, 14f, 1.2f, 0.05f, 1.5f, 1.2f, 4.3f);
                default:
                    return new CombatStats(100f, 10f, 5f, 1.5f, 0f, 1.5f, 1f, 1f);
            }
        }

        public static CombatStats KittenStats(HeroId owner)
        {
            switch (owner)
            {
                case HeroId.CardboardKnight:
                    return new CombatStats(85f, 15f, 16f, 1.4f, 0.03f, 1.5f, 1.45f, 0.75f);
                case HeroId.FishHunter:
                    return new CombatStats(60f, 22f, 6f, 1.2f, 0.08f, 1.5f, 1.25f, 4.1f);
                case HeroId.YarnMage:
                    return new CombatStats(55f, 12f, 8f, 1.5f, 0.03f, 1.5f, 1.2f, 3.9f);
                default:
                    return new CombatStats(50f, 8f, 4f, 1.5f, 0f, 1.5f, 1f, 1f);
            }
        }

        public static string StageName(StageId stage)
        {
            return stage == StageId.AlleyRaid ? "普通关：纸箱鼠来袭" : "Boss：纸箱小霸王";
        }

        public static string StageHint(StageId stage)
        {
            return stage == StageId.AlleyRaid
                ? "两波纸箱鼠。保持纸箱侠在前排，观察第一场军团战损。"
                : "箱盖重压主要攻击前排。补满小猫、装备披风，并在预警时使用全军钻箱。";
        }

        public static string FormatRate(float value)
        {
            if (Mathf.Abs(value - Mathf.Round(value)) < 0.01f)
            {
                return Mathf.RoundToInt(value).ToString();
            }

            return value.ToString("0.0");
        }
    }
}
