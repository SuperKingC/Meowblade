using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGOnIsland3;

public class UI_btn_MyShipSlot : GButton
{
	public Controller button;

	public Controller State;

	public Controller IsSelectStrategy;

	public Controller DisplayMode;

	public Controller IsShowDamage;

	public Controller ActionMode;

	public Controller IsHidden;

	public UI_com_StrategyMenu StrategyMenu;

	public GLoader n1;

	public GImage n26;

	public GImage n27;

	public GLoader ShipSkin;

	public GImage n28;

	public GTextField KillCountText;

	public GImage n22;

	public GTextField DamageText;

	public GImage n23;

	public GGroup n24;

	public GGroup n19;

	public GTextField SoldierCountText;

	public GImage n18;

	public GGroup n21;

	public GTextField n25;

	public GTextField n29;

	public GTextField ShipName;

	public UI_btn_Strategy CurStrategyBtn;

	public GGroup StrategyGroup;

	public UI_btn_Retreat RetreatBtn;

	public GGroup RetreatGroup;

	public Transition t0;

	public const string URL = "ui://ebc4ciwrl44l1r";

	public static string Name = "UI_btn_MyShipSlot";

	public static string GetURL()
	{
		return "ui://ebc4ciwrl44l1r";
	}

	public static UI_btn_MyShipSlot CreateInstance()
	{
		return (UI_btn_MyShipSlot)(object)UIPackage.CreateObject("GvGOnIsland3", "btn_MyShipSlot");
	}

	public static UI_btn_MyShipSlot CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_btn_MyShipSlot).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://ebc4ciwrl44l1r", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_00a2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ac: Expected O, but got Unknown
		//IL_00b8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c2: Expected O, but got Unknown
		//IL_00ce: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d8: Expected O, but got Unknown
		//IL_00e4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ee: Expected O, but got Unknown
		//IL_00fa: Unknown result type (might be due to invalid IL or missing references)
		//IL_0104: Expected O, but got Unknown
		//IL_0110: Unknown result type (might be due to invalid IL or missing references)
		//IL_011a: Expected O, but got Unknown
		//IL_0126: Unknown result type (might be due to invalid IL or missing references)
		//IL_0130: Expected O, but got Unknown
		//IL_013c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0146: Expected O, but got Unknown
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
		//IL_0229: Unknown result type (might be due to invalid IL or missing references)
		//IL_0233: Expected O, but got Unknown
		//IL_027c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0286: Expected O, but got Unknown
		//IL_02a8: Unknown result type (might be due to invalid IL or missing references)
		//IL_02b2: Expected O, but got Unknown
		//IL_02d4: Unknown result type (might be due to invalid IL or missing references)
		//IL_02de: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		button = ((GComponent)this).GetController("button");
		State = ((GComponent)this).GetController("State");
		IsSelectStrategy = ((GComponent)this).GetController("IsSelectStrategy");
		DisplayMode = ((GComponent)this).GetController("DisplayMode");
		IsShowDamage = ((GComponent)this).GetController("IsShowDamage");
		ActionMode = ((GComponent)this).GetController("ActionMode");
		IsHidden = ((GComponent)this).GetController("IsHidden");
		StrategyMenu = (UI_com_StrategyMenu)(object)((GComponent)this).GetChild("StrategyMenu");
		n1 = (GLoader)((GComponent)this).GetChild("n1");
		n26 = (GImage)((GComponent)this).GetChild("n26");
		n27 = (GImage)((GComponent)this).GetChild("n27");
		ShipSkin = (GLoader)((GComponent)this).GetChild("ShipSkin");
		n28 = (GImage)((GComponent)this).GetChild("n28");
		KillCountText = (GTextField)((GComponent)this).GetChild("KillCountText");
		n22 = (GImage)((GComponent)this).GetChild("n22");
		DamageText = (GTextField)((GComponent)this).GetChild("DamageText");
		n23 = (GImage)((GComponent)this).GetChild("n23");
		n24 = (GGroup)((GComponent)this).GetChild("n24");
		n19 = (GGroup)((GComponent)this).GetChild("n19");
		SoldierCountText = (GTextField)((GComponent)this).GetChild("SoldierCountText");
		n18 = (GImage)((GComponent)this).GetChild("n18");
		n21 = (GGroup)((GComponent)this).GetChild("n21");
		n25 = (GTextField)((GComponent)this).GetChild("n25");
		string id = "ui://ebc4ciwrl44l1r".Replace("ui://", "") + "-" + ((GObject)n25).id;
		((GObject)n25).text = LanguagesManager.GetDesc(id);
		n29 = (GTextField)((GComponent)this).GetChild("n29");
		string id2 = "ui://ebc4ciwrl44l1r".Replace("ui://", "") + "-" + ((GObject)n29).id;
		((GObject)n29).text = LanguagesManager.GetDesc(id2);
		ShipName = (GTextField)((GComponent)this).GetChild("ShipName");
		CurStrategyBtn = (UI_btn_Strategy)(object)((GComponent)this).GetChild("CurStrategyBtn");
		StrategyGroup = (GGroup)((GComponent)this).GetChild("StrategyGroup");
		RetreatBtn = (UI_btn_Retreat)(object)((GComponent)this).GetChild("RetreatBtn");
		RetreatGroup = (GGroup)((GComponent)this).GetChild("RetreatGroup");
		t0 = ((GComponent)this).GetTransition("t0");
	}
}
