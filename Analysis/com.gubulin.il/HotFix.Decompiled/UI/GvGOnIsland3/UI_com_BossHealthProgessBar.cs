using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGOnIsland3;

public class UI_com_BossHealthProgessBar : GProgressBar
{
	public GImage bar;

	public const string URL = "ui://ebc4ciwrl44l1l";

	public static string Name = "UI_com_BossHealthProgessBar";

	public static string GetURL()
	{
		return "ui://ebc4ciwrl44l1l";
	}

	public static UI_com_BossHealthProgessBar CreateInstance()
	{
		return (UI_com_BossHealthProgessBar)(object)UIPackage.CreateObject("GvGOnIsland3", "com_BossHealthProgessBar");
	}

	public static UI_com_BossHealthProgessBar CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_BossHealthProgessBar).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://ebc4ciwrl44l1l", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
