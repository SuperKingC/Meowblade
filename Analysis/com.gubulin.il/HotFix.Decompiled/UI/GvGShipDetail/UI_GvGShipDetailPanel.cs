using System;
using System.Collections.Generic;
using Assets.Scripts.Managers;
using Assets.Scripts.UI;
using FairyGUI;
using FairyGUI.Utils;
using HotFix.Sources.Base.Sources.Scripts.GvG3UI.Interface;
using HotFix.Sources.Base.Sources.Scripts.GvG3UI.Model;
using HotFix.Sources.Base.Sources.Scripts.GvG3WorldMap.Controller;
using HotFix.Sources.Base.Sources.Scripts.GvG3WorldMap.Extensions;
using HotFix.Sources.Base.Sources.Scripts.GvG3WorldMap.Manager;
using HotFix.Sources.Base.Sources.Scripts.GvG3WorldMap.Model;
using Shift.Legion.Common.Helpers;
using Shift.Legion.Common.Services;
using UI.GvGChangeShipName;
using UI.GvGShipLaunch;
using UI.GvGShipOverview;

namespace UI.GvGShipDetail;

public class UI_GvGShipDetailPanel : GComponent, IUiController
{
	public Controller PageController;

	public GLoader background;

	public GImage n98;

	public GImage n99;

	public GButton BackBtn;

	public UI_SummaryPage SummaryPage;

	public UI_ArmyPage ArmyPage;

	public UI_AmplifierPage AmplifierPage;

	public UI_WorkerPage WorkerPage;

	public GImage n95;

	public UI_com_ShipStatus ShipStatus;

	public GImage n89;

	public GImage n96;

	public GTextField Index;

	public GTextField ShipName;

	public UI_btn_ChangeNameBtn ChangeNameBtn;

	public GList Tabs;

	public GButton Help;

	public Transition TimeCounter1Scale;

	public Transition TipsWrapper;

	public Transition t2;

	public Transition t3;

	public const string URL = "ui://u6x0b1gnursm1b";

	public static string Name = "UI_GvGShipDetailPanel";

	public ShipStateModel StateData;

	public bool ShowNeedFillUpTip;

	private GvGShipDetailModel Data;

	private List<IGvGShipDetailPage> _Pages;

	private int LastPageIndex;

	private UICallbackParam<Action> Onclose;

	private const int ArmyPageIndex = 1;

	private const int WorkerPageIndex = 3;

	private const int SummaryPageIndex = 0;

	private const int AmplifierPageIndex = 2;

	private const string GvgMode3ShipGroupChanged = "GVG_MODE3_SHIP_GROUP_CHANGED";

	private bool _panelClosing;

	private List<IGvGShipDetailPage> Pages
	{
		get
		{
			if (_Pages == null)
			{
				_Pages = new List<IGvGShipDetailPage> { SummaryPage, ArmyPage, AmplifierPage, WorkerPage };
				for (int i = 0; i < _Pages.Count; i++)
				{
					_Pages[i].PageIndex = i;
				}
			}
			return _Pages;
		}
	}

	public static string GetURL()
	{
		return "ui://u6x0b1gnursm1b";
	}

	public static UI_GvGShipDetailPanel CreateInstance()
	{
		return (UI_GvGShipDetailPanel)(object)UIPackage.CreateObject("GvGShipDetail", "GvGShipDetailPanel");
	}

