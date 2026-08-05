using System.Collections.Generic;
using HotFix.Sources.Base.Sources.Scripts.GvG3Common.Model;
using ProtoBuf;
using Shift.Legion.Common.Managers;
using Shift.Legion.GvG.Common.Models.GvGMode3.Collecting;

namespace Shift.Legion.GvGServer.Models.GvGMode3IslandManagerSocket;

[ProtoContract]
public class C2S_GetShipCollectingDetailInfo : SocketManager.BaseSocketPackageBodyContext
{
	[ProtoContract]
	public class Request : SocketManager.BaseSocketPackageBody
	{
		[ProtoMember(1)]
		public int ShipEntityId;
	}

	[ProtoContract]
	public class Response : SocketManager.BaseSocketPackageBody
	{
		[ProtoMember(1)]
		public int ErrorCode;

		[ProtoMember(2)]
		public int ShipState;

		[ProtoMember(3)]
		public int ShipTargetId;

		[ProtoMember(4)]
		public List<string> CurChooseStockModel;

		[ProtoMember(5, TypeName = "Shift.Legion.GvG.Common.Models.GvGMode3.Collecting.CollectingStockModel")]
		public List<CollectingStockModel> IslandStockModels;

		[ProtoMember(6, TypeName = "HotFix.Sources.Base.Sources.Scripts.GvG3Common.Model.RealTimeCollectingEfficiencyModel")]
		public RealTimeCollectingEfficiencyModel CollectingEfficiencyModel;

		[ProtoMember(7)]
		public float AvgCollectingEfficiency;

		[ProtoMember(8, TypeName = "Shift.Legion.GvG.Common.Models.GvGMode3.Collecting.RealTimeShipSummarySpeedModel")]
		public RealTimeShipSummarySpeedModel ShipSummarySpeedModel;

		[ProtoMember(9)]
		public int ShipSummarySpeed;
	}

	public C2S_GetShipCollectingDetailInfo()
	{
		base.PackageId = SocketManager.ePackageId.C2S_GetShipCollectingDetailInfo;
		base.Resp = new Response();
		base.Req = new Request();
	}
}
