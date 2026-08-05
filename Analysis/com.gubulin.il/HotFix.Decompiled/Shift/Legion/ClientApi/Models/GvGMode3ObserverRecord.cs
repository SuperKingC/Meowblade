using System.Collections.Generic;
using HotFix.Sources.Base.Sources.Scripts.GvG3Common.Model;

namespace Shift.Legion.ClientApi.Models;

public class GvGMode3ObserverRecord
{
	public int ObCampId { get; set; }

	public List<GvGMode3ShipModel> Ships { get; set; } = new List<GvGMode3ShipModel>();

	public int CurIZId { get; set; }

	public string IZConfigId { get; set; }

	public int LastIZId { get; set; } = -1;

	public bool HasEnterIZ { get; set; }

	public int ExternalSocketPort { get; set; }

	public int Pid { get; set; }

	public int LastIZIdRank { get; set; } = -1;

	public int LastIZIdCloseTimestamp { get; set; } = -1;

	public int CampChatRemainingCount { get; set; }

	public int WorldChatRemainingCount { get; set; }

	public int WorldChatFreeRemainingCount { get; set; }

	public int ShipCountLimit { get; set; }

	public float FlightSpeed { get; set; }

	public int ShipSightRange { get; set; }

	public float CollectingEfficiency { get; set; }

	public int WorkersOnboardCountLimit { get; set; }

	public int AmplifierCountLimit { get; set; }

	public int FoodOnboardCountLimit { get; set; }

	public int GroupCountLimit { get; set; }

	public int BackupGroupSlotLimit { get; set; }

	public float StorehouseLimitPar { get; set; }

	public float ExtraAmpForgeHighQualityRate { get; set; }

	public float FoodCostReduce { get; set; }

	public int 火力支援TimeOfUsage { get; set; }

	public RealTime火力支援MaxTimeOfUsageModel RealTime火力支援MaxTimeOfUsageModel { get; set; }
}
