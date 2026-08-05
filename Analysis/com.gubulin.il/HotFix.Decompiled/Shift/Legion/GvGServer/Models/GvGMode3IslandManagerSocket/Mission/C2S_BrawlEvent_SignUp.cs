using System.Collections.Generic;
using ProtoBuf;
using Shift.Legion.Common.Managers;
using Shift.Legion.GvG.Common.Models.GvGMode3.Mission.BrawlEvent;

namespace Shift.Legion.GvGServer.Models.GvGMode3IslandManagerSocket.Mission;

[ProtoContract]
public class C2S_BrawlEvent_SignUp : SocketManager.BaseSocketPackageBodyContext
{
	[ProtoContract]
	public class Request : SocketManager.BaseSocketPackageBody
	{
		[ProtoMember(1)]
		public string ShipId;

		[ProtoMember(2)]
		public int IslandId;

		[ProtoMember(3)]
		public int ZoneId;

		[ProtoMember(4)]
		public int BattleStrategy;
	}

	[ProtoContract]
	public class Response : SocketManager.BaseSocketPackageBody
	{
		[ProtoMember(1)]
		public int ErrorCode;

		[ProtoMember(2, TypeName = "Shift.Legion.GvG.Common.Models.GvGMode3.Mission.BrawlEvent.BE_SignUpDataModel_ToProtocol")]
		public List<BE_SignUpDataModel_ToProtocol> SelfSignUpDatas;

		[ProtoMember(3, TypeName = "Shift.Legion.GvG.Common.Models.GvGMode3.Mission.BrawlEvent.BE_SignUpDataModel_ToProtocol2")]
		public List<BE_SignUpDataModel_ToProtocol2> SignUpDatas;
	}

	public C2S_BrawlEvent_SignUp()
	{
		base.PackageId = SocketManager.ePackageId.C2S_BrawlEvent_SignUp;
		base.Resp = new Response();
		base.Req = new Request();
	}
}
