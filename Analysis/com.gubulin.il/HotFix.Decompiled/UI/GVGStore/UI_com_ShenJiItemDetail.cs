using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.GVGStore;

public class UI_com_ShenJiItemDetail : GComponent
{
	public Controller State;

	public Controller CanBuy;

	public Controller TicketIsEnough;

	public GImage n17;

	public GImage n16;

	public GImage n27;

	public GList Materials;

	public GLoader TicketIcon;

	public GTextField couponRequire;

	public GGroup n23;

	public GLoader StoreItemIcon;

	public GTextField ItemName;

	public GTextField ItemNum;

	public GImage n28;

	public UI_dec_bg03 n31;

	public GImage n29;

	public GImage n30;

	public GMovieClip n19;

	public GTextField n26;

	public UI_btn_Buy Buy;

	public UI_com_GrandPrizeSfxWrapper GrandPrizeSfxWrapper;

	public Transition t0;

	public Transition t1;

	public const string URL = "ui://fvc33k3gllla36";

	public static string Name = "UI_com_ShenJiItemDetail";

	public static string GetURL()
	{
		return "ui://fvc33k3gllla36";
	}

	public static UI_com_ShenJiItemDetail CreateInstance()
	{
		return (UI_com_ShenJiItemDetail)(object)UIPackage.CreateObject("GVGStore", "com_ShenJiItemDetail");
	}

	public static UI_com_ShenJiItemDetail CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_ShenJiItemDetail).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://fvc33k3gllla36", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		//IL_00b6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c0: Expected O, but got Unknown
		//IL_00cc: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d6: Expected O, but got Unknown
		//IL_00e2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ec: Expected O, but got Unknown
		//IL_00f8: Unknown result type (might be due to invalid IL or missing references)
		//IL_0102: Expected O, but got Unknown
		//IL_010e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0118: Expected O, but got Unknown
		//IL_0124: Unknown result type (might be due to invalid IL or missing references)
		//IL_012e: Expected O, but got Unknown
		//IL_0150: Unknown result type (might be due to invalid IL or missing references)
		//IL_015a: Expected O, but got Unknown
		//IL_0166: Unknown result type (might be due to invalid IL or missing references)
		//IL_0170: Expected O, but got Unknown
		//IL_017c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0186: Expected O, but got Unknown
		//IL_0192: Unknown result type (might be due to invalid IL or missing references)
		//IL_019c: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		State = ((GComponent)this).GetController("State");
		CanBuy = ((GComponent)this).GetController("CanBuy");
		TicketIsEnough = ((GComponent)this).GetController("TicketIsEnough");
		n17 = (GImage)((GComponent)this).GetChild("n17");
		n16 = (GImage)((GComponent)this).GetChild("n16");
		n27 = (GImage)((GComponent)this).GetChild("n27");
		Materials = (GList)((GComponent)this).GetChild("Materials");
		TicketIcon = (GLoader)((GComponent)this).GetChild("TicketIcon");
		couponRequire = (GTextField)((GComponent)this).GetChild("couponRequire");
		n23 = (GGroup)((GComponent)this).GetChild("n23");
		StoreItemIcon = (GLoader)((GComponent)this).GetChild("StoreItemIcon");
		ItemName = (GTextField)((GComponent)this).GetChild("ItemName");
		ItemNum = (GTextField)((GComponent)this).GetChild("ItemNum");
		n28 = (GImage)((GComponent)this).GetChild("n28");
		n31 = (UI_dec_bg03)(object)((GComponent)this).GetChild("n31");
		n29 = (GImage)((GComponent)this).GetChild("n29");
		n30 = (GImage)((GComponent)this).GetChild("n30");
		n19 = (GMovieClip)((GComponent)this).GetChild("n19");
		n26 = (GTextField)((GComponent)this).GetChild("n26");
		string id = "ui://fvc33k3gllla36".Replace("ui://", "") + "-" + ((GObject)n26).id;
		((GObject)n26).text = LanguagesManager.GetDesc(id);
		Buy = (UI_btn_Buy)(object)((GComponent)this).GetChild("Buy");
		GrandPrizeSfxWrapper = (UI_com_GrandPrizeSfxWrapper)(object)((GComponent)this).GetChild("GrandPrizeSfxWrapper");
		t0 = ((GComponent)this).GetTransition("t0");
		t1 = ((GComponent)this).GetTransition("t1");
	}
}
