using FairyGUI;
using FairyGUI.Utils;

namespace UI.MonthCard;

public class UI_PrivilegeBtn : GButton
{
	public Controller button;

	public Controller RarityController;

	public Controller IsActivated;

	public GImage n3;

	public GImage n13;

	public GImage n5;

	public GImage n7;

	public GGroup n9;

	public GImage n4;

	public GImage n14;

	public GImage n6;

	public GImage n8;

	public GGroup n10;

	public GImage n11;

	public GImage n12;

	public const string URL = "ui://4ctl553stjci2r";

	public static string Name = "UI_PrivilegeBtn";

	public static string GetURL()
	{
		return "ui://4ctl553stjci2r";
	}

	public static UI_PrivilegeBtn CreateInstance()
	{
		return (UI_PrivilegeBtn)(object)UIPackage.CreateObject("MonthCard", "PrivilegeBtn");
	}

	public static UI_PrivilegeBtn CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_PrivilegeBtn).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://4ctl553stjci2r", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0048: Unknown result type (might be due to invalid IL or missing references)
		//IL_0052: Expected O, but got Unknown
		//IL_005e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0068: Expected O, but got Unknown
		//IL_0074: Unknown result type (might be due to invalid IL or missing references)
		//IL_007e: Expected O, but got Unknown
		//IL_008a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0094: Expected O, but got Unknown
		//IL_00a0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00aa: Expected O, but got Unknown
		//IL_00b6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c0: Expected O, but got Unknown
		//IL_00cc: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d6: Expected O, but got Unknown
		//IL_00e2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ec: Expected O, but got Unknown
		//IL_00f8: Unknown result type (might be due to invalid IL or missing references)
		//IL_0102: Expected O, but got Unknown
		//IL_010e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0118: Expected O, but got Unknown
		//IL_0124: Unknown result type (might be due to invalid IL or missing references)
		//IL_012e: Expected O, but got Unknown
		//IL_013a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0144: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		button = ((GComponent)this).GetController("button");
		RarityController = ((GComponent)this).GetController("RarityController");
		IsActivated = ((GComponent)this).GetController("IsActivated");
		n3 = (GImage)((GComponent)this).GetChild("n3");
		n13 = (GImage)((GComponent)this).GetChild("n13");
		n5 = (GImage)((GComponent)this).GetChild("n5");
		n7 = (GImage)((GComponent)this).GetChild("n7");
		n9 = (GGroup)((GComponent)this).GetChild("n9");
		n4 = (GImage)((GComponent)this).GetChild("n4");
		n14 = (GImage)((GComponent)this).GetChild("n14");
		n6 = (GImage)((GComponent)this).GetChild("n6");
		n8 = (GImage)((GComponent)this).GetChild("n8");
		n10 = (GGroup)((GComponent)this).GetChild("n10");
		n11 = (GImage)((GComponent)this).GetChild("n11");
		n12 = (GImage)((GComponent)this).GetChild("n12");
	}
}
