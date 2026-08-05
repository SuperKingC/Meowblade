using System;
using System.Collections.Generic;
using Assets.Scripts.UI;
using HotFix.Sources.Base.Scripts.Helper;
using HotFix.Sources.Base.Sources.Scripts.GvG3.GvG3UI.Model.SystemMessageParser;
using HotFix.Sources.Base.Sources.Scripts.GvG3UI.Model;
using HotFix.Sources.Base.Sources.Scripts.GvG3UI.Model.SystemMessageParser;
using Shift.Legion.GvG.Common.GDEManager;
using Shift.Legion.GvG.Common.Models.GvGMode3;
using Shift.Legion.Helpers;

namespace HotFix.Sources.Base.Sources.Scripts.GvG3UI.Helper;

public static class GvGMode3MessageConfigHelper
{
	public class GvGChatConfigModel
	{
		public int MaxSendingLength { get; set; }

		public int CampChatCountLimitPerDay { get; set; }

		public int WorldChatCountLimitPerDay { get; set; }

		public int WorldChatFreeCountPerDay { get; set; }

		public int WoldChatSendingCoolDown { get; set; }

		public int CampChatSendingCoolDown { get; set; }

		public Dictionary<string, int> WorldExtraSendingConsume { get; set; }
	}

	public class GvGSystemMessageConfigModel
	{
		public List<string> PopUp { get; set; }

		public List<string> ShowOnChat { get; set; }
	}

	public const string UserRichTextPrefix = "##%%";

	public static Dictionary<string, IMessageParser<eChatSystemTemplateType, ChatSystemMessageData>> SystemMessageDataParser_Dict;

	public static Dictionary<string, IMessageParser<eChatSystemTemplateType, ChatSystemMessageBonus>> MessageBonusParser_Dict;

	public static Dictionary<string, IMessageParser<eChatUserTemplateType, ChatUserMessageData>> UserMessageBonusParser_Dict;

	private static CampType10Parser _campType10Parser;

	private const string GvGMode3ChatWorldExtraSendingConsume = "GvGMode3_Chat_WorldExtraSendingConsume";

	private static readonly List<string> _filteredSystemMessageType = new List<string> { "CampType10", "BrawlEventType_A" };

	public static GvGChatConfigModel Config { get; private set; }

	public static GvGSystemMessageConfigModel SystemMessageConfig { get; private set; }

	public static void PreLoad()
	{
		if (Config == null)
		{
			Config = "GvGChatConfig".ToConfiguration<GvGChatConfigModel>();
		}
		if (SystemMessageConfig == null)
		{
			SystemMessageConfig = "GvGSystemMessageConfig".ToConfiguration<GvGSystemMessageConfigModel>();
		}
		if (SystemMessageDataParser_Dict == null)
		{
			List<IMessageParser<eChatSystemTemplateType, ChatSystemMessageData>> parsers = new List<IMessageParser<eChatSystemTemplateType, ChatSystemMessageData>>
			{
				new CampType1Parser(),
				new CampType2Parser(),
				new CampType6Parser(),
				new CampType8Parser(),
				new CampType9Parser(),
				new UserType1Parser(),
				new UserType2Parser(),
				new UserType3Parser(),
				new UserType13Parser(),
				new UserType7Parser(),
				new UserType11Parser(),
				new UserType50Parser(),
				new UserType51Parser(),
				new UserType16Parser(),
				new UserType17Parser(),
				new UserType18Parser(),
				new UserType20Parser(),
				new UserType22Parser(),
				new UserType60Parser(),
				new UserType61Parser(),
				new WorldType1Parser(),
				new BrawlEventType_ABonusParser()
			};
			SystemMessageDataParser_Dict = ParsersInit(parsers);
		}
		if (MessageBonusParser_Dict == null)
		{
			List<IMessageParser<eChatSystemTemplateType, ChatSystemMessageBonus>> parsers2 = new List<IMessageParser<eChatSystemTemplateType, ChatSystemMessageBonus>>
			{
				new UserType3BonusParser(),
				new UserType7BonusParser(),
				new UserType13BonusParser(),
				new UserType17BonusParser(),
				new UserType18BonusParser(),
				new UserType20BonusParser(),
				new UserType22BonusParser()
			};
			MessageBonusParser_Dict = ParsersInit(parsers2);
		}
		if (UserMessageBonusParser_Dict == null)
		{
			List<IMessageParser<eChatUserTemplateType, ChatUserMessageData>> parsers3 = new List<IMessageParser<eChatUserTemplateType, ChatUserMessageData>>
			{
				new RichTextType1Parser()
			};
			UserMessageBonusParser_Dict = ParsersInit(parsers3);
		}
		if (_campType10Parser == null)
		{
			_campType10Parser = new CampType10Parser();
		}
	}

