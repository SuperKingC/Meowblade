using ProtoBuf;

namespace Shift.Legion.GvG.Common.Models.GvGMode3.BrawlEvent;

[ProtoContract]
public class CampSignUpInfo
{
	[ProtoMember(1)]
	public int CampId;

	[ProtoMember(2)]
	public int Cnt;
}
