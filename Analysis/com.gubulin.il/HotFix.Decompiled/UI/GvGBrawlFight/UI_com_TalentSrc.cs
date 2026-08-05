using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGBrawlFight;

public class UI_com_TalentSrc : GComponent
{
	public GLoader Icon;

	public GTextField TalentName;

	public const string URL = "ui://hozu168rbbek77";

	public static string Name = "UI_com_TalentSrc";

	public static string GetURL()
	{
		return "ui://hozu168rbbek77";
	}

	public static UI_com_TalentSrc CreateInstance()
	{
		return (UI_com_TalentSrc)(object)UIPackage.CreateObject("GvGBrawlFight", "com_TalentSrc");
	}

	public static UI_com_TalentSrc CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_TalentSrc).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://hozu168rbbek77", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0035: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		Icon = (GLoader)((GComponent)this).GetChild("Icon");
		TalentName = (GTextField)((GComponent)this).GetChild("TalentName");
	}
}
