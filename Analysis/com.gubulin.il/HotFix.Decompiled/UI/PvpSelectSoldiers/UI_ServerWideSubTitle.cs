using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.PvpSelectSoldiers;

public class UI_ServerWideSubTitle : GButton
{
	public GImage n46;

	public GImage n43;

	public GImage n45;

	public GTextField title;

	public const string URL = "ui://82mo10n5exsyjdr5";

	public static string Name = "UI_ServerWideSubTitle";

	public static string GetURL()
	{
		return "ui://82mo10n5exsyjdr5";
	}

	public static UI_ServerWideSubTitle CreateInstance()
	{
		return (UI_ServerWideSubTitle)(object)UIPackage.CreateObject("PvpSelectSoldiers", "ServerWideSubTitle");
	}

	public static UI_ServerWideSubTitle CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_ServerWideSubTitle).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://82mo10n5exsyjdr5", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		n46 = (GImage)((GComponent)this).GetChild("n46");
		n43 = (GImage)((GComponent)this).GetChild("n43");
		n45 = (GImage)((GComponent)this).GetChild("n45");
		title = (GTextField)((GComponent)this).GetChild("title");
		string id = "ui://82mo10n5exsyjdr5".Replace("ui://", "") + "-" + ((GObject)title).id;
		((GObject)title).text = LanguagesManager.GetDesc(id);
	}
}
