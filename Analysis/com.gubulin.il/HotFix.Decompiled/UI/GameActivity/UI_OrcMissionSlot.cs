using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.GameActivity;

public class UI_OrcMissionSlot : GComponent
{
	public Controller ProgressBgState;

	public Controller ProgressBarState;

	public Controller StoreItemState;

	public Controller IsMyth;

	public Controller showLegendItemSlot;

	public Controller isGiftEmpty;

	public GImage n4;

	public GImage n31;

	public UI_OrcClaimBtn ClaimBtn;

	public UI_OrcBonus Bonus;

	public UI_com_OrcMissionMythSlot02 n44;

	public UI_OrcBuyBtn n46;

	public GTextField n47;

	public GGroup n45;

	public GImage BonusClaimed;

	public GImage cardMask;

	public GImage n10;

	public GImage n12;

	public GImage n9;

	public GImage n13;

	public GImage bg;

	public GLoader Frame;

	public GLoader Icon;

	public GImage n40;

	public GImage n39;

	public GGroup n36;

	public GImage n41;

	public UI_OrcBuyBtn BuyBtn;

	public GTextField LimitText;

	public GList StoreItemList;

	public GImage n26;

	public GList ExtraList;

	public GGroup n51;

	public GImage StoreItemClaimed;

	public GGroup n35;

	public UI_com_OrcMissionMythSlot MythSlot;

	public UI_OrcBuyBtn BuyBtn2;

	public GTextField LimitText2;

	public GGroup n37;

	public GGroup giftPack;

	public GTextField n33;

	public UI_com_OrcMissionMythSlot MythSlotEmpty;

	public GGroup emptyGift;

	public const string URL = "ui://29q48tv6mbra4f";

	public static string Name = "UI_OrcMissionSlot";

	public UI_com_OrcMoreStoreItemSlot moreStoreItemSlots;

	public static float InitHeight;

	public static string GetURL()
	{
		return "ui://29q48tv6mbra4f";
	}

	public static UI_OrcMissionSlot CreateInstance()
	{
		return (UI_OrcMissionSlot)(object)UIPackage.CreateObject("GameActivity", "OrcMissionSlot");
	}

