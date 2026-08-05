using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using HotFix;
using ObservableClasses;
using Shift.Legion.ClientApi.Protocol.Store;
using Shift.Legion.Common.Enums;
using Shift.Legion.Common.Helpers;
using Shift.Legion.Common.Managers;
using Shift.Legion.Common.Sources.Enums;
using Shift.Legion.Helpers;

namespace Shift.Legion.Common.Models;

public class Trigger
{
	public const string OnEnterGame = "OnEnterGame";

	public const string OnEnterLevel = "OnEnterLevel";

	public const string OnLevelStart = "OnLevelStart";

	public const string OnBeforeLevelComplete = "OnBeforeLevelComplete";

	public const string OnLevelComplete = "OnLevelComplete";

	public const string OnLevelCompleteCalc = "OnLevelCompleteCalc";

	public const string OnBonusCardsPopup = "OnBonusCardsPopup";

	public const string OnBonusCardsConfirm = "OnBonusCardsConfirm";

	public const string OnBonusCardsSelect = "OnBonusCardsSelect";

	public const string OnLevelBonusSettlementPopup = "OnLevelBonusSettlementPopup";

	public const string OnLevelBonusClaimed = "OnLevelBonusClaimed";

	public const string AfterLevelBonusClaimed = "AfterLevelBonusClaimed";

	public const string OnCampAlone = "OnCampAlone";

	public const string OnStockIsFull = "OnStockIsFull";

	public const string OnMoreResourceRequired = "OnMoreResourceRequired";

	public const string OnStock = "OnStock";

	public const string OnProd = "OnProd";

	public const string OnCost = "OnCost";

	public const string OnOpenUI = "OnOpenUI";

	public const string OnCloseUI = "OnCloseUI";

	public const string OnSoldierUnlock = "OnSoldierUnlock";

	public const string OnSoldierEvolute = "OnSoldierEvolute";

	public const string OnSoldierLevelUp = "OnSoldierLevelUp";

	public const string OnSoldierBreakthrough = "OnSoldierBreakthrough";

	public const string OnSoldierPotentialUpgrade = "OnSoldierPotentialUpgrade";

	public const string OnBuildingConstructingComplete = "OnBuildingConstructingComplete";

	public const string OnBuildingUpgrade = "OnBuildingUpgrade";

	public const string OnTechnologyUpgrade = "OnTechnologyUpgrade";

	public const string OnItemUpgrade = "OnWeaponUpgrade";

	public const string OnMissionComplete = "OnMissionComplete";

	public const string OnMissionProgressChanged = "OnMissionProgressChanged";

	public const string OnMissionClaimed = "OnMissionClaimed";

	public const string MissionPicked = "MissionPicked";

	public const string OnUserLevelUp = "OnUserLevelUp";

	public const string OnFocusRegion = "OnFocusRegion";

	public const string OnStrongholdShowUp = "OnStrongholdShowUp";

	public const string OnFormationUnlocked = "OnFormationUnlocked";

	public const string OnFormationLocked = "OnFormationLocked";

	public const string OnLeaseholdRegister = "OnLeaseholdRegistered";

	public const string OnLeaseholdUnregister = "OnLeaseholdUnregister";

	public const string OnLimitTimeMerchandiseEnabled = "OnLimitTimeMerchandiseRegister";

	public const string OnLimitTimeMerchandiseExpired = "OnLimitTimeMerchandiseExpired";

	public const string OnMainCityComUnlocked = "OnMainCityComUnlocked";

	public const string OnDailyLoginCalc = "OnDailyLoginCalc";

	public const string TypeForFunds1 = "TypeForFunds1";

	public const string TypeForFunds2 = "TypeForFunds2";

	public const string OnActivityReset = "ActivityReset";

	public const string OnPvPRankScoreClaimed = "PvPRankScoreClaimed";

	public const string OnWatchingReplay = "WatchingReplay";

	public const string OnWatchingPvPRankReplay = "WatchingPvPRankReplay";

	public const string OnWatchingStoryMainReplay = "WatchingStoryMainReplay";

	public const string OnPvPRankBattleStart = "PvPRankBattleStart";

	public const string OnNewOrderStats = "NewOrderStats";

	public const string OnLegendItemEnhanced = "LegendItemEnhanced";

	public const string OnLegendItemChangedProps = "LegendItemChangedProps";

	public const string OnLegendItemReforged = "LegendItemReforged";

	public const string OnAttackInstanceClaimedFinalPrize = "AttackInstanceClaimedFinalPrize";

	public const string OnStoryEnd = "OnStoryEnd";

	public const string OnNewGuidePanelShow = "OnNewGuidePanelShow";

	public const string OnNewGuideMissionUndergoing = "OnNewGuideMissionUndergoing";

	public const string OnNewbieCardsShow = "OnNewbieCardsShow";

	public const string OnGvG2EnterIsland = "OnGvG2EnterIsland";

	public const string OnGvGIslandPanelShow = "OnGvGIslandPanelShow";

