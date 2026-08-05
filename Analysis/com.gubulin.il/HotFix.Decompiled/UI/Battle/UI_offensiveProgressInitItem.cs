using FairyGUI;
using FairyGUI.Utils;

namespace UI.Battle;

public class UI_offensiveProgressInitItem : GButton
{
	public Controller button;

	public GImage n2;

	public const string URL = "ui://twlbabic7c533g";

	public static string Name = "UI_offensiveProgressInitItem";

	public static string GetURL()
	{
		return "ui://twlbabic7c533g";
	}

	public static UI_offensiveProgressInitItem CreateInstance()
	{
		return (UI_offensiveProgressInitItem)(object)UIPackage.CreateObject("Battle", "offensiveProgressInitItem");
	}

	public static UI_offensiveProgressInitItem CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_offensiveProgressInitItem).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://twlbabic7c533g", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		button = ((GComponent)this).GetController("button");
		n2 = (GImage)((GComponent)this).GetChild("n2");
	}
}
