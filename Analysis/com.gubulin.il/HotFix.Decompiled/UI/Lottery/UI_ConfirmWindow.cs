using FairyGUI;
using FairyGUI.Utils;

namespace UI.Lottery;

public class UI_ConfirmWindow : GComponent
{
	public GImage n0;

	public UI_ConfirmBtn ConfirmBtn;

	public GTextField n2;

	public GTextField CostAmount;

	public GTextField n5;

	public UI_CancelBtn CancelBtn;

	public const string URL = "ui://gxhnhhxkqgmmx";

	public static string Name = "UI_ConfirmWindow";

	public static string GetURL()
	{
		return "ui://gxhnhhxkqgmmx";
	}

	public static UI_ConfirmWindow CreateInstance()
	{
		return (UI_ConfirmWindow)(object)UIPackage.CreateObject("Lottery", "ConfirmWindow");
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		//IL_0041: Unknown result type (might be due to invalid IL or missing references)
		//IL_004b: Expected O, but got Unknown
		//IL_0057: Unknown result type (might be due to invalid IL or missing references)
		//IL_0061: Expected O, but got Unknown
		//IL_006d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0077: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		n0 = (GImage)((GComponent)this).GetChild("n0");
		ConfirmBtn = (UI_ConfirmBtn)(object)((GComponent)this).GetChild("ConfirmBtn");
		n2 = (GTextField)((GComponent)this).GetChild("n2");
		CostAmount = (GTextField)((GComponent)this).GetChild("CostAmount");
		n5 = (GTextField)((GComponent)this).GetChild("n5");
		CancelBtn = (UI_CancelBtn)(object)((GComponent)this).GetChild("CancelBtn");
	}
}