	public const string OnLordOfDreamPanelShow = "OnLordOfDreamPanelShow";

	public const string OnVideoPlay = "OnPlayVideo";

	public const string OnRankUpdate = "OnRankUpdate";

	public const string OnDrawCard = "OnDrawCard";

	public const string OnDrawLegendItem = "OnDrawLegendItem";

	public const string OnLegendItemSet = "OnLegendItemSet";

	public const string OnCompound = "OnCompound";

	public const string OnCompoundCalc = "OnCompoundCalc";

	public const string OnTechnologyLevelUp = "OnTechnologyLevelUp";

	public const string OnTechnologyUnlock = "OnTechnologyUnlock";

	public const string OnAchievement = "OnAchievement";

	public const string OnTimeout = "OnTimeout";

	public const string OnColliding = "OnColliding";

	public const string OnActivate = "OnActivate";

	public const string Waiting = "Waiting";

	public const string Continue = "Continue";

	public const string Asynchronous = "Async";

	public const string End = "End";

	public Dictionary<string, object> DetailCases;

	public string Type;

	public readonly string TriggerKey;

	public Func<GameManagers, string, Dictionary<string, object>, bool> CallbackFilter;

	public bool DestroyAfterRunSuccess = true;

	public Trigger(string triggerKey)
	{
		TriggerKey = triggerKey;
		int num = triggerKey.IndexOf(":");
		DetailCases = null;
		if (num >= 0)
		{
			Type = triggerKey.Substring(0, num);
			string text = triggerKey.Substring(num + 1);
			string type = Type;
			string text2 = type;
			if (text2 == "OnMissionComplete" || text2 == "OnStockIsFull")
			{
				List<string> list = JsonHelper.ToObject<List<string>>(text);
				DetailCases = new Dictionary<string, object>();
				foreach (string item in list)
				{
					DetailCases.Add(item, 1);
				}
			}
			else if (text.IndexOf(":") >= 0)
			{
				Dictionary<string, object> dictionary = JsonHelper.ToObject<Dictionary<string, object>>(text);
				DetailCases = new Dictionary<string, object>(dictionary);
			}
			else
			{
				DetailCases = new Dictionary<string, object> { { "Payload", text } };
			}
		}
		else
		{
			Type = triggerKey;
		}
		ProcessFilterPayload(DetailCases);
		switch (Type)
		{
		case "OnProd":
		case "OnCost":
		case "OnStock":
			CallbackFilter = StockCountCallbackFilter;
			break;
		case "OnCompound":
			CallbackFilter = CompoundCallbackFilter;
			break;
		case "OnCompoundCalc":
			CallbackFilter = CompoundCalcCallbackFilter;
			break;
		case "OnAchievement":
			CallbackFilter = AchievementCompleteFilter;
			break;
		case "OnLevelCompleteCalc":
			CallbackFilter = LevelCompleteCountCallbackFilter;
			break;
		case "OnStockIsFull":
			CallbackFilter = delegate(GameManagers managers, string triggerId, Dictionary<string, object> callbackParams)
			{
				if (!callbackParams.TryGetValue("ItemId", out var value))
				{
					return false;
				}
				Dictionary<string, object> filterPayload = managers.TriggerManager.GetFilterPayload(triggerId);
				if (filterPayload == null || filterPayload.Count <= 1)
				{
					return true;
				}
				if (filterPayload is ObservableDictionary<string, object> val)
				{
					val.Remove(value.ToString());
				}
				else
				{
					filterPayload.Remove(value.ToString());
				}
				return false;
			};
			break;
		case "OnMissionComplete":
			CallbackFilter = delegate(GameManagers managers, string triggerId, Dictionary<string, object> callbackParams)
			{
				if (!callbackParams.TryGetValue("MissionId", out var value))
				{
					return false;
				}
				Dictionary<string, object> filterPayload = managers.TriggerManager.GetFilterPayload(triggerId);
				if (filterPayload == null || filterPayload.Count <= 1)
				{
					return true;
				}
				if (filterPayload is ObservableDictionary<string, object> val)
				{
					val.Remove(value.ToString());
				}
				else
				{
					filterPayload.Remove(value.ToString());
				}
				return false;
			};
			break;
		case "OnDailyLoginCalc":
			CallbackFilter = DailyLoginCalcFilter;
			break;
		case "TypeForFunds1":
			CallbackFilter = TypeForFunds1Filter;
			break;
		case "TypeForFunds2":
			CallbackFilter = TypeForFunds2Filter;
			break;
		case "ActivityReset":
			CallbackFilter = ActivityResetFilter;
			break;
		case "PvPRankScoreClaimed":
			CallbackFilter = PvPRankScoreClaimedFilter;
			break;
		case "WatchingReplay":
		case "WatchingPvPRankReplay":
		case "WatchingStoryMainReplay":
			CallbackFilter = WatchingReplayFilter;
			break;
		case "PvPRankBattleStart":
			CallbackFilter = PvPRankBattleStart;
			break;
		case "NewOrderStats":
			CallbackFilter = NewOrderStatsFilter;
			break;
		case "LegendItemEnhanced":
			CallbackFilter = LegendItemEnhancedFilter;
			break;
		case "LegendItemChangedProps":
			CallbackFilter = LegendItemChangedPropsFilter;
			break;
		case "LegendItemReforged":
			CallbackFilter = LegendItemReforgedFilter;
			break;
		case "AttackInstanceClaimedFinalPrize":
			CallbackFilter = AttackInstanceClaimedFinalPrizeFilter;
			break;
		case "OnSoldierPotentialUpgrade":
			CallbackFilter = OnSoldierPotentialUpgradeFilter;
			break;
		case "OnSoldierLevelUp":
			CallbackFilter = OnSoldierLevelUpFilter;
			break;
		case "OnSoldierEvolute":
			CallbackFilter = OnSoldierEvoluteFilter;
			break;
		case "OnSoldierUnlock":
			CallbackFilter = OnSoldierUnlockFilter;
			break;
		case "OnPlayVideo":
			CallbackFilter = VideoPlayCallbackFilter;
			break;
		case "OnRankUpdate":
			CallbackFilter = OnRankUpdateCallbackFilter;
			break;
		case "OnDrawCard":
			CallbackFilter = OnDrawCardCallbackFilter;
			break;
		case "OnDrawLegendItem":
			CallbackFilter = OnDrawLegendItemCallbackFilter;
			break;
		case "OnLegendItemSet":
			CallbackFilter = OnLegendItemSetCallbackFilter;
			break;
		default:
			CallbackFilter = DefaultCallbackFilter;
			break;
		}
	}

