using ProtoBuf;
using Shift.Legion.Common.Managers;

namespace Shift.Legion.GvGServer.Models.GvGMode3IslandManagerSocket.PlayerCommand;

[ProtoContract]
public class C2S_CreatePlayerCommand : SocketManager.BaseSocketPackageBodyContext
{
	[ProtoContract]
	public class Request : SocketManager.BaseSocketPackageBody
	{
		[ProtoMember(1)]
		public int CommandType;

		[ProtoMember(2)]
		public int ContributionPointAdd;

		[ProtoMember(3)]
		public int TimerAdd;

		[ProtoMember(4)]
		public string Message;

		[ProtoMember(5)]
		public int IslandId;
	}

	[ProtoContract]
	public class Response : SocketManager.BaseSocketPackageBody
	{
		[ProtoMember(1)]
		public int ErrorCode;
	}

	public C2S_CreatePlayerCommand()
	{
		base.PackageId = SocketManager.ePackageId.C2S_CreatePlayerCommand;
		base.Resp = new Response();
		base.Req = new Request();
	}
}
