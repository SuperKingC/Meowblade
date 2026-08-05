using FairyGUI;
using FairyGUI.Utils;

public class ScrollPaneHeader : GComponent
{
	private Controller _c1;

	public bool ReadyToRefresh => _c1.selectedIndex == 1;

	public override void ConstructFromXML(XML xml)
	{
		//IL_0027: Unknown result type (might be due to invalid IL or missing references)
		//IL_0031: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		_c1 = ((GComponent)this).GetController("c1");
		((GObject)this).onSizeChanged.Add(new EventCallback0(OnSizeChanged));
	}

	private void OnSizeChanged()
	{
		if (_c1.selectedIndex != 2 && _c1.selectedIndex != 3)
		{
			if (((GObject)this).height > (float)((GObject)this).sourceHeight)
			{
				_c1.selectedIndex = 1;
			}
			else
			{
				_c1.selectedIndex = 0;
			}
		}
	}

	public void SetRefreshStatus(int value)
	{
		_c1.selectedIndex = value;
	}
}
