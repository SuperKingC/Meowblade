using System.Collections.Generic;
using ProtoBuf;
using Shift.Legion.ClientApi.Models;
using Shift.Legion.ClientApi.Protocol.Mailing;

namespace Shift.Legion.ClientApi.Protocol.UserAction;

[ProtoContract]
public class PullDataResponse : IPacketBody
{
	[ProtoMember(1)]
	public bool Result;

	[ProtoMember(2)]
	public string Message;

	[ProtoMember(3, TypeName = "Shift.Legion.ClientApi.Protocol.Mailing.Mail")]
	public List<Mail> Mails;

	[ProtoMember(4, TypeName = "Shift.Legion.ClientApi.Models.NewsTicker")]
	public NewsTicker NewsTicker;

	[ProtoMember(5, TypeName = "Shift.Legion.ClientApi.Models.MarqueeContent")]
	public MarqueeContent MarqueeContent;

	public int PacketId => PacketIds.PULL_DATA_REQUEST;
}
