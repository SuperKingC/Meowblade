using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGChat;

public class UI_btn_Close : GButton
{
	public GImage Close;

	public const string URL = "ui://e3rxkbapt0aw1u";

	public static string Name = "UI_btn_Close";

	public static string GetURL()
	{
		return "ui://e3rxkbapt0aw1u";
	}

	public static UI_btn_Close CreateInstance()
	{
		return (UI_btn_Close)(object)UIPackage.CreateObject("GvGChat", "btn_Close");
	}

	public static UI_btn_Close CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_btn_Close).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://e3rxkbapt0aw1u", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		Close = (GImage)((GComponent)this).GetChild("Close");
	}
}
