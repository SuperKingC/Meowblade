using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGWorldMap3;

public class UI_bar_01 : GProgressBar
{
	public GImage bar;

	public const string URL = "ui://4eq8fgd2pepcs7v";

	public static string Name = "UI_bar_01";

	public static string GetURL()
	{
		return "ui://4eq8fgd2pepcs7v";
	}

	public static UI_bar_01 CreateInstance()
	{
		return (UI_bar_01)(object)UIPackage.CreateObject("GvGWorldMap3", "bar_01");
	}

	public static UI_bar_01 CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_bar_01).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://4eq8fgd2pepcs7v", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		bar = (GImage)((GComponent)this).GetChild("bar");
	}
}
