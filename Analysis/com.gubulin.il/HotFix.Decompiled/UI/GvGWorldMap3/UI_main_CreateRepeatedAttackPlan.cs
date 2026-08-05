using System;
using System.Collections.Generic;
using FairyGUI;
using FairyGUI.Utils;
using HotFix.Sources.Base.Scripts.Helper;
using HotFix.Sources.Base.Sources.Scripts.GvG3.GvG3UI.UI.GvGWorldMapPanel.Model;
using HotFix.Sources.Base.Sources.Scripts.GvG3UI.Helper;
using HotFix.Sources.Base.Sources.Scripts.GvG3UI.Manager;
using HotFix.Sources.Base.Sources.Scripts.GvG3WorldMap.Helper;
using Shift.Legion.Common.Helpers;
using Shift.Legion.Common.Managers;
using Shift.Legion.Common.Services;
using Shift.Legion.GvGServer.Models.GvGMode3IslandManagerSocket.Ship;

namespace UI.GvGWorldMap3;

public class UI_main_CreateRepeatedAttackPlan : GComponent, IUiController
{
	public GGraph back;

	public UI_com_ConfirmCreateRepeatedAttackPlan ConfirmDialog;

	public const string URL = "ui://4eq8fgd2efz66sd1";

	public static string Name = "UI_main_CreateRepeatedAttackPlan";

	private const string CREATE_SHIP_PLAN_REQUEST = "CreateShipPlanRequest";

	private const string CREATE_SHIP_PLAN_FOOD_COST = "CreateShipPlanFoodCost";

	private const string CREATE_SHIP_PLAN_TAKE_OUT_SOLDIERS = "CreateShipPlanTakeOutSoldiers";

	private const string CREATE_SHIP_PLAN_SHIP_ID = "CreateShipPlanShipId";

	private const string CREATE_SHIP_PLAN_ISLAND_ID = "CreateShipPlanIslandId";

	private const string CREATE_SHIP_PLAN_CALLBACK = "CREATE_SHIP_PLAN_CALLBACK";

	private const string GVG_MODE3_SHIP_REPEATED_ATTACK_PLAN_CREATE_TIP = "GvGMode3ShipRepeatedAttackPlanCreateTip";

	private C2S_CreateShipPlan.Request _request;

	private int _foodCost;

	private List<ShipPlanSoldier> _soldiers;

	private int _islandId;

	private string _shipId;

	private Action _callback;

	public static string GetURL()
	{
		return "ui://4eq8fgd2efz66sd1";
	}

	public static UI_main_CreateRepeatedAttackPlan CreateInstance()
	{
		return (UI_main_CreateRepeatedAttackPlan)(object)UIPackage.CreateObject("GvGWorldMap3", "main_CreateRepeatedAttackPlan");
	}

