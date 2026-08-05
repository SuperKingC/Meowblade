using FairyGUI;
using FairyGUI.Utils;

namespace UI.WorkShop;

public class UI_upgrade : GButton
{
	public Controller button;

	public GImage arrow;

	public const string URL = "ui://k6y9jq3appg4z";

	public static string Name = "UI_upgrade";

	public static string GetURL()
	{
		return "ui://k6y9jq3appg4z";
	}

	public static UI_upgrade CreateInstance()
	{
		return (UI_upgrade)(object)UIPackage.CreateObject("WorkShop", "upgrade");
	}

	public static UI_upgrade CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_upgrade).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://k6y9jq3appg4z", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		button = ((GComponent)this).GetController("button");
		arrow = (GImage)((GComponent)this).GetChild("arrow");
	}
}
