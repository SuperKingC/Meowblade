using System;
using System.Collections.Generic;
using System.Linq;
using Assets.Scripts.UI;
using GameDataEditor;
using GameMaths;
using Shift.Legion.ClientApi.Protocol.Modules.LegendItem.Models;
using Shift.Legion.ClientApi.Protocol.UserAction;
using Shift.Legion.Common.Helpers;
using Shift.Legion.Common.Managers;
using Shift.Legion.Common.Models.LegendItem;
using Shift.Legion.Common.Sources.Enums;

namespace Shift.Legion.Common.Models;

public class Soldier
{
	public const float BreakthroughGrowthFactor = 1.2f;

	public const float EvoluteGrowthFactor = 0.38f;

	protected static Dictionary<string, string> _attributeNameDictionary;

	protected float _attack;

	protected float _attackDistance;

	protected float _attackGrowUp;

	protected float _attackSpeed;

	protected float _baseAttrFactor;

	protected List<SoldierBreakthroughData> _breakthroughRequirement;

	protected float _criticalChance;

	protected float _criticalDamageModifier;

	protected float _defense;

	protected float _defenseGrowUp;

	protected float _evasionRate;

	protected Dictionary<string, float> _fixedBonusAttr;

	protected float _health;

	protected float _healthGrowUp;

	protected float _hitRate;

	protected float _moveSpeed;

	protected float _percentDamageSettlement;

	protected float _fixedDamageSettlement;

	protected float _percentHurtSettlement;

	protected float _fixedHurtSettlement;

	protected float _percentDamageReflect;

	protected float _fixedDamageReflect;

	protected float _percentCureSettlement;

	protected float _fixedCureSettlement;

	protected float _percentRecoverSettlement;

	protected float _fixedRecoverSettlement;

	protected Dictionary<string, float> _percentBonusAttr;

	public int ArmorType;

	public int DamageType;

	public GDESoldierData Data;

	public string Id;

	private SoldierInfoEvo infoEvoData;

	public string ItemId;

	public string prefabName;

	public int Rarity;

	public float ScaleRatio;

	public string Skin;

	public string Faction;

	protected readonly GameManagers _managers;

	private int _CombatPower = -1;

	private string _featureAbility;

	private int[] _featureAbilityUnlockLevels;

	private bool _isCacheDirty_HasNewPotentialProgress = true;

	private bool _Cache_HasNewPotentialProgress;

	public const string AiTypeMelee = "melee";

	public const string AiTypeRanged = "ranged";

	public List<string> Tags => GameEntityData.GetEntityTags(Data.Key);

	public SoldierOccupation Occupation
	{
		get
		{
			List<string> tags = Tags;
			SoldierOccupation[] all = SoldierOccupation.All;
			foreach (SoldierOccupation soldierOccupation in all)
			{
				if (tags.Contains(soldierOccupation.Tag))
				{
					return soldierOccupation;
				}
			}
			return null;
		}
	}

	public virtual int EvoLevel
	{
		get
		{
			return _managers.UserArchiveManager.GetSoldierEvolutionLevel(Id);
		}
		set
		{
			throw new NotImplementedException();
		}
	}

	public virtual int Level
	{
		get
		{
			return _managers.UserArchiveManager.GetSoldierLevel(Id);
		}
		set
		{
			throw new NotImplementedException();
		}
	}

	public virtual int PotentialLevel
	{
		get
		{
			if (Data.IsPlayer)
			{
				return _managers.UserArchiveManager.GetSoldierPotentialLevel(Id);
			}
			return Data.PotentialLevel;
		}
		set
		{
			throw new NotImplementedException();
		}
	}

	public int CurrentSpineSkinId => (PotentialLevel <= 8) ? ((PotentialLevel + 2) / 2) : 6;

	public virtual List<int> PotentialProgress => _managers.UserArchiveManager.GetSoldierPotentialProgress(Id);

	public int NextEvoLevel => ((EvoLevel <= 0) ? 1 : EvoLevel) + 1;

	public SoldierEvoData EvoData
	{
		get
		{
			if (ConfigDataManager.SoldierEvoData.TryGetValue(Id, out var value) && value.TryGetValue(NextEvoLevel, out var value2))
			{
				return value2;
			}
			return null;
		}
	}

	public int NextLevel => ((Level <= 0) ? 1 : Level) + 1;

	public int NextPotentialLevel => PotentialLevel + 1;

	public SoldierPotentialData Potential => ConfigDataManager.GetSoldierPotential(Id, PotentialLevel);

	public SoldierPotentialData NextLevelPotential => ConfigDataManager.GetSoldierPotential(Id, NextPotentialLevel);

	public string AiType => Data.AiType;

	public string PortraitPath => $"Image/Item/{Id}_{EvoLevel}";

	public int MaxLevel => _managers.UserArchiveManager.GetSoldierMaxLevel(Id);

	public SoldierInfoEvo InfoEvoData => infoEvoData ?? (infoEvoData = new SoldierInfoEvo("Soldier" + Id));

	public string Name
	{
		get
		{
			if (InfoEvoData.NameList.Count > 0 && EvoLevel > 0 && InfoEvoData.NameList.Count >= EvoLevel)
			{
				return InfoEvoData.NameList[EvoLevel - 1];
			}
			return Data.Name;
		}
	}

	public string Desc
	{
		get
		{
			if (InfoEvoData.DescList.Count > 0 && EvoLevel > 0 && InfoEvoData.DescList.Count >= EvoLevel)
			{
				return InfoEvoData.DescList[EvoLevel - 1];
			}
			return Data.Desc;
		}
	}

	public Dictionary<string, float> FixedBonusAttr
	{
		get
		{
			if (_fixedBonusAttr == null)
			{
				EnsureFixedBonus();
			}
			return _fixedBonusAttr;
		}
	}

	public Dictionary<string, float> PercentBonusAttr
	{
		get
		{
			if (_percentBonusAttr == null)
			{
				EnsurePercentBonus();
			}
			return _percentBonusAttr;
		}
	}

	public float HealthGrowUp
	{
		get
		{
			if (Math.Abs(_healthGrowUp) < float.Epsilon)
			{
				if (Potential == null || !Potential.Attributes.ContainsKey("EA12"))
				{
					_healthGrowUp = Data.HealthPerLevel;
				}
				else
				{
					_healthGrowUp = Potential.Attributes["EA12"];
				}
			}
			return _healthGrowUp;
		}
	}

	public float Health
	{
		get
		{
			if (Math.Abs(_health) < float.Epsilon)
			{
				if (Potential == null || !Potential.Attributes.ContainsKey("EA01"))
				{
					_health = Data.Health;
				}
				else
				{
					_health = Potential.Attributes["EA01"];
				}
				float num = 0f;
				if (FixedBonusAttr.ContainsKey("EA22"))
				{
					num += FixedBonusAttr["EA22"];
				}
				float num2 = 1f;
				if (PercentBonusAttr.ContainsKey("EA22"))
				{
					num2 += PercentBonusAttr["EA22"];
				}
				_health = _health * num2 + num + HealthGrowUp * (float)(Level - 1);
				float num3 = 1f;
				if (PercentBonusAttr.ContainsKey("EA01"))
				{
					num3 += PercentBonusAttr["EA01"];
				}
				float num4 = 0f;
				if (FixedBonusAttr.ContainsKey("EA01"))
				{
					num4 += FixedBonusAttr["EA01"];
				}
				_health = _health * num3 + num4;
			}
			return _health;
		}
	}

