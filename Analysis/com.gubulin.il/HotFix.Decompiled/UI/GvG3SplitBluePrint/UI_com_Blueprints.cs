using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvG3SplitBluePrint;

public class UI_com_Blueprints : GComponent
{
	public Controller BlueprintsIsEmpty;

	public Controller BlueprintSelected;

	public GImage Background;

	public GImage n21;

	public UI_dec_01 n26;

	public GImage n27;

	public GImage n22;

	public GImage n23;

	public GImage n1;

	public GTextField OuterTechName;

	public UI_btn_SelectedBlueprint SelectedBlueprint;

	public GImage n28;

	public UI_dec_light01 n31;

	public GLoader n7;

	public GTextField ExpectedToObtain;

	public GImage n29;

	public GGroup n30;

	public GImage n24;

	public GImage n25;

	public UI_btn_Confirm Comfirm;

	public GImage n4;

	public GImage n20;

	public GImage n16;

	public GImage n18;

	public GLoader n6;

	public GTextField FragmentCount;

	public GTextField n17;

	public GList AllBlueprints;

	public GImage n19;

	public UI_btn_Close Close;

	public Transition t0;

	public Transition Split;

	public const string URL = "ui://7uylntmmju1un";

	public static string Name = "UI_com_Blueprints";

	public static string GetURL()
	{
		return "ui://7uylntmmju1un";
	}

	public static UI_com_Blueprints CreateInstance()
	{
		return (UI_com_Blueprints)(object)UIPackage.CreateObject("GvG3SplitBluePrint", "com_Blueprints");
	}

	public static UI_com_Blueprints CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_Blueprints).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://7uylntmmju1un", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0037: Unknown result type (might be due to invalid IL or missing references)
		//IL_0041: Expected O, but got Unknown
		//IL_004d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0057: Expected O, but got Unknown
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
		//IL_013a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0144: Expected O, but got Unknown
		//IL_0166: Unknown result type (might be due to invalid IL or missing references)
		//IL_0170: Expected O, but got Unknown
		//IL_017c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0186: Expected O, but got Unknown
		//IL_0192: Unknown result type (might be due to invalid IL or missing references)
		//IL_019c: Expected O, but got Unknown
		//IL_01a8: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b2: Expected O, but got Unknown
		//IL_01be: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c8: Expected O, but got Unknown
		//IL_01d4: Unknown result type (might be due to invalid IL or missing references)
		//IL_01de: Expected O, but got Unknown
		//IL_0200: Unknown result type (might be due to invalid IL or missing references)
		//IL_020a: Expected O, but got Unknown
		//IL_0216: Unknown result type (might be due to invalid IL or missing references)
		//IL_0220: Expected O, but got Unknown
		//IL_022c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0236: Expected O, but got Unknown
		//IL_0242: Unknown result type (might be due to invalid IL or missing references)
		//IL_024c: Expected O, but got Unknown
		//IL_0258: Unknown result type (might be due to invalid IL or missing references)
		//IL_0262: Expected O, but got Unknown
		//IL_026e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0278: Expected O, but got Unknown
		//IL_0284: Unknown result type (might be due to invalid IL or missing references)
		//IL_028e: Expected O, but got Unknown
		//IL_02d7: Unknown result type (might be due to invalid IL or missing references)
		//IL_02e1: Expected O, but got Unknown
		//IL_02ed: Unknown result type (might be due to invalid IL or missing references)
		//IL_02f7: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		BlueprintsIsEmpty = ((GComponent)this).GetController("BlueprintsIsEmpty");
		BlueprintSelected = ((GComponent)this).GetController("BlueprintSelected");
		Background = (GImage)((GComponent)this).GetChild("Background");
		n21 = (GImage)((GComponent)this).GetChild("n21");
		n26 = (UI_dec_01)(object)((GComponent)this).GetChild("n26");
		n27 = (GImage)((GComponent)this).GetChild("n27");
		n22 = (GImage)((GComponent)this).GetChild("n22");
		n23 = (GImage)((GComponent)this).GetChild("n23");
		n1 = (GImage)((GComponent)this).GetChild("n1");
		OuterTechName = (GTextField)((GComponent)this).GetChild("OuterTechName");
		string id = "ui://7uylntmmju1un".Replace("ui://", "") + "-" + ((GObject)OuterTechName).id;
		((GObject)OuterTechName).text = LanguagesManager.GetDesc(id);
		SelectedBlueprint = (UI_btn_SelectedBlueprint)(object)((GComponent)this).GetChild("SelectedBlueprint");
		n28 = (GImage)((GComponent)this).GetChild("n28");
		n31 = (UI_dec_light01)(object)((GComponent)this).GetChild("n31");
		n7 = (GLoader)((GComponent)this).GetChild("n7");
		ExpectedToObtain = (GTextField)((GComponent)this).GetChild("ExpectedToObtain");
		n29 = (GImage)((GComponent)this).GetChild("n29");
		n30 = (GGroup)((GComponent)this).GetChild("n30");
		n24 = (GImage)((GComponent)this).GetChild("n24");
		n25 = (GImage)((GComponent)this).GetChild("n25");
		Comfirm = (UI_btn_Confirm)(object)((GComponent)this).GetChild("Comfirm");
		n4 = (GImage)((GComponent)this).GetChild("n4");
		n20 = (GImage)((GComponent)this).GetChild("n20");
		n16 = (GImage)((GComponent)this).GetChild("n16");
		n18 = (GImage)((GComponent)this).GetChild("n18");
		n6 = (GLoader)((GComponent)this).GetChild("n6");
		FragmentCount = (GTextField)((GComponent)this).GetChild("FragmentCount");
		n17 = (GTextField)((GComponent)this).GetChild("n17");
		string id2 = "ui://7uylntmmju1un".Replace("ui://", "") + "-" + ((GObject)n17).id;
		((GObject)n17).text = LanguagesManager.GetDesc(id2);
		AllBlueprints = (GList)((GComponent)this).GetChild("AllBlueprints");
		n19 = (GImage)((GComponent)this).GetChild("n19");
		Close = (UI_btn_Close)(object)((GComponent)this).GetChild("Close");
		t0 = ((GComponent)this).GetTransition("t0");
		Split = ((GComponent)this).GetTransition("Split");
	}
}
