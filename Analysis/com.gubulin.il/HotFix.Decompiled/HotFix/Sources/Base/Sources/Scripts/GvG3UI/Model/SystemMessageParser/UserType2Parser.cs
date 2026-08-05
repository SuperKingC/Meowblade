using System.Collections.Generic;
using HotFix.Sources.Base.Scripts.Helper;
using HotFix.Sources.Base.Sources.Scripts.GvG3UI.Helper;
using HotFix.Sources.Base.Sources.Scripts.GvG3UI.Manager;
using HotFix.Sources.Base.Sources.Scripts.GvG3WorldMap.Helper;
using Shift.Legion.Common.Helpers;
using Shift.Legion.GvG.Common.Models.GvGMode3;

namespace HotFix.Sources.Base.Sources.Scripts.GvG3UI.Model.SystemMessageParser;

public class UserType2Parser : IMessageParser<eChatSystemTemplateType, ChatSystemMessageData>
{
	public HashSet<eChatSystemTemplateType> CanParse()
	{
		return new HashSet<eChatSystemTemplateType>
		{
			eChatSystemTemplateType.UserType2,
			eChatSystemTemplateType.UserType4,
			eChatSystemTemplateType.UserType5,
			eChatSystemTemplateType.UserType6,
			eChatSystemTemplateType.UserType8,
			eChatSystemTemplateType.UserType9,
			eChatSystemTemplateType.UserType10
		};
	}

	public ChatSystemMessageData Parse(List<object> messageList, eChatThemeType textType)
	{
		if (messageList.Count != 3)
		{
			return null;
		}
		string text = messageList[0].ToString();
		string langKey = $"GvG_Mode3_System_{text}_{textType}";
		string myShipName = Singleton<GvGMode3RoomManager>.Instance.ObserverRecord.GetMyShipName(messageList[1].ToString());
		int num = (int)messageList[2];
		string curIZIslandName = WorldMapConfigHelper.GetCurIZIslandName(num);
		string messageText = string.Format(langKey.ToLanguage(), new object[3] { myShipName, num, curIZIslandName });
		return new ChatSystemMessageData
		{
			MessageText = messageText,
			MessageType = text
		};
	}
}
