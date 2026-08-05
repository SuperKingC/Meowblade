using System;
using System.Collections.Generic;
using System.Linq;
using Assets.Scripts.Managers;
using Assets.Scripts.UI;
using FairyGUI;
using FairyGUI.Utils;
using HotFix.Sources.Base.Scripts.Helper;
using HotFix.Sources.Base.Sources.Scripts.GvG3.GvG3UI.UI.GvGWorldMapPanel.IslandOperations;
using HotFix.Sources.Base.Sources.Scripts.GvG3.GvG3UI.UI.GvGWorldMapPanel.IslandOperations.Static;
using HotFix.Sources.Base.Sources.Scripts.GvG3Common.Manager;
using HotFix.Sources.Base.Sources.Scripts.GvG3Common.Model;
using HotFix.Sources.Base.Sources.Scripts.GvG3Common.Model.OuterTech;
using HotFix.Sources.Base.Sources.Scripts.GvG3UI.Manager;
using HotFix.Sources.Base.Sources.Scripts.GvG3UI.Model;
using HotFix.Sources.Base.Sources.Scripts.GvG3WorldMap.Controller;
using HotFix.Sources.Base.Sources.Scripts.GvG3WorldMap.Extensions;
using HotFix.Sources.Base.Sources.Scripts.GvG3WorldMap.Helper;
using HotFix.Sources.Base.Sources.Scripts.GvG3WorldMap.Manager;
using HotFix.Sources.Base.Sources.Scripts.GvG3WorldMap.Model;
using Shift.Legion.Common.Helpers;
using Shift.Legion.Common.Managers;
using Shift.Legion.Common.Services;
using Shift.Legion.GvG.Common.Models.GvGMode3;
using Shift.Legion.GvG.Common.Models.GvGMode3.Collecting;
using Shift.Legion.GvGServer.Models.GvGMode3IslandManagerSocket;
using UI.PublicResources;
using UnityEngine;

namespace UI.GvGWorldMap3;

public class UI_com_OperationDialog : GComponent
{
	public Controller OperationType;

	public Controller State;

	public Controller FlightData;

	public Controller AutoCollection;

	public Controller JumpMode;

	public Controller HasFreeJumps;

	public Controller HasJumpMode;

	public GImage n0;

	public GImage n28;

	public GImage n29;

	public GImage n25;

	public GLoader n26;

	public GTextField Tip;

	public GTextField n4;

	public GTextField StartIslandName;

	public GTextField EndIslandName;

	public UI_btn_CheckRoute CheckRoute;

	public GTextField n27;

	public GImage n30;

	public GTextField n66;

	public GTextField n38;

	public GGroup n67;

	public GTextField n9;

	public GTextField n11;

	public GTextField n12;

	public GTextField Distance;

	public GTextField JumpDist;

	public GTextField Speed;

	public GTextField InfSpeed;

	public GTextField TimeCost;

	public GButton SpeedBuff;

	public GTextField TimeCost2;

	public GImage n49;

	public GGroup n39;

	public GTextField n10;

	public GLoader n36;

	public GTextField FoodCost;

	public GButton FoodBuff;

	public GGroup NormalCost;

	public GTextField n99;

	public GLoader n54;

	public GTextField TotalFood;

	public GTextField Separator;

	public GTextField JumpFoodCost;

	public GButton JumpFoodBuff;

	public UI_com_FreeJumpTips FreeJumpTips;

	public UI_com_OuterTechI67502Switch 努力加餐饭;

	public GGroup JumpCost;

	public GImage n59;

	public GGroup n60;

	public GTextField n31;

	public GLoader n33;

	public GTextField Food;

	public GGroup n40;

	public UI_btn_AutoCollect AutoCollect;

	public GGroup n65;

	public UI_btn_Operation_Jump Jump;

	public UI_btn_Operation_Goto Operation_Goto;

	public UI_btn_Operation_CleanUp CleanUp;

	public UI_btn_Operation_Attack Attack;

	public UI_btn_Operation_Collect Collect;

	public UI_btn_Operation_FillUp FillUp;

	public GGroup OperationGroup;

	public UI_btn_FakeJumpModeSwitch FakeJumpBtn;

	public UI_btn_JumpModeSwitch JumpModeSwitch;

	public GTextField estimatedTime;

	public Transition t0;

	public const string URL = "ui://4eq8fgd2v3u537";

	public static string Name = "UI_com_OperationDialog";

	private const string _JUMP = "Jump";

	private const string STAR_ISLAND_SOLIDER_COUNT_TIP = "StarIslandSoldierCountTip";

	private static readonly List<string> _specialSuppress = new List<string> { "GVG_SpecialSuppress_001", "GVG_SpecialSuppress_002", "GVG_SpecialSuppress_003", "GVG_SpecialSuppress_004" };

	private IslandBuff _specialSuppressBuff;

	private bool _specialSuppressBuffChecked;

	private IslandOperationButtonHandlers _buttonHandlers;

	public int FoodCostCount;

	private const string AutoCollectSelectedKey = "AutoCollectSelected";

	private UI_main_GvGWorldMap3 _mainUi;

	private RealTimeShipSummarySpeedModel _shipSummarySpeed;

	private RealTimeFoodCostReduceModel _foodCostReduce;

	private int _jumpFoodCost;

	private const string EmptyNumber = "0";

	private const string EmptyString = "--";

	private ShipStateModel _shipState;

	private string _canNotJumpTip;

	private string _ignoreIslandAction;

	private string _跃迁专精Effect;

	private bool _canNotArrive;

	public Action<OuterTechHelper.Jump努力加餐饭Cost> OnConfirmJumping = null;

	private int ShipEntityId => _mainUi.ShipsInfo.Data.GetDetailModel(_mainUi.CurrentShipId).EntityId;

	private int StayIslandId => Singleton<WorldStateManager>.Instance.TryGetShip(ShipEntityId).StayIslandId;

	private string ShipId => _mainUi.CurrentShipId;

	private bool StayFlagShipIsland => StayIslandId == Singleton<WorldStateManager>.Instance.Data.OurFlagShipStayIslandId && _shipState.State == eShipState.Stay;

	private string 跃迁专精Effect => _跃迁专精Effect ?? (_跃迁专精Effect = Singleton<GvGTalentsManager>.Instance.GeTalentUiModel(125).Name + ":-100%");

