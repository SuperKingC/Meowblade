using ProtoBuf;
using Shift.Legion.Common.Managers;

namespace Shift.Legion.GvGServer.Models.GvGMode3IslandManagerSocket;

[ProtoContract]
public class C2S_ForgeAmplifier : SocketManager.BaseSocketPackageBodyContext
{
	[ProtoContract]
	public class Request : SocketManager.BaseSocketPackageBody
	{
		[ProtoMember(1)]
		public string FormulaId;

		[ProtoMember(2)]
		public int ForgeCount;
	}

	[ProtoContract]
	public class Response : SocketManager.BaseSocketPackageBody
	{
		[ProtoMember(1)]
		public int ErrorCode;
	}

	public C2S_ForgeAmplifier()
	{
		base.PackageId = SocketManager.ePackageId.C2S_ForgeAmplifier;
		base.Resp = new Response();
		base.Req = new Request();
	}
}
