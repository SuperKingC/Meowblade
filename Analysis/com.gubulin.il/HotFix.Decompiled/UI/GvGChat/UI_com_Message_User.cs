using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGChat;

public class UI_com_Message_User : GComponent
{
	public Controller Camp;

	public GImage n0;

	public GRichTextField Message;

	public GLoader CampIcon;

	public GTextField Time;

	public GComponent ProfileDisplay;

	public const string URL = "ui://e3rxkbaprb0jk";

	public static string Name = "UI_com_Message_User";

	public static string GetURL()
	{
		return "ui://e3rxkbaprb0jk";
	}

	public static UI_com_Message_User CreateInstance()
	{
		return (UI_com_Message_User)(object)UIPackage.CreateObject("GvGChat", "com_Message_User");
	}

	public static UI_com_Message_User CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_Message_User).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://e3rxkbaprb0jk", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Expected O, but got Unknown
		//IL_003c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0046: Expected O, but got Unknown
		//IL_0052: Unknown result type (might be due to invalid IL or missing references)
		//IL_005c: Expected O, but got Unknown
		//IL_0068: Unknown result type (might be due to invalid IL or missing references)
		//IL_0072: Expected O, but got Unknown
		//IL_007e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0088: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		Camp = ((GComponent)this).GetController("Camp");
		n0 = (GImage)((GComponent)this).GetChild("n0");
		Message = (GRichTextField)((GComponent)this).GetChild("Message");
		CampIcon = (GLoader)((GComponent)this).GetChild("CampIcon");
		Time = (GTextField)((GComponent)this).GetChild("Time");
		ProfileDisplay = (GComponent)((GComponent)this).GetChild("ProfileDisplay");
	}
}
