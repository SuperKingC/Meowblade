using ProtoBuf;
using Shift.Legion.Common.Managers;

namespace Shift.Legion.GvGServer.Models.GvGMode3IslandManagerSocket.FlagShip;

[ProtoContract]
public class C2S_ClaimBattlePassBonus : SocketManager.BaseSocketPackageBodyContext
{
	[ProtoContract]
	public class Request : SocketManager.BaseSocketPackageBody
	{
		[ProtoMember(1)]
		public string ActivityId;

		[ProtoMember(2)]
		public string Node;
	}

	[ProtoContract]
	public class Response : SocketManager.BaseSocketPackageBody
	{
		[ProtoMember(1)]
		public int ErrorCode;

		[ProtoMember(2)]
		public string BattlePassClaimedBonus;
	}

	public C2S_ClaimBattlePassBonus()
	{
		base.PackageId = SocketManager.ePackageId.C2S_ClaimBattlePassBonus;
		base.Resp = new Response();
		base.Req = new Request();
	}
}
