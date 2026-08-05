using FairyGUI;
using FairyGUI.Utils;

namespace UI.PvpSelectSoldiers;

public class UI_RankNo3 : GComponent
{
	public GImage n23;

	public GImage n18;

	public GImage n20;

	public GList NoList;

	public const string URL = "ui://82mo10n51053d9s";

	public static string Name = "UI_RankNo3";

	public static string GetURL()
	{
		return "ui://82mo10n51053d9s";
	}

	public static UI_RankNo3 CreateInstance()
	{
		return (UI_RankNo3)(object)UIPackage.CreateObject("PvpSelectSoldiers", "RankNo3");
	}

	public static UI_RankNo3 CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_RankNo3).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://82mo10n51053d9s", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		n23 = (GImage)((GComponent)this).GetChild("n23");
		n18 = (GImage)((GComponent)this).GetChild("n18");
		n20 = (GImage)((GComponent)this).GetChild("n20");
		NoList = (GList)((GComponent)this).GetChild("NoList");
	}
}
