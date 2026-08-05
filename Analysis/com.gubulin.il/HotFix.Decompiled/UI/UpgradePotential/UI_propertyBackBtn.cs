using FairyGUI;
using FairyGUI.Utils;

namespace UI.UpgradePotential;

public class UI_propertyBackBtn : GButton
{
	public Controller button;

	public GImage n16;

	public const string URL = "ui://l5ik1uclic7jt81";

	public static string Name = "UI_propertyBackBtn";

	public static string GetURL()
	{
		return "ui://l5ik1uclic7jt81";
	}

	public static UI_propertyBackBtn CreateInstance()
	{
		return (UI_propertyBackBtn)(object)UIPackage.CreateObject("UpgradePotential", "propertyBackBtn");
	}

	public static UI_propertyBackBtn CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_propertyBackBtn).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://l5ik1uclic7jt81", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		button = ((GComponent)this).GetController("button");
		n16 = (GImage)((GComponent)this).GetChild("n16");
	}
}
