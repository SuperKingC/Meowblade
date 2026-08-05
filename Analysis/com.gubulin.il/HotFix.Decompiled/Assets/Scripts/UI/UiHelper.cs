using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Assets.Scripts.Managers;
using FairyGUI;
using GameDataEditor;
using HotFix;
using HotFix.Sources.Base.Scripts.Helper;
using HotFix.Sources.Base.Scripts.UI;
using ObjectPool;
using RSG;
using Shift.Legion.ClientApi.Models;
using Shift.Legion.ClientApi.Protocol.Modules.LegendItem.Models;
using Shift.Legion.ClientApi.Protocol.UserAction;
using Shift.Legion.ClientApi.RPC.Api;
using Shift.Legion.ClientLib.Services;
using Shift.Legion.Common.Enums;
using Shift.Legion.Common.Helpers;
using Shift.Legion.Common.Managers;
using Shift.Legion.Common.Models;
using Shift.Legion.Common.Models.LegendItem;
using Shift.Legion.Common.Models.Store;
using Shift.Legion.Common.Services;
using Shift.Legion.Helpers;
using Spine.Unity;
using UI.Battle;
using UI.LegendItemDungeon;
using UI.LegendItems;
using UI.Tips;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.Events;
using UnityEngine.Networking;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.UI;

namespace Assets.Scripts.UI;

public static class UiHelper
{
	public enum TextColorType
	{
		Dark,
		Light
	}

	public class ReplaySoldierDetail
	{
		public const string AiTypeRanged = "ranged";

		public string Id;

		public GDESoldierData Data;

		public SoldierPotentialData Potential;

		public int PotentialLevel;

		public int Level;

		public int EvoLevel;

		public int Num;

		public float Attack;

		public float CriticalDamageModifier;

		public float CriticalChance;

		public float AttackSpeed;

		public float HitRate;

		public float Health;

		public float Defense;

		public float EvasionRate;

		private FakeSoldier FakeSoldier;

		public List<ItemLevel> Weapons;

		public List<LegendItemBrief> LegendItems;

		public Dictionary<string, float> PercentBonusAttr;

		public Dictionary<string, float> FixedBonusAttr;

		public float AttackRangeCorrector;

		public float LegendItemCorrector;

		public int CombatPower;

		public ReplaySoldierDetail(string Id, int Level, int PotentialLevel, int EvoLevel, int Num, List<ItemLevel> Weapons, List<LegendItemBrief> LegendItems, Dictionary<string, float> globalPercentEntityAttrBonus, Dictionary<string, Dictionary<string, object>> globalPercentModifierDictionary, Dictionary<string, float> globalFixedEntityAttrBonus, Dictionary<string, Dictionary<string, object>> globalFixedModifierDictionary)
		{
			this.Id = Id;
			Data = GDMgr.Get<GDESoldierData>(Id);
			this.EvoLevel = EvoLevel;
			this.Level = Level;
			this.PotentialLevel = PotentialLevel;
			this.Num = Num;
			this.Weapons = Weapons;
			this.LegendItems = LegendItems;
			FakeSoldier = new FakeSoldier(this.Id, this.Level, this.EvoLevel, this.PotentialLevel);
			Potential = ConfigDataManager.GetSoldierPotential(Id, PotentialLevel);
			PercentBonusAttr = GetPercentBonusAttr(globalPercentEntityAttrBonus, globalPercentModifierDictionary);
			FixedBonusAttr = GetFixedBonusAttr(globalFixedEntityAttrBonus, globalFixedModifierDictionary);
			Attack = GetAttack();
			AttackSpeed = GetAttackSpeed();
			HitRate = GetHitRate();
			Health = GetHealth();
			Defense = GetDefense();
			EvasionRate = GetEvasionRate();
			CriticalDamageModifier = GetCriticalDamageModifier();
			CriticalChance = GetCriticalChance();
			AttackRangeCorrector = GetAttackRangeCorrector();
			LegendItemCorrector = GetLegendItemCorrector();
			CombatPower = Formulas.CombatPower(Attack, CriticalDamageModifier, CriticalChance, AttackSpeed, HitRate, Health, Defense, EvasionRate, AttackRangeCorrector, LegendItemCorrector) * Num;
		}

		private float GetLegendItemCorrector()
		{
			float num = 0f;
			foreach (LegendItemBrief legendItem in LegendItems)
			{
				num += legendItem.CombatPowerModifier;
			}
			return num;
		}

		private float GetAttackRangeCorrector()
		{
			float num = 0f;
			string aiType = Data.AiType;
			string text = aiType;
			if (text == "ranged")
			{
				num += 0.7f;
			}
			return num;
		}

		private Dictionary<string, float> GetPercentBonusAttr(Dictionary<string, float> globalPercentEntityAttrBonus, Dictionary<string, Dictionary<string, object>> globalPercentModifierDictionary)
		{
			Dictionary<string, float> bonusDict = new Dictionary<string, float>();
			if (ConfigDataManager.SoldierEvoData.TryGetValue(Id, out var value))
			{
				int evoLevel = EvoLevel;
				SoldierEvoData value2;
				while (value.TryGetValue(evoLevel--, out value2))
				{
					ExtractAttrBonusData(value2.PercentBonus, ref bonusDict);
				}
			}
			foreach (ItemLevel weapon in Weapons)
			{
				ExtractAttrBonusData(GetSoldierProductEvoInfo(weapon.ItemId, weapon.Level).PercentBonus, ref bonusDict);
			}
			foreach (LegendItemBrief legendItem in LegendItems)
			{
				if (legendItem == null)
				{
					continue;
				}
				float legendItemCurEnhanceLevelValue = GetLegendItemCurEnhanceLevelValue(legendItem);
				ExtractItemEntriesAttrBonusData(legendItem.MainEntries, ref bonusDict, percentBonus: true, FakeSoldier);
				ExtractItemEntriesAttrBonusData(legendItem.SubEntries, ref bonusDict, percentBonus: true, FakeSoldier);
				ExtractItemEntriesAttrBonusData(legendItem.FxEntries, ref bonusDict, percentBonus: true, FakeSoldier);
				if (legendItem.MainEntries != null && legendItem.MainEntries.Count > 0 && legendItem.MainEntries[0].Attributes != null && legendItem.MainEntries[0].Attributes.Count > 0)
				{
					string key = legendItem.MainEntries[0].Attributes[0].Key;
					if (bonusDict.ContainsKey(key))
					{
						bonusDict[key] += legendItemCurEnhanceLevelValue;
					}
					else
					{
						bonusDict.Add(key, legendItemCurEnhanceLevelValue);
					}
				}
			}
			ExtractAttrBonusData(globalPercentEntityAttrBonus, ref bonusDict);
			if (globalPercentModifierDictionary.ContainsKey(Id))
			{
				ExtractAttrBonusData(globalPercentModifierDictionary[Id], ref bonusDict);
			}
			if (globalPercentModifierDictionary.ContainsKey(Data.AiType))
			{
				ExtractAttrBonusData(globalPercentModifierDictionary[Data.AiType], ref bonusDict);
			}
			return bonusDict;
		}

		private Dictionary<string, float> GetFixedBonusAttr(Dictionary<string, float> globalFixedEntityAttrBonus, Dictionary<string, Dictionary<string, object>> globalFixedModifierDictionary)
		{
			Dictionary<string, float> bonusDict = new Dictionary<string, float>();
			if (ConfigDataManager.SoldierEvoData.TryGetValue(Id, out var value))
			{
				int evoLevel = EvoLevel;
				SoldierEvoData value2;
				while (value.TryGetValue(evoLevel--, out value2))
				{
					ExtractAttrBonusData(value2.FixedBonus, ref bonusDict);
				}
			}
			foreach (ItemLevel weapon in Weapons)
			{
				ExtractAttrBonusData(GetSoldierProductEvoInfo(weapon.ItemId, weapon.Level).FixBonus, ref bonusDict);
			}
			foreach (LegendItemBrief legendItem in LegendItems)
			{
				if (legendItem == null)
				{
					continue;
				}
				float legendItemCurEnhanceLevelValue = GetLegendItemCurEnhanceLevelValue(legendItem);
				ExtractItemEntriesAttrBonusData(legendItem.MainEntries, ref bonusDict, percentBonus: false, FakeSoldier);
				ExtractItemEntriesAttrBonusData(legendItem.SubEntries, ref bonusDict, percentBonus: false, FakeSoldier);
				ExtractItemEntriesAttrBonusData(legendItem.FxEntries, ref bonusDict, percentBonus: false, FakeSoldier);
				if (legendItem.MainEntries != null && legendItem.MainEntries.Count > 0 && legendItem.MainEntries[0].Attributes != null && legendItem.MainEntries[0].Attributes.Count > 0)
				{
					string key = legendItem.MainEntries[0].Attributes[0].Key;
					if (bonusDict.ContainsKey(key))
					{
						bonusDict[key] += legendItemCurEnhanceLevelValue;
					}
					else
					{
						bonusDict.Add(key, legendItemCurEnhanceLevelValue);
					}
				}
			}
			ExtractAttrBonusData(globalFixedEntityAttrBonus, ref bonusDict);
			if (globalFixedModifierDictionary.ContainsKey(Id))
			{
				ExtractAttrBonusData(globalFixedModifierDictionary[Id], ref bonusDict);
			}
			if (globalFixedModifierDictionary.ContainsKey(Data.AiType))
			{
				ExtractAttrBonusData(globalFixedModifierDictionary[Data.AiType], ref bonusDict);
			}
			return bonusDict;
		}

		private float GetCriticalDamageModifier()
		{
			float num = 0f;
			float num2 = 1f;
			num = ((Potential != null && Potential.Attributes.ContainsKey("EA05")) ? Potential.Attributes["EA05"] : Data.CriticalDamageModifier);
			if (PercentBonusAttr.ContainsKey("EA05"))
			{
				num2 += PercentBonusAttr["EA05"];
			}
			float num3 = 0f;
			if (FixedBonusAttr.ContainsKey("EA05"))
			{
				num3 += FixedBonusAttr["EA05"];
			}
			return num * num2 + num3;
		}

		private float GetAttack()
		{
			float num = 0f;
			float num2 = 0f;
			num2 = ((Potential != null && Potential.Attributes.ContainsKey("EA13")) ? Potential.Attributes["EA13"] : Data.AttackPerLevel);
			num = ((Potential != null && Potential.Attributes.ContainsKey("EA02")) ? Potential.Attributes["EA02"] : Data.Attack);
			float num3 = 0f;
			if (FixedBonusAttr.ContainsKey("EA18"))
			{
				num3 += FixedBonusAttr["EA18"];
			}
			float num4 = 1f;
			if (PercentBonusAttr.ContainsKey("EA18"))
			{
				num4 += PercentBonusAttr["EA18"];
			}
			num = num * num4 + num3 + num2 * (float)(Level - 1);
			float num5 = 1f;
			if (PercentBonusAttr.ContainsKey("EA02"))
			{
				num5 += PercentBonusAttr["EA02"];
			}
			float num6 = 0f;
			if (FixedBonusAttr.ContainsKey("EA02"))
			{
				num6 += FixedBonusAttr["EA02"];
			}
			return num * num5 + num6;
		}

		private float GetCriticalChance()
		{
			float num = 1f;
			float num2 = 0f;
			num2 = ((Potential != null && Potential.Attributes.ContainsKey("EA04")) ? Potential.Attributes["EA04"] : Data.CriticalChance);
			if (PercentBonusAttr.ContainsKey("EA04"))
			{
				num += PercentBonusAttr["EA04"];
			}
			float num3 = 0f;
			if (FixedBonusAttr.ContainsKey("EA04"))
			{
				num3 += FixedBonusAttr["EA04"];
			}
			return num2 * num + num3;
		}

		private float GetAttackSpeed()
		{
			float num = 0f;
			num = ((Potential != null && Potential.Attributes.ContainsKey("EA08")) ? Potential.Attributes["EA08"] : Data.AttackSpeed);
			float num2 = 0f;
			if (FixedBonusAttr.ContainsKey("EA19"))
			{
				num2 += FixedBonusAttr["EA19"];
			}
			float num3 = 1f;
			if (PercentBonusAttr.ContainsKey("EA19"))
			{
				num3 += PercentBonusAttr["EA19"];
			}
			num = num * num3 + num2;
			float num4 = 1f;
			if (PercentBonusAttr.ContainsKey("EA08"))
			{
				num4 += PercentBonusAttr["EA08"];
			}
			float num5 = 0f;
			if (FixedBonusAttr.ContainsKey("EA08"))
			{
				num5 += FixedBonusAttr["EA08"];
			}
			return num * num4 + num5;
		}

		private float GetHitRate()
		{
			float num = 0f;
			num = ((Potential != null && Potential.Attributes.ContainsKey("EA06")) ? Potential.Attributes["EA06"] : Data.HitRate);
			float num2 = 1f;
			if (PercentBonusAttr.ContainsKey("EA06"))
			{
				num2 += PercentBonusAttr["EA06"];
			}
			float num3 = 0f;
			if (FixedBonusAttr.ContainsKey("EA06"))
			{
				num3 += FixedBonusAttr["EA06"];
			}
			return num * num2 + num3;
		}

		private float GetHealth()
		{
			float num = 0f;
			float num2 = 0f;
			num2 = ((Potential != null && Potential.Attributes.ContainsKey("EA12")) ? Potential.Attributes["EA12"] : Data.HealthPerLevel);
			num = ((Potential != null && Potential.Attributes.ContainsKey("EA01")) ? Potential.Attributes["EA01"] : Data.Health);
			float num3 = 0f;
			if (FixedBonusAttr.ContainsKey("EA22"))
			{
				num3 += FixedBonusAttr["EA22"];
			}
			float num4 = 1f;
			if (PercentBonusAttr.ContainsKey("EA22"))
			{
				num4 += PercentBonusAttr["EA22"];
			}
			num = num * num4 + num3 + num2 * (float)(Level - 1);
			float num5 = 1f;
			if (PercentBonusAttr.ContainsKey("EA01"))
			{
				num5 += PercentBonusAttr["EA01"];
			}
			float num6 = 0f;
			if (FixedBonusAttr.ContainsKey("EA01"))
			{
				num6 += FixedBonusAttr["EA01"];
			}
			return num * num5 + num6;
		}

		private float GetDefense()
		{
			float num = 0f;
			float num2 = 0f;
			num2 = ((Potential != null && Potential.Attributes.ContainsKey("EA14")) ? Potential.Attributes["EA14"] : Data.DefensePerLevel);
			num = ((Potential != null && Potential.Attributes.ContainsKey("EA03")) ? Potential.Attributes["EA03"] : Data.Defense);
			float num3 = 0f;
			if (FixedBonusAttr.ContainsKey("EA20"))
			{
				num3 += FixedBonusAttr["EA20"];
			}
			float num4 = 1f;
			if (PercentBonusAttr.ContainsKey("EA20"))
			{
				num4 += PercentBonusAttr["EA20"];
			}
			num = num * num4 + num3 + num2 * (float)(Level - 1);
			float num5 = 1f;
			if (PercentBonusAttr.ContainsKey("EA03"))
			{
				num5 += PercentBonusAttr["EA03"];
			}
			float num6 = 0f;
			if (FixedBonusAttr.ContainsKey("EA03"))
			{
				num6 += FixedBonusAttr["EA03"];
			}
			return num * num5 + num6;
		}

		private float GetEvasionRate()
		{
			float num = 0f;
			num = ((Potential != null && Potential.Attributes.ContainsKey("EA07")) ? Potential.Attributes["EA07"] : Data.EvasionRate);
			float num2 = 1f;
			if (PercentBonusAttr.ContainsKey("EA07"))
			{
				num2 += PercentBonusAttr["EA07"];
			}
			float num3 = 0f;
			if (FixedBonusAttr.ContainsKey("EA07"))
			{
				num3 += FixedBonusAttr["EA07"];
			}
			return num * num2 + num3;
		}

		public WeaponBonusAndDemand GetSoldierProductEvoInfo(string itemId, int itemLevel)
		{
			Dictionary<string, Dictionary<int, WeaponBonusAndDemand>> dictionary = new Dictionary<string, Dictionary<int, WeaponBonusAndDemand>>();
			if (!dictionary.ContainsKey(itemId))
			{
				dictionary.Add(itemId, new Dictionary<int, WeaponBonusAndDemand>());
			}
			int weaponEvoLevel = GetWeaponEvoLevel(itemId, itemLevel);
			int weaponSubLevel = GetWeaponSubLevel(itemId, itemLevel);
			if (!dictionary[itemId].ContainsKey(itemLevel))
			{
				WeaponBonusAndDemand config = new WeaponBonusAndDemand
				{
					FixBonus = new Dictionary<string, float>(),
					PercentBonus = new Dictionary<string, float>(),
					Require = new Dictionary<string, float>()
				};
				dictionary[itemId].Add(itemLevel, config);
				GDEProductEvoData gDEProductEvoData = GDMgr.Get<GDEProductEvoData>("P" + itemId);
				if (gDEProductEvoData != null)
				{
					object obj = gDEProductEvoData.GetType().GetProperty($"Level{weaponEvoLevel}")?.GetValue(gDEProductEvoData);
					object obj2 = gDEProductEvoData.GetType().GetProperty($"Demand{weaponEvoLevel}")?.GetValue(gDEProductEvoData);
					object obj3 = gDEProductEvoData.GetType().GetProperty($"FragBonus{weaponEvoLevel}")?.GetValue(gDEProductEvoData);
					object obj4 = gDEProductEvoData.GetType().GetProperty($"FragDemand{weaponEvoLevel}")?.GetValue(gDEProductEvoData);
					if (obj != null && obj2 != null && obj3 != null && obj4 != null)
					{
						string text = obj.ToString();
						string text2 = obj2.ToString();
						string text3 = obj3.ToString();
						string text4 = obj4.ToString();
						if (!string.IsNullOrEmpty(text))
						{
							AddEffect(ref config, JsonHelper.ToObject<Dictionary<string, object>>(text));
						}
						if (weaponSubLevel > 0)
						{
							if (!string.IsNullOrEmpty(text3))
							{
								AddEffect(ref config, JsonHelper.ToObject<Dictionary<string, object>>(text3), weaponSubLevel);
							}
							if (!string.IsNullOrEmpty(text4))
							{
								AddDemand(ref config, JsonHelper.ToObject<Dictionary<string, float>>(text4));
							}
						}
						else if (!string.IsNullOrEmpty(text2))
						{
							AddDemand(ref config, JsonHelper.ToObject<Dictionary<string, float>>(text2));
						}
					}
				}
			}
			if (dictionary[itemId].ContainsKey(itemLevel))
			{
				return dictionary[itemId][itemLevel];
			}
			return default(WeaponBonusAndDemand);
		}

