using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.LordOfDreams;

public class UI_GVGTip_Damageinfo : GComponent
{
	public GTextField Content;

	public GImage n1;

	public const string URL = "ui://0i520nzmmmjvocg";

	public static string Name = "UI_GVGTip_Damageinfo";

	public static string GetURL()
	{
		return "ui://0i520nzmmmjvocg";
	}

	public static UI_GVGTip_Damageinfo CreateInstance()
	{
		return (UI_GVGTip_Damageinfo)(object)UIPackage.CreateObject("LordOfDreams", "GVGTip_Damageinfo");
	}

	public static UI_GVGTip_Damageinfo CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_GVGTip_Damageinfo).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://0i520nzmmmjvocg", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		string id = "ui://0i520nzmmmjvocg".Replace("ui://", "") + "-" + ((GObject)Content).id;
		((GObject)Content).text = LanguagesManager.GetDesc(id);
		n1 = (GImage)((GComponent)this).GetChild("n1");
	}
}