	private bool OnRankUpdateCallbackFilter(GameManagers managers, string triggerId, Dictionary<string, object> callbackParams)
	{
		if (!callbackParams.TryGetValue("TopRank", out var value))
		{
			return false;
		}
		Dictionary<string, object> filterPayload = managers.TriggerManager.GetFilterPayload(triggerId);
		if (!filterPayload.TryGetValue("Rank", out var value2))
		{
			return false;
		}
		return int.Parse(value.ToString()) <= int.Parse(value2.ToString());
	}

	private bool OnDrawCardCallbackFilter(GameManagers managers, string triggerId, Dictionary<string, object> callbackParams)
	{
		if (!callbackParams.TryGetValue("Cnt", out var value))
		{
			return false;
		}
		Dictionary<string, object> filterPayload = managers.TriggerManager.GetFilterPayload(triggerId);
		int num = Convert.ToInt32(filterPayload["Total"]) - int.Parse(value.ToString());
		if (filterPayload is ObservableDictionary<string, object> val)
		{
			val["Total"] = num;
		}
		else
		{
			filterPayload["Total"] = num;
		}
		return num <= 0;
	}

	private bool OnDrawLegendItemCallbackFilter(GameManagers managers, string triggerId, Dictionary<string, object> callbackParams)
	{
		if (!callbackParams.TryGetValue("Cnt", out var value))
		{
			return false;
		}
		Dictionary<string, object> filterPayload = managers.TriggerManager.GetFilterPayload(triggerId);
		int num = Convert.ToInt32(filterPayload["Total"]) - int.Parse(value.ToString());
		if (filterPayload is ObservableDictionary<string, object> val)
		{
			val["Total"] = num;
		}
		else
		{
			filterPayload["Total"] = num;
		}
		return num <= 0;
	}

	private bool OnLegendItemSetCallbackFilter(GameManagers managers, string triggerId, Dictionary<string, object> callbackParams)
	{
		if (!callbackParams.TryGetValue("Cnt", out var value))
		{
			return false;
		}
		Dictionary<string, object> filterPayload = managers.TriggerManager.GetFilterPayload(triggerId);
		if (!filterPayload.TryGetValue("Total", out var value2))
		{
			return false;
		}
		return int.Parse(value.ToString()) >= int.Parse(value2.ToString());
	}