		public static int GetWeaponEvoLevel(string itemId, int specifiedLevel = 0)
		{
			if (Shift.Legion.Common.Models.Item.ItemType(itemId) != 2)
			{
				return 1;
			}
			if (specifiedLevel < 1)
			{
				return 1;
			}
			if (specifiedLevel <= 40)
			{
				return (int)Math.Ceiling((float)specifiedLevel / 10f);
			}
			return (int)Math.Ceiling((float)(specifiedLevel - 40) / 20f) + 4;
		}

		public static int GetWeaponSubLevel(string itemId, int specifiedLevel = 0)
		{
			if (Shift.Legion.Common.Models.Item.ItemType(itemId) != 2)
			{
				return 1;
			}
			if (specifiedLevel < 1)
			{
				return 1;
			}
			if (specifiedLevel <= 40)
			{
				return (specifiedLevel - 1) % 10;
			}
			return (specifiedLevel - 41) % 20;
		}

		private void AddEffect(ref WeaponBonusAndDemand config, Dictionary<string, object> data, int multiplier = 1)
		{
			foreach (KeyValuePair<string, object> datum in data)
			{
				string text = datum.Value.ToString();
				if (Modifier.EntityAttrModifierList.Contains(datum.Key))
				{
					float num;
					object obj;
					if (text.IndexOf('%') == -1)
					{
						num = NumericParser.Float(text) * (float)multiplier;
						obj = config.FixBonus;
					}
					else
					{
						num = NumericParser.FloatPercent(text) * (float)multiplier;
						obj = config.PercentBonus;
					}
					if (((Dictionary<string, float>)obj).ContainsKey(datum.Key))
					{
						((Dictionary<string, float>)obj)[datum.Key] += num;
					}
					else
					{
						((Dictionary<string, float>)obj).Add(datum.Key, num);
					}
				}
			}
		}

		private void AddDemand(ref WeaponBonusAndDemand config, Dictionary<string, float> data)
		{
			foreach (KeyValuePair<string, float> datum in data)
			{
				config.Require.Add(datum.Key, datum.Value);
			}
		}
	}

	public class ReplayCombatInfo
	{
		private Dictionary<string, ReplaySoldierDetail> ReplaySoldierCombatCache;

		public Dictionary<string, Dictionary<string, object>> GlobalFixedModifierDictionary;

		public Dictionary<string, Dictionary<string, object>> GlobalPercentModifierDictionary;

		private Dictionary<string, float> _globalPercentEntityAttrBonus;

		private Dictionary<string, float> _globalFixedEntityAttrBonus;

		private void LoadModifier(List<TechLevel> Techs, Dictionary<string, Dictionary<string, object>> globalFixedModifierDictionary, Dictionary<string, Dictionary<string, object>> globalPercentModifierDictionary)
		{
			foreach (TechLevel Tech in Techs)
			{
				List<Modifier> techEffects = GameManagers.Instance.TechnologyManager.GetTechEffects(Tech.TechId, Tech.Level);
				if (techEffects == null)
				{
					continue;
				}
				foreach (Modifier item in techEffects)
				{
					if (!(item.ModifierId == "Bonus") && !(item.ModifierId == "OfflineYieldTimeLimit") && !(item.ModifierId == "TimeMachine"))
					{
						ReadFromModifier(item, globalFixedModifierDictionary, globalPercentModifierDictionary);
					}
				}
			}
		}

		private void ReadFromModifier(Modifier modifier, Dictionary<string, Dictionary<string, object>> globalFixedModifierDictionary, Dictionary<string, Dictionary<string, object>> globalPercentModifierDictionary, int mod = 1)
		{
			Dictionary<string, Dictionary<string, object>> fixedModifierDict = globalFixedModifierDictionary;
			Dictionary<string, Dictionary<string, object>> percentModifierDict = globalPercentModifierDictionary;
			int scope = modifier.Scope;
			int num = scope;
			if (num != 2 && num != 3)
			{
				fixedModifierDict = GlobalFixedModifierDictionary;
				percentModifierDict = GlobalPercentModifierDictionary;
			}
			switch (modifier.ModifierId)
			{
			case "Bonus":
				break;
			case "ProductionEfficiency":
				break;
			case "ProducingTime":
				break;
			case "ProduceCost":
				break;
			case "FreeProduceChance":
				break;
			case "Alchemy":
				break;
			case "StubornWorker":
				break;
			case "StockLimit":
				break;
			case "RecycleRebate":
				break;
			case "OfflineYieldTimeLimit":
				break;
			case "AttributeBundle":
				ProcessAttributeBundleModifier(modifier, ref fixedModifierDict, ref percentModifierDict, mod);
				break;
			default:
				ProcessCommonModifier(modifier, ref fixedModifierDict, ref percentModifierDict, mod);
				break;
			}
		}

		public ReplayCombatInfo(List<TechLevel> Techs)
		{
			GlobalFixedModifierDictionary = new Dictionary<string, Dictionary<string, object>>();
			GlobalPercentModifierDictionary = new Dictionary<string, Dictionary<string, object>>();
			LoadModifier(Techs, GlobalFixedModifierDictionary, GlobalPercentModifierDictionary);
			ReplaySoldierCombatCache = new Dictionary<string, ReplaySoldierDetail>();
		}

		public ReplaySoldierDetail GetReplaySoldierDetailCache(string battleId, string Id, int Level, int PotentialLevel, int EvoLevel, int Num, List<ItemLevel> Weapons, List<LegendItemBrief> LegendItems, List<TechLevel> Techs)
		{
			if (ReplaySoldierCombatCache.ContainsKey(Id))
			{
				return ReplaySoldierCombatCache[Id];
			}
			if (Weapons == null)
			{
				Weapons = new List<ItemLevel>();
			}
			if (LegendItems == null)
			{
				LegendItems = new List<LegendItemBrief>();
			}
			ReplaySoldierDetail value = new ReplaySoldierDetail(Id, Level, PotentialLevel, EvoLevel, Num, Weapons, LegendItems, GetGlobalPercentEntityAttrBonus(), GlobalPercentModifierDictionary, GetGlobalFixedEntityAttrBonus(), GlobalFixedModifierDictionary);
			ReplaySoldierCombatCache.Add(Id, value);
			return ReplaySoldierCombatCache[Id];
		}

		private Dictionary<string, float> GetGlobalPercentEntityAttrBonus()
		{
			if (_globalPercentEntityAttrBonus == null)
			{
				_globalPercentEntityAttrBonus = new Dictionary<string, float>();
				foreach (string entityAttrModifier in Modifier.EntityAttrModifierList)
				{
					if (GlobalPercentModifierDictionary.ContainsKey(entityAttrModifier))
					{
						_globalPercentEntityAttrBonus.Add(entityAttrModifier, (float)GlobalPercentModifierDictionary[entityAttrModifier]["Payload"]);
					}
				}
			}
			return _globalPercentEntityAttrBonus;
		}

		private Dictionary<string, float> GetGlobalFixedEntityAttrBonus()
		{
			if (_globalFixedEntityAttrBonus == null)
			{
				_globalFixedEntityAttrBonus = new Dictionary<string, float>();
				foreach (string entityAttrModifier in Modifier.EntityAttrModifierList)
				{
					if (GlobalFixedModifierDictionary.ContainsKey(entityAttrModifier))
					{
						_globalFixedEntityAttrBonus.Add(entityAttrModifier, (float)GlobalFixedModifierDictionary[entityAttrModifier]["Payload"]);
					}
				}
			}
			return _globalFixedEntityAttrBonus;
		}
	}

	public struct WeaponBonusAndDemand
	{
		public Dictionary<string, float> FixBonus;

		public Dictionary<string, float> PercentBonus;

		public Dictionary<string, float> Require;
	}

	public static bool ShowFrameRateSwitch = false;

	public static List<int> FrameRateCandidates = new List<int> { 30, 60 };

	public static int DefaultFrameRate = 30;

	private const int MaxFrameBorderLevel = 6;

	public const int ICON_FRAME_TYPE_ROUND_I = 1;

	public const int ICON_FRAME_TYPE_ROUND_II = 2;

	public const int ICON_FRAME_TYPE_SQUARE = 3;

	public const int ICON_FRAME_TYPE_PIECES = 4;

	public const int ICON_FRAME_TYPE_STONE = 5;

	public const int ICON_FRAME_TYPE_WOOD = 6;

	public const int ICON_FRAME_TYPE_LOCKED = 7;

	public const int ICON_FRAME_TYPE_SQUARE_AVATAR = 8;

	public const string KuangSquareAvatarWood = "kuang_square_avatar_wood";

	public const string DefaultItemIconPath = "I11001";

	public const int SC_NORMAL = 0;

	public const int SC_MATERIAL = 1;

	public const int SC_PRODUCT = 2;

	public static List<string> LoadTips;

	private static readonly Color32[] colorDarkList = (Color32[])(object)new Color32[6]
	{
		new Color32((byte)155, (byte)197, (byte)42, byte.MaxValue),
		new Color32((byte)15, (byte)127, (byte)213, byte.MaxValue),
		new Color32((byte)223, (byte)139, byte.MaxValue, byte.MaxValue),
		new Color32((byte)246, (byte)130, (byte)5, byte.MaxValue),
		new Color32(byte.MaxValue, (byte)210, (byte)0, byte.MaxValue),
		new Color32(byte.MaxValue, (byte)26, (byte)45, byte.MaxValue)
	};

	private static readonly Color32[] colorLightList = (Color32[])(object)new Color32[6]
	{
		new Color32((byte)26, (byte)122, (byte)0, byte.MaxValue),
		new Color32((byte)0, (byte)70, (byte)174, byte.MaxValue),
		new Color32((byte)161, (byte)46, (byte)209, byte.MaxValue),
		new Color32((byte)218, (byte)87, (byte)0, byte.MaxValue),
		new Color32(byte.MaxValue, (byte)210, (byte)0, byte.MaxValue),
		new Color32((byte)217, (byte)0, (byte)36, byte.MaxValue)
	};

	public static readonly Color32[] colorItemList = (Color32[])(object)new Color32[6]
	{
		new Color32((byte)188, (byte)124, (byte)41, byte.MaxValue),
		new Color32((byte)155, (byte)197, (byte)42, byte.MaxValue),
		new Color32((byte)15, (byte)127, (byte)213, byte.MaxValue),
		new Color32((byte)166, (byte)69, (byte)203, byte.MaxValue),
		new Color32((byte)246, (byte)130, (byte)5, byte.MaxValue),
		new Color32((byte)217, (byte)0, (byte)36, byte.MaxValue)
	};

	private const string WX_AGENT = "Mozilla/5.0 (iPhone; CPU iPhone OS 14_6 like Mac OS X) AppleWebKit/605.1.15 (KHTML, like Gecko) Mobile/15E148 MicroMessenger/8.0.7(0x1800072d) NetType/WIFI Language/zh_CN";

	private static List<Texture2D> _needReleaseTexture2Ds;

	public const int PvpAvatarExpireSeconds = 86400;

	public const int MedalExpireSeconds = 3600;

	public const int PvpFakeAvatarExpireSeconds = 1;

	public const int SelfAvatarExpireSeconds = 31536000;

	public const int SelfAvatarInPendingExpireSeconds = 3600;

	private static string _httpUrl;

	private const int blueDiscount = 4;

	private const int purpleDiscount = 1;

	private const int notDisconut = 10;

	private static Dictionary<string, int> _timeMachineMaxUseCount = new Dictionary<string, int>
	{
		{ "I41010", 480 },
		{ "I41011", 120 },
		{ "I41012", 40 },
		{ "I41013", 20 },
		{ "I41014", 10 },
		{ "I40998", 144 },
		{ "I40999", 48 },
		{ "I41000", 12 },
		{ "I41001", 4 },
		{ "I41002", 2 },
		{ "I41003", 1 },
		{ "I41021", 24 }
	};

	private static List<int> _formationUnlockCost = new List<int> { 50, 200, 300, 500, 800, 1000, 2000, 2000, 3000, 5000 };

	private const string LevelP120 = "P120";

	private const string LevelP205 = "P205";

	private const string LevelP215 = "P215";

	private const string Chapter2 = "C1002";

	public static Dictionary<string, int> UiPublicResourcesDic = new Dictionary<string, int>();

	private static Dictionary<string, float> levelMoneyOutputCache = new Dictionary<string, float>();

	private static Dictionary<string, float> chapterMoneyOutputCache = new Dictionary<string, float>();

	public static bool blackMarketStoryPlayed;

	public static int server_local_diff;

	public static readonly List<int> RefreshTicketHours = new List<int>
	{
		0, 2, 4, 6, 8, 10, 12, 14, 16, 18,
		20, 22
	};

	public static bool xiaomiTipShowed;

	public static bool needShowXiaomiTipOnLogin;

	public static readonly List<string> xiaomiDeviceModel = new List<string> { "Xiaomi", "blackshark" };

	public const string FightTestBox = "FightTestBox";

	public const string FightTestCoin = "FightTestCoin";

	public const string FightTest = "FightTest";

	public const int BuildingUiTitleFontSize = 48;

	public static int BuildingTitleFontSize = ((HotUpdateProcess.LanguageKey == "eng") ? 24 : 36);

	public static UiSpecialConfig uiSpecialConfig;

	public static Dictionary<string, int> IconBundleRef = new Dictionary<string, int>();

	public static List<string> IconPathUsed = new List<string>();

	private const int MaxCacheIcon = 100;

	public static Dictionary<string, ReplayCombatInfo> ReplayCombatInfoCache = new Dictionary<string, ReplayCombatInfo>();

	public const int CredentialsMaxNum = 3;

	private const string UniWebViewCanvasUrl = "Prefabs/UniWebViewPrefab/UniWebViewCanvas";

	private const string UniWebViewCanvasName = "UniWebViewCanvas";

	private const string UniWebViewPrefabUrl = "Prefabs/UniWebViewPrefab/UniWebView";

	private const string UniWebViewPrefabName = "UniWebView";

	private const string Menu = "Menu";

	private const string BtnClose = "BtnClose";

	private const string TextMsg = "TextMsg";

	private static readonly Dictionary<string, int> ModelTopOffset = new Dictionary<string, int>
	{
		{ "iPhone10,3", 100 },
		{ "iPhone10,6", 100 },
		{ "iPhone10,1", 100 },
		{ "iPhone10,2", 100 },
		{ "iPhone10,4", 100 },
		{ "iPhone10,5", 100 },
		{ "iPhone11,2", 100 },
		{ "iPhone11,6", 100 },
		{ "iPhone11,8", 100 },
		{ "iPhone11,4", 100 },
		{ "iPhone12,1", 100 },
		{ "iPhone12,3", 100 },
		{ "iPhone12,5", 100 },
		{ "iPhone12,8", 100 },
		{ "iPhone13,1", 100 },
		{ "iPhone13,2", 100 },
		{ "iPhone13,3", 100 },
		{ "iPhone13,4", 100 }
	};

	private const string ULiteWebViewCanvasName = "ULiteWebViewCanvas";

	private const string WebViewPanel = "WebViewPanel";

	private static int uLiteWebViewTop = 100;

	private static int uLiteWebViewBottom = 0;

	public static int FrameRate
	{
		get
		{
			int frameRate = GameLocalDataManager.GetFrameRate();
			if (frameRate <= 0)
			{
				return DefaultFrameRate;
			}
			return frameRate;
		}
		set
		{
			GameLocalDataManager.SetFrameRate(value);
		}
	}

	private static string HttpUrl => HotUpdateProcess.Instance.RegionModel.Zone.url.res[0];

	public static string UserProfilePath { get; private set; }

	public static string StoryMainRetreatLevelId { get; set; }

	public static string LoginTypeStr { get; set; }

	private static bool UserLoginCredentialsIsFull { get; set; }

	private static bool CredentialsObtained { get; set; }

	public static string ResetTip => LanguagesManager.GetDesc("CsharpCodeZhTcText518");

	public static string ChangeUserArchiveTip => LanguagesManager.GetDesc("CsharpCodeZhTcText519") + LanguagesManager.Comma + LanguagesManager.GetDesc("CsharpCodeZhTcText520");

	public static string DeleteUserArchiveTip => LanguagesManager.GetDesc("CsharpCodeZhTcText521") + " {0}(" + LanguagesManager.GetDesc("CsharpCodeZhTcText95") + "ID:{1}, " + LanguagesManager.GetDesc("CsharpCodeZhTcText112") + ":{2}) " + LanguagesManager.GetDesc("CsharpCodeZhTcText522") + "？";

	public static string DeleteUserArchiveTip2 => LanguagesManager.GetDesc("DeleteUserArchive_DoubleCheck_Tip_Placeholder");

	private static bool needResetUserArchive { get; set; }

	private static GameObject uniWebViewPrefab { get; set; }

	public static string ShortNumberFormat(int number, int scale = 1)
	{
		if (HotUpdateProcess.Instance.IsRegionOutCN)
		{
			return number.ToKMB();
		}
		string num = $"{number}";
		string text = "";
		if (number > 99999999)
		{
			num = ((scale != 1) ? $"{(float)number / 100000000f:F2}" : $"{(float)number / 100000000f:F1}");
			text = LanguagesManager.GetDesc("CsharpCodeZhTcText516");
		}
		else if (number > 9999)
		{
			num = ((scale != 1) ? $"{(float)number / 10000f:F2}" : $"{(float)number / 10000f:F1}");
			text = LanguagesManager.GetDesc("CsharpCodeZhTcText517");
		}
		num = RemoveSurplusZeroBehindDecimalPoint(num);
		return num + text;
	}

	public static string ToKMB(this int num)
	{
		if (num > 999999999 || num < -999999999)
		{
			return num.ToString("0,,,.###B", CultureInfo.InvariantCulture);
		}
		if (num > 999999 || num < -999999)
		{
			return num.ToString("0,,.##M", CultureInfo.InvariantCulture);
		}
		if (num > 999 || num < -999)
		{
			return num.ToString("0,.#K", CultureInfo.InvariantCulture);
		}
		return num.ToString(CultureInfo.InvariantCulture);
	}

	public static string ShortNumberFormat(this long number)
	{
		string num = $"{number}";
		string text = "";
		if (number > 99999999)
		{
			num = $"{(float)number / 100000000f:F1}";
			text = LanguagesManager.GetDesc("CsharpCodeZhTcText516");
		}
		else if (number > 9999)
		{
			num = $"{(float)number / 10000f:F1}";
			text = LanguagesManager.GetDesc("CsharpCodeZhTcText517");
		}
		num = RemoveSurplusZeroBehindDecimalPoint(num);
		return num + text;
	}

