using ProtoBuf;
using Shift.Legion.Common.Managers;

namespace Shift.Legion.GvGServer.Models.GvGMode3IslandManagerSocket.PlayerCommand;

[ProtoContract]
public class C2S_CheckPlayerCommandMessage : SocketManager.BaseSocketPackageBodyContext
{
	[ProtoContract]
	public class Request : SocketManager.BaseSocketPackageBody
	{
		[ProtoMember(1)]
		public string Msg;
	}

	[ProtoContract]
	public class Response : SocketManager.BaseSocketPackageBody
	{
		[ProtoMember(1)]
		public bool Changed;

		[ProtoMember(2)]
		public string newString;
	}

	public C2S_CheckPlayerCommandMessage()
	{
		base.PackageId = SocketManager.ePackageId.C2S_CheckPlayerCommandMessage;
		base.Resp = new Response();
		base.Req = new Request();
	}
}
