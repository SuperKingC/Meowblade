using FairyGUI;
using FairyGUI.Utils;
using UnityEngine;

namespace UI.GvGBrawlFight;

public class UI_com_ShipPositionSlot02 : GComponent, IShipPosition
{
	public Controller State;

	public Controller isShowCancelBtn;

	public Controller isSelect;

	public Controller isDark;

	public Controller isWaitConfirm;

	public GImage n73;

	public GImage n70;

	public GImage n58;

	public GImage n60;

	public GImage n69;

	public GGroup n61;

	public GImage n74;

	public GImage n63;

	public UI_com_IslandAvatar02 avatar;

	public GImage n68;

	public GImage n57;

	public GGroup n64;

	public GImage n75;

	public GImage n76;

	public GImage n71;

	public GImage n65;

	public UI_com_IslandAvatarSelf avatarSelf;

	public GImage n62;

	public GGroup n66;

	public GTextField slotName;

	public UI_btn_03 cancelEnroll;

	public GGroup n77;

	public GImage n81;

	public GImage n82;

	public GGroup n80;

	public Transition t0;

	public Transition t1;

	public const string URL = "ui://hozu168rqbhc7m";

	public static string Name = "UI_com_ShipPositionSlot02";

	public int Index { get; set; }

	public Vector2 Position => Vector2.op_Implicit(((GObject)this).position);

	public Vector2 Size => ((GObject)this).size;

	public Controller GetState => State;

	public Controller GetIsShowCancelBtn => isShowCancelBtn;

	public Controller GetIsSelect => isSelect;

	public Controller GetIsDark => isDark;

	public Controller GetIsWaitConfirm => isWaitConfirm;

	public IIslandAvatar GetAvatar => avatar;

	public UI_com_IslandAvatarSelf GetAvatarSelf => avatarSelf;

	public GTextField GetSlotName => slotName;

	public UI_btn_03 GetCancelEnroll => cancelEnroll;

	public GObject GetThis => (GObject)(object)this;

	public static string GetURL()
	{
		return "ui://hozu168rqbhc7m";
	}

	public static UI_com_ShipPositionSlot02 CreateInstance()
	{
		return (UI_com_ShipPositionSlot02)(object)UIPackage.CreateObject("GvGBrawlFight", "com_ShipPositionSlot02");
	}

	public static UI_com_ShipPositionSlot02 CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_ShipPositionSlot02).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://hozu168rqbhc7m", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_006a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0074: Expected O, but got Unknown
		//IL_0080: Unknown result type (might be due to invalid IL or missing references)
		//IL_008a: Expected O, but got Unknown
		//IL_0096: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a0: Expected O, but got Unknown
		//IL_00ac: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b6: Expected O, but got Unknown
		//IL_00c2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00cc: Expected O, but got Unknown
		//IL_00d8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e2: Expected O, but got Unknown
		//IL_00ee: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f8: Expected O, but got Unknown
		//IL_0104: Unknown result type (might be due to invalid IL or missing references)
		//IL_010e: Expected O, but got Unknown
		//IL_0130: Unknown result type (might be due to invalid IL or missing references)
		//IL_013a: Expected O, but got Unknown
		//IL_0146: Unknown result type (might be due to invalid IL or missing references)
		//IL_0150: Expected O, but got Unknown
		//IL_015c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0166: Expected O, but got Unknown
		//IL_0172: Unknown result type (might be due to invalid IL or missing references)
		//IL_017c: Expected O, but got Unknown
		//IL_0188: Unknown result type (might be due to invalid IL or missing references)
		//IL_0192: Expected O, but got Unknown
		//IL_019e: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a8: Expected O, but got Unknown
		//IL_01b4: Unknown result type (might be due to invalid IL or missing references)
		//IL_01be: Expected O, but got Unknown
		//IL_01e0: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ea: Expected O, but got Unknown
		//IL_01f6: Unknown result type (might be due to invalid IL or missing references)
		//IL_0200: Expected O, but got Unknown
		//IL_020c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0216: Expected O, but got Unknown
		//IL_0238: Unknown result type (might be due to invalid IL or missing references)
		//IL_0242: Expected O, but got Unknown
		//IL_024e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0258: Expected O, but got Unknown
		//IL_0264: Unknown result type (might be due to invalid IL or missing references)
		//IL_026e: Expected O, but got Unknown
		//IL_027a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0284: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		State = ((GComponent)this).GetController("State");
		isShowCancelBtn = ((GComponent)this).GetController("isShowCancelBtn");
		isSelect = ((GComponent)this).GetController("isSelect");
		isDark = ((GComponent)this).GetController("isDark");
		isWaitConfirm = ((GComponent)this).GetController("isWaitConfirm");
		n73 = (GImage)((GComponent)this).GetChild("n73");
		n70 = (GImage)((GComponent)this).GetChild("n70");
		n58 = (GImage)((GComponent)this).GetChild("n58");
		n60 = (GImage)((GComponent)this).GetChild("n60");
		n69 = (GImage)((GComponent)this).GetChild("n69");
		n61 = (GGroup)((GComponent)this).GetChild("n61");
		n74 = (GImage)((GComponent)this).GetChild("n74");
		n63 = (GImage)((GComponent)this).GetChild("n63");
		avatar = (UI_com_IslandAvatar02)(object)((GComponent)this).GetChild("avatar");
		n68 = (GImage)((GComponent)this).GetChild("n68");
		n57 = (GImage)((GComponent)this).GetChild("n57");
		n64 = (GGroup)((GComponent)this).GetChild("n64");
		n75 = (GImage)((GComponent)this).GetChild("n75");
		n76 = (GImage)((GComponent)this).GetChild("n76");
		n71 = (GImage)((GComponent)this).GetChild("n71");
		n65 = (GImage)((GComponent)this).GetChild("n65");
		avatarSelf = (UI_com_IslandAvatarSelf)(object)((GComponent)this).GetChild("avatarSelf");
		n62 = (GImage)((GComponent)this).GetChild("n62");
		n66 = (GGroup)((GComponent)this).GetChild("n66");
		slotName = (GTextField)((GComponent)this).GetChild("slotName");
		cancelEnroll = (UI_btn_03)(object)((GComponent)this).GetChild("cancelEnroll");
		n77 = (GGroup)((GComponent)this).GetChild("n77");
		n81 = (GImage)((GComponent)this).GetChild("n81");
		n82 = (GImage)((GComponent)this).GetChild("n82");
		n80 = (GGroup)((GComponent)this).GetChild("n80");
		t0 = ((GComponent)this).GetTransition("t0");
		t1 = ((GComponent)this).GetTransition("t1");
	}
}
