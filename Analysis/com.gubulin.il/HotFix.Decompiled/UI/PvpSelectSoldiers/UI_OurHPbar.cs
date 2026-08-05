using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.PvpSelectSoldiers;

public class UI_OurHPbar : GProgressBar
{
	public GImage bar;

	public GTextField name;

	public const string URL = "ui://82mo10n5jh34dbc";

	public static string Name = "UI_OurHPbar";

	public static string GetURL()
	{
		return "ui://82mo10n5jh34dbc";
	}

	public static UI_OurHPbar CreateInstance()
	{
		return (UI_OurHPbar)(object)UIPackage.CreateObject("PvpSelectSoldiers", "OurHPbar");
	}

	public static UI_OurHPbar CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_OurHPbar).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://82mo10n5jh34dbc", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		name = (GTextField)((GComponent)this).GetChild("name");
		string id = "ui://82mo10n5jh34dbc".Replace("ui://", "") + "-" + ((GObject)name).id;
		((GObject)name).text = LanguagesManager.GetDesc(id);
	}
}
