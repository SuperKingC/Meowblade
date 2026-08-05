using ProtoBuf;

namespace HotFix.Sources.Base.Sources.Scripts.GvG3.GvG3Common.Model.Oem;

[ProtoContract]
public class FormulaOEMMissionsDetail
{
	[ProtoMember(1)]
	public int UserId;

	[ProtoMember(2)]
	public int AmpIdx;

	[ProtoMember(3)]
	public int FinishCount;

	[ProtoMember(4)]
	public int TotalCount;

	[ProtoMember(5)]
	public int CloseTimestamp;

	[ProtoMember(6)]
	public bool HasTitanTalent;

	[ProtoMember(7)]
	public float CriRate;

	[ProtoMember(8)]
	public int MUID;

	[ProtoMember(9)]
	public int 精益求精Level;
}
