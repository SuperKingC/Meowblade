using ProtoBuf;
using Shift.Legion.Common.Managers;

namespace Shift.Legion.GvGServer.Models.GvGMode3IslandManagerSocket;

[ProtoContract]
public class C2S_SoldierWear : SocketManager.BaseSocketPackageBodyContext
{
	[ProtoContract]
	public class Request : SocketManager.BaseSocketPackageBody
	{
		[ProtoMember(1)]
		public string SoldierId;

		[ProtoMember(2)]
		public int SlotId;

		[ProtoMember(3)]
		public long InstanceId;

		[ProtoMember(4)]
		public int ShipEntityId;
	}

	[ProtoContract]
	public class Response : SocketManager.BaseSocketPackageBody
	{
		[ProtoMember(1)]
		public int ErrorCode { get; set; }
	}

	public C2S_SoldierWear()
	{
		base.PackageId = SocketManager.ePackageId.C2S_Soldier_Wear;
		base.Resp = new Response();
		base.Req = new Request();
	}
}