	public static UI_main_CreateRepeatedAttackPlan CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_main_CreateRepeatedAttackPlan).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://4eq8fgd2efz66sd1", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		back = (GGraph)((GComponent)this).GetChild("back");
		ConfirmDialog = (UI_com_ConfirmCreateRepeatedAttackPlan)(object)((GComponent)this).GetChild("ConfirmDialog");
	}

	public static void OpenCreateDialog(C2S_CreateShipPlan.Request request, int foodCost, List<ShipPlanSoldier> soldiers, string shipId, int islandId, Action callback)
	{
		Dictionary<string, object> parameters = new Dictionary<string, object>
		{
			{ "CreateShipPlanRequest", request },
			{ "CreateShipPlanFoodCost", foodCost },
			{ "CreateShipPlanTakeOutSoldiers", soldiers },
			{ "CreateShipPlanShipId", shipId },
			{ "CreateShipPlanIslandId", islandId },
			{ "CREATE_SHIP_PLAN_CALLBACK", callback }
		};
		GameController.Contexts.Service<IUiService>().OpenPanel(Name, parameters);
	}

	public UI_main_CreateRepeatedAttackPlan(List<ShipPlanSoldier> soldiers)
	{
		_soldiers = soldiers;
	}

	public void BeforeDestroy()
	{
	}

	public void Destroy()
	{
	}

	public void Init(Dictionary<string, object> parameters)
	{
		FGUIManager.SetUiPanelSizeAndXy((GObject)(object)this, scaleAdaption: true);
		ParseParameters(parameters);
		RenderUi();
	}

	public void OnShow()
	{
	}

	public void RegisterUiEventListeners()
	{
		//IL_0018: Unknown result type (might be due to invalid IL or missing references)
		//IL_0022: Expected O, but got Unknown
		//IL_003a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0044: Expected O, but got Unknown
		((GObject)ConfirmDialog.Confirm).onClick.Set(new EventCallback0(CreateShipPlan));
		((GObject)ConfirmDialog.Cancel).onClick.Set(new EventCallback0(End));
		S2C_CreateShipPlanSuccess.OnPushEvent = (Action<S2C_CreateShipPlanSuccess.Request>)Delegate.Combine(S2C_CreateShipPlanSuccess.OnPushEvent, new Action<S2C_CreateShipPlanSuccess.Request>(OnShipPlanCreateSuccess));
	}

	public void UnregisterUiEventListeners()
	{
		((GObject)ConfirmDialog.Confirm).onClick.Clear();
		((GObject)ConfirmDialog.Cancel).onClick.Clear();
		S2C_CreateShipPlanSuccess.OnPushEvent = (Action<S2C_CreateShipPlanSuccess.Request>)Delegate.Remove(S2C_CreateShipPlanSuccess.OnPushEvent, new Action<S2C_CreateShipPlanSuccess.Request>(OnShipPlanCreateSuccess));
	}

	private static void End()
	{
		GameController.Contexts.Service<IUiService>().ClosePanel(Name, reservePackageRes: true);
	}

	private void ParseParameters(Dictionary<string, object> parameters)
	{
		_request = (C2S_CreateShipPlan.Request)parameters["CreateShipPlanRequest"];
		string text = parameters["CreateShipPlanFoodCost"].ToString();
		_foodCost = int.Parse(parameters["CreateShipPlanFoodCost"].ToString());
		_soldiers = (List<ShipPlanSoldier>)parameters["CreateShipPlanTakeOutSoldiers"];
		_shipId = parameters["CreateShipPlanShipId"].ToString();
		_islandId = int.Parse(parameters["CreateShipPlanIslandId"].ToString());
		_callback = (Action)parameters["CREATE_SHIP_PLAN_CALLBACK"];
	}

	private void RenderUi()
	{
		RenderTip();
		RenderSoldiers();
		RenderFoodCost();
	}

	private void RenderSoldiers()
	{
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_001d: Expected O, but got Unknown
		ConfirmDialog.Legions.itemRenderer = new ListItemRenderer(SoldierRenderer);
		ConfirmDialog.Legions.numItems = _soldiers.Count;
	}

	private void RenderFoodCost()
	{
		((GObject)ConfirmDialog.FoodCost).text = $"{_foodCost}";
	}

	private void RenderTip()
	{
		string myShipName = Singleton<GvGMode3RoomManager>.Instance.ObserverRecord.GetMyShipName(_shipId);
		string text = WorldMapConfigHelper.Configs.TryGetIsland(_islandId)?.Name;
		((GObject)ConfirmDialog.Tip).text = "GvGMode3ShipRepeatedAttackPlanCreateTip".ToLanguage().Format(new object[3] { myShipName, text, _request.PlanAttackCount });
	}

	private void SoldierRenderer(int index, GObject obj)
	{
		if (obj is UI_com_ShipPlanSoldier uI_com_ShipPlanSoldier)
		{
			uI_com_ShipPlanSoldier.RenderSoldier(_soldiers[index]);
		}
	}

	private void CreateShipPlan()
	{
		SocketManager.Instance.GetConnection(eConType.GvGMode3IslandManager).Request(new C2S_CreateShipPlan
		{
			Req = _request
		}, delegate(SocketManager.BaseSocketPackageBodyContext contextResponse)
		{
			C2S_CreateShipPlan.Response response = (C2S_CreateShipPlan.Response)contextResponse.Resp;
			if (response.ErrorCode != 0)
			{
				ILRequestHelper.ShowErrorCode(response.ErrorCode);
				End();
			}
		});
		((GObject)ConfirmDialog.Confirm).touchable = false;
	}

	private void OnShipPlanCreateSuccess(S2C_CreateShipPlanSuccess.Request req)
	{
		if (req.ErrorCode != 0)
		{
			ILRequestHelper.ShowErrorCode(req.ErrorCode);
			End();
		}
		else
		{
			End();
			_callback?.Invoke();
		}
	}
}
