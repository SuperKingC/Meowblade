using System.Collections.Generic;
using ProtoBuf;
using Shift.Legion.ClientApi.Protocol.UserAction;
using Shift.Legion.Common.Managers;

namespace Shift.Legion.GvGServer.Models.WorldBossSocket;

public class C2S_GetCurBattleDetailInfo : SocketManager.BaseSocketPackageBodyContext
{
	[ProtoContract]
	public class Request : SocketManager.BaseSocketPackageBody
	{
		[ProtoMember(1)]
		public int EntityId;
	}

	[ProtoContract]
	public class Response : SocketManager.BaseSocketPackageBody
	{
		[ProtoMember(1)]
		public int ErrorCode;

		[ProtoMember(2)]
		public string ShipId;

		[ProtoMember(3)]
		public string BattleId;

		[ProtoMember(4)]
		public long Frame;

		[ProtoMember(5)]
		public long Damage;

		[ProtoMember(6)]
		public int SoldierInitValue;

		[ProtoMember(7)]
		public int SoldierRemaining;

		[ProtoMember(8, TypeName = "Shift.Legion.ClientApi.Protocol.UserAction.GvGShipRecord")]
		public List<GvGShipRecord> HistoryRecord;
	}

	public C2S_GetCurBattleDetailInfo()
	{
		base.PackageId = SocketManager.ePackageId.C2S_GetCurBattleDetailInfo;
		base.Req = new Request();
		base.Resp = new Response();
	}
}
