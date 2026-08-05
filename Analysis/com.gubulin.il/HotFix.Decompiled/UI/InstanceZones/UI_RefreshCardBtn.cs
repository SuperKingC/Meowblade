using FairyGUI;
using FairyGUI.Utils;

namespace UI.InstanceZones;

public class UI_RefreshCardBtn : GButton
{
	public Controller button;

	public GImage n6;

	public const string URL = "ui://f4wr270ric7j2w";

	public static string Name = "UI_RefreshCardBtn";

	public static string GetURL()
	{
		return "ui://f4wr270ric7j2w";
	}

	public static UI_RefreshCardBtn CreateInstance()
	{
		return (UI_RefreshCardBtn)(object)UIPackage.CreateObject("InstanceZones", "RefreshCardBtn");
	}

	public static UI_RefreshCardBtn CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_RefreshCardBtn).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://f4wr270ric7j2w", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		button = ((GComponent)this).GetController("button");
		n6 = (GImage)((GComponent)this).GetChild("n6");
	}
}
