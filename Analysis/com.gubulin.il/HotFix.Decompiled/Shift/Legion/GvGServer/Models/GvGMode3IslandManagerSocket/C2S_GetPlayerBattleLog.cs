using System.Collections.Generic;
using ProtoBuf;
using Shift.Legion.Common.Managers;

namespace Shift.Legion.GvGServer.Models.GvGMode3IslandManagerSocket;

[ProtoContract]
public class C2S_GetPlayerBattleLog : SocketManager.BaseSocketPackageBodyContext
{
	[ProtoContract]
	public class Request : SocketManager.BaseSocketPackageBody
	{
		[ProtoMember(1)]
		public int Num;

		[ProtoMember(4)]
		public string StartKey;
	}

	[ProtoContract]
	public class Response : SocketManager.BaseSocketPackageBody
	{
		[ProtoMember(1)]
		public int ErrorCode;

		[ProtoMember(2)]
		public List<string> Keys;
	}

	public C2S_GetPlayerBattleLog()
	{
		base.PackageId = SocketManager.ePackageId.C2S_GetPlayerBattleLog;
		base.Resp = new Response();
		base.Req = new Request();
	}
}
