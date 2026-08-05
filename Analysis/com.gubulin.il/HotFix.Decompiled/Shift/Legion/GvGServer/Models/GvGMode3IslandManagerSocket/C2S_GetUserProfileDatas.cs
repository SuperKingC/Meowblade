using System.Collections.Generic;
using ProtoBuf;
using Shift.Legion.ClientApi.Protocol;
using Shift.Legion.Common.Managers;

namespace Shift.Legion.GvGServer.Models.GvGMode3IslandManagerSocket;

[ProtoContract]
public class C2S_GetUserProfileDatas : SocketManager.BaseSocketPackageBodyContext
{
	[ProtoContract]
	public class Request : SocketManager.BaseSocketPackageBody
	{
		[ProtoMember(1)]
		public List<int> UserIds;
	}

	[ProtoContract]
	public class Response : SocketManager.BaseSocketPackageBody
	{
		[ProtoMember(1)]
		public int ErrorCode;

		[ProtoMember(2, TypeName = "Shift.Legion.ClientApi.Protocol.GvGMode3ProfileModel")]
		public List<GvGMode3ProfileModel> Models;
	}

	public C2S_GetUserProfileDatas()
	{
		base.PackageId = SocketManager.ePackageId.C2S_GetUserProfileDatas;
		base.Resp = new Response();
		base.Req = new Request();
	}
}
