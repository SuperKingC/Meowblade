using System.Collections.Generic;
using ProtoBuf;
using Shift.Legion.Common.Managers;
using Shift.Legion.GvG.Common.Models.GvGMode3;

namespace Shift.Legion.GvGServer.Models.GvGMode3IslandManagerSocket;

[ProtoContract]
public class C2S_GetSystemMessages_BattleResultBonus : SocketManager.BaseSocketPackageBodyContext
{
	[ProtoContract]
	public class Request : SocketManager.BaseSocketPackageBody
	{
		[ProtoMember(1)]
		public long StartId;

		[ProtoMember(2)]
		public bool IsGetWaitToClaimIds;
	}

	[ProtoContract]
	public class Response : SocketManager.BaseSocketPackageBody
	{
		[ProtoMember(1)]
		public int ErrorCode;

		[ProtoMember(2, TypeName = "Shift.Legion.GvG.Common.Models.GvGMode3.GvGMode3ChatRecord")]
		public List<GvGMode3ChatRecord> RecordList;

		[ProtoMember(3)]
		public bool IsGetWaitToClaimIds;

		[ProtoMember(4)]
		public List<long> WaitToClaimIds;
	}

	private const int MaxGetCount = 5;

	public C2S_GetSystemMessages_BattleResultBonus()
	{
		base.PackageId = SocketManager.ePackageId.C2S_GetSystemMessages_BattleResultBonus;
		base.Resp = new Response();
		base.Req = new Request();
	}
}
