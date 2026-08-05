using ProtoBuf;

namespace Shift.Legion.GvG.Common.Models.GvGMode3.Mission;

[ProtoContract]
public class OEMMissionState_ToProtocol
{
	[ProtoMember(1)]
	public int MUID;

	[ProtoMember(2)]
	public int State;

	[ProtoMember(3)]
	public bool IsExpired;
}
