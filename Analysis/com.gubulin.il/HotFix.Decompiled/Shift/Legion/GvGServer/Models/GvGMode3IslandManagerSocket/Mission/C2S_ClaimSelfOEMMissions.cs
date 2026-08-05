using HotFix.Sources.Base.Sources.Scripts.GvG3Common.Model;
using ProtoBuf;
using Shift.Legion.Common.Managers;

namespace Shift.Legion.GvGServer.Models.GvGMode3IslandManagerSocket.Mission;

[ProtoContract]
public class C2S_ClaimSelfOEMMissions : SocketManager.BaseSocketPackageBodyContext
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

		[ProtoMember(2, TypeName = "HotFix.Sources.Base.Sources.Scripts.GvG3Common.Model.OEMGiverClaimBonus")]
		public OEMGiverClaimBonus ClaimBonus;
	}

	public C2S_ClaimSelfOEMMissions()
	{
		base.PackageId = SocketManager.ePackageId.C2S_ClaimSelfOEMMissions;
		base.Resp = new Response();
		base.Req = new Request();
	}
}
