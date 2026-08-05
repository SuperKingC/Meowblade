using System.Collections.Generic;
using System.Linq;
using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;
using HotFix.Sources.Base.Scripts.UI;
using HotFix.Sources.Base.Scripts.UI.LoadWebImage;
using Shift.Legion.ClientApi.Protocol.UserAction;
using UnityEngine;

namespace UI.PvpSelectSoldiers;

public class UI_PvpScoreRankingListDialog : GComponent
{
	public GImage Background;

	public GImage n1;

	public GList ScoreRankingList;

	public const string URL = "ui://82mo10n5lt7m9e";

	public static string Name = "UI_PvpScoreRankingListDialog";

	private const int FirstRank = 1;

	private const int SecondRank = 2;

	private const int ThirdRank = 3;

	private int myUserId;

	private List<ScoreRankSummary> _scoreRankList = new List<ScoreRankSummary>();

	private LoadWebImageTaskQueue loadWebImageTaskQueue;

	public static string GetURL()
	{
		return "ui://82mo10n5lt7m9e";
	}

	public static UI_PvpScoreRankingListDialog CreateInstance()
	{
		return (UI_PvpScoreRankingListDialog)(object)UIPackage.CreateObject("PvpSelectSoldiers", "PvpScoreRankingListDialog");
	}

	public static UI_PvpScoreRankingListDialog CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_PvpScoreRankingListDialog).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://82mo10n5lt7m9e", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		((GComponent)this).ConstructFromXML(xml);
		Background = (GImage)((GComponent)this).GetChild("Background");
		n1 = (GImage)((GComponent)this).GetChild("n1");
		ScoreRankingList = (GList)((GComponent)this).GetChild("ScoreRankingList");
	}

	public void RenderScoreRankingList(List<ScoreRankSummary> scoreRankList)
	{
		//IL_007a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0084: Expected O, but got Unknown
		if (scoreRankList == null || scoreRankList.Count <= 0)
		{
			ScoreRankingList.numItems = 0;
			return;
		}
		loadWebImageTaskQueue?.Clear();
		loadWebImageTaskQueue = new LoadWebImageTaskQueue();
		_scoreRankList = scoreRankList;
		myUserId = GameController.Contexts.gameState.user.value.UserId;
		ScoreRankingList.itemRenderer = new ListItemRenderer(RenderScoreRank);
		ScoreRankingList.numItems = _scoreRankList.Count;
		loadWebImageTaskQueue?.Start();
	}

	private void RenderScoreRank(int index, GObject obj)
	{
		UI_PvpScoreRankInfo uI_PvpScoreRankInfo = obj as UI_PvpScoreRankInfo;
		ScoreRankSummary scoreRankSummary = _scoreRankList[index];
		int num = index + 1;
		switch (num)
		{
		case 1:
			uI_PvpScoreRankInfo.RankType.selectedIndex = 0;
			break;
		case 2:
			uI_PvpScoreRankInfo.RankType.selectedIndex = 1;
			break;
		case 3:
			uI_PvpScoreRankInfo.RankType.selectedIndex = 2;
			break;
		default:
			uI_PvpScoreRankInfo.RankType.selectedIndex = 3;
			uI_PvpScoreRankInfo.Rank.ShowRankLevel(num);
			break;
		}
		if (scoreRankSummary.UserId == myUserId)
		{
			uI_PvpScoreRankInfo.SelfType.selectedIndex = 1;
		}
		else
		{
			uI_PvpScoreRankInfo.SelfType.selectedIndex = 0;
		}
		((GObject)uI_PvpScoreRankInfo.CombatPower).text = $"{scoreRankSummary.CombatPower}";
		((GObject)uI_PvpScoreRankInfo.TotalScore).text = $"{scoreRankSummary.Score}";
		((GObject)uI_PvpScoreRankInfo.ScoreBonus).text = string.Format("[color=#178914]+{0}[/color]/{1}", RankDataHelper.GetRankScoreReward(scoreRankSummary.LadderRank)?.ToList()?[0].Value, LanguagesManager.GetDesc("CsharpCodeZhTcText248"));
		loadWebImageTaskQueue?.AddTask(((MonoBehaviour)FGUIManager.Instance).StartCoroutine(FGUIManager.Instance.GetImageByWebRequestAndStorageWithoutFadeIn(Name, scoreRankSummary.UserId, uI_PvpScoreRankInfo.Avatar.HeadPortrait.icon, uI_PvpScoreRankInfo.UserName)));
	}
}
