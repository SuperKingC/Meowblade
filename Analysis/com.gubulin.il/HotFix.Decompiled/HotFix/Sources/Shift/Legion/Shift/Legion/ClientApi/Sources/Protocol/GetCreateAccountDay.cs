using ProtoBuf;
using Shift.Legion.ClientApi.Protocol;

namespace HotFix.Sources.Shift.Legion.Shift.Legion.ClientApi.Sources.Protocol;

public class GetCreateAccountDay
{
	[ProtoContract]
	public class Request : IRequestPacket, IPacketBody
	{
		[ProtoMember(99)]
		public int MsgIndex { get; set; }

		public int PacketId => PacketIds.USER_ACTION_GET_ACCOUNTCREATEDAY_REQUEST;
	}

	[ProtoContract]
	public class Response : IPacketBody
	{
		[ProtoMember(1)]
		public int Timestamp { get; set; }

		[ProtoMember(999)]
		public int ErrorCode { get; set; }

		public int PacketId => PacketIds.USER_ACTION_GET_ACCOUNTCREATEDAY_REQUEST;
	}
}
