using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGBrawlFight;

public class UI_com_BrawlFightRuleHelp2 : GComponent
{
	public GImage n0;

	public UI_btn_Close Close;

	public GImage n20;

	public const string URL = "ui://hozu168r7sjy8w";

	public static string Name = "UI_com_BrawlFightRuleHelp2";

	public static string GetURL()
	{
		return "ui://hozu168r7sjy8w";
	}

	public static UI_com_BrawlFightRuleHelp2 CreateInstance()
	{
		return (UI_com_BrawlFightRuleHelp2)(object)UIPackage.CreateObject("GvGBrawlFight", "com_BrawlFightRuleHelp2");
	}

	public static UI_com_BrawlFightRuleHelp2 CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_BrawlFightRuleHelp2).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://hozu168r7sjy8w", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		//IL_0041: Unknown result type (might be due to invalid IL or missing references)
		//IL_004b: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		n0 = (GImage)((GComponent)this).GetChild("n0");
		Close = (UI_btn_Close)(object)((GComponent)this).GetChild("Close");
		n20 = (GImage)((GComponent)this).GetChild("n20");
	}
}
