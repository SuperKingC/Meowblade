using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.Friends;

public class UI_FriendItem : GComponent
{
	public Controller RecycleCenterStatus;

	public GGraph n12;

	public UI_InvitationIcon IconBtn;

	public GImage n2;

	public GTextField level;

	public GTextField name;

	public GImage n5;

	public GTextField BattlePower;

	public GImage n10;

	public GTextField LastLoginAt;

	public UI_deleteBtn DeleteBtn;

	public GList Medals;

	public UI_startMessage StartMessage;

	public GTextField n16;

	public const string URL = "ui://3rz8gv6cc3w32";

	public static string Name = "UI_FriendItem";

	public static string GetURL()
	{
		return "ui://3rz8gv6cc3w32";
	}

	public static UI_FriendItem CreateInstance()
	{
		return (UI_FriendItem)(object)UIPackage.CreateObject("Friends", "FriendItem");
	}

	public static UI_FriendItem CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_FriendItem).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://3rz8gv6cc3w32", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Expected O, but got Unknown
		//IL_0052: Unknown result type (might be due to invalid IL or missing references)
		//IL_005c: Expected O, but got Unknown
		//IL_0068: Unknown result type (might be due to invalid IL or missing references)
		//IL_0072: Expected O, but got Unknown
		//IL_00bb: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c5: Expected O, but got Unknown
		//IL_010e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0118: Expected O, but got Unknown
		//IL_0124: Unknown result type (might be due to invalid IL or missing references)
		//IL_012e: Expected O, but got Unknown
		//IL_0177: Unknown result type (might be due to invalid IL or missing references)
		//IL_0181: Expected O, but got Unknown
		//IL_018d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0197: Expected O, but got Unknown
		//IL_01f6: Unknown result type (might be due to invalid IL or missing references)
		//IL_0200: Expected O, but got Unknown
		//IL_0222: Unknown result type (might be due to invalid IL or missing references)
		//IL_022c: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		RecycleCenterStatus = ((GComponent)this).GetController("RecycleCenterStatus");
		n12 = (GGraph)((GComponent)this).GetChild("n12");
		IconBtn = (UI_InvitationIcon)(object)((GComponent)this).GetChild("IconBtn");
		n2 = (GImage)((GComponent)this).GetChild("n2");
		level = (GTextField)((GComponent)this).GetChild("level");
		string id = "ui://3rz8gv6cc3w32".Replace("ui://", "") + "-" + ((GObject)level).id;
		((GObject)level).text = LanguagesManager.GetDesc(id);
		name = (GTextField)((GComponent)this).GetChild("name");
		string id2 = "ui://3rz8gv6cc3w32".Replace("ui://", "") + "-" + ((GObject)name).id;
		((GObject)name).text = LanguagesManager.GetDesc(id2);
		n5 = (GImage)((GComponent)this).GetChild("n5");
		BattlePower = (GTextField)((GComponent)this).GetChild("BattlePower");
		string id3 = "ui://3rz8gv6cc3w32".Replace("ui://", "") + "-" + ((GObject)BattlePower).id;
		((GObject)BattlePower).text = LanguagesManager.GetDesc(id3);
		n10 = (GImage)((GComponent)this).GetChild("n10");
		LastLoginAt = (GTextField)((GComponent)this).GetChild("LastLoginAt");
		string id4 = "ui://3rz8gv6cc3w32".Replace("ui://", "") + "-" + ((GObject)LastLoginAt).id;
		((GObject)LastLoginAt).text = LanguagesManager.GetDesc(id4);
		DeleteBtn = (UI_deleteBtn)(object)((GComponent)this).GetChild("DeleteBtn");
		Medals = (GList)((GComponent)this).GetChild("Medals");
		StartMessage = (UI_startMessage)(object)((GComponent)this).GetChild("StartMessage");
		n16 = (GTextField)((GComponent)this).GetChild("n16");
		string id5 = "ui://3rz8gv6cc3w32".Replace("ui://", "") + "-" + ((GObject)n16).id;
		((GObject)n16).text = LanguagesManager.GetDesc(id5);
	}
}
