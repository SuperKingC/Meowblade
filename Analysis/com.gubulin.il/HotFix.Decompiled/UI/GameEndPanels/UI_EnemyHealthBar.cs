using FairyGUI;
using FairyGUI.Utils;

namespace UI.GameEndPanels;

public class UI_EnemyHealthBar : GProgressBar
{
	public GImage back;

	public GImage bar;

	public const string URL = "ui://hda5vzklrjqw3f";

	public static string Name = "UI_EnemyHealthBar";

	public static string GetURL()
	{
		return "ui://hda5vzklrjqw3f";
	}

	public static UI_EnemyHealthBar CreateInstance()
	{
		return (UI_EnemyHealthBar)(object)UIPackage.CreateObject("GameEndPanels", "EnemyHealthBar");
	}

	public static UI_EnemyHealthBar CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_EnemyHealthBar).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://hda5vzklrjqw3f", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
