using System.Collections.Generic;
using GvG2.Common.Models;
using ProtoBuf;
using Shift.Legion.GvG.Common.Models;
using Shift.Legion.Helpers;

namespace Shift.Legion.GvGServer.Models.IslandManagerSocket;

[ProtoContract]
public class C2S_GetShipSummaryAndFlightScheduleInfo
{
	[ProtoMember(1)]
	public int EntityId;

	[ProtoMember(2)]
	public int UserId;

	[ProtoMember(3)]
	public string ShipId;

	[ProtoMember(4, TypeName = "GvG2.Common.Models.FlightSchedule")]
	public FlightSchedule FlightSchedule;

	[ProtoMember(5)]
	public int State;

	[ProtoMember(6)]
	public int StayIslandId;

	[ProtoMember(7)]
	public string FormationId;

	[ProtoMember(8, TypeName = "Shift.Legion.GvG.Common.Models.ShipSummaryUnitInfo")]
	public List<ShipSummaryUnitInfo> GroupInfo;

	[ProtoMember(9)]
	public string _jsonFillUpTimestamp;

	private Dictionary<string, int> _FillUpTimestamp;

	[ProtoMember(10)]
	public int StartFillUpTimestamp;

	[ProtoMember(11, TypeName = "Shift.Legion.GvG.Common.Models.ShipSummaryUnitInfo")]
	public List<ShipSummaryUnitInfo> OldGroupInfo;

	[ProtoMember(12)]
	public string _jsonStockInfoBeforeFillUp;

	private Dictionary<string, int> _StockInfoBeforeFillUp;

	public Dictionary<string, int> FillUpTimestamp
	{
		get
		{
			if (_FillUpTimestamp == null && !string.IsNullOrEmpty(_jsonFillUpTimestamp))
			{
				_FillUpTimestamp = JsonHelper.ToObject<Dictionary<string, int>>(_jsonFillUpTimestamp);
			}
			return _FillUpTimestamp;
		}
		set
		{
			_FillUpTimestamp = value;
			_jsonFillUpTimestamp = JsonHelper.ToJson(_FillUpTimestamp);
		}
	}

	public Dictionary<string, int> StockInfoBeforeFillUp
	{
		get
		{
			if (_StockInfoBeforeFillUp == null && !string.IsNullOrEmpty(_jsonStockInfoBeforeFillUp))
			{
				_StockInfoBeforeFillUp = JsonHelper.ToObject<Dictionary<string, int>>(_jsonStockInfoBeforeFillUp);
			}
			return _StockInfoBeforeFillUp;
		}
		set
		{
			_StockInfoBeforeFillUp = value;
			_jsonStockInfoBeforeFillUp = JsonHelper.ToJson(_StockInfoBeforeFillUp);
		}
	}
}
