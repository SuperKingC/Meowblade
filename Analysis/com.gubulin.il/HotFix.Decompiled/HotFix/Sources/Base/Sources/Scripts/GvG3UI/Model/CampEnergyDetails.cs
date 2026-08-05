using System.Collections.Generic;
using System.Linq;
using Shift.Legion.GvGServer.Models.GvGMode3IslandManagerSocket.FlagShip;

namespace HotFix.Sources.Base.Sources.Scripts.GvG3UI.Model;

public class CampEnergyDetails
{
	public int CampEnergy;

	public int BrawlEventCampEnergyLastDay;

	public int BrawlEventRankLastDay;

	public int IslandCount;

	public List<CampEnergyDetailInfo> CampEnergyDetailInfos = new List<CampEnergyDetailInfo>();

	public int TotalEnergyEfficiencyPerDay => CampEnergyDetailInfos?.Sum((CampEnergyDetailInfo info) => info.EnergyEfficiencyPerDay) ?? 0;

	public bool HasBrawlEventEnergy => BrawlEventCampEnergyLastDay > 0;
}
