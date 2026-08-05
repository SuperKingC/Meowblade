using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.SoldierCultivate;

public class UI_SoldierPromotionDialog : GComponent
{
	public Controller PageController;

	public Controller Status;

	public GImage background;

	public GGraph line1;

	public GList nextLevelStarListBack;

	public GList nextLevelStarList;

	public GImage n25;

	public GGroup n24;

	public GTextField CurAttackGrow;

	public GImage n4;

	public GImage n9;

	public GTextField NextAttackGrow;

	public GGroup n13;

	public GTextField CurDefenseGrow;

	public GImage n5;

	public GImage n10;

	public GTextField NextDefenseGrow;

	public GGroup n15;

	public GTextField CurHealthGrow;

	public GImage n6;

	public GImage n11;

	public GTextField NextHealthGrow;

	public GGroup n17;

	public GImage n7;

	public GLoader EvolevelIcon;

	public GTextField EvoLevel;

	public GGroup n21;

	public GTextField n26;

	public GImage n27;

	public GComponent curPotential;

	public GComponent nextPotential;

	public GGroup n30;

	public GGraph line2;

	public GTextField dengj;

	public GImage n46;

	public GTextField curLevelLimit;

	public GTextField nextLevelLimit;

	public GImage n50;

	public GGroup n51;

	public GGraph baseSpine;

	public GGraph Spine;

	public GGraph maskSpine;

	public GGroup SoldierSpineGroup;

	public GImage n52;

	public const string URL = "ui://7dantnbih7os72";

	public static string Name = "UI_SoldierPromotionDialog";

	public static string GetURL()
	{
		return "ui://7dantnbih7os72";
	}

	public static UI_SoldierPromotionDialog CreateInstance()
	{
		return (UI_SoldierPromotionDialog)(object)UIPackage.CreateObject("SoldierCultivate", "SoldierPromotionDialog");
	}

