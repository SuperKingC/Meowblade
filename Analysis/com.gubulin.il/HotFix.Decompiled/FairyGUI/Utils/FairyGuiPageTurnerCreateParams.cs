using System;

namespace FairyGUI.Utils;

public class FairyGuiPageTurnerCreateParams
{
	public IFairyGuiPageTurner PageTurner { get; set; }

	public int SelectingPageIndex { get; set; }

	public int PageCount { get; set; }

	public Func<int, string> OnPageIndexChange { get; set; }
}
