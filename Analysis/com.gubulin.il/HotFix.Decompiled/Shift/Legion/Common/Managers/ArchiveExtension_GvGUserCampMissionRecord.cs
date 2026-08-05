using System.Collections.Generic;
using Shift.Legion.GvG.Common.Model;

namespace Shift.Legion.Common.Managers;

public static class ArchiveExtension_GvGUserCampMissionRecord
{
	public class Model
	{
		public Dictionary<string, List<GvGUserCampMissionRecord>> Records = new Dictionary<string, List<GvGUserCampMissionRecord>>();
	}

	public class GvGUserCampMissionRecord
	{
		public string MissionConfigId { get; set; }

		public eCampMissionState State { get; set; }
	}

	private const string Key = "GvGUserCampMissionRecord";

	public static Model GetGvGUserCampMissionRecord(this UserArchiveManager manager)
	{
		Model model = manager.GetConfigValue<Model>("GvGUserCampMissionRecord");
		if (model == null)
		{
			model = new Model();
			if (model.Records == null)
			{
				model.Records = new Dictionary<string, List<GvGUserCampMissionRecord>>();
			}
			manager.SetConfigValue("GvGUserCampMissionRecord", model);
		}
		return model;
	}

	public static void SetGvGUserCampMissionRecord(this UserArchiveManager manager, Model _model)
	{
		manager.SetConfigValue("GvGUserCampMissionRecord", _model);
	}

	public static bool TryClaimGvGUserCampMissionRecord(this UserArchiveManager manager, string IZId, string MissionConfigId)
	{
		Model gvGUserCampMissionRecord = manager.GetGvGUserCampMissionRecord();
		Dictionary<string, List<GvGUserCampMissionRecord>> records = gvGUserCampMissionRecord.Records;
		if (!records.ContainsKey(IZId))
		{
			records.Add(IZId, new List<GvGUserCampMissionRecord>());
		}
		GvGUserCampMissionRecord gvGUserCampMissionRecord2 = records[IZId].Find((GvGUserCampMissionRecord _r) => _r.MissionConfigId == MissionConfigId);
		if (gvGUserCampMissionRecord2 == null)
		{
			gvGUserCampMissionRecord2 = new GvGUserCampMissionRecord();
			gvGUserCampMissionRecord2.MissionConfigId = MissionConfigId;
			gvGUserCampMissionRecord2.State = eCampMissionState.Undergoing;
			records[IZId].Add(gvGUserCampMissionRecord2);
		}
		if (gvGUserCampMissionRecord2.State == eCampMissionState.Claimed)
		{
			return false;
		}
		gvGUserCampMissionRecord2.State = eCampMissionState.Claimed;
		manager.SetGvGUserCampMissionRecord(gvGUserCampMissionRecord);
		return true;
	}

	public static eCampMissionState GetGvGUserCampMissionState(this UserArchiveManager manager, string IZId, string MissionConfigId)
	{
		Dictionary<string, List<GvGUserCampMissionRecord>> records = manager.GetGvGUserCampMissionRecord().Records;
		if (records.TryGetValue(IZId, out var value))
		{
			GvGUserCampMissionRecord gvGUserCampMissionRecord = value.Find((GvGUserCampMissionRecord _r) => _r.MissionConfigId == MissionConfigId);
			if (gvGUserCampMissionRecord != null)
			{
				return eCampMissionState.Claimed;
			}
		}
		return eCampMissionState.Undergoing;
	}
}
