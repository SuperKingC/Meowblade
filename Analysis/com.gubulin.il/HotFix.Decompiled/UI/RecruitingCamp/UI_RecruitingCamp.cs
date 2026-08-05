using System;
using System.Collections.Generic;
using Assets.Scripts.Managers;
using Assets.Scripts.UI;
using FairyGUI;
using FairyGUI.Utils;
using HotFix.Sources.Base.Scripts.Helper;
using Shift.Legion.ClientApi.Protocol.UserAction;
using Shift.Legion.Common.Helpers;
using Shift.Legion.Common.Managers;
using Shift.Legion.Common.Models;
using Shift.Legion.Common.Services;
using Shift.Legion.Common.Sources.Enums;
using Spine.Unity;
using UI.Legion;
using UI.MainCity;
using UI.PublicResources;
using UI.SoldierCultivate;
using UI.SoldierFormationInfo;
using UI.Tips;
using UI.UpGrade;
using UnityEngine;

namespace UI.RecruitingCamp;

public class UI_RecruitingCamp : GComponent, IUiController
{
	public Controller Status;

	public Controller Type;

	public GLoader background;

	public GImage n229;

	public GImage n230;

	public UI_dec_01 n207;

	public GImage n209;

	public UI_dec_02 n212;

	public GImage n211;

	public GImage n210;

	public GImage n213;

	public GImage n214;

	public GImage n218;

	public GImage n227;

	public GImage n222;

	public GTextField n219;

	public GTextField n220;

	public GImage n221;

	public GImage n228;

	public GGroup n217;

	public GImage n77;

	public GImage n2;

	public GButton DiamondBtn;

	public GTextField DiamondAmount_t;

	public GGroup diamondGroup;

	public GImage n78;

	public GButton SoldierAmountBtn;

	public GTextField WorkerAmount;

	public GImage n112;

	public GGroup workerGroup;

	public UI_OpenSoldierBtn OpenSoldierBtn;

	public UI_SoldierCultivateBtn SoldierCultivateBtn;

	public GGraph AnimaPlaceholder;

	public GComponent SoldierNamePotentialLevelBack;

	public GTextField SoldierUpperLimit_t;

	public GTextField n165;

	public GTextField Soldiername_t;

	public GTextField Soldiername_Max;

	public GTextField n16;

	public GTextField n186;

	public GTextField SoldierLevel_t;

	public GTextField SoldierLevel_Max;

	public GLoader ShoulderStrap;

	public GGroup n193;

	public GImage n223;

	public GGraph CombatPowerSfxBack;

	public GTextField n169;

	public GTextField Combatpower_t;

	public GImage CombatPowerIcon;

	public GGroup detialLeft;

	public GTextField ReadyTime_t;

	public GButton ExclamationMarkBtn1st;

	public GList WeaponList;

	public UI_SoldierInfoPanelClickBtn SoldierInfoPanelClickBtn;

	public GTextField n33;

	public GTextField SoldierAmount;

	public GButton ExclamationMarkBtn2nd;

	public GGraph IslandComeAgainCheckSoldierLimit;

	public GLoader goToBtn;

	public GGroup detialRight;

	public GList QueueList;

	public GTextField tip;

	public UI_com_NewRecruitInfo HighLevelPage;

	public UI_Title Title;

	public GButton UpgraedeBtn;

	public GGroup nameGroup;

	public GComponent addWorkerBtn;

	public UI_ComfirmBtn2 Confirm_New;

	public UI_ComfirmBtn ConfirmBtn;

	public GButton ExitBtn;

	public Transition t0;

	public const string URL = "ui://72fujxhkpipjp";

	public static string Name = "UI_RecruitingCamp";

	private readonly GTextField[] _amountNums = (GTextField[])(object)new GTextField[15];

	private readonly GImage[] _productImages = (GImage[])(object)new GImage[15];

	private readonly string[] _soldierIdsStrings = new string[15];

	private Dictionary<int, string> _recruitingData;

	private string _soldierId;

	private string _soldierIdTemp;

	private Dictionary<int, string> _tempRecruitingData;

	private GameObject canvasObject1;

	private GameObject canvasObject2;

	private GoWrapper gw1;

	private GComponent ListItem;

	private int listItemIndex;

	public Camp RecruitingCamp;

	private List<string> textureList = new List<string>();

	private List<string> spineSet = new List<string>();

	private Soldier soldier;

	private int selectedSlotIndex = 0;

	private readonly Color32[] SoldierNameColor = (Color32[])(object)new Color32[5]
	{
		new Color32((byte)155, (byte)197, (byte)42, byte.MaxValue),
		new Color32((byte)15, (byte)127, (byte)213, byte.MaxValue),
		new Color32((byte)223, (byte)139, byte.MaxValue, byte.MaxValue),
		new Color32((byte)246, (byte)130, (byte)5, byte.MaxValue),
		new Color32(byte.MaxValue, (byte)210, (byte)0, byte.MaxValue)
	};

	private RecruitingStockLimitIncrementTip _stockLimitIncrementTip = new RecruitingStockLimitIncrementTip();

	private const string SoldierStockLimitNextDungeonLevelTip = "SoldierStockLimitNextDungeonLevelTip";

	private const string SoldierStockLimitMaxTip = "SoldierStockLimitMaxTip";

	private bool IsHighLevel
	{
		get
		{
			Camp recruitingCamp = RecruitingCamp;
			return recruitingCamp != null && recruitingCamp.Level > 5;
		}
	}

	private bool SoldierNotHave => string.IsNullOrWhiteSpace(_soldierId) || _soldierId == "Unlock" || _soldierId == "Lock";

	public static string GetURL()
	{
		return "ui://72fujxhkpipjp";
	}

	public static UI_RecruitingCamp CreateInstance()
	{
		return (UI_RecruitingCamp)(object)UIPackage.CreateObject("RecruitingCamp", "RecruitingCamp");
	}

