using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.PvpSelectSoldiers;

public class UI_PointTitle : GComponent
{
	public GTextField n42;

	public const string URL = "ui://82mo10n51053da2";

	public static string Name = "UI_PointTitle";

	public static string GetURL()
	{
		return "ui://82mo10n51053da2";
	}

	public static UI_PointTitle CreateInstance()
	{
		return (UI_PointTitle)(object)UIPackage.CreateObject("PvpSelectSoldiers", "PointTitle");
	}

	public static UI_PointTitle CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_PointTitle).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://82mo10n51053da2", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		n42 = (GTextField)((GComponent)this).GetChild("n42");
		string id = "ui://82mo10n51053da2".Replace("ui://", "") + "-" + ((GObject)n42).id;
		((GObject)n42).text = LanguagesManager.GetDesc(id);
	}
}
