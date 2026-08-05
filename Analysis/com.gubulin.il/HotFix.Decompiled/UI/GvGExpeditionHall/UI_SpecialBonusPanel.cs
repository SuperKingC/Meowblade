using System.Collections.Generic;
using Assets.Scripts.Managers;
using Assets.Scripts.UI;
using FairyGUI;
using FairyGUI.Utils;
using HotFix.Sources.Base.Sources.Scripts.GvG3UI.Interface;
using HotFix.Sources.Base.Sources.Scripts.GvG3UI.Model;
using Shift.Legion.Common.Managers;
using Shift.Legion.Common.Models;
using Shift.Legion.Common.Services;
using Shift.Legion.GvG.Common.Models;
using Shift.Legion.Helpers;
using UI.LegendItemBlueprintTemplate;

namespace UI.GvGExpeditionHall;

public class UI_SpecialBonusPanel : GComponent, IGvGExpeditionPopup
{
	public Controller IsShow;

	public GGraph Mask;

	public UI_com_SpecialBonusDialog Dialog;

	public UI_com_DropDetailDialog DropDetailDialog;

	public Transition Popup;

	public const string URL = "ui://k19peou7qix93i";

	public static string Name = "UI_SpecialBonusPanel";

	private GvGExpeditionHallModel Data;

	private UI_GvGExpeditionHallPanel ParentPanel;

	private List<SpecialRewardItem> SpecialRewards;

	private List<RItem> SpecialRewards2;

	public static string GetURL()
	{
		return "ui://k19peou7qix93i";
	}

	public static UI_SpecialBonusPanel CreateInstance()
	{
		return (UI_SpecialBonusPanel)(object)UIPackage.CreateObject("GvGExpeditionHall", "SpecialBonusPanel");
	}