	public static UI_RecruitingCamp CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_RecruitingCamp).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://72fujxhkpipjp", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		//IL_008f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0099: Expected O, but got Unknown
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
		//IL_0129: Unknown result type (might be due to invalid IL or missing references)
		//IL_0133: Expected O, but got Unknown
		//IL_013f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0149: Expected O, but got Unknown
		//IL_0155: Unknown result type (might be due to invalid IL or missing references)
		//IL_015f: Expected O, but got Unknown
		//IL_01a8: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b2: Expected O, but got Unknown
		//IL_01fb: Unknown result type (might be due to invalid IL or missing references)
		//IL_0205: Expected O, but got Unknown
		//IL_0211: Unknown result type (might be due to invalid IL or missing references)
		//IL_021b: Expected O, but got Unknown
		//IL_0227: Unknown result type (might be due to invalid IL or missing references)
		//IL_0231: Expected O, but got Unknown
		//IL_023d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0247: Expected O, but got Unknown
		//IL_0253: Unknown result type (might be due to invalid IL or missing references)
		//IL_025d: Expected O, but got Unknown
		//IL_0269: Unknown result type (might be due to invalid IL or missing references)
		//IL_0273: Expected O, but got Unknown
		//IL_027f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0289: Expected O, but got Unknown
		//IL_02d2: Unknown result type (might be due to invalid IL or missing references)
		//IL_02dc: Expected O, but got Unknown
		//IL_02e8: Unknown result type (might be due to invalid IL or missing references)
		//IL_02f2: Expected O, but got Unknown
		//IL_02fe: Unknown result type (might be due to invalid IL or missing references)
		//IL_0308: Expected O, but got Unknown
		//IL_0314: Unknown result type (might be due to invalid IL or missing references)
		//IL_031e: Expected O, but got Unknown
		//IL_0367: Unknown result type (might be due to invalid IL or missing references)
		//IL_0371: Expected O, but got Unknown
		//IL_037d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0387: Expected O, but got Unknown
		//IL_03bf: Unknown result type (might be due to invalid IL or missing references)
		//IL_03c9: Expected O, but got Unknown
		//IL_03d5: Unknown result type (might be due to invalid IL or missing references)
		//IL_03df: Expected O, but got Unknown
		//IL_03eb: Unknown result type (might be due to invalid IL or missing references)
		//IL_03f5: Expected O, but got Unknown
		//IL_0401: Unknown result type (might be due to invalid IL or missing references)
		//IL_040b: Expected O, but got Unknown
		//IL_0456: Unknown result type (might be due to invalid IL or missing references)
		//IL_0460: Expected O, but got Unknown
		//IL_04ab: Unknown result type (might be due to invalid IL or missing references)
		//IL_04b5: Expected O, but got Unknown
		//IL_0500: Unknown result type (might be due to invalid IL or missing references)
		//IL_050a: Expected O, but got Unknown
		//IL_0555: Unknown result type (might be due to invalid IL or missing references)
		//IL_055f: Expected O, but got Unknown
		//IL_05aa: Unknown result type (might be due to invalid IL or missing references)
		//IL_05b4: Expected O, but got Unknown
		//IL_05ff: Unknown result type (might be due to invalid IL or missing references)
		//IL_0609: Expected O, but got Unknown
		//IL_0654: Unknown result type (might be due to invalid IL or missing references)
		//IL_065e: Expected O, but got Unknown
		//IL_066a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0674: Expected O, but got Unknown
		//IL_0680: Unknown result type (might be due to invalid IL or missing references)
		//IL_068a: Expected O, but got Unknown
		//IL_0696: Unknown result type (might be due to invalid IL or missing references)
		//IL_06a0: Expected O, but got Unknown
		//IL_06ac: Unknown result type (might be due to invalid IL or missing references)
		//IL_06b6: Expected O, but got Unknown
		//IL_0701: Unknown result type (might be due to invalid IL or missing references)
		//IL_070b: Expected O, but got Unknown
		//IL_0717: Unknown result type (might be due to invalid IL or missing references)
		//IL_0721: Expected O, but got Unknown
		//IL_072d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0737: Expected O, but got Unknown
		//IL_0743: Unknown result type (might be due to invalid IL or missing references)
		//IL_074d: Expected O, but got Unknown
		//IL_0798: Unknown result type (might be due to invalid IL or missing references)
		//IL_07a2: Expected O, but got Unknown
		//IL_07ae: Unknown result type (might be due to invalid IL or missing references)
		//IL_07b8: Expected O, but got Unknown
		//IL_07da: Unknown result type (might be due to invalid IL or missing references)
		//IL_07e4: Expected O, but got Unknown
		//IL_082f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0839: Expected O, but got Unknown
		//IL_0845: Unknown result type (might be due to invalid IL or missing references)
		//IL_084f: Expected O, but got Unknown
		//IL_085b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0865: Expected O, but got Unknown
		//IL_0871: Unknown result type (might be due to invalid IL or missing references)
		//IL_087b: Expected O, but got Unknown
		//IL_0887: Unknown result type (might be due to invalid IL or missing references)
		//IL_0891: Expected O, but got Unknown
		//IL_089d: Unknown result type (might be due to invalid IL or missing references)
		//IL_08a7: Expected O, but got Unknown
		//IL_08b3: Unknown result type (might be due to invalid IL or missing references)
		//IL_08bd: Expected O, but got Unknown
		//IL_0934: Unknown result type (might be due to invalid IL or missing references)
		//IL_093e: Expected O, but got Unknown
		//IL_094a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0954: Expected O, but got Unknown
		//IL_0960: Unknown result type (might be due to invalid IL or missing references)
		//IL_096a: Expected O, but got Unknown
		//IL_09a2: Unknown result type (might be due to invalid IL or missing references)
		//IL_09ac: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		Status = ((GComponent)this).GetController("Status");
		Type = ((GComponent)this).GetController("Type");
		background = (GLoader)((GComponent)this).GetChild("background");
		n229 = (GImage)((GComponent)this).GetChild("n229");
		n230 = (GImage)((GComponent)this).GetChild("n230");
		n207 = (UI_dec_01)(object)((GComponent)this).GetChild("n207");
		n209 = (GImage)((GComponent)this).GetChild("n209");
		n212 = (UI_dec_02)(object)((GComponent)this).GetChild("n212");
		n211 = (GImage)((GComponent)this).GetChild("n211");
		n210 = (GImage)((GComponent)this).GetChild("n210");
		n213 = (GImage)((GComponent)this).GetChild("n213");
		n214 = (GImage)((GComponent)this).GetChild("n214");
		n218 = (GImage)((GComponent)this).GetChild("n218");
		n227 = (GImage)((GComponent)this).GetChild("n227");
		n222 = (GImage)((GComponent)this).GetChild("n222");
		n219 = (GTextField)((GComponent)this).GetChild("n219");
		string id = "ui://72fujxhkpipjp".Replace("ui://", "") + "-" + ((GObject)n219).id;
		((GObject)n219).text = LanguagesManager.GetDesc(id);
		n220 = (GTextField)((GComponent)this).GetChild("n220");
		string id2 = "ui://72fujxhkpipjp".Replace("ui://", "") + "-" + ((GObject)n220).id;
		((GObject)n220).text = LanguagesManager.GetDesc(id2);
		n221 = (GImage)((GComponent)this).GetChild("n221");
		n228 = (GImage)((GComponent)this).GetChild("n228");
		n217 = (GGroup)((GComponent)this).GetChild("n217");
		n77 = (GImage)((GComponent)this).GetChild("n77");
		n2 = (GImage)((GComponent)this).GetChild("n2");
		DiamondBtn = (GButton)((GComponent)this).GetChild("DiamondBtn");
		DiamondAmount_t = (GTextField)((GComponent)this).GetChild("DiamondAmount_t");
		string id3 = "ui://72fujxhkpipjp".Replace("ui://", "") + "-" + ((GObject)DiamondAmount_t).id;
		((GObject)DiamondAmount_t).text = LanguagesManager.GetDesc(id3);
		diamondGroup = (GGroup)((GComponent)this).GetChild("diamondGroup");
		n78 = (GImage)((GComponent)this).GetChild("n78");
		SoldierAmountBtn = (GButton)((GComponent)this).GetChild("SoldierAmountBtn");
		WorkerAmount = (GTextField)((GComponent)this).GetChild("WorkerAmount");
		string id4 = "ui://72fujxhkpipjp".Replace("ui://", "") + "-" + ((GObject)WorkerAmount).id;
		((GObject)WorkerAmount).text = LanguagesManager.GetDesc(id4);
		n112 = (GImage)((GComponent)this).GetChild("n112");
		workerGroup = (GGroup)((GComponent)this).GetChild("workerGroup");
		OpenSoldierBtn = (UI_OpenSoldierBtn)(object)((GComponent)this).GetChild("OpenSoldierBtn");
		SoldierCultivateBtn = (UI_SoldierCultivateBtn)(object)((GComponent)this).GetChild("SoldierCultivateBtn");
		AnimaPlaceholder = (GGraph)((GComponent)this).GetChild("AnimaPlaceholder");
		SoldierNamePotentialLevelBack = (GComponent)((GComponent)this).GetChild("SoldierNamePotentialLevelBack");
		SoldierUpperLimit_t = (GTextField)((GComponent)this).GetChild("SoldierUpperLimit_t");
		n165 = (GTextField)((GComponent)this).GetChild("n165");
		string id5 = "ui://72fujxhkpipjp".Replace("ui://", "") + "-" + ((GObject)n165).id;
		((GObject)n165).text = LanguagesManager.GetDesc(id5);
		Soldiername_t = (GTextField)((GComponent)this).GetChild("Soldiername_t");
		string id6 = "ui://72fujxhkpipjp".Replace("ui://", "") + "-" + ((GObject)Soldiername_t).id;
		((GObject)Soldiername_t).text = LanguagesManager.GetDesc(id6);
		Soldiername_Max = (GTextField)((GComponent)this).GetChild("Soldiername_Max");
		string id7 = "ui://72fujxhkpipjp".Replace("ui://", "") + "-" + ((GObject)Soldiername_Max).id;
		((GObject)Soldiername_Max).text = LanguagesManager.GetDesc(id7);
		n16 = (GTextField)((GComponent)this).GetChild("n16");
		string id8 = "ui://72fujxhkpipjp".Replace("ui://", "") + "-" + ((GObject)n16).id;
		((GObject)n16).text = LanguagesManager.GetDesc(id8);
		n186 = (GTextField)((GComponent)this).GetChild("n186");
		string id9 = "ui://72fujxhkpipjp".Replace("ui://", "") + "-" + ((GObject)n186).id;
		((GObject)n186).text = LanguagesManager.GetDesc(id9);
		SoldierLevel_t = (GTextField)((GComponent)this).GetChild("SoldierLevel_t");
		string id10 = "ui://72fujxhkpipjp".Replace("ui://", "") + "-" + ((GObject)SoldierLevel_t).id;
		((GObject)SoldierLevel_t).text = LanguagesManager.GetDesc(id10);
		SoldierLevel_Max = (GTextField)((GComponent)this).GetChild("SoldierLevel_Max");
		string id11 = "ui://72fujxhkpipjp".Replace("ui://", "") + "-" + ((GObject)SoldierLevel_Max).id;
		((GObject)SoldierLevel_Max).text = LanguagesManager.GetDesc(id11);
		ShoulderStrap = (GLoader)((GComponent)this).GetChild("ShoulderStrap");
		n193 = (GGroup)((GComponent)this).GetChild("n193");
		n223 = (GImage)((GComponent)this).GetChild("n223");
		CombatPowerSfxBack = (GGraph)((GComponent)this).GetChild("CombatPowerSfxBack");
		n169 = (GTextField)((GComponent)this).GetChild("n169");
		string id12 = "ui://72fujxhkpipjp".Replace("ui://", "") + "-" + ((GObject)n169).id;
		((GObject)n169).text = LanguagesManager.GetDesc(id12);
		Combatpower_t = (GTextField)((GComponent)this).GetChild("Combatpower_t");
		CombatPowerIcon = (GImage)((GComponent)this).GetChild("CombatPowerIcon");
		detialLeft = (GGroup)((GComponent)this).GetChild("detialLeft");
		ReadyTime_t = (GTextField)((GComponent)this).GetChild("ReadyTime_t");
		string id13 = "ui://72fujxhkpipjp".Replace("ui://", "") + "-" + ((GObject)ReadyTime_t).id;
		((GObject)ReadyTime_t).text = LanguagesManager.GetDesc(id13);
		ExclamationMarkBtn1st = (GButton)((GComponent)this).GetChild("ExclamationMarkBtn1st");
		WeaponList = (GList)((GComponent)this).GetChild("WeaponList");
		SoldierInfoPanelClickBtn = (UI_SoldierInfoPanelClickBtn)(object)((GComponent)this).GetChild("SoldierInfoPanelClickBtn");
		n33 = (GTextField)((GComponent)this).GetChild("n33");
		string id14 = "ui://72fujxhkpipjp".Replace("ui://", "") + "-" + ((GObject)n33).id;
		((GObject)n33).text = LanguagesManager.GetDesc(id14);
		SoldierAmount = (GTextField)((GComponent)this).GetChild("SoldierAmount");
		ExclamationMarkBtn2nd = (GButton)((GComponent)this).GetChild("ExclamationMarkBtn2nd");
		IslandComeAgainCheckSoldierLimit = (GGraph)((GComponent)this).GetChild("IslandComeAgainCheckSoldierLimit");
		goToBtn = (GLoader)((GComponent)this).GetChild("goToBtn");
		detialRight = (GGroup)((GComponent)this).GetChild("detialRight");
		QueueList = (GList)((GComponent)this).GetChild("QueueList");
		tip = (GTextField)((GComponent)this).GetChild("tip");
		string id15 = "ui://72fujxhkpipjp".Replace("ui://", "") + "-" + ((GObject)tip).id;
		((GObject)tip).text = LanguagesManager.GetDesc(id15);
		HighLevelPage = (UI_com_NewRecruitInfo)(object)((GComponent)this).GetChild("HighLevelPage");
		Title = (UI_Title)(object)((GComponent)this).GetChild("Title");
		UpgraedeBtn = (GButton)((GComponent)this).GetChild("UpgraedeBtn");
		nameGroup = (GGroup)((GComponent)this).GetChild("nameGroup");
		addWorkerBtn = (GComponent)((GComponent)this).GetChild("addWorkerBtn");
		Confirm_New = (UI_ComfirmBtn2)(object)((GComponent)this).GetChild("Confirm_New");
		ConfirmBtn = (UI_ComfirmBtn)(object)((GComponent)this).GetChild("ConfirmBtn");
		ExitBtn = (GButton)((GComponent)this).GetChild("ExitBtn");
		t0 = ((GComponent)this).GetTransition("t0");
	}

	public void BeforeDestroy()
	{
		for (int i = 0; i < textureList.Count; i++)
		{
			AssetsManager.Instance.UnloadAsset<Texture2D>(textureList[i]);
		}
		if ((Object)(object)canvasObject1 != (Object)null)
		{
			SkeletonGraphic component = ((Component)canvasObject1.transform.GetChild(0)).gameObject.GetComponent<SkeletonGraphic>();
			if ((Object)(object)component != (Object)null)
			{
				component.skeletonDataAsset = null;
			}
			Object.Destroy((Object)(object)canvasObject1);
		}
	}

	public void OnShow()
	{
		UiTagManager instance = UiTagManager.Instance;
		instance.Register("Camp.ConfirmChangeBtn", OpenSoldierBtn);
		instance.Register("Camp.ConfirmProduceBtn", ConfirmBtn);
		instance.Register("Camp.ExitBtn", ExitBtn);
		instance.Register("Camp.CheckSoldierLimit", IslandComeAgainCheckSoldierLimit);
		if (QueueList.numItems > 0)
		{
			instance.Register("Camp.FirstProduction", ((GComponent)QueueList).GetChildAt(0));
		}
		UiAudioManager.Instance.SetMainCityBgmVolume(UiAudioManager.Instance.MiddleBgmVolume);
		UiAudioManager.Instance.PlayBackgroundSound("Building10_Click");
	}

	public void Destroy()
	{
		UiTagManager instance = UiTagManager.Instance;
		instance.Unregister("Camp.ConfirmChangeBtn", OpenSoldierBtn);
		instance.Unregister("Camp.ConfirmProduceBtn", ConfirmBtn);
		instance.Unregister("Camp.ExitBtn", ExitBtn);
		instance.Unregister("Camp.CheckSoldierLimit", IslandComeAgainCheckSoldierLimit);
		if (QueueList.numItems > 0)
		{
			instance.Unregister("Camp.FirstProduction", ((GComponent)QueueList).GetChildAt(0));
		}
		if (WeaponList.numItems > 0)
		{
			instance.Unregister("Camp.FirstMaterial", ((GComponent)WeaponList).GetChildAt(0));
		}
		UiAudioManager.Instance.SetMainCityBgmVolume(UiAudioManager.Instance.MaxUiBgmVolume);
	}

	public void Init(Dictionary<string, object> parameters)
	{
		//IL_0193: Unknown result type (might be due to invalid IL or missing references)
		//IL_0198: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c0: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c5: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ed: Unknown result type (might be due to invalid IL or missing references)
		//IL_01f2: Unknown result type (might be due to invalid IL or missing references)
		FGUIManager.SetUiPanelSizeAndXy((GObject)(object)this);
		((GObject)this).sortingOrder = 1;
		foreach (KeyValuePair<int, string> item in GameManagers.Instance.RecruitingCampDataManager.ProducingQueue)
		{
			if (!string.IsNullOrWhiteSpace(item.Value) && !(item.Value == "Unlock") && !(item.Value == "Lock"))
			{
				_soldierId = item.Value;
			}
		}
		_tempRecruitingData = new Dictionary<int, string>();
		_recruitingData = new Dictionary<int, string>();
		foreach (KeyValuePair<int, string> item2 in GameManagers.Instance.RecruitingCampDataManager.ProducingQueue)
		{
			_tempRecruitingData.Add(item2.Key, item2.Value);
			_recruitingData.Add(item2.Key, item2.Value);
		}
		RecruitingCamp = GameManagers.Instance.BuildingManager.GetBuildingByType("10") as Camp;
		SetBuildingName();
		Title.icon.url = "ui://PublicResources/Building" + RecruitingCamp.BuildingType;
		((GObject)ConfirmBtn).enabled = false;
		addWorkerBtn.GetChild("CurrentWorkerAmount").asTextField.strokeColor = Color32.op_Implicit(new Color32((byte)0, (byte)0, (byte)0, (byte)153));
		addWorkerBtn.GetChild("separate").asTextField.strokeColor = Color32.op_Implicit(new Color32((byte)0, (byte)0, (byte)0, (byte)153));
		addWorkerBtn.GetChild("AllWorkerAmount").asTextField.strokeColor = Color32.op_Implicit(new Color32((byte)0, (byte)0, (byte)0, (byte)153));
		CheckUpBtnTip();
		InitData(Flag: false, SoldierNotHave);
		InitPanel();
	}

	public void RegisterUiEventListeners()
	{
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_001d: Expected O, but got Unknown
		//IL_0030: Unknown result type (might be due to invalid IL or missing references)
		//IL_003a: Expected O, but got Unknown
		//IL_004d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0057: Expected O, but got Unknown
		//IL_0074: Unknown result type (might be due to invalid IL or missing references)
		//IL_007e: Expected O, but got Unknown
		//IL_0091: Unknown result type (might be due to invalid IL or missing references)
		//IL_009b: Expected O, but got Unknown
		//IL_00ae: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b8: Expected O, but got Unknown
		//IL_00cb: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d5: Expected O, but got Unknown
		((GObject)ExitBtn).onClick.Add(new EventCallback0(BackEvent));
		((GObject)UpgraedeBtn).onClick.Add(new EventCallback0(UpgradeClickEvent));
		((GObject)DiamondBtn).onClick.Add(new EventCallback0(DiamondClickEvent));
		addWorkerBtn.GetChild("addButton").onClick.Add(new EventCallback0(WorkerClickEvent));
		((GObject)ConfirmBtn).onClick.Add(new EventCallback1(ConfirmClickBtn));
		((GObject)Confirm_New).onClick.Add(new EventCallback1(ConfirmClickBtn));
		((GObject)goToBtn).onClick.Set(new EventCallback1(UI_MainCity.DungeonsBtnEvent));
		SharedMessenger.AddListener<string, int>("BUILDING_UPGRADED", OnBuildingUpgraded);
		SharedMessenger.AddListener<Building>("WORKERS_ALLOCATION_DISPLAY_CHANGED", UpdateWorkerNum);
		RegisterUiEventListeners_All();
	}

	public void UnregisterUiEventListeners()
	{
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_001d: Expected O, but got Unknown
		//IL_0030: Unknown result type (might be due to invalid IL or missing references)
		//IL_003a: Expected O, but got Unknown
		//IL_004d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0057: Expected O, but got Unknown
		//IL_0074: Unknown result type (might be due to invalid IL or missing references)
		//IL_007e: Expected O, but got Unknown
		//IL_0091: Unknown result type (might be due to invalid IL or missing references)
		//IL_009b: Expected O, but got Unknown
		//IL_00ae: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b8: Expected O, but got Unknown
		((GObject)ExitBtn).onClick.Remove(new EventCallback0(BackEvent));
		((GObject)UpgraedeBtn).onClick.Remove(new EventCallback0(UpgradeClickEvent));
		((GObject)DiamondBtn).onClick.Remove(new EventCallback0(DiamondClickEvent));
		addWorkerBtn.GetChild("addButton").onClick.Remove(new EventCallback0(WorkerClickEvent));
		((GObject)ConfirmBtn).onClick.Remove(new EventCallback1(ConfirmClickBtn));
		((GObject)Confirm_New).onClick.Remove(new EventCallback1(ConfirmClickBtn));
		((GObject)goToBtn).onClick.Clear();
		SharedMessenger.RemoveListener<string, int>("BUILDING_UPGRADED", OnBuildingUpgraded);
		SharedMessenger.RemoveListener<Building>("WORKERS_ALLOCATION_DISPLAY_CHANGED", UpdateWorkerNum);
		UnregisterUiEventListeners_All();
	}

	private void OpenSoldierCultivate()
	{
		GameController.Contexts.Service<IUiService>().OpenPanel(UI_SoldierCultivate.Name, new Dictionary<string, object>
		{
			{ "soldierId", soldier.Id },
			{ "soldierPanel", null },
			{
				"UnlockSoldierList",
				UiHelper.GetUnlockSoldierList()
			}
		});
	}

	public void UpdateWorkerNum(Building building = null)
	{
		Dungeon value = GameController.Contexts.game.dungeon.value;
		addWorkerBtn.GetChild("CurrentWorkerAmount").text = $"{Dungeon.GetFreeManPower(GameManagers.Instance)}";
		addWorkerBtn.GetChild("AllWorkerAmount").text = $"{Dungeon.GetTotalManPower(GameManagers.Instance)}";
	}

	private void ShowTipText()
	{
		((GObject)tip).visible = SoldierNotHave;
	}

	private void SetBuildingName()
	{
		((GObject)Title.buildingName).text = RecruitingCamp.Name ?? "";
	}

	public void InitData(bool Flag, bool isHide)
	{
		if (IsHighLevel)
		{
			InitData_New(Flag, isHide);
		}
		else
		{
			InitData_Old(Flag, isHide);
		}
	}

	private void InitPanel()
	{
		if (IsHighLevel)
		{
			InitPanel_New();
		}
		else
		{
			InitPanel_Old();
		}
	}

	private void InitData_New(bool flag, bool isHide)
	{
		//IL_04f2: Unknown result type (might be due to invalid IL or missing references)
		//IL_04f7: Unknown result type (might be due to invalid IL or missing references)
		//IL_0421: Unknown result type (might be due to invalid IL or missing references)
		//IL_0426: Unknown result type (might be due to invalid IL or missing references)
		//IL_04c3: Unknown result type (might be due to invalid IL or missing references)
		//IL_0530: Unknown result type (might be due to invalid IL or missing references)
		//IL_0659: Unknown result type (might be due to invalid IL or missing references)
		Type.selectedIndex = 1;
		((GComponent)UpgraedeBtn).GetChild("level").text = $"{RecruitingCamp.Level}";
		RenderSoldierStockLimit();
		if (flag)
		{
			IndependentRefreshQueueItem();
		}
		if (isHide)
		{
			HighLevelPage.Type.selectedIndex = 1;
			((GObject)HighLevelPage.Soldiername_t).text = string.Empty;
			((GObject)HighLevelPage.Soldiername_Max).text = string.Empty;
			((GObject)HighLevelPage.SoldierLevel_t).text = string.Empty;
			((GObject)HighLevelPage.SoldierLevel_Max).text = string.Empty;
			((GObject)HighLevelPage.Combatpower_t).text = string.Empty;
			((GObject)HighLevelPage.SoldierUpperLimit_t).text = string.Empty;
			((GObject)HighLevelPage.ReadyTime_t).text = string.Empty;
			((GObject)HighLevelPage.SoldierAmount).text = string.Empty;
			HighLevelPage.ShoulderStrap.url = string.Empty;
			return;
		}
		HighLevelPage.Type.selectedIndex = 0;
		soldier = GameManagers.Instance.SoldierManager.Get(_soldierId);
		foreach (KeyValuePair<int, string> tempRecruitingDatum in _tempRecruitingData)
		{
			if (tempRecruitingDatum.Value == soldier.Id)
			{
				listItemIndex = tempRecruitingDatum.Key;
				break;
			}
		}
		if (soldier.PotentialLevel >= 8)
		{
			HighLevelPage.NameType.selectedIndex = 1;
			((GObject)HighLevelPage.Soldiername_Max).text = soldier.Name;
			((GObject)HighLevelPage.SoldierLevel_Max).text = soldier.Level.ToString();
			HighLevelPage.ShoulderStrap.url = $"ui://PublicResources/icon_class_{soldier.EvoLevel}_legend";
		}
		else
		{
			HighLevelPage.NameType.selectedIndex = 0;
			((GObject)HighLevelPage.Soldiername_t).text = soldier.Name;
			((GObject)HighLevelPage.SoldierLevel_t).text = soldier.Level.ToString();
			HighLevelPage.ShoulderStrap.url = $"ui://PublicResources/icon_class_{soldier.EvoLevel}";
		}
		LoadAnimation();
		int soldierFormationNumber = Singleton<SoldierFormationManager>.Instance.GetSoldierFormationNumber(soldier.Id, soldier.Level);
		((GObject)HighLevelPage.Combatpower_t).text = (soldier.CombatPower * soldierFormationNumber).ToString();
		((GObject)HighLevelPage.SoldierUpperLimit_t).text = soldierFormationNumber.ToString();
		float num = Singleton<SoldierProductManager>.Instance.GetSoldierProductData(soldier.Id).Time / (1f + GameManagers.Instance.ModifierManager.GetPercentFloatPayload("ProductionEfficiency", new string[1] { "BuildingType10" }));
		((GObject)HighLevelPage.ReadyTime_t).text = UiHelper.RemoveSurplusZeroBehindDecimalPoint($"{num:F1}") ?? "";
		float percentFloatPayload = GameManagers.Instance.ModifierManager.GetPercentFloatPayload("ProductionEfficiency", new string[1] { "BuildingType" + RecruitingCamp.BuildingType });
		if (percentFloatPayload > 0f)
		{
			HighLevelPage.ReadyTime_t.color = Color32.op_Implicit(new Color32((byte)0, (byte)167, (byte)0, byte.MaxValue));
			((GObject)HighLevelPage.ExclamationMarkBtn1st).visible = true;
			((GObject)HighLevelPage.ExclamationMarkBtn1st).data = new Dictionary<string, object>
			{
				{
					"Title",
					LanguagesManager.GetDesc("CsharpCodeZhTcText105") + Environment.NewLine + string.Format("{0}：{1:F1}{2}", LanguagesManager.GetDesc("CsharpCodeZhTcText524"), Singleton<SoldierProductManager>.Instance.GetSoldierProductData(soldier.Id).Time, LanguagesManager.GetDesc("CsharpCodeZhTcText92"))
				},
				{
					"Pos",
					(object)new Vector2(417f, 866f)
				}
			};
		}
		else
		{
			HighLevelPage.ReadyTime_t.color = Color32.op_Implicit(new Color32((byte)80, (byte)40, (byte)10, byte.MaxValue));
			((GObject)HighLevelPage.ExclamationMarkBtn1st).visible = false;
		}
		_stockLimitIncrementTip.RenderLimitIncrementBtn((GObject)(object)HighLevelPage.ExclamationMarkBtn2nd, new Vector2(753f, 866f));
		RenderWeaponList();
		((GObject)HighLevelPage.SoldierAmount).text = GameManagers.Instance.StockController.GetStock(soldier.Id).ShortNumberFormat() + "/" + GameManagers.Instance.StockController.GetLimit(soldier.Id).ShortNumberFormat();
		((GObject)HighLevelPage.SoldierNamePotentialLevelBack).visible = true;
		HighLevelPage.SoldierNamePotentialLevelBack.GetController("Level").selectedIndex = soldier.PotentialLevel;
		if (!((GObject)HighLevelPage.CombatPowerSfxBack).displayObject.isDisposed)
		{
			((GObject)HighLevelPage.CombatPowerSfxBack).displayObject.Dispose();
		}
		FGUIManager.Instance.AddTextSpecialEffects(HighLevelPage.CombatPowerSfxBack, "combat_power", new Vector3(((GObject)HighLevelPage.CombatPowerSfxBack).width / 4f, ((GObject)HighLevelPage.CombatPowerSfxBack).height * 6f, ((GObject)HighLevelPage.CombatPowerSfxBack).height));
	}

	private void InitPanel_New()
	{
		//IL_0084: Unknown result type (might be due to invalid IL or missing references)
		//IL_00be: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00de: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fe: Unknown result type (might be due to invalid IL or missing references)
		//IL_0103: Unknown result type (might be due to invalid IL or missing references)
		if (!((GObject)HighLevelPage.CombatPowerSfxBack).displayObject.isDisposed)
		{
			((GObject)HighLevelPage.CombatPowerSfxBack).displayObject.Dispose();
		}
		FGUIManager.Instance.AddTextSpecialEffects(HighLevelPage.CombatPowerSfxBack, "combat_power", new Vector3(((GObject)HighLevelPage.CombatPowerSfxBack).width / 4f, ((GObject)HighLevelPage.CombatPowerSfxBack).height * 6f, ((GObject)HighLevelPage.CombatPowerSfxBack).height));
		RenderSoldierList();
		ShowTip();
		HighLevelPage.Soldiername_t.strokeColor = Color32.op_Implicit(new Color32((byte)102, (byte)84, (byte)50, (byte)153));
		HighLevelPage.n21.strokeColor = Color32.op_Implicit(new Color32((byte)0, (byte)0, (byte)0, (byte)102));
		HighLevelPage.SoldierLevel_t.strokeColor = Color32.op_Implicit(new Color32((byte)0, (byte)0, (byte)0, (byte)102));
	}

	private void InitPanel_Old()
	{
		//IL_0066: Unknown result type (might be due to invalid IL or missing references)
		//IL_009b: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bb: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d6: Unknown result type (might be due to invalid IL or missing references)
		//IL_0101: Unknown result type (might be due to invalid IL or missing references)
		//IL_0106: Unknown result type (might be due to invalid IL or missing references)
		if (!((GObject)CombatPowerSfxBack).displayObject.isDisposed)
		{
			((GObject)CombatPowerSfxBack).displayObject.Dispose();
		}
		FGUIManager.Instance.AddTextSpecialEffects(CombatPowerSfxBack, "combat_power", new Vector3(((GObject)CombatPowerSfxBack).width / 4f, ((GObject)CombatPowerSfxBack).height * 6f, ((GObject)CombatPowerSfxBack).height));
		QueueListData();
		ShowTipText();
		Soldiername_t.strokeColor = Color32.op_Implicit(new Color32((byte)102, (byte)84, (byte)50, (byte)153));
		n16.strokeColor = Color32.op_Implicit(new Color32((byte)0, (byte)0, (byte)0, (byte)102));
		SoldierLevel_t.strokeColor = Color32.op_Implicit(new Color32((byte)0, (byte)0, (byte)0, (byte)102));
		((GComponent)OpenSoldierBtn).GetChild("title").asTextField.strokeColor = Color32.op_Implicit(new Color32((byte)60, (byte)72, (byte)13, (byte)153));
	}

	private void InitData_Old(bool Flag, bool isHide)
	{
		//IL_0444: Unknown result type (might be due to invalid IL or missing references)
		//IL_0449: Unknown result type (might be due to invalid IL or missing references)
		//IL_0382: Unknown result type (might be due to invalid IL or missing references)
		//IL_0387: Unknown result type (might be due to invalid IL or missing references)
		//IL_041a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0478: Unknown result type (might be due to invalid IL or missing references)
		//IL_05a8: Unknown result type (might be due to invalid IL or missing references)
		Type.selectedIndex = 0;
		((GComponent)UpgraedeBtn).GetChild("level").text = $"{RecruitingCamp.Level}";
		((GObject)DiamondAmount_t).text = "12345";
		Dungeon value = GameController.Contexts.game.dungeon.value;
		addWorkerBtn.GetChild("CurrentWorkerAmount").text = $"{Dungeon.GetFreeManPower(GameManagers.Instance)}";
		addWorkerBtn.GetChild("AllWorkerAmount").text = $"{Dungeon.GetTotalManPower(GameManagers.Instance)}";
		if (Flag)
		{
			IndependentRefreshQueueListData();
		}
		if (!isHide)
		{
			soldier = GameManagers.Instance.SoldierManager.Get(_soldierId);
			foreach (KeyValuePair<int, string> tempRecruitingDatum in _tempRecruitingData)
			{
				if (tempRecruitingDatum.Value == soldier.Id)
				{
					listItemIndex = tempRecruitingDatum.Key;
					break;
				}
			}
			if (soldier.PotentialLevel >= 8)
			{
				Status.selectedIndex = 1;
				((GObject)Soldiername_Max).text = soldier.Name;
				((GObject)SoldierLevel_Max).text = soldier.Level.ToString();
				ShoulderStrap.url = $"ui://PublicResources/icon_class_{soldier.EvoLevel}_legend";
			}
			else
			{
				Status.selectedIndex = 0;
				((GObject)Soldiername_t).text = soldier.Name;
				((GObject)SoldierLevel_t).text = soldier.Level.ToString();
				ShoulderStrap.url = $"ui://PublicResources/icon_class_{soldier.EvoLevel}";
			}
			LoadAnima();
			int soldierFormationNumber = Singleton<SoldierFormationManager>.Instance.GetSoldierFormationNumber(soldier.Id, soldier.Level);
			((GObject)Combatpower_t).text = (soldier.CombatPower * soldierFormationNumber).ToString();
			((GObject)SoldierUpperLimit_t).text = soldierFormationNumber.ToString() ?? "";
			float num = Singleton<SoldierProductManager>.Instance.GetSoldierProductData(soldier.Id).Time / (1f + GameManagers.Instance.ModifierManager.GetPercentFloatPayload("ProductionEfficiency", new string[1] { "BuildingType10" }));
			((GObject)ReadyTime_t).text = UiHelper.RemoveSurplusZeroBehindDecimalPoint($"{num:F1}") + LanguagesManager.GetDesc("CsharpCodeZhTcText92");
			float percentFloatPayload = GameManagers.Instance.ModifierManager.GetPercentFloatPayload("ProductionEfficiency", new string[1] { "BuildingType" + RecruitingCamp.BuildingType });
			if (percentFloatPayload > 0f)
			{
				ReadyTime_t.color = Color32.op_Implicit(new Color32((byte)0, (byte)167, (byte)0, byte.MaxValue));
				((GObject)ExclamationMarkBtn1st).visible = true;
				((GObject)ExclamationMarkBtn1st).data = new Dictionary<string, object>
				{
					{
						"Title",
						LanguagesManager.GetDesc("CsharpCodeZhTcText105") + Environment.NewLine + string.Format("{0}：{1:F1}{2}", LanguagesManager.GetDesc("CsharpCodeZhTcText524"), Singleton<SoldierProductManager>.Instance.GetSoldierProductData(soldier.Id).Time, LanguagesManager.GetDesc("CsharpCodeZhTcText92"))
					},
					{
						"Pos",
						(object)new Vector2(1481f, 295f)
					}
				};
			}
			else
			{
				ReadyTime_t.color = Color32.op_Implicit(new Color32((byte)80, (byte)40, (byte)10, byte.MaxValue));
				((GObject)ExclamationMarkBtn1st).visible = false;
			}
			_stockLimitIncrementTip.RenderLimitIncrementBtn((GObject)(object)ExclamationMarkBtn2nd, new Vector2(1481f, 730f));
			WeaponListData();
			((GObject)SoldierAmount).text = GameManagers.Instance.StockController.GetStock(soldier.Id).ShortNumberFormat() + "/" + GameManagers.Instance.StockController.GetLimit(soldier.Id).ShortNumberFormat();
			((GObject)SoldierNamePotentialLevelBack).visible = true;
			SoldierNamePotentialLevelBack.GetController("Level").selectedIndex = soldier.PotentialLevel;
			((GObject)detialLeft).visible = true;
			((GObject)detialRight).visible = true;
			((GObject)CombatPowerSfxBack).visible = true;
			((GObject)SoldierCultivateBtn).visible = false;
			if (!((GObject)CombatPowerSfxBack).displayObject.isDisposed)
			{
				((GObject)CombatPowerSfxBack).displayObject.Dispose();
			}
			FGUIManager.Instance.AddTextSpecialEffects(CombatPowerSfxBack, "combat_power", new Vector3(((GObject)CombatPowerSfxBack).width / 4f, ((GObject)CombatPowerSfxBack).height * 6f, ((GObject)CombatPowerSfxBack).height));
		}
		else
		{
			((GObject)Soldiername_t).text = "";
			((GObject)Soldiername_Max).text = "";
			((GObject)SoldierLevel_t).text = "";
			((GObject)SoldierLevel_Max).text = "";
			((GObject)Combatpower_t).text = "";
			((GObject)SoldierUpperLimit_t).text = "";
			((GObject)ReadyTime_t).text = LanguagesManager.GetDesc("CsharpCodeZhTcText92");
			((GObject)ExclamationMarkBtn1st).visible = false;
			((GObject)ExclamationMarkBtn2nd).visible = false;
			((GObject)SoldierAmount).text = "";
			((GObject)SoldierNamePotentialLevelBack).visible = false;
			((GObject)detialLeft).visible = false;
			((GObject)detialRight).visible = false;
			ShoulderStrap.url = "";
			((GObject)CombatPowerSfxBack).visible = false;
			((GObject)SoldierCultivateBtn).visible = false;
		}
	}

	public void IndependentRefreshQueueListData()
	{
		if (!_tempRecruitingData.TryGetValue(listItemIndex, out var value))
		{
			return;
		}
		_soldierId = value;
		GameManagers instance = GameManagers.Instance;
		soldier = instance.SoldierManager.Get(value);
		_soldierIdsStrings[listItemIndex] = value;
		GComponent asCom = ((GComponent)QueueList).GetChildAt(listItemIndex).asCom;
		asCom.GetChild("IconLoader").asCom.GetChild("IconLoader").asLoader.fill = (FillType)1;
		asCom.GetChild("IconLoader").asCom.GetChild("IconLoader").asLoader.url = "ui://PublicResources/" + UiHelper.GetIconPath(soldier.Id);
		asCom.GetChild("IconLoader").data = value;
		string iconFrameBorderSoldier = UiHelper.GetIconFrameBorderSoldier(soldier.PotentialLevel);
		asCom.GetChild("FrameLoader").asLoader.url = "ui://PublicResources/" + iconFrameBorderSoldier;
		UiHelper.LoadSoldierIconFrameMaterial(asCom.GetChild("FrameLoader").asLoader, soldier.PotentialLevel);
		((GObject)asCom.GetChild("FrameLoader").asLoader).grayed = false;
		asCom.GetChild("lvFrame").asLoader.url = UiHelper.GetLevelFrameBorderSoldier(soldier.PotentialLevel);
		FGUIManager.Instance.SetAlightSoulStoneForSoldierIcon(asCom.GetChild("SoulStoneLevel").asCom, soldier.PotentialLevel, soldier.PotentialProgress);
		((GObject)asCom.GetChild("InfoGroup").asGroup).visible = true;
		((GObject)asCom.GetChild("Level_t").asTextField).text = $"{soldier.Level}";
		((GObject)asCom.GetChild("Amount_t").asTextField).text = instance.StockController.GetStock(value).ShortNumberFormat();
		SetNumStatus(asCom, value);
		_amountNums[listItemIndex] = asCom.GetChild("Amount_t").asTextField;
		asCom.GetChild("Name_t").visible = false;
		asCom.GetChild("Name_Max").visible = false;
		asCom.GetChild("Mask").visible = true;
		_productImages[listItemIndex] = asCom.GetChild("Mask").asImage;
		_productImages[listItemIndex].fillAmount = 0f;
		int stock = instance.StockController.GetStock(soldier.Id);
		int limit = instance.StockController.GetLimit(soldier.Id);
		asCom.GetController("PageController").selectedIndex = ((stock >= limit) ? 1 : 0);
		for (int i = 0; i < QueueList.numItems; i++)
		{
			GComponent asCom2 = ((GComponent)QueueList).GetChildAt(i).asCom;
			if (asCom2.GetController("Status").selectedIndex == 0)
			{
				asCom2.GetController("Status").selectedIndex = 1;
				break;
			}
		}
		asCom.GetController("Status").selectedIndex = 0;
	}

	private void SetNumStatus(GComponent numComponent, string sid)
	{
		int stock = GameManagers.Instance.StockController.GetStock(sid);
		int soldierLevel = GameManagers.Instance.UserArchiveManager.GetSoldierLevel(sid);
		int soldierFormationNumber = Singleton<SoldierFormationManager>.Instance.GetSoldierFormationNumber(sid, soldierLevel);
		numComponent.GetController("NumStatus").selectedIndex = ((stock >= soldierFormationNumber) ? 1 : 0);
	}

	public void UnlockRefreshQueueListData(int listItemIndex, string _id)
	{
		GComponent asCom = ((GComponent)QueueList).GetChildAt(listItemIndex).asCom;
		asCom.GetChild("IconLoader").asCom.GetChild("IconLoader").asLoader.url = "";
		asCom.GetChild("IconLoader").data = null;
		asCom.GetChild("FrameLoader").asLoader.url = "ui://PublicResources/kuang_square_avatar_wood";
		((GObject)asCom.GetChild("FrameLoader").asLoader).grayed = false;
		asCom.GetChild("lvFrame").asLoader.url = "";
		((GObject)asCom.GetChild("InfoGroup").asGroup).visible = false;
		((GObject)asCom.GetChild("Level_t").asTextField).text = "";
		((GObject)asCom.GetChild("Amount_t").asTextField).text = "";
		asCom.GetController("NumStatus").selectedIndex = 1;
		_amountNums[listItemIndex] = null;
		asCom.GetChild("Name_t").visible = false;
		asCom.GetChild("Name_Max").visible = false;
		asCom.GetChild("Mask").visible = false;
		GList asList = asCom.GetChild("LevelStarList").asList;
		asList.numItems = 0;
		GameManagers instance = GameManagers.Instance;
		string text = _soldierIdsStrings[listItemIndex];
		if (!string.IsNullOrEmpty(text))
		{
			int stock = instance.StockController.GetStock(text);
			int limit = instance.StockController.GetLimit(text);
			asCom.GetController("PageController").selectedIndex = ((stock >= limit) ? 1 : 0);
			if (string.IsNullOrWhiteSpace(_id) || _soldierId == "Unlock" || _soldierId == "Lock")
			{
				asCom.GetController("PageController").selectedIndex = 0;
			}
			asCom.GetController("Status").selectedIndex = 2;
		}
	}

	public void QueueListData()
	{
		//IL_001f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0029: Expected O, but got Unknown
		QueueList.RemoveChildrenToPool();
		QueueList.onClickItem.Add(new EventCallback1(ListItemClickEvent));
		int num = 0;
		GameManagers instance = GameManagers.Instance;
		foreach (KeyValuePair<int, string> tempRecruitingDatum in _tempRecruitingData)
		{
			GComponent asCom = QueueList.AddItemFromPool().asCom;
			asCom.GetChild("Name_t").visible = false;
			asCom.GetChild("Name_Max").visible = false;
			if (num < RecruitingCamp.Slot)
			{
				if (tempRecruitingDatum.Value == "Unlock" || tempRecruitingDatum.Value == "Lock")
				{
					_soldierIdsStrings[num] = null;
					_productImages[num] = null;
					_amountNums[num] = null;
					asCom.GetChild("FloorLoader").asLoader.url = "ui://PublicResources/Unlockfloor";
					asCom.GetChild("FrameLoader").asLoader.url = "ui://PublicResources/kuang_square_avatar_wood";
					asCom.GetChild("IconLoader").data = null;
					asCom.GetChild("IconLoader").asCom.GetChild("IconLoader").asLoader.url = "";
					asCom.GetChild("lvFrame").asLoader.url = "ui://PublicResources/kuang_round 2_lv1";
					((GObject)asCom.GetChild("InfoGroup").asGroup).visible = false;
					asCom.GetChild("Mask").visible = false;
					asCom.GetController("Status").selectedIndex = 2;
				}
				else
				{
					Soldier soldier = instance.SoldierManager.Get(tempRecruitingDatum.Value);
					_soldierId = tempRecruitingDatum.Value;
					_soldierIdsStrings[num] = tempRecruitingDatum.Value;
					asCom.GetChild("FloorLoader").asLoader.url = "ui://PublicResources/Soldierfloor";
					asCom.GetChild("IconLoader").asCom.GetChild("IconLoader").asLoader.fill = (FillType)1;
					asCom.GetChild("IconLoader").asCom.GetChild("IconLoader").asLoader.url = "ui://PublicResources/" + UiHelper.GetIconPath(soldier.Id);
					asCom.GetChild("IconLoader").data = tempRecruitingDatum.Value;
					string iconFrameBorderSoldier = UiHelper.GetIconFrameBorderSoldier(soldier.PotentialLevel);
					asCom.GetChild("FrameLoader").asLoader.url = "ui://PublicResources/" + iconFrameBorderSoldier;
					UiHelper.LoadSoldierIconFrameMaterial(asCom.GetChild("FrameLoader").asLoader, soldier.PotentialLevel);
					asCom.GetChild("lvFrame").asLoader.url = UiHelper.GetLevelFrameBorderSoldier(soldier.PotentialLevel);
					FGUIManager.Instance.SetAlightSoulStoneForSoldierIcon(asCom.GetChild("SoulStoneLevel").asCom, soldier.PotentialLevel, soldier.PotentialProgress);
					((GObject)asCom.GetChild("InfoGroup").asGroup).visible = true;
					((GObject)asCom.GetChild("Level_t").asTextField).text = $"{soldier.Level}";
					((GObject)asCom.GetChild("Amount_t").asTextField).text = instance.StockController.GetStock(tempRecruitingDatum.Value).ShortNumberFormat();
					SetNumStatus(asCom, tempRecruitingDatum.Value);
					_amountNums[num] = asCom.GetChild("Amount_t").asTextField;
					asCom.GetChild("Mask").visible = true;
					_productImages[num] = asCom.GetChild("Mask").asImage;
					int stock = instance.StockController.GetStock(soldier.Id);
					int limit = instance.StockController.GetLimit(soldier.Id);
					asCom.GetController("PageController").selectedIndex = ((stock >= limit) ? 1 : 0);
					if (_soldierIdsStrings[num] == this.soldier.Id && listItemIndex == num)
					{
						asCom.GetController("Status").selectedIndex = 0;
					}
					else
					{
						asCom.GetController("Status").selectedIndex = 1;
					}
				}
			}
			else
			{
				_soldierIdsStrings[num] = null;
				_productImages[num] = null;
				_amountNums[num] = null;
				asCom.GetChild("FloorLoader").asLoader.url = "ui://PublicResources/Lockfloor";
				asCom.GetChild("FrameLoader").asLoader.url = "ui://PublicResources/kuang_square_avatar_locked";
				asCom.GetChild("IconLoader").data = null;
				asCom.GetChild("IconLoader").asCom.GetChild("IconLoader").asLoader.url = "";
				asCom.GetChild("lvFrame").asLoader.url = "";
				((GObject)asCom.GetChild("InfoGroup").asGroup).visible = false;
				asCom.GetChild("Mask").visible = false;
				asCom.GetController("Status").selectedIndex = 3;
			}
			if (num >= 5)
			{
				((GObject)asCom).visible = false;
			}
			num++;
		}
	}

	public void RefreshTime(object parameter)
	{
		long serverTime = GameController.Instance.GetServerTime();
		CampController campController = (CampController)RecruitingCamp.Controller;
		for (int i = 0; i < _recruitingData.Count; i++)
		{
			if (_productImages[i] != null && !(_recruitingData[i] == "Unlock") && !(_recruitingData[i] == "Lock") && !(_recruitingData[i] != _tempRecruitingData[i]))
			{
				float fillAmount = (float)(GameManagers.Instance.RecruitingCampDataManager.ProducingEndTime[i] - serverTime) / GameManagers.Instance.RecruitingCampDataManager.ProductTime[i];
				_productImages[i].fillAmount = fillAmount;
			}
		}
	}

	private void RefreshSoldierInfo(string itemId, int incr, (StockInContext, string) context)
	{
		if (IsHighLevel)
		{
			return;
		}
		bool flag = false;
		if (SchemaIndexHelper.GetSchemaById(itemId) == "Soldier")
		{
			GameManagers instance = GameManagers.Instance;
			CampController campController = (CampController)RecruitingCamp.Controller;
			for (int i = 0; i < _productImages.Length; i++)
			{
				string text = _soldierIdsStrings[i];
				if (!string.IsNullOrEmpty(text) && _amountNums[i] != null)
				{
					((GObject)_amountNums[i]).text = instance.StockController.GetStock(text).ShortNumberFormat();
					SetNumStatus(((GComponent)QueueList).GetChildAt(i).asCom, text);
					int stock = instance.StockController.GetStock(text);
					int limit = instance.StockController.GetLimit(text);
					((GComponent)QueueList).GetChildAt(i).asCom.GetController("PageController").selectedIndex = ((stock >= limit) ? 1 : 0);
				}
			}
			if (itemId == _soldierId)
			{
				flag = true;
				((GObject)SoldierAmount).text = instance.StockController.GetStock(soldier.Id).ShortNumberFormat() + " / " + instance.StockController.GetLimit(soldier.Id).ShortNumberFormat();
			}
		}
		if (flag || (soldier != null && soldier.WeaponList.Contains(itemId)))
		{
			WeaponListData();
		}
	}

	private void OnBuildingUpgraded(string buildingType, int level)
	{
		if (!(buildingType != RecruitingCamp.BuildingType))
		{
			if (level == 6)
			{
				GameController.Contexts.Service<IUiService>().OpenPanel(Name, null);
				return;
			}
			CheckUpBtnTip();
			InitData(Flag: false, SoldierNotHave);
		}
	}

	private void CheckUpBtnTip()
	{
		((GObject)((GComponent)UpgraedeBtn).GetChild("redPoint").asImage).visible = RecruitingCamp.CanUpgrade() || RecruitingCamp.HasNewMaxLevel();
	}

	public void ListItemClickEvent(EventContext context)
	{
		//IL_000e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0018: Expected O, but got Unknown
		//IL_0024: Unknown result type (might be due to invalid IL or missing references)
		//IL_002e: Expected O, but got Unknown
		listItemIndex = ((GComponent)QueueList).GetChildIndex((GObject)context.data);
		ListItem = (GComponent)context.data;
		if (ListItem.GetController("Status").selectedIndex != 3)
		{
			UiAudioManager.Instance.PlaySoundEffect("GeneralClick");
			if (ListItem.GetChild("IconLoader").data == null)
			{
				PushPanel();
				return;
			}
			if (ListItem.GetController("Status").selectedIndex == 0)
			{
				PushPanel();
				return;
			}
			_soldierId = ListItem.GetChild("IconLoader").data.ToString();
			InitData(Flag: false, SoldierNotHave);
			ShowTipText();
			for (int i = 0; i < QueueList.numItems; i++)
			{
				GComponent asCom = ((GComponent)QueueList).GetChildAt(i).asCom;
				if (asCom.GetController("Status").selectedIndex == 0)
				{
					asCom.GetController("Status").selectedIndex = 1;
					break;
				}
			}
			ListItem.GetController("Status").selectedIndex = 0;
		}
		else
		{
			int unlockLevelBySlot = RecruitingCamp.GetUnlockLevelBySlot(RecruitingCamp.Level, listItemIndex + 1);
			List<string> arg = new List<string>
			{
				string.Format("{0}{1}{2}", LanguagesManager.GetDesc("CsharpCodeZhTcText525"), unlockLevelBySlot, LanguagesManager.GetDesc("CsharpCodeZhTcText124")),
				LanguagesManager.GetDesc("CsharpCodeZhTcText523")
			};
			SharedMessenger.Broadcast("SHOW_TIPS", arg, 1, arg3: false);
		}
	}

	public void PushPanel()
	{
		Dictionary<string, object> dictionary = new Dictionary<string, object>();
		dictionary.Add("Style", "3");
		dictionary.Add("Spine", canvasObject1);
		dictionary.Add("OnlyUnlocked", 1);
		GameController.Contexts.Service<IUiService>().OpenPanel(UI_LegionPanel.Name, dictionary);
	}

	public void OnCampClose(EventContext context, string solderId, int chosenType)
	{
		if (!IsHighLevel && chosenType == 3)
		{
			_soldierId = solderId;
			_tempRecruitingData[listItemIndex] = solderId;
			if (SoldierNotHave)
			{
				InitData(Flag: false, isHide: true);
				UnlockRefreshQueueListData(listItemIndex, _soldierId);
			}
			else
			{
				InitData(Flag: true, isHide: false);
			}
			((GObject)ConfirmBtn).enabled = true;
			ShowTipText();
		}
	}

	public void UnloadSoldierSpine()
	{
		((GObject)AnimaPlaceholder).displayObject.Dispose();
	}

	public void LoadAnima()
	{
		//IL_00a4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00aa: Expected O, but got Unknown
		//IL_00cf: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d9: Unknown result type (might be due to invalid IL or missing references)
		UnloadSoldierSpine();
		ref GameObject reference = ref canvasObject1;
		Object obj = Object.Instantiate(Resources.Load("Items/Spine", typeof(GameObject)));
		reference = (GameObject)(object)((obj is GameObject) ? obj : null);
		canvasObject1.GetComponent<Canvas>().sortingLayerName = "Default";
		int potentialLevel = soldier.CurrentSpineSkinId;
		SpawnManager.Instance.LoadSoldierSpine(canvasObject1, $"{_soldierId}_skin{potentialLevel}").Then((Action<SkeletonDataAsset>)delegate(SkeletonDataAsset asset)
		{
			if (!((GObject)this).isDisposed)
			{
				SkeletonGraphic component = ((Component)canvasObject1.transform.GetChild(0)).gameObject.GetComponent<SkeletonGraphic>();
				if ((Object)(object)component != (Object)null && (Object)(object)asset != (Object)null)
				{
					component.skeletonDataAsset = asset;
					component.initialSkinName = $"skin{potentialLevel}";
					component.Initialize(true);
					((Component)canvasObject1.transform.GetChild(0)).gameObject.SetActive(true);
				}
			}
		});
		GoWrapper nativeObject = new GoWrapper(canvasObject1);
		AnimaPlaceholder.SetNativeObject((DisplayObject)(object)nativeObject);
		InitSpineObj(canvasObject1);
		canvasObject1.transform.localScale = Vector3.one * 0.8f;
	}

	private void InitSpineObj(GameObject spineObj)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_000b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0010: Unknown result type (might be due to invalid IL or missing references)
		//IL_0017: Unknown result type (might be due to invalid IL or missing references)
		//IL_001d: Expected O, but got Unknown
		//IL_001e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_003c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0042: Expected O, but got Unknown
		//IL_0043: Unknown result type (might be due to invalid IL or missing references)
		//IL_004b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0053: Unknown result type (might be due to invalid IL or missing references)
		//IL_005b: Unknown result type (might be due to invalid IL or missing references)
		Vector2 val = Vector2.right * 0.5f;
		RectTransform val2 = (RectTransform)spineObj.transform;
		val2.pivot = val;
		val2.anchoredPosition = Vector2.zero;
		RectTransform val3 = (RectTransform)((Transform)val2).Find("Spine");
		val3.pivot = val;
		val3.anchorMin = val;
		val3.anchorMax = val;
		val3.anchoredPosition = Vector2.zero;
	}

	public void WeaponListData()
	{
		//IL_0262: Unknown result type (might be due to invalid IL or missing references)
		//IL_024d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0267: Unknown result type (might be due to invalid IL or missing references)
		//IL_0279: Unknown result type (might be due to invalid IL or missing references)
		//IL_027a: Unknown result type (might be due to invalid IL or missing references)
		//IL_02ad: Unknown result type (might be due to invalid IL or missing references)
		//IL_02b7: Expected O, but got Unknown
		int num = 0;
		UiTagManager instance = UiTagManager.Instance;
		if (WeaponList.numItems > 0)
		{
			instance.Unregister("Camp.FirstMaterial", ((GComponent)WeaponList).GetChildAt(0));
		}
		WeaponList.RemoveChildrenToPool();
		List<string> weaponList = soldier.WeaponList;
		Dictionary<string, float> soldierProductRequirements = Singleton<SoldierProductManager>.Instance.GetSoldierProductRequirements(soldier.Id);
		foreach (string item in weaponList)
		{
			if (!(item != "null"))
			{
				continue;
			}
			GButton asButton = WeaponList.AddItemFromPool().asButton;
			((GComponent)asButton).GetChild("WeaponIconLoader").asLoader.url = "ui://PublicResources/" + UiHelper.GetIcon(item);
			int weaponEvoLevel = GameManagers.Instance.UserArchiveManager.GetWeaponEvoLevel(item);
			((GComponent)asButton).GetChild("WeaponFrameLoader").asLoader.url = $"ui://PublicResources/kuang_round 2_lv{weaponEvoLevel}";
			((GObject)((GComponent)asButton).GetChild("WeaponName_t").asTextField).text = SchemaIndexHelper.GetNameById(GameManagers.Instance, item);
			num = GameManagers.Instance.StockController.GetStock(item);
			if (soldierProductRequirements.ContainsKey(item))
			{
				if ((float)num < soldierProductRequirements[item])
				{
					((GObject)((GComponent)asButton).GetChild("WeaponAmount_t").asTextField).text = $"[color=#DC143C]{num.ShortNumberFormat()}[/color][color=#DC143C]/{soldierProductRequirements[item]}[/color]";
					((GComponent)asButton).GetTransition("breathing").Play();
				}
				else
				{
					((GObject)((GComponent)asButton).GetChild("WeaponAmount_t").asTextField).text = $"{num.ShortNumberFormat()}/{soldierProductRequirements[item]}";
					((GComponent)asButton).GetTransition("breathing").Stop();
					((GComponent)asButton).GetChild("WeaponAmount_t").SetScale(1f, 1f);
				}
			}
			else
			{
				((GObject)((GComponent)asButton).GetChild("WeaponAmount_t").asTextField).text = num.ShortNumberFormat() ?? "";
				Color32 val = ((num == 0) ? new Color32((byte)233, (byte)76, (byte)39, byte.MaxValue) : new Color32((byte)80, (byte)40, (byte)10, byte.MaxValue));
				((GComponent)asButton).GetChild("WeaponAmount_t").asTextField.color = Color32.op_Implicit(val);
			}
			((GObject)((GComponent)asButton).GetChild("title").asTextField).text = item;
			((GObject)asButton).onClick.Set(new EventCallback1(MaterialIntroductionPanelInit));
		}
		if (WeaponList.numItems > 0)
		{
			instance.Register("Camp.FirstMaterial", ((GComponent)WeaponList).GetChildAt(0));
		}
	}

	private void MaterialIntroductionPanelInit(EventContext context)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000d: Expected O, but got Unknown
		GComponent val = (GComponent)context.sender;
		string text = ((GObject)val.GetChild("title").asTextField).text;
		FGUIManager.Instance.ItemTip(text, ((GObject)this).sortingOrder);
	}

	public void ConfirmClickBtn(EventContext eventContext)
	{
		ILRequestHelper<ChangeCampProduceConfigResponse>.Request(eventContext, () => GameController.Contexts.Service<INetworkService>().ChangeCampProduceConfig(1L, _tempRecruitingData), delegate(ChangeCampProduceConfigResponse response)
		{
			if (!response.Result)
			{
				ILRequestHelper.ShowErrorCode(response.ErrorCode);
			}
			else
			{
				OnChangeCampProduceConfigCompleted();
			}
		});
	}

	private void OnChangeCampProduceConfigCompleted()
	{
		GameManagers.Instance.RecruitingCampDataManager.ProducingQueue = _tempRecruitingData;
		ExitPanel();
		GameManagers.Instance.RecruitingCampDataManager.MakeOneRecruiting();
	}

	public void WorkerClickEvent()
	{
		List<string> arg = new List<string> { LanguagesManager.GetDesc("CsharpCodeZhTcText21") };
		SharedMessenger.Broadcast("SHOW_TIPS", arg, 1, arg3: false);
	}

	public void DiamondClickEvent()
	{
	}

	public void UpgradeClickEvent()
	{
		Dictionary<string, object> dictionary = new Dictionary<string, object>();
		dictionary.Add("Parent", this);
		dictionary.Add("Building", RecruitingCamp);
		GameController.Contexts.Service<IUiService>().OpenPanel(UI_Main_UpGradePanel.Name, dictionary);
	}

	private void BackEvent()
	{
		if (((GObject)ConfirmBtn).enabled)
		{
			GameController.Contexts.Service<IUiService>().OpenPanel(UI_UniversalConfirmPopup.Name, new Dictionary<string, object>
			{
				{
					"Content",
					LanguagesManager.GetDesc("CsharpCodeZhTcText526") + LanguagesManager.Comma + LanguagesManager.GetDesc("CsharpCodeZhTcText527") + "？"
				},
				{
					"Buttons",
					new Dictionary<string, Action>
					{
						{
							"Confirm",
							delegate
							{
								((GObject)ConfirmBtn).onClick.Call();
							}
						},
						{
							"Cancel",
							delegate
							{
								ExitPanel();
							}
						}
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
			ExitPanel();
		}
	}

	public void ExitPanel()
	{
		GameController.Contexts.Service<IUiService>().ClosePanel(Name);
	}

	private void OpenSoldierInfoPanel()
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0011: Unknown result type (might be due to invalid IL or missing references)
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_0014: Unknown result type (might be due to invalid IL or missing references)
		//IL_0019: Unknown result type (might be due to invalid IL or missing references)
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_0031: Unknown result type (might be due to invalid IL or missing references)
		//IL_0036: Unknown result type (might be due to invalid IL or missing references)
		Vector2 val = ((GObject)SoldierInfoPanelClickBtn).LocalToGlobal(Vector2.zero);
		val = ((GObject)this).GlobalToLocal(val);
		Dictionary<string, object> dictionary = new Dictionary<string, object>();
		dictionary.Add("DialogPos", val + new Vector2(0f, 90f));
		GameController.Contexts.Service<IUiService>().OpenPanel(UI.SoldierFormationInfo.UI_SoldierFormationInfoPanel.Name, dictionary);
	}

	private void RegisterUiEventListeners_All()
	{
		RegisterUiEventListeners_Old();
		RegisterUiEventListeners_New();
	}

	private void RegisterUiEventListeners_Old()
	{
		//IL_0017: Unknown result type (might be due to invalid IL or missing references)
		//IL_0021: Expected O, but got Unknown
		//IL_0038: Unknown result type (might be due to invalid IL or missing references)
		//IL_0042: Expected O, but got Unknown
		//IL_0055: Unknown result type (might be due to invalid IL or missing references)
		//IL_005f: Expected O, but got Unknown
		//IL_0072: Unknown result type (might be due to invalid IL or missing references)
		//IL_007c: Expected O, but got Unknown
		//IL_008f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0099: Expected O, but got Unknown
		//IL_00ac: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b7: Expected O, but got Unknown
		((GObject)ExclamationMarkBtn1st).onClick.Add(new EventCallback1(FGUIManager.Instance.OpenExclamationMarkPanel));
		((GObject)ExclamationMarkBtn2nd).onClick.Add(new EventCallback1(FGUIManager.Instance.OpenExclamationMarkPanel));
		((GObject)OpenSoldierBtn).onClick.Add(new EventCallback0(PushPanel));
		((GObject)SoldierInfoPanelClickBtn).onClick.Add(new EventCallback0(OpenSoldierInfoPanel));
		((GObject)SoldierCultivateBtn).onClick.Add(new EventCallback0(OpenSoldierCultivate));
		Timers.inst.Add(0.1f, 0, new TimerCallback(RefreshTime), (object)null);
		SharedMessenger.AddListener<EventContext, string, int>("ON_SOLDIER_SELECTED", OnCampClose);
		SharedMessenger.AddListener<string, int, (StockInContext, string)>("ON_STOCK_CHANGE", RefreshSoldierInfo);
	}

	private void RegisterUiEventListeners_New()
	{
		//IL_001c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0026: Expected O, but got Unknown
		//IL_0042: Unknown result type (might be due to invalid IL or missing references)
		//IL_004c: Expected O, but got Unknown
		//IL_0064: Unknown result type (might be due to invalid IL or missing references)
		//IL_006e: Expected O, but got Unknown
		//IL_008a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0094: Expected O, but got Unknown
		//IL_00ac: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b6: Expected O, but got Unknown
		//IL_00c9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d4: Expected O, but got Unknown
		((GObject)HighLevelPage.ExclamationMarkBtn1st).onClick.Add(new EventCallback1(FGUIManager.Instance.OpenExclamationMarkPanel));
		((GObject)HighLevelPage.ExclamationMarkBtn2nd).onClick.Add(new EventCallback1(FGUIManager.Instance.OpenExclamationMarkPanel));
		((GObject)HighLevelPage.SoldierInfoPanelClickBtn).onClick.Add(new EventCallback0(OpenSoldierInfoPanel));
		((GObject)HighLevelPage.Help).onClick.Add(new EventCallback1(FGUIManager.Instance.OpenExclamationMarkPanel));
		((GObject)HighLevelPage.ShipPlanOccupiedLimit).onClick.Set(new EventCallback0(ShowStockLimitOccupied));
		Timers.inst.Add(0.1f, 0, new TimerCallback(RefreshTime), (object)null);
		SharedMessenger.AddListener<EventContext, string, int>("ON_SOLDIER_SELECTED", OnSoldierSelected);
		SharedMessenger.AddListener<string, int, (StockInContext, string)>("ON_STOCK_CHANGE", RefreshSoldierInfo_New);
	}

	private void UnregisterUiEventListeners_All()
	{
		UnregisterUiEventListeners_Old();
		UnregisterUiEventListeners_New();
	}

	private void UnregisterUiEventListeners_Old()
	{
		//IL_0017: Unknown result type (might be due to invalid IL or missing references)
		//IL_0021: Expected O, but got Unknown
		//IL_0038: Unknown result type (might be due to invalid IL or missing references)
		//IL_0042: Expected O, but got Unknown
		//IL_0055: Unknown result type (might be due to invalid IL or missing references)
		//IL_005f: Expected O, but got Unknown
		//IL_0072: Unknown result type (might be due to invalid IL or missing references)
		//IL_007c: Expected O, but got Unknown
		//IL_008f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0099: Expected O, but got Unknown
		//IL_00a7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b1: Expected O, but got Unknown
		((GObject)ExclamationMarkBtn1st).onClick.Remove(new EventCallback1(FGUIManager.Instance.OpenExclamationMarkPanel));
		((GObject)ExclamationMarkBtn2nd).onClick.Remove(new EventCallback1(FGUIManager.Instance.OpenExclamationMarkPanel));
		((GObject)OpenSoldierBtn).onClick.Remove(new EventCallback0(PushPanel));
		((GObject)SoldierInfoPanelClickBtn).onClick.Remove(new EventCallback0(OpenSoldierInfoPanel));
		((GObject)SoldierCultivateBtn).onClick.Remove(new EventCallback0(OpenSoldierCultivate));
		((GObject)this).onRemovedFromStage.Add((EventCallback0)delegate
		{
			//IL_000d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0017: Expected O, but got Unknown
			Timers.inst.Remove(new TimerCallback(RefreshTime));
		});
		SharedMessenger.RemoveListener<EventContext, string, int>("ON_SOLDIER_SELECTED", OnCampClose);
		SharedMessenger.RemoveListener<string, int, (StockInContext, string)>("ON_STOCK_CHANGE", RefreshSoldierInfo);
	}

	private void UnregisterUiEventListeners_New()
	{
		//IL_001c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0026: Expected O, but got Unknown
		//IL_0042: Unknown result type (might be due to invalid IL or missing references)
		//IL_004c: Expected O, but got Unknown
		//IL_0064: Unknown result type (might be due to invalid IL or missing references)
		//IL_006e: Expected O, but got Unknown
		//IL_008a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0094: Expected O, but got Unknown
		//IL_00b8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c2: Expected O, but got Unknown
		((GObject)HighLevelPage.ExclamationMarkBtn1st).onClick.Remove(new EventCallback1(FGUIManager.Instance.OpenExclamationMarkPanel));
		((GObject)HighLevelPage.ExclamationMarkBtn2nd).onClick.Remove(new EventCallback1(FGUIManager.Instance.OpenExclamationMarkPanel));
		((GObject)HighLevelPage.SoldierInfoPanelClickBtn).onClick.Remove(new EventCallback0(OpenSoldierInfoPanel));
		((GObject)HighLevelPage.Help).onClick.Remove(new EventCallback1(FGUIManager.Instance.OpenExclamationMarkPanel));
		((GObject)HighLevelPage.ShipPlanOccupiedLimit).onClick.Clear();
		((GObject)this).onRemovedFromStage.Add((EventCallback0)delegate
		{
			//IL_000d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0017: Expected O, but got Unknown
			Timers.inst.Remove(new TimerCallback(RefreshTime));
		});
		SharedMessenger.RemoveListener<EventContext, string, int>("ON_SOLDIER_SELECTED", OnSoldierSelected);
		SharedMessenger.RemoveListener<string, int, (StockInContext, string)>("ON_STOCK_CHANGE", RefreshSoldierInfo_New);
	}

	private void RefreshSoldierInfo_New(string itemId, int incr, (StockInContext, string) context)
	{
		if (!IsHighLevel)
		{
			return;
		}
		bool flag = false;
		if (SchemaIndexHelper.GetSchemaById(itemId) == "Soldier")
		{
			GameManagers instance = GameManagers.Instance;
			int stock = instance.StockController.GetStock(itemId);
			int limit = instance.StockController.GetLimit(itemId);
			for (int i = 0; i < _soldierIdsStrings.Length; i++)
			{
				string text = _soldierIdsStrings[i];
				if (!string.IsNullOrEmpty(text) && _amountNums[i] != null && text == itemId)
				{
					((GObject)_amountNums[i]).text = stock.ShortNumberFormat();
					SetNumStatus(((GComponent)HighLevelPage.QueueList).GetChildAt(i).asCom, text);
					bool flag2 = stock >= limit;
					((GComponent)HighLevelPage.QueueList).GetChildAt(i).asCom.GetController("PageController").selectedIndex = (flag2 ? 1 : 0);
					if (!flag2)
					{
						((GComponent)HighLevelPage.QueueList).GetChildAt(i).asCom.GetController("PageController").selectedIndex = (RequirementsNotEnough(soldier.Id) ? 2 : 0);
					}
				}
			}
			if (itemId == _soldierId)
			{
				flag = true;
				((GObject)HighLevelPage.SoldierAmount).text = instance.StockController.GetStock(soldier.Id).ShortNumberFormat() + "/" + instance.StockController.GetLimit(soldier.Id).ShortNumberFormat();
			}
		}
		if (flag || (soldier != null && soldier.WeaponList.Contains(itemId)))
		{
			RenderWeaponList();
		}
	}

	private void IndependentRefreshQueueItem()
	{
		if (!_tempRecruitingData.TryGetValue(listItemIndex, out var value))
		{
			return;
		}
		_soldierId = value;
		GameManagers instance = GameManagers.Instance;
		soldier = instance.SoldierManager.Get(value);
		_soldierIdsStrings[listItemIndex] = value;
		if (!(((GComponent)HighLevelPage.QueueList).GetChildAt(listItemIndex) is UI_com_QueueListItem uI_com_QueueListItem))
		{
			ILRuntimeDebug.LogError("IndependentRefreshQueueItem gComponent is null");
			return;
		}
		GLoader iconLoader = uI_com_QueueListItem.IconLoader.IconLoader;
		iconLoader.fill = (FillType)1;
		iconLoader.url = "ui://PublicResources/" + UiHelper.GetIconPath(soldier.Id);
		((GObject)uI_com_QueueListItem.IconLoader).data = value;
		string iconFrameBorderSoldier = UiHelper.GetIconFrameBorderSoldier(soldier.PotentialLevel);
		uI_com_QueueListItem.FrameLoader.url = "ui://PublicResources/" + iconFrameBorderSoldier;
		UiHelper.LoadSoldierIconFrameMaterial(uI_com_QueueListItem.FrameLoader, soldier.PotentialLevel);
		((GObject)uI_com_QueueListItem.FrameLoader).grayed = false;
		uI_com_QueueListItem.lvFrame.url = UiHelper.GetLevelFrameBorderSoldier(soldier.PotentialLevel);
		FGUIManager.Instance.SetAlightSoulStoneForSoldierIcon(uI_com_QueueListItem.SoulStoneLevel, soldier.PotentialLevel, soldier.PotentialProgress);
		((GObject)uI_com_QueueListItem.InfoGroup).visible = true;
		((GObject)uI_com_QueueListItem.Level_t).text = $"{soldier.Level}";
		((GObject)uI_com_QueueListItem.Amount_t).text = instance.StockController.GetStock(value).ShortNumberFormat();
		SetNumStatus((GComponent)(object)uI_com_QueueListItem, value);
		_amountNums[listItemIndex] = (GTextField)(object)uI_com_QueueListItem.Amount_t;
		((GObject)uI_com_QueueListItem.Mask).visible = true;
		_productImages[listItemIndex] = uI_com_QueueListItem.Mask;
		_productImages[listItemIndex].fillAmount = 0f;
		int stock = instance.StockController.GetStock(soldier.Id);
		int limit = instance.StockController.GetLimit(soldier.Id);
		bool flag = stock >= limit;
		uI_com_QueueListItem.PageController.selectedIndex = (flag ? 1 : 0);
		if (!flag)
		{
			uI_com_QueueListItem.PageController.selectedIndex = (RequirementsNotEnough(soldier.Id) ? 2 : 0);
		}
		for (int i = 0; i < HighLevelPage.QueueList.numItems; i++)
		{
			if (((GComponent)HighLevelPage.QueueList).GetChildAt(i).asCom is UI_com_QueueListItem uI_com_QueueListItem2 && uI_com_QueueListItem2.Status.selectedIndex == 0)
			{
				uI_com_QueueListItem2.Status.selectedIndex = 1;
				break;
			}
		}
		uI_com_QueueListItem.Status.selectedIndex = 0;
	}

	private void UnloadSpine()
	{
		((GObject)HighLevelPage.AnimaPlaceholder).displayObject.Dispose();
	}

	private void LoadAnimation()
	{
		//IL_0079: Unknown result type (might be due to invalid IL or missing references)
		//IL_009e: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00cd: Unknown result type (might be due to invalid IL or missing references)
		//IL_012d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0132: Unknown result type (might be due to invalid IL or missing references)
		//IL_0139: Unknown result type (might be due to invalid IL or missing references)
		//IL_0146: Expected O, but got Unknown
		UnloadSpine();
		GameObject spineObject = default(GameObject);
		ref GameObject reference = ref spineObject;
		Object obj = Object.Instantiate(Resources.Load("SpineTest", typeof(GameObject)));
		reference = (GameObject)(object)((obj is GameObject) ? obj : null);
		if ((Object)(object)spineObject == (Object)null)
		{
			ILRuntimeDebug.LogError("UIHelper.LoadSpine: SpineTest加载失败");
			return;
		}
		spineObject.transform.localScale = new Vector3(45f, 45f, 45f);
		spineObject.transform.localPosition = -new Vector3(0f, 0f, 0f);
		spineObject.transform.localEulerAngles = -new Vector3(0f, 0f, 0f);
		int potentialLevel = soldier.CurrentSpineSkinId;
		SpawnManager.Instance.LoadSoldierSpine(spineObject, $"{_soldierId}_skin{potentialLevel}").Then((Action<SkeletonDataAsset>)delegate(SkeletonDataAsset asset)
		{
			if (!((GObject)this).isDisposed && !((Object)(object)spineObject == (Object)null))
			{
				SkeletonAnimation component = spineObject.GetComponent<SkeletonAnimation>();
				if ((Object)(object)component != (Object)null && (Object)(object)asset != (Object)null)
				{
					((SkeletonRenderer)component).skeletonDataAsset = asset;
					((SkeletonRenderer)component).initialSkinName = $"skin{potentialLevel}";
					((SkeletonRenderer)component).Initialize(true);
					component.AnimationState.SetAnimation(0, "idle", true);
				}
			}
		});
		GoWrapper nativeObject = new GoWrapper(spineObject)
		{
			supportStencil = true,
			scaleX = -1f
		};
		HighLevelPage.AnimaPlaceholder.SetNativeObject((DisplayObject)(object)nativeObject);
	}

	private void RenderSoldierList()
	{
		//IL_0029: Unknown result type (might be due to invalid IL or missing references)
		//IL_0033: Expected O, but got Unknown
		HighLevelPage.QueueList.RemoveChildrenToPool();
		HighLevelPage.QueueList.onClickItem.Add(new EventCallback1(SoldierListItemClick));
		int num = 0;
		GameManagers instance = GameManagers.Instance;
		foreach (KeyValuePair<int, string> tempRecruitingDatum in _tempRecruitingData)
		{
			if (!(HighLevelPage.QueueList.AddItemFromPool() is UI_com_QueueListItem uI_com_QueueListItem))
			{
				continue;
			}
			if (num < RecruitingCamp.Slot)
			{
				if (tempRecruitingDatum.Value == "Unlock" || tempRecruitingDatum.Value == "Lock")
				{
					_soldierIdsStrings[num] = null;
					_productImages[num] = null;
					_amountNums[num] = null;
					uI_com_QueueListItem.FrameLoader.url = "ui://PublicResources/kuang_square_avatar_wood";
					((GObject)uI_com_QueueListItem.IconLoader).data = null;
					uI_com_QueueListItem.IconLoader.IconLoader.url = string.Empty;
					uI_com_QueueListItem.lvFrame.url = "ui://PublicResources/kuang_round 2_lv1";
					((GObject)uI_com_QueueListItem.InfoGroup).visible = false;
					((GObject)uI_com_QueueListItem.Mask).visible = false;
					uI_com_QueueListItem.Status.selectedIndex = 2;
				}
				else
				{
					Soldier soldier = instance.SoldierManager.Get(tempRecruitingDatum.Value);
					_soldierId = tempRecruitingDatum.Value;
					_soldierIdsStrings[num] = tempRecruitingDatum.Value;
					uI_com_QueueListItem.IconLoader.IconLoader.fill = (FillType)1;
					uI_com_QueueListItem.IconLoader.IconLoader.url = "ui://PublicResources/" + UiHelper.GetIconPath(soldier.Id);
					((GObject)uI_com_QueueListItem.IconLoader).data = tempRecruitingDatum.Value;
					string iconFrameBorderSoldier = UiHelper.GetIconFrameBorderSoldier(soldier.PotentialLevel);
					uI_com_QueueListItem.FrameLoader.url = "ui://PublicResources/" + iconFrameBorderSoldier;
					UiHelper.LoadSoldierIconFrameMaterial(uI_com_QueueListItem.FrameLoader, soldier.PotentialLevel);
					uI_com_QueueListItem.lvFrame.url = UiHelper.GetLevelFrameBorderSoldier(soldier.PotentialLevel);
					FGUIManager.Instance.SetAlightSoulStoneForSoldierIcon(uI_com_QueueListItem.SoulStoneLevel, soldier.PotentialLevel, soldier.PotentialProgress);
					((GObject)uI_com_QueueListItem.InfoGroup).visible = true;
					((GObject)uI_com_QueueListItem.Level_t).text = $"{soldier.Level}";
					((GObject)uI_com_QueueListItem.Amount_t).text = instance.StockController.GetStock(tempRecruitingDatum.Value).ShortNumberFormat();
					SetNumStatus((GComponent)(object)uI_com_QueueListItem, tempRecruitingDatum.Value);
					_amountNums[num] = (GTextField)(object)uI_com_QueueListItem.Amount_t;
					((GObject)uI_com_QueueListItem.Mask).visible = true;
					_productImages[num] = uI_com_QueueListItem.Mask;
					int stock = instance.StockController.GetStock(soldier.Id);
					int limit = instance.StockController.GetLimit(soldier.Id);
					bool flag = stock >= limit;
					uI_com_QueueListItem.PageController.selectedIndex = (flag ? 1 : 0);
					if (!flag)
					{
						uI_com_QueueListItem.PageController.selectedIndex = (RequirementsNotEnough(soldier.Id) ? 2 : 0);
					}
					if (_soldierIdsStrings[num] == this.soldier.Id && listItemIndex == num)
					{
						uI_com_QueueListItem.Status.selectedIndex = 0;
					}
					else
					{
						uI_com_QueueListItem.Status.selectedIndex = 1;
					}
				}
			}
			else
			{
				_soldierIdsStrings[num] = null;
				_productImages[num] = null;
				_amountNums[num] = null;
				uI_com_QueueListItem.FrameLoader.url = "ui://PublicResources/kuang_square_avatar_locked";
				((GObject)uI_com_QueueListItem.IconLoader).data = null;
				uI_com_QueueListItem.IconLoader.IconLoader.url = string.Empty;
				uI_com_QueueListItem.lvFrame.url = string.Empty;
				((GObject)uI_com_QueueListItem.InfoGroup).visible = false;
				((GObject)uI_com_QueueListItem.Mask).visible = false;
				uI_com_QueueListItem.Status.selectedIndex = ((num > RecruitingCamp.Slot) ? 4 : 3);
				if (uI_com_QueueListItem.Status.selectedIndex == 3)
				{
					((GObject)uI_com_QueueListItem.RedDot).visible = RecruitingCamp.CanUpgrade() || RecruitingCamp.HasNewMaxLevel();
				}
			}
			num++;
		}
	}

	private void RenderWeaponList()
	{
		//IL_01e5: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d0: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ea: Unknown result type (might be due to invalid IL or missing references)
		//IL_01f2: Unknown result type (might be due to invalid IL or missing references)
		//IL_01f3: Unknown result type (might be due to invalid IL or missing references)
		//IL_021c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0226: Expected O, but got Unknown
		int num = 0;
		HighLevelPage.WeaponList.RemoveChildrenToPool();
		List<string> weaponList = soldier.WeaponList;
		Dictionary<string, float> soldierProductRequirements = Singleton<SoldierProductManager>.Instance.GetSoldierProductRequirements(soldier.Id);
		bool visible = false;
		foreach (string item in weaponList)
		{
			if (!(item != "null") || !(HighLevelPage.WeaponList.AddItemFromPool() is UI_com_WeaponItem uI_com_WeaponItem))
			{
				continue;
			}
			uI_com_WeaponItem.WeaponIconLoader.url = "ui://PublicResources/" + UiHelper.GetIcon(item);
			int weaponEvoLevel = GameManagers.Instance.UserArchiveManager.GetWeaponEvoLevel(item);
			uI_com_WeaponItem.WeaponFrameLoader.url = $"ui://PublicResources/kuang_round 2_lv{weaponEvoLevel}";
			num = GameManagers.Instance.StockController.GetStock(item);
			if (soldierProductRequirements.ContainsKey(item))
			{
				if ((float)num < soldierProductRequirements[item])
				{
					((GObject)uI_com_WeaponItem.WeaponAmount_t).text = $"[color=#DC143C]{num.ShortNumberFormat()}[/color][color=#DC143C]/{soldierProductRequirements[item]}[/color]";
					uI_com_WeaponItem.breathing.Play();
					visible = true;
				}
				else
				{
					((GObject)uI_com_WeaponItem.WeaponAmount_t).text = $"{num.ShortNumberFormat()}/{soldierProductRequirements[item]}";
					uI_com_WeaponItem.breathing.Stop();
					((GObject)uI_com_WeaponItem.WeaponAmount_t).SetScale(1f, 1f);
				}
			}
			else
			{
				((GObject)uI_com_WeaponItem.WeaponAmount_t).text = num.ShortNumberFormat() ?? "";
				Color32 val = ((num == 0) ? new Color32((byte)233, (byte)76, (byte)39, byte.MaxValue) : new Color32((byte)80, (byte)40, (byte)10, byte.MaxValue));
				uI_com_WeaponItem.WeaponAmount_t.color = Color32.op_Implicit(val);
			}
			((GObject)uI_com_WeaponItem.title).text = item;
			((GObject)uI_com_WeaponItem).onClick.Set(new EventCallback1(MaterialIntroductionPanelInit));
		}
		((GObject)HighLevelPage.NotEnough).visible = visible;
	}

	private void RefreshListItemOnUnlock(int listItemIndex, string _id)
	{
		if (!(((GComponent)HighLevelPage.QueueList).GetChildAt(listItemIndex) is UI_com_QueueListItem uI_com_QueueListItem))
		{
			return;
		}
		uI_com_QueueListItem.IconLoader.IconLoader.url = string.Empty;
		((GObject)uI_com_QueueListItem.IconLoader).data = null;
		uI_com_QueueListItem.FrameLoader.url = "ui://PublicResources/kuang_square_avatar_wood";
		((GObject)uI_com_QueueListItem.FrameLoader).grayed = false;
		uI_com_QueueListItem.lvFrame.url = "";
		((GObject)uI_com_QueueListItem.InfoGroup).visible = false;
		((GObject)uI_com_QueueListItem.Level_t).text = string.Empty;
		((GObject)uI_com_QueueListItem.Amount_t).text = string.Empty;
		uI_com_QueueListItem.NumStatus.selectedIndex = 1;
		_amountNums[listItemIndex] = null;
		((GObject)uI_com_QueueListItem.Mask).visible = false;
		GameManagers instance = GameManagers.Instance;
		string text = _soldierIdsStrings[listItemIndex];
		if (!string.IsNullOrEmpty(text))
		{
			int stock = instance.StockController.GetStock(text);
			int limit = instance.StockController.GetLimit(text);
			bool flag = stock >= limit;
			uI_com_QueueListItem.PageController.selectedIndex = (flag ? 1 : 0);
			if (!flag)
			{
				uI_com_QueueListItem.PageController.selectedIndex = (RequirementsNotEnough(soldier.Id) ? 2 : 0);
			}
			if (string.IsNullOrWhiteSpace(_id) || _soldierId == "Unlock" || _soldierId == "Lock")
			{
				uI_com_QueueListItem.PageController.selectedIndex = 0;
			}
			uI_com_QueueListItem.Status.selectedIndex = 2;
		}
	}

	private void RenderSoldierStockLimit()
	{
		//IL_019e: Unknown result type (might be due to invalid IL or missing references)
		int num = Mathf.Abs(GameManagers.Instance.UserArchiveManager.GetGvGShipPlanSoldiersStockLimitOccupiedValue());
		int legionSizeLimit = GameController.Contexts.game.dungeon.value.LegionSizeLimit;
		int num2 = legionSizeLimit + num;
		bool flag = num > 0;
		HighLevelPage.HasShipPlanOccupied.SetSelectedIndex(flag ? 1 : 0);
		if (flag)
		{
			((GObject)HighLevelPage.ShipPlanOccupiedLimit.LeftBracket).text = "(";
			((GObject)HighLevelPage.ShipPlanOccupiedLimit.ShipPlanOccupiedValue).text = num.ToString();
			((GObject)HighLevelPage.ShipPlanOccupiedLimit.StockLimit).text = legionSizeLimit.ToString();
			((GObject)HighLevelPage.ShipPlanOccupiedLimit.RightBracket).text = ")";
		}
		else
		{
			((GObject)HighLevelPage.StockLimit).text = legionSizeLimit.ToString();
		}
		string value = (GameManagers.Instance.UserArchiveManager.DungeonIsLevelMax() ? string.Format(LanguagesManager.GetDesc("SoldierStockLimitMaxTip"), new object[1] { num2 }) : string.Format(LanguagesManager.GetDesc("SoldierStockLimitNextDungeonLevelTip"), new object[3]
		{
			GameManagers.Instance.UserArchiveManager.GetDungeonLevel(),
			num2,
			num2 + GameManagers.Instance.ConfigDataManager.GetDungeonNextLevelSoldierStockIncrement("S001")
		}));
		((GObject)HighLevelPage.Help).data = new Dictionary<string, object>
		{
			{ "Title", value },
			{
				"Pos",
				(object)new Vector2(1239f, 750f)
			}
		};
	}

	private void ShowStockLimitOccupied()
	{
		//IL_001b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0021: Unknown result type (might be due to invalid IL or missing references)
		FairyGUITip.ShowTip((GObject)(object)HighLevelPage.ShipPlanOccupiedLimit, eFairyGUITipDir.Up, delegate(UI_com_UniversalPopupTip popup)
		{
			((GTextField)popup.title).align = (AlignType)1;
			((GObject)popup.title).text = "GvG3_Soldier_StockLimit_Occupied_Tip".ToLanguage();
			((GObject)popup).x = ((GObject)popup).x - ((GObject)HighLevelPage.ShipPlanOccupiedLimit).width / 2f;
		});
	}

	private bool RequirementsNotEnough(string soldierId)
	{
		List<string> list = GameManagers.Instance.SoldierManager.Get(soldierId)?.WeaponList;
		if (list == null)
		{
			return false;
		}
		Dictionary<string, float> soldierProductRequirements = Singleton<SoldierProductManager>.Instance.GetSoldierProductRequirements(soldierId);
		bool result = false;
		foreach (string item in list)
		{
			if (!(item == "null"))
			{
				int stock = GameManagers.Instance.StockController.GetStock(item);
				if (soldierProductRequirements.ContainsKey(item) && (float)stock < soldierProductRequirements[item])
				{
					result = true;
				}
			}
		}
		return result;
	}

	private void ShowTip()
	{
		((GObject)HighLevelPage.tip).visible = SoldierNotHave;
	}

	private void OnSoldierSelected(EventContext context, string solderId, int chosenType)
	{
		if (IsHighLevel && chosenType == 3)
		{
			_soldierId = solderId;
			_tempRecruitingData[listItemIndex] = solderId;
			if (SoldierNotHave)
			{
				InitData(Flag: false, isHide: true);
				RefreshListItemOnUnlock(listItemIndex, _soldierId);
			}
			else
			{
				InitData(Flag: true, isHide: false);
			}
			((GObject)ConfirmBtn).enabled = true;
			ShowTip();
		}
	}

	private void SoldierListItemClick(EventContext context)
	{
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_001d: Expected O, but got Unknown
		//IL_0029: Unknown result type (might be due to invalid IL or missing references)
		//IL_0033: Expected O, but got Unknown
		listItemIndex = ((GComponent)HighLevelPage.QueueList).GetChildIndex((GObject)context.data);
		ListItem = (GComponent)context.data;
		if (ListItem.GetController("Status").selectedIndex != 3 && ListItem.GetController("Status").selectedIndex != 4)
		{
			UiAudioManager.Instance.PlaySoundEffect("GeneralClick");
			if (ListItem.GetChild("IconLoader").data == null)
			{
				PushPanel();
				return;
			}
			if (ListItem.GetController("Status").selectedIndex == 0)
			{
				PushPanel();
				return;
			}
			_soldierId = ListItem.GetChild("IconLoader").data.ToString();
			InitData(Flag: false, SoldierNotHave);
			ShowTip();
			for (int i = 0; i < HighLevelPage.QueueList.numItems; i++)
			{
				GComponent asCom = ((GComponent)HighLevelPage.QueueList).GetChildAt(i).asCom;
				if (asCom.GetController("Status").selectedIndex == 0)
				{
					asCom.GetController("Status").selectedIndex = 1;
					break;
				}
			}
			ListItem.GetController("Status").selectedIndex = 0;
		}
		else if (ListItem.GetController("Status").selectedIndex == 3)
		{
			UpgradeClickEvent();
		}
	}
}
