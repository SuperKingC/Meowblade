using System.Collections.Generic;
using HotFix.Sources.Base.Sources.Scripts.GvG3Common.Model;
using ProtoBuf;
using Shift.Legion.Common.Managers;
using Shift.Legion.GvG.Common.Models;

namespace Shift.Legion.GvGServer.Models.GvGMode3IslandManagerSocket.Mission;

[ProtoContract]
public class C2S_SubmitOEMMission : SocketManager.BaseSocketPackageBodyContext
{
	[ProtoContract]
	public class Request : SocketManager.BaseSocketPackageBody
	{
		[ProtoMember(1)]
		public int MUID;
	}

	[ProtoContract]
	public class Response : SocketManager.BaseSocketPackageBody
	{
		[ProtoMember(1)]
		public int ErrorCode;

		[ProtoMember(2, TypeName = "HotFix.Sources.Base.Sources.Scripts.GvG3Common.Model.OEMGiverBonus")]
		public OEMGiverBonus GiverBonus;

		[ProtoMember(3, TypeName = "HotFix.Sources.Base.Sources.Scripts.GvG3Common.Model.OEMGiverBonus")]
		public OEMTakerBonus TakerBonus;

		[ProtoMember(4, TypeName = "Shift.Legion.GvG.Common.Models.RItem")]
		public List<RItem> TakerStorehouseChanged;
	}

	public C2S_SubmitOEMMission()
	{
		base.PackageId = SocketManager.ePackageId.C2S_SubmitOEMMission;
		base.Resp = new Response();
		base.Req = new Request();
	}
}
