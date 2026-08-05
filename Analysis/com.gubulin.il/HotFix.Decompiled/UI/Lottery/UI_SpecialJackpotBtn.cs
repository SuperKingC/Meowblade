using FairyGUI;
using FairyGUI.Utils;

namespace UI.Lottery;

public class UI_SpecialJackpotBtn : GButton
{
	public Controller button;

	public GImage n0;

	public GImage n1;

	public GTextField n2;

	public const string URL = "ui://gxhnhhxkrtxa6";

	public static string Name = "UI_SpecialJackpotBtn";

	public static string GetURL()
	{
		return "ui://gxhnhhxkrtxa6";
	}

	public static UI_SpecialJackpotBtn CreateInstance()
	{
		return (UI_SpecialJackpotBtn)(object)UIPackage.CreateObject("Lottery", "SpecialJackpotBtn");
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Expected O, but got Unknown
		//IL_003c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0046: Expected O, but got Unknown
		//IL_0052: Unknown result type (might be due to invalid IL or missing references)
		//IL_005c: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		button = ((GComponent)this).GetController("button");
		n0 = (GImage)((GComponent)this).GetChild("n0");
		n1 = (GImage)((GComponent)this).GetChild("n1");
		n2 = (GTextField)((GComponent)this).GetChild("n2");
	}
}
