using System.Collections.Generic;
using HotFix.Sources.Base.Scripts.Helper;
using HotFix.Sources.Base.Sources.Scripts.GvG3WorldMap.Helper;
using Shift.Legion.GvG.Common.Models.GvGMode3;

namespace HotFix.Sources.Base.Sources.Scripts.GvG3UI.Model.SystemMessageParser;

public class RichTextType1Parser : IMessageParser<eChatUserTemplateType, ChatUserMessageData>
{
	public HashSet<eChatUserTemplateType> CanParse()
	{
		return new HashSet<eChatUserTemplateType> { eChatUserTemplateType.Type1 };
	}

	public ChatUserMessageData Parse(List<object> messageList, eChatThemeType textType)
	{
		if (messageList.Count != 2)
		{
			return null;
		}
		string text = messageList[0].ToString();
		string langKey = $"GvG_Mode3_User_{text}_{textType}";
		int num = (int)messageList[1];
		string curIZIslandName = WorldMapConfigHelper.GetCurIZIslandName(num);
		string messageText = string.Format(langKey.ToLanguage(), new object[2] { num, curIZIslandName });
		return new ChatUserMessageData
		{
			MessageText = messageText,
			MessageType = text
		};
	}
}
