using ProtoBuf;

namespace Shift.Legion.GvGServer.Models.WorldBossSocket;

[ProtoContract]
public class BroadcastGroupInfo
{
	[ProtoMember(1)]
	public int EntityId;

	[ProtoMember(2, TypeName = "Shift.Legion.GvGServer.Models.WorldBossSocket.BroadcastGroupUpdateInfo")]
	public BroadcastGroupUpdateInfo UpdateInfo;

	[ProtoMember(3, TypeName = "Shift.Legion.GvGServer.Models.WorldBossSocket.BroadcastGroupDetailInfo")]
	public BroadcastGroupDetailInfo DetailInfo;

	[ProtoMember(4, TypeName = "Shift.Legion.GvGServer.Models.WorldBossSocket.MarchingCommandInfo")]
	public MarchingCommandInfo MarchingCommandInfo;

	[ProtoMember(5, TypeName = "Shift.Legion.GvGServer.Models.WorldBossSocket.FightingCommandInfo")]
	public FightingCommandInfo FightingCommandInfo;
}
