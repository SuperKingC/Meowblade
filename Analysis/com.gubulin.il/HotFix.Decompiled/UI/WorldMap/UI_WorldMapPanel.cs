using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Assets.Scripts.Managers;
using Assets.Scripts.UI;
using FairyGUI;
using FairyGUI.Utils;
using GameDataEditor;
using HotFix;
using Shift.Legion.ClientApi.Protocol.UserAction;
using Shift.Legion.ClientApi.RPC.Api;
using Shift.Legion.Common.Enums;
using Shift.Legion.Common.Managers;
using Shift.Legion.Common.Models;
using Shift.Legion.Common.Services;
using Shift.Legion.Common.Sources.Enums;
using Spine;
using Spine.Unity;
using UI.Battle;
using UI.Guide;
using UI.Legion;
using UI.PrinceOfTheDevils;
using UI.PublicResources;
using UnityEngine;

namespace UI.WorldMap;

public class UI_WorldMapPanel : GComponent, IUiController
{
	[Serializable]
	[CompilerGenerated]
	private sealed class _003C_003Ec
	{
		public static readonly _003C_003Ec _003C_003E9 = new _003C_003Ec();

		public static Action<GameObject> _003C_003E9__43_3;

		public static Action<GameObject> _003C_003E9__67_2;

		public static EventCallback0 _003C_003E9__101_0;

		public static Action<GameObject> _003C_003E9__109_0;

		internal void _003CPlayOccupationEffect_003Eb__43_3(GameObject flagSlam)
		{
			flagSlam.AddComponent<HotFix_DestroySelf>().destroyTime = 3f;
		}

		internal void _003CPlayMoneyDisapear_003Eb__67_2(GameObject activatingYellow)
		{
			activatingYellow.AddComponent<HotFix_DestroySelf>().destroyTime = 0.8f;
		}

		internal void _003CGetMapData_003Eb__101_0()
		{
		}

		internal void _003CPlayRegionProdAutoClaimed_003Eb__109_0(GameObject blackHole)
		{
			blackHole.AddComponent<HotFix_DestroySelf>().destroyTime = 3f;
			UiAudioManager.Instance.LoadSoundsForSfx(blackHole, "portal");
		}
	}

	public Controller pageController;

	public GLoader mainMapLoader;

	public GImage n13;

	public GImage n27;

	public GImage n28;

	public UI_TitleGroup TitleGroup;

	public UI_BackBtn backBtn;

	public UI_WorldMapBtn switchMapBtn;

	public UI_ManorSize ManorSize;

	public UI_CurEarnings CurEarnings;

	public UI_CurAreaEarnings CurAreaEarnings;

	public UI_CountdownBtn CountdownBtn;

	public UI_LastRegionBtn LastRegionBtn;

	public UI_LastRegionBtn02 NextRegionBtn;

	public GImage leftArrow;

	public GImage rightArrow;

	public UI_TitleGroup02 n30;

	public GLoader Finger;

	public Transition zeroToOne;

	public Transition oneToZero;

	public Transition infoRefresh;

	public Transition test;

	public Transition titleOut;

	public Transition AreaEarningsOut;

	public Transition switchMapBtnOut;

	public Transition CurEarningsOut;

	public const string URL = "ui://c9n2h0ksomji5";

	public static string Name = "UI_WorldMapPanel";

	public static UI_WorldMapPanel WorldMapPanel;

	private Coroutine refreshSelectedAreaInfo;

	private List<UI_newTotalEarnBtn> allAreasStrongholdOutPutBtns = new List<UI_newTotalEarnBtn>();

	private int interval = 0;

	private const int showFingerTime = 3;

	private Coroutine showFingerTimerCoroutine;

	private bool hasFguiGrootClick;

	public UI_Map mapCom;

	private readonly List<GComponent> areaList = new List<GComponent>();

	private readonly List<Region> areaDataList = new List<Region>();

	private GComponent _selectedArea;

	private float minX;

	private float minY;

	private float maxX;

	private float maxY;

	private PinchGesture _pinchGesture;

	private readonly List<Tuple<string, string, Color32, string, float>> totalEarningsData = new List<Tuple<string, string, Color32, string, float>>();

	private readonly List<Tuple<string, string, Color32, string, float>> areaEarningsData = new List<Tuple<string, string, Color32, string, float>>();

	private int occupyingIndex;

	private string curSelectedStrongholdId;

	public Stronghold curSelectedStronghold;

	private bool alreadyReceived;

	private readonly List<string> textureList = new List<string>();

	private readonly List<KeyValuePair<float, GComponent>> briefInfo = new List<KeyValuePair<float, GComponent>>();

	private readonly List<GButton> strongholdUIBackList = new List<GButton>();

	private tKeyValue<int, Vector2> selectAreaInfo;

	private UI_unlockAreaTip unlockAreaTip;

	private GButton selectedStronghold;

	private bool _dragging;

	private float GaussianBlurValue;

	private bool GaussianBlurExist;

	private Vector2 curLevelPos;

	private bool fromBattleField;

	private IUiController parentUiController;

	private tKeyValue<GComponent, bool> OccupiedArea;

	private Region focusedRegion;

	private string focusedRegionId;

	private UI_warringLogo warringLogo;

	private List<UI_warringLogo> StrongldLevelTitles = new List<UI_warringLogo>();

	private UI_WorkerOnMap workerOnMap;

	private int curWorkerPosIndex;

	private Dictionary<string, GProgressBar> curRegionStrongholdsBars = new Dictionary<string, GProgressBar>();

	private Dictionary<string, GMovieClip> curRegionLevelClips = new Dictionary<string, GMovieClip>();

	private List<string> spineList = new List<string>();

	private List<AnimationState> spineStates = new List<AnimationState>();

	private Dictionary<string, GTweener> progressBarsTweeners = new Dictionary<string, GTweener>();

	private Coroutine RefreshStrongholdProgressBarCoroutine;

	private Coroutine RefreshLevelprogressBarCoroutine;

	private Coroutine RefreshLevelAutoClaimedCutDownCoroutine;

	private Coroutine PlayRegionProdAutoClaimedCoroutine;

	private UI_blackHoleBack blackHoleBack;

	private List<UI_MoneyBtn> MoneyBtnList = new List<UI_MoneyBtn>();

	private GComponent selectedArea
	{
		get
		{
			return _selectedArea;
		}
		set
		{
			if (_selectedArea != value)
			{
				_selectedArea = value;
			}
		}
	}

	public static string GetURL()
	{
		return "ui://c9n2h0ksomji5";
	}

	public static UI_WorldMapPanel CreateInstance()
	{
		return (UI_WorldMapPanel)(object)UIPackage.CreateObject("WorldMap", "WorldMapPanel");
	}

