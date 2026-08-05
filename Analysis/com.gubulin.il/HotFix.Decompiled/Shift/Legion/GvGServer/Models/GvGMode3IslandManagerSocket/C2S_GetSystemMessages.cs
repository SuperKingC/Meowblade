using System.Collections.Generic;
using ProtoBuf;
using Shift.Legion.Common.Managers;
using Shift.Legion.GvG.Common.Models.GvGMode3;

namespace Shift.Legion.GvGServer.Models.GvGMode3IslandManagerSocket;

[ProtoContract]
public class C2S_GetSystemMessages : SocketManager.BaseSocketPackageBodyContext
{
	[ProtoContract]
	public class Request : SocketManager.BaseSocketPackageBody
	{
		[ProtoMember(1)]
		public long StartId;
	}

	[ProtoContract]
	public class Response : SocketManager.BaseSocketPackageBody
	{
		[ProtoMember(1)]
		public int ErrorCode;

		[ProtoMember(2, TypeName = "Shift.Legion.GvG.Common.Models.GvGMode3.GvGMode3ChatRecord")]
		public List<GvGMode3ChatRecord> RecordList;
	}

	private const long GetTimestampRange_24Hrs_ms = 86400000L;

	private const int MaxGetCount = 5;

	public C2S_GetSystemMessages()
	{
		base.PackageId = SocketManager.ePackageId.C2S_GetSystemMessages;
		base.Resp = new Response();
		base.Req = new Request();
	}
}
