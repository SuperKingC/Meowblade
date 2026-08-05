using System;
using System.Collections.Generic;
using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;
using GameDataEditor;
using HotFix.Sources.Base.Scripts.Helper;
using HotFix.Sources.Base.Sources.Scripts.GvG3.GvG3UI.UI.GvGWorldMapPanel.Model;
using HotFix.Sources.Base.Sources.Scripts.GvG3Common.Model;
using HotFix.Sources.Base.Sources.Scripts.GvG3UI.Manager;
using HotFix.Sources.Base.Sources.Scripts.GvG3WorldMap.Manager;
using Shift.Legion.Common.Helpers;
using Shift.Legion.Common.Managers;
using Shift.Legion.Common.Models;
using Shift.Legion.Common.Services;
using Shift.Legion.GvG.Common.Models;
using Shift.Legion.GvGServer.Models.GvGMode3IslandManagerSocket;
using Shift.Legion.GvGServer.Models.GvGMode3IslandManagerSocket.Sweep;
using Shift.Legion.Helpers;
using UI.PublicResources;
using UnityEngine;

namespace UI.GvGWorldMap3;

public class UI_com_SweepOperationDialog : GComponent
{
	public Controller State;

	public Controller SweepEnabled;

	public GImage n0;

	public GImage n53;

	public GImage n28;

	public GImage n60;

	public GImage n52;

	public GImage n51;

	public GImage n29;

	public GImage n25;

	public GLoader n26;

	public GTextField Tip;

	public GTextField n4;

	public GTextField n38;

	public GTextField n56;

	public UI_btn_Operation_Sweep Sweep;

	public GTextField n10;

	public GLoader n36;

	public GTextField FoodCost;

	public GButton FoodBuff;

	public GGroup NormalCost;

	public GList DisplayBonus;

	public GTextField RemainingSweepCount;

	public UI_btn_FillupSweepCount FillupSweepCount;

	public Transition t0;

	public const string URL = "ui://4eq8fgd2l2e2sa7";

	public static string Name = "UI_com_SweepOperationDialog";

	private const string _COUNT_NOT_ENOUGH_CODE = "ErrorCode_-8152";

	private const string _FOOD_IS_NOT_ENOUGH = "ErrorCode_-8153";

	private readonly SweepInfo _sweepInfo = new SweepInfo();

	private int _shipEntityId;

	private string _shipId;

	private int _islandId;

	private Action<EventCallback0> _playSweepEffect;

	private RealTimeFoodCostReduceModel _foodCostReduce;

	private static readonly Lazy<SweepConfig> _sweepConfig = new Lazy<SweepConfig>(() => "GvGMode3_SweepConfig".ToConfiguration<SweepConfig>());

	public static SweepConfig SweepConfig => _sweepConfig.Value;

	public static string GetURL()
	{
		return "ui://4eq8fgd2l2e2sa7";
	}

	public static UI_com_SweepOperationDialog CreateInstance()
	{
		return (UI_com_SweepOperationDialog)(object)UIPackage.CreateObject("GvGWorldMap3", "com_SweepOperationDialog");
	}

