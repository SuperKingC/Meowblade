using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGWorldMap3;

public class UI_btn_CheckFlagShipMissions : GButton
{
	public GImage back;

	public GTextField n3;

	public const string URL = "ui://4eq8fgd2ko68dh";

	public static string Name = "UI_btn_CheckFlagShipMissions";

	public static string GetURL()
	{
		return "ui://4eq8fgd2ko68dh";
	}

	public static UI_btn_CheckFlagShipMissions CreateInstance()
	{
		return (UI_btn_CheckFlagShipMissions)(object)UIPackage.CreateObject("GvGWorldMap3", "btn_CheckFlagShipMissions");
	}

	public static UI_btn_CheckFlagShipMissions CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_btn_CheckFlagShipMissions).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://4eq8fgd2ko68dh", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0035: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		back = (GImage)((GComponent)this).GetChild("back");
		n3 = (GTextField)((GComponent)this).GetChild("n3");
		string id = "ui://4eq8fgd2ko68dh".Replace("ui://", "") + "-" + ((GObject)n3).id;
		((GObject)n3).text = LanguagesManager.GetDesc(id);
	}
}
