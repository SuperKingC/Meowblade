using ProtoBuf;

namespace Shift.Legion.ClientApi.Protocol.UserAction;

[ProtoContract]
public class GetGvGMode3DescriptionsResponse : IPacketBody
{
	[ProtoMember(1)]
	public bool Result { get; set; }

	[ProtoMember(999)]
	public int ErrorCode { get; set; }

	[ProtoMember(3)]
	public string GvGMode3Descriptions { get; set; }

	[ProtoMember(4)]
	public string GvGStoreDescription { get; set; }

	public int PacketId => PacketIds.USER_ACTION_GVGMODE3_GET_DESCRIPTIONS;
}
