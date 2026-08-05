using System;
using ProtoBuf;
using Shift.Legion.Common.Managers;

namespace Shift.Legion.GvGServer.Models.GvGMode2IslandSocket;

[ProtoContract]
public class S2C_GvGMode2IslandStop : SocketManager.BaseSocketPackageBodyContext
{
	[ProtoContract]
	public class Request : SocketManager.BaseSocketPackageBody
	{
		[ProtoMember(1)]
		public bool IsStop;

		[ProtoMember(2)]
		public int WinnerCamp;

		[ProtoMember(3)]
		public int IslandScore;
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

	public S2C_GvGMode2IslandStop()
	{
		base.PackageId = SocketManager.ePackageId.S2C_GvGMode2IslandStop;
		base.Req = new Request();
		base.Resp = new Response();
	}

	public override void OnPush()
	{
		OnPushEvent?.Invoke((Request)base.Req);
	}
}
