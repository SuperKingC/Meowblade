using System;
using System.Collections.Generic;
using UnityEngine;

namespace Meowblade
{
    public enum BattleEventType
    {
        Message,
        Damage,
        Skill,
        UnitDown,
        Wave,
        Telegraph,
        Command
    }

    public sealed class BattleEvent
    {
        public BattleEventType Type;
        public int SourceUnitId;
        public int TargetUnitId;
        public float Value;
        public string Message;

        public BattleEvent(BattleEventType type, string message, int sourceUnitId, int targetUnitId, float value)
        {
            Type = type;
            Message = message;
            SourceUnitId = sourceUnitId;
            TargetUnitId = targetUnitId;
            Value = value;
        }
    }

    public sealed class InjuredKitten
    {
        public HeroId HeroId;
        public int SlotIndex;

        public InjuredKitten(HeroId heroId, int slotIndex)
        {
            HeroId = heroId;
            SlotIndex = slotIndex;
        }
    }

    public sealed class BattleResult
    {
        public StageId StageId;
        public bool Victory;
        public float ElapsedSeconds;
        public string FailureReason;
        public List<InjuredKitten> InjuredKittens = new List<InjuredKitten>();
    }

    public sealed class BattleUnit
    {
        public int Id;
        public string DisplayName;
        public bool IsPlayer;
        public bool IsHero;
        public bool IsKitten;
        public bool IsBoss;
        public HeroId OwnerHeroId;
        public int KittenSlotIndex = -1;
        public string EnemyKind;
        public CombatStats Stats;
        public float Hp;
        public float Shield;
        public Vector2 Position;
        public bool Alive = true;
        public bool Retreated;
        public float AttackTimer;
        public float SkillTimer;
        public float SlowTimer;
        public float SlowMultiplier = 1f;
        public float CommandBuffTimer;
        public float TauntTimer;
        public int TauntedByUnitId = -1;
        public float DownTime = -1f;

        public float Health01
        {
            get { return Stats.MaxHp <= 0f ? 0f : Mathf.Clamp01(Hp / Stats.MaxHp); }
        }

        public float EffectiveMoveSpeed
        {
            get { return Stats.MoveSpeed * (SlowTimer > 0f ? SlowMultiplier : 1f); }
        }
    }

    public sealed class BattleSimulation
    {
        private readonly GameSession _session;
        private readonly StageId _stageId;
        private readonly System.Random _random;
        private readonly List<BattleUnit> _units = new List<BattleUnit>();
        private readonly List<BattleEvent> _events = new List<BattleEvent>();
        private readonly Dictionary<HeroId, float> _heroDownTimes = new Dictionary<HeroId, float>();

        private int _nextUnitId = 1;
        private int _currentWave;
        private float _waveDelay;
        private bool _bossSummonedAdds;
        private float _bossSlamTelegraph;
        private bool _bossSlamPending;
        private BattleResult _result;

        public IReadOnlyList<BattleUnit> Units { get { return _units; } }
        public StageId StageId { get { return _stageId; } }
        public float ElapsedSeconds { get; private set; }
        public float TimeLimit { get; private set; }
        public float CommandEnergy { get; private set; }
        public bool CommandUsed { get; private set; }
        public bool IsFinished { get { return _result != null; } }
        public BattleResult Result { get { return _result; } }
        public float BossSlamTelegraphRemaining { get { return _bossSlamTelegraph; } }
        public int CurrentWave { get { return _currentWave; } }
        public int TotalWaves { get { return _stageId == StageId.AlleyRaid ? 2 : 1; } }

        public BattleSimulation(GameSession session, StageId stageId)
        {
            _session = session;
            _stageId = stageId;
            _random = new System.Random(7301 + (int)stageId * 101);
            TimeLimit = stageId == StageId.AlleyRaid ? 45f : 60f;

            SpawnPlayerFormation();
            if (_stageId == StageId.AlleyRaid)
            {
                SpawnAlleyWaveOne();
            }
            else
            {
                SpawnBoss();
            }
        }

