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
using HotFix;
using HotFix.Sources.Base.Scripts.UI;
using HotFix.Sources.Shift.Legion.Shift.Legion.Common.Models.Sources;
using Shift.Legion.ClientApi.Protocol.UserAction;
using Shift.Legion.Common.Services;
using UnityEngine;

namespace UI.PvpSelectSoldiers;

public class UI_PvpTotalRankingListDialog : GComponent
{
	public GImage Background;

	public GImage n6;

	public GList TotalRankingList;

	public UI_TotalRankFilter TotalRankFilter;

	public UI_MyTotalRank MyTotalRank;

	public const string URL = "ui://82mo10n5lt7m9r";

	public static string Name = "UI_PvpTotalRankingListDialog";

	private const string ScoreColor = "#178914";

	private const string NpcIconUrl = "ui://PvpSelectSoldiers/Clap1_filled";

	private const int NickNameMaxLength = 14;

	private List<string> characters = new List<string>
	{
		LanguagesManager.GetDesc("CsharpCodeZhTcText456"),
		LanguagesManager.GetDesc("CsharpCodeZhTcText457"),
		LanguagesManager.GetDesc("CsharpCodeZhTcText458"),
		LanguagesManager.GetDesc("CsharpCodeZhTcText459"),
		LanguagesManager.GetDesc("CsharpCodeZhTcText460"),
		LanguagesManager.GetDesc("CsharpCodeZhTcText461"),
		LanguagesManager.GetDesc("CsharpCodeZhTcText462"),
		LanguagesManager.GetDesc("CsharpCodeZhTcText463"),
		LanguagesManager.GetDesc("CsharpCodeZhTcText464"),
		LanguagesManager.GetDesc("CsharpCodeZhTcText465")
	};

	private bool filterNpc;

	private int myUserId;

	private List<SimpleRankSummary> simpleRankList = new List<SimpleRankSummary>();

	private List<SimpleRankSummary> simpleRankUserList = new List<SimpleRankSummary>();

	public Dictionary<int, AvatarAndNameCache> AvatarAndNameCachingMap = new Dictionary<int, AvatarAndNameCache>();

	private int myRankLocationInTotalRank = -1;

	private int myRankLocationInUserRank = -1;

	private string NpcName => LanguagesManager.GetDesc("CsharpCodeZhTcText51");

	public static string GetURL()
	{
		return "ui://82mo10n5lt7m9r";
	}

	public static UI_PvpTotalRankingListDialog CreateInstance()
	{
		return (UI_PvpTotalRankingListDialog)(object)UIPackage.CreateObject("PvpSelectSoldiers", "PvpTotalRankingListDialog");
	}

