using System.Collections.Generic;
using HotFix.Sources.Base.Sources.Scripts.GvG3Common.Model;
using ProtoBuf;
using Shift.Legion.Common.Managers;

namespace Shift.Legion.GvGServer.Models.GvGMode3IslandManagerSocket;

[ProtoContract]
public class C2S_ChangeShipCollectingInfo : SocketManager.BaseSocketPackageBodyContext
{
	[ProtoContract]
	public class Request : SocketManager.BaseSocketPackageBody
	{
		[ProtoMember(1)]
		public int ShipEntityId;

		[ProtoMember(2)]
		public List<string> StockModelIds;
	}

	[ProtoContract]
	public class Response : SocketManager.BaseSocketPackageBody
	{
		[ProtoMember(1)]
		public int ErrorCode;

		[ProtoMember(3)]
		public List<string> SelectedCollectingStockModelIds;

		[ProtoMember(4, TypeName = "HotFix.Sources.Base.Sources.Scripts.GvG3Common.Model.RealTimeCollectingEfficiencyModel")]
		public RealTimeCollectingEfficiencyModel CollectingEfficiencyModel;
	}

	public C2S_ChangeShipCollectingInfo()
	{
		base.PackageId = SocketManager.ePackageId.C2S_ChangeShipCollectingInfo;
		base.Resp = new Response();
		base.Req = new Request();
	}
}
