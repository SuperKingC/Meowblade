using System.Collections.Generic;
using HotFix.Sources.Base.Scripts.Helper;
using HotFix.Sources.Base.Sources.Scripts.GvG3WorldMap.Helper;
using Shift.Legion.GvG.Common.Models.GvGMode3;

namespace HotFix.Sources.Base.Sources.Scripts.GvG3UI.Model.SystemMessageParser;

public class UserType7Parser : IMessageParser<eChatSystemTemplateType, ChatSystemMessageData>
{
	public enum eChatMessageExtraType
	{
		None,
		SuppressNormal,
		SuppressOverLimit
	}

	public HashSet<eChatSystemTemplateType> CanParse()
	{
		return new HashSet<eChatSystemTemplateType> { eChatSystemTemplateType.UserType7 };
	}

	public ChatSystemMessageData Parse(List<object> messageList, eChatThemeType textType)
	{
		if (messageList.Count < 4)
		{
			return null;
		}
		eChatMessageExtraType eChatMessageExtraType = eChatMessageExtraType.SuppressNormal;
		if (messageList.Count >= 5)
		{
			eChatMessageExtraType = (eChatMessageExtraType)messageList[4];
		}
		string text = messageList[0].ToString();
		string langKey = $"GvG_Mode3_System_{text}_{textType}";
		if (eChatMessageExtraType == eChatMessageExtraType.SuppressOverLimit)
		{
			langKey = $"GvG_Mode3_System_{text}_{textType}2";
		}
		int num = (int)messageList[1];
		string curIZIslandName = WorldMapConfigHelper.GetCurIZIslandName(num);
		string messageText = string.Format(langKey.ToLanguage(), new object[2] { num, curIZIslandName });
		return new ChatSystemMessageData
		{
			MessageText = messageText,
			MessageType = text
		};
	}
}
