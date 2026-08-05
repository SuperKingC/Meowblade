using System;
using System.Collections.Generic;
using ProtoBuf;
using Shift.Legion.Common.Managers;
using Shift.Legion.GvG.Common.Models.GvGMode3;

namespace Shift.Legion.GvGServer.Models.GvGMode3IslandManagerSocket;

[ProtoContract]
public class S2C_BroadcastChatChannelMessages : SocketManager.BaseSocketPackageBodyContext
{
	[ProtoContract]
	public class Request : SocketManager.BaseSocketPackageBody
	{
		[ProtoMember(2, TypeName = "Shift.Legion.GvG.Common.Models.GvGMode3.GvGMode3ChatRecord")]
		public List<GvGMode3ChatRecord> RecordList;

		[ProtoMember(3)]
		public int ChatChannel;

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
	}

	public static Action<Request> OnPushEvent = delegate
	{
	};

	public S2C_BroadcastChatChannelMessages()
	{
		base.PackageId = SocketManager.ePackageId.S2C_BroadcastChatChannelMessages;
		base.Resp = new Response();
		base.Req = new Request();
	}

	public override void OnPush()
	{
		OnPushEvent?.Invoke((Request)base.Req);
	}
}
