namespace Shift.Legion.ClientApi.Models;

public class GvGMode3MetaData
{
	public bool Isinit { get; set; }

	public int ShipCountLimit { get; set; }

	public float FlightSpeed { get; set; }

	public float CollectingEfficiency { get; set; }

	public int WorkersOnboardCountLimit { get; set; }

	public int AmplifierCountLimit { get; set; }

	public int FoodOnboardCountLimit { get; set; }

	public int GroupCountLimit { get; set; }

	public int BackupGroupSlotLimit { get; set; }

	public float StorehouseLimitPar { get; set; }

	public float ExtraAmpForgeHighQualityRate { get; set; }

	public static GvGMode3MetaData MakeMetaDataFromRecord(GvGMode3ObserverRecord record)
	{
		return new GvGMode3MetaData
		{
			ShipCountLimit = record.ShipCountLimit,
			FlightSpeed = record.FlightSpeed,
			CollectingEfficiency = record.CollectingEfficiency,
			WorkersOnboardCountLimit = record.WorkersOnboardCountLimit,
			AmplifierCountLimit = record.AmplifierCountLimit,
			GroupCountLimit = record.GroupCountLimit,
			BackupGroupSlotLimit = record.BackupGroupSlotLimit,
			StorehouseLimitPar = record.StorehouseLimitPar,
			ExtraAmpForgeHighQualityRate = record.ExtraAmpForgeHighQualityRate
		};
	}
}
