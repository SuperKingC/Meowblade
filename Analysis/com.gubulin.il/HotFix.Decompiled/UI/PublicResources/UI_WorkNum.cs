using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.PublicResources;

public class UI_WorkNum : GButton
{
	public Controller button;

	public GTextField title;

	public GMovieClip n8;

	public const string URL = "ui://kt6rg65owj3dtgd";

	public static string Name = "UI_WorkNum";

	public static string GetURL()
	{
		return "ui://kt6rg65owj3dtgd";
	}

	public static UI_WorkNum CreateInstance()
	{
		return (UI_WorkNum)(object)UIPackage.CreateObject("PublicResources", "WorkNum");
	}

	public static UI_WorkNum CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_WorkNum).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://kt6rg65owj3dtgd", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		string id = "ui://kt6rg65owj3dtgd".Replace("ui://", "") + "-" + ((GObject)title).id;
		((GObject)title).text = LanguagesManager.GetDesc(id);
		n8 = (GMovieClip)((GComponent)this).GetChild("n8");
	}
}
