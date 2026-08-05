using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;
using GameDataEditor;
using HotFix.Sources.Base.Scripts.Helper.ClickSimulator;
using Shift.Legion.Client.Sources.Extensions;
using Shift.Legion.ClientApi.Models;
using Shift.Legion.Common.Enums;
using Shift.Legion.Common.Managers;
using Shift.Legion.Common.Models;
using Shift.Legion.Common.Services;
using Shift.Legion.Helpers;
using Spine.Unity;
using UI.GameEndPanels;
using UI.InstanceZones;
using UI.LegendItemDungeon;
using UI.MilitaryIntelligence;
using UI.Tips;
using UnityEngine;

namespace UI.MilitaryAFKAssistant;

public class UI_main_MilitaryAFKAssistant : GComponent, IUiController
{
	[Serializable]
	[CompilerGenerated]
	private sealed class _003C_003Ec
	{
		public static readonly _003C_003Ec _003C_003E9 = new _003C_003Ec();

		public static Func<TreasureHuntLevelInfo, bool> _003C_003E9__26_0;

		public static Func<string, bool> _003C_003E9__39_0;

		public static Action _003C_003E9__40_1;

		public static Func<GameLocalDataManager.MilitaryAssistantData, bool> _003C_003E9__46_0;

		public static Action _003C_003E9__46_2;

		public static Action _003C_003E9__57_0;

		public static Action<Exception> _003C_003E9__59_1;

		public static EventCallback1 _003C_003E9__60_0;

		internal bool _003CCheckCacheData_003Eb__26_0(TreasureHuntLevelInfo levelInfo)
		{
			int value;
			return LegendItemDungeonUiHelper.LegendItemDungeonLevelStatus.TryGetValue(levelInfo.LevelId, out value) && value == 2;
		}

		internal bool _003CRenderLegendItemDungeonLevelOption_003Eb__39_0(string _soldierId)
		{
			return GameManagers.Instance.StockController.GetStock(_soldierId) > 0;
		}

		internal void _003CConfirmLegendItemDungeonPlayingIntro_003Eb__40_1()
		{
		}

		internal bool _003COnClickStart_003Eb__46_0(GameLocalDataManager.MilitaryAssistantData cacheData)
		{
			return cacheData == null || (string.IsNullOrEmpty(cacheData.LevelId) && cacheData.LevelIndex == -1 && cacheData.LevelDifficulty == -1);
		}

		internal void _003COnClickStart_003Eb__46_2()
		{
		}

		internal void _003CPopupResultDialog_003Eb__57_0()
		{
		}

		internal void _003CLoadSpine_003Eb__59_1(Exception e)
		{
			ILRuntimeDebug.LogError(e.Message);
		}

		internal void _003CStopClickEventPropagation_003Eb__60_0(EventContext e)
		{
			e.StopPropagation();
		}
	}

	public Controller onGoing;

	public Controller showEditor;

	public GGraph mask;

	public UI_com_07 n3;

	public GGraph SpineWrapper;

	public GLoader SpineClickMask;

	public GGraph n4;

	public UI_com_AssistantPanel AssistantPanel;

	public const string URL = "ui://8x5gc8j2o7bu0";

	public static string Name = "UI_main_MilitaryAFKAssistant";

	private List<Activity> _activities;

	private Coroutine ScriptCoroutine;

	private ClickSimulatorScript CurrentRunningScript;

	private SkeletonAnimation _goblinPlayingGameAnimation;

	private List<GameLocalDataManager.MilitaryAssistantData> _militaryAssistantDatas;

	public string resultTips = null;

	private SkeletonAnimation goblinPlayingGameAnimation
	{
		get
		{
			//IL_0046: Unknown result type (might be due to invalid IL or missing references)
			//IL_0066: Unknown result type (might be due to invalid IL or missing references)
			//IL_006b: Unknown result type (might be due to invalid IL or missing references)
			//IL_008b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0090: Unknown result type (might be due to invalid IL or missing references)
			//IL_009c: Unknown result type (might be due to invalid IL or missing references)
			//IL_00a2: Expected O, but got Unknown
			//IL_00be: Unknown result type (might be due to invalid IL or missing references)
			if ((Object)(object)_goblinPlayingGameAnimation == (Object)null)
			{
				GameObject val = Object.Instantiate<GameObject>(Resources.Load<GameObject>("SpineTest"));
				_goblinPlayingGameAnimation = val.GetComponent<SkeletonAnimation>();
				val.transform.localScale = new Vector3(100f, 100f, 100f);
				val.transform.localPosition = -new Vector3(0f, 0f, 0f);
				val.transform.localEulerAngles = -new Vector3(0f, 0f, 0f);
				GoWrapper val2 = new GoWrapper(val);
				((DisplayObject)val2).SetXY(0f, 0f);
				((DisplayObject)val2).pivot = new Vector2(0.5f, 0.5f);
				((DisplayObject)val2).scaleX = 1f;
				((DisplayObject)val2).scaleY = 1f;
				SpineWrapper.SetNativeObject((DisplayObject)(object)val2);
			}
			return _goblinPlayingGameAnimation;
		}
	}

	public static string GetURL()
	{
		return "ui://8x5gc8j2o7bu0";
	}

	public static UI_main_MilitaryAFKAssistant CreateInstance()
	{
		return (UI_main_MilitaryAFKAssistant)(object)UIPackage.CreateObject("MilitaryAFKAssistant", "main_MilitaryAFKAssistant");
	}

