using System.Collections.Generic;
using HotFix.Sources.Base.Scripts.Helper;
using HotFix.Sources.Base.Sources.Scripts.GvG3WorldMap.Helper;
using Shift.Legion.GvG.Common.Models.GvGMode3;

namespace HotFix.Sources.Base.Sources.Scripts.GvG3UI.Model.SystemMessageParser;

public class UserType13Parser : IMessageParser<eChatSystemTemplateType, ChatSystemMessageData>
{
	public HashSet<eChatSystemTemplateType> CanParse()
	{
		return new HashSet<eChatSystemTemplateType>
		{
			eChatSystemTemplateType.UserType13,
			eChatSystemTemplateType.UserType14
		};
	}

	public ChatSystemMessageData Parse(List<object> messageList, eChatThemeType textType)
	{
		if (messageList.Count != 6)
		{
			return null;
		}
		string text = messageList[0].ToString();
		string langKey = $"GvG_Mode3_System_{text}_{textType}";
		int num = (int)messageList[1];
		string curIZIslandName = WorldMapConfigHelper.GetCurIZIslandName(num);
		string text2 = (string)messageList[2];
		string text3 = (text2 + "_Name1").ToLanguage();
		int num2 = (int)messageList[3] + 1;
		string messageText = string.Format(langKey.ToLanguage(), num, curIZIslandName, text3, num2);
		return new ChatSystemMessageData
		{
			MessageText = messageText,
			MessageType = text
		};
	}
}
