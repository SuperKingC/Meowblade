using ProtoBuf;
using Shift.Legion.Common.Managers;

namespace Shift.Legion.GvGServer.Models.GvGMode3IslandManagerSocket.NPC;

[ProtoContract]
public class C2S_BuyNPCShop : SocketManager.BaseSocketPackageBodyContext
{
	[ProtoContract]
	public class Request : SocketManager.BaseSocketPackageBody
	{
		[ProtoMember(1)]
		public int MUID;

		[ProtoMember(2)]
		public string FormulaId;

		[ProtoMember(3)]
		public int BuyCnt;
	}

	[ProtoContract]
	public class Response : SocketManager.BaseSocketPackageBody
	{
		[ProtoMember(1)]
		public int ErrorCode;
	}

	public C2S_BuyNPCShop()
	{
		base.PackageId = SocketManager.ePackageId.C2S_BuyNPCShop;
		base.Resp = new Response();
		base.Req = new Request();
	}
}