        public void Tick(float deltaTime)
        {
            if (IsFinished || deltaTime <= 0f)
            {
                return;
            }

            ElapsedSeconds += deltaTime;
            if (ElapsedSeconds >= TimeLimit)
            {
                Finish(false, "战斗超时：输出不足");
                return;
            }

            TickWaveFlow(deltaTime);
            TickBuffs(deltaTime);
            TickBossSpecials(deltaTime);

            for (int i = 0; i < _units.Count; i++)
            {
                BattleUnit unit = _units[i];
                if (!unit.Alive)
                {
                    continue;
                }

                unit.AttackTimer -= deltaTime;
                unit.SkillTimer -= deltaTime;

                if (unit.IsHero && TryUseHeroSkill(unit))
                {
                    continue;
                }

                BattleUnit target = FindTarget(unit);
                if (target == null)
                {
                    continue;
                }

                float distance = Vector2.Distance(unit.Position, target.Position);
                if (distance > unit.Stats.AttackRange)
                {
                    Vector2 direction = (target.Position - unit.Position).normalized;
                    unit.Position += direction * unit.EffectiveMoveSpeed * deltaTime;
                    unit.Position = new Vector2(Mathf.Clamp(unit.Position.x, -6.5f, 6.5f), Mathf.Clamp(unit.Position.y, -2.7f, 2.7f));
                    continue;
                }

                if (unit.AttackTimer <= 0f)
                {
                    unit.AttackTimer = Mathf.Max(0.2f, unit.Stats.AttackInterval * (unit.SlowTimer > 0f ? 1.2f : 1f));
                    ApplyDamage(unit, target, 1f, true);
                }
            }

            CheckBattleEnd();
        }

        public bool UseCommand()
        {
            if (IsFinished || CommandUsed || CommandEnergy < 99.99f)
            {
                return false;
            }

            CommandUsed = true;
            CommandEnergy = 0f;
            for (int i = 0; i < _units.Count; i++)
            {
                BattleUnit unit = _units[i];
                if (unit.Alive && unit.IsPlayer)
                {
                    unit.CommandBuffTimer = Mathf.Max(unit.CommandBuffTimer, 4f);
                }
            }

            AddEvent(BattleEventType.Command, "全军钻箱！4 秒内全军减伤 35%", -1, -1, 0f);
            return true;
        }

        public BattleUnit GetUnit(int unitId)
        {
            for (int i = 0; i < _units.Count; i++)
            {
                if (_units[i].Id == unitId)
                {
                    return _units[i];
                }
            }

            return null;
        }

        public BattleUnit GetBoss()
        {
            for (int i = 0; i < _units.Count; i++)
            {
                if (_units[i].IsBoss)
                {
                    return _units[i];
                }
            }

            return null;
        }

        public BattleUnit GetHero(HeroId heroId)
        {
            for (int i = 0; i < _units.Count; i++)
            {
                if (_units[i].IsHero && _units[i].OwnerHeroId == heroId)
                {
                    return _units[i];
                }
            }

            return null;
        }

        public List<BattleEvent> DrainEvents()
        {
            List<BattleEvent> result = new List<BattleEvent>(_events);
            _events.Clear();
            return result;
        }

        private void SpawnPlayerFormation()
        {
            for (int slot = 0; slot < 6; slot++)
            {
                int heroValue = _session.GetFormationHero(slot);
                if (heroValue < 0)
                {
                    continue;
                }

                HeroId heroId = (HeroId)heroValue;
                Vector2 heroPosition = FormationPosition(slot);
                CombatStats heroStats = GameBalance.HeroStats(heroId);
                BattleUnit hero = CreateUnit(
                    GameBalance.HeroName(heroId),
                    true,
                    heroId,
                    true,
                    false,
                    false,
                    -1,
                    null,
                    heroStats,
                    heroPosition);
                hero.SkillTimer = heroId == HeroId.CardboardKnight ? 2.5f : heroId == HeroId.FishHunter ? 3f : 4f;

                HeroArmyData army = _session.GetArmy(heroId);
                int visualIndex = 0;
                for (int i = 0; i < army.kittens.Count; i++)
                {
                    if (army.kittens[i].status != KittenStatus.Ready)
                    {
                        continue;
                    }

                    float yOffset = (visualIndex % 2 == 0 ? 0.42f : -0.42f) + (visualIndex / 2) * 0.2f;
                    float xOffset = slot % 2 == 0 ? -0.55f : -0.35f;
                    Vector2 kittenPosition = heroPosition + new Vector2(xOffset, yOffset);
                    CreateUnit(
                        GameBalance.HeroName(heroId) + "小队" + (i + 1),
                        true,
                        heroId,
                        false,
                        true,
                        false,
                        army.kittens[i].slotIndex,
                        null,
                        GameBalance.KittenStats(heroId),
                        kittenPosition);
                    visualIndex++;
                }
            }
        }

