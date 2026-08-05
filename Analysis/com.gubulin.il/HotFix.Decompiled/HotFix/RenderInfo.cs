using FairyGUI;

namespace HotFix;

public class RenderInfo
{
	public int index;

	public GObject gobject;

	public RenderInfo(int _index, GObject _gobject)
	{
		index = _index;
		gobject = _gobject;
	}
}
