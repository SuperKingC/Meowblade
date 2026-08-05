using ProtoBuf;

namespace HotFix.Sources.Base.Sources.Scripts.GvG3.GvG3Common.Model.Oem;

[ProtoContract]
public class FormulaOemMissionsFilter
{
	[ProtoMember(1)]
	public int Quality;

	[ProtoMember(2)]
	public int Race;

	[ProtoMember(3)]
	public string Soldier;

	[ProtoMember(4)]
	public string Prop;

	[ProtoMember(5)]
	public bool HasTitanTalent;
}
