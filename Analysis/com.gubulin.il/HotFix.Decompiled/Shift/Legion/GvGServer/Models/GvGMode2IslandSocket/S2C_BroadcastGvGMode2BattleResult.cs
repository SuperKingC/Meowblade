using System;
using System.Collections.Generic;
using ProtoBuf;
using Shift.Legion.Common.Managers;

namespace Shift.Legion.GvGServer.Models.GvGMode2IslandSocket;

[ProtoContract]
public class S2C_BroadcastGvGMode2BattleResult : SocketManager.BaseSocketPackageBodyContext
{
	[ProtoContract]
	public class Request : SocketManager.BaseSocketPackageBody
	{
		[ProtoMember(1)]
		public long Frame;

		[ProtoMember(2, TypeName = "Shift.Legion.GvGServer.Models.GvGMode2IslandSocket.GvGMode2BattleResult")]
		public List<GvGMode2BattleResult> GvGMode2BattleResults;
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

	public S2C_BroadcastGvGMode2BattleResult()
	{
		base.PackageId = SocketManager.ePackageId.S2C_BroadcastGvGMode2BattleResult;
		base.Req = new Request();
		base.Resp = new Response();
	}

	public override void OnPush()
	{
		OnPushEvent?.Invoke((Request)base.Req);
	}
}
