namespace Shift.Legion.ClientApi.Models;

public struct UnitBornRecord
{
	public string UnitId { get; set; }

	public int Born { get; set; }

	public UnitBornRecord(string unitId, int born)
	{
		UnitId = unitId;
		Born = born;
	}
}
