using System.Collections.Generic;
using ProtoBuf;
using Shift.Legion.Helpers;

namespace Shift.Legion.ClientApi.Protocol.UserAction;

[ProtoContract]
public class GetGvGStoreGuaranteedItemsResponse : IPacketBody
{
	[ProtoIgnore]
	private Dictionary<string, List<GvGStoreGuaranteedItem>> _cacheItem;

	[ProtoMember(99)]
	public bool Result { get; set; }

	[ProtoMember(999)]
	public int ErrorCode { get; set; }

	[ProtoMember(1)]
	public string GuaranteedItems { get; set; }

	[ProtoMember(2)]
	public int TotalRefreshCount { get; set; }

	public int PacketId => PacketIds.USER_ACTION_GET_GVG_STORE_GUARANTEED;

	[ProtoIgnore]
	public Dictionary<string, List<GvGStoreGuaranteedItem>> GuaranteedItemDict => _cacheItem ?? (_cacheItem = ((!string.IsNullOrEmpty(GuaranteedItems)) ? JsonHelper.ToObject<Dictionary<string, List<GvGStoreGuaranteedItem>>>(GuaranteedItems) : new Dictionary<string, List<GvGStoreGuaranteedItem>>()));
}
