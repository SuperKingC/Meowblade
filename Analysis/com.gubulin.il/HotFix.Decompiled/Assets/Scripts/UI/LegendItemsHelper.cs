using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Assets.Scripts.Managers;
using FairyGUI;
using GameDataEditor;
using GameMaths;
using HotFix.Sources.Base.Scripts.Helper;
using HotFix.Sources.Base.Scripts.Managers.LegendItemsManager;
using Shift.Legion.ClientApi;
using Shift.Legion.ClientApi.Models;
using Shift.Legion.ClientApi.Models.LegendItemBlueprint;
using Shift.Legion.ClientApi.Protocol.Modules.LegendItem;
using Shift.Legion.ClientApi.Protocol.Modules.LegendItem.Models;
using Shift.Legion.ClientApi.Protocol.Modules.LegendItemEnhancement;
using Shift.Legion.ClientApi.Protocol.Modules.SoldierItemSlot;
using Shift.Legion.ClientApi.Protocol.Modules.SoldierItemSlot.Models;
using Shift.Legion.ClientApi.Protocol.Modules.SoldierLegendItem;
using Shift.Legion.ClientApi.Protocol.UserAction;
using Shift.Legion.Common.Managers;
using Shift.Legion.Common.Models;
using Shift.Legion.Common.Models.LegendItem;
using Shift.Legion.Common.Services;
using Shift.Legion.Common.Sources.Enums;
using Shift.Legion.GvG.Common.Models;
using Shift.Legion.Helpers;
using UI.GvGExpeditionHall;
using UI.LegendItemBlueprint;
using UI.LegendItemCultivation;
using UI.MainCity;
using UI.Tips;

namespace Assets.Scripts.UI;

public static class LegendItemsHelper
{
	public class BlackMarketLegendItem
	{
		public LegendItemData ItemData;

		public int Rarity;

		public string Name;

		public string SetId;

		public string Score;

		public string Icon;

		public BlackMarketLegendItem(LegendItemData itemData, string legendItemId, string score)
		{
			ItemData = itemData;
			GDELegendItemData gDELegendItemData = LegendItemManager.LegendItemTemplates[legendItemId];
			Rarity = gDELegendItemData.Rarity;
			Name = gDELegendItemData.Name;
			SetId = gDELegendItemData.SetId;
			Icon = gDELegendItemData.Icon;
			Score = (string.IsNullOrWhiteSpace(score) ? "----" : score);
		}
	}

	public enum PendingAttrTipType
	{
		None,
		HighValue,
		AllMax
	}

	public class OpenPanelData
	{
		public int ShowLegendItemType;

		public List<string> FilterItemId;

		public int FilterRarity;

		public int CurrentSlotIndex;

		public long CurrentSlotInstanceId;

		public string CurrentSlotULItemId;
	}

	public enum CanNotSelectTipType
	{
		IsMainLegendItem,
		Equipped,
		Occupied,
		Pending
	}

	public class ConfirmDialogInfo
	{
		public bool ShowCancelBtn;

		public bool CanNotChangeLock;

		public List<CanNotSelectTipType> TipType;

		public void ShowTip(string legendItemName = "")
		{
			if (TipType != null && TipType.Count > 0)
			{
				for (int i = 0; i < TipType.Count; i++)
				{
					ShowCanNotSelectTip(TipType[i], legendItemName);
				}
			}
		}
	}

	public const int InitialNeedExp = 150;

	public const int InitialItemEntryDataValueInt = 10;

	public const float InitialItemEntryDataValuePct = 0.05f;

	public static List<LegendItemUi> LegendItems;

	public static Dictionary<string, long[]> SoldiersEquippedItems;

	public static Dictionary<string, string> EquippedLegendItems = new Dictionary<string, string>();

	private static Dictionary<string, List<int>> ReforgeLockSubEntries = new Dictionary<string, List<int>>();

	private const int SecondPropetryUnlockLevel = 5;

	private const int ThirdPropetryUnlockLevel = 10;

	private static Dictionary<string, int[]> SoldierItemSlotStates;

	private static readonly Lazy<TopTournamentLegendItemReminder> _topTournamentLegendItemReminder = new Lazy<TopTournamentLegendItemReminder>(() => new TopTournamentLegendItemReminder());

	private const string ChangeEntryTip = "LegendItemSubEntrymChangeTip";

	private const string ReforgeEntryTip = "LegendItemSubEntrymReforgeTip";

	public static bool IsFirstLegendItemsDraw;

	public const string BlueprintFrameUrl = "ui://PublicResources/kuang_round 2_lv6";

	private static bool blueprintDataInit;

	private const string Blueprint_Name_Prefix_Key = "Blueprint_Name_Prefix";

	private static string Blueprint_Name_Prefix;

	private static Dictionary<string, GDELegendItemSetData> _legendItemSetMap;

	private static Dictionary<string, List<string>> _legendItemTags;

	private static Dictionary<string, List<string>> _legendItemProperyExclude;

	public const int SoldierItemMaxSlots = 2;

	private static List<SoldierWithLegendItemId> units = new List<SoldierWithLegendItemId>();

	private const int IsMainLegendItemCode = 81311510;

	private const int EquippedCode = 81311512;

	private const int PendingCode = 81311509;

	private const int OccupiedCode = 81311511;

	private const string TopLeagueTextKey = "TopLeagueText";

	public static bool HasAnyLegendItem
	{
		get
		{
			List<string> unlockedMainCityCom = GameManagers.Instance.UserArchiveManager.GetUnlockedMainCityCom();
			return unlockedMainCityCom.Contains("MainCity.LegendItems");
		}
	}

	public static TopTournamentLegendItemReminder TopTournamentLegendItemReminder => _topTournamentLegendItemReminder.Value;

	public static bool Level6_UI_Open => GameManagers.Instance.UserArchiveManager.GetChapterLevelProgress("C1005").Contains("P520");

	public static bool DisplayLegendItemBlueprintUi { get; private set; }

	public static Dictionary<string, GDELegendItemSetData> LegendItemSetMap
	{
		get
		{
			if (_legendItemSetMap == null)
			{
				_legendItemSetMap = new Dictionary<string, GDELegendItemSetData>();
				IEnumerable<GDELegendItemSetData> allItems = GDMgr.GetAllItems<GDELegendItemSetData>();
				foreach (GDELegendItemSetData item in allItems)
				{
					if (item.SetPieces == null)
					{
						continue;
					}
					foreach (string setPiece in item.SetPieces)
					{
						_legendItemSetMap.Add(setPiece, item);
					}
				}
			}
			return _legendItemSetMap;
		}
	}

	public static string GetInitEnhanceLevelConfigId(int raity)
	{
		return $"{raity}星宝物强化规则";
	}

	public static void LoadReforgeLockSubEntries()
	{
		string reforgeSubEntries = GameLocalDataManager.GetReforgeSubEntries();
		if (!string.IsNullOrWhiteSpace(reforgeSubEntries))
		{
			ReforgeLockSubEntries = JsonHelper.ToObject<Dictionary<string, List<int>>>(reforgeSubEntries);
		}
	}

	public static List<int> GetLegendItemLockSubEntriesIndex(long itemUiId)
	{
		string key = itemUiId.ToString();
		return ReforgeLockSubEntries.ContainsKey(key) ? ReforgeLockSubEntries[key] : null;
	}

	public static void SetLegendItemLockSubEntriesIndex(LegendItemUi legendItemUi, int index)
	{
		string key = legendItemUi.InstanceId.ToString();
		if (ReforgeLockSubEntries.ContainsKey(key))
		{
			if (ReforgeLockSubEntries[key].Contains(index))
			{
				legendItemUi.ReforgeIndex.Remove(index);
			}
			else
			{
				legendItemUi.ReforgeIndex.Add(index);
			}
			ReforgeLockSubEntries[key] = legendItemUi.ReforgeIndex;
		}
		else
		{
			ReforgeLockSubEntries.Add(key, new List<int> { index });
			legendItemUi.ReforgeIndex = new List<int> { index };
		}
		GameLocalDataManager.SetReforgeSubEntries(JsonHelper.ToJson(ReforgeLockSubEntries));
	}

	public static bool ChangeEntriesExist(Shift.Legion.Common.Models.LegendItem.LegendItem item)
	{
		return false;
	}

	public static string GetEntries(List<ItemEntry> entries, bool isFxEntry = false)
	{
		if (entries == null)
		{
			return "";
		}
		string text = "";
		for (int i = 0; i < entries.Count; i++)
		{
			string legendItemPropetryDesc = LanguagesManager.GetLegendItemPropetryDesc(entries[i].EntryId, entries[i].Attributes, isFxEntry);
			if (!string.IsNullOrWhiteSpace(legendItemPropetryDesc))
			{
				text += legendItemPropetryDesc;
			}
			else
			{
				int num = 0;
				foreach (ItemEntryData attribute in entries[i].Attributes)
				{
					text += $"{attribute.Key} {attribute.Value}";
					if (num < entries[i].Attributes.Count - 1)
					{
						text += Environment.NewLine;
					}
					num++;
				}
			}
			if (i < entries.Count - 1)
			{
				text += Environment.NewLine;
			}
		}
		return text;
	}

	public static string GetEntries(List<ItemEntryBrief> entries, bool isFxEntry = false)
	{
		if (entries == null)
		{
			return "";
		}
		string text = "";
		for (int i = 0; i < entries.Count; i++)
		{
			string legendItemPropetryDesc = LanguagesManager.GetLegendItemPropetryDesc(entries[i].EntryId, entries[i].Attributes, isFxEntry);
			if (!string.IsNullOrWhiteSpace(legendItemPropetryDesc))
			{
				text += legendItemPropetryDesc;
			}
			else
			{
				int num = 0;
				foreach (ItemEntryData attribute in entries[i].Attributes)
				{
					text += $"{attribute.Key} {attribute.Value}";
					if (num < entries[i].Attributes.Count - 1)
					{
						text += Environment.NewLine;
					}
					num++;
				}
			}
			if (i < entries.Count - 1)
			{
				text += Environment.NewLine;
			}
		}
		return text;
	}

	public static string GetSubEntries(LegendItemUi itemUi)
	{
		List<ItemEntry> subEntries = itemUi.LegendItemData.SubEntries;
		if (subEntries == null)
		{
			return "";
		}
		string text = "";
		for (int i = 0; i < subEntries.Count; i++)
		{
			if (!GetSubPropertyUnlocked(itemUi, i))
			{
				text = text + LanguagesManager.GetLockedSubEntryText() + string.Format("[color=#66FF66]（{0}{1}{2}）[/color]", LanguagesManager.GetDesc("CsharpCodeZhTcText319"), GetSubPropertyUnlockLevel(itemUi, i), LanguagesManager.GetDesc("CsharpCodeZhTcText320"));
			}
			else
			{
				string legendItemPropetryDesc = LanguagesManager.GetLegendItemPropetryDesc(subEntries[i].EntryId, subEntries[i].Attributes);
				if (!string.IsNullOrWhiteSpace(legendItemPropetryDesc))
				{
					text += legendItemPropetryDesc;
				}
				else
				{
					int num = 0;
					foreach (ItemEntryData attribute in subEntries[i].Attributes)
					{
						text += $"{attribute.Key} {attribute.Value}";
						if (num < subEntries[i].Attributes.Count - 1)
						{
							text += Environment.NewLine;
						}
						num++;
					}
				}
			}
			if (i < subEntries.Count - 1)
			{
				text += Environment.NewLine;
			}
		}
		return text;
	}

	public static string GetSubEntries(BlackMarketLegendItem itemData)
	{
		List<ItemEntry> subEntries = itemData.ItemData.SubEntries;
		if (subEntries == null)
		{
			return "";
		}
		string text = "";
		for (int i = 0; i < subEntries.Count; i++)
		{
			if (!GetSubPropertyUnlocked(i))
			{
				text = text + LanguagesManager.GetLockedSubEntryText() + string.Format("[color=#66FF66]（{0}{1}{2}）[/color]", LanguagesManager.GetDesc("CsharpCodeZhTcText319"), GetSubPropertyUnlockLevel(itemData, i), LanguagesManager.GetDesc("CsharpCodeZhTcText320"));
			}
			else
			{
				string legendItemPropetryDesc = LanguagesManager.GetLegendItemPropetryDesc(subEntries[i].EntryId, subEntries[i].Attributes);
				if (!string.IsNullOrWhiteSpace(legendItemPropetryDesc))
				{
					text += legendItemPropetryDesc;
				}
				else
				{
					int num = 0;
					foreach (ItemEntryData attribute in subEntries[i].Attributes)
					{
						text += $"{attribute.Key} {attribute.Value}";
						if (num < subEntries[i].Attributes.Count - 1)
						{
							text += Environment.NewLine;
						}
						num++;
					}
				}
			}
			if (i < subEntries.Count - 1)
			{
				text += Environment.NewLine;
			}
		}
		return text;
	}

	public static string GetSubEntries(LegendItemBrief itemData)
	{
		List<ItemEntryBrief> subEntries = itemData.SubEntries;
		if (subEntries == null)
		{
			return "";
		}
		string text = "";
		for (int i = 0; i < subEntries.Count; i++)
		{
			string legendItemPropetryDesc = LanguagesManager.GetLegendItemPropetryDesc(subEntries[i].EntryId, subEntries[i].Attributes);
			if (!string.IsNullOrWhiteSpace(legendItemPropetryDesc))
			{
				text += legendItemPropetryDesc;
			}
			else
			{
				int num = 0;
				foreach (ItemEntryData attribute in subEntries[i].Attributes)
				{
					text += $"{attribute.Key} {attribute.Value}";
					if (num < subEntries[i].Attributes.Count - 1)
					{
						text += Environment.NewLine;
					}
					num++;
				}
			}
			if (i < subEntries.Count - 1)
			{
				text += Environment.NewLine;
			}
		}
		return text;
	}

