using System.Collections.Generic;
using ProtoBuf;
using Shift.Legion.ClientApi.Models;

namespace Shift.Legion.ClientApi.Protocol;

[ProtoContract]
public class GetAccessoryInfoResponse : IPacketBody
{
	[ProtoMember(999)]
	public int ErrorCode { get; set; }

	[ProtoMember(1, TypeName = "Shift.Legion.ClientApi.Models.AccessoryRecordModel")]
	public List<AccessoryRecordModel> Records { get; set; }

	public int PacketId => PacketIds.USER_ACTION_GET_ACCESSORY_INFO;
}
