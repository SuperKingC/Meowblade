using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGChat;

public class UI_com_MessagePopUp : GComponent
{
	public GImage n2;

	public GImage n5;

	public GRichTextField Message;

	public GImage n1;

	public UI_btn_Close Close;

	public const string URL = "ui://e3rxkbaprb0j9";

	public static string Name = "UI_com_MessagePopUp";

	public static string GetURL()
	{
		return "ui://e3rxkbaprb0j9";
	}

	public static UI_com_MessagePopUp CreateInstance()
	{
		return (UI_com_MessagePopUp)(object)UIPackage.CreateObject("GvGChat", "com_MessagePopUp");
	}

	public static UI_com_MessagePopUp CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_MessagePopUp).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://e3rxkbaprb0j9", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		n2 = (GImage)((GComponent)this).GetChild("n2");
		n5 = (GImage)((GComponent)this).GetChild("n5");
		Message = (GRichTextField)((GComponent)this).GetChild("Message");
		n1 = (GImage)((GComponent)this).GetChild("n1");
		Close = (UI_btn_Close)(object)((GComponent)this).GetChild("Close");
	}
}
