using System.Collections.Generic;
using ProtoBuf;
using Shift.Legion.Common.Managers;
using Shift.Legion.GvG.Common.Models;

namespace Shift.Legion.GvGServer.Models.GvGMode3IslandManagerSocket.OuterTech;

[ProtoContract]
public class C2S_OuterTechAmpTransform : SocketManager.BaseSocketPackageBodyContext
{
	[ProtoContract]
	public class Request : SocketManager.BaseSocketPackageBody
	{
		[ProtoMember(1)]
		public string Rarity;

		[ProtoMember(2)]
		public RItem InputAmp;

		[ProtoMember(3, TypeName = "Shift.Legion.GvG.Common.Models.RItem")]
		public List<RItem> OutputItems;
	}

	[ProtoContract]
	public class Response : SocketManager.BaseSocketPackageBody
	{
		[ProtoMember(1)]
		public int ErrorCode;

		[ProtoMember(2, TypeName = "Shift.Legion.GvG.Common.Models.RItem")]
		public List<RItem> RItems;
	}

	public C2S_OuterTechAmpTransform()
	{
		base.PackageId = SocketManager.ePackageId.C2S_OuterTechAmpTransform;
		base.Resp = new Response();
		base.Req = new Request();
	}
}
