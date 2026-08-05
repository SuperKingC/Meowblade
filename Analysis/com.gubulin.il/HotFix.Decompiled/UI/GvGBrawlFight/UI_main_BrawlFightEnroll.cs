using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;
using HotFix;
using HotFix.Sources.Base.Sources.Scripts.GvG3.GvG3UI.Model.BrawlUi;
using HotFix.Sources.Base.Sources.Scripts.GvG3UI.Manager;
using HotFix.Sources.Base.Sources.Scripts.GvG3WorldMap.Helper;
using HotFix.Sources.Base.Sources.Scripts.GvG3WorldMap.Manager;
using Shift.Legion.Common.Helpers;
using Shift.Legion.Common.Managers;
using Shift.Legion.GvG.Common.Models.GvGMode3.BrawlEvent;
using Shift.Legion.GvGServer.Models.GvGMode3IslandManagerSocket.Mission;
using UnityEngine;

namespace UI.GvGBrawlFight;

public class UI_main_BrawlFightEnroll : GComponent, IUiController
{
	public Controller Type;

	public Controller StepType;

	public GLoader background;

	public GLoader n16;

	public UI_dec_01 n35;

	public UI_dec_02 n38;

	public UI_dec_portal_01 n44;

	public UI_dec_portal_02 n45;

	public GGraph vfxWrapper01;

	public GGraph vfxWrapper02;

	public GImage n24;

	public GImage n22;

	public GLoader n23;

	public GGroup n40;

	public GTextField n7;

	public GTextField n25;

	public GTextField n26;

	public GTextField n27;

	public GTextField n28;

	public GGroup n39;

	public GTextField n8;

	public GTextField n29;

	public GTextField n30;

	public GTextField nextOpenTime;

	public GTextField battleStartTime;

	public GTextField battleEndTime;

	public GButton goEnrollBtn;

	public GButton adjustEnrollBtn;

	public GButton viewEnrollBtn;

	public GButton viewBattleBtn;

	public GImage note;

	public GGroup n41;

	public UI_btn_BattleRecord battleRecordBtn;

	public UI_btn_01 replayBtn;

	public UI_btn_02 ruleBtn;

	public GGroup n43;

	public UI_com_EnrollStatus enrollStatus;

	public GButton BackBtn;

	public UI_com_Title Title;

	public GImage n49;

	public Transition t0;

	public Transition EnterSelectIsland;

	public const string URL = "ui://hozu168rnt900";

	public static string Name = "UI_main_BrawlFightEnroll";

	public const string GVG_BRAWL_EVENT_INFO = "GVG_BRAWL_EVENT_INFO";

	private C2S_BrawlEvent_GetInfo.Response _brawlEventInfo;

	private GvGMode3BrawlEvent_BaseInfo _config;

	private readonly BrawlRecordEntrance _recordEntrance = new BrawlRecordEntrance();

	private bool _needPopupBattleResult;

	private const string BrawlIslandStateKey = "BrawlIslandStateKey";

	public static string GetURL()
	{
		return "ui://hozu168rnt900";
	}

	public static UI_main_BrawlFightEnroll CreateInstance()
	{
		return (UI_main_BrawlFightEnroll)(object)UIPackage.CreateObject("GvGBrawlFight", "main_BrawlFightEnroll");
	}