	public float AttackGrowUp
	{
		get
		{
			if (Math.Abs(_attackGrowUp) < float.Epsilon)
			{
				if (Potential == null || !Potential.Attributes.ContainsKey("EA13"))
				{
					_attackGrowUp = Data.AttackPerLevel;
				}
				else
				{
					_attackGrowUp = Potential.Attributes["EA13"];
				}
			}
			return _attackGrowUp;
		}
	}

	public float Attack
	{
		get
		{
			if (Math.Abs(_attack) < float.Epsilon)
			{
				if (Potential == null || !Potential.Attributes.ContainsKey("EA02"))
				{
					_attack = Data.Attack;
				}
				else
				{
					_attack = Potential.Attributes["EA02"];
				}
				float num = 0f;
				if (FixedBonusAttr.ContainsKey("EA18"))
				{
					num += FixedBonusAttr["EA18"];
				}
				float num2 = 1f;
				if (PercentBonusAttr.ContainsKey("EA18"))
				{
					num2 += PercentBonusAttr["EA18"];
				}
				_attack = _attack * num2 + num + AttackGrowUp * (float)(Level - 1);
				float num3 = 1f;
				if (PercentBonusAttr.ContainsKey("EA02"))
				{
					num3 += PercentBonusAttr["EA02"];
				}
				float num4 = 0f;
				if (FixedBonusAttr.ContainsKey("EA02"))
				{
					num4 += FixedBonusAttr["EA02"];
				}
				_attack = _attack * num3 + num4;
			}
			return _attack;
		}
	}

	public float DefenseGrowUp
	{
		get
		{
			if (Math.Abs(_defenseGrowUp) < float.Epsilon)
			{
				if (Potential == null || !Potential.Attributes.ContainsKey("EA14"))
				{
					_defenseGrowUp = Data.DefensePerLevel;
				}
				else
				{
					_defenseGrowUp = Potential.Attributes["EA14"];
				}
			}
			return _defenseGrowUp;
		}
	}

	public float Defense
	{
		get
		{
			if (Math.Abs(_defense) < float.Epsilon)
			{
				if (Potential == null || !Potential.Attributes.ContainsKey("EA03"))
				{
					_defense = Data.Defense;
				}
				else
				{
					_defense = Potential.Attributes["EA03"];
				}
				float num = 0f;
				if (FixedBonusAttr.ContainsKey("EA20"))
				{
					num += FixedBonusAttr["EA20"];
				}
				float num2 = 1f;
				if (PercentBonusAttr.ContainsKey("EA20"))
				{
					num2 += PercentBonusAttr["EA20"];
				}
				_defense = _defense * num2 + num + DefenseGrowUp * (float)(Level - 1);
				float num3 = 1f;
				if (PercentBonusAttr.ContainsKey("EA03"))
				{
					num3 += PercentBonusAttr["EA03"];
				}
				float num4 = 0f;
				if (FixedBonusAttr.ContainsKey("EA03"))
				{
					num4 += FixedBonusAttr["EA03"];
				}
				_defense = _defense * num3 + num4;
			}
			return _defense;
		}
	}

	public float AttackDistance
	{
		get
		{
			if (Math.Abs(_attackDistance) < float.Epsilon)
			{
				if (Potential == null || !Potential.Attributes.ContainsKey("EA15"))
				{
					_attackDistance = Data.AttackDistance;
				}
				else
				{
					_attackDistance = Potential.Attributes["EA15"];
				}
				float num = 1f;
				if (PercentBonusAttr.ContainsKey("EA15"))
				{
					num += PercentBonusAttr["EA15"];
				}
				float num2 = 0f;
				if (FixedBonusAttr.ContainsKey("EA15"))
				{
					num2 += FixedBonusAttr["EA15"];
				}
				_attackDistance = _attackDistance * num + num2;
			}
			return _attackDistance;
		}
	}

	public float CriticalChance
	{
		get
		{
			float num = 1f;
			if (Math.Abs(_criticalChance) < float.Epsilon)
			{
				if (Potential == null || !Potential.Attributes.ContainsKey("EA04"))
				{
					_criticalChance = Data.CriticalChance;
				}
				else
				{
					_criticalChance = Potential.Attributes["EA04"];
				}
				if (PercentBonusAttr.ContainsKey("EA04"))
				{
					num += PercentBonusAttr["EA04"];
				}
				float num2 = 0f;
				if (FixedBonusAttr.ContainsKey("EA04"))
				{
					num2 += FixedBonusAttr["EA04"];
				}
				_criticalChance = _criticalChance * num + num2;
			}
			return _criticalChance;
		}
	}

	public float CriticalDamageModifier
	{
		get
		{
			float num = 1f;
			if (Math.Abs(_criticalDamageModifier) < float.Epsilon)
			{
				if (Potential == null || !Potential.Attributes.ContainsKey("EA05"))
				{
					_criticalDamageModifier = Data.CriticalDamageModifier;
				}
				else
				{
					_criticalDamageModifier = Potential.Attributes["EA05"];
				}
				if (PercentBonusAttr.ContainsKey("EA05"))
				{
					num += PercentBonusAttr["EA05"];
				}
				float num2 = 0f;
				if (FixedBonusAttr.ContainsKey("EA05"))
				{
					num2 += FixedBonusAttr["EA05"];
				}
				_criticalDamageModifier = _criticalDamageModifier * num + num2;
			}
			return _criticalDamageModifier;
		}
	}

	public float HitRate
	{
		get
		{
			if (Math.Abs(_hitRate) < float.Epsilon)
			{
				if (Potential == null || !Potential.Attributes.ContainsKey("EA06"))
				{
					_hitRate = Data.HitRate;
				}
				else
				{
					_hitRate = Potential.Attributes["EA06"];
				}
				float num = 1f;
				if (PercentBonusAttr.ContainsKey("EA06"))
				{
					num += PercentBonusAttr["EA06"];
				}
				float num2 = 0f;
				if (FixedBonusAttr.ContainsKey("EA06"))
				{
					num2 += FixedBonusAttr["EA06"];
				}
				_hitRate = _hitRate * num + num2;
			}
			return _hitRate;
		}
		set
		{
			_hitRate = value;
		}
	}

	public float EvasionRate
	{
		get
		{
			if (Math.Abs(_evasionRate) < float.Epsilon)
			{
				if (Potential == null || !Potential.Attributes.ContainsKey("EA07"))
				{
					_evasionRate = Data.EvasionRate;
				}
				else
				{
					_evasionRate = Potential.Attributes["EA07"];
				}
				float num = 1f;
				if (PercentBonusAttr.ContainsKey("EA07"))
				{
					num += PercentBonusAttr["EA07"];
				}
				float num2 = 0f;
				if (FixedBonusAttr.ContainsKey("EA07"))
				{
					num2 += FixedBonusAttr["EA07"];
				}
				_evasionRate = _evasionRate * num + num2;
			}
			return _evasionRate;
		}
	}

