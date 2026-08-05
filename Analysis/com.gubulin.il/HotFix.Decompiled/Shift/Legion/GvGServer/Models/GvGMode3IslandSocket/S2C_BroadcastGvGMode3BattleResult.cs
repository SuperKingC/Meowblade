using System;
using System.Collections.Generic;
using ProtoBuf;
using Shift.Legion.Common.Managers;

namespace Shift.Legion.GvGServer.Models.GvGMode3IslandSocket;

[ProtoContract]
public class S2C_BroadcastGvGMode3BattleResult : SocketManager.BaseSocketPackageBodyContext
{
	[ProtoContract]
	public class Request : SocketManager.BaseSocketPackageBody
	{
		[ProtoMember(1)]
		public long Frame;

		[ProtoMember(2, TypeName = "Shift.Legion.GvGServer.Models.GvGMode3IslandSocket.GvGMode3BattleResult")]
		public List<GvGMode3BattleResult> GvGMode3BattleResults;

		[ProtoMember(3)]
		public long BossHp;

		[ProtoMember(4)]
		public int NPCSoldierCount;
	}

	[ProtoContract]
	public class Response : SocketManager.BaseSocketPackageBody
	{
		[ProtoMember(1)]
		public int ErrorCode;
	}

	public static Action<Request> OnPushEvent = delegate
	{
	};

	public S2C_BroadcastGvGMode3BattleResult()
	{
		base.PackageId = SocketManager.ePackageId.S2C_BroadcastGvGMode3BattleResult;
		base.Req = new Request();
		base.Resp = new Response();
	}

	public override void OnPush()
	{
		OnPushEvent?.Invoke((Request)base.Req);
	}
}