	public static UI_main_BrawlFightEnroll CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_main_BrawlFightEnroll).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://hozu168rnt900", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0037: Unknown result type (might be due to invalid IL or missing references)
		//IL_0041: Expected O, but got Unknown
		//IL_004d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0057: Expected O, but got Unknown
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
		//IL_0192: Unknown result type (might be due to invalid IL or missing references)
		//IL_019c: Expected O, but got Unknown
		//IL_01e5: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ef: Expected O, but got Unknown
		//IL_0238: Unknown result type (might be due to invalid IL or missing references)
		//IL_0242: Expected O, but got Unknown
		//IL_028b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0295: Expected O, but got Unknown
		//IL_02e0: Unknown result type (might be due to invalid IL or missing references)
		//IL_02ea: Expected O, but got Unknown
		//IL_02f6: Unknown result type (might be due to invalid IL or missing references)
		//IL_0300: Expected O, but got Unknown
		//IL_034b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0355: Expected O, but got Unknown
		//IL_03a0: Unknown result type (might be due to invalid IL or missing references)
		//IL_03aa: Expected O, but got Unknown
		//IL_03f5: Unknown result type (might be due to invalid IL or missing references)
		//IL_03ff: Expected O, but got Unknown
		//IL_044a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0454: Expected O, but got Unknown
		//IL_049f: Unknown result type (might be due to invalid IL or missing references)
		//IL_04a9: Expected O, but got Unknown
		//IL_04f4: Unknown result type (might be due to invalid IL or missing references)
		//IL_04fe: Expected O, but got Unknown
		//IL_050a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0514: Expected O, but got Unknown
		//IL_0520: Unknown result type (might be due to invalid IL or missing references)
		//IL_052a: Expected O, but got Unknown
		//IL_0536: Unknown result type (might be due to invalid IL or missing references)
		//IL_0540: Expected O, but got Unknown
		//IL_054c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0556: Expected O, but got Unknown
		//IL_0562: Unknown result type (might be due to invalid IL or missing references)
		//IL_056c: Expected O, but got Unknown
		//IL_05ba: Unknown result type (might be due to invalid IL or missing references)
		//IL_05c4: Expected O, but got Unknown
		//IL_05e6: Unknown result type (might be due to invalid IL or missing references)
		//IL_05f0: Expected O, but got Unknown
		//IL_0612: Unknown result type (might be due to invalid IL or missing references)
		//IL_061c: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		Type = ((GComponent)this).GetController("Type");
		StepType = ((GComponent)this).GetController("StepType");
		background = (GLoader)((GComponent)this).GetChild("background");
		n16 = (GLoader)((GComponent)this).GetChild("n16");
		n35 = (UI_dec_01)(object)((GComponent)this).GetChild("n35");
		n38 = (UI_dec_02)(object)((GComponent)this).GetChild("n38");
		n44 = (UI_dec_portal_01)(object)((GComponent)this).GetChild("n44");
		n45 = (UI_dec_portal_02)(object)((GComponent)this).GetChild("n45");
		vfxWrapper01 = (GGraph)((GComponent)this).GetChild("vfxWrapper01");
		vfxWrapper02 = (GGraph)((GComponent)this).GetChild("vfxWrapper02");
		n24 = (GImage)((GComponent)this).GetChild("n24");
		n22 = (GImage)((GComponent)this).GetChild("n22");
		n23 = (GLoader)((GComponent)this).GetChild("n23");
		n40 = (GGroup)((GComponent)this).GetChild("n40");
		n7 = (GTextField)((GComponent)this).GetChild("n7");
		string id = "ui://hozu168rnt900".Replace("ui://", "") + "-" + ((GObject)n7).id;
		((GObject)n7).text = LanguagesManager.GetDesc(id);
		n25 = (GTextField)((GComponent)this).GetChild("n25");
		string id2 = "ui://hozu168rnt900".Replace("ui://", "") + "-" + ((GObject)n25).id;
		((GObject)n25).text = LanguagesManager.GetDesc(id2);
		n26 = (GTextField)((GComponent)this).GetChild("n26");
		string id3 = "ui://hozu168rnt900".Replace("ui://", "") + "-" + ((GObject)n26).id;
		((GObject)n26).text = LanguagesManager.GetDesc(id3);
		n27 = (GTextField)((GComponent)this).GetChild("n27");
		string id4 = "ui://hozu168rnt900".Replace("ui://", "") + "-" + ((GObject)n27).id;
		((GObject)n27).text = LanguagesManager.GetDesc(id4);
		n28 = (GTextField)((GComponent)this).GetChild("n28");
		string id5 = "ui://hozu168rnt900".Replace("ui://", "") + "-" + ((GObject)n28).id;
		((GObject)n28).text = LanguagesManager.GetDesc(id5);
		n39 = (GGroup)((GComponent)this).GetChild("n39");
		n8 = (GTextField)((GComponent)this).GetChild("n8");
		string id6 = "ui://hozu168rnt900".Replace("ui://", "") + "-" + ((GObject)n8).id;
		((GObject)n8).text = LanguagesManager.GetDesc(id6);
		n29 = (GTextField)((GComponent)this).GetChild("n29");
		string id7 = "ui://hozu168rnt900".Replace("ui://", "") + "-" + ((GObject)n29).id;
		((GObject)n29).text = LanguagesManager.GetDesc(id7);
		n30 = (GTextField)((GComponent)this).GetChild("n30");
		string id8 = "ui://hozu168rnt900".Replace("ui://", "") + "-" + ((GObject)n30).id;
		((GObject)n30).text = LanguagesManager.GetDesc(id8);
		nextOpenTime = (GTextField)((GComponent)this).GetChild("nextOpenTime");
		string id9 = "ui://hozu168rnt900".Replace("ui://", "") + "-" + ((GObject)nextOpenTime).id;
		((GObject)nextOpenTime).text = LanguagesManager.GetDesc(id9);
		battleStartTime = (GTextField)((GComponent)this).GetChild("battleStartTime");
		string id10 = "ui://hozu168rnt900".Replace("ui://", "") + "-" + ((GObject)battleStartTime).id;
		((GObject)battleStartTime).text = LanguagesManager.GetDesc(id10);
		battleEndTime = (GTextField)((GComponent)this).GetChild("battleEndTime");
		string id11 = "ui://hozu168rnt900".Replace("ui://", "") + "-" + ((GObject)battleEndTime).id;
		((GObject)battleEndTime).text = LanguagesManager.GetDesc(id11);
		goEnrollBtn = (GButton)((GComponent)this).GetChild("goEnrollBtn");
		adjustEnrollBtn = (GButton)((GComponent)this).GetChild("adjustEnrollBtn");
		viewEnrollBtn = (GButton)((GComponent)this).GetChild("viewEnrollBtn");
		viewBattleBtn = (GButton)((GComponent)this).GetChild("viewBattleBtn");
		note = (GImage)((GComponent)this).GetChild("note");
		n41 = (GGroup)((GComponent)this).GetChild("n41");
		battleRecordBtn = (UI_btn_BattleRecord)(object)((GComponent)this).GetChild("battleRecordBtn");
		replayBtn = (UI_btn_01)(object)((GComponent)this).GetChild("replayBtn");
		ruleBtn = (UI_btn_02)(object)((GComponent)this).GetChild("ruleBtn");
		n43 = (GGroup)((GComponent)this).GetChild("n43");
		enrollStatus = (UI_com_EnrollStatus)(object)((GComponent)this).GetChild("enrollStatus");
		BackBtn = (GButton)((GComponent)this).GetChild("BackBtn");
		Title = (UI_com_Title)(object)((GComponent)this).GetChild("Title");
		n49 = (GImage)((GComponent)this).GetChild("n49");
		t0 = ((GComponent)this).GetTransition("t0");
		EnterSelectIsland = ((GComponent)this).GetTransition("EnterSelectIsland");
	}

	public void RegisterUiEventListeners()
	{
		SharedMessenger.AddListener<string>("CLOSE_UI", OnUiClose);
		RegisterUiBtnEvent();
		S2C_BrawlEvent_TodayAllowSignUp.OnPushEvent = (Action<S2C_BrawlEvent_TodayAllowSignUp.Request>)Delegate.Combine(S2C_BrawlEvent_TodayAllowSignUp.OnPushEvent, new Action<S2C_BrawlEvent_TodayAllowSignUp.Request>(OnTodayAllowSignUp));
		GvGMode3RoomManager instance = Singleton<GvGMode3RoomManager>.Instance;
		instance.OnRoomClose = (Action)Delegate.Combine(instance.OnRoomClose, new Action(End));
	}

	private void RegisterUiBtnEvent()
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
		((GObject)BackBtn).onClick.Set(new EventCallback0(End));
		((GObject)goEnrollBtn).onClick.Set(new EventCallback0(OnClickOpenSelectIsland));
		((GObject)battleRecordBtn).onClick.Set(new EventCallback0(OnClickBattleRecordBtn));
		((GObject)adjustEnrollBtn).onClick.Set(new EventCallback0(OnClickOpenSelectIsland));
		((GObject)viewEnrollBtn).onClick.Set(new EventCallback0(OnClickOpenSelectIsland));
		((GObject)viewBattleBtn).onClick.Set(new EventCallback0(OnClickOpenSelectIsland));
		((GObject)ruleBtn).onClick.Set(new EventCallback0(OnClickRuleBtn));
		((GObject)replayBtn).onClick.Set(new EventCallback0(OnClickGoReviewYesterdayFight));
	}

	private void UnRegisterUiBtnEvent()
	{
		((GObject)BackBtn).onClick.Clear();
		((GObject)goEnrollBtn).onClick.Clear();
		((GObject)battleRecordBtn).onClick.Clear();
		((GObject)adjustEnrollBtn).onClick.Clear();
		((GObject)viewEnrollBtn).onClick.Clear();
		((GObject)viewBattleBtn).onClick.Clear();
		((GObject)ruleBtn).onClick.Clear();
		((GObject)replayBtn).onClick.Clear();
	}

	public void UnregisterUiEventListeners()
	{
		SharedMessenger.RemoveListener<string>("CLOSE_UI", OnUiClose);
		UnRegisterUiBtnEvent();
		S2C_BrawlEvent_TodayAllowSignUp.OnPushEvent = (Action<S2C_BrawlEvent_TodayAllowSignUp.Request>)Delegate.Remove(S2C_BrawlEvent_TodayAllowSignUp.OnPushEvent, new Action<S2C_BrawlEvent_TodayAllowSignUp.Request>(OnTodayAllowSignUp));
		GvGMode3RoomManager instance = Singleton<GvGMode3RoomManager>.Instance;
		instance.OnRoomClose = (Action)Delegate.Combine(instance.OnRoomClose, new Action(End));
	}

	public void Init(Dictionary<string, object> parameters)
	{
		//IL_00c1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f6: Unknown result type (might be due to invalid IL or missing references)
		FGUIManager.SetUiPanelSizeAndXy((GObject)(object)this);
		_brawlEventInfo = (C2S_BrawlEvent_GetInfo.Response)parameters["GVG_BRAWL_EVENT_INFO"];
		_config = WorldMapConfigHelper.Configs.TryGetBrawlEvent(_brawlEventInfo.StepIdx);
		C2S_BrawlEvent_GetInfo.Stage stage = _brawlEventInfo.GetStage();
		bool flag = stage == C2S_BrawlEvent_GetInfo.Stage.Enroll || stage == C2S_BrawlEvent_GetInfo.Stage.Enrolled || stage == C2S_BrawlEvent_GetInfo.Stage.EnrollFirstDay;
		if (_brawlEventInfo.MaxCanRecordInLeaderboard > 0 && flag)
		{
			_recordEntrance.TryPopupBattleResult(_brawlEventInfo, OnClaimed);
		}
		Refresh();
		((MonoBehaviour)FGUIManager.Instance).StartCoroutine(Update());
		FGUIManager.Instance.AddTextSpecialEffects(vfxWrapper01, "ui_gvg_brawfight_main_1", new Vector3(100f, 100f, 100f));
		FGUIManager.Instance.AddTextSpecialEffects(vfxWrapper02, "ui_gvg_brawfight_main_2", new Vector3(100f, 100f, 100f));
	}

	public void OnShow()
	{
	}

	public void BeforeDestroy()
	{
	}

	public void Destroy()
	{
	}

	private void Refresh()
	{
		((GObject)nextOpenTime).text = DateTimeHelper.ParseTimeStamp(_brawlEventInfo.GetAllowRegisterTimeEnd).LocalDateTime.ToString("yyyy/MM/dd HH:mm:ss");
		((GObject)battleStartTime).text = DateTimeHelper.ParseTimeStamp(_brawlEventInfo.GetFightingTimeEnd).LocalDateTime.ToString("yyyy/MM/dd HH:mm:ss");
		DateTime localDateTime = DateTimeHelper.Parse(_brawlEventInfo.GetFightingTimeEnd).LocalDateTime;
		TimeSpan timeSpan = _config.AllowRegisterTimeSpans[0];
		DateTimeOffset dateTimeOffset = new DateTimeOffset(localDateTime.Year, localDateTime.Month, localDateTime.Day, timeSpan.Hours, timeSpan.Minutes, timeSpan.Seconds, TimeSpan.Zero);
		((GObject)battleEndTime).text = dateTimeOffset.ToString("yyyy/MM/dd HH:mm:ss");
		C2S_BrawlEvent_GetInfo.Stage stage = _brawlEventInfo.GetStage();
		Type.SetSelectedIndex((int)stage);
		RefreshEnrollStatus(enrollStatus, _brawlEventInfo, _config);
		bool flag = IsFinalStep(_brawlEventInfo.StepIdx);
		StepType.SetSelectedIndex(flag ? 1 : 0);
		bool flag2 = _brawlEventInfo.HasReplayYesterdayFight();
		bool flag3 = stage == C2S_BrawlEvent_GetInfo.Stage.Enrolled || stage == C2S_BrawlEvent_GetInfo.Stage.Enroll || stage == C2S_BrawlEvent_GetInfo.Stage.Finished;
		replayBtn.Status.SetSelectedIndex((flag2 && flag3) ? 1 : 0);
		battleRecordBtn.Status.SetSelectedIndex(flag2 ? 1 : 0);
		UpdateRecordBtnNote();
	}

	private void ReloadUi(Action onReload = null)
	{
		Task<C2S_BrawlEvent_GetInfo.Response> task = GetBrawlEventInfo();
		task.GetAwaiter().OnCompleted(delegate
		{
			_brawlEventInfo = task.Result;
			_config = WorldMapConfigHelper.Configs.TryGetBrawlEvent(_brawlEventInfo.StepIdx);
			Refresh();
			onReload?.Invoke();
		});
	}

	private IEnumerator Update()
	{
		WaitForSeconds wait = new WaitForSeconds(1f);
		while (!((GObject)this).isDisposed)
		{
			if (((GObject)this).visible)
			{
				C2S_BrawlEvent_GetInfo.Stage stage = _brawlEventInfo.GetStage();
				Type.SetSelectedIndex((int)stage);
			}
			yield return wait;
		}
	}

	private void OnUiClose(string uiName)
	{
		Action onReload = PopupBattleResult(uiName);
		ReloadUi(onReload);
		if (uiName == UI_main_BrawlFightSelectIsland.Name)
		{
			EnterSelectIsland.PlayReverse();
			EnterSelectIsland.Stop(true, false);
		}
	}

	private Action PopupBattleResult(string uiName)
	{
		if (uiName == UI_main_BrawlFightSelectIsland.Name && _needPopupBattleResult)
		{
			_needPopupBattleResult = false;
			return delegate
			{
				_recordEntrance.TryPopupBattleResult(_brawlEventInfo, OnClaimed);
			};
		}
		return null;
	}

	private void UpdateRecordBtnNote()
	{
		((GObject)battleRecordBtn.note).visible = _brawlEventInfo.ClaimedInfos.Any((BrawlEventSettleClaimedInfo info) => info.MessageId > 0 && !info.IsClaimed);
	}

	private void OnClaimed(int day)
	{
		BrawlEventSettleClaimedInfo brawlEventSettleClaimedInfo = _brawlEventInfo.ClaimedInfos.Find((BrawlEventSettleClaimedInfo info) => info.Day == day);
		if (brawlEventSettleClaimedInfo != null)
		{
			brawlEventSettleClaimedInfo.IsClaimed = true;
			UpdateRecordBtnNote();
		}
	}

	private void OnTodayAllowSignUp(S2C_BrawlEvent_TodayAllowSignUp.Request request)
	{
		_needPopupBattleResult = true;
		if (((GObject)this).visible)
		{
			Action onReload = PopupBattleResult(UI_main_BrawlFightSelectIsland.Name);
			ReloadUi(onReload);
		}
	}

	private void OnClickOpenSelectIsland()
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		UnRegisterUiBtnEvent();
		EnterSelectIsland.Play((PlayCompleteCallback)delegate
		{
			RegisterUiBtnEvent();
			UnityUiService.Instance.OpenPanel(UI_main_BrawlFightSelectIsland.Name, new Dictionary<string, object> { { "GvGBrawlEventInfo", _brawlEventInfo } });
		});
	}

	private void OnClickBattleRecordBtn()
	{
		_recordEntrance.TryCheckBattleResult(_brawlEventInfo, OnClaimed);
	}

	private void OnClickGoReviewYesterdayFight()
	{
		if (!_brawlEventInfo.HasReplayYesterdayFight())
		{
			return;
		}
		((GObject)replayBtn).touchable = false;
		SocketManager.Instance.GetConnection(eConType.GvGMode3IslandManager).Request(new C2S_BrawlEvent_Review(), delegate(SocketManager.BaseSocketPackageBodyContext contextResponse)
		{
			((GObject)replayBtn).touchable = true;
			C2S_BrawlEvent_Review.Response response = (C2S_BrawlEvent_Review.Response)contextResponse.Resp;
			if (response.ErrorCode != 0)
			{
				ILRequestHelper.ShowErrorCode(response.ErrorCode);
			}
			else
			{
				UnityUiService.Instance.OpenPanel(UI_main_BrawlFightSelectIsland.Name, new Dictionary<string, object>
				{
					{ "GvGBrawlEventInfo", _brawlEventInfo },
					{ "GvGBrawlEventReview", response }
				});
			}
		});
	}

	private static void OnClickRuleBtn()
	{
		UnityUiService.Instance.OpenPanel(UI_main_BrawlFightRuleHelp.Name, new Dictionary<string, object>());
	}

	private static void End()
	{
		UnityUiService.Instance.ClosePanel(Name);
	}

	public static bool IsFinalStep(int stepIdx)
	{
		return stepIdx >= 100;
	}

	public static bool IsFinalStepOne(int stepidx)
	{
		return stepidx == 100;
	}

	public static bool IsDebugOpen()
	{
		string value;
		string text = (HotUpdateProcess.Instance.Configs.TryGetValue("DebugBrawlEventLocalTime", out value) ? value : null);
		if (text != null)
		{
			return int.Parse(text) != 0;
		}
		return false;
	}

	public static long GetBrawlEventTime()
	{
		if (IsDebugOpen())
		{
			return DateTimeHelper.TimeStamp;
		}
		return GameController.Instance.GetServerTime();
	}

	public static int WhatDayIsToday()
	{
		long brawlEventTime = GetBrawlEventTime();
		int iZBeginTimestamp = Singleton<WorldStateManager>.Instance.Data.IZBeginTimestamp;
		DateTimeOffset dateTimeOffset = DateTimeHelper.ParseTimeStamp(iZBeginTimestamp);
		DateTimeOffset dateTimeOffset2 = new DateTimeOffset(dateTimeOffset.Year, dateTimeOffset.Month, dateTimeOffset.Day, 0, 0, 0, DateTimeHelper.TimezoneOffset);
		DateTime localDateTime = DateTimeHelper.ParseTimeStamp((int)brawlEventTime).LocalDateTime;
		int num = (localDateTime - dateTimeOffset2).Days;
		GvGMode3BrawlEvent_BaseInfo gvGMode3BrawlEvent_BaseInfo = WorldMapConfigHelper.Configs.TryGetBrawlEventByDay(2);
		int hour = localDateTime.ToLocalTime().Hour;
		if (hour >= gvGMode3BrawlEvent_BaseInfo.AllowRegisterTimeSpans[0].Hours)
		{
			num++;
		}
		return Mathf.Max(num, 1);
	}

	public static Task<C2S_BrawlEvent_GetInfo.Response> GetBrawlEventInfo()
	{
		TaskCompletionSource<C2S_BrawlEvent_GetInfo.Response> task = new TaskCompletionSource<C2S_BrawlEvent_GetInfo.Response>();
		SocketManager.Instance.GetConnection(eConType.GvGMode3IslandManager).Request(new C2S_BrawlEvent_GetInfo(), delegate(SocketManager.BaseSocketPackageBodyContext contextResponse)
		{
			C2S_BrawlEvent_GetInfo.Response response = (C2S_BrawlEvent_GetInfo.Response)contextResponse.Resp;
			if (response.ErrorCode != 0)
			{
				ILRequestHelper.ShowErrorCode(response.ErrorCode);
				task.SetResult(null);
			}
			else
			{
				GameManagers.Instance.Messenger.Broadcast("BRAWL_EVENT_SIGN_UP_CHANGE", response);
				task.SetResult(response);
			}
		});
		return task.Task;
	}

	private static int StepIndexToUiIndex(int stepIdx)
	{
		if (IsFinalStep(stepIdx))
		{
			return stepIdx - 100 + 4;
		}
		return stepIdx - 1;
	}

	public static void RefreshEnrollStatus(UI_com_EnrollStatus enrollStatus, C2S_BrawlEvent_GetInfo.Response brawlEventInfo, GvGMode3BrawlEvent_BaseInfo config)
	{
		int selfShipCount = brawlEventInfo.SelfSignUpDatas?.Count ?? 0;
		RefreshEnrollStatus(enrollStatus, selfShipCount, config);
	}

	public static void RefreshEnrollStatus(UI_com_EnrollStatus enrollStatus, int selfShipCount, GvGMode3BrawlEvent_BaseInfo config)
	{
		//IL_0086: Unknown result type (might be due to invalid IL or missing references)
		//IL_0090: Expected O, but got Unknown
		int limitForEachUser = config.LimitForEachUser;
		((GObject)enrollStatus.shipCount).text = $"{selfShipCount}/{limitForEachUser}";
		int num = 0;
		num = ((selfShipCount != 0) ? ((selfShipCount < limitForEachUser) ? 1 : 2) : 0);
		enrollStatus.countStatus.SetSelectedIndex(num);
		enrollStatus.stepIndex.SetSelectedIndex(StepIndexToUiIndex(config.StepIdx));
		((GObject)enrollStatus.helpBtn).onClick.Set(new EventCallback0(OnClickEnrollStatusHelp));
	}

	private static void OnClickEnrollStatusHelp()
	{
		UnityUiService.Instance.OpenPanel(UI_main_BrawlFightRuleHelp2.Name, new Dictionary<string, object>());
	}

	public static void TryReloadBrawlIslandState(int day)
	{
		int curIZId = Singleton<GvGMode3RoomManager>.Instance.ObserverRecord.CurIZId;
		string text = $"{curIZId}_d_{day}";
		string text2 = GameLocalDataManager.GetString("BrawlIslandStateKey");
		if (text2 != text)
		{
			GameLocalDataManager.SetString("BrawlIslandStateKey", text);
			GvGMode3BrawlEvent_BaseInfo gvGMode3BrawlEvent_BaseInfo = WorldMapConfigHelper.Configs.TryGetBrawlEventByDay(day);
			Singleton<WorldStateManager>.Instance.GetIslandsState(gvGMode3BrawlEvent_BaseInfo.EffectIslandIds, null, isForceSync: true);
		}
	}
}
