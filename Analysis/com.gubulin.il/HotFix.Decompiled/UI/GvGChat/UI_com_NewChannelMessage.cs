using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGChat;

public class UI_com_NewChannelMessage : GComponent
{
	public UI_com_ChannelLastMessage LastMessage;

	public const string URL = "ui://e3rxkbapyfd38";

	public static string Name = "UI_com_NewChannelMessage";

	public static string GetURL()
	{
		return "ui://e3rxkbapyfd38";
	}

	public static UI_com_NewChannelMessage CreateInstance()
	{
		return (UI_com_NewChannelMessage)(object)UIPackage.CreateObject("GvGChat", "com_NewChannelMessage");
	}

	public static UI_com_NewChannelMessage CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_NewChannelMessage).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://e3rxkbapyfd38", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		((GComponent)this).ConstructFromXML(xml);
		LastMessage = (UI_com_ChannelLastMessage)(object)((GComponent)this).GetChild("LastMessage");
	}
}
