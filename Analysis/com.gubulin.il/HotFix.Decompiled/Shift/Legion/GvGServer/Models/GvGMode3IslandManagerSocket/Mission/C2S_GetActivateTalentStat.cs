using ProtoBuf;
using Shift.Legion.Common.Managers;

namespace Shift.Legion.GvGServer.Models.GvGMode3IslandManagerSocket.Mission;

[ProtoContract]
public class C2S_GetActivateTalentStat : SocketManager.BaseSocketPackageBodyContext
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
		public long RealPointConsumed;
	}

	public C2S_GetActivateTalentStat()
	{
		base.PackageId = SocketManager.ePackageId.C2S_GetActivateTalentStat;
		base.Resp = new Response();
		base.Req = new Request();
	}
}
