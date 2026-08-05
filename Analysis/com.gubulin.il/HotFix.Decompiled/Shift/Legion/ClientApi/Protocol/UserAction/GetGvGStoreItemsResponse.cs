using System.Collections.Generic;
using ProtoBuf;
using Shift.Legion.Helpers;

namespace Shift.Legion.ClientApi.Protocol.UserAction;

[ProtoContract]
public class GetGvGStoreItemsResponse : IPacketBody
{
	[ProtoIgnore]
	private List<GvGStoreItem> _currentItems;

	[ProtoMember(99)]
	public bool Result { get; set; }

	[ProtoMember(999)]
	public int ErrorCode { get; set; }

	[ProtoMember(1)]
	public string CurrentItems { get; set; }

	[ProtoMember(2)]
	public int NextUpdateTime { get; set; }

	[ProtoMember(3)]
	public int RemainingFreeRefreshCount { get; set; }

	[ProtoMember(4)]
	public bool UseTicket { get; set; }

	[ProtoMember(5)]
	public int NotSilentTimestamp { get; set; }

	[ProtoMember(6)]
	public int RemainingExchangeableRefreshCount { get; set; }

	[ProtoMember(7)]
	public int TotalRefreshCount { get; set; }

	public List<GvGStoreItem> StoreItems
	{
		get
		{
			if (_currentItems == null && !string.IsNullOrEmpty(CurrentItems))
			{
				_currentItems = JsonHelper.ToObject<List<GvGStoreItem>>(CurrentItems);
			}
			return _currentItems;
		}
	}

	public int PacketId => PacketIds.USER_ACTION_GET_GVG_STORE_ITEMS;
}
