using System.Collections.Generic;
using GameDataEditor;
using HotFix.Sources.Base.Scripts.Helper;
using HotFix.Sources.Base.Sources.Scripts.GvG3WorldMap.Helper;
using Shift.Legion.Common.Managers;
using Shift.Legion.GvG.Common.Models.GvGMode3;

namespace HotFix.Sources.Base.Sources.Scripts.GvG3UI.Model.SystemMessageParser;

public class CampType9Parser : IMessageParser<eChatSystemTemplateType, ChatSystemMessageData>
{
	public HashSet<eChatSystemTemplateType> CanParse()
	{
		return new HashSet<eChatSystemTemplateType> { eChatSystemTemplateType.CampType9 };
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
		string text2 = (string)messageList[2];
		GDEGvGMode3CampMissionData gDEGvGMode3CampMissionData = GDMgr.Get<GDEGvGMode3CampMissionData>(text2);
		string text3 = "[img]" + gDEGvGMode3CampMissionData.SubType.ToPublicResourcesRgbIcon() + "[/img]";
		string text4 = (text2 + "_Name1").ToLanguage();
		string messageText = langKey.ToLanguage().Format(num, curIZIslandName, text3, text4);
		return new ChatSystemMessageData
		{
			MessageText = messageText,
			MessageType = text
		};
	}
}
