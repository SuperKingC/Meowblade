using ProtoBuf;
using Shift.Legion.Common.Managers;

namespace Shift.Legion.GvGServer.Models.IslandManagerSocket;

[ProtoContract]
public class C2S_GetGvGMode2IZConfig : SocketManager.BaseSocketPackageBodyContext
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
		public string CampScore;

		[ProtoMember(2)]
		public int IZProgress;

		[ProtoMember(3)]
		public int IZBeginTimestamp;

		[ProtoMember(4)]
		public int IZEndTimestamp;

		[ProtoMember(5)]
		public bool IsIZOver;

		[ProtoMember(6)]
		public string IZResult;

		[ProtoMember(7)]
		public int BestKillUserId;

		[ProtoMember(8)]
		public int BestKillCount;

		[ProtoMember(9)]
		public int BestKillCampId;
	}

	public C2S_GetGvGMode2IZConfig()
	{
		base.PackageId = SocketManager.ePackageId.C2S_GetGvGMode2IZConfig;
		base.Resp = new Response();
		base.Req = new Request();
	}
}
