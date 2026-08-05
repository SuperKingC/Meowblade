using System;
using System.Collections.Generic;

namespace HotFix.Sources.Base.Sources.Scripts.GvG3UI.Model.SystemMessageParser;

public interface IMessageParser<E, T> where E : Enum
{
	HashSet<E> CanParse();

	T Parse(List<object> messageList, eChatThemeType textType);
}
