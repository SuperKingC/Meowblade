using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGExpeditionHall;

public class UI_btn_SelectedRoom : GButton
{
	public Controller IsRoomFull;

	public Controller ShipState;

	public Controller Camp;

	public GImage n47;

	public GImage n67;

	public GTextField n49;

	public GTextField UserCount;

	public GTextField n52;

	public GTextField StartTime;

	public GImage n54;

	public GTextField n60;

	public GTextField n61;

	public GTextField n62;

	public GTextField n66;

	public GTextField TimeToStart;

	public GLoader CampIcon;

	public GTextField CampName;

	public UI_btn_CancelSignInBtn CancelSignInBtn;

	public GImage n68;

	public GTextField RoomName;

	public GTextField n70;

	public const string URL = "ui://k19peou7dnvl31";

	public static string Name = "UI_btn_SelectedRoom";

	public static string GetURL()
	{
		return "ui://k19peou7dnvl31";
	}

	public static UI_btn_SelectedRoom CreateInstance()
	{
		return (UI_btn_SelectedRoom)(object)UIPackage.CreateObject("GvGExpeditionHall", "btn_SelectedRoom");
	}

	public static UI_btn_SelectedRoom CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_btn_SelectedRoom).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://k19peou7dnvl31", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		//IL_00c7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d1: Expected O, but got Unknown
		//IL_00dd: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e7: Expected O, but got Unknown
		//IL_0130: Unknown result type (might be due to invalid IL or missing references)
		//IL_013a: Expected O, but got Unknown
		//IL_0146: Unknown result type (might be due to invalid IL or missing references)
		//IL_0150: Expected O, but got Unknown
		//IL_015c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0166: Expected O, but got Unknown
		//IL_01af: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b9: Expected O, but got Unknown
		//IL_0202: Unknown result type (might be due to invalid IL or missing references)
		//IL_020c: Expected O, but got Unknown
		//IL_0257: Unknown result type (might be due to invalid IL or missing references)
		//IL_0261: Expected O, but got Unknown
		//IL_02ac: Unknown result type (might be due to invalid IL or missing references)
		//IL_02b6: Expected O, but got Unknown
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
		IsRoomFull = ((GComponent)this).GetController("IsRoomFull");
		ShipState = ((GComponent)this).GetController("ShipState");
		Camp = ((GComponent)this).GetController("Camp");
		n47 = (GImage)((GComponent)this).GetChild("n47");
		n67 = (GImage)((GComponent)this).GetChild("n67");
		n49 = (GTextField)((GComponent)this).GetChild("n49");
		string id = "ui://k19peou7dnvl31".Replace("ui://", "") + "-" + ((GObject)n49).id;
		((GObject)n49).text = LanguagesManager.GetDesc(id);
		UserCount = (GTextField)((GComponent)this).GetChild("UserCount");
		n52 = (GTextField)((GComponent)this).GetChild("n52");
		string id2 = "ui://k19peou7dnvl31".Replace("ui://", "") + "-" + ((GObject)n52).id;
		((GObject)n52).text = LanguagesManager.GetDesc(id2);
		StartTime = (GTextField)((GComponent)this).GetChild("StartTime");
		n54 = (GImage)((GComponent)this).GetChild("n54");
		n60 = (GTextField)((GComponent)this).GetChild("n60");
		string id3 = "ui://k19peou7dnvl31".Replace("ui://", "") + "-" + ((GObject)n60).id;
		((GObject)n60).text = LanguagesManager.GetDesc(id3);
		n61 = (GTextField)((GComponent)this).GetChild("n61");
		string id4 = "ui://k19peou7dnvl31".Replace("ui://", "") + "-" + ((GObject)n61).id;
		((GObject)n61).text = LanguagesManager.GetDesc(id4);
		n62 = (GTextField)((GComponent)this).GetChild("n62");
		string id5 = "ui://k19peou7dnvl31".Replace("ui://", "") + "-" + ((GObject)n62).id;
		((GObject)n62).text = LanguagesManager.GetDesc(id5);
		n66 = (GTextField)((GComponent)this).GetChild("n66");
		string id6 = "ui://k19peou7dnvl31".Replace("ui://", "") + "-" + ((GObject)n66).id;
		((GObject)n66).text = LanguagesManager.GetDesc(id6);
		TimeToStart = (GTextField)((GComponent)this).GetChild("TimeToStart");
		CampIcon = (GLoader)((GComponent)this).GetChild("CampIcon");
		CampName = (GTextField)((GComponent)this).GetChild("CampName");
		CancelSignInBtn = (UI_btn_CancelSignInBtn)(object)((GComponent)this).GetChild("CancelSignInBtn");
		n68 = (GImage)((GComponent)this).GetChild("n68");
		RoomName = (GTextField)((GComponent)this).GetChild("RoomName");
		n70 = (GTextField)((GComponent)this).GetChild("n70");
		string id7 = "ui://k19peou7dnvl31".Replace("ui://", "") + "-" + ((GObject)n70).id;
		((GObject)n70).text = LanguagesManager.GetDesc(id7);
	}
}
