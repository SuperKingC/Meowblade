using System.Collections.Generic;
using System.Threading.Tasks;
using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;
using HotFix.Sources.Base.Scripts.UI;
using HotFix.Sources.Base.Scripts.UI.LoadWebImage;
using Shift.Legion.ClientApi.Protocol.UserAction;
using Shift.Legion.Common.Services;
using UnityEngine;

namespace UI.PvpSelectSoldiers;

public class UI_TopTournamentRankList : GComponent
{
	public GImage n11;

	public GImage n46;

	public GImage n47;

	public GImage n43;

	public GList RankList;

	public GTextField tip;

	public const string URL = "ui://82mo10n5t7wpdfo";

	public static string Name = "UI_TopTournamentRankList";

	private List<Dictionary<string, object>> TopTournamentRankListData = new List<Dictionary<string, object>>();

	private const int FirstRank = 1;

	private const int SecondRank = 2;

	private const int ThirdRank = 3;

	private int myUserId;

	private LoadWebImageTaskQueue loadWebImageTaskQueue;

	public static string GetURL()
	{
		return "ui://82mo10n5t7wpdfo";
	}

	public static UI_TopTournamentRankList CreateInstance()
	{
		return (UI_TopTournamentRankList)(object)UIPackage.CreateObject("PvpSelectSoldiers", "TopTournamentRankList");
	}

	public static UI_TopTournamentRankList CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_TopTournamentRankList).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://82mo10n5t7wpdfo", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0035: Expected O, but got Unknown
		//IL_0041: Unknown result type (might be due to invalid IL or missing references)
		//IL_004b: Expected O, but got Unknown
		//IL_0057: Unknown result type (might be due to invalid IL or missing references)
		//IL_0061: Expected O, but got Unknown
		//IL_006d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0077: Expected O, but got Unknown
		//IL_0083: Unknown result type (might be due to invalid IL or missing references)
		//IL_008d: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		n11 = (GImage)((GComponent)this).GetChild("n11");
		n46 = (GImage)((GComponent)this).GetChild("n46");
		n47 = (GImage)((GComponent)this).GetChild("n47");
		n43 = (GImage)((GComponent)this).GetChild("n43");
		RankList = (GList)((GComponent)this).GetChild("RankList");
		tip = (GTextField)((GComponent)this).GetChild("tip");
		string id = "ui://82mo10n5t7wpdfo".Replace("ui://", "") + "-" + ((GObject)tip).id;
		((GObject)tip).text = LanguagesManager.GetDesc(id);
	}

	public async Task Init()
	{
		await GetTopTournamentRankListData();
	}

	private async Task GetTopTournamentRankListData()
	{
		Dictionary<int, string> _dayIndexData = RankDataHelper.GetTopTournamentLogDayIndex();
		if (_dayIndexData == null || _dayIndexData.Count <= 0)
		{
			RenderLastTurnTournamentRank();
			return;
		}
		GetPvPTopTournamentRankResponse response = await GameController.Contexts.Service<INetworkService>().GetPvPTopTournamentRankInfo();
		if (!response.Result)
		{
			ILRequestHelper.ShowErrorCode(response.ErrorCode);
			((GObject)tip).visible = true;
			return;
		}
		TopTournamentRankListData = response.TopTournamentRankListInfo;
		if (TopTournamentRankListData == null || TopTournamentRankListData.Count <= 0)
		{
			((GObject)tip).visible = true;
		}
		else
		{
			RenderRankList();
		}
	}

	private async void RenderLastTurnTournamentRank()
	{
		int currentTurnId = RankDataHelper.RankSeasonInfo.TurnId - RankDataHelper.RankSeasonInfo.Id * 10;
		bool isFirstTurn = currentTurnId <= 0;
		int lastTurnId = (isFirstTurn ? 3 : (currentTurnId - 1));
		int lastSeasonId = (isFirstTurn ? (RankDataHelper.RankSeasonInfo.Id - 1) : RankDataHelper.RankSeasonInfo.Id);
		GetPvPRankLastTurnResultResponse response = await GameController.Contexts.Service<INetworkService>().GetPvPRankLastTurnResult(lastSeasonId, lastTurnId);
		if (!response.Result)
		{
			ILRequestHelper.ShowErrorCode(response.ErrorCode);
			((GObject)tip).visible = true;
			return;
		}
		foreach (GetPvPRankLastTurnResultResponse.TopTournamentRankModel item in response.Data)
		{
			Dictionary<string, object> _rankData = new Dictionary<string, object>
			{
				{ "UserId", item.UserId },
				{ "Score", item.Score },
				{ "MaxCombatPower", item.MaxCombatPower }
			};
			TopTournamentRankListData.Add(_rankData);
		}
		if (TopTournamentRankListData == null || TopTournamentRankListData.Count <= 0)
		{
			((GObject)tip).visible = true;
		}
		else
		{
			RenderRankList();
		}
	}

	private void RenderRankList()
	{
		//IL_0056: Unknown result type (might be due to invalid IL or missing references)
		//IL_0060: Expected O, but got Unknown
		if (!((GObject)this).isDisposed)
		{
			loadWebImageTaskQueue?.Clear();
			loadWebImageTaskQueue = new LoadWebImageTaskQueue();
			myUserId = GameController.Contexts.gameState.user.value.UserId;
			RankList.itemRenderer = new ListItemRenderer(RenderScoreRank);
			RankList.numItems = TopTournamentRankListData.Count;
			loadWebImageTaskQueue?.Start();
		}
	}

	private void RenderScoreRank(int index, GObject obj)
	{
		UI_TopTournamentScoreRankInfo uI_TopTournamentScoreRankInfo = obj as UI_TopTournamentScoreRankInfo;
		Dictionary<string, object> dictionary = TopTournamentRankListData[index];
		int num = (int)dictionary["UserId"];
		int num2 = (int)dictionary["Score"];
		int num3 = (int)dictionary["MaxCombatPower"];
		int num4 = index + 1;
		switch (num4)
		{
		case 1:
			uI_TopTournamentScoreRankInfo.RankType.selectedIndex = 0;
			break;
		case 2:
			uI_TopTournamentScoreRankInfo.RankType.selectedIndex = 1;
			break;
		case 3:
			uI_TopTournamentScoreRankInfo.RankType.selectedIndex = 2;
			break;
		default:
			uI_TopTournamentScoreRankInfo.RankType.selectedIndex = 3;
			uI_TopTournamentScoreRankInfo.Rank.ShowRankLevel(num4);
			break;
		}
		if (num == myUserId)
		{
			uI_TopTournamentScoreRankInfo.SelfType.selectedIndex = 1;
		}
		else
		{
			uI_TopTournamentScoreRankInfo.SelfType.selectedIndex = 0;
		}
		((GObject)uI_TopTournamentScoreRankInfo.CombatPower).text = ((num3 < 0) ? ("[size=28]" + LanguagesManager.GetDesc("CsharpCodeZhTcText512") + "[/size]") : $"[size=33]{num3}[/size]");
		((GObject)uI_TopTournamentScoreRankInfo.TotalScore).text = $"{num2}";
		FGUIManager.Instance.GetUserMedal(num, uI_TopTournamentScoreRankInfo.medalList);
		loadWebImageTaskQueue?.AddTask(((MonoBehaviour)FGUIManager.Instance).StartCoroutine(FGUIManager.Instance.GetImageByWebRequestAndStorageWithoutFadeIn(Name, num, uI_TopTournamentScoreRankInfo.Avatar.HeadPortrait.icon, uI_TopTournamentScoreRankInfo.UserName)));
	}
}
