using ProtoBuf;

namespace Shift.Legion.ClientApi.Models;

[ProtoContract]
public class LevelExtraInfo
{
	[ProtoMember(1)]
	public string ActivityId;

	[ProtoMember(2)]
	public int SubId;

	public override string ToString()
	{
		return $"{ActivityId}_{SubId}";
	}
}
