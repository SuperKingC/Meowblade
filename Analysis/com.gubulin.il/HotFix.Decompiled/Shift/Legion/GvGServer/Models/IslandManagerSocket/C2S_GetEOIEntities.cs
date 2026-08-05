using System.Collections.Generic;
using ProtoBuf;
using Shift.Legion.Common.Managers;

namespace Shift.Legion.GvGServer.Models.IslandManagerSocket;

public class C2S_GetEOIEntities : SocketManager.BaseSocketPackageBodyContext
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

		[ProtoMember(2, TypeName = "Shift.Legion.GvGServer.Models.IslandManagerSocket.C2S_GetEOIEntitiesInfo")]
		public List<C2S_GetEOIEntitiesInfo> Infos;
	}

	public C2S_GetEOIEntities()
	{
		base.PackageId = SocketManager.ePackageId.C2S_GetEOIEntities;
		base.Resp = new Response();
		base.Req = new Request();
	}
}
