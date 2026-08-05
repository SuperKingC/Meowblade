using System;
using System.Collections.Generic;
using System.Linq;
using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;
using HotFix.Sources.Base.Scripts.Helper;
using HotFix.Sources.Base.Sources.Scripts.GvG3.GvG3UI.UI.GvGWorldMapPanel.Model;
using HotFix.Sources.Base.Sources.Scripts.GvG3Common.Model;
using HotFix.Sources.Base.Sources.Scripts.GvG3WorldMap.Manager;
using HotFix.Sources.Utils;
using Shift.Legion.Common.Helpers;
using Shift.Legion.Common.Managers;
using Shift.Legion.GvGServer.Models.GvGMode3IslandManagerSocket.Ship;
using UI.PublicResources;
using UnityEngine;

namespace UI.GvGWorldMap3;

public class UI_com_ShipPlanOperationDialog : GComponent
{
	public Controller State;

	public GImage n0;

	public GImage n28;

	public GImage n29;

	public GImage n25;

	public GLoader OperationIcon;

	public GTextField Tip;

	public GTextField n4;

	public GTextField n38;

	public GTextField n10;

	public GLoader n36;

	public GTextField FoodCost;

	public GButton FoodBuff;

	public GGroup NormalCost;

	public GList Legions;

	public GImage n62;

	public GButton Help;

	public GImage n65;

	public GTextField n66;

	public GGroup n68;

	public UI_com_OemCount ChangeAttackCount;

	public GButton RepeatedAttack;

	public Transition t0;

	public const string URL = "ui://4eq8fgd2efz66scq";

	public static string Name = "UI_com_ShipPlanOperationDialog";

	private string _shipId;

	private int _islandId;

	private Action _returnMainUi;

	private List<ShipPlanSoldier> _soldiers;

	private RealTimeFoodCostReduceModel _foodCostReduce;

	private int _foodCost;

	private int _代理作战RemainingCount;

	private C2S_CreateShipPlan.Request _request;

	private bool _foodIsNotEnough;

	private int _maxAttackCount;

	private readonly BindableProperty<int> _attackCount = new BindableProperty<int>();

	private const int ATTACK_COUNT_IS_INVALID = -108317;

	private const int SOLDIER_COUNT_IS_NOT_ENOUGH = -108318;

	private const int FOOD_IS_NOT_ENOUGH = -108316;

	private const int ATTACK_COUNT_EXCEED_CONFIG_LIMIT = -108315;

	private const int SOLDIER_LIMIT_ERROR = 81610101;

	private const int 代理作战_COUNT_IS_NOT_ENOUGH = -108310;

	private const string GVG3_CHECK_SHIP_PLAN_HELPER = "GVG3_CHECK_SHIP_PLAN_HELPER";

	private readonly List<int> _attackCountTips = new List<int>();

	public static string GetURL()
	{
		return "ui://4eq8fgd2efz66scq";
	}

	public static UI_com_ShipPlanOperationDialog CreateInstance()
	{
		return (UI_com_ShipPlanOperationDialog)(object)UIPackage.CreateObject("GvGWorldMap3", "com_ShipPlanOperationDialog");
	}

