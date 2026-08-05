using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGExchange3;

public class UI_com_MyFormulaOemMission : GComponent
{
	public Controller Status;

	public Controller Type;

	public Controller CountColor;

	public GImage n29;

	public GImage n14;

	public GTextField n15;

	public GImage n28;

	public GImage n26;

	public GImage n27;

	public GImage n19;

	public GComponent Formula;

	public GTextField n1;

	public GTextField Countdown;

	public GTextField n6;

	public GTextField n7;

	public GTextField n9;

	public GTextField n10;

	public GTextField n23;

	public GTextField RemainingCount;

	public UI_com_FormulaOemRewardCount RewardCount;

	public GImage n20;

	public GImage n21;

	public GGroup n13;

	public const string URL = "ui://tt2iq07osmtg2x";

	public static string Name = "UI_com_MyFormulaOemMission";

	public static string GetURL()
	{
		return "ui://tt2iq07osmtg2x";
	}

	public static UI_com_MyFormulaOemMission CreateInstance()
	{
		return (UI_com_MyFormulaOemMission)(object)UIPackage.CreateObject("GvGExchange3", "com_MyFormulaOemMission");
	}

	public static UI_com_MyFormulaOemMission CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_MyFormulaOemMission).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://tt2iq07osmtg2x", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		//IL_00c7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d1: Expected O, but got Unknown
		//IL_00dd: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e7: Expected O, but got Unknown
		//IL_00f3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fd: Expected O, but got Unknown
		//IL_0109: Unknown result type (might be due to invalid IL or missing references)
		//IL_0113: Expected O, but got Unknown
		//IL_011f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0129: Expected O, but got Unknown
		//IL_0135: Unknown result type (might be due to invalid IL or missing references)
		//IL_013f: Expected O, but got Unknown
		//IL_0188: Unknown result type (might be due to invalid IL or missing references)
		//IL_0192: Expected O, but got Unknown
		//IL_019e: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a8: Expected O, but got Unknown
		//IL_01f1: Unknown result type (might be due to invalid IL or missing references)
		//IL_01fb: Expected O, but got Unknown
		//IL_0244: Unknown result type (might be due to invalid IL or missing references)
		//IL_024e: Expected O, but got Unknown
		//IL_0299: Unknown result type (might be due to invalid IL or missing references)
		//IL_02a3: Expected O, but got Unknown
		//IL_02ee: Unknown result type (might be due to invalid IL or missing references)
		//IL_02f8: Expected O, but got Unknown
		//IL_0343: Unknown result type (might be due to invalid IL or missing references)
		//IL_034d: Expected O, but got Unknown
		//IL_036f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0379: Expected O, but got Unknown
		//IL_0385: Unknown result type (might be due to invalid IL or missing references)
		//IL_038f: Expected O, but got Unknown
		//IL_039b: Unknown result type (might be due to invalid IL or missing references)
		//IL_03a5: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		Status = ((GComponent)this).GetController("Status");
		Type = ((GComponent)this).GetController("Type");
		CountColor = ((GComponent)this).GetController("CountColor");
		n29 = (GImage)((GComponent)this).GetChild("n29");
		n14 = (GImage)((GComponent)this).GetChild("n14");
		n15 = (GTextField)((GComponent)this).GetChild("n15");
		string id = "ui://tt2iq07osmtg2x".Replace("ui://", "") + "-" + ((GObject)n15).id;
		((GObject)n15).text = LanguagesManager.GetDesc(id);
		n28 = (GImage)((GComponent)this).GetChild("n28");
		n26 = (GImage)((GComponent)this).GetChild("n26");
		n27 = (GImage)((GComponent)this).GetChild("n27");
		n19 = (GImage)((GComponent)this).GetChild("n19");
		Formula = (GComponent)((GComponent)this).GetChild("Formula");
		n1 = (GTextField)((GComponent)this).GetChild("n1");
		string id2 = "ui://tt2iq07osmtg2x".Replace("ui://", "") + "-" + ((GObject)n1).id;
		((GObject)n1).text = LanguagesManager.GetDesc(id2);
		Countdown = (GTextField)((GComponent)this).GetChild("Countdown");
		n6 = (GTextField)((GComponent)this).GetChild("n6");
		string id3 = "ui://tt2iq07osmtg2x".Replace("ui://", "") + "-" + ((GObject)n6).id;
		((GObject)n6).text = LanguagesManager.GetDesc(id3);
		n7 = (GTextField)((GComponent)this).GetChild("n7");
		string id4 = "ui://tt2iq07osmtg2x".Replace("ui://", "") + "-" + ((GObject)n7).id;
		((GObject)n7).text = LanguagesManager.GetDesc(id4);
		n9 = (GTextField)((GComponent)this).GetChild("n9");
		string id5 = "ui://tt2iq07osmtg2x".Replace("ui://", "") + "-" + ((GObject)n9).id;
		((GObject)n9).text = LanguagesManager.GetDesc(id5);
		n10 = (GTextField)((GComponent)this).GetChild("n10");
		string id6 = "ui://tt2iq07osmtg2x".Replace("ui://", "") + "-" + ((GObject)n10).id;
		((GObject)n10).text = LanguagesManager.GetDesc(id6);
		n23 = (GTextField)((GComponent)this).GetChild("n23");
		string id7 = "ui://tt2iq07osmtg2x".Replace("ui://", "") + "-" + ((GObject)n23).id;
		((GObject)n23).text = LanguagesManager.GetDesc(id7);
		RemainingCount = (GTextField)((GComponent)this).GetChild("RemainingCount");
		RewardCount = (UI_com_FormulaOemRewardCount)(object)((GComponent)this).GetChild("RewardCount");
		n20 = (GImage)((GComponent)this).GetChild("n20");
		n21 = (GImage)((GComponent)this).GetChild("n21");
		n13 = (GGroup)((GComponent)this).GetChild("n13");
	}
}
