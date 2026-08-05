using ProtoBuf;

namespace Shift.Legion.ClientApi.Protocol.UserAction;

[ProtoContract]
public class DownloadBattleReplayRequest : IRequestPacket, IPacketBody
{
	[ProtoMember(99)]
	public int MsgIndex { get; set; }

	[ProtoMember(1)]
	public string BattleId { get; set; }

	[ProtoMember(2)]
	public int ReplayIndex { get; set; }

	public int PacketId => PacketIds.USER_ACTION_DOWNLOAD_BATTLE_REPLAY_REQUEST;
}
