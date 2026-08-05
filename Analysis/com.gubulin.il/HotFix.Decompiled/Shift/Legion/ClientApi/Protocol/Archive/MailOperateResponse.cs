using System.Collections.Generic;
using ProtoBuf;
using Shift.Legion.ClientApi.Protocol.UserAction;

namespace Shift.Legion.ClientApi.Protocol.Archive;

[ProtoContract]
public class MailOperateResponse : IPacketBody
{
	[ProtoMember(1)]
	public bool Result;

	public string Message;

	[ProtoMember(999)]
	public int ErrorCode { get; set; }

	[ProtoMember(2, TypeName = "Shift.Legion.ClientApi.Protocol.UserAction.StockChangeRecord")]
	public List<StockChangeRecord> StockChangeRecords { get; set; }

	public int PacketId => PacketIds.MAIL_OPERATION_REQUEST;
}