	public static UI_com_SweepOperationDialog CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_SweepOperationDialog).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://4eq8fgd2l2e2sa7", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0037: Unknown result type (might be due to invalid IL or missing references)
		//IL_0041: Expected O, but got Unknown
		//IL_004d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0057: Expected O, but got Unknown
		//IL_0063: Unknown result type (might be due to invalid IL or missing references)
		//IL_006d: Expected O, but got Unknown
		//IL_0079: Unknown result type (might be due to invalid IL or missing references)
		//IL_0083: Expected O, but got Unknown
		//IL_008f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0099: Expected O, but got Unknown
		//IL_00a5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00af: Expected O, but got Unknown
		//IL_00bb: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c5: Expected O, but got Unknown
		//IL_00d1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00db: Expected O, but got Unknown
		//IL_00e7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f1: Expected O, but got Unknown
		//IL_00fd: Unknown result type (might be due to invalid IL or missing references)
		//IL_0107: Expected O, but got Unknown
		//IL_0150: Unknown result type (might be due to invalid IL or missing references)
		//IL_015a: Expected O, but got Unknown
		//IL_01a3: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ad: Expected O, but got Unknown
		//IL_01f6: Unknown result type (might be due to invalid IL or missing references)
		//IL_0200: Expected O, but got Unknown
		//IL_025f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0269: Expected O, but got Unknown
		//IL_02b4: Unknown result type (might be due to invalid IL or missing references)
		//IL_02be: Expected O, but got Unknown
		//IL_02ca: Unknown result type (might be due to invalid IL or missing references)
		//IL_02d4: Expected O, but got Unknown
		//IL_02e0: Unknown result type (might be due to invalid IL or missing references)
		//IL_02ea: Expected O, but got Unknown
		//IL_02f6: Unknown result type (might be due to invalid IL or missing references)
		//IL_0300: Expected O, but got Unknown
		//IL_030c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0316: Expected O, but got Unknown
		//IL_0322: Unknown result type (might be due to invalid IL or missing references)
		//IL_032c: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		State = ((GComponent)this).GetController("State");
		SweepEnabled = ((GComponent)this).GetController("SweepEnabled");
		n0 = (GImage)((GComponent)this).GetChild("n0");
		n53 = (GImage)((GComponent)this).GetChild("n53");
		n28 = (GImage)((GComponent)this).GetChild("n28");
		n60 = (GImage)((GComponent)this).GetChild("n60");
		n52 = (GImage)((GComponent)this).GetChild("n52");
		n51 = (GImage)((GComponent)this).GetChild("n51");
		n29 = (GImage)((GComponent)this).GetChild("n29");
		n25 = (GImage)((GComponent)this).GetChild("n25");
		n26 = (GLoader)((GComponent)this).GetChild("n26");
		Tip = (GTextField)((GComponent)this).GetChild("Tip");
		string id = "ui://4eq8fgd2l2e2sa7".Replace("ui://", "") + "-" + ((GObject)Tip).id;
		((GObject)Tip).text = LanguagesManager.GetDesc(id);
		n4 = (GTextField)((GComponent)this).GetChild("n4");
		string id2 = "ui://4eq8fgd2l2e2sa7".Replace("ui://", "") + "-" + ((GObject)n4).id;
		((GObject)n4).text = LanguagesManager.GetDesc(id2);
		n38 = (GTextField)((GComponent)this).GetChild("n38");
		string id3 = "ui://4eq8fgd2l2e2sa7".Replace("ui://", "") + "-" + ((GObject)n38).id;
		((GObject)n38).text = LanguagesManager.GetDesc(id3);
		n56 = (GTextField)((GComponent)this).GetChild("n56");
		string id4 = "ui://4eq8fgd2l2e2sa7".Replace("ui://", "") + "-" + ((GObject)n56).id;
		((GObject)n56).text = LanguagesManager.GetDesc(id4);
		Sweep = (UI_btn_Operation_Sweep)(object)((GComponent)this).GetChild("Sweep");
		n10 = (GTextField)((GComponent)this).GetChild("n10");
		string id5 = "ui://4eq8fgd2l2e2sa7".Replace("ui://", "") + "-" + ((GObject)n10).id;
		((GObject)n10).text = LanguagesManager.GetDesc(id5);
		n36 = (GLoader)((GComponent)this).GetChild("n36");
		FoodCost = (GTextField)((GComponent)this).GetChild("FoodCost");
		FoodBuff = (GButton)((GComponent)this).GetChild("FoodBuff");
		NormalCost = (GGroup)((GComponent)this).GetChild("NormalCost");
		DisplayBonus = (GList)((GComponent)this).GetChild("DisplayBonus");
		RemainingSweepCount = (GTextField)((GComponent)this).GetChild("RemainingSweepCount");
		FillupSweepCount = (UI_btn_FillupSweepCount)(object)((GComponent)this).GetChild("FillupSweepCount");
		t0 = ((GComponent)this).GetTransition("t0");
	}

	public void RegisterEvent()
	{
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_001d: Expected O, but got Unknown
		//IL_0030: Unknown result type (might be due to invalid IL or missing references)
		//IL_003a: Expected O, but got Unknown
		((GObject)Sweep).onClick.Set(new EventCallback1(OnSweepClick));
		((GObject)FillupSweepCount).onClick.Set(new EventCallback0(OnFillUpClick));
		S2C_BuySweepCount.OnPushEvent = (Action<S2C_BuySweepCount.Request>)Delegate.Combine(S2C_BuySweepCount.OnPushEvent, new Action<S2C_BuySweepCount.Request>(OnPushBuySweepResult));
	}

	public void UnregisterEvent()
	{
		S2C_BuySweepCount.OnPushEvent = (Action<S2C_BuySweepCount.Request>)Delegate.Remove(S2C_BuySweepCount.OnPushEvent, new Action<S2C_BuySweepCount.Request>(OnPushBuySweepResult));
		_playSweepEffect = null;
		((GObject)Sweep).onClick.Clear();
		((GObject)FillupSweepCount).onClick.Clear();
	}

	public void Init(Action<EventCallback0> action)
	{
		_playSweepEffect = action;
	}

	public void Display(int islandId, EventCallback0 displayTransition)
	{
		_islandId = islandId;
		State.SetSelectedIndex(0);
		RenderPreviewBonus();
		GetSweepInfo(displayTransition);
	}

	public void DisplayOnSelectShip(int shipEntityId, string shipId)
	{
		_shipEntityId = shipEntityId;
		_shipId = shipId;
		State.SetSelectedIndex(1);
		RenderFoodCostAndUpdateConfirmBtnState();
	}

	public void Hide()
	{
		_islandId = 0;
		_shipEntityId = 0;
		State.SetSelectedIndex(0);
	}

	private void RenderPreviewBonus()
	{
		//IL_0074: Unknown result type (might be due to invalid IL or missing references)
		//IL_007e: Expected O, but got Unknown
		string serverMapId = Singleton<WorldStateManager>.Instance.TryGetIsland(_islandId).DetailInfo.ServerMapId;
		string text = GDMgr.Get<GDEGvGIslandMapConfigData>(serverMapId)?.SweepReward;
		List<RItem> rItems;
		if (!string.IsNullOrEmpty(text))
		{
			SweepReward reward = JsonHelper.ToObject<SweepReward>(GDMgr.Get<GDEItemData>(text).Effect);
			rItems = reward.ToRItems();
			DisplayBonus.itemRenderer = new ListItemRenderer(RenderItem);
			DisplayBonus.numItems = rItems.Count;
		}
		void RenderItem(int index, GObject obj)
		{
			//IL_007f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0089: Expected O, but got Unknown
			if (obj is UI_com_IslandSpeciality02 uI_com_IslandSpeciality)
			{
				RItem rItem = rItems[index];
				FGUIManager.Instance.SetItemIconAndFrame(uI_com_IslandSpeciality.Icon, rItem.ItemId);
				((GObject)uI_com_IslandSpeciality.GvGStoreHouseStock).text = rItem.cnt.ToString();
				((GObject)uI_com_IslandSpeciality).data = rItem.ItemId;
				((GObject)uI_com_IslandSpeciality).onClick.Set(new EventCallback1(DisplayItemTip));
			}
		}
	}

	private void DisplayItemTip(EventContext context)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		string itemId = ((GObject)context.sender).data.ToString();
		itemId.DisplayItemTip();
	}

	private void GetSweepInfo(EventCallback0 displayTransition)
	{
		SocketManager.Instance.GetConnection(eConType.GvGMode3IslandManager).Request(new C2S_BuySweepCount
		{
			Req = new C2S_BuySweepCount.Request
			{
				IsBuyCount = false
			}
		}, delegate(SocketManager.BaseSocketPackageBodyContext contextResponse)
		{
			C2S_BuySweepCount.Response response = (C2S_BuySweepCount.Response)contextResponse.Resp;
			if (response.ErrorCode != 0)
			{
				ILRequestHelper.ShowErrorCode(response.ErrorCode);
			}
			UpdateSweepInfo(response);
			RenderSweepCount();
			EventCallback0 obj = displayTransition;
			if (obj != null)
			{
				obj.Invoke();
			}
		});
	}

	private void OnPushBuySweepResult(S2C_BuySweepCount.Request request)
	{
		UpdateSweepInfoAndShowTip(request);
		RenderFoodCostAndUpdateConfirmBtnState();
		RenderSweepCount();
	}

	private void UpdateSweepInfo(C2S_BuySweepCount.Response res)
	{
		_sweepInfo.RemainingSweepCount = res.RemainingSweepCount;
		_sweepInfo.TodayPurchasedCount = res.TodayPurchasedCount;
		_sweepInfo.TodayRefillCountByPurchase = res.TodayRefillCountByPurchase;
	}

	private void UpdateSweepInfoAndShowTip(S2C_BuySweepCount.Request request)
	{
		"GvGMode3_SweepCountAdd".ToLanguage().Format(new object[1] { request.RemainingSweepCount - _sweepInfo.RemainingSweepCount }).ToTip();
		_sweepInfo.RemainingSweepCount = request.RemainingSweepCount;
		_sweepInfo.TodayPurchasedCount = request.TodayPurchasedCount;
		_sweepInfo.TodayRefillCountByPurchase = request.TodayRefillCountByPurchase;
	}

	private void RenderSweepCount()
	{
		((GObject)RemainingSweepCount).text = _sweepInfo.RemainingSweepCount.ToString();
	}

	private void RenderFoodCostAndUpdateConfirmBtnState()
	{
		if (State.selectedIndex == 1)
		{
			Singleton<GvGShipUiInfoManager>.Instance.GetRealTimeFoodCostReduce(_shipId, _islandId, delegate(RealTimeFoodCostReduceModel reduceModel)
			{
				//IL_005b: Unknown result type (might be due to invalid IL or missing references)
				//IL_0065: Expected O, but got Unknown
				int foodCost = (int)((float)SweepConfig.FoodCost * (1f - reduceModel.Total));
				_foodCostReduce = reduceModel;
				((GObject)FoodBuff).visible = reduceModel.Total > 0f;
				((GObject)FoodBuff).enabled = true;
				((GObject)FoodBuff).onClick.Set(new EventCallback1(ShowFoodCostReduceText));
				bool foodIsNotEnough = RenderFoodCost(foodCost);
				UpdateConfirmBtnState(foodIsNotEnough);
			});
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

	private bool RenderFoodCost(int foodCost)
	{
		int foodOnboardCount = Singleton<WorldStateManager>.Instance.TryGetShip(_shipEntityId).FoodOnboardCount;
		bool flag = foodOnboardCount < foodCost;
		string arg = (flag ? "#ff1919" : "#FFF2CC");
		((GObject)FoodCost).text = $"[color={arg}]{foodOnboardCount}[/color]/{foodCost}";
		return flag;
	}

	private void UpdateConfirmBtnState(bool foodIsNotEnough)
	{
		bool flag = _sweepInfo.RemainingSweepCount <= 0;
		if (flag)
		{
			((GObject)Sweep).data = "ErrorCode_-8152";
		}
		else if (foodIsNotEnough)
		{
			((GObject)Sweep).data = "ErrorCode_-8153";
		}
		SweepEnabled.SetSelectedIndex((flag || foodIsNotEnough) ? 1 : 0);
	}

	private void OnFillUpClick()
	{
		GameController.Contexts.Service<IUiService>().OpenPanel(UI_main_BuySweepCountDialog.Name, new Dictionary<string, object> { { "SweepInfo", _sweepInfo } });
	}

	private void OnSweepClick(EventContext context)
	{
		if (!CanNotSweep(context))
		{
			RequestSweep();
		}
	}

	private bool CanNotSweep(EventContext context)
	{
		//IL_001d: Unknown result type (might be due to invalid IL or missing references)
		if (SweepEnabled.selectedIndex == 0)
		{
			return false;
		}
		string text = ((GObject)context.sender).data.ToString();
		text.ToShowLanguageTip();
		if (text == "ErrorCode_-8152")
		{
			OnFillUpClick();
		}
		return true;
	}

	private void RequestSweep()
	{
		SocketManager.Instance.GetConnection(eConType.GvGMode3IslandManager).Request(new C2S_Sweep
		{
			Req = new C2S_Sweep.Request
			{
				ShipEntityId = _shipEntityId,
				SweepIslandId = _islandId
			}
		}, delegate(SocketManager.BaseSocketPackageBodyContext contextResponse)
		{
			C2S_Sweep.Response response = (C2S_Sweep.Response)contextResponse.Resp;
			if (response.ErrorCode != 0)
			{
				ILRequestHelper.ShowErrorCode(response.ErrorCode);
			}
			_sweepInfo.RemainingSweepCount = Mathf.Max(_sweepInfo.RemainingSweepCount - 1, 0);
			PlaySweepEffect();
		});
	}

	private void PlaySweepEffect()
	{
		//IL_0014: Unknown result type (might be due to invalid IL or missing references)
		//IL_001e: Expected O, but got Unknown
		_playSweepEffect?.Invoke(new EventCallback0(UpdateSweepInfo));
	}

	private void UpdateSweepInfo()
	{
		RenderSweepCount();
		RenderFoodCostAndUpdateConfirmBtnState();
	}
}
