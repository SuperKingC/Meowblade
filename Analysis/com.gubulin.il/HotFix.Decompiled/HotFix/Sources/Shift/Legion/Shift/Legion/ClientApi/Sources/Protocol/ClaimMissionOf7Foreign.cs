using System.Collections.Generic;
using ProtoBuf;
using Shift.Legion.ClientApi.Protocol;
using Shift.Legion.ClientApi.Protocol.UserAction;

namespace HotFix.Sources.Shift.Legion.Shift.Legion.ClientApi.Sources.Protocol;

public class ClaimMissionOf7Foreign
{
	[ProtoContract]
	public class Request : IRequestPacket, IPacketBody
	{
		[ProtoMember(99)]
		public int MsgIndex { get; set; }

		[ProtoMember(1)]
		public string ActivityId { get; set; }

		[ProtoMember(2)]
		public int Score { get; set; }

		[ProtoMember(3)]
		public bool ClaimPayBonus { get; set; }

		public int PacketId => PacketIds.USER_ACTION_GET_MISSIONOF7FOREIGN_BONUS_REQUEST;
	}

	[ProtoContract]
	public class Response : IPacketBody
	{
		[ProtoMember(1, TypeName = "Shift.Legion.ClientApi.Protocol.UserAction.StockChangeRecord")]
		public List<StockChangeRecord> StockChangeRecords { get; set; }

		[ProtoMember(999)]
		public int ErrorCode { get; set; }

		public int PacketId => PacketIds.USER_ACTION_GET_MISSIONOF7FOREIGN_BONUS_REQUEST;
	}
}
