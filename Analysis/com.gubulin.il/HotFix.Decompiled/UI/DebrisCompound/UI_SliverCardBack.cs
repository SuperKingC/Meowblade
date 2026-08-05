using FairyGUI;
using FairyGUI.Utils;

namespace UI.DebrisCompound;

public class UI_SliverCardBack : GComponent
{
	public GButton n12;

	public const string URL = "ui://6n2woz97vecsa";

	public static string Name = "UI_SliverCardBack";

	public static string GetURL()
	{
		return "ui://6n2woz97vecsa";
	}

	public static UI_SliverCardBack CreateInstance()
	{
		return (UI_SliverCardBack)(object)UIPackage.CreateObject("DebrisCompound", "SliverCardBack");
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		n12 = (GButton)((GComponent)this).GetChild("n12");
	}
}
