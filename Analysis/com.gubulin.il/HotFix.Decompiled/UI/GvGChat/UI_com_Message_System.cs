using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGChat;

public class UI_com_Message_System : GComponent
{
	public GImage n0;

	public GRichTextField Message;

	public GImage n2;

	public GTextField Time;

	public const string URL = "ui://e3rxkbaprb0je";

	public static string Name = "UI_com_Message_System";

	public static string GetURL()
	{
		return "ui://e3rxkbaprb0je";
	}

	public static UI_com_Message_System CreateInstance()
	{
		return (UI_com_Message_System)(object)UIPackage.CreateObject("GvGChat", "com_Message_System");
	}

	public static UI_com_Message_System CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_Message_System).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://e3rxkbaprb0je", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0035: Expected O, but got Unknown
		//IL_0041: Unknown result type (might be due to invalid IL or missing references)
		//IL_004b: Expected O, but got Unknown
		//IL_0057: Unknown result type (might be due to invalid IL or missing references)
		//IL_0061: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		n0 = (GImage)((GComponent)this).GetChild("n0");
		Message = (GRichTextField)((GComponent)this).GetChild("Message");
		n2 = (GImage)((GComponent)this).GetChild("n2");
		Time = (GTextField)((GComponent)this).GetChild("Time");
	}
}
