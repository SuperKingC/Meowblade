using System.Collections.Generic;
using System.Linq;
using Assets.Scripts.Managers;
using Assets.Scripts.UI;
using FairyGUI;
using FairyGUI.Utils;
using GvG2;
using Shift.Legion.ClientApi.Models;
using Shift.Legion.ClientApi.Protocol;
using Shift.Legion.Common.Helpers;
using Shift.Legion.Common.Managers;
using Shift.Legion.Common.Services;
using Shift.Legion.GvG.Common.Models;
using UI.GameEndPanels;
using UI.GvGWorldMap2;
using UI.GvGWorldMapRecord2;
using UnityEngine;

namespace UI.IslandComeAgain;

public class UI_IslandComeAgainBattleResultPanel : GComponent, IUiController
{
	public class ScoreInfo
	{
		public int UserId;

		public GvGMode2ScoreInfo Score;
	}

	public Controller Type;

	public GGraph Mask;

	public UI_mc_settlement_0 WinnerLogo;

	public UI_CampBattleInfo RedCampInfo;

	public UI_CampBattleInfo BlueCampInfo;

	public UI_CampBattleInfo YellowCampInfo;

	public UI_CampBattleInfo GreenCampInfo;

	public UI_BattleRecord BattleRecord;

	public UI_MyBattleRecordInfo MyBattleRecordInfo;

	public UI_Confirm Confirm;

	public GTextField n17;

	public Transition t0;

	public const string URL = "ui://k2sprg26uctj7j";

	public static string Name = "UI_IslandComeAgainBattleResultPanel";

	private int myUserId;

	private int winner;

	private int myRank;

	private GvGMode2IZResult battleResult;

	private GvGMode2ScoreInfo myBattleResult;

	private Dictionary<int, Dictionary<int, GvGMode2ScoreInfo>> campBattleResult = new Dictionary<int, Dictionary<int, GvGMode2ScoreInfo>>();

	private Dictionary<int, List<ScoreInfo>> campBattleResultSort = new Dictionary<int, List<ScoreInfo>>();

	public static string GetURL()
	{
		return "ui://k2sprg26uctj7j";
	}

	public static UI_IslandComeAgainBattleResultPanel CreateInstance()
	{
		return (UI_IslandComeAgainBattleResultPanel)(object)UIPackage.CreateObject("IslandComeAgain", "IslandComeAgainBattleResultPanel");
	}