	public static UI_SoldierPromotionDialog CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_SoldierPromotionDialog).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://7dantnbih7os72", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		//IL_01f6: Unknown result type (might be due to invalid IL or missing references)
		//IL_0200: Expected O, but got Unknown
		//IL_020c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0216: Expected O, but got Unknown
		//IL_0222: Unknown result type (might be due to invalid IL or missing references)
		//IL_022c: Expected O, but got Unknown
		//IL_0275: Unknown result type (might be due to invalid IL or missing references)
		//IL_027f: Expected O, but got Unknown
		//IL_028b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0295: Expected O, but got Unknown
		//IL_02e0: Unknown result type (might be due to invalid IL or missing references)
		//IL_02ea: Expected O, but got Unknown
		//IL_02f6: Unknown result type (might be due to invalid IL or missing references)
		//IL_0300: Expected O, but got Unknown
		//IL_030c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0316: Expected O, but got Unknown
		//IL_0361: Unknown result type (might be due to invalid IL or missing references)
		//IL_036b: Expected O, but got Unknown
		//IL_0377: Unknown result type (might be due to invalid IL or missing references)
		//IL_0381: Expected O, but got Unknown
		//IL_038d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0397: Expected O, but got Unknown
		//IL_03a3: Unknown result type (might be due to invalid IL or missing references)
		//IL_03ad: Expected O, but got Unknown
		//IL_03f8: Unknown result type (might be due to invalid IL or missing references)
		//IL_0402: Expected O, but got Unknown
		//IL_040e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0418: Expected O, but got Unknown
		//IL_0463: Unknown result type (might be due to invalid IL or missing references)
		//IL_046d: Expected O, but got Unknown
		//IL_0479: Unknown result type (might be due to invalid IL or missing references)
		//IL_0483: Expected O, but got Unknown
		//IL_048f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0499: Expected O, but got Unknown
		//IL_04a5: Unknown result type (might be due to invalid IL or missing references)
		//IL_04af: Expected O, but got Unknown
		//IL_04bb: Unknown result type (might be due to invalid IL or missing references)
		//IL_04c5: Expected O, but got Unknown
		//IL_04d1: Unknown result type (might be due to invalid IL or missing references)
		//IL_04db: Expected O, but got Unknown
		//IL_0526: Unknown result type (might be due to invalid IL or missing references)
		//IL_0530: Expected O, but got Unknown
		//IL_053c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0546: Expected O, but got Unknown
		//IL_0591: Unknown result type (might be due to invalid IL or missing references)
		//IL_059b: Expected O, but got Unknown
		//IL_05e6: Unknown result type (might be due to invalid IL or missing references)
		//IL_05f0: Expected O, but got Unknown
		//IL_05fc: Unknown result type (might be due to invalid IL or missing references)
		//IL_0606: Expected O, but got Unknown
		//IL_0612: Unknown result type (might be due to invalid IL or missing references)
		//IL_061c: Expected O, but got Unknown
		//IL_0628: Unknown result type (might be due to invalid IL or missing references)
		//IL_0632: Expected O, but got Unknown
		//IL_063e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0648: Expected O, but got Unknown
		//IL_0654: Unknown result type (might be due to invalid IL or missing references)
		//IL_065e: Expected O, but got Unknown
		//IL_066a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0674: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		PageController = ((GComponent)this).GetController("PageController");
		Status = ((GComponent)this).GetController("Status");
		background = (GImage)((GComponent)this).GetChild("background");
		line1 = (GGraph)((GComponent)this).GetChild("line1");
		nextLevelStarListBack = (GList)((GComponent)this).GetChild("nextLevelStarListBack");
		nextLevelStarList = (GList)((GComponent)this).GetChild("nextLevelStarList");
		n25 = (GImage)((GComponent)this).GetChild("n25");
		n24 = (GGroup)((GComponent)this).GetChild("n24");
		CurAttackGrow = (GTextField)((GComponent)this).GetChild("CurAttackGrow");
		string id = "ui://7dantnbih7os72".Replace("ui://", "") + "-" + ((GObject)CurAttackGrow).id;
		((GObject)CurAttackGrow).text = LanguagesManager.GetDesc(id);
		n4 = (GImage)((GComponent)this).GetChild("n4");
		n9 = (GImage)((GComponent)this).GetChild("n9");
		NextAttackGrow = (GTextField)((GComponent)this).GetChild("NextAttackGrow");
		string id2 = "ui://7dantnbih7os72".Replace("ui://", "") + "-" + ((GObject)NextAttackGrow).id;
		((GObject)NextAttackGrow).text = LanguagesManager.GetDesc(id2);
		n13 = (GGroup)((GComponent)this).GetChild("n13");
		CurDefenseGrow = (GTextField)((GComponent)this).GetChild("CurDefenseGrow");
		string id3 = "ui://7dantnbih7os72".Replace("ui://", "") + "-" + ((GObject)CurDefenseGrow).id;
		((GObject)CurDefenseGrow).text = LanguagesManager.GetDesc(id3);
		n5 = (GImage)((GComponent)this).GetChild("n5");
		n10 = (GImage)((GComponent)this).GetChild("n10");
		NextDefenseGrow = (GTextField)((GComponent)this).GetChild("NextDefenseGrow");
		string id4 = "ui://7dantnbih7os72".Replace("ui://", "") + "-" + ((GObject)NextDefenseGrow).id;
		((GObject)NextDefenseGrow).text = LanguagesManager.GetDesc(id4);
		n15 = (GGroup)((GComponent)this).GetChild("n15");
		CurHealthGrow = (GTextField)((GComponent)this).GetChild("CurHealthGrow");
		string id5 = "ui://7dantnbih7os72".Replace("ui://", "") + "-" + ((GObject)CurHealthGrow).id;
		((GObject)CurHealthGrow).text = LanguagesManager.GetDesc(id5);
		n6 = (GImage)((GComponent)this).GetChild("n6");
		n11 = (GImage)((GComponent)this).GetChild("n11");
		NextHealthGrow = (GTextField)((GComponent)this).GetChild("NextHealthGrow");
		string id6 = "ui://7dantnbih7os72".Replace("ui://", "") + "-" + ((GObject)NextHealthGrow).id;
		((GObject)NextHealthGrow).text = LanguagesManager.GetDesc(id6);
		n17 = (GGroup)((GComponent)this).GetChild("n17");
		n7 = (GImage)((GComponent)this).GetChild("n7");
		EvolevelIcon = (GLoader)((GComponent)this).GetChild("EvolevelIcon");
		EvoLevel = (GTextField)((GComponent)this).GetChild("EvoLevel");
		string id7 = "ui://7dantnbih7os72".Replace("ui://", "") + "-" + ((GObject)EvoLevel).id;
		((GObject)EvoLevel).text = LanguagesManager.GetDesc(id7);
		n21 = (GGroup)((GComponent)this).GetChild("n21");
		n26 = (GTextField)((GComponent)this).GetChild("n26");
		string id8 = "ui://7dantnbih7os72".Replace("ui://", "") + "-" + ((GObject)n26).id;
		((GObject)n26).text = LanguagesManager.GetDesc(id8);
		n27 = (GImage)((GComponent)this).GetChild("n27");
		curPotential = (GComponent)((GComponent)this).GetChild("curPotential");
		nextPotential = (GComponent)((GComponent)this).GetChild("nextPotential");
		n30 = (GGroup)((GComponent)this).GetChild("n30");
		line2 = (GGraph)((GComponent)this).GetChild("line2");
		dengj = (GTextField)((GComponent)this).GetChild("dengj");
		string id9 = "ui://7dantnbih7os72".Replace("ui://", "") + "-" + ((GObject)dengj).id;
		((GObject)dengj).text = LanguagesManager.GetDesc(id9);
		n46 = (GImage)((GComponent)this).GetChild("n46");
		curLevelLimit = (GTextField)((GComponent)this).GetChild("curLevelLimit");
		string id10 = "ui://7dantnbih7os72".Replace("ui://", "") + "-" + ((GObject)curLevelLimit).id;
		((GObject)curLevelLimit).text = LanguagesManager.GetDesc(id10);
		nextLevelLimit = (GTextField)((GComponent)this).GetChild("nextLevelLimit");
		string id11 = "ui://7dantnbih7os72".Replace("ui://", "") + "-" + ((GObject)nextLevelLimit).id;
		((GObject)nextLevelLimit).text = LanguagesManager.GetDesc(id11);
		n50 = (GImage)((GComponent)this).GetChild("n50");
		n51 = (GGroup)((GComponent)this).GetChild("n51");
		baseSpine = (GGraph)((GComponent)this).GetChild("baseSpine");
		Spine = (GGraph)((GComponent)this).GetChild("Spine");
		maskSpine = (GGraph)((GComponent)this).GetChild("maskSpine");
		SoldierSpineGroup = (GGroup)((GComponent)this).GetChild("SoldierSpineGroup");
		n52 = (GImage)((GComponent)this).GetChild("n52");
	}
}
