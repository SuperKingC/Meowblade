using HotFix.Sources.Base.Sources.Scripts.GvG3UI.Model;
using ProtoBuf;
using Shift.Legion.Common.Managers;

namespace Shift.Legion.GvGServer.Models.GvGMode3IslandManagerSocket;

[ProtoContract]
public class C2S_GetRealTimeStorehouseLimitParModel : SocketManager.BaseSocketPackageBodyContext
{
	[ProtoContract]
	public class Request : SocketManager.BaseSocketPackageBody
	{
		[ProtoMember(1)]
		public string ShipId;
	}

	[ProtoContract]
	public class Response : SocketManager.BaseSocketPackageBody
	{
		[ProtoMember(1)]
		public int ErrorCode;

		[ProtoMember(2)]
		public RealTimeStorehouseLimitParModel Model;

		[ProtoMember(3)]
		public int StorehouseLimit;
	}

	public C2S_GetRealTimeStorehouseLimitParModel()
	{
		base.PackageId = SocketManager.ePackageId.C2S_GetRealTimeStorehouseLimitParModel;
		base.Resp = new Response();
		base.Req = new Request();
	}
}