	public static string ShortNumberFormat(this int number)
	{
		return ((long)number).ShortNumberFormat();
	}

	public static string GetIconFrameBorder(int frameType, int level = 1, int defaultLevel = 1)
	{
		string text = "";
		text = frameType switch
		{
			3 => text + "kuang_square", 
			2 => text + "kuang_round 2", 
			8 => text + "kuang_square_avatar", 
			_ => text + "round", 
		};
		if (level > 6)
		{
			level = 6;
		}
		return text + $"_lv{level}";
	}

	public static string GetIconFrameBorderSoldier(int level = 1)
	{
		string text = "kuang_square_avatar";
		return level switch
		{
			0 => text + "_C", 
			1 => text + "_C+", 
			2 => text + "_B", 
			3 => text + "_B+", 
			4 => text + "_A", 
			5 => text + "_A+", 
			6 => text + "_S", 
			7 => text + "_S+", 
			8 => text + "_M", 
			9 => text + "_MYTH", 
			_ => text + "_C", 
		};
	}

	public static string GetSoldierLevelStr(int level)
	{
		return level switch
		{
			0 => "C", 
			1 => "C+", 
			2 => "B", 
			3 => "B+", 
			4 => "A", 
			5 => "A+", 
			6 => "S", 
			7 => "S+", 
			8 => "L", 
			9 => "MYTH", 
			_ => "C", 
		};
	}

	public static string GetLevelFrameBorderSoldier(int level = 1)
	{
		string arg = "ui://PublicResources/kuang_round 3_lv";
		if (level >= 9)
		{
			return $"{arg}{6}";
		}
		int num = (level + 2) / 2;
		return $"{arg}{num}";
	}

	public static string GetSlimLevelFrameBorderSoldier(int potentialLevel = 1)
	{
		string text = "ui://PublicResources/frame_Amplifieravatar_";
		if (potentialLevel >= 9)
		{
			return text + "red";
		}
		if (potentialLevel >= 8)
		{
			return text + "yellow";
		}
		if (potentialLevel >= 6)
		{
			return text + "orange";
		}
		if (potentialLevel >= 4)
		{
			return text + "purple";
		}
		if (potentialLevel >= 2)
		{
			return text + "blue";
		}
		return text + "green";
	}

	public static async void LoadSoldierIconFrameMaterial(GLoader iconFrame, int level = 1, List<string> shaderList = null)
	{
		while (iconFrame.image == null || (Object)(object)((DisplayObject)iconFrame.image).material == (Object)null)
		{
			await Task.Delay(35);
		}
		Material material = null;
		int _level = level + 2;
		if (_level == 10)
		{
			material = new Material(FGUIManager.Instance._FairyGUIFlowCrossingUp);
			material.CopyPropertiesFromMaterial(((DisplayObject)iconFrame.image).material);
			((DisplayObject)iconFrame.image).material = material;
			((DisplayObject)iconFrame.image).material.shader = FGUIManager.Instance._FairyGUIFlowCrossingUp;
			((DisplayObject)iconFrame.image).material.SetTexture("_FlowTex", (Texture)(object)FGUIManager.Instance._noise_2_orange);
			((DisplayObject)iconFrame.image).material.SetFloat("_FlowSpeed", 0.1f);
		}
		else if ((Object)(object)((DisplayObject)iconFrame.image).material != (Object)null)
		{
			material = new Material(FGUIManager.Instance._FairyGUI_Image);
			material.CopyPropertiesFromMaterial(((DisplayObject)iconFrame.image).material);
			((DisplayObject)iconFrame.image).material = material;
		}
		((DisplayObject)iconFrame.image).onRemovedFromStage.Set((EventCallback0)delegate
		{
			((DisplayObject)iconFrame.image).material = null;
			Object.Destroy((Object)(object)material);
		});
	}

	public static string GetIconFrameBorderSoldierNum(int level = 1)
	{
		string text = "kuang_square_lv";
		int num = level + 2;
		return (num / 2) switch
		{
			1 => text + "1", 
			2 => text + "2", 
			3 => text + "3", 
			4 => text + "4", 
			5 => text + "5", 
			_ => text + "1", 
		};
	}

	public static string GetStrongHoldModifierColor(float modifier)
	{
		string text = "";
		if (modifier <= 0.5f)
		{
			return "#2bb214";
		}
		if (modifier <= 1f)
		{
			return "#25a6e9";
		}
		if (modifier <= 1.5f)
		{
			return "#d37fff";
		}
		if (modifier < 2f)
		{
			return "#ff6400";
		}
		return "#ffff00";
	}

	public static string RemoveSurplusZeroBehindDecimalPoint(string num)
	{
		if (num.Contains("."))
		{
			num = num.TrimEnd('0');
			num = num.TrimEnd('.');
		}
		return num;
	}

	public static Color32 GetColorByLevel(int level, int brightness = 0)
	{
		//IL_0042: Unknown result type (might be due to invalid IL or missing references)
		//IL_0047: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Unknown result type (might be due to invalid IL or missing references)
		//IL_0037: Unknown result type (might be due to invalid IL or missing references)
		//IL_004a: Unknown result type (might be due to invalid IL or missing references)
		int val = ((level <= 8) ? ((level + 2) / 2) : 6);
		val = Math.Max(1, Math.Min(colorDarkList.Length, val));
		if (brightness == 0)
		{
			return colorDarkList[val - 1];
		}
		return colorLightList[val - 1];
	}

	public static Color32 GetColorByItemLevel(int level, int brightness = 0)
	{
		//IL_0036: Unknown result type (might be due to invalid IL or missing references)
		//IL_003b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_003e: Unknown result type (might be due to invalid IL or missing references)
		level = Math.Max(1, Math.Min(colorDarkList.Length, level));
		if (brightness == 0)
		{
			return colorItemList[level - 1];
		}
		return colorItemList[level - 1];
	}

	public static string GetIconPath(string itemName, int itemLevel = 0, string defaultPath = null, bool isMaterialIcon = false)
	{
		return GetResourcePath(itemName, itemLevel, isMaterialIcon);
	}

	public static string GetItemIconPath(string itemName, int itemLevel = 0, string defaultPath = null, bool isMaterialIcon = false)
	{
		string resourcePath = GetResourcePath(itemName, itemLevel, isMaterialIcon);
		return "ui://PublicResources/" + resourcePath;
	}

	public static string GetItemFramePath(string itemId)
	{
		string iconFrameBorder = GetIconFrameBorder(2, Shift.Legion.Common.Models.Item.Rarity(itemId));
		return "ui://PublicResources/" + iconFrameBorder;
	}

	public static string GetMaterialIconPath(string itemName, int itemLevel = 0, string defaultPath = null)
	{
		return GetScenarioResourcePath(itemName, itemLevel, 1);
	}

	public static string GetProductIconPath(string itemName, int itemLevel = 0, string defaultPath = null)
	{
		return GetScenarioResourcePath(itemName, itemLevel, 2);
	}

	private static string GetScenarioResourcePath(string productId, int itemLevel, int scenario)
	{
		string schemaById = SchemaIndexHelper.GetSchemaById(productId);
		string text = productId;
		GDEProductData gDEProductData = ((schemaById == "Product") ? GDMgr.Get<GDEProductData>(productId) : GDMgr.Get<GDEProductData>("P" + productId.Substring(1)));
		GDEItemData gDEItemData = GDMgr.Get<GDEItemData>(gDEProductData.ItemId);
		if (itemLevel <= 0)
		{
			switch ((ItemType)gDEItemData.ItemType)
			{
			case ItemType.Weapon:
				itemLevel = GameManagers.Instance.UserArchiveManager.GetWeaponEvoLevel(gDEProductData.ItemId);
				break;
			case ItemType.CollectableResource:
				itemLevel = 0;
				break;
			}
		}
		string text2 = null;
		switch (scenario)
		{
		case 1:
			text2 = gDEProductData.MaterialIcon;
			break;
		case 2:
			text2 = gDEProductData.ProductIcon;
			break;
		}
		if (string.IsNullOrEmpty(text2))
		{
			if (!string.IsNullOrEmpty(gDEItemData.Icon))
			{
				text = gDEItemData.Icon;
			}
		}
		else
		{
			text = text2;
		}
		if (itemLevel > 0)
		{
			text += $"_{itemLevel}";
		}
		return text;
	}

	private static string SpellSoldierIconName(string soldierId, int level)
	{
		GDESoldierData gDESoldierData = GDMgr.Get<GDESoldierData>(soldierId);
		string text = ((level > 0) ? level.ToString() : GetValidSoldierIconSuffix(soldierId));
		return gDESoldierData.ItemID + "_" + text;
	}

	private static string SpellSoldierPieceIconName(string itemId)
	{
		GDEItemData gDEItemData = GDMgr.Get<GDEItemData>(itemId);
		string icon = gDEItemData.Icon;
		GDESoldierData gDESoldierData = GDMgr.Get<GDESoldierData>("S" + icon.Substring(3));
		Soldier soldier = GameManagers.Instance.SoldierManager.Get(gDESoldierData.Key);
		return gDESoldierData.ItemID + "_" + GetValidSoldierIconSuffix(soldier.Id);
	}

	private static string SpellResourceAndWeaponIconName(string itemId, int level)
	{
		GDEItemData gDEItemData = GDMgr.Get<GDEItemData>(itemId);
		if (level == 0)
		{
			level = GameManagers.Instance.UserArchiveManager.GetWeaponEvoLevel(itemId);
		}
		return $"{gDEItemData.Icon}_{level}";
	}

	private static string SpellCardItemIconName(string itemId)
	{
		GDEItemData gDEItemData = GDMgr.Get<GDEItemData>(itemId);
		string result = gDEItemData.Icon;
		List<Modifier> list = Shift.Legion.Common.Models.Item.Effect(GameManagers.Instance, itemId);
		foreach (Modifier item in list)
		{
			if (!(item.ModifierId == "Bonus"))
			{
				continue;
			}
			foreach (KeyValuePair<string, object> item2 in item.PayloadDictionary)
			{
				if (SchemaIndexHelper.GetSchemaById(item2.Key) == "Soldier")
				{
					GDESoldierData gDESoldierData = GDMgr.Get<GDESoldierData>(item2.Key);
					result = gDESoldierData.ItemID + "_" + GetValidSoldierIconSuffix(item2.Key);
					break;
				}
			}
			break;
		}
		return result;
	}

	private static string SpellSummonStoneIconName(string itemId)
	{
		GDEItemData gDEItemData = GDMgr.Get<GDEItemData>(itemId);
		string result = gDEItemData.Icon;
		List<Modifier> list = Shift.Legion.Common.Models.Item.Effect(GameManagers.Instance, itemId);
		foreach (Modifier item in list)
		{
			if (SchemaIndexHelper.GetSchemaById(item.ModifierId) == "Soldier")
			{
				GDESoldierData gDESoldierData = GDMgr.Get<GDESoldierData>(item.ModifierId);
				result = gDESoldierData.ItemID + "_" + GetValidSoldierIconSuffix(item.ModifierId);
				break;
			}
		}
		return result;
	}

	private static string SpellProductIconName(string productId, int level, bool isMaterialIcon = false)
	{
		GDEProductData prodData = GDMgr.Get<GDEProductData>(productId);
		GDEItemData gDEItemData = GDMgr.Get<GDEItemData>(prodData.ItemId);
		string text = (isMaterialIcon ? prodData.MaterialIcon : gDEItemData.Icon);
		if (UseOriginalIcon())
		{
			return text;
		}
		if ((level <= 0 && gDEItemData.ItemType == 2) || gDEItemData.ItemType == 1)
		{
			switch ((ItemType)gDEItemData.ItemType)
			{
			case ItemType.Weapon:
				level = GameManagers.Instance.UserArchiveManager.GetWeaponEvoLevel(prodData.ItemId);
				break;
			case ItemType.CollectableResource:
				level = 1;
				break;
			}
		}
		if (level > 0)
		{
			text += $"_{level}";
		}
		return text;
		bool UseOriginalIcon()
		{
			bool flag = prodData.BuildType.Contains("8") || prodData.BuildType.Contains("9") || prodData.BuildType.Contains("13");
			return isMaterialIcon && flag;
		}
	}

	private static string GetValidSoldierIconSuffix(string soldierId)
	{
		int soldierMaxEvoLevel = GameManagers.Instance.UserArchiveManager.GetSoldierMaxEvoLevel();
		int potentialLevel = GameManagers.Instance.SoldierManager.Get(soldierId).PotentialLevel;
		if (potentialLevel == 9)
		{
			return "6";
		}
		int num = (potentialLevel + 2) / 2;
		return Mathf.Clamp(num, 1, soldierMaxEvoLevel).ToString();
	}

	public static string GetResourcePath(string itemId, int itemLevel, bool isMaterialIcon = false)
	{
		string schemaById = SchemaIndexHelper.GetSchemaById(itemId);
		string text = itemId;
		switch (schemaById)
		{
		case "Soldier":
			text = SpellSoldierIconName(itemId, itemLevel);
			break;
		case "Item":
			switch (itemId)
			{
			default:
				switch ((ItemType)Shift.Legion.Common.Models.Item.ItemType(itemId))
				{
				case ItemType.Weapon:
					if (Define.WeaponMaxDisplayLevel6UnderDevelopment())
					{
						itemLevel = GameManagers.Instance.UserArchiveManager.GetWeaponEvoLevel(itemId);
						if (itemLevel > 5)
						{
							itemLevel = 5;
						}
					}
					text = SpellResourceAndWeaponIconName(itemId, itemLevel);
					break;
				case ItemType.Card:
					text = SpellCardItemIconName(itemId);
					break;
				case ItemType.SoldierPiece:
					text = SpellSoldierPieceIconName(itemId);
					break;
				case ItemType.SummonStone:
					text = SpellSummonStoneIconName(itemId);
					break;
				case ItemType.GvGServer_CollectingMaterial:
				{
					string text2 = itemId;
					if (!text2.StartsWith("GvG"))
					{
						string text3 = itemId.Replace("P", "I");
						string[] source = text3.Split('_');
						text2 = source.First();
					}
					text = GDMgr.Get<GDEItemData>(text2).Icon;
					break;
				}
				default:
					if (GDMgr.Get<GDEItemData>(itemId) == null)
					{
						Debug.LogError((object)("未找到物品:" + itemId));
						return itemId;
					}
					text = GDMgr.Get<GDEItemData>(itemId).Icon;
					break;
				}
				break;
			case "ManPower":
			case "Gem":
			case "RMB":
			case "UserExp":
			case "DungeonExp":
			case "SoldierExp":
			case "CollectableResource":
			case "ResourcePortal1":
			case "ResourcePortal2":
			case "ResourcePortal3":
				break;
			}
			break;
		case "Product":
			if (Define.WeaponMaxDisplayLevel6UnderDevelopment())
			{
				itemLevel = GameManagers.Instance.UserArchiveManager.GetWeaponEvoLevel(itemId.Replace("P", "I"));
				if (itemLevel > 5)
				{
					itemLevel = 5;
				}
			}
			text = SpellProductIconName(itemId, itemLevel, isMaterialIcon);
			break;
		default:
			if (itemLevel > 0)
			{
				text = text + "_" + itemId;
			}
			break;
		}
		return text;
	}

	public static string GetIcon(string itemId)
	{
		return GetIconPath(itemId);
	}

	public static string SetIcon(this SpriteRenderer target, string itemName, int itemLevel = 0, string defaultPath = null)
	{
		string resourcePath = GetResourcePath(itemName, itemLevel);
		AssetsManager.Instance.LoadAsset<Sprite>(resourcePath).Then<Sprite>((Func<Sprite, Sprite>)((Sprite asset) => target.sprite = asset)).Catch((Action<Exception>)delegate
		{
			target.SetIcon(defaultPath);
		});
		return resourcePath;
	}

	public static string SetMaterialIcon(this SpriteRenderer target, string itemName, int itemLevel = 0, string defaultPath = null)
	{
		string resourcePath = GetResourcePath(itemName, itemLevel);
		AssetsManager.Instance.LoadAsset<Sprite>(resourcePath).Then<Sprite>((Func<Sprite, Sprite>)((Sprite asset) => target.sprite = asset)).Catch((Action<Exception>)delegate
		{
			target.SetIcon(defaultPath);
		});
		return resourcePath;
	}

	public static string SetProductIcon(this SpriteRenderer target, string itemName, int itemLevel = 0, string defaultPath = null)
	{
		string scenarioResourcePath = GetScenarioResourcePath(itemName, itemLevel, 2);
		AssetsManager.Instance.LoadAsset<Sprite>(scenarioResourcePath).Then<Sprite>((Func<Sprite, Sprite>)((Sprite asset) => target.sprite = asset)).Catch((Action<Exception>)delegate
		{
			target.SetIcon(defaultPath);
		});
		return scenarioResourcePath;
	}

	public static string ParseFullTime(int time)
	{
		return DateTimeHelper.Parse(time).LocalDateTime.ToString("yyyy/MM/dd HH:mm:ss");
	}

	public static string ParseTime(int time)
	{
		int num = time % 60;
		int num2 = time / 60 % 60;
		int num3 = time / 3600;
		if (num3 > 0)
		{
			return $"{num3:d2}:{num2:d2}:{num:d2}";
		}
		if (num2 > 0)
		{
			return $"00:{num2:d2}:{num:d2}";
		}
		return $"00:00:{num:d2}";
	}

	public static string ParseTimeShort(int time)
	{
		int num = time % 60;
		int num2 = time / 60 % 60;
		int num3 = time / 3600;
		if (num3 > 0)
		{
			return $"{num3:d2}:{num2:d2}:{num:d2}";
		}
		if (num2 > 0)
		{
			return $"{num2:d2}:{num:d2}";
		}
		return $"00:{num:d2}";
	}

	public static string ParseTime_Foo(int time)
	{
		int num = time % 60;
		int num2 = time / 60 % 60;
		int num3 = time / 3600;
		if (num3 > 0)
		{
			return $"{num3:d2}:{num2:d2}:{num:d2}";
		}
		if (num2 > 0)
		{
			return $"{num2:d2}:{num:d2}";
		}
		return $"00:{num:d2}";
	}

