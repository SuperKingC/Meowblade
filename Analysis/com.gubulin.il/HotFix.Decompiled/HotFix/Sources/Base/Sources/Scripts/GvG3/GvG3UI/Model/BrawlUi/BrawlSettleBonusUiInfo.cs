using System.Collections.Generic;
using FairyGUI;
using HotFix.Sources.Base.Scripts.Helper;
using HotFix.Sources.Base.Sources.Scripts.GvG3.GvG3UI.Interface.Brawl;
using Shift.Legion.Common.Models;
using Shift.Legion.GvG.Common.Models;
using Shift.Legion.GvG.Common.Models.GvGMode3.BrawlEvent;
using UI.GvGBrawlFight;
using UI.PublicResources;
using UnityEngine;

namespace HotFix.Sources.Base.Sources.Scripts.GvG3.GvG3UI.Model.BrawlUi;

public class BrawlSettleBonusUiInfo : IBrawlBonusUiInfo
{
	private const string SCORE_BUFF_TIP = "BRAWL_SCORE_BUFF_TIP";

	private readonly List<int> _talentSrcList;

	public bool IsFinal { get; }

	public List<RItem> Bonuses { get; }

	public bool HasBuff { get; }

	public BrawlSettleBonusUiInfo(BrawlEventSettleInfoBonus bonus, BrawlSettleBonusUiType type, bool hasExtraScorePar)
	{
		BrawlSettleBonusUiInfo brawlSettleBonusUiInfo = this;
		_talentSrcList = new List<int>(bonus.TalentSrcList);
		int itemType = Item.ItemType(bonus.Bonuses[0].ItemId);
		IsFinal = type == BrawlSettleBonusUiType.Final;
		Bonuses = bonus.Bonuses.Clone();
		HasBuff = InitHasBuff();
		bool InitHasBuff()
		{
			int result;
			if (!IsFinal)
			{
				List<int> talentSrcList = _talentSrcList;
				result = ((talentSrcList != null && talentSrcList.Count > 0) ? 1 : 0);
			}
			else
			{
				result = ((itemType == 52 && hasExtraScorePar) ? 1 : 0);
			}
			return (byte)result != 0;
		}
	}

	public void DisplayBuffInfo(EventContext context)
	{
		//IL_0062: Unknown result type (might be due to invalid IL or missing references)
		//IL_0069: Expected O, but got Unknown
		//IL_007a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0080: Unknown result type (might be due to invalid IL or missing references)
		//IL_0021: Unknown result type (might be due to invalid IL or missing references)
		//IL_0027: Expected O, but got Unknown
		//IL_004a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0050: Unknown result type (might be due to invalid IL or missing references)
		if (!HasBuff)
		{
			return;
		}
		if (IsFinal)
		{
			GObject target = (GObject)context.sender;
			FairyGUITip.ShowTip(target, eFairyGUITipDir.Left, delegate(UI_com_UniversalPopupTip popup)
			{
				((GObject)popup.title).text = "BRAWL_SCORE_BUFF_TIP".ToLanguage();
			}, default(Rect), lastSetXy: true);
		}
		else
		{
			GObject target2 = (GObject)context.sender;
			FairyGUITip.ShowTip(target2, eFairyGUITipDir.Right, delegate(UI_com_BrawlSettleBonusTalentSrc popup)
			{
				popup.RenderTalents(_talentSrcList);
			}, default(Rect), lastSetXy: true);
		}
	}
}
