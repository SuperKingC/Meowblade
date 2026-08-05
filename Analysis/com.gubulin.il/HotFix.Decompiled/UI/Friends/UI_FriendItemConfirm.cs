using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.Friends;

public class UI_FriendItemConfirm : GComponent
{
	public GGraph n15;

	public UI_InvitationIcon IconBtn;

	public GImage n2;

	public GTextField level;

	public GTextField name;

	public GImage n5;

	public GTextField BattlePower;

	public GGraph n16;

	public GGraph n17;

	public UI_CancelBtn CancelBtn;

	public UI_ConfirmBtn ConfirmBtn;

	public const string URL = "ui://3rz8gv6cqtr6w";

	public static string Name = "UI_FriendItemConfirm";

	public static string GetURL()
	{
		return "ui://3rz8gv6cqtr6w";
	}

	public static UI_FriendItemConfirm CreateInstance()
	{
		return (UI_FriendItemConfirm)(object)UIPackage.CreateObject("Friends", "FriendItemConfirm");
	}

	public static UI_FriendItemConfirm CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_FriendItemConfirm).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://3rz8gv6cqtr6w", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		//IL_0041: Unknown result type (might be due to invalid IL or missing references)
		//IL_004b: Expected O, but got Unknown
		//IL_0057: Unknown result type (might be due to invalid IL or missing references)
		//IL_0061: Expected O, but got Unknown
		//IL_00aa: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b4: Expected O, but got Unknown
		//IL_00fd: Unknown result type (might be due to invalid IL or missing references)
		//IL_0107: Expected O, but got Unknown
		//IL_0113: Unknown result type (might be due to invalid IL or missing references)
		//IL_011d: Expected O, but got Unknown
		//IL_0166: Unknown result type (might be due to invalid IL or missing references)
		//IL_0170: Expected O, but got Unknown
		//IL_017c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0186: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		n15 = (GGraph)((GComponent)this).GetChild("n15");
		IconBtn = (UI_InvitationIcon)(object)((GComponent)this).GetChild("IconBtn");
		n2 = (GImage)((GComponent)this).GetChild("n2");
		level = (GTextField)((GComponent)this).GetChild("level");
		string id = "ui://3rz8gv6cqtr6w".Replace("ui://", "") + "-" + ((GObject)level).id;
		((GObject)level).text = LanguagesManager.GetDesc(id);
		name = (GTextField)((GComponent)this).GetChild("name");
		string id2 = "ui://3rz8gv6cqtr6w".Replace("ui://", "") + "-" + ((GObject)name).id;
		((GObject)name).text = LanguagesManager.GetDesc(id2);
		n5 = (GImage)((GComponent)this).GetChild("n5");
		BattlePower = (GTextField)((GComponent)this).GetChild("BattlePower");
		string id3 = "ui://3rz8gv6cqtr6w".Replace("ui://", "") + "-" + ((GObject)BattlePower).id;
		((GObject)BattlePower).text = LanguagesManager.GetDesc(id3);
		n16 = (GGraph)((GComponent)this).GetChild("n16");
		n17 = (GGraph)((GComponent)this).GetChild("n17");
		CancelBtn = (UI_CancelBtn)(object)((GComponent)this).GetChild("CancelBtn");
		ConfirmBtn = (UI_ConfirmBtn)(object)((GComponent)this).GetChild("ConfirmBtn");
	}
}