        private void SpawnAlleyWaveOne()
        {
            _currentWave = 1;
            SpawnMouse("纸箱鼠", new Vector2(4.8f, 1.7f), 170f, 24f, 8f);
            SpawnMouse("纸箱鼠", new Vector2(5.3f, 0f), 170f, 24f, 8f);
            SpawnMouse("纸箱鼠", new Vector2(4.8f, -1.7f), 170f, 24f, 8f);
            AddEvent(BattleEventType.Wave, "第一波纸箱鼠出现！", -1, -1, 1f);
        }

        private void SpawnAlleyWaveTwo()
        {
            _currentWave = 2;
            SpawnMouse("纸箱鼠", new Vector2(5.2f, 1.5f), 190f, 26f, 9f);
            SpawnMouse("纸箱鼠", new Vector2(5.2f, -1.5f), 190f, 26f, 9f);
            CombatStats tapeStats = new CombatStats(300f, 30f, 14f, 1.5f, 0.04f, 1.5f, 1.05f, 0.8f);
            CreateUnit("胶带鼠", false, HeroId.CardboardKnight, false, false, false, -1, "TapeMouse", tapeStats, new Vector2(5.8f, 0f));
            AddEvent(BattleEventType.Wave, "第二波：胶带鼠带队冲进来了！", -1, -1, 2f);
        }

        private void SpawnMouse(string name, Vector2 position, float hp, float attack, float defense)
        {
            CombatStats stats = new CombatStats(hp, attack, defense, 1.3f, 0.04f, 1.5f, 1.4f, 0.75f);
            CreateUnit(name, false, HeroId.CardboardKnight, false, false, false, -1, "Mouse", stats, position);
        }

        private void SpawnBoss()
        {
            _currentWave = 1;
            CombatStats bossStats = new CombatStats(3600f, 48f, 18f, 1.6f, 0.05f, 1.5f, 0.85f, 1.05f);
            BattleUnit boss = CreateUnit("纸箱小霸王", false, HeroId.CardboardKnight, false, false, true, -1, "Boss", bossStats, new Vector2(4.5f, 0f));
            boss.SkillTimer = 7f;
            AddEvent(BattleEventType.Wave, "纸箱小霸王登场！注意箱盖重压。", boss.Id, -1, 1f);
        }

        private BattleUnit CreateUnit(
            string displayName,
            bool isPlayer,
            HeroId ownerHeroId,
            bool isHero,
            bool isKitten,
            bool isBoss,
            int kittenSlot,
            string enemyKind,
            CombatStats stats,
            Vector2 position)
        {
            BattleUnit unit = new BattleUnit();
            unit.Id = _nextUnitId++;
            unit.DisplayName = displayName;
            unit.IsPlayer = isPlayer;
            unit.OwnerHeroId = ownerHeroId;
            unit.IsHero = isHero;
            unit.IsKitten = isKitten;
            unit.IsBoss = isBoss;
            unit.KittenSlotIndex = kittenSlot;
            unit.EnemyKind = enemyKind;
            unit.Stats = stats;
            unit.Hp = stats.MaxHp;
            unit.Position = position;
            unit.AttackTimer = (float)_random.NextDouble() * 0.5f;
            _units.Add(unit);
            return unit;
        }

        private static Vector2 FormationPosition(int slot)
        {
            int row = slot / 2;
            bool front = slot % 2 == 1;
            float y = row == 0 ? 2f : row == 1 ? 0f : -2f;
            float x = front ? -2.15f : -4.35f;
            return new Vector2(x, y);
        }

        private void TickWaveFlow(float deltaTime)
        {
            if (_stageId != StageId.AlleyRaid || IsFinished)
            {
                return;
            }

            if (HasAliveEnemy())
            {
                _waveDelay = 0f;
                return;
            }

            if (_currentWave == 1)
            {
                _waveDelay += deltaTime;
                if (_waveDelay >= 1.2f)
                {
                    _waveDelay = 0f;
                    SpawnAlleyWaveTwo();
                }
            }
        }

        private void TickBuffs(float deltaTime)
        {
            for (int i = 0; i < _units.Count; i++)
            {
                BattleUnit unit = _units[i];
                if (!unit.Alive)
                {
                    continue;
                }

                unit.CommandBuffTimer = Mathf.Max(0f, unit.CommandBuffTimer - deltaTime);
                unit.TauntTimer = Mathf.Max(0f, unit.TauntTimer - deltaTime);
                if (unit.TauntTimer <= 0f)
                {
                    unit.TauntedByUnitId = -1;
                }

                unit.SlowTimer = Mathf.Max(0f, unit.SlowTimer - deltaTime);
                if (unit.SlowTimer <= 0f)
                {
                    unit.SlowMultiplier = 1f;
                }
            }
        }

