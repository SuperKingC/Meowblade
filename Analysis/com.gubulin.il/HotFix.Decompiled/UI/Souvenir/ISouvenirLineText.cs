using System.Collections.Generic;

namespace UI.Souvenir;

public interface ISouvenirLineText
{
	string OriginalText { get; }

	PostScriptLineType Type { get; set; }

	List<int> UserIds { get; set; }

	string GetProcessedText();

	void SetProcessedText(string value);
}
