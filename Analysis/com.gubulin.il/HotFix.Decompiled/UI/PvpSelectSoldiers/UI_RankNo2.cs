using FairyGUI;
using FairyGUI.Utils;

namespace UI.PvpSelectSoldiers;

public class UI_RankNo2 : GComponent
{
	public GImage n20;

	public GImage n16;

	public GImage n18;

	public GList NoList;

	public const string URL = "ui://82mo10n51053d9r";

	public static string Name = "UI_RankNo2";

	public static string GetURL()
	{
		return "ui://82mo10n51053d9r";
	}

	public static UI_RankNo2 CreateInstance()
	{
		return (UI_RankNo2)(object)UIPackage.CreateObject("PvpSelectSoldiers", "RankNo2");
	}

	public static UI_RankNo2 CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_RankNo2).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://82mo10n51053d9r", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		n20 = (GImage)((GComponent)this).GetChild("n20");
		n16 = (GImage)((GComponent)this).GetChild("n16");
		n18 = (GImage)((GComponent)this).GetChild("n18");
		NoList = (GList)((GComponent)this).GetChild("NoList");
	}
}
