using HotFix.Sources.Base.Sources.Scripts.GvG3UI.Model;
using ProtoBuf;
using Shift.Legion.Common.Managers;

namespace Shift.Legion.GvGServer.Models.GvGMode3IslandManagerSocket;

[ProtoContract]
public class C2S_GetUnitDetailInfo : SocketManager.BaseSocketPackageBodyContext
{
	[ProtoContract]
	public class Request : SocketManager.BaseSocketPackageBody
	{
		[ProtoMember(1)]
		public int ShipEntityId;

		[ProtoMember(2)]
		public string SoldierId;
	}

	[ProtoContract]
	public class Response : SocketManager.BaseSocketPackageBody
	{
		[ProtoMember(1)]
		public int ErrorCode;

		[ProtoMember(2)]
		public string jsonGameEntityData;

		[ProtoMember(3)]
		public string EquippedItemsDetail;

		[ProtoMember(4, TypeName = "HotFix.Sources.Base.Sources.Scripts.GvG3UI.Model.RealTimeCombatPowerModel")]
		public RealTimeCombatPowerModel Model;

		[ProtoMember(5)]
		public int RealTimeCombatPower;

		[ProtoMember(6)]
		public float RealTimeAttack;

		[ProtoMember(7)]
		public float RealTimeDefense;

		[ProtoMember(8)]
		public float RealTimeHealth;
	}

	public C2S_GetUnitDetailInfo()
	{
		base.PackageId = SocketManager.ePackageId.C2S_GetUnitDetailInfo;
		base.Resp = new Response();
		base.Req = new Request();
	}
}
