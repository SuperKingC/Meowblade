using FairyGUI;
using FairyGUI.Utils;

namespace UI.WorkShop;

public class UI_armItem1 : GButton
{
	public Controller button;

	public GImage n25;

	public const string URL = "ui://k6y9jq3amtr02u";

	public static string Name = "UI_armItem1";

	public static string GetURL()
	{
		return "ui://k6y9jq3amtr02u";
	}

	public static UI_armItem1 CreateInstance()
	{
		return (UI_armItem1)(object)UIPackage.CreateObject("WorkShop", "armItem1");
	}

	public static UI_armItem1 CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_armItem1).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://k6y9jq3amtr02u", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		button = ((GComponent)this).GetController("button");
		n25 = (GImage)((GComponent)this).GetChild("n25");
	}
}
