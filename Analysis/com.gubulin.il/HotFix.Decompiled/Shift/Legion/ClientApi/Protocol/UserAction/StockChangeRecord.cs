using ProtoBuf;

namespace Shift.Legion.ClientApi.Protocol.UserAction;

[ProtoContract]
public class StockChangeRecord
{
	public const int TYPE_LIMIT = 0;

	public const int TYPE_NO_LIMIT = 1;

	[ProtoMember(1)]
	public string ItemId;

	[ProtoMember(2)]
	public int Offset;

	[ProtoMember(3)]
	public int Type;

	[ProtoMember(4)]
	public int Context;

	[ProtoMember(5)]
	public string ContextValue;

	[ProtoMember(6)]
	public bool SendEvent;

	public override string ToString()
	{
		return $"{ItemId}:{Offset} Type:{Type}, {Context}:{ContextValue}";
	}
}
