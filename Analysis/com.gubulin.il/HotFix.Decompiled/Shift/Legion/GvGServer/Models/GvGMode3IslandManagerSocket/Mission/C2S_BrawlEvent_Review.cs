using System.Collections.Generic;
using HotFix.Sources.Base.Sources.Scripts.GvG3Common.Model;
using ProtoBuf;
using Shift.Legion.Common.Managers;
using Shift.Legion.GvG.Common.Models.GvGMode3.BrawlEvent;
using Shift.Legion.GvG.Common.Models.GvGMode3.Mission.BrawlEvent;

namespace Shift.Legion.GvGServer.Models.GvGMode3IslandManagerSocket.Mission;

[ProtoContract]
public class C2S_BrawlEvent_Review : SocketManager.BaseSocketPackageBodyContext
{
	[ProtoContract]
	public class Request : SocketManager.BaseSocketPackageBody
	{
		[ProtoMember(1)]
		public int Non;
	}

	[ProtoContract]
	public class Response : SocketManager.BaseSocketPackageBody
	{
		[ProtoMember(1)]
		public int ErrorCode;

		[ProtoMember(2, TypeName = "Shift.Legion.GvG.Common.Models.GvGMode3.BrawlEvent.ReviewResult")]
		public List<ReviewResult> ReviewResults;

		[ProtoMember(3, TypeName = "Shift.Legion.GvG.Common.Models.GvGMode3.BrawlEvent.ReviewTotal")]
		public List<ReviewTotal> ReviewTotals;

		[ProtoMember(4, TypeName = "Shift.Legion.GvG.Common.Models.GvGMode3.Mission.BrawlEvent.BE_SignUpDataModel_ToProtocol")]
		public List<BE_SignUpDataModel_ToProtocol> SignUpDatas;

		[ProtoMember(5)]
		public int StepIdx;

		public eRace GetPlayerSignUpShipRaceByIslandId(int islandId)
		{
			if (SignUpDatas == null || SignUpDatas.Count == 0)
			{
				return eRace.Invalid;
			}
			return (eRace)(SignUpDatas.Find((BE_SignUpDataModel_ToProtocol x) => x.IslandId == islandId)?.ShipRace ?? (-2));
		}
	}

	public C2S_BrawlEvent_Review()
	{
		base.PackageId = SocketManager.ePackageId.C2S_BrawlEvent_Review;
		base.Resp = new Response();
		base.Req = new Request();
	}
}