	public static string GetChangeEntryText(ItemEntry entries)
	{
		if (entries == null)
		{
			return null;
		}
		string text = null;
		string legendItemPropetryDesc = LanguagesManager.GetLegendItemPropetryDesc(entries.EntryId, entries.Attributes);
		if (!string.IsNullOrWhiteSpace(legendItemPropetryDesc))
		{
			text += legendItemPropetryDesc;
		}
		else
		{
			int num = 0;
			foreach (ItemEntryData attribute in entries.Attributes)
			{
				text += $"{attribute.Key} {attribute.Value}";
				if (num < entries.Attributes.Count - 1)
				{
					text += Environment.NewLine;
				}
				num++;
			}
		}
		return text;
	}

	public static string GetEntryText(ItemEntry entries, string textTitle, ItemEntry lastItemEntries = null, bool isFxEntry = false)
	{
		if (entries == null)
		{
			return null;
		}
		string text = null;
		string changePropetry = LanguagesManager.GetChangePropetry(entries.EntryId, entries.Attributes, textTitle, lastItemEntries?.Attributes, isFxEntry);
		if (!string.IsNullOrWhiteSpace(changePropetry))
		{
			text += changePropetry;
		}
		else
		{
			int num = 0;
			foreach (ItemEntryData attribute in entries.Attributes)
			{
				text += $"{attribute.Key} {attribute.Value}";
				if (num < entries.Attributes.Count - 1)
				{
					text += Environment.NewLine;
				}
				num++;
			}
		}
		return text;
	}

	public static Dictionary<string, string> GetReforgeEntry(ItemEntry entries, out string maxLogoText)
	{
		if (entries == null)
		{
			maxLogoText = "";
			return null;
		}
		return LanguagesManager.GetReforgeTitle(entries.EntryId, entries.Attributes, out maxLogoText);
	}

	public static Dictionary<string, string> GetReforgeEntry(ItemEntryBrief entries, out string maxLogoText)
	{
		if (entries == null)
		{
			maxLogoText = "";
			return null;
		}
		return LanguagesManager.GetReforgeTitle(entries.EntryId, entries.Attributes, out maxLogoText);
	}

	public static List<string> GetEntriesList(List<ItemEntry> entries)
	{
		List<string> list = new List<string>();
		if (entries == null)
		{
			return list;
		}
		for (int i = 0; i < entries.Count; i++)
		{
			string text = LanguagesManager.GetLegendItemPropetryDesc(entries[i].EntryId, entries[i].Attributes);
			if (string.IsNullOrWhiteSpace(text))
			{
				foreach (ItemEntryData attribute in entries[i].Attributes)
				{
					text += $"{attribute.Key} {attribute.Value}";
				}
			}
			if (i < entries.Count - 1)
			{
				text += Environment.NewLine;
			}
			list.Add(text);
		}
		return list;
	}

	public static List<KeyValuePair<string, int>> GetEntriesKeyValuePairs(List<ItemEntry> entries)
	{
		List<KeyValuePair<string, int>> list = new List<KeyValuePair<string, int>>();
		if (entries == null)
		{
			return list;
		}
		for (int i = 0; i < entries.Count; i++)
		{
			foreach (ItemEntryData attribute in entries[i].Attributes)
			{
				list.Add(new KeyValuePair<string, int>(attribute.Key, attribute.Value));
			}
		}
		return list;
	}

	public static bool GetSubPropertyUnlocked(LegendItemUi itemUi, int propetryIndex)
	{
		return propetryIndex < itemUi.LegendItemData.UnlockedSubEntries;
	}

	public static bool GetSubPropertyUnlocked(int propetryIndex)
	{
		return propetryIndex < 1;
	}

	public static int GetSubPropertyUnlockLevel(LegendItemUi itemUi, int propetryIndex)
	{
		List<Dictionary<int, int>> list = LegendItemManager.LegendItemNextUnlockEnhanceLevel.Values.ToList();
		if (list.Count <= 0)
		{
			if (propetryIndex == 1)
			{
				return 5;
			}
			return 10;
		}
		int num = itemUi.LegendItemData.Data.Rarity - 1;
		if (list.Count >= num + 1)
		{
			Dictionary<int, int> dictionary = list[num];
			if (dictionary.ContainsKey(propetryIndex + 1))
			{
				return dictionary[propetryIndex + 1];
			}
			return 0;
		}
		return 0;
	}

	public static int GetSubPropertyUnlockLevel(BlackMarketLegendItem itemData, int propetryIndex)
	{
		List<Dictionary<int, int>> list = LegendItemManager.LegendItemNextUnlockEnhanceLevel.Values.ToList();
		if (list.Count <= 0)
		{
			if (propetryIndex == 1)
			{
				return 5;
			}
			return 10;
		}
		int num = itemData.Rarity - 1;
		if (list.Count >= num + 1)
		{
			Dictionary<int, int> dictionary = list[num];
			if (dictionary.ContainsKey(propetryIndex + 1))
			{
				return dictionary[propetryIndex + 1];
			}
			return 0;
		}
		return 0;
	}

	public static void SetSoldiersEquippedItems(Dictionary<string, long[]> dataItems)
	{
		GameManagers.Instance.SoldierEquipmentManager.SoldiersEquippedItems.Value = dataItems;
		if (dataItems == null)
		{
			SoldiersEquippedItems = new Dictionary<string, long[]>();
		}
		else
		{
			SoldiersEquippedItems = dataItems;
		}
		SetEquippedLegendItems();
	}

	public static void UpdateSoldiersEquippedItems(string soldierId, long[] items)
	{
		if (SoldiersEquippedItems == null)
		{
			SoldiersEquippedItems = new Dictionary<string, long[]>();
		}
		if (SoldiersEquippedItems.ContainsKey(soldierId))
		{
			SoldiersEquippedItems[soldierId] = items;
		}
		else
		{
			SoldiersEquippedItems.Add(soldierId, items);
		}
		SetEquippedLegendItems();
	}

	public static void ReplaceSoldierEquip(long instanceId)
	{
		if (!EquippedLegendItems.ContainsKey(instanceId.ToString()))
		{
			return;
		}
		string key = EquippedLegendItems[instanceId.ToString()];
		long[] array = SoldiersEquippedItems[key];
		int num = -1;
		for (int i = 0; i < array.Length; i++)
		{
			if (array[i] == instanceId)
			{
				num = i;
				break;
			}
		}
		if (num >= 0)
		{
			SoldiersEquippedItems[key][num] = 0L;
		}
	}

	private static void SetEquippedLegendItems()
	{
		EquippedLegendItems.Clear();
		foreach (KeyValuePair<string, long[]> soldiersEquippedItem in SoldiersEquippedItems)
		{
			for (int i = 0; i < soldiersEquippedItem.Value.Length; i++)
			{
				if (soldiersEquippedItem.Value[i] > 0)
				{
					string key = soldiersEquippedItem.Value[i].ToString();
					if (EquippedLegendItems.ContainsKey(key))
					{
						EquippedLegendItems[key] = soldiersEquippedItem.Key;
					}
					else
					{
						EquippedLegendItems.Add(key, soldiersEquippedItem.Key);
					}
				}
			}
		}
	}

	public static async Task GetLegendItemsData()
	{
		GetLegendItems((await GameController.Contexts.Service<INetworkService>().LegendItemAll()).Items);
		SoldierEquippedItemsAllResponse _soldier_equip = await GameController.Contexts.Service<INetworkService>().SoldierEquippedItemsAll();
		GameManagers.Instance.SoldierEquipmentManager.SoldiersEquippedItems = _soldier_equip.SoldiersEquippedItems;
		SetSoldiersEquippedItems(_soldier_equip.SoldiersEquippedItems.Value);
		SetSoldierItemSlotData((await GameController.Contexts.Service<INetworkService>().SoldierItemSlotAll()).SoldiersItemSlots);
	}

	public static void UiGetLegendItems(Action action, int sortingOrder)
	{
		if (LegendItems != null)
		{
			action();
			return;
		}
		ILRequestHelper<LegendItemAllResponse>.Request((EventContext)null, (Func<Task<LegendItemAllResponse>>)(() => GameController.Contexts.Service<INetworkService>().LegendItemAll()), (Action<LegendItemAllResponse>)delegate(LegendItemAllResponse response)
		{
			if (!response.Result)
			{
				List<string> arg = new List<string> { LanguagesManager.GetDesc("CsharpCodeZhTcText74") + "！" };
				SharedMessenger.Broadcast("SHOW_TIPS", arg, sortingOrder + 1, arg3: false);
			}
			else
			{
				GetLegendItems(response.Items);
				UiGetSoldiersEquippedItems(action, sortingOrder);
			}
		});
	}

	private static void UiGetSoldiersEquippedItems(Action action, int sortingOrder)
	{
		if (SoldiersEquippedItems != null)
		{
			action();
			return;
		}
		ILRequestHelper<SoldierEquippedItemsAllResponse>.Request((EventContext)null, (Func<Task<SoldierEquippedItemsAllResponse>>)(() => GameController.Contexts.Service<INetworkService>().SoldierEquippedItemsAll()), (Action<SoldierEquippedItemsAllResponse>)delegate(SoldierEquippedItemsAllResponse response)
		{
			if (!response.Result)
			{
				List<string> arg = new List<string> { LanguagesManager.GetDesc("CsharpCodeZhTcText75") + "！" };
				SharedMessenger.Broadcast("SHOW_TIPS", arg, sortingOrder + 1, arg3: false);
			}
			else
			{
				SetSoldiersEquippedItems(response.SoldiersEquippedItems.Value);
				UiGetSoldiersItemsSlotInfo(action, sortingOrder);
			}
		});
	}

	private static void UiGetSoldiersItemsSlotInfo(Action action, int sortingOrder)
	{
		if (SoldierItemSlotStates != null)
		{
			action();
			return;
		}
		ILRequestHelper<SoldierItemSlotAllResponse>.Request((EventContext)null, (Func<Task<SoldierItemSlotAllResponse>>)(() => GameController.Contexts.Service<INetworkService>().SoldierItemSlotAll()), (Action<SoldierItemSlotAllResponse>)delegate(SoldierItemSlotAllResponse response)
		{
			if (!response.Result)
			{
				if (response.ErrorCode != 0)
				{
					ILRequestHelper.ShowErrorCode(response.ErrorCode);
				}
			}
			else
			{
				SetSoldierItemSlotData(response.SoldiersItemSlots);
				action();
			}
		});
	}

	public static void SetSoldierItemSlotData(SoldiersItemSlots slotData)
	{
		SoldierItemSlotStates = new Dictionary<string, int[]>();
		if (slotData.Value != null)
		{
			SoldierItemSlotStates = DictionaryExtensions.DeepCopy<string, int[]>(slotData.Value);
			GameManagers.Instance.SoldierItemSlotsManager.SetSoldiersItemSlots(slotData);
		}
		else
		{
			slotData.Value = new Dictionary<string, int[]>();
			GameManagers.Instance.SoldierItemSlotsManager.SetSoldiersItemSlots(slotData);
		}
	}

	public static bool GetSoldierItemSlotState(string soldierId, int slot)
	{
		return GameManagers.Instance.SoldierItemSlotsManager.IsSlotUnlocked(soldierId, slot);
	}

	public static bool CanUseLegendItem(LegendItemUi itemUi)
	{
		return EquippedLegendItems.ContainsKey(itemUi.InstanceId.ToString()) || itemUi.LegendItemData.Locked;
	}

	public static Dictionary<string, int> GetUnlockSoldierItemSlotCost(string soldierId, int slotId)
	{
		if (!SoldierItemSlotsManager.UnlockRequirements.TryGetValue(soldierId, out var value))
		{
			value = SoldierItemSlotsManager.UnlockRequirements["Normal"];
		}
		using (List<ResourceRequirement>.Enumerator enumerator = value[slotId].GetEnumerator())
		{
			if (enumerator.MoveNext())
			{
				ResourceRequirement current = enumerator.Current;
				return new Dictionary<string, int> { { current.ItemId, current.Qty } };
			}
		}
		return new Dictionary<string, int> { { "Gem", 0 } };
	}

	public static bool CanUnlockable(string soldierId, int slotId)
	{
		return GameManagers.Instance.SoldierItemSlotsManager.IsSlotUnlockable(soldierId, slotId) && GameManagers.Instance.SoldierItemSlotsManager.IsSlotUnlockRequirementsEnough(soldierId, slotId);
	}

	public static void UnlockSoldierItemSlot(string soldierId, int slotId, Action action)
	{
		ILRequestHelper<SoldierItemSlotUnlockResponse>.Request((EventContext)null, (Func<Task<SoldierItemSlotUnlockResponse>>)(() => GameController.Contexts.Service<INetworkService>().SoldierItemSlotUnlock(soldierId, slotId)), (Action<SoldierItemSlotUnlockResponse>)delegate(SoldierItemSlotUnlockResponse response)
		{
			if (!response.Result)
			{
				if (response.ErrorCode != 0)
				{
					ILRequestHelper.ShowErrorCode(response.ErrorCode);
				}
			}
			else
			{
				GameManagers.Instance.SoldierItemSlotsManager.SetSlotUnlocked(soldierId, slotId);
				GameManagers.Instance.StockController.ReadStockChangeRecords(response.Costs);
				SharedMessenger.Broadcast("SOLDIER_LEGEND_ITEM_SLOT_UNLOCKED", soldierId, slotId);
				if (slotId > 0)
				{
					ThinkingDataHelper.Instance.LegendItemSlotUnlockTrack(soldierId);
				}
				if (slotId == 1 && Define.SoldierMythUnderDevelopment())
				{
					SharedMessenger.Broadcast("SHOW_L_TO_M_PAGE");
				}
				else
				{
					action?.Invoke();
				}
			}
		});
	}

	public static int GetLegendItemTotalExpNeed(LegendItemUi target, int levelAdd = 0)
	{
		string configId = ((target.LegendItemData.EnhancementConfig != null) ? target.LegendItemData.EnhancementConfig.ConfigId : GetInitEnhanceLevelConfigId(target.LegendItemData.Data.Rarity));
		int num = target.LegendItemData.EnhanceLevel + levelAdd;
		LegendItemEnhancementConfig maxLeveLegendItemEnhancementConfig;
		int legendItemMaxLevelEnhancementConfigs = GetLegendItemMaxLevelEnhancementConfigs(target, out maxLeveLegendItemEnhancementConfig);
		if (num > legendItemMaxLevelEnhancementConfigs)
		{
			num = legendItemMaxLevelEnhancementConfigs;
		}
		if (num == 0)
		{
			return 0;
		}
		return LegendItemEnhancementConfig.GetEnhanceConfig(configId, num)?.TotalExpNeed ?? target.LegendItemData.TotalGainedExp;
	}