	private string FoodCostUnit => "GvG3ShipFoodCostUnit".ToLanguage();

	private bool NextCollection => AutoCollection.selectedIndex == 1;

	public static string GetURL()
	{
		return "ui://4eq8fgd2v3u537";
	}

	public static UI_com_OperationDialog CreateInstance()
	{
		return (UI_com_OperationDialog)(object)UIPackage.CreateObject("GvGWorldMap3", "com_OperationDialog");
	}

	public static UI_com_OperationDialog CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_OperationDialog).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://4eq8fgd2v3u537", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_008c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0096: Expected O, but got Unknown
		//IL_00a2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ac: Expected O, but got Unknown
		//IL_00b8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c2: Expected O, but got Unknown
		//IL_00ce: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d8: Expected O, but got Unknown
		//IL_00e4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ee: Expected O, but got Unknown
		//IL_00fa: Unknown result type (might be due to invalid IL or missing references)
		//IL_0104: Expected O, but got Unknown
		//IL_0110: Unknown result type (might be due to invalid IL or missing references)
		//IL_011a: Expected O, but got Unknown
		//IL_0163: Unknown result type (might be due to invalid IL or missing references)
		//IL_016d: Expected O, but got Unknown
		//IL_0179: Unknown result type (might be due to invalid IL or missing references)
		//IL_0183: Expected O, but got Unknown
		//IL_01a5: Unknown result type (might be due to invalid IL or missing references)
		//IL_01af: Expected O, but got Unknown
		//IL_01bb: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c5: Expected O, but got Unknown
		//IL_01d1: Unknown result type (might be due to invalid IL or missing references)
		//IL_01db: Expected O, but got Unknown
		//IL_0224: Unknown result type (might be due to invalid IL or missing references)
		//IL_022e: Expected O, but got Unknown
		//IL_0277: Unknown result type (might be due to invalid IL or missing references)
		//IL_0281: Expected O, but got Unknown
		//IL_028d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0297: Expected O, but got Unknown
		//IL_02e0: Unknown result type (might be due to invalid IL or missing references)
		//IL_02ea: Expected O, but got Unknown
		//IL_0335: Unknown result type (might be due to invalid IL or missing references)
		//IL_033f: Expected O, but got Unknown
		//IL_038a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0394: Expected O, but got Unknown
		//IL_03a0: Unknown result type (might be due to invalid IL or missing references)
		//IL_03aa: Expected O, but got Unknown
		//IL_03b6: Unknown result type (might be due to invalid IL or missing references)
		//IL_03c0: Expected O, but got Unknown
		//IL_03cc: Unknown result type (might be due to invalid IL or missing references)
		//IL_03d6: Expected O, but got Unknown
		//IL_0421: Unknown result type (might be due to invalid IL or missing references)
		//IL_042b: Expected O, but got Unknown
		//IL_0476: Unknown result type (might be due to invalid IL or missing references)
		//IL_0480: Expected O, but got Unknown
		//IL_048c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0496: Expected O, but got Unknown
		//IL_04e1: Unknown result type (might be due to invalid IL or missing references)
		//IL_04eb: Expected O, but got Unknown
		//IL_04f7: Unknown result type (might be due to invalid IL or missing references)
		//IL_0501: Expected O, but got Unknown
		//IL_050d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0517: Expected O, but got Unknown
		//IL_0562: Unknown result type (might be due to invalid IL or missing references)
		//IL_056c: Expected O, but got Unknown
		//IL_0578: Unknown result type (might be due to invalid IL or missing references)
		//IL_0582: Expected O, but got Unknown
		//IL_058e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0598: Expected O, but got Unknown
		//IL_05a4: Unknown result type (might be due to invalid IL or missing references)
		//IL_05ae: Expected O, but got Unknown
		//IL_05ba: Unknown result type (might be due to invalid IL or missing references)
		//IL_05c4: Expected O, but got Unknown
		//IL_060f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0619: Expected O, but got Unknown
		//IL_0625: Unknown result type (might be due to invalid IL or missing references)
		//IL_062f: Expected O, but got Unknown
		//IL_063b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0645: Expected O, but got Unknown
		//IL_0651: Unknown result type (might be due to invalid IL or missing references)
		//IL_065b: Expected O, but got Unknown
		//IL_0667: Unknown result type (might be due to invalid IL or missing references)
		//IL_0671: Expected O, but got Unknown
		//IL_06a9: Unknown result type (might be due to invalid IL or missing references)
		//IL_06b3: Expected O, but got Unknown
		//IL_06bf: Unknown result type (might be due to invalid IL or missing references)
		//IL_06c9: Expected O, but got Unknown
		//IL_06d5: Unknown result type (might be due to invalid IL or missing references)
		//IL_06df: Expected O, but got Unknown
		//IL_06eb: Unknown result type (might be due to invalid IL or missing references)
		//IL_06f5: Expected O, but got Unknown
		//IL_0740: Unknown result type (might be due to invalid IL or missing references)
		//IL_074a: Expected O, but got Unknown
		//IL_0756: Unknown result type (might be due to invalid IL or missing references)
		//IL_0760: Expected O, but got Unknown
		//IL_076c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0776: Expected O, but got Unknown
		//IL_0798: Unknown result type (might be due to invalid IL or missing references)
		//IL_07a2: Expected O, but got Unknown
		//IL_0832: Unknown result type (might be due to invalid IL or missing references)
		//IL_083c: Expected O, but got Unknown
		//IL_0874: Unknown result type (might be due to invalid IL or missing references)
		//IL_087e: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		OperationType = ((GComponent)this).GetController("OperationType");
		State = ((GComponent)this).GetController("State");
		FlightData = ((GComponent)this).GetController("FlightData");
		AutoCollection = ((GComponent)this).GetController("AutoCollection");
		JumpMode = ((GComponent)this).GetController("JumpMode");
		HasFreeJumps = ((GComponent)this).GetController("HasFreeJumps");
		HasJumpMode = ((GComponent)this).GetController("HasJumpMode");
		n0 = (GImage)((GComponent)this).GetChild("n0");
		n28 = (GImage)((GComponent)this).GetChild("n28");
		n29 = (GImage)((GComponent)this).GetChild("n29");
		n25 = (GImage)((GComponent)this).GetChild("n25");
		n26 = (GLoader)((GComponent)this).GetChild("n26");
		Tip = (GTextField)((GComponent)this).GetChild("Tip");
		n4 = (GTextField)((GComponent)this).GetChild("n4");
		string id = "ui://4eq8fgd2v3u537".Replace("ui://", "") + "-" + ((GObject)n4).id;
		((GObject)n4).text = LanguagesManager.GetDesc(id);
		StartIslandName = (GTextField)((GComponent)this).GetChild("StartIslandName");
		EndIslandName = (GTextField)((GComponent)this).GetChild("EndIslandName");
		CheckRoute = (UI_btn_CheckRoute)(object)((GComponent)this).GetChild("CheckRoute");
		n27 = (GTextField)((GComponent)this).GetChild("n27");
		n30 = (GImage)((GComponent)this).GetChild("n30");
		n66 = (GTextField)((GComponent)this).GetChild("n66");
		string id2 = "ui://4eq8fgd2v3u537".Replace("ui://", "") + "-" + ((GObject)n66).id;
		((GObject)n66).text = LanguagesManager.GetDesc(id2);
		n38 = (GTextField)((GComponent)this).GetChild("n38");
		string id3 = "ui://4eq8fgd2v3u537".Replace("ui://", "") + "-" + ((GObject)n38).id;
		((GObject)n38).text = LanguagesManager.GetDesc(id3);
		n67 = (GGroup)((GComponent)this).GetChild("n67");
		n9 = (GTextField)((GComponent)this).GetChild("n9");
		string id4 = "ui://4eq8fgd2v3u537".Replace("ui://", "") + "-" + ((GObject)n9).id;
		((GObject)n9).text = LanguagesManager.GetDesc(id4);
		n11 = (GTextField)((GComponent)this).GetChild("n11");
		string id5 = "ui://4eq8fgd2v3u537".Replace("ui://", "") + "-" + ((GObject)n11).id;
		((GObject)n11).text = LanguagesManager.GetDesc(id5);
		n12 = (GTextField)((GComponent)this).GetChild("n12");
		string id6 = "ui://4eq8fgd2v3u537".Replace("ui://", "") + "-" + ((GObject)n12).id;
		((GObject)n12).text = LanguagesManager.GetDesc(id6);
		Distance = (GTextField)((GComponent)this).GetChild("Distance");
		JumpDist = (GTextField)((GComponent)this).GetChild("JumpDist");
		Speed = (GTextField)((GComponent)this).GetChild("Speed");
		InfSpeed = (GTextField)((GComponent)this).GetChild("InfSpeed");
		string id7 = "ui://4eq8fgd2v3u537".Replace("ui://", "") + "-" + ((GObject)InfSpeed).id;
		((GObject)InfSpeed).text = LanguagesManager.GetDesc(id7);
		TimeCost = (GTextField)((GComponent)this).GetChild("TimeCost");
		string id8 = "ui://4eq8fgd2v3u537".Replace("ui://", "") + "-" + ((GObject)TimeCost).id;
		((GObject)TimeCost).text = LanguagesManager.GetDesc(id8);
		SpeedBuff = (GButton)((GComponent)this).GetChild("SpeedBuff");
		TimeCost2 = (GTextField)((GComponent)this).GetChild("TimeCost2");
		string id9 = "ui://4eq8fgd2v3u537".Replace("ui://", "") + "-" + ((GObject)TimeCost2).id;
		((GObject)TimeCost2).text = LanguagesManager.GetDesc(id9);
		n49 = (GImage)((GComponent)this).GetChild("n49");
		n39 = (GGroup)((GComponent)this).GetChild("n39");
		n10 = (GTextField)((GComponent)this).GetChild("n10");
		string id10 = "ui://4eq8fgd2v3u537".Replace("ui://", "") + "-" + ((GObject)n10).id;
		((GObject)n10).text = LanguagesManager.GetDesc(id10);
		n36 = (GLoader)((GComponent)this).GetChild("n36");
		FoodCost = (GTextField)((GComponent)this).GetChild("FoodCost");
		FoodBuff = (GButton)((GComponent)this).GetChild("FoodBuff");
		NormalCost = (GGroup)((GComponent)this).GetChild("NormalCost");
		n99 = (GTextField)((GComponent)this).GetChild("n99");
		string id11 = "ui://4eq8fgd2v3u537".Replace("ui://", "") + "-" + ((GObject)n99).id;
		((GObject)n99).text = LanguagesManager.GetDesc(id11);
		n54 = (GLoader)((GComponent)this).GetChild("n54");
		TotalFood = (GTextField)((GComponent)this).GetChild("TotalFood");
		Separator = (GTextField)((GComponent)this).GetChild("Separator");
		JumpFoodCost = (GTextField)((GComponent)this).GetChild("JumpFoodCost");
		JumpFoodBuff = (GButton)((GComponent)this).GetChild("JumpFoodBuff");
		FreeJumpTips = (UI_com_FreeJumpTips)(object)((GComponent)this).GetChild("FreeJumpTips");
		努力加餐饭 = (UI_com_OuterTechI67502Switch)(object)((GComponent)this).GetChild("努力加餐饭");
		JumpCost = (GGroup)((GComponent)this).GetChild("JumpCost");
		n59 = (GImage)((GComponent)this).GetChild("n59");
		n60 = (GGroup)((GComponent)this).GetChild("n60");
		n31 = (GTextField)((GComponent)this).GetChild("n31");
		string id12 = "ui://4eq8fgd2v3u537".Replace("ui://", "") + "-" + ((GObject)n31).id;
		((GObject)n31).text = LanguagesManager.GetDesc(id12);
		n33 = (GLoader)((GComponent)this).GetChild("n33");
		Food = (GTextField)((GComponent)this).GetChild("Food");
		n40 = (GGroup)((GComponent)this).GetChild("n40");
		AutoCollect = (UI_btn_AutoCollect)(object)((GComponent)this).GetChild("AutoCollect");
		n65 = (GGroup)((GComponent)this).GetChild("n65");
		Jump = (UI_btn_Operation_Jump)(object)((GComponent)this).GetChild("Jump");
		Operation_Goto = (UI_btn_Operation_Goto)(object)((GComponent)this).GetChild("Operation_Goto");
		CleanUp = (UI_btn_Operation_CleanUp)(object)((GComponent)this).GetChild("CleanUp");
		Attack = (UI_btn_Operation_Attack)(object)((GComponent)this).GetChild("Attack");
		Collect = (UI_btn_Operation_Collect)(object)((GComponent)this).GetChild("Collect");
		FillUp = (UI_btn_Operation_FillUp)(object)((GComponent)this).GetChild("FillUp");
		OperationGroup = (GGroup)((GComponent)this).GetChild("OperationGroup");
		FakeJumpBtn = (UI_btn_FakeJumpModeSwitch)(object)((GComponent)this).GetChild("FakeJumpBtn");
		JumpModeSwitch = (UI_btn_JumpModeSwitch)(object)((GComponent)this).GetChild("JumpModeSwitch");
		estimatedTime = (GTextField)((GComponent)this).GetChild("estimatedTime");
		string id13 = "ui://4eq8fgd2v3u537".Replace("ui://", "") + "-" + ((GObject)estimatedTime).id;
		((GObject)estimatedTime).text = LanguagesManager.GetDesc(id13);
		t0 = ((GComponent)this).GetTransition("t0");
	}

	private void OperationGoTo()
	{
		ExecuteButtonClick(eIslandAction.GoTo);
	}

	private void OperationClearUp()
	{
		ExecuteButtonClick(eIslandAction.SuppressRebellion);
	}

	private void OperationAttack()
	{
		ExecuteButtonClick(eIslandAction.Attack);
	}

	private void OperationFillUp()
	{
		ExecuteButtonClick(eIslandAction.FillUpSoldier);
	}

	private void OperationCollect()
	{
		ExecuteButtonClick(eIslandAction.Collect);
	}

	private void ExecuteButtonClick(eIslandAction actionType)
	{
		if (_mainUi != null)
		{
			_buttonHandlers.ExecuteButtonClick(actionType.ToString());
		}
	}

	private void OnClickJumpBtn()
	{
		if (_mainUi != null)
		{
			_buttonHandlers.ExecuteButtonClick("Jump");
		}
	}

	private void JumpModeOnChange()
	{
		RefreshFoodEstimate(_shipState.FoodOnboardCount);
		if (_canNotArrive)
		{
			if (FlightData.selectedIndex == 2 && JumpMode.selectedIndex == 1)
			{
				FlightData.selectedIndex = 1;
				((GObject)TimeCost).visible = false;
				((GObject)n49).visible = false;
				((GObject)TimeCost2).x = 208f;
			}
			else if (FlightData.selectedIndex == 1 && JumpMode.selectedIndex == 0)
			{
				FlightData.selectedIndex = 2;
			}
		}
	}

	private void ShowCanNotJumpTip()
	{
		if (!string.IsNullOrEmpty(_canNotJumpTip))
		{
			ILRequestHelper.ShowMessage(_canNotJumpTip);
		}
	}

	private bool SoldierCountIsEnough()
	{
		eIslandType type = WorldMapConfigHelper.Configs.TryGetIsland(StayIslandId).Props.Type;
		if (_mainUi.CurrentIslandId == StayIslandId)
		{
			return true;
		}
		if (type != eIslandType.MainMoon && type != eIslandType.Moon && !StayFlagShipIsland)
		{
			return true;
		}
		return _shipState.GroupInfo.All((GvGMode3UnitInfo unit) => unit.CurCnt >= unit.Total);
	}

	private bool SoldierCountIsEnoughOnStarIsland()
	{
		eIslandType type = WorldMapConfigHelper.Configs.TryGetIsland(StayIslandId).Props.Type;
		if (type == eIslandType.MainMoon || type == eIslandType.Moon || StayFlagShipIsland)
		{
			return true;
		}
		return _shipState.GroupInfo.Any((GvGMode3UnitInfo unit) => unit.CurCnt > 0);
	}

	private static string LoadSoldierCountIsNotEnoughTipText()
	{
		return "StarIslandSoldierCountTip".ToLanguage();
	}

	private void SoldierCountIsNotEnoughExtraActionOnStar()
	{
		_mainUi.ShipsInfo.OpenShipDetailArmyPage();
	}

	private void ClearSpecialSuppressRecord()
	{
		_specialSuppressBuff = null;
		_specialSuppressBuffChecked = false;
	}

	private bool SpecialSuppressIsExistent()
	{
		if (_specialSuppressBuffChecked)
		{
			return _specialSuppressBuff == null;
		}
		IslandStateModel islandStateModel = Singleton<WorldStateManager>.Instance.TryGetIsland(_mainUi.CurrentIslandId);
		List<IslandBuff> list = islandStateModel.DetailInfo.Buff.Where(CheckAffectedBuff).ToList();
		_specialSuppressBuffChecked = true;
		if (list.Count <= 0)
		{
			return true;
		}
		list.Sort(CampBuffSort);
		_specialSuppressBuff = list[0];
		return false;
		static int CampBuffSort(IslandBuff a, IslandBuff b)
		{
			return b.Ability.ItemAbility.AbilityLevel - a.Ability.ItemAbility.AbilityLevel;
		}
	}

	private static bool CheckAffectedBuff(IslandBuff buff)
	{
		if (!buff.AffectedCampId.Contains(Singleton<GvGMode3RoomManager>.Instance.ObserverRecord.ObCampId))
		{
			return false;
		}
		if (!_specialSuppress.Contains(buff.Ability.AbilityId))
		{
			return false;
		}
		return true;
	}

	private string GetSpecialSuppressEffectTip()
	{
		if (_specialSuppressBuff == null)
		{
			return string.Empty;
		}
		string name = WorldMapConfigHelper.Configs.TryGetIsland(_specialSuppressBuff.FromIslandId).Name;
		string specialTagName = Singleton<AbilityDataManager>.Instance.GetSpecialTagName(_specialSuppressBuff.Ability.ItemAbility.AbilityId);
		int abilityLevel = _specialSuppressBuff.Ability.ItemAbility.AbilityLevel;
		return HotFix.Sources.Base.Scripts.Helper.StringExtensions.Format("GvG3IslandSpecialSuppressEffectTip".ToLanguage(), name, specialTagName, abilityLevel, name);
	}

	private static bool CheckValidAttack()
	{
		return IslandStateModelExtension.IslandAttackActionCheck();
	}

	private bool CheckJumpEnableOuterTech()
	{
		return !((GButton)努力加餐饭.UseTech).selected || !JumpUseOuterTechTip.NeedCheckJumpUseOuterTech();
	}

	private string GetJump努力加餐饭Cost()
	{
		return OuterTechHelper.Get_努力加餐饭Config().GetCosumeCount(_jumpFoodCost).ToString();
	}

	private void OnJumpUseTechSwitchChanged()
	{
		if (((GButton)努力加餐饭.UseTech).selected && Singleton<WorldStateManager>.Instance.Data.OuterTechModel.o努力加餐饭_LimitTime <= 0)
		{
			((GButton)努力加餐饭.UseTech).selected = false;
			"GvG3努力加餐饭DailyLimitReached".ToShowLanguageTip();
		}
	}

	private void DisplayJump努力加餐饭Switch()
	{
		bool flag = Singleton<GvGOuterTechManager>.Instance.IsAvailable && "I67502".IsActive();
		((GObject)努力加餐饭).visible = flag;
		((GButton)努力加餐饭.UseTech).selected = false;
		OuterTechHelper.努力加餐饭Config config;
		if (flag)
		{
			((GObject)努力加餐饭.Buff).visible = false;
			config = OuterTechHelper.Get_努力加餐饭Config();
			DisplayAvailableCount();
			DisplayCost();
		}
		void DisplayAvailableCount()
		{
			int maxUseTimes = config.MaxUseTimes;
			int o努力加餐饭_LimitTime = Singleton<WorldStateManager>.Instance.Data.OuterTechModel.o努力加餐饭_LimitTime;
			((GObject)努力加餐饭.AvailableCount).text = $"{o努力加餐饭_LimitTime}/{maxUseTimes}";
		}
		void DisplayCost()
		{
			努力加餐饭.CostIcon.url = UiHelper.GetIcon(config.CosumeItemId).ToPublicResourceIcon();
			int stock = GameManagers.Instance.StockController.GetStock(config.CosumeItemId);
			string jump努力加餐饭Cost = GetJump努力加餐饭Cost();
			((GObject)努力加餐饭.CostValue).text = stock.ShortNumberFormat() + "/[color=#ffffff]" + jump努力加餐饭Cost + "[/color]";
		}
	}

	private void Display努力加餐饭CostBuff(bool buffVisible)
	{
		((GObject)努力加餐饭.Buff).visible = buffVisible;
	}

	public void TryInitButtonHandlers()
	{
		if (_buttonHandlers == null)
		{
			_buttonHandlers = new IslandOperationButtonHandlers();
			List<IConditionInfo> list = CreateConditionInfos();
			AddButtonsHandlers(list);
			AddJumpButtonHandler(list);
		}
	}

	private List<IConditionInfo> CreateConditionInfos()
	{
		OnStarIslandSoldierCountCondition onStarIslandSoldierCountCondition = new OnStarIslandSoldierCountCondition(SoldierCountIsEnoughOnStarIsland, LoadSoldierCountIsNotEnoughTipText);
		onStarIslandSoldierCountCondition.AddExtraAction(SoldierCountIsNotEnoughExtraActionOnStar);
		FillUpSoldierCondition fillUpSoldierCondition = new FillUpSoldierCondition(SoldierCountIsEnough);
		fillUpSoldierCondition.AddExtraAction(OnFillUpActionInvoke);
		ArmisticeCheckCondition item = new ArmisticeCheckCondition(CheckValidAttack);
		SpecialSuppressIsExistent();
		SpecialSuppressCondition item2 = new SpecialSuppressCondition(SpecialSuppressIsExistent, GetSpecialSuppressEffectTip);
		JumpUseOuterTechCondition item3 = new JumpUseOuterTechCondition(CheckJumpEnableOuterTech, GetJump努力加餐饭Cost);
		return new List<IConditionInfo> { onStarIslandSoldierCountCondition, fillUpSoldierCondition, item, item2, item3 };
	}

	private void OnFillUpActionInvoke()
	{
		_ignoreIslandAction = eIslandAction.FillUpSoldier.ToString();
		_mainUi.ShipsInfo.OpenShipDetailArmyPage();
	}

	private void AddButtonsHandlers(List<IConditionInfo> conditionInfos)
	{
		AddButtonHandler(eIslandAction.GoTo, conditionInfos.Where((IConditionInfo c) => c.BelongToOperation(eIslandAction.GoTo.ToString())).ToList());
		AddButtonHandler(eIslandAction.Attack, conditionInfos.Where((IConditionInfo c) => c.BelongToOperation(eIslandAction.Attack.ToString())).ToList());
		AddButtonHandler(eIslandAction.SuppressRebellion, conditionInfos.Where((IConditionInfo c) => c.BelongToOperation(eIslandAction.SuppressRebellion.ToString())).ToList());
		AddButtonHandler(eIslandAction.Collect, conditionInfos.Where((IConditionInfo c) => c.BelongToOperation(eIslandAction.Collect.ToString())).ToList());
		AddButtonHandler(eIslandAction.FillUpSoldier, conditionInfos.Where((IConditionInfo c) => c.BelongToOperation(eIslandAction.FillUpSoldier.ToString())).ToList());
	}

	private void AddButtonHandler(eIslandAction actionType, List<IConditionInfo> conditions)
	{
		Action executableAction = GetExecutableAction(actionType);
		ButtonHandler buttonHandler = new ButtonHandler(executableAction);
		buttonHandler.AddCondition(conditions);
		_buttonHandlers.AddButtonHandlers(actionType.ToString(), buttonHandler);
	}

	private void AddJumpButtonHandler(List<IConditionInfo> conditions)
	{
		List<IConditionInfo> conditions2 = conditions.Where((IConditionInfo c) => c.BelongToOperation("Jump")).ToList();
		Action executeAction = CreateJumpAction();
		ButtonHandler buttonHandler = new ButtonHandler(executeAction);
		buttonHandler.AddCondition(conditions2);
		_buttonHandlers.AddButtonHandlers("Jump", buttonHandler);
	}

	private Action GetExecutableAction(eIslandAction actionType)
	{
		switch (actionType)
		{
		case eIslandAction.GoTo:
		case eIslandAction.Attack:
		case eIslandAction.SuppressRebellion:
			return CreateGoToOrAttackExecutableAction(actionType, actionType != eIslandAction.GoTo);
		case eIslandAction.Collect:
			return CreateCollectExecutableAction();
		case eIslandAction.FillUpSoldier:
			return CreateFillUpSoldierExecutableAction();
		default:
			throw new ArgumentOutOfRangeException("actionType", actionType, "UI_com_OperationDialog.GetExecutableAction");
		}
	}

	private Action CreateGoToOrAttackExecutableAction(eIslandAction actionType, bool autoCollection = false)
	{
		return IslandAction;
		void IslandAction()
		{
			GvGWorldMapController.Instance.IslandActionManager.IslandAction(actionType, _mainUi.CurrentIslandId, ShipEntityId, null, SendIslandActionComplete, autoCollection && NextCollection);
		}
		void SendIslandActionComplete()
		{
			SharedMessenger.Broadcast("ON_GVG3_ISLAND_ACTION_SUCCESS", (int)actionType);
		}
	}

	private Action CreateCollectExecutableAction()
	{
		return delegate
		{
			IslandStateModel islandStateModel = Singleton<WorldStateManager>.Instance.TryGetIsland(_mainUi.CurrentIslandId);
			GameController.Contexts.Service<IUiService>().OpenPanel(UI_main_IslandOutput.Name, new Dictionary<string, object>
			{
				{
					"Output",
					islandStateModel.DetailInfo.GetAllCollectingStock()
				},
				{ "DialogType", 1 },
				{ "IslandId", islandStateModel.IslandId },
				{ "CurrentShipId", ShipId },
				{ "IslandDetail", islandStateModel.DetailInfo }
			});
		};
	}

	private Action CreateFillUpSoldierExecutableAction()
	{
		return delegate
		{
			GvGWorldMapController.Instance.IslandActionManager.FillUpShipSoldiers(_mainUi.CurrentIslandId, ShipEntityId);
		};
	}

	private Action CreateJumpAction()
	{
		return delegate
		{
			bool selected = ((GButton)努力加餐饭.UseTech).selected;
			OuterTechHelper.努力加餐饭Config 努力加餐饭Config = OuterTechHelper.Get_努力加餐饭Config();
			int cosumeCount = 努力加餐饭Config.GetCosumeCount(_jumpFoodCost);
			OnConfirmJumping?.Invoke(new OuterTechHelper.Jump努力加餐饭Cost
			{
				Use努力加餐饭 = selected,
				努力加餐饭CostItemId = 努力加餐饭Config.CosumeItemId,
				努力加餐饭CostValue = cosumeCount
			});
		};
	}

	private bool IsJumpModeAvailable()
	{
		if (StayIslandId == _mainUi.CurrentIslandId)
		{
			_canNotJumpTip = "GvG3CanNotJumpTip3".ToLanguage();
			return false;
		}
		IslandStateModel islandStateModel = Singleton<WorldStateManager>.Instance.TryGetIsland(_mainUi.CurrentIslandId);
		if (islandStateModel.State == eGvGMode3IslandState.Fighting)
		{
			_canNotJumpTip = "GvG3CanNotJumpTip1".ToLanguage();
			return false;
		}
		if (islandStateModel.GetBelongStatus() != eGvGMode3IslandBelongStatus.OwnSide)
		{
			_canNotJumpTip = "GvG3CanNotJumpTip2".ToLanguage();
			return false;
		}
		return true;
	}

	public void ShowFlightData()
	{
		_shipState = Singleton<WorldStateManager>.Instance.TryGetShip(ShipEntityId);
		if (_shipState != null)
		{
			ShipStateModel shipState = _shipState;
			shipState.OnChange = (Action<ShipStateModel>)Delegate.Combine(shipState.OnChange, new Action<ShipStateModel>(OnShipStateChange));
		}
		if (StayIslandId == _mainUi.CurrentIslandId && _mainUi.IslandActionType == eIslandAction.FillUpSoldier && _mainUi.IslandActionType == eIslandAction.FillUpSoldier)
		{
			ShowFlightSchedule(null);
		}
		else
		{
			Singleton<GvGShipUiInfoManager>.Instance.SyncPreFlightSchedule(ShipId, StayIslandId, _mainUi.CurrentIslandId, (int)_mainUi.IslandActionType, ShowFlightSchedule);
		}
		void ShowFlightSchedule(C2S_GetPreFlightSchedule.Response response)
		{
			if (response != null && response.ErrorCode < 0)
			{
				ErrorExecute();
			}
			else
			{
				SuccessExecute();
			}
			void ErrorExecute()
			{
				int num = Mathf.Abs(response.ErrorCode) - 200000;
				if (1 <= num && num <= 4)
				{
					GvGWorldMapController.Instance.RouteManager.ShowNullRoute(StayIslandId, _mainUi.CurrentIslandId);
					_canNotArrive = true;
					FlightData.selectedIndex = 2;
					RenderDialog(response);
					((GObject)Operation_Goto).enabled = false;
					((GObject)CleanUp).enabled = false;
					((GObject)Collect).enabled = false;
					((GObject)FillUp).enabled = false;
					_mainUi.ShowOperationDialog.Play();
				}
			}
			void SuccessExecute()
			{
				FlightData.selectedIndex = 1;
				RenderDialog(response);
				if (response?.Route != null)
				{
					GvGWorldMapController.Instance.RouteManager.ShowRoute(response.Route);
				}
				_mainUi.ShowOperationDialog.Play();
			}
		}
	}

	public void ShowDialog()
	{
		FlightData.selectedIndex = 0;
		TryInitButtonHandlers();
		RenderDialog(null);
		_mainUi.ShowOperationDialog.Play();
	}

	public void HideDialog()
	{
		GvGWorldMapController.Instance.RouteManager.EraseRoute();
		if (_canNotArrive)
		{
			_canNotArrive = false;
			((GObject)TimeCost).visible = true;
			((GObject)n49).visible = true;
		}
		_ignoreIslandAction = string.Empty;
		_canNotJumpTip = string.Empty;
		((GObject)Food).text = string.Empty;
		_jumpFoodCost = 0;
		ClearSpecialSuppressRecord();
		if (_shipState != null)
		{
			ShipStateModel shipState = _shipState;
			shipState.OnChange = (Action<ShipStateModel>)Delegate.Remove(shipState.OnChange, new Action<ShipStateModel>(OnShipStateChange));
		}
	}

	public bool TryIgnoreIslandActionSuccess(int actionType)
	{
		if (string.IsNullOrEmpty(_ignoreIslandAction))
		{
			return false;
		}
		eIslandAction eIslandAction = (eIslandAction)actionType;
		string b = eIslandAction.ToString();
		if (!string.Equals(_ignoreIslandAction, b))
		{
			return false;
		}
		_ignoreIslandAction = string.Empty;
		return true;
	}

	public void Init(UI_main_GvGWorldMap3 mainUi)
	{
		//IL_0054: Unknown result type (might be due to invalid IL or missing references)
		//IL_005a: Unknown result type (might be due to invalid IL or missing references)
		_mainUi = mainUi;
		((GObject)TimeCost2).text = "00:00";
		((GObject)Separator).text = "/";
		GvGTalentUiModel gvGTalentUiModel = Singleton<GvGTalentsManager>.Instance.GeTalentUiModel(125);
		FreeJumpTips.JumpBuff.SetPopupTips(gvGTalentUiModel.Name + ":-100%");
	}

	public void RegisterEvent()
	{
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_001d: Expected O, but got Unknown
		//IL_0030: Unknown result type (might be due to invalid IL or missing references)
		//IL_003a: Expected O, but got Unknown
		//IL_004d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0057: Expected O, but got Unknown
		//IL_006a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0074: Expected O, but got Unknown
		//IL_0087: Unknown result type (might be due to invalid IL or missing references)
		//IL_0091: Expected O, but got Unknown
		//IL_00a4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ae: Expected O, but got Unknown
		//IL_00c1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00cb: Expected O, but got Unknown
		//IL_00de: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e8: Expected O, but got Unknown
		//IL_00fb: Unknown result type (might be due to invalid IL or missing references)
		//IL_0105: Expected O, but got Unknown
		//IL_011d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0127: Expected O, but got Unknown
		//IL_013f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0149: Expected O, but got Unknown
		//IL_0161: Unknown result type (might be due to invalid IL or missing references)
		//IL_016b: Expected O, but got Unknown
		((GObject)Operation_Goto).onClick.Set(new EventCallback0(OperationGoTo));
		((GObject)CleanUp).onClick.Set(new EventCallback0(OperationClearUp));
		((GObject)Attack).onClick.Set(new EventCallback0(OperationAttack));
		((GObject)Collect).onClick.Set(new EventCallback0(OperationCollect));
		((GObject)FillUp).onClick.Set(new EventCallback0(OperationFillUp));
		AutoCollection.onChanged.Set(new EventCallback0(UpdateNextActionFoodCost));
		((GObject)Jump).onClick.Set(new EventCallback0(OnClickJumpBtn));
		JumpMode.onChanged.Set(new EventCallback0(JumpModeOnChange));
		((GObject)FakeJumpBtn).onClick.Set(new EventCallback0(ShowCanNotJumpTip));
		((GObject)FreeJumpTips.JumpBuff).onClick.Set(new EventCallback1(ShowJumpBuffEffect));
		((GButton)努力加餐饭.UseTech).onChanged.Set(new EventCallback0(OnJumpUseTechSwitchChanged));
		((GObject)努力加餐饭.Buff).onClick.Set(new EventCallback1(ShowFoodCostReduceText));
	}

	private void UpdateNextActionFoodCost()
	{
		GameLocalDataManager.SetBool("AutoCollectSelected", ((GButton)AutoCollect).selected);
		if (NextCollection && string.IsNullOrEmpty(((GObject)Food).text))
		{
			((GObject)Food).text = GvGWorldMapController.Instance.IslandActionManager.CalcIslandActionCost(eIslandAction.Collect, _mainUi.CurrentIslandId, _foodCostReduce).ToString();
		}
	}

	public void UnregisterEvent()
	{
		((GObject)Operation_Goto).onClick.Clear();
		((GObject)CleanUp).onClick.Clear();
		((GObject)Attack).onClick.Clear();
		((GObject)Collect).onClick.Clear();
		((GObject)FillUp).onClick.Clear();
		AutoCollection.onChanged.Clear();
		((GObject)Jump).onClick.Clear();
		JumpMode.onChanged.Clear();
		((GObject)FakeJumpBtn).onClick.Clear();
		((GObject)FreeJumpTips.JumpBuff).onClick.Clear();
		((GButton)努力加餐饭.UseTech).onChanged.Clear();
		((GObject)努力加餐饭.Buff).onClick.Clear();
	}

	public void OnDestroy()
	{
		_mainUi = null;
	}

	private void OnShipStateChange(ShipStateModel newState)
	{
		string arg = ((newState.FoodOnboardCount >= FoodCostCount) ? "#FFF2CC" : "#ff1a1a");
		((GObject)FoodCost).text = $"[color={arg}]{newState.FoodOnboardCount}[/color]/{FoodCostCount}";
		if (OperationType.selectedIndex == 3)
		{
			GTextField foodCost = FoodCost;
			((GObject)foodCost).text = ((GObject)foodCost).text + FoodCostUnit;
		}
		RefreshFoodEstimate(newState.FoodOnboardCount);
	}

	private void RefreshFoodEstimate(int foodOnBoardCount)
	{
		if (_mainUi != null)
		{
			if (FoodCostCount == 0)
			{
				((GObject)estimatedTime).visible = false;
				return;
			}
			string desc = LanguagesManager.GetDesc("GvG3OperationFoodEstimateTime");
			int num = foodOnBoardCount / FoodCostCount;
			int time = num * 60 * 10;
			bool visible = num > 0 && _mainUi.IslandActionType == eIslandAction.Collect && JumpMode.selectedIndex == 0;
			((GObject)estimatedTime).text = string.Format(desc, UiHelper.ParseTime(time));
			((GObject)estimatedTime).visible = visible;
		}
	}

	private void RenderDialog(C2S_GetPreFlightSchedule.Response response)
	{
		HasJumpMode.selectedIndex = ((response != null && IsJumpModeAvailable()) ? 1 : 0);
		JumpMode.selectedIndex = 0;
		switch (_mainUi.IslandActionType)
		{
		case eIslandAction.Attack:
			OperationType.selectedIndex = 2;
			break;
		case eIslandAction.GoTo:
			OperationType.selectedIndex = 0;
			break;
		case eIslandAction.SuppressRebellion:
			OperationType.selectedIndex = 1;
			break;
		case eIslandAction.Collect:
			OperationType.selectedIndex = 3;
			break;
		case eIslandAction.FillUpSoldier:
			OperationType.selectedIndex = 4;
			break;
		}
		ShowOperationInfo(response);
	}

	private void ShowOperationInfo(C2S_GetPreFlightSchedule.Response response)
	{
		bool flag = response != null;
		FoodCostCount = Convert.ToInt32(response?.FoodCost);
		((GObject)EndIslandName).text = WorldMapConfigHelper.Configs.TryGetIsland(_mainUi.CurrentIslandId).Name;
		((GObject)StartIslandName).text = (flag ? WorldMapConfigHelper.Configs.TryGetIsland(StayIslandId).Name : "--");
		((GObject)Distance).text = (flag ? $"{Convert.ToInt32(response.FlyDist)}" : "0");
		((GObject)JumpDist).text = (flag ? $"{Convert.ToInt32(response.JumpDist)}" : "0");
		if (flag)
		{
			string arg = ((_shipState.FoodOnboardCount >= FoodCostCount) ? "#FFF2CC" : "#ff1a1a");
			string arg2 = $"[color={arg}]{_shipState.FoodOnboardCount}[/color]";
			((GObject)FoodCost).text = $"{arg2}/{FoodCostCount}";
			if (OperationType.selectedIndex == 3)
			{
				GTextField foodCost = FoodCost;
				((GObject)foodCost).text = ((GObject)foodCost).text + FoodCostUnit;
			}
			RefreshFoodEstimate(_shipState.FoodOnboardCount);
			_jumpFoodCost = response.JumpFoodCost;
			arg = ((_shipState.FoodOnboardCount >= response.JumpFoodCost) ? "#FFF2CC" : "#ff1a1a");
			arg2 = $"[color={arg}]{_shipState.FoodOnboardCount}[/color]";
			((GObject)TotalFood).text = arg2 ?? "";
			((GObject)JumpFoodCost).text = $"{response.JumpFoodCost}";
			HasFreeJumps.selectedIndex = ((response.FreeJumps > 0) ? 1 : 0);
		}
		else
		{
			((GObject)FoodCost).text = "--";
		}
		((GObject)Speed).text = (flag ? $"{Convert.ToInt32(response.ShipSummarySpeed)}" : "0");
		((GObject)TimeCost).text = (flag ? UiHelper.ParseTime_Foo(response.TimeCost) : "0");
		((GObject)AutoCollect).enabled = flag;
		((GObject)Operation_Goto).enabled = flag;
		((GObject)CleanUp).enabled = flag;
		((GObject)Attack).enabled = flag;
		((GObject)Collect).enabled = flag;
		((GObject)FillUp).enabled = FlightData.selectedIndex == 1;
		((GObject)FoodBuff).visible = flag;
		SetAutoCollection();
		DisplayJump努力加餐饭Switch();
		if (flag)
		{
			SetBuffButtonsVisible();
		}
	}

	private void SetAutoCollection()
	{
		((GButton)AutoCollect).selected = GameLocalDataManager.HasKey("AutoCollectSelected") && GameLocalDataManager.GetBool("AutoCollectSelected");
	}

	private void SetBuffButtonsVisible()
	{
		((GObject)FoodBuff).onClick.Clear();
		((GObject)SpeedBuff).onClick.Clear();
		((GObject)JumpFoodBuff).onClick.Clear();
		((GObject)FoodBuff).visible = false;
		((GObject)SpeedBuff).visible = false;
		((GObject)JumpFoodBuff).visible = false;
		_shipSummarySpeed = null;
		_foodCostReduce = null;
		Singleton<GvGShipUiInfoManager>.Instance.GetRealTimeFoodCostReduce(ShipId, _mainUi.CurrentIslandId, ShowFoodBuff);
		Singleton<GvGShipUiInfoManager>.Instance.GetRealTimeShipSummarySpeed(ShipId, _mainUi.CurrentIslandId, ShowSpeedBuff);
		void ShowFoodBuff(RealTimeFoodCostReduceModel model)
		{
			//IL_0040: Unknown result type (might be due to invalid IL or missing references)
			//IL_004a: Expected O, but got Unknown
			//IL_0083: Unknown result type (might be due to invalid IL or missing references)
			//IL_008d: Expected O, but got Unknown
			_foodCostReduce = model;
			((GObject)FoodBuff).visible = model.Total > 0f;
			((GObject)FoodBuff).enabled = true;
			((GObject)FoodBuff).onClick.Set(new EventCallback1(ShowFoodCostReduceText));
			((GObject)JumpFoodBuff).visible = model.Total > 0f;
			((GObject)JumpFoodBuff).enabled = true;
			((GObject)JumpFoodBuff).onClick.Set(new EventCallback1(ShowFoodCostReduceText));
			Display努力加餐饭CostBuff(((GObject)FoodBuff).visible);
		}
		void ShowSpeedBuff(RealTimeShipSummarySpeedModel model)
		{
			//IL_0033: Unknown result type (might be due to invalid IL or missing references)
			//IL_003d: Expected O, but got Unknown
			_shipSummarySpeed = model;
			((GObject)SpeedBuff).visible = model.Total > 1f;
			((GObject)SpeedBuff).onClick.Set(new EventCallback1(ShowRealTimeSpeedText));
		}
	}

	private void ShowRealTimeSpeedText(EventContext context)
	{
		//IL_000e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0014: Expected O, but got Unknown
		//IL_0024: Unknown result type (might be due to invalid IL or missing references)
		//IL_002a: Unknown result type (might be due to invalid IL or missing references)
		context.StopPropagation();
		GObject target = (GObject)context.sender;
		FairyGUITip.ShowTip(target, eFairyGUITipDir.Up, delegate(UI_com_UniversalPopupTip popup)
		{
			((GObject)popup.title).text = _shipSummarySpeed.GetEfficiencyText();
		});
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

	private void ShowJumpBuffEffect(EventContext context)
	{
		//IL_000e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0014: Expected O, but got Unknown
		//IL_0024: Unknown result type (might be due to invalid IL or missing references)
		//IL_002a: Unknown result type (might be due to invalid IL or missing references)
		context.StopPropagation();
		GObject target = (GObject)context.sender;
		FairyGUITip.ShowTip(target, eFairyGUITipDir.Up, delegate(UI_com_UniversalPopupTip popup)
		{
			((GObject)popup.title).text = 跃迁专精Effect;
		});
	}
}
