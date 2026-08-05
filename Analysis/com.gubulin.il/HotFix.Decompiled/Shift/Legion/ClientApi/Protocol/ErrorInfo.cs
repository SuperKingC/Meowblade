using ProtoBuf;

namespace Shift.Legion.ClientApi.Protocol;

[ProtoContract]
public class ErrorInfo
{
	[ProtoMember(1)]
	public int ErrorCode { get; set; }
}