        private void TickBossSpecials(float deltaTime)
        {
            BattleUnit boss = GetBoss();
            if (boss == null || !boss.Alive)
            {
                return;
            }

            if (!_bossSummonedAdds && boss.Health01 <= 0.5f)
            {
                _bossSummonedAdds = true;
                SpawnMouse("增援纸箱鼠", new Vector2(5.6f, 2.2f), 220f, 27f, 9f);
                SpawnMouse("增援纸箱鼠", new Vector2(5.6f, -2.2f), 220f, 27f, 9f);
                AddEvent(BattleEventType.Skill, "纸箱小霸王呼叫了两只增援！", boss.Id, -1, 0f);
            }

            if (_bossSlamPending)
            {
                _bossSlamTelegraph -= deltaTime;
                if (_bossSlamTelegraph <= 0f)
                {
                    _bossSlamPending = false;
                    _bossSlamTelegraph = 0f;
                    PerformBossSlam(boss);
                }

                return;
            }

            if (boss.SkillTimer <= 0f)
            {
                boss.SkillTimer = 10f;
                _bossSlamPending = true;
                _bossSlamTelegraph = 1.5f;
                AddEvent(BattleEventType.Telegraph, "箱盖重压预警！现在使用全军钻箱。", boss.Id, -1, 1.5f);
            }
        }

        private void PerformBossSlam(BattleUnit boss)
        {
            AddEvent(BattleEventType.Skill, "纸箱小霸王释放箱盖重压！", boss.Id, -1, 0f);
            List<BattleUnit> targets = new List<BattleUnit>();
            for (int i = 0; i < _units.Count; i++)
            {
                BattleUnit unit = _units[i];
                if (!unit.Alive || !unit.IsPlayer)
                {
                    continue;
                }

                bool front = unit.Position.x > -3.2f;
                float coefficient = front ? 1.8f : 0.72f;
                if (unit.IsKitten)
                {
                    coefficient *= 1.1f;
                }

                ApplyDamage(boss, unit, coefficient, false);
                targets.Add(unit);
            }
        }

        private bool TryUseHeroSkill(BattleUnit hero)
        {
            if (hero.SkillTimer > 0f || !hero.Alive)
            {
                return false;
            }

            if (hero.OwnerHeroId == HeroId.CardboardKnight)
            {
                hero.SkillTimer = 8f;
                hero.Shield += hero.Stats.MaxHp * 0.25f;
                int taunted = 0;
                for (int i = 0; i < _units.Count && taunted < 2; i++)
                {
                    BattleUnit enemy = _units[i];
                    if (enemy.Alive && !enemy.IsPlayer && Vector2.Distance(enemy.Position, hero.Position) <= 4f)
                    {
                        enemy.TauntedByUnitId = hero.Id;
                        enemy.TauntTimer = 3f;
                        taunted++;
                    }
                }

                AddEvent(BattleEventType.Skill, "纸箱侠嘲讽敌人并撑起纸箱护盾！", hero.Id, -1, hero.Shield);
                return true;
            }

            if (hero.OwnerHeroId == HeroId.FishHunter)
            {
                BattleUnit target = FindLowestHealthEnemy();
                if (target == null)
                {
                    return false;
                }

                hero.SkillTimer = 6f;
                ApplyDamage(hero, target, 0.9f, true);
                if (target.Alive)
                {
                    float secondCoefficient = target.Health01 < 0.3f ? 1.35f : 0.9f;
                    ApplyDamage(hero, target, secondCoefficient, true);
                }

                AddEvent(BattleEventType.Skill, "小鱼干连续投出双鱼骨！", hero.Id, target.Id, 0f);
                return true;
            }

            if (hero.OwnerHeroId == HeroId.YarnMage)
            {
                BattleUnit center = FindBestAreaTarget();
                if (center == null)
                {
                    return false;
                }

                hero.SkillTimer = 9f;
                for (int i = 0; i < _units.Count; i++)
                {
                    BattleUnit enemy = _units[i];
                    if (enemy.Alive && !enemy.IsPlayer && Vector2.Distance(enemy.Position, center.Position) <= 1.65f)
                    {
                        ApplyDamage(hero, enemy, 1f, false);
                        enemy.SlowTimer = 3f;
                        enemy.SlowMultiplier = 0.7f;
                    }
                }

                AddEvent(BattleEventType.Skill, "毛线球释放毛线缠绕，敌人被减速！", hero.Id, center.Id, 0f);
                return true;
            }

            return false;
        }

