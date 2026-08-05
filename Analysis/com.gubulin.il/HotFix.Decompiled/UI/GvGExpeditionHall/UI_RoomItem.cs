using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGExpeditionHall;

public class UI_RoomItem : GButton
{
	public Controller button;

	public Controller IsRoomFull;

	public Controller SignInState;

	public GImage n47;

	public GImage n54;

	public GImage n68;

	public GImage n67;

	public GTextField n49;

	public GTextField UserCount;

	public GTextField n52;

	public GTextField StartTime;

	public GTextField n64;

	public GTextField n57;

	public GTextField n63;

	public GTextField n66;

	public GTextField StateTime;

	public GImage n70;

	public UI_btn_SignInBtn SignInBtn;

	public GImage n65;

	public GTextField RoomName;

	public GImage n71;

	public const string URL = "ui://k19peou7dnvl2z";

	public static string Name = "UI_RoomItem";

	public static string GetURL()
	{
		return "ui://k19peou7dnvl2z";
	}

	public static UI_RoomItem CreateInstance()
	{
		return (UI_RoomItem)(object)UIPackage.CreateObject("GvGExpeditionHall", "RoomItem");
	}

	public static UI_RoomItem CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_RoomItem).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://k19peou7dnvl2z", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0048: Unknown result type (might be due to invalid IL or missing references)
		//IL_0052: Expected O, but got Unknown
		//IL_005e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0068: Expected O, but got Unknown
		//IL_0074: Unknown result type (might be due to invalid IL or missing references)
		//IL_007e: Expected O, but got Unknown
		//IL_008a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0094: Expected O, but got Unknown
		//IL_00a0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00aa: Expected O, but got Unknown
		//IL_00f3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fd: Expected O, but got Unknown
		//IL_0109: Unknown result type (might be due to invalid IL or missing references)
		//IL_0113: Expected O, but got Unknown
		//IL_015c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0166: Expected O, but got Unknown
		//IL_0172: Unknown result type (might be due to invalid IL or missing references)
		//IL_017c: Expected O, but got Unknown
		//IL_01c5: Unknown result type (might be due to invalid IL or missing references)
		//IL_01cf: Expected O, but got Unknown
		//IL_0218: Unknown result type (might be due to invalid IL or missing references)
		//IL_0222: Expected O, but got Unknown
		//IL_026d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0277: Expected O, but got Unknown
		//IL_02c2: Unknown result type (might be due to invalid IL or missing references)
		//IL_02cc: Expected O, but got Unknown
		//IL_02d8: Unknown result type (might be due to invalid IL or missing references)
		//IL_02e2: Expected O, but got Unknown
		//IL_0304: Unknown result type (might be due to invalid IL or missing references)
		//IL_030e: Expected O, but got Unknown
		//IL_031a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0324: Expected O, but got Unknown
		//IL_0330: Unknown result type (might be due to invalid IL or missing references)
		//IL_033a: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		button = ((GComponent)this).GetController("button");
		IsRoomFull = ((GComponent)this).GetController("IsRoomFull");
		SignInState = ((GComponent)this).GetController("SignInState");
		n47 = (GImage)((GComponent)this).GetChild("n47");
		n54 = (GImage)((GComponent)this).GetChild("n54");
		n68 = (GImage)((GComponent)this).GetChild("n68");
		n67 = (GImage)((GComponent)this).GetChild("n67");
		n49 = (GTextField)((GComponent)this).GetChild("n49");
		string id = "ui://k19peou7dnvl2z".Replace("ui://", "") + "-" + ((GObject)n49).id;
		((GObject)n49).text = LanguagesManager.GetDesc(id);
		UserCount = (GTextField)((GComponent)this).GetChild("UserCount");
		n52 = (GTextField)((GComponent)this).GetChild("n52");
		string id2 = "ui://k19peou7dnvl2z".Replace("ui://", "") + "-" + ((GObject)n52).id;
		((GObject)n52).text = LanguagesManager.GetDesc(id2);
		StartTime = (GTextField)((GComponent)this).GetChild("StartTime");
		n64 = (GTextField)((GComponent)this).GetChild("n64");
		string id3 = "ui://k19peou7dnvl2z".Replace("ui://", "") + "-" + ((GObject)n64).id;
		((GObject)n64).text = LanguagesManager.GetDesc(id3);
		n57 = (GTextField)((GComponent)this).GetChild("n57");
		string id4 = "ui://k19peou7dnvl2z".Replace("ui://", "") + "-" + ((GObject)n57).id;
		((GObject)n57).text = LanguagesManager.GetDesc(id4);
		n63 = (GTextField)((GComponent)this).GetChild("n63");
		string id5 = "ui://k19peou7dnvl2z".Replace("ui://", "") + "-" + ((GObject)n63).id;
		((GObject)n63).text = LanguagesManager.GetDesc(id5);
		n66 = (GTextField)((GComponent)this).GetChild("n66");
		string id6 = "ui://k19peou7dnvl2z".Replace("ui://", "") + "-" + ((GObject)n66).id;
		((GObject)n66).text = LanguagesManager.GetDesc(id6);
		StateTime = (GTextField)((GComponent)this).GetChild("StateTime");
		n70 = (GImage)((GComponent)this).GetChild("n70");
		SignInBtn = (UI_btn_SignInBtn)(object)((GComponent)this).GetChild("SignInBtn");
		n65 = (GImage)((GComponent)this).GetChild("n65");
		RoomName = (GTextField)((GComponent)this).GetChild("RoomName");
		n71 = (GImage)((GComponent)this).GetChild("n71");
	}
}
