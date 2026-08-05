using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGPlayerCommand3;

public class UI_btn_Command : GButton
{
	public Controller Type;

	public Controller button;

	public GImage n5;

	public GImage n6;

	public GImage n1;

	public GImage n2;

	public GImage n3;

	public GImage n4;

	public const string URL = "ui://vheg8vabfmir0";

	public static string Name = "UI_btn_Command";

	public static string GetURL()
	{
		return "ui://vheg8vabfmir0";
	}

	public static UI_btn_Command CreateInstance()
	{
		return (UI_btn_Command)(object)UIPackage.CreateObject("GvGPlayerCommand3", "btn_Command");
	}

	public static UI_btn_Command CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_btn_Command).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://vheg8vabfmir0", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		((GComponent)this).ConstructFromXML(xml);
		Type = ((GComponent)this).GetController("Type");
		button = ((GComponent)this).GetController("button");
		n5 = (GImage)((GComponent)this).GetChild("n5");
		n6 = (GImage)((GComponent)this).GetChild("n6");
		n1 = (GImage)((GComponent)this).GetChild("n1");
		n2 = (GImage)((GComponent)this).GetChild("n2");
		n3 = (GImage)((GComponent)this).GetChild("n3");
		n4 = (GImage)((GComponent)this).GetChild("n4");
	}
}
