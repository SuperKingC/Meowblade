using System.Collections.Generic;

namespace UI.Souvenir;

public class SouvenirPostScriptLine : ISouvenirLineText
{
	public string OriginalText { get; }

	public string ProcessedText { get; private set; }

	public PostScriptLineType Type { get; set; }

	public List<int> UserIds { get; set; } = new List<int>();

	public SouvenirPostScriptLine(string originalText)
	{
		OriginalText = originalText;
	}

	public string GetProcessedText()
	{
		return ProcessedText;
	}

	public void SetProcessedText(string value)
	{
		ProcessedText = value;
	}
}
