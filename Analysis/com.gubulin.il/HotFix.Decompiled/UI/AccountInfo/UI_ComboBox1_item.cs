using FairyGUI;
using FairyGUI.Utils;

namespace UI.AccountInfo;

public class UI_ComboBox1_item : GButton
{
	public Controller buttonController;

	public GTextField title;

	public GImage n4;

	public GImage icon;

	public const string URL = "ui://b9yxt7u0t1jrc";

	public static string Name = "UI_ComboBox1_item";

	public static string GetURL()
	{
		return "ui://b9yxt7u0t1jrc";
	}

	public static UI_ComboBox1_item CreateInstance()
	{
		return (UI_ComboBox1_item)(object)UIPackage.CreateObject("AccountInfo", "ComboBox1_item");
	}

	public static UI_ComboBox1_item CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_ComboBox1_item).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://b9yxt7u0t1jrc", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
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
		buttonController = ((GComponent)this).GetController("buttonController");
		title = (GTextField)((GComponent)this).GetChild("title");
		n4 = (GImage)((GComponent)this).GetChild("n4");
		icon = (GImage)((GComponent)this).GetChild("icon");
	}
}