	public static string GetLegendItemMainPropetryKeyText(LegendItemUi target)
	{
		if (target.LegendItemData.MainEntries == null || target.LegendItemData.MainEntries.Count <= 0)
		{
			return "";
		}
		string maxLogoText;
		return GetReforgeEntry(target.LegendItemData.MainEntries.First(), out maxLogoText).Values.First();
	}

	public static string GetLegendItemMainPropetryKeyText(LegendItemData target)
	{
		if (target.MainEntries == null || target.MainEntries.Count <= 0)
		{
			return "";
		}
		string maxLogoText;
		return GetReforgeEntry(target.MainEntries.First(), out maxLogoText).Values.First();
	}

	public static string GetLegendItemMainPropetryKeyText(LegendItemBrief target)
	{
		if (target.MainEntries == null || target.MainEntries.Count <= 0)
		{
			return "";
		}
		string maxLogoText;
		return GetReforgeEntry(target.MainEntries.First(), out maxLogoText).Values.First();
	}

	public static string GetLegendItemNextEnhanceLevelValue(LegendItemUi target, int levelAdd = 0)
	{
		string text = "";
		if (levelAdd == 0 && target.LegendItemData.EnhancementConfig == null)
		{
			for (int i = 0; i < target.LegendItemData.MainEntries.Count; i++)
			{
				ItemEntry itemEntry = target.LegendItemData.MainEntries[i];
				for (int j = 0; j < itemEntry.Attributes.Count; j++)
				{
					ItemEntryData itemEntryData = itemEntry.Attributes[j];
					float num = itemEntryData.GetValue();
					if (levelAdd != 0)
					{
						num = ((!itemEntryData.IsPercent) ? (num + 10f) : (num + 0.05f));
					}
					bool flag = itemEntryData.IsPercent || Modifier.NeedPercentConvertProcess(itemEntryData.Key);
					string entryValuePrecision = LanguagesManager.GetEntryValuePrecision(itemEntry.EntryId);
					if (flag)
					{
						num *= 100f;
					}
					string text2;
					if (string.IsNullOrEmpty(entryValuePrecision))
					{
						text2 = Convert.ToInt32(num).ToString();
					}
					else
					{
						text2 = num.ToString(entryValuePrecision);
						if (text2.EndsWith("."))
						{
							text2 += "0";
						}
					}
					text = "+" + text2;
					if (flag)
					{
						text += "%";
					}
				}
			}
			return text;
		}
		string configId = ((target.LegendItemData.EnhancementConfig != null) ? target.LegendItemData.EnhancementConfig.ConfigId : GetInitEnhanceLevelConfigId(target.LegendItemData.Data.Rarity));
		int enhanceLevel = target.LegendItemData.EnhanceLevel + levelAdd;
		LegendItemEnhancementConfig enhanceConfig = LegendItemEnhancementConfig.GetEnhanceConfig(configId, enhanceLevel);
		for (int k = 0; k < target.LegendItemData.MainEntries.Count; k++)
		{
			ItemEntry itemEntry2 = target.LegendItemData.MainEntries[k];
			for (int l = 0; l < itemEntry2.Attributes.Count; l++)
			{
				ItemEntryData itemEntryData2 = itemEntry2.Attributes[l];
				float value = itemEntryData2.GetValue();
				string text3 = itemEntryData2.Key;
				if (itemEntryData2.IsPercent)
				{
					text3 += "_PCT";
				}
				if (!enhanceConfig.EnhancedAttrs.ContainsKey(text3))
				{
					continue;
				}
				float value2 = enhanceConfig.EnhancedAttrs[text3].GetValue();
				float num2 = value + value2;
				string entryValuePrecision2 = LanguagesManager.GetEntryValuePrecision(itemEntry2.EntryId);
				bool flag2 = itemEntryData2.IsPercent || Modifier.NeedPercentConvertProcess(itemEntryData2.Key);
				if (flag2)
				{
					num2 *= 100f;
				}
				string text4;
				if (string.IsNullOrEmpty(entryValuePrecision2))
				{
					text4 = Convert.ToInt32(num2).ToString();
				}
				else
				{
					text4 = num2.ToString(entryValuePrecision2);
					if (text4.EndsWith("."))
					{
						text4 += "0";
					}
				}
				text = "+" + text4;
				if (flag2)
				{
					text += "%";
				}
			}
		}
		return text;
	}

	public static float GetLegendItemCurEnhanceLevelValue(Shift.Legion.Common.Models.LegendItem.LegendItem target)
	{
		float result = 0f;
		string configId = ((target.EnhancementConfig != null) ? target.EnhancementConfig.ConfigId : GetInitEnhanceLevelConfigId(target.Data.Rarity));
		int enhanceLevel = target.EnhanceLevel;
		LegendItemEnhancementConfig enhanceConfig = LegendItemEnhancementConfig.GetEnhanceConfig(configId, enhanceLevel);
		if (enhanceConfig == null)
		{
			return result;
		}
		for (int i = 0; i < target.MainEntries.Count; i++)
		{
			ItemEntry itemEntry = target.MainEntries[i];
			for (int j = 0; j < itemEntry.Attributes.Count; j++)
			{
				ItemEntryData itemEntryData = itemEntry.Attributes[j];
				float value = itemEntryData.GetValue();
				string text = itemEntryData.Key;
				if (itemEntryData.IsPercent)
				{
					text += "_PCT";
				}
				if (enhanceConfig.EnhancedAttrs != null && enhanceConfig.EnhancedAttrs.ContainsKey(text))
				{
					float value2 = enhanceConfig.EnhancedAttrs[text].GetValue();
					float num = value2;
					result = num;
				}
			}
		}
		return result;
	}

	public static string GetLegendItemNextEnhanceLevelValue(LegendItemData target, int levelAdd = 0)
	{
		string text = "";
		for (int i = 0; i < target.MainEntries.Count; i++)
		{
			ItemEntry itemEntry = target.MainEntries[i];
			for (int j = 0; j < itemEntry.Attributes.Count; j++)
			{
				ItemEntryData itemEntryData = itemEntry.Attributes[j];
				float num = itemEntryData.GetValue();
				if (levelAdd != 0)
				{
					num = ((!itemEntryData.IsPercent) ? (num + 10f) : (num + 0.05f));
				}
				string entryValuePrecision = LanguagesManager.GetEntryValuePrecision(itemEntry.EntryId);
				bool flag = itemEntryData.IsPercent || Modifier.NeedPercentConvertProcess(itemEntryData.Key);
				if (flag)
				{
					num *= 100f;
				}
				string text2;
				if (string.IsNullOrEmpty(entryValuePrecision))
				{
					text2 = Convert.ToInt32(num).ToString();
				}
				else
				{
					text2 = num.ToString(entryValuePrecision);
					if (text2.EndsWith("."))
					{
						text2 += "0";
					}
				}
				text = "+" + text2;
				if (flag)
				{
					text += "%";
				}
			}
		}
		return text;
	}

	public static string GetLegendItemNextEnhanceLevelValue(LegendItemBrief target, int rarity, int levelAdd = 0)
	{
		string text = "";
		if (levelAdd == 0 && target.EnhanceLevel == 0)
		{
			for (int i = 0; i < target.MainEntries.Count; i++)
			{
				ItemEntryBrief itemEntryBrief = target.MainEntries[i];
				for (int j = 0; j < itemEntryBrief.Attributes.Count; j++)
				{
					ItemEntryData itemEntryData = itemEntryBrief.Attributes[j];
					float num = itemEntryData.GetValue();
					if (levelAdd != 0)
					{
						num = ((!itemEntryData.IsPercent) ? (num + 10f) : (num + 0.05f));
					}
					bool flag = itemEntryData.IsPercent || Modifier.NeedPercentConvertProcess(itemEntryData.Key);
					string entryValuePrecision = LanguagesManager.GetEntryValuePrecision(itemEntryBrief.EntryId);
					if (flag)
					{
						num *= 100f;
					}
					string text2;
					if (string.IsNullOrEmpty(entryValuePrecision))
					{
						text2 = Convert.ToInt32(num).ToString();
					}
					else
					{
						text2 = num.ToString(entryValuePrecision);
						if (text2.EndsWith("."))
						{
							text2 += "0";
						}
					}
					text = "+" + text2;
					if (flag)
					{
						text += "%";
					}
				}
			}
			return text;
		}
		string initEnhanceLevelConfigId = GetInitEnhanceLevelConfigId(rarity);
		int enhanceLevel = target.EnhanceLevel + levelAdd;
		LegendItemEnhancementConfig enhanceConfig = LegendItemEnhancementConfig.GetEnhanceConfig(initEnhanceLevelConfigId, enhanceLevel);
		for (int k = 0; k < target.MainEntries.Count; k++)
		{
			ItemEntryBrief itemEntryBrief2 = target.MainEntries[k];
			for (int l = 0; l < itemEntryBrief2.Attributes.Count; l++)
			{
				ItemEntryData itemEntryData2 = itemEntryBrief2.Attributes[l];
				float value = itemEntryData2.GetValue();
				string text3 = itemEntryData2.Key;
				if (itemEntryData2.IsPercent)
				{
					text3 += "_PCT";
				}
				if (!enhanceConfig.EnhancedAttrs.ContainsKey(text3))
				{
					continue;
				}
				float value2 = enhanceConfig.EnhancedAttrs[text3].GetValue();
				float num2 = value + value2;
				string entryValuePrecision2 = LanguagesManager.GetEntryValuePrecision(itemEntryBrief2.EntryId);
				bool flag2 = itemEntryData2.IsPercent || Modifier.NeedPercentConvertProcess(itemEntryData2.Key);
				if (flag2)
				{
					num2 *= 100f;
				}
				string text4;
				if (string.IsNullOrEmpty(entryValuePrecision2))
				{
					text4 = Convert.ToInt32(num2).ToString();
				}
				else
				{
					text4 = num2.ToString(entryValuePrecision2);
					if (text4.EndsWith("."))
					{
						text4 += "0";
					}
				}
				text = "+" + text4;
				if (flag2)
				{
					text += "%";
				}
			}
		}
		return text;
	}

	public static void LegendItemEnhance(LegendItemUi target, List<LegendItemUi> foods, List<long> foodIds, Action action, Action<int> errorProcessor = null)
	{
		if (foodIds == null || foodIds.Count <= 0)
		{
			List<string> arg = new List<string> { LanguagesManager.GetDesc("CsharpCodeZhTcText69") };
			SharedMessenger.Broadcast("SHOW_TIPS", arg, 1, arg3: false);
			return;
		}
		if (foodIds != null)
		{
			foreach (long foodId in foodIds)
			{
				string gvGSoldierIdByEquippedLegendItem = GameManagers.Instance.GetGvGSoldierIdByEquippedLegendItem(foodId);
				if (!string.IsNullOrEmpty(gvGSoldierIdByEquippedLegendItem))
				{
					LegendItemUi legendItemUi = GetLegendItemUi(foodId);
					string tipText = string.Format(LanguagesManager.GetDesc("LegendItemCostFailed_InGvG"), legendItemUi.LegendItemData.Data.Name);
					tipText.ToConfirmPopup(delegate
					{
						GameController.Contexts.Service<IUiService>().CloseAll(ignoreLoading: true, new List<string> { UI_MainCity.Name });
						GameController.Contexts.Service<IUiService>().OpenPanel(UI_GvGExpeditionHallPanel.Name, null);
					}, null, (AlignType)0);
					return;
				}
			}
		}
		int oldEnhanceLevel = target.LegendItemData.EnhanceLevel;
		ILRequestHelper<LegendItemEnhancementEnhanceResponse>.Request((EventContext)null, (Func<Task<LegendItemEnhancementEnhanceResponse>>)(() => GameController.Contexts.Service<INetworkService>().EnhanceLegendItem(target.InstanceId, foodIds)), (Action<LegendItemEnhancementEnhanceResponse>)delegate(LegendItemEnhancementEnhanceResponse response)
		{
			if (response.ErrorCode != 0)
			{
				if (errorProcessor != null)
				{
					errorProcessor(response.ErrorCode);
				}
				else
				{
					ILRequestHelper.ShowErrorCode(response.ErrorCode);
				}
			}
			if (response.Result)
			{
				Dictionary<int, int> value = GameManagers.Instance.AchievementManager.LegendItemEnhanceLevelStats.GetValue();
				for (int i = oldEnhanceLevel + 1; i <= response.EnhancedItem.EnhanceLevel; i++)
				{
					if (value.ContainsKey(i))
					{
						value[i]++;
					}
					else
					{
						value.Add(i, 1);
					}
				}
				GameManagers.Instance.AchievementManager.LegendItemEnhanceLevelStats.SetValue(value);
				SharedMessenger.Broadcast("LEGEND_ITEMS_CHANGED", 32);
				GameManagers.Instance.StockController.ReadStockChangeRecords(response.Costs);
				foodIds = response.DevouredItems;
				for (int num = foods.Count - 1; num >= 0; num--)
				{
					for (int num2 = foodIds.Count - 1; num2 >= 0; num2--)
					{
						if (foodIds[num2] == foods[num].InstanceId)
						{
							foodIds.RemoveAt(num2);
							break;
						}
						if (num2 == foodIds.Count - 1)
						{
							foods.RemoveAt(num);
						}
					}
				}
				EnhanceUpdateLegendItems(target, response.EnhancedItem, foods);
				ThinkingDataHelper.Instance.LegendItemEnhanceTrack();
				GameManagers.Instance.Messenger.Broadcast("LEGEND_ITEM_ENHANCED", target.LegendItemData);
				action();
			}
		});
	}

