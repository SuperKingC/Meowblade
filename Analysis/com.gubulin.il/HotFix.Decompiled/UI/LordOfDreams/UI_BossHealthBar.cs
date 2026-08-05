using FairyGUI;
using FairyGUI.Utils;

namespace UI.LordOfDreams;

public class UI_BossHealthBar : GProgressBar
{
	public GImage back;

	public GImage bar;

	public const string URL = "ui://0i520nzmt300o6s";

	public static string Name = "UI_BossHealthBar";

	public static string GetURL()
	{
		return "ui://0i520nzmt300o6s";
	}

	public static UI_BossHealthBar CreateInstance()
	{
		return (UI_BossHealthBar)(object)UIPackage.CreateObject("LordOfDreams", "BossHealthBar");
	}

	public static UI_BossHealthBar CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_BossHealthBar).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://0i520nzmt300o6s", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
