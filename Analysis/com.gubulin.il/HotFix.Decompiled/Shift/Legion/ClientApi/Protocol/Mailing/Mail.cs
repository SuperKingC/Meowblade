using System;
using System.Collections.Generic;
using System.ComponentModel;
using ProtoBuf;

namespace Shift.Legion.ClientApi.Protocol.Mailing;

[ProtoContract]
public class Mail
{
	[ProtoMember(1)]
	public int Id { get; set; }

	[ProtoMember(2)]
	[DefaultValue("")]
	public string Title { get; set; } = "";

	[ProtoMember(3)]
	[DefaultValue("")]
	public string Content { get; set; } = "";

	[ProtoMember(4)]
	public long CreatedTime { get; set; }

	[ProtoMember(5)]
	public long ExpireTime { get; set; }

	[ProtoMember(6)]
	public int Status { get; set; }

	[ProtoMember(7)]
	public bool HasPayloads { get; set; }

	[ProtoMember(15, TypeName = "Shift.Legion.ClientApi.Protocol.ProtocolBonus")]
	public List<ProtocolBonus> Payloads { get; set; } = new List<ProtocolBonus>();

	[ProtoMember(16, TypeName = "Shift.Legion.ClientApi.Protocol.ProtocolBonus")]
	public List<ProtocolBonus> ExtraPayloads { get; set; } = new List<ProtocolBonus>();

	public void UsedOnlyForAOTCodeGeneration()
	{
		new List<ProtocolBonus>();
		throw new InvalidOperationException("This method is used for AOT code generation only.Do not call it at runtime.");
	}
}
