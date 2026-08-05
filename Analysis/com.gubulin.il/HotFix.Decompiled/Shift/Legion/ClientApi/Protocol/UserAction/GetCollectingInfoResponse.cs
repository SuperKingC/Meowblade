using ProtoBuf;

namespace Shift.Legion.ClientApi.Protocol.UserAction;

[ProtoContract]
public class GetCollectingInfoResponse : IPacketBody
{
	[ProtoMember(1)]
	public bool Result;

	[ProtoMember(2)]
	public int ErrorCode;

	public string Message;

	[ProtoMember(3)]
	public string jsonInfo;

	public int PacketId => PacketIds.USER_ACTION_GET_COLLECTING_INFO;
}