	public static string ParseTimeChinses(int time)
	{
		if (HotUpdateProcess.Instance.IsRegionOutCN)
		{
			return ParseTimeSpanUniversal(time);
		}
		int num = time % 60;
		int num2 = time % 3600 / 60;
		int num3 = time / 3600;
		if (num3 > 0)
		{
			if (num2 <= 0 && num <= 0)
			{
				return string.Format("{0}{1}", num3, LanguagesManager.GetDesc("CsharpCodeZhTcText248"));
			}
			if (num <= 0)
			{
				return string.Format("{0}{1}{2}{3}", num3, LanguagesManager.GetDesc("CsharpCodeZhTcText248"), num2, LanguagesManager.GetDesc("CsharpCodeZhTcText502"));
			}
			return string.Format("{0}{1}{2}{3}{4}{5}", num3, LanguagesManager.GetDesc("CsharpCodeZhTcText248"), num2, LanguagesManager.GetDesc("CsharpCodeZhTcText502"), num, LanguagesManager.GetDesc("CsharpCodeZhTcText92"));
		}
		if (num2 > 0)
		{
			if (num <= 0)
			{
				return string.Format("{0}{1}", num2, LanguagesManager.GetDesc("CsharpCodeZhTcText304"));
			}
			return string.Format("{0}{1}{2}{3}", num2, LanguagesManager.GetDesc("CsharpCodeZhTcText502"), num, LanguagesManager.GetDesc("CsharpCodeZhTcText92"));
		}
		return string.Format("{0}{1}", num, LanguagesManager.GetDesc("CsharpCodeZhTcText92"));
	}

	public static string ParseTimeChinsesDH(int time)
	{
		if (HotUpdateProcess.Instance.IsRegionOutCN)
		{
			return ParseTimeSpanUniversal(time);
		}
		int num = time % 86400 / 3600;
		int num2 = time / 86400;
		int num3 = time % 3600 / 60;
		if (num2 > 0)
		{
			return string.Format("{0}{1}{2}{3}{4}{5}", num2, LanguagesManager.GetDesc("CsharpCodeZhTcText228"), num, LanguagesManager.GetDesc("CsharpCodeZhTcText11"), num3, LanguagesManager.GetDesc("CsharpCodeZhTcText502"));
		}
		if (num > 0)
		{
			return string.Format("{0}{1}{2}{3}", num, LanguagesManager.GetDesc("CsharpCodeZhTcText11"), num3, LanguagesManager.GetDesc("CsharpCodeZhTcText502"));
		}
		return string.Format("{0}{1}", num3, LanguagesManager.GetDesc("CsharpCodeZhTcText502"));
	}

	public static string ParseTimeChinsesDH_Foo(int time)
	{
		int num = time % 86400 / 3600;
		int num2 = time / 86400;
		int num3 = time % 3600 / 60;
		if (num2 > 0)
		{
			return string.Format("{0}{1}{2}{3}{4}{5}", num2, LanguagesManager.GetDesc("CsharpCodeZhTcText228"), num, LanguagesManager.GetDesc("CsharpCodeZhTcText248"), num3, LanguagesManager.GetDesc("CsharpCodeZhTcText502"));
		}
		if (num > 0)
		{
			return string.Format("{0}{1}{2}{3}", num, LanguagesManager.GetDesc("CsharpCodeZhTcText248"), num3, LanguagesManager.GetDesc("CsharpCodeZhTcText502"));
		}
		return string.Format("{0}{1}", num3, LanguagesManager.GetDesc("CsharpCodeZhTcText502"));
	}

	public static string GetDateStringMMdd(DateTimeOffset dateTimeOffset)
	{
		if (!HotUpdateProcess.Instance.IsRegionOutCN)
		{
			string desc = LanguagesManager.GetDesc("CsharpCodeZhTcText397");
			string desc2 = LanguagesManager.GetDesc("CsharpCodeZhTcText398");
			return dateTimeOffset.ToString("M" + desc + "dd" + desc2);
		}
		return dateTimeOffset.ToString("yyyy-MM-dd");
	}

	public static string GetDateStringMMddHH(DateTime dateTime)
	{
		if (!HotUpdateProcess.Instance.IsRegionOutCN)
		{
			string desc = LanguagesManager.GetDesc("CsharpCodeZhTcText397");
			string desc2 = LanguagesManager.GetDesc("CsharpCodeZhTcText398");
			string desc3 = LanguagesManager.GetDesc("CsharpCodeZhTcText11");
			return dateTime.ToString("MM" + desc + "dd" + desc2 + "HH" + desc3);
		}
		return dateTime.ToString("yyyy-MM-dd HH:mm");
	}

	public static string GetDateStringYYMMdd(DateTime dateTime)
	{
		if (!HotUpdateProcess.Instance.IsRegionOutCN)
		{
			string desc = LanguagesManager.GetDesc("CsharpCodeZhTcText557");
			string desc2 = LanguagesManager.GetDesc("CsharpCodeZhTcText397");
			string desc3 = LanguagesManager.GetDesc("CsharpCodeZhTcText398");
			return dateTime.ToString("yyyy" + desc + "MM" + desc2 + "dd" + desc3);
		}
		return dateTime.ToString("yyyy-MM-dd HH:mm");
	}

	public static string ParseTimeSpanUniversal(int second)
	{
		TimeSpan timeSpan = TimeSpan.FromSeconds(second);
		return $"{timeSpan.Days}d {timeSpan.Hours}h {timeSpan.Minutes}m";
	}

	public static string ParseTimeChnForGift(int time)
	{
		if (HotUpdateProcess.Instance.IsRegionOutCN)
		{
			return ParseTimeSpanUniversal(time);
		}
		int num = time % 86400 / 3600;
		int num2 = time / 86400;
		int num3 = time % 3600 / 60;
		if (num2 > 0)
		{
			return string.Format("{0}{1}{2}{3}", num2, LanguagesManager.GetDesc("CsharpCodeZhTcText228"), num, LanguagesManager.GetDesc("CsharpCodeZhTcText11"));
		}
		if (num > 0)
		{
			return string.Format("{0}{1}{2}{3}", num, LanguagesManager.GetDesc("CsharpCodeZhTcText11"), num3, LanguagesManager.GetDesc("CsharpCodeZhTcText502"));
		}
		return string.Format("{0}{1}", num3, LanguagesManager.GetDesc("CsharpCodeZhTcText502"));
	}

	public static GTweener SetTimeout(this GComponent gComponent, float duration)
	{
		return ((GObject)gComponent).TweenFade(((GObject)gComponent).alpha, duration);
	}

	public static void GetImageByUnityWebRequest(GLoader imageComp, string url, string defaultIcon = "Clap1", float delayTime = 0f, Action callback = null)
	{
		if (imageComp == null || string.IsNullOrWhiteSpace(url))
		{
			if (imageComp != null)
			{
				imageComp.url = "ui://PublicResources/" + defaultIcon;
				callback?.Invoke();
			}
		}
		else
		{
			((MonoBehaviour)FGUIManager.Instance).StartCoroutine(UnityWebRequestGetData(imageComp, url, delayTime, callback));
		}
	}

	private static IEnumerator UnityWebRequestGetData(GLoader imageComp, string url, float delayTime, Action callback)
	{
		UnityWebRequest uwr = UnityWebRequestTexture.GetTexture(url);
		uwr.SetRequestHeader("Accept", "*/*");
		uwr.SetRequestHeader("Accept-Encoding", "gzip, deflate");
		uwr.SetRequestHeader("User-Agent", "Mozilla/5.0 (iPhone; CPU iPhone OS 14_6 like Mac OS X) AppleWebKit/605.1.15 (KHTML, like Gecko) Mobile/15E148 MicroMessenger/8.0.7(0x1800072d) NetType/WIFI Language/zh_CN");
		uwr.timeout = 10;
		yield return uwr.SendWebRequest();
		if (!uwr.isHttpError && !uwr.isNetworkError)
		{
			yield return null;
			int width = (int)((GObject)imageComp).width;
			int height = (int)((GObject)imageComp).height;
			new Texture2D(width, height);
			Texture2D texture2d = DownloadHandlerTexture.GetContent(uwr);
			imageComp.texture = new NTexture((Texture)(object)texture2d);
			callback?.Invoke();
			if (_needReleaseTexture2Ds == null)
			{
				_needReleaseTexture2Ds = new List<Texture2D>();
			}
			_needReleaseTexture2Ds.Add(texture2d);
		}
	}

	public static void ReleaseUnityWebRequestImage()
	{
		if (_needReleaseTexture2Ds == null)
		{
			return;
		}
		foreach (Texture2D needReleaseTexture2D in _needReleaseTexture2Ds)
		{
			Object.Destroy((Object)(object)needReleaseTexture2D);
		}
		_needReleaseTexture2Ds.Clear();
	}

	public static int GetUserAvatarExpireSeconds(int userId)
	{
		int num = (int)GameController.Instance.GetServerTime();
		if (GameController.Contexts.gameState.user.value.UserId != userId)
		{
			return num + 86400;
		}
		return num + 3600;
	}

	public static string GetSelfAvatarLocalPath()
	{
		string text = Application.persistentDataPath + "/UserAvatar";
		string text2 = "/myself.bytes";
		if (!Directory.Exists(text))
		{
			Directory.CreateDirectory(text);
		}
		return text + text2;
	}

	public static string GetUserBigAvatarLocalPath(string userId)
	{
		string text = Application.persistentDataPath + "/UserAvatar";
		string text2 = "/" + userId + "_big.bytes";
		if (!Directory.Exists(text))
		{
			Directory.CreateDirectory(text);
		}
		return text + text2;
	}

	public static string GetUserAvatarLocalPath(string userId)
	{
		string text = Application.persistentDataPath + "/UserAvatar";
		string text2 = "/" + userId + ".bytes";
		if (!Directory.Exists(text))
		{
			Directory.CreateDirectory(text);
		}
		return text + text2;
	}

	public static string GetGvG3UserAvatarLocalPath(string userId, string size)
	{
		string text = Application.persistentDataPath + "/GvG3UserAvatar";
		string text2 = "/" + userId + "_" + size + ".bytes";
		if (!Directory.Exists(text))
		{
			Directory.CreateDirectory(text);
		}
		return text + text2;
	}

	public static string GetUserProfileHttpsUrl(int userId)
	{
		string text = $"/{UserProfilePath}/UserProfile_{userId}.bytes";
		return HttpUrl + text + $"?t={DateTimeHelper.TimeStamp}";
	}

	public static string GetUserBigAvatarHttpsUrl(int userId)
	{
		string text = $"/{UserProfilePath}/UserProfile450_{userId}.bytes";
		return HttpUrl + text + $"?t={DateTimeHelper.TimeStamp}";
	}

	public static string GetUserSelfAvatarHttpsUrl(int userId)
	{
		string text = $"/{UserProfilePath}_userself/UserProfile132_{userId}.bytes";
		return HttpUrl + text + $"?t={DateTimeHelper.TimeStamp}";
	}

	public static string GetUserPendingAvatarHttpsUrl(int userId)
	{
		string text = $"/{UserProfilePath}_pending/UserProfile132_{userId}.bytes";
		return HttpUrl + text + $"?t={DateTimeHelper.TimeStamp}";
	}

	public static string GetUserAvatarHttpsUrl(int userId)
	{
		string text = $"/{UserProfilePath}/UserProfile132_{userId}.bytes";
		return HttpUrl + text + $"?t={DateTimeHelper.TimeStamp}";
	}

	public static async Task GetUserProfileUrl()
	{
		UserProfilePath = (await GameController.Contexts.Service<INetworkService>().GetUserProfileUrl()).UserProfilePath;
	}

	public static string GetGVGBattleRecordDetailRedHttpsUrl(int userId, string envStr, string shipId)
	{
		string text = $"BattleRecordDetail/{envStr}/GvGShip/{userId}/{shipId}/GvGShipBattleRecordDetail_Red.bytes";
		return HttpUrl + text;
	}

	public static string GetGVGBattleRecordDetailRedLocalDataKey(int userId, string envStr, string shipId)
	{
		return $"GVGRecordDetailRedLocalKey:{userId}_{envStr}_{shipId}";
	}

	public static string GetGVGBattleRecordDetailBlueHttpsUrl(int userId, string envStr, string shipId, string battleId)
	{
		string text = $"BattleRecordDetail/{envStr}/GvGShip/{userId}/{shipId}/{battleId}-GvGShipBattleRecordDetail_Blue.bytes";
		return HttpUrl + text;
	}

	public static string GetGVGBattleRecordDetailBlueLocalDataKey(int userId, string envStr, string shipId, string battleId)
	{
		return $"GVGRecordDetailBlueLocalKey:{userId}_{envStr}_{shipId}_{battleId}";
	}

	public static void SetStoreItemDiscount(StoreItem storeItem, GComponent Discount, bool ribbonVisible, int page = -1)
	{
		Controller controller = Discount.GetController("PageController");
		if (storeItem.IsFree)
		{
			((GObject)Discount).visible = true;
			controller.selectedIndex = 3;
			return;
		}
		float num = storeItem.Discount * 10f;
		if (HotUpdateProcess.Instance.IsRegionOutCN)
		{
			num = storeItem.InternationalDiscount * 10f;
		}
		if (storeItem.Tags != null)
		{
			for (int i = 0; i < storeItem.Tags.Count; i++)
			{
				if (storeItem.Tags[i].Contains("{Discount}"))
				{
					string raw = storeItem.Tags[i].Replace("{Discount}", "");
					num = NumericParser.Float(raw);
					break;
				}
			}
		}
		if (num >= 10f)
		{
			((GObject)Discount).visible = false;
			return;
		}
		((GObject)Discount).visible = true;
		if (num > 4f)
		{
			controller.selectedIndex = 2;
		}
		else if (num > 1f)
		{
			controller.selectedIndex = 1;
		}
		else
		{
			controller.selectedIndex = 0;
		}
		if (page >= 0)
		{
			controller.selectedIndex = page;
		}
		GObject val = null;
		GObject val2 = null;
		switch (controller.selectedIndex)
		{
		case 0:
			val = Discount.GetChild("discountDiyGold");
			val2 = Discount.GetChild("discountDiyGold_s");
			break;
		case 1:
			val = Discount.GetChild("discountDiyPurple");
			val2 = Discount.GetChild("discountDiyPurple_s");
			break;
		case 2:
			val = Discount.GetChild("discountDiyBlue");
			val2 = Discount.GetChild("discountDiyBlue_s");
			break;
		default:
			val = Discount.GetChild("discountDiyGold");
			val2 = Discount.GetChild("discountDiyGold_s");
			break;
		}
		if (HotUpdateProcess.Instance.IsRegionOutCN)
		{
			val2.visible = false;
			num *= 10f;
			val.text = (100 - Mathf.RoundToInt(num)).ToString();
		}
		else
		{
			string text = num.ToString(CultureInfo.InvariantCulture);
			string text2 = (text.Contains(".") ? text.Split('.')[0] : text);
			string text3 = (text.Contains(".") ? ("." + text.Split('.')[1]) : "");
			val.text = text2 ?? "";
			val2.text = text3;
		}
		GObject child = Discount.GetChild($"ribbon_{controller.selectedIndex}");
		if (child != null)
		{
			child.visible = ribbonVisible;
		}
	}

	public static void FiltrateSoldiersByRace(List<List<string>> soldierFilter, List<Soldier> soldiers)
	{
		if (soldierFilter == null || soldierFilter.Count <= 0)
		{
			return;
		}
		for (int num = soldiers.Count - 1; num >= 0; num--)
		{
			if (FiltrateSoldierByTag(soldiers[num], soldierFilter))
			{
				soldiers.RemoveAt(num);
			}
		}
	}

	public static void FiltrateSoldiersBySelected(List<string> soldiersSelected, List<Soldier> soldiers)
	{
		if (soldiersSelected == null || soldiersSelected.Count <= 0)
		{
			return;
		}
		for (int num = soldiers.Count - 1; num >= 0; num--)
		{
			if (soldiers[num] != null && soldiersSelected.Contains(soldiers[num]?.Id))
			{
				soldiers.RemoveAt(num);
			}
		}
	}

	public static void FilterSoldiersByLegendItemDungeon(List<Soldier> soldiers)
	{
		if (LegendItemDungeonUiHelper.CurSoldiers.Count <= 0)
		{
			return;
		}
		Dictionary<string, int> dictionary = new Dictionary<string, int>();
		for (int i = 0; i < LegendItemDungeonUiHelper.CurSoldiers.Count; i++)
		{
			dictionary.Add(LegendItemDungeonUiHelper.CurSoldiers[i].Key, LegendItemDungeonUiHelper.CurSoldiers[i].Value);
		}
		for (int num = soldiers.Count - 1; num >= 0; num--)
		{
			if (soldiers[num] != null && !dictionary.ContainsKey(soldiers[num].Id))
			{
				soldiers.RemoveAt(num);
			}
		}
	}

	private static bool FiltrateSoldierByTag(Soldier solider, List<List<string>> soldierFilter)
	{
		if (solider == null)
		{
			return false;
		}
		bool flag = false;
		for (int i = 0; i < soldierFilter.Count; i++)
		{
			flag = false;
			for (int j = 0; j < soldierFilter[i].Count; j++)
			{
				if (!solider.Tags.Contains(soldierFilter[i][j]))
				{
					flag = true;
					break;
				}
			}
			if (!flag)
			{
				break;
			}
		}
		return flag;
	}

	public static List<float> CalculatePercent(float percentSum, ref List<float> percentList)
	{
		List<float> list = new List<float>();
		int count = percentList.Count;
		for (int i = 0; i < count; i++)
		{
			list.Add(0f);
		}
		if (percentSum <= 0f || count <= 0)
		{
			return list;
		}
		List<KeyValuePair<int, float>> list2 = new List<KeyValuePair<int, float>>();
		float num = 0f;
		for (int j = 0; j < count; j++)
		{
			float num2 = percentList[j] / percentSum * 100f;
			float num3 = Mathf.Floor(num2);
			list[j] += num3;
			num += num3;
			list2.Add(new KeyValuePair<int, float>(j, num2 - num3));
		}
		list2.Sort((KeyValuePair<int, float> x, KeyValuePair<int, float> y) => -x.Value.CompareTo(y.Value));
		int num4 = Convert.ToInt32(100f - num);
		for (int num5 = 0; num5 < num4; num5++)
		{
			list[list2[num5].Key] += 1f;
		}
		return list;
	}

	public static void FguiTextClickLink(EventContext context)
	{
		if (context.data != null)
		{
			UniWebViewOpenUrl(context.data.ToString());
		}
	}

