using System.Collections.Generic;
using ProtoBuf;
using Shift.Legion.Common.Managers;
using Shift.Legion.GvG.Common.Models;

namespace Shift.Legion.GvGServer.Models.GvGMode3IslandManagerSocket.Mission;

[ProtoContract]
public class C2S_FinishNPCDialogMission : SocketManager.BaseSocketPackageBodyContext
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

		[ProtoMember(2, TypeName = "Shift.Legion.GvG.Common.Models.RItem")]
		public List<RItem> StorehouseChanged;
	}

	public C2S_FinishNPCDialogMission()
	{
		base.PackageId = SocketManager.ePackageId.C2S_FinishNPCDialogMission;
		base.Resp = new Response();
		base.Req = new Request();
	}
}
