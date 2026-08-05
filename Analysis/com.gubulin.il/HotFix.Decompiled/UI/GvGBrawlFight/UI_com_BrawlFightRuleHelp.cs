using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGBrawlFight;

public class UI_com_BrawlFightRuleHelp : GComponent
{
	public GImage n0;

	public GImage n19;

	public UI_btn_Close Close;

	public const string URL = "ui://hozu168rliey8h";

	public static string Name = "UI_com_BrawlFightRuleHelp";

	public static string GetURL()
	{
		return "ui://hozu168rliey8h";
	}

	public static UI_com_BrawlFightRuleHelp CreateInstance()
	{
		return (UI_com_BrawlFightRuleHelp)(object)UIPackage.CreateObject("GvGBrawlFight", "com_BrawlFightRuleHelp");
	}

	public static UI_com_BrawlFightRuleHelp CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_BrawlFightRuleHelp).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://hozu168rliey8h", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0035: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		n0 = (GImage)((GComponent)this).GetChild("n0");
		n19 = (GImage)((GComponent)this).GetChild("n19");
		Close = (UI_btn_Close)(object)((GComponent)this).GetChild("Close");
	}
}
