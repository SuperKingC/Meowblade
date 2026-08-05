using System.Collections.Generic;
using ProtoBuf;
using Shift.Legion.Common.Managers;
using Shift.Legion.GvG.Common.Models.GvGMode3;

namespace Shift.Legion.GvGServer.Models.GvGMode3IslandManagerSocket;

[ProtoContract]
public class C2S_GetChatChannelMessages : SocketManager.BaseSocketPackageBodyContext
{
	[ProtoContract]
	public class Request : SocketManager.BaseSocketPackageBody
	{
		[ProtoMember(1)]
		public int ChatChannel;

		[ProtoMember(2)]
		public long StartId;

		public eChatChannel ChatChannelEnum
		{
			get
			{
				return (eChatChannel)ChatChannel;
			}
			set
			{
				ChatChannel = (int)value;
			}
		}
	}

	[ProtoContract]
	public class Response : SocketManager.BaseSocketPackageBody
	{
		[ProtoMember(1)]
		public int ErrorCode;

		[ProtoMember(2)]
		public int ChatChannel;

		[ProtoMember(3, TypeName = "Shift.Legion.GvG.Common.Models.GvGMode3.GvGMode3ChatRecord")]
		public List<GvGMode3ChatRecord> RecordList = new List<GvGMode3ChatRecord>();

		public eChatChannel ChatChannelEnum
		{
			get
			{
				return (eChatChannel)ChatChannel;
			}
			set
			{
				ChatChannel = (int)value;
			}
		}
	}

	public C2S_GetChatChannelMessages()
	{
		base.PackageId = SocketManager.ePackageId.C2S_GetChatChannelMessages;
		base.Resp = new Response();
		base.Req = new Request();
	}
}
