using System;
using System.Collections.Generic;
using GameDataEditor;
using Shift.Legion.Common.Enums;
using Shift.Legion.Common.Helpers;
using Shift.Legion.Common.Managers;

namespace Shift.Legion.Common.Models;

public class GameEntityData
{
	private static Dictionary<string, List<string>> _entityTags = new Dictionary<string, List<string>>();

	private static readonly List<string> _emptyTags = new List<string>();

	public float AttackRangeCorrection = 0f;

	public float LegendItemCorrection = 0f;

	private float _attrFixFactor;

	private float _combatPowerModifier;

	public string Identifier { get; set; }

	public int PotentialLevel { get; set; }

	public int Level { get; set; }

	public int EvoLevel { get; set; }

	public string ModelName { get; set; }

	public string PrefabPath { get; set; }

	public string MiniMapIcon { get; set; }

	public string BaseImage { get; set; }

	public List<string> Tags { get; set; }

	public string Skin { get; set; }

	public string Icon { get; set; }

	public float BaseAttackDamage { get; set; }

	public float AttackDamage => BaseAttackDamage * _attrFixFactor;

	public float BaseAttackDistance { get; set; }

	public float BaseAttackSpeed { get; set; }

	public float AttackAngle { get; set; }

	public DamageType DamageType { get; set; }

	public float BaseArmor { get; set; }

	public float Armor => BaseArmor * _attrFixFactor;

	public ArmorType ArmorType { get; set; }

	public float BaseHealth { get; set; }

	public float Health => BaseHealth * _attrFixFactor;

	public float MoveSpeed { get; set; }

	public List<string> AbilityIdList { get; set; }

	public List<ItemAbility> ItemAbilities { get; set; }

	public float ScaleRatio { get; set; }

	public float ShadowScaleRatio { get; set; }

	public float Radius { get; set; }

	public float VisionRadius { get; set; }

	public string AiType { get; set; }

	public float CriticalChance { get; set; }

	public float CriticalDamage { get; set; }

	public float EvasionRate { get; set; }

	public float AccuracyRate { get; set; }

	public float DamageSettlement { get; set; }

	public float DamageFixed { get; set; }

	public float HurtSettlement { get; set; }

	public float HurtFixed { get; set; }

	public float DamageReflectSettlement { get; set; }

	public float DamageReflectFixed { get; set; }

	public float CureSettlement { get; set; }

	public float CureFixed { get; set; }

	public float RecoverSettlement { get; set; }

	public float RecoverFixed { get; set; }

	public float CombatPowerModifier
	{
		get
		{
			return _combatPowerModifier;
		}
		set
		{
			_combatPowerModifier = value;
			if (!(Math.Abs(CombatPowerModifier - 1f) > float.Epsilon))
			{
				return;
			}
			_attrFixFactor = 1f;
			float attackDamage = AttackDamage;
			float health = Health;
			float armor = Armor;
			int num = Formulas.CombatPower(attackDamage, CriticalDamage, CriticalChance, BaseAttackSpeed, AccuracyRate, health, armor, EvasionRate, AttackRangeCorrection, LegendItemCorrection);
			float num2 = (float)num * CombatPowerModifier;
			_attrFixFactor = CombatPowerModifier;
			float num3 = 1f;
			bool flag = CombatPowerModifier > 1f;
			int num4 = 0;
			do
			{
				int combatPower = CombatPower;
				float num5 = num2 - (float)combatPower;
				if (Math.Abs(num5) < 10f || Math.Abs(num5) / num2 < 0.05f)
				{
					break;
				}
				float attrFixFactor = _attrFixFactor;
				bool flag2 = num5 > 0f;
				if ((flag2 && !flag) || (!flag2 && flag))
				{
					_attrFixFactor = (attrFixFactor + num3) / 2f;
				}
				else
				{
					_attrFixFactor += attrFixFactor - num3;
				}
				num3 = attrFixFactor;
				flag = flag2;
				num4++;
			}
			while (num4 <= 1000);
		}
	}