	public static UI_OrcMissionSlot CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_OrcMissionSlot).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://29q48tv6mbra4f", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_007b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0085: Expected O, but got Unknown
		//IL_0091: Unknown result type (might be due to invalid IL or missing references)
		//IL_009b: Expected O, but got Unknown
		//IL_00ff: Unknown result type (might be due to invalid IL or missing references)
		//IL_0109: Expected O, but got Unknown
		//IL_0152: Unknown result type (might be due to invalid IL or missing references)
		//IL_015c: Expected O, but got Unknown
		//IL_0168: Unknown result type (might be due to invalid IL or missing references)
		//IL_0172: Expected O, but got Unknown
		//IL_017e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0188: Expected O, but got Unknown
		//IL_0194: Unknown result type (might be due to invalid IL or missing references)
		//IL_019e: Expected O, but got Unknown
		//IL_01aa: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b4: Expected O, but got Unknown
		//IL_01c0: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ca: Expected O, but got Unknown
		//IL_01d6: Unknown result type (might be due to invalid IL or missing references)
		//IL_01e0: Expected O, but got Unknown
		//IL_01ec: Unknown result type (might be due to invalid IL or missing references)
		//IL_01f6: Expected O, but got Unknown
		//IL_0202: Unknown result type (might be due to invalid IL or missing references)
		//IL_020c: Expected O, but got Unknown
		//IL_0218: Unknown result type (might be due to invalid IL or missing references)
		//IL_0222: Expected O, but got Unknown
		//IL_022e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0238: Expected O, but got Unknown
		//IL_0244: Unknown result type (might be due to invalid IL or missing references)
		//IL_024e: Expected O, but got Unknown
		//IL_025a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0264: Expected O, but got Unknown
		//IL_0270: Unknown result type (might be due to invalid IL or missing references)
		//IL_027a: Expected O, but got Unknown
		//IL_029c: Unknown result type (might be due to invalid IL or missing references)
		//IL_02a6: Expected O, but got Unknown
		//IL_02ef: Unknown result type (might be due to invalid IL or missing references)
		//IL_02f9: Expected O, but got Unknown
		//IL_0305: Unknown result type (might be due to invalid IL or missing references)
		//IL_030f: Expected O, but got Unknown
		//IL_031b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0325: Expected O, but got Unknown
		//IL_0331: Unknown result type (might be due to invalid IL or missing references)
		//IL_033b: Expected O, but got Unknown
		//IL_0347: Unknown result type (might be due to invalid IL or missing references)
		//IL_0351: Expected O, but got Unknown
		//IL_035d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0367: Expected O, but got Unknown
		//IL_039f: Unknown result type (might be due to invalid IL or missing references)
		//IL_03a9: Expected O, but got Unknown
		//IL_03f2: Unknown result type (might be due to invalid IL or missing references)
		//IL_03fc: Expected O, but got Unknown
		//IL_0408: Unknown result type (might be due to invalid IL or missing references)
		//IL_0412: Expected O, but got Unknown
		//IL_041e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0428: Expected O, but got Unknown
		//IL_0487: Unknown result type (might be due to invalid IL or missing references)
		//IL_0491: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		ProgressBgState = ((GComponent)this).GetController("ProgressBgState");
		ProgressBarState = ((GComponent)this).GetController("ProgressBarState");
		StoreItemState = ((GComponent)this).GetController("StoreItemState");
		IsMyth = ((GComponent)this).GetController("IsMyth");
		showLegendItemSlot = ((GComponent)this).GetController("showLegendItemSlot");
		isGiftEmpty = ((GComponent)this).GetController("isGiftEmpty");
		n4 = (GImage)((GComponent)this).GetChild("n4");
		n31 = (GImage)((GComponent)this).GetChild("n31");
		ClaimBtn = (UI_OrcClaimBtn)(object)((GComponent)this).GetChild("ClaimBtn");
		Bonus = (UI_OrcBonus)(object)((GComponent)this).GetChild("Bonus");
		n44 = (UI_com_OrcMissionMythSlot02)(object)((GComponent)this).GetChild("n44");
		n46 = (UI_OrcBuyBtn)(object)((GComponent)this).GetChild("n46");
		n47 = (GTextField)((GComponent)this).GetChild("n47");
		string id = "ui://29q48tv6mbra4f".Replace("ui://", "") + "-" + ((GObject)n47).id;
		((GObject)n47).text = LanguagesManager.GetDesc(id);
		n45 = (GGroup)((GComponent)this).GetChild("n45");
		BonusClaimed = (GImage)((GComponent)this).GetChild("BonusClaimed");
		cardMask = (GImage)((GComponent)this).GetChild("cardMask");
		n10 = (GImage)((GComponent)this).GetChild("n10");
		n12 = (GImage)((GComponent)this).GetChild("n12");
		n9 = (GImage)((GComponent)this).GetChild("n9");
		n13 = (GImage)((GComponent)this).GetChild("n13");
		bg = (GImage)((GComponent)this).GetChild("bg");
		Frame = (GLoader)((GComponent)this).GetChild("Frame");
		Icon = (GLoader)((GComponent)this).GetChild("Icon");
		n40 = (GImage)((GComponent)this).GetChild("n40");
		n39 = (GImage)((GComponent)this).GetChild("n39");
		n36 = (GGroup)((GComponent)this).GetChild("n36");
		n41 = (GImage)((GComponent)this).GetChild("n41");
		BuyBtn = (UI_OrcBuyBtn)(object)((GComponent)this).GetChild("BuyBtn");
		LimitText = (GTextField)((GComponent)this).GetChild("LimitText");
		string id2 = "ui://29q48tv6mbra4f".Replace("ui://", "") + "-" + ((GObject)LimitText).id;
		((GObject)LimitText).text = LanguagesManager.GetDesc(id2);
		StoreItemList = (GList)((GComponent)this).GetChild("StoreItemList");
		n26 = (GImage)((GComponent)this).GetChild("n26");
		ExtraList = (GList)((GComponent)this).GetChild("ExtraList");
		n51 = (GGroup)((GComponent)this).GetChild("n51");
		StoreItemClaimed = (GImage)((GComponent)this).GetChild("StoreItemClaimed");
		n35 = (GGroup)((GComponent)this).GetChild("n35");
		MythSlot = (UI_com_OrcMissionMythSlot)(object)((GComponent)this).GetChild("MythSlot");
		BuyBtn2 = (UI_OrcBuyBtn)(object)((GComponent)this).GetChild("BuyBtn2");
		LimitText2 = (GTextField)((GComponent)this).GetChild("LimitText2");
		string id3 = "ui://29q48tv6mbra4f".Replace("ui://", "") + "-" + ((GObject)LimitText2).id;
		((GObject)LimitText2).text = LanguagesManager.GetDesc(id3);
		n37 = (GGroup)((GComponent)this).GetChild("n37");
		giftPack = (GGroup)((GComponent)this).GetChild("giftPack");
		n33 = (GTextField)((GComponent)this).GetChild("n33");
		string id4 = "ui://29q48tv6mbra4f".Replace("ui://", "") + "-" + ((GObject)n33).id;
		((GObject)n33).text = LanguagesManager.GetDesc(id4);
		MythSlotEmpty = (UI_com_OrcMissionMythSlot)(object)((GComponent)this).GetChild("MythSlotEmpty");
		emptyGift = (GGroup)((GComponent)this).GetChild("emptyGift");
	}
}
