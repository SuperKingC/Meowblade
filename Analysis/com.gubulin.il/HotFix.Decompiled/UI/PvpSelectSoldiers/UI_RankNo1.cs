using FairyGUI;
using FairyGUI.Utils;

namespace UI.PvpSelectSoldiers;

public class UI_RankNo1 : GComponent
{
	public GImage n17;

	public GImage n14;

	public GImage n15;

	public GList NoList;

	public const string URL = "ui://82mo10n51053d9m";

	public static string Name = "UI_RankNo1";

	public static string GetURL()
	{
		return "ui://82mo10n51053d9m";
	}

	public static UI_RankNo1 CreateInstance()
	{
		return (UI_RankNo1)(object)UIPackage.CreateObject("PvpSelectSoldiers", "RankNo1");
	}

	public static UI_RankNo1 CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_RankNo1).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://82mo10n51053d9m", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		n17 = (GImage)((GComponent)this).GetChild("n17");
		n14 = (GImage)((GComponent)this).GetChild("n14");
		n15 = (GImage)((GComponent)this).GetChild("n15");
		NoList = (GList)((GComponent)this).GetChild("NoList");
	}
}
