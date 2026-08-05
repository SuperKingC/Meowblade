using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Assets.Scripts.Managers;
using Assets.Scripts.UI;
using FairyGUI;
using FairyGUI.Utils;
using GameDataEditor;
using GameMaths;
using HotFix.Sources.Base.Scripts.Helper;
using Shift.Legion.ClientApi.Protocol.Modules.LegendItem.Models;
using Shift.Legion.ClientApi.Protocol.Modules.LegendItemEnhancement;
using Shift.Legion.Common.Helpers;
using Shift.Legion.Common.Managers;
using Shift.Legion.Common.Models;
using Shift.Legion.Common.Models.LegendItem;
using Shift.Legion.Common.Services;
using Shift.Legion.Helpers;
using UI.Tips;

namespace UI.LegendItemCultivation;

public class UI_Replace : GComponent
{
	internal class PropPayloadEntry
	{
		public string Key;

		public string Type;

		public string Value;
	}

	public Controller readyToSwap;

	public GImage bg;

	public GImage n28;

	public UI_AttributeReplace curAttribute;

	public GImage arrow1;

	public GImage arrow2;

	public GImage arrow3;

	public UI_AttributeReplace repAttribute;

	public UI_LegendItemReplace treasureIcon;

	public GImage n31;

	public GLoader treasureIconBefore;

	public UI_btn_AddLegendItem plusIcon;

	public GGroup TreasureBeforeGroup;

	public UI_ReforgeCostItemAndNum costItem;

	public GImage n34;

	public GImage n33;

	public GTextField costLabel;

	public GButton yesBtn;

	public const string URL = "ui://b9wlonaqk42ih5";

	public static string Name = "UI_Replace";

	private LegendItemUi curLegendItem;

	private LegendItemUi selectedSwapItem;

	private Dictionary<string, int> swapCostConfig;

	private string _swapCostKey;

	private int _swapCostCount;

	private static Dictionary<string, string> _effectTypeToSuffix;

	internal static Dictionary<string, PropPayloadEntry> PropPayloadCache;

	public static string GetURL()
	{
		return "ui://b9wlonaqk42ih5";
	}

	public static UI_Replace CreateInstance()
	{
		return (UI_Replace)(object)UIPackage.CreateObject("LegendItemCultivation", "Replace");
	}