	public static UI_IslandComeAgainBattleResultPanel CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_IslandComeAgainBattleResultPanel).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://k2sprg26uctj7j", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Expected O, but got Unknown
		//IL_00ec: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f6: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		Type = ((GComponent)this).GetController("Type");
		Mask = (GGraph)((GComponent)this).GetChild("Mask");
		WinnerLogo = (UI_mc_settlement_0)(object)((GComponent)this).GetChild("WinnerLogo");
		RedCampInfo = (UI_CampBattleInfo)(object)((GComponent)this).GetChild("RedCampInfo");
		BlueCampInfo = (UI_CampBattleInfo)(object)((GComponent)this).GetChild("BlueCampInfo");
		YellowCampInfo = (UI_CampBattleInfo)(object)((GComponent)this).GetChild("YellowCampInfo");
		GreenCampInfo = (UI_CampBattleInfo)(object)((GComponent)this).GetChild("GreenCampInfo");
		BattleRecord = (UI_BattleRecord)(object)((GComponent)this).GetChild("BattleRecord");
		MyBattleRecordInfo = (UI_MyBattleRecordInfo)(object)((GComponent)this).GetChild("MyBattleRecordInfo");
		Confirm = (UI_Confirm)(object)((GComponent)this).GetChild("Confirm");
		n17 = (GTextField)((GComponent)this).GetChild("n17");
		string id = "ui://k2sprg26uctj7j".Replace("ui://", "") + "-" + ((GObject)n17).id;
		((GObject)n17).text = LanguagesManager.GetDesc(id);
		t0 = ((GComponent)this).GetTransition("t0");
	}

	public void BeforeDestroy()
	{
	}

	public void Destroy()
	{
	}

	public void Init(Dictionary<string, object> parameters)
	{
		SocketManager.Instance.GetConnection(eConType.GvGMode2Island).CloseConnect();
		FGUIManager.SetUiPanelSizeAndXy((GObject)(object)this, scaleAdaption: true);
		if (parameters.TryGetValue("BattleResult", out var value))
		{
			battleResult = value as GvGMode2IZResult;
		}
		GetBattleResult();
		RenderMyBattleResult();
		RenderAllCampBattleResult();
	}

	public void OnShow()
	{
		if (GameController.Contexts.Service<IUiService>().HasShowingUi(UI_DamageMeter.Name))
		{
			((GObject)((GObject)this).parent).visible = false;
		}
		ShowTransition();
	}

	public void RegisterUiEventListeners()
	{
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_001d: Expected O, but got Unknown
		//IL_0030: Unknown result type (might be due to invalid IL or missing references)
		//IL_003a: Expected O, but got Unknown
		((GObject)Confirm).onClick.Add(new EventCallback0(End));
		((GObject)BattleRecord).onClick.Add(new EventCallback0(OpenBattleRecord));
	}

	public void UnregisterUiEventListeners()
	{
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_001d: Expected O, but got Unknown
		//IL_0030: Unknown result type (might be due to invalid IL or missing references)
		//IL_003a: Expected O, but got Unknown
		((GObject)Confirm).onClick.Remove(new EventCallback0(End));
		((GObject)BattleRecord).onClick.Remove(new EventCallback0(OpenBattleRecord));
	}

	public void End()
	{
		Singleton<GvGInstanceZone>.Instance.SyncProduce();
		GameController.Contexts.Service<IUiService>().ClosePanel(UI_GvGWorldMap2.Name, reservePackageRes: true);
		GvGIslandController.ReleaseInstance();
		GvGWorldMapController.ReleaseInstance();
		GameController.Contexts.Service<IUiService>().ClosePanel(Name);
	}

	private void ShowTransition()
	{
		//IL_0037: Unknown result type (might be due to invalid IL or missing references)
		//IL_0041: Expected O, but got Unknown
		WinnerLogo.Type.selectedIndex = battleResult.WinnerOder[0] - 1;
		((GComponent)(object)this).SetTimeout(0.75f).OnComplete((GTweenCallback)delegate
		{
			Type.selectedIndex = 1;
			WinnerLogo.Title.selectedIndex = 1;
		});
	}

	private void RenderMyBattleResult()
	{
		MyBattleRecordInfo.Type.selectedIndex = myBattleResult.CampId - 1;
		((GObject)MyBattleRecordInfo.MyRank).text = $"{myRank}";
		((GObject)MyBattleRecordInfo.BestMultiKill).text = myBattleResult.BestKillCount.ToString();
		((GObject)MyBattleRecordInfo.Reward).text = myBattleResult.FinalScore.ToString();
		((GObject)MyBattleRecordInfo.TotalKill).text = myBattleResult.Kill.ToString();
		((GObject)MyBattleRecordInfo.TotalLoss).text = myBattleResult.Loss.ToString();
	}

	private void RenderAllCampBattleResult()
	{
		RenderCampBattleResult(1, RedCampInfo);
		RenderCampBattleResult(2, GreenCampInfo);
		RenderCampBattleResult(3, BlueCampInfo);
		RenderCampBattleResult(4, YellowCampInfo);
	}

	private void RenderCampBattleResult(int campId, UI_CampBattleInfo campBattleInfo)
	{
		//IL_00ad: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b7: Expected O, but got Unknown
		List<ScoreInfo> list = campBattleResultSort[campId];
		battleResult.CampScore.TryGetValue(campId.ToString(), out var value);
		((GObject)campBattleInfo.n12).text = "/2000";
		((GObject)campBattleInfo.CampScore).text = value.ToString();
		campBattleInfo.Winner.selectedIndex = ((campId == winner) ? 1 : 0);
		campBattleInfo.Type.selectedIndex = ((campId == Singleton<GvGInstanceZone>.Instance.CampId) ? 1 : 0);
		campBattleInfo.Camp.SetSelectedIndex(campId);
		((GObject)campBattleInfo.UserBattleInfo).data = campId;
		campBattleInfo.UserBattleInfo.itemRenderer = new ListItemRenderer(RenderUserBattleResult);
		campBattleInfo.UserBattleInfo.numItems = list.Count;
	}

	private void RenderUserBattleResult(int index, GObject obj)
	{
		UI_UserBattleResylt btn = obj as UI_UserBattleResylt;
		if (btn == null)
		{
			return;
		}
		int num = (int)((GObject)((GObject)btn).parent).data;
		List<ScoreInfo> source = campBattleResultSort[num];
		ScoreInfo scoreInfo = source.ToList()[index];
		int rankInSelfCamp = scoreInfo.Score.RankInSelfCamp;
		btn.RankType.selectedIndex = ((rankInSelfCamp > 3) ? 3 : (rankInSelfCamp - 1));
		btn.SelfMark.selectedIndex = ((scoreInfo.UserId == myUserId) ? 1 : 0);
		if (btn.RankType.selectedIndex == 3)
		{
			((GObject)btn.MyRank).text = rankInSelfCamp.ToString();
		}
		btn.Camp.SetSelectedIndex(num);
		((GObject)btn.Kill).text = scoreInfo.Score.Kill.ToString();
		((GObject)btn.Loss).text = scoreInfo.Score.Loss.ToString();
		ProfileHelper.GetUserProfile($"{num}", scoreInfo.UserId, delegate(UserProfile profile)
		{
			if (!((GObject)btn).isDisposed)
			{
				((GObject)btn.UserName).text = profile.Name;
			}
		});
		btn.Avatar.Type.selectedIndex = num - 1;
		AvatarHelper.GetUserAvatarSprite($"{num}", scoreInfo.UserId, delegate(Sprite sprite)
		{
			//IL_001c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0026: Expected O, but got Unknown
			btn.Avatar.Avatar.icon.texture = new NTexture((Texture)(object)sprite.texture);
		});
	}

	private void GetBattleResult()
	{
		if (battleResult == null)
		{
			return;
		}
		myUserId = GameController.Contexts.gameState.user.value.UserId;
		winner = battleResult.WinnerOder[0];
		foreach (GvGMode2ScoreInfo scoreInfo in battleResult.ScoreInfos)
		{
			if (scoreInfo.UserId == myUserId)
			{
				myBattleResult = scoreInfo;
			}
			switch (scoreInfo.CampId)
			{
			case 1:
				if (campBattleResult.ContainsKey(1))
				{
					campBattleResult[1].Add(scoreInfo.UserId, scoreInfo);
					break;
				}
				campBattleResult.Add(1, new Dictionary<int, GvGMode2ScoreInfo> { { scoreInfo.UserId, scoreInfo } });
				break;
			case 2:
				if (campBattleResult.ContainsKey(2))
				{
					campBattleResult[2].Add(scoreInfo.UserId, scoreInfo);
					break;
				}
				campBattleResult.Add(2, new Dictionary<int, GvGMode2ScoreInfo> { { scoreInfo.UserId, scoreInfo } });
				break;
			case 3:
				if (campBattleResult.ContainsKey(3))
				{
					campBattleResult[3].Add(scoreInfo.UserId, scoreInfo);
					break;
				}
				campBattleResult.Add(3, new Dictionary<int, GvGMode2ScoreInfo> { { scoreInfo.UserId, scoreInfo } });
				break;
			case 4:
				if (campBattleResult.ContainsKey(4))
				{
					campBattleResult[4].Add(scoreInfo.UserId, scoreInfo);
					break;
				}
				campBattleResult.Add(4, new Dictionary<int, GvGMode2ScoreInfo> { { scoreInfo.UserId, scoreInfo } });
				break;
			}
		}
		foreach (KeyValuePair<int, Dictionary<int, GvGMode2ScoreInfo>> item in campBattleResult)
		{
			int key = item.Key;
			List<ScoreInfo> list = new List<ScoreInfo>();
			foreach (KeyValuePair<int, GvGMode2ScoreInfo> item2 in item.Value)
			{
				list.Add(new ScoreInfo
				{
					UserId = item2.Key,
					Score = item2.Value
				});
			}
			list.Sort(BattleResultSort);
			campBattleResultSort.Add(key, list);
		}
		List<ScoreInfo> list2 = campBattleResultSort[myBattleResult.CampId];
		for (int i = 0; i < list2.Count; i++)
		{
			if (list2[i].UserId == myUserId)
			{
				myRank = list2[i].Score.RankInSelfCamp;
				break;
			}
		}
	}

	private int BattleResultSort(ScoreInfo a, ScoreInfo b)
	{
		if (a.Score.RankInSelfCamp < b.Score.RankInSelfCamp)
		{
			return -1;
		}
		if (a.Score.RankInSelfCamp > b.Score.RankInSelfCamp)
		{
			return 1;
		}
		return 0;
	}

	private void OpenBattleRecord()
	{
		Singleton<GvGInstanceZone>.Instance.GetAllBattleRecordSummary(inZone: true, OpenBattleRecordPanel);
	}

	private void OpenBattleRecordPanel(List<UserIslandEntityBattleRecordSummary> summaries)
	{
		GameController.Contexts.Service<IUiService>().OpenPanel(UI_IslandComeAgainBattleRecordsPanel.Name, new Dictionary<string, object>
		{
			{ "BattleRecordSummary", summaries },
			{
				"IsInZone",
				Singleton<GvGInstanceZone>.Instance.IsInZone
			}
		});
	}
}
