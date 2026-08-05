using System.Collections.Generic;
using ProtoBuf;
using Shift.Legion.Common.Managers;

namespace Shift.Legion.GvGServer.Models.GvGMode3IslandSocket;

[ProtoContract]
public class S2C_BrawlReplayKeyFrame : SocketManager.BaseSocketPackageBodyContext
{
	[ProtoContract]
	public class Request : SocketManager.BaseSocketPackageBody
	{
		[ProtoMember(1)]
		public int EntityId;

		[ProtoMember(2)]
		public int RoleFace;

		[ProtoMember(3)]
		public float X;

		[ProtoMember(4)]
		public float Y;

		[ProtoMember(5)]
		public int GvGMode3State;

		[ProtoMember(6)]
		public byte[] GvGMode3StateData;

		[ProtoMember(7)]
		public List<int> Total;

		[ProtoMember(8)]
		public bool IsDead;
	}

	[ProtoContract]
	public class Response : SocketManager.BaseSocketPackageBody
	{
		[ProtoMember(1)]
		public int ErrorCode;
	}

	public S2C_BrawlReplayKeyFrame()
	{
		base.PackageId = SocketManager.ePackageId.S2C_BrawlReplayKeyFrame;
		base.Req = new Request();
		base.Resp = new Response();
	}
}
