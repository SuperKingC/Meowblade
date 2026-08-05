using FairyGUI;
using FairyGUI.Utils;

namespace UI.Battle;

public class UI_GvGBossHpBackBar : GProgressBar
{
	public UI_GvGBossHpBackBarCom bar;

	public const string URL = "ui://twlbabiclqo8le";

	public static string Name = "UI_GvGBossHpBackBar";

	public static string GetURL()
	{
		return "ui://twlbabiclqo8le";
	}

	public static UI_GvGBossHpBackBar CreateInstance()
	{
		return (UI_GvGBossHpBackBar)(object)UIPackage.CreateObject("Battle", "GvGBossHpBackBar");
	}

	public static UI_GvGBossHpBackBar CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_GvGBossHpBackBar).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://twlbabiclqo8le", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		((GComponent)this).ConstructFromXML(xml);
		bar = (UI_GvGBossHpBackBarCom)(object)((GComponent)this).GetChild("bar");
	}
}
