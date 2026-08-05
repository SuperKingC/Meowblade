using ProtoBuf;
using Shift.Legion.Common.Managers;

namespace Shift.Legion.GvGServer.Models.GvGMode3IslandManagerSocket.FlagShip;

[ProtoContract]
public class C2S_SubmitShadowEnergy : SocketManager.BaseSocketPackageBodyContext
{
	[ProtoContract]
	public class Request : SocketManager.BaseSocketPackageBody
	{
		[ProtoMember(1)]
		public int non;
	}

	[ProtoContract]
	public class Response : SocketManager.BaseSocketPackageBody
	{
		[ProtoMember(1)]
		public int ErrorCode;

		[ProtoMember(2)]
		public long CampShadowEnergy;
	}

	public C2S_SubmitShadowEnergy()
	{
		base.PackageId = SocketManager.ePackageId.C2S_SubmitShadowEnergy;
		base.Resp = new Response();
		base.Req = new Request();
	}
}
