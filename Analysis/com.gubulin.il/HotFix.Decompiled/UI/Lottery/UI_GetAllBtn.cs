using FairyGUI;
using FairyGUI.Utils;

namespace UI.Lottery;

public class UI_GetAllBtn : GButton
{
	public Controller button;

	public GGraph n0;

	public GGraph n1;

	public GGraph n2;

	public GTextField n3;

	public const string URL = "ui://gxhnhhxkrtxac";

	public static string Name = "UI_GetAllBtn";

	public static string GetURL()
	{
		return "ui://gxhnhhxkrtxac";
	}

	public static UI_GetAllBtn CreateInstance()
	{
		return (UI_GetAllBtn)(object)UIPackage.CreateObject("Lottery", "GetAllBtn");
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
		n1 = (GGraph)((GComponent)this).GetChild("n1");
		n2 = (GGraph)((GComponent)this).GetChild("n2");
		n3 = (GTextField)((GComponent)this).GetChild("n3");
	}
}
