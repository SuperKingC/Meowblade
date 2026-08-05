using System.Collections.Generic;
using ProtoBuf;
using Shift.Legion.Helpers;

namespace Shift.Legion.ClientApi.Protocol.UserAction;

[ProtoContract]
public class SyncStockResponse : IPacketBody
{
	[ProtoMember(2)]
	public string _jsonStocks;

	private Dictionary<string, int> _stocks;

	[ProtoMember(99)]
	public bool Result { get; set; }

	[ProtoMember(1)]
	public long Tick { get; set; }

	public Dictionary<string, int> Stocks
	{
		get
		{
			if (_stocks == null && !string.IsNullOrEmpty(_jsonStocks))
			{
				_stocks = JsonHelper.ToObject<Dictionary<string, int>>(_jsonStocks);
			}
			return _stocks;
		}
		set
		{
			_stocks = value;
			_jsonStocks = JsonHelper.ToJson(_stocks);
		}
	}

	public int PacketId => PacketIds.USER_ACTION_SYNC_STOCK;
}
