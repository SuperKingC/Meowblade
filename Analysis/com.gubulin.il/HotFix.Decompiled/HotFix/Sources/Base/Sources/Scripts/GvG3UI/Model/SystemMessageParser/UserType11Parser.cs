using System.Collections.Generic;
using HotFix.Sources.Base.Scripts.Helper;
using HotFix.Sources.Base.Sources.Scripts.GvG3WorldMap.Helper;
using Shift.Legion.GvG.Common.Models.GvGMode3;

namespace HotFix.Sources.Base.Sources.Scripts.GvG3UI.Model.SystemMessageParser;

public class UserType11Parser : IMessageParser<eChatSystemTemplateType, ChatSystemMessageData>
{
	public HashSet<eChatSystemTemplateType> CanParse()
	{
		return new HashSet<eChatSystemTemplateType> { eChatSystemTemplateType.UserType11 };
	}

	public ChatSystemMessageData Parse(List<object> messageList, eChatThemeType textType)
	{
		if (messageList.Count != 3)
		{
			return null;
		}
		string text = messageList[0].ToString();
		string langKey = $"GvG_Mode3_System_{text}_{textType}";
		int num = (int)messageList[1];
		string curIZIslandName = WorldMapConfigHelper.GetCurIZIslandName(num);
		int num2 = (int)messageList[2];
		string messageText = string.Format(langKey.ToLanguage(), new object[3] { num, curIZIslandName, num2 });
		return new ChatSystemMessageData
		{
			MessageText = messageText,
			MessageType = text
		};
	}
}
