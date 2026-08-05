using FairyGUI;
using FairyGUI.Utils;

namespace UI.LordOfDreams;

public class UI_BossHealthProgessBar : GProgressBar
{
	public GImage n5;

	public GImage bar;

	public const string URL = "ui://0i520nzmiv0uo8p";

	public static string Name = "UI_BossHealthProgessBar";

	public static string GetURL()
	{
		return "ui://0i520nzmiv0uo8p";
	}

	public static UI_BossHealthProgessBar CreateInstance()
	{
		return (UI_BossHealthProgessBar)(object)UIPackage.CreateObject("LordOfDreams", "BossHealthProgessBar");
	}

	public static UI_BossHealthProgessBar CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_BossHealthProgessBar).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://0i520nzmiv0uo8p", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0035: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		n5 = (GImage)((GComponent)this).GetChild("n5");
		bar = (GImage)((GComponent)this).GetChild("bar");
	}
}