	public int CombatPower => Formulas.CombatPower(AttackDamage, CriticalDamage, CriticalChance, BaseAttackSpeed, AccuracyRate, Health, Armor, EvasionRate, AttackRangeCorrection, LegendItemCorrection);

	public static List<string> GetEntityTags(string unitIdentifier, string from_unitIdentifier = "")
	{
		if (_entityTags.TryGetValue(unitIdentifier, out var value))
		{
			return value;
		}
		GDESoldierData gDESoldierData = GDMgr.Get<GDESoldierData>(unitIdentifier);
		if ((string.IsNullOrEmpty(gDESoldierData.Key) || string.IsNullOrEmpty(gDESoldierData.Tags)) && !string.IsNullOrEmpty(gDESoldierData?.ParentSoldierId))
		{
			return GetEntityTags(gDESoldierData.ParentSoldierId, unitIdentifier);
		}
		if (!string.IsNullOrEmpty(gDESoldierData.Key) && !string.IsNullOrEmpty(gDESoldierData.Tags))
		{
			if (from_unitIdentifier != "")
			{
				_entityTags.Add(from_unitIdentifier, new List<string>(gDESoldierData.Tags.Split(' ')));
			}
			else
			{
				_entityTags.Add(gDESoldierData.Key, new List<string>(gDESoldierData.Tags.Split(' ')));
			}
		}
		else if (from_unitIdentifier != "")
		{
			_entityTags.Add(from_unitIdentifier, _emptyTags);
		}
		else
		{
			_entityTags.Add(gDESoldierData.Key, _emptyTags);
		}
		if (from_unitIdentifier != "")
		{
			return _entityTags[from_unitIdentifier];
		}
		return _entityTags[unitIdentifier];
	}

	public GameEntityData()
	{
		Identifier = string.Empty;
		ModelName = string.Empty;
		PrefabPath = string.Empty;
		MiniMapIcon = string.Empty;
		BaseImage = string.Empty;
		Icon = string.Empty;
		_attrFixFactor = 1f;
		_combatPowerModifier = 1f;
	}