	public static void FguiBtnClickLink(EventContext context)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		object data = ((GObject)context.sender).data;
		if (data != null)
		{
			string url = $"{data}&token={GameController.Contexts.gameState.user.value.FeedbackToken}";
			OpenUrl(url);
		}
	}

	public static void CustomerServiceOnlineClickLink(EventContext context)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		string text = ((GObject)context.sender).data.ToString();
		Dictionary<string, string> obj = new Dictionary<string, string> { { "peerId", "10053174" } };
		string text2 = ((GameController.UserAgent == "pro" || GameController.UserAgent == "ios_pro") ? "" : GameController.UserAgent);
		string text3 = Application.version + "\t" + text2;
		Dictionary<string, string> dictionary = new Dictionary<string, string>
		{
			{ "userid", "-1" },
			{ "level", "-1" },
			{ "gold_hold", "0" },
			{ "diamond_hold", "0" },
			{ "total_revenue", "0" },
			{ "mainline_underway", "" },
			{ "create_time", "" },
			{ "farmer_hold", "0" },
			{
				"fmt_UserAgent",
				text3 ?? ""
			},
			{
				"model",
				SystemInfo.deviceModel
			},
			{
				"operating_system",
				SystemInfo.operatingSystem
			},
			{
				"deviceUniqueIdentifier",
				SystemInfo.deviceUniqueIdentifier
			}
		};
		if (GameController.Contexts.gameState.hasUser && GameController.Contexts.gameState.isDataReady)
		{
			dictionary["userid"] = $"{GameController.Contexts.gameState.user.value.UserId}";
			dictionary["level"] = $"{GameManagers.Instance.UserArchiveManager.GetUserLevel()}";
			string text4 = GameManagers.Instance.UserArchiveManager.GetCurrentLevelId();
			if (string.IsNullOrEmpty(text4))
			{
				text4 = "";
			}
			dictionary["mainline_underway"] = text4 ?? "";
			dictionary["gold_hold"] = string.Format("{0}", GameManagers.Instance.StockController.GetStock("Money"));
			dictionary["diamond_hold"] = string.Format("{0}", GameManagers.Instance.StockController.GetStock("Gem"));
			dictionary["total_revenue"] = $"{GameManagers.Instance.UserArchiveManager.GetTotalRecharge()}";
			dictionary["farmer_hold"] = $"{Dungeon.GetTotalManPower(GameManagers.Instance)}";
			string text5 = GameController.Contexts.gameState.user.value.RegisterAt.DateTime.ToString("s");
			dictionary["create_time"] = text5 ?? "";
		}
		string text6 = "accessId=" + UrlEncode("e83d6240-178c-11ec-8741-3dd2225b9764") + "&fromUrl=" + UrlEncode("http://" + text) + "&urlTitle=" + UrlEncode(text) + "&language=" + UrlEncode("ZHCN" + JsonHelper.ToJson(obj)) + "&customField=" + UrlEncode(JsonHelper.ToJson(dictionary));
		if (HotUpdateProcess.Instance.IsRegionOutCN)
		{
			OpenUrl(HotUpdateProcess.Instance.FeedBackUrl + "?Language=" + HotUpdateProcess.LanguageKey + "#/feedback?customField=" + UrlEncode(JsonHelper.ToJson(dictionary)));
		}
		else if (HotUpdateProcess.ChannelCode == "xipu")
		{
			OpenUrl("https://tb.53kf.com/code/client/10194316/1");
		}
		else
		{
			OpenUrl("https://ykf-webchat.yuntongxun.com/wapchat.html?" + text6);
		}
	}

	public static string UrlEncode(string str)
	{
		StringBuilder stringBuilder = new StringBuilder();
		byte[] bytes = Encoding.UTF8.GetBytes(str);
		for (int i = 0; i < bytes.Length; i++)
		{
			stringBuilder.Append("%" + Convert.ToString(bytes[i], 16));
		}
		return stringBuilder.ToString();
	}

	public static SkeletonAnimation SpineLoad(GGraph wrapper, string spineName, float size, string skinName, string aniName, List<string> skeletonList = null, bool isMask = false, bool aniLoop = true, float flap = 1f)
	{
		//IL_00a1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00eb: Unknown result type (might be due to invalid IL or missing references)
		//IL_0103: Unknown result type (might be due to invalid IL or missing references)
		//IL_010a: Expected O, but got Unknown
		//IL_0128: Unknown result type (might be due to invalid IL or missing references)
		Object obj = Object.Instantiate(Resources.Load("SpineTest", typeof(GameObject)));
		GameObject val = (GameObject)(object)((obj is GameObject) ? obj : null);
		SkeletonAnimation skeletonGraphic = ((val != null) ? val.GetComponent<SkeletonAnimation>() : null);
		SpawnManager.Instance.LoadAnimation(spineName, isMask).Then((Action<SkeletonDataAsset>)delegate(SkeletonDataAsset asset)
		{
			if (wrapper != null && !((GObject)wrapper).isDisposed && (Object)(object)skeletonGraphic != (Object)null)
			{
				((SkeletonRenderer)skeletonGraphic).skeletonDataAsset = asset;
				((SkeletonRenderer)skeletonGraphic).Initialize(true);
				SpineHelper.SetSkin((ISkeletonAnimation)(object)skeletonGraphic, skinName);
				skeletonGraphic.AnimationState.AddAnimation(0, aniName, aniLoop, 0f);
				skeletonList?.Add(spineName);
			}
		});
		if ((Object)(object)val != (Object)null)
		{
			val.transform.localScale = new Vector3(size, size, size);
			val.transform.localPosition = -new Vector3(0f, 0f, 100f);
			val.transform.localEulerAngles = -new Vector3(0f, 0f, 0f);
			DisplayObject displayObject = ((GObject)wrapper).displayObject;
			GoWrapper val2 = new GoWrapper(val);
			((DisplayObject)val2).SetXY(0f, 0f);
			((DisplayObject)val2).pivot = new Vector2(0.5f, 0.5f);
			((DisplayObject)val2).scaleX = flap;
			if (isMask)
			{
				val2.supportStencil = true;
			}
			wrapper.SetNativeObject((DisplayObject)(object)val2);
			displayObject.Dispose();
		}
		return skeletonGraphic;
	}

	public static List<Soldier> GetUnlockSoldierList()
	{
		List<Soldier> list = new List<Soldier>();
		string formationContext = GameController.Contexts.Service<IBattleFieldService>().LevelFormationContext;
		string mode = GameController.Contexts.Service<IBattleFieldService>().Level?.BattleMode.ToString() ?? BattleMode.RushMode.ToString();
		var source = from sid in GameManagers.Instance.StockController.GetOwnedSoldiers().Keys
			select new
			{
				sid = sid,
				s = GameManagers.Instance.SoldierManager.Get(sid)
			} into t
			orderby UI_Battle.GetFormationUnits(formationContext, mode).Contains(t.sid) descending
			select t;
		source = source.ThenByDescending(t => t.s.CombatPower * Singleton<SoldierFormationManager>.Instance.GetSoldierFormationNumber(t.s.Id, t.s.Level));
		list.AddRange(source.Select(t => t.s));
		return list;
	}

	public static void RenderSoldierItem(GButton soldierItem, string soldierId, List<string> textureList = null)
	{
		Soldier soldier = GameManagers.Instance.SoldierManager.Get(soldierId);
		((GComponent)soldierItem).GetChild("assemblyNote").visible = false;
		((GComponent)soldierItem).GetChild("occupation").visible = false;
		((GComponent)soldierItem).GetChild("title").text = "";
		((GComponent)soldierItem).GetChild("removeBack").visible = false;
		((GComponent)soldierItem).GetChild("removeNote").visible = false;
		((GComponent)soldierItem).GetChild("removeText").visible = false;
		((GComponent)soldierItem).GetChild("SoulStoneLevel").visible = true;
		((GComponent)soldierItem).GetChild("racePicture").visible = false;
		((GComponent)soldierItem).GetChild("num").text = "";
		((GComponent)soldierItem).GetChild("numNote").visible = false;
		((GComponent)soldierItem).GetChild("NumBack").visible = false;
		((GComponent)soldierItem).GetChild("lvFrame").visible = false;
		((GComponent)soldierItem).GetChild("lv").text = "";
		int num = (soldier.PotentialLevel + 2) / 2;
		((GComponent)soldierItem).GetChild("lvFrame").asLoader.url = $"ui://PublicResources/kuang_round 3_lv{num}";
		((GComponent)soldierItem).GetChild("icon").asLoader.url = "ui://PublicResources/" + GetIconPath(soldier.Id);
		string iconFrameBorderSoldier = GetIconFrameBorderSoldier(soldier.PotentialLevel);
		((GComponent)soldierItem).GetChild("iconFrame").asLoader.url = "ui://PublicResources/" + iconFrameBorderSoldier;
		FGUIManager.Instance.SetAlightSoulStoneForSoldierIcon(((GComponent)soldierItem).GetChild("SoulStoneLevel").asCom, soldier.PotentialLevel, soldier.PotentialProgress);
	}

	public static void ClassListRender(GList classList, int count, List<string> textureList)
	{
		((GObject)classList).visible = true;
		for (int i = 0; i < 5; i++)
		{
			GComponent asCom = ((GComponent)classList).GetChildAt(i).asCom;
			if (i > count - 1)
			{
				asCom.GetChild("icon").asLoader.url = "";
			}
			else
			{
				asCom.GetChild("icon").asLoader.url = "ui://PublicResources/icon_star_1";
			}
		}
	}

	public static void RenderLegendItem(GButton item, LegendItemUi legendItem, TextColorType colorType, List<string> textureList = null, int typeIndex = -1, bool grayed = false, LegendItemsShowType showType = LegendItemsShowType.Show)
	{
		//IL_0226: Unknown result type (might be due to invalid IL or missing references)
		//IL_022b: Unknown result type (might be due to invalid IL or missing references)
		if (typeIndex != -1)
		{
			((GComponent)item).GetController("TypeController").selectedIndex = typeIndex;
		}
		else
		{
			((GComponent)item).GetController("TypeController").selectedIndex = (LegendItemsHelper.EquippedLegendItems.ContainsKey(legendItem.InstanceId.ToString()) ? 1 : 0);
		}
		if (legendItem == null)
		{
			return;
		}
		string text = string.Empty;
		if (LegendItemsHelper.EquippedLegendItems.ContainsKey(legendItem.InstanceId.ToString()))
		{
			text = LegendItemsHelper.EquippedLegendItems[legendItem.InstanceId.ToString()];
		}
		if (showType == LegendItemsShowType.GvGModeChoice)
		{
			text = GameManagers.Instance.GetGvGSoldierIdByEquippedLegendItem(legendItem.InstanceId);
			if (string.IsNullOrEmpty(text))
			{
				((GComponent)item).GetController("TypeController").selectedIndex = 0;
			}
			else
			{
				((GComponent)item).GetController("TypeController").selectedIndex = 1;
			}
		}
		if (!string.IsNullOrEmpty(text))
		{
			Soldier soldier = GameManagers.Instance.SoldierManager.Get(text);
			GButton asButton = ((GComponent)item).GetChild("SoldierIcon").asButton;
			string itemId = soldier.ItemId;
			GObject child = ((GComponent)asButton).GetChild("icon");
			string iconPath = GetIconPath(itemId);
			child.asCom.GetChild("icon").asLoader.url = "ui://PublicResources/" + iconPath;
			((GComponent)asButton).GetChild("iconFrame").asLoader.url = GetSlimLevelFrameBorderSoldier(soldier.PotentialLevel);
			((GComponent)asButton).GetChild("numNote").visible = false;
			((GComponent)asButton).GetChild("num").text = "";
			((GComponent)asButton).GetChild("title").text = "";
			((GComponent)asButton).GetChild("title_Max").text = "";
		}
		((GComponent)item).GetChild("name").text = legendItem.LegendItemData.Data.Name;
		((GTextField)((GComponent)item).GetChild("Level").asRichTextField).strokeColor = Color32.op_Implicit(new Color32((byte)0, (byte)0, (byte)0, (byte)204));
		((GComponent)item).GetChild("Level").text = $"{legendItem.LegendItemData.EnhanceLevel}";
		((GComponent)item).GetChild("FrameIcon").asLoader.url = $"ui://PublicResources/frame_treasure_square_{legendItem.LegendItemData.Data.Rarity}";
		((GComponent)item).GetChild("LvFrame").asLoader.url = $"ui://PublicResources/board_corner_treasureframe_{legendItem.LegendItemData.Data.Rarity}";
		((GComponent)item).GetChild("Icon").asLoader.LoadArmsIcon(legendItem.LegendItemData.Data.Icon);
		int rarity = legendItem.LegendItemData.Data.Rarity;
		Controller controller = ((GComponent)item).GetController("ClassController");
		if (controller != null)
		{
			controller.selectedIndex = rarity - 1;
		}
		else
		{
			ClassListRender(((GComponent)item).GetChild("ClassList").asList, rarity, textureList);
		}
		((GComponent)item).GetChild("FrameIcon").grayed = grayed;
		((GComponent)item).GetChild("Icon").grayed = grayed;
		((GComponent)item).GetChild("LvFrame").grayed = grayed;
		((GComponent)item).GetChild("Level").grayed = grayed;
		((GComponent)item).GetChild("ClassList").grayed = grayed;
		((GComponent)item).GetChild("ClassIcon").grayed = grayed;
		((GComponent)item).GetChild("name").grayed = grayed;
		((GComponent)item).GetChild("Tip").grayed = grayed;
		((GComponent)item).GetChild("n14").grayed = grayed;
	}

	public static void RenderRankLegendItem(GButton item, RankSoldierEquipmentsInfo legendItem, TextColorType colorType, List<string> textureList = null, int typeIndex = -1, bool grayed = false)
	{
		//IL_009c: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a1: Unknown result type (might be due to invalid IL or missing references)
		//IL_0117: Unknown result type (might be due to invalid IL or missing references)
		//IL_011c: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00dc: Unknown result type (might be due to invalid IL or missing references)
		if (legendItem != null && LegendItemManager.LegendItemTemplates.ContainsKey(legendItem.LegendItemId))
		{
			GDELegendItemData gDELegendItemData = LegendItemManager.LegendItemTemplates[legendItem.LegendItemId];
			if (typeIndex != -1)
			{
				((GComponent)item).GetController("TypeController").selectedIndex = typeIndex;
			}
			else
			{
				((GComponent)item).GetController("TypeController").selectedIndex = 0;
			}
			switch (colorType)
			{
			case TextColorType.Dark:
				((GComponent)item).GetChild("name").asTextField.color = Color32.op_Implicit(colorItemList[gDELegendItemData.Rarity - 1]);
				break;
			case TextColorType.Light:
				((GComponent)item).GetChild("name").asTextField.color = Color32.op_Implicit(colorItemList[gDELegendItemData.Rarity - 1]);
				break;
			}
			((GComponent)item).GetChild("name").text = gDELegendItemData.Name;
			((GTextField)((GComponent)item).GetChild("Level").asRichTextField).strokeColor = Color32.op_Implicit(new Color32((byte)0, (byte)0, (byte)0, (byte)204));
			((GComponent)item).GetChild("Level").text = $"{legendItem.LegendItemEnhanceLevel}";
			((GComponent)item).GetChild("FrameIcon").asLoader.url = $"ui://PublicResources/frame_treasure_square_{gDELegendItemData.Rarity}";
			((GComponent)item).GetChild("LvFrame").asLoader.url = $"ui://PublicResources/board_corner_treasureframe_{gDELegendItemData.Rarity}";
			((GComponent)item).GetChild("Icon").asLoader.LoadArmsIcon(gDELegendItemData.Icon);
			int rarity = gDELegendItemData.Rarity;
			((GComponent)item).GetController("ClassController").selectedIndex = rarity - 1;
			((GComponent)item).GetChild("FrameIcon").grayed = grayed;
			((GComponent)item).GetChild("Icon").grayed = grayed;
			((GComponent)item).GetChild("LvFrame").grayed = grayed;
			((GComponent)item).GetChild("Level").grayed = grayed;
			((GComponent)item).GetChild("ClassList").grayed = grayed;
			((GComponent)item).GetChild("name").grayed = grayed;
			((GComponent)item).GetChild("Tip").grayed = grayed;
			((GComponent)item).GetChild("n14").grayed = grayed;
		}
	}

	public static void RenderLegendItem(GButton item, LegendItemBrief legendItem, TextColorType colorType, List<string> textureList = null, int typeIndex = -1, bool grayed = false)
	{
		//IL_009c: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a1: Unknown result type (might be due to invalid IL or missing references)
		//IL_0117: Unknown result type (might be due to invalid IL or missing references)
		//IL_011c: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00dc: Unknown result type (might be due to invalid IL or missing references)
		if (legendItem != null && LegendItemManager.LegendItemTemplates.ContainsKey(legendItem.ItemId))
		{
			GDELegendItemData gDELegendItemData = LegendItemManager.LegendItemTemplates[legendItem.ItemId];
			if (typeIndex != -1)
			{
				((GComponent)item).GetController("TypeController").selectedIndex = typeIndex;
			}
			else
			{
				((GComponent)item).GetController("TypeController").selectedIndex = 0;
			}
			switch (colorType)
			{
			case TextColorType.Dark:
				((GComponent)item).GetChild("name").asTextField.color = Color32.op_Implicit(colorItemList[gDELegendItemData.Rarity - 1]);
				break;
			case TextColorType.Light:
				((GComponent)item).GetChild("name").asTextField.color = Color32.op_Implicit(colorItemList[gDELegendItemData.Rarity - 1]);
				break;
			}
			((GComponent)item).GetChild("name").text = gDELegendItemData.Name;
			((GTextField)((GComponent)item).GetChild("Level").asRichTextField).strokeColor = Color32.op_Implicit(new Color32((byte)0, (byte)0, (byte)0, (byte)204));
			((GComponent)item).GetChild("Level").text = $"{legendItem.EnhanceLevel}";
			((GComponent)item).GetChild("FrameIcon").asLoader.url = $"ui://PublicResources/frame_treasure_square_{gDELegendItemData.Rarity}";
			((GComponent)item).GetChild("LvFrame").asLoader.url = $"ui://PublicResources/board_corner_treasureframe_{gDELegendItemData.Rarity}";
			((GComponent)item).GetChild("Icon").asLoader.LoadArmsIcon(gDELegendItemData.Icon);
			int rarity = gDELegendItemData.Rarity;
			((GComponent)item).GetController("ClassController").selectedIndex = rarity - 1;
			((GComponent)item).GetChild("FrameIcon").grayed = grayed;
			((GComponent)item).GetChild("Icon").grayed = grayed;
			((GComponent)item).GetChild("LvFrame").grayed = grayed;
			((GComponent)item).GetChild("Level").grayed = grayed;
			((GComponent)item).GetChild("ClassList").grayed = grayed;
			((GComponent)item).GetChild("name").grayed = grayed;
			((GComponent)item).GetChild("Tip").grayed = grayed;
			((GComponent)item).GetChild("n14").grayed = grayed;
		}
	}

	public static void RenderLegendItem(GButton item, LegendItemsHelper.BlackMarketLegendItem legendItem, List<string> textureList = null, bool grayed = false)
	{
		//IL_003d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0042: Unknown result type (might be due to invalid IL or missing references)
		//IL_007c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0081: Unknown result type (might be due to invalid IL or missing references)
		((GComponent)item).GetController("TypeController").selectedIndex = 0;
		if (legendItem != null)
		{
			((GComponent)item).GetChild("name").asTextField.color = Color32.op_Implicit(colorItemList[legendItem.Rarity - 1]);
			((GComponent)item).GetChild("name").text = legendItem.Name;
			((GTextField)((GComponent)item).GetChild("Level").asRichTextField).strokeColor = Color32.op_Implicit(new Color32((byte)0, (byte)0, (byte)0, (byte)204));
			((GComponent)item).GetChild("Level").text = $"{legendItem.ItemData.EnhanceLevel}";
			((GComponent)item).GetChild("FrameIcon").asLoader.url = $"ui://PublicResources/frame_treasure_square_{legendItem.Rarity}";
			((GComponent)item).GetChild("LvFrame").asLoader.url = $"ui://PublicResources/board_corner_treasureframe_{legendItem.Rarity}";
			((GComponent)item).GetChild("Icon").asLoader.LoadArmsIcon(legendItem.Icon);
			int rarity = legendItem.Rarity;
			((GComponent)item).GetController("ClassController").selectedIndex = rarity - 1;
			((GComponent)item).GetChild("FrameIcon").grayed = grayed;
			((GComponent)item).GetChild("Icon").grayed = grayed;
			((GComponent)item).GetChild("LvFrame").grayed = grayed;
			((GComponent)item).GetChild("Level").grayed = grayed;
			((GComponent)item).GetChild("ClassList").grayed = grayed;
			((GComponent)item).GetChild("name").grayed = grayed;
			((GComponent)item).GetChild("Tip").grayed = grayed;
			((GComponent)item).GetChild("n14").grayed = grayed;
		}
	}

	public static void RenderNoLegendItem(GButton item, List<string> textureList = null)
	{
		((GComponent)item).GetController("TypeController").selectedIndex = 3;
		((GComponent)item).GetChild("FrameIcon").asLoader.url = "ui://PublicResources/frame_treasure_square_1";
		((GComponent)item).GetChild("Icon").asLoader.url = "";
	}

	public static void RenderConsumptionItem(GButton button, string itemKey, int itemValue, List<string> textureList = null)
	{
		FGUIManager.Instance.SetItemIconAndFrame(((GComponent)button).GetChild("icon").asLoader, itemKey, textureList);
		((GComponent)button).GetChild("reqDesc").asCom.GetChild("curPrice").text = $"{itemValue}/{GameManagers.Instance.StockController.GetStock(itemKey)}";
		((GComponent)button).GetChild("reqDesc").asCom.GetChild("originPrice").visible = false;
	}

	public static void DestoryUiSfx(GGraph backGraph, GameObject sfx, float delay)
	{
		ScriptApi.CreateTimer(delay, delegate
		{
			if (!((GObject)backGraph).isDisposed)
			{
				GGraph obj = backGraph;
				if (obj != null)
				{
					((GObject)obj).displayObject.Dispose();
				}
				if ((Object)(object)sfx != (Object)null)
				{
					SpawnManager.Instance.Destroy(sfx);
				}
			}
		});
	}

	public static void HideUiSfx(GGraph backGraph, GameObject sfx, float delay)
	{
		ScriptApi.CreateTimer(delay, delegate
		{
			if (!((GObject)backGraph).isDisposed && (Object)(object)sfx != (Object)null)
			{
				SpawnManager.Instance.Destroy(sfx);
			}
		});
	}

	public static int GetMoneyTimeMachineMaxUseNum(string _itemId)
	{
		if (_timeMachineMaxUseCount.ContainsKey(_itemId))
		{
			return _timeMachineMaxUseCount[_itemId];
		}
		return 1;
	}

	public static List<int> GetFormationUnlockCost()
	{
		return _formationUnlockCost;
	}

	public static UIPanel GetProductLoader(GameObject obj, string iconName, string iconName1 = "", float iconScale = 0.005f)
	{
		//IL_005b: Unknown result type (might be due to invalid IL or missing references)
		UIPanel component = obj.GetComponent<UIPanel>();
		UIPanel val = null;
		if ((Object)(object)component != (Object)null && component.componentName == "ProductLoader")
		{
			val = component;
		}
		else
		{
			UIPanel val2 = obj.AddComponent<UIPanel>();
			val2.packageName = "PublicResources";
			val2.componentName = "ProductLoader";
			val2.container.renderMode = (RenderMode)2;
			val2.SetSortingOrder(0, true);
			val2.sortingOrder = 0;
			val2.CreateUI();
			val = val2;
		}
		val.ui.GetChild("icon").asLoader.url = "ui://PublicResources/" + iconName;
		val.ui.GetChild("iconb").asLoader.url = "ui://PublicResources/" + iconName1;
		if (iconName == "sack3")
		{
			((GObject)val.ui).SetScale(0.004f, 0.004f);
		}
		else
		{
			((GObject)val.ui).SetScale(iconScale, iconScale);
		}
		MeshRenderer component2 = ((Component)val.ui.GetChild("icon").displayObject.gameObject.transform.Find("Image")).GetComponent<MeshRenderer>();
		if ((Object)(object)component2 != (Object)null)
		{
			((Renderer)component2).sortingLayerName = "Default";
			((Renderer)component2).sortingOrder = 0;
		}
		MeshRenderer component3 = ((Component)val.ui.GetChild("iconb").displayObject.gameObject.transform.Find("Image")).GetComponent<MeshRenderer>();
		if ((Object)(object)component2 != (Object)null)
		{
			((Renderer)component3).sortingLayerName = "Default";
			((Renderer)component3).sortingOrder = 0;
		}
		return val;
	}

	public static string GetSoldierSummonIcon(string modelId, int _level = 1)
	{
		Soldier soldier = GameManagers.Instance.SoldierManager.Get(modelId);
		string text = "";
		if (string.IsNullOrWhiteSpace(soldier.ItemId))
		{
			string text2 = GameManagers.Instance.SoldierManager.Get(soldier.Data.ParentSoldierId)?.ItemId;
			string arg = (string.IsNullOrWhiteSpace(text2) ? "I14003" : text2);
			text = $"{arg}_{_level}";
		}
		else
		{
			text = $"{soldier.ItemId}_{_level}";
		}
		return "ui://PublicResources/" + text;
	}

	public static bool CombatCapabilityUpToPar(string _levelId, int ourCombat, int enemyCombat)
	{
		if (_levelId == "P120" || _levelId == "P205" || _levelId == "P215")
		{
			return ourCombat >= enemyCombat;
		}
		return true;
	}

	public static bool ShowCombatPowerTip(string chapterId)
	{
		return chapterId == "C1002";
	}

	public static void LoadSomeUiPublicResources(Action action, string uiBagName = "PublicResourceStoreItemIcons")
	{
		if (UiPublicResourcesDic.ContainsKey(uiBagName))
		{
			UiPublicResourcesDic[uiBagName]++;
			action();
			return;
		}
		PooledList<Promise<AssetBundle>> list = ObjectPool<PooledList<Promise<AssetBundle>>>.Spawn((Func<PooledList<Promise<AssetBundle>>>)(() => new PooledList<Promise<AssetBundle>>()));
		((List<Promise<AssetBundle>>)(object)list).Add(AssetsManager.Instance.LoadAssetBundle("FGUI/" + uiBagName + "/" + uiBagName + "_desc.ab"));
		((List<Promise<AssetBundle>>)(object)list).Add(AssetsManager.Instance.LoadAssetBundle("FGUI/" + uiBagName + "/" + uiBagName + "_res.ab"));
		Promise<AssetBundle>.All((IEnumerable<IPromise<AssetBundle>>)list).Then((Action<IEnumerable<AssetBundle>>)delegate(IEnumerable<AssetBundle> assetBundles)
		{
			AssetBundle val = null;
			AssetBundle val2 = null;
			int num = 0;
			foreach (AssetBundle assetBundle in assetBundles)
			{
				switch (num)
				{
				case 0:
					val = assetBundle;
					break;
				case 1:
					val2 = assetBundle;
					break;
				}
				num++;
			}
			if (val != null && val2 != null)
			{
				if (UiPublicResourcesDic.ContainsKey(uiBagName))
				{
					UiPublicResourcesDic[uiBagName]++;
				}
				else
				{
					UIPackage.AddPackage(val, val2);
					UiPublicResourcesDic.Add(uiBagName, 1);
				}
				action?.Invoke();
			}
			else
			{
				Debug.LogError((object)("FGUI " + uiBagName + " load failed."));
			}
		}).Finally((Action)delegate
		{
			list.UnSpawn();
		});
	}

	public static void UnloadPackage(string uiBagName = "PublicResourceStoreItemIcons")
	{
		if (!UiPublicResourcesDic.ContainsKey(uiBagName) || uiBagName == "PublicResources")
		{
			return;
		}
		int num = UiPublicResourcesDic[uiBagName];
		if (num > 1)
		{
			UiPublicResourcesDic[uiBagName]--;
			return;
		}
		string text = "FGUI/" + uiBagName + "/" + uiBagName;
		AssetsManager.Instance.UnloadAssetBundle(text + "_desc.ab");
		if (AssetsManager.Instance.IsAssetBundleExists(text + "_res.ab"))
		{
			AssetsManager.Instance.UnloadAssetBundle(text + "_res.ab");
		}
		if (!AssetsManager.Instance.IsAssetBundleInUsing(text + "_desc.ab"))
		{
			UiPublicResourcesDic.Remove(uiBagName);
			UIPackage.RemovePackage(uiBagName);
		}
	}

	public static float GetLevelMoneyOutput(string levelId, bool containBonus = true)
	{
		float percentFloatPayload = GameManagers.Instance.ModifierManager.GetPercentFloatPayload("AutoProduceEfficiency");
		float num = (containBonus ? (percentFloatPayload + 1f) : 1f);
		if (levelMoneyOutputCache.ContainsKey(levelId))
		{
			return levelMoneyOutputCache[levelId] * num;
		}
		Level levelInstance = GameManagers.Instance.ChapterManager.GetLevelInstance(levelId);
		if (levelInstance == null)
		{
			return 0f;
		}
		if (levelInstance.Chapter.ChapterId == "C1000" || levelInstance.Chapter.ChapterId == "C10000" || levelInstance.Chapter.ChapterId == "C10001" || levelInstance.Chapter.ChapterId == "C1000" || levelInstance.Chapter.ChapterId == "C10002")
		{
			return 0f;
		}
		if (levelInstance.Chapter.ChapterId == "FightTest")
		{
			return 0f;
		}
		List<string> level_IDs = levelInstance.Chapter.Level_IDs;
		int num2 = level_IDs.IndexOf(levelId);
		if (num2 == -1)
		{
			return 0f;
		}
		if (!levelInstance.AutoProduceBonus.ContainsKey("Money"))
		{
			return 0f;
		}
		float num3 = levelInstance.AutoProduceBonus["Money"];
		if (num2 > 0)
		{
			float num4 = levelInstance.Chapter.GetLevels(num2 - 1).AutoProduceBonus["Money"];
			float num5 = num3 - num4;
			if (!levelMoneyOutputCache.ContainsKey(levelId))
			{
				levelMoneyOutputCache.Add(levelId, num5);
			}
			return num5 * num;
		}
		if (levelInstance.Chapter.PrevChapter == null)
		{
			return 0f;
		}
		if (levelInstance.Chapter.PrevChapter.ChapterId == "C1000" || levelInstance.Chapter.PrevChapter.ChapterId == "C10000" || levelInstance.Chapter.PrevChapter.ChapterId == "C10001" || levelInstance.Chapter.PrevChapter.ChapterId == "C1000" || levelInstance.Chapter.PrevChapter.ChapterId == "C10002")
		{
			if (!levelMoneyOutputCache.ContainsKey(levelId))
			{
				levelMoneyOutputCache.Add(levelId, num3);
			}
			return num3 * num;
		}
		int key = levelInstance.Chapter.PrevChapter.Level_IDs.Count - 1;
		if (levelInstance.Chapter.PrevChapter.Levels.ContainsKey(key))
		{
			float num6 = levelInstance.Chapter.PrevChapter.Levels[key].AutoProduceBonus["Money"];
			float num7 = num3 - num6;
			if (!levelMoneyOutputCache.ContainsKey(levelId))
			{
				levelMoneyOutputCache.Add(levelId, num7);
			}
			return num7 * num;
		}
		return 0f;
	}

	public static float GetChapterMoneyOutput(string chapterId)
	{
		float percentFloatPayload = GameManagers.Instance.ModifierManager.GetPercentFloatPayload("AutoProduceEfficiency");
		float num = percentFloatPayload + 1f;
		if (chapterMoneyOutputCache.ContainsKey(chapterId))
		{
			return chapterMoneyOutputCache[chapterId] * num;
		}
		Chapter previousChapter = GameManagers.Instance.ChapterManager.GetPreviousChapter(chapterId);
		if (previousChapter == null)
		{
			return 0f;
		}
		Level levels = previousChapter.GetLevels(previousChapter.Level_IDs.Count - 1);
		if (!GameManagers.Instance.ChapterManager.IsChapterDone(chapterId))
		{
			Dictionary<string, float> formattedAutoProductions = GameManagers.Instance.UserArchiveManager.GetFormattedAutoProductions(containBonus: false);
			float num2 = (formattedAutoProductions.ContainsKey("Money") ? formattedAutoProductions["Money"] : 0f);
			if (previousChapter.ChapterId == "C1000" || previousChapter.ChapterId == "C10000" || previousChapter.ChapterId == "C10001" || previousChapter.ChapterId == "C1000" || previousChapter.ChapterId == "C10002")
			{
				return num2 * num;
			}
			return (num2 - levels.AutoProduceBonus["Money"]) * num;
		}
		Chapter chapter = GameManagers.Instance.ChapterManager.GetChapter(chapterId);
		Level levels2 = chapter.GetLevels(chapter.Level_IDs.Count - 1);
		float num3 = ((previousChapter.ChapterId == "C1000" || previousChapter.ChapterId == "C10000" || previousChapter.ChapterId == "C10001" || previousChapter.ChapterId == "C1000" || previousChapter.ChapterId == "C10002") ? 0f : levels.AutoProduceBonus["Money"]);
		float num4 = levels2.AutoProduceBonus["Money"] - num3;
		chapterMoneyOutputCache.Add(chapterId, num4);
		return num4 * num;
	}

	public static void UseFightTestBox(string _itemId)
	{
		List<Modifier> list = Shift.Legion.Common.Models.Item.Effect(GameManagers.Instance, _itemId);
		string value = "";
		if (list != null)
		{
			foreach (Modifier item in list)
			{
				if (item.ModifierId == "LevelID")
				{
					value = item.PayloadDictionary?.First().Value.ToString();
					break;
				}
			}
		}
		if (!string.IsNullOrEmpty(value))
		{
			CommandFactory.CreateOpenSceneCommand("BattleField", new SceneBattleFieldArguments(new Dictionary<string, object>
			{
				{ "LevelId", value },
				{ "Asset", "Prefabs/BattleField" },
				{ "ForceCloseOtherUi", true },
				{ "TaskCompletionSource", null }
			}));
		}
	}

	public static void ShowConfirmDialog(string message, Action action)
	{
		UnityUiService.Instance.OpenPanel(UI_UniversalConfirmPopup.Name, new Dictionary<string, object>
		{
			{ "Content", message },
			{
				"Buttons",
				new Dictionary<string, Action> { { "Confirm", action } }
			},
			{ "PageIndex", 4 },
			{ "ClickSound", "Confirm" },
			{ "Order", 999999 }
		}, multiMode: false, ignoreQueue: true);
	}

	public static void ShowConfirmAndCancelDialog(string message, Action confirmAction, Action cancelAction, bool mirror = true)
	{
		UnityUiService.Instance.OpenPanel(UI_UniversalConfirmPopup.Name, new Dictionary<string, object>
		{
			{ "Content", message },
			{
				"Buttons",
				new Dictionary<string, Action>
				{
					{ "Confirm", confirmAction },
					{ "Cancel", cancelAction }
				}
			},
			{ "PageIndex", 0 },
			{ "ClickSound", "Confirm" },
			{ "Mirror", mirror }
		}, multiMode: false, ignoreQueue: true);
	}

	public static void NumberTextChangeGTween(float startValue, float endValue, GTextField textField, float delay = 0.8f, EaseType easeType = (EaseType)0)
	{
		//IL_0031: Unknown result type (might be due to invalid IL or missing references)
		//IL_003f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0049: Expected O, but got Unknown
		//IL_0050: Unknown result type (might be due to invalid IL or missing references)
		//IL_005a: Expected O, but got Unknown
		if (textField == null)
		{
			return;
		}
		GTween.To(startValue, endValue, delay).SetEase(easeType).OnUpdate((GTweenCallback1)delegate(GTweener tweener)
		{
			if (!((GObject)textField).isDisposed)
			{
				((GObject)textField).text = $"{Convert.ToInt32(Mathf.Floor(tweener.value.x))}";
			}
		})
			.OnComplete((GTweenCallback)delegate
			{
				if (!((GObject)textField).isDisposed)
				{
					((GObject)textField).text = $"{Convert.ToInt32(endValue)}";
				}
			});
	}

	public static void LoadUiSpecialConfig()
	{
		//IL_0010: Unknown result type (might be due to invalid IL or missing references)
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		uiSpecialConfig = new UiSpecialConfig();
		TextAsset val = Addressables.LoadAssetAsync<TextAsset>((object)"UiSpecialConfig").WaitForCompletion();
		if (!string.IsNullOrEmpty(val.text))
		{
			uiSpecialConfig = JsonHelper.ToObject<UiSpecialConfig>(val.text);
		}
	}

	public static string ToAddCouponBtnText(string num, string total = null)
	{
		string text = num.ToString();
		if (!string.IsNullOrEmpty(total))
		{
			text = text + "[color=#dba04c][size=26]/" + total + "[/size][/color]";
		}
		return text;
	}

	public static void LoadSpine_Addressable(GGraph spineLoader, string name, float scale = 1f, Action<SkeletonAnimation> onSuccess = null)
	{
		//IL_007a: Unknown result type (might be due to invalid IL or missing references)
		//IL_009f: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ce: Unknown result type (might be due to invalid IL or missing references)
		//IL_00df: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e5: Expected O, but got Unknown
		//IL_00f3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f8: Unknown result type (might be due to invalid IL or missing references)
		GameObject spineObject = default(GameObject);
		ref GameObject reference = ref spineObject;
		Object obj = Object.Instantiate(Resources.Load("SpineTest", typeof(GameObject)));
		reference = (GameObject)(object)((obj is GameObject) ? obj : null);
		if ((Object)(object)spineObject == (Object)null)
		{
			ILRuntimeDebug.LogError("UIHelper.LoadSpine: SpineTest加载失败");
			return;
		}
		spineObject.SetActive(false);
		spineObject.transform.localScale = new Vector3(scale, scale, scale);
		spineObject.transform.localPosition = -new Vector3(0f, 0f, 0f);
		spineObject.transform.localEulerAngles = -new Vector3(0f, 0f, 0f);
		GoWrapper nativeObject = new GoWrapper(spineObject);
		spineLoader.SetNativeObject((DisplayObject)(object)nativeObject);
		AsyncOperationHandle<SkeletonDataAsset> val = Addressables.LoadAssetAsync<SkeletonDataAsset>((object)name);
		val.Completed += delegate(AsyncOperationHandle<SkeletonDataAsset> res)
		{
			SkeletonAnimation component = spineObject.GetComponent<SkeletonAnimation>();
			((Behaviour)component).enabled = false;
			if (!((GObject)spineLoader).isDisposed && !((Object)(object)res.Result == (Object)null) && !((Object)(object)component == (Object)null))
			{
				((SkeletonRenderer)component).skeletonDataAsset = res.Result;
				((SkeletonRenderer)component).Initialize(true);
				((SkeletonRenderer)component).ClearState();
				component.state.ClearTracks();
				component.state.ClearTrack(0);
				onSuccess?.Invoke(component);
				((Behaviour)component).enabled = true;
				spineObject.SetActive(true);
			}
		};
	}

	public static GameObject LoadSoilderSpine_Addressable(GGraph spineLoader, string name, float scale = 1f, Action<SkeletonAnimation> onSuccess = null, bool isMask = false, float goWrapperScale = 1f)
	{
		//IL_006f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0094: Unknown result type (might be due to invalid IL or missing references)
		//IL_0099: Unknown result type (might be due to invalid IL or missing references)
		//IL_00be: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ea: Expected O, but got Unknown
		GameObject spineObject = default(GameObject);
		ref GameObject reference = ref spineObject;
		Object obj = Object.Instantiate(Resources.Load("SpineTest", typeof(GameObject)));
		reference = (GameObject)(object)((obj is GameObject) ? obj : null);
		if ((Object)(object)spineObject == (Object)null)
		{
			ILRuntimeDebug.LogError("UIHelper.LoadSpine: SpineTest加载失败");
			return null;
		}
		spineObject.transform.localScale = new Vector3(scale, scale, scale);
		spineObject.transform.localPosition = -new Vector3(0f, 0f, 0f);
		spineObject.transform.localEulerAngles = -new Vector3(0f, 0f, 0f);
		GoWrapper nativeObject = new GoWrapper(spineObject)
		{
			supportStencil = true,
			scaleX = goWrapperScale
		};
		spineLoader.SetNativeObject((DisplayObject)(object)nativeObject);
		SpawnManager.Instance.LoadSoldierSpine(spineObject, name, isMask).Then((Action<SkeletonDataAsset>)delegate(SkeletonDataAsset asset)
		{
			if (!((GObject)spineLoader).isDisposed && !((Object)(object)asset == (Object)null))
			{
				SkeletonAnimation component = spineObject.GetComponent<SkeletonAnimation>();
				if (!((Object)(object)component == (Object)null))
				{
					((SkeletonRenderer)component).skeletonDataAsset = asset;
					((SkeletonRenderer)component).Initialize(true);
					((SkeletonRenderer)component).ClearState();
					component.state.ClearTracks();
					onSuccess?.Invoke(component);
				}
			}
		});
		return spineObject;
	}

	public static GameObject LoadSpine_AB(GGraph spineLoader, string name, float scale = 1f, Action<SkeletonAnimation> onSuccess = null, bool isMask = false, float goWrapperScale = 1f)
	{
		//IL_006f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0094: Unknown result type (might be due to invalid IL or missing references)
		//IL_0099: Unknown result type (might be due to invalid IL or missing references)
		//IL_00be: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ea: Expected O, but got Unknown
		GameObject spineObject = default(GameObject);
		ref GameObject reference = ref spineObject;
		Object obj = Object.Instantiate(Resources.Load("SpineTest", typeof(GameObject)));
		reference = (GameObject)(object)((obj is GameObject) ? obj : null);
		if ((Object)(object)spineObject == (Object)null)
		{
			ILRuntimeDebug.LogError("UIHelper.LoadSpine: SpineTest加载失败");
			return null;
		}
		spineObject.transform.localScale = new Vector3(scale, scale, scale);
		spineObject.transform.localPosition = -new Vector3(0f, 0f, 0f);
		spineObject.transform.localEulerAngles = -new Vector3(0f, 0f, 0f);
		GoWrapper nativeObject = new GoWrapper(spineObject)
		{
			supportStencil = true,
			scaleX = goWrapperScale
		};
		spineLoader.SetNativeObject((DisplayObject)(object)nativeObject);
		SpawnManager.Instance.LoadAnimation(name, isMask).Then((Action<SkeletonDataAsset>)delegate(SkeletonDataAsset asset)
		{
			if (!((GObject)spineLoader).isDisposed && !((Object)(object)asset == (Object)null))
			{
				SkeletonAnimation component = spineObject.GetComponent<SkeletonAnimation>();
				if (!((Object)(object)component == (Object)null))
				{
					((SkeletonRenderer)component).skeletonDataAsset = asset;
					((SkeletonRenderer)component).Initialize(true);
					((SkeletonRenderer)component).ClearState();
					component.state.ClearTracks();
					onSuccess?.Invoke(component);
				}
			}
		});
		return spineObject;
	}

	public static GameObject LoadSpine_AB(string name, float scale = 1f, Action<SkeletonAnimation> onSuccess = null, bool isMask = false)
	{
		//IL_0068: Unknown result type (might be due to invalid IL or missing references)
		//IL_008d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0092: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bc: Unknown result type (might be due to invalid IL or missing references)
		GameObject spineObject = default(GameObject);
		ref GameObject reference = ref spineObject;
		Object obj = Object.Instantiate(Resources.Load("SpineTest", typeof(GameObject)));
		reference = (GameObject)(object)((obj is GameObject) ? obj : null);
		if ((Object)(object)spineObject == (Object)null)
		{
			ILRuntimeDebug.LogError("UIHelper.LoadSpine: SpineTest加载失败");
			return null;
		}
		spineObject.transform.localScale = new Vector3(scale, scale, scale);
		spineObject.transform.localPosition = -new Vector3(0f, 0f, 0f);
		spineObject.transform.localEulerAngles = -new Vector3(0f, 0f, 0f);
		SpawnManager.Instance.LoadAnimation(name, isMask).Then((Action<SkeletonDataAsset>)delegate(SkeletonDataAsset asset)
		{
			if (!((Object)(object)spineObject == (Object)null))
			{
				SkeletonAnimation component = spineObject.GetComponent<SkeletonAnimation>();
				if (!((Object)(object)asset == (Object)null) && !((Object)(object)component == (Object)null))
				{
					((SkeletonRenderer)component).skeletonDataAsset = asset;
					((SkeletonRenderer)component).Initialize(true);
					((SkeletonRenderer)component).ClearState();
					component.state.ClearTracks();
					onSuccess?.Invoke(component);
				}
			}
		});
		return spineObject;
	}

	public static void LoadAbilityIcon(this GLoader gLoader, string iconName)
	{
		gLoader.LoadIcon("PublicSkillIcons", iconName);
	}

	public static void LoadArmsIcon(this GLoader gLoader, string iconName)
	{
		gLoader.LoadIcon("PublicArmsIcons", iconName);
	}

	public static void LoadBlueprintIcon(this GLoader gLoader, string iconName)
	{
		gLoader.LoadIcon("PublicBlueprintIcons", iconName);
	}

	public static void LoadIcon(this GLoader gLoader, string bundleName, string iconName)
	{
		string iconUrl = "ui://" + bundleName + "/" + iconName;
		LoadSomeUiPublicResources(delegate
		{
			gLoader.url = iconUrl;
			CacheIconRefCount(bundleName, iconName);
		}, bundleName);
	}

	private static void CacheIconRefCount(string bundleName, string iconName)
	{
		string item = bundleName + "/" + iconName;
		int num = IconPathUsed.IndexOf(item);
		if (num != -1)
		{
			IconPathUsed.RemoveAt(num);
			RemoveIconRefCount(bundleName);
		}
		else if (IconBundleRef.ContainsKey(bundleName))
		{
			IconBundleRef[bundleName]++;
		}
		else
		{
			IconBundleRef.Add(bundleName, 1);
		}
		IconPathUsed.Add(item);
		while (IconPathUsed.Count > 100)
		{
			string text = IconPathUsed[0];
			IconPathUsed.RemoveAt(0);
			string name = text.Split('/')[0];
			RemoveIconRefCount(name);
		}
	}

	private static void RemoveIconRefCount(string name)
	{
		if (IconBundleRef.ContainsKey(name))
		{
			IconBundleRef[name]--;
			if (IconBundleRef[name] == 0)
			{
				IconBundleRef.Remove(name);
			}
			UnloadPackage(name);
		}
	}

	public static void DisplayStockChangedRecords(this IEnumerable<StockChangeRecord> records)
	{
		foreach (string item in records.Select((StockChangeRecord r) => $"{Shift.Legion.Common.Models.Item.Name(GameManagers.Instance, r.ItemId)}+{r.Offset}"))
		{
			item.ToTip();
		}
	}

	public static Vector2 GetGObjectPositionOnGRoot(GObject gObject, Vector2 offset)
	{
		//IL_003e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0044: Unknown result type (might be due to invalid IL or missing references)
		//IL_0049: Unknown result type (might be due to invalid IL or missing references)
		//IL_004f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0054: Unknown result type (might be due to invalid IL or missing references)
		//IL_005e: Unknown result type (might be due to invalid IL or missing references)
		//IL_006f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0077: Unknown result type (might be due to invalid IL or missing references)
		//IL_0078: Unknown result type (might be due to invalid IL or missing references)
		//IL_007b: Unknown result type (might be due to invalid IL or missing references)
		if (gObject.pivotAsAnchor)
		{
			offset.x -= gObject.pivotX * gObject.width;
			offset.y -= gObject.pivotY * gObject.height;
		}
		Vector2 result = gObject.LocalToRoot(offset, GRoot.inst);
		Vector2 xy = ((GObject)GRoot.inst).xy;
		result.x -= xy.x;
		result.y -= xy.y;
		return result;
	}

	private static void ProcessAttributeBundleModifier(Modifier modifier, ref Dictionary<string, Dictionary<string, object>> fixedModifierDict, ref Dictionary<string, Dictionary<string, object>> percentModifierDict, int mod)
	{
		string text = "";
		if (modifier.PayloadDictionary.ContainsKey("SoldierId"))
		{
			text = modifier.PayloadDictionary["SoldierId"].ToString();
		}
		else if (modifier.PayloadDictionary.ContainsKey("AiType"))
		{
			text = modifier.PayloadDictionary["AiType"].ToString();
		}
		foreach (KeyValuePair<string, object> item in modifier.PayloadDictionary)
		{
			if (item.Key == "SoldierId" || item.Key == "AiType")
			{
				continue;
			}
			string text2 = item.Value.ToString();
			if (text2.Length <= 0)
			{
				continue;
			}
			bool flag;
			object obj;
			float num;
			if (text2.IndexOf('%') == -1)
			{
				flag = false;
				obj = fixedModifierDict;
				num = NumericParser.Float(text2);
			}
			else
			{
				flag = true;
				obj = percentModifierDict;
				num = NumericParser.FloatPercent(text2);
			}
			if (text.Length > 0)
			{
				if (!((Dictionary<string, Dictionary<string, Dictionary<string, object>>>)obj).ContainsKey(text))
				{
					((Dictionary<string, Dictionary<string, Dictionary<string, object>>>)obj).Add(text, new Dictionary<string, Dictionary<string, object>>());
				}
				obj = ((Dictionary<string, Dictionary<string, Dictionary<string, object>>>)obj)[text];
			}
			if (!((Dictionary<string, Dictionary<string, object>>)obj).ContainsKey(item.Key))
			{
				((Dictionary<string, Dictionary<string, object>>)obj).Add(item.Key, new Dictionary<string, object> { { "Payload", 0f } });
			}
			if (Modifier.NeedStackMultipleProcess(item.Key) && flag)
			{
				num += 1f;
				if (mod < 0)
				{
					num = 1f / num;
				}
				((Dictionary<string, Dictionary<string, object>>)obj)[item.Key]["Payload"] = (float)((Dictionary<string, Dictionary<string, object>>)obj)[item.Key]["Payload"] * num;
			}
			else
			{
				((Dictionary<string, Dictionary<string, object>>)obj)[item.Key]["Payload"] = (float)((Dictionary<string, Dictionary<string, object>>)obj)[item.Key]["Payload"] + num * (float)mod;
			}
		}
	}

	private static void ProcessCommonModifier(Modifier modifier, ref Dictionary<string, Dictionary<string, object>> fixedModifierDict, ref Dictionary<string, Dictionary<string, object>> percentModifierDict, int mod)
	{
		if (!modifier.PayloadDictionary.ContainsKey("Payload"))
		{
			return;
		}
		string text = modifier.PayloadDictionary["Payload"].ToString();
		if (modifier.PayloadDictionary["Payload"] is IDictionary)
		{
			Dictionary<string, object> dictionary = (Dictionary<string, object>)modifier.PayloadDictionary["Payload"];
			text = (dictionary.TryGetValue("Payload", out var value) ? value.ToString() : string.Empty);
		}
		if (text.Length > 0)
		{
			Dictionary<string, Dictionary<string, object>> dictionary2 = percentModifierDict;
			float num = NumericParser.FloatPercent(text);
			if (dictionary2 == null)
			{
			}
			if (!dictionary2.ContainsKey(modifier.ModifierId))
			{
				dictionary2.Add(modifier.ModifierId, new Dictionary<string, object>());
				dictionary2[modifier.ModifierId].Add("Payload", 0f);
			}
			dictionary2[modifier.ModifierId]["Payload"] = (float)dictionary2[modifier.ModifierId]["Payload"] + num * (float)mod;
		}
	}

	private static void ExtractAttrBonusData(Dictionary<string, float> bonusData, ref Dictionary<string, float> bonusDict)
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

	private static void ExtractAttrBonusData(Dictionary<string, object> bonusData, ref Dictionary<string, float> bonusDict)
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

	private static void ExtractItemEntriesAttrBonusData(List<ItemEntryBrief> entries, ref Dictionary<string, float> bonusDict, bool percentBonus, FakeSoldier _fakeSoldier)
	{
		if (entries == null)
		{
			return;
		}
		foreach (ItemEntryBrief entry in entries)
		{
			ExtractItemEntryAttrBonusData(entry, ref bonusDict, percentBonus, _fakeSoldier);
		}
	}

	private static void ExtractItemEntryAttrBonusData(ItemEntryBrief entry, ref Dictionary<string, float> bonusDict, bool percentBonus, FakeSoldier _fakeSoldier)
	{
		if (entry == null || entry.Status == -1 || (LegendItemManager.ItemEntryEnableFilters.TryGetValue(entry.EntryId, out var value) && !AttributeChecker.Check(value, _fakeSoldier)) || entry?.Attributes == null || entry.Attributes.Count == 0)
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

	private static string GetInitEnhanceLevelConfigId(int raity)
	{
		return $"{raity}星宝物强化规则";
	}

	private static float GetLegendItemCurEnhanceLevelValue(LegendItemBrief target)
	{
		float result = 0f;
		GDELegendItemData gDELegendItemData = LegendItemManager.LegendItemTemplates[target.ItemId];
		LegendItemEnhancementConfig enhanceConfig = LegendItemEnhancementConfig.GetEnhanceConfig(gDELegendItemData.EnhanceConfig, target.EnhanceLevel);
		string configId = ((enhanceConfig != null) ? enhanceConfig.ConfigId : GetInitEnhanceLevelConfigId(gDELegendItemData.Rarity));
		int enhanceLevel = target.EnhanceLevel;
		LegendItemEnhancementConfig enhanceConfig2 = LegendItemEnhancementConfig.GetEnhanceConfig(configId, enhanceLevel);
		if (enhanceConfig2 == null)
		{
			return result;
		}
		for (int i = 0; i < target.MainEntries.Count; i++)
		{
			ItemEntryBrief itemEntryBrief = target.MainEntries[i];
			for (int j = 0; j < itemEntryBrief.Attributes.Count; j++)
			{
				ItemEntryData itemEntryData = itemEntryBrief.Attributes[j];
				float value = itemEntryData.GetValue();
				string text = itemEntryData.Key;
				if (itemEntryData.IsPercent)
				{
					text += "_PCT";
				}
				if (enhanceConfig2.EnhancedAttrs != null && enhanceConfig2.EnhancedAttrs.ContainsKey(text))
				{
					float value2 = enhanceConfig2.EnhancedAttrs[text].GetValue();
					float num = value2;
					result = num;
				}
			}
		}
		return result;
	}

	public static ReplaySoldierDetail GetReplaySoldierDetail(string battleId, string Id, int Level, int PotentialLevel, int EvoLevel, int Num, List<ItemLevel> Weapons, List<LegendItemBrief> LegendItems, List<TechLevel> Techs)
	{
		if (ReplayCombatInfoCache.ContainsKey(battleId))
		{
			return ReplayCombatInfoCache[battleId].GetReplaySoldierDetailCache(battleId, Id, Level, PotentialLevel, EvoLevel, Num, Weapons, LegendItems, Techs);
		}
		ReplayCombatInfo value = new ReplayCombatInfo(Techs);
		ReplayCombatInfoCache.Add(battleId, value);
		return ReplayCombatInfoCache[battleId].GetReplaySoldierDetailCache(battleId, Id, Level, PotentialLevel, EvoLevel, Num, Weapons, LegendItems, Techs);
	}

	public static void ClearReplaySoldierCombatCache()
	{
		ReplayCombatInfoCache.Clear();
	}

	public static async void OpenHelpPage(string entranceName, string topic1 = null, string topic2 = null, string topic3 = null)
	{
		try
		{
			string _leveId = GameManagers.Instance.UserArchiveManager.GetCurrentLevelId();
			if (string.IsNullOrEmpty(_leveId))
			{
				_leveId = "";
			}
			string _creatTime = GameController.Contexts.gameState.user.value.RegisterAt.DateTime.ToString("s");
			string _version = string.Concat(str2: (GameController.UserAgent == "pro" || GameController.UserAgent == "ios_pro") ? "" : GameController.UserAgent, str0: Application.version, str1: "\t");
			Dictionary<string, string> customField = new Dictionary<string, string>
			{
				{
					"userid",
					$"{GameController.Contexts.gameState.user.value.UserId}"
				},
				{
					"level",
					$"{GameManagers.Instance.UserArchiveManager.GetUserLevel()}"
				},
				{
					"gold_hold",
					string.Format("{0}", GameManagers.Instance.StockController.GetStock("Money"))
				},
				{
					"diamond_hold",
					string.Format("{0}", GameManagers.Instance.StockController.GetStock("Gem"))
				},
				{
					"total_revenue",
					$"{GameManagers.Instance.UserArchiveManager.GetTotalRecharge()}"
				},
				{
					"mainline_underway",
					_leveId ?? ""
				},
				{
					"create_time",
					_creatTime ?? ""
				},
				{
					"farmer_hold",
					$"{Dungeon.GetTotalManPower(GameManagers.Instance)}"
				},
				{
					"fmt_UserAgent",
					_version ?? ""
				}
			};
			GetBBSKeyResponse dic = await GameController.Contexts.Service<INetworkService>().GetBBSKey();
			string _token = dic.BBSKey;
			string customerServiceOnlineUrl1st = string.Format("accessId={0}&fromUrl={1}&urlTitle={2}&peerId=10053174&customField={3}&token={4}&userId={5}&timestamp={6}", UrlEncode("e83d6240-178c-11ec-8741-3dd2225b9764"), UrlEncode("http://" + entranceName), UrlEncode(entranceName), UrlEncode(JsonHelper.ToJson(customField)), _token, GameController.Contexts.gameState.user.value.UserId, dic.Timestamp);
			if (!string.IsNullOrEmpty(topic1))
			{
				customerServiceOnlineUrl1st = customerServiceOnlineUrl1st + "&topic1=" + UrlEncode(topic1);
			}
			if (!string.IsNullOrEmpty(topic2))
			{
				customerServiceOnlineUrl1st = customerServiceOnlineUrl1st + "&topic2=" + UrlEncode(topic2);
			}
			if (!string.IsNullOrEmpty(topic3))
			{
				customerServiceOnlineUrl1st = customerServiceOnlineUrl1st + "&topic3=" + UrlEncode(topic3);
			}
			OpenUrl(HotUpdateProcess.Instance.RegionModel.Zone.url.help + "?" + customerServiceOnlineUrl1st);
		}
		catch (Exception ex)
		{
			Exception e = ex;
			ILRuntimeDebug.LogError($"[OpenHelpPage]{e}");
		}
	}

	public static async Task<UserLoginCredentialsResult> GetUserCredentials()
	{
		if (string.IsNullOrWhiteSpace(LoginTypeStr))
		{
			return null;
		}
		UserLoginCredentialsResult result = await GameController.Contexts.Service<INetworkService>().GetUserCredentialsOperation(LoginTypeStr, GameController.Contexts.gameState.user.value.UserId);
		if (result == null)
		{
			return null;
		}
		if (result.ErrorCode != 1006)
		{
			ILRequestHelper.ShowErrorCode(result.ErrorCode);
			return null;
		}
		CredentialsObtained = true;
		UserLoginCredentialsIsFull = result.Infos.Count >= 3;
		return result;
	}

	public static async void DeleteUserArchive(int userId, Action action)
	{
		if (string.IsNullOrWhiteSpace(LoginTypeStr) || GameController.Contexts.gameState.user.value.UserId == userId)
		{
			return;
		}
		CredentialsOperationResult result = await GameController.Contexts.Service<INetworkService>().UserCredentialsOperation(LoginTypeStr, UserLoginCredentialsOperation.Delete, userId);
		if (result.ErrorCode != 1010)
		{
			ILRequestHelper.ShowErrorCode(result.ErrorCode);
			return;
		}
		GameLocalDataManager.MarkFirstInstallAndRegist(GameLocalDataManager.FirstInstallAndRegistFlag.Reset);
		UserLoginCredentialsIsFull = false;
		action?.Invoke();
		if (needResetUserArchive)
		{
			needResetUserArchive = false;
			ResetUserArchive(null);
		}
	}

	public static async void ChangeUserArchive(int userId)
	{
		if (!string.IsNullOrWhiteSpace(LoginTypeStr) && GameController.Contexts.gameState.user.value.UserId != userId)
		{
			GameController.Contexts.Service<IUiService>().ShowWaitingAnimation(show: true);
			CredentialsOperationResult result = await GameController.Contexts.Service<INetworkService>().UserCredentialsOperation(LoginTypeStr, UserLoginCredentialsOperation.ChangeCurrent, userId);
			if (result.ErrorCode != 1009)
			{
				ILRequestHelper.ShowErrorCode(result.ErrorCode);
				GameController.Contexts.Service<IUiService>().ShowWaitingAnimation(show: false);
				return;
			}
			GameController.Contexts.gameState.RemoveCharacterArchive();
			HotUpdateProcess.Instance.IsOffline = true;
			GameLocalDataManager.MarkFirstInstallAndRegist(GameLocalDataManager.FirstInstallAndRegistFlag.Reset);
			SharedMessenger.Broadcast("USER_CREDENTIALS_OPERATION", LanguagesManager.GetDesc("CsharpCodeZhTcText855") + LanguagesManager.Comma + LanguagesManager.GetDesc("CsharpCodeZhTcText856"), 3);
		}
	}

	public static async void ResetUserArchiveWithAutoDelete(int userId, Action onSuccess)
	{
		if (string.IsNullOrWhiteSpace(LoginTypeStr))
		{
			ILRuntimeDebug.LogError("[ResetUserArchiveWithAutoDelete] Faield LoginTypeStr == null");
			return;
		}
		GameController.Contexts.Service<IUiService>().ShowWaitingAnimation(show: true);
		INetworkService networkService = GameController.Contexts.Service<INetworkService>();
		CredentialsOperationResult result = await networkService.UserCredentialsOperation(LoginTypeStr, UserLoginCredentialsOperation.ResetByOldPlayer, userId);
		GameController.Contexts.Service<IUiService>().ShowWaitingAnimation(show: false);
		if (result.ErrorCode != 1025)
		{
			ILRequestHelper.ShowErrorCode(result.ErrorCode);
			ILRuntimeDebug.LogError($"ResetUserArchiveWithAutoDelete Failed, ErrorCode={result.ErrorCode}");
			return;
		}
		onSuccess?.Invoke();
		HotUpdateProcess.Instance.IsOffline = true;
		GameLocalDataManager.MarkFirstInstallAndRegist(GameLocalDataManager.FirstInstallAndRegistFlag.Reset);
		networkService.ClearCookie();
		UserTokenInfo userTokenInfo = new UserTokenInfo
		{
			Token = string.Empty
		};
		string zone = (string.IsNullOrEmpty(HotUpdateProcess.ZoneKey) ? string.Empty : HotUpdateProcess.ZoneKey);
		if (LoginTypeStr == UserLoginCredentialsType.Telephone.ToString())
		{
			if (!string.IsNullOrEmpty(NetworkService.AuthName))
			{
				userTokenInfo = await networkService.AuthenticateAsync(userId: (await networkService.GetUserCredentialsAsync(LoginTypeStr, NetworkService.AuthName, zone)).CurrentUserId, name: NetworkService.AuthName, pwd: NetworkService.AuthPwd, identityType: NetworkService.AuthIdentityType);
			}
		}
		else if (!string.IsNullOrEmpty(NetworkService.AuthJsonUserInfo))
		{
			string platformType = LoginTypeStr;
			if (LoginTypeStr == UserLoginCredentialsType.OpenId.ToString())
			{
				platformType = "Wechat";
			}
			else if (LoginTypeStr == UserLoginCredentialsType.AppleId.ToString())
			{
				platformType = "AppleOriginal";
			}
			if (string.IsNullOrEmpty(platformType))
			{
				ILRuntimeDebug.LogError($"[ResetUserArchiveWithAutoDelete]u{userId}, LoginTypeStr={LoginTypeStr}, PlatformType is null, UserInfo: {NetworkService.AuthJsonUserInfo}");
			}
			else
			{
				userTokenInfo = await networkService.AuthenticateByPlatformAsync(userId: (await networkService.GetUserCredentialsAsync(Value: networkService.GetCredentialValueByTypeStr(NetworkService.AuthJsonUserInfo, LoginTypeStr), TypeStr: LoginTypeStr, zone: zone)).CurrentUserId, jsonUserInfo: NetworkService.AuthJsonUserInfo, platformType: platformType, channelCode: HotUpdateProcess.ChannelCode);
			}
		}
		SharedMessenger.Broadcast("USER_CREDENTIALS_OPERATION", LanguagesManager.GetDesc("CsharpCodeZhTcText855") + LanguagesManager.Comma + LanguagesManager.GetDesc("CsharpCodeZhTcText856"), 3);
		networkService.SaveToken(userTokenInfo.Token);
	}

	public static async void ResetUserArchive(Action action)
	{
		if (string.IsNullOrWhiteSpace(LoginTypeStr))
		{
			return;
		}
		if (!CredentialsObtained)
		{
			await GetUserCredentials();
		}
		if (UserLoginCredentialsIsFull)
		{
			action?.Invoke();
			needResetUserArchive = true;
			return;
		}
		GameController.Contexts.Service<IUiService>().ShowWaitingAnimation(show: true);
		CredentialsOperationResult result = await GameController.Contexts.Service<INetworkService>().UserCredentialsOperation(LoginTypeStr, UserLoginCredentialsOperation.Reset, GameController.Contexts.gameState.user.value.UserId);
		if (result.ErrorCode != 1008)
		{
			ILRequestHelper.ShowErrorCode(result.ErrorCode);
			GameController.Contexts.Service<IUiService>().ShowWaitingAnimation(show: false);
		}
		else
		{
			GameController.Contexts.gameState.RemoveCharacterArchive();
			GameLocalDataManager.MarkFirstInstallAndRegist(GameLocalDataManager.FirstInstallAndRegistFlag.Reset);
			SharedMessenger.Broadcast("USER_CREDENTIALS_OPERATION", LanguagesManager.GetDesc("CsharpCodeZhTcText859") + LanguagesManager.Comma + LanguagesManager.GetDesc("CsharpCodeZhTcText856"), 1);
		}
	}

	public static void GuestsAccessRestrictTip()
	{
		GameController.Contexts.Service<IUiService>().OpenPanel(UI_UniversalConfirmPopup.Name, new Dictionary<string, object>
		{
			{
				"TipTextAlign",
				(object)(AlignType)1
			},
			{
				"Content",
				LanguagesManager.GetDesc("CsharpCodeTextGuestAccessRestricted")
			},
			{
				"Buttons",
				new Dictionary<string, Action>
				{
					{
						"Confirm",
						delegate
						{
							GameController.Contexts.Service<IUiService>().OpenPanel(UI_GuestRegistPopup.Name, null);
						}
					},
					{ "Cancel", null }
				}
			},
			{ "PageIndex", 0 },
			{ "FontSize", 44 }
		}, multiMode: false, ignoreQueue: true);
	}

	private static float GetTopOffset()
	{
		string deviceModel = SystemInfo.deviceModel;
		if (ModelTopOffset.ContainsKey(deviceModel))
		{
			return ModelTopOffset[deviceModel];
		}
		return 0f;
	}

	public static void OpenUrl(string url)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0007: Invalid comparison between Unknown and I4
		if ((int)Application.platform == 8)
		{
			MethodInfo method = typeof(HotFixManager).GetMethod("_OpenURL", BindingFlags.Static | BindingFlags.NonPublic);
			if (method != null)
			{
				method.Invoke(null, new object[1] { url });
				return;
			}
		}
		Application.OpenURL(url);
	}

	public static async void ULiteWebViewOpenUrl(string url, string titleText = "古卜林酒馆", bool canShowReturnBtn = false)
	{
		if (!string.IsNullOrEmpty(url))
		{
			MethodInfo ULiteWebViewLoadUrlMethod = ((object)HotFixManager.Instance).GetType().GetMethod("ULiteWebViewLoadUrl");
			MethodInfo ULiteWebViewShowMethod = ((object)HotFixManager.Instance).GetType().GetMethod("ULiteWebViewShow");
			if ((object)ULiteWebViewLoadUrlMethod == null || (object)ULiteWebViewShowMethod == null)
			{
				OpenUrl(url);
				return;
			}
			Screen.orientation = (ScreenOrientation)1;
			await Task.Delay(500);
			ULiteWebViewShowMethod.Invoke(HotFixManager.Instance, new object[6] { titleText, uLiteWebViewTop, uLiteWebViewBottom, 0, 0, canShowReturnBtn });
			ULiteWebViewLoadUrlMethod.Invoke(HotFixManager.Instance, new object[1] { url });
		}
	}

	public static void ULiteWebViewInit()
	{
		((object)HotFixManager.Instance).GetType().GetMethod("ULiteWebViewCanvasInit")?.Invoke(HotFixManager.Instance, null);
		ULiteWebViewIOSSetPanelSafeArea();
	}

	private static void ULiteWebViewIOSSetPanelSafeArea()
	{
		//IL_0008: Unknown result type (might be due to invalid IL or missing references)
		//IL_000e: Invalid comparison between Unknown and I4
		//IL_004f: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00cc: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f0: Unknown result type (might be due to invalid IL or missing references)
		//IL_012d: Unknown result type (might be due to invalid IL or missing references)
		uLiteWebViewTop = 100;
		uLiteWebViewBottom = (((int)Application.platform != 8) ? 80 : 0);
		GameObject val = GameObject.Find("ULiteWebViewCanvas");
		if (Object.op_Implicit((Object)(object)val))
		{
			float num = (float)Screen.width / (float)Screen.height;
			float num2 = 1.7777778f;
			Vector2 val2 = default(Vector2);
			if (num >= num2)
			{
				val2.y = Screen.height;
				val2.x = 1920f * (float)Screen.height / 1080f;
			}
			else
			{
				val2.x = Screen.width;
				val2.y = (float)Screen.width / 1.7777778f;
			}
			val.transform.localScale = Vector2.op_Implicit(new Vector2(val2.x / 1920f, val2.y / 1080f));
			RectTransform component = val.GetComponent<RectTransform>();
			component.sizeDelta = new Vector2(1920f, 1080f);
			float topOffset = GetTopOffset();
			uLiteWebViewTop += (int)topOffset;
			((Component)val.transform.Find("WebViewPanel")).GetComponent<RectTransform>().offsetMax = new Vector2(0f, 0f - topOffset);
		}
	}

	public static async void UniWebViewOpenUrl(string url, string titleText = "古卜林酒馆")
	{
		if (string.IsNullOrEmpty(url))
		{
			return;
		}
		MethodInfo uniWebViewLoadUrlAndShowMethod = ((object)HotFixManager.Instance).GetType().GetMethod("UniWebViewLoadUrlAndShow");
		MethodInfo uniWebViewSetFrameMethod = ((object)HotFixManager.Instance).GetType().GetMethod("UniWebViewSetFrame");
		if ((object)uniWebViewLoadUrlAndShowMethod == null || (object)uniWebViewSetFrameMethod == null)
		{
			OpenUrl(url);
			return;
		}
		Screen.orientation = (ScreenOrientation)1;
		await Task.Delay(500);
		float topOffset;
		GameObject uniWebViewGameObject = UniWebViewInit(titleText, out topOffset);
		if (uniWebViewGameObject == null)
		{
			OpenUrl(url);
			return;
		}
		uniWebViewLoadUrlAndShowMethod.Invoke(HotFixManager.Instance, new object[3] { uniWebViewGameObject, true, url });
		Rect webViewRect = new Rect(0f, (float)(int)topOffset, (float)Screen.width, (float)(Screen.height - (int)topOffset));
		uniWebViewSetFrameMethod.Invoke(HotFixManager.Instance, new object[2] { uniWebViewGameObject, webViewRect });
	}

	public static GameObject UniWebViewInit(string titleText, out float webViewTopOffset)
	{
		//IL_0051: Unknown result type (might be due to invalid IL or missing references)
		//IL_0056: Unknown result type (might be due to invalid IL or missing references)
		//IL_0130: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ce: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d3: Unknown result type (might be due to invalid IL or missing references)
		MethodInfo method = ((object)HotFixManager.Instance).GetType().GetMethod("UniWebViewSetCloseEvent");
		if ((object)method == null)
		{
			webViewTopOffset = 0f;
			return null;
		}
		GameObject val = GameObject.Find("UniWebViewCanvas");
		if (val == null)
		{
			GameObject val2 = Addressables.LoadAssetAsync<GameObject>((object)"Prefabs/UniWebViewPrefab/UniWebViewCanvas").WaitForCompletion();
			val = Object.Instantiate<GameObject>(val2);
			((Object)val).name = "UniWebViewCanvas";
			Object.DontDestroyOnLoad((Object)(object)val);
		}
		((Component)val.transform.Find("WebViewPanel")).gameObject.SetActive(true);
		((Component)val.transform.Find("WebViewPanel/Menu/TextMsg")).gameObject.GetComponent<Text>().text = titleText;
		if (uniWebViewPrefab == null)
		{
			uniWebViewPrefab = Addressables.LoadAssetAsync<GameObject>((object)"Prefabs/UniWebViewPrefab/UniWebView").WaitForCompletion();
		}
		GameObject val3 = Object.Instantiate<GameObject>(uniWebViewPrefab);
		((Object)val3).name = "UniWebView";
		val3.transform.SetParent(val.transform);
		float topOffset = GetTopOffset();
		((Component)val.transform.Find("WebViewPanel")).GetComponent<RectTransform>().offsetMax = new Vector2(0f, 0f - topOffset);
		webViewTopOffset = topOffset + 100f;
		string closeBtnUrl = "WebViewPanel/Menu/BtnClose";
		Action action = delegate
		{
			Screen.orientation = (ScreenOrientation)3;
			Screen.orientation = (ScreenOrientation)5;
			GameObject val4 = GameObject.Find("UniWebViewCanvas");
			if (Object.op_Implicit((Object)(object)val4))
			{
				((UnityEventBase)((Component)val4.transform.Find(closeBtnUrl)).GetComponent<Button>().onClick).RemoveAllListeners();
				((Component)val4.transform.Find("WebViewPanel")).gameObject.SetActive(false);
			}
		};
		method.Invoke(HotFixManager.Instance, new object[4] { val3, val, action, closeBtnUrl });
		return val3;
	}
}
