using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Assets.Scripts.Managers;
using Assets.Scripts.UI;
using FairyGUI;
using FairyGUI.Utils;
using HotFix.Sources.Base.Scripts.Helper;
using HotFix.Sources.Base.Scripts.UI;
using Shift.Legion.ClientApi.Protocol.UserAction;
using Shift.Legion.Common.Managers;
using Shift.Legion.Common.Services;
using UnityEngine;

namespace UI.PvpSelectSoldiers;

public class UI_FirstThree : GComponent
{
	public Controller Type;

	public GImage n32;

	public GImage n30;

	public GTextField CompetitionseasonTime;

	public GTextField Division;

	public GList FirstThreeAvatars;

	public UI_PeakBattleArray PeakBattleArray;

	public UI_TopTournamentLog TopTournamentLog;

	public GTextField tip;

	public GImage n33;

	public GImage n34;

	public UI_HelpBtn02 helpBtn;

	public const string URL = "ui://82mo10n5js4q6r";

	public static string Name = "UI_FirstThree";

	private List<Dictionary<string, object>> firstThreeSummaries = new List<Dictionary<string, object>>();

	private const int RanksSize = 3;

	private const string NpcIconUrl = "ui://PvpSelectSoldiers/Clap1_filled";

	private const int TypeSelectIndex = 0;

	public static string GetURL()
	{
		return "ui://82mo10n5js4q6r";
	}

	public static UI_FirstThree CreateInstance()
	{
		return (UI_FirstThree)(object)UIPackage.CreateObject("PvpSelectSoldiers", "FirstThree");
	}

