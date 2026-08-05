using System.Collections.Generic;
using HotFix.Sources.Base.Sources.Scripts.GvG3UI.Model;
using HotFix.Sources.Base.Sources.Scripts.GvG3UI.Model.SystemMessageParser;
using Shift.Legion.GvG.Common.Models.GvGMode3;

namespace Shift.Legion.GvG.Common.GDEManager;

public class BrawlEventType_ABonusParser : IMessageParser<eChatSystemTemplateType, ChatSystemMessageData>
{
	public HashSet<eChatSystemTemplateType> CanParse()
	{
		return new HashSet<eChatSystemTemplateType> { eChatSystemTemplateType.BrawlEventType_A };
	}

	public ChatSystemMessageData Parse(List<object> messageList, eChatThemeType textType)
	{
		if (messageList.Count != 2)
		{
			return null;
		}
		return new ChatSystemMessageData();
	}
}