	public static void ProcessFilterPayload(Dictionary<string, object> detailCases)
	{
		if (detailCases == null || detailCases.Count == 0)
		{
			return;
		}
		if (detailCases.TryGetValue("Items", out var value) && !(value is ArrayList))
		{
			if (!(value is string[]))
			{
				detailCases["Items"] = value.ToString().Split(',');
			}
			else
			{
				ILRuntimeDebug.LogError("统一的格式处理 错误 Items ");
			}
		}
		if (detailCases.TryGetValue("Tags", out var value2) && !(value2 is ArrayList))
		{
			if (!(value2 is string[]))
			{
				detailCases["Tags"] = value2.ToString().Split(' ');
			}
			else
			{
				ILRuntimeDebug.LogError("统一的格式处理 错误 Tags");
			}
		}
		if (detailCases.TryGetValue("LevelId", out var value3))
		{
			if (value3 is ArrayList arrayList)
			{
				detailCases["LevelId"] = new string[arrayList.Count];
				for (int i = 0; i < arrayList.Count; i++)
				{
					(detailCases["LevelId"] as string[])[i] = arrayList[i].ToString();
				}
			}
			else if (!(value3 is string[]))
			{
				detailCases["LevelId"] = value3.ToString().Split(',');
			}
			else
			{
				ILRuntimeDebug.LogError("统一的格式处理 错误 LevelId");
			}
		}
		if (!detailCases.TryGetValue("ChapterType", out var value4))
		{
			return;
		}
		if (value4 is ArrayList)
		{
			detailCases["ChapterType"] = ((ArrayList)value4).ToArray();
		}
		else if (!(value4 is int[]))
		{
			detailCases["ChapterType"] = (from chapterType in value4.ToString().Split(',')
				select Convert.ToInt32(chapterType)).ToArray();
		}
		else
		{
			ILRuntimeDebug.LogError("统一的格式处理 错误 ChapterType");
		}
	}

	public bool DefaultCallbackFilter(GameManagers managers, string triggerId, Dictionary<string, object> cases = null)
	{
		Dictionary<string, object> filterPayload = managers.TriggerManager.GetFilterPayload(triggerId);
		if (cases != null)
		{
			foreach (KeyValuePair<string, object> @case in cases)
			{
			}
		}
		if (filterPayload != null)
		{
			if (cases == null)
			{
				return false;
			}
			foreach (KeyValuePair<string, object> item in filterPayload)
			{
				string key = item.Key;
				switch (key)
				{
				case "Items":
				case "Tags":
				case "LevelId":
				{
					if (!cases.TryGetValue(key, out var value) || !((string[])item.Value).Contains<string>(value.ToString()))
					{
						return false;
					}
					break;
				}
				case "ChapterType":
				{
					if (!cases.TryGetValue(key, out var value2) || !((int[])item.Value).Contains((int)value2))
					{
						return false;
					}
					break;
				}
				case "LevelFilter":
					foreach (List<string> value3 in managers.UserArchiveManager.GetLevelProgress().Values)
					{
						if (value3.Contains(item.Value))
						{
							return true;
						}
					}
					break;
				default:
					if (!cases.ContainsKey(key) || item.Value.ToString() != cases[key].ToString())
					{
						return false;
					}
					break;
				}
			}
		}
		return true;
	}

	public bool VideoPlayCallbackFilter(GameManagers managers, string triggerId, Dictionary<string, object> cases = null)
	{
		return false;
	}

