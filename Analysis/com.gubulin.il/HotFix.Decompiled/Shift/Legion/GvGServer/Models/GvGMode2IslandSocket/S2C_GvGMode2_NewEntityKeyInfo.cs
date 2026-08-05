using System;
using ProtoBuf;
using Shift.Legion.Common.Managers;
using Shift.Legion.GvG.Common.GvGMode2Island;

namespace Shift.Legion.GvGServer.Models.GvGMode2IslandSocket;

[ProtoContract]
public class S2C_GvGMode2_NewEntityKeyInfo : SocketManager.BaseSocketPackageBodyContext
{
	[ProtoContract]
	public class Request : SocketManager.BaseSocketPackageBody
	{
		[ProtoMember(1, TypeName = "Shift.Legion.GvG.Common.GvGMode2Island.EntityKeyInfo")]
		public EntityKeyInfo KeyInfo;
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

	public S2C_GvGMode2_NewEntityKeyInfo()
	{
		base.PackageId = SocketManager.ePackageId.S2C_NewEntityKeyInfo;
		base.Req = new Request();
		base.Resp = new Response();
	}

	public override void OnPush()
	{
		OnPushEvent?.Invoke((Request)base.Req);
	}
}
