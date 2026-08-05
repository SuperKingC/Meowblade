using System.Collections.Generic;
using Shift.Legion.GvG.Common.Models;
using Shift.Legion.GvG.Common.Models.GvGMode3;
using Shift.Legion.Helpers;

namespace HotFix.Sources.Base.Sources.Scripts.GvG3UI.Model.SystemMessageParser;

public class UserType22BonusParser : IMessageParser<eChatSystemTemplateType, ChatSystemMessageBonus>
{
	public HashSet<eChatSystemTemplateType> CanParse()
	{
		return new HashSet<eChatSystemTemplateType> { eChatSystemTemplateType.UserType22 };
	}

	public ChatSystemMessageBonus Parse(List<object> messageList, eChatThemeType textType)
	{
		if (messageList.Count != 3)
		{
			return null;
		}
		string json = (string)messageList[2];
		return new ChatSystemMessageBonus
		{
			Bonuses = JsonHelper.ToObject<List<RItem>>(json)
		};
	}
}
