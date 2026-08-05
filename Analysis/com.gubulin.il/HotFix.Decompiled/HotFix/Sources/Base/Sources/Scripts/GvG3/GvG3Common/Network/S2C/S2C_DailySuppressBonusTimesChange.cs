using System;
using ProtoBuf;
using Shift.Legion.Common.Managers;
using Shift.Legion.GvGServer.Models.GvGMode3IslandManagerSocket;

namespace HotFix.Sources.Base.Sources.Scripts.GvG3.GvG3Common.Network.S2C;

[ProtoContract]
public class S2C_DailySuppressBonusTimesChange : SocketManager.BaseSocketPackageBodyContext
{
	[ProtoContract]
	public class Request : SocketManager.BaseSocketPackageBody
	{
		[ProtoMember(1, TypeName = "Shift.Legion.GvGServer.Models.GvGMode3IslandManagerSocket.DailySuppressBonusModel")]
		public DailySuppressBonusModel DailySuppressBonusModel;
	}

	[ProtoContract]
	public class Response : SocketManager.BaseSocketPackageBody
	{
	}

	public static Action<Request> OnPushEvent = delegate
	{
	};

	public S2C_DailySuppressBonusTimesChange()
	{
		base.PackageId = SocketManager.ePackageId.S2C_DailySuppressBonusTimesChange;
		base.Resp = new Response();
		base.Req = new Request();
	}

	public override void OnPush()
	{
		OnPushEvent?.Invoke((Request)base.Req);
	}
}
