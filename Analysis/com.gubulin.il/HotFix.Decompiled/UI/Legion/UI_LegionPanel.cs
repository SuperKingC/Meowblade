using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using Assets.Scripts.Managers;
using Assets.Scripts.UI;
using FairyGUI;
using FairyGUI.Utils;
using GameDataEditor;
using GameMaths;
using HotFix.Sources.Base.Sources.Scripts.GvG3Common.Model;
using HotFix.Sources.Base.Sources.Scripts.GvG3UI.Helper;
using HotFix.Sources.Base.Sources.Scripts.GvG3UI.Model;
using Shift.Legion.ClientApi.Protocol.UserAction;
using Shift.Legion.Common.Enums;
using Shift.Legion.Common.Helpers;
using Shift.Legion.Common.Managers;
using Shift.Legion.Common.Models;
using Shift.Legion.Common.Services;
using Shift.Legion.Common.Sources.Enums;
using Spine.Unity;
using UI.Battle;
using UI.LegendItemDungeon;
using UI.SoldierCultivate;
using UI.Tips;
using UI.WorldMap;
using UnityEngine;

namespace UI.Legion;

public class UI_LegionPanel : GComponent, IUiController
{
	public Controller controller;

	public Controller SpecificRace;

	public GLoader background;

	public GImage armsBtnDark;

	public GImage chipBtnDark;

	public GImage n96;

	public GImage n134;

	public GImage n135;

	public GGroup backAndCrack;

	public GImage backB;

	public GImage n132;

	public GImage n133;

	public GGroup backGroup;

	public UI_Title Title;

	public GComponent addWorkerBtn;

	public GButton diamondAddBtn;

	public GButton backBtn;

	public GImage armsBtnLight;

	public UI_switchButtonA armsBtn;

	public GImage chipBtnLight;

	public UI_switchButtonB chipBtn;

	public GImage n151;

	public GImage n152;

	public GGraph endChooseClick;

	public GImage n136;

	public GImage n137;

	public GImage n138;

	public GGroup chooseListBackGroup;

	public GList armsList;

	public UI_ArmsList ArmsList;

	public GList chipsList;

	public UI_LegionRaceFilters LegionRaceFilters;

	public GImage n116;

	public GImage n117;

	public GTextField stockLimitTitle;

	public GTextField stockLimit;

	public GImage n121;

	public GButton ExclamationMarkBtn;

	public GGroup stockLimitGroup;

	public GImage n127;

	public GTextField totalPower;

	public GGraph workUI;

	public UI_IntroductionPanelA IntroductionPanel;

	public GTextField tip1;

	public GImage n139;

	public GButton ConfirmBtn;

	public GButton IslandComeAgainConfirm;

	public GTextField n141;

	public GTextField n142;

	public GTextField LegionNumber;

	public GTextField n144;

	public GButton Race;

	public GTextField RaceNumber;

	public GGroup n147;

	public const string URL = "ui://lrhs6zw7l9gz4";

	public static string Name = "UI_LegionPanel";

	private UI_StationConfirmPanel StationConfirmPanel;

	private string curSelectSoldierId;

	private List<string> stationConfirmPanelShaderList = new List<string>();

	private const int IslandComeAgainMaxSoldierNum = 5;

	private List<string> IslandComeAgainInitialSoldiers = new List<string>();

	private List<string> IslandComeAgainSelectSoldier = new List<string>();

	private string currentFaction = "";

	private List<Soldier> soldierRenderListA = new List<Soldier>();

	private List<Soldier> soldierRenderListB = new List<Soldier>();

	private List<Soldier> soldierRenderListC = new List<Soldier>();

	private List<Soldier> unlockSoldierRenderList = new List<Soldier>();

	private List<GComponent> allRuneGComponents = new List<GComponent>();

	private const int LegendItemsLimit = 2;

	private List<string> fakeSoldierDatas = new List<string>();

	private Dictionary<string, string> formationUnits = new Dictionary<string, string>();

	public SpriteMask ArmsListSpriteMask;

	private readonly string[] attackTypeNames = new string[4]
	{
		LanguagesManager.GetDesc("CsharpCodeZhTcText196"),
		LanguagesManager.GetDesc("CsharpCodeZhTcText197"),
		LanguagesManager.GetDesc("CsharpCodeZhTcText198"),
		LanguagesManager.GetDesc("CsharpCodeZhTcText199")
	};

	private readonly string[] armorTypeNames = new string[4]
	{
		LanguagesManager.GetDesc("CsharpCodeZhTcText200"),
		LanguagesManager.GetDesc("CsharpCodeZhTcText201"),
		LanguagesManager.GetDesc("CsharpCodeZhTcText202"),
		LanguagesManager.GetDesc("CsharpCodeZhTcText203")
	};

	private readonly Color32[] SoldierNameColor1 = (Color32[])(object)new Color32[6]
	{
		new Color32((byte)106, (byte)178, (byte)31, byte.MaxValue),
		new Color32((byte)52, (byte)119, (byte)181, byte.MaxValue),
		new Color32((byte)104, (byte)40, (byte)133, byte.MaxValue),
		new Color32((byte)145, (byte)45, (byte)10, byte.MaxValue),
		new Color32((byte)220, (byte)95, (byte)5, byte.MaxValue),
		new Color32((byte)217, (byte)0, (byte)36, byte.MaxValue)
	};

	public List<Soldier> SoldierList = new List<Soldier>();

	public readonly List<Soldier> LockSoldierList = new List<Soldier>();

	private readonly Color32[] SoldierNameColor2 = (Color32[])(object)new Color32[6]
	{
		new Color32((byte)106, (byte)178, (byte)31, byte.MaxValue),
		new Color32((byte)52, (byte)119, (byte)181, byte.MaxValue),
		new Color32((byte)150, (byte)56, (byte)192, byte.MaxValue),
		new Color32((byte)186, (byte)54, (byte)7, byte.MaxValue),
		new Color32((byte)220, (byte)95, (byte)5, byte.MaxValue),
		new Color32(byte.MaxValue, (byte)26, (byte)45, byte.MaxValue)
	};

	private EventCallback1 callback1;

	private EventCallback1 callback2;

	private List<int> Updatelist = new List<int>();

	private List<string> _piecesAllKeys = new List<string>();

	private List<Pieces> ChipsList = new List<Pieces>();

	private GoWrapper gw1;

	private GoWrapper gw2;

	private GameObject workerObj;

	private bool chosenMode;

	private int _chosenType;

	private bool _fromGvG3ModeShipDetail;

	private Stronghold curStronghold;

	private UI_WorldMapPanel WorldMapPanel;

	private List<string> textureList = new List<string>();

	private List<string> shaderList = new List<string>();

	private bool onlyUnlocked = false;

	private bool includeEmptyStock = true;

	private List<List<string>> soldierFilter;

	private List<string> pvpSelectedSoldiers;

	private List<string> islandComeAgainSelectSoldiers = new List<string>();

	private bool needSaveIslandComeAgainSoldiers;

	private bool isLegendItemDungeon;

	private Coroutine _Coroutine_RenderArmList;

	private Coroutine _Coroutine_RenderLegendSoldiers;

	private UICallbackParam<Action<GvGMode3SoldierSelected>> _selectedWithTickOnConfirm;

	private List<string> _selectedWithTick;

	private int _selectedWithTickMaxCount;

	private int _raceTypeGvGMode3 = -1;

	private int _raceMinCount;

	private bool _isCurGroup;

	private int _selectedRaceLegionCnt;

	private float topY { get; set; }

	private float bottomY { get; set; }

	private bool IsIslandComeAgain => chosenMode && _chosenType == 10;

	private bool IsGvGMode3 => _selectedWithTick != null && chosenMode && _chosenType == 9;

	public static string GetURL()
	{
		return "ui://lrhs6zw7l9gz4";
	}

	public static UI_LegionPanel CreateInstance()
	{
		return (UI_LegionPanel)(object)UIPackage.CreateObject("Legion", "LegionPanel");
	}

