using System;
using System.Collections.Generic;
using System.Linq;
using Assets.Scripts.Managers;
using Assets.Scripts.UI;
using FairyGUI;
using FairyGUI.Utils;
using HotFix.Sources.Base.Sources.Scripts.GvG3.GvG3UI.Helper;
using HotFix.Sources.Base.Sources.Scripts.GvG3.GvG3UI.Model.UserProfile;
using HotFix.Sources.Base.Sources.Scripts.GvG3UI.Manager;
using HotFix.Sources.Base.Sources.Scripts.GvG3UI.Model;
using HotFix.Sources.Base.Sources.Scripts.GvG3WorldMap.Manager;
using Shift.Legion.ClientApi.Protocol;
using Shift.Legion.Common.Helpers;
using Shift.Legion.GvG.Common.Models.GvGMode3;
using Shift.Legion.GvGServer.Models.GvGMode3IslandManagerSocket;
using UnityEngine;

namespace UI.GvGWorldMap3;

public class UI_com_BestOfToday : GComponent
{
	public Controller HasLogs;

	public Controller IsInSettlement;

	public GImage n7;

	public GImage n17;

	public GImage n18;

	public GImage n19;

	public GList BattleLog;

	public GGroup n25;

	public GImage n29;

	public GTextField n9;

	public UI_com_TodayBestRecord MyBossRecords;

	public GTextField n21;

	public GGraph n31;

	public GTextField n27;

	public GImage n30;

	public GTextField n32;

	public GTextField n33;

	public const string URL = "ui://4eq8fgd2c6jrs6y";

	public static string Name = "UI_com_BestOfToday";

	private GvG3LeaderboardModel _data;

	private readonly string _curCacheId = $"{Singleton<GvGMode3RoomManager>.Instance.ObserverRecord.CurIZId}";

	private const int BestRecordsMaxCount = 3;

	private bool BossDeceased => Singleton<GvGMode3RoomManager>.Instance.IsIZInSettlement || Singleton<WorldStateManager>.Instance.Data.ProgressData.HasSettlement;

	public static string GetURL()
	{
		return "ui://4eq8fgd2c6jrs6y";
	}

	public static UI_com_BestOfToday CreateInstance()
	{
		return (UI_com_BestOfToday)(object)UIPackage.CreateObject("GvGWorldMap3", "com_BestOfToday");
	}

