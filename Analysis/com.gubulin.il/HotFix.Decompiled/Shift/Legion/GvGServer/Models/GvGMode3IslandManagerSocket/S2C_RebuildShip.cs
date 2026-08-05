using System;
using System.Collections.Generic;
using ProtoBuf;
using Shift.Legion.Common.Managers;
using Shift.Legion.GvG.Common.Models;

namespace Shift.Legion.GvGServer.Models.GvGMode3IslandManagerSocket;

[ProtoContract]
public class S2C_RebuildShip : SocketManager.BaseSocketPackageBodyContext
{
	[ProtoContract]
	public class Request : SocketManager.BaseSocketPackageBody
	{
		[ProtoMember(1)]
		public int ErrorCode;

		[ProtoMember(2, TypeName = "Shift.Legion.GvG.Common.Models.RItem")]
		public List<RItem> ChangedItems;

		[ProtoMember(3)]
		public string jsonGvGMode3Record;

		[ProtoMember(4)]
		public bool FastBuild;
	}

	[ProtoContract]
	public class Response : SocketManager.BaseSocketPackageBody
	{
	}

	public static Action<Request> OnPushEvent = delegate
	{
	};

	public S2C_RebuildShip()
	{
		base.PackageId = SocketManager.ePackageId.S2C_RebuildShip;
		base.Resp = new Response();
		base.Req = new Request();
	}

	public override void OnPush()
	{
		OnPushEvent?.Invoke((Request)base.Req);
	}
}
