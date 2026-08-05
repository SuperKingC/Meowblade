using ProtoBuf;

namespace Shift.Legion.ClientApi.Models;

[ProtoContract]
public class TechLevel
{
	[ProtoMember(1)]
	public string TechId;

	[ProtoMember(2)]
	public int Level;
}