	public static UI_main_MilitaryAFKAssistant CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_main_MilitaryAFKAssistant).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://8x5gc8j2o7bu0", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0037: Unknown result type (might be due to invalid IL or missing references)
		//IL_0041: Expected O, but got Unknown
		//IL_0063: Unknown result type (might be due to invalid IL or missing references)
		//IL_006d: Expected O, but got Unknown
		//IL_0079: Unknown result type (might be due to invalid IL or missing references)
		//IL_0083: Expected O, but got Unknown
		//IL_008f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0099: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		onGoing = ((GComponent)this).GetController("onGoing");
		showEditor = ((GComponent)this).GetController("showEditor");
		mask = (GGraph)((GComponent)this).GetChild("mask");
		n3 = (UI_com_07)(object)((GComponent)this).GetChild("n3");
		SpineWrapper = (GGraph)((GComponent)this).GetChild("SpineWrapper");
		SpineClickMask = (GLoader)((GComponent)this).GetChild("SpineClickMask");
		n4 = (GGraph)((GComponent)this).GetChild("n4");
		AssistantPanel = (UI_com_AssistantPanel)(object)((GComponent)this).GetChild("AssistantPanel");
	}

	public void RegisterUiEventListeners()
	{
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_001d: Expected O, but got Unknown
		//IL_0030: Unknown result type (might be due to invalid IL or missing references)
		//IL_003a: Expected O, but got Unknown
		//IL_0052: Unknown result type (might be due to invalid IL or missing references)
		//IL_005c: Expected O, but got Unknown
		//IL_0074: Unknown result type (might be due to invalid IL or missing references)
		//IL_007e: Expected O, but got Unknown
		((GObject)mask).onClick.Add(new EventCallback0(OnClickMask));
		((GObject)SpineClickMask).onClick.Add(new EventCallback0(OnClickSpineWrapper));
		((GObject)AssistantPanel.startBtn).onClick.Add(new EventCallback1(OnClickStart));
		((GObject)AssistantPanel.pauseBtn).onClick.Add(new EventCallback1(OnClickPause));
		SharedMessenger.AddListener<string>("CLICK_SIMULATOR_ABORTED", OnSimulatorAborted);
		SharedMessenger.AddListener<string>("CLICK_SIMULATOR_ONCE_CHALLENGE", OnOnceChallenge);
		SharedMessenger.AddListener<string>("CLICK_SIMULATOR_ONCE_FINISH", OnScriptOnceFinish);
	}

	public void UnregisterUiEventListeners()
	{
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_001d: Expected O, but got Unknown
		//IL_0030: Unknown result type (might be due to invalid IL or missing references)
		//IL_003a: Expected O, but got Unknown
		//IL_0052: Unknown result type (might be due to invalid IL or missing references)
		//IL_005c: Expected O, but got Unknown
		//IL_0074: Unknown result type (might be due to invalid IL or missing references)
		//IL_007e: Expected O, but got Unknown
		((GObject)mask).onClick.Remove(new EventCallback0(OnClickMask));
		((GObject)SpineClickMask).onClick.Remove(new EventCallback0(OnClickSpineWrapper));
		((GObject)AssistantPanel.startBtn).onClick.Remove(new EventCallback1(OnClickStart));
		((GObject)AssistantPanel.pauseBtn).onClick.Remove(new EventCallback1(OnClickPause));
		SharedMessenger.RemoveListener<string>("CLICK_SIMULATOR_ABORTED", OnSimulatorAborted);
		SharedMessenger.RemoveListener<string>("CLICK_SIMULATOR_ONCE_CHALLENGE", OnOnceChallenge);
		SharedMessenger.RemoveListener<string>("CLICK_SIMULATOR_ONCE_FINISH", OnScriptOnceFinish);
	}

	public void Init(Dictionary<string, object> parameters)
	{
		FGUIManager.SetUiPanelSizeAndXy((GObject)(object)this, scaleAdaption: true);
		if (parameters != null && parameters.TryGetValue("Status", out var value))
		{
			onGoing.selectedIndex = Convert.ToInt32(value);
		}
		else
		{
			onGoing.selectedIndex = 0;
		}
		showEditor.selectedIndex = 1;
		LoadData();
		CheckCacheData();
	}

	private void LoadData()
	{
		Activity currentSingletonActivityByType = GameManagers.Instance.ActivityManager.GetCurrentSingletonActivityByType(ActivityType.TimeLimitInstance);
		Activity currentSingletonActivityByType2 = GameManagers.Instance.ActivityManager.GetCurrentSingletonActivityByType(ActivityType.DefenseInstance);
		Activity currentSingletonActivityByType3 = GameManagers.Instance.ActivityManager.GetCurrentSingletonActivityByType(ActivityType.AttackInstance);
		Activity item = GameManagers.Instance.ActivityManager.GetActivitiesByType(ActivityType.TreasureHunt)[0];
		Activity item2 = FGUIManager.Instance.NeutralDungeonData?.Activity;
		_activities = new List<Activity> { currentSingletonActivityByType, currentSingletonActivityByType2, currentSingletonActivityByType3, item, item2 };
	}

	private void CheckCacheData()
	{
		_militaryAssistantDatas = new List<GameLocalDataManager.MilitaryAssistantData>();
		foreach (Activity activity in _activities)
		{
			ActivityType type = activity.Type;
			ActivityType activityType = type;
			string text = ((activityType != ActivityType.DefenseInstance && activityType != ActivityType.TimeLimitInstance && activityType != ActivityType.NeutralDungeonInstance) ? activity.Type.ToString() : activity.ActivityId);
			GameLocalDataManager.MilitaryAssistantData militaryAssistantData = GameLocalDataManager.GetMilitaryAssistantData(text);
			if (militaryAssistantData == null)
			{
				militaryAssistantData = new GameLocalDataManager.MilitaryAssistantData
				{
					ActivityId = activity.ActivityId,
					ActivityMark = text
				};
			}
			else
			{
				militaryAssistantData.ChallengeCnt = 0;
				militaryAssistantData.ChallengePlan = 0;
				militaryAssistantData.Status = GameLocalDataManager.MilitaryAssistantStatus.Preparing;
			}
			if (activity.Type == ActivityType.TreasureHunt)
			{
				militaryAssistantData.ChallengePlan = LegendItemDungeonUiHelper.ScoreToBoss - Math.Max(LegendItemDungeonUiHelper.CurFinishedLevelNum, 0);
				List<TreasureHuntLevelInfo> source = LegendItemDungeonUiHelper.LegendItemDungeonLevels["BOSS"];
				if (!source.Any((TreasureHuntLevelInfo levelInfo) => LegendItemDungeonUiHelper.LegendItemDungeonLevelStatus.TryGetValue(levelInfo.LevelId, out var value) && value == 2))
				{
					militaryAssistantData.ChallengePlan++;
				}
			}
			else
			{
				militaryAssistantData.ChallengePlan = GameManagers.Instance.StockController.GetStock(activity.TicketItem);
			}
			militaryAssistantData.ChallengeCnt = militaryAssistantData.ChallengePlan;
			_militaryAssistantDatas.Add(militaryAssistantData);
		}
	}

	public void OnShow()
	{
		RenderActivitiesList();
	}

	private void RenderActivitiesList()
	{
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_001d: Expected O, but got Unknown
		AssistantPanel.LevelSelecters.itemRenderer = new ListItemRenderer(RenderLevelSelector);
		AssistantPanel.LevelSelecters.numItems = _activities.Count;
		for (int i = 0; i < AssistantPanel.LevelSelecters.numItems; i++)
		{
			UI_com_LevelSelector uI_com_LevelSelector = ((GComponent)AssistantPanel.LevelSelecters).GetChildAt(i) as UI_com_LevelSelector;
			StopClickEventPropagation((GComponent)(object)uI_com_LevelSelector.levelOptions);
		}
	}

	private void RenderLevelSelector(int index, GObject obj)
	{
		//IL_0321: Unknown result type (might be due to invalid IL or missing references)
		//IL_032b: Expected O, but got Unknown
		UI_com_LevelSelector uI_com_LevelSelector = obj.asCom as UI_com_LevelSelector;
		Activity activity = _activities[index];
		((GObject)uI_com_LevelSelector).data = index;
		UI_com_LevelSelectorLabel levelSeletorLabel = uI_com_LevelSelector.levelSeletorLabel;
		int selectedIndex = levelSeletorLabel.onGoingController.selectedIndex;
		uI_com_LevelSelector.enabled.selectedIndex = 1;
		if (activity.Type == ActivityType.TimeLimitInstance)
		{
			levelSeletorLabel.labelPreparing.typeController.selectedIndex = 0;
			levelSeletorLabel.labelOnGoing.typeController.selectedIndex = 0;
		}
		else if (activity.Type == ActivityType.DefenseInstance)
		{
			levelSeletorLabel.labelPreparing.typeController.selectedIndex = 1;
			levelSeletorLabel.labelOnGoing.typeController.selectedIndex = 1;
		}
		else if (activity.Type == ActivityType.AttackInstance)
		{
			levelSeletorLabel.labelPreparing.typeController.selectedIndex = 2;
			levelSeletorLabel.labelOnGoing.typeController.selectedIndex = 2;
		}
		else if (activity.Type == ActivityType.TreasureHunt)
		{
			levelSeletorLabel.labelPreparing.typeController.selectedIndex = 3;
			levelSeletorLabel.labelOnGoing.typeController.selectedIndex = 3;
		}
		else if (activity.Type == ActivityType.NeutralDungeonInstance)
		{
			levelSeletorLabel.labelPreparing.typeController.selectedIndex = 4;
			levelSeletorLabel.labelOnGoing.typeController.selectedIndex = 4;
		}
		GameLocalDataManager.MilitaryAssistantData militaryAssistantData = _militaryAssistantDatas[index];
		((GObject)levelSeletorLabel.labelOnGoing.ticketsTip).text = $"{militaryAssistantData.ChallengeCnt}/{militaryAssistantData.ChallengePlan}";
		switch (militaryAssistantData.Status)
		{
		case GameLocalDataManager.MilitaryAssistantStatus.Preparing:
			if (string.IsNullOrEmpty(militaryAssistantData.LevelId) && militaryAssistantData.LevelIndex < 0 && militaryAssistantData.LevelDifficulty < 0)
			{
				levelSeletorLabel.onGoingController.selectedIndex = 0;
				levelSeletorLabel.labelPreparing.battleController.selectedIndex = 0;
				levelSeletorLabel.labelPreparing.expanded.selectedIndex = 0;
				((GObject)levelSeletorLabel.labelPreparing.ticketsTip).text = $"{militaryAssistantData.ChallengeCnt}/{militaryAssistantData.ChallengePlan}";
			}
			else
			{
				levelSeletorLabel.onGoingController.selectedIndex = 1;
				((GObject)levelSeletorLabel.labelOnGoing.levelName).text = militaryAssistantData.LevelDesc;
				for (int i = 0; i < levelSeletorLabel.labelOnGoing.stars.numItems; i++)
				{
					UI_com_star uI_com_star = ((GComponent)levelSeletorLabel.labelOnGoing.stars).GetChildAt(i) as UI_com_star;
					uI_com_star.active.selectedIndex = ((i < militaryAssistantData.LevelDifficulty) ? 1 : 0);
				}
				levelSeletorLabel.labelOnGoing.expanded.selectedIndex = 0;
				levelSeletorLabel.labelOnGoing.battleController.selectedIndex = 0;
				levelSeletorLabel.labelOnGoing.stateController.selectedIndex = 2;
			}
			((GObject)levelSeletorLabel).onClick.Add(new EventCallback1(OnClickLevelSelectorLabel));
			break;
		case GameLocalDataManager.MilitaryAssistantStatus.Battling:
			levelSeletorLabel.onGoingController.selectedIndex = 1;
			levelSeletorLabel.labelOnGoing.expanded.selectedIndex = 0;
			levelSeletorLabel.labelOnGoing.battleController.selectedIndex = 1;
			levelSeletorLabel.labelOnGoing.stateController.selectedIndex = 1;
			break;
		case GameLocalDataManager.MilitaryAssistantStatus.Done:
			levelSeletorLabel.onGoingController.selectedIndex = 1;
			levelSeletorLabel.labelOnGoing.expanded.selectedIndex = 0;
			levelSeletorLabel.labelOnGoing.battleController.selectedIndex = 0;
			levelSeletorLabel.labelOnGoing.stateController.selectedIndex = 0;
			break;
		}
		bool flag = (activity.Type == ActivityType.TreasureHunt || GameManagers.Instance.StockController.GetStock(activity.TicketItem) > 0) && militaryAssistantData.ChallengePlan > 0;
		levelSeletorLabel.labelPreparing.canChallenge.selectedIndex = ((!flag) ? 1 : 0);
		levelSeletorLabel.labelOnGoing.canChallenge.selectedIndex = ((!flag) ? 1 : 0);
		bool flag2 = activity.GetStatus(GameManagers.Instance) == ActivityStatus.Enabled;
		((GObject)uI_com_LevelSelector).grayed = !flag2;
		((GObject)uI_com_LevelSelector).touchable = flag2;
		if (selectedIndex != levelSeletorLabel.onGoingController.selectedIndex)
		{
			if (levelSeletorLabel.onGoingController.selectedIndex == 1)
			{
				((GObject)uI_com_LevelSelector).height = ((GObject)uI_com_LevelSelector).height - 70f;
			}
			else
			{
				((GObject)uI_com_LevelSelector).height = ((GObject)uI_com_LevelSelector).height + 70f;
			}
		}
	}

	private void OnClickLevelSelectorLabel(EventContext context)
	{
		if (onGoing.selectedIndex != 1)
		{
			UI_com_LevelSelectorLabel uI_com_LevelSelectorLabel = context.sender as UI_com_LevelSelectorLabel;
			UI_com_LevelSelector uI_com_LevelSelector = ((GObject)uI_com_LevelSelectorLabel).parent as UI_com_LevelSelector;
			if (uI_com_LevelSelector.enabled.selectedIndex == 1)
			{
				ToggleLevelSelector(uI_com_LevelSelector);
			}
		}
	}

	private void ToggleLevelSelector(UI_com_LevelSelector levelSelector)
	{
		if (levelSelector.dropDownController.selectedIndex == 0)
		{
			levelSelector.dropDownController.selectedIndex = 1;
			levelSelector.levelSeletorLabel.labelPreparing.expanded.selectedIndex = 1;
			levelSelector.levelSeletorLabel.labelOnGoing.expanded.selectedIndex = 1;
			RenderLevelOptions(levelSelector);
			((GObject)levelSelector).height = ((GObject)levelSelector).height + 40f;
			levelSelector.levelOptions.LevelOptions.ResizeToFit(levelSelector.levelOptions.LevelOptions.numItems);
		}
		else if (levelSelector.dropDownController.selectedIndex == 1)
		{
			levelSelector.levelOptions.LevelOptions.ResizeToFit(0);
			((GObject)levelSelector).height = ((GObject)levelSelector).height - 40f;
			levelSelector.dropDownController.selectedIndex = 0;
			levelSelector.levelSeletorLabel.labelPreparing.expanded.selectedIndex = 0;
			levelSelector.levelSeletorLabel.labelOnGoing.expanded.selectedIndex = 0;
		}
		((GComponent)AssistantPanel.LevelSelecters).scrollPane.ScrollToView((GObject)(object)levelSelector, true);
	}

	private void RenderLevelOptions(UI_com_LevelSelector levelSelector)
	{
		int index = Convert.ToInt32(((GObject)levelSelector).data);
		GameLocalDataManager.MilitaryAssistantData assistantData = _militaryAssistantDatas[index];
		Activity activity = _activities[index];
		switch (activity.Type)
		{
		case ActivityType.TimeLimitInstance:
			RenderTimeLimitDungeonLevelOption(levelSelector.levelOptions, activity, assistantData);
			break;
		case ActivityType.DefenseInstance:
			RenderDefenseDungeonLevelOption(levelSelector.levelOptions, activity, assistantData);
			break;
		case ActivityType.AttackInstance:
			RenderOffensiveDungeonLevelOption(levelSelector.levelOptions, activity, assistantData);
			break;
		case ActivityType.TreasureHunt:
			RenderLegendItemDungeonLevelOption(levelSelector.levelOptions, activity, assistantData);
			break;
		case ActivityType.NeutralDungeonInstance:
			RenderNeutralDungeonLevelOption(levelSelector.levelOptions, activity, assistantData);
			break;
		}
	}

	private void RenderTimeLimitDungeonLevelOption(UI_com_LevelOptionsList levelOptionsList, Activity activity, GameLocalDataManager.MilitaryAssistantData assistantData)
	{
		//IL_013e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0148: Expected O, but got Unknown
		//IL_0298: Unknown result type (might be due to invalid IL or missing references)
		//IL_02a2: Expected O, but got Unknown
		levelOptionsList.LevelOptions.numItems = 0;
		levelOptionsList.LevelOptions.RemoveChildrenToPool();
		List<string> list = activity.UnlockedContent(GameManagers.Instance);
		bool flag = true;
		foreach (ActivityContentPayload value in activity.ContentPayload(GameManagers.Instance).Values)
		{
			ChapterActivityPayload chapterActivityPayload = (ChapterActivityPayload)value;
			if (chapterActivityPayload.IsPortal)
			{
				flag = chapterActivityPayload.CanPortal(GameManagers.Instance);
				continue;
			}
			Level level = chapterActivityPayload.Levels(GameManagers.Instance)[0];
			UI_com_LevelOption uI_com_LevelOption = levelOptionsList.LevelOptions.AddItemFromPool() as UI_com_LevelOption;
			uI_com_LevelOption.typeController.selectedIndex = 0;
			if (assistantData.LevelId == level.LevelId)
			{
				uI_com_LevelOption.stateController.selectedIndex = 1;
			}
			else if (!list.Contains(chapterActivityPayload.ChapterId))
			{
				uI_com_LevelOption.stateController.selectedIndex = 2;
			}
			else
			{
				uI_com_LevelOption.stateController.selectedIndex = 0;
			}
			((GObject)uI_com_LevelOption.levelName).text = level.Name;
			((GObject)uI_com_LevelOption).data = level.LevelId;
			((GObject)uI_com_LevelOption).onClick.Add(new EventCallback1(ChooseThemeDungeonLevel));
		}
		Activity activity2 = ActivityManager.Activities[activity.Data.SubActivity];
		List<string> list2 = activity2.UnlockedContent(GameManagers.Instance);
		foreach (ActivityContentPayload value2 in activity2.ContentPayload(GameManagers.Instance).Values)
		{
			ChapterActivityPayload chapterActivityPayload2 = (ChapterActivityPayload)value2;
			Level level2 = chapterActivityPayload2.Levels(GameManagers.Instance)[0];
			if (!chapterActivityPayload2.IsPortal)
			{
				UI_com_LevelOption uI_com_LevelOption2 = levelOptionsList.LevelOptions.AddItemFromPool() as UI_com_LevelOption;
				uI_com_LevelOption2.typeController.selectedIndex = 0;
				if (assistantData.LevelId == level2.LevelId)
				{
					uI_com_LevelOption2.stateController.selectedIndex = 1;
				}
				else if (!list2.Contains(chapterActivityPayload2.ChapterId) || !flag)
				{
					uI_com_LevelOption2.stateController.selectedIndex = 2;
				}
				else
				{
					uI_com_LevelOption2.stateController.selectedIndex = 0;
				}
				((GObject)uI_com_LevelOption2.levelName).text = level2.Name;
				((GObject)uI_com_LevelOption2).data = level2.LevelId;
				((GObject)uI_com_LevelOption2).onClick.Add(new EventCallback1(ChooseThemeDungeonLevel));
			}
		}
		UI_com_LevelOptionTip uI_com_LevelOptionTip = levelOptionsList.LevelOptions.AddItemFromPool("ui://8x5gc8j2ihxkv4v2") as UI_com_LevelOptionTip;
		((GObject)uI_com_LevelOptionTip.tipContent).text = LanguagesManager.GetDesc("TipsMilitaryAFKAssistantChooseLevel_ThemeDungeon");
		StopClickEventPropagation((GComponent)(object)uI_com_LevelOptionTip);
	}

	private void ChooseThemeDungeonLevel(EventContext eventContext)
	{
		UI_com_LevelOption uI_com_LevelOption = eventContext.sender as UI_com_LevelOption;
		UI_com_LevelSelector uI_com_LevelSelector = ((GObject)((GObject)((GObject)uI_com_LevelOption).parent).parent).parent as UI_com_LevelSelector;
		int index = Convert.ToInt32(((GObject)uI_com_LevelSelector).data);
		if (uI_com_LevelOption.stateController.selectedIndex == 2)
		{
			eventContext.StopPropagation();
			List<string> arg = new List<string> { string.Format(LanguagesManager.GetDesc("TipsLevelNotUnlockedYet_ThemeDungeonAdvanced"), ((GObject)uI_com_LevelOption.levelName).text) };
			SharedMessenger.Broadcast("SHOW_TIPS", arg, 1, arg3: false);
			return;
		}
		GameLocalDataManager.MilitaryAssistantData militaryAssistantData = _militaryAssistantDatas[index];
		militaryAssistantData = new GameLocalDataManager.MilitaryAssistantData
		{
			ActivityId = militaryAssistantData.ActivityId,
			ActivityMark = militaryAssistantData.ActivityMark,
			ChallengePlan = militaryAssistantData.ChallengePlan,
			ChallengeCnt = militaryAssistantData.ChallengeCnt,
			Status = GameLocalDataManager.MilitaryAssistantStatus.Preparing
		};
		if (uI_com_LevelOption.stateController.selectedIndex == 0)
		{
			militaryAssistantData.LevelId = ((GObject)uI_com_LevelOption).data.ToString();
			militaryAssistantData.LevelDesc = ((GObject)uI_com_LevelOption.levelName).text;
		}
		_militaryAssistantDatas[index] = militaryAssistantData;
		GameLocalDataManager.SetMilitaryAssistantData(militaryAssistantData);
		ToggleLevelSelector(uI_com_LevelSelector);
		RenderLevelSelector(index, (GObject)(object)uI_com_LevelSelector);
	}

	private void RenderDefenseDungeonLevelOption(UI_com_LevelOptionsList levelOptionsList, Activity activity, GameLocalDataManager.MilitaryAssistantData assistantData)
	{
		//IL_0112: Unknown result type (might be due to invalid IL or missing references)
		//IL_011c: Expected O, but got Unknown
		levelOptionsList.LevelOptions.numItems = 0;
		levelOptionsList.LevelOptions.RemoveChildrenToPool();
		List<string> list = activity.UnlockedContent(GameManagers.Instance);
		List<ActivityContentPayload> list2 = activity.ContentPayload(GameManagers.Instance).Values.ToList();
		for (int i = 0; i < list2.Count; i++)
		{
			ActivityContentPayload activityContentPayload = list2[i];
			ChapterActivityPayload chapterActivityPayload = (ChapterActivityPayload)activityContentPayload;
			Level level = chapterActivityPayload.Levels(GameManagers.Instance)[0];
			UI_com_LevelOption uI_com_LevelOption = levelOptionsList.LevelOptions.AddItemFromPool() as UI_com_LevelOption;
			uI_com_LevelOption.typeController.selectedIndex = 1;
			if (assistantData.LevelIndex == i)
			{
				uI_com_LevelOption.stateController.selectedIndex = 1;
			}
			else if (!list.Contains(chapterActivityPayload.ChapterId))
			{
				uI_com_LevelOption.stateController.selectedIndex = 2;
			}
			else
			{
				uI_com_LevelOption.stateController.selectedIndex = 0;
			}
			((GObject)uI_com_LevelOption.levelName).text = level.Name;
			((GObject)uI_com_LevelOption).data = i;
			((GObject)uI_com_LevelOption).onClick.Add(new EventCallback1(ChooseDefenseDungeonLevel));
		}
		UI_com_LevelOptionTip uI_com_LevelOptionTip = levelOptionsList.LevelOptions.AddItemFromPool("ui://8x5gc8j2ihxkv4v2") as UI_com_LevelOptionTip;
		((GObject)uI_com_LevelOptionTip.tipContent).text = LanguagesManager.GetDesc("TipsMilitaryAFKAssistantChooseLevel_DefenseDungeon");
		StopClickEventPropagation((GComponent)(object)uI_com_LevelOptionTip);
	}

	private void ChooseDefenseDungeonLevel(EventContext eventContext)
	{
		UI_com_LevelOption uI_com_LevelOption = eventContext.sender as UI_com_LevelOption;
		UI_com_LevelSelector uI_com_LevelSelector = ((GObject)((GObject)((GObject)uI_com_LevelOption).parent).parent).parent as UI_com_LevelSelector;
		int index = Convert.ToInt32(((GObject)uI_com_LevelSelector).data);
		if (uI_com_LevelOption.stateController.selectedIndex == 2)
		{
			eventContext.StopPropagation();
			List<string> arg = new List<string> { string.Format(LanguagesManager.GetDesc("TipsLevelNotUnlockedYet_DefenseDungeon"), ((GObject)uI_com_LevelOption.levelName).text) };
			SharedMessenger.Broadcast("SHOW_TIPS", arg, 1, arg3: false);
			return;
		}
		GameLocalDataManager.MilitaryAssistantData militaryAssistantData = _militaryAssistantDatas[index];
		militaryAssistantData = new GameLocalDataManager.MilitaryAssistantData
		{
			ActivityId = militaryAssistantData.ActivityId,
			ActivityMark = militaryAssistantData.ActivityMark,
			ChallengePlan = militaryAssistantData.ChallengePlan,
			ChallengeCnt = militaryAssistantData.ChallengeCnt,
			Status = GameLocalDataManager.MilitaryAssistantStatus.Preparing
		};
		if (uI_com_LevelOption.stateController.selectedIndex == 0)
		{
			militaryAssistantData.LevelIndex = Convert.ToInt32(((GObject)uI_com_LevelOption).data);
			militaryAssistantData.LevelDesc = ((GObject)uI_com_LevelOption.levelName).text;
		}
		_militaryAssistantDatas[index] = militaryAssistantData;
		GameLocalDataManager.SetMilitaryAssistantData(militaryAssistantData);
		ToggleLevelSelector(uI_com_LevelSelector);
		RenderLevelSelector(index, (GObject)(object)uI_com_LevelSelector);
	}

	private void RenderOffensiveDungeonLevelOption(UI_com_LevelOptionsList levelOptionsList, Activity activity, GameLocalDataManager.MilitaryAssistantData assistantData)
	{
		//IL_00e4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ee: Expected O, but got Unknown
		levelOptionsList.LevelOptions.numItems = 0;
		levelOptionsList.LevelOptions.RemoveChildrenToPool();
		for (int i = 0; i < 5; i++)
		{
			UI_com_LevelOption uI_com_LevelOption = levelOptionsList.LevelOptions.AddItemFromPool() as UI_com_LevelOption;
			uI_com_LevelOption.typeController.selectedIndex = 2;
			int num = i + 1;
			if (assistantData.LevelDifficulty == num)
			{
				uI_com_LevelOption.stateController.selectedIndex = 1;
			}
			else
			{
				uI_com_LevelOption.stateController.selectedIndex = 0;
			}
			for (int j = 0; j < num; j++)
			{
				((UI_com_star)(object)((GComponent)uI_com_LevelOption.stars).GetChildAt(j)).active.selectedIndex = 1;
			}
			((GObject)uI_com_LevelOption.levelNameForDifficulty).text = string.Format(LanguagesManager.GetDesc("LevelNameForDifficultyStars"), num);
			((GObject)uI_com_LevelOption).data = num;
			((GObject)uI_com_LevelOption).onClick.Add(new EventCallback1(ChooseOffensiveDungeonLevel));
		}
		UI_com_LevelOptionTip uI_com_LevelOptionTip = levelOptionsList.LevelOptions.AddItemFromPool("ui://8x5gc8j2ihxkv4v2") as UI_com_LevelOptionTip;
		((GObject)uI_com_LevelOptionTip.tipContent).text = LanguagesManager.GetDesc("TipsMilitaryAFKAssistantChooseLevel_OffensiveDungeon");
		StopClickEventPropagation((GComponent)(object)uI_com_LevelOptionTip);
	}

	private void ChooseOffensiveDungeonLevel(EventContext eventContext)
	{
		UI_com_LevelOption uI_com_LevelOption = eventContext.sender as UI_com_LevelOption;
		UI_com_LevelSelector uI_com_LevelSelector = ((GObject)((GObject)((GObject)uI_com_LevelOption).parent).parent).parent as UI_com_LevelSelector;
		int index = Convert.ToInt32(((GObject)uI_com_LevelSelector).data);
		GameLocalDataManager.MilitaryAssistantData militaryAssistantData = _militaryAssistantDatas[index];
		militaryAssistantData = new GameLocalDataManager.MilitaryAssistantData
		{
			ActivityId = militaryAssistantData.ActivityId,
			ActivityMark = militaryAssistantData.ActivityMark,
			ChallengePlan = militaryAssistantData.ChallengePlan,
			ChallengeCnt = militaryAssistantData.ChallengeCnt,
			Status = GameLocalDataManager.MilitaryAssistantStatus.Preparing
		};
		if (uI_com_LevelOption.stateController.selectedIndex == 0)
		{
			militaryAssistantData.LevelDifficulty = Convert.ToInt32(((GObject)uI_com_LevelOption).data);
			militaryAssistantData.LevelDesc = ((GObject)uI_com_LevelOption.levelName).text;
		}
		_militaryAssistantDatas[index] = militaryAssistantData;
		GameLocalDataManager.SetMilitaryAssistantData(militaryAssistantData);
		ToggleLevelSelector(uI_com_LevelSelector);
		RenderLevelSelector(index, (GObject)(object)uI_com_LevelSelector);
	}

	private void RenderLegendItemDungeonLevelOption(UI_com_LevelOptionsList levelOptionsList, Activity activity, GameLocalDataManager.MilitaryAssistantData assistantData)
	{
		//IL_0181: Unknown result type (might be due to invalid IL or missing references)
		//IL_018b: Expected O, but got Unknown
		levelOptionsList.LevelOptions.numItems = 0;
		levelOptionsList.LevelOptions.RemoveChildrenToPool();
		List<string> list = activity.UnlockedContent(GameManagers.Instance);
		List<ActivityContentPayload> list2 = activity.ContentPayload(GameManagers.Instance).Values.ToList();
		for (int i = 0; i < list2.Count; i++)
		{
			TreasureHuntChapterActivityPayload treasureHuntChapterActivityPayload = list2[i] as TreasureHuntChapterActivityPayload;
			if (treasureHuntChapterActivityPayload.Type == "Boss")
			{
				continue;
			}
			List<int> list3 = new List<int>();
			int lastLegendExplorationIndex = GameLocalDataManager.GetLastLegendExplorationIndex();
			foreach (string level_ID in treasureHuntChapterActivityPayload.Level_IDs)
			{
				GDELevelData gDELevelData = GDMgr.Get<GDELevelData>(level_ID);
				if (!list3.Contains(gDELevelData.Difficult))
				{
					list3.Add(gDELevelData.Difficult);
					UI_com_LevelOption uI_com_LevelOption = levelOptionsList.LevelOptions.AddItemFromPool() as UI_com_LevelOption;
					uI_com_LevelOption.typeController.selectedIndex = 3;
					if (assistantData.LevelDifficulty == gDELevelData.Difficult)
					{
						uI_com_LevelOption.stateController.selectedIndex = 1;
					}
					else if (LegendItemDungeonUiHelper.MaxDifficult < gDELevelData.Difficult)
					{
						uI_com_LevelOption.stateController.selectedIndex = 2;
					}
					else
					{
						uI_com_LevelOption.stateController.selectedIndex = 0;
					}
					((GObject)uI_com_LevelOption.levelName).text = gDELevelData.Name;
					((GObject)uI_com_LevelOption).data = gDELevelData.Difficult;
					((GObject)uI_com_LevelOption).onClick.Add(new EventCallback1(ChooseLegendItemDungeonLevel));
				}
			}
		}
		UI_com_LevelOptionTip uI_com_LevelOptionTip = levelOptionsList.LevelOptions.AddItemFromPool("ui://8x5gc8j2ihxkv4v2") as UI_com_LevelOptionTip;
		((GObject)uI_com_LevelOptionTip.tipContent).text = LanguagesManager.GetDesc("TipsMilitaryAFKAssistantChooseLevel_LegendItemDungeon");
		StopClickEventPropagation((GComponent)(object)uI_com_LevelOptionTip);
		bool flag = !GameLocalDataManager.GetLastLegendExplorationSoldiers().Any((string _soldierId) => GameManagers.Instance.StockController.GetStock(_soldierId) > 0);
		levelOptionsList.enabled.selectedIndex = (flag ? 1 : 0);
		if (flag)
		{
			((GObject)levelOptionsList.disableTips).y = 300f;
			((GObject)levelOptionsList.disableTips).text = LanguagesManager.GetDesc("TipsNeedDeploySoldiersFirst");
		}
	}

	private void ConfirmLegendItemDungeonPlayingIntro(GameLocalDataManager.MilitaryAssistantData assistantData, UI_com_LevelOption chosenLevel)
	{
		UI_com_LevelSelector levelSelector = ((GObject)((GObject)((GObject)chosenLevel).parent).parent).parent as UI_com_LevelSelector;
		int selectorIndex = Convert.ToInt32(((GObject)levelSelector).data);
		int legendItemDungeonPlayingIntroDontShowAgainUntil = GameLocalDataManager.GetLegendItemDungeonPlayingIntroDontShowAgainUntil();
		if (DateTimeHelper.GetTimeStamp(DateTimeHelper.ServerNow) >= legendItemDungeonPlayingIntroDontShowAgainUntil)
		{
			GameController.Contexts.Service<IUiService>().OpenPanel(UI_ConfirmPopupDontShowAgain.Name, new Dictionary<string, object>
			{
				{ "TipKey", "TipKey_LegendItemDungeonPlayingIntroDontShowAgain" },
				{
					"TipValue",
					DateTimeHelper.GetTimeStamp(DateTimeHelper.GetWeeklyRefreshTime(DateTimeHelper.ServerNow, DateTimeHelper.TimezoneOffset, DateTimeHelper.RefreshHours).AddDays(7.0))
				},
				{
					"TipContent",
					LanguagesManager.GetDesc("TipsDontShowUntilNextWeek")
				},
				{
					"Content",
					LanguagesManager.GetDesc("TipsLegendItemDungeonPlayingIntro")
				},
				{
					"Buttons",
					new Dictionary<string, Action>
					{
						{
							"Confirm",
							delegate
							{
								assistantData.LevelDifficulty = Convert.ToInt32(((GObject)chosenLevel).data);
								assistantData.LevelDesc = ((GObject)chosenLevel.levelName).text;
								GameLocalDataManager.SetMilitaryAssistantData(assistantData);
								_militaryAssistantDatas[selectorIndex] = assistantData;
								ToggleLevelSelector(levelSelector);
								RenderLevelSelector(selectorIndex, (GObject)(object)levelSelector);
							}
						},
						{
							"Cancel",
							delegate
							{
							}
						}
					}
				},
				{ "ClickSound", "Confirm" }
			});
		}
		else
		{
			assistantData.LevelDifficulty = Convert.ToInt32(((GObject)chosenLevel).data);
			assistantData.LevelDesc = ((GObject)chosenLevel.levelName).text;
			GameLocalDataManager.SetMilitaryAssistantData(assistantData);
			_militaryAssistantDatas[selectorIndex] = assistantData;
			ToggleLevelSelector(levelSelector);
			RenderLevelSelector(selectorIndex, (GObject)(object)levelSelector);
		}
	}

	private void ChooseLegendItemDungeonLevel(EventContext eventContext)
	{
		UI_com_LevelOption uI_com_LevelOption = eventContext.sender as UI_com_LevelOption;
		UI_com_LevelOptionsList uI_com_LevelOptionsList = ((GObject)((GObject)uI_com_LevelOption).parent).parent as UI_com_LevelOptionsList;
		UI_com_LevelSelector uI_com_LevelSelector = ((GObject)uI_com_LevelOptionsList).parent as UI_com_LevelSelector;
		int index = Convert.ToInt32(((GObject)uI_com_LevelSelector).data);
		if (uI_com_LevelOptionsList.enabled.selectedIndex == 1)
		{
			((GComponent)AssistantPanel.LevelSelecters).scrollPane.ScrollToView((GObject)(object)uI_com_LevelSelector, true);
			List<string> arg = new List<string> { string.Format(LanguagesManager.GetDesc("TipsNeedDeploySoldiersFirst"), ((GObject)uI_com_LevelOption.levelName).text) };
			SharedMessenger.Broadcast("SHOW_TIPS", arg, 1, arg3: false);
			return;
		}
		if (uI_com_LevelOption.stateController.selectedIndex == 2)
		{
			eventContext.StopPropagation();
			List<string> arg2 = new List<string> { string.Format(LanguagesManager.GetDesc("TipsLevelNotUnlockedYet_LegendItemDungeon"), ((GObject)uI_com_LevelOption.levelName).text) };
			SharedMessenger.Broadcast("SHOW_TIPS", arg2, 1, arg3: false);
			return;
		}
		GameLocalDataManager.MilitaryAssistantData militaryAssistantData = _militaryAssistantDatas[index];
		militaryAssistantData = new GameLocalDataManager.MilitaryAssistantData
		{
			ActivityId = militaryAssistantData.ActivityId,
			ActivityMark = militaryAssistantData.ActivityMark,
			ChallengePlan = militaryAssistantData.ChallengePlan,
			ChallengeCnt = militaryAssistantData.ChallengeCnt,
			Status = GameLocalDataManager.MilitaryAssistantStatus.Preparing
		};
		if (uI_com_LevelOption.stateController.selectedIndex == 0)
		{
			ConfirmLegendItemDungeonPlayingIntro(militaryAssistantData, uI_com_LevelOption);
			return;
		}
		GameLocalDataManager.SetMilitaryAssistantData(militaryAssistantData);
		_militaryAssistantDatas[index] = militaryAssistantData;
		ToggleLevelSelector(uI_com_LevelSelector);
		RenderLevelSelector(index, (GObject)(object)uI_com_LevelSelector);
	}

	private void RenderNeutralDungeonLevelOption(UI_com_LevelOptionsList levelOptionsList, Activity activity, GameLocalDataManager.MilitaryAssistantData assistantData)
	{
		//IL_0119: Unknown result type (might be due to invalid IL or missing references)
		//IL_0123: Expected O, but got Unknown
		levelOptionsList.LevelOptions.numItems = 0;
		levelOptionsList.LevelOptions.RemoveChildrenToPool();
		List<string> list = activity.UnlockedContent(GameManagers.Instance);
		foreach (ActivityContentPayload value in activity.ContentPayload(GameManagers.Instance).Values)
		{
			ChapterActivityPayload chapterActivityPayload = (ChapterActivityPayload)value;
			Level level = chapterActivityPayload.Levels(GameManagers.Instance)[0];
			UI_com_LevelOption uI_com_LevelOption = levelOptionsList.LevelOptions.AddItemFromPool() as UI_com_LevelOption;
			uI_com_LevelOption.typeController.selectedIndex = 4;
			if (assistantData.LevelId == level.LevelId)
			{
				uI_com_LevelOption.stateController.selectedIndex = 1;
			}
			else if (!list.Contains(chapterActivityPayload.ChapterId))
			{
				uI_com_LevelOption.stateController.selectedIndex = 2;
			}
			else
			{
				uI_com_LevelOption.stateController.selectedIndex = 0;
			}
			((GObject)uI_com_LevelOption.levelName).text = level.Name;
			((GObject)uI_com_LevelOption).data = level.LevelId;
			((GObject)uI_com_LevelOption).onClick.Add(new EventCallback1(ChooseNeutralDungeonLevel));
		}
		UI_com_LevelOptionTip uI_com_LevelOptionTip = levelOptionsList.LevelOptions.AddItemFromPool("ui://8x5gc8j2ihxkv4v2") as UI_com_LevelOptionTip;
		((GObject)uI_com_LevelOptionTip.tipContent).text = LanguagesManager.GetDesc("TipsMilitaryAFKAssistantChooseLevel_NeutralDungeon");
		StopClickEventPropagation((GComponent)(object)uI_com_LevelOptionTip);
	}

	private void ChooseNeutralDungeonLevel(EventContext eventContext)
	{
		UI_com_LevelOption uI_com_LevelOption = eventContext.sender as UI_com_LevelOption;
		UI_com_LevelSelector uI_com_LevelSelector = ((GObject)((GObject)((GObject)uI_com_LevelOption).parent).parent).parent as UI_com_LevelSelector;
		int index = Convert.ToInt32(((GObject)uI_com_LevelSelector).data);
		if (uI_com_LevelOption.stateController.selectedIndex == 2)
		{
			eventContext.StopPropagation();
			List<string> arg = new List<string> { string.Format(LanguagesManager.GetDesc("TipsLevelNotUnlockedYet_NeutralDungeon"), ((GObject)uI_com_LevelOption.levelName).text) };
			SharedMessenger.Broadcast("SHOW_TIPS", arg, 1, arg3: false);
			return;
		}
		GameLocalDataManager.MilitaryAssistantData militaryAssistantData = _militaryAssistantDatas[index];
		militaryAssistantData = new GameLocalDataManager.MilitaryAssistantData
		{
			ActivityId = militaryAssistantData.ActivityId,
			ActivityMark = militaryAssistantData.ActivityMark,
			ChallengePlan = militaryAssistantData.ChallengePlan,
			ChallengeCnt = militaryAssistantData.ChallengeCnt,
			Status = GameLocalDataManager.MilitaryAssistantStatus.Preparing
		};
		if (uI_com_LevelOption.stateController.selectedIndex == 0)
		{
			militaryAssistantData.LevelId = ((GObject)uI_com_LevelOption).data.ToString();
			militaryAssistantData.LevelDesc = ((GObject)uI_com_LevelOption.levelName).text;
		}
		GameLocalDataManager.SetMilitaryAssistantData(militaryAssistantData);
		_militaryAssistantDatas[index] = militaryAssistantData;
		ToggleLevelSelector(uI_com_LevelSelector);
		RenderLevelSelector(index, (GObject)(object)uI_com_LevelSelector);
	}

	private void OnClickMask()
	{
		if (onGoing.selectedIndex == 0 && ClickSimulatorHelper.HasUiShownOnTop(UI_MilitaryIntelligencePanel.Name))
		{
			resultTips = null;
			End();
		}
		else if (showEditor.selectedIndex == 1)
		{
			showEditor.selectedIndex = 0;
		}
	}

	private void OnClickSpineWrapper()
	{
		if (onGoing.selectedIndex == 1 && showEditor.selectedIndex == 0)
		{
			showEditor.selectedIndex = 1;
		}
	}

	private void OnClickStart(EventContext eventContext)
	{
		if (_militaryAssistantDatas.All((GameLocalDataManager.MilitaryAssistantData cacheData) => cacheData == null || (string.IsNullOrEmpty(cacheData.LevelId) && cacheData.LevelIndex == -1 && cacheData.LevelDifficulty == -1)))
		{
			SharedMessenger.Broadcast("SHOW_TIPS", new List<string> { LanguagesManager.GetDesc("TipsNoMilitaryAssistantData") }, 1, arg3: false);
		}
		else
		{
			if (onGoing.selectedIndex != 0)
			{
				return;
			}
			int militaryAssistantRunningTipsDontShowAgainUntil = GameLocalDataManager.GetMilitaryAssistantRunningTipsDontShowAgainUntil();
			if (DateTimeHelper.GetTimeStamp(DateTimeHelper.ServerNow) >= militaryAssistantRunningTipsDontShowAgainUntil)
			{
				GameController.Contexts.Service<IUiService>().OpenPanel(UI_ConfirmPopupDontShowAgain.Name, new Dictionary<string, object>
				{
					{ "TipKey", "TipKey_MilitaryAssistantRunningTipsDontShowAgain" },
					{
						"TipValue",
						DateTimeHelper.GetTimeStamp(DateTimeHelper.GetWeeklyRefreshTime(DateTimeHelper.ServerNow, DateTimeHelper.TimezoneOffset, DateTimeHelper.RefreshHours).AddDays(7.0))
					},
					{
						"TipContent",
						LanguagesManager.GetDesc("TipsDontShowUntilNextWeek")
					},
					{
						"Content",
						LanguagesManager.GetDesc("TipsMilitaryAFKAssistantRunning")
					},
					{
						"Buttons",
						new Dictionary<string, Action>
						{
							{
								"Confirm",
								delegate
								{
									onGoing.selectedIndex = 1;
									showEditor.selectedIndex = 0;
									AssistantPanel.stateController.selectedIndex = 2;
									LoadSpine();
									RunSimulator();
								}
							},
							{
								"Cancel",
								delegate
								{
								}
							}
						}
					},
					{ "ClickSound", "Confirm" }
				});
			}
			else
			{
				onGoing.selectedIndex = 1;
				showEditor.selectedIndex = 0;
				AssistantPanel.stateController.selectedIndex = 2;
				LoadSpine();
				RunSimulator();
			}
		}
	}

	private void OnClickPause(EventContext eventContext)
	{
		if (AssistantPanel.stateController.selectedIndex == 2)
		{
			AssistantPanel.stateController.selectedIndex = 1;
			resultTips = LanguagesManager.GetDesc("TipsMilitaryAFKAssistantStopManually");
			PauseSimulator();
		}
	}

	private void PauseSimulator()
	{
		if (ScriptCoroutine == null || CurrentRunningScript == null)
		{
			End();
			return;
		}
		((MonoBehaviour)FGUIManager.Instance).StopCoroutine(ScriptCoroutine);
		End();
	}

	private IEnumerator DelayCoroutine(float delayTime, IEnumerator enumerator)
	{
		yield return (object)new WaitForSeconds(delayTime);
		yield return enumerator;
	}

	private void RunSimulator(int offsetIndex = 0)
	{
		SentrySdk.AddBreadcrumb("[ClickSimulator]RunSimulator");
		if (ScriptCoroutine != null)
		{
			ILRuntimeDebug.LogError("[ClickSimulator]RunSimulator While ScriptCoroutine is not null, Force Stop Old One");
			((MonoBehaviour)FGUIManager.Instance).StopCoroutine(ScriptCoroutine);
		}
		ScriptCoroutine = null;
		CurrentRunningScript = null;
		for (int i = offsetIndex; i < _militaryAssistantDatas.Count; i++)
		{
			GameLocalDataManager.MilitaryAssistantData militaryAssistantData = _militaryAssistantDatas[i];
			if (militaryAssistantData == null || (string.IsNullOrEmpty(militaryAssistantData.LevelId) && militaryAssistantData.LevelIndex == -1 && militaryAssistantData.LevelDifficulty == -1))
			{
				continue;
			}
			Activity activity = ActivityManager.Activities[militaryAssistantData.ActivityId];
			ActivityStatus status = activity.GetStatus(GameManagers.Instance);
			if (status != ActivityStatus.Enabled)
			{
				continue;
			}
			int challengeCnt = militaryAssistantData.ChallengeCnt;
			int stock = GameManagers.Instance.StockController.GetStock(activity.TicketItem);
			bool flag = ((activity.Type != ActivityType.TreasureHunt) ? (stock > 0) : (challengeCnt > 0));
			if (!flag || challengeCnt < 1)
			{
				continue;
			}
			if (ClickSimulatorHelper.TryGetUiInstOnTop(UI_GameEndPanelVictory.Name, out var uiInst) && ((GObject)((UI_GameEndPanelVictory)(object)uiInst).againBtn).visible)
			{
				_RunSimulatorFromRestartStep(activity, militaryAssistantData);
			}
			else if (ClickSimulatorHelper.TryGetUiInstOnTop(UI_InstanceZonesPanel.Name, out uiInst))
			{
				UI_InstanceZonesPanel uI_InstanceZonesPanel = uiInst as UI_InstanceZonesPanel;
				if ((uI_InstanceZonesPanel.PageController.selectedIndex == 0 || uI_InstanceZonesPanel.PageController.selectedIndex == 4) && activity.Type != ActivityType.TimeLimitInstance)
				{
					Script_ThemeDungeonBackToMilitary currentStep = new Script_ThemeDungeonBackToMilitary(new ThemeDungeonLevelLocator());
					CurrentRunningScript = new ClickSimulatorScript
					{
						CurrentStep = currentStep
					};
				}
				else if (uI_InstanceZonesPanel.PageController.selectedIndex == 1 && activity.Type != ActivityType.DefenseInstance)
				{
					Script_DefenseDungeonBackToMilitary currentStep2 = new Script_DefenseDungeonBackToMilitary(new DefenseDungeonLevelLocator());
					CurrentRunningScript = new ClickSimulatorScript
					{
						CurrentStep = currentStep2
					};
				}
				else if (uI_InstanceZonesPanel.PageController.selectedIndex == 2 && activity.Type != ActivityType.AttackInstance)
				{
					Script_OffensiveDungeonBackToMilitary currentStep3 = new Script_OffensiveDungeonBackToMilitary(new OffensiveDungeonLevelLocator());
					CurrentRunningScript = new ClickSimulatorScript
					{
						CurrentStep = currentStep3
					};
				}
				else if (uI_InstanceZonesPanel.PageController.selectedIndex == 5 && activity.Type != ActivityType.NeutralDungeonInstance)
				{
					Script_NeutralDungeonBackToMilitary currentStep4 = new Script_NeutralDungeonBackToMilitary(new NeutralDungeonLevelLocator());
					CurrentRunningScript = new ClickSimulatorScript
					{
						CurrentStep = currentStep4
					};
				}
				else
				{
					_RunSimulatorFromChooseLevelStep(activity, militaryAssistantData);
				}
			}
			else if (ClickSimulatorHelper.HasUiShownOnTop(UI_LegendItemDungeonPanel.Name))
			{
				if (activity.Type == ActivityType.TreasureHunt)
				{
					_RunSimulatorFromChooseLevelStep(activity, militaryAssistantData);
				}
				else
				{
					Script_LegendItemDungeonBackToMilitary currentStep5 = new Script_LegendItemDungeonBackToMilitary(new LegendItemDungeonLevelLocator());
					CurrentRunningScript = new ClickSimulatorScript
					{
						CurrentStep = currentStep5
					};
				}
			}
			else
			{
				if (!ClickSimulatorHelper.HasUiShownOnTop(UI_MilitaryIntelligencePanel.Name))
				{
					if (!ClickSimulatorHelper.HasUiShownOnTop(UI_GameEndPanelFail.Name))
					{
						ILRuntimeDebug.LogError($"[ClickSimulator]RunSimulator Failed, Exceptional Situation, CurrentRunningScript is null ? {CurrentRunningScript == null}, Uis: {JsonHelper.ToJson(UnityUiService.Instance.DictUI.Keys.ToList())}, Stack:{Environment.StackTrace}");
					}
					break;
				}
				_RunSimulatorFromEnterDungeonPanelStep(activity, militaryAssistantData);
			}
			if (CurrentRunningScript != null)
			{
				break;
			}
		}
		if (CurrentRunningScript == null)
		{
			if (string.IsNullOrEmpty(resultTips))
			{
				resultTips = LanguagesManager.GetDesc("TipsMilitaryAFKAssistantPlayDone");
			}
			End();
		}
		else
		{
			ScriptCoroutine = ((MonoBehaviour)FGUIManager.Instance).StartCoroutine(CurrentRunningScript.Run());
		}
	}

	private void _RunSimulatorFromEnterDungeonPanelStep(Activity activity, GameLocalDataManager.MilitaryAssistantData assistantData)
	{
		switch (activity.Type)
		{
		case ActivityType.TimeLimitInstance:
		{
			Activity levelActivity = GameManagers.Instance.ActivityManager.GetLevelActivity(assistantData.LevelId);
			ThemeDungeonLevelLocator levelLocator5 = new ThemeDungeonLevelLocator
			{
				ActivityId = activity.ActivityId,
				LevelId = assistantData.LevelId,
				IsAdvanced = !string.IsNullOrEmpty(levelActivity.Parent),
				LevelDesc = assistantData.LevelDesc
			};
			Script_EnterThemeDungeonPanel currentStep5 = new Script_EnterThemeDungeonPanel(levelLocator5);
			CurrentRunningScript = new ThemeDungeonClickScript
			{
				Marker = activity.ActivityId,
				LevelLocator = levelLocator5,
				CurrentStep = currentStep5
			};
			break;
		}
		case ActivityType.DefenseInstance:
		{
			DefenseDungeonLevelLocator levelLocator4 = new DefenseDungeonLevelLocator
			{
				ActivityId = activity.ActivityId,
				LevelIndex = assistantData.LevelIndex,
				LevelDesc = assistantData.LevelDesc
			};
			Script_EnterDefenseDungeonPanel currentStep4 = new Script_EnterDefenseDungeonPanel(levelLocator4);
			CurrentRunningScript = new DefenseDungeonClickScript
			{
				Marker = activity.ActivityId,
				LevelLocator = levelLocator4,
				CurrentStep = currentStep4
			};
			break;
		}
		case ActivityType.AttackInstance:
		{
			OffensiveDungeonLevelLocator levelLocator3 = new OffensiveDungeonLevelLocator
			{
				ActivityId = activity.ActivityId,
				Difficulty = assistantData.LevelDifficulty,
				LevelDesc = assistantData.LevelDesc
			};
			Script_EnterOffensiveDungeonPanel currentStep3 = new Script_EnterOffensiveDungeonPanel(levelLocator3);
			CurrentRunningScript = new OffensiveDungeonClickScript
			{
				Marker = activity.ActivityId,
				LevelLocator = levelLocator3,
				CurrentStep = currentStep3
			};
			break;
		}
		case ActivityType.TreasureHunt:
		{
			LegendItemDungeonLevelLocator levelLocator2 = new LegendItemDungeonLevelLocator
			{
				ActivityId = activity.ActivityId,
				Difficulty = assistantData.LevelDifficulty,
				LevelDesc = assistantData.LevelDesc,
				FormationIndex = LegendItemDungeonUiHelper.CurFinishedLevelNum % 3
			};
			Script_EnterLegendItemDungeonPanel currentStep2 = new Script_EnterLegendItemDungeonPanel(levelLocator2);
			CurrentRunningScript = new LegendItemDungeonClickScript
			{
				Marker = activity.ActivityId,
				LevelLocator = levelLocator2,
				CurrentStep = currentStep2
			};
			break;
		}
		case ActivityType.NeutralDungeonInstance:
		{
			NeutralDungeonLevelLocator levelLocator = new NeutralDungeonLevelLocator
			{
				ActivityId = activity.ActivityId,
				LevelId = assistantData.LevelId,
				LevelDesc = assistantData.LevelDesc
			};
			Script_EnterNeutralDungeonPanel currentStep = new Script_EnterNeutralDungeonPanel(levelLocator);
			CurrentRunningScript = new NeutralDungeonClickScript
			{
				Marker = activity.ActivityId,
				LevelLocator = levelLocator,
				CurrentStep = currentStep
			};
			break;
		}
		}
	}

	private void _RunSimulatorFromChooseLevelStep(Activity activity, GameLocalDataManager.MilitaryAssistantData assistantData)
	{
		switch (activity.Type)
		{
		case ActivityType.TimeLimitInstance:
		{
			Activity levelActivity = GameManagers.Instance.ActivityManager.GetLevelActivity(assistantData.LevelId);
			ThemeDungeonLevelLocator levelLocator5 = new ThemeDungeonLevelLocator
			{
				ActivityId = activity.ActivityId,
				LevelId = assistantData.LevelId,
				IsAdvanced = !string.IsNullOrEmpty(levelActivity.Parent),
				LevelDesc = assistantData.LevelDesc
			};
			Script_ThemeDungeonChooseLevel currentStep5 = new Script_ThemeDungeonChooseLevel(levelLocator5);
			CurrentRunningScript = new ThemeDungeonClickScript
			{
				Marker = activity.ActivityId,
				LevelLocator = levelLocator5,
				CurrentStep = currentStep5
			};
			break;
		}
		case ActivityType.DefenseInstance:
		{
			DefenseDungeonLevelLocator levelLocator4 = new DefenseDungeonLevelLocator
			{
				ActivityId = activity.ActivityId,
				LevelIndex = assistantData.LevelIndex,
				LevelDesc = assistantData.LevelDesc
			};
			Script_DefenseDungeonChooseLevel currentStep4 = new Script_DefenseDungeonChooseLevel(levelLocator4);
			CurrentRunningScript = new DefenseDungeonClickScript
			{
				Marker = activity.ActivityId,
				LevelLocator = levelLocator4,
				CurrentStep = currentStep4
			};
			break;
		}
		case ActivityType.AttackInstance:
		{
			OffensiveDungeonLevelLocator levelLocator3 = new OffensiveDungeonLevelLocator
			{
				ActivityId = activity.ActivityId,
				Difficulty = assistantData.LevelDifficulty,
				LevelDesc = assistantData.LevelDesc
			};
			Script_OffensiveDungeonChooseLevel currentStep3 = new Script_OffensiveDungeonChooseLevel(levelLocator3);
			CurrentRunningScript = new OffensiveDungeonClickScript
			{
				Marker = activity.ActivityId,
				LevelLocator = levelLocator3,
				CurrentStep = currentStep3
			};
			break;
		}
		case ActivityType.TreasureHunt:
		{
			LegendItemDungeonLevelLocator levelLocator2 = new LegendItemDungeonLevelLocator
			{
				ActivityId = activity.ActivityId,
				Difficulty = assistantData.LevelDifficulty,
				LevelDesc = assistantData.LevelDesc,
				FormationIndex = LegendItemDungeonUiHelper.CurFinishedLevelNum % 3
			};
			Script_LegendItemDungeonChooseLevel currentStep2 = new Script_LegendItemDungeonChooseLevel(levelLocator2);
			CurrentRunningScript = new LegendItemDungeonClickScript
			{
				Marker = activity.ActivityId,
				LevelLocator = levelLocator2,
				CurrentStep = currentStep2
			};
			break;
		}
		case ActivityType.NeutralDungeonInstance:
		{
			NeutralDungeonLevelLocator levelLocator = new NeutralDungeonLevelLocator
			{
				ActivityId = activity.ActivityId,
				LevelId = assistantData.LevelId,
				LevelDesc = assistantData.LevelDesc
			};
			Script_NeutralDungeonChooseLevel currentStep = new Script_NeutralDungeonChooseLevel(levelLocator);
			CurrentRunningScript = new NeutralDungeonClickScript
			{
				Marker = activity.ActivityId,
				LevelLocator = levelLocator,
				CurrentStep = currentStep
			};
			break;
		}
		}
	}

	private void _RunSimulatorFromRestartStep(Activity activity, GameLocalDataManager.MilitaryAssistantData assistantData)
	{
		switch (activity.Type)
		{
		case ActivityType.TimeLimitInstance:
		{
			Activity levelActivity = GameManagers.Instance.ActivityManager.GetLevelActivity(assistantData.LevelId);
			ThemeDungeonLevelLocator levelLocator5 = new ThemeDungeonLevelLocator
			{
				ActivityId = activity.ActivityId,
				LevelId = assistantData.LevelId,
				IsAdvanced = !string.IsNullOrEmpty(levelActivity.Parent),
				LevelDesc = assistantData.LevelDesc
			};
			Script_ThemeDungeonRestartQuickBattle currentStep5 = new Script_ThemeDungeonRestartQuickBattle(levelLocator5);
			CurrentRunningScript = new ThemeDungeonClickScript
			{
				Marker = activity.ActivityId,
				LevelLocator = levelLocator5,
				CurrentStep = currentStep5
			};
			break;
		}
		case ActivityType.DefenseInstance:
		{
			DefenseDungeonLevelLocator levelLocator4 = new DefenseDungeonLevelLocator
			{
				ActivityId = activity.ActivityId,
				LevelIndex = assistantData.LevelIndex,
				LevelDesc = assistantData.LevelDesc
			};
			Script_DefenseDungeonRestartQuickBattle currentStep4 = new Script_DefenseDungeonRestartQuickBattle(levelLocator4);
			CurrentRunningScript = new DefenseDungeonClickScript
			{
				Marker = activity.ActivityId,
				LevelLocator = levelLocator4,
				CurrentStep = currentStep4
			};
			break;
		}
		case ActivityType.AttackInstance:
		{
			OffensiveDungeonLevelLocator levelLocator3 = new OffensiveDungeonLevelLocator
			{
				ActivityId = activity.ActivityId,
				Difficulty = assistantData.LevelDifficulty,
				LevelDesc = assistantData.LevelDesc
			};
			Script_OffensiveDungeonRestartQuickBattle currentStep3 = new Script_OffensiveDungeonRestartQuickBattle(levelLocator3);
			CurrentRunningScript = new OffensiveDungeonClickScript
			{
				Marker = activity.ActivityId,
				LevelLocator = levelLocator3,
				CurrentStep = currentStep3
			};
			break;
		}
		case ActivityType.TreasureHunt:
		{
			LegendItemDungeonLevelLocator levelLocator2 = new LegendItemDungeonLevelLocator
			{
				ActivityId = activity.ActivityId,
				Difficulty = assistantData.LevelDifficulty,
				LevelDesc = assistantData.LevelDesc,
				FormationIndex = LegendItemDungeonUiHelper.CurFinishedLevelNum % 3
			};
			Script_LegendItemDungeonRestartQuickBattle currentStep2 = new Script_LegendItemDungeonRestartQuickBattle(levelLocator2);
			CurrentRunningScript = new LegendItemDungeonClickScript
			{
				Marker = activity.ActivityId,
				LevelLocator = levelLocator2,
				CurrentStep = currentStep2
			};
			break;
		}
		case ActivityType.NeutralDungeonInstance:
		{
			NeutralDungeonLevelLocator levelLocator = new NeutralDungeonLevelLocator
			{
				ActivityId = activity.ActivityId,
				LevelId = assistantData.LevelId,
				LevelDesc = assistantData.LevelDesc
			};
			Script_NeutralDungeonRestartQuickBattle currentStep = new Script_NeutralDungeonRestartQuickBattle(levelLocator);
			CurrentRunningScript = new NeutralDungeonClickScript
			{
				Marker = activity.ActivityId,
				LevelLocator = levelLocator,
				CurrentStep = currentStep
			};
			break;
		}
		}
	}

	private void OnSimulatorAborted(string errMsg)
	{
		SharedMessenger.Broadcast("SHOW_TIPS", new List<string> { errMsg }, 1, arg3: false);
		showEditor.selectedIndex = 1;
		if (AssistantPanel.stateController.selectedIndex == 2)
		{
			AssistantPanel.stateController.selectedIndex = 1;
			resultTips = errMsg;
			PauseSimulator();
		}
	}

	private void OnOnceChallenge(string activityId)
	{
		for (int i = 0; i < _militaryAssistantDatas.Count; i++)
		{
			GameLocalDataManager.MilitaryAssistantData militaryAssistantData = _militaryAssistantDatas[i];
			if (militaryAssistantData.ActivityId == activityId)
			{
				militaryAssistantData.ChallengeCnt--;
				if (militaryAssistantData.ChallengeCnt <= 0)
				{
					militaryAssistantData.Status = GameLocalDataManager.MilitaryAssistantStatus.Done;
				}
				GameLocalDataManager.SetMilitaryAssistantData(militaryAssistantData);
				RenderLevelSelector(i, ((GComponent)AssistantPanel.LevelSelecters).GetChildAt(i));
				break;
			}
		}
	}

	private void OnScriptOnceFinish(string activityId)
	{
		int offsetIndex = 0;
		if (!string.IsNullOrEmpty(activityId))
		{
			for (int i = 0; i < _activities.Count; i++)
			{
				if (_activities[i].ActivityId == activityId)
				{
					offsetIndex = i;
					break;
				}
			}
		}
		ScriptCoroutine = null;
		CurrentRunningScript = null;
		if (onGoing.selectedIndex == 1)
		{
			RunSimulator(offsetIndex);
		}
	}

	private void PopupResultDialog(string content)
	{
		UnityUiService.Instance.OpenPanel(UI_UniversalConfirmPopup.Name, new Dictionary<string, object>
		{
			{ "Content", content },
			{
				"Buttons",
				new Dictionary<string, Action> { 
				{
					"Confirm",
					delegate
					{
					}
				} }
			},
			{ "PageIndex", 4 },
			{ "ClickSound", "Confirm" }
		}, multiMode: false, ignoreQueue: true);
	}

	public void End()
	{
		ScriptCoroutine = null;
		CurrentRunningScript = null;
		onGoing.selectedIndex = 0;
		showEditor.selectedIndex = 1;
		AssistantPanel.stateController.selectedIndex = 0;
		if (!string.IsNullOrEmpty(resultTips))
		{
			PopupResultDialog(resultTips);
		}
		GameController.Contexts.Service<IUiService>().ClosePanel(Name);
	}

	public void LoadSpine()
	{
		string model = "GoblinPlayGame";
		SpawnManager.Instance.LoadAnimation(model).Then((Action<SkeletonDataAsset>)delegate(SkeletonDataAsset asset)
		{
			if (!((GObject)this).isDisposed)
			{
				((SkeletonRenderer)goblinPlayingGameAnimation).skeletonDataAsset = asset;
				((SkeletonRenderer)goblinPlayingGameAnimation).Initialize(true);
				SpineHelper.SetSkin((ISkeletonAnimation)(object)goblinPlayingGameAnimation, "skin1");
				goblinPlayingGameAnimation.AnimationState.AddAnimation(0, "appear", false, 0f);
				goblinPlayingGameAnimation.AnimationState.AddAnimation(0, "idle", true, 0f);
				goblinPlayingGameAnimation.timeScale = 1f;
				goblinPlayingGameAnimation.loop = true;
			}
		}).Catch((Action<Exception>)delegate(Exception e)
		{
			ILRuntimeDebug.LogError(e.Message);
		});
	}

	private void StopClickEventPropagation(GComponent gComponent)
	{
		//IL_001b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0020: Unknown result type (might be due to invalid IL or missing references)
		//IL_0026: Expected O, but got Unknown
		EventListener onClick = ((GObject)gComponent).onClick;
		object obj = _003C_003Ec._003C_003E9__60_0;
		if (obj == null)
		{
			EventCallback1 val = delegate(EventContext e)
			{
				e.StopPropagation();
			};
			_003C_003Ec._003C_003E9__60_0 = val;
			obj = (object)val;
		}
		onClick.Add((EventCallback1)obj);
	}

	public void BeforeDestroy()
	{
	}

	public void Destroy()
	{
	}
}
