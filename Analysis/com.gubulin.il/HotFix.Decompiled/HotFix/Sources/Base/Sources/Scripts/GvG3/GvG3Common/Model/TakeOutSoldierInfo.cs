using ProtoBuf;

namespace HotFix.Sources.Base.Sources.Scripts.GvG3.GvG3Common.Model;

[ProtoContract]
public class TakeOutSoldierInfo
{
	[ProtoMember(1)]
	public string SoldierId { get; set; }

	[ProtoMember(2)]
	public int StockChange { get; set; }

	[ProtoMember(3)]
	public int SpaceUsage { get; set; }
}
