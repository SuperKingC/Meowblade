using FairyGUI;
using FairyGUI.Utils;

namespace UI.Legion;

public class UI_RemoveSoldierBtn : GButton
{
	public Controller button;

	public GImage n8;

	public const string URL = "ui://lrhs6zw7ndu545b";

	public static string Name = "UI_RemoveSoldierBtn";

	public static string GetURL()
	{
		return "ui://lrhs6zw7ndu545b";
	}

	public static UI_RemoveSoldierBtn CreateInstance()
	{
		return (UI_RemoveSoldierBtn)(object)UIPackage.CreateObject("Legion", "RemoveSoldierBtn");
	}

	public static UI_RemoveSoldierBtn CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_RemoveSoldierBtn).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://lrhs6zw7ndu545b", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		button = ((GComponent)this).GetController("button");
		n8 = (GImage)((GComponent)this).GetChild("n8");
	}
}
