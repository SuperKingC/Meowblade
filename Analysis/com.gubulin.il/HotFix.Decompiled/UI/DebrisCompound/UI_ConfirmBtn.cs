using FairyGUI;
using FairyGUI.Utils;

namespace UI.DebrisCompound;

public class UI_ConfirmBtn : GButton
{
	public Controller button;

	public GLoader icon;

	public GTextField title;

	public const string URL = "ui://6n2woz97o4kt7";

	public static string Name = "UI_ConfirmBtn";

	public static string GetURL()
	{
		return "ui://6n2woz97o4kt7";
	}

	public static UI_ConfirmBtn CreateInstance()
	{
		return (UI_ConfirmBtn)(object)UIPackage.CreateObject("DebrisCompound", "ConfirmBtn");
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Expected O, but got Unknown
		//IL_003c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0046: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		button = ((GComponent)this).GetController("button");
		icon = (GLoader)((GComponent)this).GetChild("icon");
		title = (GTextField)((GComponent)this).GetChild("title");
	}
}