	public float AttackSpeed
	{
		get
		{
			if (Math.Abs(_attackSpeed) < float.Epsilon)
			{
				if (Potential == null || !Potential.Attributes.ContainsKey("EA08"))
				{
					_attackSpeed = Data.AttackSpeed;
				}
				else
				{
					_attackSpeed = Potential.Attributes["EA08"];
				}
				float num = 0f;
				if (FixedBonusAttr.ContainsKey("EA19"))
				{
					num += FixedBonusAttr["EA19"];
				}
				float num2 = 1f;
				if (PercentBonusAttr.ContainsKey("EA19"))
				{
					num2 += PercentBonusAttr["EA19"];
				}
				_attackSpeed = _attackSpeed * num2 + num;
				float num3 = 1f;
				if (PercentBonusAttr.ContainsKey("EA08"))
				{
					num3 += PercentBonusAttr["EA08"];
				}
				float num4 = 0f;
				if (FixedBonusAttr.ContainsKey("EA08"))
				{
					num4 += FixedBonusAttr["EA08"];
				}
				_attackSpeed = _attackSpeed * num3 + num4;
			}
			return _attackSpeed;
		}
	}

	public float MoveSpeed
	{
		get
		{
			float num = 0f;
			if (Math.Abs(_moveSpeed) < float.Epsilon)
			{
				if (Potential == null || !Potential.Attributes.ContainsKey("EA09"))
				{
					_moveSpeed = Data.MoveSpeed;
				}
				else
				{
					_moveSpeed = Potential.Attributes["EA09"];
				}
				float num2 = 0f;
				if (FixedBonusAttr.ContainsKey("EA21"))
				{
					num2 += FixedBonusAttr["EA21"];
				}
				float num3 = 1f;
				if (PercentBonusAttr.ContainsKey("EA21"))
				{
					num3 += PercentBonusAttr["EA21"];
				}
				_moveSpeed = _moveSpeed * num3 + num2;
				float num4 = 1f;
				if (PercentBonusAttr.ContainsKey("EA09"))
				{
					num4 += PercentBonusAttr["EA09"];
				}
				if (FixedBonusAttr.ContainsKey("EA09"))
				{
					num += FixedBonusAttr["EA09"];
				}
				_moveSpeed = _moveSpeed * num4 + num;
			}
			return _moveSpeed;
		}
		set
		{
			_moveSpeed = value;
		}
	}

	public float PercentDamageSettlement
	{
		get
		{
			if (Math.Abs(_percentDamageSettlement) < float.Epsilon && PercentBonusAttr.TryGetValue("EA16", out var value))
			{
				_percentDamageSettlement = value;
			}
			return _percentDamageSettlement;
		}
	}

	public float FixedDamageSettlement
	{
		get
		{
			if (Math.Abs(_fixedDamageSettlement) < float.Epsilon)
			{
				_fixedDamageSettlement = 0f;
				if (FixedBonusAttr.TryGetValue("EA16", out var value))
				{
					_fixedDamageSettlement += value;
				}
			}
			return _fixedDamageSettlement;
		}
	}

	public float PercentHurtSettlement
	{
		get
		{
			if (Math.Abs(_percentHurtSettlement) < float.Epsilon && PercentBonusAttr.TryGetValue("EA27", out var value))
			{
				_percentHurtSettlement = value;
			}
			return _percentHurtSettlement;
		}
	}

	public float FixedHurtSettlement
	{
		get
		{
			if (Math.Abs(_fixedHurtSettlement) < float.Epsilon)
			{
				_fixedHurtSettlement = 0f;
				if (FixedBonusAttr.TryGetValue("EA17", out var value))
				{
					_fixedHurtSettlement += value;
				}
			}
			return _fixedHurtSettlement;
		}
	}

	public float PercentDamageReflect
	{
		get
		{
			if (Math.Abs(_percentDamageReflect) < float.Epsilon)
			{
				_percentDamageReflect = 1f;
				if (PercentBonusAttr.TryGetValue("EA23", out var value))
				{
					_percentDamageReflect += value;
				}
			}
			return _percentDamageReflect;
		}
	}

	public float FixedDamageReflect
	{
		get
		{
			if (Math.Abs(_fixedDamageReflect) < float.Epsilon)
			{
				_fixedDamageReflect = 0f;
				if (FixedBonusAttr.TryGetValue("EA23", out var value))
				{
					_fixedDamageReflect += value;
				}
			}
			return _fixedDamageReflect;
		}
	}

	public float PercentCureSettlement
	{
		get
		{
			if (Math.Abs(_percentCureSettlement) < float.Epsilon)
			{
				_percentCureSettlement = 1f;
				if (PercentBonusAttr.TryGetValue("EA28", out var value))
				{
					_percentCureSettlement *= value;
				}
				if (PercentBonusAttr.TryGetValue("EA24", out var value2))
				{
					_percentCureSettlement += value2;
				}
			}
			return _percentCureSettlement;
		}
	}

	public float FixedCureSettlement
	{
		get
		{
			if (Math.Abs(_fixedCureSettlement) < float.Epsilon)
			{
				_fixedCureSettlement = 0f;
				if (FixedBonusAttr.TryGetValue("EA24", out var value))
				{
					_fixedCureSettlement += value;
				}
			}
			return _fixedCureSettlement;
		}
	}

	public float PercentRecoverSettlement
	{
		get
		{
			if (Math.Abs(_percentRecoverSettlement) < float.Epsilon)
			{
				_percentRecoverSettlement = 1f;
				if (PercentBonusAttr.TryGetValue("EA29", out var value))
				{
					_percentRecoverSettlement *= value;
				}
				if (PercentBonusAttr.TryGetValue("EA25", out var value2))
				{
					_percentRecoverSettlement += value2;
				}
			}
			return _percentRecoverSettlement;
		}
	}

	public float FixedRecoverSettlement
	{
		get
		{
			if (Math.Abs(_fixedRecoverSettlement) < float.Epsilon)
			{
				_fixedRecoverSettlement = 0f;
				if (FixedBonusAttr.TryGetValue("EA25", out var value))
				{
					_fixedRecoverSettlement += value;
				}
			}
			return _fixedRecoverSettlement;
		}
	}

	public Dictionary<string, int> OriginEvoRequirement => EvoData?.EvoRequire;

	public Dictionary<string, int> EvoRequirement
	{
		get
		{
			Dictionary<string, int> originEvoRequirement = OriginEvoRequirement;
			if (originEvoRequirement == null)
			{
				return null;
			}
			float percentFloatPayload = _managers.ModifierManager.GetPercentFloatPayload("SoldierEvoCost", new string[2] { Id, Data.AiType });
			Dictionary<string, int> dictionary;
			if (Math.Abs(percentFloatPayload) > float.Epsilon)
			{
				dictionary = new Dictionary<string, int>();
				percentFloatPayload += 1f;
				foreach (KeyValuePair<string, int> item in originEvoRequirement)
				{
					dictionary.Add(item.Key, Mathf.RoundToInt((float)item.Value * percentFloatPayload));
				}
			}
			else
			{
				dictionary = originEvoRequirement;
			}
			return dictionary;
		}
	}

	public List<string> WeaponList => Singleton<SoldierProductManager>.Instance.GetSoldierWeaponList(Id);

	public int CombatPower
	{
		get
		{
			if (_CombatPower != -1)
			{
				return _CombatPower;
			}
			_CombatPower = Formulas.CombatPower(Attack, CriticalDamageModifier, CriticalChance, AttackSpeed, HitRate, Health, Defense, EvasionRate, AttackRangeCorrector, LegendItemCorrector);
			return _CombatPower;
		}
	}

