using System;
using System.Collections.Generic;
using ProtoBuf;
using Shift.Legion.Common.Managers;
using Shift.Legion.GvG.Common.Models;
using Shift.Legion.Helpers;

namespace Shift.Legion.GvGServer.Models.IslandManagerSocket;

[ProtoContract]
public class S2C_ChangeShipSummaryStateShipFillingUp : SocketManager.BaseSocketPackageBodyContext
{
	[ProtoContract]
	public class Request : SocketManager.BaseSocketPackageBody
	{
		[ProtoMember(1)]
		public int ShipSummaryState;

		[ProtoMember(2)]
		public int ShipSummaryStayIslandId;

		[ProtoMember(3)]
		public string JsonFillUpTimestamp;

		[ProtoMember(4, TypeName = "Shift.Legion.GvG.Common.Models.ShipSummaryUnitInfo")]
		public List<ShipSummaryUnitInfo> FillUpSoldiers;

		[ProtoMember(5)]
		public int StartFillUpTimestamp;

		[ProtoMember(6, TypeName = "Shift.Legion.GvG.Common.Models.ShipSummaryUnitInfo")]
		public List<ShipSummaryUnitInfo> StartFillUpSoldiers;

		[ProtoMember(7)]
		public string JsonStockInfoBeforeFillUp;

		private Dictionary<string, int> _fillUpTimestamp = new Dictionary<string, int>();

		private Dictionary<string, int> _stockInfoBeforeFillUp = new Dictionary<string, int>();

		public Dictionary<string, int> FillUpTimestamp
		{
			get
			{
				if ((_fillUpTimestamp == null || _fillUpTimestamp.Count <= 0) && !string.IsNullOrEmpty(JsonFillUpTimestamp))
				{
					_fillUpTimestamp = JsonHelper.ToObject<Dictionary<string, int>>(JsonFillUpTimestamp);
				}
				return _fillUpTimestamp ?? (_fillUpTimestamp = new Dictionary<string, int>());
			}
			set
			{
				_fillUpTimestamp = value;
				JsonFillUpTimestamp = JsonHelper.ToJson(_fillUpTimestamp);
			}
		}

		public Dictionary<string, int> StockInfoBeforeFillUp
		{
			get
			{
				if ((_stockInfoBeforeFillUp == null || _stockInfoBeforeFillUp.Count <= 0) && !string.IsNullOrEmpty(JsonStockInfoBeforeFillUp))
				{
					_stockInfoBeforeFillUp = JsonHelper.ToObject<Dictionary<string, int>>(JsonStockInfoBeforeFillUp);
				}
				return _stockInfoBeforeFillUp ?? (_stockInfoBeforeFillUp = new Dictionary<string, int>());
			}
			set
			{
				_stockInfoBeforeFillUp = value;
				JsonStockInfoBeforeFillUp = JsonHelper.ToJson(_stockInfoBeforeFillUp);
			}
		}
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

	public S2C_ChangeShipSummaryStateShipFillingUp()
	{
		base.PackageId = SocketManager.ePackageId.S2C_ChangeShipSummaryStateShipFillingUp;
		base.Req = new Request();
		base.Resp = new Response();
	}

	public override void OnPush()
	{
		OnPushEvent?.Invoke((Request)base.Req);
	}
}
