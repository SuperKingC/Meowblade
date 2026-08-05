using FairyGUI;
using FairyGUI.Utils;

namespace UI.DebrisCompound;

public class UI_ClassicCardBack : GComponent
{
	public GButton cardReverseSide;

	public const string URL = "ui://6n2woz97o4kt1";

	public static string Name = "UI_ClassicCardBack";

	public static string GetURL()
	{
		return "ui://6n2woz97o4kt1";
	}

	public static UI_ClassicCardBack CreateInstance()
	{
		return (UI_ClassicCardBack)(object)UIPackage.CreateObject("DebrisCompound", "ClassicCardBack");
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		cardReverseSide = (GButton)((GComponent)this).GetChild("cardReverseSide");
	}
}
