using System.Collections.Generic;
using ProtoBuf;
using Shift.Legion.Common.Managers;

namespace Shift.Legion.GvGServer.Models.GvGMode3IslandManagerSocket;

[ProtoContract]
public class C2S_GetActiveTalents : SocketManager.BaseSocketPackageBodyContext
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

		[ProtoMember(2)]
		public List<int> ActiveTalents;

		[ProtoMember(3)]
		public List<int> ActiveSpecialTalents;

		[ProtoMember(4)]
		public int NextAvailableResetTime;
	}

	public C2S_GetActiveTalents()
	{
		base.PackageId = SocketManager.ePackageId.C2S_GetActiveTalents;
		base.Resp = new Response();
		base.Req = new Request();
	}
}
