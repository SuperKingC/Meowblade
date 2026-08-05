using System.Collections.Generic;
using ProtoBuf;
using Shift.Legion.Common.Managers;
using Shift.Legion.GvG.Common.Models;

namespace HotFix.Sources.Base.Sources.Scripts.GvG3.GvG3Common.Network.C2S;

[ProtoContract]
public class C2SOuterTechSplitBluePrint : SocketManager.BaseSocketPackageBodyContext
{
	[ProtoContract]
	public class Request : SocketManager.BaseSocketPackageBody
	{
		[ProtoMember(1)]
		public string BluePrintId;
	}

	[ProtoContract]
	public class Response : SocketManager.BaseSocketPackageBody
	{
		[ProtoMember(1)]
		public int ErrorCode;

		[ProtoMember(2, TypeName = "Shift.Legion.GvG.Common.Models.RItem")]
		public List<RItem> RItems;
	}

	public C2SOuterTechSplitBluePrint()
	{
		base.PackageId = SocketManager.ePackageId.C2S_OuterTech_SplitBluePrint;
		base.Resp = new Response();
		base.Req = new Request();
	}
}