        private BattleUnit FindTarget(BattleUnit attacker)
        {
            if (attacker.TauntTimer > 0f && attacker.TauntedByUnitId >= 0)
            {
                BattleUnit taunter = GetUnit(attacker.TauntedByUnitId);
                if (taunter != null && taunter.Alive)
                {
                    return taunter;
                }
            }

            BattleUnit best = null;
            float bestScore = float.MaxValue;
            for (int i = 0; i < _units.Count; i++)
            {
                BattleUnit candidate = _units[i];
                if (!candidate.Alive || candidate.IsPlayer == attacker.IsPlayer)
                {
                    continue;
                }

                float distance = Vector2.Distance(attacker.Position, candidate.Position);
                float score = distance;

                if (!attacker.IsPlayer && attacker.Stats.AttackRange < 1.5f)
                {
                    bool candidateFront = candidate.Position.x > -3.2f;
                    if (!candidateFront && HasAlivePlayerFrontline())
                    {
                        score += 20f;
                    }
                }

                if (attacker.IsPlayer && attacker.OwnerHeroId == HeroId.CardboardKnight)
                {
                    bool threateningBackline = candidate.Position.x < -0.8f;
                    if (threateningBackline)
                    {
                        score -= 3f;
                    }
                }

                if (score < bestScore)
                {
                    bestScore = score;
                    best = candidate;
                }
            }

            return best;
        }

        private BattleUnit FindLowestHealthEnemy()
        {
            BattleUnit best = null;
            float bestHealth = float.MaxValue;
            for (int i = 0; i < _units.Count; i++)
            {
                BattleUnit unit = _units[i];
                if (unit.Alive && !unit.IsPlayer && unit.Health01 < bestHealth)
                {
                    best = unit;
                    bestHealth = unit.Health01;
                }
            }

            return best;
        }

        private BattleUnit FindBestAreaTarget()
        {
            BattleUnit best = null;
            int bestCount = -1;
            for (int i = 0; i < _units.Count; i++)
            {
                BattleUnit candidate = _units[i];
                if (!candidate.Alive || candidate.IsPlayer)
                {
                    continue;
                }

                int count = 0;
                for (int j = 0; j < _units.Count; j++)
                {
                    BattleUnit other = _units[j];
                    if (other.Alive && !other.IsPlayer && Vector2.Distance(candidate.Position, other.Position) <= 1.65f)
                    {
                        count++;
                    }
                }

                if (count > bestCount || (count == bestCount && candidate.IsBoss))
                {
                    best = candidate;
                    bestCount = count;
                }
            }

            return best;
        }

        private void ApplyDamage(BattleUnit attacker, BattleUnit defender, float coefficient, bool canCrit)
        {
            if (attacker == null || defender == null || !attacker.Alive || !defender.Alive)
            {
                return;
            }

            float damage = Mathf.Max(1f, attacker.Stats.Attack * coefficient - defender.Stats.Defense * 0.45f);
            bool critical = canCrit && _random.NextDouble() < attacker.Stats.CritChance;
            if (critical)
            {
                damage *= attacker.Stats.CritMultiplier;
            }

            damage *= Mathf.Lerp(0.95f, 1.05f, (float)_random.NextDouble());
            if (defender.CommandBuffTimer > 0f)
            {
                damage *= 0.65f;
            }

            if (defender.IsPlayer && defender.OwnerHeroId == HeroId.CardboardKnight && _session.SaveData.cardboardCapeEquipped)
            {
                damage *= 0.8f;
            }

            float remainingDamage = damage;
            if (defender.Shield > 0f)
            {
                float absorbed = Mathf.Min(defender.Shield, remainingDamage);
                defender.Shield -= absorbed;
                remainingDamage -= absorbed;
            }

            if (remainingDamage > 0f)
            {
                defender.Hp = Mathf.Max(0f, defender.Hp - remainingDamage);
            }

            float energyDamage = damage;
            if (attacker.IsPlayer)
            {
                CommandEnergy = Mathf.Min(100f, CommandEnergy + energyDamage * 0.05f);
            }

            if (defender.IsPlayer)
            {
                CommandEnergy = Mathf.Min(100f, CommandEnergy + energyDamage * 0.10f);
            }

            string critText = critical ? " 暴击" : string.Empty;
            AddEvent(BattleEventType.Damage, critText, attacker.Id, defender.Id, damage);

            if (defender.Hp <= 0f)
            {
                DefeatUnit(defender);
            }
        }

