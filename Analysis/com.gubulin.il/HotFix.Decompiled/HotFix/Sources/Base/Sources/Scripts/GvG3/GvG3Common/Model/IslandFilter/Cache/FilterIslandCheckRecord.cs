namespace HotFix.Sources.Base.Sources.Scripts.GvG3.GvG3Common.Model.IslandFilter.Cache;

public class FilterIslandCheckRecord
{
	public int LastCheckIslandId { get; private set; }

	public string SelectFilterId { get; private set; } = string.Empty;

	public bool UpdateOnFilterChange(string filterId)
	{
		if (string.Equals(filterId, SelectFilterId))
		{
			return false;
		}
		SelectFilterId = filterId;
		LastCheckIslandId = 0;
		return true;
	}

	public void UpdateCheckIslandId(int checkIslandId)
	{
		LastCheckIslandId = checkIslandId;
	}

	public void ClearCheckIslandIdRecord()
	{
		LastCheckIslandId = 0;
	}
}