	private static void EnhanceUpdateLegendItems(LegendItemUi target, Shift.Legion.ClientApi.Protocol.Modules.LegendItem.Models.LegendItem apiModel, List<LegendItemUi> foods)
	{
		int num = Mathf.Min(target.LegendItemData.UnlockedSubEntries, target.LegendItemData.SubEntries.Count);
		LegendItems.Remove(target);
		for (int num2 = foods.Count - 1; num2 >= 0; num2--)
		{
			LegendItems.Remove(foods[num2]);
		}
		Shift.Legion.Common.Models.LegendItem.LegendItem legendItem = new Shift.Legion.Common.Models.LegendItem.LegendItem(GameManagers.Instance, apiModel);
		LegendItemUi legendItemUi = new LegendItemUi(legendItem.InstanceId, legendItem);
		LegendItems.Add(legendItemUi);
		int num3 = Mathf.Min(legendItemUi.LegendItemData.UnlockedSubEntries, legendItemUi.LegendItemData.SubEntries.Count);
		if (num3 > num)
		{
			List<string> arg = new List<string> { LanguagesManager.GetDesc("LegendItemSubEntryUnlockTip") };
			SharedMessenger.Broadcast("SHOW_TIPS", arg, 1, arg3: false);
		}
		UI_LegendItemCultivationPanel.CurLegendItemData = legendItemUi;
	}

	public static void LockLegendItem(LegendItemUi itemUi, Action action)
	{
		bool target = !itemUi.LegendItemData.Locked;
		ILRequestHelper<LegendItemLockResponse>.Request((EventContext)null, (Func<Task<LegendItemLockResponse>>)(() => GameController.Contexts.Service<INetworkService>().LegendItemLock(itemUi.InstanceId, target)), (Action<LegendItemLockResponse>)delegate(LegendItemLockResponse response)
		{
			if (!response.Result)
			{
				ILRequestHelper.ShowErrorCode(response.ErrorCode);
			}
			else
			{
				itemUi.LegendItemData.Locked = response.LockStatus;
				SharedMessenger.Broadcast("LEGEND_ITEM_LOCK_STATE_CHANGED");
				action();
			}
		});
	}

	public static void LegendItemConfirmChangePropetry(LegendItemUi itemUi, int entryType, int entryIndex, bool confirm, Action action, int sortingOrder = 121)
	{
		ILRequestHelper<LegendItemConfirmChangePropertyResponse>.Request((EventContext)null, (Func<Task<LegendItemConfirmChangePropertyResponse>>)(() => GameController.Contexts.Service<INetworkService>().LegendItemConfirmChangeProperty(itemUi.InstanceId, entryType, entryIndex, confirm)), (Action<LegendItemConfirmChangePropertyResponse>)delegate(LegendItemConfirmChangePropertyResponse response)
		{
			if (!response.Result)
			{
				ILRequestHelper.ShowErrorCode(response.ErrorCode);
			}
			else
			{
				ConfirmCurEntryAfterChange(itemUi, entryType, entryIndex, confirm, response.NewScore, response.NewCombatPowerModifier);
				action();
			}
		});
	}

	private static void ConfirmCurEntryAfterChange(LegendItemUi itemUi, int entryType, int entryIndex, bool confirm, int newScore, float newCombat)
	{
		ItemEntry itemEntry = null;
		switch (entryType)
		{
		case 0:
			itemEntry = itemUi.LegendItemData.MainEntries[entryIndex];
			break;
		case 1:
			itemEntry = itemUi.LegendItemData.SubEntries[entryIndex];
			break;
		case 2:
			itemEntry = itemUi.LegendItemData.FxEntries[entryIndex];
			break;
		}
		if (itemEntry != null)
		{
			itemUi.LegendItemData.Score = newScore;
			itemUi.LegendItemData.CombatPowerModifier = newCombat;
			UpdateCurItemEntryBar(itemEntry, confirm);
		}
	}

	public static void LegendItemChandeProperty(LegendItemUi itemUi, int entryType, int entryIndex, Action action, int sortingOrder = 121)
	{
		ILRequestHelper<LegendItemChangePropertyResponse>.Request((EventContext)null, (Func<Task<LegendItemChangePropertyResponse>>)(() => GameController.Contexts.Service<INetworkService>().LegendItemChangeProperty(itemUi.InstanceId, entryType, entryIndex)), (Action<LegendItemChangePropertyResponse>)delegate(LegendItemChangePropertyResponse response)
		{
			if (!response.Result)
			{
				ILRequestHelper.ShowErrorCode(response.Code);
			}
			else
			{
				GameManagers.Instance.StockController.ReadStockChangeRecords(response.Costs);
				UpdateChangeProperty();
				UpdateLegendItemProperty(itemUi, entryType, entryIndex, response.ItemEntryNeedConfirm);
				ThinkingDataHelper.Instance.LegendItemChangePropertyTrack();
				GameManagers.Instance.Messenger.Broadcast("LEGEND_ITEM_CHANGED_PROPS", itemUi.LegendItemData);
				action();
			}
		});
	}

	private static void UpdateCurItemEntryBar(ItemEntry curItemEntry, bool confirm)
	{
		if (confirm && curItemEntry.TmpItemEntry != null)
		{
			curItemEntry.EntryId = curItemEntry.TmpItemEntry.EntryId;
			curItemEntry.Attributes = curItemEntry.TmpItemEntry.Attributes;
		}
		curItemEntry.TmpItemEntry = null;
		curItemEntry.Status = 0;
	}

	private static void UpdateLegendItemProperty(LegendItemUi itemUi, int entryType, int entryIndex, ItemEntry entryNeedConfirm)
	{
		switch (entryType)
		{
		case 0:
			itemUi.LegendItemData.MainEntries[entryIndex] = entryNeedConfirm;
			break;
		case 1:
			itemUi.LegendItemData.SubEntries[entryIndex] = entryNeedConfirm;
			break;
		case 2:
			itemUi.LegendItemData.FxEntries[entryIndex] = entryNeedConfirm;
			break;
		case -1:
			break;
		}
	}

	public static int GetReforgeLockCostCount(LegendItemUi itemUi)
	{
		int result = 1;
		if (itemUi.ReforgeIndex == null)
		{
			return result;
		}
		switch (itemUi.ReforgeIndex.Count)
		{
		case 1:
			result = 1;
			break;
		case 2:
			result = 3;
			break;
		case 3:
			result = 6;
			break;
		}
		return result;
	}

	public static void LegendItemConfirmReforge(LegendItemUi itemUi, bool confirm, Action action, int sortingOrder = 121)
	{
		ILRequestHelper<LegendItemConfirmReforgeResponse>.Request((EventContext)null, (Func<Task<LegendItemConfirmReforgeResponse>>)(() => GameController.Contexts.Service<INetworkService>().LegendItemConfirmReforge(itemUi.InstanceId, confirm)), (Action<LegendItemConfirmReforgeResponse>)delegate(LegendItemConfirmReforgeResponse response)
		{
			if (!response.Result)
			{
				ILRequestHelper.ShowErrorCode(response.ErrorCode);
			}
			else
			{
				LegendItemConfirmReforgePropetry(itemUi, confirm, response.NewScore, response.NewCombatPowerModifier);
				action();
			}
		});
	}

	private static void LegendItemConfirmReforgePropetry(LegendItemUi itemUi, bool confirm, int newScore, float newCombat)
	{
		if (itemUi.LegendItemData.SubEntries != null)
		{
			for (int i = 0; i < itemUi.LegendItemData.SubEntries.Count; i++)
			{
				ItemEntry curItemEntry = itemUi.LegendItemData.SubEntries[i];
				UpdateCurItemEntryBar(curItemEntry, confirm);
			}
			itemUi.LegendItemData.Score = newScore;
			itemUi.LegendItemData.CombatPowerModifier = newCombat;
		}
	}

	public static void LegendItemReforge(LegendItemUi itemUi, Action action)
	{
		ILRequestHelper<LegendItemReforgeResponse>.Request((EventContext)null, (Func<Task<LegendItemReforgeResponse>>)(() => GameController.Contexts.Service<INetworkService>().LegendItemReforge(itemUi.InstanceId, itemUi.ReforgeIndex)), (Action<LegendItemReforgeResponse>)delegate(LegendItemReforgeResponse response)
		{
			if (!response.Result)
			{
				ILRequestHelper.ShowErrorCode(response.Code);
			}
			else
			{
				GameManagers.Instance.StockController.ReadStockChangeRecords(response.Costs);
				UpdateReforgeCount();
				UpdateLegendItemReforge(itemUi, response.ReforgedItem);
				ThinkingDataHelper.Instance.LegendItemReforgeTrack(itemUi);
				GameManagers.Instance.Messenger.Broadcast("LEGEND_ITEM_REFORGED", itemUi.LegendItemData);
				action();
			}
		});
	}

	private static void UpdateLegendItemReforge(LegendItemUi target, Shift.Legion.ClientApi.Protocol.Modules.LegendItem.Models.LegendItem apiModel)
	{
		Shift.Legion.Common.Models.LegendItem.LegendItem legendItemData = new Shift.Legion.Common.Models.LegendItem.LegendItem(GameManagers.Instance, apiModel);
		target.LegendItemData = legendItemData;
		UI_LegendItemCultivationPanel.CurLegendItemData = target;
	}

	public static void ClearLegendItems()
	{
		LegendItems?.Clear();
		SoldierItemSlotStates?.Clear();
		SoldiersEquippedItems?.Clear();
		EquippedLegendItems?.Clear();
	}

	public static void GetLegendItems(List<string> itemDatas)
	{
		LegendItems = new List<LegendItemUi>();
		if (itemDatas != null)
		{
			for (int i = 0; i < itemDatas.Count; i++)
			{
				string json = itemDatas[i];
				Shift.Legion.ClientApi.Protocol.Modules.LegendItem.Models.LegendItem apiModel = JsonHelper.ToObject<Shift.Legion.ClientApi.Protocol.Modules.LegendItem.Models.LegendItem>(json);
				Shift.Legion.Common.Models.LegendItem.LegendItem legendItem = new Shift.Legion.Common.Models.LegendItem.LegendItem(GameManagers.Instance, apiModel);
				LegendItemUi item = new LegendItemUi(legendItem.InstanceId, legendItem);
				LegendItems.Add(item);
			}
		}
	}

	public static int GetFakeLegendItemLevel(LegendItemUi iem, int extraExp, out bool canLevelUp)
	{
		int num = iem.LegendItemData.TotalGainedExp + extraExp;
		string key = ((iem.LegendItemData.EnhancementConfig != null) ? iem.LegendItemData.EnhancementConfig.ConfigId : GetInitEnhanceLevelConfigId(iem.LegendItemData.Data.Rarity));
		Dictionary<int, LegendItemEnhancementConfig> dictionary = LegendItemManager.LegendItemEnhancementConfigs[key];
		LegendItemEnhancementConfig maxLeveLegendItemEnhancementConfig;
		int legendItemMaxLevelEnhancementConfigs = GetLegendItemMaxLevelEnhancementConfigs(iem, out maxLeveLegendItemEnhancementConfig);
		int totalExpNeed = maxLeveLegendItemEnhancementConfig.TotalExpNeed;
		if (num > totalExpNeed)
		{
			canLevelUp = false;
			return legendItemMaxLevelEnhancementConfigs;
		}
		int num2 = 0;
		foreach (KeyValuePair<int, LegendItemEnhancementConfig> item in dictionary)
		{
			if (item.Value.TotalExpNeed < num)
			{
				continue;
			}
			num2 = ((item.Value.TotalExpNeed != num) ? (item.Key - 1) : item.Key);
			break;
		}
		canLevelUp = true;
		return (num2 >= 0) ? num2 : 0;
	}

	public static string GetLegendItemNameTitle(string dataName, int enhanceLevel, string numColor = "#FFF2D3")
	{
		if (enhanceLevel <= 0)
		{
			return dataName;
		}
		return $"{dataName}[color={numColor}]+{enhanceLevel}[/color]";
	}

	public static void UpdateLegendItems(LegendItemUi iem)
	{
		LegendItems.Add(iem);
		SharedMessenger.messengerInstance.Broadcast("ON_LEGENDITEM_UPDATE", LegendItemManager.GetLegendItemSetInstanceCount());
	}

	public static LegendItemUi GetLegendItemUi(long instanceId)
	{
		if (LegendItems == null)
		{
			return null;
		}
		LegendItemUi result = null;
		foreach (LegendItemUi legendItem in LegendItems)
		{
			if (legendItem.InstanceId == instanceId)
			{
				result = legendItem;
				break;
			}
		}
		return result;
	}

	public static List<LegendItemUi> GetLegendItemsByRarity()
	{
		if (LegendItems != null)
		{
			LegendItems.Sort(SortLegendItemDataMaxToMin);
			return LegendItems;
		}
		return LegendItems;
	}

	public static List<LegendItemUi> FilterLegendItemsByRarity(int rarity)
	{
		LegendItems.Sort(SortGDELegendItemData);
		List<LegendItemUi> list = new List<LegendItemUi>();
		list.AddRange(LegendItems.Where((LegendItemUi item) => item.LegendItemData.Data.Rarity == rarity));
		return list;
	}

	public static List<LegendItemUi> FilterLegendItemsForEnhance()
	{
		if (LegendItems != null)
		{
			LegendItems.Sort(SortGDELegendItemData);
			return LegendItems;
		}
		return LegendItems;
	}

	private static int SortGDELegendItemData(LegendItemUi a, LegendItemUi b)
	{
		if (a.LegendItemData.Data.Rarity > b.LegendItemData.Data.Rarity)
		{
			return 1;
		}
		if (a.LegendItemData.Data.Rarity < b.LegendItemData.Data.Rarity)
		{
			return -1;
		}
		if (a.LegendItemData.EnhanceLevel > b.LegendItemData.EnhanceLevel)
		{
			return 1;
		}
		if (a.LegendItemData.EnhanceLevel < b.LegendItemData.EnhanceLevel)
		{
			return -1;
		}
		int num = CutLegendItemDataItemId(a.LegendItemData.ItemId);
		int num2 = CutLegendItemDataItemId(b.LegendItemData.ItemId);
		if (num > num2)
		{
			return 1;
		}
		if (num < num2)
		{
			return -1;
		}
		if (a.LegendItemData.Score > b.LegendItemData.Score)
		{
			return 1;
		}
		if (a.LegendItemData.Score < b.LegendItemData.Score)
		{
			return -1;
		}
		return 0;
	}

