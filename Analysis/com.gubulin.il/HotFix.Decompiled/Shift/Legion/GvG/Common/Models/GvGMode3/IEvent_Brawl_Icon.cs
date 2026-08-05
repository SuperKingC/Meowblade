using ProtoBuf;

namespace Shift.Legion.GvG.Common.Models.GvGMode3;

[ProtoContract]
public class IEvent_Brawl_Icon
{
	[ProtoMember(2)]
	public string ItemId;

	[ProtoMember(3)]
	public int Cnt;
}
