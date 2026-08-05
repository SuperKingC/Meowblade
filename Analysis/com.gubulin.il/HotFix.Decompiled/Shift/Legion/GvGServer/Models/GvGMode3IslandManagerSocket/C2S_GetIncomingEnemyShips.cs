using System.Collections.Generic;
using ProtoBuf;
using Shift.Legion.Common.Managers;

namespace Shift.Legion.GvGServer.Models.GvGMode3IslandManagerSocket;

[ProtoContract]
public class C2S_GetIncomingEnemyShips : SocketManager.BaseSocketPackageBodyContext
{
	[ProtoContract]
	public class Request : SocketManager.BaseSocketPackageBody
	{
		[ProtoMember(1)]
		public string NonStr;
	}

	[ProtoContract]
	public class Response : SocketManager.BaseSocketPackageBody
	{
		[ProtoMember(1)]
		public int ErrorCode;

		public List<int> EnemyShips;
	}

	public C2S_GetIncomingEnemyShips()
	{
		base.PackageId = SocketManager.ePackageId.C2S_GetIncomingEnemyShips;
		base.Resp = new Response();
		base.Req = new Request();
	}
}
