using FairyGUI;
using FairyGUI.Utils;

namespace UI.PvpSelectSoldiers;

public class UI_RankNo4or5 : GComponent
{
	public GImage NoListBackground;

	public GImage n30;

	public GList NoList;

	public GImage n28;

	public GImage n38;

	public GImage n39;

	public GGroup n41;

	public const string URL = "ui://82mo10n51053d9v";

	public static string Name = "UI_RankNo4or5";

	public static string GetURL()
	{
		return "ui://82mo10n51053d9v";
	}

	public static UI_RankNo4or5 CreateInstance()
	{
		return (UI_RankNo4or5)(object)UIPackage.CreateObject("PvpSelectSoldiers", "RankNo4or5");
	}

	public static UI_RankNo4or5 CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_RankNo4or5).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://82mo10n51053d9v", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		n30 = (GImage)((GComponent)this).GetChild("n30");
		NoList = (GList)((GComponent)this).GetChild("NoList");
		n28 = (GImage)((GComponent)this).GetChild("n28");
		n38 = (GImage)((GComponent)this).GetChild("n38");
		n39 = (GImage)((GComponent)this).GetChild("n39");
		n41 = (GGroup)((GComponent)this).GetChild("n41");
	}
}
