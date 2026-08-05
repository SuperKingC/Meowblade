using ProtoBuf;

namespace Shift.Legion.ClientApi.Protocol.UserAction;

[ProtoContract]
public class GvGWorldBosPlayerTeamInfo
{
	[ProtoMember(1)]
	public string SoldierId { get; set; }

	[ProtoMember(2)]
	public int Number { get; set; }
}
