using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Assets.Scripts.Managers;
using Assets.Scripts.UI;
using FairyGUI;
using FairyGUI.Utils;
using GameDataEditor;
using HotFix;
using HotFix.Sources.Shift.Legion.Shift.Legion.Common.Models.Sources;
using Shift.Legion.ClientApi.Protocol;
using Shift.Legion.ClientApi.Protocol.UserAction;
using Shift.Legion.ClientApi.Sources.Protocol;
using Shift.Legion.Common.Managers;
using Shift.Legion.Common.Models;
using Shift.Legion.Common.Services;
using Shift.Legion.Common.Sources.Enums;
using Spine.Unity;
using UI.Mail;
using UI.MonthCard;
using UI.Tips;
using UI.UpGrade;
using UnityEngine;

namespace UI.RecyclingCenter;

public class UI_RecyclingCenterPanel : GComponent, IUiController
{
	public Controller Status;

	public Controller isShowMedal;

	public GImage back1;

	public GLoader background;

	public GButton backBtn;

	public UI_Title Title;

	public GButton upButton;

	public GGroup nameGroup;

	public GComponent addWorkerBtn;

	public GImage listBackground;

	public GImage n73;

	public GGroup crackAndBack;

	public GImage station;

	public GTextField remainingStation;

	public GImage n4;

	public GTextField numbers;

	public GGroup n78;

	public GButton ExclamationMarkBtn;

	public GGraph numbersSpine;

	public GGroup bottomGruop;

	public UI_confirm yesBtn;

	public GLoader friendInfoBg;

	public GTextField name;

	public UI_com_ChatIcon n54;

	public UI_com_MedalIcon medalIcon;

	public UI_MessageBtn sendMessageBtn;

	public GGroup n82;

	public GGroup n58;

	public GTextField tip1;

	public GList CardList;

	public UI_RefreshCardBtn VisitBtn;

	public GGraph n35;

	public GImage n77;

	public GImage n36;

	public GGraph recycleSfxBack;

	public GGraph recycleSfxBtn;

	public GGraph n37;

	public GTextField n38;

	public GList BriefVisitorsList;

	public GTextField tip2;

	public GTextField tip5;

	public GImage n72;

	public GGraph n71;

	public GImage n70;

	public GTextField time;

	public GTextField tip3;

	public UI_SwitchBtn SwitchBtn;

	public GImage n43;

	public GTextField moenyNum;

	public GTextField tip4;

	public GImage n47;

	public GTextField earnings;

	public UI_increase increase;

	public UI_reduce reduce;

	public GList workersBackList;

	public GList workersList;

	public GTextField n59;

	public GTextField n68;

	public GGraph workUI;

	public GGraph ScreenSfxBack;

	public Transition numbersHeightLight;

	public const string URL = "ui://72poq8plkxixg";

	public static string Name = "UI_RecyclingCenterPanel";

	private Coroutine showCardListCoroutine;

	private List<string> _textureList = new List<string>();

	private MoltenCore MoltenCoreBuilding;

	private UI_VisitPanel visitPanel;

	private UI_VisitorsPanel visitorsPanel = null;

	private UI_ConfirmationPopup ConfirmationPopup;

	private Coroutine TimeLimitRemainingCoroutine;

	private int curCheckId;

	public List<RecycleDailyProduceStat> recycleStats = new List<RecycleDailyProduceStat>();

	public List<UserInfo> friendsList = new List<UserInfo>();

	public Dictionary<int, AvatarAndNameCache> AvatarAndNameCachingMap = new Dictionary<int, AvatarAndNameCache>();

	private List<RecycleProduct> curProductDatas = new List<RecycleProduct>();

	private int outPutSelf;

	private Dictionary<string, ProductionConfig> ProductConfig;

	private Dictionary<string, ProductionConfig> NewProductConfig;

	private readonly List<string> chosenList = new List<string>();

	private List<string> chosenClone = new List<string>();

	private GoWrapper gw1;

	private GameObject canvasObject;

	private bool toUnloadAni;

	private UserInfo OtherInfo;

	private const int NickNameMaxLength = 14;

	private bool MultiplayerSwitchEnabled
	{
		get
		{
			bool result = false;
			string value = GameManagers.Instance.RecycleManager.AutoEnableMultiplayerAt.GetValue();
			foreach (List<string> value2 in GameManagers.Instance.UserArchiveManager.GetLevelProgress().Values)
			{
				if (value2.Contains(value))
				{
					result = true;
					break;
				}
			}
			return result;
		}
	}

	public void SetControllerPageText()
	{
		string id = string.Format("{0}-{1}-{2}", "ui://72poq8plkxixg".Replace("ui://", ""), ((GObject)tip1).id, Status.selectedIndex);
		((GObject)tip1).text = LanguagesManager.GetDesc(id);
		string text = ((Status.selectedIndex >= 4) ? Status.selectedIndex.ToString() : "def");
		string id2 = "ui://72poq8plkxixg".Replace("ui://", "") + "-" + ((GObject)tip2).id + "-" + text;
		((GObject)tip2).text = LanguagesManager.GetDesc(id2);
	}

	public static string GetURL()
	{
		return "ui://72poq8plkxixg";
	}

	public static UI_RecyclingCenterPanel CreateInstance()
	{
		return (UI_RecyclingCenterPanel)(object)UIPackage.CreateObject("RecyclingCenter", "RecyclingCenterPanel");
	}

