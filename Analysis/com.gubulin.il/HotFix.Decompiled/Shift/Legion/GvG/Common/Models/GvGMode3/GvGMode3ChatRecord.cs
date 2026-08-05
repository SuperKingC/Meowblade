using HotFix.Sources.Base.Sources.Scripts.GvG3UI.Helper;
using HotFix.Sources.Base.Sources.Scripts.GvG3UI.Model;
using HotFix.Sources.Base.Sources.Scripts.GvG3UI.Model.SystemMessageParser;
using ProtoBuf;

namespace Shift.Legion.GvG.Common.Models.GvGMode3;

[ProtoContract]
public class GvGMode3ChatRecord
{
	[ProtoMember(1)]
	public long Id { get; set; }

	[ProtoMember(2)]
	public int SenderId { get; set; }

	[ProtoMember(3)]
	public long Timestamp { get; set; }

	[ProtoMember(4)]
	public bool IsTemplateText { get; set; }

	[ProtoMember(5)]
	public string MessageToShow { get; set; }

	[ProtoMember(6)]
	public int SenderCampId { get; set; }

	[ProtoIgnore]
	public bool ShowOnChat { get; private set; }

	[ProtoIgnore]
	public bool PopUp { get; private set; }

	[ProtoIgnore]
	public string Message { get; private set; }

	[ProtoIgnore]
	public bool IsMe => SenderId == GameController.Contexts.gameState.user.value.UserId;

	[ProtoIgnore]
	public bool IsUser => SenderId != -1;

	[ProtoIgnore]
	public bool IsSystem => SenderId == -1;

	[ProtoIgnore]
	public int RecordId => (int)Id;

	[ProtoIgnore]
	public int ChatChannelIndex { get; set; }

	public bool ParseMessage(eChatThemeType textType)
	{
		if (IsUser)
		{
			ChatUserMessageData chatUserMessageData = GvGMode3MessageConfigHelper.ParseUserMessageData(MessageToShow, textType, IsTemplateText);
			if (chatUserMessageData == null)
			{
				Message = string.Empty;
				return false;
			}
			Message = chatUserMessageData.MessageText;
		}
		else
		{
			ChatSystemMessageData chatSystemMessageData = GvGMode3MessageConfigHelper.ParseSystemMessageData(MessageToShow, textType);
			if (chatSystemMessageData == null)
			{
				Message = string.Empty;
				return false;
			}
			string messageType = chatSystemMessageData.MessageType;
			Message = chatSystemMessageData.MessageText;
			PopUp = GvGMode3MessageConfigHelper.SystemMessageConfig.PopUp.Contains(messageType);
			ShowOnChat = GvGMode3MessageConfigHelper.SystemMessageConfig.ShowOnChat.Contains(messageType);
		}
		return true;
	}
}