	public static UI_com_ShipPlanOperationDialog CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_ShipPlanOperationDialog).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://4eq8fgd2efz66scq", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		//IL_007e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0088: Expected O, but got Unknown
		//IL_0094: Unknown result type (might be due to invalid IL or missing references)
		//IL_009e: Expected O, but got Unknown
		//IL_00e7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f1: Expected O, but got Unknown
		//IL_013a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0144: Expected O, but got Unknown
		//IL_018d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0197: Expected O, but got Unknown
		//IL_01e0: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ea: Expected O, but got Unknown
		//IL_01f6: Unknown result type (might be due to invalid IL or missing references)
		//IL_0200: Expected O, but got Unknown
		//IL_020c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0216: Expected O, but got Unknown
		//IL_0222: Unknown result type (might be due to invalid IL or missing references)
		//IL_022c: Expected O, but got Unknown
		//IL_0238: Unknown result type (might be due to invalid IL or missing references)
		//IL_0242: Expected O, but got Unknown
		//IL_024e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0258: Expected O, but got Unknown
		//IL_0264: Unknown result type (might be due to invalid IL or missing references)
		//IL_026e: Expected O, but got Unknown
		//IL_027a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0284: Expected O, but got Unknown
		//IL_0290: Unknown result type (might be due to invalid IL or missing references)
		//IL_029a: Expected O, but got Unknown
		//IL_02e5: Unknown result type (might be due to invalid IL or missing references)
		//IL_02ef: Expected O, but got Unknown
		//IL_0311: Unknown result type (might be due to invalid IL or missing references)
		//IL_031b: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		State = ((GComponent)this).GetController("State");
		n0 = (GImage)((GComponent)this).GetChild("n0");
		n28 = (GImage)((GComponent)this).GetChild("n28");
		n29 = (GImage)((GComponent)this).GetChild("n29");
		n25 = (GImage)((GComponent)this).GetChild("n25");
		OperationIcon = (GLoader)((GComponent)this).GetChild("OperationIcon");
		Tip = (GTextField)((GComponent)this).GetChild("Tip");
		string id = "ui://4eq8fgd2efz66scq".Replace("ui://", "") + "-" + ((GObject)Tip).id;
		((GObject)Tip).text = LanguagesManager.GetDesc(id);
		n4 = (GTextField)((GComponent)this).GetChild("n4");
		string id2 = "ui://4eq8fgd2efz66scq".Replace("ui://", "") + "-" + ((GObject)n4).id;
		((GObject)n4).text = LanguagesManager.GetDesc(id2);
		n38 = (GTextField)((GComponent)this).GetChild("n38");
		string id3 = "ui://4eq8fgd2efz66scq".Replace("ui://", "") + "-" + ((GObject)n38).id;
		((GObject)n38).text = LanguagesManager.GetDesc(id3);
		n10 = (GTextField)((GComponent)this).GetChild("n10");
		string id4 = "ui://4eq8fgd2efz66scq".Replace("ui://", "") + "-" + ((GObject)n10).id;
		((GObject)n10).text = LanguagesManager.GetDesc(id4);
		n36 = (GLoader)((GComponent)this).GetChild("n36");
		FoodCost = (GTextField)((GComponent)this).GetChild("FoodCost");
		FoodBuff = (GButton)((GComponent)this).GetChild("FoodBuff");
		NormalCost = (GGroup)((GComponent)this).GetChild("NormalCost");
		Legions = (GList)((GComponent)this).GetChild("Legions");
		n62 = (GImage)((GComponent)this).GetChild("n62");
		Help = (GButton)((GComponent)this).GetChild("Help");
		n65 = (GImage)((GComponent)this).GetChild("n65");
		n66 = (GTextField)((GComponent)this).GetChild("n66");
		string id5 = "ui://4eq8fgd2efz66scq".Replace("ui://", "") + "-" + ((GObject)n66).id;
		((GObject)n66).text = LanguagesManager.GetDesc(id5);
		n68 = (GGroup)((GComponent)this).GetChild("n68");
		ChangeAttackCount = (UI_com_OemCount)(object)((GComponent)this).GetChild("ChangeAttackCount");
		RepeatedAttack = (GButton)((GComponent)this).GetChild("RepeatedAttack");
		t0 = ((GComponent)this).GetTransition("t0");
	}

	public void RegisterEvent()
	{
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_001d: Expected O, but got Unknown
		//IL_0030: Unknown result type (might be due to invalid IL or missing references)
		//IL_003a: Expected O, but got Unknown
		//IL_0052: Unknown result type (might be due to invalid IL or missing references)
		//IL_005c: Expected O, but got Unknown
		//IL_0074: Unknown result type (might be due to invalid IL or missing references)
		//IL_007e: Expected O, but got Unknown
		//IL_0096: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a0: Expected O, but got Unknown
		//IL_00b3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bd: Expected O, but got Unknown
		//IL_00e3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ed: Expected O, but got Unknown
		((GObject)Help).onClick.Set(new EventCallback0(DisplayHelpPanel));
		((GObject)RepeatedAttack).onClick.Set(new EventCallback0(OpenConfirmPanel));
		((GObject)ChangeAttackCount.ReduceBtn).onClick.Set(new EventCallback0(OnReduceClick));
		((GObject)ChangeAttackCount.AddBtn).onClick.Set(new EventCallback0(OnAddBtnClick));
		((GObject)ChangeAttackCount.MaxBtn).onClick.Set(new EventCallback0(OnMaxBtnClick));
		((GObject)FoodBuff).onClick.Set(new EventCallback1(ShowFoodCostReduceText));
		_attackCount.AddAction(OnAttackCountChange);
		Legions.itemRenderer = new ListItemRenderer(SoldierRenderer);
	}

	public void UnregisterEvent()
	{
		((GObject)Help).onClick.Clear();
		((GObject)RepeatedAttack).onClick.Clear();
		((GObject)ChangeAttackCount.ReduceBtn).onClick.Clear();
		((GObject)ChangeAttackCount.AddBtn).onClick.Clear();
		((GObject)ChangeAttackCount.MaxBtn).onClick.Clear();
		((GObject)FoodBuff).onClick.Clear();
		_attackCount.RemoveAction(OnAttackCountChange);
	}

	public void Init(Action eventCallback)
	{
		_returnMainUi = eventCallback;
	}

	public void Display(int islandId, EventCallback0 displayTransition)
	{
		_islandId = islandId;
		State.SetSelectedIndex(0);
		if (displayTransition != null)
		{
			displayTransition.Invoke();
		}
		TryOpenHelper();
	}

	public void DisplayOnSelectShip(string shipId, List<ShipPlanSoldier> soldiers)
	{
		_shipId = shipId;
		_soldiers = soldiers;
		_attackCount.Value = -1;
		InitRequest();
		GetCreateShipPlanRequirement();
	}

	public void Hide()
	{
		_islandId = 0;
		State.SetSelectedIndex(0);
	}

	private static void DisplayHelpPanel()
	{
		UI_main_RepeatedAttackPlanHelper.Open();
	}

	private static void TryOpenHelper()
	{
		if (!GameLocalDataManager.GetBool("GVG3_CHECK_SHIP_PLAN_HELPER"))
		{
			DisplayHelpPanel();
			GameLocalDataManager.SetBool("GVG3_CHECK_SHIP_PLAN_HELPER", value: true);
		}
	}

	private void CalculateMaxCounts()
	{
		int num = "GvGMode3ShipOperationPlanMaxAttackCount".ToConfiguration<int>();
		int num2 = CalculateLimitMax();
		List<int> list = new List<int> { num, _代理作战RemainingCount, num2 };
		list.Sort();
		_maxAttackCount = list[0];
		if (num == _maxAttackCount)
		{
			_attackCountTips.Add(-108315);
		}
		if (num2 == _maxAttackCount)
		{
			_attackCountTips.Add(81610101);
		}
		if (_代理作战RemainingCount == _maxAttackCount)
		{
			_attackCountTips.Add(-108310);
		}
	}

	private bool CheckAttackCountExceedMax(int count)
	{
		if (count <= _maxAttackCount)
		{
			return false;
		}
		ILRequestHelper.ShowErrorCode(_attackCountTips[0]);
		return true;
	}

	private int CalculateLimitMax()
	{
		int limit = GameManagers.Instance.StockController.GetLimit("S001");
		int islandComeAgainSoldierStockLimitIncrement = GameManagers.Instance.UserArchiveManager.GetIslandComeAgainSoldierStockLimitIncrement();
		int num = limit + Mathf.Abs(GameManagers.Instance.UserArchiveManager.GetGvGShipPlanSoldiersStockLimitOccupiedValue()) - islandComeAgainSoldierStockLimitIncrement;
		int num2 = "GvGMode3ShipPlanSoldierReservedStockLimit".ToConfiguration<int>();
		int occupiedLimit = num - num2;
		List<int> list = _soldiers.Select((ShipPlanSoldier s) => s.CalculateMaxCount(occupiedLimit)).ToList();
		list.Sort();
		return list[0];
	}

	private void OnReduceClick()
	{
		int value = Mathf.Max(_attackCount.Value - 1, 0);
		_attackCount.Value = value;
	}

	private void OnAddBtnClick()
	{
		int num = _attackCount.Value + 1;
		if (!CheckAttackCountExceedMax(num))
		{
			_attackCount.Value = num;
		}
	}

	private void OnMaxBtnClick()
	{
		int value = _attackCount.Value;
		if (!CheckAttackCountExceedMax(value + 1))
		{
			_attackCount.Value = value + Mathf.Min(10, _maxAttackCount - value);
		}
	}

	private void OnAttackCountChange(int count)
	{
		if (count >= 0)
		{
			((GObject)ChangeAttackCount.AttackCount).text = count.ToString();
			SetTeamCount(count);
			RenderSoldiers();
			_foodIsNotEnough = RenderFoodCost(count);
		}
	}

	private void OpenConfirmPanel()
	{
		if (CanRepeatedAttack())
		{
			C2S_CreateShipPlan.Request request = UpdateRequest();
			int foodCost = _foodCost * _attackCount.Value;
			UI_main_CreateRepeatedAttackPlan.OpenCreateDialog(request, foodCost, _soldiers, _shipId, _islandId, _returnMainUi);
		}
	}

	private void InitRequest()
	{
		_request = new C2S_CreateShipPlan.Request
		{
			ShipId = _shipId,
			PlanType = 0,
			TargetIslandId = _islandId
		};
	}

	private C2S_CreateShipPlan.Request UpdateRequest()
	{
		_request.PlanAttackCount = _attackCount.Value;
		_request.TakeOutSoldier = _soldiers.Select((ShipPlanSoldier s) => s.ToTakeOutInfo()).ToList();
		return _request;
	}

	private bool CanRepeatedAttack()
	{
		if (_attackCount.Value <= 0)
		{
			ILRequestHelper.ShowErrorCode(-108317);
			return false;
		}
		if (_soldiers.Any((ShipPlanSoldier soldier) => !soldier.StockIsEnough()))
		{
			ILRequestHelper.ShowErrorCode(-108318);
			return false;
		}
		if (_foodIsNotEnough)
		{
			ILRequestHelper.ShowErrorCode(-108316);
			return false;
		}
		return true;
	}

	private void SetTeamCount(int teamCount)
	{
		foreach (ShipPlanSoldier soldier in _soldiers)
		{
			soldier.ChangeTeamCount(teamCount);
		}
	}

	private void RenderSoldiers()
	{
		Legions.numItems = _soldiers.Count;
	}

	private void SoldierRenderer(int index, GObject obj)
	{
		if (obj is UI_com_ShipPlanSoldier uI_com_ShipPlanSoldier)
		{
			uI_com_ShipPlanSoldier.RenderSoldier(_soldiers[index]);
		}
	}

	private void ShowFoodCostReduceText(EventContext context)
	{
		//IL_000e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0014: Expected O, but got Unknown
		//IL_0024: Unknown result type (might be due to invalid IL or missing references)
		//IL_002a: Unknown result type (might be due to invalid IL or missing references)
		context.StopPropagation();
		GObject target = (GObject)context.sender;
		FairyGUITip.ShowTip(target, eFairyGUITipDir.Up, delegate(UI_com_UniversalPopupTip popup)
		{
			((GObject)popup.title).text = _foodCostReduce.GetEfficiencyText();
		});
	}

	private bool RenderFoodCost(int count)
	{
		int foodOnboardCount = Singleton<WorldStateManager>.Instance.TryGetMyShip(_shipId).FoodOnboardCount;
		int num = _foodCost * count;
		bool flag = foodOnboardCount < num;
		string arg = (flag ? "#ff1919" : "#FFF2CC");
		((GObject)FoodCost).text = $"[color={arg}]{foodOnboardCount}[/color]/{num}";
		return flag;
	}

	private void RenderFoodBuff()
	{
		((GObject)FoodBuff).visible = _foodCostReduce.Total > 0f;
		((GObject)FoodBuff).enabled = true;
	}

	private void GetCreateShipPlanRequirement()
	{
		SocketManager.Instance.GetConnection(eConType.GvGMode3IslandManager).Request(new C2S_GetCreateShipPlanRequirement
		{
			Req = new C2S_GetCreateShipPlanRequirement.Request
			{
				ShipId = _shipId,
				TargetIslandId = _islandId
			}
		}, delegate(SocketManager.BaseSocketPackageBodyContext contextResponse)
		{
			C2S_GetCreateShipPlanRequirement.Response response = (C2S_GetCreateShipPlanRequirement.Response)contextResponse.Resp;
			if (response.ErrorCode != 0)
			{
				ILRequestHelper.ShowErrorCode(response.ErrorCode);
			}
			else
			{
				ReadResponse(response);
				CalculateMaxCounts();
				RenderFoodBuff();
				_attackCount.Value = 0;
				State.SetSelectedIndex(1);
			}
		});
	}

	private void ReadResponse(C2S_GetCreateShipPlanRequirement.Response res)
	{
		_foodCost = res.FoodCost;
		_foodCostReduce = res.Model;
		_代理作战RemainingCount = res.代理作战Count;
	}
}