	public static int SortLegendItemDataMaxToMin(LegendItemUi a, LegendItemUi b)
	{
		if (a.LegendItemData.Data.Rarity > b.LegendItemData.Data.Rarity)
		{
			return -1;
		}
		if (a.LegendItemData.Data.Rarity < b.LegendItemData.Data.Rarity)
		{
			return 1;
		}
		if (a.LegendItemData.EnhanceLevel > b.LegendItemData.EnhanceLevel)
		{
			return -1;
		}
		if (a.LegendItemData.EnhanceLevel < b.LegendItemData.EnhanceLevel)
		{
			return 1;
		}
		int num = CutLegendItemDataItemId(a.LegendItemData.ItemId);
		int num2 = CutLegendItemDataItemId(b.LegendItemData.ItemId);
		if (num > num2)
		{
			return -1;
		}
		if (num < num2)
		{
			return 1;
		}
		if (a.LegendItemData.Score > b.LegendItemData.Score)
		{
			return -1;
		}
		if (a.LegendItemData.Score < b.LegendItemData.Score)
		{
			return 1;
		}
		return 0;
	}

	public static int SortLegendItem(LegendItemUiSortOptions options)
	{
		LegendItemUi a = options.A;
		LegendItemUi b = options.B;
		if (a.LegendItemData.Data.Rarity > b.LegendItemData.Data.Rarity)
		{
			return -1;
		}
		if (a.LegendItemData.Data.Rarity < b.LegendItemData.Data.Rarity)
		{
			return 1;
		}
		int enhanceLevelOption = (int)options.EnhanceLevelOption;
		if (a.LegendItemData.EnhanceLevel > b.LegendItemData.EnhanceLevel)
		{
			return -enhanceLevelOption;
		}
		if (a.LegendItemData.EnhanceLevel < b.LegendItemData.EnhanceLevel)
		{
			return enhanceLevelOption;
		}
		int num = CutLegendItemDataItemId(a.LegendItemData.ItemId);
		int num2 = CutLegendItemDataItemId(b.LegendItemData.ItemId);
		if (num > num2)
		{
			return -1;
		}
		if (num < num2)
		{
			return 1;
		}
		if (a.LegendItemData.Score > b.LegendItemData.Score)
		{
			return -1;
		}
		return (a.LegendItemData.Score < b.LegendItemData.Score) ? 1 : 0;
	}

	public static int CutLegendItemDataItemId(string _itemId)
	{
		if (string.IsNullOrWhiteSpace(_itemId))
		{
			return 0;
		}
		_itemId = _itemId.Substring(3).TrimStart('0');
		return int.Parse(_itemId);
	}

	public static string GetSuitDataDesc(Shift.Legion.Common.Models.LegendItem.LegendItem itemUi)
	{
		string setId = itemUi.Data.SetId;
		return string.IsNullOrWhiteSpace(setId) ? setId : LanguagesManager.GetSetDesc(setId);
	}

	public static string GetSuitDataDesc(BlackMarketLegendItem itemData)
	{
		string setId = itemData.SetId;
		return string.IsNullOrWhiteSpace(setId) ? setId : LanguagesManager.GetSetDesc(setId);
	}

	public static string GetSuitDataDesc(string suitId)
	{
		return string.IsNullOrWhiteSpace(suitId) ? suitId : LanguagesManager.GetSetDesc(suitId);
	}

	public static void UpdateGetLegendItemsNum(List<ModelsBonus> legendItems)
	{
		Dictionary<string, int> value = GameManagers.Instance.AchievementManager.IdentifiedLegendItems.GetValue();
		for (int i = 0; i < legendItems.Count; i++)
		{
			ModelsBonus modelsBonus = legendItems[i];
			if (value.ContainsKey(modelsBonus.ItemId))
			{
				value[modelsBonus.ItemId]++;
			}
			else
			{
				value.Add(modelsBonus.ItemId, 1);
			}
		}
		GameManagers.Instance.AchievementManager.IdentifiedLegendItems.SetValue(value);
		SharedMessenger.Broadcast("LEGEND_ITEMS_CHANGED", 29);
	}

	public static void UpdateGetLegendItemsRarityRecords(List<LegendItemUi> disPlayItemUis)
	{
		Dictionary<int, int> value = GameManagers.Instance.AchievementManager.IdentifiedLegendItemsRarityStat.GetValue();
		foreach (LegendItemUi disPlayItemUi in disPlayItemUis)
		{
			int rarity = disPlayItemUi.LegendItemData.Data.Rarity;
			if (value.ContainsKey(rarity))
			{
				value[rarity]++;
			}
			else
			{
				value.Add(rarity, 1);
			}
		}
		GameManagers.Instance.AchievementManager.IdentifiedLegendItemsRarityStat.SetValue(value);
		SharedMessenger.Broadcast("LEGEND_ITEMS_CHANGED", 51);
	}

	public static void UpdateGetLegendItemsNum(List<string> legendItemId)
	{
		Dictionary<string, int> value = GameManagers.Instance.AchievementManager.IdentifiedLegendItems.GetValue();
		for (int i = 0; i < legendItemId.Count; i++)
		{
			string key = legendItemId[i];
			if (value.ContainsKey(key))
			{
				value[key]++;
			}
			else
			{
				value.Add(key, 1);
			}
		}
		GameManagers.Instance.AchievementManager.IdentifiedLegendItems.SetValue(value);
		SharedMessenger.Broadcast("LEGEND_ITEMS_CHANGED", 29);
	}

	public static void UpdateGetLegendItemStars(List<LegendItemUi> disPlayItemUis)
	{
		Dictionary<int, int> value = GameManagers.Instance.AchievementManager.LegendItemRarityStats.GetValue();
		for (int i = 0; i < disPlayItemUis.Count; i++)
		{
			int rarity = disPlayItemUis[i].LegendItemData.Data.Rarity;
			if (value.ContainsKey(rarity))
			{
				value[rarity]++;
			}
			else
			{
				value.Add(rarity, 1);
			}
		}
		GameManagers.Instance.AchievementManager.LegendItemRarityStats.SetValue(value);
		SharedMessenger.Broadcast("LEGEND_ITEMS_CHANGED", 30);
	}

	private static void UpdateReforgeCount()
	{
		int value = GameManagers.Instance.AchievementManager.LegendItemReforgeStats.GetValue();
		value++;
		GameManagers.Instance.AchievementManager.LegendItemReforgeStats.SetValue(value);
		SharedMessenger.Broadcast("LEGEND_ITEMS_CHANGED", 34);
	}

	private static void UpdateChangeProperty()
	{
		int value = GameManagers.Instance.AchievementManager.LegendItemChangePropertyStats.GetValue();
		value++;
		GameManagers.Instance.AchievementManager.LegendItemChangePropertyStats.SetValue(value);
		SharedMessenger.Broadcast("LEGEND_ITEMS_CHANGED", 33);
	}

	public static void BlackMarketLegendItemInStorage(string _materialItemId, int qty, bool showSfx = false, bool isShowDetail = false)
	{
		if (qty <= 0)
		{
			return;
		}
		ILRequestHelper<UseItemResponse>.Request((EventContext)null, (Func<Task<UseItemResponse>>)(() => GameController.Contexts.Service<INetworkService>().UseItem(-1L, _materialItemId, qty, null)), (Action<UseItemResponse>)delegate(UseItemResponse response)
		{
			if (!response.Result)
			{
				ILRequestHelper.ShowErrorCode(response.ErrorCode);
			}
			else
			{
				GameManagers.Instance.StockController.GetStockConfig(_materialItemId).GetValue().Stock -= qty;
				if (response.LegendItems != null)
				{
					List<LegendItemUi> list = new List<LegendItemUi>();
					List<string> list2 = new List<string>();
					for (int i = 0; i < response.LegendItems.Count; i++)
					{
						ModelsBonus modelsBonus = response.LegendItems[i];
						Bonus bonus = Bonus.Get(modelsBonus.ItemId, modelsBonus.Qty, modelsBonus.Type, modelsBonus.IsShining, modelsBonus.ExtraData);
						Dictionary<string, float> dict = bonus.Claim(GameManagers.Instance);
						long key = long.Parse(dict.First().Key);
						Shift.Legion.Common.Models.LegendItem.LegendItem legendItem = GameManagers.Instance.InventoryManager.LegendItems[key];
						LegendItemUi legendItemUi = new LegendItemUi(legendItem.InstanceId, legendItem);
						UpdateLegendItems(legendItemUi);
						list.Add(legendItemUi);
						list2.Add(legendItemUi.LegendItemData.ItemId);
					}
					if (isShowDetail)
					{
						Dictionary<string, object> parameters = new Dictionary<string, object>
						{
							{ "LegendItems", list },
							{ "ItemId", _materialItemId }
						};
						GameController.Contexts.Service<IUiService>().OpenPanel(UI_LegendItemBoxPanel.Name, parameters);
						SharedMessenger.Broadcast("FORCE_UPDATE_WAREHOUSE_PANEL");
						ThinkingDataHelper.Instance.OpenLegendItemBox(_materialItemId, qty, list2);
					}
					UpdateGetLegendItemStars(list);
					if (showSfx)
					{
						int type = 0;
						if (_materialItemId == "I73000")
						{
							type = 1;
						}
						UnityUiService.Instance.ShowGetLegendItemFullSfx("ui_fullscreen_treasure_identify", 1.5f, type);
					}
				}
			}
		});
	}

	public static void JudgeShowReforgeTip(LegendItemUi itemUi, bool confirm, Action action)
	{
		Action action2 = delegate
		{
			LegendItemConfirmReforge(itemUi, confirm: true, action);
		};
		bool flag = false;
		int num = 0;
		for (int num2 = 0; num2 < itemUi.LegendItemData.SubEntries.Count; num2++)
		{
			if ((itemUi.ReforgeIndex == null || !itemUi.ReforgeIndex.Contains(num2)) && GetSubPropertyUnlocked(itemUi, num2))
			{
				num = LanguagesManager.GetChangeEntryValueTipType(itemUi.LegendItemData.SubEntries[num2].EntryId, itemUi.LegendItemData.SubEntries[num2].Attributes);
				if (num >= 1)
				{
					flag = true;
					break;
				}
			}
		}
		if (flag)
		{
			string desc = LanguagesManager.GetDesc(string.Format("{0}{1}", "LegendItemSubEntrymReforgeTip", num));
			ShowChangeTip(desc, action2);
		}
		else
		{
			action2();
		}
	}

	public static void JudgeShowChangeTip(LegendItemUi itemUi, int entryType, int entryIndex, Action action)
	{
		ItemEntry itemEntry = ((entryType != 2) ? itemUi.LegendItemData.SubEntries[entryIndex] : itemUi.LegendItemData.FxEntries[entryIndex]);
		Action action2 = delegate
		{
			LegendItemChandeProperty(itemUi, entryType, entryIndex, action);
		};
		ItemEntry tmpItemEntry = itemEntry.TmpItemEntry;
		if (tmpItemEntry == null)
		{
			action2();
			return;
		}
		List<ItemEntryData> attributes = itemEntry.Attributes;
		List<ItemEntryData> attributes2 = tmpItemEntry.Attributes;
		List<PendingAttrTipType> tipTypes;
		PendingAttrTipType pendingAttrTipType = CheckPendingAttrTipTypes(itemEntry.EntryId, attributes2, out tipTypes);
		switch (pendingAttrTipType)
		{
		case PendingAttrTipType.HighValue:
		case PendingAttrTipType.AllMax:
		{
			if (!IsAnyAttributeBetter(itemEntry.EntryId, attributes, attributes2))
			{
				action2();
				break;
			}
			bool isFxEntry = entryType == 2;
			string empty = string.Empty;
			switch (itemEntry.Attributes.Count)
			{
			case 1:
			{
				string text5 = (Modifier.NeedPercentConvertProcess(attributes2[0].Key) ? "%" : "");
				string arg = "[color=#92D050]" + attributes2[0].GetValueString(tmpItemEntry.EntryId, isFxEntry) + text5 + "[/color]";
				empty = string.Format(LanguagesManager.GetDesc("CsharpCodeZhTcText951"), arg);
				break;
			}
			case 2:
			{
				string text = (Modifier.NeedPercentConvertProcess(attributes2[0].Key) ? "%" : "");
				string text2 = (Modifier.NeedPercentConvertProcess(attributes2[1].Key) ? "%" : "");
				string text3 = attributes2[0].GetValueString(tmpItemEntry.EntryId, isFxEntry) + text;
				string text4 = attributes2[1].GetValueString(tmpItemEntry.EntryId, isFxEntry) + text2;
				if (tipTypes[0] != PendingAttrTipType.None)
				{
					text3 = "[color=#92D050]" + text3 + "[/color]";
				}
				if (tipTypes[1] != PendingAttrTipType.None)
				{
					text4 = "[color=#92D050]" + text4 + "[/color]";
				}
				empty = string.Format(LanguagesManager.GetDesc("CsharpCodeZhTcText953"), text3, text4);
				break;
			}
			default:
				empty = LanguagesManager.GetDesc("CsharpCodeZhTcText70") + LanguagesManager.GetDesc(string.Format("{0}{1}", "LegendItemSubEntrymChangeTip", pendingAttrTipType));
				break;
			}
			ShowChangeTip(empty, action2);
			break;
		}
		case PendingAttrTipType.None:
			action2();
			break;
		default:
			action2();
			break;
		}
	}

	private static PendingAttrTipType CheckPendingAttrTipTypes(string entryId, List<ItemEntryData> checkingAttrs, out List<PendingAttrTipType> tipTypes)
	{
		tipTypes = new List<PendingAttrTipType>();
		bool flag = true;
		bool flag2 = false;
		foreach (ItemEntryData checkingAttr in checkingAttrs)
		{
			PendingAttrTipType changeEntryValueTipType = (PendingAttrTipType)LanguagesManager.GetChangeEntryValueTipType(entryId, new List<ItemEntryData> { checkingAttr });
			if (changeEntryValueTipType != PendingAttrTipType.None)
			{
				flag2 = true;
			}
			if (changeEntryValueTipType != PendingAttrTipType.AllMax)
			{
				flag = false;
			}
			tipTypes.Add(changeEntryValueTipType);
		}
		PendingAttrTipType result = PendingAttrTipType.None;
		if (flag)
		{
			result = PendingAttrTipType.AllMax;
		}
		else if (flag2)
		{
			result = PendingAttrTipType.HighValue;
		}
		return result;
	}

