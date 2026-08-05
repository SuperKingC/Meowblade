using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGOnIsland3;

public class UI_com_GVGTip_Damageinfo : GComponent
{
	public GTextField Content;

	public GImage n1;

	public const string URL = "ui://ebc4ciwrpwqhq5s";

	public static string Name = "UI_com_GVGTip_Damageinfo";

	public static string GetURL()
	{
		return "ui://ebc4ciwrpwqhq5s";
	}

	public static UI_com_GVGTip_Damageinfo CreateInstance()
	{
		return (UI_com_GVGTip_Damageinfo)(object)UIPackage.CreateObject("GvGOnIsland3", "com_GVGTip_Damageinfo");
	}

	public static UI_com_GVGTip_Damageinfo CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_GVGTip_Damageinfo).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://ebc4ciwrpwqhq5s", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		//IL_0068: Unknown result type (might be due to invalid IL or missing references)
		//IL_0072: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		Content = (GTextField)((GComponent)this).GetChild("Content");
		string id = "ui://ebc4ciwrpwqhq5s".Replace("ui://", "") + "-" + ((GObject)Content).id;
		((GObject)Content).text = LanguagesManager.GetDesc(id);
		n1 = (GImage)((GComponent)this).GetChild("n1");
	}
}
