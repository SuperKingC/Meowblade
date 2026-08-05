using System.Collections.Generic;
using System.Linq;

namespace Shift.Legion.Common.Managers;

public static class ArchiveExtension_WorldBossRecord
{
	public class Model
	{
		public Dictionary<string, Record> Records = new Dictionary<string, Record>();
	}

	public class Record
	{
		public string IZId { get; set; }

		public Dictionary<string, EveryDayRecord> EveryDayRecords { get; set; } = new Dictionary<string, EveryDayRecord>();

		public int TotalScore => EveryDayRecords.Values.Sum((EveryDayRecord _every) => _every.TodayTotalScore);
	}

	public class EveryDayRecord
	{
		public Dictionary<string, List<OnRewardUserModel>> Top4Records = new Dictionary<string, List<OnRewardUserModel>>();

		public OnRewardUserModel LatestRecords = new OnRewardUserModel();

		public int TodayTotalScore => AllBossTop4.Take(3).Sum((OnRewardUserModel _r) => _r.Score);

		public List<OnRewardUserModel> AllBossTop4
		{
			get
			{
				List<OnRewardUserModel> list = new List<OnRewardUserModel>();
				foreach (List<OnRewardUserModel> value in Top4Records.Values)
				{
					list.AddRange(value);
				}
				list.Sort(delegate(OnRewardUserModel a, OnRewardUserModel b)
				{
					int num = b.Score.CompareTo(a.Score);
					return (num != 0) ? num : b.TotalDamage.CompareTo(a.TotalDamage);
				});
				return list.Take(4).ToList();
			}
		}

		public List<OnRewardUserModel> GetBossTop3(string wbId)
		{
			if (Top4Records.TryGetValue(wbId, out var value))
			{
				value.Sort((OnRewardUserModel a, OnRewardUserModel b) => b.TotalDamage.CompareTo(a.TotalDamage));
				return value.Take(3).ToList();
			}
			return new List<OnRewardUserModel>();
		}
	}

	private const string Key = "WorldBossRecord";

	public static Model GetWorldBossRecordModel(this UserArchiveManager manager)
	{
		Model model = manager.GetConfigValue<Model>("WorldBossRecord");
		if (model == null)
		{
			model = new Model();
			if (model.Records == null)
			{
				model.Records = new Dictionary<string, Record>();
			}
			manager.SetConfigValue("WorldBossRecord", model);
		}
		return model;
	}

	public static void SetWorldBossRecordModel(this UserArchiveManager manager, Model _model)
	{
		manager.SetConfigValue("WorldBossRecord", _model);
	}
}
