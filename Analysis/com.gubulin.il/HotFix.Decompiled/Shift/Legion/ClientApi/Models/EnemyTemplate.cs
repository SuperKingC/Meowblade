using ProtoBuf;

namespace Shift.Legion.ClientApi.Models;

[ProtoContract]
public class EnemyTemplate
{
	[ProtoMember(1)]
	public string FormationId;

	[ProtoMember(2)]
	public string Enemy1;

	[ProtoMember(3)]
	public int Number1;

	[ProtoMember(4)]
	public string Enemy2;

	[ProtoMember(5)]
	public int Number2;

	[ProtoMember(6)]
	public string Enemy3;

	[ProtoMember(7)]
	public int Number3;

	[ProtoMember(8)]
	public string Enemy4;

	[ProtoMember(9)]
	public int Number4;

	[ProtoMember(10)]
	public string Enemy5;

	[ProtoMember(11)]
	public int Number5;

	[ProtoMember(12)]
	public string Enemy6;

	[ProtoMember(13)]
	public int Number6;

	[ProtoMember(14)]
	public string Enemy7;

	[ProtoMember(15)]
	public int Number7;

	[ProtoMember(16)]
	public string Enemy8;

	[ProtoMember(17)]
	public int Number8;

	[ProtoMember(18)]
	public string Enemy9;

	[ProtoMember(19)]
	public int Number9;

	[ProtoMember(20)]
	public string Enemy10;

	[ProtoMember(21)]
	public int Number10;

	[ProtoMember(22)]
	public string Enemy11;

	[ProtoMember(23)]
	public int Number11;

	[ProtoMember(24)]
	public string Enemy12;

	[ProtoMember(25)]
	public int Number12;

	[ProtoMember(26)]
	public string EnemyPortrait;
}
