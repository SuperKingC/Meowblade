using System.Collections.Generic;
using ProtoBuf;
using Shift.Legion.Helpers;

namespace Shift.Legion.ClientApi.Protocol.UserAction;

[ProtoContract]
public class GetGvGStoreroomStockLimitResponse : IPacketBody
{
	private Dictionary<string, int> _EvoRequire;

	[ProtoMember(99)]
	public bool Result { get; set; }

	[ProtoMember(999)]
	public int ErrorCode { get; set; }

	[ProtoMember(1)]
	public int StockLimit { get; set; }

	[ProtoMember(2)]
	public string NextLevelEvoRequire { get; set; }

	public Dictionary<string, int> EvoRequire
	{
		get
		{
			if (_EvoRequire == null && !string.IsNullOrEmpty(NextLevelEvoRequire))
			{
				_EvoRequire = JsonHelper.ToObject<Dictionary<string, int>>(NextLevelEvoRequire);
			}
			return _EvoRequire;
		}
	}

	public int PacketId => PacketIds.SER_ACTION_GET_GVG_STOREROOM_STOCK_LIMIT;
}
