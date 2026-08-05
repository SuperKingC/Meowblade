using System.Collections.Generic;
using ProtoBuf;
using Shift.Legion.Common.Managers;

namespace Shift.Legion.GvGServer.Models.GvGMode3IslandManagerSocket;

[ProtoContract]
public class C2S_GetFinalProgressBossDamageTodayTop3 : SocketManager.BaseSocketPackageBodyContext
{
	[ProtoContract]
	public class Request : SocketManager.BaseSocketPackageBody
	{
		[ProtoMember(1)]
		public int non;
	}

	[ProtoContract]
	public class Response : SocketManager.BaseSocketPackageBody
	{
		[ProtoMember(1)]
		public int ErrorCode;

		[ProtoMember(2, TypeName = "Shift.Legion.GvGServer.Models.GvGMode3IslandManagerSocket.FinalProgressBossDamageInfo")]
		public List<FinalProgressBossDamageInfo> TodayTop3 = new List<FinalProgressBossDamageInfo>(3);
	}

	public C2S_GetFinalProgressBossDamageTodayTop3()
	{
		base.PackageId = SocketManager.ePackageId.C2S_GetFinalProgressBossDamageTodayTop3;
		base.Resp = new Response();
		base.Req = new Request();
	}
}
