using System.Collections.Generic;
using ProtoBuf;
using Shift.Legion.ClientApi.Protocol.Building;
using Shift.Legion.Helpers;

namespace Shift.Legion.ClientApi.Protocol.UserAction;

[ProtoContract]
public class SyncGvGProduceResponse : IPacketBody
{
	[ProtoMember(1)]
	public bool Result;

	[ProtoMember(2)]
	public long Tick;

	[ProtoMember(4, TypeName = "Shift.Legion.ClientApi.Protocol.UserAction.StockChangeRecord")]
	public StockChangeRecord[] StockChangeRecords;

	[ProtoMember(6)]
	public string _jsonPendingStocks;

	private Dictionary<string, int> pendingStocks;

	[ProtoMember(7)]
	public string _jsonShipProduceStates;

	private Dictionary<string, List<ProduceState>> shipProduceStates;

	public Dictionary<string, int> PendingStocks
	{
		get
		{
			if (pendingStocks == null && !string.IsNullOrEmpty(_jsonPendingStocks))
			{
				pendingStocks = JsonHelper.ToObject<Dictionary<string, int>>(_jsonPendingStocks);
			}
			return pendingStocks;
		}
		set
		{
			pendingStocks = value;
			_jsonPendingStocks = JsonHelper.ToJson(pendingStocks);
		}
	}

	public Dictionary<string, List<ProduceState>> ShipProduceStates
	{
		get
		{
			if (shipProduceStates == null && !string.IsNullOrEmpty(_jsonShipProduceStates))
			{
				shipProduceStates = JsonHelper.ToObject<Dictionary<string, List<ProduceState>>>(_jsonShipProduceStates);
			}
			return shipProduceStates;
		}
		set
		{
			shipProduceStates = value;
			_jsonShipProduceStates = JsonHelper.ToJson(shipProduceStates);
		}
	}

	public int PacketId => PacketIds.USER_ACTION_SYNC_GVG_PRODUCE;
}
