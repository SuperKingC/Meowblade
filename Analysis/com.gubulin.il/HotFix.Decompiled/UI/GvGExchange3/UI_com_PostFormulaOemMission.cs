using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGExchange3;

public class UI_com_PostFormulaOemMission : GComponent
{
	public Controller Selected;

	public Controller hasDebuff;

	public GImage Background;

	public GImage n17;

	public GImage n20;

	public GImage n19;

	public GImage n18;

	public GImage n41;

	public UI_btn_PostMission_Small Post;

	public GTextField n2;

	public UI_btn_SelectedFormula SelectedFormula;

	public GImage n42;

	public GTextField n9;

	public GTextField n3;

	public GTextField MissionDuration;

	public GTextField n5;

	public GGroup n16;

	public GButton Help;

	public UI_com_OemCount OemCount;

	public GImage n35;

	public GTextField n36;

	public GImage n37;

	public GTextField ObtainImmediately;

	public GList PostBonus;

	public UI_btn_01 debuffBtn;

	public const string URL = "ui://tt2iq07oj1h84i";

	public static string Name = "UI_com_PostFormulaOemMission";

	public static string GetURL()
	{
		return "ui://tt2iq07oj1h84i";
	}

	public static UI_com_PostFormulaOemMission CreateInstance()
	{
		return (UI_com_PostFormulaOemMission)(object)UIPackage.CreateObject("GvGExchange3", "com_PostFormulaOemMission");
	}

	public static UI_com_PostFormulaOemMission CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_PostFormulaOemMission).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://tt2iq07oj1h84i", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		//IL_00d1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00db: Expected O, but got Unknown
		//IL_013a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0144: Expected O, but got Unknown
		//IL_0150: Unknown result type (might be due to invalid IL or missing references)
		//IL_015a: Expected O, but got Unknown
		//IL_01a3: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ad: Expected O, but got Unknown
		//IL_01f6: Unknown result type (might be due to invalid IL or missing references)
		//IL_0200: Expected O, but got Unknown
		//IL_020c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0216: Expected O, but got Unknown
		//IL_025f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0269: Expected O, but got Unknown
		//IL_0275: Unknown result type (might be due to invalid IL or missing references)
		//IL_027f: Expected O, but got Unknown
		//IL_02a1: Unknown result type (might be due to invalid IL or missing references)
		//IL_02ab: Expected O, but got Unknown
		//IL_02b7: Unknown result type (might be due to invalid IL or missing references)
		//IL_02c1: Expected O, but got Unknown
		//IL_030c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0316: Expected O, but got Unknown
		//IL_0322: Unknown result type (might be due to invalid IL or missing references)
		//IL_032c: Expected O, but got Unknown
		//IL_0338: Unknown result type (might be due to invalid IL or missing references)
		//IL_0342: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		Selected = ((GComponent)this).GetController("Selected");
		hasDebuff = ((GComponent)this).GetController("hasDebuff");
		Background = (GImage)((GComponent)this).GetChild("Background");
		n17 = (GImage)((GComponent)this).GetChild("n17");
		n20 = (GImage)((GComponent)this).GetChild("n20");
		n19 = (GImage)((GComponent)this).GetChild("n19");
		n18 = (GImage)((GComponent)this).GetChild("n18");
		n41 = (GImage)((GComponent)this).GetChild("n41");
		Post = (UI_btn_PostMission_Small)(object)((GComponent)this).GetChild("Post");
		n2 = (GTextField)((GComponent)this).GetChild("n2");
		string id = "ui://tt2iq07oj1h84i".Replace("ui://", "") + "-" + ((GObject)n2).id;
		((GObject)n2).text = LanguagesManager.GetDesc(id);
		SelectedFormula = (UI_btn_SelectedFormula)(object)((GComponent)this).GetChild("SelectedFormula");
		n42 = (GImage)((GComponent)this).GetChild("n42");
		n9 = (GTextField)((GComponent)this).GetChild("n9");
		string id2 = "ui://tt2iq07oj1h84i".Replace("ui://", "") + "-" + ((GObject)n9).id;
		((GObject)n9).text = LanguagesManager.GetDesc(id2);
		n3 = (GTextField)((GComponent)this).GetChild("n3");
		string id3 = "ui://tt2iq07oj1h84i".Replace("ui://", "") + "-" + ((GObject)n3).id;
		((GObject)n3).text = LanguagesManager.GetDesc(id3);
		MissionDuration = (GTextField)((GComponent)this).GetChild("MissionDuration");
		n5 = (GTextField)((GComponent)this).GetChild("n5");
		string id4 = "ui://tt2iq07oj1h84i".Replace("ui://", "") + "-" + ((GObject)n5).id;
		((GObject)n5).text = LanguagesManager.GetDesc(id4);
		n16 = (GGroup)((GComponent)this).GetChild("n16");
		Help = (GButton)((GComponent)this).GetChild("Help");
		OemCount = (UI_com_OemCount)(object)((GComponent)this).GetChild("OemCount");
		n35 = (GImage)((GComponent)this).GetChild("n35");
		n36 = (GTextField)((GComponent)this).GetChild("n36");
		string id5 = "ui://tt2iq07oj1h84i".Replace("ui://", "") + "-" + ((GObject)n36).id;
		((GObject)n36).text = LanguagesManager.GetDesc(id5);
		n37 = (GImage)((GComponent)this).GetChild("n37");
		ObtainImmediately = (GTextField)((GComponent)this).GetChild("ObtainImmediately");
		PostBonus = (GList)((GComponent)this).GetChild("PostBonus");
		debuffBtn = (UI_btn_01)(object)((GComponent)this).GetChild("debuffBtn");
	}
}
