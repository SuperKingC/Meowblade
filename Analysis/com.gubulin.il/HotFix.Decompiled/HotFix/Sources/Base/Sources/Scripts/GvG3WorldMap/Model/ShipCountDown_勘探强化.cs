using ProtoBuf;

namespace HotFix.Sources.Base.Sources.Scripts.GvG3WorldMap.Model;

[ProtoContract]
public class ShipCountDown_勘探强化
{
	[ProtoMember(1)]
	public string ShipId;

	[ProtoMember(2)]
	public int StartTimestamp;

	[ProtoMember(3)]
	public int EndTimestamp;
}
