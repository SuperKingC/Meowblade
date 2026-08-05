using FairyGUI;
using FairyGUI.Utils;

namespace UI.Lottery;

public class UI_EnterJackpotBtn : GButton
{
	public Controller button;

	public GGraph n0;

	public GGraph n5;

	public GGraph n6;

	public GTextField n3;

	public const string URL = "ui://gxhnhhxkrtxa9";

	public static string Name = "UI_EnterJackpotBtn";

	public static string GetURL()
	{
		return "ui://gxhnhhxkrtxa9";
	}

	public static UI_EnterJackpotBtn CreateInstance()
	{
		return (UI_EnterJackpotBtn)(object)UIPackage.CreateObject("Lottery", "EnterJackpotBtn");
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Expected O, but got Unknown
		//IL_003c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0046: Expected O, but got Unknown
		//IL_0052: Unknown result type (might be due to invalid IL or missing references)
		//IL_005c: Expected O, but got Unknown
		//IL_0068: Unknown result type (might be due to invalid IL or missing references)
		//IL_0072: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		button = ((GComponent)this).GetController("button");
		n0 = (GGraph)((GComponent)this).GetChild("n0");
		n5 = (GGraph)((GComponent)this).GetChild("n5");
		n6 = (GGraph)((GComponent)this).GetChild("n6");
		n3 = (GTextField)((GComponent)this).GetChild("n3");
	}
}
