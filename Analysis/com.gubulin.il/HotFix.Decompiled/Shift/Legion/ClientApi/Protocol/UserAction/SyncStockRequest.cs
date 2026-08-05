using System.Collections.Generic;
using ProtoBuf;
using Shift.Legion.Helpers;

namespace Shift.Legion.ClientApi.Protocol.UserAction;

[ProtoContract]
public class SyncStockRequest : IRequestPacket, IPacketBody
{
	[ProtoMember(3)]
	public string _jsonItemIds;

	private List<string> _itemIds;

	[ProtoMember(99)]
	public int MsgIndex { get; set; }

	[ProtoMember(1)]
	public long Tick { get; set; }

	[ProtoMember(2)]
	public bool SyncAllStock { get; set; }

	public List<string> ItemIds
	{
		get
		{
			if (_itemIds == null && !string.IsNullOrEmpty(_jsonItemIds))
			{
				_itemIds = JsonHelper.ToObject<List<string>>(_jsonItemIds);
			}
			return _itemIds;
		}
		set
		{
			_itemIds = value;
			_jsonItemIds = JsonHelper.ToJson(_itemIds);
		}
	}

	public int PacketId => PacketIds.USER_ACTION_SYNC_STOCK;
}
