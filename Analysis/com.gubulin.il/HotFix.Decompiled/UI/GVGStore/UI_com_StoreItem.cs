using FairyGUI;
using FairyGUI.Utils;

namespace UI.GVGStore;

public class UI_com_StoreItem : GComponent
{
	public Controller Type;

	public Controller State;

	public GGroup n18;

	public GImage n17;

	public GImage n16;

	public GImage n7;

	public GImage n15;

	public GImage n6;

	public GGroup n20;

	public GMovieClip n19;

	public GList Materials;

	public GLoader StoreItemIcon;

	public GTextField ItemName;

	public UI_btn_Buy Buy;

	public GTextField ItemNum;

	public UI_com_StoreItem_Blackbg n8;

	public GImage n9;

	public UI_com_UltraRarePrizeSfxWrapper UltraRarePrizeSfxWrapper;

	public UI_com_GrandPrizeSfxWrapper GrandPrizeSfxWrapper;

	public GGroup n14;

	public Transition t0;

	public const string URL = "ui://fvc33k3gv6i7s";

	public static string Name = "UI_com_StoreItem";

	public static string GetURL()
	{
		return "ui://fvc33k3gv6i7s";
	}

	public static UI_com_StoreItem CreateInstance()
	{
		return (UI_com_StoreItem)(object)UIPackage.CreateObject("GVGStore", "com_StoreItem");
	}

	public static UI_com_StoreItem CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_StoreItem).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://fvc33k3gv6i7s", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0037: Unknown result type (might be due to invalid IL or missing references)
		//IL_0041: Expected O, but got Unknown
		//IL_004d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0057: Expected O, but got Unknown
		//IL_0063: Unknown result type (might be due to invalid IL or missing references)
		//IL_006d: Expected O, but got Unknown
		//IL_0079: Unknown result type (might be due to invalid IL or missing references)
		//IL_0083: Expected O, but got Unknown
		//IL_008f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0099: Expected O, but got Unknown
		//IL_00a5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00af: Expected O, but got Unknown
		//IL_00bb: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c5: Expected O, but got Unknown
		//IL_00d1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00db: Expected O, but got Unknown
		//IL_00e7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f1: Expected O, but got Unknown
		//IL_00fd: Unknown result type (might be due to invalid IL or missing references)
		//IL_0107: Expected O, but got Unknown
		//IL_0113: Unknown result type (might be due to invalid IL or missing references)
		//IL_011d: Expected O, but got Unknown
		//IL_013f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0149: Expected O, but got Unknown
		//IL_016b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0175: Expected O, but got Unknown
		//IL_01ad: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b7: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		Type = ((GComponent)this).GetController("Type");
		State = ((GComponent)this).GetController("State");
		n18 = (GGroup)((GComponent)this).GetChild("n18");
		n17 = (GImage)((GComponent)this).GetChild("n17");
		n16 = (GImage)((GComponent)this).GetChild("n16");
		n7 = (GImage)((GComponent)this).GetChild("n7");
		n15 = (GImage)((GComponent)this).GetChild("n15");
		n6 = (GImage)((GComponent)this).GetChild("n6");
		n20 = (GGroup)((GComponent)this).GetChild("n20");
		n19 = (GMovieClip)((GComponent)this).GetChild("n19");
		Materials = (GList)((GComponent)this).GetChild("Materials");
		StoreItemIcon = (GLoader)((GComponent)this).GetChild("StoreItemIcon");
		ItemName = (GTextField)((GComponent)this).GetChild("ItemName");
		Buy = (UI_btn_Buy)(object)((GComponent)this).GetChild("Buy");
		ItemNum = (GTextField)((GComponent)this).GetChild("ItemNum");
		n8 = (UI_com_StoreItem_Blackbg)(object)((GComponent)this).GetChild("n8");
		n9 = (GImage)((GComponent)this).GetChild("n9");
		UltraRarePrizeSfxWrapper = (UI_com_UltraRarePrizeSfxWrapper)(object)((GComponent)this).GetChild("UltraRarePrizeSfxWrapper");
		GrandPrizeSfxWrapper = (UI_com_GrandPrizeSfxWrapper)(object)((GComponent)this).GetChild("GrandPrizeSfxWrapper");
		n14 = (GGroup)((GComponent)this).GetChild("n14");
		t0 = ((GComponent)this).GetTransition("t0");
	}
}
