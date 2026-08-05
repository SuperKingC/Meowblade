using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGShipLaunch;

public class UI_btn_IslandInfo : GButton
{
	public Controller button;

	public GImage n3;

	public GImage n5;

	public GTextField IslandName;

	public const string URL = "ui://tc205cu3fgyl5";

	public static string Name = "UI_btn_IslandInfo";

	public static string GetURL()
	{
		return "ui://tc205cu3fgyl5";
	}

	public static UI_btn_IslandInfo CreateInstance()
	{
		return (UI_btn_IslandInfo)(object)UIPackage.CreateObject("GvGShipLaunch", "btn_IslandInfo");
	}

	public static UI_btn_IslandInfo CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_btn_IslandInfo).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://tc205cu3fgyl5", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		button = ((GComponent)this).GetController("button");
		n3 = (GImage)((GComponent)this).GetChild("n3");
		n5 = (GImage)((GComponent)this).GetChild("n5");
		IslandName = (GTextField)((GComponent)this).GetChild("IslandName");
	}
}
