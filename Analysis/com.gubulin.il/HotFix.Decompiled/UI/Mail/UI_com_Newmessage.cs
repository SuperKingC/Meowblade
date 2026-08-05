using FairyGUI;
using FairyGUI.Utils;

namespace UI.Mail;

public class UI_com_Newmessage : GComponent
{
	public GImage newMessage;

	public GImage n113;

	public GImage n114;

	public GImage n115;

	public const string URL = "ui://edr57v33tjql3f";

	public static string Name = "UI_com_Newmessage";

	public static string GetURL()
	{
		return "ui://edr57v33tjql3f";
	}

	public static UI_com_Newmessage CreateInstance()
	{
		return (UI_com_Newmessage)(object)UIPackage.CreateObject("Mail", "com_Newmessage");
	}

	public static UI_com_Newmessage CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_Newmessage).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://edr57v33tjql3f", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		newMessage = (GImage)((GComponent)this).GetChild("newMessage");
		n113 = (GImage)((GComponent)this).GetChild("n113");
		n114 = (GImage)((GComponent)this).GetChild("n114");
		n115 = (GImage)((GComponent)this).GetChild("n115");
	}
}
