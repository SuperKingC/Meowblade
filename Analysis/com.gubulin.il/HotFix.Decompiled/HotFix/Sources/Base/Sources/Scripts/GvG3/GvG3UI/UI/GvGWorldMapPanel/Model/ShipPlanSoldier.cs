using HotFix.Sources.Base.Sources.Scripts.GvG3.GvG3Common.Model;
using HotFix.Sources.Base.Sources.Scripts.GvG3Common.Model;
using Shift.Legion.Common.Managers;

namespace HotFix.Sources.Base.Sources.Scripts.GvG3.GvG3UI.UI.GvGWorldMapPanel.Model;

public class ShipPlanSoldier
{
	private enum UiState
	{
		Enough,
		NotEnough
	}

	private readonly int _perGroupMemberCnt;

	private int _groupCount;

	public string Id { get; }

	public int PotentialLevel { get; }

	public int TotalCount => _groupCount * _perGroupMemberCnt;

	public ShipPlanSoldier(GvGMode3UnitInfo unitInfo)
	{
		Id = unitInfo.SoldierId;
		PotentialLevel = unitInfo.PotentialLevel;
		_perGroupMemberCnt = unitInfo.Total;
	}

	public void ChangeTeamCount(int teamCount)
	{
		_groupCount = teamCount;
	}

	public int GetUiControllerSelectIndex()
	{
		return (!StockIsEnough()) ? 1 : 0;
	}

	public bool StockIsEnough()
	{
		int stock = GameManagers.Instance.StockController.GetStock(Id);
		return stock >= TotalCount;
	}

	public TakeOutSoldierInfo ToTakeOutInfo()
	{
		return new TakeOutSoldierInfo
		{
			SoldierId = Id,
			StockChange = -TotalCount,
			SpaceUsage = -TotalCount
		};
	}

	public int CalculateMaxCount(int occupiedLimit)
	{
		return occupiedLimit / _perGroupMemberCnt;
	}
}
