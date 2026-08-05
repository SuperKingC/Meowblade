using System.Collections.Generic;
using System.Linq;
using HotFix.Sources.Base.Sources.Scripts.GvG3Common.Model;
using HotFix.Sources.Base.Sources.Scripts.GvG3UI.Model;
using HotFix.Sources.Base.Sources.Scripts.GvG3WorldMap.Manager;
using HotFix.Sources.Base.Sources.Scripts.GvG3WorldMap.Model;
using Shift.Legion.ClientApi.Models;
using Shift.Legion.Common.Helpers;
using Shift.Legion.GvG.Common.Models.GvGMode3;

namespace HotFix.Sources.Base.Sources.Scripts.GvG3UI.Helper;

public static class ObserverExtension
{
	public static string GetMyShipName(this GvGMode3ObserverRecord record, string shipId)
	{
		return record.Ships.FirstOrDefault((GvGMode3ShipModel ship) => ship.ShipId == shipId)?.PermanentData?.ShipName.ToRealShipName();
	}

	public static GvGMode3ShipModel GetMyShipData(this GvGMode3ObserverRecord record, string shipId)
	{
		return record.Ships.FirstOrDefault((GvGMode3ShipModel ship) => ship.ShipId == shipId);
	}

	public static GvGShipDetailModel GetMyShipDetail(this GvGMode3ObserverRecord record, string shipId)
	{
		GvGMode3ShipModel myShipData = record.GetMyShipData(shipId);
		if (myShipData == null)
		{
			return null;
		}
		GvGShipDetailModel gvGShipDetailModel = new GvGShipDetailModel
		{
			WorkersOnboardCountLimit = record.WorkersOnboardCountLimit,
			AmplifierCountLimit = record.AmplifierCountLimit
		};
		gvGShipDetailModel.SetRecordData(myShipData);
		return gvGShipDetailModel;
	}

	public static string GetShipRaceIcon(this GvGMode3ObserverRecord record, string shipId)
	{
		ShipConfigModel byShipRaceType = ShipConfigHelper.GetByShipRaceType((record.Ships.FirstOrDefault((GvGMode3ShipModel ship) => ship.ShipId == shipId)?.PermanentData?.ShipRace).GetValueOrDefault());
		return ShipConfigHelper.GetSkinById(byShipRaceType.DefaultSkinId).IconUrl;
	}

	public static string GetShipIdStaySomeIsland(this GvGMode3ObserverRecord record, int islandId)
	{
		GvGMode3ShipModel gvGMode3ShipModel = null;
		foreach (GvGMode3ShipModel ship in record.Ships)
		{
			ShipStateModel shipStateModel = Singleton<WorldStateManager>.Instance.TryGetMyShip(ship.ShipId);
			if (shipStateModel != null && shipStateModel.StayIslandId == islandId)
			{
				gvGMode3ShipModel = ship;
				break;
			}
		}
		return gvGMode3ShipModel?.ShipId;
	}

	public static List<string> OtherShipsSoldierIds(this GvGMode3ObserverRecord record, string shipId)
	{
		List<string> list = new List<string>();
		List<GvGMode3ShipModel> list2 = record.Ships.Where((GvGMode3ShipModel ship) => ship.ShipId != shipId).ToList();
		for (int num = 0; num < list2.Count; num++)
		{
			ShipStateModel shipStateModel = Singleton<WorldStateManager>.Instance.TryGetMyShip(list2[num].ShipId);
			if (shipStateModel?.CurrentUnitInfos == null)
			{
				continue;
			}
			foreach (GvGMode3UnitInfo currentUnitInfo in shipStateModel.CurrentUnitInfos)
			{
				string soldierId = currentUnitInfo.SoldierId;
				if (!string.IsNullOrEmpty(soldierId) && !list.Contains(soldierId))
				{
					list.Add(soldierId);
				}
			}
		}
		return list;
	}

	public static void UpdateShipOrder(this GvGMode3ObserverRecord record, Dictionary<string, int> order)
	{
		if (order == null)
		{
			return;
		}
		foreach (GvGMode3ShipModel ship in record.Ships)
		{
			if (order.TryGetValue(ship.ShipId, out var value))
			{
				ship.PermanentData.Index = value;
			}
		}
		record.Ships.Sort((GvGMode3ShipModel a, GvGMode3ShipModel b) => a.PermanentData.Index - b.PermanentData.Index + (a.PermanentData.ShipBuildState - b.PermanentData.ShipBuildState));
	}

	private static int Comparison(GvGMode3ShipModel x, GvGMode3ShipModel y)
	{
		if (x.PermanentData.Index > y.PermanentData.Index)
		{
			return 1;
		}
		if (x.PermanentData.Index < y.PermanentData.Index)
		{
			return -1;
		}
		return 0;
	}

	public static bool LastOneShip(this GvGMode3ObserverRecord record)
	{
		return record.Ships.Count <= 1 && record.HasEnterIZ;
	}
}
