using ProtoBuf;
using Shift.Legion.Common.Managers;

namespace Shift.Legion.GvGServer.Models.GvGMode3IslandManagerSocket;

[ProtoContract]
public class C2S_GetShipAllCombatPower : SocketManager.BaseSocketPackageBodyContext
{
	[ProtoContract]
	public class Request : SocketManager.BaseSocketPackageBody
	{
		[ProtoMember(1)]
		public int ShipEntityId;
	}

	[ProtoContract]
	public class Response : SocketManager.BaseSocketPackageBody
	{
		[ProtoMember(1)]
		public int ErrorCode;

		[ProtoMember(2)]
		public long CombatPower;
	}

	public C2S_GetShipAllCombatPower()
	{
		base.PackageId = SocketManager.ePackageId.C2S_GetShipAllCombatPower;
		base.Resp = new Response();
		base.Req = new Request();
	}
}
