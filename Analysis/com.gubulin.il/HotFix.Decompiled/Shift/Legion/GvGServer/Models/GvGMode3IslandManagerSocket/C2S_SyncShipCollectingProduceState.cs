using System.Collections.Generic;
using ProtoBuf;
using Shift.Legion.ClientApi.Protocol.Building;
using Shift.Legion.Common.Managers;

namespace Shift.Legion.GvGServer.Models.GvGMode3IslandManagerSocket;

[ProtoContract]
public class C2S_SyncShipCollectingProduceState : SocketManager.BaseSocketPackageBodyContext
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

		[ProtoMember(2, TypeName = "Shift.Legion.ClientApi.Protocol.Building.ProduceState")]
		public List<ProduceState> WorkersProduceStates;
	}

	public C2S_SyncShipCollectingProduceState()
	{
		base.PackageId = SocketManager.ePackageId.C2S_SyncShipCollectingProduceState;
		base.Resp = new Response();
		base.Req = new Request();
	}
}
