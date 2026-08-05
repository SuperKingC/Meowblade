using ProtoBuf;

namespace Shift.Legion.GvGServer.Models.GvGMode3IslandSocket;

[ProtoContract]
public class ScoreChangeInfo
{
	[ProtoMember(1)]
	public int EntityId;

	[ProtoMember(2)]
	public float ChangedScore;

	[ProtoMember(3)]
	public float Par;

	public int StepIndex;

	public float TipScale;
}
