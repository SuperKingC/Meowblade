using FairyGUI;
using FairyGUI.Utils;

namespace UI.GameEndPanels;

public class UI_OurDamageMeterComB : GComponent
{
	public GGraph Back;

	public GList SoldierDamageDataList;

	public const string URL = "ui://hda5vzklr5kt49";

	public static string Name = "UI_OurDamageMeterComB";

	public static string GetURL()
	{
		return "ui://hda5vzklr5kt49";
	}

	public static UI_OurDamageMeterComB CreateInstance()
	{
		return (UI_OurDamageMeterComB)(object)UIPackage.CreateObject("GameEndPanels", "OurDamageMeterComB");
	}

	public static UI_OurDamageMeterComB CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_OurDamageMeterComB).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://hda5vzklr5kt49", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0035: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		Back = (GGraph)((GComponent)this).GetChild("Back");
		SoldierDamageDataList = (GList)((GComponent)this).GetChild("SoldierDamageDataList");
	}
}