	private bool StockCountCallbackFilter(GameManagers managers, string triggerId, Dictionary<string, object> callbackParams)
	{
		if (!callbackParams.TryGetValue("ItemId", out var value) || !callbackParams.TryGetValue("Qty", out var value2))
		{
			return false;
		}
		object value3;
		(StockInContext, string) tuple = ((!callbackParams.TryGetValue("Context", out value3)) ? (StockInContext.Unknown, null) : (((StockInContext, string))value3));
		Dictionary<string, object> filterPayload = managers.TriggerManager.GetFilterPayload(triggerId);
		if (!filterPayload.ContainsKey("Total"))
		{
			return false;
		}
		if (!filterPayload.TryGetValue("Items", out var value4))
		{
			value4 = null;
		}
		if (!filterPayload.TryGetValue("Tags", out var value5))
		{
			value5 = null;
		}
		if (!filterPayload.TryGetValue("Context", out var value6))
		{
			value6 = null;
		}
		if (value4 == null && value5 == null && value6 == null)
		{
			return false;
		}
		string text = value.ToString();
		string schemaById = SchemaIndexHelper.GetSchemaById(text);
		string text2 = schemaById;
		List<string> second = ((!(text2 == "Soldier")) ? Item.Tags(text) : managers.SoldierManager.Get(text).Tags);
		List<string> list = new List<string>();
		List<string> list2 = new List<string>();
		if (value4 != null)
		{
			if (value4 is ArrayList)
			{
				foreach (object item in (ArrayList)value4)
				{
					list.Add(item.ToString());
				}
			}
			else
			{
				list.AddRange((List<string>)value4);
			}
		}
		if (value5 != null)
		{
			if (value5 is ArrayList)
			{
				foreach (object item2 in (ArrayList)value5)
				{
					list2.Add(item2.ToString());
				}
			}
			else
			{
				list2.AddRange((List<string>)value5);
			}
		}
		if (list.Count > 0 && !list.Contains(text))
		{
			return false;
		}
		if (list2.Count > 0 && !list2.Intersect(second).Any())
		{
			return false;
		}
		if (value6 != null)
		{
			Dictionary<string, object> dictionary = (Dictionary<string, object>)value6;
			Dictionary<string, string> dictionary2 = new Dictionary<string, string>();
			foreach (string key in dictionary.Keys)
			{
				dictionary2.Add(key, dictionary[key].ToString());
			}
			foreach (KeyValuePair<string, string> item3 in dictionary2)
			{
				bool flag = false;
				switch (item3.Key)
				{
				case "Building":
					if (tuple.Item1 == StockInContext.Building)
					{
						goto IL_039a;
					}
					if (tuple.Item1 == StockInContext.BuildingFeature)
					{
						IEnumerable<string> first = from building in managers.BuildingManager.GetBuildingsByFeature(tuple.Item2)
							select building.BuildingType;
						flag = string.IsNullOrEmpty(item3.Value) || first.Intersect(item3.Value.Split(',')).Any();
						goto IL_0649;
					}
					if (tuple.Item1 != StockInContext.Refund)
					{
						break;
					}
					goto IL_04ce;
				case "Stronghold":
					if (tuple.Item1 != StockInContext.StrongholdProd)
					{
						break;
					}
					goto IL_039a;
				case "BuildingFeature":
					if (tuple.Item1 == StockInContext.BuildingFeature)
					{
						goto IL_039a;
					}
					if (tuple.Item1 == StockInContext.Building)
					{
						Building buildingByType2 = managers.BuildingManager.GetBuildingByType(tuple.Item2);
						if (buildingByType2 == null)
						{
							return false;
						}
						flag = string.IsNullOrEmpty(item3.Value) || item3.Value.Split(',').Contains(buildingByType2.Feature);
						goto IL_0649;
					}
					if (tuple.Item1 != StockInContext.Refund)
					{
						break;
					}
					goto IL_04ce;
				case "KIA":
					{
						string text3 = value.ToString();
						flag = SchemaIndexHelper.GetSchemaById(text3) == "Soldier" && (string.IsNullOrEmpty(item3.Value) || item3.Value.Split(',').Contains(text3));
						goto IL_0649;
					}
					IL_039a:
					flag = string.IsNullOrEmpty(item3.Value) || item3.Value.Split(',').Contains(tuple.Item2);
					goto IL_0649;
					IL_04ce:
					if (string.IsNullOrEmpty(item3.Value) || item3.Value.Split(',').Contains(tuple.Item2))
					{
						flag = true;
					}
					else if (item3.Key == "Building")
					{
						IEnumerable<string> first2 = from building in managers.BuildingManager.GetBuildingsByFeature(tuple.Item2)
							select building.BuildingType;
						flag = string.IsNullOrEmpty(item3.Value) || first2.Intersect(item3.Value.Split(',')).Any();
					}
					else if (item3.Key == "BuildingFeature")
					{
						Building buildingByType = managers.BuildingManager.GetBuildingByType(tuple.Item2);
						if (buildingByType == null)
						{
							return false;
						}
						flag = string.IsNullOrEmpty(item3.Value) || item3.Value.Split(',').Contains(buildingByType.Feature);
					}
					goto IL_0649;
				}
				flag = false;
				goto IL_0649;
				IL_0649:
				if (!flag)
				{
					return false;
				}
			}
		}
		if (tuple.Item1 == StockInContext.Refund)
		{
			value2 = Convert.ToInt32(value2) * -1;
		}
		int num = Convert.ToInt32(filterPayload["Total"]) - Convert.ToInt32(value2);
		filterPayload["Total"] = num;
		if (filterPayload is ObservableDictionary<string, object> val)
		{
			val["Total"] = num;
		}
		else
		{
			filterPayload["Total"] = num;
		}
		return num <= 0;
	}

	private bool LevelCompleteCountCallbackFilter(GameManagers managers, string triggerId, Dictionary<string, object> callbackParams)
	{
		if (!callbackParams.TryGetValue("LevelId", out var value) || !callbackParams.TryGetValue("ChapterType", out var value2) || !callbackParams.TryGetValue("Winner", out var value3))
		{
			return false;
		}
		Dictionary<string, object> filterPayload = managers.TriggerManager.GetFilterPayload(triggerId);
		if (!filterPayload.ContainsKey("Total"))
		{
			return false;
		}
		if (!filterPayload.TryGetValue("Level", out var value4))
		{
			value4 = null;
		}
		if (!filterPayload.TryGetValue("ChapterType", out var value5))
		{
			value5 = null;
		}
		if (value4 == null && value5 == null)
		{
			return false;
		}
		if (filterPayload.TryGetValue("Winner", out var value6) && (Team)value6 != (Team)value3)
		{
			return false;
		}
		List<string> list = new List<string>();
		List<int> list2 = new List<int>();
		if (value4 != null)
		{
			object[] array = (object[])value4;
			foreach (object obj in array)
			{
				list.Add(obj.ToString());
			}
		}
		if (value5 != null)
		{
			object[] array2 = (object[])value5;
			foreach (object obj2 in array2)
			{
				list2.Add((int)obj2);
			}
		}
		if (list.Count > 0 && !list.Contains(value.ToString()))
		{
			return false;
		}
		if (list2.Count > 0 && !list2.Contains(Convert.ToInt32(value2)))
		{
			return false;
		}
		int num = Convert.ToInt32(filterPayload["Total"]) - 1;
		if (filterPayload is ObservableDictionary<string, object> val)
		{
			val["Total"] = num;
		}
		else
		{
			filterPayload["Total"] = num;
		}
		return num <= 0;
	}

