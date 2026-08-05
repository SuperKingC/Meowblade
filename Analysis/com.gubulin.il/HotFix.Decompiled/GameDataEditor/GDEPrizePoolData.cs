using ProtoBuf;

namespace GameDataEditor;

[ProtoContract]
public class GDEPrizePoolData
{
	[ProtoMember(1)]
	public string Key;

	[ProtoMember(2)]
	public int Type;

	[ProtoMember(3)]
	public string BonusConfig;

	[ProtoMember(4)]
	public string UnlockConfig;

	[ProtoMember(5)]
	public string Rarity;
}
