using FairyGUI;
using FairyGUI.Utils;

namespace UI.MaterialIntroduction;

public class UI_RepairBtn : GButton
{
	public Controller button;

	public GImage background;

	public GTextField title;

	public const string URL = "ui://l3jq1eamic7j1";

	public static string Name = "UI_RepairBtn";

	public static UI_RepairBtn CreateInstance()
	{
		return (UI_RepairBtn)(object)UIPackage.CreateObject("MaterialIntroduction", "RepairBtn");
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Expected O, but got Unknown
		//IL_003c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0046: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		button = ((GComponent)this).GetController("button");
		background = (GImage)((GComponent)this).GetChild("background");
		title = (GTextField)((GComponent)this).GetChild("title");
	}
}