	private bool CompoundCallbackFilter(GameManagers managers, string triggerId, Dictionary<string, object> callbackParams)
	{
		if (!callbackParams.TryGetValue("PiecesItemId", out var value) || !callbackParams.TryGetValue("Result", out var value2))
		{
			return false;
		}
		Dictionary<string, object> filterPayload = managers.TriggerManager.GetFilterPayload(triggerId);
		filterPayload.TryGetValue("PiecesItems", out var value3);
		filterPayload.TryGetValue("Items", out var value4);
		filterPayload.TryGetValue("Tags", out var value5);
		List<string> list = new List<string>();
		List<string> list2 = new List<string>();
		List<string> list3 = new List<string>();
		if (value3 != null)
		{
			list.AddRange((List<string>)value3);
		}
		if (value4 != null)
		{
			list2.AddRange((List<string>)value4);
		}
		if (value5 != null)
		{
			list3.AddRange((List<string>)value5);
		}
		if (list.Count > 0 && !list.Contains(value.ToString()))
		{
			return false;
		}
		int num = Convert.ToInt32(filterPayload["Total"]);
		foreach (KeyValuePair<string, int> item in (Dictionary<string, int>)value2)
		{
			string key = item.Key;
			if (list2.Count <= 0 || list2.Contains(key))
			{
				string schemaById = SchemaIndexHelper.GetSchemaById(key);
				string text = schemaById;
				List<string> second = ((!(text == "Soldier")) ? Item.Tags(key) : managers.SoldierManager.Get(key).Tags);
				if (list3.Count <= 0 || list3.Intersect(second).Any())
				{
					num -= item.Value;
				}
			}
		}
		if (filterPayload is ObservableDictionary<string, object> val)
		{
			val["Total"] = num;
		}
		else
		{
			filterPayload["Total"] = num;
		}
		return num <= 0;
	}

	private bool CompoundCalcCallbackFilter(GameManagers managers, string triggerId, Dictionary<string, object> callbackParams)
	{
		if (!callbackParams.TryGetValue("PiecesItemId", out var value) || !callbackParams.TryGetValue("Result", out var _))
		{
			return false;
		}
		Dictionary<string, object> filterPayload = managers.TriggerManager.GetFilterPayload(triggerId);
		filterPayload.TryGetValue("PiecesItems", out var value3);
		List<string> list = new List<string>();
		if (value3 != null)
		{
			list.AddRange((List<string>)value3);
		}
		if (list.Count > 0 && !list.Contains(value.ToString()))
		{
			return false;
		}
		int num = Convert.ToInt32(filterPayload["Total"]);
		num -= ((!callbackParams.TryGetValue("Count", out var value4)) ? 1 : Convert.ToInt32(value4));
		if (filterPayload is ObservableDictionary<string, object> val)
		{
			val["Total"] = num;
		}
		else
		{
			filterPayload["Total"] = num;
		}
		return num <= 0;
	}

	private bool AchievementCompleteFilter(GameManagers managers, string triggerId, Dictionary<string, object> callbackParams)
	{
		if (!callbackParams.TryGetValue("Achievements", out var value))
		{
			return false;
		}
		Dictionary<string, object> filterPayload = managers.TriggerManager.GetFilterPayload(triggerId);
		if (!filterPayload.TryGetValue("Payload", out var targetAchievementId))
		{
			ILRuntimeDebug.LogError("Trigger:" + Type + " 配置错误: " + JsonHelper.ToJson(filterPayload));
			return false;
		}
		return ((List<Achievement>)value).Find((Achievement achievement) => achievement.AchievementId == targetAchievementId.ToString()) != null;
	}

	private bool DailyLoginCalcFilter(GameManagers managers, string triggerId, Dictionary<string, object> callbackParams)
	{
		Dictionary<string, object> filterPayload = managers.TriggerManager.GetFilterPayload(triggerId);
		if (!filterPayload.TryGetValue("Payload", out var value) || !int.TryParse(value.ToString(), out var result))
		{
			ILRuntimeDebug.LogError("Trigger:" + Type + " 配置错误: " + JsonHelper.ToJson(filterPayload));
			return false;
		}
		int result2 = 1;
		if (filterPayload.TryGetValue("Offset", out var value2))
		{
			int.TryParse(value2.ToString(), out result2);
		}
		return result <= managers.UserArchiveManager.GetDailyLoginStats() - result2 + 1;
	}

