using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGTalent;

public class UI_com_TalentsBackground : GComponent
{
	public Controller Type;

	public GImage n11;

	public UI_dec_TalentsArea2 Area2;

	public UI_dec_TalentsArea8 Area8;

	public UI_dec_TalentsArea1 Area1;

	public UI_dec_TalentsArea4 Area4;

	public GImage n16;

	public GImage n22;

	public GImage n23;

	public GImage n24;

	public GImage n25;

	public GImage n17;

	public GImage n39;

	public GImage n40;

	public GImage n41;

	public GImage n42;

	public UI_dec_BG01 n18;

	public GImage n43;

	public GImage n44;

	public GImage n45;

	public GImage n46;

	public UI_com_AreaLogoRed Logo1;

	public UI_com_AreaLogoGreen Logo4;

	public UI_com_AreaLogoYellow Logo2;

	public UI_com_AreaLogoBlue Logo8;

	public GImage n12;

	public GImage n13;

	public GImage n14;

	public GImage n15;

	public GImage n10;

	public GTextField n35;

	public GTextField n36;

	public GTextField n37;

	public GTextField n38;

	public Transition SelectType_2;

	public Transition SelectType_8;

	public Transition SelectType_1;

	public Transition SelectType_4;

	public Transition t0;

	public Transition t8;

	public Transition t9;

	public Transition t10;

	public const string URL = "ui://4r1llhd8ran32";

	public static string Name = "UI_com_TalentsBackground";

	public static string GetURL()
	{
		return "ui://4r1llhd8ran32";
	}

	public static UI_com_TalentsBackground CreateInstance()
	{
		return (UI_com_TalentsBackground)(object)UIPackage.CreateObject("GvGTalent", "com_TalentsBackground");
	}

