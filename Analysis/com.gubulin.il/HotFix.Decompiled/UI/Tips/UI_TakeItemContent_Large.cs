using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.Tips;

public class UI_TakeItemContent_Large : GComponent
{
	public GLoader icon;

	public GTextField num;

	public const string URL = "ui://47lbpgx9vur65e";

	public static string Name = "UI_TakeItemContent_Large";

	public static string GetURL()
	{
		return "ui://47lbpgx9vur65e";
	}

	public static UI_TakeItemContent_Large CreateInstance()
	{
		return (UI_TakeItemContent_Large)(object)UIPackage.CreateObject("Tips", "TakeItemContent_Large");
	}

	public static UI_TakeItemContent_Large CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_TakeItemContent_Large).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://47lbpgx9vur65e", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0035: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		icon = (GLoader)((GComponent)this).GetChild("icon");
		num = (GTextField)((GComponent)this).GetChild("num");
		string id = "ui://47lbpgx9vur65e".Replace("ui://", "") + "-" + ((GObject)num).id;
		((GObject)num).text = LanguagesManager.GetDesc(id);
	}
}
