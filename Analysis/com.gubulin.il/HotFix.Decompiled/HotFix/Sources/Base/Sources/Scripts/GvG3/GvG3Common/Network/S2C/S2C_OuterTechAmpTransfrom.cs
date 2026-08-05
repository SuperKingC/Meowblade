using System;
using System.Collections.Generic;
using ProtoBuf;
using Shift.Legion.Common.Managers;
using Shift.Legion.GvG.Common.Models;

namespace HotFix.Sources.Base.Sources.Scripts.GvG3.GvG3Common.Network.S2C;

[ProtoContract]
public class S2C_OuterTechAmpTransfrom : SocketManager.BaseSocketPackageBodyContext
{
	[ProtoContract]
	public class Request : SocketManager.BaseSocketPackageBody
	{
		[ProtoMember(99)]
		public int ErrorCode;

		[ProtoMember(1, TypeName = "Shift.Legion.GvG.Common.Models.RItem")]
		public List<RItem> Items;

		[ProtoMember(3)]
		public int StockInContext;
	}

	[ProtoContract]
	public class Response : SocketManager.BaseSocketPackageBody
	{
	}

	public static Action<Request> OnPushEvent = delegate
	{
	};

	public S2C_OuterTechAmpTransfrom()
	{
		base.PackageId = SocketManager.ePackageId.S2C_OuterTechAmpTransfrom;
		base.Resp = new Response();
		base.Req = new Request();
	}

	public override void OnPush()
	{
		OnPushEvent?.Invoke((Request)base.Req);
	}
}
