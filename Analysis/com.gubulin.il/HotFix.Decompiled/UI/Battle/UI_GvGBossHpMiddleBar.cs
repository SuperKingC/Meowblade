using FairyGUI;
using FairyGUI.Utils;

namespace UI.Battle;

public class UI_GvGBossHpMiddleBar : GProgressBar
{
	public GImage bar;

	public const string URL = "ui://twlbabiclqo8lf";

	public static string Name = "UI_GvGBossHpMiddleBar";

	public static string GetURL()
	{
		return "ui://twlbabiclqo8lf";
	}

	public static UI_GvGBossHpMiddleBar CreateInstance()
	{
		return (UI_GvGBossHpMiddleBar)(object)UIPackage.CreateObject("Battle", "GvGBossHpMiddleBar");
	}

	public static UI_GvGBossHpMiddleBar CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_GvGBossHpMiddleBar).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://twlbabiclqo8lf", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
