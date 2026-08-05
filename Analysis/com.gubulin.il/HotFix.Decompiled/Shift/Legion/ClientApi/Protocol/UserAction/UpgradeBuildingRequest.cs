using System;
using System.Collections.Generic;
using ProtoBuf;
using Shift.Legion.ClientApi.Protocol.Archive;

namespace Shift.Legion.ClientApi.Protocol.UserAction;

[ProtoContract]
public class UpgradeBuildingRequest : IRequestPacket, IPacketBody
{
	[ProtoMember(1)]
	public long Tick;

	[ProtoMember(2)]
	public string BuildingType;

	[ProtoMember(3)]
	public int Workers;

	[ProtoMember(99)]
	public int MsgIndex { get; set; }

	[ProtoMember(4, TypeName = "Shift.Legion.ClientApi.Protocol.Archive.UserData")]
	public List<UserData> Data { get; set; } = new List<UserData>();

	public int PacketId => PacketIds.USER_ACTION_UPGRADE_BUILDING_REQUEST;

	public void UsedOnlyForAOTCodeGeneration()
	{
		new List<UserData>();
		throw new InvalidOperationException("This method is used for AOT code generation only.Do not call it at runtime.");
	}
}
