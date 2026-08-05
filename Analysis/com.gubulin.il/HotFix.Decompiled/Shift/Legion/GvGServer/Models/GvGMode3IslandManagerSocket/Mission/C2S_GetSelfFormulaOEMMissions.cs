using System.Collections.Generic;
using HotFix.Sources.Base.Sources.Scripts.GvG3.GvG3Common.Model.Oem;
using ProtoBuf;
using Shift.Legion.Common.Managers;

namespace Shift.Legion.GvGServer.Models.GvGMode3IslandManagerSocket.Mission;

[ProtoContract]
public class C2S_GetSelfFormulaOEMMissions : SocketManager.BaseSocketPackageBodyContext
{
	[ProtoContract]
	public class Request : SocketManager.BaseSocketPackageBody
	{
		[ProtoMember(1)]
		public int non;
	}

	[ProtoContract]
	public class Response : SocketManager.BaseSocketPackageBody
	{
		[ProtoMember(1)]
		public int ErrorCode;

		[ProtoMember(2, TypeName = "HotFix.Sources.Base.Sources.Scripts.GvG3.GvG3Common.Model.Oem.FormulaOEMMissionsSelfRecord")]
		public List<FormulaOEMMissionsSelfRecord> Records;
	}

	public C2S_GetSelfFormulaOEMMissions()
	{
		base.PackageId = SocketManager.ePackageId.C2S_GetSelfFormulaOEMMissions;
		base.Resp = new Response();
		base.Req = new Request();
	}
}
