using FairyGUI;
using FairyGUI.Utils;

namespace UI.PvpSelectSoldiers;

public class UI_UserHPbar : GProgressBar
{
	public GImage bar;

	public GImage n4;

	public const string URL = "ui://82mo10n5c3gbdcp";

	public static string Name = "UI_UserHPbar";

	public static string GetURL()
	{
		return "ui://82mo10n5c3gbdcp";
	}

	public static UI_UserHPbar CreateInstance()
	{
		return (UI_UserHPbar)(object)UIPackage.CreateObject("PvpSelectSoldiers", "UserHPbar");
	}

	public static UI_UserHPbar CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_UserHPbar).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://82mo10n5c3gbdcp", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0035: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		bar = (GImage)((GComponent)this).GetChild("bar");
		n4 = (GImage)((GComponent)this).GetChild("n4");
	}
}
