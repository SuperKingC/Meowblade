using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Assets.Scripts.Managers;
using Assets.Scripts.UI;
using FairyGUI;
using FairyGUI.Utils;
using HotFix;
using HotFix.Sources.Base.Scripts.UI;
using Shift.Legion.ClientApi.Protocol.UserAction;
using Shift.Legion.Common.Services;
using UnityEngine;

namespace UI.PvpSelectSoldiers;

public class UI_PvpZoneChoose : GComponent, IUiController
{
	public Controller Status;

	public GLoader background;

	public GImage diban;

	public GImage BakgroundIcon;

	public UI_BackBtn ExitBtn;

	public UI_TitleCom Title;

	public UI_addCouponBtn addCouponBtnLeft;

	public UI_addCouponBtn addCouponBtnRight;

	public GTextField textSeason;

	public GTextField textTime;

	public GList fakeRegionList;

	public GList regionList;

	public GTextField textTip;

	public UI_btnJoin JoinBtn;

	public GTextField n60;

	public UI_SeasonRewardPreview RewardPreview;

	public UI_btn_SeasonEntranceFunction TopTournamentLastTurn10;

	public UI_RankStore RankStore;

	public UI_btn_SeasonEntranceFunction TopTournamentHistoryRank;

	public GGraph n66;

	public GTextField CloseTip;

	public GGroup n67;

	public const string URL = "ui://82mo10n5ch138f";

	public static string Name = "UI_PvpZoneChoose";

	private BigZoneInfo currentBigZoneInfo;

	private int regionListSelectedIndex;

	private List<KeyValuePair<string, BigZoneInfo>> randomZoneDetail = new List<KeyValuePair<string, BigZoneInfo>>();

	private const string ZoneSfxName = "ui_leaderboard_portal";

	private string PanelName => LanguagesManager.GetDesc("CsharpCodeZhTcText454");

	public void SetControllerPageText()
	{
		string id = string.Format("{0}-{1}-{2}", "ui://82mo10n5ch138f".Replace("ui://", ""), ((GObject)CloseTip).id, Status.selectedIndex);
		((GObject)CloseTip).text = LanguagesManager.GetDesc(id);
	}

	public static string GetURL()
	{
		return "ui://82mo10n5ch138f";
	}

	public static UI_PvpZoneChoose CreateInstance()
	{
		return (UI_PvpZoneChoose)(object)UIPackage.CreateObject("PvpSelectSoldiers", "PvpZoneChoose");
	}