	private bool TypeForFunds1Filter(GameManagers managers, string triggerId, Dictionary<string, object> callbackParams)
	{
		Dictionary<string, object> filterPayload = managers.TriggerManager.GetFilterPayload(triggerId);
		if (!filterPayload.TryGetValue("LoginCnt", out var value) || !int.TryParse(value.ToString(), out var result) || !filterPayload.TryGetValue("FundCert", out var value2))
		{
			return false;
		}
		if (managers.StoreManager.GetPurchaseCnt(value2.ToString()) < 1)
		{
			return false;
		}
		int result2 = 1;
		if (filterPayload.TryGetValue("Offset", out var value3))
		{
			int.TryParse(value3.ToString(), out result2);
		}
		return result <= managers.UserArchiveManager.GetDailyLoginStats() - result2 + 1;
	}

	private bool TypeForFunds2Filter(GameManagers managers, string triggerId, Dictionary<string, object> callbackParams)
	{
		if (!callbackParams.TryGetValue("Achievements", out var value))
		{
			return false;
		}
		Dictionary<string, object> filterPayload = managers.TriggerManager.GetFilterPayload(triggerId);
		if (!filterPayload.TryGetValue("Achievement", out var targetAchievementId) || !filterPayload.TryGetValue("FundCert", out var value2))
		{
			return false;
		}
		if (managers.StoreManager.GetPurchaseCnt(value2.ToString()) < 1)
		{
			return false;
		}
		return ((List<Achievement>)value).Find((Achievement achievement) => achievement.AchievementId == targetAchievementId.ToString()) != null;
	}

	private bool ActivityResetFilter(GameManagers managers, string triggerId, Dictionary<string, object> callbackParams)
	{
		if (!callbackParams.TryGetValue("Activity", out var value))
		{
			return false;
		}
		if (!(value is Activity activity))
		{
			return false;
		}
		Dictionary<string, object> filterPayload = managers.TriggerManager.GetFilterPayload(triggerId);
		if (filterPayload.TryGetValue("ActivityType", out var value2) && activity.Type != (ActivityType)Convert.ToInt32(value2))
		{
			return false;
		}
		int num = Convert.ToInt32(filterPayload["Total"]) - 1;
		if (filterPayload is ObservableDictionary<string, object> val)
		{
			val["Total"] = num;
		}
		else
		{
			filterPayload["Total"] = num;
		}
		return num <= 0;
	}

	private bool PvPRankScoreClaimedFilter(GameManagers managers, string triggerId, Dictionary<string, object> callbackParams)
	{
		Dictionary<string, object> filterPayload = managers.TriggerManager.GetFilterPayload(triggerId);
		int num = Convert.ToInt32(filterPayload["Payload"]) - 1;
		if (filterPayload is ObservableDictionary<string, object> val)
		{
			val["Payload"] = num;
		}
		else
		{
			filterPayload["Payload"] = num;
		}
		return num <= 0;
	}

	private bool NewOrderStatsFilter(GameManagers managers, string triggerId, Dictionary<string, object> callbackParams)
	{
		if (!callbackParams.TryGetValue("StoreItemId", out var value))
		{
			return false;
		}
		Dictionary<string, object> filterPayload = managers.TriggerManager.GetFilterPayload(triggerId);
		if (!filterPayload.TryGetValue("Total", out var value2))
		{
			return false;
		}
		if (!filterPayload.TryGetValue("Pages", out var value3))
		{
			return false;
		}
		List<string> list = new List<string>();
		string text = "GiftPackMerchant";
		if (HotUpdateProcess.Instance.IsRegionOutCN)
		{
			text = text + "_" + HotUpdateProcess.RegionKey;
		}
		if (value3 is string text2)
		{
			list.Add(text + ":" + text2);
		}
		else if (value3 is ArrayList arrayList)
		{
			foreach (object item in arrayList)
			{
				list.Add($"{text}:{item}");
			}
		}
		Dictionary<string, StoreItem[]> blackMarket_StoreItem = FGUIManager.Instance.BlackMarket_StoreItem;
		if (blackMarket_StoreItem == null || blackMarket_StoreItem.Count <= 0)
		{
			return false;
		}
		List<string> second = blackMarket_StoreItem.Keys.ToList();
		if (list.Count > 0 && !list.Intersect(second).Any())
		{
			return false;
		}
		foreach (KeyValuePair<string, StoreItem[]> item2 in blackMarket_StoreItem)
		{
			StoreItem[] value4 = item2.Value;
			bool flag = false;
			if (!list.Contains(item2.Key))
			{
				continue;
			}
			StoreItem[] array = value4;
			foreach (StoreItem storeItem in array)
			{
				if (storeItem.StoreItemId == value.ToString())
				{
					flag = true;
					break;
				}
			}
			if (!flag)
			{
				continue;
			}
			int num = Convert.ToInt32(value2) - 1;
			if (filterPayload is ObservableDictionary<string, object> val)
			{
				val["Total"] = num;
			}
			else
			{
				filterPayload["Total"] = num;
			}
			return num <= 0;
		}
		return false;
	}