	public float AttackRangeCorrector
	{
		get
		{
			float num = 0f;
			string aiType = AiType;
			string text = aiType;
			if (text == "ranged")
			{
				num += 0.7f;
			}
			return num;
		}
	}

	public float LegendItemCorrector
	{
		get
		{
			float num = 0f;
			List<Shift.Legion.Common.Models.LegendItem.LegendItem> soldierEquippedItemInstances = _managers.SoldierEquipmentManager.GetSoldierEquippedItemInstances(Id);
			foreach (Shift.Legion.Common.Models.LegendItem.LegendItem item in soldierEquippedItemInstances)
			{
				num += item.CombatPowerModifier;
			}
			return num;
		}
	}

	public float ManagePower
	{
		get
		{
			float num = 0f;
			num = PotentialLevel switch
			{
				0 => num + 0.05f, 
				1 => num + 0.1f, 
				2 => num + 0.15f, 
				3 => num + 0.2f, 
				4 => num + 0.3f, 
				5 => num + 0.4f, 
				6 => num + 0.5f, 
				7 => num + 0.6f, 
				8 => num + 0.8f, 
				_ => num + 0.8f, 
			};
			return EvoLevel switch
			{
				1 => num + 0.05f, 
				2 => num + 0.1f, 
				3 => num + 0.2f, 
				4 => num + 0.3f, 
				5 => num + 0.4f, 
				_ => num + 0.4f, 
			};
		}
	}

	public List<string> AbilityList => Data.Abilities;

	public string FeatureAbility
	{
		get
		{
			if (_featureAbility == null)
			{
				string text = Data.FeatureAbilityLevel;
				if (string.IsNullOrEmpty(text) && !string.IsNullOrEmpty(Data.ParentSoldierId))
				{
					text = GDMgr.Get<GDESoldierData>(Data.ParentSoldierId)?.FeatureAbilityLevel ?? string.Empty;
				}
				string[] array = text.Split(new char[1] { '|' }, StringSplitOptions.RemoveEmptyEntries);
				if (array.Length == 2)
				{
					_featureAbility = array[0];
				}
				else
				{
					List<string> abilities = Data.Abilities;
					if (abilities.Count == 0 && !string.IsNullOrEmpty(Data.ParentSoldierId))
					{
						GDESoldierData gDESoldierData = GDMgr.Get<GDESoldierData>(Data.ParentSoldierId);
						if (gDESoldierData != null)
						{
							abilities = gDESoldierData.Abilities;
						}
					}
					_featureAbility = abilities.Last();
				}
			}
			return _featureAbility;
		}
	}

	public int[] FeatureAbilityUnlockPotentialLevels
	{
		get
		{
			if (_featureAbilityUnlockLevels == null)
			{
				string text = Data.FeatureAbilityLevel;
				if (string.IsNullOrEmpty(text) && !string.IsNullOrEmpty(Data.ParentSoldierId))
				{
					text = GDMgr.Get<GDESoldierData>(Data.ParentSoldierId)?.FeatureAbilityLevel ?? string.Empty;
				}
				string[] array = text.Split(new char[1] { '|' }, StringSplitOptions.RemoveEmptyEntries);
				if (array.Length == 2)
				{
					array = array[1].Split(new char[1] { ',' }, StringSplitOptions.RemoveEmptyEntries);
					_featureAbilityUnlockLevels = new int[array.Length];
					for (int i = 0; i < array.Length; i++)
					{
						_featureAbilityUnlockLevels[i] = int.Parse(array[i]);
					}
				}
				else
				{
					_featureAbilityUnlockLevels = new int[1];
				}
			}
			return _featureAbilityUnlockLevels;
		}
	}

	public List<string> UnlockedAbilityList
	{
		get
		{
			if (Data.Abilities.Count != Data.AbilityLearning.Count)
			{
				return new List<string>();
			}
			List<string> list = new List<string>();
			for (int i = 0; i < Data.Abilities.Count; i++)
			{
				if (Data.AbilityLearning[i] <= PotentialLevel)
				{
					string text = Data.Abilities[i];
					if (text == FeatureAbility)
					{
						text = GetCurrentLevelFeatureAbilityId();
					}
					if (!string.IsNullOrEmpty(text))
					{
						list.Add(text);
					}
				}
			}
			return list;
		}
	}

	public List<ItemAbility> ItemAbilities
	{
		get
		{
			List<ItemAbility> list = new List<ItemAbility>();
			List<Shift.Legion.Common.Models.LegendItem.LegendItem> soldierEquippedItemInstances = _managers.SoldierEquipmentManager.GetSoldierEquippedItemInstances(Id);
			foreach (Shift.Legion.Common.Models.LegendItem.LegendItem item in soldierEquippedItemInstances)
			{
				if (item != null)
				{
					GetItemAbilityFromEntries(item.MainEntries, list);
					GetItemAbilityFromEntries(item.SubEntries, list);
					GetItemAbilityFromEntries(item.FxEntries, list);
				}
			}
			return list;
		}
	}

	public bool IsUnlocked => _managers.UserArchiveManager.GetUnlockedSoldiers().Contains(Id);

	public Soldier(string soldierId)
		: this(GameManagers.Instance, GDMgr.Get<GDESoldierData>(soldierId))
	{
	}

	public Soldier(GDESoldierData soldierData)
		: this(GameManagers.Instance, soldierData)
	{
	}

	public Soldier(GameManagers managers, string soldierId)
		: this(managers, GDMgr.Get<GDESoldierData>(soldierId))
	{
	}

	public Soldier(GameManagers managers, GDESoldierData soldierData)
	{
		_managers = managers;
		EnsureAttr();
		Data = soldierData;
		Id = soldierData.Key;
		ScaleRatio = soldierData.ScaleRatio;
		ItemId = soldierData.ItemID;
		prefabName = soldierData.ModelName;
		Rarity = Data.Rarity;
		DamageType = Data.DamageType;
		ArmorType = Data.ArmorType;
		if (string.IsNullOrEmpty(Data.Faction))
		{
			if (string.IsNullOrEmpty(Data.ParentSoldierId))
			{
				Faction = "其它";
			}
			else
			{
				Soldier soldier = new Soldier(_managers, Data.ParentSoldierId);
				Faction = soldier.Faction;
			}
		}
		else
		{
			Faction = Data.Faction;
		}
		if (_managers != null)
		{
			Skin = _managers.UserArchiveManager.GetSoldierSkin(this);
		}
	}

	public string GetSkin()
	{
		int num = (PotentialLevel + 2) / 2;
		if (PotentialLevel >= 9)
		{
			num = 6;
		}
		if (Skin.Equals("UsePotentialLevel"))
		{
			return $"skin{num}";
		}
		return Skin;
	}

	public string GetPortraitPathByEvoLevel(int evoLevel)
	{
		if (evoLevel <= 0)
		{
			evoLevel = _managers.UserArchiveManager.GetSoldierEvolutionLevel(Id);
		}
		else
		{
			int soldierMaxEvoLevel = _managers.UserArchiveManager.GetSoldierMaxEvoLevel();
			if (evoLevel > soldierMaxEvoLevel)
			{
				evoLevel = soldierMaxEvoLevel;
			}
		}
		return $"{Data.ItemID}_{evoLevel}";
	}

