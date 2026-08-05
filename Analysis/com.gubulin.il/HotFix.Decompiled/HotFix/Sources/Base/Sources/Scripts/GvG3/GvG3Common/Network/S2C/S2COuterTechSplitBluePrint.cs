using System;
using System.Collections.Generic;
using ProtoBuf;
using Shift.Legion.Common.Managers;
using Shift.Legion.Common.Sources.Enums;
using Shift.Legion.GvG.Common.Models;

namespace HotFix.Sources.Base.Sources.Scripts.GvG3.GvG3Common.Network.S2C;

[ProtoContract]
public class S2COuterTechSplitBluePrint : SocketManager.BaseSocketPackageBodyContext
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

	public S2COuterTechSplitBluePrint()
	{
		base.PackageId = SocketManager.ePackageId.S2C_OuterTech_SplitBluePrint;
		base.Resp = new Response();
		base.Req = new Request();
	}

	public override void OnPush()
	{
		Request request = (Request)base.Req;
		if (request.Items != null)
		{
			foreach (RItem item in request.Items)
			{
				GameManagers.Instance.StockController.SetStock(item.ItemId, item.cnt, StockInContext.AutoFill);
			}
		}
		OnPushEvent?.Invoke((Request)base.Req);
	}
}
