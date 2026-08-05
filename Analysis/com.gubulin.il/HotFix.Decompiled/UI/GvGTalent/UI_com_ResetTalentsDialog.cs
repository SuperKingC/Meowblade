using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGTalent;

public class UI_com_ResetTalentsDialog : GComponent
{
	public Controller Status;

	public Controller OuterTechIsActive;

	public Controller Page;

	public Controller ShowCountDown;

	public GImage back;

	public GImage n32;

	public GImage n6;

	public GLoader Icon;

	public GTextField Num;

	public GTextField n7;

	public GTextField Text;

	public GGroup n20;

	public GImage n14;

	public GImage n21;

	public GTextField n15;

	public GImage n16;

	public GTextField n17;

	public GTextField n23;

	public GTextField ReturnPercent;

	public GTextField OuterTechCountDown;

	public GTextField n26;

	public GTextField OuterTechTimes;

	public GGroup n33;

	public GImage n28;

	public GTextField n29;

	public GGroup n19;

	public GTextField ReturnNum;

	public GTextField n25;

	public GLoader ReturnIcon;

	public UI_btn_Confirm Confirm;

	public UI_btn_Cancel Cancel;

	public UI_btn_ResetTab n12;

	public UI_btn_ResetTab n13;

	public const string URL = "ui://4r1llhd8xohkg";

	public static string Name = "UI_com_ResetTalentsDialog";

	public static string GetURL()
	{
		return "ui://4r1llhd8xohkg";
	}

	public static UI_com_ResetTalentsDialog CreateInstance()
	{
		return (UI_com_ResetTalentsDialog)(object)UIPackage.CreateObject("GvGTalent", "com_ResetTalentsDialog");
	}