	public string GetPortraitPath(string soldierId, int evoLevel = 0)
	{
		GDESoldierData gDESoldierData = GDMgr.Get<GDESoldierData>(soldierId);
		if (evoLevel <= 0)
		{
			evoLevel = _managers.UserArchiveManager.GetSoldierEvolutionLevel(soldierId);
		}
		else
		{
			int soldierMaxEvoLevel = _managers.UserArchiveManager.GetSoldierMaxEvoLevel();
			if (evoLevel > soldierMaxEvoLevel)
			{
				evoLevel = soldierMaxEvoLevel;
			}
		}
		return $"Image/Item/{gDESoldierData.ItemID}_{evoLevel}";
	}

	private void ExtractAttrBonusData(Dictionary<string, float> bonusData, ref Dictionary<string, float> bonusDict)
	{
		if (bonusData == null)
		{
			return;
		}
		foreach (KeyValuePair<string, float> bonusDatum in bonusData)
		{
			string key = bonusDatum.Key;
			if (Modifier.EntityAttrModifierList.Contains(key))
			{
				float num = bonusDatum.Value;
				bool flag = Modifier.NeedStackMultipleProcess(key);
				if (flag)
				{
					num = ((!Modifier.NeedReverseValeProcess(key)) ? (1f + num) : (1f - num));
				}
				if (!bonusDict.ContainsKey(key))
				{
					bonusDict.Add(key, num);
				}
				else if (flag)
				{
					bonusDict[key] *= num;
				}
				else
				{
					bonusDict[key] += num;
				}
			}
		}
	}

	private void ExtractAttrBonusData(Dictionary<string, object> bonusData, ref Dictionary<string, float> bonusDict)
	{
		if (bonusData == null)
		{
			return;
		}
		foreach (KeyValuePair<string, object> bonusDatum in bonusData)
		{
			string key = bonusDatum.Key;
			if (Modifier.EntityAttrModifierList.Contains(key) && bonusDatum.Value is Dictionary<string, object>)
			{
				float num = (float)((Dictionary<string, object>)bonusDatum.Value)["Payload"];
				bool flag = Modifier.NeedStackMultipleProcess(key);
				if (flag)
				{
					num = ((!Modifier.NeedReverseValeProcess(key)) ? (1f + num) : (1f - num));
				}
				if (!bonusDict.TryGetValue(key, out var value))
				{
					bonusDict.Add(key, num);
				}
				else if (flag)
				{
					bonusDict[key] *= value;
				}
				else
				{
					bonusDict[key] += value;
				}
			}
		}
	}

	private void EnsureFixedBonus(List<Shift.Legion.Common.Models.LegendItem.LegendItem> equippedItems = null)
	{
		_fixedBonusAttr = new Dictionary<string, float>();
		if (ConfigDataManager.SoldierEvoData.TryGetValue(Id, out var value))
		{
			int evoLevel = EvoLevel;
			SoldierEvoData value2;
			while (value.TryGetValue(evoLevel--, out value2))
			{
				ExtractAttrBonusData(value2.FixedBonus, ref _fixedBonusAttr);
			}
		}
		foreach (string weapon in WeaponList)
		{
			ExtractAttrBonusData(Singleton<SoldierProductManager>.Instance.GetSoldierProductEvoInfo(_managers, weapon, _managers.UserArchiveManager.GetItemLevel(weapon)).FixBonus, ref _fixedBonusAttr);
		}
		if (equippedItems == null)
		{
			equippedItems = _managers.SoldierEquipmentManager.GetSoldierEquippedItemInstances(Id);
		}
		foreach (Shift.Legion.Common.Models.LegendItem.LegendItem equippedItem in equippedItems)
		{
			if (equippedItem == null)
			{
				continue;
			}
			float legendItemCurEnhanceLevelValue = LegendItemsHelper.GetLegendItemCurEnhanceLevelValue(equippedItem);
			ExtractItemEntriesAttrBonusData(equippedItem.MainEntries, ref _fixedBonusAttr, percentBonus: false);
			ExtractItemEntriesAttrBonusData(equippedItem.SubEntries, ref _fixedBonusAttr, percentBonus: false);
			ExtractItemEntriesAttrBonusData(equippedItem.FxEntries, ref _fixedBonusAttr, percentBonus: false);
			if (equippedItem.MainEntries == null || equippedItem.MainEntries.Count <= 0 || equippedItem.MainEntries[0].Attributes == null || equippedItem.MainEntries[0].Attributes.Count <= 0)
			{
				continue;
			}
			ItemEntryData itemEntryData = equippedItem.MainEntries[0].Attributes[0];
			if (!itemEntryData.IsPercent)
			{
				string key = itemEntryData.Key;
				if (_fixedBonusAttr.ContainsKey(key))
				{
					_fixedBonusAttr[key] += legendItemCurEnhanceLevelValue;
				}
				else
				{
					_fixedBonusAttr.Add(key, legendItemCurEnhanceLevelValue);
				}
			}
		}
		ExtractAttrBonusData(_managers.ModifierManager.GetGlobalFixedEntityAttrBonus(), ref _fixedBonusAttr);
		if (_managers.ModifierManager.GlobalFixedModifierDictionary.ContainsKey(Id))
		{
			ExtractAttrBonusData(_managers.ModifierManager.GlobalFixedModifierDictionary[Id], ref _fixedBonusAttr);
		}
		if (_managers.ModifierManager.GlobalFixedModifierDictionary.ContainsKey(Data.AiType))
		{
			ExtractAttrBonusData(_managers.ModifierManager.GlobalFixedModifierDictionary[Data.AiType], ref _fixedBonusAttr);
		}
		if (GDMgr.SoldierMythConfigs.TryGetValue(_managers.UserArchiveManager.GetSoldierMyth(Id).Level, out var value3))
		{
			ExtractAttrBonusData(value3.GetFixAttr(), ref _fixedBonusAttr);
		}
	}

	private void EnsurePercentBonus(List<Shift.Legion.Common.Models.LegendItem.LegendItem> equippedItems = null)
	{
		_percentBonusAttr = new Dictionary<string, float>();
		if (ConfigDataManager.SoldierEvoData.TryGetValue(Id, out var value))
		{
			int evoLevel = EvoLevel;
			SoldierEvoData value2;
			while (value.TryGetValue(evoLevel--, out value2))
			{
				ExtractAttrBonusData(value2.PercentBonus, ref _percentBonusAttr);
			}
		}
		foreach (string weapon in WeaponList)
		{
			ExtractAttrBonusData(Singleton<SoldierProductManager>.Instance.GetSoldierProductEvoInfo(_managers, weapon, _managers.UserArchiveManager.GetItemLevel(weapon)).PercentBonus, ref _percentBonusAttr);
		}
		if (equippedItems == null)
		{
			equippedItems = _managers.SoldierEquipmentManager.GetSoldierEquippedItemInstances(Id);
		}
		foreach (Shift.Legion.Common.Models.LegendItem.LegendItem equippedItem in equippedItems)
		{
			if (equippedItem == null)
			{
				continue;
			}
			float legendItemCurEnhanceLevelValue = LegendItemsHelper.GetLegendItemCurEnhanceLevelValue(equippedItem);
			ExtractItemEntriesAttrBonusData(equippedItem.MainEntries, ref _percentBonusAttr, percentBonus: true);
			ExtractItemEntriesAttrBonusData(equippedItem.SubEntries, ref _percentBonusAttr, percentBonus: true);
			ExtractItemEntriesAttrBonusData(equippedItem.FxEntries, ref _percentBonusAttr, percentBonus: true);
			if (equippedItem.MainEntries == null || equippedItem.MainEntries.Count <= 0 || equippedItem.MainEntries[0].Attributes == null || equippedItem.MainEntries[0].Attributes.Count <= 0)
			{
				continue;
			}
			ItemEntryData itemEntryData = equippedItem.MainEntries[0].Attributes[0];
			if (itemEntryData.IsPercent)
			{
				string key = itemEntryData.Key;
				if (_percentBonusAttr.ContainsKey(key))
				{
					_percentBonusAttr[key] += legendItemCurEnhanceLevelValue;
				}
				else
				{
					_percentBonusAttr.Add(key, legendItemCurEnhanceLevelValue);
				}
			}
		}
		ExtractAttrBonusData(_managers.ModifierManager.GetGlobalPercentEntityAttrBonus(), ref _percentBonusAttr);
		if (_managers.ModifierManager.GlobalPercentModifierDictionary.ContainsKey(Id))
		{
			ExtractAttrBonusData(_managers.ModifierManager.GlobalPercentModifierDictionary[Id], ref _percentBonusAttr);
		}
		if (_managers.ModifierManager.GlobalPercentModifierDictionary.ContainsKey(Data.AiType))
		{
			ExtractAttrBonusData(_managers.ModifierManager.GlobalPercentModifierDictionary[Data.AiType], ref _percentBonusAttr);
		}
		if (GDMgr.SoldierMythConfigs.TryGetValue(_managers.UserArchiveManager.GetSoldierMyth(Id).Level, out var value3))
		{
			ExtractAttrBonusData(value3.GetPercentAttr(), ref _percentBonusAttr);
		}
	}