	public static void JudgeShowChangeTipForConfirmChange(LegendItemUi itemUi, int entryType, int entryIndex, bool confirm, Action action)
	{
		ItemEntry itemEntry = ((entryType != 2) ? itemUi.LegendItemData.SubEntries[entryIndex] : itemUi.LegendItemData.FxEntries[entryIndex]);
		Action action2 = delegate
		{
			LegendItemConfirmChangePropetry(itemUi, entryType, entryIndex, confirm, action);
		};
		ItemEntry tmpItemEntry = itemEntry.TmpItemEntry;
		if (tmpItemEntry == null)
		{
			action2();
			return;
		}
		List<ItemEntryData> attributes = tmpItemEntry.Attributes;
		List<ItemEntryData> attributes2 = itemEntry.Attributes;
		List<PendingAttrTipType> tipTypes;
		PendingAttrTipType pendingAttrTipType = CheckPendingAttrTipTypes(itemEntry.EntryId, attributes2, out tipTypes);
		CheckPendingAttrTipTypes(itemEntry.EntryId, attributes, out var tipTypes2);
		switch (pendingAttrTipType)
		{
		case PendingAttrTipType.HighValue:
		case PendingAttrTipType.AllMax:
		{
			bool isFxEntry = entryType == 2;
			string empty = string.Empty;
			switch (attributes2.Count)
			{
			case 1:
			{
				string text7 = (Modifier.NeedPercentConvertProcess(attributes2[0].Key) ? "%" : "");
				string text8 = attributes2[0].GetValueString(itemEntry.EntryId, isFxEntry) + text7;
				string text9 = attributes[0].GetValueString(tmpItemEntry.EntryId, isFxEntry) + text7;
				if (tipTypes[0] != PendingAttrTipType.None)
				{
					text8 = "[color=#92D050]" + text8 + "[/color]";
				}
				if (tipTypes2[0] != PendingAttrTipType.None)
				{
					text9 = "[color=#92D050]" + text9 + "[/color]";
				}
				empty = string.Format(LanguagesManager.GetDesc("CsharpCodeZhTcText952"), text8, text9);
				break;
			}
			case 2:
			{
				string text = (Modifier.NeedPercentConvertProcess(attributes2[0].Key) ? "%" : "");
				string text2 = (Modifier.NeedPercentConvertProcess(attributes2[1].Key) ? "%" : "");
				string text3 = attributes2[0].GetValueString(itemEntry.EntryId, isFxEntry) + text;
				string text4 = attributes[0].GetValueString(tmpItemEntry.EntryId, isFxEntry) + text;
				string text5 = attributes2[1].GetValueString(itemEntry.EntryId, isFxEntry) + text2;
				string text6 = attributes[1].GetValueString(tmpItemEntry.EntryId, isFxEntry) + text2;
				if (tipTypes[0] != PendingAttrTipType.None)
				{
					text3 = "[color=#92D050]" + text3 + "[/color]";
				}
				if (tipTypes[1] != PendingAttrTipType.None)
				{
					text5 = "[color=#92D050]" + text5 + "[/color]";
				}
				if (tipTypes2[0] != PendingAttrTipType.None)
				{
					text4 = "[color=#92D050]" + text4 + "[/color]";
				}
				if (tipTypes2[1] != PendingAttrTipType.None)
				{
					text6 = "[color=#92D050]" + text6 + "[/color]";
				}
				empty = string.Format(LanguagesManager.GetDesc("CsharpCodeZhTcText954"), text3, text4, text5, text6);
				break;
			}
			default:
				empty = LanguagesManager.GetDesc("CsharpCodeZhTcText71") + LanguagesManager.GetDesc(string.Format("{0}{1}", "LegendItemSubEntrymChangeTip", pendingAttrTipType));
				break;
			}
			ShowChangeTip(empty, action2);
			break;
		}
		case PendingAttrTipType.None:
			action2();
			break;
		default:
			action2();
			break;
		}
	}

	private static bool IsAnyAttributeBetter(string propertyId, List<ItemEntryData> origin, List<ItemEntryData> pending)
	{
		if (origin.Count != pending.Count)
		{
			return false;
		}
		for (int i = 0; i < origin.Count; i++)
		{
			if (pending[i].Value != origin[i].Value)
			{
				bool flag = LanguagesManager.IsEntryValueBiggerBetter(propertyId, origin[i]);
				bool flag2 = pending[i].Value > origin[i].Value;
				if (flag2 == flag)
				{
					return true;
				}
			}
		}
		return false;
	}

	private static void ShowChangeTip(string tipText, Action action)
	{
		GameController.Contexts.Service<IUiService>().OpenPanel(UI_UniversalConfirmPopup.Name, new Dictionary<string, object>
		{
			{
				"Content",
				tipText ?? ""
			},
			{
				"Buttons",
				new Dictionary<string, Action>
				{
					{ "Confirm", action },
					{
						"Cancel",
						delegate
						{
						}
					}
				}
			},
			{ "PageIndex", 0 },
			{ "ClickSound", "Confirm" },
			{ "Order", 1 }
		});
	}

	public static int GetLegendItemMaxLevelEnhancementConfigs(LegendItemUi itemUi, out LegendItemEnhancementConfig maxLeveLegendItemEnhancementConfig)
	{
		string key = ((itemUi.LegendItemData.EnhancementConfig != null) ? itemUi.LegendItemData.EnhancementConfig.ConfigId : GetInitEnhanceLevelConfigId(itemUi.LegendItemData.Data.Rarity));
		Dictionary<int, LegendItemEnhancementConfig> dictionary = LegendItemManager.LegendItemEnhancementConfigs[key];
		int num = dictionary.Count - 1;
		int num2 = -1;
		maxLeveLegendItemEnhancementConfig = null;
		foreach (KeyValuePair<int, LegendItemEnhancementConfig> item in dictionary)
		{
			if (num2 == -1 || maxLeveLegendItemEnhancementConfig == null)
			{
				num2 = item.Key;
				maxLeveLegendItemEnhancementConfig = item.Value;
			}
			else if (item.Key > num2)
			{
				num2 = item.Key;
				maxLeveLegendItemEnhancementConfig = item.Value;
			}
		}
		return num2;
	}

	public static async Task GetLegendItemsDrawCount()
	{
		GetDrawCardCntResponse response = await GameController.Contexts.Service<INetworkService>().GetDrawCardCnt("LegendItemDrawTest", "十连抽");
		IsFirstLegendItemsDraw = response.Result && response.DrawCnt < 1;
	}

	public static void OpenLegendItemBlueprintListPanel(Action action)
	{
		if (!Level6_UI_Open)
		{
			action?.Invoke();
			return;
		}
		if (blueprintDataInit)
		{
			action?.Invoke();
			return;
		}
		ILRequestHelper<LegendItemBlueprintGetResponse>.Request((EventContext)null, (Func<Task<LegendItemBlueprintGetResponse>>)(() => GameController.Contexts.Service<INetworkService>().LegendItemBlueprintGet()), (Action<LegendItemBlueprintGetResponse>)delegate(LegendItemBlueprintGetResponse response)
		{
			if (!Level6_UI_Open)
			{
				blueprintDataInit = true;
			}
			if (response.Blueprints != null)
			{
				DisplayLegendItemBlueprintUi = response.DisplayBlueprintsUi;
				GameManagers.Instance.UserArchiveManager.AddLegendItemBlueprints(response.Blueprints);
				action?.Invoke();
			}
		});
	}

	public static void OpenBlueprintsBoxResult(List<string> blueprintsId, string itemId)
	{
		if (!Level6_UI_Open || blueprintsId == null || blueprintsId.Count <= 0)
		{
			return;
		}
		ILRequestHelper<LegendItemBlueprintGetResponse>.Request((EventContext)null, (Func<Task<LegendItemBlueprintGetResponse>>)(() => GameController.Contexts.Service<INetworkService>().LegendItemBlueprintGet()), (Action<LegendItemBlueprintGetResponse>)delegate(LegendItemBlueprintGetResponse response)
		{
			if (!Level6_UI_Open)
			{
				blueprintDataInit = true;
			}
			if (response.Blueprints != null)
			{
				DisplayLegendItemBlueprintUi = response.DisplayBlueprintsUi;
				GameManagers.Instance.UserArchiveManager.AddLegendItemBlueprints(response.Blueprints);
				GameManagers.Instance.UserArchiveManager.AddOwnedBluePrintsRecord(blueprintsId);
				GameManagers.Instance.UserArchiveManager.RecordIdentifiedBluePrints(blueprintsId.Count, itemId);
				List<Blueprint> legendItemBlueprints = GameManagers.Instance.UserArchiveManager.GetLegendItemBlueprints(blueprintsId);
				Dictionary<string, object> parameters = new Dictionary<string, object>
				{
					{ "Blueprints", legendItemBlueprints },
					{ "ItemId", itemId }
				};
				GameController.Contexts.Service<IUiService>().OpenPanel(UI_LegendItemBoxPanel.Name, parameters);
			}
		});
	}

	public static string GetBlueprintNamePrefix()
	{
		if (string.IsNullOrEmpty(Blueprint_Name_Prefix))
		{
			Blueprint_Name_Prefix = LanguagesManager.GetDesc("Blueprint_Name_Prefix");
		}
		return Blueprint_Name_Prefix;
	}

	public static void RenderLegendItem(GButton item, GDELegendItemData legendItem)
	{
		((GComponent)item).GetController("TypeController").selectedIndex = 0;
		if (legendItem != null)
		{
			((GComponent)item).GetChild("name").text = string.Empty;
			((GComponent)item).GetChild("Level").text = string.Empty;
			((GComponent)item).GetChild("FrameIcon").asLoader.url = $"ui://PublicResources/frame_treasure_square_{legendItem.Rarity}";
			((GComponent)item).GetChild("LvFrame").asLoader.url = string.Empty;
			((GComponent)item).GetChild("Icon").asLoader.LoadArmsIcon(legendItem.Icon);
			Controller controller = ((GComponent)item).GetController("ClassController");
			if (controller != null)
			{
				controller.selectedIndex = legendItem.Rarity - 1;
			}
		}
	}

	public static void RenderAnyLegendItem(GButton item, int rarity)
	{
		((GComponent)item).GetController("TypeController").selectedIndex = 0;
		((GComponent)item).GetChild("name").text = string.Empty;
		((GComponent)item).GetChild("Level").text = string.Empty;
		((GComponent)item).GetChild("FrameIcon").asLoader.url = $"ui://PublicResources/frame_treasure_square_{rarity}";
		((GComponent)item).GetChild("LvFrame").asLoader.url = string.Empty;
		((GComponent)item).GetChild("Icon").asLoader.url = string.Empty;
		Controller controller = ((GComponent)item).GetController("ClassController");
		if (controller != null)
		{
			controller.selectedIndex = rarity - 1;
		}
	}

	public static string GetLegendItemMainPropetryKeyText(Shift.Legion.Common.Models.LegendItem.LegendItem target)
	{
		if (target.MainEntries == null || target.MainEntries.Count <= 0)
		{
			return "";
		}
		string maxLogoText;
		return GetReforgeEntry(target.MainEntries.First(), out maxLogoText).Values.First();
	}

	public static string GetLegendItemNextEnhanceLevelValue(Shift.Legion.Common.Models.LegendItem.LegendItem target, int levelAdd = 0, int rarityAdd = 0)
	{
		string text = "";
		if (levelAdd == 0 && target.EnhancementConfig == null)
		{
			for (int i = 0; i < target.MainEntries.Count; i++)
			{
				ItemEntry itemEntry = target.MainEntries[i];
				for (int j = 0; j < itemEntry.Attributes.Count; j++)
				{
					ItemEntryData itemEntryData = itemEntry.Attributes[j];
					float num = itemEntryData.GetValue();
					if (levelAdd != 0)
					{
						num = ((!itemEntryData.IsPercent) ? (num + 10f) : (num + 0.05f));
					}
					bool flag = itemEntryData.IsPercent || Modifier.NeedPercentConvertProcess(itemEntryData.Key);
					string entryValuePrecision = LanguagesManager.GetEntryValuePrecision(itemEntry.EntryId);
					if (flag)
					{
						num *= 100f;
					}
					string text2;
					if (string.IsNullOrEmpty(entryValuePrecision))
					{
						text2 = Convert.ToInt32(num).ToString();
					}
					else
					{
						text2 = num.ToString(entryValuePrecision);
						if (text2.EndsWith("."))
						{
							text2 += "0";
						}
					}
					text = "+" + text2;
					if (flag)
					{
						text += "%";
					}
				}
			}
			return text;
		}
		int raity = ((target.Data.Rarity + rarityAdd > 6) ? 6 : (target.Data.Rarity + rarityAdd));
		string configId = ((target.EnhancementConfig != null) ? target.EnhancementConfig.ConfigId : GetInitEnhanceLevelConfigId(raity));
		int enhanceLevel = target.EnhanceLevel + levelAdd;
		LegendItemEnhancementConfig enhanceConfig = LegendItemEnhancementConfig.GetEnhanceConfig(configId, enhanceLevel);
		for (int k = 0; k < target.MainEntries.Count; k++)
		{
			ItemEntry itemEntry2 = target.MainEntries[k];
			for (int l = 0; l < itemEntry2.Attributes.Count; l++)
			{
				ItemEntryData itemEntryData2 = itemEntry2.Attributes[l];
				float value = itemEntryData2.GetValue();
				string text3 = itemEntryData2.Key;
				if (itemEntryData2.IsPercent)
				{
					text3 += "_PCT";
				}
				if (!enhanceConfig.EnhancedAttrs.ContainsKey(text3))
				{
					continue;
				}
				float value2 = enhanceConfig.EnhancedAttrs[text3].GetValue();
				float num2 = value + value2;
				string entryValuePrecision2 = LanguagesManager.GetEntryValuePrecision(itemEntry2.EntryId);
				bool flag2 = itemEntryData2.IsPercent || Modifier.NeedPercentConvertProcess(itemEntryData2.Key);
				if (flag2)
				{
					num2 *= 100f;
				}
				string text4;
				if (string.IsNullOrEmpty(entryValuePrecision2))
				{
					text4 = Convert.ToInt32(num2).ToString();
				}
				else
				{
					text4 = num2.ToString(entryValuePrecision2);
					if (text4.EndsWith("."))
					{
						text4 += "0";
					}
				}
				text = "+" + text4;
				if (flag2)
				{
					text += "%";
				}
			}
		}
		return text;
	}

