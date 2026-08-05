using System.Collections.Generic;

namespace UI.Souvenir;

public class Souvenir
{
	public List<ISouvenirLineText> LineTexts { get; set; } = new List<ISouvenirLineText>();
}
