using FairyGUI;
using FairyGUI.Utils;
using HotFix.Sources.Base.Sources.Scripts.GvG3UI.Helper;
using HotFix.Sources.Base.Sources.Scripts.GvG3UI.Model;

namespace UI.PublicResources;

public class UI_com_ShipSmallIcon : GComponent
{
	public GLoader IconLoader;

	public const string URL = "ui://kt6rg65oebovv4nl";

	public static string Name = "UI_com_ShipSmallIcon";

	public static string GetURL()
	{
		return "ui://kt6rg65oebovv4nl";
	}

	public static UI_com_ShipSmallIcon CreateInstance()
	{
		return (UI_com_ShipSmallIcon)(object)UIPackage.CreateObject("PublicResources", "com_ShipSmallIcon");
	}

	public static UI_com_ShipSmallIcon CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_ShipSmallIcon).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://kt6rg65oebovv4nl", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		IconLoader = (GLoader)((GComponent)this).GetChild("IconLoader");
	}

	public void SetShipStyle(int race, int campId)
	{
		if (race == -2 || race == 99)
		{
			((GObject)IconLoader).visible = false;
			return;
		}
		((GObject)IconLoader).visible = true;
		ShipConfigModel byShipRaceType = ShipConfigHelper.GetByShipRaceType(race);
		IconLoader.url = ShipConfigHelper.GetSkinById(byShipRaceType.DefaultSkinId).GetMiniIconUrlByCamId(campId);
	}
}
