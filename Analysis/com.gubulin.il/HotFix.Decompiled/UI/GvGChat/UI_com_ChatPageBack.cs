using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGChat;

public class UI_com_ChatPageBack : GComponent
{
	public GImage n10;

	public const string URL = "ui://e3rxkbapm9d724";

	public static string Name = "UI_com_ChatPageBack";

	public static string GetURL()
	{
		return "ui://e3rxkbapm9d724";
	}

	public static UI_com_ChatPageBack CreateInstance()
	{
		return (UI_com_ChatPageBack)(object)UIPackage.CreateObject("GvGChat", "com_ChatPageBack");
	}

	public static UI_com_ChatPageBack CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_ChatPageBack).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://e3rxkbapm9d724", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		n10 = (GImage)((GComponent)this).GetChild("n10");
	}
}
