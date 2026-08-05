using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.Plot;

public class UI_skip1 : GButton
{
	public Controller button;

	public GRichTextField title;

	public GImage n5;

	public const string URL = "ui://56axd6he8h2b2";

	public static string Name = "UI_skip1";

	public static string GetURL()
	{
		return "ui://56axd6he8h2b2";
	}

	public static UI_skip1 CreateInstance()
	{
		return (UI_skip1)(object)UIPackage.CreateObject("Plot", "skip1");
	}

	public static UI_skip1 CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_skip1).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://56axd6he8h2b2", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		string id = "ui://56axd6he8h2b2".Replace("ui://", "") + "-" + ((GObject)title).id;
		((GObject)title).text = LanguagesManager.GetDesc(id);
		n5 = (GImage)((GComponent)this).GetChild("n5");
	}
}
