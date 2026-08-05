using System.Collections.Generic;
using HotFix.Sources.Base.Sources.Scripts.GvG3WorldMap.Model;
using ProtoBuf;
using Shift.Legion.Common.Managers;

namespace Shift.Legion.GvGServer.Models.GvGMode3IslandManagerSocket;

[ProtoContract]
public class C2S_UseTalent勘探强化Detect : SocketManager.BaseSocketPackageBodyContext
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

		[ProtoMember(2, TypeName = "HotFix.Sources.Base.Sources.Scripts.GvG3WorldMap.Model.IslandResource_勘探强化")]
		public List<IslandResource_勘探强化> IslandResource_List;

		[ProtoMember(3, TypeName = "HotFix.Sources.Base.Sources.Scripts.GvG3WorldMap.Model.ShipCountDown_勘探强化")]
		public ShipCountDown_勘探强化 ShipCountDown;

		[ProtoMember(4)]
		public int X;

		[ProtoMember(5)]
		public int Y;
	}

	public C2S_UseTalent勘探强化Detect()
	{
		base.PackageId = SocketManager.ePackageId.C2S_UseTalent勘探强化Detect;
		base.Resp = new Response();
		base.Req = new Request();
	}
}
