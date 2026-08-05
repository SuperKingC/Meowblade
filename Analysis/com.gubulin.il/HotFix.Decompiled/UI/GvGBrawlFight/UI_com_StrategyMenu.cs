using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGBrawlFight;

public class UI_com_StrategyMenu : GComponent
{
	public GImage n16;

	public GImage n13;

	public GList List;

	public GImage n1;

	public const string URL = "ui://hozu168rvb402g";

	public static string Name = "UI_com_StrategyMenu";

	public static string GetURL()
	{
		return "ui://hozu168rvb402g";
	}

	public static UI_com_StrategyMenu CreateInstance()
	{
		return (UI_com_StrategyMenu)(object)UIPackage.CreateObject("GvGBrawlFight", "com_StrategyMenu");
	}

	public static UI_com_StrategyMenu CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_StrategyMenu).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://hozu168rvb402g", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		((GComponent)this).ConstructFromXML(xml);
		n16 = (GImage)((GComponent)this).GetChild("n16");
		n13 = (GImage)((GComponent)this).GetChild("n13");
		List = (GList)((GComponent)this).GetChild("List");
		n1 = (GImage)((GComponent)this).GetChild("n1");
	}
}