	public static UI_com_BestOfToday CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_BestOfToday).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://4eq8fgd2c6jrs6y", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0037: Unknown result type (might be due to invalid IL or missing references)
		//IL_0041: Expected O, but got Unknown
		//IL_004d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0057: Expected O, but got Unknown
		//IL_0063: Unknown result type (might be due to invalid IL or missing references)
		//IL_006d: Expected O, but got Unknown
		//IL_0079: Unknown result type (might be due to invalid IL or missing references)
		//IL_0083: Expected O, but got Unknown
		//IL_008f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0099: Expected O, but got Unknown
		//IL_00a5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00af: Expected O, but got Unknown
		//IL_00bb: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c5: Expected O, but got Unknown
		//IL_00d1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00db: Expected O, but got Unknown
		//IL_013a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0144: Expected O, but got Unknown
		//IL_018d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0197: Expected O, but got Unknown
		//IL_01a3: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ad: Expected O, but got Unknown
		//IL_01f6: Unknown result type (might be due to invalid IL or missing references)
		//IL_0200: Expected O, but got Unknown
		//IL_020c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0216: Expected O, but got Unknown
		//IL_025f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0269: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		HasLogs = ((GComponent)this).GetController("HasLogs");
		IsInSettlement = ((GComponent)this).GetController("IsInSettlement");
		n7 = (GImage)((GComponent)this).GetChild("n7");
		n17 = (GImage)((GComponent)this).GetChild("n17");
		n18 = (GImage)((GComponent)this).GetChild("n18");
		n19 = (GImage)((GComponent)this).GetChild("n19");
		BattleLog = (GList)((GComponent)this).GetChild("BattleLog");
		n25 = (GGroup)((GComponent)this).GetChild("n25");
		n29 = (GImage)((GComponent)this).GetChild("n29");
		n9 = (GTextField)((GComponent)this).GetChild("n9");
		string id = "ui://4eq8fgd2c6jrs6y".Replace("ui://", "") + "-" + ((GObject)n9).id;
		((GObject)n9).text = LanguagesManager.GetDesc(id);
		MyBossRecords = (UI_com_TodayBestRecord)(object)((GComponent)this).GetChild("MyBossRecords");
		n21 = (GTextField)((GComponent)this).GetChild("n21");
		string id2 = "ui://4eq8fgd2c6jrs6y".Replace("ui://", "") + "-" + ((GObject)n21).id;
		((GObject)n21).text = LanguagesManager.GetDesc(id2);
		n31 = (GGraph)((GComponent)this).GetChild("n31");
		n27 = (GTextField)((GComponent)this).GetChild("n27");
		string id3 = "ui://4eq8fgd2c6jrs6y".Replace("ui://", "") + "-" + ((GObject)n27).id;
		((GObject)n27).text = LanguagesManager.GetDesc(id3);
		n30 = (GImage)((GComponent)this).GetChild("n30");
		n32 = (GTextField)((GComponent)this).GetChild("n32");
		string id4 = "ui://4eq8fgd2c6jrs6y".Replace("ui://", "") + "-" + ((GObject)n32).id;
		((GObject)n32).text = LanguagesManager.GetDesc(id4);
		n33 = (GTextField)((GComponent)this).GetChild("n33");
		string id5 = "ui://4eq8fgd2c6jrs6y".Replace("ui://", "") + "-" + ((GObject)n33).id;
		((GObject)n33).text = LanguagesManager.GetDesc(id5);
	}

	public void OnLoad()
	{
		_data = new GvG3LeaderboardModel();
		GvG3FlagShipMissionsManager instance = Singleton<GvG3FlagShipMissionsManager>.Instance;
		instance.RenderBossDamage = (Action<List<FinalProgressBossDamageInfo>>)Delegate.Combine(instance.RenderBossDamage, new Action<List<FinalProgressBossDamageInfo>>(RenderMyBestToday));
	}

	public void OnClose()
	{
		_data = null;
		GvG3FlagShipMissionsManager instance = Singleton<GvG3FlagShipMissionsManager>.Instance;
		instance.RenderBossDamage = (Action<List<FinalProgressBossDamageInfo>>)Delegate.Remove(instance.RenderBossDamage, new Action<List<FinalProgressBossDamageInfo>>(RenderMyBestToday));
	}

	public void OnRender()
	{
		IsInSettlement.selectedIndex = (BossDeceased ? 1 : 0);
		_data.GetData(eLeaderboardType.BOSS输出榜_全副本, (!BossDeceased) ? eLeaderboardSubType.Today : eLeaderboardSubType.Total, RenderBestData);
		void RenderBestData(GvGMode3LeaderboardData leaderboard)
		{
			if (!((GObject)this).isDisposed)
			{
				RenderCampBest(leaderboard.RankList);
				RenderMyBest(leaderboard);
			}
		}
	}

	private void RenderCampBest(List<GvGMode3PlayerRankInfo> rankInfos)
	{
		//IL_003f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0049: Expected O, but got Unknown
		HasLogs.SetSelectedIndex(rankInfos.Any() ? 1 : 0);
		BattleLog.itemRenderer = new ListItemRenderer(RenderRankUi);
		BattleLog.numItems = 3;
		void RenderRankUi(int index, GObject obj)
		{
			UI_com_TodayBestRecord rankInfoUi = obj as UI_com_TodayBestRecord;
			if (rankInfoUi == null)
			{
				throw new Exception("UI_com_BestOfToday rankInfoUi is not UI_com_TodayBestBossBattleLog");
			}
			if (index > rankInfos.Count - 1)
			{
				rankInfoUi.IsNotEmpty.SetSelectedIndex(0);
			}
			else
			{
				rankInfoUi.IsNotEmpty.SetSelectedIndex(1);
				GvGMode3PlayerRankInfo gvGMode3PlayerRankInfo = rankInfos[index];
				rankInfoUi.Rank.Rank.SetSelectedIndex(index);
				GvG3ProfileHelper.GetUserProfile(new GvG3UserProfileRequestOptions(_curCacheId, gvGMode3PlayerRankInfo.UserId, delegate(UserProfile profile)
				{
					((GObject)rankInfoUi.UserName).text = profile.Name;
				}, delegate(Sprite sprite)
				{
					//IL_001c: Unknown result type (might be due to invalid IL or missing references)
					//IL_0026: Expected O, but got Unknown
					rankInfoUi.Avatar.HeadPortrait.icon.texture = new NTexture((Texture)(object)sprite.texture);
				}));
				((GObject)rankInfoUi.Damage).text = gvGMode3PlayerRankInfo.RankData.ShortNumberFormat() ?? "";
			}
		}
	}

	private void RenderMyBest(GvGMode3LeaderboardData leaderboard)
	{
		if (BossDeceased)
		{
			RenderMyBestTotal(leaderboard);
		}
		else
		{
			Singleton<GvG3FlagShipMissionsManager>.Instance.GetFinalProgressBossDamageTodayTop3();
		}
	}

	private void RenderMyBestTotal(GvGMode3LeaderboardData leaderboard)
	{
		if (leaderboard.MyRanking <= 0)
		{
			MyBossRecords.IsNotEmpty.SetSelectedIndex(0);
			return;
		}
		MyBossRecords.IsNotEmpty.SetSelectedIndex(1);
		int userId = GameController.Contexts.gameState.user.value.UserId;
		GvG3ProfileHelper.GetUserProfile(new GvG3UserProfileRequestOptions(_curCacheId, userId, delegate(UserProfile profile)
		{
			((GObject)MyBossRecords.UserName).text = profile.Name;
		}, delegate(Sprite sprite)
		{
			//IL_001c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0026: Expected O, but got Unknown
			MyBossRecords.Avatar.HeadPortrait.icon.texture = new NTexture((Texture)(object)sprite.texture);
		}));
		MyBossRecords.IsMe.SetSelectedIndex(1);
		((GObject)MyBossRecords.MyRanking).text = leaderboard.MyRanking.ToString();
		((GObject)MyBossRecords.Damage).text = leaderboard.MyRankData.ShortNumberFormat();
	}

	private void RenderMyBestToday(List<FinalProgressBossDamageInfo> todayTop3)
	{
		if (todayTop3 == null || todayTop3.Count() == 0)
		{
			MyBossRecords.IsNotEmpty.SetSelectedIndex(0);
			return;
		}
		MyBossRecords.IsNotEmpty.SetSelectedIndex(1);
		int userId = GameController.Contexts.gameState.user.value.UserId;
		GvG3ProfileHelper.GetUserProfile(new GvG3UserProfileRequestOptions(_curCacheId, userId, delegate(UserProfile profile)
		{
			((GObject)MyBossRecords.UserName).text = profile.Name;
		}, delegate(Sprite sprite)
		{
			//IL_001c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0026: Expected O, but got Unknown
			MyBossRecords.Avatar.HeadPortrait.icon.texture = new NTexture((Texture)(object)sprite.texture);
		}));
		MyBossRecords.IsMe.SetSelectedIndex(1);
		long num = 0L;
		foreach (FinalProgressBossDamageInfo item in todayTop3)
		{
			if (item != null)
			{
				num += item.TotalDamage;
			}
		}
		((GObject)MyBossRecords.Damage).text = num.ShortNumberFormat();
	}
}