	private static Dictionary<string, IMessageParser<E, T>> ParsersInit<E, T>(List<IMessageParser<E, T>> parsers) where E : Enum
	{
		Dictionary<string, IMessageParser<E, T>> dictionary = new Dictionary<string, IMessageParser<E, T>>();
		foreach (IMessageParser<E, T> parser in parsers)
		{
			foreach (E item in parser.CanParse())
			{
				if (dictionary.ContainsKey(item.ToString()))
				{
					ILRuntimeDebug.LogError($"[GvGMode3MessageConfigHelper] ParsersInit时，不同的解析器里出现重复的解析类型 type={item}");
				}
				else
				{
					dictionary.Add(item.ToString(), parser);
				}
			}
		}
		return dictionary;
	}

	public static string GetChatWorldExtraSendingConsumeText(string itemId, int itemNum)
	{
		return HotFix.Sources.Base.Scripts.Helper.StringExtensions.Format("GvGMode3_Chat_WorldExtraSendingConsume".ToLanguage(), UiHelper.GetItemIconPath(itemId), itemNum);
	}

	public static ChatSystemMessageData ParseSystemMessageData(string message, eChatThemeType textType)
	{
		if (string.IsNullOrEmpty(message))
		{
			return null;
		}
		List<object> list = JsonHelper.ToObject<List<object>>(message);
		if (list == null || list.Count == 0)
		{
			return null;
		}
		string text = list[0] as string;
		if (string.IsNullOrEmpty(text))
		{
			return null;
		}
		if (_filteredSystemMessageType.Contains(text))
		{
			return null;
		}
		if (!SystemMessageDataParser_Dict.TryGetValue(text, out var value))
		{
			ILRuntimeDebug.LogError("[GvGMode3MessageConfigHelper] ParseSystemMessage时，找不到对应的消息解析器 messageType=" + text);
			return null;
		}
		try
		{
			return value.Parse(list, textType);
		}
		catch (Exception)
		{
			return null;
		}
	}

	public static ChatSystemMessageBonus ParseSystemMessageBonus(string message)
	{
		if (string.IsNullOrEmpty(message))
		{
			return null;
		}
		List<object> list = JsonHelper.ToObject<List<object>>(message);
		if (list == null || list.Count == 0)
		{
			return null;
		}
		string text = list[0] as string;
		if (string.IsNullOrEmpty(text))
		{
			return null;
		}
		if (!MessageBonusParser_Dict.TryGetValue(text, out var value))
		{
			return null;
		}
		try
		{
			return value.Parse(list, eChatThemeType.None);
		}
		catch (Exception)
		{
			return null;
		}
	}

	public static BrawlCampRankInfos ParseBrawlCampRankInfos(string message)
	{
		if (string.IsNullOrEmpty(message))
		{
			return null;
		}
		List<object> list = JsonHelper.ToObject<List<object>>(message);
		if (list == null || list.Count == 0)
		{
			return null;
		}
		string value = list[0] as string;
		if (string.IsNullOrEmpty(value))
		{
			return null;
		}
		return _campType10Parser.Parse(list);
	}

	public static ChatUserMessageData ParseUserMessageData(string message, eChatThemeType textType, bool isTemplateText)
	{
		if (string.IsNullOrEmpty(message))
		{
			return null;
		}
		ChatUserMessageData chatUserMessageData = new ChatUserMessageData
		{
			MessageText = message,
			MessageType = eChatUserTemplateType.NotTemplate.ToString()
		};
		if (message.StartsWith("##%%"))
		{
			List<object> list = JsonHelper.ToObject<List<object>>(message.Remove(0, "##%%".Length));
			if (list != null || list.Count != 0)
			{
				string key = list[0] as string;
				if (UserMessageBonusParser_Dict.TryGetValue(key, out var value))
				{
					try
					{
						ChatUserMessageData chatUserMessageData2 = value.Parse(list, textType);
						if (chatUserMessageData2 != null)
						{
							return chatUserMessageData2;
						}
						chatUserMessageData.MessageText = "";
					}
					catch (Exception)
					{
						chatUserMessageData.MessageText = "";
					}
				}
			}
		}
		return chatUserMessageData;
	}

	public static string GenerateUserRichText(eChatUserTemplateType type, List<object> parameters)
	{
		parameters.Insert(0, type.ToString());
		return "##%%" + JsonHelper.ToJson(parameters);
	}
}
