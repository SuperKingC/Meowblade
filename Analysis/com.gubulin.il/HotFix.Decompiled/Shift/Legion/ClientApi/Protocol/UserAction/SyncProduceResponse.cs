using System.Collections.Generic;
using ProtoBuf;
using Shift.Legion.ClientApi.Protocol.Building;
using Shift.Legion.Helpers;

namespace Shift.Legion.ClientApi.Protocol.UserAction;

[ProtoContract]
public class SyncProduceResponse : IPacketBody
{
	[ProtoMember(1)]
	public bool Result;

	[ProtoMember(2)]
	public long Tick;

	[ProtoMember(3)]
	public string Message;

	[ProtoMember(4, TypeName = "Shift.Legion.ClientApi.Protocol.UserAction.StockChangeRecord")]
	public StockChangeRecord[] StockChangeRecords;

	[ProtoMember(5, TypeName = "Shift.Legion.ClientApi.Protocol.Building.ProduceStates")]
	public ProduceState[] ProduceStates;

	[ProtoMember(6)]
	public string _jsonPendingStocks;

	private Dictionary<string, int> pendingStocks;

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

	public int PacketId => PacketIds.USER_ACTION_SYNC_PRODUCE_REQUEST;
}
