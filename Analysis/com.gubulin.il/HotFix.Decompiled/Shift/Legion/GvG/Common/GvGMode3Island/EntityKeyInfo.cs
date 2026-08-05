using ProtoBuf;

namespace Shift.Legion.GvG.Common.GvGMode3Island;

[ProtoContract]
public class EntityKeyInfo
{
	[ProtoMember(1)]
	public int UserId;

	[ProtoMember(2)]
	public int CampId;

	[ProtoMember(3)]
	public int EntityId;
}
