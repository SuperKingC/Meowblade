using System.Collections.Generic;
using ProtoBuf;
using Shift.Legion.Common.Managers;
using Shift.Legion.GvG.Common.Models.GvGMode3;

namespace HotFix.Sources.Base.Sources.Scripts.GvG3.GvG3Common.Network.C2S;

public class C2S_GetIslandRunningBattleLog : SocketManager.BaseSocketPackageBodyContext
{
	[ProtoContract]
	public class Request : SocketManager.BaseSocketPackageBody
	{
		[ProtoMember(1)]
		public int Num;

		[ProtoMember(4)]
		public int IslandId;
	}

	[ProtoContract]
	public class Response : SocketManager.BaseSocketPackageBody
	{
		[ProtoMember(1)]
		public int ErrorCode;

		[ProtoMember(2, TypeName = "Shift.Legion.GvG.Common.Models.GvGMode3.RunningBattleLogItem")]
		public List<RunningBattleLogItem> Logs;
	}

	public C2S_GetIslandRunningBattleLog()
	{
		base.PackageId = SocketManager.ePackageId.C2S_GetIslandRunningBattleLog;
		base.Resp = new Response();
		base.Req = new Request();
	}
}