	public static UI_WorldMapPanel CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_WorldMapPanel).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://c9n2h0ksomji5", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		//IL_0144: Unknown result type (might be due to invalid IL or missing references)
		//IL_014e: Expected O, but got Unknown
		//IL_015a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0164: Expected O, but got Unknown
		//IL_0186: Unknown result type (might be due to invalid IL or missing references)
		//IL_0190: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		pageController = ((GComponent)this).GetController("pageController");
		mainMapLoader = (GLoader)((GComponent)this).GetChild("mainMapLoader");
		n13 = (GImage)((GComponent)this).GetChild("n13");
		n27 = (GImage)((GComponent)this).GetChild("n27");
		n28 = (GImage)((GComponent)this).GetChild("n28");
		TitleGroup = (UI_TitleGroup)(object)((GComponent)this).GetChild("TitleGroup");
		backBtn = (UI_BackBtn)(object)((GComponent)this).GetChild("backBtn");
		switchMapBtn = (UI_WorldMapBtn)(object)((GComponent)this).GetChild("switchMapBtn");
		ManorSize = (UI_ManorSize)(object)((GComponent)this).GetChild("ManorSize");
		CurEarnings = (UI_CurEarnings)(object)((GComponent)this).GetChild("CurEarnings");
		CurAreaEarnings = (UI_CurAreaEarnings)(object)((GComponent)this).GetChild("CurAreaEarnings");
		CountdownBtn = (UI_CountdownBtn)(object)((GComponent)this).GetChild("CountdownBtn");
		LastRegionBtn = (UI_LastRegionBtn)(object)((GComponent)this).GetChild("LastRegionBtn");
		NextRegionBtn = (UI_LastRegionBtn02)(object)((GComponent)this).GetChild("NextRegionBtn");
		leftArrow = (GImage)((GComponent)this).GetChild("leftArrow");
		rightArrow = (GImage)((GComponent)this).GetChild("rightArrow");
		n30 = (UI_TitleGroup02)(object)((GComponent)this).GetChild("n30");
		Finger = (GLoader)((GComponent)this).GetChild("Finger");
		zeroToOne = ((GComponent)this).GetTransition("zeroToOne");
		oneToZero = ((GComponent)this).GetTransition("oneToZero");
		infoRefresh = ((GComponent)this).GetTransition("infoRefresh");
		test = ((GComponent)this).GetTransition("test");
		titleOut = ((GComponent)this).GetTransition("titleOut");
		AreaEarningsOut = ((GComponent)this).GetTransition("AreaEarningsOut");
		switchMapBtnOut = ((GComponent)this).GetTransition("switchMapBtnOut");
		CurEarningsOut = ((GComponent)this).GetTransition("CurEarningsOut");
	}

	public void Init(Dictionary<string, object> parameters)
	{
		FGUIManager.SetUiPanelSizeAndXy((GObject)(object)this, scaleAdaption: true);
		((GObject)this).sortingOrder = 99;
		WorldMapPanel = this;
		if (parameters.TryGetValue("Region", out var value))
		{
			focusedRegionId = value.ToString();
		}
		if (parameters.TryGetValue("FromBattleField", out var value2))
		{
			fromBattleField = (bool)value2;
			parentUiController = (IUiController)parameters["BattleField"];
		}
		((GObject)CurEarnings).SetPivot(0.5f, 1f, true);
		((GObject)CountdownBtn).visible = false;
		GetMapData();
		SetDragRange();
		RefreshMapUI();
		RefreshAreasUiVisible(_visible: false);
		ShowInitRegion();
	}

	public void RegisterUiEventListeners()
	{
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_001d: Expected O, but got Unknown
		//IL_0030: Unknown result type (might be due to invalid IL or missing references)
		//IL_003a: Expected O, but got Unknown
		//IL_004d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0057: Expected O, but got Unknown
		//IL_006f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0079: Expected O, but got Unknown
		//IL_008c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0096: Expected O, but got Unknown
		//IL_00ae: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b8: Expected O, but got Unknown
		//IL_00ed: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f7: Expected O, but got Unknown
		//IL_010a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0114: Expected O, but got Unknown
		//IL_0122: Unknown result type (might be due to invalid IL or missing references)
		//IL_012c: Expected O, but got Unknown
		((GObject)switchMapBtn).onClick.Add(new EventCallback0(SwitchPage));
		((GObject)backBtn).onClick.Add(new EventCallback0(End));
		((GObject)backBtn).onClick.Add(new EventCallback0(CheckCanShowEdgeMaskOnBack));
		((GObject)CurAreaEarnings.EnterBattlefieldBtn).onClick.Add(new EventCallback1(EnterBattlefield));
		((GObject)ManorSize).onClick.Add(new EventCallback0(OpenDevilUI));
		((GObject)CurEarnings.arrow).onClick.Add(new EventCallback0(CurEarningsListSwtich));
		((GObject)LastRegionBtn).data = -1;
		((GObject)NextRegionBtn).data = 1;
		((GObject)LastRegionBtn).onClick.Add(new EventCallback1(QuickChangeRegion));
		((GObject)NextRegionBtn).onClick.Add(new EventCallback1(QuickChangeRegion));
		((GObject)this).onClick.Add(new EventCallback0(GRootInstClick));
		SharedMessenger.AddListener<string, Dictionary<string, object>>("OPEN_UI", SetSoldierNum);
		SharedMessenger.AddListener<EventContext, string, int>("ON_SOLDIER_SELECTED", SetStrongholdSoldier);
		SharedMessenger.AddListener<List<string>>("REGION_PROD_PROGRESS_DONE", WorkerOnMapProgressBarRefresh);
		SharedMessenger.AddListener<List<string>>("REGION_PROD_AUTO_CLAIMED", PlayRegioProdAutoClaimedSfx);
		SharedMessenger.AddListener<List<string>>("STRONGHOLD_PROD_PROGRESS_DONE", CurRegionStrongholdsProgressBarRefresh);
		SharedMessenger.AddListener<string>("CLOSE_UI", CheckIsWorldMapTop);
		SharedMessenger.AddListener<string, int, (StockInContext, string)>("ON_STOCK_CHANGE", OnStockChange);
		SharedMessenger.AddListener<Cache_PrinceRedDot>(Cache_PrinceRedDot.ON_PAGE_REDDOT_CHANGE, OnPageRedDotChange);
	}

	public void UnregisterUiEventListeners()
	{
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_001d: Expected O, but got Unknown
		//IL_0030: Unknown result type (might be due to invalid IL or missing references)
		//IL_003a: Expected O, but got Unknown
		//IL_004d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0057: Expected O, but got Unknown
		//IL_006f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0079: Expected O, but got Unknown
		//IL_008c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0096: Expected O, but got Unknown
		//IL_00ae: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b8: Expected O, but got Unknown
		//IL_00cb: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d5: Expected O, but got Unknown
		//IL_00e8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f2: Expected O, but got Unknown
		//IL_0100: Unknown result type (might be due to invalid IL or missing references)
		//IL_010a: Expected O, but got Unknown
		((GObject)switchMapBtn).onClick.Remove(new EventCallback0(SwitchPage));
		((GObject)backBtn).onClick.Remove(new EventCallback0(End));
		((GObject)backBtn).onClick.Remove(new EventCallback0(CheckCanShowEdgeMaskOnBack));
		((GObject)CurAreaEarnings.EnterBattlefieldBtn).onClick.Remove(new EventCallback1(EnterBattlefield));
		((GObject)ManorSize).onClick.Remove(new EventCallback0(OpenDevilUI));
		((GObject)CurEarnings.arrow).onClick.Remove(new EventCallback0(CurEarningsListSwtich));
		((GObject)LastRegionBtn).onClick.Remove(new EventCallback1(QuickChangeRegion));
		((GObject)NextRegionBtn).onClick.Remove(new EventCallback1(QuickChangeRegion));
		((GObject)this).onClick.Remove(new EventCallback0(GRootInstClick));
		SharedMessenger.RemoveListener<string, Dictionary<string, object>>("OPEN_UI", SetSoldierNum);
		SharedMessenger.RemoveListener<EventContext, string, int>("ON_SOLDIER_SELECTED", SetStrongholdSoldier);
		SharedMessenger.RemoveListener<List<string>>("REGION_PROD_PROGRESS_DONE", WorkerOnMapProgressBarRefresh);
		SharedMessenger.RemoveListener<List<string>>("REGION_PROD_AUTO_CLAIMED", PlayRegioProdAutoClaimedSfx);
		SharedMessenger.RemoveListener<List<string>>("STRONGHOLD_PROD_PROGRESS_DONE", CurRegionStrongholdsProgressBarRefresh);
		SharedMessenger.RemoveListener<string>("CLOSE_UI", CheckIsWorldMapTop);
		SharedMessenger.RemoveListener<string, int, (StockInContext, string)>("ON_STOCK_CHANGE", OnStockChange);
		SharedMessenger.RemoveListener<Cache_PrinceRedDot>(Cache_PrinceRedDot.ON_PAGE_REDDOT_CHANGE, OnPageRedDotChange);
	}

	public void BeforeDestroy()
	{
		WorldMapPanel = null;
	}

	public void Destroy()
	{
		UiTagManager instance = UiTagManager.Instance;
		instance.Unregister("WorldMap.BattleBtn", CurAreaEarnings.EnterBattlefieldBtn);
		instance.Unregister("WorldMap.RegionFirstStrongholdBtn");
		instance.Unregister("WorldMap.RegionSecondStrongholdBtn");
		instance.Unregister("WorldMap.ForestMistRegion");
		if (RefreshLevelprogressBarCoroutine != null)
		{
			FGUIManager.Instance.CloseIEnumerator(RefreshLevelprogressBarCoroutine);
		}
		if (RefreshLevelAutoClaimedCutDownCoroutine != null)
		{
			FGUIManager.Instance.CloseIEnumerator(RefreshLevelAutoClaimedCutDownCoroutine);
		}
		if (PlayRegionProdAutoClaimedCoroutine != null)
		{
			FGUIManager.Instance.CloseIEnumerator(PlayRegionProdAutoClaimedCoroutine);
		}
		if (RefreshStrongholdProgressBarCoroutine != null)
		{
			FGUIManager.Instance.CloseIEnumerator(RefreshStrongholdProgressBarCoroutine);
		}
		UiAudioManager.Instance.SetMainCityBgmVolume(UiAudioManager.Instance.MaxUiBgmVolume);
		CloseEnterBattleGuide();
	}

	public void OnShow()
	{
		float num = 1.7777778f;
		float num2 = (float)Screen.width / (float)Screen.height;
		float num3 = num2 / num;
		if (num3 > 1f)
		{
			UnityUiService.Instance.edgeMaskPanel.SetMaskVisible(value: false);
		}
		else
		{
			UnityUiService.Instance.edgeMaskPanel.SetMaskVisible(value: true);
		}
		UiAudioManager.Instance.SetMainCityBgmVolume(UiAudioManager.Instance.MiddleBgmVolume);
		StartEnterBattleGuide();
	}

	public void CheckIsWorldMapTop(string str)
	{
		if (!(str == UI_Guide.Name))
		{
			UnityUiService.Instance.SetEdgeMaskVisible(UnityUiService.Instance.edgeMaskPanel.ratio <= 1f);
		}
	}

	private void SwitchPage()
	{
		//IL_0282: Unknown result type (might be due to invalid IL or missing references)
		//IL_0298: Unknown result type (might be due to invalid IL or missing references)
		//IL_02a2: Expected O, but got Unknown
		//IL_02bc: Unknown result type (might be due to invalid IL or missing references)
		//IL_02ed: Unknown result type (might be due to invalid IL or missing references)
		//IL_02f7: Expected O, but got Unknown
		if (pageController.selectedIndex == 0)
		{
			ToArea(selectedArea);
		}
		else
		{
			if (pageController.selectedIndex != 1)
			{
				return;
			}
			UiAudioManager.Instance.PlayBackgroundSound("send");
			pageController.selectedIndex = 0;
			((GObject)mainMapLoader).draggable = false;
			for (int i = 0; i < areaList.Count; i++)
			{
				((GObject)areaList[i].GetChild("strongholdsGroup").asGroup).visible = false;
			}
			for (int num = strongholdUIBackList.Count - 1; num >= 0; num--)
			{
				((GObject)strongholdUIBackList[num]).Dispose();
				strongholdUIBackList.RemoveAt(num);
			}
			if (blackHoleBack != null)
			{
				if (((GObject)blackHoleBack).data != null && ((GObject)blackHoleBack).parent == areaList[(int)((GObject)blackHoleBack).data])
				{
					areaList[(int)((GObject)blackHoleBack).data].RemoveChild((GObject)(object)blackHoleBack, true);
				}
				((GObject)blackHoleBack).visible = false;
			}
			for (int num2 = MoneyBtnList.Count - 1; num2 >= 0; num2--)
			{
				((GObject)MoneyBtnList[num2]).Dispose();
				MoneyBtnList.RemoveAt(num2);
			}
			if (workerOnMap != null)
			{
				((GObject)workerOnMap).visible = false;
			}
			if (warringLogo != null)
			{
				((GObject)warringLogo).visible = false;
			}
			ClearStrongldLevelTitles();
			if (selectedStronghold != null)
			{
				((GComponent)selectedStronghold).GetChild("icon").visible = false;
				selectedStronghold = null;
			}
			((GObject)switchMapBtn).touchable = false;
			RefreshAreasUiVisible(_visible: false);
			if (PlayRegionProdAutoClaimedCoroutine != null)
			{
				FGUIManager.Instance.CloseIEnumerator(PlayRegionProdAutoClaimedCoroutine);
			}
			((GObject)mainMapLoader).TweenMove(new Vector2(((GObject)this).width / 2f, ((GObject)this).height / 2f), 0.7f).OnComplete((GTweenCallback)delegate
			{
				if (RefreshStrongholdProgressBarCoroutine != null)
				{
					FGUIManager.Instance.CloseIEnumerator(RefreshStrongholdProgressBarCoroutine);
				}
				if (RefreshLevelprogressBarCoroutine != null)
				{
					FGUIManager.Instance.CloseIEnumerator(RefreshLevelprogressBarCoroutine);
				}
				if (RefreshLevelAutoClaimedCutDownCoroutine != null)
				{
					FGUIManager.Instance.CloseIEnumerator(RefreshLevelAutoClaimedCutDownCoroutine);
				}
				RefreshAreasUiVisible(_visible: true);
				RefreshMapUI();
				SetAreaStates();
			}).SetEase((EaseType)20);
			((GObject)mainMapLoader).TweenResize(new Vector2(((GObject)this).width, ((GObject)this).height), 0.7f).SetEase((EaseType)20);
			mainMapLoader.fill = (FillType)1;
			titleOut.PlayReverse((PlayCompleteCallback)delegate
			{
				//IL_0013: Unknown result type (might be due to invalid IL or missing references)
				//IL_001d: Expected O, but got Unknown
				((GComponent)(object)this).SetTimeout(0.3f).OnComplete((GTweenCallback)delegate
				{
					//IL_001a: Unknown result type (might be due to invalid IL or missing references)
					//IL_0024: Expected O, but got Unknown
					titleOut.Play();
					CurEarningsOut.Play((PlayCompleteCallback)delegate
					{
						((GObject)switchMapBtn).touchable = true;
					});
				});
			});
			AreaEarningsOut.PlayReverse();
		}
	}

	private void CheckCanShowEdgeMaskOnBack()
	{
		if (!UnityUiService.Instance.CheckIsMainCityShowed() && !UnityUiService.Instance.CheckIsClearUi())
		{
			UnityUiService.Instance.edgeMaskPanel.SetMaskVisible(value: true);
		}
	}

	public void End()
	{
		if (RefreshStrongholdProgressBarCoroutine != null)
		{
			FGUIManager.Instance.CloseIEnumerator(RefreshStrongholdProgressBarCoroutine);
		}
		if (RefreshLevelprogressBarCoroutine != null)
		{
			FGUIManager.Instance.CloseIEnumerator(RefreshLevelprogressBarCoroutine);
		}
		if (RefreshLevelAutoClaimedCutDownCoroutine != null)
		{
			FGUIManager.Instance.CloseIEnumerator(RefreshLevelAutoClaimedCutDownCoroutine);
		}
		if (PlayRegionProdAutoClaimedCoroutine != null)
		{
			FGUIManager.Instance.CloseIEnumerator(PlayRegionProdAutoClaimedCoroutine);
		}
		if (refreshSelectedAreaInfo != null)
		{
			FGUIManager.Instance.CloseIEnumerator(refreshSelectedAreaInfo);
		}
		if (workerOnMap != null)
		{
			((GObject)workerOnMap).Dispose();
		}
		for (int num = briefInfo.Count - 1; num >= 0; num--)
		{
			((GObject)briefInfo[num].Value).Dispose();
			briefInfo.RemoveAt(num);
		}
		if (warringLogo != null)
		{
			((GObject)warringLogo).visible = false;
		}
		ClearStrongldLevelTitles();
		for (int num2 = strongholdUIBackList.Count - 1; num2 >= 0; num2--)
		{
			((GObject)strongholdUIBackList[num2]).Dispose();
			strongholdUIBackList.RemoveAt(num2);
		}
		for (int i = 0; i < spineList.Count; i++)
		{
			SpawnManager.Instance.UnloadAnimation(spineList[i]);
		}
		if (!fromBattleField && FGUIManager.Instance.JudgBattleFieldExist())
		{
			CommandFactory.CreateOpenSceneCommand("MainCity.Right", new SceneArguments(new Dictionary<string, object>
			{
				{ "ForceCloseOtherUi", true },
				{ "TaskCompletionSource", null },
				{
					"LoadingAnimationDirection",
					LoadingAnimationDirection.Left
				}
			}));
		}
		if (parentUiController != null && parentUiController is UI_Battle)
		{
			((UI_Battle)parentUiController).UpdateMapBtnNote();
		}
		GameController.Contexts.Service<IUiService>().ClosePanel(Name);
		for (int j = 0; j < textureList.Count; j++)
		{
			AssetsManager.Instance.UnloadAsset<Texture2D>(textureList[j]);
		}
		if (GaussianBlurExist)
		{
			AssetsManager.Instance.UnloadAsset<Shader>("Gaussian blur");
		}
	}

	private void PlayOccupationEffect()
	{
		//IL_007a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0084: Expected O, but got Unknown
		//IL_0097: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a1: Expected O, but got Unknown
		//IL_00b4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00be: Expected O, but got Unknown
		if (OccupiedArea == null || OccupiedArea.Key == null)
		{
			return;
		}
		((GObject)mainMapLoader).draggable = false;
		((GObject)mapCom).touchable = false;
		SetBtnEnabled(btnEnabled: false);
		int num = areaList.IndexOf(selectedArea);
		((GComponent)(object)this).SetTimeout(0.5f).OnComplete((GTweenCallback)delegate
		{
			((GObject)briefInfo[num].Value).TweenFade(0f, 1f).SetEase((EaseType)5);
		});
		((GComponent)(object)this).SetTimeout(1.5f).OnComplete((GTweenCallback)delegate
		{
			//IL_009e: Unknown result type (might be due to invalid IL or missing references)
			OccupiedArea = new tKeyValue<GComponent, bool>(OccupiedArea.Key, val: true);
			InitAllAreaUI(init: true);
			((GObject)briefInfo[num].Value).alpha = 1f;
			FGUIManager.Instance.AddTextSpecialEffects(briefInfo[num].Value.GetChild("SfxBack").asGraph, "flag_slam", new Vector3(120f, 120f, 120f), "Default", 0.5f, delegate(GameObject flagSlam)
			{
				flagSlam.AddComponent<HotFix_DestroySelf>().destroyTime = 3f;
			});
		});
		((GComponent)(object)this).SetTimeout(3.5f).OnComplete((GTweenCallback)delegate
		{
			OccupiedArea = new tKeyValue<GComponent, bool>();
			SetBtnEnabled(btnEnabled: true);
			RefreshAreaUI();
			SetSuspendUi(selectedArea, state: false);
			SetAreaStates();
			((GObject)mapCom).touchable = true;
		});
	}

	private void SetInitRegion(string regionId)
	{
		if (!string.IsNullOrEmpty(regionId))
		{
			foreach (Region areaData in areaDataList)
			{
				if (areaData.RegionId == regionId)
				{
					focusedRegion = areaData;
					if (focusedRegion != areaDataList[occupyingIndex])
					{
						OccupiedArea = new tKeyValue<GComponent, bool>(areaList[areaDataList.IndexOf(focusedRegion)], val: false);
					}
					SetSelectAreaInfo(selectedArea, setOrGet: false);
					selectedArea = areaList[areaDataList.IndexOf(focusedRegion)];
					SetSelectAreaInfo(selectedArea, setOrGet: true);
					break;
				}
			}
		}
		if (focusedRegion == null)
		{
			focusedRegion = areaDataList[occupyingIndex];
		}
	}

	private void ShowInitRegion()
	{
		//IL_0014: Unknown result type (might be due to invalid IL or missing references)
		//IL_0055: Unknown result type (might be due to invalid IL or missing references)
		//IL_005a: Unknown result type (might be due to invalid IL or missing references)
		//IL_005b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0060: Unknown result type (might be due to invalid IL or missing references)
		//IL_0067: Unknown result type (might be due to invalid IL or missing references)
		//IL_006c: Unknown result type (might be due to invalid IL or missing references)
		//IL_006d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0078: Unknown result type (might be due to invalid IL or missing references)
		//IL_0082: Unknown result type (might be due to invalid IL or missing references)
		//IL_0087: Unknown result type (might be due to invalid IL or missing references)
		//IL_008c: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ac: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ae: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bb: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ca: Unknown result type (might be due to invalid IL or missing references)
		//IL_019f: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a9: Expected O, but got Unknown
		Vector2 aim = default(Vector2);
		GObject child = selectedArea.GetChild("cameraFocusPos");
		Vector2 val = default(Vector2);
		((Vector2)(ref val))._002Ector(((GObject)selectedArea).width / 2f, ((GObject)selectedArea).height / 2f);
		Vector2 val2 = child.xy - val;
		Vector2 val3 = ((GObject)selectedArea).xy + val2 - ((GObject)mapCom).size / 2f;
		aim = new Vector2(((GObject)this).width / 2f, ((GObject)this).height / 2f) - val3;
		aim = XyAmendment(aim);
		((GObject)ManorSize).alpha = 0f;
		((GObject)CurEarnings).alpha = 0f;
		((GObject)CurAreaEarnings).alpha = ((focusedRegion.Status(GameManagers.Instance) == RegionStatus.Battling || focusedRegion.Status(GameManagers.Instance) == RegionStatus.Occupied) ? 1 : 0);
		((GObject)CurAreaEarnings).touchable = focusedRegion.Status(GameManagers.Instance) == RegionStatus.Battling || focusedRegion.Status(GameManagers.Instance) == RegionStatus.Occupied;
		pageController.selectedIndex = 1;
		((GObject)switchMapBtn).touchable = false;
		UiAudioManager.Instance.PlayBackgroundSound("send");
		GTweenCallback val4 = default(GTweenCallback);
		GTweenCallback val7 = default(GTweenCallback);
		GTweenCallback val10 = default(GTweenCallback);
		((GComponent)(object)this).SetTimeout(0.5f).OnComplete((GTweenCallback)delegate
		{
			//IL_000d: Unknown result type (might be due to invalid IL or missing references)
			//IL_005e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0035: Unknown result type (might be due to invalid IL or missing references)
			//IL_003a: Unknown result type (might be due to invalid IL or missing references)
			//IL_003c: Expected O, but got Unknown
			//IL_0041: Expected O, but got Unknown
			GTweener obj = ((GObject)mainMapLoader).TweenMove(aim, 0.7f).SetEase((EaseType)20);
			GTweenCallback obj2 = val4;
			if (obj2 == null)
			{
				GTweenCallback val5 = delegate
				{
					//IL_0023: Unknown result type (might be due to invalid IL or missing references)
					//IL_0028: Unknown result type (might be due to invalid IL or missing references)
					//IL_002a: Expected O, but got Unknown
					//IL_002f: Expected O, but got Unknown
					//IL_0058: Unknown result type (might be due to invalid IL or missing references)
					//IL_005d: Unknown result type (might be due to invalid IL or missing references)
					//IL_005f: Expected O, but got Unknown
					//IL_0064: Expected O, but got Unknown
					GTweener obj3 = ((GComponent)(object)this).SetTimeout(0.42f);
					GTweenCallback obj4 = val7;
					if (obj4 == null)
					{
						GTweenCallback val8 = delegate
						{
							((GObject)ManorSize).alpha = 1f;
							((GObject)CurEarnings).alpha = 1f;
						};
						GTweenCallback val9 = val8;
						val7 = val8;
						obj4 = val9;
					}
					obj3.OnComplete(obj4);
					GTweener obj5 = ((GComponent)(object)this).SetTimeout(0.1f);
					GTweenCallback obj6 = val10;
					if (obj6 == null)
					{
						GTweenCallback val11 = delegate
						{
							titleOut.Play();
						};
						GTweenCallback val9 = val11;
						val10 = val11;
						obj6 = val9;
					}
					obj5.OnComplete(obj6);
					RefreshAreaUI();
					SetSuspendUi(selectedArea, state: false);
					SetAreaStates();
					((GObject)mapCom).touchable = true;
					PlayOccupationEffect();
				};
				GTweenCallback val6 = val5;
				val4 = val5;
				obj2 = val6;
			}
			obj.OnComplete(obj2);
			((GObject)mainMapLoader).TweenResize(((GObject)mapCom).size, 0.7f).SetEase((EaseType)20);
		});
	}

	private void ToArea(GComponent area, bool _drag = false, bool returnOnRegion = false)
	{
		//IL_003b: Unknown result type (might be due to invalid IL or missing references)
		//IL_007c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0081: Unknown result type (might be due to invalid IL or missing references)
		//IL_0083: Unknown result type (might be due to invalid IL or missing references)
		//IL_0088: Unknown result type (might be due to invalid IL or missing references)
		//IL_0090: Unknown result type (might be due to invalid IL or missing references)
		//IL_0095: Unknown result type (might be due to invalid IL or missing references)
		//IL_0097: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ac: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00dc: Unknown result type (might be due to invalid IL or missing references)
		//IL_00de: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e9: Unknown result type (might be due to invalid IL or missing references)
		//IL_031d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0322: Unknown result type (might be due to invalid IL or missing references)
		//IL_0323: Unknown result type (might be due to invalid IL or missing references)
		//IL_0328: Unknown result type (might be due to invalid IL or missing references)
		//IL_0395: Unknown result type (might be due to invalid IL or missing references)
		//IL_039f: Expected O, but got Unknown
		//IL_0608: Unknown result type (might be due to invalid IL or missing references)
		//IL_0617: Unknown result type (might be due to invalid IL or missing references)
		//IL_0621: Expected O, but got Unknown
		//IL_026c: Unknown result type (might be due to invalid IL or missing references)
		//IL_027e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0288: Expected O, but got Unknown
		//IL_029c: Unknown result type (might be due to invalid IL or missing references)
		//IL_02c0: Unknown result type (might be due to invalid IL or missing references)
		//IL_02ca: Expected O, but got Unknown
		int index = areaList.IndexOf(area);
		Region areaData = areaDataList[index];
		Vector2 val = default(Vector2);
		GObject child = area.GetChild("cameraFocusPos");
		Vector2 val2 = default(Vector2);
		((Vector2)(ref val2))._002Ector(((GObject)area).width / 2f, ((GObject)area).height / 2f);
		Vector2 val3 = child.xy - val2;
		Vector2 val4 = ((GObject)area).xy + val3 - ((GObject)mapCom).size / 2f;
		val = new Vector2(((GObject)this).width / 2f, ((GObject)this).height / 2f) - val4;
		val = XyAmendment(val);
		if (pageController.selectedIndex == 0)
		{
			UiAudioManager.Instance.PlayBackgroundSound("send");
			KeyValuePair<float, GComponent> keyValuePair = briefInfo[index];
			if (keyValuePair.Value != null && Mathf.Abs(keyValuePair.Key - 1f) < float.Epsilon)
			{
				GameManagers.Instance.NewMsgIncomingManager.CheckRegion(areaData.RegionId);
				GObject child2 = keyValuePair.Value.GetChild("ExclamationTipBtn");
				if (child2 == null)
				{
					ILRuntimeDebug.LogError("[WorldMap.ToArea]" + areaData.Data.Name + "顶部红点检查，未找到组件ExclamationTipBtn");
				}
				else
				{
					child2.visible = false;
				}
			}
			pageController.selectedIndex = 1;
			if (areaData.RegionProgress(GameManagers.Instance) < 0.0001f && areaData.Status(GameManagers.Instance) != RegionStatus.Battling)
			{
				((GObject)CurAreaEarnings).alpha = 0f;
				((GObject)CurAreaEarnings).touchable = false;
			}
			else
			{
				((GObject)CurAreaEarnings).alpha = 1f;
				((GObject)CurAreaEarnings).touchable = true;
			}
			((GObject)switchMapBtn).touchable = false;
			RefreshAreasUiVisible(_visible: false);
			CurEarningsListInit();
			((GObject)mainMapLoader).TweenMove(val, 0.7f).OnComplete((GTweenCallback)delegate
			{
				if (!((GObject)this).isDisposed)
				{
					if (selectedArea == null)
					{
						selectedArea = area;
						SetSelectAreaInfo(area, setOrGet: true);
					}
					else if (selectedArea != area)
					{
						SetSelectAreaInfo(selectedArea, setOrGet: false);
						selectedArea = area;
						SetSelectAreaInfo(area, setOrGet: true);
					}
					RefreshAreaUI();
					SetAreaStates();
					RefreshAreasUiVisible(_visible: false);
					SetSuspendUi(selectedArea, state: false);
					SetPageBtnStatus();
				}
			}).SetEase((EaseType)20);
			((GObject)mainMapLoader).TweenResize(((GObject)mapCom).size, 0.7f).SetEase((EaseType)20);
			GTweenCallback val6 = default(GTweenCallback);
			titleOut.PlayReverse((PlayCompleteCallback)delegate
			{
				//IL_0023: Unknown result type (might be due to invalid IL or missing references)
				//IL_0028: Unknown result type (might be due to invalid IL or missing references)
				//IL_002a: Expected O, but got Unknown
				//IL_002f: Expected O, but got Unknown
				GTweener obj = ((GComponent)(object)this).SetTimeout(0.3f);
				GTweenCallback obj2 = val6;
				if (obj2 == null)
				{
					GTweenCallback val7 = delegate
					{
						if (!((GObject)this).isDisposed)
						{
							titleOut.Play();
						}
					};
					GTweenCallback val8 = val7;
					val6 = val7;
					obj2 = val8;
				}
				obj.OnComplete(obj2);
			});
			CurEarningsOut.PlayReverse();
		}
		else
		{
			if (pageController.selectedIndex != 1 || returnOnRegion)
			{
				return;
			}
			UiAudioManager.Instance.PlayBackgroundSound("send");
			Vector2 val5 = ((GObject)mainMapLoader).xy - val;
			float num = ((Vector2)(ref val5)).sqrMagnitude / 1200000f * 1f;
			if (num < 0.25f)
			{
				num = 0.25f;
			}
			if (!_drag)
			{
				titleOut.PlayReverse();
				AreaEarningsOut.PlayReverse();
				RefreshAreasUiVisible(_visible: false);
			}
			((GComponent)(object)this).SetTimeout(0.21f).OnComplete((GTweenCallback)delegate
			{
				if (!((GObject)this).isDisposed)
				{
					if (areaData.RegionProgress(GameManagers.Instance) < 0.0001f && areaData.Status(GameManagers.Instance) != RegionStatus.Battling)
					{
						((GObject)CurAreaEarnings).alpha = 0f;
						((GObject)CurAreaEarnings).touchable = false;
					}
					else
					{
						((GObject)CurAreaEarnings).alpha = 1f;
						((GObject)CurAreaEarnings).touchable = true;
					}
				}
			});
			if (selectedArea != area)
			{
				for (int num2 = strongholdUIBackList.Count - 1; num2 >= 0; num2--)
				{
					((GObject)strongholdUIBackList[num2]).Dispose();
					strongholdUIBackList.RemoveAt(num2);
				}
				if (warringLogo != null)
				{
					((GObject)warringLogo).visible = false;
				}
				if (workerOnMap != null)
				{
					((GObject)workerOnMap).visible = false;
				}
				ClearStrongldLevelTitles();
				if (blackHoleBack != null)
				{
					if (((GObject)blackHoleBack).data != null && ((GObject)blackHoleBack).parent == areaList[(int)((GObject)blackHoleBack).data])
					{
						areaList[(int)((GObject)blackHoleBack).data].RemoveChild((GObject)(object)blackHoleBack);
					}
					((GObject)blackHoleBack).visible = false;
				}
				if (PlayRegionProdAutoClaimedCoroutine != null)
				{
					FGUIManager.Instance.CloseIEnumerator(PlayRegionProdAutoClaimedCoroutine);
				}
				for (int num3 = MoneyBtnList.Count - 1; num3 >= 0; num3--)
				{
					((GObject)MoneyBtnList[num3]).Dispose();
					MoneyBtnList.RemoveAt(num3);
				}
				if (selectedStronghold != null)
				{
					((GComponent)selectedStronghold).GetChild("icon").visible = false;
					selectedStronghold = null;
				}
				GObject child3 = selectedArea.GetChild("strongholdsGroup");
				if (child3 == null)
				{
					ILRuntimeDebug.LogError("[WorldMap.ToArea] " + areaData.Data.Name + "据点渲染，未找到组件strongholdsGroup");
					return;
				}
				if (child3.asGroup == null)
				{
					ILRuntimeDebug.LogError("[WorldMap.ToArea] " + areaData.Data.Name + "据点渲染，strongholdsGroup组件不是Group");
					return;
				}
				((GObject)child3.asGroup).visible = false;
			}
			((GObject)switchMapBtn).touchable = false;
			((GObject)mainMapLoader).TweenMove(val, num).OnComplete((GTweenCallback)delegate
			{
				if (!((GObject)this).isDisposed)
				{
					RefreshAreasUiVisible(_visible: false);
					if (selectedArea != area)
					{
						RefreshAreasUiVisible(_visible: false);
						SetSelectAreaInfo(selectedArea, setOrGet: false);
						SetSuspendUi(selectedArea, state: true);
						selectedArea = area;
						SetSelectAreaInfo(area, setOrGet: true);
						RefreshAreaUI();
						SetAreaStates();
						SetPageBtnStatus();
					}
					else
					{
						SetSuspendUi(selectedArea, state: false);
						SetPageBtnStatus();
					}
					titleOut.Play();
				}
			}).SetEase((EaseType)9);
		}
	}

	private void SetStrongholdLine(GButton prior, GButton latter)
	{
		//IL_000f: Unknown result type (might be due to invalid IL or missing references)
		//IL_001a: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0024: Unknown result type (might be due to invalid IL or missing references)
		//IL_0058: Unknown result type (might be due to invalid IL or missing references)
		//IL_0059: Unknown result type (might be due to invalid IL or missing references)
		//IL_008e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0098: Expected O, but got Unknown
		Vector2 val = ((GObject)latter).xy - ((GObject)prior).xy;
		Vector2 val2 = default(Vector2);
		((Vector2)(ref val2))._002Ector(0f, 1f);
		((GObject)((GComponent)prior).GetChild("line").asButton).height = ((Vector2)(ref val)).magnitude;
		float rotation = Vector2.SignedAngle(val2, val);
		((GObject)((GComponent)prior).GetChild("line").asButton).rotation = rotation;
		((GComponent)(object)this).SetTimeout(1.025f).OnComplete((GTweenCallback)delegate
		{
			if (!((GObject)prior).isDisposed)
			{
				((GComponent)prior).GetChild("line").visible = true;
			}
		});
	}

	private void RefreshAreasUiVisible(bool _visible)
	{
		for (int i = 0; i < briefInfo.Count; i++)
		{
			if (((GObject)areaList[i]).name == "Unknown1" || ((GObject)areaList[i]).name == "Unknown2")
			{
				((GObject)briefInfo[i].Value).visible = false;
			}
			else if (areaDataList[i].RegionProgress(GameManagers.Instance) <= 0.0001f && areaDataList[i].Status(GameManagers.Instance) == RegionStatus.Locked)
			{
				((GObject)briefInfo[i].Value).visible = false;
			}
			else
			{
				((GObject)briefInfo[i].Value).visible = _visible;
			}
		}
	}

	private void SetAreaStates()
	{
		for (int i = 0; i < areaList.Count; i++)
		{
			GImage asImage = areaList[i].GetChild("icon").asImage;
			int num = areaList.IndexOf(selectedArea);
			if (num == i)
			{
				if (areaDataList[i].RegionProgress(GameManagers.Instance) > 0f)
				{
					((GObject)areaList[i].GetChild("mask").asImage).SetSize(((GObject)asImage).width, ((GObject)asImage).height);
					if (areaDataList[i].Data.Prefab != "Unknown2" && areaDataList[i].Data.Prefab != "Unknown1")
					{
						((GObject)((GComponent)mapCom).GetChild("Clouds").asCom.GetChild(areaDataList[i].Data.Prefab + "_Cloud").asImage).visible = false;
					}
				}
				else
				{
					((GObject)areaList[i].GetChild("mask").asImage).SetSize(((GObject)asImage).width, ((GObject)asImage).height);
					if (areaDataList[i].Data.Prefab != "Unknown2" && areaDataList[i].Data.Prefab != "Unknown1")
					{
						((GObject)((GComponent)mapCom).GetChild("Clouds").asCom.GetChild(areaDataList[i].Data.Prefab + "_Cloud").asImage).visible = true;
					}
				}
			}
			else
			{
				((GObject)areaList[i].GetChild("mask").asImage).SetSize(((GObject)asImage).width, ((GObject)asImage).height);
				if (areaDataList[i].RegionProgress(GameManagers.Instance) > 0f)
				{
					if (areaDataList[i].Data.Prefab != "Unknown2" && areaDataList[i].Data.Prefab != "Unknown1")
					{
						((GObject)((GComponent)mapCom).GetChild("Clouds").asCom.GetChild(areaDataList[i].Data.Prefab + "_Cloud").asImage).visible = false;
					}
				}
				else if (areaDataList[i].Data.Prefab != "Unknown2" && areaDataList[i].Data.Prefab != "Unknown1")
				{
					((GObject)((GComponent)mapCom).GetChild("Clouds").asCom.GetChild(areaDataList[i].Data.Prefab + "_Cloud").asImage).visible = true;
				}
			}
			if (occupyingIndex != i)
			{
				continue;
			}
			if (GameManagers.Instance.UserArchiveManager.CheckRegionUnlockBonusesClaimed(areaDataList[i].RegionId))
			{
				if (areaDataList[i].Data.Prefab != "Unknown2" && areaDataList[i].Data.Prefab != "Unknown1")
				{
					((GObject)((GComponent)mapCom).GetChild("Clouds").asCom.GetChild(areaDataList[i].Data.Prefab + "_Cloud").asImage).visible = false;
				}
			}
			else if (areaDataList[i].Data.Prefab != "Unknown2" && areaDataList[i].Data.Prefab != "Unknown1")
			{
				((GObject)((GComponent)mapCom).GetChild("Clouds").asCom.GetChild(areaDataList[i].Data.Prefab + "_Cloud").asImage).visible = true;
			}
			((GObject)areaList[i].GetChild("mask").asImage).SetSize(((GObject)asImage).width, ((GObject)asImage).height);
		}
	}

	private void RefreshAreaUI()
	{
		int num = areaList.IndexOf(selectedArea);
		Region region = areaDataList[num];
		if (region.RegionProgress(GameManagers.Instance) <= float.Epsilon && region.Status(GameManagers.Instance) != RegionStatus.Battling && num != occupyingIndex)
		{
			TitleGroup.isUnlocked.SetSelectedIndex(0);
		}
		else
		{
			TitleGroup.isUnlocked.SetSelectedIndex(1);
			TitleGroup.n18.url = GetFguiAreaNameUrl(region);
		}
		((GObject)CurAreaEarnings.percentage).text = ((region.RegionProgress(GameManagers.Instance) <= float.Epsilon) ? "--" : (UiHelper.RemoveSurplusZeroBehindDecimalPoint($"{region.RegionProgress(GameManagers.Instance) * 100f:####}") + "%"));
		((GObject)CurAreaEarnings.curAreaInstructions).text = region.Desc ?? "";
		((GObject)briefInfo[num].Value).visible = false;
		((GObject)CurAreaEarnings.EnterBattlefieldBtn).visible = num == occupyingIndex && areaDataList[occupyingIndex].Status(GameManagers.Instance) == RegionStatus.Battling;
		if (OccupiedArea == null || OccupiedArea.Key == null || selectedArea != OccupiedArea.Key)
		{
			RefreshSelectedAreaInfo();
		}
		UiTagManager instance = UiTagManager.Instance;
		instance.Register("WorldMap.BattleBtn", CurAreaEarnings.EnterBattlefieldBtn);
	}

	private void RefreshMapUI()
	{
		TitleGroup.isUnlocked.SetSelectedIndex(0);
		SetTitleRedPoint();
		int num = 0;
		int num2 = 0;
		for (int i = 1; i < areaDataList.Count; i++)
		{
			if (areaDataList[i].Chapters != null && areaDataList[i].Chapters.Count > 0 && !string.IsNullOrEmpty(areaDataList[i].RegionId))
			{
				num++;
				if (areaDataList[i].RegionProgress(GameManagers.Instance) >= 0.9999f && areaDataList[i].RegionProgress(GameManagers.Instance) <= 1.0001f)
				{
					num2++;
				}
			}
		}
		((GObject)CurEarnings.conquestNum).text = $"{num2}/{num}";
		RenderTotalProductionsList();
		if (selectedArea != null)
		{
			int num3 = areaList.IndexOf(selectedArea);
			if (num3 != -1 && areaDataList[num3].RegionProgress(GameManagers.Instance) <= 0.0001f && areaDataList[num3].Status(GameManagers.Instance) == RegionStatus.Locked)
			{
				((GObject)briefInfo[num3].Value).visible = false;
			}
		}
	}

	private void ClearStrongldLevelTitles()
	{
		for (int num = StrongldLevelTitles.Count - 1; num >= 0; num--)
		{
			((GObject)StrongldLevelTitles[num]).Dispose();
		}
		StrongldLevelTitles.Clear();
	}

	private void RefreshSelectedAreaInfo()
	{
		AreaEarningsOut.Stop();
		if (refreshSelectedAreaInfo != null)
		{
			FGUIManager.Instance.CloseIEnumerator(refreshSelectedAreaInfo);
		}
		refreshSelectedAreaInfo = FGUIManager.Instance.OpenIEnumerator(Real_RefreshSelectedAreaInfo());
	}

	private IEnumerator Real_RefreshSelectedAreaInfo()
	{
		for (int i = strongholdUIBackList.Count - 1; i >= 0; i--)
		{
			((GObject)strongholdUIBackList[i]).Dispose();
			strongholdUIBackList.RemoveAt(i);
		}
		Region region = areaDataList[areaList.IndexOf(selectedArea)];
		((GObject)CountdownBtn).visible = false;
		if (region.Status(GameManagers.Instance) == RegionStatus.Locked)
		{
			((GObject)switchMapBtn).touchable = true;
			yield break;
		}
		if (region.Status(GameManagers.Instance) == RegionStatus.Unlocked)
		{
			((GObject)switchMapBtn).touchable = true;
			yield break;
		}
		if (region.Chapters == null)
		{
			((GObject)switchMapBtn).touchable = true;
			yield break;
		}
		if (warringLogo != null && region.Status(GameManagers.Instance) == RegionStatus.Battling)
		{
			((GObject)warringLogo).visible = true;
		}
		ScriptApi.CreateTimer(0.15f * (float)strongholdUIBackList.Count, delegate
		{
			SharedMessenger.Broadcast("WOLRDMAP_ON_STRONGHOLD_SHOWUP", region);
		});
		SetBtnEnabled(btnEnabled: false);
		((GObject)selectedArea.GetChild("strongholdsGroup").asGroup).visible = true;
		ClearStrongldLevelTitles();
		curRegionStrongholdsBars.Clear();
		curRegionLevelClips.Clear();
		if (region.Status(GameManagers.Instance) == RegionStatus.Occupied || (region.Status(GameManagers.Instance) == RegionStatus.Battling && region.RegionProgress(GameManagers.Instance) >= 1E-05f))
		{
			WorkerOnMapProgressBarInit();
			((GObject)CountdownBtn).visible = false;
		}
		else
		{
			((GObject)CountdownBtn).visible = false;
		}
		if (region.Status(GameManagers.Instance) == RegionStatus.Occupied)
		{
			GetCurRegionStrongholdsProduceProgress(region);
		}
		int strongholdIndex = 0;
		for (int chapter_idx = 0; chapter_idx < region.Chapters.Count; chapter_idx++)
		{
			Chapter chapter = region.Chapters[chapter_idx];
			List<string> chapterProgress = GameManagers.Instance.UserArchiveManager.GetChapterLevelProgress(chapter.ChapterId);
			string curLevelId = GameManagers.Instance.UserArchiveManager.GetCurrentLevelId();
			GButton lastStrongholdBtn = null;
			for (int i2 = 0; i2 < chapter.Level_IDs.Count; i2++)
			{
				GObject child = selectedArea.GetChild($"stronghold{i2 + 1}");
				GButton strongholdBtn = ((child != null) ? child.asButton : null);
				if (strongholdBtn == null)
				{
					Debug.LogWarning((object)$"{region.RegionId} stronghold{i2 + 1} 组件没有找到");
				}
				else
				{
					((GObject)strongholdBtn).visible = false;
				}
			}
			for (int i3 = 0; i3 < chapter.Level_IDs.Count; i3++)
			{
				Level level = chapter.GetLevels(i3);
				GObject child2 = selectedArea.GetChild($"stronghold{i3 + 1}");
				GButton strongholdBtn2 = ((child2 != null) ? child2.asButton : null);
				if (strongholdBtn2 == null)
				{
					Debug.LogWarning((object)$"{region.RegionId} stronghold{i3 + 1} 组件没有找到");
					continue;
				}
				((GObject)strongholdBtn2).data = level.LevelId;
				((GObject)strongholdBtn2).visible = true;
				((GObject)strongholdBtn2).alpha = 0f;
				((GComponent)strongholdBtn2).GetChild("line").visible = false;
				if (chapterProgress.Contains(level.LevelId))
				{
					if ((i3 + 1) % 5 == 0)
					{
						((GComponent)strongholdBtn2).GetChild("icon").visible = true;
					}
					else
					{
						((GComponent)strongholdBtn2).GetChild("icon").visible = true;
						((GComponent)strongholdBtn2).GetChild("icon").alpha = 1f;
						((GComponent)strongholdBtn2).GetChild("icon").asCom.GetController("PageController").selectedIndex = 1;
						GMovieClip _clip = ((GComponent)((GComponent)strongholdBtn2).GetChild("icon").asCom.GetChild("WaveMask").asButton).GetChild("wave").asMovieClip;
						float val = UiHelper.GetLevelMoneyOutput(level.LevelId);
						((GObject)_clip).data = 3600f / val;
						((GObject)_clip).y = 36f * (float)Random.Range(0, 100) / 100f;
						curRegionLevelClips[level.LevelId] = _clip;
					}
					((GComponent)strongholdBtn2).GetChild("line").alpha = 0.5f;
				}
				else
				{
					if ((i3 + 1) % 5 == 0)
					{
						((GComponent)strongholdBtn2).GetChild("icon").visible = true;
					}
					else
					{
						((GComponent)strongholdBtn2).GetChild("icon").visible = true;
						((GComponent)strongholdBtn2).GetChild("icon").alpha = 1f;
						((GComponent)strongholdBtn2).GetChild("icon").asCom.GetController("PageController").selectedIndex = 0;
					}
					((GComponent)strongholdBtn2).GetChild("line").alpha = 1f;
				}
				if ((region.Status(GameManagers.Instance) != RegionStatus.Occupied && string.IsNullOrEmpty(curLevelId) && i3 == 0) || curLevelId == level.LevelId)
				{
					if (warringLogo == null)
					{
						warringLogo = UI_warringLogo.CreateInstance_ILRuntime();
					}
					float scaleUp = ((HotUpdateProcess.LanguageKey == "eng") ? 1.5f : 2f);
					float logoScale = (level.IsTitled ? scaleUp : 1f);
					int logoOffsetY = (level.IsTitled ? 20 : 10);
					Vector2 logoOffset = new Vector2(0f, (float)logoOffsetY);
					float logoX = ((GObject)selectedArea).x - ((GObject)selectedArea).width / 2f + ((GObject)strongholdBtn2).x + logoOffset.x;
					float logoY = ((GObject)selectedArea).y - ((GObject)selectedArea).height / 2f + ((GObject)strongholdBtn2).y + logoOffset.y;
					curLevelPos = new Vector2(logoX - logoOffset.x, logoY - logoOffset.y);
					((GObject)warringLogo.levelName).text = string.Format("{0}{1}", LanguagesManager.GetDesc("CsharpCodeZhTcText648"), i3 + 1);
					((GObject)warringLogo).SetXY(logoX, logoY);
					((GObject)warringLogo).SetScale(logoScale, logoScale);
					((GComponent)warringLogo).GetController("PageController").selectedIndex = 0;
					((GComponent)mapCom).GetChild("UILayer").asCom.AddChild((GObject)(object)warringLogo);
				}
				else if (region.Status(GameManagers.Instance) != RegionStatus.Occupied && (i3 + 1) % 5 == 0 && !chapterProgress.Contains(level.LevelId) && level.IsTitled)
				{
					UI_warringLogo _levelTitle = UI_warringLogo.CreateInstance_ILRuntime();
					float logoScale2 = ((HotUpdateProcess.LanguageKey == "eng") ? 1.5f : 2f);
					int logoOffsetY2 = 20;
					Vector2 logoOffset2 = new Vector2(0f, (float)logoOffsetY2);
					float logoX2 = ((GObject)selectedArea).x - ((GObject)selectedArea).width / 2f + ((GObject)strongholdBtn2).x + logoOffset2.x;
					float logoY2 = ((GObject)selectedArea).y - ((GObject)selectedArea).height / 2f + ((GObject)strongholdBtn2).y + logoOffset2.y;
					((GObject)_levelTitle.levelName).text = string.Format("{0}{1}", LanguagesManager.GetDesc("CsharpCodeZhTcText648"), i3 + 1);
					((GObject)_levelTitle).SetXY(logoX2, logoY2);
					((GObject)_levelTitle).SetScale(logoScale2, logoScale2);
					((GComponent)_levelTitle).GetController("PageController").selectedIndex = 1;
					((GComponent)mapCom).GetChild("UILayer").asCom.AddChild((GObject)(object)_levelTitle);
					StrongldLevelTitles.Add(_levelTitle);
				}
				if (!chapterProgress.Contains(level.LevelId) && level.IsTitled)
				{
					strongholdIndex++;
					((GObject)strongholdBtn2).touchable = true;
					((GComponent)strongholdBtn2).GetChild("icon").visible = false;
					UI_strongholdUIBack uiBack = CreateStrongholdUiBackTo((GObject)(object)strongholdBtn2, ((float)strongholdIndex + 0.5f) * 0.15f, isStronghold: true);
					uiBack.pageController.selectedIndex = 1;
					List<string> rewardList = level.TitleBonus;
					Dictionary<string, int> countDict = new Dictionary<string, int>();
					bool isGuideMode5 = GameManagers.Instance.UserArchiveManager.IsNewGuideMode5() || GameManagers.Instance.UserArchiveManager.IsNewGuideForeignMode5();
					bool isGuideMode6 = GameManagers.Instance.UserArchiveManager.IsNewGuideMode6() || GameManagers.Instance.UserArchiveManager.IsNewGuideForeignMode6();
					bool isGuideMode7 = GameManagers.Instance.UserArchiveManager.IsNewGuideMode7();
					if (isGuideMode5 || isGuideMode6 || isGuideMode7)
					{
						List<GuideMode5SpecialLevel> config = GuideMode5SpecialLevel.GetConfig();
						int targetIndex = 0;
						GuideMode5SpecialLevel target = config.Find((GuideMode5SpecialLevel x) => x.LevelId == level.LevelId);
						if (target != null)
						{
							rewardList = target.Rewards.Keys.ToList();
							if (rewardList.Count == 1)
							{
								string itemID = rewardList[0];
								int count = target.Rewards[itemID];
								targetIndex = ((count != 20) ? 1 : 2);
							}
							else if (rewardList.Count == 2)
							{
								int count2 = target.Rewards[rewardList[0]];
								targetIndex = ((count2 == 20) ? 4 : 3);
							}
						}
						uiBack.rewardType.SetSelectedIndex(targetIndex);
					}
					else
					{
						foreach (KeyValuePair<Bonus, int> levelBonu in level.GetLevelBonus(GameManagers.Instance))
						{
							Bonus bonus = levelBonu.Key;
							countDict.Add(bonus.ItemId, bonus.Qty);
						}
					}
					if (rewardList.Count > 1)
					{
						((GObject)uiBack.single).visible = true;
					}
					else
					{
						((GObject)uiBack.multiple).visible = true;
					}
					foreach (string itemId in rewardList)
					{
						UI_rewardBack5 bonusBtn = (UI_rewardBack5)(object)uiBack.BonusList.AddItemFromPool();
						((GObject)bonusBtn.num).text = "";
						FGUIManager.Instance.SetItemIconAndFrame(bonusBtn.icon, itemId, textureList, "", frameVisible: false);
						if (Item.IsShining(itemId) == 2)
						{
							((GObject)bonusBtn.fxBack).displayObject.Dispose();
							FGUIManager.Instance.AddTextSpecialEffects(bonusBtn.fxBack, "activated_fx", new Vector3(80f, 80f, 80f));
						}
						if (countDict.TryGetValue(itemId, out var count3))
						{
							((GObject)bonusBtn.num).text = $"{count3}";
						}
						((GObject)bonusBtn).onClick.Set((EventCallback0)delegate
						{
							UiAudioManager.Instance.PlaySoundEffect("GeneralClick");
							FGUIManager.Instance.ItemTip(itemId, ((GObject)this).sortingOrder, noCheckBtn: true);
						});
					}
				}
				else if (region.Status(GameManagers.Instance) == RegionStatus.Occupied && (i3 + 1) % 5 == 0)
				{
					if (strongholdIndex >= region.Strongholds.Count)
					{
						Debug.LogWarning((object)string.Format("{0}{1}:{2}/{3}", LanguagesManager.GetDesc("CsharpCodeZhTcText649"), region.RegionId, strongholdIndex, region.Strongholds.Count));
						continue;
					}
					Stronghold stronghold = region.Strongholds[strongholdIndex++];
					((GObject)strongholdBtn2).touchable = false;
					((GComponent)strongholdBtn2).GetChild("icon").visible = false;
					UI_strongholdUIBack uiBack2 = CreateStrongholdUiBackTo((GObject)(object)strongholdBtn2, ((float)strongholdIndex + 0.5f) * 0.15f, isStronghold: true);
					uiBack2.pageController.selectedIndex = 0;
					((GComponent)uiBack2).GetChild("soldierIconFrame").data = stronghold;
					((GComponent)uiBack2).GetChild("soldierIconFrame").onClick.Set(new EventCallback1(OpenLegionUi));
					float outputNum = 0f;
					string outputItemId = "";
					if (stronghold.ProductionsConfig != null)
					{
						using Dictionary<string, int>.Enumerator enumerator3 = stronghold.ProductionsConfig.GetEnumerator();
						if (enumerator3.MoveNext())
						{
							KeyValuePair<string, int> prodKv = enumerator3.Current;
							outputNum = prodKv.Value;
							((GComponent)uiBack2).GetChild("goodIcon").asLoader.url = "ui://PublicResources/" + UiHelper.GetIconPath(prodKv.Key);
							outputItemId = prodKv.Key;
							((GComponent)uiBack2).GetChild("goodIcon").touchable = true;
							((GComponent)uiBack2).GetChild("goodIcon").onClick.Set((EventCallback0)delegate
							{
								FGUIManager.Instance.ItemTip(prodKv.Key, ((GObject)this).sortingOrder, noCheckBtn: true);
								UiAudioManager.Instance.PlaySoundEffect("GeneralClick");
							});
						}
					}
					((GComponent)uiBack2).GetChild("outputNum").visible = false;
					GLoader prodIcon = ((GComponent)uiBack2).GetChild("goodIcon").asLoader;
					GTextField prodDesc = ((GComponent)uiBack2).GetChild("outputTitle").asTextField;
					GLoader occupantIcon = ((GComponent)uiBack2).GetChild("soldierIcon").asLoader;
					GLoader prodIconFrame = ((GComponent)uiBack2).GetChild("soldierIconFrame").asLoader;
					GProgressBar progressBar = ((GComponent)uiBack2).GetChild("ProgressBarForUi").asProgress;
					GObject progressMax = ((GComponent)uiBack2).GetChild("MaxIcon");
					GGroup modifierGroup = ((GComponent)uiBack2).GetChild("modifierGroup").asGroup;
					GObject note = ((GComponent)uiBack2).GetChild("note");
					GTextField modifierText = ((GComponent)uiBack2).GetChild("modifierText").asTextField;
					if (!curRegionStrongholdsBars.ContainsKey(stronghold.StrongholdId))
					{
						curRegionStrongholdsBars.Add(stronghold.StrongholdId, progressBar);
					}
					else
					{
						curRegionStrongholdsBars[stronghold.StrongholdId] = progressBar;
					}
					if (stronghold.IsOccupied(GameManagers.Instance))
					{
						((GObject)prodIcon).grayed = false;
						((GObject)progressBar).visible = true;
						((GObject)modifierGroup).visible = true;
						note.visible = false;
						float modifier = stronghold.CalcOccupantEfficiencyModifier(GameManagers.Instance, stronghold.Occupant(GameManagers.Instance));
						((GObject)modifierText).text = "[color=" + UiHelper.GetStrongHoldModifierColor(modifier) + "]+" + UiHelper.RemoveSurplusZeroBehindDecimalPoint($"{Convert.ToInt32(modifier * 100f)}") + "%[/color]";
						int currentStock = GameManagers.Instance.StockController.GetStock(outputItemId);
						int stockLimit = GameManagers.Instance.StockController.GetLimit(outputItemId);
						progressMax.visible = currentStock >= stockLimit;
						occupantIcon.url = "ui://PublicResources/" + UiHelper.GetIconPath(stronghold.Occupant(GameManagers.Instance));
						Soldier soldier = GameManagers.Instance.SoldierManager.Get(stronghold.Occupant(GameManagers.Instance));
						string soldierFrameIconName = UiHelper.GetIconFrameBorderSoldier(soldier.PotentialLevel);
						prodIconFrame.url = "ui://PublicResources/" + soldierFrameIconName;
						UiHelper.LoadSoldierIconFrameMaterial(prodIconFrame, soldier.PotentialLevel);
						prodDesc.color = Color32.op_Implicit(new Color32((byte)175, (byte)246, (byte)39, byte.MaxValue));
						((GObject)prodDesc).visible = false;
						((GObject)prodDesc).text = string.Format("+{0}/{1}", outputNum * stronghold.Efficiency(GameManagers.Instance), LanguagesManager.GetDesc("CsharpCodeZhTcText248"));
					}
					else
					{
						((GObject)prodIcon).grayed = true;
						((GObject)progressBar).visible = false;
						progressMax.visible = false;
						((GObject)modifierGroup).visible = false;
						note.visible = true;
						occupantIcon.url = "";
						prodIconFrame.url = "ui://WorldMap/jiahao 2";
						prodDesc.color = Color32.op_Implicit(new Color32((byte)213, (byte)186, (byte)122, byte.MaxValue));
						((GObject)prodDesc).visible = true;
						((GObject)prodDesc).text = LanguagesManager.GetDesc("CsharpCodeZhTcText644");
					}
				}
				((GObject)strongholdBtn2).TweenFade(1f, 0.15f);
				if (lastStrongholdBtn != null)
				{
					SetStrongholdLine(lastStrongholdBtn, strongholdBtn2);
				}
				lastStrongholdBtn = strongholdBtn2;
				if (i3 == chapter.Level_IDs.Count - 1)
				{
					((GComponent)strongholdBtn2).GetChild("line").visible = false;
				}
				yield return (object)new WaitForEndOfFrame();
			}
		}
		RenderRegionProductionsList(region);
		UiTagManager uiTagManager = UiTagManager.Instance;
		uiTagManager.Unregister("WorldMap.RegionFirstStrongholdBtn");
		uiTagManager.Unregister("WorldMap.RegionSecondStrongholdBtn");
		if (strongholdUIBackList.Count > 0)
		{
			uiTagManager.Register("WorldMap.RegionFirstStrongholdBtn", ((GComponent)strongholdUIBackList[0]).GetChild("soldierIconFrame"));
			if (strongholdUIBackList.Count > 1)
			{
				uiTagManager.Register("WorldMap.RegionSecondStrongholdBtn", ((GComponent)strongholdUIBackList[1]).GetChild("soldierIconFrame"));
			}
		}
		SetBtnEnabled(btnEnabled: true);
	}

	public void SetBtnEnabled(bool btnEnabled)
	{
		((GObject)backBtn).touchable = btnEnabled;
		((GObject)LastRegionBtn).touchable = btnEnabled;
		((GObject)NextRegionBtn).touchable = btnEnabled;
		((GObject)switchMapBtn).touchable = btnEnabled;
	}

	private void InitAllAreaUI(bool init = false)
	{
		for (int i = 0; i < areaList.Count; i++)
		{
			RefreshAreaInfo(areaList[i], areaDataList[i].RegionProgress(GameManagers.Instance), init);
		}
	}

	private void RefreshAreaInfo(GComponent area, float type, bool init = false)
	{
		//IL_029a: Unknown result type (might be due to invalid IL or missing references)
		//IL_02b7: Unknown result type (might be due to invalid IL or missing references)
		//IL_02bc: Unknown result type (might be due to invalid IL or missing references)
		//IL_02c1: Unknown result type (might be due to invalid IL or missing references)
		//IL_02c3: Unknown result type (might be due to invalid IL or missing references)
		//IL_02c8: Unknown result type (might be due to invalid IL or missing references)
		//IL_02c9: Unknown result type (might be due to invalid IL or missing references)
		//IL_02d8: Unknown result type (might be due to invalid IL or missing references)
		//IL_02dd: Unknown result type (might be due to invalid IL or missing references)
		//IL_02e2: Unknown result type (might be due to invalid IL or missing references)
		//IL_02e5: Unknown result type (might be due to invalid IL or missing references)
		//IL_02ec: Unknown result type (might be due to invalid IL or missing references)
		bool flag = false;
		GComponent val = null;
		int num = areaList.IndexOf(area);
		if (num != -1 && briefInfo.Count > num)
		{
			((GObject)briefInfo[num].Value).Dispose();
			briefInfo.RemoveAt(num);
			flag = true;
		}
		if (num == occupyingIndex)
		{
			if (GameManagers.Instance.UserArchiveManager.CheckRegionUnlockBonusesClaimed(areaDataList[num].RegionId))
			{
				if (Math.Abs(type - 1f) <= float.Epsilon)
				{
					UI_occupiedLogo uI_occupiedLogo = UI_occupiedLogo.CreateInstance_ILRuntime();
					val = (GComponent)(object)uI_occupiedLogo;
					SuspendUiInit(1, val, num, init);
				}
				else
				{
					UI_occupyingLogo uI_occupyingLogo = UI_occupyingLogo.CreateInstance_ILRuntime();
					val = (GComponent)(object)uI_occupyingLogo;
					SuspendUiInit(0, val, num);
				}
			}
			else
			{
				UI_notOccupyLogo uI_notOccupyLogo = UI_notOccupyLogo.CreateInstance_ILRuntime();
				val = (GComponent)(object)uI_notOccupyLogo;
				SuspendUiInit(2, val, num);
				ForceHidePanel(uI_notOccupyLogo);
			}
		}
		else if (0.9999f <= type && type <= 1.0001f)
		{
			UI_occupiedLogo uI_occupiedLogo2 = UI_occupiedLogo.CreateInstance_ILRuntime();
			val = (GComponent)(object)uI_occupiedLogo2;
			SuspendUiInit(1, val, num, init);
		}
		else if (type <= 0.0001f)
		{
			UI_notOccupyLogo uI_notOccupyLogo2 = UI_notOccupyLogo.CreateInstance_ILRuntime();
			val = (GComponent)(object)uI_notOccupyLogo2;
			SuspendUiInit(2, val, num);
			ForceHidePanel(uI_notOccupyLogo2);
		}
		if ((((GObject)area).name == "Unknown1" || ((GObject)area).name == "Unknown2" || ((GObject)area).name == "ImpasseFortress") && val != null)
		{
			((GObject)val).visible = false;
		}
		if (OccupiedArea != null && OccupiedArea.Key != null && OccupiedArea.Key == area)
		{
			if (val != null)
			{
				((GObject)val).Dispose();
			}
			if (!OccupiedArea.Value)
			{
				UI_occupyingLogo uI_occupyingLogo2 = UI_occupyingLogo.CreateInstance_ILRuntime();
				val = (GComponent)(object)uI_occupyingLogo2;
				SuspendUiInit(0, val, num);
			}
			else
			{
				UI_occupiedLogo uI_occupiedLogo3 = UI_occupiedLogo.CreateInstance_ILRuntime();
				val = (GComponent)(object)uI_occupiedLogo3;
				SuspendUiInit(1, val, num, init);
			}
		}
		if (val == null)
		{
			SentrySdk.AddBreadcrumb($"[WorldMap]RefreshAreaInfo, Missing BriefInfo@{num}");
			return;
		}
		((GComponent)GRoot.inst).AddChild((GObject)(object)val);
		((GComponent)mapCom).GetChild("UILayer").asCom.AddChild((GObject)(object)val);
		Vector2 val2 = area.GetChild("uiLocator").xy - new Vector2(((GObject)area).width / 2f, ((GObject)area).height / 2f);
		Vector2 val3 = ((GObject)area).xy + val2 - new Vector2(0f, 20f);
		((GObject)val).SetXY(val3.x, val3.y);
		if (flag)
		{
			briefInfo.Insert(num, new KeyValuePair<float, GComponent>(type, val));
		}
		else
		{
			briefInfo.Add(new KeyValuePair<float, GComponent>(type, val));
		}
	}

	private static void ForceHidePanel(UI_notOccupyLogo logo)
	{
		int numChildren = ((GComponent)logo).numChildren;
		for (int i = 0; i < numChildren; i++)
		{
			GObject childAt = ((GComponent)logo).GetChildAt(i);
			childAt.visible = false;
			childAt.alpha = 0f;
		}
	}

	private UI_strongholdUIBack CreateStrongholdUiBackTo(GObject strongholdBtn, float popupDelay = 0.15f, bool isStronghold = false)
	{
		//IL_0154: Unknown result type (might be due to invalid IL or missing references)
		//IL_015e: Expected O, but got Unknown
		//IL_0126: Unknown result type (might be due to invalid IL or missing references)
		//IL_013a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0144: Expected O, but got Unknown
		UI_strongholdUIBack uiBack = UI_strongholdUIBack.CreateInstance();
		float num = ((GObject)selectedArea).x - ((GObject)selectedArea).width / 2f + strongholdBtn.x;
		float num2 = ((GObject)selectedArea).y - ((GObject)selectedArea).height / 2f + strongholdBtn.y - 40f;
		((GObject)uiBack).SetXY(num, num2);
		((GObject)uiBack).SetScale(0.25f, 0.25f);
		((GObject)uiBack).alpha = 0f;
		((GComponent)mapCom).GetChild("UILayer").asCom.AddChild((GObject)(object)uiBack);
		strongholdUIBackList.Add((GButton)(object)uiBack);
		if (isStronghold)
		{
			GObject _icon = ((GComponent)strongholdBtn.asButton).GetChild("icon");
			_icon.alpha = 0f;
			float num3 = ((popupDelay > 0.15f) ? (popupDelay - 0.15f) : 0f);
			_icon.TweenScale(_icon.scale, num3).OnComplete((GTweenCallback)delegate
			{
				_icon.visible = true;
				_icon.TweenFade(1f, 0.5f);
			});
		}
		((GComponent)(object)this).SetTimeout(popupDelay).OnComplete((GTweenCallback)delegate
		{
			if (!((GObject)uiBack).isDisposed)
			{
				Transition transition = ((GComponent)uiBack).GetTransition("showSelf");
				transition.Play();
			}
		});
		return uiBack;
	}

	private void SelectStronghold(GButton button)
	{
		if (selectedStronghold == null)
		{
			selectedStronghold = button;
		}
		else
		{
			if (selectedStronghold == button)
			{
				return;
			}
			((GComponent)selectedStronghold).GetChild("icon").visible = false;
			selectedStronghold = button;
		}
		((GComponent)selectedStronghold).GetChild("icon").visible = true;
	}

	private void SetSelectAreaInfo(GComponent area, bool setOrGet)
	{
		//IL_001f: Unknown result type (might be due to invalid IL or missing references)
		if (setOrGet)
		{
			int childIndex = mainMapLoader.component.GetChildIndex((GObject)(object)area);
			selectAreaInfo = new tKeyValue<int, Vector2>(childIndex, ((GObject)area).xy);
			mainMapLoader.component.RemoveChild((GObject)(object)area);
			mainMapLoader.component.GetChild("AreaHighlightLoader").asCom.AddChild((GObject)(object)area);
			((GObject)area).SetXY(selectAreaInfo.Value.x, selectAreaInfo.Value.y);
		}
		else
		{
			mainMapLoader.component.GetChild("AreaHighlightLoader").asCom.RemoveChild((GObject)(object)area);
			mainMapLoader.component.AddChild((GObject)(object)area);
			mainMapLoader.component.SetChildIndex((GObject)(object)area, selectAreaInfo.Key);
			((GObject)area).SetXY(selectAreaInfo.Value.x, selectAreaInfo.Value.y);
		}
	}

	private Stronghold FindStrongholdBySoldierId(string soldierId)
	{
		Region region = areaDataList[areaList.IndexOf(selectedArea)];
		Stronghold result = null;
		for (int i = 0; i < region.Strongholds.Count; i++)
		{
			if (region.Strongholds[i].Occupant(GameManagers.Instance) == soldierId)
			{
				result = region.Strongholds[i];
				break;
			}
		}
		return result;
	}

	private void WorkerOnMapProgressBarInit()
	{
		if (pageController.selectedIndex != 0)
		{
			FGUIManager.Instance.CloseIEnumerator(RefreshLevelprogressBarCoroutine);
			RefreshLevelprogressBarCoroutine = FGUIManager.Instance.OpenIEnumerator(RefreshLevelProgressBar());
		}
	}

	private void PlayRegioProdAutoClaimedSfx(List<string> autoClaimedRegions)
	{
		//IL_015e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0165: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c0: Unknown result type (might be due to invalid IL or missing references)
		if (pageController.selectedIndex == 0 || selectedArea == null || areaList == null || areaDataList == null || _dragging)
		{
			return;
		}
		int num = areaList.IndexOf(selectedArea);
		if (num == -1 || num >= areaDataList.Count)
		{
			return;
		}
		Region region = areaDataList[num];
		if (!autoClaimedRegions.Contains(region.RegionId))
		{
			Debug.LogError((object)("产出中不包含区域：" + region.RegionId + "跳出"));
		}
		else if ((region.Status(GameManagers.Instance) == RegionStatus.Battling && region.RegionProgress(GameManagers.Instance) > 0f) || region.Status(GameManagers.Instance) == RegionStatus.Occupied)
		{
			if (blackHoleBack == null)
			{
				blackHoleBack = UI_blackHoleBack.CreateInstance_ILRuntime();
			}
			((GObject)blackHoleBack.SfxBack).SetPivot(0f, 0f, true);
			((GComponent)this).AddChild((GObject)(object)blackHoleBack);
			Vector2 val = default(Vector2);
			((Vector2)(ref val))._002Ector(960f, 540f);
			((GObject)blackHoleBack).SetXY(val.x, val.y);
			((GComponent)this).RemoveChild((GObject)(object)blackHoleBack);
			areaList[num].AddChild((GObject)(object)blackHoleBack);
			((GObject)blackHoleBack).visible = true;
			((GObject)blackHoleBack).xy = areaList[num].GetChild("blackHolePos").xy;
			((GObject)blackHoleBack).data = num;
			if (PlayRegionProdAutoClaimedCoroutine != null)
			{
				FGUIManager.Instance.CloseIEnumerator(PlayRegionProdAutoClaimedCoroutine);
			}
			PlayRegionProdAutoClaimedCoroutine = FGUIManager.Instance.OpenIEnumerator(PlayRegionProdAutoClaimed(num));
		}
	}

	private void WorkerOnMapProgressBarRefresh(List<string> regions)
	{
	}

	private void PlayMoneyDisapear(GComponent Wave)
	{
		//IL_0078: Unknown result type (might be due to invalid IL or missing references)
		//IL_0082: Expected O, but got Unknown
		//IL_0090: Unknown result type (might be due to invalid IL or missing references)
		//IL_009a: Expected O, but got Unknown
		Wave.GetChild("WaveMask").alpha = 0f;
		Wave.GetChild("I40001_SP").alpha = 0f;
		Wave.GetChild("I40001").alpha = 1f;
		Transition transition = Wave.GetTransition("Disapear");
		transition.Play((PlayCompleteCallback)delegate
		{
			Wave.GetChild("WaveMask").alpha = 1f;
			Wave.GetChild("I40001_SP").alpha = 1f;
			Wave.GetChild("I40001").alpha = 0f;
			Wave.GetChild("I40001").y = -2f;
		});
		transition.SetHook("activating", (TransitionHook)delegate
		{
			//IL_004f: Unknown result type (might be due to invalid IL or missing references)
			((GObject)Wave.GetChild("SfxBack").asGraph).displayObject.Dispose();
			FGUIManager.Instance.AddTextSpecialEffects(Wave.GetChild("SfxBack").asGraph, "activating_yellow", new Vector3(65f, 65f, 65f), "Default", 0.5f, delegate(GameObject activatingYellow)
			{
				activatingYellow.AddComponent<HotFix_DestroySelf>().destroyTime = 0.8f;
			});
		});
	}

	private void SetWorkerPos()
	{
		//IL_0098: Unknown result type (might be due to invalid IL or missing references)
		//IL_00cb: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ed: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fa: Unknown result type (might be due to invalid IL or missing references)
		//IL_011b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0120: Unknown result type (might be due to invalid IL or missing references)
		//IL_0137: Unknown result type (might be due to invalid IL or missing references)
		//IL_013e: Unknown result type (might be due to invalid IL or missing references)
		//IL_014a: Unknown result type (might be due to invalid IL or missing references)
		if (workerOnMap != null)
		{
			int num = Random.Range(0, 4);
			if (curWorkerPosIndex != num)
			{
				curWorkerPosIndex = num;
			}
			else if (curWorkerPosIndex == 3)
			{
				curWorkerPosIndex = 0;
			}
			else
			{
				curWorkerPosIndex++;
			}
			int index = areaList.IndexOf(selectedArea);
			Vector2 val = areaList[index].GetChild($"slot{curWorkerPosIndex}").xy - new Vector2(((GObject)areaList[index]).width / 2f, ((GObject)areaList[index]).height / 2f);
			Vector2 val2 = ((GObject)areaList[index]).xy + val;
			((GObject)workerOnMap).SetXY(val2.x, val2.y);
			Vector3 localPosition = ((GObject)workerOnMap).displayObject.gameObject.transform.localPosition;
			((GObject)workerOnMap).displayObject.gameObject.transform.localPosition = new Vector3(localPosition.x, localPosition.y, -1f);
		}
	}

	private void SetWorkerAnimation(TrackEntry trackEntry, Event eEvent)
	{
		//IL_0064: Unknown result type (might be due to invalid IL or missing references)
		if (workerOnMap != null && eEvent.Data.Name == "attack")
		{
			((GObject)workerOnMap.SfxBase).displayObject.Dispose();
			FGUIManager.Instance.AddTextSpecialEffects(workerOnMap.SfxBase, "pickaxe_slam", new Vector3(100f, 100f, 100f));
		}
	}

	private void GetCurRegionStrongholdsProduceProgress(Region region)
	{
		if (selectedArea != null && areaList != null && areaDataList != null)
		{
			int num = areaList.IndexOf(selectedArea);
			if (num != -1 && num < areaDataList.Count)
			{
				foreach (Stronghold stronghold in region.Strongholds)
				{
					stronghold.RefreshStatus(GameManagers.Instance);
				}
			}
		}
		FGUIManager.Instance.CloseIEnumerator(RefreshStrongholdProgressBarCoroutine);
		RefreshStrongholdProgressBarCoroutine = FGUIManager.Instance.OpenIEnumerator(RefreshStrongholdProgressBar());
	}

	private void CurRegionStrongholdsProgressBarRefresh(List<string> strongholds)
	{
		//IL_0142: Unknown result type (might be due to invalid IL or missing references)
		//IL_0147: Unknown result type (might be due to invalid IL or missing references)
		//IL_0150: Unknown result type (might be due to invalid IL or missing references)
		//IL_0157: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a4: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ae: Expected O, but got Unknown
		if (pageController.selectedIndex == 0 || selectedArea == null || areaList == null || areaDataList == null)
		{
			return;
		}
		int num = areaList.IndexOf(selectedArea);
		if (num == -1 || num >= areaDataList.Count || areaDataList[num].Status(GameManagers.Instance) != RegionStatus.Occupied)
		{
			return;
		}
		foreach (string stronghold in strongholds)
		{
			if (curRegionStrongholdsBars.ContainsKey(stronghold))
			{
				UI_ProductionNumFloating NumFloating = UI_ProductionNumFloating.CreateInstance_ILRuntime();
				TextFormat textFormat = NumFloating.Title.textFormat;
				textFormat.size = 38;
				NumFloating.Title.textFormat = textFormat;
				((GComponent)mapCom).GetChild("UILayer").asCom.AddChild((GObject)(object)NumFloating);
				((GObject)NumFloating).sortingOrder = 101;
				Vector2 xy = ((GObject)((GObject)curRegionStrongholdsBars[stronghold]).parent).xy;
				((GObject)NumFloating).SetXY(xy.x, xy.y - 100f);
				((GObject)NumFloating).displayObject.gameObject.AddComponent<HotFix_DestroySelf>().destroyTime = 2f;
				NumFloating.DisAppear.Play(1, 0f, (PlayCompleteCallback)delegate
				{
					((GComponent)mapCom).GetChild("UILayer").asCom.RemoveChild((GObject)(object)NumFloating);
					((GObject)NumFloating).Dispose();
				});
			}
		}
	}

	public void SetStrongholdSoldier(EventContext eventContext, string soldier, int chosenType)
	{
		if (chosenType != 2)
		{
			return;
		}
		Stronghold strongholdBySoldierId = null;
		string soldierId1 = "";
		if (GameManagers.Instance.UserArchiveManager.GetAssignedSoldiers().Contains(soldier))
		{
			strongholdBySoldierId = FindStrongholdBySoldierId(soldier);
			if (curSelectedStronghold.IsOccupied(GameManagers.Instance))
			{
				soldierId1 = curSelectedStronghold.Occupant(GameManagers.Instance);
			}
		}
		ILRequestHelper<ChangeStrongholdProduceConfigResponse>.Request(eventContext, () => GameController.Contexts.Service<INetworkService>().ChangeStrongholdProduceConfig(-1L, curSelectedStronghold.StrongholdId, soldier), delegate(ChangeStrongholdProduceConfigResponse response)
		{
			if (!response.Result)
			{
				ILRequestHelper.ShowErrorCode(response.ErrorCode);
			}
			else
			{
				ActionResult actionResult = GameManagers.Instance.WorldMapManager.SetStrongholdSoldier(curSelectedStronghold.StrongholdId, soldier);
				if (!actionResult.Result)
				{
					ILRequestHelper.ShowMessage(actionResult.ErrorMessage);
				}
				else
				{
					float profitCd = 0f;
					if (curSelectedStronghold.Productions(GameManagers.Instance).Count > 0)
					{
						profitCd = 3600f / curSelectedStronghold.Productions(GameManagers.Instance).First().Value;
					}
					float profitPlus = curSelectedStronghold.CalcOccupantEfficiencyModifier(GameManagers.Instance, soldier);
					string key = curSelectedStronghold.ProductionsConfig.First().Key;
					ThinkingDataHelper.Instance.AssignOccupantTrack(soldier, profitCd, key, profitPlus, curSelectedStronghold.StrongholdId);
					if (strongholdBySoldierId != null && soldierId1 != "")
					{
						float profitCd2 = 0f;
						if (strongholdBySoldierId.Productions(GameManagers.Instance).Count > 0)
						{
							profitCd2 = 3600f / strongholdBySoldierId.Productions(GameManagers.Instance).First().Value;
						}
						float profitPlus2 = strongholdBySoldierId.CalcOccupantEfficiencyModifier(GameManagers.Instance, soldierId1);
						string key2 = strongholdBySoldierId.ProductionsConfig.First().Key;
						ThinkingDataHelper.Instance.AssignOccupantTrack(soldierId1, profitCd2, key2, profitPlus2, strongholdBySoldierId.StrongholdId);
					}
					RenderRegionProductionsList(areaDataList[areaList.IndexOf(selectedArea)]);
					RefreshSelectedAreaInfo();
					RenderAllAreasProductionsList();
				}
			}
		});
		if (soldier == "Unlock")
		{
			FGUIManager.Instance.OpenIEnumerator(UpdateRefundingStatusForOffLine("Unlock"));
		}
	}

	public IEnumerator UpdateRefundingStatusForOffLine(string soldier)
	{
		yield return (object)new WaitForFixedUpdate();
		ActionResult result = GameManagers.Instance.WorldMapManager.SetStrongholdSoldier(curSelectedStronghold.StrongholdId, soldier);
		if (!result.Result)
		{
			ILRequestHelper.ShowMessage(result.ErrorMessage);
		}
	}

	private void StrongholdOccupant(string soldier, Stronghold curStronghold)
	{
		if (curStronghold.AssignOccupantToStronghold(GameManagers.Instance, soldier))
		{
			RenderRegionProductionsList(areaDataList[areaList.IndexOf(selectedArea)]);
			RefreshSelectedAreaInfo();
		}
		else
		{
			List<string> arg = new List<string> { GameManagers.Instance.SoldierManager.Get(soldier).Name + LanguagesManager.GetDesc("CsharpCodeZhTcText657") + "！" };
			SharedMessenger.Broadcast("SHOW_TIPS", arg, 100, arg3: false);
		}
	}

	private void SetUnlockAreaCloudAnimation(string areaName)
	{
		//IL_007e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0088: Expected O, but got Unknown
		//IL_00f0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fa: Expected O, but got Unknown
		((GObject)((GObject)mapCom.CloudsAnimation).asCom).visible = true;
		GLoader mapCloudLoader = mapCom.CloudsAnimation.MapCloudLoader;
		GObject child = ((GComponent)mapCom).GetChild(areaName + "_pos");
		((GObject)mapCloudLoader).SetXY(child.x, child.y);
		mapCloudLoader.url = "ui://c9n2h0kspplflg";
		((GComponent)(object)this).SetTimeout(0.21f).OnComplete((GTweenCallback)delegate
		{
			if (!((GObject)this).isDisposed)
			{
				if (areaDataList[occupyingIndex].RegionProgress(GameManagers.Instance) < 0.0001f && areaDataList[occupyingIndex].Status(GameManagers.Instance) != RegionStatus.Battling)
				{
					((GObject)CurAreaEarnings).alpha = 0f;
					((GObject)CurAreaEarnings).touchable = false;
				}
				else
				{
					((GObject)CurAreaEarnings).alpha = 1f;
					((GObject)CurAreaEarnings).touchable = true;
				}
			}
		});
		UI_eff_CloudsDisappear uI_eff_CloudsDisappear = (UI_eff_CloudsDisappear)(object)mapCloudLoader.component;
		uI_eff_CloudsDisappear.t0.Play();
		GObject cloud = ((GComponent)mapCom.Clouds).GetChild(areaName + "_Cloud");
		cloud.TweenFade(0f, 0.5f).SetEase((EaseType)0);
		((GComponent)(object)this).SetTimeout(1f).OnComplete((GTweenCallback)delegate
		{
			cloud.visible = false;
			((GObject)mapCom.CloudsAnimation.MapCloudLoader).visible = false;
			for (int i = 0; i < strongholdUIBackList.Count; i++)
			{
				((GObject)strongholdUIBackList[i]).visible = true;
			}
			RefreshAreaInfo(areaList[occupyingIndex], areaDataList[occupyingIndex].RegionProgress(GameManagers.Instance));
			SetSuspendUi(selectedArea, state: false);
			RefreshAreaUI();
		});
	}

	private void GetAreaUnlockBonuses(EventContext eventContext)
	{
		if (UiHelper.LoginTypeStr == UserLoginCredentialsType.Guest.ToString() && GameManagers.Instance.ChapterManager.IsChapterDone("C1001"))
		{
			UiHelper.GuestsAccessRestrictTip();
			return;
		}
		ILRequestHelper<UnlockRegionResponse>.Request(eventContext, () => GameController.Contexts.Service<INetworkService>().UnlockRegion(-1L, areaDataList[occupyingIndex].RegionId), delegate(UnlockRegionResponse response)
		{
			if (!response.Result)
			{
				ILRequestHelper.ShowErrorCode(response.ErrorCode);
			}
			else
			{
				OnUnlockRegionCompleted();
			}
		});
	}

	public void OnUnlockRegionCompleted()
	{
		//IL_003a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0044: Expected O, but got Unknown
		List<Bonus> list = areaDataList[occupyingIndex].ClaimUnlockBonuses(GameManagers.Instance);
		((GObject)areaList[occupyingIndex]).onClick.Remove(new EventCallback1(GetAreaUnlockBonuses));
		for (int i = 0; i < strongholdUIBackList.Count; i++)
		{
			((GObject)strongholdUIBackList[i]).visible = false;
		}
		SetUnlockAreaCloudAnimation(areaDataList[occupyingIndex].Data.Prefab);
		if (unlockAreaTip != null)
		{
			((GObject)unlockAreaTip).Dispose();
		}
		alreadyReceived = true;
		((GObject)CurAreaEarnings.EnterBattlefieldBtn).visible = true;
		if (list.Count > 0)
		{
			FGUIManager.Instance.IsFirstMakeWar = false;
		}
	}

	private void SuspendUiInit(int type, GComponent ui, int index, bool init = false)
	{
		//IL_00e7: Unknown result type (might be due to invalid IL or missing references)
		//IL_010c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0111: Unknown result type (might be due to invalid IL or missing references)
		//IL_0136: Unknown result type (might be due to invalid IL or missing references)
		//IL_013b: Unknown result type (might be due to invalid IL or missing references)
		//IL_014c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0152: Expected O, but got Unknown
		//IL_016e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0184: Unknown result type (might be due to invalid IL or missing references)
		switch (type)
		{
		case 1:
		{
			GameObject canvasObject = default(GameObject);
			ref GameObject reference = ref canvasObject;
			Object obj = Object.Instantiate(Resources.Load("SpineTest", typeof(GameObject)));
			reference = (GameObject)(object)((obj is GameObject) ? obj : null);
			SpawnManager.Instance.LoadAnimation("victory_flag").Then((Action<SkeletonDataAsset>)delegate(SkeletonDataAsset asset)
			{
				//IL_00e4: Unknown result type (might be due to invalid IL or missing references)
				if (!((GObject)this).isDisposed)
				{
					spineList.Add("victory_flag");
					if (!((Object)(object)canvasObject == (Object)null))
					{
						SkeletonAnimation component = canvasObject.GetComponent<SkeletonAnimation>();
						if (!((Object)(object)component == (Object)null))
						{
							((SkeletonRenderer)component).skeletonDataAsset = asset;
							((SkeletonRenderer)component).Initialize(true);
							SpineHelper.SetSkin((ISkeletonAnimation)(object)component, "default");
							if (init)
							{
								component.AnimationName = "open";
							}
							if (ui != null)
							{
								ui.GetChild("spineBase").asGraph.color = new Color(255f, 255f, 255f, 255f);
							}
						}
					}
				}
			});
			ui.GetChild("ExclamationTipBtn").visible = GameManagers.Instance.NewMsgIncomingManager.HasAnyRegionWithoutStrongholdOccupant(areaDataList[index].RegionId);
			canvasObject.transform.localScale = new Vector3(80f, 80f, 80f);
			canvasObject.transform.localPosition = -new Vector3(0f, 0f, 0.1f);
			canvasObject.transform.localEulerAngles = -new Vector3(0f, 0f, 0f);
			GoWrapper val = new GoWrapper(canvasObject);
			((DisplayObject)val).SetXY(0f, 0f);
			((DisplayObject)val).pivot = new Vector2(0.5f, 0.5f);
			((DisplayObject)val).scale = new Vector2(0.6f, 0.6f);
			ui.GetChild("spineBase").asGraph.SetNativeObject((DisplayObject)(object)val);
			break;
		}
		case 2:
		{
			if (areaDataList[index].UnlockBonuses == null)
			{
				break;
			}
			ui.GetChild("icon").asLoader.url = "";
			((GObject)ui.GetChild("num").asTextField).text = "";
			using (Dictionary<string, object>.Enumerator enumerator = areaDataList[index].UnlockBonuses.GetEnumerator())
			{
				if (enumerator.MoveNext())
				{
					KeyValuePair<string, object> current = enumerator.Current;
					ui.GetChild("icon").asLoader.url = "ui://PublicResources/" + UiHelper.GetIcon("Gem");
					((GObject)ui.GetChild("num").asTextField).text = $"{current.Value}";
				}
			}
			break;
		}
		}
		((GObject)ui.GetChild("areaName").asTextField).text = areaDataList[index].Data.Name ?? "";
	}

	private void SetSuspendUi(GComponent area, bool state)
	{
		int index = areaList.IndexOf(area);
		if (areaDataList[index].RegionProgress(GameManagers.Instance) <= 0.0001f && areaDataList[index].Status(GameManagers.Instance) == RegionStatus.Locked)
		{
			((GObject)briefInfo[index].Value).visible = false;
		}
		else if (areaDataList[index].Status(GameManagers.Instance) == RegionStatus.Unlocked)
		{
			((GObject)briefInfo[index].Value).visible = true;
		}
		else
		{
			((GObject)briefInfo[index].Value).visible = state;
		}
		if (OccupiedArea != null && OccupiedArea.Key != null && area == OccupiedArea.Key)
		{
			((GObject)briefInfo[index].Value).visible = true;
		}
	}

	private void OpenLegionUi(EventContext context)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		object data = ((GObject)context.sender).data;
		curSelectedStronghold = (Stronghold)data;
		Dictionary<string, object> dictionary = new Dictionary<string, object>();
		dictionary.Add("Style", "2");
		dictionary.Add("Spine", null);
		dictionary.Add("WorldMap", this);
		dictionary.Add("Stronghold", curSelectedStronghold);
		dictionary.Add("OnlyUnlocked", 1);
		GameController.Contexts.Service<IUiService>().OpenPanel(UI_LegionPanel.Name, dictionary);
		UiAudioManager.Instance.PlaySoundEffect("GeneralClick");
	}

	private void SetSoldierNum(string uiId, Dictionary<string, object> parameters)
	{
		//IL_0153: Unknown result type (might be due to invalid IL or missing references)
		//IL_0158: Unknown result type (might be due to invalid IL or missing references)
		if (!(uiId == UI_LegionPanel.Name))
		{
			return;
		}
		object obj = UiTagManager.Instance.FindObjectByTag("LegionPanel");
		if (obj == null)
		{
			return;
		}
		UI_LegionPanel uI_LegionPanel = (UI_LegionPanel)obj;
		int index = areaList.IndexOf(selectedArea);
		foreach (Stronghold stronghold in areaDataList[index].Strongholds)
		{
			if (stronghold == curSelectedStronghold)
			{
				for (int i = 1; i < uI_LegionPanel.armsList.numItems; i++)
				{
					float num = stronghold.CalcOccupantEfficiencyModifier(GameManagers.Instance, uI_LegionPanel.SoldierList[i]?.Id);
					((GComponent)((GComponent)uI_LegionPanel.armsList).GetChildAt(i).asButton).GetChild("modifierText").text = "[color=" + UiHelper.GetStrongHoldModifierColor(num) + "]+" + UiHelper.RemoveSurplusZeroBehindDecimalPoint($"{Convert.ToInt32(num * 100f)}") + "%[/color]";
					((GComponent)((GComponent)uI_LegionPanel.armsList).GetChildAt(i).asButton).GetChild("modifierText").asTextField.strokeColor = Color32.op_Implicit(new Color32((byte)0, (byte)0, (byte)0, (byte)229));
				}
				break;
			}
		}
	}

	private void RenderListItem(int index, GObject obj)
	{
		//IL_0037: Unknown result type (might be due to invalid IL or missing references)
		//IL_003c: Invalid comparison between O and Unknown
		//IL_0076: Unknown result type (might be due to invalid IL or missing references)
		//IL_007b: Invalid comparison between O and Unknown
		//IL_00bc: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c1: Invalid comparison between O and Unknown
		//IL_0139: Unknown result type (might be due to invalid IL or missing references)
		//IL_013e: Unknown result type (might be due to invalid IL or missing references)
		//IL_05f6: Unknown result type (might be due to invalid IL or missing references)
		//IL_0600: Expected O, but got Unknown
		//IL_039d: Unknown result type (might be due to invalid IL or missing references)
		//IL_03c9: Unknown result type (might be due to invalid IL or missing references)
		//IL_03d3: Expected O, but got Unknown
		//IL_058b: Unknown result type (might be due to invalid IL or missing references)
		//IL_05b7: Unknown result type (might be due to invalid IL or missing references)
		//IL_05c1: Expected O, but got Unknown
		GButton asButton = obj.asButton;
		Vector2 val = default(Vector2);
		((Vector2)(ref val))._002Ector(1693f, 490f);
		if ((object)CurEarnings.earningsList == (object)(GList)obj.parent && index == 0)
		{
			((GObject)asButton).alpha = 0f;
			((GObject)asButton).touchable = false;
			return;
		}
		if ((object)CurEarnings.earningsList == (object)(GList)obj.parent)
		{
			((Vector2)(ref val))._002Ector(1076f, 852f);
		}
		((GObject)asButton).alpha = 1f;
		((GObject)asButton).touchable = true;
		Tuple<string, string, Color32, string, float> descInfo = (((object)CurAreaEarnings.earningsList == (object)(GList)obj.parent) ? areaEarningsData[index] : totalEarningsData[index - 1]);
		((GComponent)asButton).GetChild("icon").asLoader.url = "ui://PublicResources/" + descInfo.Item1;
		GTextField asTextField = ((GComponent)asButton).GetChild("output").asTextField;
		((GObject)asTextField).text = descInfo.Item2;
		asTextField.color = Color32.op_Implicit(descInfo.Item3);
		if (descInfo.Item2 == LanguagesManager.GetDesc("CsharpCodeZhTcText644"))
		{
			((GComponent)asButton).GetController("Status").selectedIndex = 1;
		}
		else
		{
			((GComponent)asButton).GetController("Status").selectedIndex = 0;
		}
		((GComponent)asButton).GetChild("ProgressBarForUi").visible = false;
		int stock = GameManagers.Instance.StockController.GetStock(descInfo.Item4);
		((GComponent)asButton).GetChild("totalNum").text = $"{stock}";
		((GComponent)asButton).GetChild("increment").data = stock;
		if (descInfo.Item4 == "Money")
		{
			float percentFloatPayload = GameManagers.Instance.ModifierManager.GetPercentFloatPayload("AutoProduceEfficiency");
			if (percentFloatPayload > 0f)
			{
				string value = "";
				float value2 = descInfo.Item5 / (1f + percentFloatPayload);
				if (percentFloatPayload > 1f)
				{
					value = LanguagesManager.GetDesc("CsharpCodeZhTcText105") + Environment.NewLine + LanguagesManager.GetDesc("CsharpCodeZhTcText106") + Environment.NewLine + string.Format("{0}：{1}/h", LanguagesManager.GetDesc("CsharpCodeZhTcText125"), Convert.ToInt32(value2));
				}
				else if (percentFloatPayload >= 1f)
				{
					value = LanguagesManager.GetDesc("CsharpCodeZhTcText106") + Environment.NewLine + string.Format("{0}：{1}/h", LanguagesManager.GetDesc("CsharpCodeZhTcText125"), Convert.ToInt32(value2));
				}
				else if (percentFloatPayload > 0f)
				{
					value = LanguagesManager.GetDesc("CsharpCodeZhTcText105") + Environment.NewLine + string.Format("{0}：{1}/h", LanguagesManager.GetDesc("CsharpCodeZhTcText125"), Convert.ToInt32(value2));
				}
				((GComponent)asButton).GetChild("ExclamationMarkBtn").visible = true;
				((GComponent)asButton).GetChild("ExclamationMarkBtn").data = new Dictionary<string, object>
				{
					{ "Title", value },
					{ "Pos", val }
				};
				((GComponent)asButton).GetChild("ExclamationMarkBtn").onClick.Set(new EventCallback1(FGUIManager.Instance.OpenExclamationMarkPanel));
			}
			else
			{
				((GComponent)asButton).GetChild("ExclamationMarkBtn").visible = false;
			}
		}
		else
		{
			float percentFloatPayload2 = GameManagers.Instance.ModifierManager.GetPercentFloatPayload("OccupiedProduceEfficiency");
			bool flag = GameManagers.Instance.LeaseholdManager.GetLeaseholdItemRemainingTime("PrimeContract") > 0;
			string value3 = "";
			int num = ((descInfo.Item4 == "I40010") ? 1 : 20);
			if (percentFloatPayload2 > 0f)
			{
				if (percentFloatPayload2 > 1f)
				{
					value3 = LanguagesManager.GetDesc("CsharpCodeZhTcText105") + Environment.NewLine + LanguagesManager.GetDesc("CsharpCodeZhTcText106") + Environment.NewLine + string.Format("{0}：{1}/h", LanguagesManager.GetDesc("CsharpCodeZhTcText945"), num);
				}
				else if (percentFloatPayload2 >= 1f)
				{
					value3 = LanguagesManager.GetDesc("CsharpCodeZhTcText106") + Environment.NewLine + string.Format("{0}：{1}/h", LanguagesManager.GetDesc("CsharpCodeZhTcText945"), num);
				}
				else if (percentFloatPayload2 > 0f)
				{
					value3 = LanguagesManager.GetDesc("CsharpCodeZhTcText105") + Environment.NewLine + string.Format("{0}：{1}/h", LanguagesManager.GetDesc("CsharpCodeZhTcText945"), num);
				}
				((GComponent)asButton).GetChild("ExclamationMarkBtn").visible = true;
				((GComponent)asButton).GetChild("ExclamationMarkBtn").data = new Dictionary<string, object>
				{
					{ "Title", value3 },
					{ "Pos", val }
				};
				((GComponent)asButton).GetChild("ExclamationMarkBtn").onClick.Set(new EventCallback1(FGUIManager.Instance.OpenExclamationMarkPanel));
			}
			else
			{
				((GComponent)asButton).GetChild("ExclamationMarkBtn").visible = false;
			}
		}
		((GObject)((GComponent)asButton).GetChild("icon").asLoader).onClick.Set((EventCallback0)delegate
		{
			FGUIManager.Instance.ItemTip(descInfo.Item4, ((GObject)this).sortingOrder, noCheckBtn: true);
		});
		((GObject)asButton).data = descInfo.Item4;
	}

	private void RenderCurAreaList(int index, GObject obj)
	{
		//IL_0177: Unknown result type (might be due to invalid IL or missing references)
		//IL_017c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0184: Unknown result type (might be due to invalid IL or missing references)
		//IL_0186: Unknown result type (might be due to invalid IL or missing references)
		//IL_0398: Unknown result type (might be due to invalid IL or missing references)
		//IL_039d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0557: Unknown result type (might be due to invalid IL or missing references)
		//IL_0561: Expected O, but got Unknown
		//IL_030a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0336: Unknown result type (might be due to invalid IL or missing references)
		//IL_0340: Expected O, but got Unknown
		//IL_04ec: Unknown result type (might be due to invalid IL or missing references)
		//IL_0518: Unknown result type (might be due to invalid IL or missing references)
		//IL_0522: Expected O, but got Unknown
		GButton asButton = obj.asButton;
		Vector2 val = default(Vector2);
		((Vector2)(ref val))._002Ector(1693f, 490f);
		((GObject)asButton).alpha = 1f;
		((GObject)asButton).touchable = true;
		Tuple<string, string, Color32, string, float> descInfo = areaEarningsData[index];
		UI_earnBtn uI_earnBtn = (UI_earnBtn)(object)obj;
		((GComponent)asButton).GetChild("icon").asLoader.url = "ui://PublicResources/" + descInfo.Item1;
		((GObject)uI_earnBtn.output).text = descInfo.Item2;
		if (descInfo.Item2 == LanguagesManager.GetDesc("CsharpCodeZhTcText644"))
		{
			((GComponent)asButton).GetController("Status").selectedIndex = 1;
		}
		else
		{
			((GComponent)asButton).GetController("Status").selectedIndex = 0;
		}
		((GObject)uI_earnBtn.ProgressBarForUi).visible = false;
		int stock = GameManagers.Instance.StockController.GetStock(descInfo.Item4);
		((GObject)uI_earnBtn.totalNum).text = $"{stock}";
		((GObject)uI_earnBtn.increment).data = stock;
		if (descInfo.Item4 == "Money")
		{
			float percentFloatPayload = GameManagers.Instance.ModifierManager.GetPercentFloatPayload("AutoProduceEfficiency");
			bool flag = percentFloatPayload > 0f;
			Color32 textColor = GetTextColor(flag);
			uI_earnBtn.output.color = Color32.op_Implicit(textColor);
			((GObject)uI_earnBtn.ExclamationMarkBtn).visible = flag;
			uI_earnBtn.c1.SetSelectedIndex(1);
			if (percentFloatPayload > 0f)
			{
				string value = "";
				float value2 = descInfo.Item5 / (1f + percentFloatPayload);
				if (percentFloatPayload > 1f)
				{
					value = LanguagesManager.GetDesc("CsharpCodeZhTcText105") + Environment.NewLine + LanguagesManager.GetDesc("CsharpCodeZhTcText106") + Environment.NewLine + string.Format("{0}：{1}/h", LanguagesManager.GetDesc("CsharpCodeZhTcText125"), Convert.ToInt32(value2));
				}
				else if (percentFloatPayload >= 1f)
				{
					value = LanguagesManager.GetDesc("CsharpCodeZhTcText106") + Environment.NewLine + string.Format("{0}：{1}/h", LanguagesManager.GetDesc("CsharpCodeZhTcText125"), Convert.ToInt32(value2));
				}
				else if (percentFloatPayload > 0f)
				{
					value = LanguagesManager.GetDesc("CsharpCodeZhTcText105") + Environment.NewLine + string.Format("{0}：{1}/h", LanguagesManager.GetDesc("CsharpCodeZhTcText125"), Convert.ToInt32(value2));
				}
				((GComponent)asButton).GetChild("ExclamationMarkBtn").data = new Dictionary<string, object>
				{
					{ "Title", value },
					{ "Pos", val }
				};
				((GComponent)asButton).GetChild("ExclamationMarkBtn").onClick.Set(new EventCallback1(FGUIManager.Instance.OpenExclamationMarkPanel));
			}
		}
		else
		{
			float percentFloatPayload2 = GameManagers.Instance.ModifierManager.GetPercentFloatPayload("OccupiedProduceEfficiency");
			string value3 = "";
			int num = ((descInfo.Item4 == "I40010") ? 1 : 20);
			bool hasEffect = percentFloatPayload2 > 0f;
			uI_earnBtn.output.color = Color32.op_Implicit(GetTextColor(hasEffect));
			if (percentFloatPayload2 > 0f)
			{
				if (percentFloatPayload2 > 1f)
				{
					value3 = LanguagesManager.GetDesc("CsharpCodeZhTcText105") + Environment.NewLine + LanguagesManager.GetDesc("CsharpCodeZhTcText106") + Environment.NewLine + string.Format("{0}：{1}/h", LanguagesManager.GetDesc("CsharpCodeZhTcText945"), num);
				}
				else if (percentFloatPayload2 >= 1f)
				{
					value3 = LanguagesManager.GetDesc("CsharpCodeZhTcText106") + Environment.NewLine + string.Format("{0}：{1}/h", LanguagesManager.GetDesc("CsharpCodeZhTcText945"), num);
				}
				else if (percentFloatPayload2 > 0f)
				{
					value3 = LanguagesManager.GetDesc("CsharpCodeZhTcText105") + Environment.NewLine + string.Format("{0}：{1}/h", LanguagesManager.GetDesc("CsharpCodeZhTcText945"), num);
				}
				((GComponent)asButton).GetChild("ExclamationMarkBtn").visible = true;
				((GComponent)asButton).GetChild("ExclamationMarkBtn").data = new Dictionary<string, object>
				{
					{ "Title", value3 },
					{ "Pos", val }
				};
				((GComponent)asButton).GetChild("ExclamationMarkBtn").onClick.Set(new EventCallback1(FGUIManager.Instance.OpenExclamationMarkPanel));
			}
			else
			{
				((GComponent)asButton).GetChild("ExclamationMarkBtn").visible = false;
			}
		}
		((GObject)((GComponent)asButton).GetChild("icon").asLoader).onClick.Set((EventCallback0)delegate
		{
			FGUIManager.Instance.ItemTip(descInfo.Item4, ((GObject)this).sortingOrder, noCheckBtn: true);
		});
		((GObject)asButton).data = descInfo.Item4;
	}

	public void SetTitleRedPoint()
	{
		((GComponent)ManorSize).GetChild("redPoint").visible = CacheManager.Instance.Get<Cache_PrinceRedDot>().HasPageRedDot(AchievementCat.Region);
	}

	private void SetGaussianBlur(float size)
	{
	}

	private void UpdateTotalProductionsInfo()
	{
		//IL_0052: Unknown result type (might be due to invalid IL or missing references)
		//IL_0057: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a3: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ca: Unknown result type (might be due to invalid IL or missing references)
		//IL_01cf: Unknown result type (might be due to invalid IL or missing references)
		//IL_0286: Unknown result type (might be due to invalid IL or missing references)
		//IL_028b: Unknown result type (might be due to invalid IL or missing references)
		//IL_02fe: Unknown result type (might be due to invalid IL or missing references)
		//IL_02e0: Unknown result type (might be due to invalid IL or missing references)
		//IL_02e2: Unknown result type (might be due to invalid IL or missing references)
		//IL_0401: Unknown result type (might be due to invalid IL or missing references)
		//IL_03c7: Unknown result type (might be due to invalid IL or missing references)
		totalEarningsData.Clear();
		foreach (KeyValuePair<string, float> formattedAutoProduction in GameManagers.Instance.UserArchiveManager.GetFormattedAutoProductions())
		{
			float percentFloatPayload = GameManagers.Instance.ModifierManager.GetPercentFloatPayload("AutoProduceEfficiency");
			bool hasEffect = percentFloatPayload > 0f;
			Color32 textColor = GetTextColor(hasEffect);
			totalEarningsData.Add(new Tuple<string, string, Color32, string, float>(UiHelper.GetIconPath(formattedAutoProduction.Key), "+" + UiHelper.RemoveSurplusZeroBehindDecimalPoint($"{formattedAutoProduction.Value}") + "/" + LanguagesManager.GetDesc("CsharpCodeZhTcText248"), textColor, formattedAutoProduction.Key, formattedAutoProduction.Value));
		}
		for (int num = areaDataList.Count - 1; num >= 0; num--)
		{
			if ((areaDataList[num].Status(GameManagers.Instance) == RegionStatus.Battling || areaDataList[num].Status(GameManagers.Instance) == RegionStatus.Occupied) && !(areaDataList[num].RegionId == areaDataList[occupyingIndex].RegionId))
			{
				if (totalEarningsData.Count >= 2)
				{
					break;
				}
				foreach (Stronghold stronghold in areaDataList[num].Strongholds)
				{
					bool hasEffect2 = stronghold.OccupantEfficiencyModifier(GameManagers.Instance) > float.Epsilon;
					Color32 textColor2 = GetTextColor(hasEffect2);
					if (stronghold.ProductionsConfig == null)
					{
						continue;
					}
					foreach (KeyValuePair<string, int> item5 in stronghold.ProductionsConfig)
					{
						bool flag = false;
						for (int i = 0; i < totalEarningsData.Count; i++)
						{
							if (totalEarningsData[i].Item4 == item5.Key)
							{
								float item = totalEarningsData[i].Item5;
								item += (float)item5.Value * stronghold.Efficiency(GameManagers.Instance);
								string item2 = totalEarningsData[i].Item2;
								Color32 item3 = totalEarningsData[i].Item3;
								totalEarningsData.RemoveAt(i);
								if (stronghold.IsOccupied(GameManagers.Instance))
								{
									item2 = "+" + UiHelper.RemoveSurplusZeroBehindDecimalPoint($"{item}") + "/" + LanguagesManager.GetDesc("CsharpCodeZhTcText248");
									item3 = textColor2;
								}
								totalEarningsData.Insert(i, new Tuple<string, string, Color32, string, float>(UiHelper.GetIconPath(item5.Key), item2, item3, item5.Key, item));
								flag = true;
								break;
							}
						}
						if (!flag)
						{
							float item4 = (float)item5.Value * stronghold.Efficiency(GameManagers.Instance);
							if (stronghold.IsOccupied(GameManagers.Instance))
							{
								totalEarningsData.Add(new Tuple<string, string, Color32, string, float>(UiHelper.GetIconPath(item5.Key), "+" + UiHelper.RemoveSurplusZeroBehindDecimalPoint($"{(float)item5.Value * stronghold.Efficiency(GameManagers.Instance)}") + "/" + LanguagesManager.GetDesc("CsharpCodeZhTcText248"), textColor2, item5.Key, item4));
							}
							else
							{
								totalEarningsData.Add(new Tuple<string, string, Color32, string, float>(UiHelper.GetIconPath(item5.Key), LanguagesManager.GetDesc("CsharpCodeZhTcText644"), textColor2, item5.Key, item4));
							}
						}
					}
				}
			}
		}
	}

	private static Color32 GetTextColor(bool hasEffect)
	{
		//IL_002d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Unknown result type (might be due to invalid IL or missing references)
		//IL_0033: Unknown result type (might be due to invalid IL or missing references)
		//IL_0034: Unknown result type (might be due to invalid IL or missing references)
		//IL_0037: Unknown result type (might be due to invalid IL or missing references)
		return hasEffect ? new Color32((byte)174, (byte)242, (byte)36, byte.MaxValue) : new Color32((byte)229, (byte)191, (byte)115, byte.MaxValue);
	}

	private void UpdateAllAreaProductionsInfo()
	{
	}

	private void UpdateRegionProductionsInfo(Region region)
	{
		//IL_0148: Unknown result type (might be due to invalid IL or missing references)
		//IL_014e: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c1: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c6: Unknown result type (might be due to invalid IL or missing references)
		//IL_0467: Unknown result type (might be due to invalid IL or missing references)
		//IL_029a: Unknown result type (might be due to invalid IL or missing references)
		//IL_03f2: Unknown result type (might be due to invalid IL or missing references)
		//IL_037a: Unknown result type (might be due to invalid IL or missing references)
		areaEarningsData.Clear();
		string text = "";
		Dictionary<string, float> formattedAutoProductions = GameManagers.Instance.UserArchiveManager.GetFormattedAutoProductions();
		float item = 0f;
		foreach (KeyValuePair<string, float> item2 in formattedAutoProductions)
		{
			text = "+" + UiHelper.RemoveSurplusZeroBehindDecimalPoint($"{item2.Value}") + "/" + LanguagesManager.GetDesc("CsharpCodeZhTcText248") + " (" + LanguagesManager.GetDesc("CsharpCodeZhTcText658") + ")";
			item = item2.Value;
		}
		int num = Convert.ToInt32(UiHelper.GetChapterMoneyOutput(region.Chapters.First().ChapterId));
		areaEarningsData.Add(new Tuple<string, string, Color32, string, float>(UiHelper.GetIconPath("Money"), "+" + UiHelper.RemoveSurplusZeroBehindDecimalPoint($"{num}") + "/" + LanguagesManager.GetDesc("CsharpCodeZhTcText248") + Environment.NewLine + text, default(Color32), "Money", item));
		List<string> list = new List<string>();
		foreach (Stronghold stronghold in region.Strongholds)
		{
			bool flag = stronghold.OccupantEfficiencyModifier(GameManagers.Instance) > float.Epsilon;
			float percentFloatPayload = GameManagers.Instance.ModifierManager.GetPercentFloatPayload("OccupiedProduceEfficiency");
			flag = flag || percentFloatPayload > 0f;
			Color32 textColor = GetTextColor(flag);
			if (stronghold.ProductionsConfig == null)
			{
				continue;
			}
			foreach (KeyValuePair<string, int> item3 in stronghold.ProductionsConfig)
			{
				float num2 = (float)item3.Value * stronghold.Efficiency(GameManagers.Instance);
				if (stronghold.IsOccupied(GameManagers.Instance))
				{
					if (!list.Contains(item3.Key))
					{
						areaEarningsData.Add(new Tuple<string, string, Color32, string, float>(UiHelper.GetIconPath(item3.Key), "+" + UiHelper.RemoveSurplusZeroBehindDecimalPoint($"{(float)item3.Value * stronghold.Efficiency(GameManagers.Instance)}") + "/" + LanguagesManager.GetDesc("CsharpCodeZhTcText248"), textColor, item3.Key, num2));
						list.Add(item3.Key);
						continue;
					}
					for (int i = 0; i < areaEarningsData.Count; i++)
					{
						if (areaEarningsData[i].Item4 == item3.Key)
						{
							if (areaEarningsData[i].Item1 == LanguagesManager.GetDesc("CsharpCodeZhTcText644"))
							{
								areaEarningsData[i] = new Tuple<string, string, Color32, string, float>(UiHelper.GetIconPath(item3.Key), "+" + UiHelper.RemoveSurplusZeroBehindDecimalPoint($"{(float)item3.Value * stronghold.Efficiency(GameManagers.Instance)}") + "/" + LanguagesManager.GetDesc("CsharpCodeZhTcText248"), textColor, item3.Key, num2);
								break;
							}
							float num3 = areaEarningsData[i].Item5 + num2;
							areaEarningsData[i] = new Tuple<string, string, Color32, string, float>(UiHelper.GetIconPath(item3.Key), "+" + UiHelper.RemoveSurplusZeroBehindDecimalPoint($"{num3}") + "/" + LanguagesManager.GetDesc("CsharpCodeZhTcText248"), textColor, item3.Key, num3);
							break;
						}
					}
				}
				else if (!list.Contains(item3.Key))
				{
					areaEarningsData.Add(new Tuple<string, string, Color32, string, float>(UiHelper.GetIconPath(item3.Key), LanguagesManager.GetDesc("CsharpCodeZhTcText644"), textColor, item3.Key, num2));
					list.Add(item3.Key);
				}
			}
		}
	}

	private void RenderRegionProductionsList(Region region)
	{
		//IL_0031: Unknown result type (might be due to invalid IL or missing references)
		//IL_003b: Expected O, but got Unknown
		//IL_005a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0064: Expected O, but got Unknown
		((GObject)CurAreaEarnings).data = null;
		UpdateRegionProductionsInfo(region);
		GList earningsList = CurAreaEarnings.earningsList;
		earningsList.numItems = 0;
		earningsList.itemRenderer = new ListItemRenderer(RenderCurAreaList);
		earningsList.numItems = areaEarningsData.Count;
		AreaEarningsOut.Play((PlayCompleteCallback)delegate
		{
			((GObject)switchMapBtn).touchable = true;
		});
	}

	private void RenderTotalProductionsList()
	{
		//IL_0024: Unknown result type (might be due to invalid IL or missing references)
		//IL_002e: Expected O, but got Unknown
		UpdateTotalProductionsInfo();
		GList earningsList = CurEarnings.earningsList;
		earningsList.numItems = 0;
		earningsList.itemRenderer = new ListItemRenderer(RenderListItem);
		earningsList.numItems = totalEarningsData.Count + 1;
		RenderAllAreasProductionsList();
	}

	private void RenderAllAreasProductionsList()
	{
		//IL_014a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0154: Expected O, but got Unknown
		//IL_042b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0472: Unknown result type (might be due to invalid IL or missing references)
		//IL_047c: Expected O, but got Unknown
		//IL_02dd: Unknown result type (might be due to invalid IL or missing references)
		//IL_030e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0318: Expected O, but got Unknown
		allAreasStrongholdOutPutBtns.Clear();
		Vector2 val = default(Vector2);
		((Vector2)(ref val))._002Ector(960f, 400f);
		if (totalEarningsData.Count >= 1)
		{
			string item = totalEarningsData[0].Item1;
			string item2 = totalEarningsData[0].Item2;
			string moneyId = totalEarningsData[0].Item4;
			float item3 = totalEarningsData[0].Item5;
			int stock = GameManagers.Instance.StockController.GetStock(moneyId);
			CurEarnings.detials.icon.url = "ui://PublicResources/" + item;
			((GObject)CurEarnings.detials.icon).data = moneyId;
			((GObject)CurEarnings.detials.moneyStock).text = stock.ShortNumberFormat() ?? "";
			((GObject)CurEarnings.detials.output).text = item2;
			((GObject)CurEarnings.detials.icon).onClick.Set((EventCallback0)delegate
			{
				FGUIManager.Instance.ItemTip(moneyId, ((GObject)this).sortingOrder, noCheckBtn: true);
			});
			float percentFloatPayload = GameManagers.Instance.ModifierManager.GetPercentFloatPayload("AutoProduceEfficiency");
			if (percentFloatPayload > 0f)
			{
				string value = "";
				float value2 = item3 / (1f + percentFloatPayload);
				if (percentFloatPayload > 1f)
				{
					value = LanguagesManager.GetDesc("CsharpCodeZhTcText105") + Environment.NewLine + LanguagesManager.GetDesc("CsharpCodeZhTcText106") + Environment.NewLine + string.Format("{0}：{1}/h", LanguagesManager.GetDesc("CsharpCodeZhTcText125"), Convert.ToInt32(value2));
				}
				else if (percentFloatPayload >= 1f)
				{
					value = LanguagesManager.GetDesc("CsharpCodeZhTcText106") + Environment.NewLine + string.Format("{0}：{1}/h", LanguagesManager.GetDesc("CsharpCodeZhTcText125"), Convert.ToInt32(value2));
				}
				else if (percentFloatPayload > 0f)
				{
					value = LanguagesManager.GetDesc("CsharpCodeZhTcText105") + Environment.NewLine + string.Format("{0}：{1}/h", LanguagesManager.GetDesc("CsharpCodeZhTcText125"), Convert.ToInt32(value2));
				}
				((GObject)CurEarnings.detials.MoneyExclamationMarkBtn).visible = true;
				((GObject)CurEarnings.detials.MoneyExclamationMarkBtn).data = new Dictionary<string, object>
				{
					{ "Title", value },
					{ "Pos", val }
				};
				((GObject)CurEarnings.detials.MoneyExclamationMarkBtn).onClick.Set(new EventCallback1(FGUIManager.Instance.OpenExclamationMarkPanel));
			}
			else
			{
				((GObject)CurEarnings.detials.MoneyExclamationMarkBtn).visible = false;
			}
		}
		float percentFloatPayload2 = GameManagers.Instance.ModifierManager.GetPercentFloatPayload("OccupiedProduceEfficiency");
		bool flag = GameManagers.Instance.LeaseholdManager.GetLeaseholdItemRemainingTime("PrimeContract") > 0;
		string value3 = "";
		if (percentFloatPayload2 > 0f)
		{
			if (percentFloatPayload2 > 1f)
			{
				value3 = LanguagesManager.GetDesc("CsharpCodeZhTcText645") + Environment.NewLine + LanguagesManager.GetDesc("CsharpCodeZhTcText646");
			}
			else if (percentFloatPayload2 >= 1f)
			{
				value3 = LanguagesManager.GetDesc("CsharpCodeZhTcText646");
			}
			else if (percentFloatPayload2 > 0f)
			{
				value3 = LanguagesManager.GetDesc("CsharpCodeZhTcText645");
			}
			((GObject)CurEarnings.detials.TotalExclamationMarkBtn).visible = true;
			((GObject)CurEarnings.detials.TotalExclamationMarkBtn).data = new Dictionary<string, object>
			{
				{ "Title", value3 },
				{ "Pos", val },
				{ "Width", 380 }
			};
			((GObject)CurEarnings.detials.TotalExclamationMarkBtn).onClick.Set(new EventCallback1(FGUIManager.Instance.OpenExclamationMarkPanel));
		}
		else
		{
			((GObject)CurEarnings.detials.TotalExclamationMarkBtn).visible = false;
		}
		List<Region> list = new List<Region>();
		foreach (KeyValuePair<string, Region> region in WorldMapManager.Regions)
		{
			if (region.Value.Status(GameManagers.Instance) == RegionStatus.Occupied)
			{
				list.Add(region.Value);
			}
		}
		CurEarnings.detials.earnings.numItems = list.Count;
		for (int num = 0; num < CurEarnings.detials.earnings.numItems; num++)
		{
			RenderAreaStrongholdsInfo(((GComponent)CurEarnings.detials.earnings).GetChildAt(num).asButton, list[num], num + 1);
		}
	}

	private void RenderAreaStrongholdsInfo(GButton btn, Region regionData, int regionIndex)
	{
		//IL_00a9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b3: Expected O, but got Unknown
		//IL_0113: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fb: Unknown result type (might be due to invalid IL or missing references)
		//IL_0118: Unknown result type (might be due to invalid IL or missing references)
		UI_AreaEarningsInfo uI_AreaEarningsInfo = (UI_AreaEarningsInfo)(object)btn;
		((GObject)uI_AreaEarningsInfo.areaName).text = string.Format("{0}{1} {2}", LanguagesManager.GetDesc("CsharpCodeZhTcText659"), regionIndex, regionData.Data.Name);
		int num = -1;
		for (int i = 0; i < areaList.Count; i++)
		{
			if (regionData.Data.Prefab == ((GObject)areaList[i]).name)
			{
				num = i;
				break;
			}
		}
		((GObject)uI_AreaEarningsInfo.TotalExclamationMarkBtn).data = num;
		((GObject)uI_AreaEarningsInfo.TotalExclamationMarkBtn).onClick.Set(new EventCallback1(CheckRegion));
		List<Tuple<string, string, string, string>> list = new List<Tuple<string, string, string, string>>();
		foreach (Stronghold stronghold in regionData.Strongholds)
		{
			Color32 val = ((stronghold.OccupantEfficiencyModifier(GameManagers.Instance) > float.Epsilon) ? new Color32((byte)175, (byte)246, (byte)39, byte.MaxValue) : new Color32((byte)213, (byte)186, (byte)122, byte.MaxValue));
			if (stronghold.ProductionsConfig == null)
			{
				continue;
			}
			foreach (KeyValuePair<string, int> item2 in stronghold.ProductionsConfig)
			{
				if (stronghold.IsOccupied(GameManagers.Instance))
				{
					float num2 = stronghold.CalcOccupantEfficiencyModifier(GameManagers.Instance, stronghold.Occupant(GameManagers.Instance));
					string item = "[color=" + UiHelper.GetStrongHoldModifierColor(num2) + "]+" + UiHelper.RemoveSurplusZeroBehindDecimalPoint($"{Convert.ToInt32(num2 * 100f)}") + "%[/color]";
					list.Add(new Tuple<string, string, string, string>(item2.Key, UiHelper.GetIconPath(item2.Key), item, "+" + UiHelper.RemoveSurplusZeroBehindDecimalPoint($"{Convert.ToInt32((float)item2.Value * stronghold.Efficiency(GameManagers.Instance))}") + "/" + LanguagesManager.GetDesc("CsharpCodeZhTcText248")));
				}
				else
				{
					list.Add(new Tuple<string, string, string, string>(item2.Key, UiHelper.GetIconPath(item2.Key), "", ""));
				}
			}
		}
		uI_AreaEarningsInfo.curEarnings.numItems = list.Count;
		uI_AreaEarningsInfo.Type.selectedIndex = ((uI_AreaEarningsInfo.curEarnings.numItems > 4) ? 1 : 0);
		for (int j = 0; j < uI_AreaEarningsInfo.curEarnings.numItems; j++)
		{
			RenderAllAreasStrongholdInfo(((GComponent)uI_AreaEarningsInfo.curEarnings).GetChildAt(j).asButton, list[j]);
		}
	}

	private void CheckRegion(EventContext context)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		int num = (int)((GObject)context.sender).data;
		if (num >= 0)
		{
			ToArea(areaList[num], _drag: false, returnOnRegion: true);
		}
	}

	private void RenderAllAreasStrongholdInfo(GButton btn, Tuple<string, string, string, string> _tuple)
	{
		//IL_0059: Unknown result type (might be due to invalid IL or missing references)
		//IL_0063: Expected O, but got Unknown
		UI_newTotalEarnBtn uI_newTotalEarnBtn = (UI_newTotalEarnBtn)(object)btn;
		allAreasStrongholdOutPutBtns.Add(uI_newTotalEarnBtn);
		string _id = _tuple.Item1;
		string item = _tuple.Item2;
		uI_newTotalEarnBtn.icon.url = "ui://PublicResources/" + item;
		((GObject)uI_newTotalEarnBtn).onClick.Set((EventCallback0)delegate
		{
			FGUIManager.Instance.ItemTip(_id, ((GObject)this).sortingOrder, noCheckBtn: true);
		});
		if (string.IsNullOrWhiteSpace(_tuple.Item4))
		{
			uI_newTotalEarnBtn.Status.selectedIndex = 1;
			return;
		}
		uI_newTotalEarnBtn.Status.selectedIndex = 0;
		((GObject)uI_newTotalEarnBtn).data = _id;
		string item2 = _tuple.Item4;
		string item3 = _tuple.Item3;
		int stock = GameManagers.Instance.StockController.GetStock(_id);
		((GObject)uI_newTotalEarnBtn.totalNum).text = stock.ShortNumberFormat() ?? "";
		((GObject)uI_newTotalEarnBtn.percent).text = item3;
		((GObject)uI_newTotalEarnBtn.output).text = item2;
	}

	private void UpdateAllAreasStrongholdInfo(string _itemId, int incr)
	{
		int stock = GameManagers.Instance.StockController.GetStock(_itemId);
		if (((GObject)CurEarnings.detials.icon).data != null && ((GObject)CurEarnings.detials.icon).data.ToString() == _itemId)
		{
			((GObject)CurEarnings.detials.moneyStock).text = stock.ShortNumberFormat() ?? "";
			return;
		}
		for (int i = 0; i < allAreasStrongholdOutPutBtns.Count; i++)
		{
			UI_newTotalEarnBtn uI_newTotalEarnBtn = allAreasStrongholdOutPutBtns[i];
			if (((GObject)uI_newTotalEarnBtn).data != null && ((GObject)uI_newTotalEarnBtn).data.ToString() == _itemId && uI_newTotalEarnBtn.Status.selectedIndex != 1)
			{
				if (((GObject)uI_newTotalEarnBtn.increment).data == null)
				{
					((GObject)uI_newTotalEarnBtn.increment).data = stock;
				}
				else if (incr > 0)
				{
					((GObject)uI_newTotalEarnBtn.increment).text = $"+{incr}";
					((GObject)uI_newTotalEarnBtn.increment).data = stock;
					((GComponent)uI_newTotalEarnBtn).GetTransition("GetEarnings").Play();
				}
				((GObject)allAreasStrongholdOutPutBtns[i].totalNum).text = stock.ShortNumberFormat() ?? "";
				break;
			}
		}
	}

	private void RemoveGaussianBlur(object param)
	{
		GaussianBlurValue += 0.086f;
		((GComponent)mapCom).GetChild("GaussianBlur").asImage.material.SetFloat("_Size", GaussianBlurValue);
	}

	private void OpenDevilUI()
	{
		Dictionary<string, object> dictionary = new Dictionary<string, object>();
		dictionary.Add("Parent", this);
		dictionary.Add("Index", 3);
		GameController.Contexts.Service<IUiService>().OpenPanel(UI_PrinceOfTheDevilsPanel.Name, dictionary);
	}

	private void EnterBattlefield(EventContext contexts)
	{
		//IL_0025: Unknown result type (might be due to invalid IL or missing references)
		//IL_002f: Expected O, but got Unknown
		//IL_00b7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00cc: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00db: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fe: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ff: Unknown result type (might be due to invalid IL or missing references)
		//IL_0104: Unknown result type (might be due to invalid IL or missing references)
		//IL_0107: Unknown result type (might be due to invalid IL or missing references)
		//IL_010e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0113: Unknown result type (might be due to invalid IL or missing references)
		//IL_017b: Unknown result type (might be due to invalid IL or missing references)
		//IL_019b: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a5: Unknown result type (might be due to invalid IL or missing references)
		((GObject)CurAreaEarnings.EnterBattlefieldBtn).onClick.Remove(new EventCallback1(EnterBattlefield));
		string levelId = GameManagers.Instance.UserArchiveManager.GetCurrentLevelId();
		if (string.IsNullOrWhiteSpace(levelId))
		{
			levelId = areaDataList[occupyingIndex].CurrentLevelId(GameManagers.Instance);
		}
		if (string.IsNullOrWhiteSpace(levelId))
		{
			End();
			return;
		}
		((GObject)mainMapLoader).draggable = false;
		((GObject)mapCom).touchable = false;
		fromBattleField = true;
		Vector2 val = (curLevelPos - ((GObject)mapCom).size / 2f) * 1.4f;
		Vector2 xy = new Vector2(((GObject)this).width / 2f, ((GObject)this).height / 2f) - val;
		xy = XyAmendment(xy, 1.4f);
		titleOut.PlayReverse();
		AreaEarningsOut.PlayReverse();
		for (int num = strongholdUIBackList.Count - 1; num >= 0; num--)
		{
			((GObject)strongholdUIBackList[num]).Dispose();
			strongholdUIBackList.RemoveAt(num);
		}
		((GObject)mainMapLoader).TweenMove(xy, 0.7f).SetEase((EaseType)20);
		((GObject)mainMapLoader).TweenResize(((GObject)mapCom).size * 1.4f, 0.7f).SetEase((EaseType)20);
		ScriptApi.CreateTimer(0.4f, delegate
		{
			CommandFactory.CreateOpenSceneCommand("BattleField", new SceneBattleFieldArguments(new Dictionary<string, object>
			{
				{ "LevelId", levelId },
				{ "Asset", "Prefabs/BattleField" },
				{ "ForceCloseOtherUi", true },
				{ "TaskCompletionSource", null }
			}));
			ScriptApi.CreateTimer(1f, delegate
			{
				End();
			});
		});
	}

	private void GetMapData()
	{
		//IL_02da: Unknown result type (might be due to invalid IL or missing references)
		//IL_0317: Unknown result type (might be due to invalid IL or missing references)
		//IL_031c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0321: Unknown result type (might be due to invalid IL or missing references)
		//IL_0334: Unknown result type (might be due to invalid IL or missing references)
		//IL_0339: Unknown result type (might be due to invalid IL or missing references)
		//IL_033b: Unknown result type (might be due to invalid IL or missing references)
		//IL_034a: Unknown result type (might be due to invalid IL or missing references)
		//IL_034f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0354: Unknown result type (might be due to invalid IL or missing references)
		//IL_035c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0363: Unknown result type (might be due to invalid IL or missing references)
		//IL_03bb: Unknown result type (might be due to invalid IL or missing references)
		//IL_03c5: Expected O, but got Unknown
		//IL_01d8: Unknown result type (might be due to invalid IL or missing references)
		//IL_01e2: Expected O, but got Unknown
		//IL_01a6: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ab: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b1: Expected O, but got Unknown
		SetTitleRedPoint();
		occupyingIndex = -1;
		_dragging = false;
		mapCom = (UI_Map)(object)mainMapLoader.component;
		areaList.Clear();
		areaDataList.Clear();
		alreadyReceived = false;
		int childIndex = ((GComponent)mapCom).GetChildIndex((GObject)(object)mapCom.Unknown1);
		int childIndex2 = ((GComponent)mapCom).GetChildIndex((GObject)(object)mapCom.Unknown2);
		for (int i = childIndex; i <= childIndex2; i++)
		{
			areaList.Add(((GComponent)mapCom).GetChildAt(i).asCom);
			int index = i - 1;
			foreach (KeyValuePair<string, Region> region2 in WorldMapManager.Regions)
			{
				if (region2.Value.Data.Prefab == ((GObject)areaList[index]).name)
				{
					areaDataList.Add(region2.Value);
					break;
				}
			}
			if (((GObject)areaList[index]).name == "Unknown1" || ((GObject)areaList[index]).name == "Unknown2")
			{
				EventListener onClick = ((GObject)areaList[index]).onClick;
				object obj = _003C_003Ec._003C_003E9__101_0;
				if (obj == null)
				{
					EventCallback0 val = delegate
					{
					};
					_003C_003Ec._003C_003E9__101_0 = val;
					obj = (object)val;
				}
				onClick.Add((EventCallback0)obj);
			}
			else
			{
				((GObject)areaList[index]).onClick.Add((EventCallback0)delegate
				{
					ToArea(areaList[index], _drag: false, returnOnRegion: true);
				});
			}
		}
		selectedArea = areaList[SetOccupyingIndex()];
		RenderTotalProductionsList();
		SetSelectAreaInfo(selectedArea, setOrGet: true);
		if (!GameManagers.Instance.UserArchiveManager.CheckRegionUnlockBonusesClaimed(areaDataList[occupyingIndex].RegionId))
		{
			unlockAreaTip = UI_unlockAreaTip.CreateInstance();
			SuspendUiInit(2, (GComponent)(object)unlockAreaTip.n9, occupyingIndex);
			Region region = areaDataList[occupyingIndex];
			unlockAreaTip.n7.url = GetFguiAreaNameUrl(region);
			mainMapLoader.component.AddChild((GObject)(object)unlockAreaTip);
			Vector2 val2 = areaList[occupyingIndex].GetChild("uiLocator").xy - new Vector2(((GObject)areaList[occupyingIndex]).width / 2f, ((GObject)areaList[occupyingIndex]).height / 2f);
			Vector2 val3 = ((GObject)areaList[occupyingIndex]).xy + val2 - new Vector2(0f, 240f);
			((GObject)unlockAreaTip).SetXY(val3.x, val3.y);
			((GObject)unlockAreaTip.arrow).visible = true;
			((GObject)unlockAreaTip.tipText).text = LanguagesManager.GetDesc("CsharpCodeZhTcText647");
			((GObject)areaList[occupyingIndex]).onClick.Add(new EventCallback1(GetAreaUnlockBonuses));
			if (region.RegionId == "REGION1")
			{
				UiTagManager.Instance.Register("WorldMap.ForestMistRegion", areaList[occupyingIndex]);
			}
		}
		SetInitRegion(focusedRegionId);
		SetGaussianBlur(0f);
		SetAreaStates();
		((GObject)((GComponent)mapCom).GetChild("CloudsAnimation").asCom).visible = false;
		InitAllAreaUI();
		((GObject)mapCom).touchable = false;
		SetPageBtnStatus();
	}

	private int SetOccupyingIndex()
	{
		for (int i = 0; i < areaDataList.Count; i++)
		{
			if (areaDataList[i].Status(GameManagers.Instance) == RegionStatus.Unlocked)
			{
				occupyingIndex = i;
				alreadyReceived = false;
				((GObject)CurAreaEarnings.EnterBattlefieldBtn).visible = false;
			}
			else if (areaDataList[i].Status(GameManagers.Instance) == RegionStatus.Battling)
			{
				occupyingIndex = i;
				alreadyReceived = true;
				((GObject)CurAreaEarnings.EnterBattlefieldBtn).visible = true;
			}
		}
		if (occupyingIndex == -1)
		{
			string currentLevelId = GameManagers.Instance.UserArchiveManager.GetCurrentLevelId();
			if (!string.IsNullOrWhiteSpace(currentLevelId))
			{
				Level levelInstance = GameManagers.Instance.ChapterManager.GetLevelInstance(currentLevelId);
				if (levelInstance.ChapterId != "C1000" && levelInstance.ChapterId != "C10000" && levelInstance.ChapterId != "C10001" && levelInstance.ChapterId != "C1000" && levelInstance.ChapterId != "C10002")
				{
					GDEChapterData gDEChapterData = GDMgr.Get<GDEChapterData>(levelInstance.ChapterId);
					Region region = new Region(GDMgr.Get<GDERegionData>(gDEChapterData.Region));
					int num = 0;
					foreach (KeyValuePair<string, Region> region2 in WorldMapManager.Regions)
					{
						if (region2.Value.Data.Prefab == region.Data.Prefab)
						{
							occupyingIndex = areaDataList.IndexOf(region2.Value);
							alreadyReceived = true;
							((GObject)CurAreaEarnings.EnterBattlefieldBtn).visible = true;
							break;
						}
						num++;
						if (num == WorldMapManager.Regions.Count)
						{
							occupyingIndex = 1;
							alreadyReceived = true;
							((GObject)CurAreaEarnings.EnterBattlefieldBtn).visible = false;
						}
					}
				}
				else
				{
					occupyingIndex = 1;
					alreadyReceived = true;
					((GObject)CurAreaEarnings.EnterBattlefieldBtn).visible = false;
				}
			}
		}
		if (areaDataList[occupyingIndex].RegionId == "REGION12" || areaDataList[occupyingIndex].RegionId == "REGION13")
		{
			for (int j = 0; j < areaDataList.Count; j++)
			{
				if (areaDataList[j].Status(GameManagers.Instance) == RegionStatus.Occupied)
				{
					occupyingIndex = j;
					alreadyReceived = true;
					((GObject)CurAreaEarnings.EnterBattlefieldBtn).visible = false;
				}
			}
		}
		return occupyingIndex;
	}

	private void DragMap()
	{
		//IL_0061: Unknown result type (might be due to invalid IL or missing references)
		//IL_0066: Unknown result type (might be due to invalid IL or missing references)
		//IL_006b: Unknown result type (might be due to invalid IL or missing references)
		//IL_006c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0085: Unknown result type (might be due to invalid IL or missing references)
		//IL_008a: Unknown result type (might be due to invalid IL or missing references)
		//IL_008f: Unknown result type (might be due to invalid IL or missing references)
		int index = 1;
		float num = 0f;
		for (int i = 0; i < areaList.Count; i++)
		{
			if (!(((GObject)areaList[i]).name == "Unknown1") && !(((GObject)areaList[i]).name == "Unknown2"))
			{
				Vector2 gObjectPositionOnGRoot = UiHelper.GetGObjectPositionOnGRoot((GObject)(object)areaList[i], Vector2.one);
				Vector2 val = gObjectPositionOnGRoot - new Vector2(((GObject)this).width / 2f, ((GObject)this).height / 2f);
				float sqrMagnitude = ((Vector2)(ref val)).sqrMagnitude;
				if (i == 1)
				{
					num = sqrMagnitude;
				}
				else if (sqrMagnitude < num)
				{
					num = sqrMagnitude;
					index = i;
				}
			}
		}
		_dragging = false;
		ToArea(areaList[index], _drag: true);
	}

	private void SetDragRange()
	{
		float num = ((GObject)mapCom).width - ((GObject)this).width;
		float num2 = ((GObject)mapCom).height - ((GObject)this).height;
		minX = 0f - num;
		minY = 0f - num2;
		maxX = 0f;
		maxY = 0f;
	}

	private Vector2 XyAmendment(Vector2 _xy, float _scale = 1f)
	{
		//IL_0065: Unknown result type (might be due to invalid IL or missing references)
		//IL_0066: Unknown result type (might be due to invalid IL or missing references)
		//IL_0068: Unknown result type (might be due to invalid IL or missing references)
		//IL_0084: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00be: Unknown result type (might be due to invalid IL or missing references)
		//IL_00dc: Unknown result type (might be due to invalid IL or missing references)
		//IL_00de: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e2: Unknown result type (might be due to invalid IL or missing references)
		float num = ((GComponent)mapCom).GetChild("Sea1").width * _scale / 2f - ((GObject)this).width;
		float num2 = ((GComponent)mapCom).GetChild("Sea1").height * _scale / 2f - ((GObject)this).height;
		float num3 = 0f - num;
		float num4 = 0f - num2;
		float num5 = ((GObject)this).width + num;
		float num6 = ((GObject)this).height + num2;
		Vector2 result = _xy;
		if (_xy.x <= num3)
		{
			result.x = num3;
		}
		if (_xy.x >= num5)
		{
			result.x = num5;
		}
		if (_xy.y <= num4)
		{
			result.y = num4;
		}
		if (_xy.y >= num6)
		{
			result.y = num6;
		}
		return result;
	}

	private void OnDragMove(EventContext context)
	{
		//IL_0078: Unknown result type (might be due to invalid IL or missing references)
		//IL_00be: Unknown result type (might be due to invalid IL or missing references)
		//IL_0104: Unknown result type (might be due to invalid IL or missing references)
		//IL_014c: Unknown result type (might be due to invalid IL or missing references)
		if (!_dragging)
		{
			_dragging = true;
			titleOut.PlayReverse();
			AreaEarningsOut.PlayReverse();
			RefreshAreasUiVisible(_visible: false);
		}
		Vector2 val = default(Vector2);
		((Vector2)(ref val))._002Ector(((GObject)mainMapLoader).x - ((GObject)mainMapLoader).width / 2f, ((GObject)mainMapLoader).y - ((GObject)mainMapLoader).height / 2f);
		if (val.x <= minX)
		{
			((GObject)mainMapLoader).SetXY(minX + ((GObject)mainMapLoader).width / 2f, ((GObject)mainMapLoader).y);
		}
		if (val.x >= maxX)
		{
			((GObject)mainMapLoader).SetXY(maxX + ((GObject)mainMapLoader).width / 2f, ((GObject)mainMapLoader).y);
		}
		if (val.y <= minY)
		{
			((GObject)mainMapLoader).SetXY(((GObject)mainMapLoader).x, minY + ((GObject)mainMapLoader).height / 2f);
		}
		if (val.y >= maxY)
		{
			((GObject)mainMapLoader).SetXY(((GObject)mainMapLoader).x, maxY + ((GObject)mainMapLoader).height / 2f);
		}
	}

	private void OnPinch(EventContext context)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000d: Expected O, but got Unknown
		PinchGesture val = (PinchGesture)context.sender;
		if (val.delta > 0f && pageController.selectedIndex == 0)
		{
			SwitchPage();
		}
		else if (val.delta < 0f && pageController.selectedIndex == 1)
		{
			SwitchPage();
		}
	}

	private IEnumerator RefreshStrongholdProgressBar()
	{
		yield return (object)new WaitForSeconds(0.5f);
		if (selectedArea == null || areaList == null || areaDataList == null)
		{
			yield return null;
		}
		else
		{
			int areaIndex = areaList.IndexOf(selectedArea);
			if (areaIndex == -1 || areaIndex >= areaDataList.Count)
			{
				yield return null;
			}
			else
			{
				Region region = areaDataList[areaIndex];
				long server_tm = GameController.Instance.GetServerTime();
				foreach (Stronghold stronghold in region.Strongholds)
				{
					if (!curRegionStrongholdsBars.TryGetValue(stronghold.StrongholdId, out var strongholdProgressBar) || strongholdProgressBar == null || ((GComponent)strongholdProgressBar).GetChild("time") == null || ((GObject)strongholdProgressBar).parent == null || ((GObject)strongholdProgressBar).parent.GetChild("MaxIcon") == null)
					{
						continue;
					}
					if (stronghold.Occupant(GameManagers.Instance) == null)
					{
						strongholdProgressBar.value = 0.0;
						((GComponent)strongholdProgressBar).GetChild("time").text = "";
					}
					else
					{
						Dictionary<string, float> curProductions = stronghold.Productions(GameManagers.Instance);
						if (curProductions == null || curProductions.Count == 0)
						{
							continue;
						}
						string itemid = curProductions.First().Key;
						int tm_produce_one = (int)(3600f / curProductions.First().Value);
						int currentStock = GameManagers.Instance.StockController.GetStock(itemid);
						int stockLimit = GameManagers.Instance.StockController.GetLimit(itemid);
						bool isMax = currentStock >= stockLimit;
						((GObject)strongholdProgressBar).parent.GetChild("MaxIcon").visible = isMax;
						if (isMax)
						{
							strongholdProgressBar.value = 0.0;
							((GComponent)strongholdProgressBar).GetChild("time").text = "";
							continue;
						}
						if (!GameManagers.Instance.StockController.AllRegionProductionSyncTime.TryGetValue(itemid, out var last_produce_tm))
						{
							last_produce_tm = (int)server_tm;
							GameManagers.Instance.StockController.AllRegionProductionSyncTime[itemid] = last_produce_tm;
						}
						int producingTime = 0;
						if (last_produce_tm > 0)
						{
							producingTime = (int)server_tm - last_produce_tm;
						}
						float progress = 1f * (float)producingTime / (float)tm_produce_one;
						if (progress <= 0f)
						{
							progress = 0f;
							producingTime = 0;
						}
						else if (progress >= 1f)
						{
							progress = 1f;
							producingTime = tm_produce_one;
						}
						strongholdProgressBar.value = progress * 100f;
						((GComponent)strongholdProgressBar).GetChild("time").text = $"{producingTime}S/{tm_produce_one}S";
					}
					strongholdProgressBar = null;
				}
			}
		}
		FGUIManager.Instance.CloseIEnumerator(RefreshStrongholdProgressBarCoroutine);
		RefreshStrongholdProgressBarCoroutine = FGUIManager.Instance.OpenIEnumerator(RefreshStrongholdProgressBar());
	}

	private IEnumerator PlayRegionProdAutoClaimed(int areaIndex)
	{
		float curRegionTotalNum = 0f;
		yield return (object)new WaitForSeconds(0.1f);
		if (((GObject)CurAreaEarnings).data != null)
		{
			curRegionTotalNum = (int)((GObject)CurAreaEarnings).data;
		}
		int curAreaIndex = areaList.IndexOf(selectedArea);
		if (curAreaIndex != areaIndex)
		{
			yield break;
		}
		FGUIManager.Instance.AddTextSpecialEffects(blackHoleBack.SfxBack, "black_hole", new Vector3(100f, 100f, 100f), "Default", 0.5f, delegate(GameObject blackHole)
		{
			blackHole.AddComponent<HotFix_DestroySelf>().destroyTime = 3f;
			UiAudioManager.Instance.LoadSoundsForSfx(blackHole, "portal");
		});
		if (MoneyBtnList.Count < curRegionLevelClips.Count)
		{
			for (int i = 0; i < curRegionLevelClips.Count - MoneyBtnList.Count; i++)
			{
				UI_MoneyBtn moneyBtn = UI_MoneyBtn.CreateInstance_ILRuntime();
				((GObject)moneyBtn).alpha = 0f;
				((GObject)moneyBtn).rotation = 0f;
				areaList[areaIndex].AddChild((GObject)(object)moneyBtn);
				MoneyBtnList.Add(moneyBtn);
			}
		}
		int index = 0;
		float curRegionTotalNum2nd = 0f;
		foreach (KeyValuePair<string, GMovieClip> curRegionLevelClip in curRegionLevelClips)
		{
			GMovieClip clip = curRegionLevelClip.Value;
			GButton level = ((GObject)((GObject)((GObject)((GObject)clip).parent).parent).parent).asButton;
			GComponent Wave = ((GComponent)level).GetChild("icon").asCom;
			GObject collectNumCom = Wave.GetChild("num");
			curRegionTotalNum2nd += (float)collectNumCom.data;
			if ((float)collectNumCom.data > 0f)
			{
				Vector2 initPos = ((GObject)level).xy + new Vector2(1f, -0.5f);
				if (index > MoneyBtnList.Count - 1)
				{
					UI_MoneyBtn moneyBtn2 = UI_MoneyBtn.CreateInstance_ILRuntime();
					((GObject)moneyBtn2).alpha = 0f;
					((GObject)moneyBtn2).rotation = 0f;
					areaList[areaIndex].AddChild((GObject)(object)moneyBtn2);
					MoneyBtnList.Add(moneyBtn2);
				}
				UI_MoneyBtn _moneyBtn = MoneyBtnList[index];
				((GObject)_moneyBtn).SetXY(initPos.x, initPos.y);
				((GObject)_moneyBtn).alpha = 1f;
				((GObject)_moneyBtn).rotation = 0f;
				collectNumCom.text = "";
				collectNumCom.data = 0f;
				float moveTime = Random.Range(0.3f, 0.7f);
				float startDelay = Random.Range(0.8f, 1.2f);
				Vector2 endPos = new Vector2(((GObject)blackHoleBack).x + Random.Range(-30f, 30f), ((GObject)blackHoleBack).y + Random.Range(-30f, 30f));
				((GObject)_moneyBtn).TweenFade(((GObject)_moneyBtn).alpha, 0.2f).OnComplete((GTweenCallback)delegate
				{
					//IL_0016: Unknown result type (might be due to invalid IL or missing references)
					FGUIManager.Instance.AddTextSpecialEffects(_moneyBtn.SfxBack, "exp_missile_yellow", Vector3.zero, "Default", 0.5f, delegate(GameObject expMissileYellow)
					{
						expMissileYellow.AddComponent<HotFix_DestroySelf>().destroyTime = moveTime + startDelay;
					});
				});
				GTweenCallback val = default(GTweenCallback);
				((GComponent)(object)this).SetTimeout(startDelay).OnComplete((GTweenCallback)delegate
				{
					//IL_0008: Unknown result type (might be due to invalid IL or missing references)
					//IL_002a: Unknown result type (might be due to invalid IL or missing references)
					//IL_002f: Unknown result type (might be due to invalid IL or missing references)
					//IL_0031: Expected O, but got Unknown
					//IL_0036: Expected O, but got Unknown
					GTweener obj = ((GObject)_moneyBtn).TweenMove(endPos, moveTime);
					GTweenCallback obj2 = val;
					if (obj2 == null)
					{
						GTweenCallback val2 = delegate
						{
							((GObject)_moneyBtn).TweenFade(0f, 0.2f);
						};
						GTweenCallback val3 = val2;
						val = val2;
						obj2 = val3;
					}
					obj.OnComplete(obj2);
					((GObject)_moneyBtn).TweenRotate(Random.Range(-60f, 60f), moveTime);
				});
			}
			index++;
		}
		((GObject)blackHoleBack).TweenFade(((GObject)blackHoleBack).alpha, 1.5f).OnComplete((GTweenCallback)delegate
		{
			//IL_0111: Unknown result type (might be due to invalid IL or missing references)
			//IL_011b: Expected O, but got Unknown
			if (curRegionTotalNum <= 0f)
			{
				curRegionTotalNum = curRegionTotalNum2nd;
			}
			UI_AreaEarningsNum areaEarningsNum = UI_AreaEarningsNum.CreateInstance_ILRuntime();
			((GObject)areaEarningsNum.num).text = $"+{(int)curRegionTotalNum}";
			((GObject)areaEarningsNum).SetPivot(0.5f, 0.5f, true);
			((GComponent)blackHoleBack).AddChild((GObject)(object)areaEarningsNum);
			((GComponent)blackHoleBack).SetChildIndex((GObject)(object)areaEarningsNum, 0);
			((GObject)areaEarningsNum).x = ((GObject)blackHoleBack).width / 2f;
			UiAudioManager.Instance.PlaySoundEffect("CoinDrop");
			GTweenCallback val = default(GTweenCallback);
			((GObject)areaEarningsNum).TweenFade(((GObject)areaEarningsNum).alpha, 0.2f).OnComplete((GTweenCallback)delegate
			{
				//IL_0048: Unknown result type (might be due to invalid IL or missing references)
				//IL_004d: Unknown result type (might be due to invalid IL or missing references)
				//IL_004f: Expected O, but got Unknown
				//IL_0054: Expected O, but got Unknown
				((GObject)areaEarningsNum.num).TweenMoveY(-150f, 0.6f);
				GTweener obj = ((GObject)areaEarningsNum.num).TweenFade(1f, 0.4f);
				GTweenCallback obj2 = val;
				if (obj2 == null)
				{
					GTweenCallback val2 = delegate
					{
						((GObject)areaEarningsNum.num).TweenFade(0f, 0.2f);
					};
					GTweenCallback val3 = val2;
					val = val2;
					obj2 = val3;
				}
				obj.OnComplete(obj2);
			});
		});
	}

	private IEnumerator RefreshLevelProgressBar()
	{
		yield return (object)new WaitForEndOfFrame();
		foreach (GMovieClip _clip in curRegionLevelClips.Values)
		{
			GButton level = ((GObject)((GObject)((GObject)((GObject)_clip).parent).parent).parent).asButton;
			GComponent Wave = ((GComponent)level).GetChild("icon").asCom;
			float produce_one_tm = (float)((GObject)_clip).data;
			((GObject)_clip).y = ((GObject)_clip).y - 36f * (Time.deltaTime / produce_one_tm);
			if (((GObject)_clip).y <= 0f)
			{
				PlayMoneyDisapear(Wave);
				((GObject)_clip).y = 36f;
			}
		}
		FGUIManager.Instance.CloseIEnumerator(RefreshLevelprogressBarCoroutine);
		RefreshLevelprogressBarCoroutine = FGUIManager.Instance.OpenIEnumerator(RefreshLevelProgressBar());
	}

	private void OnStockChange(string itemId, int incr, (StockInContext, string) context)
	{
		if (pageController.selectedIndex == 1)
		{
			for (int i = 0; i < CurAreaEarnings.earningsList.numItems; i++)
			{
				GButton asButton = ((GComponent)CurAreaEarnings.earningsList).GetChildAt(i).asButton;
				if (!(itemId != ((GObject)asButton).data.ToString()) && ((GComponent)asButton).GetController("Status").selectedIndex != 1)
				{
					int stock = GameManagers.Instance.StockController.GetStock(itemId);
					((GComponent)asButton).GetChild("totalNum").text = $"{stock}";
					((GComponent)asButton).GetChild("increment").data = stock;
					if (incr > 0)
					{
						((GComponent)asButton).GetChild("increment").text = $"+{incr}";
						((GComponent)asButton).GetTransition("GetEarnings").Play();
					}
				}
			}
		}
		else
		{
			if (pageController.selectedIndex != 0)
			{
				return;
			}
			if (CurEarnings.Status.selectedIndex == 0)
			{
				for (int j = 0; j < CurEarnings.earningsList.numItems; j++)
				{
					GButton asButton2 = ((GComponent)CurEarnings.earningsList).GetChildAt(j).asButton;
					if (((GObject)asButton2).data != null && !(itemId != ((GObject)asButton2).data.ToString()) && ((GComponent)asButton2).GetController("Status").selectedIndex != 1 && !(itemId == "Money"))
					{
						int stock2 = GameManagers.Instance.StockController.GetStock(itemId);
						((GComponent)asButton2).GetChild("totalNum").text = $"{stock2}";
						if (((GComponent)asButton2).GetChild("increment").data == null)
						{
							((GComponent)asButton2).GetChild("increment").data = stock2;
						}
						else if (incr > 0)
						{
							((GComponent)asButton2).GetChild("increment").text = $"+{incr}";
							((GComponent)asButton2).GetChild("increment").data = stock2;
							((GComponent)asButton2).GetTransition("GetEarnings").Play();
						}
					}
				}
			}
			else
			{
				UpdateAllAreasStrongholdInfo(itemId, incr);
			}
		}
	}

	private void OnPageRedDotChange(Cache_PrinceRedDot cache)
	{
		SetTitleRedPoint();
	}

	private void CurEarningsListInit()
	{
		if (CurEarnings.Status.selectedIndex == 1)
		{
			CurEarnings.Status.selectedIndex = 0;
			CurEarnings.SetControllerPageText();
		}
	}

	private void CurEarningsListSwtich()
	{
		if (CurEarnings.Status.selectedIndex == 0)
		{
			CurEarnings.Status.selectedIndex = 1;
			((GComponent)CurEarnings).EnsureBoundsCorrect();
			((GObject)CurEarnings).y = 1076f;
		}
		else
		{
			CurEarnings.Status.selectedIndex = 0;
			((GComponent)CurEarnings).EnsureBoundsCorrect();
			((GObject)CurEarnings).y = 1076f;
		}
		CurEarnings.SetControllerPageText();
	}

	private void SetPageBtnStatus()
	{
		int num = areaList.IndexOf(selectedArea);
		if (num <= 1)
		{
			((GObject)LastRegionBtn).visible = false;
			((GObject)leftArrow).visible = false;
		}
		else
		{
			Region region = areaDataList[num - 1];
			bool flag = region.Status(GameManagers.Instance) == RegionStatus.Locked;
			LastRegionBtn.n8.url = GetFguiAreaNameUrl(region);
			LastRegionBtn.c1.SetSelectedIndex(flag ? 1 : 0);
			((GObject)LastRegionBtn).visible = true;
			((GObject)leftArrow).visible = true;
		}
		if (num + 1 > areaDataList.Count - 1)
		{
			NextRegionBtn.c1.SetSelectedIndex(1);
			((GObject)rightArrow).visible = false;
			return;
		}
		Region region2 = areaDataList[num + 1];
		NextRegionBtn.n8.url = GetFguiAreaNameUrl(region2);
		if (region2.Status(GameManagers.Instance) == RegionStatus.Locked)
		{
			if (!GameManagers.Instance.UserArchiveManager.CheckRegionUnlockBonusesClaimed(areaDataList[num + 1].RegionId) && occupyingIndex == num + 1)
			{
				NextRegionBtn.c1.SetSelectedIndex(0);
				((GObject)NextRegionBtn).visible = true;
				((GObject)NextRegionBtn).touchable = true;
				((GObject)rightArrow).visible = true;
				((GObject)NextRegionBtn.note).visible = true;
			}
			else
			{
				NextRegionBtn.c1.SetSelectedIndex(1);
				((GObject)NextRegionBtn).touchable = false;
				((GObject)NextRegionBtn).visible = true;
				((GObject)rightArrow).visible = true;
				((GObject)NextRegionBtn.note).visible = false;
			}
		}
		else
		{
			NextRegionBtn.c1.SetSelectedIndex(0);
			((GObject)NextRegionBtn).visible = true;
			((GObject)NextRegionBtn).touchable = true;
			((GObject)rightArrow).visible = true;
		}
	}

	private static string GetFguiAreaNameUrl(Region region)
	{
		return "ui://WorldMap/text_region_name_" + region.RegionId;
	}

	private void QuickChangeRegion(EventContext context)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		int num = Convert.ToInt32(((GObject)context.sender).data);
		int num2 = areaList.IndexOf(selectedArea);
		int num3 = num2 + num;
		if (num3 > areaList.Count - 1)
		{
			num3 = areaList.Count - 1;
		}
		if (num3 < 0)
		{
			num3 = 0;
		}
		if (areaDataList[num3].Status(GameManagers.Instance) != RegionStatus.Locked)
		{
			ToArea(areaList[num3]);
		}
	}

	private void StartEnterBattleGuide()
	{
		if (GameManagers.Instance.UserArchiveManager.IsNewGuideMode() && !fromBattleField && !GameManagers.Instance.UserArchiveManager.GetChapterLevelProgress("C1002").Contains("P220"))
		{
			showFingerTimerCoroutine = FGUIManager.Instance.OpenIEnumerator(ShowFingerTimer());
		}
	}

	private void CloseEnterBattleGuide()
	{
		if (showFingerTimerCoroutine != null)
		{
			FGUIManager.Instance.CloseIEnumerator(showFingerTimerCoroutine);
		}
	}

	private IEnumerator ShowFingerTimer()
	{
		while (true)
		{
			interval += 2;
			yield return (object)new WaitForSecondsRealtime(2f);
			if (!CanShowFinger())
			{
				interval = 0;
			}
			if (interval > 3)
			{
				interval = 0;
				ShowFinger();
			}
		}
	}

	private bool CanShowFinger()
	{
		if (((GObject)Finger).visible)
		{
			return false;
		}
		if (hasFguiGrootClick)
		{
			hasFguiGrootClick = false;
			return false;
		}
		if (pageController.selectedIndex != 1)
		{
			return false;
		}
		if (!((GObject)CurAreaEarnings.EnterBattlefieldBtn).visible)
		{
			return false;
		}
		if (GameManagers.Instance.NewGuideMissionManager.MonoInstance.HasStoryPlaying())
		{
			return false;
		}
		return true;
	}

	private void ShowFinger()
	{
		//IL_0045: Unknown result type (might be due to invalid IL or missing references)
		//IL_004a: Unknown result type (might be due to invalid IL or missing references)
		//IL_004f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0056: Unknown result type (might be due to invalid IL or missing references)
		((GObject)Finger).visible = true;
		Vector2 gObjectPositionOnGRoot = UiHelper.GetGObjectPositionOnGRoot((GObject)(object)CurAreaEarnings.EnterBattlefieldBtn, new Vector2(((GObject)CurAreaEarnings.EnterBattlefieldBtn).width / 2f, ((GObject)CurAreaEarnings.EnterBattlefieldBtn).height / 2f));
		((GObject)Finger).xy = gObjectPositionOnGRoot;
	}

	private void GRootInstClick()
	{
		hasFguiGrootClick = true;
		((GObject)Finger).visible = false;
	}
}
