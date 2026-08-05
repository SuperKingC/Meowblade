using ProtoBuf;

namespace Shift.Legion.GvG.Common.Models;

[ProtoContract]
public class GvGStateChange_Holding
{
	[ProtoMember(1)]
	public long StartHoldingTimestamp = -1L;
}
