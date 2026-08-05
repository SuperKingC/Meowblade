using System;
using System.Collections.Generic;
using FairyGUI;
using FairyGUI.Utils;
using HotFix.Sources.Base.Sources.Scripts.GvG3Common.Manager;
using HotFix.Sources.Base.Sources.Scripts.GvG3UI.Manager;
using Shift.Legion.Common.Helpers;
using Shift.Legion.Common.Managers;
using Shift.Legion.Common.Models;
using Shift.Legion.Common.Services;
using Shift.Legion.Common.Sources.Enums;

namespace UI.GvG3SupplyDepot;

public class UI_main_SupplyDepot : GComponent, IUiController
{
	public GGraph Mask;

	public UI_com_SupplyDepot PopUp;

	public UI_main_ContributionReward ContributionRewardDetail;

	public const string URL = "ui://pobej4q7uado0";

	public static string Name = "UI_main_SupplyDepot";

	public static string GetURL()
	{
		return "ui://pobej4q7uado0";
	}

	public static UI_main_SupplyDepot CreateInstance()
	{
		return (UI_main_SupplyDepot)(object)UIPackage.CreateObject("GvG3SupplyDepot", "main_SupplyDepot");
	}

	public static UI_main_SupplyDepot CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_main_SupplyDepot).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://pobej4q7uado0", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		Mask = (GGraph)((GComponent)this).GetChild("Mask");
		PopUp = (UI_com_SupplyDepot)(object)((GComponent)this).GetChild("PopUp");
		ContributionRewardDetail = (UI_main_ContributionReward)(object)((GComponent)this).GetChild("ContributionRewardDetail");
	}

	public void BeforeDestroy()
	{
		PopUp.FoodStore.Destroy();
		PopUp.DailyReward.Destroy();
	}

	public void Destroy()
	{
	}

	public void Init(Dictionary<string, object> parameters)
	{
		FGUIManager.SetUiPanelSizeAndXy((GObject)(object)this, scaleAdaption: true);
		object value;
		int selectedIndex = (parameters.TryGetValue("FocusPageIndex", out value) ? ((int)value) : 0);
		PopUp.PageController.SetSelectedIndex(selectedIndex);
		Singleton<GvGStoreHouseManager>.Instance.SyncStoreHouse(delegate
		{
			PopUp.FoodStore.Init();
			PopUp.DailyReward.Init();
			SetDailySupplyBoxTabRedDot();
		});
	}

	public void OnShow()
	{
	}

	public void RegisterUiEventListeners()
	{
		//IL_0018: Unknown result type (might be due to invalid IL or missing references)
		//IL_0022: Expected O, but got Unknown
		((GObject)PopUp.Close).onClick.Set(new EventCallback0(End));
		PopUp.FoodStore.RegisterUiEvent();
		ContributionRewardDetail.RegisterUiEvent();
		PopUp.DailyReward.RegisterUiEvent();
		UI_com_DailyReward dailyReward = PopUp.DailyReward;
		dailyReward.ShowContributionBoxConfigAction = (Action)Delegate.Combine(dailyReward.ShowContributionBoxConfigAction, new Action(ShowContributionBoxConfigData));
		GvG3SupplyDepotManager instance = Singleton<GvG3SupplyDepotManager>.Instance;
		instance.UpdateUi = (Action)Delegate.Combine(instance.UpdateUi, new Action(SetDailySupplyBoxTabRedDot));
		SharedMessenger.AddListener<string, int, (StockInContext, string)>("ON_STOCK_CHANGE", OnStockChange);
		SharedMessenger.AddListener<string, int>("ON_GVGSTOREHOUSE_STOCK_CHANGE", OnStoreHouseChange);
	}

	public void UnregisterUiEventListeners()
	{
		((GObject)PopUp.Close).onClick.Clear();
		PopUp.FoodStore.UnregisterUiEvent();
		ContributionRewardDetail.UnregisterUiEvent();
		PopUp.DailyReward.UnregisterUiEvent();
		UI_com_DailyReward dailyReward = PopUp.DailyReward;
		dailyReward.ShowContributionBoxConfigAction = (Action)Delegate.Remove(dailyReward.ShowContributionBoxConfigAction, new Action(ShowContributionBoxConfigData));
		GvG3SupplyDepotManager instance = Singleton<GvG3SupplyDepotManager>.Instance;
		instance.UpdateUi = (Action)Delegate.Remove(instance.UpdateUi, new Action(SetDailySupplyBoxTabRedDot));
		SharedMessenger.RemoveListener<string, int, (StockInContext, string)>("ON_STOCK_CHANGE", OnStockChange);
		SharedMessenger.RemoveListener<string, int>("ON_GVGSTOREHOUSE_STOCK_CHANGE", OnStoreHouseChange);
	}

	private void End()
	{
		GameController.Contexts.Service<IUiService>().ClosePanel(Name);
	}

	private void SetDailySupplyBoxTabRedDot()
	{
		PopUp.DailySupplyBoxTab.RedDot.selectedIndex = (Singleton<GvG3SupplyDepotManager>.Instance.ContributionItemInfo.DailyRewardShowRedDot() ? 1 : 0);
	}

	private void ShowContributionBoxConfigData()
	{
		ContributionRewardDetail.Init();
	}

	private static void OnStockChange(string itemId, int incr, (StockInContext, string) contextTuple)
	{
		OnStoreHouseChange(itemId, incr);
	}

	private static void OnStoreHouseChange(string itemId, int incr)
	{
		if (incr > 0 && CanShow(itemId))
		{
			FGUIManager.Instance.ItemIdReplace(ref itemId);
			ILRequestHelper.ShowMessage($"{Item.Name(GameManagers.Instance, itemId)}+{incr}");
		}
	}

	private static bool CanShow(string itemId)
	{
		if (Item.ItemType(itemId) == 32)
		{
			goto IL_004c;
		}
		switch (itemId)
		{
		case "I32017":
		case "I32000":
		case "I32100":
		case "I32014":
			goto IL_004c;
		}
		int result = ((itemId == "I32013") ? 1 : 0);
		goto IL_004d;
		IL_004c:
		result = 1;
		goto IL_004d;
		IL_004d:
		return (byte)result != 0;
	}
}
