using System.Collections.Generic;
using HotFix.Sources.Base.Sources.Scripts.GvG3Common.Model;
using HotFix.Sources.Base.Sources.Scripts.GvG3Common.Model.Talent;
using Shift.Legion.GvG.Common.Models.GvGMode3.RealTime;
using Shift.Legion.GvG.Common.Models.OuterTech;
using Shift.Legion.GvGServer.Models.GvGMode3IslandManagerSocket;

namespace HotFix.Sources.Base.Sources.Scripts.GvG3WorldMap.Model;

public class WorldStateModel
{
	public int MyCampId;

	public int IZEndTimestamp;

	public int IZBeginTimestamp;

	public int FinalProgressBegin;

	public int MainMissionGroupId;

	public Dictionary<int, ShipStateModel> Ships = new Dictionary<int, ShipStateModel>();

	public List<ShipStateModel> MyShips = new List<ShipStateModel>();

	public Dictionary<int, FlagShipStateModel> FlagShips = new Dictionary<int, FlagShipStateModel>();

	public Dictionary<int, IslandStateModel> Islands = new Dictionary<int, IslandStateModel>();

	public Dictionary<int, IslandStateModel> StrongholdIslands = new Dictionary<int, IslandStateModel>();

	public Dictionary<int, IslandStateModel> SpecialIslands = new Dictionary<int, IslandStateModel>();

	public List<EOI_ShipInfo> EOI_ShipEntityIds = new List<EOI_ShipInfo>();

	public List<int> EOI_ShipSimpleEntityIds = new List<int>();

	public HashSet<int> DetectedIslandsWithHiddenRC = new HashSet<int>();

	public int OurFlagShipStayIslandId;

	public TreasureMapInfo SelfTreasureMapInfo;

	public int BattlePassDataVersion;

	public bool HasBattlePassPaidCert;

	public bool HasBattlePassPremiumPaidCert;

	public Dictionary<string, List<int>> BattlePassClaimedBonus;

	public int TotalContributionPoints;

	public TalentEvent Talents;

	public CampProgressData ProgressData;

	public int CurIZId;

	public string IZConfigId;

	public PlayerFlagshipInfo PlayerFlagshipInfo;

	public int WaitToClaimSystemMessageIdsCount;

	public int UserPlayDays;

	public OuterTechModel OuterTechModel;

	public HashSet<int> UnreachableIslands;

	public RealTimeFoodOnBoardModel RealTimeFoodOnBoardModel;

	public string InsuranceShipId;

	public int BattlePassInsuranceTimes = -1;

	public DailySuppressBonusModel DailySuppressBonusModel;

	public bool RefreshCache_Group_SoldierId_ShipEntityId = true;

	private Dictionary<string, int> Group_SoldierId_ShipEntityId = new Dictionary<string, int>();

	public T TryGet<T>(Dictionary<int, T> dict, int id)
	{
		if (dict.TryGetValue(id, out var value))
		{
			return value;
		}
		return default(T);
	}

	public bool TryGetShipEntityIdBySoldierId(string soldierId, out int shipEntityId)
	{
		if (RefreshCache_Group_SoldierId_ShipEntityId)
		{
			Group_SoldierId_ShipEntityId.Clear();
			foreach (ShipStateModel myShip in MyShips)
			{
				foreach (GvGMode3UnitInfo currentUnitInfo in myShip.CurrentUnitInfos)
				{
					if (!string.IsNullOrEmpty(currentUnitInfo.SoldierId))
					{
						Group_SoldierId_ShipEntityId.Add(currentUnitInfo.SoldierId, myShip.EntityId);
					}
				}
			}
			RefreshCache_Group_SoldierId_ShipEntityId = false;
		}
		return Group_SoldierId_ShipEntityId.TryGetValue(soldierId, out shipEntityId);
	}
}
