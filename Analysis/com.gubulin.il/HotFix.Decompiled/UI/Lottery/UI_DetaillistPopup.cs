using FairyGUI;
using FairyGUI.Utils;

namespace UI.Lottery;

public class UI_DetaillistPopup : GComponent
{
	public GImage n1;

	public GList List;

	public const string URL = "ui://gxhnhhxkhblgu";

	public static string Name = "UI_DetaillistPopup";

	public static string GetURL()
	{
		return "ui://gxhnhhxkhblgu";
	}

	public static UI_DetaillistPopup CreateInstance()
	{
		return (UI_DetaillistPopup)(object)UIPackage.CreateObject("Lottery", "DetaillistPopup");
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0035: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		n1 = (GImage)((GComponent)this).GetChild("n1");
		List = (GList)((GComponent)this).GetChild("List");
	}
}
