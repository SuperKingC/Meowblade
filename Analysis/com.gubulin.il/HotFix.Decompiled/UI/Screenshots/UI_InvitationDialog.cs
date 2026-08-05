using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.Screenshots;

public class UI_InvitationDialog : GComponent
{
	public GImage back;

	public GImage n11;

	public GLoader icon;

	public GTextField name;

	public GGroup n9;

	public GTextField InviteCode;

	public GGroup n10;

	public GLoader code;

	public GTextField qrCodeTitle;

	public GTextField codeTitle;

	public const string URL = "ui://pzmiqysmldgh2";

	public static string Name = "UI_InvitationDialog";

	public static string GetURL()
	{
		return "ui://pzmiqysmldgh2";
	}

	public static UI_InvitationDialog CreateInstance()
	{
		return (UI_InvitationDialog)(object)UIPackage.CreateObject("Screenshots", "InvitationDialog");
	}

	public static UI_InvitationDialog CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_InvitationDialog).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://pzmiqysmldgh2", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		//IL_006d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0077: Expected O, but got Unknown
		//IL_0083: Unknown result type (might be due to invalid IL or missing references)
		//IL_008d: Expected O, but got Unknown
		//IL_0099: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a3: Expected O, but got Unknown
		//IL_00af: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b9: Expected O, but got Unknown
		//IL_00c5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00cf: Expected O, but got Unknown
		//IL_0118: Unknown result type (might be due to invalid IL or missing references)
		//IL_0122: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		back = (GImage)((GComponent)this).GetChild("back");
		n11 = (GImage)((GComponent)this).GetChild("n11");
		icon = (GLoader)((GComponent)this).GetChild("icon");
		name = (GTextField)((GComponent)this).GetChild("name");
		n9 = (GGroup)((GComponent)this).GetChild("n9");
		InviteCode = (GTextField)((GComponent)this).GetChild("InviteCode");
		n10 = (GGroup)((GComponent)this).GetChild("n10");
		code = (GLoader)((GComponent)this).GetChild("code");
		qrCodeTitle = (GTextField)((GComponent)this).GetChild("qrCodeTitle");
		string id = "ui://pzmiqysmldgh2".Replace("ui://", "") + "-" + ((GObject)qrCodeTitle).id;
		((GObject)qrCodeTitle).text = LanguagesManager.GetDesc(id);
		codeTitle = (GTextField)((GComponent)this).GetChild("codeTitle");
		string id2 = "ui://pzmiqysmldgh2".Replace("ui://", "") + "-" + ((GObject)codeTitle).id;
		((GObject)codeTitle).text = LanguagesManager.GetDesc(id2);
	}
}
