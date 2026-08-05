using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.LegendItemCultivation;

public class UI_SoldierPromotionDialog : GComponent
{
	public Controller PageController;

	public Controller Status;

	public GImage background;

	public GGraph line1;

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

	public GGraph line2;

	public GGraph baseSpine;

	public GGraph Spine;

	public GGraph maskSpine;

	public GGroup SoldierSpineGroup;

	public const string URL = "ui://b9wlonaqlud8j";

	public static string Name = "UI_SoldierPromotionDialog";

	public static string GetURL()
	{
		return "ui://b9wlonaqlud8j";
	}

	public static UI_SoldierPromotionDialog CreateInstance()
	{
		return (UI_SoldierPromotionDialog)(object)UIPackage.CreateObject("LegendItemCultivation", "SoldierPromotionDialog");
	}

	public static UI_SoldierPromotionDialog CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_SoldierPromotionDialog).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://b9wlonaqlud8j", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		//IL_00b6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c0: Expected O, but got Unknown
		//IL_00cc: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d6: Expected O, but got Unknown
		//IL_00e2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ec: Expected O, but got Unknown
		//IL_0135: Unknown result type (might be due to invalid IL or missing references)
		//IL_013f: Expected O, but got Unknown
		//IL_014b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0155: Expected O, but got Unknown
		//IL_019e: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a8: Expected O, but got Unknown
		//IL_01b4: Unknown result type (might be due to invalid IL or missing references)
		//IL_01be: Expected O, but got Unknown
		//IL_01ca: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d4: Expected O, but got Unknown
		//IL_021d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0227: Expected O, but got Unknown
		//IL_0233: Unknown result type (might be due to invalid IL or missing references)
		//IL_023d: Expected O, but got Unknown
		//IL_0288: Unknown result type (might be due to invalid IL or missing references)
		//IL_0292: Expected O, but got Unknown
		//IL_029e: Unknown result type (might be due to invalid IL or missing references)
		//IL_02a8: Expected O, but got Unknown
		//IL_02b4: Unknown result type (might be due to invalid IL or missing references)
		//IL_02be: Expected O, but got Unknown
		//IL_0309: Unknown result type (might be due to invalid IL or missing references)
		//IL_0313: Expected O, but got Unknown
		//IL_031f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0329: Expected O, but got Unknown
		//IL_0335: Unknown result type (might be due to invalid IL or missing references)
		//IL_033f: Expected O, but got Unknown
		//IL_034b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0355: Expected O, but got Unknown
		//IL_0361: Unknown result type (might be due to invalid IL or missing references)
		//IL_036b: Expected O, but got Unknown
		//IL_0377: Unknown result type (might be due to invalid IL or missing references)
		//IL_0381: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		PageController = ((GComponent)this).GetController("PageController");
		Status = ((GComponent)this).GetController("Status");
		background = (GImage)((GComponent)this).GetChild("background");
		line1 = (GGraph)((GComponent)this).GetChild("line1");
		CurAttackGrow = (GTextField)((GComponent)this).GetChild("CurAttackGrow");
		string id = "ui://b9wlonaqlud8j".Replace("ui://", "") + "-" + ((GObject)CurAttackGrow).id;
		((GObject)CurAttackGrow).text = LanguagesManager.GetDesc(id);
		n4 = (GImage)((GComponent)this).GetChild("n4");
		n9 = (GImage)((GComponent)this).GetChild("n9");
		NextAttackGrow = (GTextField)((GComponent)this).GetChild("NextAttackGrow");
		string id2 = "ui://b9wlonaqlud8j".Replace("ui://", "") + "-" + ((GObject)NextAttackGrow).id;
		((GObject)NextAttackGrow).text = LanguagesManager.GetDesc(id2);
		n13 = (GGroup)((GComponent)this).GetChild("n13");
		CurDefenseGrow = (GTextField)((GComponent)this).GetChild("CurDefenseGrow");
		string id3 = "ui://b9wlonaqlud8j".Replace("ui://", "") + "-" + ((GObject)CurDefenseGrow).id;
		((GObject)CurDefenseGrow).text = LanguagesManager.GetDesc(id3);
		n5 = (GImage)((GComponent)this).GetChild("n5");
		n10 = (GImage)((GComponent)this).GetChild("n10");
		NextDefenseGrow = (GTextField)((GComponent)this).GetChild("NextDefenseGrow");
		string id4 = "ui://b9wlonaqlud8j".Replace("ui://", "") + "-" + ((GObject)NextDefenseGrow).id;
		((GObject)NextDefenseGrow).text = LanguagesManager.GetDesc(id4);
		n15 = (GGroup)((GComponent)this).GetChild("n15");
		CurHealthGrow = (GTextField)((GComponent)this).GetChild("CurHealthGrow");
		string id5 = "ui://b9wlonaqlud8j".Replace("ui://", "") + "-" + ((GObject)CurHealthGrow).id;
		((GObject)CurHealthGrow).text = LanguagesManager.GetDesc(id5);
		n6 = (GImage)((GComponent)this).GetChild("n6");
		n11 = (GImage)((GComponent)this).GetChild("n11");
		NextHealthGrow = (GTextField)((GComponent)this).GetChild("NextHealthGrow");
		string id6 = "ui://b9wlonaqlud8j".Replace("ui://", "") + "-" + ((GObject)NextHealthGrow).id;
		((GObject)NextHealthGrow).text = LanguagesManager.GetDesc(id6);
		n17 = (GGroup)((GComponent)this).GetChild("n17");
		line2 = (GGraph)((GComponent)this).GetChild("line2");
		baseSpine = (GGraph)((GComponent)this).GetChild("baseSpine");
		Spine = (GGraph)((GComponent)this).GetChild("Spine");
		maskSpine = (GGraph)((GComponent)this).GetChild("maskSpine");
		SoldierSpineGroup = (GGroup)((GComponent)this).GetChild("SoldierSpineGroup");
	}
}
