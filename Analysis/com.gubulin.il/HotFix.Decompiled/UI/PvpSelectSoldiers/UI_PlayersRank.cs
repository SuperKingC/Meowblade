using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Assets.Scripts.Managers;
using Assets.Scripts.UI;
using FairyGUI;
using FairyGUI.Utils;
using HotFix.Sources.Base.Scripts.UI;
using HotFix.Sources.Base.Scripts.UI.LoadWebImage;
using Shift.Legion.ClientApi.Protocol.UserAction;
using Shift.Legion.Common.Managers;
using Shift.Legion.Common.Services;
using UI.Tips;
using UnityEngine;

namespace UI.PvpSelectSoldiers;

public class UI_PlayersRank : GComponent
{
	public GList PlayersArmys;

	public const string URL = "ui://82mo10n5js4q6u";

	public static string Name = "UI_PlayersRank";

	private List<RankSummary> challengeSummaries = new List<RankSummary>();

	private int myRank;

	private const string ScoreColor = "#178914";

	private const string NpcIconUrl = "ui://PvpSelectSoldiers/Clap1_filled";

	private LoadWebImageTaskQueue loadWebImageTaskQueue;

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

	private Dictionary<string, Coroutine> rankBattleCd = new Dictionary<string, Coroutine>();

	private string NpcName => LanguagesManager.GetDesc("CsharpCodeZhTcText51");

	public static string GetURL()
	{
		return "ui://82mo10n5js4q6u";
	}

	public static UI_PlayersRank CreateInstance()
	{
		return (UI_PlayersRank)(object)UIPackage.CreateObject("PvpSelectSoldiers", "PlayersRank");
	}

