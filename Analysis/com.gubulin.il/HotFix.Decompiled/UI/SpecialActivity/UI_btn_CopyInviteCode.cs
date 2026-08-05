using FairyGUI;
using FairyGUI.Utils;

namespace UI.SpecialActivity;

public class UI_btn_CopyInviteCode : GButton
{
	public Controller button;

	public GImage n13;

	public GImage n15;

	public const string URL = "ui://kozswd8hhbr0f3v";

	public static string Name = "UI_btn_CopyInviteCode";

	public static string GetURL()
	{
		return "ui://kozswd8hhbr0f3v";
	}

	public static UI_btn_CopyInviteCode CreateInstance()
	{
		return (UI_btn_CopyInviteCode)(object)UIPackage.CreateObject("SpecialActivity", "btn_CopyInviteCode");
	}

	public static UI_btn_CopyInviteCode CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_btn_CopyInviteCode).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://kozswd8hhbr0f3v", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Expected O, but got Unknown
		//IL_003c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0046: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		button = ((GComponent)this).GetController("button");
		n13 = (GImage)((GComponent)this).GetChild("n13");
		n15 = (GImage)((GComponent)this).GetChild("n15");
	}
}
