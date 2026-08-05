using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FairyGUI;
using HotFix.Sources.Base.Sources.Scripts.GvG3Common.Model;
using Shift.Legion.ClientApi.Models;
using Shift.Legion.ClientApi.Protocol.Modules.SoldierLegendItem.Models;
using Shift.Legion.ClientApi.Protocol.UserAction;
using Shift.Legion.Common.Services;
using Shift.Legion.GvG.Common.Models.GvGMode3;
using Shift.Legion.Helpers;

namespace Shift.Legion.Common.Managers;

public static class ArchiveExtension_GvGMode3ShipDetailModel
{
	private static string GvGMode3RecordKey = "GvGMode3Record";

	private static string GvGMode3PlayerSettlementKey = "GvGMode3PlayerSettlementKey";

	private static string GvGMode3StopTimestamp = "GvGMode3StopTimestamp";

	private static string GvGMode3StartTimestamp = "GvGMode3StartTimestamp";

	private static bool IsLoaded = false;

	public static bool HasEnterIZ(this UserArchiveManager manager)
	{
		return manager.LoadGvGMode3Record().HasEnterIZ;
	}

	private static void EnsureRecord(this UserArchiveManager manager)
	{
		if (!manager.Contains(GvGMode3RecordKey))
		{
			manager.SaveGvGMode3Record(new GvGMode3ObserverRecord
			{
				CurIZId = -1,
				IZConfigId = string.Empty,
				Ships = new List<GvGMode3ShipModel>(),
				HasEnterIZ = false
			});
		}
		if (!manager.Contains(GvGMode3PlayerSettlementKey))
		{
			manager.SaveGvGMode3PlayerSettlement(null);
		}
		if (!manager.Contains(GvGMode3StopTimestamp))
		{
			manager.SaveGvGMode3StopTimestamp();
		}
		if (!manager.Contains(GvGMode3StartTimestamp))
		{
			manager.SaveGvGMode3StartTimestamp();
		}
	}

	public static void SaveGvGMode3Record(this UserArchiveManager manager, GvGMode3ObserverRecord _record)
	{
		manager.SetConfigValue(GvGMode3RecordKey, _record);
	}

	public static void SaveGvGMode3PlayerSettlement(this UserArchiveManager manager, SkyIslandPlayerSettlementModel _model)
	{
		manager.SetConfigValue(GvGMode3PlayerSettlementKey, _model);
	}

	public static void SaveGvGMode3StopTimestamp(this UserArchiveManager manager, int stopTimestamp = -1)
	{
		manager.SetConfigValue(GvGMode3StopTimestamp, stopTimestamp);
	}

	public static void SaveGvGMode3StartTimestamp(this UserArchiveManager manager, int startTimestamp = -1)
	{
		manager.SetConfigValue(GvGMode3StartTimestamp, startTimestamp);
	}

	public static SkyIslandPlayerSettlementModel LoadPlayerSettlement(this UserArchiveManager manager)
	{
		manager.EnsureRecord();
		return manager.GetConfigValue<SkyIslandPlayerSettlementModel>(GvGMode3PlayerSettlementKey);
	}

	public static GvGMode3ObserverRecord LoadGvGMode3Record(this UserArchiveManager manager)
	{
		manager.EnsureRecord();
		return manager.GetConfigValue<GvGMode3ObserverRecord>(GvGMode3RecordKey);
	}

	public static int LoadGvGMode3StopTimestamp(this UserArchiveManager manager)
	{
		manager.EnsureRecord();
		return manager.GetConfigValue<int>(GvGMode3StopTimestamp);
	}

	public static int LoadGvGMode3StartTimestamp(this UserArchiveManager manager)
	{
		manager.EnsureRecord();
		return manager.GetConfigValue<int>(GvGMode3StartTimestamp);
	}

	public static GvGMode3ShipModel FindGvGMode3ShipDetailModel(this UserArchiveManager manager, string ShipId)
	{
		GvGMode3ObserverRecord gvGMode3ObserverRecord = manager.LoadGvGMode3Record();
		return gvGMode3ObserverRecord.Ships.FirstOrDefault((GvGMode3ShipModel _model) => _model.ShipId == ShipId);
	}

	public static void AddGvGMode3ShipModel(this UserArchiveManager manager, GvGMode3ShipModel _ship_model)
	{
		GvGMode3ObserverRecord gvGMode3ObserverRecord = manager.LoadGvGMode3Record();
		gvGMode3ObserverRecord.Ships.Add(_ship_model);
		manager.SaveGvGMode3Record(gvGMode3ObserverRecord);
	}

	public static bool DelGvGMode3ShipModel(this UserArchiveManager manager, string shipId)
	{
		GvGMode3ObserverRecord gvGMode3ObserverRecord = manager.LoadGvGMode3Record();
		int num = gvGMode3ObserverRecord.Ships.RemoveAll((GvGMode3ShipModel _model) => _model.ShipId == shipId);
		manager.SaveGvGMode3Record(gvGMode3ObserverRecord);
		return num == 1;
	}

