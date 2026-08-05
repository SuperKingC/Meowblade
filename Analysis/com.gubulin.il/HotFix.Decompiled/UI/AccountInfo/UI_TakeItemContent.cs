using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.AccountInfo;

public class UI_TakeItemContent : GComponent
{
	public GLoader icon;

	public GTextField num;

	public const string URL = "ui://b9yxt7u0t1jrk";

	public static string Name = "UI_TakeItemContent";

	public static string GetURL()
	{
		return "ui://b9yxt7u0t1jrk";
	}

	public static UI_TakeItemContent CreateInstance()
	{
		return (UI_TakeItemContent)(object)UIPackage.CreateObject("AccountInfo", "TakeItemContent");
	}

	public static UI_TakeItemContent CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_TakeItemContent).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://b9yxt7u0t1jrk", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		string id = "ui://b9yxt7u0t1jrk".Replace("ui://", "") + "-" + ((GObject)num).id;
		((GObject)num).text = LanguagesManager.GetDesc(id);
	}
}
