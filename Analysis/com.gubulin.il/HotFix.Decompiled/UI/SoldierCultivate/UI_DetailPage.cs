using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.SoldierCultivate;

public class UI_DetailPage : GComponent
{
	public GImage back;

	public GTextField n1;

	public GTextField n2;

	public GTextField n3;

	public GTextField n4;

	public GTextField n5;

	public GTextField n6;

	public GTextField n7;

	public GTextField n8;

	public GTextField n9;

	public GTextField n10;

	public GTextField n11;

	public GTextField n12;

	public GTextField n13;

	public GTextField n14;

	public GTextField Deta_HealthGrow_t;

	public GTextField Deta_AttackGrow_t;

	public GTextField Deta_DefenseGrow_t;

	public GTextField Deta_AttackType_t;

	public GTextField Deta_DefenceType_t;

	public GTextField Deta_Health_t;

	public GTextField Deta_Attack_t;

	public GTextField Deta_Defence_t;

	public GTextField Deta_AttackSpeed_t;

	public GTextField Deta_MoveSpeed_t;

	public GTextField Deta_Crit_t;

	public GTextField Deta_CritDamage_t;

	public GTextField Deta_Hitrate_t;

	public GTextField Deta_Dodgehate_t;

	public GTextField n30;

	public GTextField Deta_Time_t;

	public GTextField n32;

	public GTextField Deta_AttackDistance_t;

	public GGroup content;

	public GButton CloseDetailpage;

	public Transition showSelf;

	public const string URL = "ui://7dantnbinnzi5z";

	public static string Name = "UI_DetailPage";

	public static string GetURL()
	{
		return "ui://7dantnbinnzi5z";
	}

	public static UI_DetailPage CreateInstance()
	{
		return (UI_DetailPage)(object)UIPackage.CreateObject("SoldierCultivate", "DetailPage");
	}

