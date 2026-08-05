using System.Collections.Generic;
using System.Linq;
using HotFix.Sources.Base.Sources.Scripts.GvG3.GvG3Common.Model.Medal;
using Shift.Legion.Common.Enums;
using Shift.Legion.Common.Managers;

namespace HotFix.Sources.Base.Sources.Scripts.GvG3.GvG3UI.Model.MedalUi;

public class MedalUiData
{
	private Dictionary<string, bool> _medalDisplay;

	private const int ShowMedalMaxCount = 3;

	public MedalSummary Summary { get; }

	public List<GvGMedalRecord> UiMedals { get; }

	public MedalUiData(List<GvGMedalRecord> records)
	{
		UiMedals = records ?? new List<GvGMedalRecord>();
		foreach (GvGMedalRecord uiMedal in UiMedals)
		{
			uiMedal.Activated = true;
		}
		_medalDisplay = new Dictionary<string, bool>();
		foreach (GvGMedalRecord uiMedal2 in UiMedals)
		{
			_medalDisplay.Add(uiMedal2.MedalId, uiMedal2.IsShowing);
		}
		UiMedals.AddRange(GetNoActiveMedals());
		UiMedals.Sort(MedalSort);
		Summary = MedalSummaryInit();
	}

	private List<GvGMedalRecord> GetNoActiveMedals()
	{
		List<GvGMedalRecord> list = new List<GvGMedalRecord>();
		foreach (string itemId in ConfigDataManager.ItemsByType[ItemType.GvGMedal])
		{
			if (!UiMedals.Exists((GvGMedalRecord m) => m.MedalId == itemId))
			{
				list.Add(new GvGMedalRecord
				{
					MedalId = itemId,
					Activated = false
				});
			}
		}
		return list;
	}

	private MedalSummary MedalSummaryInit()
	{
		return new MedalSummary
		{
			DiamondMedalCnt = UiMedals.Count((GvGMedalRecord m) => m.Config.Rarity == 3 && m.Activated),
			DiamondMedalTotalCnt = UiMedals.Count((GvGMedalRecord m) => m.Config.Rarity == 3),
			GoldMedalCnt = UiMedals.Count((GvGMedalRecord m) => m.Config.Rarity == 2 && m.Activated),
			GoldMedalTotalCnt = UiMedals.Count((GvGMedalRecord m) => m.Config.Rarity == 2),
			SilverMedalCnt = UiMedals.Count((GvGMedalRecord m) => m.Config.Rarity == 1 && m.Activated),
			SilverMedalTotalCnt = UiMedals.Count((GvGMedalRecord m) => m.Config.Rarity == 1)
		};
	}

	public GvGMedalRecord GetGMedalRecord(string medalId)
	{
		return UiMedals.Find((GvGMedalRecord m) => m.MedalId == medalId);
	}

	public bool ChangeMedalDisplay(string medalId, out int errorCode)
	{
		int num = UiMedals.Sum((GvGMedalRecord m) => m.IsShowing ? 1 : 0);
		GvGMedalRecord gvGMedalRecord = UiMedals.Find((GvGMedalRecord m) => m.MedalId == medalId);
		bool flag = !gvGMedalRecord.IsShowing;
		if (flag && num >= 3)
		{
			errorCode = 81100009;
			return false;
		}
		gvGMedalRecord.IsShowing = flag;
		errorCode = 0;
		return true;
	}

	public List<GvG3MedalSimplifiedModel> GetSimplifiedMedals()
	{
		List<GvG3MedalSimplifiedModel> list = new List<GvG3MedalSimplifiedModel>(3);
		list.AddRange(from record in UiMedals
			where record.IsShowing
			select new GvG3MedalSimplifiedModel(record.MedalId, record.Config, record.Level));
		list.AddRange(GetEmpty(3 - list.Count));
		list.Sort(SimplifiedMedalSort);
		return list;
		static List<GvG3MedalSimplifiedModel> GetEmpty(int emptyCount)
		{
			List<GvG3MedalSimplifiedModel> list2 = new List<GvG3MedalSimplifiedModel>();
			for (int i = 0; i < emptyCount; i++)
			{
				list2.Add(new GvG3MedalSimplifiedModel(string.Empty, null, 0));
			}
			return list2;
		}
	}

	private int MedalSort(GvGMedalRecord a, GvGMedalRecord b)
	{
		if (a.Activated && !b.Activated)
		{
			return -1;
		}
		if (!a.Activated && b.Activated)
		{
			return 1;
		}
		int num = b.Config.Rarity - a.Config.Rarity;
		if (num != 0)
		{
			return num;
		}
		return a.Config.Index - b.Config.Index;
	}

	private int SimplifiedMedalSort(GvG3MedalSimplifiedModel a, GvG3MedalSimplifiedModel b)
	{
		if (a.State > b.State)
		{
			return -1;
		}
		if (a.State < b.State)
		{
			return 1;
		}
		if (a.Config == null || b.Config == null)
		{
			return 0;
		}
		int num = b.Config.Rarity - a.Config.Rarity;
		if (num != 0)
		{
			return num;
		}
		return a.Config.Index - b.Config.Index;
	}

	public void UpdateMedalRank(string medalId, int rank)
	{
		UiMedals.Find((GvGMedalRecord m) => m.MedalId == medalId).Rank = rank;
	}

	public List<GvG3MedalChange> GetNeedChangeMedalId()
	{
		List<GvG3MedalChange> list = new List<GvG3MedalChange>();
		foreach (KeyValuePair<string, bool> item in _medalDisplay)
		{
			GvGMedalRecord gMedalRecord = GetGMedalRecord(item.Key);
			if (gMedalRecord.IsShowing != item.Value)
			{
				list.Add(new GvG3MedalChange(gMedalRecord.MedalId, gMedalRecord.IsShowing));
			}
		}
		return list;
	}

	public void UpdateMedalsDisplay(List<GvG3MedalChange> medals)
	{
		foreach (GvG3MedalChange medal in medals)
		{
			GetGMedalRecord(medal.MedalId).IsShowing = medal.Display;
			_medalDisplay[medal.MedalId] = medal.Display;
		}
	}
}
