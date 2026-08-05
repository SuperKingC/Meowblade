using FairyGUI;
using FairyGUI.Utils;

namespace UI.InstanceZones;

public class UI_OffensiveCard : GButton
{
	public Controller PageController;

	public Controller Selected;

	public Controller Style;

	public GImage backNormal;

	public GImage backGold;

	public GImage backSliver;

	public GImage n34;

	public GImage needle_gold;

	public GImage needle_normal;

	public GImage iconBackNormal;

	public GImage iconBackGold;

	public GLoader Icon;

	public UI_OffensiveInstanceZonesLevel InstanceZonesLevel;

	public GImage finishLogo;

	public GGraph SfxBack;

	public GList classListCopy;

	public GList classList;

	public GGroup n32;

	public GTextField LevelName;

	public const string URL = "ui://f4wr270rhbas3j";

	public static string Name = "UI_OffensiveCard";

	public static string GetURL()
	{
		return "ui://f4wr270rhbas3j";
	}

	public static UI_OffensiveCard CreateInstance()
	{
		return (UI_OffensiveCard)(object)UIPackage.CreateObject("InstanceZones", "OffensiveCard");
	}

	public static UI_OffensiveCard CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_OffensiveCard).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://f4wr270rhbas3j", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		//IL_0124: Unknown result type (might be due to invalid IL or missing references)
		//IL_012e: Expected O, but got Unknown
		//IL_013a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0144: Expected O, but got Unknown
		//IL_0150: Unknown result type (might be due to invalid IL or missing references)
		//IL_015a: Expected O, but got Unknown
		//IL_0166: Unknown result type (might be due to invalid IL or missing references)
		//IL_0170: Expected O, but got Unknown
		//IL_017c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0186: Expected O, but got Unknown
		//IL_0192: Unknown result type (might be due to invalid IL or missing references)
		//IL_019c: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		PageController = ((GComponent)this).GetController("PageController");
		Selected = ((GComponent)this).GetController("Selected");
		Style = ((GComponent)this).GetController("Style");
		backNormal = (GImage)((GComponent)this).GetChild("backNormal");
		backGold = (GImage)((GComponent)this).GetChild("backGold");
		backSliver = (GImage)((GComponent)this).GetChild("backSliver");
		n34 = (GImage)((GComponent)this).GetChild("n34");
		needle_gold = (GImage)((GComponent)this).GetChild("needle_gold");
		needle_normal = (GImage)((GComponent)this).GetChild("needle_normal");
		iconBackNormal = (GImage)((GComponent)this).GetChild("iconBackNormal");
		iconBackGold = (GImage)((GComponent)this).GetChild("iconBackGold");
		Icon = (GLoader)((GComponent)this).GetChild("Icon");
		InstanceZonesLevel = (UI_OffensiveInstanceZonesLevel)(object)((GComponent)this).GetChild("InstanceZonesLevel");
		finishLogo = (GImage)((GComponent)this).GetChild("finishLogo");
		SfxBack = (GGraph)((GComponent)this).GetChild("SfxBack");
		classListCopy = (GList)((GComponent)this).GetChild("classListCopy");
		classList = (GList)((GComponent)this).GetChild("classList");
		n32 = (GGroup)((GComponent)this).GetChild("n32");
		LevelName = (GTextField)((GComponent)this).GetChild("LevelName");
	}
}
