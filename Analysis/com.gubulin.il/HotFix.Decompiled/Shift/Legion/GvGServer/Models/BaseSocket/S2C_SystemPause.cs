using System;
using ProtoBuf;
using Shift.Legion.Common.Managers;

namespace Shift.Legion.GvGServer.Models.BaseSocket;

[ProtoContract]
public class S2C_SystemPause : SocketManager.BaseSocketPackageBodyContext
{
	[ProtoContract]
	public class Request : SocketManager.BaseSocketPackageBody
	{
		[ProtoMember(1)]
		public string PauseMessage;
	}

	[ProtoContract]
	public class Response : SocketManager.BaseSocketPackageBody
	{
	}

	public static Action<Request> OnPushEvent = delegate
	{
	};

	public S2C_SystemPause()
	{
		base.PackageId = SocketManager.ePackageId.S2C_SystemPause;
		base.Resp = new Response();
		base.Req = new Request();
	}

	public override void OnPush()
	{
		OnPushEvent?.Invoke((Request)base.Req);
	}
}
