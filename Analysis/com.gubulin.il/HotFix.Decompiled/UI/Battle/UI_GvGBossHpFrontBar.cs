using FairyGUI;
using FairyGUI.Utils;

namespace UI.Battle;

public class UI_GvGBossHpFrontBar : GProgressBar
{
	public UI_GvGBossHpFrontBarCom bar;

	public const string URL = "ui://twlbabiclqo8lc";

	public static string Name = "UI_GvGBossHpFrontBar";

	public static string GetURL()
	{
		return "ui://twlbabiclqo8lc";
	}

	public static UI_GvGBossHpFrontBar CreateInstance()
	{
		return (UI_GvGBossHpFrontBar)(object)UIPackage.CreateObject("Battle", "GvGBossHpFrontBar");
	}

	public static UI_GvGBossHpFrontBar CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_GvGBossHpFrontBar).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://twlbabiclqo8lc", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		((GComponent)this).ConstructFromXML(xml);
		bar = (UI_GvGBossHpFrontBarCom)(object)((GComponent)this).GetChild("bar");
	}
}
