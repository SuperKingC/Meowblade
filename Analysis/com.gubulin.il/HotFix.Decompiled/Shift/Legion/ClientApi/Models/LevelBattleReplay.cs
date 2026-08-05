using ProtoBuf;

namespace Shift.Legion.ClientApi.Models;

[ProtoContract]
public class LevelBattleReplay
{
	[ProtoMember(1)]
	public string BattleId { get; set; }

	[ProtoMember(2)]
	public int UserId { get; set; }

	[ProtoMember(3)]
	public string Avatar { get; set; }

	[ProtoMember(4)]
	public string Nickname { get; set; }

	[ProtoMember(5)]
	public string LevelId { get; set; }

	[ProtoMember(6)]
	public int Result { get; set; }

	[ProtoMember(7)]
	public int HpPercent { get; set; }

	[ProtoMember(8)]
	public string Soldier1 { get; set; }

	[ProtoMember(9)]
	public string Soldier2 { get; set; }

	[ProtoMember(10)]
	public string Soldier3 { get; set; }

	[ProtoMember(11)]
	public string Soldier4 { get; set; }

	[ProtoMember(12)]
	public string Soldier5 { get; set; }

	[ProtoMember(13)]
	public string ReplayVersion { get; set; }

	[ProtoMember(14)]
	public int ReplaySegments { get; set; }

	[ProtoMember(15)]
	public int ReplayFrames { get; set; }

	[ProtoMember(30)]
	public int DateAdded { get; set; }

	[ProtoMember(40, TypeName = "Shift.Legion.ClientApi.Models.BattleRecordDetail")]
	public BattleRecordDetail Detail { get; set; }
}