	public static int GetGvGMode3CurIZId(this UserArchiveManager manager)
	{
		return manager.LoadGvGMode3Record().CurIZId;
	}

	public static void JoinNewGvGMode3(this UserArchiveManager manager, GvGMode3SignUpActionRequest req)
	{
		GvGMode3ObserverRecord gvGMode3ObserverRecord = manager.LoadGvGMode3Record();
		gvGMode3ObserverRecord.CurIZId = req.IZId;
		gvGMode3ObserverRecord.ObCampId = req.CampId;
		gvGMode3ObserverRecord.IZConfigId = req.IZConfigId;
		gvGMode3ObserverRecord.LastIZId = -1;
		gvGMode3ObserverRecord.HasEnterIZ = false;
		manager.SaveGvGMode3Record(gvGMode3ObserverRecord);
	}

	public static void CancelGvGMode3(this UserArchiveManager manager)
	{
		GvGMode3ObserverRecord gvGMode3ObserverRecord = manager.LoadGvGMode3Record();
		gvGMode3ObserverRecord.CurIZId = -1;
		gvGMode3ObserverRecord.ObCampId = -1;
		gvGMode3ObserverRecord.IZConfigId = string.Empty;
		gvGMode3ObserverRecord.LastIZId = -1;
		gvGMode3ObserverRecord.HasEnterIZ = false;
		manager.SaveGvGMode3Record(gvGMode3ObserverRecord);
	}

	public static bool IsJoinIZ(this UserArchiveManager manager)
	{
		return manager.LoadGvGMode3Record().HasEnterIZ;
	}

	public static Dictionary<int, int> GetBuildableShipType(this GvGMode3ObserverRecord record)
	{
		Dictionary<int, int> dictionary = new Dictionary<int, int>();
		foreach (object value in Enum.GetValues(typeof(eRace)))
		{
			dictionary.Add((int)value, 1);
		}
		foreach (GvGMode3ShipModel ship in record.Ships)
		{
			dictionary[ship.PermanentData.ShipRace]--;
		}
		return dictionary;
	}

	public static void GetGvGMode3Record(this UserArchiveManager manager, Action<GvGMode3Records> OnSuccess = null, bool forceSync = false)
	{
		if (IsLoaded && !forceSync)
		{
			OnSuccess?.Invoke(new GvGMode3Records
			{
				ObserverRecord = manager.LoadGvGMode3Record(),
				PlayerSettlement = manager.LoadPlayerSettlement(),
				StopTimestamp = manager.LoadGvGMode3StopTimestamp(),
				StartTimestamp = manager.LoadGvGMode3StartTimestamp()
			});
			return;
		}
		ILRequestHelper<GvGMode3ShipGetRecordResponse>.Request((EventContext)null, (Func<Task<GvGMode3ShipGetRecordResponse>>)(() => GameController.Contexts.Service<INetworkService>().GvGMode3ShipGetRecord()), (Action<GvGMode3ShipGetRecordResponse>)delegate(GvGMode3ShipGetRecordResponse response)
		{
			if (!response.Result)
			{
				ILRequestHelper.ShowErrorCode(response.ErrorCode);
			}
			else
			{
				IsLoaded = true;
				GvGMode3Records gvGMode3Records = new GvGMode3Records
				{
					StopTimestamp = response.StopTimestamp,
					StartTimestamp = response.StartTimestamp
				};
				try
				{
					gvGMode3Records.ObserverRecord = JsonHelper.ToObject<GvGMode3ObserverRecord>(response.jsonGvGMode3Record);
					if (!string.IsNullOrEmpty(response.jsonPlayerSettlement))
					{
						gvGMode3Records.PlayerSettlement = JsonHelper.ToObject<SkyIslandPlayerSettlementModel>(response.jsonPlayerSettlement);
					}
				}
				catch (Exception)
				{
					ILRuntimeDebug.LogError("[GvGMode3ShipGetRecordResponse] 无法解析observer record，请检查此数据结构在热更上和gs服务器上是否一致, json = " + response.jsonGvGMode3Record);
					return;
				}
				if (gvGMode3Records.ObserverRecord.Ships == null)
				{
					gvGMode3Records.ObserverRecord.Ships = new List<GvGMode3ShipModel>();
				}
				manager.SaveGvGMode3Record(gvGMode3Records.ObserverRecord);
				manager.SaveGvGMode3PlayerSettlement(gvGMode3Records.PlayerSettlement);
				manager.SaveGvGMode3StartTimestamp(gvGMode3Records.StartTimestamp);
				OnSuccess?.Invoke(gvGMode3Records);
				manager.SetConfigValue("GvGSoldiersEquippedItems", JsonHelper.ToObject<SoldiersEquippedItems>(response.jsonGvGSoldiersEquippedItems));
			}
		});
	}
}
