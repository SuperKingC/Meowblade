using FairyGUI;
using FairyGUI.Utils;

namespace UI.GameEndPanels;

public class UI_OurHealthBar : GProgressBar
{
	public GImage back;

	public GImage bar;

	public const string URL = "ui://hda5vzklrjqw3e";

	public static string Name = "UI_OurHealthBar";

	public static string GetURL()
	{
		return "ui://hda5vzklrjqw3e";
	}

	public static UI_OurHealthBar CreateInstance()
	{
		return (UI_OurHealthBar)(object)UIPackage.CreateObject("GameEndPanels", "OurHealthBar");
	}

	public static UI_OurHealthBar CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_OurHealthBar).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://hda5vzklrjqw3e", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		bar = (GImage)((GComponent)this).GetChild("bar");
	}
}