	public static UI_RecyclingCenterPanel CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_RecyclingCenterPanel).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://72poq8plkxixg", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		//IL_0129: Unknown result type (might be due to invalid IL or missing references)
		//IL_0133: Expected O, but got Unknown
		//IL_017c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0186: Expected O, but got Unknown
		//IL_0192: Unknown result type (might be due to invalid IL or missing references)
		//IL_019c: Expected O, but got Unknown
		//IL_01a8: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b2: Expected O, but got Unknown
		//IL_01be: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c8: Expected O, but got Unknown
		//IL_01d4: Unknown result type (might be due to invalid IL or missing references)
		//IL_01de: Expected O, but got Unknown
		//IL_01ea: Unknown result type (might be due to invalid IL or missing references)
		//IL_01f4: Expected O, but got Unknown
		//IL_0216: Unknown result type (might be due to invalid IL or missing references)
		//IL_0220: Expected O, but got Unknown
		//IL_022c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0236: Expected O, but got Unknown
		//IL_02c1: Unknown result type (might be due to invalid IL or missing references)
		//IL_02cb: Expected O, but got Unknown
		//IL_02d7: Unknown result type (might be due to invalid IL or missing references)
		//IL_02e1: Expected O, but got Unknown
		//IL_02ed: Unknown result type (might be due to invalid IL or missing references)
		//IL_02f7: Expected O, but got Unknown
		//IL_0340: Unknown result type (might be due to invalid IL or missing references)
		//IL_034a: Expected O, but got Unknown
		//IL_036c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0376: Expected O, but got Unknown
		//IL_0382: Unknown result type (might be due to invalid IL or missing references)
		//IL_038c: Expected O, but got Unknown
		//IL_0398: Unknown result type (might be due to invalid IL or missing references)
		//IL_03a2: Expected O, but got Unknown
		//IL_03ae: Unknown result type (might be due to invalid IL or missing references)
		//IL_03b8: Expected O, but got Unknown
		//IL_03c4: Unknown result type (might be due to invalid IL or missing references)
		//IL_03ce: Expected O, but got Unknown
		//IL_03da: Unknown result type (might be due to invalid IL or missing references)
		//IL_03e4: Expected O, but got Unknown
		//IL_03f0: Unknown result type (might be due to invalid IL or missing references)
		//IL_03fa: Expected O, but got Unknown
		//IL_0443: Unknown result type (might be due to invalid IL or missing references)
		//IL_044d: Expected O, but got Unknown
		//IL_0459: Unknown result type (might be due to invalid IL or missing references)
		//IL_0463: Expected O, but got Unknown
		//IL_04ae: Unknown result type (might be due to invalid IL or missing references)
		//IL_04b8: Expected O, but got Unknown
		//IL_0503: Unknown result type (might be due to invalid IL or missing references)
		//IL_050d: Expected O, but got Unknown
		//IL_0519: Unknown result type (might be due to invalid IL or missing references)
		//IL_0523: Expected O, but got Unknown
		//IL_052f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0539: Expected O, but got Unknown
		//IL_0545: Unknown result type (might be due to invalid IL or missing references)
		//IL_054f: Expected O, but got Unknown
		//IL_055b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0565: Expected O, but got Unknown
		//IL_05c6: Unknown result type (might be due to invalid IL or missing references)
		//IL_05d0: Expected O, but got Unknown
		//IL_05dc: Unknown result type (might be due to invalid IL or missing references)
		//IL_05e6: Expected O, but got Unknown
		//IL_05f2: Unknown result type (might be due to invalid IL or missing references)
		//IL_05fc: Expected O, but got Unknown
		//IL_0647: Unknown result type (might be due to invalid IL or missing references)
		//IL_0651: Expected O, but got Unknown
		//IL_065d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0667: Expected O, but got Unknown
		//IL_06de: Unknown result type (might be due to invalid IL or missing references)
		//IL_06e8: Expected O, but got Unknown
		//IL_06f4: Unknown result type (might be due to invalid IL or missing references)
		//IL_06fe: Expected O, but got Unknown
		//IL_070a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0714: Expected O, but got Unknown
		//IL_075f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0769: Expected O, but got Unknown
		//IL_07b4: Unknown result type (might be due to invalid IL or missing references)
		//IL_07be: Expected O, but got Unknown
		//IL_07ca: Unknown result type (might be due to invalid IL or missing references)
		//IL_07d4: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		Status = ((GComponent)this).GetController("Status");
		isShowMedal = ((GComponent)this).GetController("isShowMedal");
		back1 = (GImage)((GComponent)this).GetChild("back1");
		background = (GLoader)((GComponent)this).GetChild("background");
		backBtn = (GButton)((GComponent)this).GetChild("backBtn");
		Title = (UI_Title)(object)((GComponent)this).GetChild("Title");
		upButton = (GButton)((GComponent)this).GetChild("upButton");
		nameGroup = (GGroup)((GComponent)this).GetChild("nameGroup");
		addWorkerBtn = (GComponent)((GComponent)this).GetChild("addWorkerBtn");
		listBackground = (GImage)((GComponent)this).GetChild("listBackground");
		n73 = (GImage)((GComponent)this).GetChild("n73");
		crackAndBack = (GGroup)((GComponent)this).GetChild("crackAndBack");
		station = (GImage)((GComponent)this).GetChild("station");
		remainingStation = (GTextField)((GComponent)this).GetChild("remainingStation");
		string id = "ui://72poq8plkxixg".Replace("ui://", "") + "-" + ((GObject)remainingStation).id;
		((GObject)remainingStation).text = LanguagesManager.GetDesc(id);
		n4 = (GImage)((GComponent)this).GetChild("n4");
		numbers = (GTextField)((GComponent)this).GetChild("numbers");
		n78 = (GGroup)((GComponent)this).GetChild("n78");
		ExclamationMarkBtn = (GButton)((GComponent)this).GetChild("ExclamationMarkBtn");
		numbersSpine = (GGraph)((GComponent)this).GetChild("numbersSpine");
		bottomGruop = (GGroup)((GComponent)this).GetChild("bottomGruop");
		yesBtn = (UI_confirm)(object)((GComponent)this).GetChild("yesBtn");
		friendInfoBg = (GLoader)((GComponent)this).GetChild("friendInfoBg");
		name = (GTextField)((GComponent)this).GetChild("name");
		string id2 = "ui://72poq8plkxixg".Replace("ui://", "") + "-" + ((GObject)name).id;
		((GObject)name).text = LanguagesManager.GetDesc(id2);
		n54 = (UI_com_ChatIcon)(object)((GComponent)this).GetChild("n54");
		medalIcon = (UI_com_MedalIcon)(object)((GComponent)this).GetChild("medalIcon");
		sendMessageBtn = (UI_MessageBtn)(object)((GComponent)this).GetChild("sendMessageBtn");
		n82 = (GGroup)((GComponent)this).GetChild("n82");
		n58 = (GGroup)((GComponent)this).GetChild("n58");
		tip1 = (GTextField)((GComponent)this).GetChild("tip1");
		string id3 = "ui://72poq8plkxixg".Replace("ui://", "") + "-" + ((GObject)tip1).id;
		((GObject)tip1).text = LanguagesManager.GetDesc(id3);
		CardList = (GList)((GComponent)this).GetChild("CardList");
		VisitBtn = (UI_RefreshCardBtn)(object)((GComponent)this).GetChild("VisitBtn");
		n35 = (GGraph)((GComponent)this).GetChild("n35");
		n77 = (GImage)((GComponent)this).GetChild("n77");
		n36 = (GImage)((GComponent)this).GetChild("n36");
		recycleSfxBack = (GGraph)((GComponent)this).GetChild("recycleSfxBack");
		recycleSfxBtn = (GGraph)((GComponent)this).GetChild("recycleSfxBtn");
		n37 = (GGraph)((GComponent)this).GetChild("n37");
		n38 = (GTextField)((GComponent)this).GetChild("n38");
		string id4 = "ui://72poq8plkxixg".Replace("ui://", "") + "-" + ((GObject)n38).id;
		((GObject)n38).text = LanguagesManager.GetDesc(id4);
		BriefVisitorsList = (GList)((GComponent)this).GetChild("BriefVisitorsList");
		tip2 = (GTextField)((GComponent)this).GetChild("tip2");
		string id5 = "ui://72poq8plkxixg".Replace("ui://", "") + "-" + ((GObject)tip2).id;
		((GObject)tip2).text = LanguagesManager.GetDesc(id5);
		tip5 = (GTextField)((GComponent)this).GetChild("tip5");
		string id6 = "ui://72poq8plkxixg".Replace("ui://", "") + "-" + ((GObject)tip5).id;
		((GObject)tip5).text = LanguagesManager.GetDesc(id6);
		n72 = (GImage)((GComponent)this).GetChild("n72");
		n71 = (GGraph)((GComponent)this).GetChild("n71");
		n70 = (GImage)((GComponent)this).GetChild("n70");
		time = (GTextField)((GComponent)this).GetChild("time");
		tip3 = (GTextField)((GComponent)this).GetChild("tip3");
		string id7 = "ui://72poq8plkxixg".Replace("ui://", "") + "-" + ((GObject)tip3).id;
		((GObject)tip3).text = LanguagesManager.GetDesc(id7);
		SwitchBtn = (UI_SwitchBtn)(object)((GComponent)this).GetChild("SwitchBtn");
		n43 = (GImage)((GComponent)this).GetChild("n43");
		moenyNum = (GTextField)((GComponent)this).GetChild("moenyNum");
		tip4 = (GTextField)((GComponent)this).GetChild("tip4");
		string id8 = "ui://72poq8plkxixg".Replace("ui://", "") + "-" + ((GObject)tip4).id;
		((GObject)tip4).text = LanguagesManager.GetDesc(id8);
		n47 = (GImage)((GComponent)this).GetChild("n47");
		earnings = (GTextField)((GComponent)this).GetChild("earnings");
		string id9 = "ui://72poq8plkxixg".Replace("ui://", "") + "-" + ((GObject)earnings).id;
		((GObject)earnings).text = LanguagesManager.GetDesc(id9);
		increase = (UI_increase)(object)((GComponent)this).GetChild("increase");
		reduce = (UI_reduce)(object)((GComponent)this).GetChild("reduce");
		workersBackList = (GList)((GComponent)this).GetChild("workersBackList");
		workersList = (GList)((GComponent)this).GetChild("workersList");
		n59 = (GTextField)((GComponent)this).GetChild("n59");
		string id10 = "ui://72poq8plkxixg".Replace("ui://", "") + "-" + ((GObject)n59).id;
		((GObject)n59).text = LanguagesManager.GetDesc(id10);
		n68 = (GTextField)((GComponent)this).GetChild("n68");
		string id11 = "ui://72poq8plkxixg".Replace("ui://", "") + "-" + ((GObject)n68).id;
		((GObject)n68).text = LanguagesManager.GetDesc(id11);
		workUI = (GGraph)((GComponent)this).GetChild("workUI");
		ScreenSfxBack = (GGraph)((GComponent)this).GetChild("ScreenSfxBack");
		numbersHeightLight = ((GComponent)this).GetTransition("numbersHeightLight");
	}

	public void BeforeDestroy()
	{
		if (TimeLimitRemainingCoroutine != null)
		{
			FGUIManager.Instance.CloseIEnumerator(TimeLimitRemainingCoroutine);
		}
	}

	public void Destroy()
	{
		UiAudioManager.Instance.SetMainCityBgmVolume(UiAudioManager.Instance.MaxUiBgmVolume);
	}

	public void Init(Dictionary<string, object> parameters)
	{
		FGUIManager.SetUiPanelSizeAndXy((GObject)(object)this);
		if (parameters.TryGetValue("SortingOrder", out var value))
		{
			((GObject)this).sortingOrder = (int)value;
		}
		else
		{
			((GObject)this).sortingOrder = 1;
		}
		if (GameController.Configs.TryGetValue("RFB", out var value2) && value2 == "0")
		{
			((GObject)VisitBtn).visible = false;
		}
		else
		{
			((GObject)VisitBtn).visible = true;
		}
		MoltenCoreBuilding = GameManagers.Instance.BuildingManager.GetBuildingByType("17") as MoltenCore;
		ILRequestHelper<GetRecycleProductsResponse>.Request((EventContext)null, (Func<Task<GetRecycleProductsResponse>>)(() => GameController.Contexts.Service<INetworkService>().GetRecycleProducts(GameController.Contexts.gameState.user.value.UserId)), (Action<GetRecycleProductsResponse>)delegate(GetRecycleProductsResponse response)
		{
			if (!response.Result)
			{
				if (response.ErrorCode != 0)
				{
					ILRequestHelper.ShowErrorCode(response.ErrorCode);
				}
			}
			else
			{
				SetBuildingName();
				CheckWorkersCanAssign();
				InitWorkerSpine();
				((GObject)yesBtn).enabled = false;
				ProductConfig = MoltenCoreBuilding.ProductionConfigs;
				NewProductConfig = new Dictionary<string, ProductionConfig>();
				foreach (string key in ProductConfig.Keys)
				{
					NewProductConfig.Add(key, ProductConfig[key].Clone());
				}
				ChosenListInit();
				GameManagers.Instance.RecycleManager.RecycleExportTo.SetValue(response.RecycleExportTo);
				curCheckId = GameManagers.Instance.RecycleManager.RecycleExportTo.GetValue();
				UpdateMainPanel(curCheckId, isInit: true);
				if (Status.selectedIndex == 1 || Status.selectedIndex == 2)
				{
					CurUserInfoInit();
				}
			}
		});
	}

	public void OnShow()
	{
		if (TimeLimitRemainingCoroutine != null)
		{
			FGUIManager.Instance.CloseIEnumerator(TimeLimitRemainingCoroutine);
		}
		TimeLimitRemainingCoroutine = FGUIManager.Instance.OpenIEnumerator(RefreshTimeLimitRemaining());
		UiAudioManager.Instance.SetMainCityBgmVolume(UiAudioManager.Instance.MiddleBgmVolume);
		UiAudioManager.Instance.PlayBackgroundSound("Building" + MoltenCoreBuilding.BuildingType + "_Click");
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
		//IL_009f: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a9: Expected O, but got Unknown
		//IL_00bc: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c6: Expected O, but got Unknown
		//IL_00d9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e3: Expected O, but got Unknown
		//IL_00fa: Unknown result type (might be due to invalid IL or missing references)
		//IL_0104: Expected O, but got Unknown
		//IL_0117: Unknown result type (might be due to invalid IL or missing references)
		//IL_0121: Expected O, but got Unknown
		//IL_0134: Unknown result type (might be due to invalid IL or missing references)
		//IL_013e: Expected O, but got Unknown
		//IL_0151: Unknown result type (might be due to invalid IL or missing references)
		//IL_015b: Expected O, but got Unknown
		//IL_016e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0178: Expected O, but got Unknown
		//IL_018b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0195: Expected O, but got Unknown
		//IL_01a8: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b2: Expected O, but got Unknown
		((GObject)backBtn).onClick.Add(new EventCallback0(BackEvent));
		((GObject)upButton).onClick.Add(new EventCallback0(UpGrade));
		((GObject)addWorkerBtn).onClick.Add(new EventCallback0(OpenWorkerOverview));
		addWorkerBtn.GetChild("addButton").onClick.Add(new EventCallback1(AddWorker));
		addWorkerBtn.GetChild("ExclamationMarkBtn").onClick.Add(new EventCallback1(FGUIManager.Instance.OpenExclamationMarkPanel));
		((GObject)increase).onClick.Add(new EventCallback0(increaseWorker));
		((GObject)reduce).onClick.Add(new EventCallback0(reduceWorker));
		((GObject)ExclamationMarkBtn).onClick.Add(new EventCallback1(FGUIManager.Instance.OpenExclamationMarkPanel));
		((GObject)VisitBtn).onClick.Add(new EventCallback0(VisitPanelInit));
		((GObject)BriefVisitorsList).onClick.Add(new EventCallback0(VisitorPanelInit));
		((GObject)yesBtn).onClick.Add(new EventCallback1(WorkerDeployment));
		((GObject)recycleSfxBtn).onClick.Add(new EventCallback1(ReLinkTip));
		((GObject)SwitchBtn).onClick.Add(new EventCallback1(MainSwitchVisit));
		((GObject)friendInfoBg).onClick.Set(new EventCallback0(OnClickSendMessage));
		SharedMessenger.AddListener<Building>("WORKERS_ALLOCATION_DISPLAY_CHANGED", UpdateWorkerNum);
		SharedMessenger.AddListener<string, int, (StockInContext, string)>("ON_STOCK_CHANGE", OnStockChange);
		SharedMessenger.AddListener("OPEN_WORKER_OVERVIEW_PANEL", OpenWorkerOverview);
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
		//IL_009f: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a9: Expected O, but got Unknown
		//IL_00bc: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c6: Expected O, but got Unknown
		//IL_00d9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e3: Expected O, but got Unknown
		//IL_00fa: Unknown result type (might be due to invalid IL or missing references)
		//IL_0104: Expected O, but got Unknown
		//IL_0117: Unknown result type (might be due to invalid IL or missing references)
		//IL_0121: Expected O, but got Unknown
		//IL_0134: Unknown result type (might be due to invalid IL or missing references)
		//IL_013e: Expected O, but got Unknown
		//IL_0151: Unknown result type (might be due to invalid IL or missing references)
		//IL_015b: Expected O, but got Unknown
		//IL_016e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0178: Expected O, but got Unknown
		//IL_018b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0195: Expected O, but got Unknown
		((GObject)backBtn).onClick.Remove(new EventCallback0(BackEvent));
		((GObject)upButton).onClick.Remove(new EventCallback0(UpGrade));
		((GObject)addWorkerBtn).onClick.Remove(new EventCallback0(OpenWorkerOverview));
		addWorkerBtn.GetChild("addButton").onClick.Remove(new EventCallback1(AddWorker));
		addWorkerBtn.GetChild("ExclamationMarkBtn").onClick.Remove(new EventCallback1(FGUIManager.Instance.OpenExclamationMarkPanel));
		((GObject)increase).onClick.Remove(new EventCallback0(increaseWorker));
		((GObject)reduce).onClick.Remove(new EventCallback0(reduceWorker));
		((GObject)ExclamationMarkBtn).onClick.Remove(new EventCallback1(FGUIManager.Instance.OpenExclamationMarkPanel));
		((GObject)VisitBtn).onClick.Remove(new EventCallback0(VisitPanelInit));
		((GObject)BriefVisitorsList).onClick.Remove(new EventCallback0(VisitorPanelInit));
		((GObject)yesBtn).onClick.Remove(new EventCallback1(WorkerDeployment));
		((GObject)recycleSfxBtn).onClick.Remove(new EventCallback1(ReLinkTip));
		((GObject)SwitchBtn).onClick.Remove(new EventCallback1(MainSwitchVisit));
		((GObject)friendInfoBg).onClick.Clear();
		SharedMessenger.RemoveListener<Building>("WORKERS_ALLOCATION_DISPLAY_CHANGED", UpdateWorkerNum);
		SharedMessenger.RemoveListener<string, int, (StockInContext, string)>("ON_STOCK_CHANGE", OnStockChange);
		SharedMessenger.RemoveListener("OPEN_WORKER_OVERVIEW_PANEL", OpenWorkerOverview);
	}

	private void BackEvent()
	{
		if (MoltenCoreBuilding.CheckNewProductionConfigsChange(NewProductConfig))
		{
			GameController.Contexts.Service<IUiService>().OpenPanel(UI_UniversalConfirmPopup.Name, new Dictionary<string, object>
			{
				{
					"Content",
					LanguagesManager.GetDesc("CsharpCodeZhTcText162") + LanguagesManager.Comma + LanguagesManager.GetDesc("CsharpCodeZhTcText163") + "？"
				},
				{
					"Buttons",
					new Dictionary<string, Action>
					{
						{
							"Confirm",
							delegate
							{
								((GObject)yesBtn).onClick.Call();
							}
						},
						{
							"Cancel",
							delegate
							{
								End();
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
			End();
		}
	}

	public void End()
	{
		GameController.Contexts.Service<IUiService>().ClosePanel(Name, reservePackageRes: true);
		if (toUnloadAni)
		{
			SpawnManager.Instance.UnloadAnimation("Goblinworker_UI_001");
		}
		for (int i = 0; i < _textureList.Count; i++)
		{
			AssetsManager.Instance.UnloadAsset<Texture2D>(_textureList[i]);
		}
	}

	private void SetBuildingName()
	{
		((GObject)Title.buildingName).text = MoltenCoreBuilding.Name ?? "";
		Title.icon.url = "ui://PublicResources/Building" + MoltenCoreBuilding.BuildingType;
		((GObject)((GComponent)upButton).GetChild("level").asTextField).text = MoltenCoreBuilding.Level.ToString();
	}

	public void CheckWorkersCanAssign()
	{
		//IL_0189: Unknown result type (might be due to invalid IL or missing references)
		//IL_018e: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ab: Unknown result type (might be due to invalid IL or missing references)
		//IL_0130: Unknown result type (might be due to invalid IL or missing references)
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
					LanguagesManager.GetDesc("CsharpCodeZhTcText153") + Environment.NewLine + string.Format("{0}：{1}", LanguagesManager.GetDesc("CsharpCodeZhTcText164"), Dungeon.GetTotalManPower(GameManagers.Instance) - GameManagers.Instance.LeaseholdManager.GetLeaseholdManPower())
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

	private void UpdateWorkerNum(Building building)
	{
		CheckWorkersCanAssign();
		if (building.BuildingType == MoltenCoreBuilding.BuildingType)
		{
			UpdateMainUi();
		}
	}

	private void UpdateMainUi()
	{
		((GObject)yesBtn).enabled = false;
		ProductConfig = MoltenCoreBuilding.ProductionConfigs;
		NewProductConfig = new Dictionary<string, ProductionConfig>();
		foreach (string key in ProductConfig.Keys)
		{
			NewProductConfig.Add(key, ProductConfig[key].Clone());
		}
		ChosenListInit();
		UpdateMainPanel(curCheckId, isInit: true);
	}

	private void GetWorkingStatus(int a, int b, int c)
	{
		//IL_011d: Unknown result type (might be due to invalid IL or missing references)
		((GObject)numbers).text = $"{a}/{b}";
		if (c > 0)
		{
			((GObject)numbers).text = $"{a}/{b}[color=#AFF627]+{c}[/color]";
			((GObject)ExclamationMarkBtn).visible = true;
			((GObject)ExclamationMarkBtn).data = new Dictionary<string, object>
			{
				{
					"Title",
					LanguagesManager.GetDesc("CsharpCodeZhTcText106") + Environment.NewLine + string.Format("{0}：{1}", LanguagesManager.GetDesc("CsharpCodeZhTcText165"), b)
				},
				{
					"Content1",
					string.Format("  {0} +{1}", LanguagesManager.GetDesc("CsharpCodeZhTcText166"), MoltenCoreBuilding.Slot)
				},
				{
					"Content2",
					string.Format("  {0} [color=#AFF627]+{1}[/color]", LanguagesManager.GetDesc("CsharpCodeZhTcText167"), MoltenCoreBuilding.LeaseholdSlot)
				},
				{
					"Pos",
					(object)new Vector2(368f, 810f)
				}
			};
		}
		else
		{
			((GObject)numbers).text = $"{a}/{b}";
			((GObject)ExclamationMarkBtn).visible = false;
		}
	}

	private void OpenWorkerOverview()
	{
		Dictionary<string, object> dictionary = new Dictionary<string, object>();
		dictionary.Add("Order", ((GObject)this).sortingOrder);
		GameController.Contexts.Service<IUiService>().OpenPanel(UI_WorkersOverviewPanel.Name, dictionary);
	}

	private void AddWorker(EventContext context)
	{
		if (GameManagers.Instance.BuildingManager.GetBuildingByType("16").Level > 0)
		{
			GameController.Contexts.Service<IUiService>().OpenPanel(UI_MonthCardPanel.Name, new Dictionary<string, object>
			{
				{
					"Activity",
					FGUIManager.Instance.GetBlackMarketerActivity("UI_MonthCardPanel")
				},
				{
					"Order",
					((GObject)this).sortingOrder
				},
				{ "Parent", this }
			});
		}
		else
		{
			List<string> arg = new List<string> { LanguagesManager.GetDesc("CsharpCodeZhTcText152") };
			SharedMessenger.Broadcast("SHOW_TIPS", arg, ((GObject)this).sortingOrder + 1, arg3: false);
		}
		context.StopPropagation();
	}

	private void UpGrade()
	{
		Dictionary<string, object> dictionary = new Dictionary<string, object>();
		dictionary.Add("Parent", this);
		dictionary.Add("Building", MoltenCoreBuilding);
		dictionary.Add("SortingOrder", ((GObject)this).sortingOrder);
		GameController.Contexts.Service<IUiService>().OpenPanel(UI_Main_UpGradePanel.Name, dictionary);
	}

	private async void BriefVisitorsListRender(int linkId)
	{
		BriefVisitorsList.numItems = 0;
		if (!GameManagers.Instance.RecycleManager.RecycleEnableMultiplayer.GetValue())
		{
			((GObject)tip5).visible = true;
			GetVisitorsNum();
			MainPanelSwitchBtnInit();
			return;
		}
		GetRecycleStatsResponse response = await GameController.Contexts.Service<INetworkService>().GetRecycleStats(linkId);
		if (response.Result && response.RecycleStats != null)
		{
			UpdateRecycleStats(response.RecycleStats);
			BriefVisitorsList.itemRenderer = new ListItemRenderer(RenderBriefVisitorItem);
			BriefVisitorsList.numItems = ((recycleStats.Count >= 3) ? 3 : recycleStats.Count);
			if (recycleStats.Count > 0)
			{
				((GObject)tip5).visible = false;
				MainPanelSwitchBtnInit();
			}
			else
			{
				((GObject)tip5).visible = true;
				GetVisitorsNum(isMultiplayerEnable: true);
				MainPanelSwitchBtnInit();
			}
		}
		else
		{
			((GObject)tip5).visible = true;
			GetVisitorsNum(isMultiplayerEnable: true);
			MainPanelSwitchBtnInit();
		}
	}

	private async void GetVisitorsNum(bool isMultiplayerEnable = false)
	{
		if (isMultiplayerEnable)
		{
			((GObject)tip5).text = LanguagesManager.GetDesc("CsharpCodeZhTcText528");
			((GObject)tip5).y = 765f;
			return;
		}
		((GObject)tip5).y = 725f;
		GetTotalRecycleExportRequestResponse response = await GameController.Contexts.Service<INetworkService>().GetTotalRecycleExportRequest();
		if (response.Result)
		{
			if (response.RequestCnt > 0)
			{
				tip5.UBBEnabled = true;
				((GObject)tip5).text = string.Format("{0}[color=#FF1919]{1}[/color]{2}", LanguagesManager.GetDesc("CsharpCodeZhTcText529"), response.RequestCnt, LanguagesManager.GetDesc("CsharpCodeZhTcText530"));
			}
			else
			{
				((GObject)tip5).text = "";
			}
		}
		else
		{
			((GObject)tip5).text = "";
		}
	}

	private void RenderBriefVisitorItem(int index, GObject obj)
	{
		GButton asButton = obj.asButton;
		RecycleDailyProduceStat recycleDailyProduceStat = recycleStats[index];
		((GComponent)asButton).GetChild("level").text = recycleDailyProduceStat.UserLevel.ToString();
		((GComponent)asButton).GetChild("name").text = recycleDailyProduceStat.Nickname;
		((GComponent)asButton).GetChild("num").text = recycleDailyProduceStat.DailyProd.ShortNumberFormat() ?? "";
		UI_BriefVisitorItem uI_BriefVisitorItem = (UI_BriefVisitorItem)(object)asButton;
		FGUIManager.Instance.GetUserMedal(recycleDailyProduceStat.UserId, uI_BriefVisitorItem.n7);
	}

	private void CardListRender()
	{
		ILRequestHelper<GetRecycleProductsResponse>.Request((EventContext)null, (Func<Task<GetRecycleProductsResponse>>)(() => GameController.Contexts.Service<INetworkService>().GetRecycleProducts(curCheckId)), (Action<GetRecycleProductsResponse>)delegate(GetRecycleProductsResponse response)
		{
			if (!response.Result || response.Products == null)
			{
				if (response.ErrorCode != 0)
				{
					ILRequestHelper.ShowErrorCode(response.ErrorCode);
				}
			}
			else if (!((GObject)this).isDisposed)
			{
				curProductDatas.Clear();
				foreach (string product in response.Products)
				{
					if (RecycleManager.RecycleProducts.TryGetValue(product, out var value))
					{
						int i;
						for (i = 0; i < curProductDatas.Count; i++)
						{
							RecycleProduct recycleProduct = curProductDatas[i];
							if (recycleProduct.Multiplier < value.Multiplier || (recycleProduct.Multiplier == value.Multiplier && recycleProduct.Productions["Money"] <= value.Productions["Money"]))
							{
								break;
							}
						}
						curProductDatas.Insert(i, value);
					}
				}
				GameManagers.Instance.RecycleManager.RecycleExportTo.SetValue(response.RecycleExportTo);
				RenderCardList();
			}
		});
	}

	private void RenderCardList()
	{
		CardList.RemoveChildrenToPool();
		if (showCardListCoroutine != null)
		{
			FGUIManager.Instance.CloseIEnumerator(showCardListCoroutine);
		}
		showCardListCoroutine = FGUIManager.Instance.OpenIEnumerator(ShowCardList());
	}

	private IEnumerator ShowCardList()
	{
		for (int i = 0; i < curProductDatas.Count; i++)
		{
			if (((GObject)this).isDisposed || ((GObject)CardList).isDisposed)
			{
				break;
			}
			GObject item = CardList.AddItemFromPool();
			item.touchable = false;
			item.alpha = 0f;
			if (RenderCardItem(i, item))
			{
				item.TweenFade(1f, 0.1f).OnComplete((GTweenCallback)delegate
				{
					item.touchable = true;
				});
			}
			else
			{
				CardList.RemoveChildToPool(item);
			}
			yield return null;
		}
	}

	private bool RenderCardItem(int index, GObject obj)
	{
		//IL_0227: Unknown result type (might be due to invalid IL or missing references)
		//IL_0267: Unknown result type (might be due to invalid IL or missing references)
		//IL_0271: Expected O, but got Unknown
		//IL_0316: Unknown result type (might be due to invalid IL or missing references)
		//IL_0320: Expected O, but got Unknown
		//IL_03bd: Unknown result type (might be due to invalid IL or missing references)
		//IL_041d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0427: Expected O, but got Unknown
		GButton asButton = obj.asButton;
		RecycleProduct recycleProduct = curProductDatas[index];
		int num = ((!(recycleProduct.Multiplier < 3f)) ? ((recycleProduct.Multiplier < 5f) ? 1 : ((recycleProduct.Multiplier < 10f) ? 2 : ((recycleProduct.Multiplier < 18f) ? 3 : ((!(recycleProduct.Multiplier < 100f)) ? 5 : 4)))) : 0);
		Controller controller = ((GComponent)asButton).GetController("TypeStatus");
		controller.selectedIndex = num;
		string key = recycleProduct.Requirements.First().Key;
		int value = recycleProduct.Productions.First().Value;
		FGUIManager.Instance.SetItemIconAndFrame(((GComponent)asButton).GetChild("icon").asLoader, key, _textureList);
		((GComponent)asButton).GetChild("EquipmentName").text = Shift.Legion.Common.Models.Item.Name(GameManagers.Instance, key) ?? "";
		((GComponent)asButton).GetController("Status").selectedIndex = 0;
		((GComponent)asButton).GetChild("num").text = GameManagers.Instance.StockController.GetStock(key).ShortNumberFormat() ?? "";
		((GObject)asButton).data = recycleProduct;
		if (recycleProduct.Multiplier >= 100f)
		{
			((GComponent)asButton).GetController("RatioStatus").selectedIndex = 1;
		}
		else
		{
			((GComponent)asButton).GetController("RatioStatus").selectedIndex = 0;
			((GComponent)asButton).GetChild("ratio").text = string.Format("{0}{1}", Convert.ToInt32(recycleProduct.Multiplier), LanguagesManager.GetDesc("CsharpCodeZhTcText531"));
		}
		if (num == 5)
		{
			FGUIManager.Instance.AddTextSpecialEffects(((GComponent)asButton).GetChild("strokeSfxBack").asGraph, "ui_recyclecard_yellow", new Vector3(100f, 98f, 100f), "Default", 0.5f, delegate(GameObject gObject)
			{
				//IL_0016: Unknown result type (might be due to invalid IL or missing references)
				gObject.transform.localPosition = new Vector3(0f, 0f, 100f);
				((Object)gObject).name = "FxObject";
			});
			Material recyclecard = new Material(FGUIManager.Instance._FairyGUIFlowWithMask);
			recyclecard.SetTexture("_MaskTex", (Texture)(object)FGUIManager.Instance.card_recycle_mask);
			recyclecard.SetTexture("_FlowTex", (Texture)(object)FGUIManager.Instance.shine_fx_recyclecard);
			recyclecard.SetFloat("_FlowAlpha", 0.9f);
			recyclecard.SetFloat("_FlowSpeed", 0.35f);
			GImage image = ((GComponent)asButton).GetChild("CardGoldBack").asImage;
			image.material = recyclecard;
			((GObject)image).onRemovedFromStage.Set((EventCallback0)delegate
			{
				image.material = null;
				Object.Destroy((Object)(object)recyclecard);
			});
		}
		else
		{
			GameObject gameObject = ((GObject)((GComponent)asButton).GetChild("strokeSfxBack").asGraph).displayObject.gameObject;
			Transform val = gameObject.transform.Find("FxObject");
			if ((Object)(object)val != (Object)null)
			{
				SpawnManager.Instance.Destroy(((Component)val).gameObject);
			}
		}
		((GComponent)asButton).GetChild("price").text = $"{value}";
		((GComponent)asButton).GetChild("price").asTextField.strokeColor = new Color(0f, 0f, 0f, 0.6f);
		if (chosenList.Contains(curProductDatas[index].RecycleProductId))
		{
			((GComponent)asButton).GetController("Status").selectedIndex = 1;
		}
		else
		{
			((GComponent)asButton).GetController("Status").selectedIndex = 0;
		}
		((GObject)asButton).onClick.Set(new EventCallback1(SelectCard));
		return true;
	}

	private void SelectCard(EventContext context)
	{
		UI_EquipmentCom uI_EquipmentCom = (UI_EquipmentCom)(object)context.sender;
		RecycleProduct recycleProduct = (RecycleProduct)((GObject)uI_EquipmentCom).data;
		((GObject)yesBtn).enabled = true;
		if (chosenList.Contains(recycleProduct.RecycleProductId))
		{
			chosenList.Remove(recycleProduct.RecycleProductId);
		}
		else
		{
			chosenList.Add(recycleProduct.RecycleProductId);
		}
		if (uI_EquipmentCom.Status.selectedIndex == 0)
		{
			uI_EquipmentCom.Status.selectedIndex = 1;
		}
		else
		{
			uI_EquipmentCom.Status.selectedIndex = 0;
		}
		UpdateTotalOutPut(workersList.numItems - MoltenCoreBuilding.ManPower);
		foreach (ProductionConfig value in NewProductConfig.Values)
		{
			value.ProductList = ListExtensions.DeepCopy<string>(chosenList);
		}
	}

	private void RenderVisitorItem(int index, GObject obj)
	{
		//IL_01ae: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b8: Expected O, but got Unknown
		GComponent asCom = obj.asCom;
		int userId;
		if (((GObject)((GObject)asCom).parent).name == "VisitorsList")
		{
			RecycleDailyProduceStat recycleDailyProduceStat = recycleStats[index];
			userId = recycleDailyProduceStat.UserId;
			UI_VisitorItem uI_VisitorItem = (UI_VisitorItem)(object)asCom;
			FGUIManager.Instance.GetUserMedal(userId, uI_VisitorItem.n10);
			asCom.GetController("Status").selectedIndex = 0;
			asCom.GetChild("name").text = recycleDailyProduceStat.Nickname;
			asCom.GetChild("level").text = recycleDailyProduceStat.UserLevel.ToString();
			asCom.GetChild("CurEarnings").text = recycleDailyProduceStat.DailyProd.ShortNumberFormat() ?? "";
			((UI_VisitorItem)(object)asCom).SetControllerPageText();
		}
		else
		{
			UserInfo userInfo = friendsList[index];
			userId = userInfo.UserId;
			UI_VisitorItem_foo uI_VisitorItem_foo = (UI_VisitorItem_foo)(object)asCom;
			FGUIManager.Instance.GetUserMedal(userId, uI_VisitorItem_foo.n10);
			asCom.GetController("Status").selectedIndex = 1;
			asCom.GetChild("name").text = userInfo.Nickname;
			asCom.GetChild("level").text = userInfo.UserLevel.ToString();
			asCom.GetChild("CurEarnings").text = userInfo.LegionPower.ShortNumberFormat() ?? "";
			((GObject)asCom.GetChild("VisitBtn").asButton).data = userInfo;
			((GObject)asCom.GetChild("VisitBtn").asButton).onClick.Set(new EventCallback1(VisitOthersMaincity));
			((UI_VisitorItem_foo)(object)asCom).SetControllerPageText();
		}
		((MonoBehaviour)FGUIManager.Instance).StartCoroutine(RenderPlayerAvatar(userId, ((GComponent)asCom.GetChild("IconBtn").asButton).GetChild("HeadPortrait").asCom.GetChild("icon").asLoader, asCom.GetChild("name").asTextField));
	}

	private IEnumerator RenderPlayerAvatar(int userId, GLoader avatarLoader, GTextField textField)
	{
		yield return ((MonoBehaviour)FGUIManager.Instance).StartCoroutine(EnsurePlayerAvatar(userId));
		if (!((GObject)avatarLoader).isDisposed && !((GObject)textField).isDisposed && AvatarAndNameCachingMap.TryGetValue(userId, out var avatarAndName))
		{
			avatarLoader.texture = avatarAndName.AvatarTexture;
			((GObject)textField).text = FGUIManager.Instance.TruncateTextLength(avatarAndName.Nickname, 14);
		}
	}

	private IEnumerator EnsurePlayerAvatar(int userId)
	{
		if (!AvatarAndNameCachingMap.TryGetValue(userId, out var avatarAndName))
		{
			avatarAndName = new AvatarAndNameCache
			{
				CachingStatus = eCachingStatus.Caching
			};
		}
		if (userId == GameController.Contexts.gameState.user.value.UserId)
		{
			string pngPath = UiHelper.GetSelfAvatarLocalPath();
			if (!File.Exists(pngPath))
			{
				yield return ((MonoBehaviour)FGUIManager.Instance).StartCoroutine(FGUIManager.Instance.EnsureSelfAvatarExist());
			}
			CoroutineWithData cd = new CoroutineWithData((MonoBehaviour)(object)FGUIManager.Instance, HotFix_Utils.getTextureByPath(pngPath));
			yield return cd.Coroutine;
			if (cd.Result != null)
			{
				avatarAndName.AvatarTexture = new NTexture((Texture)(Texture2D)cd.Result);
			}
			avatarAndName.Nickname = GameController.Contexts.gameState.user.value.Nickname;
			avatarAndName.CachingStatus = eCachingStatus.Cached;
		}
		else
		{
			GameLocalDataManager.UserLocalData userLocalData = GameLocalDataManager.GetSomeUserLocalData(userId);
			if (userLocalData == null)
			{
				yield return ((MonoBehaviour)FGUIManager.Instance).StartCoroutine(FGUIManager.Instance.EnsurePVPAvatarExist(userId));
				userLocalData = GameLocalDataManager.GetSomeUserLocalData(userId);
			}
			CoroutineWithData cd2 = new CoroutineWithData(target: HotFix_Utils.getTextureByPath(UiHelper.GetUserAvatarLocalPath(userId.ToString())), owner: (MonoBehaviour)(object)FGUIManager.Instance);
			yield return cd2.Coroutine;
			if (cd2.Result != null)
			{
				avatarAndName.AvatarTexture = new NTexture((Texture)(Texture2D)cd2.Result);
			}
			avatarAndName.Nickname = userLocalData.NickName;
			avatarAndName.CachingStatus = eCachingStatus.Cached;
		}
		AvatarAndNameCachingMap[userId] = avatarAndName;
	}

	private void UpdateMainPanelText(int userId)
	{
		if (OtherInfo != null)
		{
			((GObject)name).text = OtherInfo.Nickname ?? "";
			((GObject)n54.level).text = $"{OtherInfo.UserLevel}";
			FGUIManager.Instance.GetUserMedal(OtherInfo.UserId, medalIcon.medalList, isShowMedal);
		}
	}

	private async void GetSelfOutPut()
	{
		GetSelfRecycleStatsResponse response = await GameController.Contexts.Service<INetworkService>().GetSelfRecycleStats();
		if (!((GObject)this).isDisposed && response.Result)
		{
			outPutSelf = response.DailyProduce;
			((GObject)moenyNum).text = outPutSelf.ShortNumberFormat() ?? "";
			((GObject)moenyNum).data = outPutSelf;
		}
	}

	private void InitWorkerSpine()
	{
		//IL_0075: Unknown result type (might be due to invalid IL or missing references)
		//IL_009a: Unknown result type (might be due to invalid IL or missing references)
		//IL_009f: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00db: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e5: Expected O, but got Unknown
		//IL_010b: Unknown result type (might be due to invalid IL or missing references)
		ref GameObject reference = ref canvasObject;
		Object obj = Object.Instantiate(Resources.Load("SpineTest", typeof(GameObject)));
		reference = (GameObject)(object)((obj is GameObject) ? obj : null);
		SpawnManager.Instance.LoadAnimation("Goblinworker_UI_001").Then((Action<SkeletonDataAsset>)delegate(SkeletonDataAsset asset)
		{
			if (!((GObject)this).isDisposed)
			{
				toUnloadAni = true;
				SkeletonAnimation component = canvasObject.GetComponent<SkeletonAnimation>();
				if ((Object)(object)component != (Object)null && (Object)(object)asset != (Object)null)
				{
					((SkeletonRenderer)component).skeletonDataAsset = asset;
					((SkeletonRenderer)component).Initialize(true);
					SpineHelper.SetSkin((ISkeletonAnimation)(object)component, "skin_default");
					component.AnimationState.AddAnimation(1, "idle", true, 0f);
				}
			}
		});
		if ((Object)(object)canvasObject != (Object)null)
		{
			canvasObject.transform.localScale = new Vector3(80f, 80f, 80f);
			canvasObject.transform.localPosition = -new Vector3(0f, 0f, 0f);
			canvasObject.transform.localEulerAngles = -new Vector3(0f, 0f, 0f);
			gw1 = new GoWrapper(canvasObject);
			((DisplayObject)gw1).SetXY(0f, 0f);
			((DisplayObject)gw1).pivot = new Vector2(0.5f, 0.5f);
			((DisplayObject)gw1).scaleX = 1f;
			workUI.SetNativeObject((DisplayObject)(object)gw1);
		}
	}

	private void UpdateMainPanel(int userId, bool isInit = false)
	{
		//IL_01d4: Unknown result type (might be due to invalid IL or missing references)
		//IL_01fc: Unknown result type (might be due to invalid IL or missing references)
		//IL_0206: Expected O, but got Unknown
		//IL_0219: Unknown result type (might be due to invalid IL or missing references)
		//IL_0223: Expected O, but got Unknown
		UpdateMainPanelText(userId);
		GetSelfOutPut();
		CalculateTotalOutPut();
		GetWorkingStatus(MoltenCoreBuilding.Slot + MoltenCoreBuilding.LeaseholdSlot - MoltenCoreBuilding.ManPower, MoltenCoreBuilding.Slot, MoltenCoreBuilding.LeaseholdSlot);
		bool flag = false;
		if (MultiplayerSwitchEnabled)
		{
			((GObject)VisitBtn).enabled = true;
		}
		else
		{
			((GObject)VisitBtn).enabled = false;
		}
		((GObject)tip5).visible = false;
		if (GameManagers.Instance.RecycleManager.RecycleExportTo.GetValue() != userId)
		{
			if (GameController.Contexts.gameState.user.value.UserId == userId)
			{
				Status.selectedIndex = 3;
				((GObject)earnings).text = "---/h";
			}
			else
			{
				Status.selectedIndex = 1;
			}
			flag = true;
		}
		else
		{
			if (GameController.Contexts.gameState.user.value.UserId == userId)
			{
				if (MultiplayerSwitchEnabled)
				{
					Status.selectedIndex = 0;
				}
				else
				{
					Status.selectedIndex = 4;
				}
			}
			else
			{
				Status.selectedIndex = 2;
			}
			if (!isInit)
			{
				flag = true;
			}
		}
		SetControllerPageText();
		if (Status.selectedIndex != 4)
		{
			BriefVisitorsListRender(GameController.Contexts.gameState.user.value.UserId);
		}
		if (flag)
		{
			UiAudioManager.Instance.PlaySoundEffect("Portal");
			FGUIManager.Instance.AddTextSpecialEffects(ScreenSfxBack, "ui_recycle_fullscreen", Vector3.zero);
			((GComponent)(object)this).SetTimeout(0.2f).OnComplete((GTweenCallback)delegate
			{
				if (!((GObject)this).isDisposed)
				{
					CardListRender();
				}
			});
			((GComponent)(object)this).SetTimeout(0.65f).OnComplete((GTweenCallback)delegate
			{
				//IL_001e: Unknown result type (might be due to invalid IL or missing references)
				if (!((GObject)this).isDisposed)
				{
					FGUIManager.Instance.AddTextSpecialEffects(recycleSfxBack, "ui_recycle_portal", Vector3.zero);
				}
			});
		}
		else
		{
			CardListRender();
		}
		WorkerListRenderer();
		WorkerBackListRenderer();
	}

	private void VisitOthersMaincity(EventContext context)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		curCheckId = (OtherInfo = (UserInfo)((GObject)context.sender).data).UserId;
		ThinkingDataHelper.Instance.VisitFriend(curCheckId);
		chosenList.Clear();
		UpdateMainPanel(curCheckId);
	}

	private void VisitPanelInit()
	{
		//IL_0023: Unknown result type (might be due to invalid IL or missing references)
		//IL_002d: Expected O, but got Unknown
		//IL_004a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0054: Expected O, but got Unknown
		visitPanel = UI_VisitPanel.CreateInstance();
		((GObject)visitPanel.Mask).onClick.Add(new EventCallback0(CloseVisitPanel));
		((GObject)visitPanel.Dialog.ReturnMaincity).onClick.Add(new EventCallback0(ReturnToMaincity));
		((GComponent)GRoot.inst).AddChild((GObject)(object)visitPanel);
		VisitPanelVisitorsList();
		FGUIManager.SetUiPanelSizeAndXy((GObject)(object)visitPanel);
		FGUIManager.SetToFullScreen((GObject)(object)visitPanel);
	}

	private void VisitPanelVisitorsList()
	{
		LoadFriendCanExportRecycle(delegate
		{
			//IL_0063: Unknown result type (might be due to invalid IL or missing references)
			//IL_006d: Expected O, but got Unknown
			if (friendsList.Count <= 0)
			{
				visitPanel.Dialog.Status.selectedIndex = 0;
			}
			else
			{
				visitPanel.Dialog.Status.selectedIndex = 1;
				visitPanel.Dialog.FriendsList.itemRenderer = new ListItemRenderer(RenderVisitorItem);
				visitPanel.Dialog.FriendsList.numItems = friendsList.Count;
				int num = ((friendsList.Count > 5) ? 5 : friendsList.Count);
				visitPanel.Dialog.FriendsList.ResizeToFit(num);
			}
		});
	}

	private void CurUserInfoInit()
	{
		LoadFriendCanExportRecycle(delegate
		{
			foreach (UserInfo friends in friendsList)
			{
				if (curCheckId == friends.UserId)
				{
					OtherInfo = friends;
					((GObject)name).text = OtherInfo.Nickname ?? "";
					((GObject)n54.level).text = $"{OtherInfo.UserLevel}";
					FGUIManager.Instance.GetUserMedal(friends.UserId, medalIcon.medalList, isShowMedal);
					break;
				}
			}
		});
	}

	private void LoadFriendCanExportRecycle(Action callback)
	{
		Task<GetFriendsCanExportRecycleResponse> task = GameController.Contexts.Service<INetworkService>().GetFriendsCanExportRecycle();
		task.GetAwaiter().OnCompleted(delegate
		{
			GetFriendsCanExportRecycleResponse result = task.Result;
			friendsList.Clear();
			if (!result.Result)
			{
				callback?.Invoke();
			}
			else
			{
				foreach (UserInfo friend in result.Friends)
				{
					if (friend.Valid)
					{
						friendsList.Add(friend);
					}
				}
				callback?.Invoke();
			}
		});
	}

	private void ReturnToMaincity()
	{
		curCheckId = GameController.Contexts.gameState.user.value.UserId;
		ChosenListInit();
		UpdateMainPanel(curCheckId);
	}

	private void CloseVisitPanel()
	{
		//IL_0018: Unknown result type (might be due to invalid IL or missing references)
		//IL_0022: Expected O, but got Unknown
		//IL_003f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0049: Expected O, but got Unknown
		((GObject)visitPanel.Mask).onClick.Remove(new EventCallback0(CloseVisitPanel));
		((GObject)visitPanel.Dialog.ReturnMaincity).onClick.Remove(new EventCallback0(ReturnToMaincity));
		((GComponent)GRoot.inst).RemoveChild((GObject)(object)visitPanel, true);
	}

	private async void VisitorPanelInit()
	{
		if (visitorsPanel == null && GameManagers.Instance.RecycleManager.RecycleEnableMultiplayer.GetValue() && Status.selectedIndex == 0)
		{
			visitorsPanel = UI_VisitorsPanel.CreateInstance_ILRuntime();
			((GObject)visitorsPanel.Dialog.close).onClick.Add(new EventCallback0(CloseVisitorPanel));
			((GObject)visitorsPanel.Dialog.SwitchBtn).onClick.Add(new EventCallback1(SwitchVisit));
			((GObject)visitorsPanel.Dialog.moenyNum).text = "";
			((GComponent)GRoot.inst).AddChild((GObject)(object)visitorsPanel);
			VisitorPanelVisitorsList();
			GetRecycleRebateResponse response = await GameController.Contexts.Service<INetworkService>().GetRecycleRebate();
			if (response.Result)
			{
				((GObject)visitorsPanel.Dialog.moenyNum).text = $"{response.TotalRebate}";
				((GObject)visitorsPanel.Dialog.ReceiveBtn).data = response.TotalRebate;
				((GObject)visitorsPanel.Dialog.ReceiveBtn).onClick.Set(new EventCallback1(ReceiveTotalRebateBonus));
				((GObject)visitorsPanel.Dialog.ReceiveBtn).enabled = response.TotalRebate > 0;
			}
			else
			{
				((GObject)visitorsPanel.Dialog.ReceiveBtn).enabled = false;
			}
			SwitchBtnInit();
			FGUIManager.SetUiPanelSizeAndXy((GObject)(object)visitorsPanel);
			FGUIManager.SetToFullScreen((GObject)(object)visitorsPanel);
		}
	}

	private async void ReceiveTotalRebateBonus(EventContext context)
	{
		int totalRebate = (int)((GObject)context.sender).data;
		if (totalRebate <= 0)
		{
			return;
		}
		ClaimRecycleRebateResponse response = await GameController.Contexts.Service<INetworkService>().ClaimRecycleRebate(totalRebate);
		if (!response.Result)
		{
			ILRequestHelper.ShowErrorCode(response.ErrorCode);
			return;
		}
		GameManagers.Instance.StockController.ReadStockChangeRecords(new StockChangeRecord[1]
		{
			new StockChangeRecord
			{
				ItemId = "Money",
				Offset = totalRebate,
				Context = 25,
				Type = 1
			}
		});
		((GObject)visitorsPanel.Dialog.ReceiveBtn).data = 0;
		((GObject)visitorsPanel.Dialog.ReceiveBtn).enabled = false;
		((GObject)visitorsPanel.Dialog.FloatingText.Count).text = $"{totalRebate}";
		visitorsPanel.Dialog.PopText.Play();
		visitorsPanel.Dialog.PopText.SetHook("OnClear", (TransitionHook)delegate
		{
			((GObject)visitorsPanel.Dialog.moenyNum).text = "0";
		});
	}

	private async void VisitorPanelVisitorsList()
	{
		GetRecycleStatsResponse response = await GameController.Contexts.Service<INetworkService>().GetRecycleStats(curCheckId);
		if (response.Result && response.RecycleStats != null)
		{
			UpdateRecycleStats(response.RecycleStats);
			visitorsPanel.Dialog.VisitorsList.itemRenderer = new ListItemRenderer(RenderVisitorItem);
			visitorsPanel.Dialog.VisitorsList.numItems = recycleStats.Count;
			if (recycleStats.Count <= 0)
			{
				visitorsPanel.Dialog.Status.selectedIndex = 0;
				((GObject)visitorsPanel.Dialog.tip2).text = LanguagesManager.GetDesc("CsharpCodeZhTcText528");
			}
			else
			{
				visitorsPanel.Dialog.Status.selectedIndex = 1;
			}
		}
		else
		{
			visitorsPanel.Dialog.Status.selectedIndex = 0;
			((GObject)visitorsPanel.Dialog.tip2).text = LanguagesManager.GetDesc("CsharpCodeZhTcText528");
		}
	}

	private void CloseVisitorPanel()
	{
		//IL_001d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0027: Expected O, but got Unknown
		//IL_0044: Unknown result type (might be due to invalid IL or missing references)
		//IL_004e: Expected O, but got Unknown
		((GObject)visitorsPanel.Dialog.close).onClick.Remove(new EventCallback0(CloseVisitorPanel));
		((GObject)visitorsPanel.Dialog.SwitchBtn).onClick.Remove(new EventCallback1(SwitchVisit));
		((GComponent)GRoot.inst).RemoveChild((GObject)(object)visitorsPanel, true);
		visitorsPanel = null;
	}

	private void SwitchBtnInit()
	{
		if (GameManagers.Instance.RecycleManager.RecycleEnableMultiplayer.GetValue())
		{
			visitorsPanel.Dialog.SwitchBtn.Status.selectedIndex = 0;
		}
		else
		{
			visitorsPanel.Dialog.SwitchBtn.Status.selectedIndex = 1;
		}
	}

	private void MainPanelSwitchBtnInit()
	{
		if (GameManagers.Instance.RecycleManager.RecycleEnableMultiplayer.GetValue())
		{
			SwitchBtn.Status.selectedIndex = 0;
			((GObject)SwitchBtn).visible = false;
			if (Status.selectedIndex != 4)
			{
				((GObject)tip2).visible = true;
			}
		}
		else
		{
			SwitchBtn.Status.selectedIndex = 1;
			((GObject)SwitchBtn).visible = true;
			if (Status.selectedIndex != 4)
			{
				((GObject)tip2).visible = false;
			}
		}
	}

	private void SwitchVisit(EventContext context)
	{
		UI_SwitchBtn uI_SwitchBtn = (UI_SwitchBtn)(object)context.sender;
		if (uI_SwitchBtn.Status.selectedIndex == 0)
		{
			ConfirmDialogInit(ChangeVisitJurisdiction, 0);
		}
		else
		{
			ChangeVisitJurisdiction();
		}
	}

	private async void ChangeVisitJurisdiction()
	{
		if (visitorsPanel.Dialog.SwitchBtn.Status.selectedIndex == 0)
		{
			SwitchRecycleMultiplayerEnableResponse response = await GameController.Contexts.Service<INetworkService>().SwitchRecycleMultiplayerEnable(enable: false);
			if (response.Result)
			{
				visitorsPanel.Dialog.SwitchBtn.Status.selectedIndex = 1;
				GameManagers.Instance.RecycleManager.RecycleEnableMultiplayer.SetValue(response.Enable);
				BriefVisitorsListRender(Contexts.sharedInstance.gameState.user.value.UserId);
			}
		}
		else
		{
			SwitchRecycleMultiplayerEnableResponse response2 = await GameController.Contexts.Service<INetworkService>().SwitchRecycleMultiplayerEnable(enable: true);
			if (response2.Result)
			{
				visitorsPanel.Dialog.SwitchBtn.Status.selectedIndex = 0;
				GameManagers.Instance.RecycleManager.RecycleEnableMultiplayer.SetValue(response2.Enable);
				BriefVisitorsListRender(Contexts.sharedInstance.gameState.user.value.UserId);
			}
		}
	}

	private void MainSwitchVisit(EventContext context)
	{
		UI_SwitchBtn uI_SwitchBtn = (UI_SwitchBtn)(object)context.sender;
		if (uI_SwitchBtn.Status.selectedIndex == 0)
		{
			ConfirmDialogInit(ChangeVisitJurisdictionForMainSwitch, 0);
		}
		else
		{
			ChangeVisitJurisdictionForMainSwitch();
		}
	}

	private async void ChangeVisitJurisdictionForMainSwitch()
	{
		SwitchRecycleMultiplayerEnableResponse response = await GameController.Contexts.Service<INetworkService>().SwitchRecycleMultiplayerEnable(SwitchBtn.Status.selectedIndex != 0);
		if (response.Result)
		{
			SwitchBtn.Status.selectedIndex = (response.Enable ? 1 : 0);
			GameManagers.Instance.RecycleManager.RecycleEnableMultiplayer.SetValue(response.Enable);
			BriefVisitorsListRender(Contexts.sharedInstance.gameState.user.value.UserId);
		}
	}

	private void ConfirmDialogInit(Action action, int selectindex)
	{
		//IL_0035: Unknown result type (might be due to invalid IL or missing references)
		//IL_003f: Expected O, but got Unknown
		//IL_0077: Unknown result type (might be due to invalid IL or missing references)
		//IL_0081: Expected O, but got Unknown
		//IL_009e: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a8: Expected O, but got Unknown
		ConfirmationPopup = UI_ConfirmationPopup.CreateInstance();
		((GObject)ConfirmationPopup.Dialog.noBtn).onClick.Add(new EventCallback0(CloseConfirmDialog));
		((GObject)ConfirmationPopup.Dialog.yesBtn).onClick.Clear();
		((GObject)ConfirmationPopup.Dialog.yesBtn).onClick.Add(new EventCallback0(CloseConfirmDialog));
		((GObject)ConfirmationPopup.Dialog.yesBtn).onClick.Add((EventCallback0)delegate
		{
			action();
		});
		((GComponent)GRoot.inst).AddChild((GObject)(object)ConfirmationPopup);
		ConfirmationPopup.Dialog.Status.selectedIndex = selectindex;
		ConfirmationPopup.Dialog.SetControllerPageText();
		FGUIManager.SetUiPanelSizeAndXy((GObject)(object)ConfirmationPopup);
		FGUIManager.SetToFullScreen((GObject)(object)ConfirmationPopup);
		ConfirmationPopup.ShowDialog.Play();
	}

	private void CloseConfirmDialog()
	{
		//IL_001d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0027: Expected O, but got Unknown
		//IL_0044: Unknown result type (might be due to invalid IL or missing references)
		//IL_004e: Expected O, but got Unknown
		((GObject)ConfirmationPopup.Dialog.noBtn).onClick.Remove(new EventCallback0(CloseConfirmDialog));
		((GObject)ConfirmationPopup.Dialog.yesBtn).onClick.Remove(new EventCallback0(CloseConfirmDialog));
		((GComponent)GRoot.inst).RemoveChild((GObject)(object)ConfirmationPopup, true);
	}

	private void WorkerListRenderer()
	{
		//IL_000e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0018: Expected O, but got Unknown
		workersList.itemRenderer = new ListItemRenderer(RenderWorkerIncrease);
		workersList.numItems = MoltenCoreBuilding.ManPower;
	}

	private void WorkerBackListRenderer()
	{
		//IL_000e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0018: Expected O, but got Unknown
		workersBackList.itemRenderer = new ListItemRenderer(RenderWorkerReduce);
		workersBackList.numItems = MoltenCoreBuilding.ManPower;
	}

	private void RenderWorkerIncrease(int index, GObject obj)
	{
		GButton asButton = obj.asButton;
		int manPower = MoltenCoreBuilding.ManPower;
		if (index < manPower)
		{
			((GObject)((GComponent)asButton).GetChild("normalState").asImage).visible = true;
			((GObject)((GComponent)asButton).GetChild("increaseState").asImage).visible = false;
		}
		else
		{
			((GObject)((GComponent)asButton).GetChild("normalState").asImage).visible = true;
			((GObject)((GComponent)asButton).GetChild("increaseState").asImage).visible = true;
		}
	}

	private void RenderWorkerReduce(int index, GObject obj)
	{
		GButton asButton = obj.asButton;
		((GObject)((GComponent)asButton).GetChild("reduceState").asImage).visible = true;
	}

	private void OnClickSendMessage()
	{
		UnityUiService.Instance.OpenPanel(UI_MailPanel.Name, new Dictionary<string, object>
		{
			{ "DefaultTab", 1 },
			{ "ChatWithFriend", OtherInfo.UserId }
		});
	}

	private void LinkRecyclingCenter(EventContext eventContext)
	{
		ILRequestHelper<RecycleExportToResponse>.Request(eventContext, () => GameController.Contexts.Service<INetworkService>().RecycleExportTo(curCheckId), async delegate(RecycleExportToResponse response)
		{
			if (!response.Result)
			{
				if (response.ExportTo == 0)
				{
					ConfirmDialogInit(delegate
					{
					}, 2);
				}
			}
			else
			{
				curCheckId = response.ExportTo;
				ClearCurProductConfig(eventContext);
				GameManagers.Instance.RecycleManager.RecycleExportTo.SetValue(response.ExportTo);
				await GameManagers.Instance.RecycleManager.GetCurrentRecyclingProducts();
				ChosenListInit();
				UpdateMainPanel(curCheckId);
			}
		});
	}

	private IEnumerator RefreshTimeLimitRemaining()
	{
		while (true)
		{
			DateTimeOffset now = DateTimeHelper.Now;
			DateTimeOffset refreshTime = DateTimeHelper.GetDailyRefreshTime(DateTimeHelper.Now, DateTimeHelper.TimezoneOffset, DateTimeHelper.RefreshHours).AddDays(1.0);
			TimeSpan timeRemapping = refreshTime - now;
			((GObject)time).text = string.Format("{0}{1}{2}{3}{4}{5}", timeRemapping.Hours, LanguagesManager.GetDesc("CsharpCodeZhTcText11"), timeRemapping.Minutes, LanguagesManager.GetDesc("CsharpCodeZhTcText502"), timeRemapping.Seconds, LanguagesManager.GetDesc("CsharpCodeZhTcText532"));
			yield return (object)new WaitForSeconds(1f);
		}
	}

	private void UpdateRecycleStats(List<RecycleDailyProduceStat> dailyProduceStats)
	{
		recycleStats.Clear();
		List<RecycleDailyProduceStat> list = new List<RecycleDailyProduceStat>();
		list.AddRange(dailyProduceStats);
		list.Sort((RecycleDailyProduceStat a, RecycleDailyProduceStat b) => -a.DailyProd.CompareTo(b.DailyProd));
		recycleStats.AddRange(list);
	}

	private void OnStockChange(string itemId, int incr, (StockInContext, string) context)
	{
		if (itemId == "Money" && context.Item1 == StockInContext.Building && context.Item2 == "17")
		{
			if (((GObject)moenyNum).data != null)
			{
				int num = (int)((GObject)moenyNum).data;
				((GObject)moenyNum).text = $"{num + incr}";
				((GObject)moenyNum).data = num + incr;
			}
			return;
		}
		for (int i = 0; i < CardList.numItems; i++)
		{
			GButton asButton = ((GComponent)CardList).GetChildAt(i).asButton;
			RecycleProduct recycleProduct = (RecycleProduct)((GObject)asButton).data;
			string key = recycleProduct.Requirements.First().Key;
			if (key == itemId)
			{
				((GComponent)asButton).GetChild("num").text = GameManagers.Instance.StockController.GetStock(itemId).ShortNumberFormat() ?? "";
				break;
			}
		}
	}

	private void ChosenListInit()
	{
		chosenList.Clear();
		foreach (ProductionConfig value in ProductConfig.Values)
		{
			foreach (string product in value.ProductList)
			{
				if (!chosenList.Contains(product))
				{
					chosenList.Add(product);
				}
			}
		}
		chosenClone = ListExtensions.DeepCopy<string>(chosenList);
	}

	private void increaseWorker()
	{
		//IL_001b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0025: Expected O, but got Unknown
		//IL_01f8: Unknown result type (might be due to invalid IL or missing references)
		//IL_024d: Unknown result type (might be due to invalid IL or missing references)
		((GObject)yesBtn).enabled = true;
		workersList.itemRenderer = new ListItemRenderer(RenderWorkerIncrease);
		int num = MoltenCoreBuilding.Slot + MoltenCoreBuilding.LeaseholdSlot;
		int newAssignedWorkers = GetNewAssignedWorkers();
		int currentAvailableWorkers = GetCurrentAvailableWorkers();
		if (newAssignedWorkers < num && currentAvailableWorkers > 0)
		{
			bool flag = false;
			for (int i = 0; i < MoltenCoreBuilding.Slot; i++)
			{
				ProductionConfig newProductionConfigAt = GetNewProductionConfigAt(i);
				if (newProductionConfigAt.Workers < 1)
				{
					newProductionConfigAt.Workers = 1;
					newProductionConfigAt.ProductList.Clear();
					newProductionConfigAt.ProductList.AddRange(ListExtensions.DeepCopy<string>(chosenList));
					flag = true;
					break;
				}
			}
			if (!flag)
			{
				for (int j = 0; j < MoltenCoreBuilding.LeaseholdSlot; j++)
				{
					int index = ((MoltenCoreController)MoltenCoreBuilding.Controller).WorkbenchNominal.Length - 1 - j;
					ProductionConfig newProductionConfigAt2 = GetNewProductionConfigAt(index);
					if (newProductionConfigAt2.Workers < 1)
					{
						newProductionConfigAt2.Workers = 1;
						newProductionConfigAt2.ProductList.Clear();
						newProductionConfigAt2.ProductList.AddRange(chosenList);
						break;
					}
				}
			}
			workersList.numItems += 1;
			((GComponent)((GComponent)workersList).GetChildAt(workersList.numItems - 1).asButton).GetTransition("increase").Play();
			addWorkerBtn.GetChild("CurrentWorkerAmount").text = GetCurrentAvailableWorkers().ToString();
			((GObject)numbersSpine).displayObject.Dispose();
			FGUIManager.Instance.AddTextSpecialEffects(numbersSpine, FGUIManager.Instance.uiGreen, Vector3.zero);
			addWorkerBtn.GetChild("workerButtonSpine").displayObject.Dispose();
			FGUIManager.Instance.AddTextSpecialEffects(addWorkerBtn.GetChild("workerButtonSpine").asGraph, FGUIManager.Instance.uiGreen, Vector3.zero);
		}
		else
		{
			Queue<Transition> queue = new Queue<Transition>();
			Queue<Action> queue2 = new Queue<Action>();
			if (currentAvailableWorkers <= 0)
			{
				Transition transition = addWorkerBtn.GetTransition("textHeoghtLight");
				if (transition.playing)
				{
					transition.Stop();
				}
				queue.Enqueue(transition);
				queue2.Enqueue(delegate
				{
					//IL_0040: Unknown result type (might be due to invalid IL or missing references)
					addWorkerBtn.GetChild("workerButtonSpine").displayObject.Dispose();
					FGUIManager.Instance.AddTextSpecialEffects(addWorkerBtn.GetChild("workerButtonSpine").asGraph, FGUIManager.Instance.uiRed, Vector3.zero);
					List<string> arg = new List<string> { LanguagesManager.GetDesc("CsharpCodeZhTcText159") + "！" };
					SharedMessenger.Broadcast("SHOW_TIPS", arg, ((GObject)this).sortingOrder + 5, arg3: false);
				});
			}
			if (newAssignedWorkers >= num)
			{
				if (numbersHeightLight.playing)
				{
					numbersHeightLight.Stop();
				}
				queue.Enqueue(numbersHeightLight);
				queue2.Enqueue(delegate
				{
					//IL_0027: Unknown result type (might be due to invalid IL or missing references)
					((GObject)numbersSpine).displayObject.Dispose();
					FGUIManager.Instance.AddTextSpecialEffects(numbersSpine, FGUIManager.Instance.uiRed, Vector3.zero);
					List<string> arg = new List<string> { LanguagesManager.GetDesc("CsharpCodeZhTcText160") + "！" };
					SharedMessenger.Broadcast("SHOW_TIPS", arg, ((GObject)this).sortingOrder + 5, arg3: false);
				});
			}
			PlayOperateFX(queue, queue2);
		}
		int newAssignedWorkers2 = GetNewAssignedWorkers();
		GetWorkingStatus(num - newAssignedWorkers2, MoltenCoreBuilding.Slot, MoltenCoreBuilding.LeaseholdSlot);
		UpdateTotalOutPut(workersList.numItems - MoltenCoreBuilding.ManPower);
	}

	private void reduceWorker()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		//IL_018e: Unknown result type (might be due to invalid IL or missing references)
		//IL_01e3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fc: Unknown result type (might be due to invalid IL or missing references)
		//IL_0106: Expected O, but got Unknown
		((GObject)yesBtn).enabled = true;
		workersList.itemRenderer = new ListItemRenderer(RenderWorkerIncrease);
		int availableWorkbenches = MoltenCoreBuilding.Slot + MoltenCoreBuilding.LeaseholdSlot;
		int newAssignedWorkers = GetNewAssignedWorkers();
		if (newAssignedWorkers > 0)
		{
			Transition transition = ((GComponent)((GComponent)workersList).GetChildAt(workersList.numItems - 1).asButton).GetTransition("reduce");
			if (transition.playing)
			{
				return;
			}
			for (int num = ((MoltenCoreController)MoltenCoreBuilding.Controller).WorkbenchNominal.Length - 1; num >= 0; num--)
			{
				ProductionConfig newProductionConfigAt = GetNewProductionConfigAt(num);
				if (newProductionConfigAt.Workers > 0)
				{
					newProductionConfigAt.Workers = 0;
					break;
				}
			}
			transition.Play((PlayCompleteCallback)delegate
			{
				workersList.numItems -= 1;
				UpdateTotalOutPut(workersList.numItems - MoltenCoreBuilding.ManPower);
				addWorkerBtn.GetChild("CurrentWorkerAmount").text = GetCurrentAvailableWorkers().ToString();
				GetWorkingStatus(availableWorkbenches - GetNewAssignedWorkers(), MoltenCoreBuilding.Slot, MoltenCoreBuilding.LeaseholdSlot);
			});
		}
		else
		{
			GetWorkingStatus(availableWorkbenches - GetNewAssignedWorkers(), MoltenCoreBuilding.Slot, MoltenCoreBuilding.LeaseholdSlot);
			List<string> arg = new List<string> { LanguagesManager.GetDesc("CsharpCodeZhTcText161") + "！" };
			SharedMessenger.Broadcast("SHOW_TIPS", arg, 5, arg3: false);
		}
		((GObject)numbersSpine).displayObject.Dispose();
		FGUIManager.Instance.AddTextSpecialEffects(numbersSpine, FGUIManager.Instance.uiGreen, Vector3.zero);
		addWorkerBtn.GetChild("workerButtonSpine").displayObject.Dispose();
		FGUIManager.Instance.AddTextSpecialEffects(addWorkerBtn.GetChild("workerButtonSpine").asGraph, FGUIManager.Instance.uiGreen, Vector3.zero);
	}

	private void CalculateTotalOutPut()
	{
		UpdateTotalOutPut(0);
	}

	private float GetAverageOutPut()
	{
		float num = 0f;
		for (int i = 0; i < chosenList.Count; i++)
		{
			RecycleProduct recycleProduct = RecycleManager.RecycleProducts[chosenList[i]];
			num += 3600f / recycleProduct.Time * (float)recycleProduct.Productions.First().Value;
		}
		return (chosenList.Count <= 0) ? 0f : (num / (float)chosenList.Count);
	}

	private void UpdateTotalOutPut(int workerNum)
	{
		//IL_0076: Unknown result type (might be due to invalid IL or missing references)
		//IL_007b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0132: Unknown result type (might be due to invalid IL or missing references)
		//IL_0137: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00dd: Unknown result type (might be due to invalid IL or missing references)
		float averageOutPut = GetAverageOutPut();
		int num = MoltenCoreBuilding.ManPower * Convert.ToInt32(averageOutPut);
		((GObject)earnings).text = $"{num}";
		if (workerNum == 0)
		{
			GTextField obj = earnings;
			((GObject)obj).text = ((GObject)obj).text + "/h";
			earnings.color = Color32.op_Implicit(new Color32((byte)225, (byte)254, (byte)233, byte.MaxValue));
		}
		else if (workerNum < 0)
		{
			GTextField obj2 = earnings;
			((GObject)obj2).text = ((GObject)obj2).text + $"{Convert.ToInt32(averageOutPut * (float)workerNum)}/h";
			earnings.color = Color32.op_Implicit(new Color32((byte)220, (byte)20, (byte)60, byte.MaxValue));
		}
		else
		{
			GTextField obj3 = earnings;
			((GObject)obj3).text = ((GObject)obj3).text + $"+{Convert.ToInt32(averageOutPut * (float)workerNum)}/h";
			earnings.color = Color32.op_Implicit(new Color32((byte)175, (byte)246, (byte)39, byte.MaxValue));
		}
	}

	private void PlayOperateFX(Queue<Transition> fxPlayList, Queue<Action> tipPlayList)
	{
		//IL_0067: Unknown result type (might be due to invalid IL or missing references)
		//IL_0071: Expected O, but got Unknown
		if (fxPlayList.Count > 0)
		{
			Transition val = fxPlayList.Dequeue();
			Action action = null;
			if (tipPlayList.Count > 0)
			{
				action = tipPlayList.Dequeue();
			}
			val.Play((PlayCompleteCallback)delegate
			{
				PlayOperateFX(fxPlayList, tipPlayList);
			});
			action?.Invoke();
		}
	}

	private ProductionConfig GetNewProductionConfigAt(int index)
	{
		if (index < NewProductConfig.Count)
		{
			return NewProductConfig[index.ToString()];
		}
		if (index >= ((MoltenCoreController)MoltenCoreBuilding.Controller).WorkbenchNominal.Length)
		{
			return null;
		}
		for (int i = NewProductConfig.Count; i <= index; i++)
		{
			NewProductConfig.Add(i.ToString(), new ProductionConfig
			{
				Workers = 0,
				ProductList = new List<string>()
			});
		}
		return NewProductConfig[index.ToString()];
	}

	private int GetNewAssignedWorkers()
	{
		return NewProductConfig.Values.Sum((ProductionConfig productConfig) => productConfig.Workers);
	}

	private int GetCurrentAvailableWorkers()
	{
		Dungeon value = GameController.Contexts.game.dungeon.value;
		return Dungeon.GetFreeManPower(GameManagers.Instance) - (GetNewAssignedWorkers() - MoltenCoreBuilding.ManPower);
	}

	private void ReLinkTip(EventContext eventContext)
	{
		bool flag = true;
		foreach (KeyValuePair<string, ProductionConfig> productionConfig in MoltenCoreBuilding.ProductionConfigs)
		{
			if (productionConfig.Value.Workers > 0)
			{
				flag = false;
				break;
			}
		}
		if (!flag)
		{
			ConfirmDialogInit(delegate
			{
				LinkRecyclingCenter(eventContext);
			}, 1);
		}
		else
		{
			LinkRecyclingCenter(eventContext);
		}
	}

	private void ClearCurProductConfig(EventContext eventContext)
	{
		CustomTaskCompletionSource<bool> customTaskCompletionSource = eventContext.data as CustomTaskCompletionSource<bool>;
		if (customTaskCompletionSource != null)
		{
			customTaskCompletionSource.IsAsync = true;
		}
		NewProductConfig = new Dictionary<string, ProductionConfig> { 
		{
			"0",
			new ProductionConfig
			{
				Workers = 0
			}
		} };
		MoltenCoreBuilding.ProductionConfigs = DictionaryExtensions.DeepCopy<string, ProductionConfig>(NewProductConfig);
		ApplyAssignationAsync(customTaskCompletionSource, isLink: true);
	}

	public void WorkerDeployment(EventContext eventContext)
	{
		CustomTaskCompletionSource<bool> taskCompletionSource = eventContext.data as CustomTaskCompletionSource<bool>;
		bool flag = NewProductConfig == null || NewProductConfig.Count < 1 || GetNewAssignedWorkers() < 1 || !NewProductConfig.Values.Any((ProductionConfig productConfig) => productConfig.ProductList.Count > 0);
		if (taskCompletionSource != null)
		{
			taskCompletionSource.IsAsync = true;
		}
		if (flag)
		{
			GameController.Contexts.Service<IUiService>().OpenPanel(UI_UniversalConfirmPopup.Name, new Dictionary<string, object>
			{
				{
					"Content",
					LanguagesManager.GetDesc("CsharpCodeZhTcText157") + MoltenCoreBuilding.Name + LanguagesManager.GetDesc("CsharpCodeZhTcText158") + LanguagesManager.Comma + LanguagesManager.GetDesc("CsharpCodeZhTcText144") + "？"
				},
				{
					"Buttons",
					new Dictionary<string, Action>
					{
						{
							"Confirm",
							delegate
							{
								ApplyAssignationAsync(taskCompletionSource);
							}
						},
						{
							"Cancel",
							delegate
							{
								taskCompletionSource?.SetResult(result: true);
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
			ApplyAssignationAsync(taskCompletionSource);
		}
	}

	private void ApplyAssignationAsync(CustomTaskCompletionSource<bool> taskCompletionSource = null, bool isLink = false)
	{
		ILRequestHelper<ChangeWorkshopProduceConfigResponse>.Request(taskCompletionSource, delegate
		{
			Dictionary<int, int> dictionary = new Dictionary<int, int>();
			Dictionary<int, List<string>> dictionary2 = new Dictionary<int, List<string>>();
			foreach (KeyValuePair<string, ProductionConfig> item in NewProductConfig)
			{
				dictionary.Add(int.Parse(item.Key), item.Value.Workers);
				dictionary2.Add(int.Parse(item.Key), item.Value.ProductList);
			}
			return GameController.Contexts.Service<INetworkService>().ChangeWorkshopProduceConfig(1L, MoltenCoreBuilding.BuildingType, dictionary, dictionary2);
		}, delegate(ChangeWorkshopProduceConfigResponse response)
		{
			if (!response.Result)
			{
				ILRequestHelper.ShowErrorCode(response.ErrorCode);
				return;
			}
			UiAudioManager.Instance.PlaySoundEffect("Confirm");
			GameManagers.Instance.StockController.NeedSyncProduce = true;
			if (!isLink)
			{
				End();
			}
			SharedMessenger.Broadcast("PRODUCTION_CONFIG_CHANGED", (Building)MoltenCoreBuilding, DictionaryExtensions.DeepCopy<string, ProductionConfig>(NewProductConfig));
			SharedMessenger.Broadcast("WORKERS_ALLOCATION_DISPLAY_CHANGED", (Building)MoltenCoreBuilding);
			foreach (RecycleProduct item2 in curProductDatas.Where((RecycleProduct recycleProd) => chosenList.Contains(recycleProd.RecycleProductId)))
			{
				ThinkingDataHelper.Instance.RecycleTrack(item2.RecycleProductId, item2.Productions.First().Value, MoltenCoreBuilding.ManPower);
			}
		});
	}
}