	public static UI_LegionPanel CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_LegionPanel).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://lrhs6zw7l9gz4", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		//IL_0113: Unknown result type (might be due to invalid IL or missing references)
		//IL_011d: Expected O, but got Unknown
		//IL_013f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0149: Expected O, but got Unknown
		//IL_0155: Unknown result type (might be due to invalid IL or missing references)
		//IL_015f: Expected O, but got Unknown
		//IL_016b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0175: Expected O, but got Unknown
		//IL_0181: Unknown result type (might be due to invalid IL or missing references)
		//IL_018b: Expected O, but got Unknown
		//IL_01ad: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b7: Expected O, but got Unknown
		//IL_01d9: Unknown result type (might be due to invalid IL or missing references)
		//IL_01e3: Expected O, but got Unknown
		//IL_01ef: Unknown result type (might be due to invalid IL or missing references)
		//IL_01f9: Expected O, but got Unknown
		//IL_0205: Unknown result type (might be due to invalid IL or missing references)
		//IL_020f: Expected O, but got Unknown
		//IL_021b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0225: Expected O, but got Unknown
		//IL_0231: Unknown result type (might be due to invalid IL or missing references)
		//IL_023b: Expected O, but got Unknown
		//IL_0247: Unknown result type (might be due to invalid IL or missing references)
		//IL_0251: Expected O, but got Unknown
		//IL_025d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0267: Expected O, but got Unknown
		//IL_0273: Unknown result type (might be due to invalid IL or missing references)
		//IL_027d: Expected O, but got Unknown
		//IL_029f: Unknown result type (might be due to invalid IL or missing references)
		//IL_02a9: Expected O, but got Unknown
		//IL_02cb: Unknown result type (might be due to invalid IL or missing references)
		//IL_02d5: Expected O, but got Unknown
		//IL_02e1: Unknown result type (might be due to invalid IL or missing references)
		//IL_02eb: Expected O, but got Unknown
		//IL_02f7: Unknown result type (might be due to invalid IL or missing references)
		//IL_0301: Expected O, but got Unknown
		//IL_034a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0354: Expected O, but got Unknown
		//IL_039d: Unknown result type (might be due to invalid IL or missing references)
		//IL_03a7: Expected O, but got Unknown
		//IL_03b3: Unknown result type (might be due to invalid IL or missing references)
		//IL_03bd: Expected O, but got Unknown
		//IL_03c9: Unknown result type (might be due to invalid IL or missing references)
		//IL_03d3: Expected O, but got Unknown
		//IL_03df: Unknown result type (might be due to invalid IL or missing references)
		//IL_03e9: Expected O, but got Unknown
		//IL_03f5: Unknown result type (might be due to invalid IL or missing references)
		//IL_03ff: Expected O, but got Unknown
		//IL_0448: Unknown result type (might be due to invalid IL or missing references)
		//IL_0452: Expected O, but got Unknown
		//IL_0474: Unknown result type (might be due to invalid IL or missing references)
		//IL_047e: Expected O, but got Unknown
		//IL_04c7: Unknown result type (might be due to invalid IL or missing references)
		//IL_04d1: Expected O, but got Unknown
		//IL_04dd: Unknown result type (might be due to invalid IL or missing references)
		//IL_04e7: Expected O, but got Unknown
		//IL_04f3: Unknown result type (might be due to invalid IL or missing references)
		//IL_04fd: Expected O, but got Unknown
		//IL_0509: Unknown result type (might be due to invalid IL or missing references)
		//IL_0513: Expected O, but got Unknown
		//IL_055e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0568: Expected O, but got Unknown
		//IL_05b3: Unknown result type (might be due to invalid IL or missing references)
		//IL_05bd: Expected O, but got Unknown
		//IL_05c9: Unknown result type (might be due to invalid IL or missing references)
		//IL_05d3: Expected O, but got Unknown
		//IL_061e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0628: Expected O, but got Unknown
		//IL_0634: Unknown result type (might be due to invalid IL or missing references)
		//IL_063e: Expected O, but got Unknown
		//IL_064a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0654: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		controller = ((GComponent)this).GetController("controller");
		SpecificRace = ((GComponent)this).GetController("SpecificRace");
		background = (GLoader)((GComponent)this).GetChild("background");
		armsBtnDark = (GImage)((GComponent)this).GetChild("armsBtnDark");
		chipBtnDark = (GImage)((GComponent)this).GetChild("chipBtnDark");
		n96 = (GImage)((GComponent)this).GetChild("n96");
		n134 = (GImage)((GComponent)this).GetChild("n134");
		n135 = (GImage)((GComponent)this).GetChild("n135");
		backAndCrack = (GGroup)((GComponent)this).GetChild("backAndCrack");
		backB = (GImage)((GComponent)this).GetChild("backB");
		n132 = (GImage)((GComponent)this).GetChild("n132");
		n133 = (GImage)((GComponent)this).GetChild("n133");
		backGroup = (GGroup)((GComponent)this).GetChild("backGroup");
		Title = (UI_Title)(object)((GComponent)this).GetChild("Title");
		addWorkerBtn = (GComponent)((GComponent)this).GetChild("addWorkerBtn");
		diamondAddBtn = (GButton)((GComponent)this).GetChild("diamondAddBtn");
		backBtn = (GButton)((GComponent)this).GetChild("backBtn");
		armsBtnLight = (GImage)((GComponent)this).GetChild("armsBtnLight");
		armsBtn = (UI_switchButtonA)(object)((GComponent)this).GetChild("armsBtn");
		chipBtnLight = (GImage)((GComponent)this).GetChild("chipBtnLight");
		chipBtn = (UI_switchButtonB)(object)((GComponent)this).GetChild("chipBtn");
		n151 = (GImage)((GComponent)this).GetChild("n151");
		n152 = (GImage)((GComponent)this).GetChild("n152");
		endChooseClick = (GGraph)((GComponent)this).GetChild("endChooseClick");
		n136 = (GImage)((GComponent)this).GetChild("n136");
		n137 = (GImage)((GComponent)this).GetChild("n137");
		n138 = (GImage)((GComponent)this).GetChild("n138");
		chooseListBackGroup = (GGroup)((GComponent)this).GetChild("chooseListBackGroup");
		armsList = (GList)((GComponent)this).GetChild("armsList");
		ArmsList = (UI_ArmsList)(object)((GComponent)this).GetChild("ArmsList");
		chipsList = (GList)((GComponent)this).GetChild("chipsList");
		LegionRaceFilters = (UI_LegionRaceFilters)(object)((GComponent)this).GetChild("LegionRaceFilters");
		n116 = (GImage)((GComponent)this).GetChild("n116");
		n117 = (GImage)((GComponent)this).GetChild("n117");
		stockLimitTitle = (GTextField)((GComponent)this).GetChild("stockLimitTitle");
		string id = "ui://lrhs6zw7l9gz4".Replace("ui://", "") + "-" + ((GObject)stockLimitTitle).id;
		((GObject)stockLimitTitle).text = LanguagesManager.GetDesc(id);
		stockLimit = (GTextField)((GComponent)this).GetChild("stockLimit");
		string id2 = "ui://lrhs6zw7l9gz4".Replace("ui://", "") + "-" + ((GObject)stockLimit).id;
		((GObject)stockLimit).text = LanguagesManager.GetDesc(id2);
		n121 = (GImage)((GComponent)this).GetChild("n121");
		ExclamationMarkBtn = (GButton)((GComponent)this).GetChild("ExclamationMarkBtn");
		stockLimitGroup = (GGroup)((GComponent)this).GetChild("stockLimitGroup");
		n127 = (GImage)((GComponent)this).GetChild("n127");
		totalPower = (GTextField)((GComponent)this).GetChild("totalPower");
		string id3 = "ui://lrhs6zw7l9gz4".Replace("ui://", "") + "-" + ((GObject)totalPower).id;
		((GObject)totalPower).text = LanguagesManager.GetDesc(id3);
		workUI = (GGraph)((GComponent)this).GetChild("workUI");
		IntroductionPanel = (UI_IntroductionPanelA)(object)((GComponent)this).GetChild("IntroductionPanel");
		tip1 = (GTextField)((GComponent)this).GetChild("tip1");
		string id4 = "ui://lrhs6zw7l9gz4".Replace("ui://", "") + "-" + ((GObject)tip1).id;
		((GObject)tip1).text = LanguagesManager.GetDesc(id4);
		n139 = (GImage)((GComponent)this).GetChild("n139");
		ConfirmBtn = (GButton)((GComponent)this).GetChild("ConfirmBtn");
		IslandComeAgainConfirm = (GButton)((GComponent)this).GetChild("IslandComeAgainConfirm");
		n141 = (GTextField)((GComponent)this).GetChild("n141");
		string id5 = "ui://lrhs6zw7l9gz4".Replace("ui://", "") + "-" + ((GObject)n141).id;
		((GObject)n141).text = LanguagesManager.GetDesc(id5);
		n142 = (GTextField)((GComponent)this).GetChild("n142");
		string id6 = "ui://lrhs6zw7l9gz4".Replace("ui://", "") + "-" + ((GObject)n142).id;
		((GObject)n142).text = LanguagesManager.GetDesc(id6);
		LegionNumber = (GTextField)((GComponent)this).GetChild("LegionNumber");
		n144 = (GTextField)((GComponent)this).GetChild("n144");
		string id7 = "ui://lrhs6zw7l9gz4".Replace("ui://", "") + "-" + ((GObject)n144).id;
		((GObject)n144).text = LanguagesManager.GetDesc(id7);
		Race = (GButton)((GComponent)this).GetChild("Race");
		RaceNumber = (GTextField)((GComponent)this).GetChild("RaceNumber");
		n147 = (GGroup)((GComponent)this).GetChild("n147");
	}

	private void StationConfirmPanelInit(string soldierId)
	{
		//IL_008b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0095: Expected O, but got Unknown
		//IL_00c9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ce: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ef: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f4: Unknown result type (might be due to invalid IL or missing references)
		//IL_0115: Unknown result type (might be due to invalid IL or missing references)
		//IL_011a: Unknown result type (might be due to invalid IL or missing references)
		//IL_03e6: Unknown result type (might be due to invalid IL or missing references)
		//IL_03f0: Expected O, but got Unknown
		//IL_0403: Unknown result type (might be due to invalid IL or missing references)
		//IL_040d: Expected O, but got Unknown
		//IL_0420: Unknown result type (might be due to invalid IL or missing references)
		//IL_042a: Expected O, but got Unknown
		//IL_043d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0447: Expected O, but got Unknown
		//IL_045f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0469: Expected O, but got Unknown
		//IL_0317: Unknown result type (might be due to invalid IL or missing references)
		//IL_0321: Expected O, but got Unknown
		if (StationConfirmPanel != null)
		{
			return;
		}
		curSelectSoldierId = soldierId;
		StationConfirmPanel = UI_StationConfirmPanel.CreateInstance();
		((GComponent)this).AddChild((GObject)(object)StationConfirmPanel);
		((GObject)StationConfirmPanel).SetXY(0f, 0f);
		FGUIManager.SetToFullScreen((GObject)(object)StationConfirmPanel);
		UI_StationConfirmDialog dialog = StationConfirmPanel.Dialog;
		dialog.SetButtonTitle();
		dialog.PageController.selectedIndex = 0;
		RenderSoldierIcon(soldierId);
		dialog.earningsDetailList.itemRenderer = new ListItemRenderer(RenderEarningsItem);
		dialog.earningsDetailList.numItems = curStronghold.Tags.Count + 1;
		((GTextField)dialog.stationBtn.title).strokeColor = Color32.op_Implicit(new Color32((byte)60, (byte)72, (byte)13, (byte)229));
		((GTextField)dialog.replaceAssembledBtn.title).strokeColor = Color32.op_Implicit(new Color32((byte)60, (byte)72, (byte)13, (byte)229));
		((GTextField)dialog.replaceStationedBtn.title).strokeColor = Color32.op_Implicit(new Color32((byte)60, (byte)72, (byte)13, (byte)229));
		float num = curStronghold.CalcOccupantEfficiencyModifier(GameManagers.Instance, soldierId);
		int num2 = ((curStronghold.Region.RegionId == "REGION11") ? 1 : 20);
		((GObject)dialog.totalModifier).text = $"[color=#fffee9]{num2}/h[/color] [color={UiHelper.GetStrongHoldModifierColor(num)}]+{UiHelper.RemoveSurplusZeroBehindDecimalPoint($"{Convert.ToInt32(num * 100f)}")}%[/color]";
		int num3 = 0;
		if (GameManagers.Instance.UserArchiveManager.GetAssignedSoldiers().Contains(soldierId))
		{
			num3 = 2;
		}
		if (num3 == 2)
		{
			Stronghold stronghold = FindStrongholdBySoldierId(curSelectSoldierId);
			if (stronghold != null)
			{
				if (curStronghold.StrongholdId == stronghold.StrongholdId)
				{
					List<string> arg = new List<string> { LanguagesManager.GetDesc("CsharpCodeZhTcText364") };
					SharedMessenger.Broadcast("SHOW_TIPS", arg, ((GObject)this).sortingOrder, arg3: false);
					CloseStationConfirmPanel();
					return;
				}
				((GObject)dialog.tip2nd).text = LanguagesManager.GetDesc("CsharpCodeZhTcText366") + "[color=#f6e2b2]" + stronghold.Region.Data.Name + "[/color]" + LanguagesManager.GetDesc("CsharpCodeZhTcText367");
				if (stronghold.ProductionsConfig != null)
				{
					using Dictionary<string, int>.Enumerator enumerator = stronghold.ProductionsConfig.GetEnumerator();
					if (enumerator.MoveNext())
					{
						KeyValuePair<string, int> prodKv = enumerator.Current;
						dialog.itemIcon.url = "ui://PublicResources/" + UiHelper.GetIconPath(prodKv.Key);
						((GObject)dialog.itemIcon).onClick.Set((EventCallback0)delegate
						{
							FGUIManager.Instance.ItemTip(prodKv.Key, ((GObject)this).sortingOrder, noCheckBtn: true);
						});
					}
				}
				float num4 = stronghold.CalcOccupantEfficiencyModifier(GameManagers.Instance, soldierId);
				((GObject)dialog.tip3rd).text = "[color=" + UiHelper.GetStrongHoldModifierColor(num4) + "]+(" + UiHelper.RemoveSurplusZeroBehindDecimalPoint($"{Convert.ToInt32(num4 * 100f)}") + "%)[/color]," + LanguagesManager.GetDesc("CsharpCodeZhTcText368") + "?";
			}
		}
		((GObject)dialog.stationBtn).data = num3;
		((GObject)dialog.stationBtn).onClick.Add(new EventCallback1(StationBtnEvent));
		((GObject)dialog.cancelBtn).onClick.Add(new EventCallback0(CancelBtnEvent));
		((GObject)dialog.replaceAssembledBtn).onClick.Add(new EventCallback1(ReplaceAssembledEvent));
		((GObject)dialog.replaceStationedBtn).onClick.Add(new EventCallback1(ReplaceStationedEvent));
		((GObject)StationConfirmPanel.transparentMask).onClick.Add(new EventCallback0(CloseStationConfirmPanel));
		StationConfirmPanel.ShowDialog.Play();
		UiTagManager instance = UiTagManager.Instance;
		instance.Unregister("StationConfirmPanel.AssignBtn");
		instance.Register("StationConfirmPanel.AssignBtn", dialog.stationBtn);
		SharedMessenger.Broadcast("OPEN_UI", Name, new Dictionary<string, object> { { "SoldierId", soldierId } });
	}

	private void RenderSoldierIcon(string soldierId)
	{
		//IL_0409: Unknown result type (might be due to invalid IL or missing references)
		//IL_03f8: Unknown result type (might be due to invalid IL or missing references)
		//IL_040e: Unknown result type (might be due to invalid IL or missing references)
		Soldier soldier = GameManagers.Instance.SoldierManager.Get(soldierId);
		Dictionary<string, Dictionary<string, List<string>>> value = GameController.Contexts.config.formationUnits.value;
		string levelFormationContext = GameController.Contexts.Service<IBattleFieldService>().LevelFormationContext;
		string key = GameController.Contexts.Service<IBattleFieldService>().Level?.BattleMode.ToString() ?? BattleMode.RushMode.ToString();
		((GObject)((GComponent)StationConfirmPanel.Dialog.soldierIcon).GetChild("assemblyNote").asImage).visible = false;
		((GObject)((GComponent)StationConfirmPanel.Dialog.soldierIcon).GetChild("occupation").asImage).visible = false;
		((GObject)((GComponent)StationConfirmPanel.Dialog.soldierIcon).GetChild("numNote").asImage).visible = false;
		((GObject)((GComponent)StationConfirmPanel.Dialog.soldierIcon).GetChild("NumBack").asImage).visible = false;
		((GObject)((GComponent)StationConfirmPanel.Dialog.soldierIcon).GetChild("removeBack").asImage).visible = false;
		((GObject)((GComponent)StationConfirmPanel.Dialog.soldierIcon).GetChild("removeNote").asImage).visible = false;
		((GObject)((GComponent)StationConfirmPanel.Dialog.soldierIcon).GetChild("removeText").asTextField).visible = false;
		((GComponent)((GComponent)StationConfirmPanel.Dialog.soldierIcon).GetChild("racePicture").asButton).GetController("Type").selectedIndex = FGUIManager.Instance.GetRaceIcon(soldier.Faction);
		((GComponent)StationConfirmPanel.Dialog.soldierIcon).GetChild("icon").asLoader.url = "ui://PublicResources/" + UiHelper.GetIconPath(soldier.Id);
		((GObject)((GComponent)StationConfirmPanel.Dialog.soldierIcon).GetChild("lv").asRichTextField).text = soldier.Level.ToString();
		((GObject)((GComponent)StationConfirmPanel.Dialog.soldierIcon).GetChild("num").asRichTextField).text = "";
		((GObject)((GComponent)StationConfirmPanel.Dialog.soldierIcon).GetChild("assemblyNote").asImage).visible = value.TryGetValue(levelFormationContext, out var value2) && value2.TryGetValue(key, out var value3) && value3 != null && value3.Contains(soldier.Id);
		((GObject)((GComponent)StationConfirmPanel.Dialog.soldierIcon).GetChild("occupation").asImage).visible = GameManagers.Instance.UserArchiveManager.GetAssignedSoldiers().Contains(soldier.Id);
		((GComponent)StationConfirmPanel.Dialog.soldierIcon).GetController("RedPointController").selectedIndex = 0;
		((GComponent)StationConfirmPanel.Dialog.soldierIcon).GetController("Status").selectedIndex = 0;
		int num = ((soldier.PotentialLevel < 9) ? ((soldier.PotentialLevel + 2) / 2) : 6);
		string text = "title";
		if (num >= 5)
		{
			text = "title_Max";
			((GComponent)StationConfirmPanel.Dialog.soldierIcon).GetController("Level").selectedIndex = 1;
		}
		else
		{
			((GComponent)StationConfirmPanel.Dialog.soldierIcon).GetController("Level").selectedIndex = 0;
		}
		((GComponent)StationConfirmPanel.Dialog.soldierIcon).GetChild(text).text = soldier.Name;
		((GTextField)((GComponent)StationConfirmPanel.Dialog.soldierIcon).GetChild(text).asRichTextField).color = Color32.op_Implicit(chosenMode ? SoldierNameColor2[num - 1] : SoldierNameColor1[num - 1]);
		string iconFrameBorderSoldier = UiHelper.GetIconFrameBorderSoldier(soldier.PotentialLevel);
		((GComponent)StationConfirmPanel.Dialog.soldierIcon).GetChild("iconFrame").asLoader.url = "ui://PublicResources/" + iconFrameBorderSoldier;
		((GComponent)StationConfirmPanel.Dialog.soldierIcon).GetChild("lvFrame").asLoader.url = UiHelper.GetLevelFrameBorderSoldier(soldier.PotentialLevel);
		FGUIManager.Instance.SetAlightSoulStoneForSoldierIcon(((GComponent)StationConfirmPanel.Dialog.soldierIcon).GetChild("SoulStoneLevel").asCom, soldier.PotentialLevel, soldier.PotentialProgress);
	}

	private void RenderEarningsItem(int index, GObject obj)
	{
		GButton asButton = obj.asButton;
		Soldier soldier = GameManagers.Instance.SoldierManager.Get(curSelectSoldierId);
		if (index == curStronghold.Tags.Count)
		{
			((GComponent)asButton).GetChild("title").text = LanguagesManager.GetDesc("CsharpCodeZhTcText365");
			((GComponent)asButton).GetChild("n4").text = "+" + UiHelper.RemoveSurplusZeroBehindDecimalPoint($"{Convert.ToInt32(soldier.ManagePower * 100f)}") + "%";
			((GComponent)asButton).GetController("Status").selectedIndex = 0;
			return;
		}
		bool flag = index == 0;
		string text = curStronghold.Tags[index];
		string id = (flag ? "CsharpCodeZhTcText369" : "CsharpCodeZhTcText370");
		string desc = LanguagesManager.GetDesc(id);
		string text2 = LanguagesManager.GetDesc("SH_T_" + text, returnKey: false);
		if (string.IsNullOrEmpty(text2))
		{
			text2 = text;
		}
		string text3 = text2 + desc;
		((GComponent)asButton).GetChild("title").text = text3 ?? "";
		string text4 = (soldier.Tags.Contains(curStronghold.Tags[index]) ? $"+{40f}%" : "----");
		((GComponent)asButton).GetChild("n4").text = text4;
		if (text4 == "----")
		{
			((GComponent)asButton).GetController("Status").selectedIndex = 1;
		}
		else
		{
			((GComponent)asButton).GetController("Status").selectedIndex = 0;
		}
	}

	private void CloseStationConfirmPanel()
	{
		//IL_002f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0039: Expected O, but got Unknown
		//IL_0056: Unknown result type (might be due to invalid IL or missing references)
		//IL_0060: Expected O, but got Unknown
		//IL_007d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0087: Expected O, but got Unknown
		//IL_00a4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ae: Expected O, but got Unknown
		//IL_00c6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d0: Expected O, but got Unknown
		UiTagManager instance = UiTagManager.Instance;
		instance.Unregister("StationConfirmPanel.AssignBtn");
		((GObject)StationConfirmPanel.Dialog.stationBtn).onClick.Remove(new EventCallback1(StationBtnEvent));
		((GObject)StationConfirmPanel.Dialog.cancelBtn).onClick.Remove(new EventCallback0(CancelBtnEvent));
		((GObject)StationConfirmPanel.Dialog.replaceAssembledBtn).onClick.Remove(new EventCallback1(ReplaceAssembledEvent));
		((GObject)StationConfirmPanel.Dialog.replaceStationedBtn).onClick.Remove(new EventCallback1(ReplaceStationedEvent));
		((GObject)StationConfirmPanel.transparentMask).onClick.Remove(new EventCallback0(CloseStationConfirmPanel));
		curSelectSoldierId = null;
		((GComponent)this).RemoveChild((GObject)(object)StationConfirmPanel, true);
		StationConfirmPanel = null;
		for (int i = 0; i < stationConfirmPanelShaderList.Count; i++)
		{
			AssetsManager.Instance.UnloadAsset<Shader>(stationConfirmPanelShaderList[i]);
		}
	}

	private void StationBtnEvent(EventContext context)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		switch ((int)((GObject)context.sender).data)
		{
		case 0:
			SharedMessenger.Broadcast<EventContext, string, int>("ON_SOLDIER_SELECTED", context, curSelectSoldierId, _chosenType);
			CloseStationConfirmPanel();
			End();
			break;
		case 1:
			StationConfirmPanel.Dialog.PageController.selectedIndex = 1;
			break;
		case 2:
			StationConfirmPanel.Dialog.PageController.selectedIndex = 2;
			break;
		}
	}

	private void CancelBtnEvent()
	{
		CloseStationConfirmPanel();
	}

	private void ReplaceAssembledEvent(EventContext eventContext)
	{
		string formationContext = GameController.Contexts.Service<IBattleFieldService>().LevelFormationContext;
		string mode = GameController.Contexts.Service<IBattleFieldService>().Level?.BattleMode.ToString() ?? BattleMode.RushMode.ToString();
		int pos = UI_Battle.GetFormationUnits(formationContext, mode).IndexOf(curSelectSoldierId);
		ILRequestHelper<ChangeFormationUnitResponse>.Request(eventContext, () => GameController.Contexts.Service<INetworkService>().ChangeFormationUnit(-1L, formationContext, mode, pos, "Unlock"), delegate(ChangeFormationUnitResponse response)
		{
			if (!response.Result)
			{
				ILRequestHelper.ShowErrorCode(response.ErrorCode);
			}
			else if (!GameManagers.Instance.FormationUnitsManager.ChangeFormationUnit(formationContext, mode, pos, "Unlock").Result)
			{
				ILRequestHelper.ShowErrorCode(response.ErrorCode);
			}
			else
			{
				if (WorldMapPanel != null)
				{
					SharedMessenger.Broadcast<EventContext, string, int>("ON_SOLDIER_SELECTED", eventContext, curSelectSoldierId, _chosenType);
				}
				CloseStationConfirmPanel();
				End();
			}
		});
	}

	private void ReplaceStationedEvent(EventContext eventContext)
	{
		SharedMessenger.Broadcast<EventContext, string, int>("ON_SOLDIER_SELECTED", eventContext, curSelectSoldierId, _chosenType);
		CloseStationConfirmPanel();
		End();
	}

	private void GetIslandComeAgainLocalSoldiers()
	{
		if (_chosenType == 9)
		{
			IslandComeAgainInitialSoldiers = GameLocalDataManager.LoadIslandComeAgainSoldiers();
			IslandComeAgainSelectSoldier = ((islandComeAgainSelectSoldiers.Count > 0) ? islandComeAgainSelectSoldiers : new List<string>(IslandComeAgainInitialSoldiers));
		}
	}

	private bool CheckSoldierIsEnough()
	{
		for (int i = 0; i < IslandComeAgainSelectSoldier.Count; i++)
		{
			string soldierId = IslandComeAgainSelectSoldier[i];
			int soldierNum = GetSoldierNum(soldierId);
			int soldierLevel = GameManagers.Instance.UserArchiveManager.GetSoldierLevel(soldierId);
			int num = Singleton<SoldierFormationManager>.Instance.GetSoldierFormationNumber(soldierId, soldierLevel) * 5;
			if (soldierNum < num)
			{
				return false;
			}
		}
		return true;
	}

	private void IslandComeAgainLocalSoldiersConfirm(EventContext context)
	{
		if (IslandComeAgainSelectSoldier == null || IslandComeAgainSelectSoldier.Count < 5)
		{
			List<string> arg = new List<string> { LanguagesManager.GetDesc("CsharpCodeZhTcText340") + "5" + LanguagesManager.GetDesc("CsharpCodeZhTcText341") };
			SharedMessenger.Broadcast("SHOW_TIPS", arg, 1, arg3: false);
		}
		else if (!CheckSoldierIsEnough())
		{
			GameController.Contexts.Service<IUiService>().OpenPanel(UI_UniversalConfirmPopup.Name, new Dictionary<string, object>
			{
				{
					"Content",
					LanguagesManager.GetDesc("CsharpCodeZhTcText342") + LanguagesManager.Comma + LanguagesManager.GetDesc("CsharpCodeZhTcText343") + "？"
				},
				{
					"Buttons",
					new Dictionary<string, Action>
					{
						{ "Confirm", SendIslandComeAgainConfirm },
						{ "Cancel", null }
					}
				},
				{ "PageIndex", 0 },
				{ "ClickSound", "Confirm" },
				{
					"Order",
					((GObject)this).sortingOrder
				}
			});
		}
		else
		{
			SendIslandComeAgainConfirm();
		}
	}

	private void SendIslandComeAgainConfirm()
	{
		List<string> list = new List<string>(IslandComeAgainInitialSoldiers);
		if (list.Count <= 0)
		{
			list = IslandComeAgainSelectSoldier;
		}
		else
		{
			for (int i = 0; i < list.Count; i++)
			{
				string text = list[i];
				if (IslandComeAgainSelectSoldier.Contains(text))
				{
					IslandComeAgainSelectSoldier.Remove(text);
					continue;
				}
				for (int num = IslandComeAgainSelectSoldier.Count - 1; num >= 0; num--)
				{
					string text2 = IslandComeAgainSelectSoldier[num];
					if (!text2.Equals(text))
					{
						list[i] = text2;
						IslandComeAgainSelectSoldier.Remove(text2);
						break;
					}
				}
			}
		}
		SharedMessenger.Broadcast("UPDATE_ISLAND_COME_AGAIN_SOLDIERS", list);
		if (needSaveIslandComeAgainSoldiers)
		{
			GameLocalDataManager.SaveIslandComeAgainSoldiers(list);
		}
		End();
	}

	private void IslandComeAgainSoldiersRender()
	{
		if (IsIslandComeAgain)
		{
			FGUIManager.Instance.ClearCache_SoliderSoulStone();
			controller.selectedIndex = 4;
			_Coroutine_RenderArmList = FGUIManager.Instance.OpenIEnumerator(Real_IslandComeAgainSoldiersRender());
			((GObject)tip1).text = string.Format("{0}({1}/{2}):", LanguagesManager.GetDesc("CsharpCodeZhTcText344"), IslandComeAgainSelectSoldier.Count, 5);
			((GObject)IslandComeAgainConfirm).grayed = IslandComeAgainSelectSoldier.Count < 5;
		}
	}

	private IEnumerator Real_IslandComeAgainSoldiersRender()
	{
		float armsListAHeight = (float)Mathf.CeilToInt((float)(chosenMode ? (soldierRenderListA.Count + 1) : soldierRenderListA.Count) / 5f) * 249f;
		float armsListBHeight = (float)Mathf.CeilToInt((float)soldierRenderListB.Count / 5f) * 249f;
		((GComponent)ArmsList.armsList_a).viewHeight = armsListAHeight;
		((GComponent)ArmsList.armsList_a).EnsureBoundsCorrect();
		((GComponent)ArmsList.armsList_b).viewHeight = armsListBHeight;
		((GComponent)ArmsList.armsList_b).EnsureBoundsCorrect();
		((GObject)ArmsList.separatedLine).visible = soldierRenderListB.Count > 0;
		((GObject)ArmsList.separatedLine1).visible = soldierRenderListC.Count > 0;
		ArmsList.armsList_a.numItems = 0;
		ArmsList.armsList_b.numItems = 0;
		allRuneGComponents?.Clear();
		yield return null;
		for (int i = 0; i < soldierRenderListA.Count; i++)
		{
			GObject item = ArmsList.armsList_a.AddItemFromPool();
			item.touchable = false;
			item.alpha = 0f;
			RenderIslandComeAgainSoldierItem(i, item, soldierRenderListA[i]);
			item.TweenFade(1f, 0.1f).OnComplete((GTweenCallback)delegate
			{
				item.touchable = true;
			});
			yield return null;
		}
		ArmsList.armsList_a.ResizeToFit(soldierRenderListA.Count);
		for (int i2 = 0; i2 < soldierRenderListB.Count; i2++)
		{
			GObject item2 = ArmsList.armsList_b.AddItemFromPool();
			item2.touchable = false;
			item2.alpha = 0f;
			RenderIslandComeAgainSoldierItem(i2, item2, soldierRenderListB[i2]);
			item2.TweenFade(1f, 0.1f).OnComplete((GTweenCallback)delegate
			{
				item2.touchable = true;
			});
			yield return null;
		}
		ArmsList.armsList_b.ResizeToFit(soldierRenderListB.Count);
		((GObject)ArmsList.separatedLine).visible = soldierRenderListB.Count > 0;
		ArmsList.armsList_c.ResizeToFit(soldierRenderListC.Count);
		((GObject)ArmsList.separatedLine1).visible = false;
		((GComponent)ArmsList.armsList_a).EnsureBoundsCorrect();
		((GComponent)ArmsList.armsList_b).EnsureBoundsCorrect();
	}

	private void RenderIslandComeAgainSoldierItem(int index, GObject obj, Soldier soldier)
	{
		//IL_0255: Unknown result type (might be due to invalid IL or missing references)
		//IL_0245: Unknown result type (might be due to invalid IL or missing references)
		//IL_025a: Unknown result type (might be due to invalid IL or missing references)
		//IL_056d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0577: Expected O, but got Unknown
		GButton asButton = obj.asButton;
		((GComponent)asButton).GetChild("assemblyNote").visible = false;
		((GComponent)asButton).GetChild("occupation").visible = false;
		((GComponent)asButton).GetChild("title").text = "";
		((GComponent)asButton).GetChild("removeBack").visible = false;
		((GComponent)asButton).GetChild("removeNote").visible = false;
		((GComponent)asButton).GetChild("removeText").visible = false;
		((GComponent)asButton).GetChild("SoulStoneLevel").visible = true;
		((GComponent)asButton).GetChild("racePicture").visible = false;
		((GComponent)asButton).GetChild("lv").text = soldier.Level.ToString();
		int num = ((soldier.PotentialLevel < 9) ? ((soldier.PotentialLevel + 2) / 2) : 6);
		((GComponent)asButton).GetChild("lvFrame").asLoader.url = UiHelper.GetLevelFrameBorderSoldier(soldier.PotentialLevel);
		((GComponent)asButton).GetChild("icon").asLoader.url = "ui://PublicResources/" + UiHelper.GetIconPath(soldier.Id);
		string iconFrameBorderSoldier = UiHelper.GetIconFrameBorderSoldier(soldier.PotentialLevel);
		((GComponent)asButton).GetChild("iconFrame").asLoader.url = "ui://PublicResources/" + iconFrameBorderSoldier;
		GComponent rune = FGUIManager.Instance.SetAlightSoulStoneForSoldierIcon(((GComponent)asButton).GetChild("SoulStoneLevel").asCom, soldier.PotentialLevel, soldier.PotentialProgress, isActivating: false, needMask: false);
		AllRuneGComponentsAdd(rune);
		RuneGComponentSetVisible(rune);
		((GObject)((GComponent)asButton).GetChild("racePicture").asButton).visible = true;
		((GComponent)((GComponent)asButton).GetChild("racePicture").asButton).GetController("Type").selectedIndex = FGUIManager.Instance.GetRaceIcon(soldier.Faction);
		string text = "title";
		if (num >= 5)
		{
			text = "title_Max";
			((GComponent)asButton).GetController("Level").selectedIndex = 1;
		}
		else
		{
			((GComponent)asButton).GetController("Level").selectedIndex = 0;
		}
		((GComponent)asButton).GetChild(text).text = soldier.Name;
		((GTextField)((GComponent)asButton).GetChild(text).asRichTextField).color = Color32.op_Implicit(chosenMode ? SoldierNameColor2[num - 1] : SoldierNameColor1[num - 1]);
		int stock = GameManagers.Instance.StockController.GetStock(soldier.Id);
		((GObject)((GComponent)asButton).GetChild("num").asRichTextField).text = $"{stock}";
		((GObject)asButton).data = soldier.Id;
		if (IslandComeAgainSelectSoldier.Contains(soldier.Id))
		{
			((GComponent)asButton).GetChild("SelectNote").visible = true;
			((GComponent)asButton).GetChild("NumSelected").visible = true;
			((GComponent)asButton).GetChild("NumSelected1").visible = false;
		}
		else
		{
			((GComponent)asButton).GetChild("SelectNote").visible = false;
			((GComponent)asButton).GetChild("NumSelected").visible = false;
			((GComponent)asButton).GetChild("NumSelected1").visible = true;
		}
		((GComponent)asButton).GetChild("LegendItems").visible = false;
		if (LegendItemsHelper.SoldiersEquippedItems != null && LegendItemsHelper.SoldiersEquippedItems.ContainsKey(soldier.Id))
		{
			for (int i = 0; i < 2; i++)
			{
				((GComponent)asButton).GetChild($"legendItem{i}").visible = false;
			}
			int num2 = 0;
			for (int j = 0; j < LegendItemsHelper.SoldiersEquippedItems[soldier.Id].Length; j++)
			{
				if (num2 >= 2)
				{
					break;
				}
				GButton asButton2 = ((GComponent)asButton).GetChild($"legendItem{num2}").asButton;
				if (!LegendItemsHelper.GetSoldierItemSlotState(soldier.Id, j))
				{
					((GObject)asButton2).visible = false;
					continue;
				}
				long num3 = LegendItemsHelper.SoldiersEquippedItems[soldier.Id][j];
				((GObject)asButton2).visible = true;
				if (num3 == 0)
				{
					((GObject)asButton2).visible = false;
					continue;
				}
				UiHelper.RenderLegendItem(asButton2, LegendItemsHelper.GetLegendItemUi(num3), UiHelper.TextColorType.Light, textureList, 2);
				num2++;
			}
			switch (num2)
			{
			case 1:
				((GComponent)asButton).GetController("LegendItemNum").selectedIndex = 0;
				((GComponent)asButton).GetChild("n56").visible = false;
				break;
			case 2:
				((GComponent)asButton).GetController("LegendItemNum").selectedIndex = 1;
				((GComponent)asButton).GetChild("n56").visible = true;
				break;
			}
			bool flag = false;
			for (int k = 0; k < 2; k++)
			{
				GButton asButton3 = ((GComponent)asButton).GetChild($"legendItem{k}").asButton;
				if (((GObject)asButton3).visible)
				{
					break;
				}
				if (k == 1)
				{
					flag = true;
				}
			}
			((GComponent)asButton).GetChild("LegendItems").visible = !flag;
		}
		Real_UpdateIsComeAgainSoldierNum(asButton, soldier.Id);
		((GObject)asButton).onClick.Set(new EventCallback1(UpdateIslandComeAgainSoldiers));
	}

	private void UpdateIslandComeAgainSoldiers(EventContext context)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000d: Expected O, but got Unknown
		GButton val = (GButton)context.sender;
		string item = ((GObject)val).data.ToString();
		if (IslandComeAgainSelectSoldier.Count >= 5 && !IslandComeAgainSelectSoldier.Contains(item) && IslandComeAgainSelectSoldier.Count >= 5)
		{
			List<string> arg = new List<string> { string.Format("{0}{1}{2}", LanguagesManager.GetDesc("CsharpCodeZhTcText345"), 5, LanguagesManager.GetDesc("CsharpCodeZhTcText346")) };
			SharedMessenger.Broadcast("SHOW_TIPS", arg, ((GObject)this).sortingOrder, arg3: false);
			return;
		}
		if (IslandComeAgainSelectSoldier.Count >= 5 && IslandComeAgainSelectSoldier.Contains(item))
		{
			((GComponent)val).GetChild("SelectNote").visible = false;
			((GComponent)val).GetChild("NumSelected").visible = false;
			((GComponent)val).GetChild("NumSelected1").visible = true;
			IslandComeAgainSelectSoldier.Remove(item);
			((GObject)tip1).text = string.Format("{0}({1}/{2}):", LanguagesManager.GetDesc("CsharpCodeZhTcText344"), IslandComeAgainSelectSoldier.Count, 5);
			((GObject)IslandComeAgainConfirm).grayed = IslandComeAgainSelectSoldier.Count < 5;
			return;
		}
		bool flag = IslandComeAgainSelectSoldier.Contains(item);
		if (flag)
		{
			IslandComeAgainSelectSoldier.Remove(item);
		}
		else
		{
			IslandComeAgainSelectSoldier.Add(item);
		}
		((GComponent)val).GetChild("SelectNote").visible = !flag;
		((GComponent)val).GetChild("NumSelected").visible = !flag;
		((GComponent)val).GetChild("NumSelected1").visible = flag;
		((GObject)tip1).text = string.Format("{0}({1}/{2}):", LanguagesManager.GetDesc("CsharpCodeZhTcText344"), IslandComeAgainSelectSoldier.Count, 5);
		((GObject)IslandComeAgainConfirm).grayed = IslandComeAgainSelectSoldier.Count < 5;
	}

	private void LegionFactionFiltersInit()
	{
		//IL_002d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0037: Expected O, but got Unknown
		//IL_0064: Unknown result type (might be due to invalid IL or missing references)
		//IL_006e: Expected O, but got Unknown
		//IL_009b: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a5: Expected O, but got Unknown
		//IL_00d2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00dc: Expected O, but got Unknown
		//IL_0109: Unknown result type (might be due to invalid IL or missing references)
		//IL_0113: Expected O, but got Unknown
		//IL_0140: Unknown result type (might be due to invalid IL or missing references)
		//IL_014a: Expected O, but got Unknown
		//IL_0177: Unknown result type (might be due to invalid IL or missing references)
		//IL_0181: Expected O, but got Unknown
		((GObject)LegionRaceFilters.allFaction).data = "";
		((GObject)LegionRaceFilters.allFaction).onClick.Set(new EventCallback1(SelectFaction));
		((GObject)LegionRaceFilters.devilFaction).data = "恶魔";
		((GObject)LegionRaceFilters.devilFaction).onClick.Set(new EventCallback1(SelectFaction));
		((GObject)LegionRaceFilters.deathFaction).data = "亡灵";
		((GObject)LegionRaceFilters.deathFaction).onClick.Set(new EventCallback1(SelectFaction));
		((GObject)LegionRaceFilters.goblinFaction).data = "哥布林";
		((GObject)LegionRaceFilters.goblinFaction).onClick.Set(new EventCallback1(SelectFaction));
		((GObject)LegionRaceFilters.humanFaction).data = "人类";
		((GObject)LegionRaceFilters.humanFaction).onClick.Set(new EventCallback1(SelectFaction));
		((GObject)LegionRaceFilters.orcFaction).data = "兽族";
		((GObject)LegionRaceFilters.orcFaction).onClick.Set(new EventCallback1(SelectFaction));
		((GObject)LegionRaceFilters.otherFaction).data = "其他";
		((GObject)LegionRaceFilters.otherFaction).onClick.Set(new EventCallback1(SelectFaction));
		if (IsGvGMode3)
		{
			if (_raceTypeGvGMode3 == -1)
			{
				LegionRaceFilters.PageController.selectedIndex = 6;
			}
			else
			{
				LegionRaceFilters.PageController.selectedIndex = _raceTypeGvGMode3;
			}
			currentFaction = GetFaction(_raceTypeGvGMode3);
		}
		else
		{
			LegionRaceFilters.PageController.selectedIndex = 6;
			currentFaction = "";
		}
		static string GetFaction(int raceType)
		{
			return raceType switch
			{
				6 => string.Empty, 
				2 => "恶魔", 
				1 => "亡灵", 
				0 => "哥布林", 
				3 => "人类", 
				5 => "兽族", 
				4 => "其他", 
				_ => string.Empty, 
			};
		}
	}

	private void SelectFaction(EventContext context)
	{
		//IL_0008: Unknown result type (might be due to invalid IL or missing references)
		currentFaction = ((GObject)context.sender).data.ToString();
		switch (currentFaction)
		{
		case "":
			LegionRaceFilters.PageController.selectedIndex = 6;
			break;
		case "恶魔":
			LegionRaceFilters.PageController.selectedIndex = 2;
			break;
		case "亡灵":
			LegionRaceFilters.PageController.selectedIndex = 1;
			break;
		case "哥布林":
			LegionRaceFilters.PageController.selectedIndex = 0;
			break;
		case "人类":
			LegionRaceFilters.PageController.selectedIndex = 3;
			break;
		case "兽族":
			LegionRaceFilters.PageController.selectedIndex = 5;
			break;
		case "其他":
			LegionRaceFilters.PageController.selectedIndex = 4;
			break;
		}
		if (_Coroutine_RenderArmList != null)
		{
			FGUIManager.Instance.CloseIEnumerator(_Coroutine_RenderArmList);
		}
		if (_Coroutine_RenderLegendSoldiers != null)
		{
			FGUIManager.Instance.CloseIEnumerator(_Coroutine_RenderLegendSoldiers);
		}
		UpdateRenderSoldiersList();
		LegendSoldiersRender();
		IslandComeAgainSoldiersRender();
		RenderGvGMode3LegionList();
		RenderArmsList();
	}

	public void GetSoldierData()
	{
		SoldierList.Clear();
		LockSoldierList.Clear();
		var source = from sid in GameManagers.Instance.StockController.GetOwnedSoldiers(onlyUnlocked, includeEmptyStock).Keys
			select new
			{
				sid = sid,
				s = GameManagers.Instance.SoldierManager.Get(sid)
			} into t
			orderby t.sid
			select t;
		IEnumerable<Soldier> enumerable = source.Select(t => t.s);
		foreach (Soldier item in enumerable)
		{
			SoldierList.Add(item);
		}
		if (_chosenType == 2)
		{
			ArmsList.Status.selectedIndex = 1;
			((GObject)LegionRaceFilters).visible = false;
			SoldierList.Sort(SortSoldierForOccupantMaxToMin);
		}
		else
		{
			ArmsList.Status.selectedIndex = 0;
			((GObject)LegionRaceFilters).visible = true;
			SoldierList.Sort(SortSoldierMaxToMin);
		}
		if ((chosenMode && (_chosenType == 6 || _chosenType == 7 || _chosenType == 8)) || _fromGvG3ModeShipDetail)
		{
			UiHelper.FiltrateSoldiersBySelected(pvpSelectedSoldiers, SoldierList);
		}
		UiHelper.FiltrateSoldiersByRace(soldierFilter, SoldierList);
		if (isLegendItemDungeon)
		{
			UiHelper.FilterSoldiersByLegendItemDungeon(SoldierList);
		}
		List<string> list = source.Select(t => t.sid).ToList();
		foreach (string key in GameManagers.Instance.SoldierManager.PlayerSoldiers.Keys)
		{
			if (!list.Contains(key))
			{
				LockSoldierList.Add(GameManagers.Instance.SoldierManager.Get(key));
			}
		}
		if (!chosenMode)
		{
			RefreshLegionTotalPower();
			return;
		}
		((GObject)totalPower).text = "";
		((GObject)n127).visible = false;
	}

	private void RefreshLegionTotalPower()
	{
		int num = 0;
		for (int i = 0; i < SoldierList.Count; i++)
		{
			num += SoldierList[i].CombatPower * Singleton<SoldierFormationManager>.Instance.GetSoldierFormationNumber(SoldierList[i].Id, SoldierList[i].Level);
		}
		((GObject)totalPower).text = string.Format("{0} {1}", LanguagesManager.GetDesc("CsharpCodeZhTcText347"), num);
	}

	private void UpdateRenderSoldiersList()
	{
		soldierRenderListA.Clear();
		soldierRenderListB.Clear();
		soldierRenderListC.Clear();
		unlockSoldierRenderList.Clear();
		if (_chosenType == 2)
		{
			soldierRenderListA = new List<Soldier>(SoldierList);
			unlockSoldierRenderList = new List<Soldier>(SoldierList);
			return;
		}
		bool flag = chosenMode && (_chosenType == 5 || _chosenType == 8 || _chosenType == 9 || _chosenType == 10);
		if (string.IsNullOrWhiteSpace(currentFaction))
		{
			soldierRenderListA = new List<Soldier>(SoldierList);
			if (!flag)
			{
				soldierRenderListB = new List<Soldier>(LockSoldierList);
			}
			unlockSoldierRenderList = new List<Soldier>(SoldierList);
			return;
		}
		List<Soldier> list = new List<Soldier>(SoldierList);
		List<Soldier> list2 = new List<Soldier>(LockSoldierList);
		for (int num = list.Count - 1; num >= 0; num--)
		{
			if (list[num].Faction == currentFaction)
			{
				soldierRenderListA.Add(list[num]);
				unlockSoldierRenderList.Add(list[num]);
				list.RemoveAt(num);
			}
		}
		if (!flag)
		{
			for (int num2 = list2.Count - 1; num2 >= 0; num2--)
			{
				if (list2[num2].Faction == currentFaction)
				{
					soldierRenderListA.Add(list2[num2]);
					list2.RemoveAt(num2);
				}
			}
		}
		soldierRenderListA.Sort(SortSoldierMaxToMin);
		unlockSoldierRenderList.Sort(SortSoldierMaxToMin);
		soldierRenderListB = new List<Soldier>(list);
		if (IsGvGMode3)
		{
			soldierRenderListB.Sort(SortSoldierMaxToMinGvGMode3);
		}
		unlockSoldierRenderList.AddRange(list);
		if (!flag)
		{
			soldierRenderListC = new List<Soldier>(list2);
		}
	}

	private void UnlockSoldierListReSort()
	{
		if (_chosenType == 2)
		{
			SoldierList.Sort(SortSoldierForOccupantMaxToMin);
		}
		else
		{
			SoldierList.Sort(SortSoldierMaxToMin);
		}
	}

	private void UnlockSoldierListReCalc_CombatPower(string soldierId)
	{
		if (string.IsNullOrEmpty(soldierId) || SoldierList == null || SoldierList.Count <= 0)
		{
			return;
		}
		for (int i = 0; i < SoldierList.Count; i++)
		{
			if (SoldierList[i].Id == soldierId)
			{
				SoldierList[i] = GameManagers.Instance.SoldierManager.Get(soldierId);
				SoldierList[i].EnsureAttr();
				break;
			}
		}
	}

	private bool SoldierIsLock(string soldierId)
	{
		if (LockSoldierList.Count <= 0)
		{
			return false;
		}
		for (int i = 0; i < LockSoldierList.Count; i++)
		{
			if (LockSoldierList[i].Id == soldierId)
			{
				return true;
			}
		}
		return false;
	}

	private void UpdateUnlockSoldierNum(string soldierId = "")
	{
		if (string.IsNullOrEmpty(soldierId))
		{
			for (int i = 0; i < ArmsList.armsList_a.numItems; i++)
			{
				GButton asButton = ((GComponent)ArmsList.armsList_a).GetChildAt(i).asButton;
				if (((GObject)asButton).data is Soldier soldier && !SoldierIsLock(soldier.Id))
				{
					Real_UpdateSoldierNum(asButton, soldier.Id);
					Real_UpdateIsComeAgainSoldierNum(asButton, soldier.Id);
				}
			}
			for (int j = 0; j < ArmsList.armsList_b.numItems; j++)
			{
				GButton asButton2 = ((GComponent)ArmsList.armsList_b).GetChildAt(j).asButton;
				if (((GObject)asButton2).data is Soldier soldier2 && !SoldierIsLock(soldier2.Id))
				{
					Real_UpdateSoldierNum(asButton2, soldier2.Id);
					Real_UpdateIsComeAgainSoldierNum(asButton2, soldier2.Id);
				}
			}
			return;
		}
		for (int k = 0; k < ArmsList.armsList_a.numItems; k++)
		{
			GButton asButton3 = ((GComponent)ArmsList.armsList_a).GetChildAt(k).asButton;
			if (((GObject)asButton3).data is Soldier soldier3 && !SoldierIsLock(soldier3.Id) && !(soldier3.Id != soldierId))
			{
				Real_UpdateSoldierNum(asButton3, soldier3.Id);
				Real_UpdateIsComeAgainSoldierNum(asButton3, soldier3.Id);
			}
		}
		for (int l = 0; l < ArmsList.armsList_b.numItems; l++)
		{
			GButton asButton4 = ((GComponent)ArmsList.armsList_b).GetChildAt(l).asButton;
			if (((GObject)asButton4).data is Soldier soldier4 && !SoldierIsLock(soldier4.Id) && !(soldier4.Id != soldierId))
			{
				Real_UpdateSoldierNum(asButton4, soldier4.Id);
				Real_UpdateIsComeAgainSoldierNum(asButton4, soldier4.Id);
			}
		}
	}

	private int SortSoldierMaxToMin(Soldier a, Soldier b)
	{
		if (a == null)
		{
			return -1;
		}
		if (b == null)
		{
			return 1;
		}
		if (IslandComeAgainInitialSoldiers.Contains(a.Id) && !IslandComeAgainInitialSoldiers.Contains(b.Id))
		{
			return -1;
		}
		if (!IslandComeAgainInitialSoldiers.Contains(a.Id) && IslandComeAgainInitialSoldiers.Contains(b.Id))
		{
			return 1;
		}
		int potentialLevel = a.PotentialLevel;
		int potentialLevel2 = b.PotentialLevel;
		if (potentialLevel > potentialLevel2)
		{
			return -1;
		}
		if (potentialLevel < potentialLevel2)
		{
			return 1;
		}
		int level = a.Level;
		int level2 = b.Level;
		if (level > level2)
		{
			return -1;
		}
		if (level < level2)
		{
			return 1;
		}
		int num = a.CombatPower * Singleton<SoldierFormationManager>.Instance.GetSoldierFormationNumber(a.Id, level);
		int num2 = b.CombatPower * Singleton<SoldierFormationManager>.Instance.GetSoldierFormationNumber(b.Id, level2);
		if (num > num2)
		{
			return -1;
		}
		if (num < num2)
		{
			return 1;
		}
		return 0;
	}

	private int SortSoldierMaxToMinGvGMode3(Soldier a, Soldier b)
	{
		if (a == null)
		{
			return -1;
		}
		if (b == null)
		{
			return 1;
		}
		if (_selectedWithTick.Contains(a.Id) && !_selectedWithTick.Contains(b.Id))
		{
			return -1;
		}
		if (!_selectedWithTick.Contains(a.Id) && _selectedWithTick.Contains(b.Id))
		{
			return 1;
		}
		int potentialLevel = a.PotentialLevel;
		int potentialLevel2 = b.PotentialLevel;
		if (potentialLevel > potentialLevel2)
		{
			return -1;
		}
		if (potentialLevel < potentialLevel2)
		{
			return 1;
		}
		int level = a.Level;
		int level2 = b.Level;
		if (level > level2)
		{
			return -1;
		}
		if (level < level2)
		{
			return 1;
		}
		int num = a.CombatPower * Singleton<SoldierFormationManager>.Instance.GetSoldierFormationNumber(a.Id, level);
		int num2 = b.CombatPower * Singleton<SoldierFormationManager>.Instance.GetSoldierFormationNumber(b.Id, level2);
		return (num > num2) ? (-1) : ((num < num2) ? 1 : 0);
	}

	private int SortSoldierForOccupantMaxToMin(Soldier a, Soldier b)
	{
		if (curStronghold == null)
		{
			return 0;
		}
		if (a == null)
		{
			return -1;
		}
		if (b == null)
		{
			return 1;
		}
		float num = curStronghold.CalcOccupantEfficiencyModifier(GameManagers.Instance, a.Id);
		float num2 = curStronghold.CalcOccupantEfficiencyModifier(GameManagers.Instance, b.Id);
		if (num > num2)
		{
			return -1;
		}
		if (num < num2)
		{
			return 1;
		}
		return 0;
	}

	private void RuneGComponentsMaskInit()
	{
		//IL_0014: Unknown result type (might be due to invalid IL or missing references)
		//IL_001e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0064: Unknown result type (might be due to invalid IL or missing references)
		//IL_006e: Expected O, but got Unknown
		((GComponent)ArmsList).EnsureBoundsCorrect();
		topY = ((GObject)ArmsList).LocalToRoot(Vector2.zero, GRoot.inst).y;
		bottomY = topY + ((GObject)ArmsList).height - 22f;
		((GComponent)ArmsList).scrollPane.onScroll.Set(new EventCallback0(AllRuneGComponentsUpdateVisible));
	}

	private void AllRuneGComponentsAdd(GComponent rune)
	{
		if (!allRuneGComponents.Contains(rune))
		{
			allRuneGComponents.Add(rune);
		}
		int selectedIndex = rune.GetController("SoulStoneIllume").selectedIndex;
		((GObject)rune).data = selectedIndex;
	}

	private void AllRuneGComponentsUpdateVisible()
	{
		for (int i = 0; i < allRuneGComponents.Count; i++)
		{
			RuneGComponentSetVisible(allRuneGComponents[i]);
		}
	}

	private void RuneGComponentSetVisible(GComponent rune)
	{
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_001d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0022: Unknown result type (might be due to invalid IL or missing references)
		//IL_0029: Unknown result type (might be due to invalid IL or missing references)
		//IL_0037: Unknown result type (might be due to invalid IL or missing references)
		if (rune != null)
		{
			rune.EnsureBoundsCorrect();
			Vector2 val = ((GObject)rune).LocalToRoot(Vector2.zero, GRoot.inst);
			if (topY > val.y || bottomY < val.y)
			{
				rune.GetController("SoulStoneIllume").selectedIndex = 0;
			}
			else if (((GObject)rune).data != null)
			{
				rune.GetController("SoulStoneIllume").selectedIndex = (int)((GObject)rune).data;
			}
		}
	}

	public void BeforeDestroy()
	{
	}

	public void Init(Dictionary<string, object> parameters)
	{
		//IL_0065: Unknown result type (might be due to invalid IL or missing references)
		//IL_006f: Expected O, but got Unknown
		//IL_0077: Unknown result type (might be due to invalid IL or missing references)
		//IL_0081: Expected O, but got Unknown
		//IL_009e: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00cb: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fd: Unknown result type (might be due to invalid IL or missing references)
		//IL_041c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0426: Expected O, but got Unknown
		//IL_0550: Unknown result type (might be due to invalid IL or missing references)
		SoldierList = new List<Soldier>();
		shaderList = new List<string>();
		textureList = new List<string>();
		ChipsList = new List<Pieces>();
		_piecesAllKeys = new List<string>();
		Updatelist = new List<int>();
		_selectedWithTick = null;
		FGUIManager.SetUiPanelSizeAndXy((GObject)(object)this);
		FGUIManager.Instance.LegionPanel = this;
		callback1 = new EventCallback1(ArmsItemClick);
		callback2 = new EventCallback1(ChipsItemClick);
		addWorkerBtn.GetChild("CurrentWorkerAmount").asTextField.strokeColor = Color32.op_Implicit(new Color32((byte)0, (byte)0, (byte)0, (byte)229));
		addWorkerBtn.GetChild("AllWorkerAmount").asTextField.strokeColor = Color32.op_Implicit(new Color32((byte)0, (byte)0, (byte)0, (byte)229));
		addWorkerBtn.GetChild("separate").asTextField.strokeColor = Color32.op_Implicit(new Color32((byte)0, (byte)0, (byte)0, (byte)229));
		((GObject)this).sortingOrder = 99;
		SetBuildingName();
		object value = null;
		object value2 = null;
		if (parameters != null)
		{
			parameters.TryGetValue("Style", out value);
			parameters.TryGetValue("Tab", out value2);
			if (parameters.TryGetValue("OnlyUnlocked", out var value3))
			{
				onlyUnlocked = int.Parse(value3.ToString()) > 0;
			}
			if (parameters.TryGetValue("IncludeEmptyStock", out var value4))
			{
				includeEmptyStock = int.Parse(value4.ToString()) > 0;
			}
			if (parameters.TryGetValue("SoldierFilter", out var value5))
			{
				soldierFilter = (List<List<string>>)value5;
			}
			if (parameters.TryGetValue("IsLegendItemDungeon", out var value6))
			{
				isLegendItemDungeon = (bool)value6;
			}
			if (parameters.TryGetValue("PvpSoldiersFilter", out var value7))
			{
				pvpSelectedSoldiers = (List<string>)value7;
			}
			if (parameters.TryGetValue("IslandComeAgainSelectSoldiers", out var value8))
			{
				islandComeAgainSelectSoldiers = (List<string>)value8;
			}
			if (parameters.TryGetValue("SaveIslandComeAgainSoldiers", out var value9))
			{
				needSaveIslandComeAgainSoldiers = (bool)value9;
			}
			if (parameters.TryGetValue("SelectedWithTick", out var value10))
			{
				_selectedWithTick = (List<string>)value10;
				_fromGvG3ModeShipDetail = true;
			}
			if (parameters.TryGetValue("RaceTypeGvGMode3", out var value11))
			{
				_raceTypeGvGMode3 = (int)value11;
			}
			if (parameters.TryGetValue("RaceMinCount", out var value12))
			{
				_raceMinCount = (int)value12;
			}
			if (parameters.TryGetValue("isCurGroup", out var value13))
			{
				_isCurGroup = (bool)value13;
			}
			if (parameters.TryGetValue("SelectedRaceLegionCnt", out var value14))
			{
				_selectedRaceLegionCnt = (int)value14;
			}
			if (parameters.TryGetValue("SelectedWithTickMaxCount", out var value15))
			{
				_selectedWithTickMaxCount = (int)value15;
			}
			if (parameters.TryGetValue("SelectedWithTick_OnConfirm", out var value16))
			{
				_selectedWithTickOnConfirm = (UICallbackParam<Action<GvGMode3SoldierSelected>>)value16;
			}
		}
		if (value2 == null)
		{
			value2 = 2;
		}
		if (value == null)
		{
			value = "Self";
		}
		if (value != null && value.ToString() == "Self")
		{
			controller.selectedIndex = 0;
			chosenMode = false;
			((GObject)this).sortingOrder = 1;
		}
		else
		{
			controller.selectedIndex = (int)value2;
			chosenMode = true;
			_chosenType = int.Parse(value.ToString());
			if (_chosenType == 2)
			{
				if (parameters.TryGetValue("WorldMap", out var value17))
				{
					WorldMapPanel = (UI_WorldMapPanel)value17;
					curStronghold = WorldMapPanel.curSelectedStronghold;
				}
				else
				{
					End();
				}
			}
			((GObject)endChooseClick).onClick.Add(new EventCallback0(End));
		}
		GetIslandComeAgainLocalSoldiers();
		InitWorkerSpine();
		LegionFactionFiltersInit();
		GetSoldierData();
		UpdateRenderSoldiersList();
		LegendSoldiersRender();
		IslandComeAgainSoldiersRender();
		RenderGvGMode3LegionList();
		RenderArmsList();
		((GObject)IntroductionPanel).visible = false;
		((GObject)stockLimit).text = $"{GameController.Contexts.game.dungeon.value.LegionSizeLimit}";
		int techLevel = GameManagers.Instance.UserArchiveManager.GetTechLevel("H010");
		if (techLevel > 0)
		{
			((GObject)ExclamationMarkBtn).visible = true;
			((GObject)ExclamationMarkBtn).data = new Dictionary<string, object>
			{
				{
					"Title",
					LanguagesManager.GetDesc("CsharpCodeZhTcText105") + Environment.NewLine + string.Format("{0}：{1}/h", LanguagesManager.GetDesc("CsharpCodeZhTcText353"), Convert.ToInt32(GameController.Contexts.game.dungeon.value.LegionSizeLimit / (1 + techLevel)))
				},
				{
					"Pos",
					(object)new Vector2(960f, 788f)
				}
			};
			float num = 38f + ((GObject)stockLimit).width + 23f;
			((GObject)n121).x = ((GObject)stockLimitTitle).x - num / 2f;
		}
		else
		{
			((GObject)ExclamationMarkBtn).visible = false;
			float num2 = 38f + ((GObject)stockLimit).width;
			((GObject)n121).x = ((GObject)stockLimitTitle).x - num2 / 2f;
		}
		if (_chosenType != 3)
		{
			((GObject)armsBtn.note).visible = GameManagers.Instance.NewMsgIncomingManager.AnySoldierHasNewMsg(flush: true);
		}
		((GObject)chipBtn.note).visible = GameManagers.Instance.NewMsgIncomingManager.AnySoldierPieceHasNewMsg();
	}

	public void OnShow()
	{
		UiTagManager instance = UiTagManager.Instance;
		instance.Register("LegionPanel.CloseBtn", backBtn);
		instance.Register("LegionPanel.TabSoldier", armsBtn);
		instance.Register("LegionPanel.TabPieces", chipBtn);
		instance.Register("LegionPanel.SummonBtn", IntroductionPanel.activate);
		instance.Register("LegionPanel", this);
		UiAudioManager.Instance.SetMainCityBgmVolume(UiAudioManager.Instance.MiddleBgmVolume);
		RuneGComponentsMaskInit();
	}

	public void Destroy()
	{
		UiTagManager instance = UiTagManager.Instance;
		instance.Unregister("LegionPanel.CloseBtn", backBtn);
		instance.Unregister("LegionPanel.TabSoldier", armsBtn);
		instance.Unregister("LegionPanel.TabPieces", chipBtn);
		instance.Unregister("LegionPanel.SummonBtn", IntroductionPanel.activate);
		instance.Unregister("LegionPanel", this);
		instance.Unregister("LegionPanel.FirstSoldier");
		instance.Unregister("LegionPanel.GoblinSoldier");
		instance.Unregister("LegionPanel.GoblinScout");
		instance.Unregister("LegionPanel.GoblinProphet");
		instance.Unregister("LegionPanel.GoblinKnight");
		instance.Unregister("LegionPanel.Soldier");
		instance.Unregister("LegionPanel.FirstPieces");
		instance.Unregister("LegionPanel.GoblinProphetPieces");
		instance.Unregister("LegionPanel.GhostWarrior");
		instance.Unregister("LegionPanel.Soldier");
		instance.Unregister("LegionPanel.SoldierPiece");
		FGUIManager.Instance.LegionPanel = null;
		if (!chosenMode)
		{
			UiAudioManager.Instance.SetMainCityBgmVolume(UiAudioManager.Instance.MaxUiBgmVolume);
		}
	}

	public void RegisterUiEventListeners()
	{
		//IL_001d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0027: Expected O, but got Unknown
		//IL_0048: Unknown result type (might be due to invalid IL or missing references)
		//IL_0052: Expected O, but got Unknown
		//IL_0069: Unknown result type (might be due to invalid IL or missing references)
		//IL_0073: Expected O, but got Unknown
		//IL_0086: Unknown result type (might be due to invalid IL or missing references)
		//IL_0090: Expected O, but got Unknown
		//IL_00a8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b2: Expected O, but got Unknown
		//IL_00c5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00cf: Expected O, but got Unknown
		//IL_00e2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ec: Expected O, but got Unknown
		//IL_0132: Unknown result type (might be due to invalid IL or missing references)
		//IL_013c: Expected O, but got Unknown
		addWorkerBtn.GetChild("addButton").onClick.Add(new EventCallback0(WorkerAddClick));
		addWorkerBtn.GetChild("ExclamationMarkBtn").onClick.Add(new EventCallback1(FGUIManager.Instance.OpenExclamationMarkPanel));
		((GObject)ExclamationMarkBtn).onClick.Add(new EventCallback1(FGUIManager.Instance.OpenExclamationMarkPanel));
		((GObject)backBtn).onClick.Add(new EventCallback0(BackClick));
		((GObject)IntroductionPanel.exit).onClick.Add(new EventCallback0(IntroductionPanelClose));
		((GObject)ConfirmBtn).onClick.Add(new EventCallback1(LegendSoldiersConfirm));
		((GObject)IslandComeAgainConfirm).onClick.Add(new EventCallback1(OnGvGConfirmClick));
		SharedMessenger.AddListener<Building>("WORKERS_ALLOCATION_DISPLAY_CHANGED", UpdateWorkerNum);
		SharedMessenger.AddListener<string, int, (StockInContext, string)>("ON_STOCK_CHANGE", UpdateSoldiersNum);
		((GObject)IntroductionPanel.specialityText).onClickLink.Set(new EventCallback1(OnClickEffectLink));
	}

	public void UnregisterUiEventListeners()
	{
		//IL_001d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0027: Expected O, but got Unknown
		//IL_0048: Unknown result type (might be due to invalid IL or missing references)
		//IL_0052: Expected O, but got Unknown
		//IL_0069: Unknown result type (might be due to invalid IL or missing references)
		//IL_0073: Expected O, but got Unknown
		//IL_0086: Unknown result type (might be due to invalid IL or missing references)
		//IL_0090: Expected O, but got Unknown
		//IL_00a8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b2: Expected O, but got Unknown
		//IL_00c5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00cf: Expected O, but got Unknown
		//IL_00e2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ec: Expected O, but got Unknown
		addWorkerBtn.GetChild("addButton").onClick.Remove(new EventCallback0(WorkerAddClick));
		addWorkerBtn.GetChild("ExclamationMarkBtn").onClick.Remove(new EventCallback1(FGUIManager.Instance.OpenExclamationMarkPanel));
		((GObject)ExclamationMarkBtn).onClick.Remove(new EventCallback1(FGUIManager.Instance.OpenExclamationMarkPanel));
		((GObject)backBtn).onClick.Remove(new EventCallback0(BackClick));
		((GObject)IntroductionPanel.exit).onClick.Remove(new EventCallback0(IntroductionPanelClose));
		((GObject)ConfirmBtn).onClick.Remove(new EventCallback1(LegendSoldiersConfirm));
		((GObject)IslandComeAgainConfirm).onClick.Remove(new EventCallback1(OnGvGConfirmClick));
		SharedMessenger.RemoveListener<Building>("WORKERS_ALLOCATION_DISPLAY_CHANGED", UpdateWorkerNum);
		SharedMessenger.RemoveListener<string, int, (StockInContext, string)>("ON_STOCK_CHANGE", UpdateSoldiersNum);
		((GObject)IntroductionPanel.specialityText).onClickLink.Clear();
	}

	private void OnGvGConfirmClick(EventContext context)
	{
		if (IsIslandComeAgain)
		{
			IslandComeAgainLocalSoldiersConfirm(context);
		}
		else if (IsGvGMode3)
		{
			OnConfirmSelectedWithTick(context);
		}
	}

	private void IntroductionPanelClose()
	{
		((GObject)IntroductionPanel).visible = false;
		((GObject)IntroductionPanel.SoldierAnimation.icon).displayObject.Dispose();
		((GObject)IntroductionPanel.SoldierAnimation.baseSpine).displayObject.Dispose();
		((GObject)IntroductionPanel.SoldierAnimation.maskSpine).displayObject.Dispose();
	}

	private void UnlockArmsItemClick(EventContext context)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		if (((GObject)context.sender).data is Soldier soldier)
		{
			RenderIntroductionPanel(soldier);
		}
	}

	public void ArmsItemClick(EventContext context)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_003a: Unknown result type (might be due to invalid IL or missing references)
		string text = ((Soldier)((GObject)context.sender).data)?.Id;
		if (!string.IsNullOrEmpty(text))
		{
			((GComponent)((GObject)context.sender).asButton).GetController("RedPointController").selectedIndex = 0;
			GameManagers.Instance.NewMsgIncomingManager.SoldierChecked(text);
			if (_chosenType != 3)
			{
				((GObject)armsBtn.note).visible = GameManagers.Instance.NewMsgIncomingManager.AnySoldierHasNewMsg(flush: true);
			}
			if (chosenMode)
			{
				ArmsItemClickOnChoiceModel(context, text);
				return;
			}
			GameController.Contexts.Service<IUiService>().OpenPanel(UI_SoldierCultivate.Name, new Dictionary<string, object>
			{
				{ "soldierId", text },
				{ "soldierPanel", null },
				{ "isFGUI", true },
				{ "LegionPanel", this },
				{ "UnlockSoldierList", unlockSoldierRenderList }
			});
		}
	}

	private void ChipsItemClick(EventContext context)
	{
		//IL_000d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0017: Expected O, but got Unknown
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		int childIndex = ((GComponent)chipsList).GetChildIndex((GObject)context.sender);
		Pieces pieces = ChipsList[childIndex];
		((GObject)((GComponent)((GObject)context.sender).asButton).GetChild("redNote").asImage).visible = false;
		GameManagers.Instance.NewMsgIncomingManager.SoldierPieceChecked(pieces.RelativeContext);
		((GObject)chipBtn.note).visible = GameManagers.Instance.NewMsgIncomingManager.AnySoldierPieceHasNewMsg();
	}

	private void ToSoldierCultivate(string soldierId)
	{
		GameController.Contexts.Service<IUiService>().OpenPanel(UI_SoldierCultivate.Name, new Dictionary<string, object>
		{
			{ "soldierId", soldierId },
			{ "soldierPanel", null },
			{ "isFGUI", true },
			{ "LegionPanel", this },
			{ "Tab", 1 },
			{ "UnlockSoldierList", SoldierList }
		});
	}

	private void WorkerAddClick()
	{
		List<string> arg = new List<string> { LanguagesManager.GetDesc("CsharpCodeZhTcText21") };
		SharedMessenger.Broadcast("SHOW_TIPS", arg, 1, arg3: false);
	}

	private void DiamondAddClick()
	{
	}

	private void BackClick()
	{
		End();
	}

	private void ArmsItemClickOnChoiceModel(EventContext eventContext, string soldierId)
	{
		if (_chosenType != 1 && _chosenType == 2)
		{
			StationConfirmPanelInit(soldierId);
			return;
		}
		if (!_fromGvG3ModeShipDetail)
		{
			SharedMessenger.Broadcast<EventContext, string, int>("ON_SOLDIER_SELECTED", eventContext, soldierId, _chosenType);
		}
		End();
	}

	private void OpenConfirmWindow(string soldierId, int type)
	{
		//IL_0164: Unknown result type (might be due to invalid IL or missing references)
		//IL_016e: Expected O, but got Unknown
		//IL_018b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0195: Expected O, but got Unknown
		UI_ConfirmWindow confirmWindow = UI_ConfirmWindow.CreateInstance();
		((GComponent)this).AddChild((GObject)(object)confirmWindow);
		((GObject)confirmWindow).SetXY(0f, 0f);
		((GObject)confirmWindow).sortingOrder = 99;
		string text = "";
		string text2 = "";
		if (type == 1)
		{
			text = LanguagesManager.GetDesc("CsharpCodeZhTcText348");
			text2 = LanguagesManager.GetDesc("CsharpCodeZhTcText349");
		}
		else if (type == 2)
		{
			text = LanguagesManager.GetDesc("CsharpCodeZhTcText350");
			text2 = LanguagesManager.GetDesc("CsharpCodeZhTcText348");
		}
		((GObject)confirmWindow.ConfirmDialog.tip).text = GameManagers.Instance.SoldierManager.Get(soldierId).Name + LanguagesManager.GetDesc("CsharpCodeZhTcText354") + text + "," + LanguagesManager.GetDesc("CsharpCodeZhTcText355") + text2 + LanguagesManager.GetDesc("CsharpCodeZhTcText356") + "?";
		confirmWindow.showTip.Play();
		((GObject)confirmWindow.ConfirmDialog.noBtn).onClick.Add((EventCallback0)delegate
		{
			((GComponent)this).RemoveChild((GObject)(object)confirmWindow);
			((GObject)confirmWindow).Dispose();
		});
		((GObject)confirmWindow.ConfirmDialog.yesBtn).onClick.Add((EventCallback1)delegate(EventContext eventContext)
		{
			((GComponent)this).RemoveChild((GObject)(object)confirmWindow);
			((GObject)confirmWindow).Dispose();
			if (type == 1)
			{
				FindStrongholdBySoldierId(soldierId)?.WithdrawOccupantFromStronghold(GameManagers.Instance);
				SharedMessenger.Broadcast<EventContext, string, int>("ON_SOLDIER_SELECTED", eventContext, soldierId, _chosenType);
				End();
			}
			else if (type == 2)
			{
				string formationContext = ChapterType.StoryMain.ToString();
				Level level = GameController.Contexts.Service<IBattleFieldService>().Level;
				if (level != null)
				{
					Activity levelActivity = GameManagers.Instance.ActivityManager.GetLevelActivity(level);
					formationContext = ((levelActivity == null) ? level.FormationContext : levelActivity.FormationTag);
				}
				string mode = level?.BattleMode.ToString() ?? BattleMode.RushMode.ToString();
				int pos = UI_Battle.GetFormationUnits(formationContext, mode).IndexOf(soldierId);
				ILRequestHelper<ChangeFormationUnitResponse>.Request(eventContext, () => GameController.Contexts.Service<INetworkService>().ChangeFormationUnit(0L, formationContext, mode, pos, "Unlock"), delegate(ChangeFormationUnitResponse response)
				{
					if (!response.Result)
					{
						ILRequestHelper.ShowErrorCode(response.ErrorCode);
					}
					else
					{
						ActionResult actionResult = GameManagers.Instance.FormationUnitsManager.ChangeFormationUnit(formationContext, mode, pos, "Unlock");
						if (!actionResult.Result)
						{
							ILRequestHelper.ShowMessage(actionResult.ErrorMessage);
						}
						else
						{
							if (WorldMapPanel != null)
							{
								SharedMessenger.Broadcast<EventContext, string, int>("ON_SOLDIER_SELECTED", null, soldierId, _chosenType);
							}
							End();
						}
					}
				});
			}
			else
			{
				End();
			}
		});
	}

	private Stronghold FindStrongholdBySoldierId(string soldierId)
	{
		Stronghold result = null;
		bool flag = false;
		foreach (KeyValuePair<string, Region> region in WorldMapManager.Regions)
		{
			foreach (Stronghold stronghold in region.Value.Strongholds)
			{
				if (stronghold.IsOccupied(GameManagers.Instance) && stronghold.Occupant(GameManagers.Instance) == soldierId)
				{
					result = stronghold;
					flag = true;
					break;
				}
			}
			if (flag)
			{
				break;
			}
		}
		return result;
	}

	private void SetBuildingName()
	{
		((GObject)Title.buildingName).text = LanguagesManager.GetDesc("CsharpCodeZhTcText351");
	}

	private void UpdateWorkerNum(Building building = null)
	{
		//IL_014b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0150: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ab: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f2: Unknown result type (might be due to invalid IL or missing references)
		Dungeon value = GameController.Contexts.game.dungeon.value;
		addWorkerBtn.GetChild("CurrentWorkerAmount").text = Dungeon.GetFreeManPower(GameManagers.Instance).ToString();
		addWorkerBtn.GetChild("AllWorkerAmount").text = Dungeon.GetTotalManPower(GameManagers.Instance).ToString();
		if (GameManagers.Instance.LeaseholdManager.GetLeaseholdManPower() > 0)
		{
			addWorkerBtn.GetChild("AllWorkerAmount").asTextField.color = Color32.op_Implicit(new Color32((byte)175, (byte)246, (byte)39, byte.MaxValue));
			addWorkerBtn.GetChild("ExclamationMarkBtn").data = new Dictionary<string, object>
			{
				{
					"Title",
					LanguagesManager.GetDesc("CsharpCodeZhTcText106")
				},
				{
					"Pos",
					(object)new Vector2(1718f, 88f)
				}
			};
			addWorkerBtn.GetChild("ExclamationMarkBtn").visible = true;
		}
		else
		{
			addWorkerBtn.GetChild("AllWorkerAmount").asTextField.color = Color32.op_Implicit(new Color32((byte)243, (byte)221, (byte)170, byte.MaxValue));
			addWorkerBtn.GetChild("ExclamationMarkBtn").visible = false;
		}
	}

	private void RenderSkillListItem(string skillId, GObject button, bool isUnLocked, int limit, bool isShow, int index)
	{
		//IL_00b6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c0: Expected O, but got Unknown
		GDEAbilityData gDEAbilityData = GDMgr.TryGetWithErrorHandling<GDEAbilityData>(skillId);
		((GComponent)((GComponent)button.asButton).GetChild("IconBtn").asButton).GetChild("IconLoader").asLoader.LoadAbilityIcon(gDEAbilityData.Icon);
		if (isUnLocked)
		{
			((GComponent)button.asButton).GetChild("IconBtn").grayed = false;
			button.touchable = true;
			Tuple<GDEAbilityData, int, bool, bool> data = new Tuple<GDEAbilityData, int, bool, bool>(gDEAbilityData, limit, isUnLocked, isShow);
			button.data = data;
		}
		else
		{
			((GComponent)button.asButton).GetChild("IconBtn").grayed = true;
			Tuple<GDEAbilityData, int, bool, bool> data2 = new Tuple<GDEAbilityData, int, bool, bool>(gDEAbilityData, limit, isUnLocked, isShow);
			button.data = data2;
			button.touchable = true;
		}
		button.onClick.Add(new EventCallback1(SkillDetailPopup));
		if (isShow)
		{
			((GComponent)button.asButton).GetChild("IconBtn").grayed = false;
		}
		int num = 5 - 5 * ((GComponent)IntroductionPanel.skillList).GetChildIndex(button);
		((GComponent)button.asButton).GetChild("n16").rotation = num;
	}

	private void SkillListRenderer(Soldier soldier)
	{
		IntroductionPanel.skillList.RemoveChildrenToPool();
		List<string> list = new List<string>();
		string currentLevelFeatureAbilityId = soldier.GetCurrentLevelFeatureAbilityId();
		for (int i = 0; i < soldier.AbilityList.Count; i++)
		{
			if (!(soldier.AbilityList[i] == soldier.FeatureAbility) && GDMgr.TryGetWithErrorHandling<GDEAbilityData>(soldier.AbilityList[i]).Visible)
			{
				list.Add(soldier.AbilityList[i]);
			}
		}
		GDEAbilityData gDEAbilityData = GDMgr.TryGetWithErrorHandling<GDEAbilityData>(currentLevelFeatureAbilityId);
		((GObject)IntroductionPanel.specialityName).text = $"{gDEAbilityData.Name} LV{1}";
		((GObject)IntroductionPanel.specialityText).text = Singleton<AbilityDataManager>.Instance.GetDescription(gDEAbilityData.Key);
		bool isShow = !GameManagers.Instance.UserArchiveManager.GetUnlockedSoldiers().Contains(soldier.Id);
		Dictionary<string, int> dictionary = soldier.AbilitiesUnlockState();
		for (int j = 0; j < list.Count; j++)
		{
			bool isUnLocked = ((dictionary[list[j]] <= soldier.PotentialLevel) ? true : false);
			IntroductionPanel.skillList.AddItemFromPool();
			RenderSkillListItem(list[j], ((GComponent)IntroductionPanel.skillList).GetChildAt(j), isUnLocked, dictionary[list[j]], isShow, j);
		}
		if (IntroductionPanel.skillList.numItems == 0)
		{
			((GObject)IntroductionPanel.skillTitleGroup).visible = false;
		}
		else
		{
			((GObject)IntroductionPanel.skillTitleGroup).visible = true;
		}
	}

	private void RenderUnlockArmsListItem(int index, GObject obj, Soldier soldier)
	{
		//IL_01ed: Unknown result type (might be due to invalid IL or missing references)
		//IL_01f7: Expected O, but got Unknown
		GButton asButton = obj.asButton;
		((DisplayObject)((GComponent)asButton).GetChild("iconFrame").asLoader.image).material = null;
		((GComponent)asButton).GetController("Level").selectedIndex = 0;
		((GComponent)asButton).GetChild("title").text = soldier.Name;
		((GObject)((GComponent)asButton).GetChild("lv").asRichTextField).text = soldier.Level.ToString();
		((GComponent)asButton).GetChild("icon").asLoader.url = "ui://PublicResources/" + UiHelper.GetIconPath(soldier.Id);
		((GObject)((GComponent)asButton).GetChild("racePicture").asButton).visible = true;
		((GComponent)((GComponent)asButton).GetChild("racePicture").asButton).GetController("Type").selectedIndex = FGUIManager.Instance.GetRaceIcon(soldier.Faction);
		((GComponent)asButton).GetChild("LegendItems").visible = false;
		string iconFrameBorderSoldier = UiHelper.GetIconFrameBorderSoldier();
		((GComponent)asButton).GetChild("iconFrame").asLoader.url = "ui://PublicResources/" + iconFrameBorderSoldier;
		UiHelper.LoadSoldierIconFrameMaterial(((GComponent)asButton).GetChild("iconFrame").asLoader, 1, shaderList);
		((GComponent)asButton).GetChild("lvFrame").asLoader.url = $"ui://PublicResources/kuang_round 3_lv{1}";
		FGUIManager.Instance.SetAlightSoulStoneForSoldierIcon(((GComponent)asButton).GetChild("SoulStoneLevel").asCom, soldier.PotentialLevel, soldier.PotentialProgress, isActivating: false, needMask: false);
		RenderStonesList(soldier.Id, ((GComponent)asButton).GetChild("unlockSoldiersStonesList").asList);
		((GComponent)asButton).GetController("Status").selectedIndex = 2;
		((GComponent)asButton).GetController("RedPointController").selectedIndex = 0;
		((GObject)asButton).data = soldier;
		((GObject)asButton).onClick.Clear();
		((GObject)asButton).onClick.Set(new EventCallback1(UnlockArmsItemClick));
	}

	public static void RenderLockSoldierStoneList(string sid, GList stoneGList)
	{
		//IL_01e7: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ec: Unknown result type (might be due to invalid IL or missing references)
		List<int> list = new List<int>();
		List<int> list2 = new List<int> { 1, 2, 3, 4, 5 };
		for (int i = 0; i < stoneGList.numItems; i++)
		{
			list.Add(0);
		}
		for (int j = 0; j < list2.Count; j++)
		{
			string itemId = $"I2{list2[j]}{sid.Substring(1)}";
			switch (Item.Level(GameManagers.Instance, itemId))
			{
			case 1:
				list[0] += GameManagers.Instance.StockController.GetStock(itemId);
				break;
			case 2:
				list[1] += GameManagers.Instance.StockController.GetStock(itemId);
				break;
			case 3:
				list[2] += GameManagers.Instance.StockController.GetStock(itemId);
				break;
			case 4:
				list[3] += GameManagers.Instance.StockController.GetStock(itemId);
				break;
			case 5:
				list[4] += GameManagers.Instance.StockController.GetStock(itemId);
				break;
			}
		}
		for (int k = 0; k < stoneGList.numItems; k++)
		{
			GComponent asCom = ((GComponent)stoneGList).GetChildAt(k).asCom;
			asCom.GetChild("num").text = list[k].ShortNumberFormat();
			asCom.GetChild("num").asTextField.strokeColor = Color32.op_Implicit(new Color32((byte)0, (byte)0, (byte)0, (byte)229));
		}
	}

	private void RenderStonesList(string sid, GList stoneGList)
	{
		//IL_0124: Unknown result type (might be due to invalid IL or missing references)
		//IL_0129: Unknown result type (might be due to invalid IL or missing references)
		//IL_0185: Unknown result type (might be due to invalid IL or missing references)
		//IL_018a: Unknown result type (might be due to invalid IL or missing references)
		//IL_01e6: Unknown result type (might be due to invalid IL or missing references)
		//IL_01eb: Unknown result type (might be due to invalid IL or missing references)
		stoneGList.RemoveChildrenToPool();
		int num = 0;
		int num2 = 0;
		int num3 = 0;
		List<int> list = new List<int> { 1, 3, 5 };
		for (int i = 0; i < list.Count; i++)
		{
			string itemId = $"I2{list[i]}{sid.Substring(1)}";
			switch (Item.Level(GameManagers.Instance, itemId))
			{
			case 1:
				num += GameManagers.Instance.StockController.GetStock(itemId);
				break;
			case 3:
				num2 += GameManagers.Instance.StockController.GetStock(itemId);
				break;
			case 5:
				num3 += GameManagers.Instance.StockController.GetStock(itemId);
				break;
			}
		}
		GComponent asCom = stoneGList.AddItemFromPool().asCom;
		asCom.GetChild("num").text = num.ShortNumberFormat();
		asCom.GetChild("num").asTextField.strokeColor = Color32.op_Implicit(new Color32((byte)0, (byte)0, (byte)0, (byte)229));
		asCom.GetController("Status").selectedIndex = 0;
		GComponent asCom2 = stoneGList.AddItemFromPool().asCom;
		asCom2.GetChild("num").text = num2.ShortNumberFormat();
		asCom2.GetChild("num").asTextField.strokeColor = Color32.op_Implicit(new Color32((byte)0, (byte)0, (byte)0, (byte)229));
		asCom2.GetController("Status").selectedIndex = 1;
		GComponent asCom3 = stoneGList.AddItemFromPool().asCom;
		asCom3.GetChild("num").text = num3.ShortNumberFormat();
		asCom3.GetChild("num").asTextField.strokeColor = Color32.op_Implicit(new Color32((byte)0, (byte)0, (byte)0, (byte)229));
		asCom3.GetController("Status").selectedIndex = 2;
	}

	public void UpdateSoldierBtnFromCultivate(string _soldierId, bool legendItemsChanged, string lastSoldierId = "")
	{
		if (!string.IsNullOrWhiteSpace(_soldierId))
		{
			RefreshLegionTotalPower();
			UnlockSoldierListReCalc_CombatPower(_soldierId);
			if (!string.IsNullOrWhiteSpace(lastSoldierId) && legendItemsChanged)
			{
				UnlockSoldierListReCalc_CombatPower(lastSoldierId);
			}
			UnlockSoldierListReSort();
			UpdateRenderSoldiersList();
			LegendSoldiersRender();
			IslandComeAgainSoldiersRender();
			RenderGvGMode3LegionList();
			RenderArmsList();
			if (UI_SoldierCultivate.SoldierCultivatePanel != null)
			{
				UI_SoldierCultivate.SoldierCultivatePanel.UnlockSoldier = unlockSoldierRenderList;
			}
		}
	}

	private void UpdateSoldierLegendItems(string soldierId, GButton btn)
	{
		if (LegendItemsHelper.SoldiersEquippedItems != null && LegendItemsHelper.SoldiersEquippedItems.ContainsKey(soldierId))
		{
			for (int i = 0; i < 2; i++)
			{
				((GComponent)btn).GetChild($"legendItem{i}").visible = false;
			}
			int num = 0;
			for (int j = 0; j < LegendItemsHelper.SoldiersEquippedItems[soldierId].Length; j++)
			{
				if (num >= 2)
				{
					break;
				}
				GButton asButton = ((GComponent)btn).GetChild($"legendItem{num}").asButton;
				if (!LegendItemsHelper.GetSoldierItemSlotState(soldierId, j))
				{
					((GObject)asButton).visible = false;
					continue;
				}
				long num2 = LegendItemsHelper.SoldiersEquippedItems[soldierId][j];
				((GObject)asButton).visible = true;
				if (num2 == 0)
				{
					((GObject)asButton).visible = false;
					continue;
				}
				UiHelper.RenderLegendItem(asButton, LegendItemsHelper.GetLegendItemUi(num2), UiHelper.TextColorType.Light, textureList, 2);
				num++;
			}
			switch (num)
			{
			case 1:
				((GComponent)btn).GetController("LegendItemNum").selectedIndex = 0;
				((GComponent)btn).GetChild("n56").visible = false;
				break;
			case 2:
				((GComponent)btn).GetController("LegendItemNum").selectedIndex = 1;
				((GComponent)btn).GetChild("n56").visible = true;
				break;
			}
			bool flag = false;
			for (int k = 0; k < 2; k++)
			{
				GButton asButton2 = ((GComponent)btn).GetChild($"legendItem{k}").asButton;
				if (((GObject)asButton2).visible)
				{
					break;
				}
				if (k == 1)
				{
					flag = true;
				}
			}
			((GComponent)btn).GetChild("LegendItems").visible = !flag;
		}
		else
		{
			((GComponent)btn).GetChild("LegendItems").visible = false;
		}
	}

	private void RenderArmsListItem(int index, GObject obj, Soldier soldier)
	{
		//IL_01f6: Unknown result type (might be due to invalid IL or missing references)
		//IL_01fb: Unknown result type (might be due to invalid IL or missing references)
		//IL_0578: Unknown result type (might be due to invalid IL or missing references)
		//IL_0567: Unknown result type (might be due to invalid IL or missing references)
		//IL_057d: Unknown result type (might be due to invalid IL or missing references)
		GButton asButton = obj.asButton;
		((GObject)asButton).data = soldier;
		((GComponent)asButton).GetController("Status").selectedIndex = 0;
		((DisplayObject)((GComponent)asButton).GetChild("iconFrame").asLoader.image).material = null;
		Dictionary<string, Dictionary<string, List<string>>> value = GameController.Contexts.config.formationUnits.value;
		string text = GameController.Contexts.Service<IBattleFieldService>().LevelFormationContext;
		if (chosenMode && _chosenType == 2)
		{
			text = ChapterType.StoryMain.ToString();
		}
		string key = GameController.Contexts.Service<IBattleFieldService>().Level?.BattleMode.ToString() ?? BattleMode.RushMode.ToString();
		((GObject)((GComponent)asButton).GetChild("assemblyNote").asImage).visible = false;
		((GObject)((GComponent)asButton).GetChild("occupation").asImage).visible = false;
		((GObject)((GComponent)asButton).GetChild("removeBack").asImage).visible = false;
		((GObject)((GComponent)asButton).GetChild("removeNote").asImage).visible = false;
		((GObject)((GComponent)asButton).GetChild("removeText").asTextField).visible = false;
		string iconPath = UiHelper.GetIconPath(soldier.Id);
		((GComponent)asButton).GetChild("icon").asLoader.url = "ui://PublicResources/" + iconPath;
		((GObject)((GComponent)asButton).GetChild("lv").asRichTextField).text = soldier.Level.ToString();
		if (isLegendItemDungeon)
		{
			int soldierCurNum = LegendItemDungeonUiHelper.GetSoldierCurNum(soldier.Id);
			GRichTextField asRichTextField = ((GComponent)asButton).GetChild("num").asRichTextField;
			((GObject)asRichTextField).text = soldierCurNum.ToString();
			if (soldierCurNum <= 0)
			{
				((GTextField)((GObject)asRichTextField).asRichTextField).color = Color32.op_Implicit(new Color32(byte.MaxValue, (byte)25, (byte)25, byte.MaxValue));
			}
		}
		else
		{
			((GObject)((GComponent)asButton).GetChild("num").asRichTextField).text = "";
			Real_UpdateSoldierNum(asButton, soldier.Id);
		}
		((GObject)((GComponent)asButton).GetChild("assemblyNote").asImage).visible = false;
		if (value != null && value.ContainsKey(text))
		{
			Dictionary<string, List<string>> dictionary = value[text];
			if (dictionary != null && dictionary.ContainsKey(key))
			{
				List<string> list = dictionary[key];
				((GObject)((GComponent)asButton).GetChild("assemblyNote").asImage).visible = list.Contains(soldier.Id);
			}
		}
		((GObject)((GComponent)asButton).GetChild("occupation").asImage).visible = text == ChapterType.StoryMain.ToString() && GameManagers.Instance.UserArchiveManager.GetAssignedSoldiers().Contains(soldier.Id);
		((GComponent)asButton).GetController("RedPointController").selectedIndex = 0;
		if (GameManagers.Instance.NewMsgIncomingManager.SoldierIsNewUnlocked(soldier.Id))
		{
			((GComponent)asButton).GetController("RedPointController").selectedIndex = 2;
		}
		else if (GameManagers.Instance.NewMsgIncomingManager.SoldierHasNewMsg(soldier.Id))
		{
			((GComponent)asButton).GetController("RedPointController").selectedIndex = 1;
		}
		else
		{
			((GComponent)asButton).GetController("RedPointController").selectedIndex = 0;
		}
		string iconFrameBorderSoldier = UiHelper.GetIconFrameBorderSoldier(soldier.PotentialLevel);
		((GComponent)asButton).GetChild("iconFrame").asLoader.url = "ui://PublicResources/" + iconFrameBorderSoldier;
		UiHelper.LoadSoldierIconFrameMaterial(((GComponent)asButton).GetChild("iconFrame").asLoader, soldier.PotentialLevel, shaderList);
		if (chosenMode && _chosenType == 2)
		{
			((GComponent)asButton).GetController("Status").selectedIndex = 1;
			float num = curStronghold.CalcOccupantEfficiencyModifier(GameManagers.Instance, soldier.Id);
			((GComponent)asButton).GetChild("modifierText").text = "[color=" + UiHelper.GetStrongHoldModifierColor(num) + "]+" + UiHelper.RemoveSurplusZeroBehindDecimalPoint($"{Convert.ToInt32(num * 100f)}") + "%[/color]";
		}
		else
		{
			((GComponent)asButton).GetController("Status").selectedIndex = 0;
		}
		int num2 = ((soldier.PotentialLevel < 9) ? ((soldier.PotentialLevel + 2) / 2) : 6);
		((GObject)((GComponent)asButton).GetChild("racePicture").asButton).visible = true;
		((GComponent)((GComponent)asButton).GetChild("racePicture").asButton).GetController("Type").selectedIndex = FGUIManager.Instance.GetRaceIcon(soldier.Faction);
		string text2 = "title";
		if (num2 >= 5)
		{
			text2 = "title_Max";
			((GComponent)asButton).GetController("Level").selectedIndex = 1;
		}
		else
		{
			((GComponent)asButton).GetController("Level").selectedIndex = 0;
		}
		((GComponent)asButton).GetChild(text2).text = soldier.Name;
		((GTextField)((GComponent)asButton).GetChild(text2).asRichTextField).color = Color32.op_Implicit(chosenMode ? SoldierNameColor2[num2 - 1] : SoldierNameColor1[num2 - 1]);
		((GComponent)asButton).GetChild("lvFrame").asLoader.url = UiHelper.GetLevelFrameBorderSoldier(soldier.PotentialLevel);
		GComponent rune = FGUIManager.Instance.SetAlightSoulStoneForSoldierIcon(((GComponent)asButton).GetChild("SoulStoneLevel").asCom, soldier.PotentialLevel, soldier.PotentialProgress, isActivating: false, needMask: false);
		AllRuneGComponentsAdd(rune);
		RuneGComponentSetVisible(rune);
		((GComponent)asButton).GetChild("LegendItems").visible = false;
		if (LegendItemsHelper.SoldiersEquippedItems != null && LegendItemsHelper.SoldiersEquippedItems.ContainsKey(soldier.Id))
		{
			for (int i = 0; i < 2; i++)
			{
				((GComponent)asButton).GetChild($"legendItem{i}").visible = false;
			}
			int num3 = 0;
			for (int j = 0; j < LegendItemsHelper.SoldiersEquippedItems[soldier.Id].Length; j++)
			{
				if (num3 >= 2)
				{
					break;
				}
				GButton asButton2 = ((GComponent)asButton).GetChild($"legendItem{num3}").asButton;
				if (!LegendItemsHelper.GetSoldierItemSlotState(soldier.Id, j))
				{
					((GObject)asButton2).visible = false;
					continue;
				}
				long num4 = LegendItemsHelper.SoldiersEquippedItems[soldier.Id][j];
				((GObject)asButton2).visible = true;
				if (num4 == 0)
				{
					((GObject)asButton2).visible = false;
					continue;
				}
				UiHelper.RenderLegendItem(asButton2, LegendItemsHelper.GetLegendItemUi(num4), UiHelper.TextColorType.Light, textureList, 2);
				num3++;
			}
			switch (num3)
			{
			case 1:
				((GComponent)asButton).GetController("LegendItemNum").selectedIndex = 0;
				((GComponent)asButton).GetChild("n56").visible = false;
				break;
			case 2:
				((GComponent)asButton).GetController("LegendItemNum").selectedIndex = 1;
				((GComponent)asButton).GetChild("n56").visible = true;
				break;
			}
			bool flag = false;
			for (int k = 0; k < 2; k++)
			{
				GButton asButton3 = ((GComponent)asButton).GetChild($"legendItem{k}").asButton;
				if (((GObject)asButton3).visible)
				{
					break;
				}
				if (k == 1)
				{
					flag = true;
				}
			}
			((GComponent)asButton).GetChild("LegendItems").visible = !flag;
		}
		((GObject)asButton).onClick.Clear();
		((GObject)asButton).onClick.Add(callback1);
	}

	private void RenderStarItem(int index, GObject obj)
	{
		GComponent asCom = obj.asCom;
		asCom.GetChild("icon").asLoader.url = "ui://PublicResources/icon_star_Light";
	}

	private void RenderStarList(int num, GList list)
	{
		//IL_0009: Unknown result type (might be due to invalid IL or missing references)
		//IL_0013: Expected O, but got Unknown
		list.itemRenderer = new ListItemRenderer(RenderStarItem);
		list.numItems = num;
	}

	private void RenderChipsListItem(int index, GObject obj)
	{
		//IL_0311: Unknown result type (might be due to invalid IL or missing references)
		//IL_0313: Unknown result type (might be due to invalid IL or missing references)
		//IL_0318: Unknown result type (might be due to invalid IL or missing references)
		//IL_017f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0181: Unknown result type (might be due to invalid IL or missing references)
		GButton asButton = obj.asButton;
		Pieces pieces = ChipsList[index];
		if (SchemaIndexHelper.GetSchemaById(pieces.RelativeContext) != "Soldier")
		{
			return;
		}
		GameManagers instance = GameManagers.Instance;
		int stock = instance.StockController.GetStock(pieces.ItemId);
		Soldier soldier = instance.SoldierManager.Get(pieces.RelativeContext);
		GButton asButton2 = ((GComponent)((GComponent)asButton).GetChild("chip").asButton).GetChild("chipSon").asButton;
		((GComponent)asButton2).GetChild("icon").asLoader.url = "ui://PublicResources/" + UiHelper.GetIconPath(soldier.Id);
		((GObject)((GComponent)asButton).GetChild("redNote").asImage).visible = false;
		if (!instance.UserArchiveManager.GetUnlockedSoldiers().Contains(pieces.RelativeContext))
		{
			if (stock >= pieces.CompositeRequirement)
			{
				((GComponent)asButton2).GetChild("back").asLoader.url = "ui://PublicResources/diban_suipian_active";
				((GObject)((GComponent)asButton).GetChild("state").asGroup).visible = true;
				((GObject)((GComponent)asButton).GetChild("stateText").asTextField).text = LanguagesManager.GetDesc("CsharpCodeZhTcText352");
				Color32 val = default(Color32);
				((Color32)(ref val))._002Ector((byte)175, (byte)246, (byte)39, byte.MaxValue);
				((GComponent)asButton).GetChild("stateText").asTextField.color = Color32.op_Implicit(val);
				((GObject)((GComponent)asButton).GetChild("total").asRichTextField).text = $"[color=#AFF627]{stock.ShortNumberFormat()}[/color][color=#F3E1BE]/{pieces.CompositeRequirement}[/color]";
				if (instance.NewMsgIncomingManager.SoldierPieceHasNewMsg(soldier.Id))
				{
					((GObject)((GComponent)asButton).GetChild("redNote").asImage).visible = true;
				}
			}
			else
			{
				((GComponent)asButton2).GetChild("back").asLoader.url = "ui://PublicResources/diban_suipian";
				((GObject)((GComponent)asButton).GetChild("state").asGroup).visible = false;
				((GObject)((GComponent)asButton).GetChild("total").asRichTextField).text = $"[color=#E94C27]{stock.ShortNumberFormat()}[/color][color=#FFF2D3]/{pieces.CompositeRequirement}[/color]";
			}
			((GObject)((GComponent)asButton).GetChild("texts").asGroup).visible = true;
			((GObject)((GComponent)asButton).GetChild("total").asRichTextField).visible = true;
		}
		else
		{
			((GComponent)asButton2).GetChild("back").asLoader.url = "ui://PublicResources/diban_suipian";
			((GObject)((GComponent)asButton).GetChild("state").asGroup).visible = true;
			((GObject)((GComponent)asButton).GetChild("stateText").asTextField).text = LanguagesManager.GetDesc("CsharpCodeZhTcText48");
			Color32 val2 = default(Color32);
			((Color32)(ref val2))._002Ector((byte)213, (byte)218, (byte)122, byte.MaxValue);
			TextFormat textFormat = ((GComponent)asButton).GetChild("stateText").asTextField.textFormat;
			textFormat.color = Color32.op_Implicit(val2);
			((GComponent)asButton).GetChild("stateText").asTextField.textFormat = textFormat;
			((GObject)((GComponent)asButton).GetChild("texts").asGroup).visible = false;
			((GObject)((GComponent)asButton).GetChild("total").asRichTextField).visible = true;
			((GObject)((GComponent)asButton).GetChild("total").asRichTextField).text = stock.ShortNumberFormat() ?? "";
		}
		int stock2 = instance.StockController.GetStock(pieces.ItemId);
		int limit = instance.StockController.GetLimit(pieces.ItemId);
		((GComponent)asButton).GetChild("max").visible = stock2 >= limit;
		((GObject)asButton).onClick.Add(callback2);
	}

	private void LegendSoldiersConfirm(EventContext context)
	{
		UI_LegendItemDungeonPanel.selectSoldierData.Clear();
		for (int i = 0; i < fakeSoldierDatas.Count; i++)
		{
			UI_LegendItemDungeonPanel.selectSoldierData.Add(new KeyValuePair<string, int>(fakeSoldierDatas[i], LegendItemDungeonUiHelper.GetSoldierNum(fakeSoldierDatas[i])));
		}
		UI_LegendItemDungeonPanel.legendItemDungeonPanel?.SoldiersRender();
		UI_LegendItemDungeonPanel.legendItemDungeonPanel?.MapCom.Map.MapMain.UpdateDownward();
		End();
	}

	private void LegendSoldiersRender()
	{
		if (!chosenMode || _chosenType != 5)
		{
			return;
		}
		FGUIManager.Instance.ClearCache_SoliderSoulStone();
		controller.selectedIndex = 3;
		foreach (KeyValuePair<string, int> selectSoldierDatum in UI_LegendItemDungeonPanel.selectSoldierData)
		{
			if (!fakeSoldierDatas.Contains(selectSoldierDatum.Key))
			{
				fakeSoldierDatas.Add(selectSoldierDatum.Key);
			}
		}
		if (fakeSoldierDatas.Count <= 0)
		{
			foreach (string lastLegendExplorationSoldier in GameLocalDataManager.GetLastLegendExplorationSoldiers())
			{
				fakeSoldierDatas.Add(lastLegendExplorationSoldier);
			}
		}
		if (_Coroutine_RenderLegendSoldiers != null)
		{
			FGUIManager.Instance.CloseIEnumerator(_Coroutine_RenderLegendSoldiers);
		}
		_Coroutine_RenderLegendSoldiers = FGUIManager.Instance.OpenIEnumerator(Real_LegendSoldiersRender());
		((GObject)tip1).text = string.Format("{0}({1}/{2}):", LanguagesManager.GetDesc("CsharpCodeZhTcText344"), fakeSoldierDatas.Count, LegendItemDungeonUiHelper.MaxLegionSize);
		((GObject)ConfirmBtn).enabled = fakeSoldierDatas.Count > 0;
	}

	private IEnumerator Real_LegendSoldiersRender()
	{
		float armsListAHeight = (float)Mathf.CeilToInt((float)(chosenMode ? (soldierRenderListA.Count + 1) : soldierRenderListA.Count) / 5f) * 249f;
		float armsListBHeight = (float)Mathf.CeilToInt((float)soldierRenderListB.Count / 5f) * 249f;
		((GComponent)ArmsList.armsList_a).viewHeight = armsListAHeight;
		((GComponent)ArmsList.armsList_a).EnsureBoundsCorrect();
		((GComponent)ArmsList.armsList_b).viewHeight = armsListBHeight;
		((GComponent)ArmsList.armsList_b).EnsureBoundsCorrect();
		((GObject)ArmsList.separatedLine).visible = soldierRenderListB.Count > 0;
		((GObject)ArmsList.separatedLine1).visible = soldierRenderListC.Count > 0;
		ArmsList.armsList_a.numItems = 0;
		ArmsList.armsList_b.numItems = 0;
		allRuneGComponents?.Clear();
		yield return null;
		for (int i = 0; i < soldierRenderListA.Count; i++)
		{
			GObject item = ArmsList.armsList_a.AddItemFromPool();
			item.touchable = false;
			item.alpha = 0f;
			RenderLegendSoldierItem(i, item, soldierRenderListA[i]);
			item.TweenFade(1f, 0.1f).OnComplete((GTweenCallback)delegate
			{
				item.touchable = true;
			});
			yield return null;
		}
		ArmsList.armsList_a.ResizeToFit(soldierRenderListA.Count);
		for (int i2 = 0; i2 < soldierRenderListB.Count; i2++)
		{
			GObject item2 = ArmsList.armsList_b.AddItemFromPool();
			item2.touchable = false;
			item2.alpha = 0f;
			RenderLegendSoldierItem(i2, item2, soldierRenderListB[i2]);
			item2.TweenFade(1f, 0.1f).OnComplete((GTweenCallback)delegate
			{
				item2.touchable = true;
			});
			yield return null;
		}
		ArmsList.armsList_b.ResizeToFit(soldierRenderListB.Count);
		((GObject)ArmsList.separatedLine).visible = soldierRenderListB.Count > 0;
		ArmsList.armsList_c.ResizeToFit(soldierRenderListC.Count);
		((GObject)ArmsList.separatedLine1).visible = false;
		((GComponent)ArmsList.armsList_a).EnsureBoundsCorrect();
		((GComponent)ArmsList.armsList_b).EnsureBoundsCorrect();
	}

	private void UpdateLegendSoldiers(EventContext context)
	{
		//IL_0014: Unknown result type (might be due to invalid IL or missing references)
		//IL_001a: Expected O, but got Unknown
		((GObject)ConfirmBtn).enabled = true;
		GButton val = (GButton)context.sender;
		string item = ((GObject)val).data.ToString();
		if (fakeSoldierDatas.Count >= LegendItemDungeonUiHelper.MaxLegionSize && !fakeSoldierDatas.Contains(item) && fakeSoldierDatas.Count >= LegendItemDungeonUiHelper.MaxLegionSize)
		{
			List<string> arg = new List<string> { string.Format("{0}{1}{2}", LanguagesManager.GetDesc("CsharpCodeZhTcText345"), LegendItemDungeonUiHelper.MaxLegionSize, LanguagesManager.GetDesc("CsharpCodeZhTcText346")) };
			SharedMessenger.Broadcast("SHOW_TIPS", arg, ((GObject)this).sortingOrder, arg3: false);
			return;
		}
		if (fakeSoldierDatas.Count >= LegendItemDungeonUiHelper.MaxLegionSize && fakeSoldierDatas.Contains(item))
		{
			((GComponent)val).GetChild("SelectNote").visible = false;
			((GComponent)val).GetChild("NumSelected").visible = false;
			((GComponent)val).GetChild("NumSelected1").visible = true;
			fakeSoldierDatas.Remove(item);
			((GObject)tip1).text = string.Format("{0}({1}/{2}):", LanguagesManager.GetDesc("CsharpCodeZhTcText344"), fakeSoldierDatas.Count, LegendItemDungeonUiHelper.MaxLegionSize);
			return;
		}
		bool flag = fakeSoldierDatas.Contains(item);
		if (flag)
		{
			fakeSoldierDatas.Remove(item);
		}
		else
		{
			fakeSoldierDatas.Add(item);
		}
		((GComponent)val).GetChild("SelectNote").visible = !flag;
		((GComponent)val).GetChild("NumSelected").visible = !flag;
		((GComponent)val).GetChild("NumSelected1").visible = flag;
		((GObject)tip1).text = string.Format("{0}({1}/{2}):", LanguagesManager.GetDesc("CsharpCodeZhTcText344"), fakeSoldierDatas.Count, LegendItemDungeonUiHelper.MaxLegionSize);
	}

	private void RenderLegendSoldierItem(int index, GObject obj, Soldier soldier)
	{
		//IL_0256: Unknown result type (might be due to invalid IL or missing references)
		//IL_0246: Unknown result type (might be due to invalid IL or missing references)
		//IL_025b: Unknown result type (might be due to invalid IL or missing references)
		//IL_05a5: Unknown result type (might be due to invalid IL or missing references)
		//IL_05af: Expected O, but got Unknown
		GButton asButton = obj.asButton;
		((GComponent)asButton).GetChild("assemblyNote").visible = false;
		((GComponent)asButton).GetChild("occupation").visible = false;
		((GComponent)asButton).GetChild("title").text = "";
		((GComponent)asButton).GetChild("removeBack").visible = false;
		((GComponent)asButton).GetChild("removeNote").visible = false;
		((GComponent)asButton).GetChild("removeText").visible = false;
		((GComponent)asButton).GetChild("SoulStoneLevel").visible = true;
		((GComponent)asButton).GetChild("racePicture").visible = false;
		((GComponent)asButton).GetChild("lv").text = soldier.Level.ToString();
		int num = ((soldier.PotentialLevel < 9) ? ((soldier.PotentialLevel + 2) / 2) : 6);
		((GComponent)asButton).GetChild("lvFrame").asLoader.url = UiHelper.GetLevelFrameBorderSoldier(soldier.PotentialLevel);
		((GComponent)asButton).GetChild("icon").asLoader.url = "ui://PublicResources/" + UiHelper.GetIconPath(soldier.Id);
		string iconFrameBorderSoldier = UiHelper.GetIconFrameBorderSoldier(soldier.PotentialLevel);
		((GComponent)asButton).GetChild("iconFrame").asLoader.url = "ui://PublicResources/" + iconFrameBorderSoldier;
		GComponent rune = FGUIManager.Instance.SetAlightSoulStoneForSoldierIcon(((GComponent)asButton).GetChild("SoulStoneLevel").asCom, soldier.PotentialLevel, soldier.PotentialProgress, isActivating: false, needMask: false);
		AllRuneGComponentsAdd(rune);
		RuneGComponentSetVisible(rune);
		((GObject)((GComponent)asButton).GetChild("racePicture").asButton).visible = true;
		((GComponent)((GComponent)asButton).GetChild("racePicture").asButton).GetController("Type").selectedIndex = FGUIManager.Instance.GetRaceIcon(soldier.Faction);
		string text = "title";
		if (num >= 5)
		{
			text = "title_Max";
			((GComponent)asButton).GetController("Level").selectedIndex = 1;
		}
		else
		{
			((GComponent)asButton).GetController("Level").selectedIndex = 0;
		}
		((GComponent)asButton).GetChild(text).text = soldier.Name;
		((GTextField)((GComponent)asButton).GetChild(text).asRichTextField).color = Color32.op_Implicit(chosenMode ? SoldierNameColor2[num - 1] : SoldierNameColor1[num - 1]);
		int stock = GameManagers.Instance.StockController.GetStock(soldier.Id);
		((GObject)((GComponent)asButton).GetChild("num").asRichTextField).text = $"{stock}";
		((GObject)((GComponent)asButton).GetChild("num2").asRichTextField).text = $"{stock}/{LegendItemDungeonUiHelper.GetSoldierLimitNum(soldier.Id)}";
		((GObject)asButton).data = soldier.Id;
		if (fakeSoldierDatas.Contains(soldier.Id))
		{
			((GComponent)asButton).GetChild("SelectNote").visible = true;
			((GComponent)asButton).GetChild("NumSelected").visible = true;
			((GComponent)asButton).GetChild("NumSelected1").visible = false;
		}
		else
		{
			((GComponent)asButton).GetChild("SelectNote").visible = false;
			((GComponent)asButton).GetChild("NumSelected").visible = false;
			((GComponent)asButton).GetChild("NumSelected1").visible = true;
		}
		((GComponent)asButton).GetChild("LegendItems").visible = false;
		if (LegendItemsHelper.SoldiersEquippedItems != null && LegendItemsHelper.SoldiersEquippedItems.ContainsKey(soldier.Id))
		{
			for (int i = 0; i < 2; i++)
			{
				((GComponent)asButton).GetChild($"legendItem{i}").visible = false;
			}
			int num2 = 0;
			for (int j = 0; j < LegendItemsHelper.SoldiersEquippedItems[soldier.Id].Length; j++)
			{
				if (num2 >= 2)
				{
					break;
				}
				GButton asButton2 = ((GComponent)asButton).GetChild($"legendItem{num2}").asButton;
				if (!LegendItemsHelper.GetSoldierItemSlotState(soldier.Id, j))
				{
					((GObject)asButton2).visible = false;
					continue;
				}
				long num3 = LegendItemsHelper.SoldiersEquippedItems[soldier.Id][j];
				((GObject)asButton2).visible = true;
				if (num3 == 0)
				{
					((GObject)asButton2).visible = false;
					continue;
				}
				UiHelper.RenderLegendItem(asButton2, LegendItemsHelper.GetLegendItemUi(num3), UiHelper.TextColorType.Light, textureList, 2);
				num2++;
			}
			switch (num2)
			{
			case 1:
				((GComponent)asButton).GetController("LegendItemNum").selectedIndex = 0;
				((GComponent)asButton).GetChild("n56").visible = false;
				break;
			case 2:
				((GComponent)asButton).GetController("LegendItemNum").selectedIndex = 1;
				((GComponent)asButton).GetChild("n56").visible = true;
				break;
			}
			bool flag = false;
			for (int k = 0; k < 2; k++)
			{
				GButton asButton3 = ((GComponent)asButton).GetChild($"legendItem{k}").asButton;
				if (((GObject)asButton3).visible)
				{
					break;
				}
				if (k == 1)
				{
					flag = true;
				}
			}
			((GComponent)asButton).GetChild("LegendItems").visible = !flag;
		}
		Real_UpdateSoldierNum(asButton, soldier.Id);
		((GObject)asButton).onClick.Set(new EventCallback1(UpdateLegendSoldiers));
	}

	public void RenderArmsList()
	{
		//IL_0075: Unknown result type (might be due to invalid IL or missing references)
		//IL_007f: Expected O, but got Unknown
		if (_chosenType == 5 || _chosenType == 9 || _chosenType == 10)
		{
			return;
		}
		ArmsList.armsList_a.numItems = 0;
		FGUIManager.Instance.ClearCache_SoliderSoulStone();
		if (chosenMode)
		{
			GObject val = ArmsList.armsList_a.AddItemFromPool("ui://lrhs6zw7ndu545b");
			val.onClick.Add((EventCallback1)delegate(EventContext context)
			{
				if (chosenMode)
				{
					if (!_fromGvG3ModeShipDetail)
					{
						SharedMessenger.Broadcast<EventContext, string, int>("ON_SOLDIER_SELECTED", context, "Unlock", _chosenType);
					}
					End();
				}
			});
		}
		UiTagManager instance = UiTagManager.Instance;
		instance.Unregister("LegionPanel.FirstSoldier");
		instance.Unregister("LegionPanel.GoblinSoldier");
		instance.Unregister("LegionPanel.GoblinScout");
		instance.Unregister("LegionPanel.GoblinProphet");
		instance.Unregister("LegionPanel.GoblinKnight");
		instance.Unregister("LegionPanel.GhostWarrior");
		instance.Unregister("LegionPanel.Soldier");
		if (_Coroutine_RenderArmList != null)
		{
			FGUIManager.Instance.CloseIEnumerator(_Coroutine_RenderArmList);
		}
		_Coroutine_RenderArmList = FGUIManager.Instance.OpenIEnumerator(Real_RenderArmsList());
	}

	private IEnumerator Real_RenderArmsList()
	{
		float armsListAHeight = (float)Mathf.CeilToInt((float)(chosenMode ? (soldierRenderListA.Count + 1) : soldierRenderListA.Count) / 5f) * 249f;
		float armsListBHeight = (float)Mathf.CeilToInt((float)soldierRenderListB.Count / 5f) * 249f;
		float armsListCHeight = (float)Mathf.CeilToInt((float)soldierRenderListC.Count / 5f) * 249f;
		((GComponent)ArmsList.armsList_a).viewHeight = armsListAHeight;
		((GComponent)ArmsList.armsList_a).EnsureBoundsCorrect();
		((GComponent)ArmsList.armsList_b).viewHeight = armsListBHeight;
		((GComponent)ArmsList.armsList_b).EnsureBoundsCorrect();
		((GComponent)ArmsList.armsList_c).viewHeight = armsListCHeight;
		((GComponent)ArmsList.armsList_c).EnsureBoundsCorrect();
		((GObject)ArmsList.separatedLine).visible = soldierRenderListB.Count > 0;
		((GObject)ArmsList.separatedLine1).visible = soldierRenderListC.Count > 0;
		ArmsList.armsList_b.numItems = 0;
		ArmsList.armsList_c.numItems = 0;
		allRuneGComponents?.Clear();
		yield return null;
		for (int i = 0; i < soldierRenderListA.Count; i++)
		{
			if (soldierRenderListA[i] != null)
			{
				if (((GObject)this).isDisposed)
				{
					yield break;
				}
				GObject item = ArmsList.armsList_a.AddItemFromPool();
				item.touchable = false;
				item.alpha = 0f;
				Soldier soldier = soldierRenderListA[i];
				if (SoldierIsLock(soldier.Id))
				{
					RenderUnlockArmsListItem(i, item, soldier);
				}
				else
				{
					RenderArmsListItem(i, item, soldier);
				}
				item.TweenFade(1f, 0.1f).OnComplete((GTweenCallback)delegate
				{
					item.touchable = true;
				});
				yield return null;
			}
		}
		ArmsList.armsList_a.ResizeToFit(chosenMode ? (soldierRenderListA.Count + 1) : soldierRenderListA.Count);
		RegisterTag();
		for (int i2 = 0; i2 < soldierRenderListB.Count; i2++)
		{
			if (((GObject)this).isDisposed)
			{
				yield break;
			}
			GObject item2 = ArmsList.armsList_b.AddItemFromPool();
			item2.touchable = false;
			item2.alpha = 0f;
			Soldier soldier2 = soldierRenderListB[i2];
			if (SoldierIsLock(soldier2.Id))
			{
				RenderUnlockArmsListItem(i2, item2, soldier2);
			}
			else
			{
				RenderArmsListItem(i2, item2, soldier2);
			}
			item2.TweenFade(1f, 0.1f).OnComplete((GTweenCallback)delegate
			{
				item2.touchable = true;
			});
			yield return null;
		}
		ArmsList.armsList_b.ResizeToFit(soldierRenderListB.Count);
		for (int i3 = 0; i3 < soldierRenderListC.Count; i3++)
		{
			if (((GObject)this).isDisposed)
			{
				yield break;
			}
			GObject item3 = ArmsList.armsList_c.AddItemFromPool();
			item3.touchable = false;
			item3.alpha = 0f;
			RenderUnlockArmsListItem(i3, item3, soldierRenderListC[i3]);
			item3.TweenFade(1f, 0.1f).OnComplete((GTweenCallback)delegate
			{
				item3.touchable = true;
			});
			yield return null;
		}
		ArmsList.armsList_c.ResizeToFit(soldierRenderListC.Count);
		((GComponent)ArmsList.armsList_a).EnsureBoundsCorrect();
		((GComponent)ArmsList.armsList_b).EnsureBoundsCorrect();
		((GComponent)ArmsList.armsList_c).EnsureBoundsCorrect();
	}

	private void RegisterTag()
	{
		Dictionary<string, object> dictionary = new Dictionary<string, object>();
		for (int i = (chosenMode ? 1 : 0); i < ArmsList.armsList_a.numItems; i++)
		{
			if (((GObject)((GComponent)ArmsList.armsList_a).GetChildAt(i).asButton).data is Soldier soldier && !dictionary.ContainsKey(soldier.Id))
			{
				dictionary.Add(soldier.Id, ((GComponent)ArmsList.armsList_a).GetChildAt(i));
			}
		}
		UiTagManager instance = UiTagManager.Instance;
		instance.Register("LegionPanel.Soldier", dictionary);
		if (dictionary.Count > 0)
		{
			instance.Register("LegionPanel.FirstSoldier", dictionary.Values.First());
			if (dictionary.TryGetValue("S001", out var value))
			{
				instance.Register("LegionPanel.GoblinSoldier", value);
			}
			if (dictionary.TryGetValue("S003", out var value2))
			{
				instance.Register("LegionPanel.GoblinScout", value2);
			}
			if (dictionary.TryGetValue("S004", out var value3))
			{
				instance.Register("LegionPanel.GoblinProphet", value3);
			}
			if (dictionary.TryGetValue("S009", out var value4))
			{
				instance.Register("LegionPanel.GoblinKnight", value4);
			}
			if (dictionary.TryGetValue("S005", out var value5))
			{
				instance.Register("LegionPanel.GhostWarrior", value5);
			}
		}
	}

	private void RenderIntroductionPanel(Soldier soldier)
	{
		//IL_0066: Unknown result type (might be due to invalid IL or missing references)
		//IL_006b: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00df: Expected O, but got Unknown
		//IL_00f7: Unknown result type (might be due to invalid IL or missing references)
		//IL_0101: Expected O, but got Unknown
		//IL_0119: Unknown result type (might be due to invalid IL or missing references)
		//IL_0123: Expected O, but got Unknown
		//IL_0274: Unknown result type (might be due to invalid IL or missing references)
		//IL_02b3: Unknown result type (might be due to invalid IL or missing references)
		//IL_01fd: Unknown result type (might be due to invalid IL or missing references)
		//IL_020e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0218: Unknown result type (might be due to invalid IL or missing references)
		//IL_0222: Expected O, but got Unknown
		//IL_0584: Unknown result type (might be due to invalid IL or missing references)
		//IL_05fd: Unknown result type (might be due to invalid IL or missing references)
		//IL_0607: Expected O, but got Unknown
		UiAudioManager.Instance.PlaySoldierVoice(soldier.Id, UiAudioManager.SoldierVoiceType.Onomatopoeia);
		((GObject)IntroductionPanel).visible = true;
		((GObject)IntroductionPanel.introduction).visible = false;
		((GTextField)IntroductionPanel.activate.title).strokeColor = Color32.op_Implicit(new Color32((byte)60, (byte)72, (byte)13, (byte)229));
		((GObject)IntroductionPanel.chipsTitle).visible = false;
		((GObject)IntroductionPanel.currentChipNum).visible = false;
		((GObject)IntroductionPanel.upLimit).visible = false;
		((GObject)IntroductionPanel.activate).visible = false;
		((GObject)IntroductionPanel.SoldierAnimation).onClick.Set((EventCallback0)delegate
		{
			UiAudioManager.Instance.PlaySoldierVoice(soldier.Id, UiAudioManager.SoldierVoiceType.Onomatopoeia);
		});
		((GObject)IntroductionPanel.attackPropertyBtn).onClick.Set((EventCallback0)delegate
		{
			OpenAttackAndDefense((GObject)(object)IntroductionPanel.attackPropertyBtn, type: true, soldier.DamageType);
		});
		((GObject)IntroductionPanel.defensePropertyBtn).onClick.Set((EventCallback0)delegate
		{
			OpenAttackAndDefense((GObject)(object)IntroductionPanel.defensePropertyBtn, type: false, soldier.ArmorType);
		});
		Object obj = Object.Instantiate(Resources.Load("SpineTest", typeof(GameObject)));
		GameObject val = (GameObject)(object)((obj is GameObject) ? obj : null);
		if ((Object)(object)val != (Object)null)
		{
			SkeletonAnimation animation = val.GetComponent<SkeletonAnimation>();
			int potentialLevel = (soldier.PotentialLevel + 2) / 2;
			SpawnManager.Instance.LoadSoldierSpine(val, $"{soldier.Id}_skin{potentialLevel}", isMask: true).Then((Action<SkeletonDataAsset>)delegate(SkeletonDataAsset asset)
			{
				if ((Object)(object)asset != (Object)null && (Object)(object)animation != (Object)null && !((GObject)this).isDisposed)
				{
					((SkeletonRenderer)animation).skeletonDataAsset = asset;
					((SkeletonRenderer)animation).initialSkinName = $"skin{potentialLevel}";
					((SkeletonRenderer)animation).Initialize(true);
					string text = "idle";
					if (soldier.Id == "S043" || soldier.Id == "S044")
					{
						text = "idle_ui";
					}
					animation.AnimationState.AddAnimation(0, text, true, 0f);
					animation.timeScale = 0.2f;
				}
			});
			Vector3 localScale = default(Vector3);
			((Vector3)(ref localScale))._002Ector(50f, 50f, 50f);
			val.transform.localEulerAngles = new Vector3(0f, 180f, 0f);
			val.transform.localScale = localScale;
			gw1 = new GoWrapper(val);
			gw1.supportStencil = true;
		}
		IntroductionPanel.SoldierAnimation.icon.SetNativeObject((DisplayObject)(object)gw1);
		FGUIManager.Instance.AddTextSpecialEffects(IntroductionPanel.SoldierAnimation.baseSpine, "MagicCircleBase", new Vector3(100f, 100f, 100f));
		FGUIManager.Instance.AddTextSpecialEffects(IntroductionPanel.SoldierAnimation.maskSpine, "MagicCircleMask", new Vector3(100f, 100f, 100f));
		((GObject)IntroductionPanel.title).text = soldier.Name;
		((GObject)IntroductionPanel.introduction).text = Regex.Match(soldier.Desc, "(?<=Desc:)([^:\\.])*(?=\\#)*").Value;
		int levelAdded = ((soldier.Level <= 0) ? 1 : 0);
		int soldierFormationNumber = Singleton<SoldierFormationManager>.Instance.GetSoldierFormationNumber(soldier.Id, soldier.Level, levelAdded);
		((GObject)IntroductionPanel.upperLimit).text = soldierFormationNumber.ToString() ?? "";
		((GObject)IntroductionPanel.fighting).text = (soldier.CombatPower * soldierFormationNumber).ToString();
		((GObject)IntroductionPanel.attack).text = $"{Convert.ToInt32(soldier.Attack)}";
		((GObject)IntroductionPanel.defense).text = $"{Convert.ToInt32(soldier.Defense)}";
		((GObject)IntroductionPanel.health).text = $"{Convert.ToInt32(soldier.Health)}";
		IntroductionPanel.attackLoader.url = $"ui://PublicResources/icon_atk_{soldier.DamageType}";
		IntroductionPanel.defenseLoader.url = $"ui://PublicResources/icon_def_{soldier.ArmorType}";
		IntroductionPanel.healthLoader.url = "ui://PublicResources/icon_hp";
		((GObject)IntroductionPanel.attackTiele).text = attackTypeNames[soldier.DamageType - 1] + "：";
		((GObject)IntroductionPanel.defenseTiele).text = armorTypeNames[soldier.ArmorType - 1] + "：";
		((GObject)IntroductionPanel.healthTiele).text = LanguagesManager.GetDesc("CsharpCodeZhTcText204") + "：";
		SkillListRenderer(soldier);
		((GObject)IntroductionPanel.CombatPowerSfxBack).displayObject.Dispose();
		FGUIManager.Instance.AddTextSpecialEffects(IntroductionPanel.CombatPowerSfxBack, "combat_power", new Vector3(((GObject)IntroductionPanel.CombatPowerSfxBack).width / 4f, ((GObject)IntroductionPanel.CombatPowerSfxBack).height * 6f, ((GObject)IntroductionPanel.CombatPowerSfxBack).height));
		RenderLockSoldierStoneList(soldier.Id, IntroductionPanel.UnlockStoneNum);
		((GComponent)IntroductionPanel.racePicture).GetController("Type").selectedIndex = FGUIManager.Instance.GetRaceIcon(soldier.Faction);
		((GObject)IntroductionPanel.racePicture).onClick.Set((EventCallback0)delegate
		{
			FGUIManager.Instance.ShowRaceInfo(soldier.Faction, 2, ((GObject)this).sortingOrder);
		});
		IntroductionPanel.showSelf.Play();
	}

	private void InitWorkerSpine()
	{
		((GObject)workUI).visible = false;
	}

	private void End()
	{
		if (_Coroutine_RenderArmList != null)
		{
			FGUIManager.Instance.CloseIEnumerator(_Coroutine_RenderArmList);
		}
		if (_Coroutine_RenderLegendSoldiers != null)
		{
			FGUIManager.Instance.CloseIEnumerator(_Coroutine_RenderLegendSoldiers);
		}
		FGUIManager.Instance.ClearCache_SoliderSoulStone();
		GameController.Contexts.Service<IUiService>().ClosePanel(Name);
		for (int i = 0; i < textureList.Count; i++)
		{
			AssetsManager.Instance.UnloadAsset<Texture2D>(textureList[i]);
		}
		for (int j = 0; j < shaderList.Count; j++)
		{
			AssetsManager.Instance.UnloadAsset<Shader>(shaderList[j]);
		}
	}

	private int UnlockSoldiersReorder(string _sid)
	{
		Soldier soldier = GameManagers.Instance.SoldierManager.Get(_sid);
		int num = -1;
		List<Soldier> list = ListExtensions.DeepCopy<Soldier>(SoldierList);
		for (int i = 0; i < list.Count; i++)
		{
			if (list[i].Id == soldier.Id)
			{
				num = i;
				list.RemoveAt(i);
				break;
			}
		}
		list.Insert(num, soldier);
		List<Soldier> list2 = new List<Soldier>();
		List<Soldier> list3 = new List<Soldier>();
		for (int j = 0; j < list.Count; j++)
		{
			if (formationUnits.ContainsValue(list[j].Id))
			{
				list2.Add(list[j]);
			}
			else
			{
				list3.Add(list[j]);
			}
		}
		list2.Sort(SortUnlockSoldiersByCombatPower);
		list3.Sort(SortUnlockSoldiersByCombatPower);
		SoldierList.Clear();
		SoldierList.AddRange(list2);
		SoldierList.AddRange(list3);
		return num;
	}

	private static int SortUnlockSoldiersByCombatPower(Soldier a, Soldier b)
	{
		int num = a.CombatPower * Singleton<SoldierFormationManager>.Instance.GetSoldierFormationNumber(a.Id, a.Level);
		int num2 = b.CombatPower * Singleton<SoldierFormationManager>.Instance.GetSoldierFormationNumber(b.Id, b.Level);
		if (a.PotentialLevel > b.PotentialLevel)
		{
			return -1;
		}
		if (a.PotentialLevel < b.PotentialLevel)
		{
			return 1;
		}
		if (num > num2)
		{
			return -1;
		}
		if (num < num2)
		{
			return 1;
		}
		return 0;
	}

	private void GetChipsData()
	{
		ChipsList.Clear();
		List<string> unlockedSoldiers = GameManagers.Instance.UserArchiveManager.GetUnlockedSoldiers();
		IOrderedEnumerable<Pieces> source = from sp in ConfigDataManager.GetPiecesDataByType(PiecesType.SoldierPieces)
			where Item.ItemType(sp.ItemId) == 3
			orderby !unlockedSoldiers.Contains(sp.RelativeContext)
			select sp;
		source = source.ThenByDescending((Pieces sp) => GameManagers.Instance.StockController.GetStock(sp.ItemId));
		IEnumerable<Pieces> collection = source.Where((Pieces sp2) => GameManagers.Instance.StockController.GetStock(sp2.ItemId) > 0);
		ChipsList.AddRange(collection);
	}

	public void SkillDetailPopup(EventContext context)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000d: Expected O, but got Unknown
		//IL_0024: Unknown result type (might be due to invalid IL or missing references)
		//IL_0029: Unknown result type (might be due to invalid IL or missing references)
		//IL_002e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Unknown result type (might be due to invalid IL or missing references)
		//IL_0031: Unknown result type (might be due to invalid IL or missing references)
		//IL_0036: Unknown result type (might be due to invalid IL or missing references)
		//IL_0039: Unknown result type (might be due to invalid IL or missing references)
		//IL_0045: Unknown result type (might be due to invalid IL or missing references)
		//IL_0062: Unknown result type (might be due to invalid IL or missing references)
		GButton val = (GButton)context.sender;
		Tuple<GDEAbilityData, int, bool, bool> tuple = (Tuple<GDEAbilityData, int, bool, bool>)((GObject)val).data;
		Vector2 val2 = ((GObject)IntroductionPanel.skillList).LocalToGlobal(Vector2.zero);
		val2 = ((GObject)this).GlobalToLocal(val2);
		((Vector2)(ref val2))._002Ector(val2.x + 200f, val2.y + 20f);
		Dictionary<string, object> dictionary = new Dictionary<string, object>();
		dictionary.Add("Pos", val2);
		dictionary.Add("Data", tuple.Item1);
		dictionary.Add("Limit", tuple.Item2);
		dictionary.Add("State", tuple.Item3);
		dictionary.Add("GList", IntroductionPanel.skillList);
		dictionary.Add("IsShow", tuple.Item4);
		GameController.Contexts.Service<IUiService>().OpenPanel(UI_SkillDetailPopup.Name, dictionary);
	}

	private void OnClickEffectLink(EventContext e)
	{
		GameController.Contexts.Service<IUiService>().OpenPanel(UI_SkillEffectPanel.Name, new Dictionary<string, object> { 
		{
			"EffectKey",
			e.data.ToString()
		} });
	}

	public void UpdateSoldiersNum(string itemId, int incr, (StockInContext, string) context)
	{
		if (!isLegendItemDungeon)
		{
			if (string.IsNullOrEmpty(itemId))
			{
				UpdateUnlockSoldierNum();
			}
			else if (SchemaIndexHelper.GetSchemaById(itemId) == "Soldier")
			{
				UpdateUnlockSoldierNum(itemId);
			}
		}
	}

	private void Real_UpdateSoldierNum(GButton button, string soldierId)
	{
		//IL_00b1: Unknown result type (might be due to invalid IL or missing references)
		//IL_009c: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00dd: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fd: Unknown result type (might be due to invalid IL or missing references)
		//IL_0176: Unknown result type (might be due to invalid IL or missing references)
		//IL_0161: Unknown result type (might be due to invalid IL or missing references)
		//IL_017b: Unknown result type (might be due to invalid IL or missing references)
		//IL_01bd: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a2: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c2: Unknown result type (might be due to invalid IL or missing references)
		if (!chosenMode || (_chosenType != 9 && _chosenType != 10))
		{
			GameManagers instance = GameManagers.Instance;
			int soldierNum = GetSoldierNum(soldierId);
			int soldierLevel = instance.UserArchiveManager.GetSoldierLevel(soldierId);
			int soldierFormationNumber = Singleton<SoldierFormationManager>.Instance.GetSoldierFormationNumber(soldierId, soldierLevel);
			((GObject)((GComponent)button).GetChild("num").asRichTextField).text = soldierNum.ToString();
			((GTextField)((GComponent)button).GetChild("num").asRichTextField).color = Color32.op_Implicit((soldierNum < soldierFormationNumber) ? new Color32(byte.MaxValue, (byte)33, (byte)33, byte.MaxValue) : new Color32(byte.MaxValue, (byte)242, (byte)211, byte.MaxValue));
			((GTextField)((GComponent)button).GetChild("num").asRichTextField).strokeColor = Color32.op_Implicit((soldierNum < soldierFormationNumber) ? new Color32(byte.MaxValue, (byte)242, (byte)211, byte.MaxValue) : new Color32((byte)0, (byte)0, (byte)0, byte.MaxValue));
			((GObject)((GComponent)button).GetChild("num2").asRichTextField).text = $"{soldierNum}/{LegendItemDungeonUiHelper.GetSoldierLimitNum(soldierId)}";
			((GTextField)((GComponent)button).GetChild("num2").asRichTextField).color = Color32.op_Implicit((soldierNum < soldierFormationNumber) ? new Color32(byte.MaxValue, (byte)33, (byte)33, byte.MaxValue) : new Color32(byte.MaxValue, (byte)242, (byte)211, byte.MaxValue));
			((GTextField)((GComponent)button).GetChild("num2").asRichTextField).strokeColor = Color32.op_Implicit((soldierNum < soldierFormationNumber) ? new Color32(byte.MaxValue, (byte)242, (byte)211, byte.MaxValue) : new Color32((byte)0, (byte)0, (byte)0, byte.MaxValue));
			int stock = instance.StockController.GetStock(soldierId);
			int limit = instance.StockController.GetLimit(soldierId);
			((GComponent)button).GetChild("max").visible = stock >= limit;
		}
	}

	private void Real_UpdateIsComeAgainSoldierNum(GButton button, string soldierId)
	{
		//IL_0080: Unknown result type (might be due to invalid IL or missing references)
		//IL_0085: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ed: Unknown result type (might be due to invalid IL or missing references)
		if (IsGvGMode3 || IsIslandComeAgain)
		{
			GameManagers instance = GameManagers.Instance;
			int soldierNum = GetSoldierNum(soldierId);
			int soldierLevel = instance.UserArchiveManager.GetSoldierLevel(soldierId);
			int num = Singleton<SoldierFormationManager>.Instance.GetSoldierFormationNumber(soldierId, soldierLevel) * 5;
			((GObject)((GComponent)button).GetChild("num").asRichTextField).text = soldierNum.ToString();
			((GTextField)((GComponent)button).GetChild("num").asRichTextField).strokeColor = Color32.op_Implicit(new Color32((byte)0, (byte)0, (byte)0, byte.MaxValue));
			string arg = ((soldierNum < num) ? "#FF2121" : "#FFF2D3");
			((GObject)((GComponent)button).GetChild("num2").asRichTextField).text = $"[color={arg}]{soldierNum}[/color]/{num}";
			((GTextField)((GComponent)button).GetChild("num2").asRichTextField).strokeColor = Color32.op_Implicit(new Color32((byte)0, (byte)0, (byte)0, byte.MaxValue));
			int stock = instance.StockController.GetStock(soldierId);
			int limit = instance.StockController.GetLimit(soldierId);
			((GComponent)button).GetChild("max").visible = stock >= limit;
		}
	}

	private int GetSoldierNum(string soldierId)
	{
		if (_chosenType == 4)
		{
			BattleConfigComponent battleConfig = GameController.Contexts.config.battleConfig;
			Dictionary<string, int> unitsPool = battleConfig.Red.UnitsPool;
			Dictionary<string, int> unitsBorn = battleConfig.Red.UnitsBorn;
			if (unitsPool != null && unitsBorn != null)
			{
				int num = 0;
				int num2 = 0;
				foreach (KeyValuePair<string, int> item in unitsPool)
				{
					if (item.Key == soldierId)
					{
						num = item.Value;
						break;
					}
				}
				foreach (KeyValuePair<string, int> item2 in unitsBorn)
				{
					if (item2.Key == soldierId)
					{
						num2 = item2.Value;
						break;
					}
				}
				return num - num2;
			}
			return GameManagers.Instance.StockController.GetStock(soldierId);
		}
		return GameManagers.Instance.StockController.GetStock(soldierId);
	}

	private void OpenAttackAndDefense(GObject button, bool type, int index)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		//IL_000e: Unknown result type (might be due to invalid IL or missing references)
		//IL_000f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0014: Unknown result type (might be due to invalid IL or missing references)
		//IL_0021: Unknown result type (might be due to invalid IL or missing references)
		Vector2 val = button.LocalToGlobal(Vector2.zero);
		val = ((GObject)this).GlobalToLocal(val);
		Dictionary<string, object> dictionary = new Dictionary<string, object>();
		dictionary.Add("Pos", val);
		dictionary.Add("Type", type);
		dictionary.Add("Index", index);
		GameController.Contexts.Service<IUiService>().OpenPanel(UI_SpearAndShield.Name, dictionary);
	}

	private int CurrentRaceCount()
	{
		int num = 0;
		foreach (string item in _selectedWithTick)
		{
			if (!string.IsNullOrEmpty(item))
			{
				eRace eRace = RaceHelper.FactionToRaceEnum(GameManagers.Instance.SoldierManager.Get(item).Faction);
				if (_raceTypeGvGMode3 == (int)eRace)
				{
					num++;
				}
			}
		}
		return num;
	}

	private void RenderGvGMode3LegionList()
	{
		if (IsGvGMode3)
		{
			FGUIManager.Instance.ClearCache_SoliderSoulStone();
			controller.selectedIndex = 5;
			_Coroutine_RenderArmList = FGUIManager.Instance.OpenIEnumerator(Real_RenderSelectedWithTick());
			SpecificRace.selectedIndex = ((_raceTypeGvGMode3 >= 0 && _raceTypeGvGMode3 <= 5) ? 1 : 0);
			if (SpecificRace.selectedIndex == 1)
			{
				RenderHelper_RaceTypeIcon.RenderShipRaceType((GComponent)(object)Race, (eRace)_raceTypeGvGMode3);
			}
			UpdateRaceInfo();
		}
	}

	private void UpdateRaceInfo()
	{
		string arg = ((_selectedWithTick.Count >= _selectedWithTickMaxCount) ? "#FFFFFF" : "#ff1a1a");
		((GObject)LegionNumber).text = $"[color={arg}]{_selectedWithTick.Count}[/color]/{_selectedWithTickMaxCount}";
		if (SpecificRace.selectedIndex == 1)
		{
			int num = CurrentRaceCount() + _selectedRaceLegionCnt;
			string arg2 = ((num >= _raceMinCount) ? "#FFFFFF" : "#ff1a1a");
			((GObject)RaceNumber).text = $"[color={arg2}]{num}[/color]/{_raceMinCount}";
		}
	}

	private IEnumerator Real_RenderSelectedWithTick()
	{
		float armsListAHeight = (float)Mathf.CeilToInt((float)(chosenMode ? (soldierRenderListA.Count + 1) : soldierRenderListA.Count) / 5f) * 249f;
		float armsListBHeight = (float)Mathf.CeilToInt((float)soldierRenderListB.Count / 5f) * 249f;
		((GComponent)ArmsList.armsList_a).viewHeight = armsListAHeight;
		((GComponent)ArmsList.armsList_a).EnsureBoundsCorrect();
		((GComponent)ArmsList.armsList_b).viewHeight = armsListBHeight;
		((GComponent)ArmsList.armsList_b).EnsureBoundsCorrect();
		((GObject)ArmsList.separatedLine).visible = soldierRenderListB.Count > 0;
		((GObject)ArmsList.separatedLine1).visible = soldierRenderListC.Count > 0;
		ArmsList.armsList_a.numItems = 0;
		ArmsList.armsList_b.numItems = 0;
		allRuneGComponents?.Clear();
		yield return null;
		for (int i = 0; i < soldierRenderListA.Count; i++)
		{
			GObject item = ArmsList.armsList_a.AddItemFromPool();
			item.touchable = false;
			item.alpha = 0f;
			RenderSelectedWithTick_SoldierItem(i, item, soldierRenderListA[i]);
			item.TweenFade(1f, 0.1f).OnComplete((GTweenCallback)delegate
			{
				item.touchable = true;
			});
			yield return null;
		}
		ArmsList.armsList_a.ResizeToFit(soldierRenderListA.Count);
		for (int i2 = 0; i2 < soldierRenderListB.Count; i2++)
		{
			GObject item2 = ArmsList.armsList_b.AddItemFromPool();
			item2.touchable = false;
			item2.alpha = 0f;
			RenderSelectedWithTick_SoldierItem(i2, item2, soldierRenderListB[i2]);
			item2.TweenFade(1f, 0.1f).OnComplete((GTweenCallback)delegate
			{
				item2.touchable = true;
			});
			yield return null;
		}
		ArmsList.armsList_b.ResizeToFit(soldierRenderListB.Count);
		((GObject)ArmsList.separatedLine).visible = soldierRenderListB.Count > 0;
		ArmsList.armsList_c.ResizeToFit(soldierRenderListC.Count);
		((GObject)ArmsList.separatedLine1).visible = false;
		((GComponent)ArmsList.armsList_a).EnsureBoundsCorrect();
		((GComponent)ArmsList.armsList_b).EnsureBoundsCorrect();
	}

	private void RenderSelectedWithTick_SoldierItem(int index, GObject obj, Soldier soldier)
	{
		//IL_0256: Unknown result type (might be due to invalid IL or missing references)
		//IL_0246: Unknown result type (might be due to invalid IL or missing references)
		//IL_025b: Unknown result type (might be due to invalid IL or missing references)
		//IL_05a0: Unknown result type (might be due to invalid IL or missing references)
		//IL_05aa: Expected O, but got Unknown
		GButton asButton = obj.asButton;
		((GComponent)asButton).GetChild("assemblyNote").visible = false;
		((GComponent)asButton).GetChild("occupation").visible = false;
		((GComponent)asButton).GetChild("title").text = "";
		((GComponent)asButton).GetChild("removeBack").visible = false;
		((GComponent)asButton).GetChild("removeNote").visible = false;
		((GComponent)asButton).GetChild("removeText").visible = false;
		((GComponent)asButton).GetChild("SoulStoneLevel").visible = true;
		((GComponent)asButton).GetChild("racePicture").visible = false;
		((GComponent)asButton).GetChild("lv").text = soldier.Level.ToString();
		int num = ((soldier.PotentialLevel < 9) ? ((soldier.PotentialLevel + 2) / 2) : 6);
		((GComponent)asButton).GetChild("lvFrame").asLoader.url = UiHelper.GetLevelFrameBorderSoldier(soldier.PotentialLevel);
		((GComponent)asButton).GetChild("icon").asLoader.url = "ui://PublicResources/" + UiHelper.GetIconPath(soldier.Id);
		string iconFrameBorderSoldier = UiHelper.GetIconFrameBorderSoldier(soldier.PotentialLevel);
		((GComponent)asButton).GetChild("iconFrame").asLoader.url = "ui://PublicResources/" + iconFrameBorderSoldier;
		GComponent rune = FGUIManager.Instance.SetAlightSoulStoneForSoldierIcon(((GComponent)asButton).GetChild("SoulStoneLevel").asCom, soldier.PotentialLevel, soldier.PotentialProgress, isActivating: false, needMask: false);
		AllRuneGComponentsAdd(rune);
		RuneGComponentSetVisible(rune);
		((GObject)((GComponent)asButton).GetChild("racePicture").asButton).visible = true;
		((GComponent)((GComponent)asButton).GetChild("racePicture").asButton).GetController("Type").selectedIndex = FGUIManager.Instance.GetRaceIcon(soldier.Faction);
		string text = "title";
		if (num >= 5)
		{
			text = "title_Max";
			((GComponent)asButton).GetController("Level").selectedIndex = 1;
		}
		else
		{
			((GComponent)asButton).GetController("Level").selectedIndex = 0;
		}
		((GComponent)asButton).GetChild(text).text = soldier.Name;
		((GTextField)((GComponent)asButton).GetChild(text).asRichTextField).color = Color32.op_Implicit(chosenMode ? SoldierNameColor2[num - 1] : SoldierNameColor1[num - 1]);
		int stock = GameManagers.Instance.StockController.GetStock(soldier.Id);
		((GObject)((GComponent)asButton).GetChild("num").asRichTextField).text = $"{stock}";
		((GObject)asButton).data = soldier.Id;
		if (_selectedWithTick.Contains(soldier.Id))
		{
			((GComponent)asButton).GetChild("SelectNote").visible = true;
			((GComponent)asButton).GetChild("NumSelected").visible = true;
			((GComponent)asButton).GetChild("NumSelected1").visible = false;
		}
		else
		{
			((GComponent)asButton).GetChild("SelectNote").visible = false;
			((GComponent)asButton).GetChild("NumSelected").visible = false;
			((GComponent)asButton).GetChild("NumSelected1").visible = true;
		}
		((GComponent)asButton).GetChild("LegendItems").visible = false;
		long[] array = null;
		if (controller.selectedIndex == 5)
		{
			array = GameManagers.Instance.GetGvGSoldiersEquippedItemIds(soldier.Id);
		}
		else if (LegendItemsHelper.SoldiersEquippedItems != null && LegendItemsHelper.SoldiersEquippedItems.ContainsKey(soldier.Id))
		{
			array = LegendItemsHelper.SoldiersEquippedItems[soldier.Id];
		}
		if (array != null)
		{
			for (int i = 0; i < 2; i++)
			{
				((GComponent)asButton).GetChild($"legendItem{i}").visible = false;
			}
			int num2 = 0;
			for (int j = 0; j < array.Length; j++)
			{
				if (num2 >= 2)
				{
					break;
				}
				GButton asButton2 = ((GComponent)asButton).GetChild($"legendItem{num2}").asButton;
				if (!LegendItemsHelper.GetSoldierItemSlotState(soldier.Id, j))
				{
					((GObject)asButton2).visible = false;
					continue;
				}
				long num3 = array[j];
				((GObject)asButton2).visible = true;
				if (num3 == 0)
				{
					((GObject)asButton2).visible = false;
					continue;
				}
				UiHelper.RenderLegendItem(asButton2, LegendItemsHelper.GetLegendItemUi(num3), UiHelper.TextColorType.Light, textureList, 2);
				num2++;
			}
			switch (num2)
			{
			case 1:
				((GComponent)asButton).GetController("LegendItemNum").selectedIndex = 0;
				((GComponent)asButton).GetChild("n56").visible = false;
				break;
			case 2:
				((GComponent)asButton).GetController("LegendItemNum").selectedIndex = 1;
				((GComponent)asButton).GetChild("n56").visible = true;
				break;
			}
			bool flag = false;
			for (int k = 0; k < 2; k++)
			{
				GButton asButton3 = ((GComponent)asButton).GetChild($"legendItem{k}").asButton;
				if (((GObject)asButton3).visible)
				{
					break;
				}
				if (k == 1)
				{
					flag = true;
				}
			}
			((GComponent)asButton).GetChild("LegendItems").visible = !flag;
		}
		Real_UpdateIsComeAgainSoldierNum(asButton, soldier.Id);
		((GObject)asButton).onClick.Set(new EventCallback1(UpdateSelectedWithTick));
	}

	private void UpdateSelectedWithTick(EventContext context)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000d: Expected O, but got Unknown
		GButton val = (GButton)context.sender;
		string item = ((GObject)val).data.ToString();
		if (_selectedWithTick.Count >= _selectedWithTickMaxCount && !_selectedWithTick.Contains(item) && _selectedWithTick.Count >= _selectedWithTickMaxCount)
		{
			List<string> arg = new List<string> { string.Format("{0}{1}{2}", LanguagesManager.GetDesc("CsharpCodeZhTcText345"), _selectedWithTickMaxCount, LanguagesManager.GetDesc("CsharpCodeZhTcText346")) };
			SharedMessenger.Broadcast("SHOW_TIPS", arg, ((GObject)this).sortingOrder, arg3: false);
			return;
		}
		if (_selectedWithTick.Count >= _selectedWithTickMaxCount && _selectedWithTick.Contains(item))
		{
			((GComponent)val).GetChild("SelectNote").visible = false;
			((GComponent)val).GetChild("NumSelected").visible = false;
			((GComponent)val).GetChild("NumSelected1").visible = true;
			_selectedWithTick.Remove(item);
			UpdateRaceInfo();
			return;
		}
		bool flag = _selectedWithTick.Contains(item);
		if (flag)
		{
			_selectedWithTick.Remove(item);
		}
		else
		{
			_selectedWithTick.Add(item);
		}
		((GComponent)val).GetChild("SelectNote").visible = !flag;
		((GComponent)val).GetChild("NumSelected").visible = !flag;
		((GComponent)val).GetChild("NumSelected1").visible = flag;
		UpdateRaceInfo();
	}

	private void OnConfirmSelectedWithTick(EventContext context)
	{
		if (_selectedWithTickOnConfirm != null)
		{
			_selectedWithTickOnConfirm.Callback?.Invoke(new GvGMode3SoldierSelected
			{
				Selected = _selectedWithTick,
				IsGroup = _isCurGroup
			});
		}
		End();
	}
}