	private bool WatchingReplayFilter(GameManagers managers, string triggerId, Dictionary<string, object> callbackParams)
	{
		Dictionary<string, object> filterPayload = managers.TriggerManager.GetFilterPayload(triggerId);
		int num = Convert.ToInt32(filterPayload["Payload"]) - 1;
		if (filterPayload is ObservableDictionary<string, object> val)
		{
			val["Payload"] = num;
		}
		else
		{
			filterPayload["Payload"] = num;
		}
		return num <= 0;
	}

	private bool AttackInstanceClaimedFinalPrizeFilter(GameManagers managers, string triggerId, Dictionary<string, object> callbackParams)
	{
		Dictionary<string, object> filterPayload = managers.TriggerManager.GetFilterPayload(triggerId);
		int num = Convert.ToInt32(filterPayload["Payload"]) - 1;
		if (filterPayload is ObservableDictionary<string, object> val)
		{
			val["Payload"] = num;
		}
		else
		{
			filterPayload["Payload"] = num;
		}
		return num <= 0;
	}

	private bool PvPRankBattleStart(GameManagers managers, string triggerId, Dictionary<string, object> callbackParams)
	{
		Dictionary<string, object> filterPayload = managers.TriggerManager.GetFilterPayload(triggerId);
		int num = Convert.ToInt32(filterPayload["Payload"]) - 1;
		if (filterPayload is ObservableDictionary<string, object> val)
		{
			val["Payload"] = num;
		}
		else
		{
			filterPayload["Payload"] = num;
		}
		return num <= 0;
	}

	private bool OnSoldierLevelUpFilter(GameManagers managers, string triggerId, Dictionary<string, object> callbackParams)
	{
		Dictionary<string, object> filterPayload = managers.TriggerManager.GetFilterPayload(triggerId);
		int num = Convert.ToInt32(filterPayload["Total"]) - 1;
		if (filterPayload is ObservableDictionary<string, object> val)
		{
			val["Total"] = num;
		}
		else
		{
			filterPayload["Total"] = num;
		}
		return num <= 0;
	}

	private bool OnSoldierEvoluteFilter(GameManagers managers, string triggerId, Dictionary<string, object> callbackParams)
	{
		Dictionary<string, object> filterPayload = managers.TriggerManager.GetFilterPayload(triggerId);
		int num = Convert.ToInt32(filterPayload["Total"]) - 1;
		if (filterPayload is ObservableDictionary<string, object> val)
		{
			val["Total"] = num;
		}
		else
		{
			filterPayload["Total"] = num;
		}
		return num <= 0;
	}

	private bool OnSoldierPotentialUpgradeFilter(GameManagers managers, string triggerId, Dictionary<string, object> cases)
	{
		Dictionary<string, object> filterPayload = managers.TriggerManager.GetFilterPayload(triggerId);
		string soldierId = filterPayload["Id"].ToString();
		int num = Convert.ToInt32(filterPayload["PotentialLevel"].ToString());
		int soldierPotentialLevel = managers.UserArchiveManager.GetSoldierPotentialLevel(soldierId);
		return soldierPotentialLevel >= num;
	}

	private bool OnSoldierUnlockFilter(GameManagers managers, string triggerId, Dictionary<string, object> cases)
	{
		Dictionary<string, object> filterPayload = managers.TriggerManager.GetFilterPayload(triggerId);
		string item = filterPayload["Id"]?.ToString();
		return managers.UserArchiveManager.GetUnlockedSoldiers().Contains(item);
	}

	private bool LegendItemEnhancedFilter(GameManagers managers, string triggerId, Dictionary<string, object> callbackParams)
	{
		Dictionary<string, object> filterPayload = managers.TriggerManager.GetFilterPayload(triggerId);
		int num = Convert.ToInt32(filterPayload["Total"]) - 1;
		if (filterPayload is ObservableDictionary<string, object> val)
		{
			val["Total"] = num;
		}
		else
		{
			filterPayload["Total"] = num;
		}
		return num <= 0;
	}

	private bool LegendItemChangedPropsFilter(GameManagers managers, string triggerId, Dictionary<string, object> callbackParams)
	{
		Dictionary<string, object> filterPayload = managers.TriggerManager.GetFilterPayload(triggerId);
		int num = Convert.ToInt32(filterPayload["Total"]) - 1;
		if (filterPayload is ObservableDictionary<string, object> val)
		{
			val["Total"] = num;
		}
		else
		{
			filterPayload["Total"] = num;
		}
		return num <= 0;
	}

	private bool LegendItemReforgedFilter(GameManagers managers, string triggerId, Dictionary<string, object> callbackParams)
	{
		Dictionary<string, object> filterPayload = managers.TriggerManager.GetFilterPayload(triggerId);
		int num = Convert.ToInt32(filterPayload["Total"]) - 1;
		if (filterPayload is ObservableDictionary<string, object> val)
		{
			val["Total"] = num;
		}
		else
		{
			filterPayload["Total"] = num;
		}
		return num <= 0;
	}
}
