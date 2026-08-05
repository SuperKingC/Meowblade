using System.Collections.Generic;
using ProtoBuf;
using Shift.Legion.Common.Managers;
using Shift.Legion.GvG.Common.GvGMode3Island;

namespace Shift.Legion.GvGServer.Models.GvGMode3IslandSocket;

[ProtoContract]
public class C2S_GetGvGMode3Island_EntityInfo : SocketManager.BaseSocketPackageBodyContext
{
	[ProtoContract]
	public class Request : SocketManager.BaseSocketPackageBody
	{
		[ProtoMember(1)]
		public List<int> EntityIds;
	}

	[ProtoContract]
	public class Response : SocketManager.BaseSocketPackageBody
	{
		[ProtoMember(1)]
		public int ErrorCode;

		[ProtoMember(2, TypeName = "Shift.Legion.GvG.Common.GvGMode3Island.EntityInfo")]
		public List<EntityInfo> Entities;
	}

	public C2S_GetGvGMode3Island_EntityInfo()
	{
		base.PackageId = SocketManager.ePackageId.C2S_GetGvGMode3Island_EntityInfo;
		base.Resp = new Response();
		base.Req = new Request();
	}
}