	public static UI_PvpZoneChoose CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_PvpZoneChoose).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://82mo10n5ch138f", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		//IL_00c0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ca: Expected O, but got Unknown
		//IL_0113: Unknown result type (might be due to invalid IL or missing references)
		//IL_011d: Expected O, but got Unknown
		//IL_0166: Unknown result type (might be due to invalid IL or missing references)
		//IL_0170: Expected O, but got Unknown
		//IL_017c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0186: Expected O, but got Unknown
		//IL_0192: Unknown result type (might be due to invalid IL or missing references)
		//IL_019c: Expected O, but got Unknown
		//IL_01fb: Unknown result type (might be due to invalid IL or missing references)
		//IL_0205: Expected O, but got Unknown
		//IL_02a6: Unknown result type (might be due to invalid IL or missing references)
		//IL_02b0: Expected O, but got Unknown
		//IL_02bc: Unknown result type (might be due to invalid IL or missing references)
		//IL_02c6: Expected O, but got Unknown
		//IL_0311: Unknown result type (might be due to invalid IL or missing references)
		//IL_031b: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		Status = ((GComponent)this).GetController("Status");
		background = (GLoader)((GComponent)this).GetChild("background");
		diban = (GImage)((GComponent)this).GetChild("diban");
		BakgroundIcon = (GImage)((GComponent)this).GetChild("BakgroundIcon");
		ExitBtn = (UI_BackBtn)(object)((GComponent)this).GetChild("ExitBtn");
		Title = (UI_TitleCom)(object)((GComponent)this).GetChild("Title");
		addCouponBtnLeft = (UI_addCouponBtn)(object)((GComponent)this).GetChild("addCouponBtnLeft");
		addCouponBtnRight = (UI_addCouponBtn)(object)((GComponent)this).GetChild("addCouponBtnRight");
		textSeason = (GTextField)((GComponent)this).GetChild("textSeason");
		string id = "ui://82mo10n5ch138f".Replace("ui://", "") + "-" + ((GObject)textSeason).id;
		((GObject)textSeason).text = LanguagesManager.GetDesc(id);
		textTime = (GTextField)((GComponent)this).GetChild("textTime");
		string id2 = "ui://82mo10n5ch138f".Replace("ui://", "") + "-" + ((GObject)textTime).id;
		((GObject)textTime).text = LanguagesManager.GetDesc(id2);
		fakeRegionList = (GList)((GComponent)this).GetChild("fakeRegionList");
		regionList = (GList)((GComponent)this).GetChild("regionList");
		textTip = (GTextField)((GComponent)this).GetChild("textTip");
		string id3 = "ui://82mo10n5ch138f".Replace("ui://", "") + "-" + ((GObject)textTip).id;
		((GObject)textTip).text = LanguagesManager.GetDesc(id3);
		JoinBtn = (UI_btnJoin)(object)((GComponent)this).GetChild("JoinBtn");
		n60 = (GTextField)((GComponent)this).GetChild("n60");
		string id4 = "ui://82mo10n5ch138f".Replace("ui://", "") + "-" + ((GObject)n60).id;
		((GObject)n60).text = LanguagesManager.GetDesc(id4);
		RewardPreview = (UI_SeasonRewardPreview)(object)((GComponent)this).GetChild("RewardPreview");
		TopTournamentLastTurn10 = (UI_btn_SeasonEntranceFunction)(object)((GComponent)this).GetChild("TopTournamentLastTurn10");
		RankStore = (UI_RankStore)(object)((GComponent)this).GetChild("RankStore");
		TopTournamentHistoryRank = (UI_btn_SeasonEntranceFunction)(object)((GComponent)this).GetChild("TopTournamentHistoryRank");
		n66 = (GGraph)((GComponent)this).GetChild("n66");
		CloseTip = (GTextField)((GComponent)this).GetChild("CloseTip");
		string id5 = "ui://82mo10n5ch138f".Replace("ui://", "") + "-" + ((GObject)CloseTip).id;
		((GObject)CloseTip).text = LanguagesManager.GetDesc(id5);
		n67 = (GGroup)((GComponent)this).GetChild("n67");
	}

	public void BeforeDestroy()
	{
	}

	public void Destroy()
	{
	}

	public void Init(Dictionary<string, object> parameters)
	{
		FGUIManager.SetUiPanelSizeAndXy((GObject)(object)this);
		SetBuildingName();
		currentBigZoneInfo = RankDataHelper.RankSeasonInfo.GetSomeUserIdBigZoneInfo(GameController.Contexts.gameState.user.value.UserId);
		((GObject)textSeason).text = string.Format("{0}（{1}{2}{3}）", RankDataHelper.RankSeasonInfo.GetDisplayName(), LanguagesManager.GetDesc("CsharpCodeZhTcText145"), RankDataHelper.RankStartGameInfo.Turn, LanguagesManager.GetDesc("CsharpCodeZhTcText503"));
		DateTimeOffset dateTimeOffset = DateTimeHelper.ParseTimeStamp(RankDataHelper.RankStartGameInfo.StartAtTimestamp);
		DateTimeOffset dateTimeOffset2 = DateTimeHelper.ParseTimeStamp(RankDataHelper.RankStartGameInfo.BattleEndAtTimestamp);
		if (!HotUpdateProcess.Instance.IsRegionOutCN)
		{
			string desc = LanguagesManager.GetDesc("CsharpCodeZhTcText397");
			string desc2 = LanguagesManager.GetDesc("CsharpCodeZhTcText398");
			string desc3 = LanguagesManager.GetDesc("CsharpCodeZhTcText11");
			string text = dateTimeOffset.LocalDateTime.ToString("MM" + desc + "dd" + desc2 + "HH" + desc3);
			string text2 = dateTimeOffset2.LocalDateTime.ToString("MM" + desc + "dd" + desc2 + "HH" + desc3);
			((GObject)textTime).text = text + " - " + text2;
		}
		else
		{
			string text = dateTimeOffset.LocalDateTime.ToString("yyyy-MM-dd HH:mm");
			string text2 = dateTimeOffset2.LocalDateTime.ToString("yyyy-MM-dd HH:mm");
			((GObject)textTime).text = text + " ~ " + text2;
		}
		((GComponent)addCouponBtnRight).GetChild("addButton").visible = false;
		((GComponent)addCouponBtnRight).GetChild("icon").asLoader.url = "ui://PublicResources/" + RankDataHelper.PvPRankScoreItem;
		((GComponent)addCouponBtnRight).GetChild("num").text = "0";
		((GObject)addCouponBtnLeft).visible = false;
		RenderMainUi();
		if (!RankDataHelper.IsServerWideBattle)
		{
			((GObject)RankStore).visible = true;
			((GObject)RankStore).alpha = 1f;
			UI_btn_SeasonEntranceFunction topTournamentLastTurn = TopTournamentLastTurn10;
			((GObject)topTournamentLastTurn).x = ((GObject)topTournamentLastTurn).x - 158f;
			UI_btn_SeasonEntranceFunction topTournamentHistoryRank = TopTournamentHistoryRank;
			((GObject)topTournamentHistoryRank).x = ((GObject)topTournamentHistoryRank).x - 158f;
		}
	}

	public void OnShow()
	{
		UiHelper.NumberTextChangeGTween(0f, RankDataHelper.GetPvPRankScoreItemNum(), ((GComponent)addCouponBtnRight).GetChild("num").asTextField, 1f, (EaseType)19);
	}

	public void RegisterUiEventListeners()
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
		((GObject)ExitBtn).onClick.Add(new EventCallback0(End));
		((GObject)JoinBtn).onClick.Add(new EventCallback1(JoinRegion));
		((GObject)RankStore).onClick.Add(new EventCallback0(OpenRankStore));
		((GObject)TopTournamentHistoryRank).onClick.Add(new EventCallback1(OpenHistoryRankList));
		((GObject)TopTournamentLastTurn10).onClick.Add(new EventCallback0(GetLastTurnLast10));
	}

	public void UnregisterUiEventListeners()
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
		((GObject)ExitBtn).onClick.Remove(new EventCallback0(End));
		((GObject)JoinBtn).onClick.Remove(new EventCallback1(JoinRegion));
		((GObject)RankStore).onClick.Remove(new EventCallback0(OpenRankStore));
		((GObject)TopTournamentHistoryRank).onClick.Remove(new EventCallback1(OpenHistoryRankList));
		((GObject)TopTournamentLastTurn10).onClick.Remove(new EventCallback0(GetLastTurnLast10));
	}

	public void End()
	{
		GameController.Contexts.Service<IUiService>().ClosePanel(Name);
	}

	private void OpenHistoryRankList(EventContext context)
	{
		//IL_0044: Unknown result type (might be due to invalid IL or missing references)
		//IL_004e: Expected O, but got Unknown
		((GObject)TopTournamentHistoryRank).touchable = false;
		IUiService uiService = Contexts.sharedInstance.Service<IUiService>();
		int num = uiService.SetUiNotTouchable(Name);
		uiService.ShowWaitingAnimation(show: true);
		((GComponent)(object)TopTournamentHistoryRank).SetTimeout(0.5f).OnComplete((GTweenCallback)delegate
		{
			((GObject)TopTournamentHistoryRank).touchable = true;
		});
		GameController.Contexts.Service<IUiService>().OpenPanel(UI_TopTournamentHistoryRankList.Name, new Dictionary<string, object> { { "ChangeId", num } });
	}

	private async void GetLastTurnLast10()
	{
		int turnId = DayIndexListInit();
		int originalCurTurnId = ((RankDataHelper.RankSeasonInfo.TurnId < 0) ? (turnId + RankDataHelper.RankSeasonInfo.Id * 10 + 1) : RankDataHelper.RankSeasonInfo.TurnId);
		int currentTurnId = originalCurTurnId - RankDataHelper.RankSeasonInfo.Id * 10;
		bool isFirstTurn = currentTurnId <= 0;
		int lastTurnId = (isFirstTurn ? 3 : (currentTurnId - 1));
		int lastSeasonId = (isFirstTurn ? (RankDataHelper.RankSeasonInfo.Id - 1) : RankDataHelper.RankSeasonInfo.Id);
		GetPvPRankLastTurnLast10SelfRankRecordResponse response = await GameController.Contexts.Service<INetworkService>().GetPvPRankLastTurnLast10SelfRankRecord(lastSeasonId, lastTurnId);
		if (!response.Result)
		{
			ILRequestHelper.ShowErrorCode(response.ErrorCode);
			return;
		}
		GameController.Contexts.Service<IUiService>().OpenPanel(UI_PvpBattleLogPanel.Name, new Dictionary<string, object> { { "LastTurnLast10RankChangeRecord", response.RankChangeRecords } });
	}

	private void RenderMainUiSeasonEnable()
	{
		randomZoneDetail = currentBigZoneInfo.RandomZoneDetail();
		RewardPreview.RenderReward();
		((GObject)JoinBtn).enabled = false;
		regionListSelectedIndex = -1;
		RenderRegionList();
	}

	public int DayIndexListInit()
	{
		RankDataHelper.GetCurrentSeasonIs(isBattleEnd: true, out var turns);
		List<int> list = new List<int>();
		for (int i = 0; i < turns.Count; i++)
		{
			list.Add(turns[i].Turn - 1);
		}
		if (turns.Count <= 0 || list.Count <= 0)
		{
			return -1;
		}
		int num = (int)GameController.Instance.GetServerTime();
		int endAtTimestamp = turns[turns.Count - 1].EndAtTimestamp;
		if (num <= endAtTimestamp)
		{
			return 0;
		}
		return list.ToList()[list.Count - 1];
	}

	private void RenderMainUi()
	{
		List<RankDataHelper.tRankStartGame> turns;
		int currentSeasonIs = RankDataHelper.GetCurrentSeasonIs(isBattleEnd: true, out turns);
		Status.selectedIndex = currentSeasonIs;
		SetControllerPageText();
		if (Status.selectedIndex == 0)
		{
			RenderMainUiSeasonEnable();
		}
		else
		{
			RewardPreview.RenderReward();
		}
	}

	private void RenderRegionList()
	{
		//IL_000e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0018: Expected O, but got Unknown
		regionList.itemRenderer = new ListItemRenderer(RenderRegionItem);
		regionList.numItems = randomZoneDetail.Count;
	}

	private void RenderFakeRegionList()
	{
		if (fakeRegionList.numItems >= 2)
		{
			((GComponent)fakeRegionList).GetChildAt(1).alpha = 0f;
		}
		for (int i = 0; i < fakeRegionList.numItems; i++)
		{
			GComponent asCom = ((GComponent)fakeRegionList).GetChildAt(i).asCom;
			asCom.GetController("Status").selectedIndex = 2;
			GComponent asCom2 = asCom.GetChild("Content").asCom;
			asCom2.GetController("Type").selectedIndex = 2;
			asCom2.GetChild("textSeason").text = LanguagesManager.GetDesc("CsharpCodeZhTcText376");
		}
	}

	private void RenderRegionItem(int index, GObject obj)
	{
		//IL_00b7: Unknown result type (might be due to invalid IL or missing references)
		//IL_0148: Unknown result type (might be due to invalid IL or missing references)
		//IL_0152: Expected O, but got Unknown
		if (obj is UI_regionSelect uI_regionSelect)
		{
			((GObject)uI_regionSelect.Content).touchable = false;
			BigZoneInfo value = randomZoneDetail[index].Value;
			((GObject)uI_regionSelect.Content.battleTotal).text = Convert.ToInt32(value.CurrentZoneInfo.AverageCompbatPower).ShortNumberFormat();
			((GObject)uI_regionSelect.Content.textSeason).text = LanguagesManager.GetDesc("CsharpCodeZhTcText376");
			int zoneBtnType = value.CurrentZoneInfo.GetZoneBtnType();
			uI_regionSelect.Content.Type.selectedIndex = zoneBtnType;
			FGUIManager.Instance.AddTextSpecialEffects(uI_regionSelect.SfxBack, "ui_leaderboard_portal", new Vector3(120f, 120f, 120f), "Default", 0.5f, delegate(GameObject zoneSfx)
			{
				//IL_001b: Unknown result type (might be due to invalid IL or missing references)
				zoneSfx.gameObject.transform.localPosition = new Vector3(0f, 0f, -2f);
			});
			if (index == regionListSelectedIndex)
			{
				uI_regionSelect.Status.selectedIndex = 1;
			}
			else if (zoneBtnType == 3)
			{
				uI_regionSelect.Status.selectedIndex = 2;
			}
			else
			{
				uI_regionSelect.Status.selectedIndex = 0;
			}
			((GObject)uI_regionSelect).data = index;
			((GObject)uI_regionSelect).onClick.Set(new EventCallback1(SelectRegion));
		}
	}

	public void SetBuildingName()
	{
		((GObject)Title.buildingName).text = PanelName;
	}

	private void OpenRankStore()
	{
		GameController.Contexts.Service<IUiService>().OpenPanel(UI_PvpStorePanel.Name, null);
	}

	private void SelectRegion(EventContext context)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000d: Expected O, but got Unknown
		GObject val = (GObject)context.sender;
		object data = val.data;
		if (data == null || randomZoneDetail == null || randomZoneDetail.Count <= 0)
		{
			return;
		}
		int num = (int)data;
		int zoneBtnType = randomZoneDetail[num].Value.CurrentZoneInfo.GetZoneBtnType();
		if (zoneBtnType == 0 || zoneBtnType == 1 || zoneBtnType == 2)
		{
			regionListSelectedIndex = num;
			if (regionListSelectedIndex >= 0 && regionListSelectedIndex < regionList.numItems)
			{
				RenderRegionList();
				((GObject)JoinBtn).data = num;
				((GObject)JoinBtn).enabled = true;
			}
		}
		else
		{
			List<string> arg = new List<string> { LanguagesManager.GetDesc("CsharpCodeZhTcText504") + LanguagesManager.Comma + LanguagesManager.GetDesc("CsharpCodeZhTcText505") };
			SharedMessenger.Broadcast("SHOW_TIPS", arg, 1, arg3: false);
		}
	}

	private void JoinRegion(EventContext context)
	{
		//IL_0014: Unknown result type (might be due to invalid IL or missing references)
		//IL_001a: Expected O, but got Unknown
		GObject val = (GObject)context.sender;
		if (val.data == null)
		{
			return;
		}
		int index = (int)val.data;
		BigZoneInfo bigZone = randomZoneDetail?[index].Value;
		string rsName = bigZone.CurrentZoneInfo.RSName;
		int zoneBtnType = bigZone.CurrentZoneInfo.GetZoneBtnType();
		if (string.IsNullOrEmpty(rsName))
		{
			return;
		}
		if (zoneBtnType == 2)
		{
			UiHelper.ShowConfirmAndCancelDialog(LanguagesManager.GetDesc("CsharpCodeZhTcText506") + LanguagesManager.Comma + LanguagesManager.GetDesc("CsharpCodeZhTcText507") + LanguagesManager.Comma + LanguagesManager.GetDesc("CsharpCodeZhTcText508") + "？", delegate
			{
				ChooseRankZone(bigZone.BigZoneId, rsName);
			}, null);
		}
		else
		{
			ChooseRankZone(bigZone.BigZoneId, rsName);
		}
	}

	private void ChooseRankZone(int bigZoneId, string rsName)
	{
		ILRequestHelper<PVPRankSeasonChooseZoneResponse>.Request((EventContext)null, (Func<Task<PVPRankSeasonChooseZoneResponse>>)(() => GameController.Contexts.Service<INetworkService>().PVPRankSeasonChooseZone(-1L, bigZoneId)), (Action<PVPRankSeasonChooseZoneResponse>)delegate(PVPRankSeasonChooseZoneResponse response)
		{
			if (!response.Result)
			{
				ILRequestHelper.ShowErrorCode(response.ErrorCode);
			}
			else
			{
				ThinkingDataHelper.Instance.PvpSelectZone(bigZoneId, rsName);
				UpdateOnChooseRankZoneSuccess(rsName);
			}
		});
	}

	private async void UpdateOnChooseRankZoneSuccess(string rsName)
	{
		End();
		RankDataHelper.UpdateRankProgressRankServerName(rsName);
		Action action_Foo = delegate
		{
			RankDataHelper.OpenPvpEntrancePanel();
		};
		RankDataHelper.GetPvpRankSeasonInfo(action_Foo);
	}
}