	public static UI_SpecialBonusPanel CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_SpecialBonusPanel).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://k19peou7qix93i", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		IsShow = ((GComponent)this).GetController("IsShow");
		Mask = (GGraph)((GComponent)this).GetChild("Mask");
		Dialog = (UI_com_SpecialBonusDialog)(object)((GComponent)this).GetChild("Dialog");
		DropDetailDialog = (UI_com_DropDetailDialog)(object)((GComponent)this).GetChild("DropDetailDialog");
		Popup = ((GComponent)this).GetTransition("Popup");
	}

	public void Init(GvGExpeditionHallModel data, UI_GvGExpeditionHallPanel parentPanel)
	{
		Data = data;
		ParentPanel = parentPanel;
	}

	public void RegisterUiEventListeners()
	{
		//IL_0014: Unknown result type (might be due to invalid IL or missing references)
		//IL_001e: Expected O, but got Unknown
		//IL_0036: Unknown result type (might be due to invalid IL or missing references)
		//IL_0040: Expected O, but got Unknown
		//IL_0058: Unknown result type (might be due to invalid IL or missing references)
		//IL_0062: Expected O, but got Unknown
		((GObject)Mask).onClick.Set(new EventCallback0(OnInactivate));
		((GObject)Dialog.CheckDropDetialBtn).onClick.Set(new EventCallback1(OnOpenDropDetailPanel));
		((GObject)DropDetailDialog.Mask).onClick.Set(new EventCallback1(OnCloseDropDetailPanel));
	}

	public void UnregisterUiEventListeners()
	{
		((GObject)Mask).onClick.Clear();
		((GObject)Dialog.CheckDropDetialBtn).onClick.Clear();
		((GObject)DropDetailDialog.Mask).onClick.Clear();
	}

	public void OnActivate()
	{
		Render();
	}

	private void Render()
	{
		//IL_00a8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b2: Expected O, but got Unknown
		//IL_010b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0115: Expected O, but got Unknown
		GvGIZConfigModel gvGIZConfigModel = Data.IZConfigs[Data.SelectedIZIndex];
		SpecialRewards = Data.GetGvGStoreRewardsPreview();
		if (SpecialRewards.Count < 1 || gvGIZConfigModel.SpecialRewards2 == null)
		{
			ILRuntimeDebug.LogError($"[UI_NormalBonusPanel] SpecialRewards Count {SpecialRewards.Count}, SpecialRewards2 is null={gvGIZConfigModel.SpecialRewards2 == null} ");
			return;
		}
		SpecialRewards2 = gvGIZConfigModel.SpecialRewards2;
		Dialog.ItemList.SpecialList2.itemRenderer = (ListItemRenderer)delegate(int i, GObject o)
		{
			RenderSpecialRewardsItem(SpecialRewards2[i], (UI_SpecialItem)(object)o);
		};
		Dialog.ItemList.SpecialList2.numItems = SpecialRewards2.Count;
		Dialog.ItemList.SpecialList2.ResizeToFit(SpecialRewards2.Count);
		Dialog.ItemList.SpecialList1.itemRenderer = (ListItemRenderer)delegate(int i, GObject o)
		{
			RenderSpecialRewardsItem(SpecialRewards[i], (UI_SpecialItem)(object)o);
		};
		Dialog.ItemList.SpecialList1.numItems = SpecialRewards.Count;
		Dialog.ItemList.SpecialList1.ResizeToFit(SpecialRewards.Count);
		if (Data.HasActiveGvGStoreDesc())
		{
			((GObject)Dialog.ItemList.RemainingTime).visible = true;
			((GObject)Dialog.ItemList.CountDown).text = GetRemainingTimeStr(Data.GetGvGStoreRemainingSeconds());
		}
		else
		{
			((GObject)Dialog.ItemList.RemainingTime).visible = false;
		}
	}

	private string GetRemainingTimeStr(int remainingSeconds)
	{
		if (remainingSeconds > 86400)
		{
			return string.Format("{0:F0} {1}", remainingSeconds / 86400, LanguagesManager.GetDesc("DateTime_Days"));
		}
		if (remainingSeconds > 3600)
		{
			return string.Format("{0:F0} {1}", remainingSeconds / 3600, LanguagesManager.GetDesc("DateTime_Hours"));
		}
		return string.Format("{0:F0} {1}", remainingSeconds / 60, LanguagesManager.GetDesc("DateTime_Minutes"));
	}

	private void RenderSpecialRewardsItem(RItem data, UI_SpecialItem item)
	{
		//IL_0085: Unknown result type (might be due to invalid IL or missing references)
		//IL_008f: Expected O, but got Unknown
		string itemId = data.ItemId;
		((GObject)item.ItemName).text = Item.Name(GameManagers.Instance, itemId);
		int num = Item.Level(GameManagers.Instance, itemId);
		string iconFrameBorder = UiHelper.GetIconFrameBorder(2, (num < 1) ? 1 : num);
		FGUIManager.Instance.SetItemIconAndFrame(item.icon, itemId, null, iconFrameBorder, frameVisible: false);
		((GObject)item).onClick.Set((EventCallback0)delegate
		{
			OnPopupSpecialRewardTip(itemId);
		});
	}

	private void OnPopupSpecialRewardTip(string itemId)
	{
		if (Item.ItemType(itemId) == 27)
		{
			ArchiveExtension_Formulas.GvGStoreItemInfo value = JsonHelper.ToObject<ArchiveExtension_Formulas.GvGStoreItemInfo>(Item.PostScript(itemId));
			GameController.Contexts.Service<IUiService>().OpenPanel(UI_main_LegendItemBlueprintTemplatePanel.Name, new Dictionary<string, object> { { "Info", value } });
		}
		else
		{
			FGUIManager.Instance.ItemTip(itemId, ((GObject)this).sortingOrder, noCheckBtn: true, reserveRes: false, ParentPanel, isPack: true);
		}
	}

	private void OnOpenDropDetailPanel(EventContext context)
	{
		IsShow.selectedIndex = 2;
		if (Data.HasActiveGvGStoreDesc())
		{
			DropDetailDialog.RewardType.selectedIndex = 1;
			for (int i = 0; i < SpecialRewards.Count; i++)
			{
				SpecialRewardItem specialRewardItem = SpecialRewards[i];
				UI_com_DropDetailItem uI_com_DropDetailItem = null;
				if (i < 3)
				{
					uI_com_DropDetailItem = DropDetailDialog.DynamicRewards1.AddItemFromPool() as UI_com_DropDetailItem;
				}
				else if (i < 6)
				{
					uI_com_DropDetailItem = DropDetailDialog.DynamicRewards2.AddItemFromPool() as UI_com_DropDetailItem;
				}
				else if (i < 9)
				{
					uI_com_DropDetailItem = DropDetailDialog.DynamicRewards3.AddItemFromPool() as UI_com_DropDetailItem;
				}
				if (uI_com_DropDetailItem != null)
				{
					((GObject)uI_com_DropDetailItem.itemName).text = specialRewardItem.NameText;
					((GObject)uI_com_DropDetailItem.itemRate).text = specialRewardItem.WeightText;
				}
			}
			((GObject)DropDetailDialog.CountDown).text = GetRemainingTimeStr(Data.GetGvGStoreRemainingSeconds());
		}
		else
		{
			DropDetailDialog.RewardType.selectedIndex = 0;
		}
	}

	private void OnCloseDropDetailPanel(EventContext context)
	{
		IsShow.selectedIndex = 1;
	}

	public void OnInactivate()
	{
		IsShow.selectedIndex = 0;
	}
}
