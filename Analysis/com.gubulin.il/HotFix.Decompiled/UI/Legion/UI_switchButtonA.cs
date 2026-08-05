using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.Legion;

public class UI_switchButtonA : GButton
{
	public Controller button;

	public GTextField title;

	public GImage note;

	public const string URL = "ui://lrhs6zw7l9gzf";

	public static string Name = "UI_switchButtonA";

	public static string GetURL()
	{
		return "ui://lrhs6zw7l9gzf";
	}

	public static UI_switchButtonA CreateInstance()
	{
		return (UI_switchButtonA)(object)UIPackage.CreateObject("Legion", "switchButtonA");
	}

	public static UI_switchButtonA CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_switchButtonA).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://lrhs6zw7l9gzf", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		title = (GTextField)((GComponent)this).GetChild("title");
		string id = "ui://lrhs6zw7l9gzf".Replace("ui://", "") + "-" + ((GObject)title).id;
		((GObject)title).text = LanguagesManager.GetDesc(id);
		note = (GImage)((GComponent)this).GetChild("note");
	}
}
