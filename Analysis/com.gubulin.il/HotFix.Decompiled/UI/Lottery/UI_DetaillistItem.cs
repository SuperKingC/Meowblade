using FairyGUI;
using FairyGUI.Utils;

namespace UI.Lottery;

public class UI_DetaillistItem : GComponent
{
	public GTextField Name_t;

	public GTextField Amount;

	public const string URL = "ui://gxhnhhxkhblgv";

	public static string Name = "UI_DetaillistItem";

	public static string GetURL()
	{
		return "ui://gxhnhhxkhblgv";
	}

	public static UI_DetaillistItem CreateInstance()
	{
		return (UI_DetaillistItem)(object)UIPackage.CreateObject("Lottery", "DetaillistItem");
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0035: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		Name_t = (GTextField)((GComponent)this).GetChild("Name_t");
		Amount = (GTextField)((GComponent)this).GetChild("Amount");
	}
}
