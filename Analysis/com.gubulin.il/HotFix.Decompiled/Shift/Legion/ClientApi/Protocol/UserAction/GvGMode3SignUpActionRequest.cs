using ProtoBuf;

namespace Shift.Legion.ClientApi.Protocol.UserAction;

[ProtoContract]
public class GvGMode3SignUpActionRequest : IRequestPacket, IPacketBody
{
	[ProtoMember(1)]
	public int CampId;

	[ProtoMember(2)]
	public int IZId;

	[ProtoMember(3)]
	public string IZConfigId;

	[ProtoMember(4)]
	public string SignUpAction;

	[ProtoMember(99)]
	public int MsgIndex { get; set; }

	public int PacketId => PacketIds.USER_ACTION_GVGMODE3_SIGNUP_ACTION;
}
