using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGExpeditionHall;

public class UI_com_SelectRoomDialog : GComponent
{
	public Controller IsSigned;

	public GImage tipBack;

	public GImage n50;

	public GTextField n1;

	public GButton CloseBtn;

	public UI_btn_SelectedRoom SelectedRoom;

	public GTextField n48;

	public GList RoomList;

	public GTextField n51;

	public const string URL = "ui://k19peou7dnvl2p";

	public static string Name = "UI_com_SelectRoomDialog";

	public static string GetURL()
	{
		return "ui://k19peou7dnvl2p";
	}

	public static UI_com_SelectRoomDialog CreateInstance()
	{
		return (UI_com_SelectRoomDialog)(object)UIPackage.CreateObject("GvGExpeditionHall", "com_SelectRoomDialog");
	}

	public static UI_com_SelectRoomDialog CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_SelectRoomDialog).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://k19peou7dnvl2p", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		//IL_00a5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00af: Expected O, but got Unknown
		//IL_00d1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00db: Expected O, but got Unknown
		//IL_0124: Unknown result type (might be due to invalid IL or missing references)
		//IL_012e: Expected O, but got Unknown
		//IL_013a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0144: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		IsSigned = ((GComponent)this).GetController("IsSigned");
		tipBack = (GImage)((GComponent)this).GetChild("tipBack");
		n50 = (GImage)((GComponent)this).GetChild("n50");
		n1 = (GTextField)((GComponent)this).GetChild("n1");
		string id = "ui://k19peou7dnvl2p".Replace("ui://", "") + "-" + ((GObject)n1).id;
		((GObject)n1).text = LanguagesManager.GetDesc(id);
		CloseBtn = (GButton)((GComponent)this).GetChild("CloseBtn");
		SelectedRoom = (UI_btn_SelectedRoom)(object)((GComponent)this).GetChild("SelectedRoom");
		n48 = (GTextField)((GComponent)this).GetChild("n48");
		string id2 = "ui://k19peou7dnvl2p".Replace("ui://", "") + "-" + ((GObject)n48).id;
		((GObject)n48).text = LanguagesManager.GetDesc(id2);
		RoomList = (GList)((GComponent)this).GetChild("RoomList");
		n51 = (GTextField)((GComponent)this).GetChild("n51");
		string id3 = "ui://k19peou7dnvl2p".Replace("ui://", "") + "-" + ((GObject)n51).id;
		((GObject)n51).text = LanguagesManager.GetDesc(id3);
	}
}