	public static UI_com_ResetTalentsDialog CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_ResetTalentsDialog).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://4r1llhd8xohkg", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0059: Unknown result type (might be due to invalid IL or missing references)
		//IL_0063: Expected O, but got Unknown
		//IL_006f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0079: Expected O, but got Unknown
		//IL_0085: Unknown result type (might be due to invalid IL or missing references)
		//IL_008f: Expected O, but got Unknown
		//IL_009b: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a5: Expected O, but got Unknown
		//IL_00b1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bb: Expected O, but got Unknown
		//IL_00c7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d1: Expected O, but got Unknown
		//IL_011a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0124: Expected O, but got Unknown
		//IL_016d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0177: Expected O, but got Unknown
		//IL_0183: Unknown result type (might be due to invalid IL or missing references)
		//IL_018d: Expected O, but got Unknown
		//IL_0199: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a3: Expected O, but got Unknown
		//IL_01af: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b9: Expected O, but got Unknown
		//IL_0202: Unknown result type (might be due to invalid IL or missing references)
		//IL_020c: Expected O, but got Unknown
		//IL_0218: Unknown result type (might be due to invalid IL or missing references)
		//IL_0222: Expected O, but got Unknown
		//IL_026b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0275: Expected O, but got Unknown
		//IL_02c0: Unknown result type (might be due to invalid IL or missing references)
		//IL_02ca: Expected O, but got Unknown
		//IL_02d6: Unknown result type (might be due to invalid IL or missing references)
		//IL_02e0: Expected O, but got Unknown
		//IL_02ec: Unknown result type (might be due to invalid IL or missing references)
		//IL_02f6: Expected O, but got Unknown
		//IL_0341: Unknown result type (might be due to invalid IL or missing references)
		//IL_034b: Expected O, but got Unknown
		//IL_0357: Unknown result type (might be due to invalid IL or missing references)
		//IL_0361: Expected O, but got Unknown
		//IL_036d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0377: Expected O, but got Unknown
		//IL_0383: Unknown result type (might be due to invalid IL or missing references)
		//IL_038d: Expected O, but got Unknown
		//IL_03d8: Unknown result type (might be due to invalid IL or missing references)
		//IL_03e2: Expected O, but got Unknown
		//IL_03ee: Unknown result type (might be due to invalid IL or missing references)
		//IL_03f8: Expected O, but got Unknown
		//IL_0404: Unknown result type (might be due to invalid IL or missing references)
		//IL_040e: Expected O, but got Unknown
		//IL_0459: Unknown result type (might be due to invalid IL or missing references)
		//IL_0463: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		Status = ((GComponent)this).GetController("Status");
		OuterTechIsActive = ((GComponent)this).GetController("OuterTechIsActive");
		Page = ((GComponent)this).GetController("Page");
		ShowCountDown = ((GComponent)this).GetController("ShowCountDown");
		back = (GImage)((GComponent)this).GetChild("back");
		n32 = (GImage)((GComponent)this).GetChild("n32");
		n6 = (GImage)((GComponent)this).GetChild("n6");
		Icon = (GLoader)((GComponent)this).GetChild("Icon");
		Num = (GTextField)((GComponent)this).GetChild("Num");
		n7 = (GTextField)((GComponent)this).GetChild("n7");
		string id = "ui://4r1llhd8xohkg".Replace("ui://", "") + "-" + ((GObject)n7).id;
		((GObject)n7).text = LanguagesManager.GetDesc(id);
		Text = (GTextField)((GComponent)this).GetChild("Text");
		string id2 = "ui://4r1llhd8xohkg".Replace("ui://", "") + "-" + ((GObject)Text).id;
		((GObject)Text).text = LanguagesManager.GetDesc(id2);
		n20 = (GGroup)((GComponent)this).GetChild("n20");
		n14 = (GImage)((GComponent)this).GetChild("n14");
		n21 = (GImage)((GComponent)this).GetChild("n21");
		n15 = (GTextField)((GComponent)this).GetChild("n15");
		string id3 = "ui://4r1llhd8xohkg".Replace("ui://", "") + "-" + ((GObject)n15).id;
		((GObject)n15).text = LanguagesManager.GetDesc(id3);
		n16 = (GImage)((GComponent)this).GetChild("n16");
		n17 = (GTextField)((GComponent)this).GetChild("n17");
		string id4 = "ui://4r1llhd8xohkg".Replace("ui://", "") + "-" + ((GObject)n17).id;
		((GObject)n17).text = LanguagesManager.GetDesc(id4);
		n23 = (GTextField)((GComponent)this).GetChild("n23");
		string id5 = "ui://4r1llhd8xohkg".Replace("ui://", "") + "-" + ((GObject)n23).id;
		((GObject)n23).text = LanguagesManager.GetDesc(id5);
		ReturnPercent = (GTextField)((GComponent)this).GetChild("ReturnPercent");
		OuterTechCountDown = (GTextField)((GComponent)this).GetChild("OuterTechCountDown");
		n26 = (GTextField)((GComponent)this).GetChild("n26");
		string id6 = "ui://4r1llhd8xohkg".Replace("ui://", "") + "-" + ((GObject)n26).id;
		((GObject)n26).text = LanguagesManager.GetDesc(id6);
		OuterTechTimes = (GTextField)((GComponent)this).GetChild("OuterTechTimes");
		n33 = (GGroup)((GComponent)this).GetChild("n33");
		n28 = (GImage)((GComponent)this).GetChild("n28");
		n29 = (GTextField)((GComponent)this).GetChild("n29");
		string id7 = "ui://4r1llhd8xohkg".Replace("ui://", "") + "-" + ((GObject)n29).id;
		((GObject)n29).text = LanguagesManager.GetDesc(id7);
		n19 = (GGroup)((GComponent)this).GetChild("n19");
		ReturnNum = (GTextField)((GComponent)this).GetChild("ReturnNum");
		n25 = (GTextField)((GComponent)this).GetChild("n25");
		string id8 = "ui://4r1llhd8xohkg".Replace("ui://", "") + "-" + ((GObject)n25).id;
		((GObject)n25).text = LanguagesManager.GetDesc(id8);
		ReturnIcon = (GLoader)((GComponent)this).GetChild("ReturnIcon");
		Confirm = (UI_btn_Confirm)(object)((GComponent)this).GetChild("Confirm");
		Cancel = (UI_btn_Cancel)(object)((GComponent)this).GetChild("Cancel");
		n12 = (UI_btn_ResetTab)(object)((GComponent)this).GetChild("n12");
		n13 = (UI_btn_ResetTab)(object)((GComponent)this).GetChild("n13");
	}
}
