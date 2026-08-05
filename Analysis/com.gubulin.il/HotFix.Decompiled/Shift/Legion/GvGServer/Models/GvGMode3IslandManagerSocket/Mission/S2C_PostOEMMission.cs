using System;
using System.Collections.Generic;
using HotFix.Sources.Base.Scripts.Helper;
using ProtoBuf;
using Shift.Legion.ClientApi.Protocol.UserAction;
using Shift.Legion.Common.Managers;
using Shift.Legion.Common.Sources.Enums;
using Shift.Legion.GvG.Common.Models;

namespace Shift.Legion.GvGServer.Models.GvGMode3IslandManagerSocket.Mission;

[ProtoContract]
public class S2C_PostOEMMission : SocketManager.BaseSocketPackageBodyContext
{
	[ProtoContract]
	public class Request : SocketManager.BaseSocketPackageBody
	{
		[ProtoMember(1)]
		public int ErrorCode;

		[ProtoMember(2, TypeName = "Shift.Legion.GvG.Common.Models.RItem")]
		public List<RItem> GSRItems;

		public void SyncGsStockChange()
		{
			if (GSRItems != null && GSRItems.Count > 0)
			{
				StockChangeRecord[] stockChangeRecords = GSRItems.ToDict().ToStockChangeRecords(StockInContext.GvGMode3Mission_PostOEM, "PostOEMMission");
				GameManagers.Instance.StockController.ReadStockChangeRecords(stockChangeRecords);
			}
		}
	}

	[ProtoContract]
	public class Response : SocketManager.BaseSocketPackageBody
	{
	}

	public static Action<Request> OnPushEvent = delegate
	{
	};

	public S2C_PostOEMMission()
	{
		base.PackageId = SocketManager.ePackageId.S2C_PostOEMMission;
		base.Resp = new Response();
		base.Req = new Request();
	}

	public override void OnPush()
	{
		OnPushEvent?.Invoke((Request)base.Req);
	}
}
