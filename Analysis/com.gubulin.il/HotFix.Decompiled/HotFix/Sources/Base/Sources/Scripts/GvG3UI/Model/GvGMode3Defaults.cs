using System.Collections.Generic;

namespace HotFix.Sources.Base.Sources.Scripts.GvG3UI.Model;

public class GvGMode3Defaults
{
	public int MinRequiredRaceSoldiersCount { get; set; }

	public int SoldiersCountLimit { get; set; }

	public int WorkersOnboardCountLimit { get; set; }

	public int FoodOnboardCountLimit { get; set; }

	public int FoodOnFlagShipCountLimit { get; set; }

	public int FoodOnFlagShipRecoverPerDay { get; set; }

	public int FoodConsuming { get; set; }

	public int FlightSpeed { get; set; } = 0;

	public int ShipSightRange { get; set; } = 0;

	public int GroupCountLimit { get; set; }

	public int MaxGroupCountLimit { get; set; }

	public int ShipCountLimit { get; set; }

	public float CollectingEfficiency { get; set; } = 0f;

	public int MaxWorkersWhenCreateShip { get; set; }

	public int AmplifierCountLimit { get; set; }

	public int BackupGroupSlotLimit { get; set; }

	public float StorehouseLimitPar { get; set; }

	public Dictionary<string, float> AmpForgeHighQualityRate { get; set; }
}
