using System;
using ProtoBuf;
using Shift.Legion.Common.Managers;

namespace Shift.Legion.GvGServer.Models.GvGMode3IslandSocket;

[ProtoContract]
public class S2C_GvGStateChange : SocketManager.BaseSocketPackageBodyContext
{
	[ProtoContract]
	public class Request : SocketManager.BaseSocketPackageBody
	{
		[ProtoMember(1)]
		public int EntityId;

		[ProtoMember(2)]
		public int State;

		[ProtoMember(3)]
		public float X;

		[ProtoMember(4)]
		public float Y;

		[ProtoMember(5)]
		public int RoleFace;

		[ProtoMember(6)]
		public byte[] Data;

		[ProtoMember(7)]
		public int HoldingScorePerSecond;

		[ProtoMember(8)]
		public bool IsInsuranceShip;
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

	public S2C_GvGStateChange()
	{
		base.PackageId = SocketManager.ePackageId.S2C_GvGStateChange;
		base.Req = new Request();
		base.Resp = new Response();
	}

	public override void OnPush()
	{
		OnPushEvent?.Invoke((Request)base.Req);
	}
}
