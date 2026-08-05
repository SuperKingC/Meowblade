namespace FairyGUI.Utils;

public interface IFairyGuiPageTurner
{
	GButton ToLast { get; }

	GButton ToNext { get; }

	void RenderTitle(string title);
}
