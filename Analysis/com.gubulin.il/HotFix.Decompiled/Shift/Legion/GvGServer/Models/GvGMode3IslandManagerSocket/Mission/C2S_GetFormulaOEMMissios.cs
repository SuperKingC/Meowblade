using System.Collections.Generic;
using HotFix.Sources.Base.Sources.Scripts.GvG3.GvG3Common.Model.Oem;
using ProtoBuf;
using Shift.Legion.Common.Managers;

namespace Shift.Legion.GvGServer.Models.GvGMode3IslandManagerSocket.Mission;

[ProtoContract]
public class C2S_GetFormulaOEMMissios : SocketManager.BaseSocketPackageBodyContext
{
	[ProtoContract]
	public class Request : SocketManager.BaseSocketPackageBody
	{
		[ProtoMember(1, TypeName = "HotFix.Sources.Base.Sources.Scripts.GvG3.GvG3Common.Model.Oem.FormulaOemMissionsFilter")]
		public FormulaOemMissionsFilter Filter;

		[ProtoMember(3)]
		public int PageNumber;

		[ProtoMember(4)]
		public int PageCount;
	}

	[ProtoContract]
	public class Response : SocketManager.BaseSocketPackageBody
	{
		[ProtoMember(1)]
		public int ErrorCode;

		[ProtoMember(2, TypeName = "HotFix.Sources.Base.Sources.Scripts.GvG3.GvG3Common.Model.Oem.FormulaOEMMissionsDetail")]
		public List<FormulaOEMMissionsDetail> Details;

		[ProtoMember(3)]
		public int PageNumber;

		[ProtoMember(4)]
		public int PageMax;
	}

	public C2S_GetFormulaOEMMissios()
	{
		base.PackageId = SocketManager.ePackageId.C2S_GetFormulaOEMMissions;
		base.Resp = new Response();
		base.Req = new Request();
	}
}
