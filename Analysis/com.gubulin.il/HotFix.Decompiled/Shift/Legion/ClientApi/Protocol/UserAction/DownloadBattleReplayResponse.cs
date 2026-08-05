using ProtoBuf;
using Shift.Legion.ClientApi.RPC;

namespace Shift.Legion.ClientApi.Protocol.UserAction;

[ProtoContract]
public class DownloadBattleReplayResponse : IPacketBody
{
	[ProtoMember(1)]
	public long Tick;

	[ProtoMember(2)]
	public bool Result;

	[ProtoMember(3)]
	public string Message;

	[ProtoMember(10)]
	public byte[] BattleReplayData;

	public int PacketId => PacketIds.USER_ACTION_DOWNLOAD_BATTLE_REPLAY_REQUEST;

	public BattleReplay GetBattleReplay()
	{
		return BattleReplayData.As<BattleReplay>();
	}
}
