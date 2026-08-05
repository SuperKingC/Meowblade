using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGWorldMap3;

public class UI_com_ShipIcon : GComponent
{
	public GLoader Icon;

	public const string URL = "ui://4eq8fgd2zit4a7";

	public static string Name = "UI_com_ShipIcon";

	public static string GetURL()
	{
		return "ui://4eq8fgd2zit4a7";
	}

	public static UI_com_ShipIcon CreateInstance()
	{
		return (UI_com_ShipIcon)(object)UIPackage.CreateObject("GvGWorldMap3", "com_ShipIcon");
	}

	public static UI_com_ShipIcon CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_ShipIcon).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://4eq8fgd2zit4a7", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		Icon = (GLoader)((GComponent)this).GetChild("Icon");
	}
}
