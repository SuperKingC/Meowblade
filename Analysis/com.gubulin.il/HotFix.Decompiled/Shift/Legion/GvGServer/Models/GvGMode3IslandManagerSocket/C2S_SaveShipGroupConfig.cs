using System.Collections.Generic;
using HotFix.Sources.Base.Sources.Scripts.GvG3Common.Model;
using ProtoBuf;
using Shift.Legion.Common.Managers;

namespace Shift.Legion.GvGServer.Models.GvGMode3IslandManagerSocket;

[ProtoContract]
public class C2S_SaveShipGroupConfig : SocketManager.BaseSocketPackageBodyContext
{
	[ProtoContract]
	public class Request : SocketManager.BaseSocketPackageBody
	{
		[ProtoMember(2)]
		public string ShipId;

		[ProtoMember(3)]
		public string FormationId;

		[ProtoMember(4)]
		public List<string> SoldierIds = new List<string>();

		[ProtoMember(5)]
		public List<string> BackupSoldierIds = new List<string>();
	}

	[ProtoContract]
	public class Response : SocketManager.BaseSocketPackageBody
	{
		[ProtoMember(1)]
		public int ErrorCode;

		[ProtoMember(2, TypeName = "HotFix.Sources.Base.Sources.Scripts.GvG3Common.Model.GvGMode3UnitInfo")]
		public List<GvGMode3UnitInfo> On_Group;

		[ProtoMember(3, TypeName = "HotFix.Sources.Base.Sources.Scripts.GvG3Common.Model.GvGMode3UnitInfo")]
		public List<GvGMode3UnitInfo> On_BackUpGroup;

		[ProtoMember(4)]
		public string FormationId;

		[ProtoMember(5)]
		public bool IsSaveConfig;
	}

	public C2S_SaveShipGroupConfig()
	{
		base.PackageId = SocketManager.ePackageId.C2S_SaveShipGroupConfig;
		base.Resp = new Response();
		base.Req = new Request();
	}
}
