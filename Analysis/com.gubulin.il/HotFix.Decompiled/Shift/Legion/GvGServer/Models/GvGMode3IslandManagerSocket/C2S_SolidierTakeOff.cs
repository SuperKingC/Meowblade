using ProtoBuf;
using Shift.Legion.Common.Managers;

namespace Shift.Legion.GvGServer.Models.GvGMode3IslandManagerSocket;

[ProtoContract]
public class C2S_SolidierTakeOff : SocketManager.BaseSocketPackageBodyContext
{
	[ProtoContract]
	public class Request : SocketManager.BaseSocketPackageBody
	{
		[ProtoMember(1)]
		public string SoldierId;

		[ProtoMember(2)]
		public int SlotId;

		[ProtoMember(4)]
		public int ShipEntityId;
	}

	[ProtoContract]
	public class Response : SocketManager.BaseSocketPackageBody
	{
		[ProtoMember(1)]
		public int ErrorCode;
	}

	public C2S_SolidierTakeOff()
	{
		base.PackageId = SocketManager.ePackageId.C2S_Soldier_TakeOff;
		base.Resp = new Response();
		base.Req = new Request();
	}
}
