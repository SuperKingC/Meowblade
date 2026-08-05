using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGWorldMap3;

public class UI_com_FilterIcon : GComponent
{
	public GLoader Icon;

	public const string URL = "ui://4eq8fgd2kivrsbp";

	public static string Name = "UI_com_FilterIcon";

	public static string GetURL()
	{
		return "ui://4eq8fgd2kivrsbp";
	}

	public static UI_com_FilterIcon CreateInstance()
	{
		return (UI_com_FilterIcon)(object)UIPackage.CreateObject("GvGWorldMap3", "com_FilterIcon");
	}

	public static UI_com_FilterIcon CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_FilterIcon).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://4eq8fgd2kivrsbp", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