	public static UI_GvGShipDetailPanel CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_GvGShipDetailPanel).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://u6x0b1gnursm1b", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Expected O, but got Unknown
		//IL_003c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0046: Expected O, but got Unknown
		//IL_0052: Unknown result type (might be due to invalid IL or missing references)
		//IL_005c: Expected O, but got Unknown
		//IL_0068: Unknown result type (might be due to invalid IL or missing references)
		//IL_0072: Expected O, but got Unknown
		//IL_00d6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e0: Expected O, but got Unknown
		//IL_0102: Unknown result type (might be due to invalid IL or missing references)
		//IL_010c: Expected O, but got Unknown
		//IL_0118: Unknown result type (might be due to invalid IL or missing references)
		//IL_0122: Expected O, but got Unknown
		//IL_012e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0138: Expected O, but got Unknown
		//IL_0144: Unknown result type (might be due to invalid IL or missing references)
		//IL_014e: Expected O, but got Unknown
		//IL_01ad: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b7: Expected O, but got Unknown
		//IL_01c3: Unknown result type (might be due to invalid IL or missing references)
		//IL_01cd: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		PageController = ((GComponent)this).GetController("PageController");
		background = (GLoader)((GComponent)this).GetChild("background");
		n98 = (GImage)((GComponent)this).GetChild("n98");
		n99 = (GImage)((GComponent)this).GetChild("n99");
		BackBtn = (GButton)((GComponent)this).GetChild("BackBtn");
		SummaryPage = (UI_SummaryPage)(object)((GComponent)this).GetChild("SummaryPage");
		ArmyPage = (UI_ArmyPage)(object)((GComponent)this).GetChild("ArmyPage");
		AmplifierPage = (UI_AmplifierPage)(object)((GComponent)this).GetChild("AmplifierPage");
		WorkerPage = (UI_WorkerPage)(object)((GComponent)this).GetChild("WorkerPage");
		n95 = (GImage)((GComponent)this).GetChild("n95");
		ShipStatus = (UI_com_ShipStatus)(object)((GComponent)this).GetChild("ShipStatus");
		n89 = (GImage)((GComponent)this).GetChild("n89");
		n96 = (GImage)((GComponent)this).GetChild("n96");
		Index = (GTextField)((GComponent)this).GetChild("Index");
		ShipName = (GTextField)((GComponent)this).GetChild("ShipName");
		string id = "ui://u6x0b1gnursm1b".Replace("ui://", "") + "-" + ((GObject)ShipName).id;
		((GObject)ShipName).text = LanguagesManager.GetDesc(id);
		ChangeNameBtn = (UI_btn_ChangeNameBtn)(object)((GComponent)this).GetChild("ChangeNameBtn");
		Tabs = (GList)((GComponent)this).GetChild("Tabs");
		Help = (GButton)((GComponent)this).GetChild("Help");
		TimeCounter1Scale = ((GComponent)this).GetTransition("TimeCounter1Scale");
		TipsWrapper = ((GComponent)this).GetTransition("TipsWrapper");
		t2 = ((GComponent)this).GetTransition("t2");
		t3 = ((GComponent)this).GetTransition("t3");
	}

	public void Init(Dictionary<string, object> parameters)
	{
		FGUIManager.SetUiPanelSizeAndXy((GObject)(object)this);
		if (parameters.TryGetValue("OnClose", out var value))
		{
			Onclose = (UICallbackParam<Action>)value;
		}
		if (parameters.TryGetValue("GvGShipDetailModelData", out var value2))
		{
			Data = (GvGShipDetailModel)value2;
		}
		ShowNeedFillUpTip = parameters.TryGetValue("ShowFillUpTip", out var value3) && (bool)value3;
		LastPageIndex = (parameters.TryGetValue("ShowPageIndex", out var value4) ? ((int)value4) : 0);
		GList tabs = Tabs;
		int selectedIndex = (PageController.selectedIndex = LastPageIndex);
		tabs.selectedIndex = selectedIndex;
		StateData = Singleton<WorldStateManager>.Instance.TryGetShip(Data.EntityId);
		foreach (IGvGShipDetailPage page in Pages)
		{
			page.Init(Data, this);
		}
		Pages[LastPageIndex].OnActivate();
		UpdateShipName();
		UpdateShipState();
	}

	public void RegisterUiEventListeners()
	{
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_001d: Expected O, but got Unknown
		//IL_0030: Unknown result type (might be due to invalid IL or missing references)
		//IL_003a: Expected O, but got Unknown
		//IL_004d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0057: Expected O, but got Unknown
		//IL_006a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0074: Expected O, but got Unknown
		//IL_008c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0096: Expected O, but got Unknown
		//IL_00ae: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b8: Expected O, but got Unknown
		((GObject)BackBtn).onClick.Set(new EventCallback0(BackBtnClick));
		((GObject)Help).onClick.Set(new EventCallback0(OnHelpClick));
		Tabs.onClickItem.Set(new EventCallback1(TabOnClick));
		((GObject)ChangeNameBtn).onClick.Set(new EventCallback1(OnOpenChangeShipNamePanel));
		((GObject)ShipStatus.ToNearestBtn).onClick.Set(new EventCallback1(OnClickToNearestBtn));
		((GObject)ShipStatus.LiftoffBtn).onClick.Set(new EventCallback0(OnLaunch));
		foreach (IGvGShipDetailPage page in Pages)
		{
			page.RegisterUiEventListeners();
		}
		SharedMessenger.AddListener<string>("ON_GVG3_SHIP_LAUNCH", OnShipLaunched);
	}

	public void UnregisterUiEventListeners()
	{
		((GObject)BackBtn).onClick.Clear();
		((GObject)Help).onClick.Clear();
		Tabs.onClickItem.Clear();
		((GObject)ChangeNameBtn).onClick.Clear();
		((GObject)ShipStatus.ToNearestBtn).onClick.Clear();
		((GObject)ShipStatus.LiftoffBtn).onClick.Clear();
		foreach (IGvGShipDetailPage page in Pages)
		{
			page.UnregisterUiEventListeners();
		}
		SharedMessenger.RemoveListener<string>("ON_GVG3_SHIP_LAUNCH", OnShipLaunched);
	}

	private void OnHelpClick()
	{
		UiHelper.OpenHelpPage("飞空艇详情", "远征相关", "飞空艇相关");
	}

	public void UpdateWorkerTabHasNotice()
	{
		((UI_WorkerTab)(object)((GComponent)Tabs).GetChildAt(3)).HasNotice.selectedIndex = ((StateData.WorkersOnboardCount < 1) ? 1 : 0);
	}

	public void UpdateArmyTabHasNotice()
	{
		((UI_ArmyTab)(object)((GComponent)Tabs).GetChildAt(1)).HasNotice.selectedIndex = (StateData.ShipGroupHasNotice() ? 1 : 0);
	}

	private void TabOnClick(EventContext context)
	{
		foreach (IGvGShipDetailPage page in Pages)
		{
			if (LastPageIndex != page.PageIndex || !page.ConfigModified())
			{
				continue;
			}
			page.ConfirmOperationOnChangePage(ChangePage, RevertTabClick());
			return;
		}
		ChangePage();
	}

	private Action RevertTabClick()
	{
		return delegate
		{
			Tabs.selectedIndex = LastPageIndex;
		};
	}

	private void ChangePage()
	{
		PageController.selectedIndex = Tabs.selectedIndex;
		Pages[LastPageIndex].OnInactivate();
		LastPageIndex = PageController.selectedIndex;
		Pages[LastPageIndex].OnActivate();
	}

	private void OnOpenChangeShipNamePanel(EventContext context)
	{
		Dictionary<string, object> parameters = new Dictionary<string, object>
		{
			{ "ShipId", Data.ShipId },
			{
				"OnConfirm",
				new UICallbackParam<Action<string>>(OnConfirmName)
			}
		};
		GameController.Contexts.Service<IUiService>().OpenPanel(UI_GvGChangeShipNamePanel.Name, parameters);
	}

	private void OnConfirmName(string newName)
	{
		Data.RefreshName();
		UpdateShipName();
	}

	private void OnClickToNearestBtn(EventContext context)
	{
		IUiService uiService = GameController.Contexts.Service<IUiService>();
		if (uiService.HasShowingUi(UI_GvGShipOverviewPanel.Name))
		{
			uiService.ClosePanel(UI_GvGShipOverviewPanel.Name);
		}
		End();
		Singleton<WorldStateManager>.Instance.GetShipNearestFlagShipOrMoonIsland(Data.EntityId, delegate(int islandId)
		{
			GvGWorldMapController.Instance.FocusIslandById(islandId);
		});
	}

	private void OnLaunch()
	{
		Data.GetLaunchableIsland(OpenLaunchPanel);
		static void OpenLaunchPanel(GvGShipDetailModel shipDetailModel)
		{
			GameController.Contexts.Service<IUiService>().OpenPanel(UI_main_GvGShipLaunch.Name, new Dictionary<string, object> { { "ShipDetail", shipDetailModel } });
		}
	}

	private void UpdateOnShipGroupChange(ShipStateModel stateModel)
	{
		if (((GObject)this).isDisposed)
		{
			return;
		}
		foreach (IGvGShipDetailPage page in Pages)
		{
			int pageIndex = page.PageIndex;
			int num = pageIndex;
			if ((uint)(num - 2) > 1u)
			{
				page.OnShipStateChange();
			}
		}
		UpdateShipState();
		UpdateArmyTabHasNotice();
	}

	private void UpdateShipState()
	{
		ShipStatus.Status.selectedIndex = (int)StateData.UiState;
		if (ShipStatus.Status.selectedIndex != 0 && Data.StayIslandId > 0)
		{
			string stayIslandName = Data.StayIslandName;
			((GObject)ShipStatus.IslandName).text = stayIslandName;
		}
	}

	private void UpdateShipName()
	{
		((GObject)ShipName).text = Data.ShipName;
	}

	private void OnShipLaunched(string shipId)
	{
		if (!((GObject)this).isDisposed && !(shipId != Data.ShipId))
		{
			UpdateShipState();
		}
	}

	private void BackBtnClick()
	{
		foreach (IGvGShipDetailPage page in Pages)
		{
			page.OnDestroy();
			if (!page.ConfigModified())
			{
				continue;
			}
			page.ConfirmOperationOnClose(End);
			return;
		}
		End();
	}

	public void End()
	{
		GameController.Contexts.Service<IUiService>().ClosePanel(Name);
	}

	public void OnShow()
	{
		ShipStateModel stateData = StateData;
		stateData.OnGroupInfoChange = (Action<ShipStateModel>)Delegate.Combine(stateData.OnGroupInfoChange, new Action<ShipStateModel>(UpdateOnShipGroupChange));
		UpdateWorkerTabHasNotice();
		UpdateArmyTabHasNotice();
	}

	public void BeforeDestroy()
	{
		foreach (IGvGShipDetailPage page in Pages)
		{
			page.OnDestroy();
		}
		ShipStateModel stateData = StateData;
		stateData.OnGroupInfoChange = (Action<ShipStateModel>)Delegate.Remove(stateData.OnGroupInfoChange, new Action<ShipStateModel>(UpdateOnShipGroupChange));
	}

	public void Destroy()
	{
		Onclose?.Callback?.Invoke();
	}
}
