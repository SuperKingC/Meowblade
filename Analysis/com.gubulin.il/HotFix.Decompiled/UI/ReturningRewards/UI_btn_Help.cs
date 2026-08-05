using FairyGUI;
using FairyGUI.Utils;

namespace UI.ReturningRewards;

public class UI_btn_Help : GButton
{
	public Controller button;

	public GImage n3;

	public const string URL = "ui://rx5ntv98yvss2c";

	public static string Name = "UI_btn_Help";

	public static string GetURL()
	{
		return "ui://rx5ntv98yvss2c";
	}

	public static UI_btn_Help CreateInstance()
	{
		return (UI_btn_Help)(object)UIPackage.CreateObject("ReturningRewards", "btn_Help");
	}

	public static UI_btn_Help CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_btn_Help).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://rx5ntv98yvss2c", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		button = ((GComponent)this).GetController("button");
		n3 = (GImage)((GComponent)this).GetChild("n3");
	}
}