	public void ReCalc_CombatPower()
	{
		_CombatPower = -1;
	}

	public void SetSoldierCombatPower(int combatPower)
	{
		_CombatPower = combatPower;
	}

	public int GetCombatPowerWithLegendItems(List<Shift.Legion.Common.Models.LegendItem.LegendItem> legendItems)
	{
		EnsureAttr();
		EnsureFixedBonus(legendItems);
		EnsurePercentBonus(legendItems);
		float num = 0f;
		foreach (Shift.Legion.Common.Models.LegendItem.LegendItem legendItem in legendItems)
		{
			num += legendItem.CombatPowerModifier;
		}
		int result = Formulas.CombatPower(Attack, CriticalDamageModifier, CriticalChance, AttackSpeed, HitRate, Health, Defense, EvasionRate, AttackRangeCorrector, num);
		EnsureAttr();
		return result;
	}

	public string GetCurrentLevelFeatureAbilityId()
	{
		return GameEntityData.GetCurrentFeatureAbilityId(FeatureAbility, GetFeatureAbilityLevel());
	}

	public int GetFeatureAbilityLevel()
	{
		int[] featureAbilityUnlockPotentialLevels = FeatureAbilityUnlockPotentialLevels;
		int result = 0;
		for (int i = 0; i < featureAbilityUnlockPotentialLevels.Length && PotentialLevel >= featureAbilityUnlockPotentialLevels[i]; i++)
		{
			result = i + 1;
		}
		return result;
	}

	private static void GetItemAbilityFromEntries(List<ItemEntry> entries, List<ItemAbility> abilities)
	{
		if (entries == null)
		{
			return;
		}
		foreach (ItemEntry entry in entries)
		{
			GetItemAbilityFromEntry(entry, abilities);
		}
	}

	private static void GetItemAbilityFromEntry(ItemEntry entry, List<ItemAbility> abilities)
	{
		GDELegendItemPropertyData gDELegendItemPropertyData = GDMgr.Get<GDELegendItemPropertyData>(entry.EntryId);
		if (gDELegendItemPropertyData == null)
		{
			throw new NullReferenceException("词条:" + entry.EntryId + "的配置不存在");
		}
		if (!string.IsNullOrEmpty(gDELegendItemPropertyData.AbilityId))
		{
			abilities.Add(new ItemAbility
			{
				AbilityId = gDELegendItemPropertyData.AbilityId,
				Variables = entry.Attributes
			});
		}
	}

	public void EnsureAttr()
	{
		ReCalc_CombatPower();
		_fixedBonusAttr = null;
		_percentBonusAttr = null;
		_baseAttrFactor = -1f;
		_healthGrowUp = 0f;
		_attackGrowUp = 0f;
		_defenseGrowUp = 0f;
		_health = 0f;
		_attack = 0f;
		_defense = 0f;
		_attackDistance = 0f;
		_criticalChance = 0f;
		_criticalDamageModifier = 0f;
		_hitRate = 0f;
		_evasionRate = 0f;
		_attackSpeed = 0f;
		_moveSpeed = 0f;
		_percentDamageSettlement = 0f;
		_fixedDamageSettlement = 0f;
		_percentHurtSettlement = 0f;
		_fixedHurtSettlement = 0f;
		_percentDamageReflect = 0f;
		_fixedDamageReflect = 0f;
		_percentCureSettlement = 0f;
		_fixedCureSettlement = 0f;
		_percentRecoverSettlement = 0f;
		_fixedRecoverSettlement = 0f;
	}

	public void Evolute()
	{
		if (CanEvolute())
		{
			ConsumeEvolute();
			_managers.UserArchiveManager.SetSoldierEvolutionLevel(Id, NextEvoLevel);
			EnsureAttr();
			_managers.Messenger.Broadcast("SOLDIER_EVOLUTED", Id, EvoLevel);
		}
	}

	private void ConsumeEvolute()
	{
		if (EvoRequirement == null)
		{
			return;
		}
		StockChangeRecord[] array = new StockChangeRecord[EvoRequirement.Count];
		int num = 0;
		foreach (KeyValuePair<string, int> item in EvoRequirement)
		{
			array[num++] = new StockChangeRecord
			{
				ItemId = item.Key,
				Offset = -item.Value,
				Context = 9,
				ContextValue = Id,
				Type = 1
			};
		}
		_managers.StockController.ReadStockChangeRecords(array);
	}

	public bool CanEvolute()
	{
		if (!IsUnlocked)
		{
			return false;
		}
		if (EvoRequirement == null)
		{
			return false;
		}
		if (NextEvoLevel > _managers.UserArchiveManager.GetSoldierMaxEvoLevel())
		{
			return false;
		}
		if (!CheckEvoluteWeaponLevelRequirement())
		{
			return false;
		}
		if (!CheckEvoluteCostRequirement())
		{
			return false;
		}
		return true;
	}

	private bool CheckEvoluteWeaponLevelRequirement()
	{
		foreach (string weapon in WeaponList)
		{
			if (_managers.UserArchiveManager.GetWeaponEvoLevel(weapon) < NextEvoLevel)
			{
				return false;
			}
		}
		return true;
	}

	private bool CheckEvoluteCostRequirement()
	{
		foreach (KeyValuePair<string, int> item in EvoRequirement)
		{
			if (_managers.StockController.GetStock(item.Key) < item.Value)
			{
				return false;
			}
		}
		return true;
	}

