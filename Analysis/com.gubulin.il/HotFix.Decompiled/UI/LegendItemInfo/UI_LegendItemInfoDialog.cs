using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Assets.Scripts.Managers;
using Assets.Scripts.UI;
using FairyGUI;
using FairyGUI.Utils;
using GameDataEditor;
using HotFix.Sources.Base.Scripts.Helper;
using HotFix.Sources.Base.Scripts.Utils;
using HotFix.Sources.Base.Sources.Scripts.GvG3WorldMap.Manager;
using Shift.Legion.ClientApi.Models;
using Shift.Legion.ClientApi.Protocol.Modules.SoldierLegendItem;
using Shift.Legion.Common.Helpers;
using Shift.Legion.Common.Managers;
using Shift.Legion.Common.Services;
using UI.LegendItemBlueprint;
using UI.LegendItemCultivation;
using UI.LegendItems;
using UI.PvpSelectSoldiers;
using UI.SoldierCultivate;
using UI.Tips;
using UnityEngine;

namespace UI.LegendItemInfo;

public class UI_LegendItemInfoDialog : GComponent, IUiController
{
	public GGraph Mask;

	public UI_InfoDialog Dialog;

	public Transition ShowDialog;

	public const string URL = "ui://lzvt5p2vv5cz0";

	public static string Name = "UI_LegendItemInfoDialog";

	public static LegendItemInfoDialogInfo DialogInfo;

	private Action _changeAction;

	private const int LockedErrorCode = 81311514;

	private List<string> textureList = new List<string>();

	private LegendItemUi curItemData;

	private LegendItemsHelper.BlackMarketLegendItem curBlackLegendItemData;

	private LegendItemBrief curLegendItemBriefData;

	private string soldierId;

	private int slotIndex;

	private List<EntryText> EntriesTexts = new List<EntryText>();

	private int forgeLegendItemType;

	private bool canChangeLockState;

	private static string HIDDEN_FIELD_TEMPLATE => string.Format("<font color=\"#AC9D78\">{0}</font><font color=\"#66FF66\">（{1}{2}{3}）</font>", LanguagesManager.GetDesc("CsharpCodeZhTcText56"), LanguagesManager.GetDesc("CsharpCodeZhTcText319"), 0, LanguagesManager.GetDesc("CsharpCodeZhTcText320"));

	public static string GetURL()
	{
		return "ui://lzvt5p2vv5cz0";
	}

	public static UI_LegendItemInfoDialog CreateInstance()
	{
		return (UI_LegendItemInfoDialog)(object)UIPackage.CreateObject("LegendItemInfo", "LegendItemInfoDialog");
	}