	private static int GetSubPropertyUnlockLevel(Shift.Legion.Common.Models.LegendItem.LegendItem itemUi, int propetryIndex)
	{
		Dictionary<string, Dictionary<int, LegendItemEnhancementConfig>> legendItemEnhancementConfigs = LegendItemManager.LegendItemEnhancementConfigs;
		List<Dictionary<int, int>> list = LegendItemManager.LegendItemNextUnlockEnhanceLevel.Values.ToList();
		if (list.Count <= 0)
		{
			return propetryIndex switch
			{
				1 => 5, 
				2 => 10, 
				_ => 5 * propetryIndex, 
			};
		}
		int num = itemUi.Data.Rarity - 1;
		if (list.Count >= num + 1)
		{
			Dictionary<int, int> dictionary = list[num];
			if (dictionary.ContainsKey(propetryIndex + 1))
			{
				return dictionary[propetryIndex + 1];
			}
			return 0;
		}
		return 0;
	}

	private static bool GetSubPropertyUnlocked(Shift.Legion.Common.Models.LegendItem.LegendItem itemUi, int propetryIndex)
	{
		return propetryIndex < itemUi.UnlockedSubEntries;
	}

	public static string GetBlueprintFxText(string result)
	{
		return result.Replace("[color=#afabab]", "[color=#aef224]") + "<img src='ui://PublicResources/icon_arrow_green_up' width='33' height='33'/>";
	}

	public static List<BlueprintFxText> GetFxEntriesForgeResult(Shift.Legion.Common.Models.LegendItem.LegendItem legendItem)
	{
		List<BlueprintFxText> list = new List<BlueprintFxText>();
		List<ItemEntry> fxEntries = legendItem.FxEntries;
		if (fxEntries == null)
		{
			return list;
		}
		for (int i = 0; i < fxEntries.Count; i++)
		{
			string text = LanguagesManager.GetLegendItemPropetryDesc(fxEntries[i].EntryId, fxEntries[i].Attributes, isFxEntry: true);
			if (string.IsNullOrWhiteSpace(text))
			{
				int num = 0;
				foreach (ItemEntryData attribute in fxEntries[i].Attributes)
				{
					text += $"{attribute.Key} {attribute.Value}";
					if (num < fxEntries[i].Attributes.Count - 1)
					{
						text += Environment.NewLine;
					}
					num++;
				}
			}
			list.Add(new BlueprintFxText
			{
				FxTextType = (fxEntries[i].IsBlueprintEntry ? 1 : 0),
				Text = text
			});
		}
		if (!string.IsNullOrWhiteSpace(legendItem.Data.SetId))
		{
			list.Add(new BlueprintFxText
			{
				FxTextType = 2,
				Text = GetSuitDesc(legendItem)
			});
		}
		return list;
	}

	public static string GetSuitDesc(LegendItemBrief legendItemBrief)
	{
		if (LegendItemManager.LegendItemTemplates.ContainsKey(legendItemBrief.ItemId) && !string.IsNullOrWhiteSpace(LegendItemManager.LegendItemTemplates[legendItemBrief.ItemId].SetId))
		{
			return GetSuitDataDesc(LegendItemManager.LegendItemTemplates[legendItemBrief.ItemId].SetId);
		}
		if (!string.IsNullOrEmpty(legendItemBrief.SetAlias) && LegendItemSetMap.TryGetValue(legendItemBrief.SetAlias, out var value))
		{
			string setDesc = LanguagesManager.GetSetDesc(value.Key);
			string desc = LanguagesManager.GetDesc("CsharpCodeZhTcText965");
			return string.Format(desc, legendItemBrief.SetAlias) + setDesc;
		}
		return string.Empty;
	}

	public static string GetSuitDesc(Shift.Legion.Common.Models.LegendItem.LegendItem legendItem)
	{
		if (!string.IsNullOrWhiteSpace(legendItem.Data.SetId))
		{
			return GetSuitDataDesc(legendItem);
		}
		if (!string.IsNullOrEmpty(legendItem.SetAlias) && LegendItemSetMap.TryGetValue(legendItem.SetAlias, out var value))
		{
			string setDesc = LanguagesManager.GetSetDesc(value.Key);
			string desc = LanguagesManager.GetDesc("CsharpCodeZhTcText965");
			return string.Format(desc, legendItem.SetAlias) + setDesc;
		}
		return string.Empty;
	}

	public static bool IsBlueprintSuit(Shift.Legion.Common.Models.LegendItem.LegendItem legendItem)
	{
		if (!string.IsNullOrEmpty(legendItem.SetAlias) && LegendItemSetMap.TryGetValue(legendItem.SetAlias, out var _))
		{
			return true;
		}
		return false;
	}

	public static string GetSuitDesc(BlackMarketLegendItem legendItem)
	{
		if (!string.IsNullOrWhiteSpace(legendItem.SetId))
		{
			return GetSuitDataDesc(legendItem);
		}
		if (!string.IsNullOrEmpty(legendItem.ItemData.SetAlias) && LegendItemSetMap.TryGetValue(legendItem.ItemData.SetAlias, out var value))
		{
			return LanguagesManager.GetSetDesc(value.Key);
		}
		return string.Empty;
	}

	public static List<string> GetFxEntries(Shift.Legion.Common.Models.LegendItem.LegendItem legendItem, bool isBlueprint = false)
	{
		List<string> list = new List<string>();
		List<ItemEntry> fxEntries = legendItem.FxEntries;
		if (fxEntries == null)
		{
			return list;
		}
		for (int i = 0; i < fxEntries.Count; i++)
		{
			if (isBlueprint && !fxEntries[i].IsBlueprintEntry)
			{
				continue;
			}
			string text = LanguagesManager.GetLegendItemPropetryDesc(fxEntries[i].EntryId, fxEntries[i].Attributes, isFxEntry: true);
			if (string.IsNullOrWhiteSpace(text))
			{
				int num = 0;
				foreach (ItemEntryData attribute in fxEntries[i].Attributes)
				{
					text += $"{attribute.Key} {attribute.Value}";
					if (num < fxEntries[i].Attributes.Count - 1)
					{
						text += Environment.NewLine;
					}
					num++;
				}
			}
			list.Add(text);
		}
		return list;
	}

	public static string GetFxEntriesExcludeBlueprint(Shift.Legion.Common.Models.LegendItem.LegendItem legendItem)
	{
		string text = string.Empty;
		List<ItemEntry> fxEntries = legendItem.FxEntries;
		if (fxEntries == null)
		{
			return text;
		}
		for (int i = 0; i < fxEntries.Count; i++)
		{
			if (fxEntries[i].IsBlueprintEntry)
			{
				continue;
			}
			string text2 = LanguagesManager.GetLegendItemPropetryDesc(fxEntries[i].EntryId, fxEntries[i].Attributes, isFxEntry: true);
			if (string.IsNullOrWhiteSpace(text2))
			{
				int num = 0;
				foreach (ItemEntryData attribute in fxEntries[i].Attributes)
				{
					text2 += $"{attribute.Key} {attribute.Value}";
					if (num < fxEntries[i].Attributes.Count - 1)
					{
						text2 += Environment.NewLine;
					}
					num++;
				}
			}
			text += text2;
		}
		return text;
	}

	public static List<string> GetFxEntries(LegendItemData legendItem)
	{
		List<string> list = new List<string>();
		List<ItemEntry> fxEntries = legendItem.FxEntries;
		if (fxEntries == null)
		{
			return list;
		}
		for (int i = 0; i < fxEntries.Count; i++)
		{
			string text = LanguagesManager.GetLegendItemPropetryDesc(fxEntries[i].EntryId, fxEntries[i].Attributes, isFxEntry: true);
			if (string.IsNullOrWhiteSpace(text))
			{
				int num = 0;
				foreach (ItemEntryData attribute in fxEntries[i].Attributes)
				{
					text += $"{attribute.Key} {attribute.Value}";
					if (num < fxEntries[i].Attributes.Count - 1)
					{
						text += Environment.NewLine;
					}
					num++;
				}
			}
			list.Add(text);
		}
		return list;
	}

	public static List<string> GetFxEntries(LegendItemBrief legendItem)
	{
		List<string> list = new List<string>();
		List<ItemEntryBrief> fxEntries = legendItem.FxEntries;
		if (fxEntries == null)
		{
			return list;
		}
		for (int i = 0; i < fxEntries.Count; i++)
		{
			string text = LanguagesManager.GetLegendItemPropetryDesc(fxEntries[i].EntryId, fxEntries[i].Attributes, isFxEntry: true);
			if (string.IsNullOrWhiteSpace(text))
			{
				int num = 0;
				foreach (ItemEntryData attribute in fxEntries[i].Attributes)
				{
					text += $"{attribute.Key} {attribute.Value}";
					if (num < fxEntries[i].Attributes.Count - 1)
					{
						text += Environment.NewLine;
					}
					num++;
				}
			}
			list.Add(text);
		}
		return list;
	}

	public static string GetSubEntriesBlueprint(Shift.Legion.Common.Models.LegendItem.LegendItem legendItem, out List<string> blueprintEntryText)
	{
		if (legendItem.SubEntries == null)
		{
			blueprintEntryText = new List<string>();
			return "";
		}
		string text = "";
		blueprintEntryText = new List<string>();
		List<ItemEntry> subEntries = legendItem.SubEntries;
		for (int i = 0; i < subEntries.Count; i++)
		{
			bool isBlueprintEntry = subEntries[i].IsBlueprintEntry;
			if (!GetSubPropertyUnlocked(legendItem, i))
			{
				string text2 = LanguagesManager.GetLockedSubEntryText() + string.Format("[color=#66FF66]（{0}{1}{2}）[/color]", LanguagesManager.GetDesc("CsharpCodeZhTcText319"), GetSubPropertyUnlockLevel(legendItem, i), LanguagesManager.GetDesc("CsharpCodeZhTcText320"));
				if (isBlueprintEntry)
				{
					blueprintEntryText.Add(text2);
				}
				else
				{
					text += text2;
				}
			}
			else
			{
				string legendItemPropetryDesc = LanguagesManager.GetLegendItemPropetryDesc(subEntries[i].EntryId, subEntries[i].Attributes);
				if (!string.IsNullOrWhiteSpace(legendItemPropetryDesc))
				{
					if (isBlueprintEntry)
					{
						blueprintEntryText.Add(legendItemPropetryDesc);
					}
					else
					{
						text += legendItemPropetryDesc;
					}
				}
				else
				{
					int num = 0;
					foreach (ItemEntryData attribute in subEntries[i].Attributes)
					{
						string item = $"{attribute.Key} {attribute.Value}";
						if (isBlueprintEntry)
						{
							blueprintEntryText.Add(item);
						}
						else
						{
							text += $"{attribute.Key} {attribute.Value}";
						}
						if (num < subEntries[i].Attributes.Count - 1 && !isBlueprintEntry)
						{
							text += Environment.NewLine;
						}
						num++;
					}
				}
			}
			if (i < subEntries.Count - 1 && !isBlueprintEntry)
			{
				text += Environment.NewLine;
			}
		}
		char[] trimChars = Environment.NewLine.ToCharArray();
		return text.TrimEnd(trimChars);
	}

	public static string GetSubEntries(Shift.Legion.Common.Models.LegendItem.LegendItem itemUi)
	{
		List<ItemEntry> subEntries = itemUi.SubEntries;
		if (subEntries == null)
		{
			return "";
		}
		string text = "";
		for (int i = 0; i < subEntries.Count; i++)
		{
			if (!GetSubPropertyUnlocked(itemUi, i))
			{
				text = text + LanguagesManager.GetLockedSubEntryText() + string.Format("[color=#66FF66]（{0}{1}{2}）[/color]", LanguagesManager.GetDesc("CsharpCodeZhTcText319"), GetSubPropertyUnlockLevel(itemUi, i), LanguagesManager.GetDesc("CsharpCodeZhTcText320"));
			}
			else
			{
				string legendItemPropetryDesc = LanguagesManager.GetLegendItemPropetryDesc(subEntries[i].EntryId, subEntries[i].Attributes);
				if (!string.IsNullOrWhiteSpace(legendItemPropetryDesc))
				{
					text += legendItemPropetryDesc;
				}
				else
				{
					int num = 0;
					foreach (ItemEntryData attribute in subEntries[i].Attributes)
					{
						text += $"{attribute.Key} {attribute.Value}";
						if (num < subEntries[i].Attributes.Count - 1)
						{
							text += Environment.NewLine;
						}
						num++;
					}
				}
			}
			if (i < subEntries.Count - 1)
			{
				text += Environment.NewLine;
			}
		}
		return text;
	}

	public static string GetBlueprintFxDesc(string propetryId)
	{
		List<object> list = new List<object>();
		string legendItemEntryIdText = LanguagesManager.GetLegendItemEntryIdText(propetryId);
		string desc = LanguagesManager.GetDesc(legendItemEntryIdText + "_Blueprint", returnKey: false);
		list.AddRange(LanguagesManager.GetPropetryRandomValueText(propetryId));
		if (desc.Contains("{2}") || desc.Contains("{3}"))
		{
			list.AddRange(LanguagesManager.GetPropetryRandomValueText(propetryId + "_1"));
		}
		string text = string.Format(desc, list.ToArray());
		if (string.IsNullOrEmpty(text))
		{
			text = legendItemEntryIdText + "_" + JsonHelper.ToJson(list);
		}
		return text;
	}

