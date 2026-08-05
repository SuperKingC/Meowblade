using ProtoBuf;
using Shift.Legion.Common.Managers;

namespace Shift.Legion.GvGServer.Models.GvGMode3IslandManagerSocket.OuterTech;

[ProtoContract]
public class C2S_OuterTech_UseGreenWay : SocketManager.BaseSocketPackageBodyContext
{
	[ProtoContract]
	public class Request : SocketManager.BaseSocketPackageBody
	{
		[ProtoMember(1)]
		public string OuterTechName;
	}

	[ProtoContract]
	public class Response : SocketManager.BaseSocketPackageBody
	{
		[ProtoMember(1)]
		public int ErrorCode;

		[ProtoMember(2)]
		public int EndTime;

		[ProtoMember(3)]
		public int LimitTime;
	}

	public C2S_OuterTech_UseGreenWay()
	{
		base.PackageId = SocketManager.ePackageId.C2S_OuterTech_UseGreenWay;
		base.Resp = new Response();
		base.Req = new Request();
	}
}
