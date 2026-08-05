using System.Collections.Generic;
using ProtoBuf;
using Shift.Legion.Common.Managers;

namespace Shift.Legion.GvGServer.Models.GvGMode3IslandManagerSocket;

[ProtoContract]
public class C2S_UseItem : SocketManager.BaseSocketPackageBodyContext
{
	[ProtoContract]
	public class Request : SocketManager.BaseSocketPackageBody
	{
		[ProtoMember(1)]
		public string ItemId;

		[ProtoMember(2)]
		public int Cnt;

		[ProtoMember(3)]
		public List<string> SelectedItems;
	}

	[ProtoContract]
	public class Response : SocketManager.BaseSocketPackageBody
	{
		[ProtoMember(1)]
		public int ErrorCode;
	}

	public C2S_UseItem()
	{
		base.PackageId = SocketManager.ePackageId.C2S_UseItem;
		base.Resp = new Response();
		base.Req = new Request();
	}
}
