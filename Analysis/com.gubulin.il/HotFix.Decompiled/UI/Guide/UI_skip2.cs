using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.Guide;

public class UI_skip2 : GButton
{
	public Controller button;

	public GRichTextField title;

	public GImage n5;

	public const string URL = "ui://5vxjvcrbqy8o7";

	public static string Name = "UI_skip2";

	public static string GetURL()
	{
		return "ui://5vxjvcrbqy8o7";
	}

	public static UI_skip2 CreateInstance()
	{
		return (UI_skip2)(object)UIPackage.CreateObject("Guide", "skip2");
	}

	public static UI_skip2 CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_skip2).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://5vxjvcrbqy8o7", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Expected O, but got Unknown
		//IL_0079: Unknown result type (might be due to invalid IL or missing references)
		//IL_0083: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		button = ((GComponent)this).GetController("button");
		title = (GRichTextField)((GComponent)this).GetChild("title");
		string id = "ui://5vxjvcrbqy8o7".Replace("ui://", "") + "-" + ((GObject)title).id;
		((GObject)title).text = LanguagesManager.GetDesc(id);
		n5 = (GImage)((GComponent)this).GetChild("n5");
	}
}
