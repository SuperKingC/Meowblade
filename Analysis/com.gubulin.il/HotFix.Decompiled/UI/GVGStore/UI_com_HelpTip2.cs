using FairyGUI;
using FairyGUI.Utils;

namespace UI.GVGStore;

public class UI_com_HelpTip2 : GComponent
{
	public GImage n5;

	public GImage n6;

	public GGroup n7;

	public const string URL = "ui://fvc33k3gdrjq30";

	public static string Name = "UI_com_HelpTip2";

	public static string GetURL()
	{
		return "ui://fvc33k3gdrjq30";
	}

	public static UI_com_HelpTip2 CreateInstance()
	{
		return (UI_com_HelpTip2)(object)UIPackage.CreateObject("GVGStore", "com_HelpTip2");
	}

	public static UI_com_HelpTip2 CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_HelpTip2).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://fvc33k3gdrjq30", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0035: Expected O, but got Unknown
		//IL_0041: Unknown result type (might be due to invalid IL or missing references)
		//IL_004b: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		n5 = (GImage)((GComponent)this).GetChild("n5");
		n6 = (GImage)((GComponent)this).GetChild("n6");
		n7 = (GGroup)((GComponent)this).GetChild("n7");
	}
}
