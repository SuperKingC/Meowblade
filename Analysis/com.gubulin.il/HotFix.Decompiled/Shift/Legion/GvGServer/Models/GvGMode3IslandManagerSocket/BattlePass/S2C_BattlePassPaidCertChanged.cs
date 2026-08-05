using System;
using ProtoBuf;
using Shift.Legion.Common.Managers;

namespace Shift.Legion.GvGServer.Models.GvGMode3IslandManagerSocket.BattlePass;

public class S2C_BattlePassPaidCertChanged : SocketManager.BaseSocketPackageBodyContext
{
	[ProtoContract]
	public class Request : SocketManager.BaseSocketPackageBody
	{
		[ProtoMember(99)]
		public int ErrorCode;

		[ProtoMember(1)]
		public bool HasPaidCert;

		[ProtoMember(2)]
		public bool HasPremiumPaidCert;

		[ProtoMember(3)]
		public int BattlePassInsuranceTimes;
	}

	[ProtoContract]
	public class Response : SocketManager.BaseSocketPackageBody
	{
	}

	public static Action<Request> OnPushEvent = delegate
	{
	};

	public S2C_BattlePassPaidCertChanged()
	{
		base.PackageId = SocketManager.ePackageId.S2C_BattlePassPaidCertChanged;
		base.Resp = new Response();
		base.Req = new Request();
	}

	public override void OnPush()
	{
		OnPushEvent?.Invoke((Request)base.Req);
	}
}