	public static UI_LegendItemInfoDialog CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_LegendItemInfoDialog).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://lzvt5p2vv5cz0", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		Mask = (GGraph)((GComponent)this).GetChild("Mask");
		Dialog = (UI_InfoDialog)(object)((GComponent)this).GetChild("Dialog");
		ShowDialog = ((GComponent)this).GetTransition("ShowDialog");
	}

	public void BeforeDestroy()
	{
		DialogInfo?.ClearDialogInfo();
		UiTagManager instance = UiTagManager.Instance;
		instance.Unregister("LegendItem.Cultivation", Dialog.cultivation);
	}

	public void Destroy()
	{
	}

	public void Init(Dictionary<string, object> parameters)
	{
		FGUIManager.SetUiPanelSizeAndXy((GObject)(object)this);
		((GObject)this).sortingOrder = 1;
		if (DialogInfo == null)
		{
			End();
			return;
		}
		curItemData = DialogInfo.Item;
		Dialog.Type.selectedIndex = DialogInfo.TypeIndex;
		soldierId = DialogInfo.SoldierId;
		slotIndex = DialogInfo.SlotIndex;
		curBlackLegendItemData = DialogInfo.ItemData;
		curLegendItemBriefData = DialogInfo.ItemBrief;
		forgeLegendItemType = DialogInfo.ForgeLegendItemType;
		canChangeLockState = DialogInfo.CanChangeLockState;
		if (parameters != null && parameters.TryGetValue("DialogX", out var value))
		{
			((GObject)Dialog).x = (float)value;
		}
		if (parameters != null)
		{
			_changeAction = (parameters.TryGetValue("ChangeAction", out var value2) ? (value2 as Action) : null);
		}
		SetExchangeBtnState();
		DialogRender();
		void SetExchangeBtnState()
		{
			object value3;
			bool flag = parameters != null && parameters.TryGetValue("GvGModeCanChange", out value3) && !(bool)value3;
			Dialog.ExchangeBtnState.SetSelectedIndex(flag ? 1 : 0);
		}
	}

	public void OnShow()
	{
		ShowDialog.Play();
		UiTagManager instance = UiTagManager.Instance;
		instance.Register("LegendItem.Cultivation", Dialog.cultivation);
		Dialog.SetButtonTitle();
	}

	public void RegisterUiEventListeners()
	{
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_001d: Expected O, but got Unknown
		//IL_0035: Unknown result type (might be due to invalid IL or missing references)
		//IL_003f: Expected O, but got Unknown
		//IL_0057: Unknown result type (might be due to invalid IL or missing references)
		//IL_0061: Expected O, but got Unknown
		//IL_0079: Unknown result type (might be due to invalid IL or missing references)
		//IL_0083: Expected O, but got Unknown
		//IL_009b: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a5: Expected O, but got Unknown
		//IL_00bd: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c7: Expected O, but got Unknown
		//IL_00df: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e9: Expected O, but got Unknown
		((GObject)Mask).onClick.Add(new EventCallback0(End));
		((GObject)Dialog.change).onClick.Add(new EventCallback1(OpenLegendItemsPanel));
		((GObject)Dialog.equipBtn).onClick.Add(new EventCallback1(ConfirmSelect));
		((GObject)Dialog.cultivation).onClick.Add(new EventCallback1(OpenLegendItemCultivationPanel));
		((GObject)Dialog.ConfirmCostItem).onClick.Add(new EventCallback1(ConfirmSelectForgeItem));
		((GObject)Dialog.CancelForge).onClick.Add(new EventCallback1(CancelSelectedForgeItem));
		((GObject)Dialog.Lock).onClick.Add(new EventCallback1(ChangeLegendItemLockState));
	}

	public void UnregisterUiEventListeners()
	{
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_001d: Expected O, but got Unknown
		//IL_0035: Unknown result type (might be due to invalid IL or missing references)
		//IL_003f: Expected O, but got Unknown
		//IL_0057: Unknown result type (might be due to invalid IL or missing references)
		//IL_0061: Expected O, but got Unknown
		//IL_0079: Unknown result type (might be due to invalid IL or missing references)
		//IL_0083: Expected O, but got Unknown
		//IL_009b: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a5: Expected O, but got Unknown
		//IL_00bd: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c7: Expected O, but got Unknown
		//IL_00df: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e9: Expected O, but got Unknown
		((GObject)Mask).onClick.Remove(new EventCallback0(End));
		((GObject)Dialog.change).onClick.Remove(new EventCallback1(OpenLegendItemsPanel));
		((GObject)Dialog.equipBtn).onClick.Remove(new EventCallback1(ConfirmSelect));
		((GObject)Dialog.cultivation).onClick.Remove(new EventCallback1(OpenLegendItemCultivationPanel));
		((GObject)Dialog.ConfirmCostItem).onClick.Remove(new EventCallback1(ConfirmSelectForgeItem));
		((GObject)Dialog.CancelForge).onClick.Remove(new EventCallback1(CancelSelectedForgeItem));
		((GObject)Dialog.Lock).onClick.Remove(new EventCallback1(ChangeLegendItemLockState));
	}

	private void End()
	{
		GameController.Contexts.Service<IUiService>().ClosePanel(Name);
		for (int i = 0; i < textureList.Count; i++)
		{
			AssetsManager.Instance.UnloadAsset<Texture2D>(textureList[i]);
		}
	}

	private void CancelSelectedForgeItem(EventContext context)
	{
		SharedMessenger.Broadcast("UPDATE_FORGE_LEGENDITEM", new ForgeSelectLegendItem
		{
			InstanceId = -1L,
			Slot = slotIndex,
			ItemType = forgeLegendItemType
		});
		End();
	}

	private void ConfirmSelectForgeItem(EventContext context)
	{
		if (DialogInfo.TypeIndex == 8)
		{
			DialogInfo.CallbackForType8?.Invoke();
			End();
		}
		else if (forgeLegendItemType == 1 && curItemData.LegendItemData.Locked)
		{
			ILRequestHelper.ShowErrorCode(81311514);
		}
		else if (curItemData.LegendItemData.Data.Rarity == 6)
		{
			GameController.Contexts.Service<IUiService>().OpenPanel(UI_main_LegendItemEvoConfirm.Name, new Dictionary<string, object> { { "MainLegendItemId", curItemData.InstanceId } });
			End();
		}
		else
		{
			SharedMessenger.Broadcast("UPDATE_FORGE_LEGENDITEM", new ForgeSelectLegendItem
			{
				InstanceId = curItemData.InstanceId,
				Slot = slotIndex,
				ItemType = forgeLegendItemType
			});
			End();
		}
	}

	private void ChangeLegendItemLockState(EventContext context)
	{
		((GObject)Dialog.Lock.n6).SetPivot(0.5f, 0.5f);
		((GObject)Dialog.Lock.n7).SetPivot(0.5f, 0.5f);
		lockSizeChange(Dialog.Lock.n6);
		lockSizeChange(Dialog.Lock.n7);
		LegendItemsHelper.LockLegendItem(curItemData, UpdateLockState);
	}

	private void lockSizeChange(GImage clickarea)
	{
		EffectHelper.PlayCoroutineEffect(1f, delegate(float effectTime, float totalEffecTime)
		{
			float num = effectTime / totalEffecTime;
			float num2 = ((float)Math.Sin(num * 5f) * 0.5f + 0.5f) * 0.4f + 1f;
			((GObject)clickarea).scaleX = num2;
			((GObject)clickarea).scaleY = num2;
		}, delegate
		{
			((GObject)clickarea).scaleX = 1f;
			((GObject)clickarea).scaleY = 1f;
		});
	}

	private void UpdateLockState()
	{
		((GObject)Dialog.Lock).visible = canChangeLockState;
		if (canChangeLockState)
		{
			Dialog.Lock.Status.selectedIndex = (curItemData.LegendItemData.Locked ? 1 : 0);
			UI_LegendItemsPanel.LegendItemsPanel?.RenderUiContent();
			SharedMessenger.Broadcast("UPDATE_FORGE_SELECT_LEGENDITEM_LIST");
		}
	}

	private void ConfirmSelect(EventContext context)
	{
		if (curItemData.InstanceId != UI_LegendItemsPanel.OpenPanelInfo?.itemId)
		{
			if (curItemData.InstanceId == 0)
			{
				TakeOffLegendItem();
			}
			else
			{
				WaerLegendItem();
			}
		}
		UI_LegendItemsPanel.LegendItemsPanel?.End();
		End();
	}

	private void OpenLegendItemsPanel(EventContext context)
	{
		if (_changeAction != null)
		{
			_changeAction?.Invoke();
			End();
			return;
		}
		LegendItemsShowType showType = LegendItemsShowType.Choice;
		if (Dialog.Type.selectedIndex == 4)
		{
			showType = LegendItemsShowType.TopTopTournamentChoice;
		}
		else if (Dialog.Type.selectedIndex == 7)
		{
			showType = LegendItemsShowType.GvGModeChoice;
		}
		if (showType == LegendItemsShowType.GvGModeChoice)
		{
			Action();
		}
		else
		{
			Action();
		}
		void Action()
		{
			LegendItemsHelper.OpenLegendItemBlueprintListPanel(OpenItemsPanel);
		}
		void OpenItemsPanel()
		{
			UI_LegendItemsPanel.OpenPanelInfo = new LegendItemsPanelInfo(showType, DialogInfo.Item.InstanceId, soldierId, slotIndex, DialogInfo.FromShipEntityId);
			GameController.Contexts.Service<IUiService>().OpenPanel(UI_LegendItemsPanel.Name, null);
			End();
		}
	}

	private void WaerLegendItem()
	{
		if (Dialog.Type.selectedIndex == 4)
		{
			LegendItemsHelper.WearOperationTop(ActionFoo, curItemData, slotIndex, soldierId);
		}
		else if (DialogInfo.ShowType == LegendItemsShowType.GvGModeChoice)
		{
			Singleton<WorldStateManager>.Instance.GVGSoldierWear(soldierId, slotIndex, curItemData.InstanceId, DialogInfo.FromShipEntityId);
		}
		else
		{
			LegendItemsHelper.WearOperationDevelop(ActionBar, curItemData, slotIndex, soldierId);
		}
		void ActionBar()
		{
			string lastSoldierId = "";
			if (LegendItemsHelper.EquippedLegendItems.ContainsKey(curItemData.InstanceId.ToString()) && LegendItemsHelper.EquippedLegendItems[curItemData.InstanceId.ToString()] != soldierId)
			{
				lastSoldierId = LegendItemsHelper.EquippedLegendItems[curItemData.InstanceId.ToString()];
			}
			ILRequestHelper<SoldierWearLegendItemResponse>.Request((EventContext)null, (Func<Task<SoldierWearLegendItemResponse>>)(() => GameController.Contexts.Service<INetworkService>().SoldierWearLegendItem(soldierId, slotIndex, curItemData.InstanceId)), (Action<SoldierWearLegendItemResponse>)delegate(SoldierWearLegendItemResponse response)
			{
				if (!response.Result)
				{
					ILRequestHelper.ShowErrorCode(response.ErrorCode);
				}
				else
				{
					LegendItemsHelper.ReplaceSoldierEquip(curItemData.InstanceId);
					LegendItemsHelper.UpdateSoldiersEquippedItems(soldierId, response.Items);
					UI_SoldierCultivate.SoldierCultivatePanel?.LegendItemButtonsInit();
					UI_SoldierCultivate.SoldierCultivatePanel?.FlashingSlot(slotIndex);
					UI_SoldierCultivate.SoldierCultivatePanel?.RefreshSoldierDetailInfo(GameManagers.Instance.SoldierManager.Get(soldierId));
					UI_SoldierCultivate.SoldierCultivatePanel?.WaitToRefreshCombatPower(_isUpGrade: false);
					UI_SoldierCultivate.legendItemsChanged = true;
					UI_SoldierCultivate.lastLegendItemSoldierId = lastSoldierId;
					BroadcastGvGShipLegendItemsChange();
				}
			});
		}
		void ActionFoo()
		{
			UI_PeakBattleSelectArrayPanel.PeakBattleSelectArrayPanel?.UpdateSoldierLegendItems(soldierId, slotIndex, curItemData.InstanceId);
			UI_SelectServerWideBattleArrayPanel.Instance?.UpdateSoldierLegendItems(soldierId, slotIndex, curItemData.InstanceId);
		}
	}

	private void TakeOffLegendItem()
	{
		if (Dialog.Type.selectedIndex == 4)
		{
			UI_PeakBattleSelectArrayPanel.PeakBattleSelectArrayPanel?.UpdateOnTakeOffLegendItem(soldierId, slotIndex);
			UI_SelectServerWideBattleArrayPanel.Instance?.UpdateOnTakeOffLegendItem(soldierId, slotIndex);
			return;
		}
		ILRequestHelper<SoldierTakeOffLegendItemResponse>.Request((EventContext)null, (Func<Task<SoldierTakeOffLegendItemResponse>>)(() => GameController.Contexts.Service<INetworkService>().SoldierTakeOffLegendItem(soldierId, slotIndex)), (Action<SoldierTakeOffLegendItemResponse>)delegate(SoldierTakeOffLegendItemResponse response)
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
				LegendItemsHelper.UpdateSoldiersEquippedItems(soldierId, response.Items);
				UI_SoldierCultivate.SoldierCultivatePanel?.LegendItemButtonsInit();
				UI_SoldierCultivate.legendItemsChanged = true;
				BroadcastGvGShipLegendItemsChange();
			}
		});
	}

	private void BroadcastGvGShipLegendItemsChange()
	{
		SharedMessenger.Broadcast("ON_SHIP_LEGEND_ITEM_CHANGE");
	}

	private void OpenLegendItemCultivationPanel(EventContext context)
	{
		LegendItemsHelper.OpenSelectLegendItems(OpenPanel);
		void OpenPanel()
		{
			Dictionary<string, object> parameters = new Dictionary<string, object> { { "LegendItem", curItemData } };
			GameController.Contexts.Service<IUiService>().OpenPanel(UI_LegendItemCultivationPanel.Name, parameters);
			End();
		}
	}

	private void DialogRender()
	{
		if (curItemData != null)
		{
			((GObject)Dialog.title0).text = LegendItemsHelper.GetLegendItemNameTitle(curItemData.LegendItemData.Data.Name, curItemData.LegendItemData.EnhanceLevel);
			Dialog.ClassController.selectedIndex = curItemData.LegendItemData.Data.Rarity - 1;
			string legendItemMainPropetryKeyText = LegendItemsHelper.GetLegendItemMainPropetryKeyText(curItemData);
			((GObject)Dialog.primeAttribute).text = legendItemMainPropetryKeyText + LegendItemsHelper.GetLegendItemNextEnhanceLevelValue(curItemData);
			SecondaryAspectsRender();
			((GComponent)Dialog).GetChild("score").text = $"{curItemData.LegendItemData.Score}";
			UiHelper.RenderLegendItem(Dialog.Icon, curItemData, UiHelper.TextColorType.Dark, textureList, 0);
			((GComponent)Dialog.Icon).GetController("ClassController").selectedIndex = Dialog.ClassController.selectedIndex;
		}
		else if (curBlackLegendItemData != null)
		{
			((GObject)Dialog.title0).text = LegendItemsHelper.GetLegendItemNameTitle(curBlackLegendItemData.Name, curBlackLegendItemData.ItemData.EnhanceLevel);
			Dialog.ClassController.selectedIndex = curBlackLegendItemData.Rarity - 1;
			if (curBlackLegendItemData.ItemData.MainEntries != null)
			{
				string legendItemMainPropetryKeyText2 = LegendItemsHelper.GetLegendItemMainPropetryKeyText(curBlackLegendItemData.ItemData);
				((GObject)Dialog.primeAttribute).text = legendItemMainPropetryKeyText2 + LegendItemsHelper.GetLegendItemNextEnhanceLevelValue(curBlackLegendItemData.ItemData);
			}
			else
			{
				((GObject)Dialog.primeAttribute).text = "RandomMainEntryTip".ToLanguage();
			}
			SecondaryAspectsRender();
			((GComponent)Dialog).GetChild("score").text = curBlackLegendItemData.Score ?? "";
			UiHelper.RenderLegendItem(Dialog.Icon, curBlackLegendItemData, textureList);
			((GComponent)Dialog.Icon).GetController("ClassController").selectedIndex = Dialog.ClassController.selectedIndex;
		}
		else if (curLegendItemBriefData != null && LegendItemManager.LegendItemTemplates.ContainsKey(curLegendItemBriefData.ItemId))
		{
			GDELegendItemData gDELegendItemData = LegendItemManager.LegendItemTemplates[curLegendItemBriefData.ItemId];
			((GObject)Dialog.title0).text = LegendItemsHelper.GetLegendItemNameTitle(gDELegendItemData.Name, curLegendItemBriefData.EnhanceLevel);
			Dialog.ClassController.selectedIndex = gDELegendItemData.Rarity - 1;
			string legendItemMainPropetryKeyText3 = LegendItemsHelper.GetLegendItemMainPropetryKeyText(curLegendItemBriefData);
			((GObject)Dialog.primeAttribute).text = legendItemMainPropetryKeyText3 + LegendItemsHelper.GetLegendItemNextEnhanceLevelValue(curLegendItemBriefData, gDELegendItemData.Rarity);
			SecondaryAspectsRender();
			((GComponent)Dialog).GetChild("score").text = $"{curLegendItemBriefData.Score}";
			UiHelper.RenderLegendItem(Dialog.Icon, curLegendItemBriefData, UiHelper.TextColorType.Dark, textureList);
			((GComponent)Dialog.Icon).GetController("ClassController").selectedIndex = Dialog.ClassController.selectedIndex;
		}
		((GComponent)Dialog.Icon).GetChild("name").visible = false;
		((GComponent)Dialog.Icon).GetChild("LvFrame").visible = false;
		((GComponent)Dialog.Icon).GetChild("Level").visible = false;
		((GComponent)Dialog.Icon).GetChild("ClassList").visible = false;
		if (Dialog.Type.selectedIndex == 5 || Dialog.Type.selectedIndex == 6)
		{
			UpdateLockState();
		}
	}

	private void RenderAllEntries()
	{
		//IL_02f6: Unknown result type (might be due to invalid IL or missing references)
		//IL_0300: Expected O, but got Unknown
		EntriesTexts.Clear();
		((GObject)Dialog.Entries).visible = true;
		((GObject)Dialog.Content).visible = false;
		string text = string.Empty;
		List<string> list = new List<string>();
		string text2 = string.Empty;
		if (curItemData != null)
		{
			text = LegendItemsHelper.GetSubEntries(curItemData).Replace("%[/color] ", "%[/color]  ");
			list = LegendItemsHelper.GetFxEntries(curItemData.LegendItemData);
			text2 = LegendItemsHelper.GetSuitDesc(curItemData.LegendItemData);
		}
		if (curBlackLegendItemData != null)
		{
			text = LegendItemsHelper.GetSubEntries(curBlackLegendItemData);
			list = LegendItemsHelper.GetFxEntries(curBlackLegendItemData.ItemData);
			text2 = LegendItemsHelper.GetSuitDesc(curBlackLegendItemData);
		}
		if (curLegendItemBriefData != null)
		{
			string[] array = LegendItemsHelper.GetSubEntries(curLegendItemBriefData).Split('\n');
			int num = curLegendItemBriefData.EnhanceLevel / 5;
			for (int i = 0; i < array.Length; i++)
			{
				string text3 = ((i <= num) ? array[i] : string.Format(HIDDEN_FIELD_TEMPLATE, i * 5));
				text3 += ((i != array.Length - 1) ? "\n" : "");
				text += text3;
			}
			list = LegendItemsHelper.GetFxEntries(curLegendItemBriefData);
			text2 = LegendItemsHelper.GetSuitDesc(curLegendItemBriefData);
		}
		if (!string.IsNullOrEmpty(text))
		{
			EntriesTexts.Add(new EntryText
			{
				TextType = 0,
				Text = text
			});
		}
		else if (DialogInfo.IsPreviewMode)
		{
			EntriesTexts.Add(new EntryText
			{
				TextType = 0,
				Text = "RandomSubEntryTip".ToLanguage()
			});
		}
		for (int j = 0; j < list.Count; j++)
		{
			EntriesTexts.Add(new EntryText
			{
				TextType = 1,
				Text = list[j]
			});
		}
		if (DialogInfo.IsPreviewMode && list.Count <= 0 && curBlackLegendItemData != null)
		{
			bool flag = !string.IsNullOrEmpty(curBlackLegendItemData.SetId);
			bool flag2 = curBlackLegendItemData.Rarity >= 5;
			if (flag && flag2)
			{
				EntriesTexts.Add(new EntryText
				{
					TextType = 1,
					Text = "RandomEffectTip1".ToLanguage()
				});
			}
		}
		if (!string.IsNullOrEmpty(text2))
		{
			EntriesTexts.Add(new EntryText
			{
				TextType = 2,
				Text = text2
			});
		}
		Dialog.Entries.itemRenderer = new ListItemRenderer(RenderEntry);
		Dialog.Entries.numItems = EntriesTexts.Count;
	}

	private void RenderEntry(int index, GObject obj)
	{
		//IL_008c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0096: Expected O, but got Unknown
		if (obj is UI_com_Propetry uI_com_Propetry)
		{
			EntryText entryText = EntriesTexts[index];
			uI_com_Propetry.State.selectedIndex = entryText.TextType;
			uI_com_Propetry.SetControllerPageText();
			uI_com_Propetry.GetControllerText(entryText.TextType);
			((GObject)uI_com_Propetry.content).text = entryText.Text;
			uI_com_Propetry.Type.selectedIndex = ((index != EntriesTexts.Count - 1) ? 1 : 0);
			((GObject)uI_com_Propetry.content).onClickLink.Set(new EventCallback1(OnClickEffectLink));
		}
	}

	public void SecondaryAspectsRender()
	{
		if (curItemData != null)
		{
			if (curItemData.LegendItemData.SubEntries == null || curItemData.LegendItemData.SubEntries.Count == 0)
			{
				return;
			}
		}
		else if (curBlackLegendItemData != null)
		{
			if (!DialogInfo.IsPreviewMode && (curBlackLegendItemData.ItemData.SubEntries == null || curBlackLegendItemData.ItemData.SubEntries.Count == 0))
			{
				return;
			}
		}
		else if (curLegendItemBriefData != null && (curLegendItemBriefData.SubEntries == null || curLegendItemBriefData.SubEntries.Count == 0))
		{
			return;
		}
		RenderAllEntries();
	}

	private void OnClickEffectLink(EventContext e)
	{
		GameController.Contexts.Service<IUiService>().OpenPanel(UI_SkillEffectPanel.Name, new Dictionary<string, object> { 
		{
			"EffectKey",
			e.data.ToString()
		} });
	}

	private void SetPropetryText(int index, GButton btn)
	{
		//IL_001f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0029: Expected O, but got Unknown
		GRichTextField asRichTextField = ((GComponent)btn).GetChild("content").asRichTextField;
		((GObject)asRichTextField).onClickLink.Set(new EventCallback1(OnClickEffectLink));
		if (curItemData != null)
		{
			switch (index)
			{
			case 0:
				((GObject)asRichTextField).text = LegendItemsHelper.GetSubEntries(curItemData).Replace("%[/color] ", "%[/color]  ");
				break;
			case 1:
				if (curItemData.LegendItemData.FxEntries == null || curItemData.LegendItemData.FxEntries.Count == 0)
				{
					((GObject)btn).visible = false;
					((GObject)btn).height = 0f;
					((GComponent)Dialog.Content).EnsureBoundsCorrect();
					((GObject)btn).y = ((GObject)btn).y - 20f;
				}
				else
				{
					((GObject)asRichTextField).text = LegendItemsHelper.GetEntries(curItemData.LegendItemData.FxEntries, isFxEntry: true);
				}
				break;
			case 2:
				if (string.IsNullOrWhiteSpace(curItemData.LegendItemData.Data.SetId))
				{
					((GObject)btn).visible = false;
					((GObject)btn).height = 0f;
				}
				else
				{
					((GObject)asRichTextField).text = LegendItemsHelper.GetSuitDesc(curItemData.LegendItemData);
					((GObject)btn).visible = true;
				}
				break;
			}
		}
		else if (curBlackLegendItemData != null)
		{
			switch (index)
			{
			case 0:
				((GObject)asRichTextField).text = LegendItemsHelper.GetSubEntries(curBlackLegendItemData);
				break;
			case 1:
				if (curBlackLegendItemData.ItemData.FxEntries == null || curBlackLegendItemData.ItemData.FxEntries.Count == 0)
				{
					((GObject)btn).visible = false;
					((GObject)btn).height = 0f;
					((GObject)btn).y = ((GObject)btn).y - 20f;
				}
				else
				{
					((GObject)asRichTextField).text = LegendItemsHelper.GetEntries(curBlackLegendItemData.ItemData.FxEntries, isFxEntry: true);
				}
				break;
			case 2:
				if (string.IsNullOrWhiteSpace(curBlackLegendItemData.SetId))
				{
					((GObject)btn).visible = false;
					((GObject)btn).height = 0f;
				}
				else
				{
					((GObject)asRichTextField).text = LegendItemsHelper.GetSuitDesc(curBlackLegendItemData);
					((GObject)btn).visible = true;
				}
				break;
			}
		}
		else
		{
			if (curLegendItemBriefData == null)
			{
				return;
			}
			switch (index)
			{
			case 0:
			{
				string[] array = LegendItemsHelper.GetSubEntries(curLegendItemBriefData).Split('\n');
				((GObject)asRichTextField).text = "";
				int num = curLegendItemBriefData.EnhanceLevel / 5;
				for (int i = 0; i < array.Length; i++)
				{
					string text = ((i <= num) ? array[i] : string.Format(HIDDEN_FIELD_TEMPLATE, i * 5));
					text += ((i != array.Length - 1) ? "\n" : "");
					((GObject)asRichTextField).text = ((GObject)asRichTextField).text + text;
				}
				break;
			}
			case 1:
				if (curLegendItemBriefData.FxEntries == null || curLegendItemBriefData.FxEntries.Count == 0)
				{
					((GObject)btn).visible = false;
					((GObject)btn).height = 0f;
					((GObject)btn).y = ((GObject)btn).y - 20f;
				}
				else
				{
					((GObject)asRichTextField).text = LegendItemsHelper.GetEntries(curLegendItemBriefData.FxEntries, isFxEntry: true);
				}
				break;
			case 2:
				if (LegendItemManager.LegendItemTemplates.ContainsKey(curLegendItemBriefData.ItemId) && !string.IsNullOrWhiteSpace(LegendItemManager.LegendItemTemplates[curLegendItemBriefData.ItemId].SetId))
				{
					((GObject)asRichTextField).text = LegendItemsHelper.GetSuitDataDesc(LegendItemManager.LegendItemTemplates[curLegendItemBriefData.ItemId].SetId);
					((GObject)btn).visible = true;
				}
				else
				{
					((GObject)btn).visible = false;
					((GObject)btn).height = 0f;
				}
				break;
			}
		}
	}

	private void AspectsRender(GObject obj, string desc)
	{
		GButton asButton = obj.asButton;
		asButton.title = desc;
	}
}
