using ProtoBuf;

namespace GvG2.Common.Models;

[ProtoContract]
public class WBKeyInfo
{
	[ProtoMember(1)]
	public string WBId;

	[ProtoMember(2)]
	public string HPPer;

	[ProtoMember(3)]
	public bool IsBossDead;
}
