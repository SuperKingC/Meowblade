using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGWorldMap3;

public class UI_dec_OpertarionShipBG : GComponent
{
	public GImage n90;

	public GImage n91;

	public const string URL = "ui://4eq8fgd2b87g64";

	public static string Name = "UI_dec_OpertarionShipBG";

	public static string GetURL()
	{
		return "ui://4eq8fgd2b87g64";
	}

	public static UI_dec_OpertarionShipBG CreateInstance()
	{
		return (UI_dec_OpertarionShipBG)(object)UIPackage.CreateObject("GvGWorldMap3", "dec_OpertarionShipBG");
	}

	public static UI_dec_OpertarionShipBG CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_dec_OpertarionShipBG).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://4eq8fgd2b87g64", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0035: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		n90 = (GImage)((GComponent)this).GetChild("n90");
		n91 = (GImage)((GComponent)this).GetChild("n91");
	}
}