	public bool UpgradePotential()
	{
		if (CanUpgradePotential())
		{
			ConsumeUpgradePotential();
			Dictionary<string, int> dictionary = NextLevelPotential.Requirements(GameManagers.Instance);
			foreach (KeyValuePair<string, int> item in dictionary)
			{
				GDEItemData gDEItemData = GDMgr.Get<GDEItemData>(item.Key);
				if (gDEItemData.ItemType == 103)
				{
					int num = GameManagers.Instance.StockController.GetStock(item.Key) - item.Value;
					GameManagers.Instance.StockController.SetStock(item.Key, num, StockInContext.PotentialUpgrade, Id, sendStockChangeEvent: false);
				}
			}
			string text = $"skin{(NextPotentialLevel + 2) / 2}";
			if (NextPotentialLevel == 9)
			{
				text = "skin6";
			}
			if (Skin != text)
			{
				Skin = text;
				_managers.UserArchiveManager.SetSoldierSkin(Id, Skin);
			}
			_managers.UserArchiveManager.SetSoldierPotentialLevel(Id, NextPotentialLevel);
			EnsureAttr();
			_managers.Messenger.Broadcast<string, int, Dictionary<string, int>>("SOLDIER_SUMMONING", Id, 1, null);
			return true;
		}
		return false;
	}

	public bool CanUpgradePotential()
	{
		if (PotentialLevel >= 8)
		{
			return CanUpgradeMythPotential();
		}
		if (NextLevelPotential == null)
		{
			return false;
		}
		if (_managers.UserArchiveManager.GetSoldierPotentialProgress(Id).Count < NextLevelPotential.Requirements(_managers).First().Value)
		{
			return false;
		}
		return true;
	}

	public bool CanUpgradeMythPotential()
	{
		if (!LegendItemsHelper.GetSoldierItemSlotState(Id, 1))
		{
			return false;
		}
		if (PotentialLevel < 8)
		{
			return false;
		}
		SoldierPotentialData nextLevelPotential = NextLevelPotential;
		if (nextLevelPotential == null)
		{
			return false;
		}
		Dictionary<string, int> dictionary = nextLevelPotential.Requirements(_managers);
		if (dictionary.Count <= 0)
		{
			return false;
		}
		bool flag = _managers.UserArchiveManager.GetSoldierPotentialProgress(Id).Count >= dictionary.First().Value;
		KeyValuePair<string, int> keyValuePair = dictionary.ToList()[dictionary.Count - 1];
		bool flag2 = _managers.StockController.GetStock(keyValuePair.Key) >= keyValuePair.Value;
		return flag && flag2;
	}

	public bool CanAddPotentialProgress(int position)
	{
		if (NextLevelPotential == null)
		{
			return false;
		}
		List<int> soldierPotentialProgress = _managers.UserArchiveManager.GetSoldierPotentialProgress(Id);
		KeyValuePair<string, int> keyValuePair = NextLevelPotential.Requirements(_managers).First();
		int stock = _managers.StockController.GetStock(keyValuePair.Key);
		return !soldierPotentialProgress.Contains(position) && stock >= 1 && soldierPotentialProgress.Count < keyValuePair.Value;
	}

	public bool CanAddPotentialProgress(IEnumerable<int> positionList)
	{
		List<int> soldierPotentialProgress = _managers.UserArchiveManager.GetSoldierPotentialProgress(Id);
		KeyValuePair<string, int> keyValuePair = NextLevelPotential.Requirements(_managers).First();
		int stock = _managers.StockController.GetStock(keyValuePair.Key);
		if (soldierPotentialProgress.Exists(positionList.Contains<int>))
		{
			return false;
		}
		if (soldierPotentialProgress.Count + positionList.Count() > keyValuePair.Value || stock < positionList.Count())
		{
			return false;
		}
		return true;
	}

	public bool AddPotentialProgress(int position)
	{
		return AddPotentialProgress(new int[1] { position });
	}

	public bool AddPotentialProgress(IEnumerable<int> positionList)
	{
		if (!CanAddPotentialProgress(positionList))
		{
			return false;
		}
		ConsumeAddPotentialProgress(positionList.Count());
		List<int> soldierPotentialProgress = _managers.UserArchiveManager.GetSoldierPotentialProgress(Id);
		soldierPotentialProgress.AddRange(positionList);
		_managers.UserArchiveManager.SetSoldierPotentialProgress(Id, soldierPotentialProgress);
		return true;
	}

	private void ConsumeAddPotentialProgress(int qty)
	{
		Dictionary<string, int> dictionary = new Dictionary<string, int>();
		foreach (KeyValuePair<string, int> item in NextLevelPotential.Requirements(_managers))
		{
			if (Item.ItemType(item.Key) == 3)
			{
				dictionary.Add(item.Key, item.Value);
			}
		}
		StockChangeRecord[] array = new StockChangeRecord[dictionary.Count];
		int num = 0;
		foreach (KeyValuePair<string, int> item2 in dictionary)
		{
			array[num++] = new StockChangeRecord
			{
				ItemId = item2.Key,
				Offset = -qty,
				Context = 11,
				ContextValue = Id,
				Type = 1
			};
		}
		_managers.StockController.ReadStockChangeRecords(array);
	}

	private void ConsumeUpgradePotential()
	{
	}

	public bool HasSoulStoneToComposite()
	{
		List<Pieces> soulStoneCompositeDataBySoldier = PiecesManager.GetSoulStoneCompositeDataBySoldier(Id);
		Dictionary<int, SoldierPotentialData> soldierPotentials = ConfigDataManager.GetSoldierPotentials(Id);
		List<string> list = new List<string>();
		int nextPotentialLevel = NextPotentialLevel;
		for (int i = 1; i <= nextPotentialLevel; i++)
		{
			soldierPotentials.TryGetValue(i, out var value);
			if (value != null)
			{
				list.AddRange(value.OriginRequirement.Keys);
			}
		}
		List<Pieces> piecesDataByCompositeResult = PiecesManager.GetPiecesDataByCompositeResult(soulStoneCompositeDataBySoldier, list.ToArray());
		foreach (Pieces item in piecesDataByCompositeResult)
		{
			if (_managers.PiecesManager.GetMaxComposite(item.PiecesId) > 0)
			{
				return true;
			}
		}
		return false;
	}

	public void FlushCache_HasNewPotentialProgress()
	{
		_isCacheDirty_HasNewPotentialProgress = true;
	}

