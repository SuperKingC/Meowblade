using ProtoBuf;

namespace GameDataEditor;

[ProtoContract]
public class GDEFormulaData
{
	[ProtoMember(1)]
	public string Key;

	[ProtoMember(2)]
	public int Type;

	[ProtoMember(3)]
	public string Input;

	[ProtoMember(4)]
	public string Output;

	[ProtoMember(5)]
	public int Rarity;

	[ProtoMember(6)]
	public string Data;
}
