using System.Collections.Generic;
using ProtoBuf;
using Shift.Legion.GvG.Common.Models;

namespace Shift.Legion.ClientApi.Protocol;

[ProtoContract]
public class PreCheckResponse : IPacketBody
{
	[ProtoMember(999)]
	public int ErrorCode { get; set; }

	[ProtoMember(1)]
	public bool OfflineOldPlayer { get; set; }

	[ProtoMember(2)]
	public string Reason { get; set; }

	[ProtoMember(3, TypeName = "Shift.Legion.GvG.Common.Models.RItem")]
	public List<RItem> Bonus { get; set; }

	public int PacketId => PacketIds.USER_PRELOGIN_CHECK;
}
