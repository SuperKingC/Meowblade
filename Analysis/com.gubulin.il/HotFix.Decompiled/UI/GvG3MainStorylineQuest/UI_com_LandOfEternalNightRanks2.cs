using System.Collections.Generic;
using System.Linq;
using FairyGUI;
using FairyGUI.Utils;
using HotFix.Sources.Base.Sources.Scripts.GvG3UI.Manager;
using HotFix.Sources.Base.Sources.Scripts.GvG3UI.Model;
using Shift.Legion.Common.Helpers;
using Shift.Legion.GvG.Common.Models.GvGMode3;

namespace UI.GvG3MainStorylineQuest;

public class UI_com_LandOfEternalNightRanks2 : GComponent, IFairyComponent
{
	public Controller StepIndex;

	public GImage n47;

	public GImage n0;

	public GList CampRank;

	public GImage n48;

	public const string URL = "ui://249h3k3dm95us5u";

	public static string Name = "UI_com_LandOfEternalNightRanks2";

	private bool Activated => Singleton<GvG3FlagShipMissionsManager>.Instance.IsEternalNight;

	public static string GetURL()
	{
		return "ui://249h3k3dm95us5u";
	}

	public static UI_com_LandOfEternalNightRanks2 CreateInstance()
	{
		return (UI_com_LandOfEternalNightRanks2)(object)UIPackage.CreateObject("GvG3MainStorylineQuest", "com_LandOfEternalNightRanks2");
	}

	public static UI_com_LandOfEternalNightRanks2 CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_LandOfEternalNightRanks2).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://249h3k3dm95us5u", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		((GComponent)this).ConstructFromXML(xml);
		StepIndex = ((GComponent)this).GetController("StepIndex");
		n47 = (GImage)((GComponent)this).GetChild("n47");
		n0 = (GImage)((GComponent)this).GetChild("n0");
		CampRank = (GList)((GComponent)this).GetChild("CampRank");
		n48 = (GImage)((GComponent)this).GetChild("n48");
	}

	public void Destroy()
	{
	}

	public void Init()
	{
		RenderBrawlFightCampRank();
	}

	public void RegisterUiEvent()
	{
	}

	public void UnregisterUiEvent()
	{
	}

	private void RenderBrawlFightCampRank()
	{
		if (!Activated)
		{
			return;
		}
		GvG3LeaderboardModel.Instance.GetData(eLeaderboardType.乱斗永夜阵营获胜榜, eLeaderboardSubType.Total, delegate(GvGMode3LeaderboardData data)
		{
			//IL_011d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0127: Expected O, but got Unknown
			List<GvGMode3PlayerRankInfo> rankList = data.RankList;
			if (rankList.Count < 4)
			{
				rankList = new List<GvGMode3PlayerRankInfo>();
				int i;
				for (i = 1; i <= 4; i++)
				{
					GvGMode3PlayerRankInfo gvGMode3PlayerRankInfo = data.RankList.Find((GvGMode3PlayerRankInfo x) => x.CampId == i);
					if (gvGMode3PlayerRankInfo != null)
					{
						rankList.Add(gvGMode3PlayerRankInfo);
					}
					else
					{
						rankList.Add(new GvGMode3PlayerRankInfo
						{
							CampId = i,
							Rank = 4,
							RankData = 0L,
							RankDataDetail = new List<GvGMode3PlayerRankDataDetail>
							{
								new GvGMode3PlayerRankDataDetail
								{
									_BrawlEventIZRankDetail = new BrawlEventIZRankDetailInfo
									{
										WinnerCount = 0
									}
								}
							}
						});
					}
				}
			}
			int myCampId = Singleton<GvGMode3RoomManager>.Instance.ObserverRecord.ObCampId;
			CampRank.itemRenderer = (ListItemRenderer)delegate(int index, GObject item)
			{
				GvGMode3PlayerRankInfo gvGMode3PlayerRankInfo2 = rankList[index];
				UI_com_LandOfEternalNightCampRank2 uI_com_LandOfEternalNightCampRank = (UI_com_LandOfEternalNightCampRank2)(object)item;
				uI_com_LandOfEternalNightCampRank.Rank.Rank.SetSelectedIndex(gvGMode3PlayerRankInfo2.Rank - 1);
				uI_com_LandOfEternalNightCampRank.Camp.SetSelectedIndex(gvGMode3PlayerRankInfo2.CampId);
				string text = gvGMode3PlayerRankInfo2.RankData.ToString();
				((GObject)uI_com_LandOfEternalNightCampRank.DataValue).text = text;
				int winnerCount = gvGMode3PlayerRankInfo2.RankDataDetail.Last().BrawlEventIZRankDetail.WinnerCount;
				((GObject)uI_com_LandOfEternalNightCampRank.LastValue).text = $"+{winnerCount}";
				bool flag = myCampId == gvGMode3PlayerRankInfo2.CampId;
				uI_com_LandOfEternalNightCampRank.IsMe.SetSelectedIndex(flag ? 1 : 0);
			};
			CampRank.numItems = rankList.Count;
		});
	}
}
