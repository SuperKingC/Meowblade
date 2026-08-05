using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.PvpSelectSoldiers;

public class UI_RankTitle : GComponent
{
	public GTextField n17;

	public const string URL = "ui://82mo10n51053da1";

	public static string Name = "UI_RankTitle";

	public static string GetURL()
	{
		return "ui://82mo10n51053da1";
	}

	public static UI_RankTitle CreateInstance()
	{
		return (UI_RankTitle)(object)UIPackage.CreateObject("PvpSelectSoldiers", "RankTitle");
	}

	public static UI_RankTitle CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_RankTitle).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://82mo10n51053da1", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		n17 = (GTextField)((GComponent)this).GetChild("n17");
		string id = "ui://82mo10n51053da1".Replace("ui://", "") + "-" + ((GObject)n17).id;
		((GObject)n17).text = LanguagesManager.GetDesc(id);
	}
}