	public static GameEntityData UpdateSoldierData(GameManagers managers, ref GameEntityData entityData, Team team)
	{
		GDESoldierData gDESoldierData = GDMgr.Get<GDESoldierData>(entityData.Identifier);
		if (gDESoldierData == null || !gDESoldierData.IsPlayer)
		{
			if (entityData.AiType == "ranged")
			{
				entityData.AttackRangeCorrection = 0.7f;
			}
			return entityData;
		}
		Soldier soldier = managers.SoldierManager.Get(gDESoldierData.Key, useCache: false);
		entityData.Level = soldier.Level;
		entityData.EvoLevel = soldier.EvoLevel;
		entityData.PotentialLevel = soldier.PotentialLevel;
		entityData.Identifier = soldier.Id;
		entityData.Icon = soldier.ItemId;
		entityData.MiniMapIcon = soldier.Data.MiniMapIcon;
		entityData.BaseImage = soldier.Data.BaseImage;
		entityData.Tags = soldier.Tags;
		entityData.PrefabPath = soldier.Data.PrefabPath;
		entityData.Skin = managers.UserArchiveManager.GetSoldierSkin(soldier.Id);
		entityData.AiType = soldier.Data.AiType;
		entityData.ModelName = soldier.Data.ModelName;
		entityData.AttackRangeCorrection = soldier.AttackRangeCorrector;
		entityData.LegendItemCorrection = soldier.LegendItemCorrector;
		entityData.BaseHealth = soldier.Health;
		entityData.BaseAttackDamage = soldier.Attack;
		entityData.DamageType = (DamageType)soldier.Data.DamageType;
		entityData.BaseAttackDistance = soldier.AttackDistance;
		entityData.BaseAttackSpeed = soldier.AttackSpeed;
		entityData.AttackAngle = soldier.Data.AttackAngle;
		entityData.BaseArmor = soldier.Defense;
		entityData.ArmorType = (ArmorType)soldier.Data.ArmorType;
		entityData.MoveSpeed = soldier.MoveSpeed;
		entityData.AbilityIdList = soldier.UnlockedAbilityList;
		entityData.ItemAbilities = soldier.ItemAbilities;
		entityData.Radius = soldier.Data.Radius;
		entityData.VisionRadius = soldier.Data.VisionRadius;
		entityData.ScaleRatio = soldier.ScaleRatio;
		entityData.ShadowScaleRatio = soldier.Data.ShadowScaleRatio;
		entityData.CriticalChance = soldier.CriticalChance;
		entityData.CriticalDamage = soldier.CriticalDamageModifier;
		entityData.EvasionRate = soldier.EvasionRate;
		entityData.AccuracyRate = soldier.HitRate;
		entityData.DamageFixed = soldier.FixedDamageSettlement;
		entityData.DamageSettlement = soldier.PercentDamageSettlement;
		entityData.HurtFixed = soldier.FixedHurtSettlement;
		entityData.HurtSettlement = soldier.PercentHurtSettlement;
		entityData.DamageReflectFixed = soldier.FixedDamageReflect;
		entityData.DamageReflectSettlement = soldier.PercentDamageReflect - 1f;
		entityData.CureFixed = soldier.FixedCureSettlement;
		entityData.CureSettlement = soldier.PercentCureSettlement - 1f;
		entityData.RecoverFixed = soldier.FixedRecoverSettlement;
		entityData.RecoverSettlement = soldier.PercentRecoverSettlement - 1f;
		return entityData;
	}