	public static UI_PlayersRank CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_PlayersRank).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://82mo10n5js4q6u", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		PlayersArmys = (GList)((GComponent)this).GetChild("PlayersArmys");
	}

	public void Init(List<RankSummary> challenge, int _myRank)
	{
		if (challenge != null && challenge.Count > 0)
		{
			challengeSummaries = challenge;
			myRank = _myRank;
			RenderPlayersArmy();
		}
	}

	public void Update(List<RankSummary> challenge, int _myRank)
	{
		if (challenge != null && challenge.Count > 0)
		{
			challengeSummaries = challenge;
			myRank = _myRank;
			RenderPlayersArmy();
		}
	}

	private void RenderPlayersArmy()
	{
		//IL_0069: Unknown result type (might be due to invalid IL or missing references)
		//IL_0073: Expected O, but got Unknown
		if (PlayersArmys != null && !((GObject)PlayersArmys).isDisposed)
		{
			PlayersArmys.numItems = 0;
			loadWebImageTaskQueue?.Clear();
			loadWebImageTaskQueue = new LoadWebImageTaskQueue();
			FGUIManager.Instance.ClearCache_SoliderSoulStone();
			ClearRankBattleCd();
			PlayersArmys.itemRenderer = new ListItemRenderer(RenderArmy);
			PlayersArmys.numItems = challengeSummaries.Count;
			loadWebImageTaskQueue?.Start();
			if (PlayersArmys.numItems > 0)
			{
				PlayersArmys.ScrollToView(0);
			}
		}
	}

	private string GetFloor(int rank, out int layerIndex)
	{
		return RankDataHelper.GetPvpRankRangeText(layerIndex = ((rank % 100 == 0) ? (rank / 100) : (rank / 100 + 1))) ?? "";
	}

	private void RenderArmy(int index, GObject obj)
	{
		//IL_0183: Unknown result type (might be due to invalid IL or missing references)
		//IL_0188: Unknown result type (might be due to invalid IL or missing references)
		//IL_006f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0074: Unknown result type (might be due to invalid IL or missing references)
		//IL_0414: Unknown result type (might be due to invalid IL or missing references)
		//IL_041e: Expected O, but got Unknown
		//IL_0431: Unknown result type (might be due to invalid IL or missing references)
		//IL_043b: Expected O, but got Unknown
		if (obj is UI_PlayerRankInfo uI_PlayerRankInfo)
		{
			RankSummary summary = challengeSummaries[index];
			uI_PlayerRankInfo.Avatar.Type.selectedIndex = 1;
			if (summary.UserId != 0)
			{
				uI_PlayerRankInfo.PlayerName.color = Color32.op_Implicit(new Color32((byte)124, (byte)75, (byte)42, byte.MaxValue));
				uI_PlayerRankInfo.Avatar.HeadPortrait.Type.selectedIndex = 0;
				Coroutine work = ((MonoBehaviour)FGUIManager.Instance).StartCoroutine(FGUIManager.Instance.GetImageByWebRequestAndStorageWithoutFadeIn(Name, summary.UserId, uI_PlayerRankInfo.Avatar.HeadPortrait.icon, uI_PlayerRankInfo.PlayerName));
				loadWebImageTaskQueue?.AddTask(work);
				FGUIManager.Instance.GetUserMedal(summary.UserId, uI_PlayerRankInfo.medalList, uI_PlayerRankInfo.isShowMedal);
			}
			else
			{
				uI_PlayerRankInfo.isShowMedal.SetSelectedIndex(0);
				uI_PlayerRankInfo.Avatar.HeadPortrait.Type.selectedIndex = 1;
				uI_PlayerRankInfo.Avatar.HeadPortrait.icon.url = RankDataHelper.GetNpcIconName(summary.Rank);
				((GObject)uI_PlayerRankInfo.PlayerName).text = NpcName;
				uI_PlayerRankInfo.PlayerName.color = Color32.op_Implicit(new Color32((byte)60, (byte)179, (byte)113, byte.MaxValue));
			}
			((GObject)uI_PlayerRankInfo.LegionCombatPower).text = $"{summary.CombatPower}";
			int rank = ((summary.Rank >= 1 && summary.Rank <= 800) ? summary.Rank : 0);
			((GObject)uI_PlayerRankInfo.ScoreIncome).text = string.Format("[color={0}]+{1}[/color]/{2}", "#178914", RankDataHelper.GetRankScoreReward(rank)?.ToList()?[0].Value, LanguagesManager.GetDesc("CsharpCodeZhTcText248"));
			((GObject)uI_PlayerRankInfo.Layer).text = GetFloor(summary.Rank, out var layerIndex);
			uI_PlayerRankInfo.Rank.ShowRankLevel(summary.Rank);
			uI_PlayerRankInfo.enemy.RemoveChildrenToPool();
			for (int i = 0; i < summary.SoldierInfoList.Count; i++)
			{
				string soldierId = summary.SoldierInfoList[i].SoldierId;
				int potentialLevel = summary.SoldierInfoList[i].PotentialLevel;
				int level = summary.SoldierInfoList[i].Level;
				int qty = summary.SoldierInfoList[i].Qty;
				UI_enemyItem obj2 = uI_PlayerRankInfo.enemy.AddItemFromPool() as UI_enemyItem;
				RenderSoldier(obj2, soldierId, potentialLevel, level, qty);
			}
			((GObject)uI_PlayerRankInfo.CdTime).text = "";
			PreparationTimeInit(summary, uI_PlayerRankInfo.CdTime);
			((GObject)uI_PlayerRankInfo.WaveNumber).text = $"{summary.FormationsCnt}";
			((GObject)uI_PlayerRankInfo.lockTip).visible = layerIndex < RankDataHelper.UnlockedBlocks;
			int num = ((myRank < 1 || myRank > 800) ? 801 : myRank);
			uI_PlayerRankInfo.Capture.Type.selectedIndex = ((summary.Rank >= num) ? 1 : 0);
			((GObject)uI_PlayerRankInfo.Capture).data = summary;
			((GObject)uI_PlayerRankInfo.Capture).onClick.Set(new EventCallback1(CaptureClickEvent));
			((GObject)uI_PlayerRankInfo.Avatar).onClick.Set((EventCallback0)delegate
			{
				FGUIManager.Instance.OpenForumUserProfilePage(summary.UserId);
			});
		}
	}

	private void ClearRankBattleCd()
	{
		foreach (KeyValuePair<string, Coroutine> item in rankBattleCd)
		{
			if (item.Value != null)
			{
				((MonoBehaviour)FGUIManager.Instance).StopCoroutine(item.Value);
			}
		}
		rankBattleCd.Clear();
	}

	private void AddRankBattleCd(int targetId, Coroutine _coroutine)
	{
		if (rankBattleCd.ContainsKey(targetId.ToString()))
		{
			rankBattleCd[targetId.ToString()] = _coroutine;
		}
		else
		{
			rankBattleCd.Add(targetId.ToString(), _coroutine);
		}
	}

	private void PreparationTimeInit(RankSummary aimRankInfo, GTextField textField)
	{
		int targetId = ((aimRankInfo.UserId == 0) ? (-1 * aimRankInfo.Rank) : aimRankInfo.UserId);
		int pvpRankProgressCdFinishAt = RankDataHelper.GetPvpRankProgressCdFinishAt(targetId.ToString());
		if (pvpRankProgressCdFinishAt > 0)
		{
			((GObject)textField).visible = true;
			Coroutine coroutine = FGUIManager.Instance.OpenIEnumerator(RenderRankBattleCd(targetId, textField));
			AddRankBattleCd(targetId, coroutine);
		}
	}

	private IEnumerator RenderRankBattleCd(int targetId, GTextField textField)
	{
		int curRankBattleCd = RankDataHelper.GetPvpRankProgressCdFinishAt(targetId.ToString());
		if (curRankBattleCd < 0 || ((GObject)textField).isDisposed)
		{
			if (!((GObject)textField).isDisposed)
			{
				((GObject)textField).visible = false;
			}
		}
		else if (!((GObject)textField).isDisposed)
		{
			yield return (object)new WaitForSeconds(1f);
			((GObject)textField).text = UiHelper.ParseTime(curRankBattleCd) ?? "";
			AddRankBattleCd(_coroutine: FGUIManager.Instance.OpenIEnumerator(RenderRankBattleCd(targetId, textField)), targetId: targetId);
		}
	}

	private void RenderSoldier(UI_enemyItem obj, string soldierId, int _potentialLevel, int _level, int _qty)
	{
		int num = (_potentialLevel + 2) / 2;
		if (_potentialLevel == 9)
		{
			num = 6;
		}
		string text = $"{GameManagers.Instance.SoldierManager.Get(soldierId).ItemId}_{num}";
		obj.icon.url = "ui://PublicResources/" + text;
		((GObject)obj.lv).text = $"{_level}";
		string iconFrameBorderSoldier = UiHelper.GetIconFrameBorderSoldier(_potentialLevel);
		obj.iconFrame.url = "ui://PublicResources/" + iconFrameBorderSoldier;
		obj.lvFrame.url = UiHelper.GetLevelFrameBorderSoldier(_potentialLevel);
		((GObject)obj.num).text = $"{_qty}";
		UiHelper.LoadSoldierIconFrameMaterial(((GObject)obj.iconFrame).asLoader, _potentialLevel);
		FGUIManager.Instance.SetAlightSoulStoneForSoldierIcon(obj.SoulStoneLevel, _potentialLevel, null);
	}

	private void CaptureClickEvent(EventContext context)
	{
		//IL_0014: Unknown result type (might be due to invalid IL or missing references)
		object data = ((GObject)context.sender).data;
		if (data == null)
		{
			return;
		}
		RankSummary aimRankData = (RankSummary)data;
		ILRequestHelper<GetDetailRankInfoResponse>.Request((EventContext)null, (Func<Task<GetDetailRankInfoResponse>>)(() => GameController.Contexts.Service<INetworkService>().GetDetailRankInfo(-1L, aimRankData.Rank, aimRankData.LastBattleFinishAt)), (Action<GetDetailRankInfoResponse>)delegate(GetDetailRankInfoResponse response)
		{
			if (10039003 == response.ErrorCode)
			{
				string desc = LanguagesManager.GetDesc("ErrorCode_" + response.ErrorCode);
				UnityUiService.Instance.OpenPanel(UI_UniversalConfirmPopup.Name, new Dictionary<string, object>
				{
					{ "Content", desc },
					{
						"Buttons",
						new Dictionary<string, Action> { 
						{
							"Confirm",
							delegate
							{
								UI_LadderTournamentPanel.LadderTournamentPanel?.UpdatePanel();
							}
						} }
					},
					{ "PageIndex", 4 },
					{ "ClickSound", "Confirm" },
					{ "Order", 999999 }
				}, multiMode: false, ignoreQueue: true);
			}
			else if (!response.Result)
			{
				ILRequestHelper.ShowErrorCode(response.ErrorCode);
			}
			else
			{
				RankRecord enemyRankRecord = response.EnemyRankRecord;
				Dictionary<string, object> parameters = new Dictionary<string, object>
				{
					{ "MyRank", myRank },
					{ "EnemyRankData", aimRankData },
					{ "EnemyRankDetailInfo", enemyRankRecord }
				};
				if (enemyRankRecord == null)
				{
					List<string> arg = new List<string> { "rankBattleConfig is null" };
					SharedMessenger.Broadcast("SHOW_TIPS", arg, 1, arg3: false);
				}
				else
				{
					GameController.Contexts.Service<IUiService>().OpenPanel(UI_PvpSelectSoldiersPanel.Name, parameters);
				}
			}
		});
	}
}
