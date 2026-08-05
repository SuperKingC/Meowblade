using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGBrawlFight;

public class UI_btn_03 : GButton
{
	public GImage n61;

	public GImage n62;

	public GTextField n63;

	public const string URL = "ui://hozu168riwm75e";

	public static string Name = "UI_btn_03";

	public static string GetURL()
	{
		return "ui://hozu168riwm75e";
	}

	public static UI_btn_03 CreateInstance()
	{
		return (UI_btn_03)(object)UIPackage.CreateObject("GvGBrawlFight", "btn_03");
	}

	public static UI_btn_03 CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_btn_03).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://hozu168riwm75e", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		((GComponent)this).ConstructFromXML(xml);
		n61 = (GImage)((GComponent)this).GetChild("n61");
		n62 = (GImage)((GComponent)this).GetChild("n62");
		n63 = (GTextField)((GComponent)this).GetChild("n63");
		string id = "ui://hozu168riwm75e".Replace("ui://", "") + "-" + ((GObject)n63).id;
		((GObject)n63).text = LanguagesManager.GetDesc(id);
	}
}