	public static UI_PvpTotalRankingListDialog CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_PvpTotalRankingListDialog).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://82mo10n5lt7m9r", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		n6 = (GImage)((GComponent)this).GetChild("n6");
		TotalRankingList = (GList)((GComponent)this).GetChild("TotalRankingList");
		TotalRankFilter = (UI_TotalRankFilter)(object)((GComponent)this).GetChild("TotalRankFilter");
		MyTotalRank = (UI_MyTotalRank)(object)((GComponent)this).GetChild("MyTotalRank");
	}

	private void RenderRankList(List<SimpleRankSummary> _rankSummaries)
	{
		//IL_0062: Unknown result type (might be due to invalid IL or missing references)
		//IL_006c: Expected O, but got Unknown
		if (_rankSummaries == null || _rankSummaries.Count <= 0)
		{
			TotalRankingList.numItems = 0;
			return;
		}
		UI_PvpTotalRankListPanel.PvpTotalRankListPanel?.ClearLoadAvatarQueue();
		UI_PvpTotalRankListPanel.PvpTotalRankListPanel?.CreateLoadAvatarQueue();
		TotalRankingList.SetVirtual();
		TotalRankingList.itemRenderer = new ListItemRenderer(RenderRank);
		TotalRankingList.numItems = _rankSummaries.Count;
	}

	private void RenderRank(int index, GObject obj)
	{
		//IL_023f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0244: Unknown result type (might be due to invalid IL or missing references)
		//IL_0202: Unknown result type (might be due to invalid IL or missing references)
		//IL_0207: Unknown result type (might be due to invalid IL or missing references)
		SimpleRankSummary simpleRankSummary = (filterNpc ? simpleRankUserList[index] : simpleRankList[index]);
		if (!(obj is UI_PvpTotalRankInfo uI_PvpTotalRankInfo) || (((GObject)uI_PvpTotalRankInfo).data is SimpleRankSummary simpleRankSummary2 && simpleRankSummary2.Rank == simpleRankSummary.Rank && simpleRankSummary2.UserId == simpleRankSummary.UserId))
		{
			return;
		}
		SimpleRankSummary simpleRankSummary3 = (SimpleRankSummary)(((GObject)uI_PvpTotalRankInfo).data = simpleRankSummary);
		((GObject)uI_PvpTotalRankInfo.CombatPower).text = $"{simpleRankSummary.CombatPower}";
		int rank = ((simpleRankSummary.Rank >= 1 && simpleRankSummary.Rank <= 800) ? simpleRankSummary.Rank : 0);
		((GObject)uI_PvpTotalRankInfo.ScoreBonus).text = string.Format("[color={0}]+{1}[/color]/{2}", "#178914", RankDataHelper.GetRankScoreReward(rank)?.ToList()?[0].Value, LanguagesManager.GetDesc("CsharpCodeZhTcText248"));
		uI_PvpTotalRankInfo.SelfType.selectedIndex = ((simpleRankSummary.UserId == myUserId) ? 1 : 0);
		uI_PvpTotalRankInfo.Rank.ShowRankLevel(simpleRankSummary.Rank);
		((GObject)uI_PvpTotalRankInfo.Layer).text = GetFloor(simpleRankSummary.Rank);
		if (simpleRankSummary3.UserId < 1)
		{
			uI_PvpTotalRankInfo.Avatar.HeadPortrait.Type.selectedIndex = 1;
			uI_PvpTotalRankInfo.Avatar.HeadPortrait.icon.url = RankDataHelper.GetNpcIconName(((SimpleRankSummary)((GObject)uI_PvpTotalRankInfo).data).Rank);
			((GObject)uI_PvpTotalRankInfo.UserName).text = FGUIManager.Instance.TruncateTextLength(LanguagesManager.GetDesc("CsharpCodeZhTcText51"), 14);
			uI_PvpTotalRankInfo.UserName.color = Color32.op_Implicit(new Color32((byte)60, (byte)179, (byte)113, byte.MaxValue));
			return;
		}
		uI_PvpTotalRankInfo.Avatar.HeadPortrait.Type.selectedIndex = 0;
		uI_PvpTotalRankInfo.UserName.color = Color32.op_Implicit(new Color32((byte)124, (byte)75, (byte)42, byte.MaxValue));
		if (!AvatarAndNameCachingMap.TryGetValue(simpleRankSummary.UserId, out var value))
		{
			value = new AvatarAndNameCache
			{
				CachingStatus = eCachingStatus.NoCache
			};
			AvatarAndNameCachingMap[simpleRankSummary.UserId] = value;
		}
		if (value.CachingStatus == eCachingStatus.NoCache)
		{
			value.CachingStatus = eCachingStatus.Caching;
			uI_PvpTotalRankInfo.Avatar.HeadPortrait.icon.url = "ui://PublicResources/avatar_player_default";
			((GObject)uI_PvpTotalRankInfo.UserName).text = string.Empty;
			((MonoBehaviour)FGUIManager.Instance).StartCoroutine(GetPvpUserAvatarAndNameForUiPvpTotalRankInfo(index, simpleRankSummary.UserId, uI_PvpTotalRankInfo));
		}
		else if (value.CachingStatus == eCachingStatus.Cached)
		{
			uI_PvpTotalRankInfo.Avatar.HeadPortrait.icon.texture = value.AvatarTexture;
			((GObject)uI_PvpTotalRankInfo.UserName).text = FGUIManager.Instance.TruncateTextLength(value.Nickname, 14);
		}
	}

	private IEnumerator GetPvpUserAvatarAndNameForUiPvpTotalRankInfo(int rankListItemIndex, int userId, UI_PvpTotalRankInfo uiPvpTotalRankInfo)
	{
		yield return ((MonoBehaviour)FGUIManager.Instance).StartCoroutine(GetPvpUserAvatarAndName(userId));
		if (!((GObject)this).isDisposed && uiPvpTotalRankInfo != null && !((GObject)uiPvpTotalRankInfo).isDisposed)
		{
			int rankListChildIndex = TotalRankingList.ItemIndexToChildIndex(rankListItemIndex);
			if (rankListChildIndex >= 0 && rankListChildIndex < ((GComponent)TotalRankingList).numChildren && AvatarAndNameCachingMap.TryGetValue(userId, out var avatarAndName))
			{
				uiPvpTotalRankInfo.Avatar.HeadPortrait.icon.texture = avatarAndName.AvatarTexture;
				((GObject)uiPvpTotalRankInfo.UserName).text = FGUIManager.Instance.TruncateTextLength(avatarAndName.Nickname, 14);
			}
		}
	}

	private IEnumerator GetPvpUserAvatarAndName(int userId)
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
				if (((GObject)this).isDisposed)
				{
					yield break;
				}
			}
			CoroutineWithData cd = new CoroutineWithData((MonoBehaviour)(object)FGUIManager.Instance, HotFix_Utils.getTextureByPath(pngPath));
			yield return cd.Coroutine;
			if (((GObject)this).isDisposed)
			{
				yield break;
			}
			if (cd.Result != null)
			{
				avatarAndName.AvatarTexture = new NTexture((Texture)(Texture2D)cd.Result);
			}
			avatarAndName.Nickname = GameController.Contexts.gameState.user.value.Nickname;
			avatarAndName.CachingStatus = eCachingStatus.Cached;
		}
		else if (userId > 0)
		{
			GameLocalDataManager.UserLocalData userLocalData = GameLocalDataManager.GetSomeUserLocalData(userId);
			if (userLocalData == null)
			{
				yield return ((MonoBehaviour)FGUIManager.Instance).StartCoroutine(FGUIManager.Instance.EnsurePVPAvatarExist(userId));
				if (((GObject)this).isDisposed)
				{
					yield break;
				}
				userLocalData = GameLocalDataManager.GetSomeUserLocalData(userId);
			}
			CoroutineWithData cd2 = new CoroutineWithData(target: HotFix_Utils.getTextureByPath(UiHelper.GetUserAvatarLocalPath(userId.ToString())), owner: (MonoBehaviour)(object)FGUIManager.Instance);
			yield return cd2.Coroutine;
			if (((GObject)this).isDisposed)
			{
				yield break;
			}
			if (cd2.Result != null)
			{
				avatarAndName.AvatarTexture = new NTexture((Texture)(Texture2D)cd2.Result);
			}
			avatarAndName.Nickname = userLocalData.NickName;
			avatarAndName.CachingStatus = eCachingStatus.Cached;
		}
		AvatarAndNameCachingMap[userId] = avatarAndName;
	}

	private void CheckMyRank(EventContext context)
	{
		UI_PvpTotalRankListPanel.PvpTotalRankListPanel?.ClearLoadAvatarQueue();
		UI_PvpTotalRankListPanel.PvpTotalRankListPanel?.CreateLoadAvatarQueue();
		int num = (filterNpc ? myRankLocationInUserRank : myRankLocationInTotalRank);
		int num2 = ((num - 2 >= 0) ? (num - 2) : 0);
		TotalRankingList.ScrollToView(num2, false, true);
		UI_PvpTotalRankListPanel.PvpTotalRankListPanel?.loadAvatarQueue?.Start();
	}

	private void FilterNpc(EventContext context)
	{
		filterNpc = ((GButton)TotalRankFilter).selected;
		if (filterNpc)
		{
			RenderRankList(simpleRankUserList);
		}
		else
		{
			RenderRankList(simpleRankList);
		}
	}

	public void GetPvpTotalRank()
	{
		List<SimpleRankSummary> simpleRankingList = GameLocalDataManager.GetSimpleRankingList();
		if (simpleRankingList != null)
		{
			MainUiInit(simpleRankingList);
			return;
		}
		ILRequestHelper<GetSimplePvPRankListResponse>.Request((EventContext)null, (Func<Task<GetSimplePvPRankListResponse>>)(() => GameController.Contexts.Service<INetworkService>().GetSimplePvPRank(-1L)), (Action<GetSimplePvPRankListResponse>)delegate(GetSimplePvPRankListResponse response)
		{
			if (!response.Result)
			{
				ILRequestHelper.ShowErrorCode(response.ErrorCode);
			}
			else if (response.SimpleRankList != null)
			{
				GameLocalDataManager.SetSimpleRankingList(response.SimpleRankList, response.ExpiredAt);
				MainUiInit(response.SimpleRankList);
			}
		});
	}

	private void MainUiInit(List<SimpleRankSummary> rawData)
	{
		//IL_0051: Unknown result type (might be due to invalid IL or missing references)
		//IL_005b: Expected O, but got Unknown
		//IL_006e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0078: Expected O, but got Unknown
		DataHandle(rawData);
		if (AvatarAndNameCachingMap == null)
		{
			AvatarAndNameCachingMap = new Dictionary<int, AvatarAndNameCache>();
		}
		if (myRankLocationInTotalRank < 0)
		{
			((GObject)MyTotalRank).enabled = false;
		}
		((GObject)MyTotalRank).onClick.Set(new EventCallback1(CheckMyRank));
		((GButton)TotalRankFilter).onChanged.Set(new EventCallback1(FilterNpc));
		RenderRankList(simpleRankList);
	}

	private string GetFloor(int rank)
	{
		int rangeIndex = ((rank % 100 == 0) ? (rank / 100) : (rank / 100 + 1));
		return RankDataHelper.GetPvpRankRangeText(rangeIndex) ?? "";
	}

	private void DataHandle(List<SimpleRankSummary> rawData)
	{
		simpleRankList.Clear();
		simpleRankUserList.Clear();
		myUserId = GameController.Contexts.gameState.user.value.UserId;
		simpleRankList = rawData;
		for (int i = 0; i < rawData.Count; i++)
		{
			if (rawData[i].UserId != 0)
			{
				simpleRankUserList.Add(rawData[i]);
			}
			if (rawData[i].UserId == myUserId)
			{
				myRankLocationInTotalRank = i;
				myRankLocationInUserRank = simpleRankUserList.Count - 1;
			}
		}
	}
}
