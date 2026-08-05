using System.Collections.Generic;
using Assets.Scripts.UI;
using FairyGUI;
using FairyGUI.Utils;
using HotFix.Sources.Base.Sources.Scripts.GvG3UI.Interface;
using HotFix.Sources.Base.Sources.Scripts.GvG3UI.Model;
using Shift.Legion.Common.Managers;
using Shift.Legion.Common.Models;
using Shift.Legion.GvG.Common.Models;

namespace UI.GvGExpeditionHall;

public class UI_NormalBonusPanel : GComponent, IGvGExpeditionPopup
{
	public Controller IsShow;

	public GGraph Mask;

	public UI_com_NormalBonusDialog Dialog;

	public Transition Popup;

	public const string URL = "ui://k19peou7nroy3d";

	public static string Name = "UI_NormalBonusPanel";

	private GvGExpeditionHallModel Data;

	private UI_GvGExpeditionHallPanel ParentPanel;

	private List<RItem> Rewards;

	public static string GetURL()
	{
		return "ui://k19peou7nroy3d";
	}

	public static UI_NormalBonusPanel CreateInstance()
	{
		return (UI_NormalBonusPanel)(object)UIPackage.CreateObject("GvGExpeditionHall", "NormalBonusPanel");
	}

	public static UI_NormalBonusPanel CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_NormalBonusPanel).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://k19peou7nroy3d", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		IsShow = ((GComponent)this).GetController("IsShow");
		Mask = (GGraph)((GComponent)this).GetChild("Mask");
		Dialog = (UI_com_NormalBonusDialog)(object)((GComponent)this).GetChild("Dialog");
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
		((GObject)Mask).onClick.Set(new EventCallback0(OnInactivate));
	}

	public void UnregisterUiEventListeners()
	{
		((GObject)Mask).onClick.Clear();
	}

	public void OnActivate()
	{
		Render();
	}

	private void Render()
	{
		//IL_005b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0065: Expected O, but got Unknown
		GvGIZConfigModel gvGIZConfigModel = Data.IZConfigs[Data.SelectedIZIndex];
		if (gvGIZConfigModel.Rewards == null)
		{
			ILRuntimeDebug.LogError("[UI_NormalBonusPanel] Rewards is null");
			return;
		}
		Rewards = gvGIZConfigModel.Rewards;
		Dialog.ItemList.itemRenderer = (ListItemRenderer)delegate(int i, GObject o)
		{
			RenderRewardItem(i, (UI_btn_NormalItemBig)(object)o);
		};
		Dialog.ItemList.numItems = Rewards.Count;
	}

	private void RenderRewardItem(int i, UI_btn_NormalItemBig item)
	{
		//IL_0092: Unknown result type (might be due to invalid IL or missing references)
		//IL_009c: Expected O, but got Unknown
		RItem rItem = Rewards[i];
		string itemId = rItem.ItemId;
		((GObject)item.ItemName).text = Item.Name(GameManagers.Instance, itemId);
		int num = Item.Level(GameManagers.Instance, itemId);
		string iconFrameBorder = UiHelper.GetIconFrameBorder(2, (num < 1) ? 1 : num);
		FGUIManager.Instance.SetItemIconAndFrame(item.icon, itemId, null, iconFrameBorder, frameVisible: false);
		((GObject)item).onClick.Set((EventCallback0)delegate
		{
			FGUIManager.Instance.ItemTip(itemId, ((GObject)this).sortingOrder, noCheckBtn: true, reserveRes: false, ParentPanel, isPack: true);
		});
	}

	public void OnInactivate()
	{
		IsShow.selectedIndex = 0;
	}
}
