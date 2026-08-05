using System.Collections.Generic;
using Assets.Scripts.UI;
using HotFix.Sources.Base.Scripts.Helper;
using HotFix.Sources.Base.Sources.Scripts.GvG3UI.Helper;
using HotFix.Sources.Base.Sources.Scripts.GvG3UI.Manager;
using HotFix.Sources.Base.Sources.Scripts.GvG3WorldMap.Helper;
using Shift.Legion.Common.Helpers;
using Shift.Legion.GvG.Common.Models.GvGMode3;

namespace HotFix.Sources.Base.Sources.Scripts.GvG3UI.Model.SystemMessageParser;

public class UserType61Parser : IMessageParser<eChatSystemTemplateType, ChatSystemMessageData>
{
	public HashSet<eChatSystemTemplateType> CanParse()
	{
		return new HashSet<eChatSystemTemplateType> { eChatSystemTemplateType.UserType61 };
	}

	public ChatSystemMessageData Parse(List<object> messageList, eChatThemeType textType)
	{
		if (messageList.Count != 8)
		{
			return null;
		}
		string text = messageList[0].ToString();
		string langKey = $"GvG_Mode3_System_{text}_{textType}";
		string myShipName = Singleton<GvGMode3RoomManager>.Instance.ObserverRecord.GetMyShipName(messageList[1].ToString());
		int num = (int)messageList[2];
		int num2 = (int)messageList[3];
		int num3 = (int)messageList[4];
		int num4 = (int)messageList[5];
		string text2 = UiHelper.ParseTime((int)messageList[6]);
		string name = WorldMapConfigHelper.Configs.TryGetIsland((int)messageList[7]).Name;
		string messageText = string.Format(langKey.ToLanguage(), myShipName, num, num2, num3, num4, text2, name);
		return new ChatSystemMessageData
		{
			MessageText = messageText,
			MessageType = text
		};
	}
}
