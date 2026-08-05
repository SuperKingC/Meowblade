using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.SpecialActivity;

public class UI_com_MyInviteCode : GComponent
{
	public GImage b1;

	public GTextField n47;

	public GTextField InviteCode;

	public const string URL = "ui://kozswd8hbwf1f3y";

	public static string Name = "UI_com_MyInviteCode";

	public static string GetURL()
	{
		return "ui://kozswd8hbwf1f3y";
	}

	public static UI_com_MyInviteCode CreateInstance()
	{
		return (UI_com_MyInviteCode)(object)UIPackage.CreateObject("SpecialActivity", "com_MyInviteCode");
	}

	public static UI_com_MyInviteCode CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_MyInviteCode).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://kozswd8hbwf1f3y", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0035: Expected O, but got Unknown
		//IL_007e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0088: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		b1 = (GImage)((GComponent)this).GetChild("b1");
		n47 = (GTextField)((GComponent)this).GetChild("n47");
		string id = "ui://kozswd8hbwf1f3y".Replace("ui://", "") + "-" + ((GObject)n47).id;
		((GObject)n47).text = LanguagesManager.GetDesc(id);
		InviteCode = (GTextField)((GComponent)this).GetChild("InviteCode");
	}
}