	public static GameEntityData ResetForSoldier(GDESoldierData data, int potentialLevel)
	{
		GDESoldierData gDESoldierData = null;
		if (!string.IsNullOrEmpty(data.ParentSoldierId))
		{
			gDESoldierData = GDMgr.Get<GDESoldierData>(data.ParentSoldierId);
		}
		GameEntityData gameEntityData = new GameEntityData();
		gameEntityData.PotentialLevel = potentialLevel;
		gameEntityData.Identifier = data.Key;
		gameEntityData.Icon = data.ItemID;
		gameEntityData.MiniMapIcon = data.MiniMapIcon;
		gameEntityData.BaseImage = data.BaseImage;
		gameEntityData.Tags = GetEntityTags(data.Key);
		gameEntityData.BaseHealth = data.Health;
		gameEntityData.BaseAttackDamage = data.Attack;
		gameEntityData.DamageType = (DamageType)data.DamageType;
		gameEntityData.BaseAttackDistance = data.AttackDistance;
		gameEntityData.BaseAttackSpeed = data.AttackSpeed;
		gameEntityData.AttackAngle = data.AttackAngle;
		gameEntityData.BaseArmor = data.Defense;
		gameEntityData.ArmorType = (ArmorType)data.ArmorType;
		gameEntityData.MoveSpeed = data.MoveSpeed;
		gameEntityData.ModelName = data.ModelName;
		gameEntityData.PrefabPath = data.PrefabPath;
		gameEntityData.AiType = data.AiType;
		gameEntityData.Skin = data.Skin;
		gameEntityData.Radius = data.Radius;
		gameEntityData.VisionRadius = data.VisionRadius;
		gameEntityData.ScaleRatio = data.ScaleRatio;
		gameEntityData.ShadowScaleRatio = data.ShadowScaleRatio;
		gameEntityData.CriticalChance = data.CriticalChance;
		gameEntityData.CriticalDamage = data.CriticalDamageModifier;
		gameEntityData.EvasionRate = data.EvasionRate;
		gameEntityData.AccuracyRate = data.HitRate;
		string featureAbilityLevel = data.FeatureAbilityLevel;
		if (gDESoldierData != null && string.IsNullOrEmpty(featureAbilityLevel))
		{
			featureAbilityLevel = gDESoldierData.FeatureAbilityLevel;
		}
		List<string> abilityList = ((gDESoldierData != null && data.Abilities.Count == 0) ? gDESoldierData.Abilities : data.Abilities);
		List<int> abilityLearning = (data.IsPlayer ? data.AbilityLearning : null);
		gameEntityData.AbilityIdList = GetAbilityList(abilityList, potentialLevel, abilityLearning, featureAbilityLevel);
		gameEntityData.ItemAbilities = null;
		if (gDESoldierData != null)
		{
			gameEntityData.Icon = gDESoldierData.ItemID;
			gameEntityData.Skin = data.Skin;
			if (!string.IsNullOrEmpty(data.MiniMapIcon))
			{
				gameEntityData.MiniMapIcon = data.MiniMapIcon;
			}
			if (!string.IsNullOrEmpty(data.BaseImage))
			{
				gameEntityData.BaseImage = data.BaseImage;
			}
			gameEntityData.BaseHealth = ((data.Health < 0f) ? gDESoldierData.Health : data.Health) * data.HealthMultiplier;
			gameEntityData.BaseAttackDamage = ((data.Attack < 0f) ? gDESoldierData.Attack : data.Attack) * data.AttackMultiplier;
			gameEntityData.BaseAttackDistance = ((data.AttackDistance < 0f) ? gDESoldierData.AttackDistance : data.AttackDistance);
			gameEntityData.BaseAttackSpeed = ((data.AttackSpeed < 0f) ? gDESoldierData.AttackSpeed : data.AttackSpeed);
			gameEntityData.AttackAngle = ((data.AttackAngle < 0) ? gDESoldierData.AttackAngle : data.AttackAngle);
			gameEntityData.DamageType = (DamageType)((data.DamageType < 0) ? gDESoldierData.DamageType : data.DamageType);
			gameEntityData.BaseArmor = ((data.Defense < 0f) ? gDESoldierData.Defense : data.Defense) * data.DefenseMultiplier;
			gameEntityData.ArmorType = (ArmorType)((data.ArmorType < 0) ? gDESoldierData.ArmorType : data.ArmorType);
			gameEntityData.MoveSpeed = ((data.MoveSpeed < 0f) ? gDESoldierData.MoveSpeed : data.MoveSpeed);
			gameEntityData.CriticalChance = ((data.CriticalChance < 0f) ? gDESoldierData.CriticalChance : data.CriticalChance);
			gameEntityData.CriticalDamage = ((data.CriticalDamageModifier < 0f) ? gDESoldierData.CriticalDamageModifier : data.CriticalDamageModifier);
			gameEntityData.AccuracyRate = ((data.HitRate < 0f) ? gDESoldierData.HitRate : data.HitRate);
			gameEntityData.EvasionRate = ((data.EvasionRate < 0f) ? gDESoldierData.EvasionRate : data.EvasionRate);
			gameEntityData.Radius = ((data.Radius < 0f) ? gDESoldierData.Radius : data.Radius);
			gameEntityData.VisionRadius = ((data.VisionRadius < 0f) ? gDESoldierData.VisionRadius : data.VisionRadius);
			gameEntityData.ScaleRatio = ((data.ScaleRatio < 0f) ? gDESoldierData.ScaleRatio : data.ScaleRatio);
			gameEntityData.ShadowScaleRatio = ((data.ShadowScaleRatio < 0f) ? gDESoldierData.ShadowScaleRatio : data.ShadowScaleRatio);
			gameEntityData.ModelName = ((data.ModelName == "-1") ? gDESoldierData.ModelName : data.ModelName);
			gameEntityData.PrefabPath = ((data.PrefabPath == "-1") ? gDESoldierData.PrefabPath : data.PrefabPath);
			gameEntityData.AiType = ((data.AiType == "-1") ? gDESoldierData.AiType : data.AiType);
			gameEntityData.Tags = GetEntityTags(data.Key);
		}
		return gameEntityData;
	}

