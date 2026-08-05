using ProtoBuf;

namespace Shift.Legion.ClientApi.Protocol.UserAction;

[ProtoContract]
public class GvGClaimUserCampMissionRequest : IRequestPacket, IPacketBody
{
	[ProtoMember(99)]
	public int MsgIndex { get; set; }

	[ProtoMember(1)]
	public string IZId { get; set; }

	[ProtoMember(2)]
	public string CampId { get; set; }

	[ProtoMember(3)]
	public string MissionId { get; set; }

	public int PacketId => PacketIds.USER_ACTION_GVG_CLAIM_USER_CAMPMISSION;
}
