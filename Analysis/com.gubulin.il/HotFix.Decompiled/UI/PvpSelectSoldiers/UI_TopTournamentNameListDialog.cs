using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Assets.Scripts.Managers;
using Assets.Scripts.UI;
using FairyGUI;
using FairyGUI.Utils;
using HotFix.Sources.Base.Scripts.UI.LoadWebImage;
using Shift.Legion.ClientApi.Protocol.UserAction;
using Shift.Legion.Common.Services;
using UnityEngine;

namespace UI.PvpSelectSoldiers;

public class UI_TopTournamentNameListDialog : GComponent
{
	public Controller Type;

	public GImage Background;

	public GImage n13;

	public GImage n9;

	public GTextField CurrentDay;

	public GList ScoreRankingList;

	public GImage n14;

	public GTextField UserNum;

	public GTextField tip;

	public GTextField n15;

	public const string URL = "ui://82mo10n5aveldh5";

	public static string Name = "UI_TopTournamentNameListDialog";

	private List<Dictionary<string, object>> TopTournamentNameListData = new List<Dictionary<string, object>>();

	private const int MaxUserNum = 50;

	private const int FirstRank = 1;

	private const int SecondRank = 2;

	private const int ThirdRank = 3;

	private int myUserId;

	private LoadWebImageTaskQueue loadWebImageTaskQueue;

	public static string GetURL()
	{
		return "ui://82mo10n5aveldh5";
	}

	public static UI_TopTournamentNameListDialog CreateInstance()
	{
		return (UI_TopTournamentNameListDialog)(object)UIPackage.CreateObject("PvpSelectSoldiers", "TopTournamentNameListDialog");
	}

	public static UI_TopTournamentNameListDialog CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_TopTournamentNameListDialog).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://82mo10n5aveldh5", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		//IL_007e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0088: Expected O, but got Unknown
		//IL_0094: Unknown result type (might be due to invalid IL or missing references)
		//IL_009e: Expected O, but got Unknown
		//IL_00aa: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b4: Expected O, but got Unknown
		//IL_00c0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ca: Expected O, but got Unknown
		//IL_0113: Unknown result type (might be due to invalid IL or missing references)
		//IL_011d: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		Type = ((GComponent)this).GetController("Type");
		Background = (GImage)((GComponent)this).GetChild("Background");
		n13 = (GImage)((GComponent)this).GetChild("n13");
		n9 = (GImage)((GComponent)this).GetChild("n9");
		CurrentDay = (GTextField)((GComponent)this).GetChild("CurrentDay");
		ScoreRankingList = (GList)((GComponent)this).GetChild("ScoreRankingList");
		n14 = (GImage)((GComponent)this).GetChild("n14");
		UserNum = (GTextField)((GComponent)this).GetChild("UserNum");
		tip = (GTextField)((GComponent)this).GetChild("tip");
		string id = "ui://82mo10n5aveldh5".Replace("ui://", "") + "-" + ((GObject)tip).id;
		((GObject)tip).text = LanguagesManager.GetDesc(id);
		n15 = (GTextField)((GComponent)this).GetChild("n15");
		string id2 = "ui://82mo10n5aveldh5".Replace("ui://", "") + "-" + ((GObject)n15).id;
		((GObject)n15).text = LanguagesManager.GetDesc(id2);
	}

	public async Task Init()
	{
		await GetTopTournamentNameListData();
	}

	private async Task GetTopTournamentNameListData()
	{
		GetPvPTopTournamentPlayersInfoResponse response = await GameController.Contexts.Service<INetworkService>().GetPvPTopTournamentPlayersInfo();
		if (!response.Result)
		{
			ILRequestHelper.ShowErrorCode(response.ErrorCode);
			((GObject)UserNum).text = "";
			Type.selectedIndex = 1;
			return;
		}
		TopTournamentNameListData = response.TopTournamentNameListInfo;
		if (TopTournamentNameListData == null || TopTournamentNameListData.Count <= 0)
		{
			((GObject)UserNum).text = "";
			Type.selectedIndex = 1;
		}
		else
		{
			Type.selectedIndex = 0;
			RenderNameList();
		}
	}

	private void RenderNameList()
	{
		//IL_00a3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ad: Expected O, but got Unknown
		long num = GameController.Instance.GetServerTime() + 28800;
		DateTimeOffset dateTimeOffset = DateTimeHelper.ParseTimeStamp((int)num);
		((GObject)CurrentDay).text = UiHelper.GetDateStringMMdd(dateTimeOffset);
		((GObject)UserNum).text = $"{TopTournamentNameListData.Count}/{50}";
		loadWebImageTaskQueue?.Clear();
		loadWebImageTaskQueue = new LoadWebImageTaskQueue();
		myUserId = GameController.Contexts.gameState.user.value.UserId;
		ScoreRankingList.itemRenderer = new ListItemRenderer(RenderScoreRank);
		ScoreRankingList.numItems = TopTournamentNameListData.Count;
		loadWebImageTaskQueue?.Start();
	}

	private void RenderScoreRank(int index, GObject obj)
	{
		UI_TopTournamentUserInfo uI_TopTournamentUserInfo = obj as UI_TopTournamentUserInfo;
		Dictionary<string, object> dictionary = TopTournamentNameListData[index];
		int num = (int)dictionary["UserId"];
		int num2 = (int)dictionary["Score"];
		int num3 = (int)dictionary["MaxCombatPower"];
		int num4 = index + 1;
		switch (num4)
		{
		case 1:
			uI_TopTournamentUserInfo.RankType.selectedIndex = 0;
			break;
		case 2:
			uI_TopTournamentUserInfo.RankType.selectedIndex = 1;
			break;
		case 3:
			uI_TopTournamentUserInfo.RankType.selectedIndex = 2;
			break;
		default:
			uI_TopTournamentUserInfo.RankType.selectedIndex = 3;
			uI_TopTournamentUserInfo.Rank.ShowRankLevel(num4);
			break;
		}
		uI_TopTournamentUserInfo.SelfType.selectedIndex = ((num == myUserId) ? 1 : 0);
		uI_TopTournamentUserInfo.HighlyStyle.SetSelectedIndex(0);
		((GObject)uI_TopTournamentUserInfo.CombatPower).text = ((num3 < 0) ? ("[size=28]" + LanguagesManager.GetDesc("CsharpCodeZhTcText512") + "[/size]") : $"[size=33]{num3}[/size]");
		((GObject)uI_TopTournamentUserInfo.TotalScore).visible = false;
		((GObject)uI_TopTournamentUserInfo.Help).visible = false;
		((GObject)uI_TopTournamentUserInfo.n24).visible = false;
		FGUIManager.Instance.GetUserMedal(num, uI_TopTournamentUserInfo.medalList);
		loadWebImageTaskQueue?.AddTask(((MonoBehaviour)FGUIManager.Instance).StartCoroutine(FGUIManager.Instance.GetImageByWebRequestAndStorageWithoutFadeIn(Name, num, uI_TopTournamentUserInfo.Avatar.HeadPortrait.icon, uI_TopTournamentUserInfo.UserName)));
	}
}