	public bool HasNewPotentialProgress(bool flush = false)
	{
		if (flush)
		{
			FlushCache_HasNewPotentialProgress();
		}
		if (!_isCacheDirty_HasNewPotentialProgress)
		{
			return _Cache_HasNewPotentialProgress;
		}
		_isCacheDirty_HasNewPotentialProgress = false;
		bool soldierItemSlotState = LegendItemsHelper.GetSoldierItemSlotState(Id, 1);
		int potentialLevel = PotentialLevel;
		if (potentialLevel == 8 && !soldierItemSlotState)
		{
			Dictionary<string, int> unlockSoldierItemSlotCost = LegendItemsHelper.GetUnlockSoldierItemSlotCost(Id, 1);
			bool cache_HasNewPotentialProgress = GameManagers.Instance.StockController.GetStock(unlockSoldierItemSlotCost.First().Key) >= unlockSoldierItemSlotCost.First().Value;
			_Cache_HasNewPotentialProgress = cache_HasNewPotentialProgress;
			return _Cache_HasNewPotentialProgress;
		}
		bool flag = Define.SoldierMythUnderDevelopment();
		if (soldierItemSlotState && !GameManagers.Instance.UserArchiveManager.GetLegendItemSlotCheckRecord(Id) && flag)
		{
			_Cache_HasNewPotentialProgress = true;
			return _Cache_HasNewPotentialProgress;
		}
		if (potentialLevel == 9 && GameManagers.Instance.UserArchiveManager.GetSoldierMyth(Id).Open)
		{
			FakeSoldier fakeSoldier = new FakeSoldier(Id, Level, EvoLevel, 8);
			List<KeyValuePair<string, int>> list = fakeSoldier.NextLevelPotential?.Requirements(GameManagers.Instance).ToList();
			if (list != null && list.Count > 0)
			{
				string key = list[0].Key;
				int sStoneCost = GameManagers.Instance.UserArchiveManager.GetSStoneCost(Id);
				int stock = GameManagers.Instance.StockController.GetStock(key);
				if (stock >= sStoneCost)
				{
					_Cache_HasNewPotentialProgress = true;
					return true;
				}
			}
		}
		bool flag2 = potentialLevel == 8 && !flag;
		SoldierPotentialData nextLevelPotential = NextLevelPotential;
		if (nextLevelPotential != null && !flag2)
		{
			Dictionary<string, int> dictionary = nextLevelPotential.Requirements(_managers);
			if (dictionary.Count > 0)
			{
				string itemId = dictionary.Keys.First();
				int sStoneCost2 = GameManagers.Instance.UserArchiveManager.GetSStoneCost(Id);
				int stock2 = GameManagers.Instance.StockController.GetStock(itemId);
				if (stock2 > 0 && sStoneCost2 > PotentialProgress.Count)
				{
					_Cache_HasNewPotentialProgress = true;
					return true;
				}
			}
		}
		if (CanUpgradePotential())
		{
			_Cache_HasNewPotentialProgress = true;
			return true;
		}
		if (HasSoulStoneToComposite())
		{
			_Cache_HasNewPotentialProgress = true;
			return true;
		}
		_Cache_HasNewPotentialProgress = false;
		return false;
	}

	public Dictionary<string, int> AbilitiesUnlockState()
	{
		List<string> abilityList = AbilityList;
		List<int> abilityLearning = Data.AbilityLearning;
		if (abilityList.Count != abilityLearning.Count)
		{
			ILRuntimeDebug.LogError($"Soldier:{Id} 技能配置错误 {abilityList.Count} != {abilityLearning.Count}");
			return null;
		}
		Dictionary<string, int> dictionary = new Dictionary<string, int>();
		for (int i = 0; i < abilityList.Count; i++)
		{
			int value = abilityLearning[i];
			string key = abilityList[i];
			dictionary.Add(key, value);
		}
		return dictionary;
	}

	public void LoadAttrData(Dictionary<string, float> data)
	{
		if (_fixedBonusAttr == null)
		{
			_fixedBonusAttr = new Dictionary<string, float>();
		}
		else
		{
			_fixedBonusAttr.Clear();
		}
		if (_percentBonusAttr == null)
		{
			_percentBonusAttr = new Dictionary<string, float>();
		}
		else
		{
			_percentBonusAttr.Clear();
		}
		_health = (data.ContainsKey("EA01") ? data["EA01"] : float.Epsilon);
		_attack = (data.ContainsKey("EA02") ? data["EA02"] : float.Epsilon);
		_defense = (data.ContainsKey("EA03") ? data["EA03"] : float.Epsilon);
		_criticalChance = (data.ContainsKey("EA04") ? data["EA04"] : float.Epsilon);
		_criticalDamageModifier = (data.ContainsKey("EA05") ? data["EA05"] : float.Epsilon);
		_hitRate = (data.ContainsKey("EA06") ? data["EA06"] : float.Epsilon);
		_evasionRate = (data.ContainsKey("EA07") ? data["EA07"] : float.Epsilon);
		_moveSpeed = (data.ContainsKey("EA09") ? data["EA09"] : float.Epsilon);
		_attackSpeed = (data.ContainsKey("EA08") ? data["EA08"] : float.Epsilon);
		_moveSpeed = (data.ContainsKey("EA09") ? data["EA09"] : float.Epsilon);
		_attackDistance = (data.ContainsKey("EA15") ? data["EA15"] : float.Epsilon);
	}

	public bool CanQuickLevelUp(string itemId)
	{
		float num = 0f;
		List<Modifier> list = Item.Effect(_managers, itemId);
		if (list.Count > 0)
		{
			foreach (Modifier item in list)
			{
				if (item.ModifierId == "Bonus" && item.PayloadDictionary.TryGetValue("SoldierExp", out var value))
				{
					num = Convert.ToSingle(value) * (1f + _managers.ModifierManager.GetPercentFloatPayload("SoldierExpGain", 1));
					break;
				}
			}
		}
		if (num > 0f)
		{
			int num2 = SoldierLevelManager.GetLevelExp(NextLevel) - _managers.UserArchiveManager.GetSoldierExp(Id);
			int num3 = Mathf.CeilToInt((float)num2 / num);
			return _managers.StockController.GetStock(itemId) >= num3;
		}
		return false;
	}

	public int GetQuickLevelUpItemNeeded(string itemId)
	{
		float num = 0f;
		List<Modifier> list = Item.Effect(_managers, itemId);
		if (list.Count > 0)
		{
			foreach (Modifier item in list)
			{
				if (item.ModifierId == "Bonus" && item.PayloadDictionary.TryGetValue("SoldierExp", out var value))
				{
					num = Convert.ToSingle(value) * (1f + _managers.ModifierManager.GetPercentFloatPayload("SoldierExpGain", 1));
					break;
				}
			}
		}
		if (num > 0f)
		{
			int num2 = SoldierLevelManager.GetLevelExp(NextLevel) - _managers.UserArchiveManager.GetSoldierExp(Id);
			int num3 = Mathf.CeilToInt((float)num2 / num);
			if (_managers.StockController.GetStock(itemId) >= num3)
			{
				return num3;
			}
			return 0;
		}
		return 0;
	}

	private void ExtractItemEntriesAttrBonusData(List<ItemEntry> entries, ref Dictionary<string, float> bonusDict, bool percentBonus)
	{
		if (entries == null)
		{
			return;
		}
		foreach (ItemEntry entry in entries)
		{
			ExtractItemEntryAttrBonusData(entry, ref bonusDict, percentBonus);
		}
	}

	private void ExtractItemEntryAttrBonusData(ItemEntry entry, ref Dictionary<string, float> bonusDict, bool percentBonus)
	{
		if (entry == null || entry.Status == -1 || (LegendItemManager.ItemEntryEnableFilters.TryGetValue(entry.EntryId, out var value) && !AttributeChecker.Check(value, this)) || entry?.Attributes == null || entry.Attributes.Count == 0)
		{
			return;
		}
		foreach (ItemEntryData attribute in entry.Attributes)
		{
			if (percentBonus)
			{
				if (!attribute.IsPercent)
				{
					continue;
				}
			}
			else if (attribute.IsPercent)
			{
				continue;
			}
			string key = attribute.Key;
			if (Modifier.EntityAttrModifierList.Contains(key))
			{
				float num = attribute.GetValue();
				bool flag = Modifier.NeedStackMultipleProcess(key);
				if (flag)
				{
					num = ((!Modifier.NeedReverseValeProcess(key)) ? (1f + num) : (1f - num));
				}
				if (!bonusDict.ContainsKey(key))
				{
					bonusDict.Add(key, num);
				}
				else if (flag)
				{
					bonusDict[key] *= num;
				}
				else
				{
					bonusDict[key] += num;
				}
			}
		}
	}
}
