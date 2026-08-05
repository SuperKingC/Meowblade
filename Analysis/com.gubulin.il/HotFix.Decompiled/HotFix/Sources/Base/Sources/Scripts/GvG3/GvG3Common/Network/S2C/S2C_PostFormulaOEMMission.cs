using System;
using System.Collections.Generic;
using ProtoBuf;
using Shift.Legion.ClientApi.Protocol.UserAction;
using Shift.Legion.Common.Managers;
using Shift.Legion.Common.Sources.Enums;
using Shift.Legion.GvG.Common.Models;

namespace HotFix.Sources.Base.Sources.Scripts.GvG3.GvG3Common.Network.S2C;

[ProtoContract]
public class S2C_PostFormulaOEMMission : SocketManager.BaseSocketPackageBodyContext
{
	[ProtoContract]
	public class Request : SocketManager.BaseSocketPackageBody
	{
		[ProtoMember(1)]
		public int ErrorCode;

		[ProtoMember(2, TypeName = "Shift.Legion.GvG.Common.Models.RItem")]
		public List<RItem> GSRItems;

		[ProtoMember(3, TypeName = "Shift.Legion.GvG.Common.Models.RItem")]
		public List<RItem> GvGRItems;
	}

	[ProtoContract]
	public class Response : SocketManager.BaseSocketPackageBody
	{
	}

	public static Action<Request> OnPushEvent = delegate
	{
	};

	public S2C_PostFormulaOEMMission()
	{
		base.PackageId = SocketManager.ePackageId.S2C_PostFormulaOEMMission;
		base.Resp = new Response();
		base.Req = new Request();
	}

	public override void OnPush()
	{
		Request request = (Request)base.Req;
		if (request.GSRItems != null)
		{
			StockChangeRecord[] stockChangeRecords = request.GSRItems.ToStockChangeRecords(StockInContext.AutoFill);
			GameManagers.Instance.StockController.ReadStockChangeRecords(stockChangeRecords);
		}
		OnPushEvent?.Invoke(request);
	}
}
