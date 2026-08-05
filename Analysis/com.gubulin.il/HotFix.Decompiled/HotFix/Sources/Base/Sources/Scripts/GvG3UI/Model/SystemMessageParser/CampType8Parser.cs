using System.Collections.Generic;
using HotFix.Sources.Base.Scripts.Helper;
using HotFix.Sources.Base.Sources.Scripts.GvG3.GvG3UI.Helper;
using HotFix.Sources.Base.Sources.Scripts.GvG3WorldMap.Helper;
using Shift.Legion.GvG.Common.Models.GvGMode3;

namespace HotFix.Sources.Base.Sources.Scripts.GvG3UI.Model.SystemMessageParser;

public class CampType8Parser : IMessageParser<eChatSystemTemplateType, ChatSystemMessageData>
{
	public HashSet<eChatSystemTemplateType> CanParse()
	{
		return new HashSet<eChatSystemTemplateType> { eChatSystemTemplateType.CampType8 };
	}

	public ChatSystemMessageData Parse(List<object> messageList, eChatThemeType textType)
	{
		if (messageList.Count != 4)
		{
			return null;
		}
		string text = messageList[0].ToString();
		string langKey = $"GvG_Mode3_System_{text}_{textType}";
		int num = (int)messageList[1];
		int num2 = (int)messageList[2];
		string text2 = ((eIslandEvent)messageList[3]/*cast due to .constrained prefix*/).ToString().ToLanguage();
		string text3 = GvG3ProfileHelper.TryGetUserProfile(num)?.Name ?? $"{num}";
		string curIZIslandName = WorldMapConfigHelper.GetCurIZIslandName(num2);
		string messageText = string.Format(langKey.ToLanguage(), text3, num2, curIZIslandName, text2);
		return new ChatSystemMessageData
		{
			MessageText = messageText,
			MessageType = text
		};
	}
}
