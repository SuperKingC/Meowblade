using System.Collections.Generic;
using ProtoBuf;
using Shift.Legion.Common.Managers;
using Shift.Legion.GvG.Common.Models.GvGMode3;

namespace Shift.Legion.GvGServer.Models.GvGMode3IslandManagerSocket;

[ProtoContract]
public class C2S_GetSystemMessages_IslandBattleLog : SocketManager.BaseSocketPackageBodyContext
{
	[ProtoContract]
	public class Request : SocketManager.BaseSocketPackageBody
	{
		[ProtoMember(1)]
		public int StartId;

		[ProtoMember(2)]
		public int IslandId;
	}

	[ProtoContract]
	public class Response : SocketManager.BaseSocketPackageBody
	{
		[ProtoMember(1)]
		public int ErrorCode;

		[ProtoMember(2, TypeName = "Shift.Legion.GvG.Common.Models.GvGMode3.GvGMode3ChatRecord")]
		public List<GvGMode3ChatRecord> RecordList;

		[ProtoMember(3, TypeName = "Shift.Legion.GvGServer.Models.GvGMode3IslandManagerSocket.C2S_GetSystemMessages_IslandBattleLog.RunningBattleLog")]
		public RunningBattleLog RunningLog;
	}

	[ProtoContract]
	public class RunningBattleLog
	{
		[ProtoMember(1)]
		public int IslandId;

		[ProtoMember(2)]
		public int OriginalCampId;

		[ProtoMember(3)]
		public int ProcessStartByWhichCamp;

		[ProtoMember(4)]
		public long Timestamp_ms;
	}

	public C2S_GetSystemMessages_IslandBattleLog()
	{
		base.PackageId = SocketManager.ePackageId.C2S_GetSystemMessages_IslandBattleLog;
		base.Resp = new Response();
		base.Req = new Request();
	}
}
