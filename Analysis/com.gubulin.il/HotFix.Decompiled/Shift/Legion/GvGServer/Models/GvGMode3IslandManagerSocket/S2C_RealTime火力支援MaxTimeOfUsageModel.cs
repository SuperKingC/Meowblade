using System;
using HotFix.Sources.Base.Sources.Scripts.GvG3Common.Model;
using ProtoBuf;
using Shift.Legion.Common.Managers;

namespace Shift.Legion.GvGServer.Models.GvGMode3IslandManagerSocket;

[ProtoContract]
public class S2C_RealTime火力支援MaxTimeOfUsageModel : SocketManager.BaseSocketPackageBodyContext
{
	[ProtoContract]
	public class Request : SocketManager.BaseSocketPackageBody
	{
		[ProtoMember(1, TypeName = "HotFix.Sources.Base.Sources.Scripts.GvG3Common.Model.RealTime火力支援MaxTimeOfUsageModel")]
		public RealTime火力支援MaxTimeOfUsageModel Model;

		[ProtoMember(2)]
		public int 火力支援TimeOfUsage;
	}

	[ProtoContract]
	public class Response : SocketManager.BaseSocketPackageBody
	{
	}

	public static Action<Request> OnPushEvent = delegate
	{
	};

	public S2C_RealTime火力支援MaxTimeOfUsageModel()
	{
		base.PackageId = SocketManager.ePackageId.S2C_RealTime火力支援MaxTimeOfUsageModel;
		base.Resp = new Response();
		base.Req = new Request();
	}

	public override void OnPush()
	{
		OnPushEvent?.Invoke((Request)base.Req);
	}
}
