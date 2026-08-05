using System.Collections.Generic;
using Shift.Legion.GvG.Common.Models;
using Shift.Legion.GvG.Common.Models.GvGMode3;
using Shift.Legion.Helpers;

namespace HotFix.Sources.Base.Sources.Scripts.GvG3UI.Model.SystemMessageParser;

public class UserType7BonusParser : IMessageParser<eChatSystemTemplateType, ChatSystemMessageBonus>
{
	public HashSet<eChatSystemTemplateType> CanParse()
	{
		return new HashSet<eChatSystemTemplateType> { eChatSystemTemplateType.UserType7 };
	}

	public ChatSystemMessageBonus Parse(List<object> messageList, eChatThemeType textType)
	{
		if (messageList.Count < 4)
		{
			ILRuntimeDebug.LogError("UserType7BonusParser Error Format - " + string.Join(",", messageList));
			return null;
		}
		string json = (string)messageList[2];
		string json2 = (string)messageList[3];
		return new ChatSystemMessageBonus
		{
			Bonuses = JsonHelper.ToObject<List<RItem>>(json),
			TalentSrcList = JsonHelper.ToObject<List<int>>(json2)
		};
	}
}
