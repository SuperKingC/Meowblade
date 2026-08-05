using System.Collections.Generic;
using HotFix.Sources.Base.Scripts.Helper;
using HotFix.Sources.Base.Sources.Scripts.GvG3WorldMap.Helper;
using Shift.Legion.GvG.Common.Models.GvGMode3;

namespace HotFix.Sources.Base.Sources.Scripts.GvG3UI.Model.SystemMessageParser;

public class CampType1Parser : IMessageParser<eChatSystemTemplateType, ChatSystemMessageData>
{
	public HashSet<eChatSystemTemplateType> CanParse()
	{
		return new HashSet<eChatSystemTemplateType>
		{
			eChatSystemTemplateType.CampType1,
			eChatSystemTemplateType.CampType3
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
		int islandId = (int)messageList[1];
		string curIZIslandName = WorldMapConfigHelper.GetCurIZIslandName(islandId);
		int campId = (int)messageList[2];
		string text2 = WorldMapConfigHelper.TryGetCampPrefabConfig(campId).CampName.ToLanguage();
		string messageText = string.Format(langKey.ToLanguage(), new object[3]
		{
			islandId.ToString(),
			curIZIslandName,
			text2
		});
		return new ChatSystemMessageData
		{
			MessageText = messageText,
			MessageType = text
		};
	}
}