	public static UI_FirstThree CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_FirstThree).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://82mo10n5js4q6r", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		//IL_00a5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00af: Expected O, but got Unknown
		//IL_00bb: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c5: Expected O, but got Unknown
		//IL_00fd: Unknown result type (might be due to invalid IL or missing references)
		//IL_0107: Expected O, but got Unknown
		//IL_0150: Unknown result type (might be due to invalid IL or missing references)
		//IL_015a: Expected O, but got Unknown
		//IL_0166: Unknown result type (might be due to invalid IL or missing references)
		//IL_0170: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		Type = ((GComponent)this).GetController("Type");
		n32 = (GImage)((GComponent)this).GetChild("n32");
		n30 = (GImage)((GComponent)this).GetChild("n30");
		CompetitionseasonTime = (GTextField)((GComponent)this).GetChild("CompetitionseasonTime");
		string id = "ui://82mo10n5js4q6r".Replace("ui://", "") + "-" + ((GObject)CompetitionseasonTime).id;
		((GObject)CompetitionseasonTime).text = LanguagesManager.GetDesc(id);
		Division = (GTextField)((GComponent)this).GetChild("Division");
		FirstThreeAvatars = (GList)((GComponent)this).GetChild("FirstThreeAvatars");
		PeakBattleArray = (UI_PeakBattleArray)(object)((GComponent)this).GetChild("PeakBattleArray");
		TopTournamentLog = (UI_TopTournamentLog)(object)((GComponent)this).GetChild("TopTournamentLog");
		tip = (GTextField)((GComponent)this).GetChild("tip");
		string id2 = "ui://82mo10n5js4q6r".Replace("ui://", "") + "-" + ((GObject)tip).id;
		((GObject)tip).text = LanguagesManager.GetDesc(id2);
		n33 = (GImage)((GComponent)this).GetChild("n33");
		n34 = (GImage)((GComponent)this).GetChild("n34");
		helpBtn = (UI_HelpBtn02)(object)((GComponent)this).GetChild("helpBtn");
	}

	public async Task Init()
	{
		((GObject)PeakBattleArray).onClick.Set(new EventCallback1(SelectPeakBattleArray));
		((GObject)TopTournamentLog).onClick.Set(new EventCallback0(OpenTopTournamentBattlePanel));
		((GObject)helpBtn).onClick.Set(new EventCallback0(OnClickHelpBtn));
		bool rankListVisible = await GetUserRankList();
		if (!((GObject)this).isDisposed)
		{
			((GObject)tip).visible = !rankListVisible;
			SetPeakBattleState();
			ShowCompetitionSeasonInfo();
			RenderFirstThreeAvatars();
			((GObject)TopTournamentLog).grayed = !IsUnlocked();
		}
	}

	public async Task Update()
	{
		bool rankListVisible = await GetUserRankList();
		if (!((GObject)this).isDisposed)
		{
			((GObject)tip).visible = !rankListVisible;
			SetPeakBattleState();
			ShowCompetitionSeasonInfo();
			RenderFirstThreeAvatars();
		}
	}

	public void SetPeakBattleState()
	{
		Type.selectedIndex = ((RankDataHelper.PeakBattleUnlocked() || RankDataHelper.HasTopTournamentFormationConfig) ? 1 : 0);
	}

	public static bool IsUnlocked()
	{
		return GameManagers.Instance.UserArchiveManager.GetChapterLevelProgress("C1003").Contains("P320");
	}

	private void ShowCompetitionSeasonInfo()
	{
		DateTimeOffset dateTimeOffset = DateTimeHelper.ParseTimeStamp(RankDataHelper.RankStartGameInfo.StartAtTimestamp);
		DateTimeOffset dateTimeOffset2 = DateTimeHelper.ParseTimeStamp(RankDataHelper.RankStartGameInfo.BattleEndAtTimestamp);
		string dateStringMMddHH = UiHelper.GetDateStringMMddHH(dateTimeOffset.LocalDateTime);
		string dateStringMMddHH2 = UiHelper.GetDateStringMMddHH(dateTimeOffset2.LocalDateTime);
		((GObject)CompetitionseasonTime).text = LanguagesManager.GetDesc("CsharpCodeZhTcText453") + "：" + dateStringMMddHH + " - " + dateStringMMddHH2;
		((GObject)Division).text = "";
	}

	private void RenderFirstThreeAvatars()
	{
		//IL_006b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0075: Expected O, but got Unknown
		if (FirstThreeAvatars != null && !((GObject)FirstThreeAvatars).isDisposed)
		{
			FirstThreeAvatars.numItems = 0;
			if (firstThreeSummaries.Count > 0)
			{
				int numItems = ((firstThreeSummaries.Count >= 3) ? 3 : firstThreeSummaries.Count);
				FirstThreeAvatars.itemRenderer = new ListItemRenderer(RenderPlayerAvatar);
				FirstThreeAvatars.numItems = numItems;
			}
		}
	}

	private void RenderPlayerAvatar(int index, GObject obj)
	{
		//IL_00f4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fe: Expected O, but got Unknown
		if (obj is UI_FirstThreeUserInfo uI_FirstThreeUserInfo && index <= firstThreeSummaries.Count - 1)
		{
			Dictionary<string, object> dictionary = firstThreeSummaries[index];
			int userId = (int)dictionary["UserId"];
			uI_FirstThreeUserInfo.Type.selectedIndex = index;
			if (userId != 0)
			{
				uI_FirstThreeUserInfo.Icon.HeadPortrait.Type.selectedIndex = 0;
				((MonoBehaviour)FGUIManager.Instance).StartCoroutine(FGUIManager.Instance.GetImageByWebRequestAndStorage(Name, userId, uI_FirstThreeUserInfo.Icon.HeadPortrait.icon, uI_FirstThreeUserInfo.UserName));
				FGUIManager.Instance.GetUserMedal(userId, uI_FirstThreeUserInfo.medalList);
			}
			((GObject)uI_FirstThreeUserInfo).onClick.Set((EventCallback0)delegate
			{
				FGUIManager.Instance.OpenForumUserProfilePage(userId);
			});
		}
	}

	private async void OpenRankList()
	{
		await Update();
		GameController.Contexts.Service<IUiService>().OpenPanel(UI_PvpScoreRankListPanel.Name, new Dictionary<string, object> { { "ScoreRankingListData", firstThreeSummaries } });
	}

	public void OpenTopTournamentBattlePanel()
	{
		//IL_0063: Unknown result type (might be due to invalid IL or missing references)
		//IL_006d: Expected O, but got Unknown
		if (!IsUnlocked())
		{
			"TopTournamentLogLockedTip".ToLanguage().ToTip();
			return;
		}
		((GObject)TopTournamentLog).touchable = false;
		IUiService uiService = Contexts.sharedInstance.Service<IUiService>();
		int num = uiService.SetUiNotTouchable(Name);
		uiService.ShowWaitingAnimation(show: true);
		((GComponent)(object)TopTournamentLog).SetTimeout(0.5f).OnComplete((GTweenCallback)delegate
		{
			((GObject)TopTournamentLog).touchable = true;
		});
		GameController.Contexts.Service<IUiService>().OpenPanel(UI_TopTournamentBattlePanel.Name, new Dictionary<string, object> { { "ChangeId", num } });
	}

	private void OnClickHelpBtn()
	{
		UnityUiService.Instance.OpenPanel(UI_PvpHelpPanel.Name, new Dictionary<string, object> { { "PvpSelectSoldiers", this } });
	}

	private void SelectPeakBattleArray(EventContext context)
	{
		if (RankDataHelper.IsInTopTournament && !RankDataHelper.HasTopTournamentFormationConfig)
		{
			ShowFirstTimePeakBattleTip();
		}
		else
		{
			OpenPeakBattleArrayPanel();
		}
	}

	private void ShowFirstTimePeakBattleTip()
	{
		string desc = LanguagesManager.GetDesc("PeakBattleFirstTip1");
		UiHelper.ShowConfirmDialog(desc, delegate
		{
			OpenPeakBattleArrayPanel();
		});
	}

	private void OpenPeakBattleArrayPanel()
	{
		ILRequestHelper<GetPvPTopTournamentFormationResponse>.Request((EventContext)null, (Func<Task<GetPvPTopTournamentFormationResponse>>)(() => GameController.Contexts.Service<INetworkService>().GetPvPTopTournamentFormation()), (Action<GetPvPTopTournamentFormationResponse>)delegate(GetPvPTopTournamentFormationResponse response)
		{
			if (!response.Result)
			{
				ILRequestHelper.ShowErrorCode(response.ErrorCode);
			}
			else
			{
				GameController.Contexts.Service<IUiService>().OpenPanel(UI_PeakBattleSelectArrayPanel.Name, new Dictionary<string, object> { { "FormationResponse", response } });
			}
		});
	}

	private async Task<bool> GetUserRankList()
	{
		GetPvPTopTournamentRankResponse response = await GameController.Contexts.Service<INetworkService>().GetPvPTopTournamentRankInfo();
		if (!response.Result)
		{
			ILRequestHelper.ShowErrorCode(response.ErrorCode);
			return response.Result;
		}
		firstThreeSummaries = response.TopTournamentRankListInfo;
		if (firstThreeSummaries == null)
		{
			firstThreeSummaries = new List<Dictionary<string, object>>();
		}
		return firstThreeSummaries.Count > 0;
	}
}
