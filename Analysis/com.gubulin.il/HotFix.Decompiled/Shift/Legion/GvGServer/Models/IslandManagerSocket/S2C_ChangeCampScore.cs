using System;
using ProtoBuf;
using Shift.Legion.Common.Managers;

namespace Shift.Legion.GvGServer.Models.IslandManagerSocket;

[ProtoContract]
public class S2C_ChangeCampScore : SocketManager.BaseSocketPackageBodyContext
{
	[ProtoContract]
	public class Request : SocketManager.BaseSocketPackageBody
	{
		[ProtoMember(1)]
		public string CampScore;

		[ProtoMember(2)]
		public int ChangeCampId;

		[ProtoMember(3)]
		public int ChangeScore;

		[ProtoMember(4)]
		public int StopIslandConfigId;
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

	public S2C_ChangeCampScore()
	{
		base.PackageId = SocketManager.ePackageId.S2C_ChangeCampScore;
		base.Req = new Request();
		base.Resp = new Response();
	}

	public override void OnPush()
	{
		OnPushEvent?.Invoke((Request)base.Req);
	}
}
