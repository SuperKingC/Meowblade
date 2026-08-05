using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.PushGiftBag;

public class UI_Title : GComponent
{
	public GTextField title1;

	public GTextField title2;

	public GGroup n9;

	public const string URL = "ui://ume49e0adecwc";

	public static string Name = "UI_Title";

	public static string GetURL()
	{
		return "ui://ume49e0adecwc";
	}

	public static UI_Title CreateInstance()
	{
		return (UI_Title)(object)UIPackage.CreateObject("PushGiftBag", "Title");
	}

	public static UI_Title CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_Title).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://ume49e0adecwc", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		//IL_0068: Unknown result type (might be due to invalid IL or missing references)
		//IL_0072: Expected O, but got Unknown
		//IL_00bb: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c5: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		title1 = (GTextField)((GComponent)this).GetChild("title1");
		string id = "ui://ume49e0adecwc".Replace("ui://", "") + "-" + ((GObject)title1).id;
		((GObject)title1).text = LanguagesManager.GetDesc(id);
		title2 = (GTextField)((GComponent)this).GetChild("title2");
		string id2 = "ui://ume49e0adecwc".Replace("ui://", "") + "-" + ((GObject)title2).id;
		((GObject)title2).text = LanguagesManager.GetDesc(id2);
		n9 = (GGroup)((GComponent)this).GetChild("n9");
	}
}
