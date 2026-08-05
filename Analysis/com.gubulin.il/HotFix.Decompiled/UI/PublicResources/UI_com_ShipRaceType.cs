using FairyGUI;
using FairyGUI.Utils;

namespace UI.PublicResources;

public class UI_com_ShipRaceType : GButton
{
	public Controller button;

	public GLoader RaceIcon;

	public const string URL = "ui://kt6rg65osdu22c";

	public static string Name = "UI_com_ShipRaceType";

	public static string GetURL()
	{
		return "ui://kt6rg65osdu22c";
	}

	public static UI_com_ShipRaceType CreateInstance()
	{
		return (UI_com_ShipRaceType)(object)UIPackage.CreateObject("PublicResources", "com_ShipRaceType");
	}

	public static UI_com_ShipRaceType CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_ShipRaceType).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://kt6rg65osdu22c", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		button = ((GComponent)this).GetController("button");
		RaceIcon = (GLoader)((GComponent)this).GetChild("RaceIcon");
	}
}
