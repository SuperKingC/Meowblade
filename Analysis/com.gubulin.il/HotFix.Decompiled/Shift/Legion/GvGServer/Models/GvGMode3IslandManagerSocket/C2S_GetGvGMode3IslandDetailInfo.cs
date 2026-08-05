using ProtoBuf;
using Shift.Legion.Common.Managers;
using Shift.Legion.GvG.Common.Models.GvGMode3;

namespace Shift.Legion.GvGServer.Models.GvGMode3IslandManagerSocket;

[ProtoContract]
public class C2S_GetGvGMode3IslandDetailInfo : SocketManager.BaseSocketPackageBodyContext
{
	[ProtoContract]
	public class Request : SocketManager.BaseSocketPackageBody
	{
		[ProtoMember(1)]
		public int IslandId;

		[ProtoMember(2)]
		public string ShipId;
	}

	[ProtoContract]
	public class Response : SocketManager.BaseSocketPackageBody
	{
		[ProtoMember(1)]
		public int ErrorCode;

		[ProtoMember(2)]
		public GvGMode3IslandDetailInfo Info;
	}

	public C2S_GetGvGMode3IslandDetailInfo()
	{
		base.PackageId = SocketManager.ePackageId.C2S_GetGvGMode3IslandDetailInfo;
		base.Resp = new Response();
		base.Req = new Request();
	}
}
