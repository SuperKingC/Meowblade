using FairyGUI;
using FairyGUI.Utils;

namespace UI.RecyclingCenter;

public class UI_confirm : GButton
{
	public Controller button;

	public GImage back;

	public GImage n7;

	public const string URL = "ui://72poq8plkxixi";

	public static string Name = "UI_confirm";

	public static string GetURL()
	{
		return "ui://72poq8plkxixi";
	}

	public static UI_confirm CreateInstance()
	{
		return (UI_confirm)(object)UIPackage.CreateObject("RecyclingCenter", "confirm");
	}

	public static UI_confirm CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_confirm).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://72poq8plkxixi", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Expected O, but got Unknown
		//IL_003c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0046: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		button = ((GComponent)this).GetController("button");
		back = (GImage)((GComponent)this).GetChild("back");
		n7 = (GImage)((GComponent)this).GetChild("n7");
	}
}