	public static UI_com_TalentsBackground CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_TalentsBackground).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://4r1llhd8ran32", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Expected O, but got Unknown
		//IL_0094: Unknown result type (might be due to invalid IL or missing references)
		//IL_009e: Expected O, but got Unknown
		//IL_00aa: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b4: Expected O, but got Unknown
		//IL_00c0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ca: Expected O, but got Unknown
		//IL_00d6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e0: Expected O, but got Unknown
		//IL_00ec: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f6: Expected O, but got Unknown
		//IL_0102: Unknown result type (might be due to invalid IL or missing references)
		//IL_010c: Expected O, but got Unknown
		//IL_0118: Unknown result type (might be due to invalid IL or missing references)
		//IL_0122: Expected O, but got Unknown
		//IL_012e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0138: Expected O, but got Unknown
		//IL_0144: Unknown result type (might be due to invalid IL or missing references)
		//IL_014e: Expected O, but got Unknown
		//IL_015a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0164: Expected O, but got Unknown
		//IL_0186: Unknown result type (might be due to invalid IL or missing references)
		//IL_0190: Expected O, but got Unknown
		//IL_019c: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a6: Expected O, but got Unknown
		//IL_01b2: Unknown result type (might be due to invalid IL or missing references)
		//IL_01bc: Expected O, but got Unknown
		//IL_01c8: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d2: Expected O, but got Unknown
		//IL_0236: Unknown result type (might be due to invalid IL or missing references)
		//IL_0240: Expected O, but got Unknown
		//IL_024c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0256: Expected O, but got Unknown
		//IL_0262: Unknown result type (might be due to invalid IL or missing references)
		//IL_026c: Expected O, but got Unknown
		//IL_0278: Unknown result type (might be due to invalid IL or missing references)
		//IL_0282: Expected O, but got Unknown
		//IL_028e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0298: Expected O, but got Unknown
		//IL_02a4: Unknown result type (might be due to invalid IL or missing references)
		//IL_02ae: Expected O, but got Unknown
		//IL_02f7: Unknown result type (might be due to invalid IL or missing references)
		//IL_0301: Expected O, but got Unknown
		//IL_034a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0354: Expected O, but got Unknown
		//IL_039d: Unknown result type (might be due to invalid IL or missing references)
		//IL_03a7: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		Type = ((GComponent)this).GetController("Type");
		n11 = (GImage)((GComponent)this).GetChild("n11");
		Area2 = (UI_dec_TalentsArea2)(object)((GComponent)this).GetChild("Area2");
		Area8 = (UI_dec_TalentsArea8)(object)((GComponent)this).GetChild("Area8");
		Area1 = (UI_dec_TalentsArea1)(object)((GComponent)this).GetChild("Area1");
		Area4 = (UI_dec_TalentsArea4)(object)((GComponent)this).GetChild("Area4");
		n16 = (GImage)((GComponent)this).GetChild("n16");
		n22 = (GImage)((GComponent)this).GetChild("n22");
		n23 = (GImage)((GComponent)this).GetChild("n23");
		n24 = (GImage)((GComponent)this).GetChild("n24");
		n25 = (GImage)((GComponent)this).GetChild("n25");
		n17 = (GImage)((GComponent)this).GetChild("n17");
		n39 = (GImage)((GComponent)this).GetChild("n39");
		n40 = (GImage)((GComponent)this).GetChild("n40");
		n41 = (GImage)((GComponent)this).GetChild("n41");
		n42 = (GImage)((GComponent)this).GetChild("n42");
		n18 = (UI_dec_BG01)(object)((GComponent)this).GetChild("n18");
		n43 = (GImage)((GComponent)this).GetChild("n43");
		n44 = (GImage)((GComponent)this).GetChild("n44");
		n45 = (GImage)((GComponent)this).GetChild("n45");
		n46 = (GImage)((GComponent)this).GetChild("n46");
		Logo1 = (UI_com_AreaLogoRed)(object)((GComponent)this).GetChild("Logo1");
		Logo4 = (UI_com_AreaLogoGreen)(object)((GComponent)this).GetChild("Logo4");
		Logo2 = (UI_com_AreaLogoYellow)(object)((GComponent)this).GetChild("Logo2");
		Logo8 = (UI_com_AreaLogoBlue)(object)((GComponent)this).GetChild("Logo8");
		n12 = (GImage)((GComponent)this).GetChild("n12");
		n13 = (GImage)((GComponent)this).GetChild("n13");
		n14 = (GImage)((GComponent)this).GetChild("n14");
		n15 = (GImage)((GComponent)this).GetChild("n15");
		n10 = (GImage)((GComponent)this).GetChild("n10");
		n35 = (GTextField)((GComponent)this).GetChild("n35");
		string id = "ui://4r1llhd8ran32".Replace("ui://", "") + "-" + ((GObject)n35).id;
		((GObject)n35).text = LanguagesManager.GetDesc(id);
		n36 = (GTextField)((GComponent)this).GetChild("n36");
		string id2 = "ui://4r1llhd8ran32".Replace("ui://", "") + "-" + ((GObject)n36).id;
		((GObject)n36).text = LanguagesManager.GetDesc(id2);
		n37 = (GTextField)((GComponent)this).GetChild("n37");
		string id3 = "ui://4r1llhd8ran32".Replace("ui://", "") + "-" + ((GObject)n37).id;
		((GObject)n37).text = LanguagesManager.GetDesc(id3);
		n38 = (GTextField)((GComponent)this).GetChild("n38");
		string id4 = "ui://4r1llhd8ran32".Replace("ui://", "") + "-" + ((GObject)n38).id;
		((GObject)n38).text = LanguagesManager.GetDesc(id4);
		SelectType_2 = ((GComponent)this).GetTransition("SelectType-2");
		SelectType_8 = ((GComponent)this).GetTransition("SelectType-8");
		SelectType_1 = ((GComponent)this).GetTransition("SelectType-1");
		SelectType_4 = ((GComponent)this).GetTransition("SelectType-4");
		t0 = ((GComponent)this).GetTransition("t0");
		t8 = ((GComponent)this).GetTransition("t8");
		t9 = ((GComponent)this).GetTransition("t9");
		t10 = ((GComponent)this).GetTransition("t10");
	}
}
