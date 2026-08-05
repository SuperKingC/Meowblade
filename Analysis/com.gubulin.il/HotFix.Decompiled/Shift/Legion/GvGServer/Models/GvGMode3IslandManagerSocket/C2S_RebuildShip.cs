using ProtoBuf;
using Shift.Legion.Common.Managers;

namespace Shift.Legion.GvGServer.Models.GvGMode3IslandManagerSocket;

[ProtoContract]
public class C2S_RebuildShip : SocketManager.BaseSocketPackageBodyContext
{
	[ProtoContract]
	public class Request : SocketManager.BaseSocketPackageBody
	{
		[ProtoMember(1)]
		public string ShipId;

		[ProtoMember(2)]
		public int RebuildRace;

		[ProtoMember(3)]
		public int WorkerCount;

		[ProtoMember(4)]
		public bool FastBuild;
	}

	[ProtoContract]
	public class Response : SocketManager.BaseSocketPackageBody
	{
		[ProtoMember(1)]
		public int ErrorCode;
	}

	public C2S_RebuildShip()
	{
		base.PackageId = SocketManager.ePackageId.C2S_RebuildShip;
		base.Resp = new Response();
		base.Req = new Request();
	}
}