	public static List<string> GetLegendItemTags(string legendItemId)
	{
		if (_legendItemTags == null)
		{
			string json = GDMgr.LoadGameDataFileAllText(null, "LegendItemTags");
			_legendItemTags = JsonHelper.ToObject<Dictionary<string, List<string>>>(json);
			GDMgr.ReleaseGameDataFileAllText("LegendItemTags");
		}
		if (_legendItemTags.TryGetValue(legendItemId, out var value))
		{
			return value;
		}
		return new List<string>();
	}

	public static List<string> GetLegendItemPropertyExclude(string propertyId)
	{
		if (_legendItemProperyExclude == null)
		{
			string json = GDMgr.LoadGameDataFileAllText(null, "LegendItemPropertyExclude");
			_legendItemProperyExclude = JsonHelper.ToObject<Dictionary<string, List<string>>>(json);
			GDMgr.ReleaseGameDataFileAllText("LegendItemPropertyExclude");
		}
		if (_legendItemProperyExclude.TryGetValue(propertyId, out var value))
		{
			return value;
		}
		return new List<string>();
	}

	public static string GetBlueprintSetDesc(string setAlias)
	{
		GDELegendItemSetData value;
		return (!LegendItemSetMap.TryGetValue(setAlias, out value)) ? setAlias : GetSuitDataDesc(value.Key);
	}

	public static bool MainLegendItemIsPending(LegendItemUi legendItemUi)
	{
		if (legendItemUi.LegendItemData.FxEntries != null && legendItemUi.LegendItemData.FxEntries.Any((ItemEntry t) => t.Status == 2))
		{
			return true;
		}
		if (legendItemUi.LegendItemData.SubEntries == null)
		{
			return false;
		}
		return legendItemUi.LegendItemData.SubEntries.Any((ItemEntry t) => t.Status == 1 || t.Status == 2);
	}

	public static Shift.Legion.Common.Models.LegendItem.LegendItem UpdateMainItem(string mainItemInstanceId, byte[] itemData)
	{
		LegendItemUi legendItemUi = GetLegendItemUi(long.Parse(mainItemInstanceId));
		if (legendItemUi == null)
		{
			return null;
		}
		Shift.Legion.ClientApi.Protocol.Modules.LegendItem.Models.LegendItem apiModel = itemData.Deserialize<Shift.Legion.ClientApi.Protocol.Modules.LegendItem.Models.LegendItem>();
		legendItemUi.LegendItemData = new Shift.Legion.Common.Models.LegendItem.LegendItem(GameManagers.Instance, apiModel);
		return legendItemUi.LegendItemData;
	}

	public static void DeleteBlueprint(string blueprintId)
	{
		GameManagers.Instance.UserArchiveManager.DeleteLegendItemBlueprint(blueprintId);
	}

	public static void DeleteLegendItemsBeforeForge(List<string> randomList, List<string> anyList, List<RItem> universalLegendItem)
	{
		List<string> list = new List<string>();
		list.AddRange(randomList);
		list.AddRange(anyList);
		for (int num = LegendItems.Count - 1; num >= 0; num--)
		{
			if (list.Contains(LegendItems[num].InstanceId.ToString()))
			{
				LegendItems.RemoveAt(num);
			}
		}
		StockChangeRecord[] stockChangeRecords = universalLegendItem.Select((RItem i) => new RItem
		{
			ItemId = i.ItemId,
			cnt = -i.cnt
		}).ToList().ToStockChangeRecords(StockInContext.Unknown);
		GameManagers.Instance.StockController.ReadStockChangeRecords(stockChangeRecords);
	}

	public static void UpdateStockBeforeForge(string blueprintId, Dictionary<string, int> other)
	{
		StockChangeRecord[] array = new StockChangeRecord[other.Count];
		int num = 0;
		foreach (KeyValuePair<string, int> item in other)
		{
			array[num++] = new StockChangeRecord
			{
				ItemId = item.Key,
				Offset = item.Value * -1,
				Context = 111,
				ContextValue = blueprintId,
				Type = 1
			};
		}
		GameManagers.Instance.StockController.ReadStockChangeRecords(array);
	}

	private static bool LegendItemIdentityCheck(List<string> wearFxIdentity, int slotId, long[] items)
	{
		List<string> list = new List<string>();
		for (int i = 0; i < 2; i++)
		{
			long num = items[i];
			if (num == 0 || i == slotId)
			{
				continue;
			}
			Shift.Legion.Common.Models.LegendItem.LegendItem legendItemData = GetLegendItemUi(items[i]).LegendItemData;
			if (legendItemData != null && legendItemData.FxEntries != null)
			{
				IEnumerable<string> enumerable = from _entry in legendItemData.FxEntries
					where !string.IsNullOrEmpty(GDMgr.Get<GDELegendItemPropertyData>(_entry.EntryId).Identity)
					select GDMgr.Get<GDELegendItemPropertyData>(_entry.EntryId).Identity;
				if (enumerable != null)
				{
					list.AddRange(enumerable);
				}
			}
		}
		return list.Intersect(wearFxIdentity).Any();
	}

	private static bool LegendItemIdentityCheck(List<string> wearFxIdentity, int slotId, List<long> items)
	{
		List<string> list = new List<string>();
		for (int i = 0; i < 2; i++)
		{
			long num = items[i];
			if (num == 0 || i == slotId)
			{
				continue;
			}
			Shift.Legion.Common.Models.LegendItem.LegendItem legendItemData = GetLegendItemUi(items[i]).LegendItemData;
			if (legendItemData != null && legendItemData.FxEntries != null)
			{
				IEnumerable<string> enumerable = from _entry in legendItemData.FxEntries
					where !string.IsNullOrEmpty(GDMgr.Get<GDELegendItemPropertyData>(_entry.EntryId).Identity)
					select GDMgr.Get<GDELegendItemPropertyData>(_entry.EntryId).Identity;
				if (enumerable != null)
				{
					list.AddRange(enumerable);
				}
			}
		}
		return list.Intersect(wearFxIdentity).Any();
	}

	public static void WearOperationDevelop(Action action, LegendItemUi legendItem, int slotId, string soldierId)
	{
		if (!SoldiersEquippedItems.TryGetValue(soldierId, out var value))
		{
			action?.Invoke();
			return;
		}
		if (value == null || value.Length == 0)
		{
			action?.Invoke();
			return;
		}
		List<string> list = new List<string>();
		if (legendItem.LegendItemData.FxEntries != null)
		{
			IEnumerable<string> enumerable = from _entry in legendItem.LegendItemData.FxEntries
				where !string.IsNullOrEmpty(GDMgr.Get<GDELegendItemPropertyData>(_entry.EntryId).Identity)
				select GDMgr.Get<GDELegendItemPropertyData>(_entry.EntryId).Identity;
			if (enumerable != null)
			{
				list.AddRange(enumerable);
			}
		}
		if (LegendItemIdentityCheck(list, slotId, value))
		{
			GameController.Contexts.Service<IUiService>().OpenPanel(UI_main_LegendItemIdentityConfirm.Name, new Dictionary<string, object>
			{
				{ "DialogType", 1 },
				{ "ConfirmAction", action }
			});
		}
		else
		{
			action?.Invoke();
		}
	}

	public static void WearOperationTop(Action action, LegendItemUi legendItem, int slotId, string soldierId)
	{
		List<long> soldierTopLegendItems = GetSoldierTopLegendItems(soldierId);
		if (soldierTopLegendItems.Count <= 0)
		{
			action?.Invoke();
			return;
		}
		List<string> list = new List<string>();
		if (legendItem.LegendItemData.FxEntries != null)
		{
			IEnumerable<string> enumerable = from _entry in legendItem.LegendItemData.FxEntries
				where !string.IsNullOrEmpty(GDMgr.Get<GDELegendItemPropertyData>(_entry.EntryId).Identity)
				select GDMgr.Get<GDELegendItemPropertyData>(_entry.EntryId).Identity;
			if (enumerable != null)
			{
				list.AddRange(enumerable);
			}
		}
		if (LegendItemIdentityCheck(list, slotId, soldierTopLegendItems))
		{
			GameController.Contexts.Service<IUiService>().OpenPanel(UI_main_LegendItemIdentityConfirm.Name, new Dictionary<string, object>
			{
				{ "DialogType", 1 },
				{ "ConfirmAction", action }
			});
		}
		else
		{
			action?.Invoke();
		}
	}

	public static void ForgeOperation(Action action, LegendItemUi legendItem, Blueprint blueprint)
	{
		bool flag = false;
		List<string> list = new List<string>();
		if (legendItem.LegendItemData.FxEntries != null)
		{
			IEnumerable<string> enumerable = from _entry in legendItem.LegendItemData.FxEntries
				where !_entry.IsBlueprintEntry && !string.IsNullOrEmpty(GDMgr.Get<GDELegendItemPropertyData>(_entry.EntryId).Identity)
				select GDMgr.Get<GDELegendItemPropertyData>(_entry.EntryId).Identity;
			if (enumerable != null)
			{
				list.AddRange(enumerable);
			}
		}
		if (blueprint.NewFxEntries != null)
		{
			IEnumerable<string> enumerable2 = from _entry in blueprint.NewFxEntries
				where !string.IsNullOrEmpty(_entry) && !string.IsNullOrEmpty(GDMgr.Get<GDELegendItemPropertyData>(_entry).Identity)
				select GDMgr.Get<GDELegendItemPropertyData>(_entry).Identity;
			if (enumerable2 != null)
			{
				list.AddRange(enumerable2);
			}
		}
		int slotId;
		List<long> soldierTopLegendItems = GetSoldierTopLegendItems(legendItem.InstanceId, out slotId);
		if (slotId >= 0 && soldierTopLegendItems != null && soldierTopLegendItems.Count >= 0 && LegendItemIdentityCheck(list, slotId, soldierTopLegendItems))
		{
			GameController.Contexts.Service<IUiService>().OpenPanel(UI_main_LegendItemIdentityConfirm.Name, new Dictionary<string, object>
			{
				{ "DialogType", 0 },
				{ "ConfirmAction", action }
			});
			return;
		}
		long[] soldierLegendItems = GetSoldierLegendItems(legendItem.InstanceId, out slotId);
		if (slotId >= 0 && soldierLegendItems != null && LegendItemIdentityCheck(list, slotId, soldierLegendItems))
		{
			GameController.Contexts.Service<IUiService>().OpenPanel(UI_main_LegendItemIdentityConfirm.Name, new Dictionary<string, object>
			{
				{ "DialogType", 0 },
				{ "ConfirmAction", action }
			});
		}
		else
		{
			action?.Invoke();
		}
	}

	public static void OpenSelectLegendItems(Action onSuccess)
	{
		ILRequestHelper<GetPvPTopTournamentFormationResponse>.Request((EventContext)null, (Func<Task<GetPvPTopTournamentFormationResponse>>)(() => GameController.Contexts.Service<INetworkService>().GetPvPTopTournamentFormation()), (Action<GetPvPTopTournamentFormationResponse>)delegate(GetPvPTopTournamentFormationResponse response)
		{
			if (!response.Result)
			{
				ILRequestHelper.ShowErrorCode(response.ErrorCode);
			}
			else
			{
				if (response.CurFormation?.Units != null)
				{
					units.Clear();
					for (int i = 0; i < response.CurFormation.Units.Count; i++)
					{
						for (int j = 0; j < response.CurFormation.Units[i].Count; j++)
						{
							SoldierWithLegendItemId soldierWithLegendItemId = response.CurFormation.Units[i][j];
							soldierWithLegendItemId.DataCheck();
							units.Add(soldierWithLegendItemId);
						}
					}
				}
				onSuccess?.Invoke();
			}
		});
	}

	private static List<long> GetSoldierTopLegendItems(string soldierId)
	{
		for (int i = 0; i < units.Count; i++)
		{
			if (units[i].SoldierId == soldierId)
			{
				units[i].DataCheck();
				return units[i].LegendItemIds;
			}
		}
		return new List<long>();
	}

	public static bool LegendItemsEquiped(long itemId)
	{
		for (int i = 0; i < units.Count; i++)
		{
			if (units[i].LegendItemIds == null)
			{
				continue;
			}
			for (int j = 0; j < units[i].LegendItemIds.Count; j++)
			{
				if (units[i].LegendItemIds[j] == itemId)
				{
					return true;
				}
			}
		}
		return false;
	}

	private static List<long> GetSoldierTopLegendItems(long itemId, out int slotId)
	{
		List<long> result = new List<long>();
		slotId = -1;
		for (int i = 0; i < units.Count; i++)
		{
			if (units[i].LegendItemIds == null)
			{
				continue;
			}
			for (int j = 0; j < units[i].LegendItemIds.Count; j++)
			{
				if (units[i].LegendItemIds[j] == itemId)
				{
					units[i].DataCheck();
					result = units[i].LegendItemIds;
					slotId = j;
					break;
				}
			}
		}
		return result;
	}

	private static long[] GetSoldierLegendItems(long itemId, out int slotId)
	{
		long[] result = new long[2];
		slotId = -1;
		if (!EquippedLegendItems.TryGetValue(itemId.ToString(), out var value))
		{
			return result;
		}
		if (!SoldiersEquippedItems.TryGetValue(value, out var value2))
		{
			return result;
		}
		if (value2 == null || value2.Length == 0)
		{
			return result;
		}
		for (int i = 0; i < value2.Length; i++)
		{
			if (value2[i] == itemId)
			{
				slotId = i;
				break;
			}
		}
		return value2;
	}

	public static void ShowCanNotSelectTip(CanNotSelectTipType tipType, string legendItemName = "")
	{
		switch (tipType)
		{
		case CanNotSelectTipType.IsMainLegendItem:
			ILRequestHelper.ShowErrorCode(81311510);
			break;
		case CanNotSelectTipType.Equipped:
			ILRequestHelper.ShowErrorCode(81311512);
			break;
		case CanNotSelectTipType.Occupied:
			TopTournamentLegendItemReminder.RemindGoToUnEquip(legendItemName);
			break;
		case CanNotSelectTipType.Pending:
			ILRequestHelper.ShowErrorCode(81311509);
			break;
		}
	}
}
