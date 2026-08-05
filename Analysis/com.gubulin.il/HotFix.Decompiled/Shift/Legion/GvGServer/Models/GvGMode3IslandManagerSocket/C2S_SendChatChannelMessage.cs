using ProtoBuf;
using Shift.Legion.Common.Managers;
using Shift.Legion.GvG.Common.Models.GvGMode3;

namespace Shift.Legion.GvGServer.Models.GvGMode3IslandManagerSocket;

[ProtoContract]
public class C2S_SendChatChannelMessage : SocketManager.BaseSocketPackageBodyContext
{
	[ProtoContract]
	public class Request : SocketManager.BaseSocketPackageBody
	{
		[ProtoMember(1)]
		public string StrMessage;

		[ProtoMember(2)]
		public bool IsTemplateText;

		[ProtoMember(3)]
		public int ChatChannel;

		[ProtoMember(4)]
		public bool BuyExtraSending;

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

	public C2S_SendChatChannelMessage()
	{
		base.PackageId = SocketManager.ePackageId.C2S_SendChatChannelMessage;
		base.Resp = new Response();
		base.Req = new Request();
	}
}
