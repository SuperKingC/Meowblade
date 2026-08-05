using HotFix.Sources.Base.Sources.Scripts.GvG3.GvG3Common.Model.IslandFilter.Cache;

namespace HotFix.Sources.Base.Sources.Scripts.GvG3.GvG3Common.Model.IslandFilter;

public class FilterIslandRecordController
{
	private readonly FilterIslandCheckRecord _checkRecord = new FilterIslandCheckRecord();

	private readonly IslandFilterSelectRecord _playerPref = new IslandFilterSelectRecord();

	public string CurFilterId => _checkRecord.SelectFilterId;

	public int LastCheckIslandId => _checkRecord.LastCheckIslandId;

	public FilterIslandRecordController()
	{
		string filterId = _playerPref.LastSelectedFilterId();
		_checkRecord.UpdateOnFilterChange(filterId);
	}

	public bool UpdateOnFilterChange(string filterId)
	{
		bool flag = _checkRecord.UpdateOnFilterChange(filterId);
		if (flag)
		{
			_playerPref.UpdateSelectedFilterId(filterId);
		}
		return flag;
	}

	public void UpdateCheckIslandId(int checkIslandId)
	{
		_checkRecord.UpdateCheckIslandId(checkIslandId);
	}

	public void ClearCheckRecord()
	{
		_checkRecord.ClearCheckIslandIdRecord();
	}
}
