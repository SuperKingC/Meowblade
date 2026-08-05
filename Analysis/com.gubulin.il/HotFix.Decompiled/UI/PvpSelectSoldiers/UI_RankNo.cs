using FairyGUI;
using FairyGUI.Utils;

namespace UI.PvpSelectSoldiers;

public class UI_RankNo : GComponent
{
	public GImage NoListBackground;

	public GList NoList;

	public GImage n43;

	public GImage n44;

	public GTextField StartIndex;

	public GTextField EndIndex;

	public GGroup n47;

	public const string URL = "ui://82mo10n5pmghdnk";

	public static string Name = "UI_RankNo";

	public static string GetURL()
	{
		return "ui://82mo10n5pmghdnk";
	}

	public static UI_RankNo CreateInstance()
	{
		return (UI_RankNo)(object)UIPackage.CreateObject("PvpSelectSoldiers", "RankNo");
	}

	public static UI_RankNo CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_RankNo).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://82mo10n5pmghdnk", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		n43 = (GImage)((GComponent)this).GetChild("n43");
		n44 = (GImage)((GComponent)this).GetChild("n44");
		StartIndex = (GTextField)((GComponent)this).GetChild("StartIndex");
		EndIndex = (GTextField)((GComponent)this).GetChild("EndIndex");
		n47 = (GGroup)((GComponent)this).GetChild("n47");
	}
}
