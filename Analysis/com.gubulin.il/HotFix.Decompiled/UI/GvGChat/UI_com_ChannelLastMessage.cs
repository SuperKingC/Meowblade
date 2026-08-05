using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGChat;

public class UI_com_ChannelLastMessage : GComponent
{
	public GRichTextField Message;

	public UI_com_ChannelIcon ChannelIcon;

	public const string URL = "ui://e3rxkbapf0oi23";

	public static string Name = "UI_com_ChannelLastMessage";

	public static string GetURL()
	{
		return "ui://e3rxkbapf0oi23";
	}

	public static UI_com_ChannelLastMessage CreateInstance()
	{
		return (UI_com_ChannelLastMessage)(object)UIPackage.CreateObject("GvGChat", "com_ChannelLastMessage");
	}

	public static UI_com_ChannelLastMessage CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_ChannelLastMessage).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://e3rxkbapf0oi23", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		Message = (GRichTextField)((GComponent)this).GetChild("Message");
		ChannelIcon = (UI_com_ChannelIcon)(object)((GComponent)this).GetChild("ChannelIcon");
	}
}
