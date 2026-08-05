using System.Collections.Generic;
using HotFix.Sources.Base.Sources.Scripts.GvG3Common.Model;
using ProtoBuf;
using Shift.Legion.Common.Managers;

namespace Shift.Legion.GvGServer.Models.GvGMode3IslandSocket;

[ProtoContract]
public class S2C_BrawlReplayCreateShip : SocketManager.BaseSocketPackageBodyContext
{
	[ProtoContract]
	public class Request : SocketManager.BaseSocketPackageBody
	{
		[ProtoMember(1)]
		public int EntityId;

		[ProtoMember(2)]
		public int UserId;

		[ProtoMember(3)]
		public int CampId;

		[ProtoMember(4)]
		public string FormationId;

		[ProtoMember(5)]
		public float GroupSpeed;

		[ProtoMember(6)]
		public int BattleStrategy;

		[ProtoMember(9)]
		public int RoleFace;

		[ProtoMember(10, TypeName = "HotFix.Sources.Base.Sources.Scripts.GvG3Common.Model.UnitInfo_Protocol")]
		public List<UnitInfo_Protocol> UnitsInfo;

		[ProtoMember(11)]
		public float X;

		[ProtoMember(12)]
		public float Y;

		[ProtoMember(16)]
		public float GroupIconSize;

		[ProtoMember(17)]
		public float debug_MatrixWidth;

		[ProtoMember(19)]
		public int GvGMode3State;

		[ProtoMember(20)]
		public byte[] GvGMode3StateData;

		[ProtoMember(41)]
		public int ShipRace;

		[ProtoMember(42)]
		public int ShipSkinId;

		[ProtoMember(43)]
		public string ShipId;

		[ProtoMember(45)]
		public string Icon;

		[ProtoMember(51)]
		public int GvGRole;
	}

	[ProtoContract]
	public class Response : SocketManager.BaseSocketPackageBody
	{
		[ProtoMember(1)]
		public int ErrorCode;
	}

	public S2C_BrawlReplayCreateShip()
	{
		base.PackageId = SocketManager.ePackageId.S2C_BrawlReplayCreateShip;
		base.Req = new Request();
		base.Resp = new Response();
	}
}
