using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGAmplifierForge;

public class UI_RecipeSlot : GButton
{
	public Controller button;

	public Controller State;

	public Controller IsShowRace;

	public Controller Rarity;

	public Controller c1;

	public Controller ForgeCountState;

	public GImage n107;

	public GImage n116;

	public GImage n119;

	public GImage n120;

	public GImage n121;

	public GImage n122;

	public GImage n117;

	public GImage n123;

	public GComponent AffectedSoldier;

	public GComponent RaceType;

	public GTextField AmpName;

	public GTextField MaxResourceForgeCount;

	public GTextField n105;

	public GImage n124;

	public GImage n125;

	public GTextField ForgeScrollCount;

	public GTextField InfiniteText;

	public GTextField Empty;

	public GGroup n130;

	public GImage n126;

	public GImage n113;

	public GImage RedDot;

	public GTextField n131;

	public GTextField Unlocking;

	public const string URL = "ui://fpjheycbxe3q8";

	public static string Name = "UI_RecipeSlot";

	public static string GetURL()
	{
		return "ui://fpjheycbxe3q8";
	}

	public static UI_RecipeSlot CreateInstance()
	{
		return (UI_RecipeSlot)(object)UIPackage.CreateObject("GvGAmplifierForge", "RecipeSlot");
	}

	public static UI_RecipeSlot CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_RecipeSlot).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://fpjheycbxe3q8", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_007b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0085: Expected O, but got Unknown
		//IL_0091: Unknown result type (might be due to invalid IL or missing references)
		//IL_009b: Expected O, but got Unknown
		//IL_00a7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b1: Expected O, but got Unknown
		//IL_00bd: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c7: Expected O, but got Unknown
		//IL_00d3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00dd: Expected O, but got Unknown
		//IL_00e9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f3: Expected O, but got Unknown
		//IL_00ff: Unknown result type (might be due to invalid IL or missing references)
		//IL_0109: Expected O, but got Unknown
		//IL_0115: Unknown result type (might be due to invalid IL or missing references)
		//IL_011f: Expected O, but got Unknown
		//IL_012b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0135: Expected O, but got Unknown
		//IL_0141: Unknown result type (might be due to invalid IL or missing references)
		//IL_014b: Expected O, but got Unknown
		//IL_0157: Unknown result type (might be due to invalid IL or missing references)
		//IL_0161: Expected O, but got Unknown
		//IL_016d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0177: Expected O, but got Unknown
		//IL_0183: Unknown result type (might be due to invalid IL or missing references)
		//IL_018d: Expected O, but got Unknown
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
		//IL_0286: Unknown result type (might be due to invalid IL or missing references)
		//IL_0290: Expected O, but got Unknown
		//IL_029c: Unknown result type (might be due to invalid IL or missing references)
		//IL_02a6: Expected O, but got Unknown
		//IL_02ef: Unknown result type (might be due to invalid IL or missing references)
		//IL_02f9: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		button = ((GComponent)this).GetController("button");
		State = ((GComponent)this).GetController("State");
		IsShowRace = ((GComponent)this).GetController("IsShowRace");
		Rarity = ((GComponent)this).GetController("Rarity");
		c1 = ((GComponent)this).GetController("c1");
		ForgeCountState = ((GComponent)this).GetController("ForgeCountState");
		n107 = (GImage)((GComponent)this).GetChild("n107");
		n116 = (GImage)((GComponent)this).GetChild("n116");
		n119 = (GImage)((GComponent)this).GetChild("n119");
		n120 = (GImage)((GComponent)this).GetChild("n120");
		n121 = (GImage)((GComponent)this).GetChild("n121");
		n122 = (GImage)((GComponent)this).GetChild("n122");
		n117 = (GImage)((GComponent)this).GetChild("n117");
		n123 = (GImage)((GComponent)this).GetChild("n123");
		AffectedSoldier = (GComponent)((GComponent)this).GetChild("AffectedSoldier");
		RaceType = (GComponent)((GComponent)this).GetChild("RaceType");
		AmpName = (GTextField)((GComponent)this).GetChild("AmpName");
		MaxResourceForgeCount = (GTextField)((GComponent)this).GetChild("MaxResourceForgeCount");
		n105 = (GTextField)((GComponent)this).GetChild("n105");
		string id = "ui://fpjheycbxe3q8".Replace("ui://", "") + "-" + ((GObject)n105).id;
		((GObject)n105).text = LanguagesManager.GetDesc(id);
		n124 = (GImage)((GComponent)this).GetChild("n124");
		n125 = (GImage)((GComponent)this).GetChild("n125");
		ForgeScrollCount = (GTextField)((GComponent)this).GetChild("ForgeScrollCount");
		InfiniteText = (GTextField)((GComponent)this).GetChild("InfiniteText");
		Empty = (GTextField)((GComponent)this).GetChild("Empty");
		n130 = (GGroup)((GComponent)this).GetChild("n130");
		n126 = (GImage)((GComponent)this).GetChild("n126");
		n113 = (GImage)((GComponent)this).GetChild("n113");
		RedDot = (GImage)((GComponent)this).GetChild("RedDot");
		n131 = (GTextField)((GComponent)this).GetChild("n131");
		string id2 = "ui://fpjheycbxe3q8".Replace("ui://", "") + "-" + ((GObject)n131).id;
		((GObject)n131).text = LanguagesManager.GetDesc(id2);
		Unlocking = (GTextField)((GComponent)this).GetChild("Unlocking");
	}
}
