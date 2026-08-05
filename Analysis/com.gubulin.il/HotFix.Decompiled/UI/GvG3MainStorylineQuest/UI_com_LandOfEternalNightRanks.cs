using System;
using System.Collections.Generic;
using Assets.Scripts.UI;
using FairyGUI;
using FairyGUI.Utils;
using HotFix.Sources.Base.Sources.Scripts.GvG3UI.Manager;
using HotFix.Sources.Base.Sources.Scripts.GvG3WorldMap.Manager;
using Shift.Legion.Common.Helpers;
using Shift.Legion.Common.Services;
using Shift.Legion.GvG.Common.Models.GvGMode3;
using Shift.Legion.GvGServer.Models.GvGMode3IslandManagerSocket.FinalProgress;

namespace UI.GvG3MainStorylineQuest;

public class UI_com_LandOfEternalNightRanks : GComponent, IFairyComponent
{
	public Controller Type;

	public GImage n47;

	public GImage n0;

	public GList CampRank;

	public UI_btn_RewardDetail RewardDetail;

	public GImage n48;

	public GImage n49;

	public const string URL = "ui://249h3k3dzit42x";

	public static string Name = "UI_com_LandOfEternalNightRanks";

	private bool Activated => Singleton<GvG3FlagShipMissionsManager>.Instance.IsEternalNightProgress && !((GObject)this).isDisposed;

	public static string GetURL()
	{
		return "ui://249h3k3dzit42x";
	}

	public static UI_com_LandOfEternalNightRanks CreateInstance()
	{
		return (UI_com_LandOfEternalNightRanks)(object)UIPackage.CreateObject("GvG3MainStorylineQuest", "com_LandOfEternalNightRanks");
	}

	public static UI_com_LandOfEternalNightRanks CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_LandOfEternalNightRanks).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://249h3k3dzit42x", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		//IL_007e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0088: Expected O, but got Unknown
		//IL_0094: Unknown result type (might be due to invalid IL or missing references)
		//IL_009e: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		Type = ((GComponent)this).GetController("Type");
		n47 = (GImage)((GComponent)this).GetChild("n47");
		n0 = (GImage)((GComponent)this).GetChild("n0");
		CampRank = (GList)((GComponent)this).GetChild("CampRank");
		RewardDetail = (UI_btn_RewardDetail)(object)((GComponent)this).GetChild("RewardDetail");
		n48 = (GImage)((GComponent)this).GetChild("n48");
		n49 = (GImage)((GComponent)this).GetChild("n49");
	}

	public void Destroy()
	{
	}

	public void Init()
	{
	}

	public void RegisterUiEvent()
	{
		//IL_0039: Unknown result type (might be due to invalid IL or missing references)
		//IL_0043: Expected O, but got Unknown
		GvG3FlagShipMissionsManager instance = Singleton<GvG3FlagShipMissionsManager>.Instance;
		instance.RenderEternalNightRank = (Action<C2S_GetFinalProgressRank.Response>)Delegate.Combine(instance.RenderEternalNightRank, new Action<C2S_GetFinalProgressRank.Response>(Render));
		((GObject)RewardDetail).onClick.Set(new EventCallback0(ShowMainMissionCampBonus));
	}

	public void UnregisterUiEvent()
	{
		GvG3FlagShipMissionsManager instance = Singleton<GvG3FlagShipMissionsManager>.Instance;
		instance.RenderEternalNightRank = (Action<C2S_GetFinalProgressRank.Response>)Delegate.Remove(instance.RenderEternalNightRank, new Action<C2S_GetFinalProgressRank.Response>(Render));
		((GObject)RewardDetail).onClick.Clear();
	}

	private void Render(C2S_GetFinalProgressRank.Response response)
	{
		//IL_0093: Unknown result type (might be due to invalid IL or missing references)
		//IL_009d: Expected O, but got Unknown
		List<GvGMode3CampRankInfo> rankDataList;
		int myCampId;
		if (Activated)
		{
			Type.selectedIndex = Singleton<WorldStateManager>.Instance.Data.ProgressData.CampStep - 1;
			rankDataList = ((Type.selectedIndex == 0) ? response.EngeryRankInfo : response.BossDamageRankInfo);
			myCampId = Singleton<GvGMode3RoomManager>.Instance.ObserverRecord.ObCampId;
			if (rankDataList != null)
			{
				CampRank.itemRenderer = new ListItemRenderer(RenderRankUi);
				CampRank.numItems = rankDataList.Count;
			}
		}
		void RenderRankUi(int index, GObject obj)
		{
			if (obj is UI_com_LandOfEternalNightCampRank uI_com_LandOfEternalNightCampRank)
			{
				GvGMode3CampRankInfo gvGMode3CampRankInfo = rankDataList[index];
				uI_com_LandOfEternalNightCampRank.Camp.selectedIndex = gvGMode3CampRankInfo.CampId;
				uI_com_LandOfEternalNightCampRank.IsMe.selectedIndex = ((myCampId == gvGMode3CampRankInfo.CampId) ? 1 : 0);
				uI_com_LandOfEternalNightCampRank.InCompetition.selectedIndex = ((!gvGMode3CampRankInfo.HasBegin) ? 2 : ((gvGMode3CampRankInfo.Rank < 0) ? 1 : 0));
				if (uI_com_LandOfEternalNightCampRank.InCompetition.selectedIndex < 2)
				{
					if (uI_com_LandOfEternalNightCampRank.InCompetition.selectedIndex == 0)
					{
						uI_com_LandOfEternalNightCampRank.Rank.Rank.selectedIndex = gvGMode3CampRankInfo.Rank - 1;
					}
					((GObject)uI_com_LandOfEternalNightCampRank.DataValue).text = ((Type.selectedIndex == 0) ? $"{gvGMode3CampRankInfo.RankData / 100:F1}%" : gvGMode3CampRankInfo.RankData.ShortNumberFormat());
				}
			}
		}
	}

	private void ShowMainMissionCampBonus()
	{
		GameController.Contexts.Service<IUiService>().OpenPanel(UI_main_LandOfEternalNightCampBonus.Name, new Dictionary<string, object> { 
		{
			"LeaderboardType",
			eLeaderboardType.BOSS总输出榜_阵营
		} });
	}
}
