using System.Collections.Generic;

namespace UI.LegendItemDungeon;

public class FakeChapterData
{
	public string Name;

	public List<string> OutputList = new List<string>();

	public FakeChapterData(string chapterName)
	{
		Name = chapterName;
	}
}
