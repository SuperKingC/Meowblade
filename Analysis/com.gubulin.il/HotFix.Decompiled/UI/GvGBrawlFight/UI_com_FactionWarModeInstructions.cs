using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGBrawlFight;

public class UI_com_FactionWarModeInstructions : GComponent
{
	public GImage n2;

	public GImage n1;

	public GImage bg;

	public GImage n4;

	public GList rewardList;

	public GTextField n6;

	public const string URL = "ui://hozu168rniiv6v";

	public static string Name = "UI_com_FactionWarModeInstructions";

	public static string GetURL()
	{
		return "ui://hozu168rniiv6v";
	}

	public static UI_com_FactionWarModeInstructions CreateInstance()
	{
		return (UI_com_FactionWarModeInstructions)(object)UIPackage.CreateObject("GvGBrawlFight", "com_FactionWarModeInstructions");
	}

	public static UI_com_FactionWarModeInstructions CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_FactionWarModeInstructions).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://hozu168rniiv6v", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0035: Expected O, but got Unknown
		//IL_0041: Unknown result type (might be due to invalid IL or missing references)
		//IL_004b: Expected O, but got Unknown
		//IL_0057: Unknown result type (might be due to invalid IL or missing references)
		//IL_0061: Expected O, but got Unknown
		//IL_006d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0077: Expected O, but got Unknown
		//IL_0083: Unknown result type (might be due to invalid IL or missing references)
		//IL_008d: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		n2 = (GImage)((GComponent)this).GetChild("n2");
		n1 = (GImage)((GComponent)this).GetChild("n1");
		bg = (GImage)((GComponent)this).GetChild("bg");
		n4 = (GImage)((GComponent)this).GetChild("n4");
		rewardList = (GList)((GComponent)this).GetChild("rewardList");
		n6 = (GTextField)((GComponent)this).GetChild("n6");
		string id = "ui://hozu168rniiv6v".Replace("ui://", "") + "-" + ((GObject)n6).id;
		((GObject)n6).text = LanguagesManager.GetDesc(id);
	}
}