	public static UI_DetailPage CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_DetailPage).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://7dantnbinnzi5z", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0035: Expected O, but got Unknown
		//IL_007e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0088: Expected O, but got Unknown
		//IL_00d1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00db: Expected O, but got Unknown
		//IL_0124: Unknown result type (might be due to invalid IL or missing references)
		//IL_012e: Expected O, but got Unknown
		//IL_0177: Unknown result type (might be due to invalid IL or missing references)
		//IL_0181: Expected O, but got Unknown
		//IL_01cc: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d6: Expected O, but got Unknown
		//IL_0221: Unknown result type (might be due to invalid IL or missing references)
		//IL_022b: Expected O, but got Unknown
		//IL_0276: Unknown result type (might be due to invalid IL or missing references)
		//IL_0280: Expected O, but got Unknown
		//IL_02cb: Unknown result type (might be due to invalid IL or missing references)
		//IL_02d5: Expected O, but got Unknown
		//IL_0320: Unknown result type (might be due to invalid IL or missing references)
		//IL_032a: Expected O, but got Unknown
		//IL_0375: Unknown result type (might be due to invalid IL or missing references)
		//IL_037f: Expected O, but got Unknown
		//IL_03ca: Unknown result type (might be due to invalid IL or missing references)
		//IL_03d4: Expected O, but got Unknown
		//IL_041f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0429: Expected O, but got Unknown
		//IL_0474: Unknown result type (might be due to invalid IL or missing references)
		//IL_047e: Expected O, but got Unknown
		//IL_04c9: Unknown result type (might be due to invalid IL or missing references)
		//IL_04d3: Expected O, but got Unknown
		//IL_051e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0528: Expected O, but got Unknown
		//IL_0573: Unknown result type (might be due to invalid IL or missing references)
		//IL_057d: Expected O, but got Unknown
		//IL_05c8: Unknown result type (might be due to invalid IL or missing references)
		//IL_05d2: Expected O, but got Unknown
		//IL_061d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0627: Expected O, but got Unknown
		//IL_0672: Unknown result type (might be due to invalid IL or missing references)
		//IL_067c: Expected O, but got Unknown
		//IL_06c7: Unknown result type (might be due to invalid IL or missing references)
		//IL_06d1: Expected O, but got Unknown
		//IL_071c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0726: Expected O, but got Unknown
		//IL_0771: Unknown result type (might be due to invalid IL or missing references)
		//IL_077b: Expected O, but got Unknown
		//IL_07c6: Unknown result type (might be due to invalid IL or missing references)
		//IL_07d0: Expected O, but got Unknown
		//IL_081b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0825: Expected O, but got Unknown
		//IL_0870: Unknown result type (might be due to invalid IL or missing references)
		//IL_087a: Expected O, but got Unknown
		//IL_08c5: Unknown result type (might be due to invalid IL or missing references)
		//IL_08cf: Expected O, but got Unknown
		//IL_091a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0924: Expected O, but got Unknown
		//IL_096f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0979: Expected O, but got Unknown
		//IL_09c4: Unknown result type (might be due to invalid IL or missing references)
		//IL_09ce: Expected O, but got Unknown
		//IL_0a19: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a23: Expected O, but got Unknown
		//IL_0a6e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a78: Expected O, but got Unknown
		//IL_0ac3: Unknown result type (might be due to invalid IL or missing references)
		//IL_0acd: Expected O, but got Unknown
		//IL_0ad9: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ae3: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		back = (GImage)((GComponent)this).GetChild("back");
		n1 = (GTextField)((GComponent)this).GetChild("n1");
		string id = "ui://7dantnbinnzi5z".Replace("ui://", "") + "-" + ((GObject)n1).id;
		((GObject)n1).text = LanguagesManager.GetDesc(id);
		n2 = (GTextField)((GComponent)this).GetChild("n2");
		string id2 = "ui://7dantnbinnzi5z".Replace("ui://", "") + "-" + ((GObject)n2).id;
		((GObject)n2).text = LanguagesManager.GetDesc(id2);
		n3 = (GTextField)((GComponent)this).GetChild("n3");
		string id3 = "ui://7dantnbinnzi5z".Replace("ui://", "") + "-" + ((GObject)n3).id;
		((GObject)n3).text = LanguagesManager.GetDesc(id3);
		n4 = (GTextField)((GComponent)this).GetChild("n4");
		string id4 = "ui://7dantnbinnzi5z".Replace("ui://", "") + "-" + ((GObject)n4).id;
		((GObject)n4).text = LanguagesManager.GetDesc(id4);
		n5 = (GTextField)((GComponent)this).GetChild("n5");
		string id5 = "ui://7dantnbinnzi5z".Replace("ui://", "") + "-" + ((GObject)n5).id;
		((GObject)n5).text = LanguagesManager.GetDesc(id5);
		n6 = (GTextField)((GComponent)this).GetChild("n6");
		string id6 = "ui://7dantnbinnzi5z".Replace("ui://", "") + "-" + ((GObject)n6).id;
		((GObject)n6).text = LanguagesManager.GetDesc(id6);
		n7 = (GTextField)((GComponent)this).GetChild("n7");
		string id7 = "ui://7dantnbinnzi5z".Replace("ui://", "") + "-" + ((GObject)n7).id;
		((GObject)n7).text = LanguagesManager.GetDesc(id7);
		n8 = (GTextField)((GComponent)this).GetChild("n8");
		string id8 = "ui://7dantnbinnzi5z".Replace("ui://", "") + "-" + ((GObject)n8).id;
		((GObject)n8).text = LanguagesManager.GetDesc(id8);
		n9 = (GTextField)((GComponent)this).GetChild("n9");
		string id9 = "ui://7dantnbinnzi5z".Replace("ui://", "") + "-" + ((GObject)n9).id;
		((GObject)n9).text = LanguagesManager.GetDesc(id9);
		n10 = (GTextField)((GComponent)this).GetChild("n10");
		string id10 = "ui://7dantnbinnzi5z".Replace("ui://", "") + "-" + ((GObject)n10).id;
		((GObject)n10).text = LanguagesManager.GetDesc(id10);
		n11 = (GTextField)((GComponent)this).GetChild("n11");
		string id11 = "ui://7dantnbinnzi5z".Replace("ui://", "") + "-" + ((GObject)n11).id;
		((GObject)n11).text = LanguagesManager.GetDesc(id11);
		n12 = (GTextField)((GComponent)this).GetChild("n12");
		string id12 = "ui://7dantnbinnzi5z".Replace("ui://", "") + "-" + ((GObject)n12).id;
		((GObject)n12).text = LanguagesManager.GetDesc(id12);
		n13 = (GTextField)((GComponent)this).GetChild("n13");
		string id13 = "ui://7dantnbinnzi5z".Replace("ui://", "") + "-" + ((GObject)n13).id;
		((GObject)n13).text = LanguagesManager.GetDesc(id13);
		n14 = (GTextField)((GComponent)this).GetChild("n14");
		string id14 = "ui://7dantnbinnzi5z".Replace("ui://", "") + "-" + ((GObject)n14).id;
		((GObject)n14).text = LanguagesManager.GetDesc(id14);
		Deta_HealthGrow_t = (GTextField)((GComponent)this).GetChild("Deta_HealthGrow_t");
		string id15 = "ui://7dantnbinnzi5z".Replace("ui://", "") + "-" + ((GObject)Deta_HealthGrow_t).id;
		((GObject)Deta_HealthGrow_t).text = LanguagesManager.GetDesc(id15);
		Deta_AttackGrow_t = (GTextField)((GComponent)this).GetChild("Deta_AttackGrow_t");
		string id16 = "ui://7dantnbinnzi5z".Replace("ui://", "") + "-" + ((GObject)Deta_AttackGrow_t).id;
		((GObject)Deta_AttackGrow_t).text = LanguagesManager.GetDesc(id16);
		Deta_DefenseGrow_t = (GTextField)((GComponent)this).GetChild("Deta_DefenseGrow_t");
		string id17 = "ui://7dantnbinnzi5z".Replace("ui://", "") + "-" + ((GObject)Deta_DefenseGrow_t).id;
		((GObject)Deta_DefenseGrow_t).text = LanguagesManager.GetDesc(id17);
		Deta_AttackType_t = (GTextField)((GComponent)this).GetChild("Deta_AttackType_t");
		string id18 = "ui://7dantnbinnzi5z".Replace("ui://", "") + "-" + ((GObject)Deta_AttackType_t).id;
		((GObject)Deta_AttackType_t).text = LanguagesManager.GetDesc(id18);
		Deta_DefenceType_t = (GTextField)((GComponent)this).GetChild("Deta_DefenceType_t");
		string id19 = "ui://7dantnbinnzi5z".Replace("ui://", "") + "-" + ((GObject)Deta_DefenceType_t).id;
		((GObject)Deta_DefenceType_t).text = LanguagesManager.GetDesc(id19);
		Deta_Health_t = (GTextField)((GComponent)this).GetChild("Deta_Health_t");
		string id20 = "ui://7dantnbinnzi5z".Replace("ui://", "") + "-" + ((GObject)Deta_Health_t).id;
		((GObject)Deta_Health_t).text = LanguagesManager.GetDesc(id20);
		Deta_Attack_t = (GTextField)((GComponent)this).GetChild("Deta_Attack_t");
		string id21 = "ui://7dantnbinnzi5z".Replace("ui://", "") + "-" + ((GObject)Deta_Attack_t).id;
		((GObject)Deta_Attack_t).text = LanguagesManager.GetDesc(id21);
		Deta_Defence_t = (GTextField)((GComponent)this).GetChild("Deta_Defence_t");
		string id22 = "ui://7dantnbinnzi5z".Replace("ui://", "") + "-" + ((GObject)Deta_Defence_t).id;
		((GObject)Deta_Defence_t).text = LanguagesManager.GetDesc(id22);
		Deta_AttackSpeed_t = (GTextField)((GComponent)this).GetChild("Deta_AttackSpeed_t");
		string id23 = "ui://7dantnbinnzi5z".Replace("ui://", "") + "-" + ((GObject)Deta_AttackSpeed_t).id;
		((GObject)Deta_AttackSpeed_t).text = LanguagesManager.GetDesc(id23);
		Deta_MoveSpeed_t = (GTextField)((GComponent)this).GetChild("Deta_MoveSpeed_t");
		string id24 = "ui://7dantnbinnzi5z".Replace("ui://", "") + "-" + ((GObject)Deta_MoveSpeed_t).id;
		((GObject)Deta_MoveSpeed_t).text = LanguagesManager.GetDesc(id24);
		Deta_Crit_t = (GTextField)((GComponent)this).GetChild("Deta_Crit_t");
		string id25 = "ui://7dantnbinnzi5z".Replace("ui://", "") + "-" + ((GObject)Deta_Crit_t).id;
		((GObject)Deta_Crit_t).text = LanguagesManager.GetDesc(id25);
		Deta_CritDamage_t = (GTextField)((GComponent)this).GetChild("Deta_CritDamage_t");
		string id26 = "ui://7dantnbinnzi5z".Replace("ui://", "") + "-" + ((GObject)Deta_CritDamage_t).id;
		((GObject)Deta_CritDamage_t).text = LanguagesManager.GetDesc(id26);
		Deta_Hitrate_t = (GTextField)((GComponent)this).GetChild("Deta_Hitrate_t");
		string id27 = "ui://7dantnbinnzi5z".Replace("ui://", "") + "-" + ((GObject)Deta_Hitrate_t).id;
		((GObject)Deta_Hitrate_t).text = LanguagesManager.GetDesc(id27);
		Deta_Dodgehate_t = (GTextField)((GComponent)this).GetChild("Deta_Dodgehate_t");
		string id28 = "ui://7dantnbinnzi5z".Replace("ui://", "") + "-" + ((GObject)Deta_Dodgehate_t).id;
		((GObject)Deta_Dodgehate_t).text = LanguagesManager.GetDesc(id28);
		n30 = (GTextField)((GComponent)this).GetChild("n30");
		string id29 = "ui://7dantnbinnzi5z".Replace("ui://", "") + "-" + ((GObject)n30).id;
		((GObject)n30).text = LanguagesManager.GetDesc(id29);
		Deta_Time_t = (GTextField)((GComponent)this).GetChild("Deta_Time_t");
		string id30 = "ui://7dantnbinnzi5z".Replace("ui://", "") + "-" + ((GObject)Deta_Time_t).id;
		((GObject)Deta_Time_t).text = LanguagesManager.GetDesc(id30);
		n32 = (GTextField)((GComponent)this).GetChild("n32");
		string id31 = "ui://7dantnbinnzi5z".Replace("ui://", "") + "-" + ((GObject)n32).id;
		((GObject)n32).text = LanguagesManager.GetDesc(id31);
		Deta_AttackDistance_t = (GTextField)((GComponent)this).GetChild("Deta_AttackDistance_t");
		string id32 = "ui://7dantnbinnzi5z".Replace("ui://", "") + "-" + ((GObject)Deta_AttackDistance_t).id;
		((GObject)Deta_AttackDistance_t).text = LanguagesManager.GetDesc(id32);
		content = (GGroup)((GComponent)this).GetChild("content");
		CloseDetailpage = (GButton)((GComponent)this).GetChild("CloseDetailpage");
		showSelf = ((GComponent)this).GetTransition("showSelf");
	}
}
