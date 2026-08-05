using System;
using System.Collections.Generic;
using ProtoBuf;

namespace Shift.Legion.ClientApi.Protocol.Mailing;

[ProtoContract]
public class MailListResponse : IPacketBody
{
	[ProtoMember(2)]
	public bool Result;

	[ProtoMember(3)]
	public string Message;

	[ProtoMember(1, Name = "List")]
	public List<Mail> List { get; } = new List<Mail>();

	public int PacketId => PacketIds.MAIL_LIST_REQUEST;

	public void UsedOnlyForAOTCodeGeneration()
	{
		new List<Mail>();
		throw new InvalidOperationException("This method is used for AOT code generation only.Do not call it at runtime.");
	}
}
