using FairyGUI;
using HotFix.Sources.Base.Scripts.Helper;
using HotFix.Sources.Base.Sources.Scripts.GvG3.GvG3UI.Interface.Brawl;
using Shift.Legion.GvG.Common.Models.GvGMode3.BrawlEvent;
using UI.PublicResources;
using UnityEngine;

namespace HotFix.Sources.Base.Sources.Scripts.GvG3.GvG3UI.Model.BrawlUi;

public class BrawlUserRankUiInfo : IBrawlRankUiInfo
{
	private const string SCORE_BUFF_TIP = "BRAWL_SCORE_BUFF_TIP";

	public int Progress { get; }

	public int RankType { get; }

	public int HasScore { get; }

	public bool HasExtraScorePar { get; }

	public long RankScore { get; }

	public int ShipRace { get; }

	public int Rank { get; }

	public BrawlUserRankUiInfo(BrawlEventSettleInfo info, int progress)
	{
		Progress = progress;
		RankType = 0;
		HasScore = ((info.UserRank > 0) ? 1 : 0);
		HasExtraScorePar = info.HasExtraScorePar;
		ShipRace = info.ShipRace;
		RankScore = info.UserScore;
		Rank = info.UserRank;
	}

	public void DisplayBuffInfo(EventContext context)
	{
		//IL_000e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0014: Expected O, but got Unknown
		//IL_0043: Unknown result type (might be due to invalid IL or missing references)
		//IL_0049: Unknown result type (might be due to invalid IL or missing references)
		context.StopPropagation();
		GObject val = (GObject)context.sender;
		eFairyGUITipDir dir = (eFairyGUITipDir)val.data;
		FairyGUITip.ShowTip(val, dir, delegate(UI_com_UniversalPopupTip popup)
		{
			((GObject)popup.title).text = "BRAWL_SCORE_BUFF_TIP".ToLanguage();
		}, default(Rect), lastSetXy: true);
	}
}
