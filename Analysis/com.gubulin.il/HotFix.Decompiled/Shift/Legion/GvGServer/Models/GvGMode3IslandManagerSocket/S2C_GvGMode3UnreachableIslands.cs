using System;
using System.Collections.Generic;
using ProtoBuf;
using Shift.Legion.Common.Managers;

namespace Shift.Legion.GvGServer.Models.GvGMode3IslandManagerSocket;

[ProtoContract]
public class S2C_GvGMode3UnreachableIslands : SocketManager.BaseSocketPackageBodyContext
{
	[ProtoContract]
	public class Request : SocketManager.BaseSocketPackageBody
	{
		[ProtoMember(99)]
		public int ErrorCode;

		[ProtoMember(1)]
		public List<int> UnreachableIslands;
	}

	[ProtoContract]
	public class Response : SocketManager.BaseSocketPackageBody
	{
	}

	public static Action<Request> OnPushEvent = delegate
	{
	};

	public S2C_GvGMode3UnreachableIslands()
	{
		base.PackageId = SocketManager.ePackageId.S2C_GvGMode3UnreachableIslands;
		base.Resp = new Response();
		base.Req = new Request();
	}

	public override void OnPush()
	{
		OnPushEvent?.Invoke((Request)base.Req);
	}
}
