using System.Collections.Generic;
using ProtoBuf;
using Shift.Legion.Common.Managers;
using Shift.Legion.GvG.Common.GvGMode2Island;

namespace Shift.Legion.GvGServer.Models.GvGMode2IslandSocket;

[ProtoContract]
public class C2S_GetGvGMode2Island_EOIEntities : SocketManager.BaseSocketPackageBodyContext
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

		[ProtoMember(2, TypeName = "Shift.Legion.GvG.Common.GvGMode2Island.EntityKeyInfo")]
		public List<EntityKeyInfo> Infos;
	}

	public C2S_GetGvGMode2Island_EOIEntities()
	{
		base.PackageId = SocketManager.ePackageId.C2S_GetGvGMode2Island_EOIEntities;
		base.Resp = new Response();
		base.Req = new Request();
	}
}
