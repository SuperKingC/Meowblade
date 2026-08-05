using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGExpeditionHall;

public class UI_com_SignInInfo : GComponent
{
	public Controller Camp;

	public GImage n127;

	public GImage n140;

	public GImage n141;

	public GTextField n137;

	public GTextField n129;

	public GTextField n130;

	public GTextField RoomName;

	public GTextField StartTime;

	public GTextField CampName;

	public GLoader CampIcon;

	public UI_btn_GoToRoomDetailBtn GoToRoomDetailBtn;

	public const string URL = "ui://k19peou7ipyh1l";

	public static string Name = "UI_com_SignInInfo";

	public static string GetURL()
	{
		return "ui://k19peou7ipyh1l";
	}

	public static UI_com_SignInInfo CreateInstance()
	{
		return (UI_com_SignInInfo)(object)UIPackage.CreateObject("GvGExpeditionHall", "com_SignInInfo");
	}

	public static UI_com_SignInInfo CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_SignInInfo).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://k19peou7ipyh1l", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		//IL_00bb: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c5: Expected O, but got Unknown
		//IL_010e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0118: Expected O, but got Unknown
		//IL_0161: Unknown result type (might be due to invalid IL or missing references)
		//IL_016b: Expected O, but got Unknown
		//IL_0177: Unknown result type (might be due to invalid IL or missing references)
		//IL_0181: Expected O, but got Unknown
		//IL_018d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0197: Expected O, but got Unknown
		//IL_01a3: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ad: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		Camp = ((GComponent)this).GetController("Camp");
		n127 = (GImage)((GComponent)this).GetChild("n127");
		n140 = (GImage)((GComponent)this).GetChild("n140");
		n141 = (GImage)((GComponent)this).GetChild("n141");
		n137 = (GTextField)((GComponent)this).GetChild("n137");
		string id = "ui://k19peou7ipyh1l".Replace("ui://", "") + "-" + ((GObject)n137).id;
		((GObject)n137).text = LanguagesManager.GetDesc(id);
		n129 = (GTextField)((GComponent)this).GetChild("n129");
		string id2 = "ui://k19peou7ipyh1l".Replace("ui://", "") + "-" + ((GObject)n129).id;
		((GObject)n129).text = LanguagesManager.GetDesc(id2);
		n130 = (GTextField)((GComponent)this).GetChild("n130");
		string id3 = "ui://k19peou7ipyh1l".Replace("ui://", "") + "-" + ((GObject)n130).id;
		((GObject)n130).text = LanguagesManager.GetDesc(id3);
		RoomName = (GTextField)((GComponent)this).GetChild("RoomName");
		StartTime = (GTextField)((GComponent)this).GetChild("StartTime");
		CampName = (GTextField)((GComponent)this).GetChild("CampName");
		CampIcon = (GLoader)((GComponent)this).GetChild("CampIcon");
		GoToRoomDetailBtn = (UI_btn_GoToRoomDetailBtn)(object)((GComponent)this).GetChild("GoToRoomDetailBtn");
	}
}