	public static UI_Replace CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_Replace).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://b9wlonaqk42ih5", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Expected O, but got Unknown
		//IL_003c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0046: Expected O, but got Unknown
		//IL_0068: Unknown result type (might be due to invalid IL or missing references)
		//IL_0072: Expected O, but got Unknown
		//IL_007e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0088: Expected O, but got Unknown
		//IL_0094: Unknown result type (might be due to invalid IL or missing references)
		//IL_009e: Expected O, but got Unknown
		//IL_00d6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e0: Expected O, but got Unknown
		//IL_00ec: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f6: Expected O, but got Unknown
		//IL_0118: Unknown result type (might be due to invalid IL or missing references)
		//IL_0122: Expected O, but got Unknown
		//IL_0144: Unknown result type (might be due to invalid IL or missing references)
		//IL_014e: Expected O, but got Unknown
		//IL_015a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0164: Expected O, but got Unknown
		//IL_0170: Unknown result type (might be due to invalid IL or missing references)
		//IL_017a: Expected O, but got Unknown
		//IL_01c3: Unknown result type (might be due to invalid IL or missing references)
		//IL_01cd: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		readyToSwap = ((GComponent)this).GetController("readyToSwap");
		bg = (GImage)((GComponent)this).GetChild("bg");
		n28 = (GImage)((GComponent)this).GetChild("n28");
		curAttribute = (UI_AttributeReplace)(object)((GComponent)this).GetChild("curAttribute");
		arrow1 = (GImage)((GComponent)this).GetChild("arrow1");
		arrow2 = (GImage)((GComponent)this).GetChild("arrow2");
		arrow3 = (GImage)((GComponent)this).GetChild("arrow3");
		repAttribute = (UI_AttributeReplace)(object)((GComponent)this).GetChild("repAttribute");
		treasureIcon = (UI_LegendItemReplace)(object)((GComponent)this).GetChild("treasureIcon");
		n31 = (GImage)((GComponent)this).GetChild("n31");
		treasureIconBefore = (GLoader)((GComponent)this).GetChild("treasureIconBefore");
		plusIcon = (UI_btn_AddLegendItem)(object)((GComponent)this).GetChild("plusIcon");
		TreasureBeforeGroup = (GGroup)((GComponent)this).GetChild("TreasureBeforeGroup");
		costItem = (UI_ReforgeCostItemAndNum)(object)((GComponent)this).GetChild("costItem");
		n34 = (GImage)((GComponent)this).GetChild("n34");
		n33 = (GImage)((GComponent)this).GetChild("n33");
		costLabel = (GTextField)((GComponent)this).GetChild("costLabel");
		string id = "ui://b9wlonaqk42ih5".Replace("ui://", "") + "-" + ((GObject)costLabel).id;
		((GObject)costLabel).text = LanguagesManager.GetDesc(id);
		yesBtn = (GButton)((GComponent)this).GetChild("yesBtn");
	}

	public void Init()
	{
		LoadSwapCostConfig();
		((GObject)repAttribute.questionMark).text = "SwapLegendItemTip5".ToLanguage();
	}

	public void ResetLegendItem(LegendItemUi item)
	{
		curLegendItem = item;
		selectedSwapItem = null;
		ResetAll();
	}

	public void RegisterEvents()
	{
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_001d: Expected O, but got Unknown
		//IL_0030: Unknown result type (might be due to invalid IL or missing references)
		//IL_003a: Expected O, but got Unknown
		//IL_004d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0057: Expected O, but got Unknown
		((GObject)treasureIcon).onClick.Add(new EventCallback0(OnClickSelectTreasure));
		((GObject)plusIcon).onClick.Add(new EventCallback0(OnClickSelectTreasure));
		((GObject)yesBtn).onClick.Add(new EventCallback0(OnClickConfirm));
		SharedMessenger.AddListener<SwapSelectLegendItem>("LEGEND_ITEM_SWAP_SELECT", OnSwapSelect);
	}

	public void UnregisterEvents()
	{
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_001d: Expected O, but got Unknown
		//IL_0030: Unknown result type (might be due to invalid IL or missing references)
		//IL_003a: Expected O, but got Unknown
		//IL_004d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0057: Expected O, but got Unknown
		((GObject)treasureIcon).onClick.Remove(new EventCallback0(OnClickSelectTreasure));
		((GObject)plusIcon).onClick.Remove(new EventCallback0(OnClickSelectTreasure));
		((GObject)yesBtn).onClick.Remove(new EventCallback0(OnClickConfirm));
		SharedMessenger.RemoveListener<SwapSelectLegendItem>("LEGEND_ITEM_SWAP_SELECT", OnSwapSelect);
	}

	public void ResetAll()
	{
		readyToSwap.SetSelectedIndex((selectedSwapItem != null) ? 1 : 0);
		((GObject)treasureIconBefore).visible = true;
		RenderCurrentTreasureIcon();
		RenderCurrentMainAttr();
		ResetReplacementAttr();
		RenderCostItem();
	}

	private void RenderCurrentTreasureIcon()
	{
		if (curLegendItem != null && curLegendItem.LegendItemData != null && curLegendItem.LegendItemData.Data != null)
		{
			treasureIconBefore.LoadArmsIcon(curLegendItem.LegendItemData.Data.Icon);
		}
	}

	private void LoadSwapCostConfig()
	{
		swapCostConfig = "SwapCostConfig".ToConfiguration<Dictionary<string, int>>();
		KeyValuePair<string, int> keyValuePair = swapCostConfig.First();
		_swapCostKey = keyValuePair.Key;
		_swapCostCount = keyValuePair.Value;
	}

	private void RenderCurrentMainAttr()
	{
		List<ItemEntry> mainEntries = curLegendItem.LegendItemData.MainEntries;
		if (mainEntries != null && mainEntries.Count > 0)
		{
			string legendItemMainPropetryKeyText = LegendItemsHelper.GetLegendItemMainPropetryKeyText(curLegendItem);
			((GObject)curAttribute.primeAttribute).text = legendItemMainPropetryKeyText + LegendItemsHelper.GetLegendItemNextEnhanceLevelValue(curLegendItem);
		}
		else
		{
			((GObject)curAttribute.primeAttribute).text = "";
		}
	}

	private void ResetReplacementAttr()
	{
		repAttribute.AttributeContent.SetSelectedIndex(0);
	}

	private void RenderCostItem()
	{
		FGUIManager.Instance.SetItemIconAndFrame(costItem.Icon, _swapCostKey, null, "", frameVisible: false);
		costItem.Icon.InitMaterialIntroductionBtn(_swapCostKey);
		int stock = GameManagers.Instance.StockController.GetStock(_swapCostKey);
		((GObject)costItem.num).text = $"x{_swapCostCount}";
		if (selectedSwapItem != null)
		{
			UpdateSwapButtonState(stock, _swapCostCount);
			return;
		}
		((GObject)yesBtn).enabled = false;
		((GObject)yesBtn).grayed = true;
	}

	private void UpdateSwapButtonState(int currentStock, int costCount)
	{
		if (costCount > 0 && currentStock < costCount)
		{
			((GObject)yesBtn).enabled = false;
		}
		else
		{
			((GObject)yesBtn).enabled = true;
		}
	}

	private void OnClickSelectTreasure()
	{
		if (curLegendItem == null || curLegendItem.LegendItemData == null)
		{
			return;
		}
		string name = curLegendItem.LegendItemData.Data.Name;
		if (string.IsNullOrEmpty(name))
		{
			return;
		}
		HashSet<string> hashSet = new HashSet<string>();
		EnsurePayloadCaches();
		Shift.Legion.Common.Models.LegendItem.LegendItem legendItemData = curLegendItem.LegendItemData;
		List<ItemEntry>[] array = new List<ItemEntry>[3] { legendItemData.MainEntries, legendItemData.SubEntries, legendItemData.AlterMainEntries };
		List<ItemEntry>[] array2 = array;
		foreach (List<ItemEntry> list in array2)
		{
			if (list == null)
			{
				continue;
			}
			foreach (ItemEntry item in list)
			{
				if (item.Attributes == null)
				{
					continue;
				}
				foreach (ItemEntryData attribute in item.Attributes)
				{
					if (!string.IsNullOrEmpty(attribute.Key))
					{
						hashSet.Add(attribute.Key);
					}
				}
			}
		}
		Dictionary<string, object> parameters = new Dictionary<string, object>
		{
			{ "FilterSameNameItemId", name },
			{ "CurrentInstanceId", curLegendItem.InstanceId },
			{ "CurrentSlotIndex", 0 },
			{ "ExcludeAttrTypes", hashSet }
		};
		GameController.Contexts.Service<IUiService>().OpenPanel(UI_main_LegendItemSelect.Name, parameters);
	}

	private void OnSwapSelect(SwapSelectLegendItem selectInfo)
	{
		if (selectInfo != null)
		{
			LegendItemUi legendItemUi = LegendItemsHelper.LegendItems?.FirstOrDefault((LegendItemUi item) => item.InstanceId == selectInfo.InstanceId);
			if (legendItemUi == null)
			{
				"SwapLegendItemTip1".ToLanguage().ToTip();
			}
			else
			{
				OnLegendItemSelected(legendItemUi);
			}
		}
	}

	private string GetSwapMainAttrText(ItemEntry swapEntry)
	{
		ItemEntry itemEntry = curLegendItem?.LegendItemData?.MainEntries?[0];
		if (itemEntry == null || swapEntry?.Attributes == null || swapEntry.Attributes.Count == 0 || itemEntry.Attributes == null || itemEntry.Attributes.Count == 0)
		{
			return "";
		}
		ItemEntryData itemEntryData = swapEntry.Attributes[0];
		string maxLogoText;
		string text = LegendItemsHelper.GetReforgeEntry(swapEntry, out maxLogoText)?.Values.FirstOrDefault() ?? "";
		int swapPredictedLevelAdd = GetSwapPredictedLevelAdd();
		string text2 = ComputeMainAttrEnhancedValue(itemEntryData.Key, itemEntryData.IsPercent, swapEntry.EntryId, swapPredictedLevelAdd);
		return text + text2;
	}

	private int GetSwapPredictedLevelAdd()
	{
		if (selectedSwapItem == null)
		{
			return 0;
		}
		int num = selectedSwapItem.LegendItemData.TotalGainedExp + selectedSwapItem.LegendItemData.Data.ExpProvide;
		if (num <= 0)
		{
			return 0;
		}
		bool canLevelUp;
		int fakeLegendItemLevel = LegendItemsHelper.GetFakeLegendItemLevel(curLegendItem, num, out canLevelUp);
		int num2 = fakeLegendItemLevel - curLegendItem.LegendItemData.EnhanceLevel;
		return (num2 > 0) ? num2 : 0;
	}

	private string ComputeMainAttrEnhancedValue(string effectType, bool isPercent, string entryId, int levelAdd = 0)
	{
		int enhanceLevel = curLegendItem.LegendItemData.EnhanceLevel + levelAdd;
		int num = GetMainPropBaseValue(curLegendItem.LegendItemData.Data.Rarity, effectType);
		if (num == 0)
		{
			num = (curLegendItem.LegendItemData.MainEntries?[0]?.Attributes?[0])?.Value ?? 0;
		}
		string enhanceConfig = curLegendItem.LegendItemData.Data.EnhanceConfig;
		if (!string.IsNullOrEmpty(enhanceConfig))
		{
			LegendItemEnhancementConfig enhanceConfig2 = LegendItemEnhancementConfig.GetEnhanceConfig(enhanceConfig, enhanceLevel);
			if (enhanceConfig2 != null)
			{
				string text = effectType;
				if (isPercent)
				{
					text += "_PCT";
				}
				if (enhanceConfig2.EnhancedAttrs.TryGetValue(text, out var value))
				{
					num += value.Value;
				}
			}
		}
		float num2 = (isPercent ? ((float)num / 10000f / 100f) : ((float)num / 10000f));
		bool flag = isPercent || Modifier.NeedPercentConvertProcess(effectType);
		string entryValuePrecision = LanguagesManager.GetEntryValuePrecision(entryId);
		if (flag)
		{
			num2 *= 100f;
		}
		string text2;
		if (string.IsNullOrEmpty(entryValuePrecision))
		{
			text2 = Convert.ToInt32(num2).ToString();
		}
		else
		{
			text2 = num2.ToString(entryValuePrecision);
			if (text2.EndsWith("."))
			{
				text2 += "0";
			}
		}
		string text3 = "+" + text2;
		if (flag)
		{
			text3 += "%";
		}
		return text3;
	}

	private static int GetMainPropBaseValue(int rarity, string effectType)
	{
		if (string.IsNullOrEmpty(effectType))
		{
			return 0;
		}
		EnsurePayloadCaches();
		if (!_effectTypeToSuffix.TryGetValue(effectType, out var value))
		{
			return 0;
		}
		string key = $"ItemPropmain{rarity}{value}";
		if (!PropPayloadCache.TryGetValue(key, out var value2))
		{
			return 0;
		}
		return ParsePropValueToRawInt(value2.Value);
	}

	internal static void EnsurePayloadCaches()
	{
		if (PropPayloadCache != null)
		{
			return;
		}
		PropPayloadCache = new Dictionary<string, PropPayloadEntry>();
		_effectTypeToSuffix = new Dictionary<string, string>();
		foreach (GDELegendItemPropertyData allItem in GDMgr.GetAllItems<GDELegendItemPropertyData>())
		{
			if (string.IsNullOrEmpty(allItem.Payload))
			{
				continue;
			}
			List<PropPayloadEntry> list = JsonHelper.ToObject<List<PropPayloadEntry>>(allItem.Payload);
			if (list == null || list.Count == 0)
			{
				continue;
			}
			PropPayloadEntry propPayloadEntry = list[0];
			if (string.IsNullOrEmpty(propPayloadEntry.Key))
			{
				continue;
			}
			if (!PropPayloadCache.ContainsKey(allItem.Key))
			{
				PropPayloadCache[allItem.Key] = propPayloadEntry;
			}
			if (allItem.Key.StartsWith("ItemPropmain") && !_effectTypeToSuffix.ContainsKey(propPayloadEntry.Key))
			{
				int num = allItem.Key.LastIndexOf('_');
				if (num >= 0)
				{
					_effectTypeToSuffix[propPayloadEntry.Key] = allItem.Key.Substring(num);
				}
			}
		}
	}

	private static int ParsePropValueToRawInt(string valStr)
	{
		if (string.IsNullOrEmpty(valStr))
		{
			return 0;
		}
		if (valStr.EndsWith("%"))
		{
			return Mathf.RoundToInt(NumericParser.Float(valStr.TrimEnd('%')) * 10000f);
		}
		return Mathf.RoundToInt(NumericParser.Float(valStr) * 10000f);
	}

	private void OnLegendItemSelected(LegendItemUi selectedItem)
	{
		selectedSwapItem = selectedItem;
		List<ItemEntry> mainEntries = selectedItem.LegendItemData.MainEntries;
		if (mainEntries != null && mainEntries.Count > 0)
		{
			repAttribute.AttributeContent.SetSelectedIndex(1);
			((GObject)repAttribute.primeAttribute).text = GetSwapMainAttrText(mainEntries[0]);
		}
		else
		{
			repAttribute.AttributeContent.SetSelectedIndex(0);
		}
		GDELegendItemData data = selectedItem.LegendItemData.Data;
		UI_LegendItemReplace uI_LegendItemReplace = treasureIcon;
		((GComponent)uI_LegendItemReplace).GetController("TypeController").selectedIndex = 0;
		((GComponent)uI_LegendItemReplace).GetChild("Level").text = string.Empty;
		((GComponent)uI_LegendItemReplace).GetChild("FrameIcon").asLoader.url = $"ui://PublicResources/frame_treasure_square_{data.Rarity}";
		((GComponent)uI_LegendItemReplace).GetChild("LvFrame").asLoader.url = string.Empty;
		((GComponent)uI_LegendItemReplace).GetChild("Icon").asLoader.LoadArmsIcon(data.Icon);
		Controller controller = ((GComponent)uI_LegendItemReplace).GetController("ClassController");
		if (controller != null)
		{
			controller.selectedIndex = data.Rarity - 1;
		}
		readyToSwap.SetSelectedIndex((selectedSwapItem != null) ? 1 : 0);
		RenderCostItem();
	}

	private void OnClickConfirm()
	{
		if (selectedSwapItem == null)
		{
			"SwapLegendItemTip2".ToLanguage().ToTip();
		}
		else if (CheckMainSubConflict())
		{
			"SwapLegendItemTip3".ToLanguage().ToTip();
		}
		else if (CheckSufficientStock())
		{
			ShowConfirmDialog();
		}
	}

	private bool CheckSufficientStock()
	{
		int stock = GameManagers.Instance.StockController.GetStock(_swapCostKey);
		return stock >= _swapCostCount;
	}

	private bool CheckMainSubConflict()
	{
		List<ItemEntry> mainEntries = selectedSwapItem.LegendItemData.MainEntries;
		if (mainEntries == null || mainEntries.Count == 0)
		{
			return false;
		}
		HashSet<string> hashSet = new HashSet<string>();
		foreach (ItemEntry item in mainEntries)
		{
			if (item.Attributes == null)
			{
				continue;
			}
			foreach (ItemEntryData attribute in item.Attributes)
			{
				if (!string.IsNullOrEmpty(attribute.Key))
				{
					hashSet.Add(attribute.Key);
				}
			}
		}
		if (hashSet.Count == 0)
		{
			return false;
		}
		List<ItemEntry> list = new List<ItemEntry>();
		if (curLegendItem.LegendItemData.MainEntries != null)
		{
			list.AddRange(curLegendItem.LegendItemData.MainEntries);
		}
		if (curLegendItem.LegendItemData.SubEntries != null)
		{
			list.AddRange(curLegendItem.LegendItemData.SubEntries);
		}
		foreach (ItemEntry item2 in list)
		{
			if (item2.Attributes == null)
			{
				continue;
			}
			foreach (ItemEntryData attribute2 in item2.Attributes)
			{
				if (!string.IsNullOrEmpty(attribute2.Key) && hashSet.Contains(attribute2.Key))
				{
					return true;
				}
			}
		}
		return false;
	}

	private void ShowConfirmDialog()
	{
		string arg = "";
		if (curLegendItem.LegendItemData.MainEntries != null && curLegendItem.LegendItemData.MainEntries.Count > 0)
		{
			string legendItemMainPropetryKeyText = LegendItemsHelper.GetLegendItemMainPropetryKeyText(curLegendItem);
			arg = legendItemMainPropetryKeyText + LegendItemsHelper.GetLegendItemNextEnhanceLevelValue(curLegendItem);
		}
		string arg2 = "";
		if (selectedSwapItem.LegendItemData.MainEntries != null && selectedSwapItem.LegendItemData.MainEntries.Count > 0)
		{
			arg2 = GetSwapMainAttrText(selectedSwapItem.LegendItemData.MainEntries[0]);
		}
		string arg3 = selectedSwapItem.LegendItemData.Data?.Name ?? selectedSwapItem.LegendItemData.ItemId;
		string tipText = string.Format("SwapLegendItemTip4".ToLanguage(), arg3, arg, arg2);
		tipText.ToConfirmPopup(OnConfirmSwap, null, (AlignType)0);
	}

	private void OnConfirmSwap()
	{
		if (selectedSwapItem == null)
		{
			return;
		}
		UI_LegendItemCultivationPanel parentPanel = (UI_LegendItemCultivationPanel)(object)((GObject)this).parent;
		((GObject)parentPanel.LegendItemReplaceAnim).visible = true;
		ILRequestHelper<LegendItemEnhancementSwapMainResponse>.Request((EventContext)null, (Func<Task<LegendItemEnhancementSwapMainResponse>>)(() => GameController.Contexts.Service<INetworkService>().LegendItemEnhancementSwapMain(curLegendItem.InstanceId, selectedSwapItem.InstanceId)), (Action<LegendItemEnhancementSwapMainResponse>)delegate(LegendItemEnhancementSwapMainResponse response)
		{
			if (response.ErrorCode != 0)
			{
				((GObject)parentPanel.LegendItemReplaceAnim).visible = false;
				ILRequestHelper.ShowErrorCode(response.ErrorCode);
			}
			else
			{
				if (response.TargetItem != null)
				{
					curLegendItem.UpdateFromApiModel(response.TargetItem);
				}
				LegendItemUi swappedItem = selectedSwapItem;
				string legendItemMainPropetryKeyText = LegendItemsHelper.GetLegendItemMainPropetryKeyText(curLegendItem);
				string newText = legendItemMainPropetryKeyText + LegendItemsHelper.GetLegendItemNextEnhanceLevelValue(curLegendItem);
				LegendItemsHelper.LegendItems.RemoveAll((LegendItemUi item) => item.InstanceId == swappedItem.InstanceId);
				GameManagers.Instance.StockController.ReadStockChangeRecords(response.StockChangeRecords);
				UI_LegendItemCultivationPanel.CurLegendItemData = curLegendItem;
				selectedSwapItem = null;
				PlaySwapAnimation(newText, swappedItem);
			}
		});
	}

	private void PlaySwapAnimation(string newText, LegendItemUi swappedItem)
	{
		//IL_0100: Unknown result type (might be due to invalid IL or missing references)
		//IL_010a: Expected O, but got Unknown
		UI_LegendItemCultivationPanel parentPanel = (UI_LegendItemCultivationPanel)(object)((GObject)this).parent;
		if (curLegendItem != null && curLegendItem.LegendItemData != null && curLegendItem.LegendItemData.Data != null)
		{
			parentPanel.LegendItemReplaceAnim.LegendItem.LoadArmsIcon(curLegendItem.LegendItemData.Data.Icon);
		}
		if (swappedItem != null && swappedItem.LegendItemData != null && swappedItem.LegendItemData.Data != null)
		{
			parentPanel.LegendItemReplaceAnim.LegendItemReplace.LoadArmsIcon(swappedItem.LegendItemData.Data.Icon);
		}
		((GObject)treasureIcon).visible = false;
		((GObject)parentPanel.LegendItemReplaceAnim).visible = true;
		TransitionHook val = default(TransitionHook);
		PlayCompleteCallback val4 = default(PlayCompleteCallback);
		parentPanel.LegendItemReplaceAnim.ShowReplace.Play((PlayCompleteCallback)delegate
		{
			//IL_005e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0063: Unknown result type (might be due to invalid IL or missing references)
			//IL_0065: Expected O, but got Unknown
			//IL_006a: Expected O, but got Unknown
			//IL_0093: Unknown result type (might be due to invalid IL or missing references)
			//IL_0098: Unknown result type (might be due to invalid IL or missing references)
			//IL_009a: Expected O, but got Unknown
			//IL_009f: Expected O, but got Unknown
			((GObject)parentPanel.LegendItemReplaceAnim).visible = false;
			((GObject)treasureIcon).visible = true;
			readyToSwap.SetSelectedIndex(0);
			Transition changeText = curAttribute.ChangeText;
			TransitionHook obj = val;
			if (obj == null)
			{
				TransitionHook val2 = delegate
				{
					((GObject)curAttribute.primeAttribute).text = newText;
				};
				TransitionHook val3 = val2;
				val = val2;
				obj = val3;
			}
			changeText.SetHook("ChangeText", obj);
			Transition changeText2 = curAttribute.ChangeText;
			PlayCompleteCallback obj2 = val4;
			if (obj2 == null)
			{
				PlayCompleteCallback val5 = delegate
				{
					ResetAll();
					SharedMessenger.Broadcast("LEGEND_ITEM_MAIN_SWAPPED");
				};
				PlayCompleteCallback val6 = val5;
				val4 = val5;
				obj2 = val6;
			}
			changeText2.Play(obj2);
		});
	}
}
