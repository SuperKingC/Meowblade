using FairyGUI;
using FairyGUI.Utils;

namespace UI.QQGameActivity;

public class UI_com_01 : GComponent
{
	public Controller c1;

	public Controller c2;

	public GImage n33;

	public GImage n21;

	public GImage n24;

	public GImage n25;

	public GImage n27;

	public GTextField MoneyText;

	public GImage n26;

	public GImage n22;

	public GLoader icon;

	public GButton GetGiftBtn;

	public GImage n30;

	public GTextField UnlockLevel;

	public GImage n32;

	public Transition t0;

	public const string URL = "ui://r1j1a2l0nbmf34";

	public static string Name = "UI_com_01";

	public static string GetURL()
	{
		return "ui://r1j1a2l0nbmf34";
	}

	public static UI_com_01 CreateInstance()
	{
		return (UI_com_01)(object)UIPackage.CreateObject("QQGameActivity", "com_01");
	}

	public static UI_com_01 CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_01).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://r1j1a2l0nbmf34", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
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
		//IL_00bb: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c5: Expected O, but got Unknown
		//IL_00d1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00db: Expected O, but got Unknown
		//IL_00e7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f1: Expected O, but got Unknown
		//IL_00fd: Unknown result type (might be due to invalid IL or missing references)
		//IL_0107: Expected O, but got Unknown
		//IL_0113: Unknown result type (might be due to invalid IL or missing references)
		//IL_011d: Expected O, but got Unknown
		//IL_0129: Unknown result type (might be due to invalid IL or missing references)
		//IL_0133: Expected O, but got Unknown
		//IL_013f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0149: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		c1 = ((GComponent)this).GetController("c1");
		c2 = ((GComponent)this).GetController("c2");
		n33 = (GImage)((GComponent)this).GetChild("n33");
		n21 = (GImage)((GComponent)this).GetChild("n21");
		n24 = (GImage)((GComponent)this).GetChild("n24");
		n25 = (GImage)((GComponent)this).GetChild("n25");
		n27 = (GImage)((GComponent)this).GetChild("n27");
		MoneyText = (GTextField)((GComponent)this).GetChild("MoneyText");
		n26 = (GImage)((GComponent)this).GetChild("n26");
		n22 = (GImage)((GComponent)this).GetChild("n22");
		icon = (GLoader)((GComponent)this).GetChild("icon");
		GetGiftBtn = (GButton)((GComponent)this).GetChild("GetGiftBtn");
		n30 = (GImage)((GComponent)this).GetChild("n30");
		UnlockLevel = (GTextField)((GComponent)this).GetChild("UnlockLevel");
		n32 = (GImage)((GComponent)this).GetChild("n32");
		t0 = ((GComponent)this).GetTransition("t0");
	}
}
