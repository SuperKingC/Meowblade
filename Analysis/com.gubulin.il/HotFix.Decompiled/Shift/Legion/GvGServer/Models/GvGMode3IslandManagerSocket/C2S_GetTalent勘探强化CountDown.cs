using System.Collections.Generic;
using HotFix.Sources.Base.Sources.Scripts.GvG3WorldMap.Model;
using ProtoBuf;
using Shift.Legion.Common.Managers;

namespace Shift.Legion.GvGServer.Models.GvGMode3IslandManagerSocket;

[ProtoContract]
public class C2S_GetTalent勘探强化CountDown : SocketManager.BaseSocketPackageBodyContext
{
	[ProtoContract]
	public class Request : SocketManager.BaseSocketPackageBody
	{
		[ProtoMember(1)]
		public string NonStr;
	}

	[ProtoContract]
	public class Response : SocketManager.BaseSocketPackageBody
	{
		[ProtoMember(1)]
		public int ErrorCode;

		[ProtoMember(2, TypeName = "HotFix.Sources.Base.Sources.Scripts.GvG3WorldMap.Model.ShipCountDown_勘探强化")]
		public List<ShipCountDown_勘探强化> ShipCountDown_List;
	}

	public C2S_GetTalent勘探强化CountDown()
	{
		base.PackageId = SocketManager.ePackageId.C2S_GetTalent勘探强化CountDown;
		base.Resp = new Response();
		base.Req = new Request();
	}
}
