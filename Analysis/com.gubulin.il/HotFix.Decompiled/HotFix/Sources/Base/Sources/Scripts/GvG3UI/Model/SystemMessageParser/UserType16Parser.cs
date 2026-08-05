using System.Collections.Generic;
using HotFix.Sources.Base.Scripts.Helper;
using Shift.Legion.GvG.Common.Models.GvGMode3;

namespace HotFix.Sources.Base.Sources.Scripts.GvG3UI.Model.SystemMessageParser;

public class UserType16Parser : IMessageParser<eChatSystemTemplateType, ChatSystemMessageData>
{
	public HashSet<eChatSystemTemplateType> CanParse()
	{
		return new HashSet<eChatSystemTemplateType> { eChatSystemTemplateType.UserType16 };
	}

	public ChatSystemMessageData Parse(List<object> messageList, eChatThemeType textType)
	{
		if (messageList.Count != 1)
		{
			return null;
		}
		string text = messageList[0].ToString();
		string langKey = $"GvG_Mode3_System_{text}_{textType}";
		string messageText = langKey.ToLanguage();
		return new ChatSystemMessageData
		{
			MessageText = messageText,
			MessageType = text
		};
	}
}
