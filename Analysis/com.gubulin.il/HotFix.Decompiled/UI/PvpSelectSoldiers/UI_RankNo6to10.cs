using FairyGUI;
using FairyGUI.Utils;

namespace UI.PvpSelectSoldiers;

public class UI_RankNo6to10 : GComponent
{
	public GImage NoListBackground;

	public GList NoList;

	public GImage n45;

	public GImage n44;

	public GImage n46;

	public GImage n47;

	public GImage n48;

	public const string URL = "ui://82mo10n51053d9y";

	public static string Name = "UI_RankNo6to10";

	public static string GetURL()
	{
		return "ui://82mo10n51053d9y";
	}

	public static UI_RankNo6to10 CreateInstance()
	{
		return (UI_RankNo6to10)(object)UIPackage.CreateObject("PvpSelectSoldiers", "RankNo6to10");
	}

	public static UI_RankNo6to10 CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_RankNo6to10).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://82mo10n51053d9y", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		//IL_0099: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a3: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		NoListBackground = (GImage)((GComponent)this).GetChild("NoListBackground");
		NoList = (GList)((GComponent)this).GetChild("NoList");
		n45 = (GImage)((GComponent)this).GetChild("n45");
		n44 = (GImage)((GComponent)this).GetChild("n44");
		n46 = (GImage)((GComponent)this).GetChild("n46");
		n47 = (GImage)((GComponent)this).GetChild("n47");
		n48 = (GImage)((GComponent)this).GetChild("n48");
	}
}
