using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGOEMForge3;

public class UI_com_FormulaOemForgeHelp : GComponent
{
	public Controller RateLevel;

	public Controller hasTalent;

	public GImage n4;

	public GTextField BonusCnt;

	public GTextField n2;

	public GTextField qulityDes;

	public GTextField n9;

	public GTextField n5;

	public GImage talentIcon;

	public GTextField talentDes;

	public GTextField n17;

	public GGroup talent;

	public GImage n11;

	public const string URL = "ui://hotvoz3prne564";

	public static string Name = "UI_com_FormulaOemForgeHelp";

	public static string GetURL()
	{
		return "ui://hotvoz3prne564";
	}

	public static UI_com_FormulaOemForgeHelp CreateInstance()
	{
		return (UI_com_FormulaOemForgeHelp)(object)UIPackage.CreateObject("GvGOEMForge3", "com_FormulaOemForgeHelp");
	}

	public static UI_com_FormulaOemForgeHelp CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_FormulaOemForgeHelp).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://hotvoz3prne564", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		//IL_0109: Unknown result type (might be due to invalid IL or missing references)
		//IL_0113: Expected O, but got Unknown
		//IL_015c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0166: Expected O, but got Unknown
		//IL_01af: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b9: Expected O, but got Unknown
		//IL_01c5: Unknown result type (might be due to invalid IL or missing references)
		//IL_01cf: Expected O, but got Unknown
		//IL_021a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0224: Expected O, but got Unknown
		//IL_026f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0279: Expected O, but got Unknown
		//IL_0285: Unknown result type (might be due to invalid IL or missing references)
		//IL_028f: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		RateLevel = ((GComponent)this).GetController("RateLevel");
		hasTalent = ((GComponent)this).GetController("hasTalent");
		n4 = (GImage)((GComponent)this).GetChild("n4");
		BonusCnt = (GTextField)((GComponent)this).GetChild("BonusCnt");
		n2 = (GTextField)((GComponent)this).GetChild("n2");
		string id = "ui://hotvoz3prne564".Replace("ui://", "") + "-" + ((GObject)n2).id;
		((GObject)n2).text = LanguagesManager.GetDesc(id);
		qulityDes = (GTextField)((GComponent)this).GetChild("qulityDes");
		string id2 = "ui://hotvoz3prne564".Replace("ui://", "") + "-" + ((GObject)qulityDes).id;
		((GObject)qulityDes).text = LanguagesManager.GetDesc(id2);
		n9 = (GTextField)((GComponent)this).GetChild("n9");
		string id3 = "ui://hotvoz3prne564".Replace("ui://", "") + "-" + ((GObject)n9).id;
		((GObject)n9).text = LanguagesManager.GetDesc(id3);
		n5 = (GTextField)((GComponent)this).GetChild("n5");
		string id4 = "ui://hotvoz3prne564".Replace("ui://", "") + "-" + ((GObject)n5).id;
		((GObject)n5).text = LanguagesManager.GetDesc(id4);
		talentIcon = (GImage)((GComponent)this).GetChild("talentIcon");
		talentDes = (GTextField)((GComponent)this).GetChild("talentDes");
		string id5 = "ui://hotvoz3prne564".Replace("ui://", "") + "-" + ((GObject)talentDes).id;
		((GObject)talentDes).text = LanguagesManager.GetDesc(id5);
		n17 = (GTextField)((GComponent)this).GetChild("n17");
		string id6 = "ui://hotvoz3prne564".Replace("ui://", "") + "-" + ((GObject)n17).id;
		((GObject)n17).text = LanguagesManager.GetDesc(id6);
		talent = (GGroup)((GComponent)this).GetChild("talent");
		n11 = (GImage)((GComponent)this).GetChild("n11");
	}
}
