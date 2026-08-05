using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGExchange3;

public class UI_btn_Formula : GButton
{
	public Controller button;

	public Controller IsShowRace;

	public Controller Rarity;

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

	public GTextField n105;

	public GTextField ForgeScrollCount;

	public const string URL = "ui://tt2iq07oj1h834";

	public static string Name = "UI_btn_Formula";

	public static string GetURL()
	{
		return "ui://tt2iq07oj1h834";
	}

	public static UI_btn_Formula CreateInstance()
	{
		return (UI_btn_Formula)(object)UIPackage.CreateObject("GvGExchange3", "btn_Formula");
	}

	public static UI_btn_Formula CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_btn_Formula).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://tt2iq07oj1h834", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		//IL_013a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0144: Expected O, but got Unknown
		//IL_018d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0197: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		button = ((GComponent)this).GetController("button");
		IsShowRace = ((GComponent)this).GetController("IsShowRace");
		Rarity = ((GComponent)this).GetController("Rarity");
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
		n105 = (GTextField)((GComponent)this).GetChild("n105");
		string id = "ui://tt2iq07oj1h834".Replace("ui://", "") + "-" + ((GObject)n105).id;
		((GObject)n105).text = LanguagesManager.GetDesc(id);
		ForgeScrollCount = (GTextField)((GComponent)this).GetChild("ForgeScrollCount");
	}
}
