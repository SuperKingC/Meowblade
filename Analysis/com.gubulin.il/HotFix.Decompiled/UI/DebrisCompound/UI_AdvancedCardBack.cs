using FairyGUI;
using FairyGUI.Utils;

namespace UI.DebrisCompound;

public class UI_AdvancedCardBack : GComponent
{
	public GButton n11;

	public const string URL = "ui://6n2woz97o4kt4";

	public static string Name = "UI_AdvancedCardBack";

	public static string GetURL()
	{
		return "ui://6n2woz97o4kt4";
	}

	public static UI_AdvancedCardBack CreateInstance()
	{
		return (UI_AdvancedCardBack)(object)UIPackage.CreateObject("DebrisCompound", "AdvancedCardBack");
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		n11 = (GButton)((GComponent)this).GetChild("n11");
	}
}