        private void DefeatUnit(BattleUnit unit)
        {
            if (!unit.Alive)
            {
                return;
            }

            unit.Alive = false;
            unit.DownTime = ElapsedSeconds;
            AddEvent(BattleEventType.UnitDown,
                unit.IsKitten ? unit.DisplayName + "受伤，钻进纸箱撤退" : unit.DisplayName + "撤退",
                unit.Id,
                -1,
                0f);

            if (unit.IsHero)
            {
                _heroDownTimes[unit.OwnerHeroId] = ElapsedSeconds;
                for (int i = 0; i < _units.Count; i++)
                {
                    BattleUnit member = _units[i];
                    if (member.Alive && member.IsPlayer && member.IsKitten && member.OwnerHeroId == unit.OwnerHeroId)
                    {
                        member.Alive = false;
                        member.Retreated = true;
                        member.DownTime = ElapsedSeconds;
                    }
                }
            }
        }

        private void CheckBattleEnd()
        {
            if (!HasAlivePlayerHero())
            {
                Finish(false, BuildFailureReason());
                return;
            }

            if (_stageId == StageId.AlleyRaid)
            {
                if (_currentWave >= 2 && !HasAliveEnemy())
                {
                    Finish(true, string.Empty);
                }
            }
            else
            {
                BattleUnit boss = GetBoss();
                if (boss != null && !boss.Alive)
                {
                    Finish(true, string.Empty);
                }
            }
        }

        private string BuildFailureReason()
        {
            int readyTotal = 0;
            foreach (HeroId hero in GameBalance.AllHeroes)
            {
                readyTotal += _session.GetKittenCount(hero, KittenStatus.Ready);
            }

            if (readyTotal < 8)
            {
                return "军团编制不完整：回猫窝治疗或补员";
            }

            if (_stageId == StageId.BoxOverlord && !_session.SaveData.cardboardCapeEquipped)
            {
                return "前排承伤不足：制作并装备纸箱侠披风";
            }

            float cardboardDown;
            if (_heroDownTimes.TryGetValue(HeroId.CardboardKnight, out cardboardDown) && cardboardDown < 20f)
            {
                return "前排过早撤退：把纸箱侠放前排并保护它";
            }

            if (_stageId == StageId.BoxOverlord && !CommandUsed)
            {
                return "没有使用军团号令：在箱盖重压预警时全军钻箱";
            }

            return "阵型被突破：调整前后排后再试一次";
        }

        private void Finish(bool victory, string failureReason)
        {
            if (IsFinished)
            {
                return;
            }

            BattleResult result = new BattleResult();
            result.StageId = _stageId;
            result.Victory = victory;
            result.ElapsedSeconds = ElapsedSeconds;
            result.FailureReason = failureReason;

            if (victory)
            {
                for (int i = 0; i < _units.Count; i++)
                {
                    BattleUnit unit = _units[i];
                    if (unit.IsPlayer && unit.IsKitten && !unit.Alive && !unit.Retreated)
                    {
                        result.InjuredKittens.Add(new InjuredKitten(unit.OwnerHeroId, unit.KittenSlotIndex));
                    }
                }
            }

            _result = result;
            AddEvent(BattleEventType.Message, victory ? "战斗胜利！" : "挑战失败", -1, -1, 0f);
        }

        private bool HasAliveEnemy()
        {
            for (int i = 0; i < _units.Count; i++)
            {
                if (_units[i].Alive && !_units[i].IsPlayer)
                {
                    return true;
                }
            }

            return false;
        }

        private bool HasAlivePlayerHero()
        {
            for (int i = 0; i < _units.Count; i++)
            {
                if (_units[i].Alive && _units[i].IsPlayer && _units[i].IsHero)
                {
                    return true;
                }
            }

            return false;
        }

        private bool HasAlivePlayerFrontline()
        {
            for (int i = 0; i < _units.Count; i++)
            {
                BattleUnit unit = _units[i];
                if (unit.Alive && unit.IsPlayer && unit.Position.x > -3.2f)
                {
                    return true;
                }
            }

            return false;
        }

        private void AddEvent(BattleEventType type, string message, int source, int target, float value)
        {
            _events.Add(new BattleEvent(type, message, source, target, value));
        }
    }
}
