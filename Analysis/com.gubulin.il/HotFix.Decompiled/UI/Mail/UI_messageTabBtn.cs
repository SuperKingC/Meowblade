using FairyGUI;
using FairyGUI.Utils;

namespace UI.Mail;

public class UI_messageTabBtn : GButton
{
	public Controller button;

	public GGraph n0;

	public GImage n3;

	public GImage note;

	public GLoader icon;

	public const string URL = "ui://edr57v33tjql3n";

	public static string Name = "UI_messageTabBtn";

	public static string GetURL()
	{
		return "ui://edr57v33tjql3n";
	}

	public static UI_messageTabBtn CreateInstance()
	{
		return (UI_messageTabBtn)(object)UIPackage.CreateObject("Mail", "messageTabBtn");
	}

	public static UI_messageTabBtn CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_messageTabBtn).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://edr57v33tjql3n", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		((GComponent)this).ConstructFromXML(xml);
		button = ((GComponent)this).GetController("button");
		n0 = (GGraph)((GComponent)this).GetChild("n0");
		n3 = (GImage)((GComponent)this).GetChild("n3");
		note = (GImage)((GComponent)this).GetChild("note");
		icon = (GLoader)((GComponent)this).GetChild("icon");
	}
}
