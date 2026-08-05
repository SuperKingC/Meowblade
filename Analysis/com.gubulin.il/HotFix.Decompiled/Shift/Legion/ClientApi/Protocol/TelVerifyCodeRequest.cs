using ProtoBuf;

namespace Shift.Legion.ClientApi.Protocol;

[ProtoContract]
public class TelVerifyCodeRequest : IRequestPacket, IPacketBody
{
	[ProtoMember(99)]
	public int MsgIndex { get; set; }

	[ProtoMember(1)]
	public string TelNo { get; set; }

	public int PacketId => PacketIds.TEL_VERIFY_CODE_REQUEST;
}
