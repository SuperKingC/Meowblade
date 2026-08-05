using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.IslandComeAgain;

public class UI_CampBattleInfo : GComponent
{
	public Controller Camp;

	public Controller Winner;

	public Controller Type;

	public GImage n0;

	public GImage n1;

	public GImage n4;

	public GImage n7;

	public GImage n6;

	public GImage n5;

	public GGraph n11;

	public GImage n2;

	public GImage n3;

	public GLoader Logo;

	public GImage n9;

	public GTextField n10;

	public GTextField n12;

	public GTextField CampScore;

	public GList UserBattleInfo;

	public const string URL = "ui://k2sprg26uctj87";

	public static string Name = "UI_CampBattleInfo";

	public static string GetURL()
	{
		return "ui://k2sprg26uctj87";
	}

	public static UI_CampBattleInfo CreateInstance()
	{
		return (UI_CampBattleInfo)(object)UIPackage.CreateObject("IslandComeAgain", "CampBattleInfo");
	}

	public static UI_CampBattleInfo CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_CampBattleInfo).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://k2sprg26uctj87", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		//IL_01a3: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ad: Expected O, but got Unknown
		//IL_01b9: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c3: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		Camp = ((GComponent)this).GetController("Camp");
		Winner = ((GComponent)this).GetController("Winner");
		Type = ((GComponent)this).GetController("Type");
		n0 = (GImage)((GComponent)this).GetChild("n0");
		n1 = (GImage)((GComponent)this).GetChild("n1");
		n4 = (GImage)((GComponent)this).GetChild("n4");
		n7 = (GImage)((GComponent)this).GetChild("n7");
		n6 = (GImage)((GComponent)this).GetChild("n6");
		n5 = (GImage)((GComponent)this).GetChild("n5");
		n11 = (GGraph)((GComponent)this).GetChild("n11");
		n2 = (GImage)((GComponent)this).GetChild("n2");
		n3 = (GImage)((GComponent)this).GetChild("n3");
		Logo = (GLoader)((GComponent)this).GetChild("Logo");
		n9 = (GImage)((GComponent)this).GetChild("n9");
		n10 = (GTextField)((GComponent)this).GetChild("n10");
		string id = "ui://k2sprg26uctj87".Replace("ui://", "") + "-" + ((GObject)n10).id;
		((GObject)n10).text = LanguagesManager.GetDesc(id);
		n12 = (GTextField)((GComponent)this).GetChild("n12");
		CampScore = (GTextField)((GComponent)this).GetChild("CampScore");
		UserBattleInfo = (GList)((GComponent)this).GetChild("UserBattleInfo");
	}
}