	public static GameEntityData GetEntityData(GameManagers managers, string entityDataId, float powerModifier = 1f, int potentialLevel = -1, Team team = Team.None)
	{
		GDESoldierData gDESoldierData = GDMgr.Get<GDESoldierData>(entityDataId);
		potentialLevel = ((potentialLevel >= 0) ? potentialLevel : gDESoldierData.PotentialLevel);
		if (gDESoldierData.IsPlayer)
		{
			potentialLevel = managers.UserArchiveManager.GetSoldierPotentialLevel(entityDataId);
		}
		GameEntityData entityData = ResetForSoldier(gDESoldierData, potentialLevel);
		UpdateSoldierData(managers, ref entityData, team);
		entityData.CombatPowerModifier = powerModifier;
		return entityData;
	}

	public static List<string> GetAbilityList(List<string> abilityList, int potentialLevel, List<int> abilityLearning, string featureAbilityLevel)
	{
		if (abilityList.Count == 0 || string.IsNullOrEmpty(featureAbilityLevel))
		{
			return abilityList;
		}
		string[] array = featureAbilityLevel.Split(new char[1] { '|' }, StringSplitOptions.RemoveEmptyEntries);
		if (array.Length == 2)
		{
			string featureAbilityId = array[0];
			array = array[1].Split(new char[1] { ',' }, StringSplitOptions.RemoveEmptyEntries);
			int[] array2 = new int[array.Length];
			for (int i = 0; i < array.Length; i++)
			{
				array2[i] = int.Parse(array[i]);
			}
			return GetAbilityList(abilityList, potentialLevel, abilityLearning, featureAbilityId, array2);
		}
		return abilityList;
	}

	public static List<string> GetAbilityList(List<string> abilityList, int potentialLevel, List<int> abilityLearning, string featureAbilityId, int[] featureAbilityUnlockPotentialLevels)
	{
		if (abilityLearning != null && abilityList.Count != abilityLearning.Count)
		{
			return new List<string>();
		}
		List<string> list = new List<string>();
		for (int i = 0; i < abilityList.Count; i++)
		{
			string text = abilityList[i];
			if (text == featureAbilityId)
			{
				int featureAbilityLevel = GetFeatureAbilityLevel(potentialLevel, featureAbilityUnlockPotentialLevels);
				text = GetCurrentFeatureAbilityId(featureAbilityId, featureAbilityLevel);
			}
			if (!string.IsNullOrEmpty(text))
			{
				if (abilityLearning == null)
				{
					list.Add(text);
				}
				else if (abilityLearning[i] <= potentialLevel)
				{
					list.Add(text);
				}
			}
		}
		return list;
	}

	public static string GetCurrentFeatureAbilityId(string abilityId, int level)
	{
		string text = $"{abilityId}_{level}";
		GDEAbilityData abilityData = AbilityDataManager.getAbilityData(text);
		return (abilityData == null) ? abilityId : text;
	}

	public static int GetFeatureAbilityLevel(int potentialLevel, int[] featureAbilityUnlockPotentialLevels)
	{
		int result = 0;
		for (int i = 0; i < featureAbilityUnlockPotentialLevels.Length; i++)
		{
			if (potentialLevel >= featureAbilityUnlockPotentialLevels[i])
			{
				result = i + 1;
			}
		}
		return result;
	}

	public static List<string> GetSoldierUnlockedAbilityList(GDESoldierData data, int potentialLevel)
	{
		return GetAbilityList(data.Abilities, potentialLevel, data.AbilityLearning, data.FeatureAbilityLevel);
	}

	public object Clone()
	{
		return MemberwiseClone();
	}
}
