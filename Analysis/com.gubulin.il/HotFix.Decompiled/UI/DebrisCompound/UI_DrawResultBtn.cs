using FairyGUI;
using FairyGUI.Utils;

namespace UI.DebrisCompound;

public class UI_DrawResultBtn : GButton
{
	public Controller button;

	public Controller PageController;

	public GLoader icon;

	public GTextField name;

	public GComponent curLevel;

	public GTextField num;

	public GImage newIcon;

	public GImage n9;

	public Transition bounce;

	public const string URL = "ui://6n2woz97o4kt5";

	public static string Name = "UI_DrawResultBtn";

	public static string GetURL()
	{
		return "ui://6n2woz97o4kt5";
	}

	public static UI_DrawResultBtn CreateInstance()
	{
		return (UI_DrawResultBtn)(object)UIPackage.CreateObject("DebrisCompound", "DrawResultBtn");
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0037: Unknown result type (might be due to invalid IL or missing references)
		//IL_0041: Expected O, but got Unknown
		//IL_004d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0057: Expected O, but got Unknown
		//IL_0063: Unknown result type (might be due to invalid IL or missing references)
		//IL_006d: Expected O, but got Unknown
		//IL_0079: Unknown result type (might be due to invalid IL or missing references)
		//IL_0083: Expected O, but got Unknown
		//IL_008f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0099: Expected O, but got Unknown
		//IL_00a5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00af: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		button = ((GComponent)this).GetController("button");
		PageController = ((GComponent)this).GetController("PageController");
		icon = (GLoader)((GComponent)this).GetChild("icon");
		name = (GTextField)((GComponent)this).GetChild("name");
		curLevel = (GComponent)((GComponent)this).GetChild("curLevel");
		num = (GTextField)((GComponent)this).GetChild("num");
		newIcon = (GImage)((GComponent)this).GetChild("newIcon");
		n9 = (GImage)((GComponent)this).GetChild("n9");
		bounce = ((GComponent)this).GetTransition("bounce");
	}
}
