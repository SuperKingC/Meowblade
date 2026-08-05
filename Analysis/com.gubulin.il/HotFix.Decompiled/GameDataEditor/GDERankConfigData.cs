using ProtoBuf;

namespace GameDataEditor;

[ProtoContract]
public class GDERankConfigData
{
	[ProtoMember(1)]
	public string Key;

	[ProtoMember(2)]
	public int Rank;

	[ProtoMember(3)]
	public int RankRange;

	[ProtoMember(4)]
	public int LegionSize;

	[ProtoMember(5)]
	public string LevelId;

	[ProtoMember(6)]
	public string Productions;

	[ProtoMember(7)]
	public string DisplayProductions;

	[ProtoMember(8)]
	public string RankBonus;

	[ProtoMember(9)]
	public string DisplayRankBonus;
}
