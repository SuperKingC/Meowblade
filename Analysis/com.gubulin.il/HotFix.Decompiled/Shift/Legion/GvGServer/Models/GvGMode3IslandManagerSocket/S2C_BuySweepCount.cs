using System;
using System.Collections.Generic;
using ProtoBuf;
using Shift.Legion.ClientApi.Protocol.UserAction;
using Shift.Legion.Common.Managers;
using Shift.Legion.Common.Sources.Enums;
using Shift.Legion.GvG.Common.Models;

namespace Shift.Legion.GvGServer.Models.GvGMode3IslandManagerSocket;

[ProtoContract]
public class S2C_BuySweepCount : SocketManager.BaseSocketPackageBodyContext
{
	[ProtoContract]
	public class Request : SocketManager.BaseSocketPackageBody
	{
		[ProtoMember(1)]
		public int ErrorCode;

		[ProtoMember(2)]
		public int RemainingSweepCount;

		[ProtoMember(3)]
		public int TodayPurchasedCount;

		[ProtoMember(4)]
		public int TodayRefillCountByPurchase;

		[ProtoMember(5, TypeName = "Shift.Legion.GvG.Common.Models.RItem")]
		public List<RItem> GsItems;
	}

	[ProtoContract]
	public class Response : SocketManager.BaseSocketPackageBody
	{
	}

	public static Action<Request> OnPushEvent = delegate
	{
	};

	public S2C_BuySweepCount()
	{
		base.PackageId = SocketManager.ePackageId.S2C_BuySweepCount;
		base.Resp = new Response();
		base.Req = new Request();
	}

	public override void OnPush()
	{
		Request request = (Request)base.Req;
		if (request.GsItems != null)
		{
			StockChangeRecord[] stockChangeRecords = request.GsItems.ToStockChangeRecords(StockInContext.AutoFill);
			GameManagers.Instance.StockController.ReadStockChangeRecords(stockChangeRecords);
		}
		OnPushEvent?.Invoke(request);
	}
}
