using FairyGUI;
using FairyGUI.Utils;

namespace UI.Lottery;

public class UI_DetailInfoPopup : GComponent
{
	public GImage n1;

	public GTextField InfoContext;

	public const string URL = "ui://gxhnhhxkhblgt";

	public static string Name = "UI_DetailInfoPopup";

	public static string GetURL()
	{
		return "ui://gxhnhhxkhblgt";
	}

	public static UI_DetailInfoPopup CreateInstance()
	{
		return (UI_DetailInfoPopup)(object)UIPackage.CreateObject("Lottery", "DetailInfoPopup");
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0035: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		n1 = (GImage)((GComponent)this).GetChild("n1");
		InfoContext = (GTextField)((GComponent)this).GetChild("InfoContext");
	}
}
