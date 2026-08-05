using ProtoBuf;
using Shift.Legion.Common.Managers;

namespace Shift.Legion.GvGServer.Models.GvGMode2IslandSocket;

[ProtoContract]
public class C2S_GetGvGMode2Island_IslandInfo : SocketManager.BaseSocketPackageBodyContext
{
	[ProtoContract]
	public class Request : SocketManager.BaseSocketPackageBody
	{
		[ProtoMember(1)]
		public string NonStr;
	}

	[ProtoContract]
	public class Response : SocketManager.BaseSocketPackageBody
	{
		[ProtoMember(1)]
		public int ErrorCode;

		[ProtoMember(2)]
		public int HoldingCamp;

		[ProtoMember(3)]
		public string HoldingPercent;

		[ProtoMember(4)]
		public bool IsStop;

		[ProtoMember(5)]
		public int IslandScore;

		[ProtoMember(6)]
		public int HoldingScorePerSecond;

		[ProtoMember(7)]
		public int IslandCloseTimestamp;

		[ProtoMember(8)]
		public int IslandConfigId;

		[ProtoMember(9)]
		public int WinnerCampId;

		[ProtoMember(10)]
		public int BestKillUserId;

		[ProtoMember(11)]
		public int BestKillCount;

		[ProtoMember(12)]
		public int BestKillCampId;
	}

	public C2S_GetGvGMode2Island_IslandInfo()
	{
		base.PackageId = SocketManager.ePackageId.C2S_GetGvGMode2Island_IslandInfo;
		base.Resp = new Response();
		base.Req = new Request();
	}
}
