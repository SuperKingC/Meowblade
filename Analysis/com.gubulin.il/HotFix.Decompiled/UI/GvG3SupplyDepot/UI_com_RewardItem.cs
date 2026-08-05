using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvG3SupplyDepot;

public class UI_com_RewardItem : GComponent
{
	public GImage n7;

	public GLoader icon;

	public const string URL = "ui://pobej4q7t6pm10";

	public static string Name = "UI_com_RewardItem";

	public static string GetURL()
	{
		return "ui://pobej4q7t6pm10";
	}

	public static UI_com_RewardItem CreateInstance()
	{
		return (UI_com_RewardItem)(object)UIPackage.CreateObject("GvG3SupplyDepot", "com_RewardItem");
	}

	public static UI_com_RewardItem CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_RewardItem).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://pobej4q7t6pm10", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0035: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		n7 = (GImage)((GComponent)this).GetChild("n7");
		icon = (GLoader)((GComponent)this).GetChild("icon");
	}
}
