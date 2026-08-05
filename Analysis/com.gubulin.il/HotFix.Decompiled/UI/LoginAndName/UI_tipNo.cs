using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.LoginAndName;

public class UI_tipNo : GButton
{
	public Controller button;

	public GTextField title;

	public GImage mark;

	public const string URL = "ui://yb3s7uv7ryu8a";

	public static string Name = "UI_tipNo";

	public static string GetURL()
	{
		return "ui://yb3s7uv7ryu8a";
	}

	public static UI_tipNo CreateInstance()
	{
		return (UI_tipNo)(object)UIPackage.CreateObject("LoginAndName", "tipNo");
	}

	public static UI_tipNo CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_tipNo).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://yb3s7uv7ryu8a", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		string id = "ui://yb3s7uv7ryu8a".Replace("ui://", "") + "-" + ((GObject)title).id;
		((GObject)title).text = LanguagesManager.GetDesc(id);
		mark = (GImage)((GComponent)this).GetChild("mark");
	}
}
