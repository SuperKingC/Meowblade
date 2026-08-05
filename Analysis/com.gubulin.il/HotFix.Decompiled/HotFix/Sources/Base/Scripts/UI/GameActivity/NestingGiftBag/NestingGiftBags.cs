using System.Collections.Generic;
using System.Linq;
using HotFix.Sources.Base.Scripts.Helper;
using Shift.Legion.Common.Managers;

namespace HotFix.Sources.Base.Scripts.UI.GameActivity.NestingGiftBag;

public class NestingGiftBags
{
	private readonly string _unlockChapterId;

	private readonly string _unlockLevelId;

	private readonly List<INestingGift> _freeGiftBags;

	private readonly List<INestingGift> _paidGiftBags;

	public string UnlockTitle { get; }

	public INestingGift FreeGiftBag => _freeGiftBags[0];

	public INestingGift PaidGiftBag => _paidGiftBags?[0];

	public NestingGiftBags(NestingGiftBagsConfig config)
	{
		_unlockChapterId = config.UnlockChapterId;
		_unlockLevelId = config.UnlockLevelId;
		UnlockTitle = config.UnlockTitle.ToLanguage();
		string unlockTip = config.UnlockTip.ToLanguage();
		_freeGiftBags = new List<INestingGift>(config.FreeGiftBags.Select((NestingGiftConfig free) => new FreeNestingGift(free, unlockTip)));
		_paidGiftBags = ((config.PaidGiftBags == null) ? null : new List<INestingGift>(config.PaidGiftBags.Select((NestingGiftConfig paid) => new PaidNestingGift(paid))));
	}

	public bool IsUnlock()
	{
		return SelfIsUnlock();
	}

	private bool SelfIsUnlock()
	{
		if (string.IsNullOrEmpty(_unlockChapterId) || string.IsNullOrEmpty(_unlockLevelId))
		{
			return true;
		}
		return GameManagers.Instance.UserArchiveManager.GetChapterLevelProgress(_unlockChapterId).Contains(_unlockLevelId);
	}

	public int LevelProgressUiIndex(NestingGiftBags nextNode)
	{
		bool flag = SelfIsUnlock();
		if (nextNode == null)
		{
			return flag ? 1 : 2;
		}
		bool flag2 = nextNode.IsUnlock();
		if (flag)
		{
			if (flag2)
			{
				return 0;
			}
			return 1;
		}
		return 2;
	}

	public int LevelNodeIndex(NestingGiftBags nextNode)
	{
		return (nextNode == null) ? 1 : 0;
	}

	public int GetGiftUiType()
	{
		INestingGift nestingGift = _freeGiftBags[0];
		if (nestingGift.GetUiState() != 2)
		{
			return 0;
		}
		INestingGift nestingGift2 = _paidGiftBags?[0];
		if (nestingGift2 == null || nestingGift2.GetUiState() == 0)
		{
			return 0;
		}
		return 1;
	}

	public bool HasClaimableFreeGiftBag()
	{
		return _freeGiftBags.Any((INestingGift bag) => bag.GetUiState() == 1);
	}

	public bool HasToBeUsedGiftBag()
	{
		return _freeGiftBags.Any((INestingGift bag) => bag.GetUiState() != 2) || (_paidGiftBags != null && _paidGiftBags.Any((INestingGift bag) => bag.GetUiState() != 2));
	}
}
