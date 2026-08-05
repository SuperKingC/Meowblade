using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.Tips;

public class UI_SpearAndShieldDialog : GComponent
{
	public Controller pageController;

	public GImage background;

	public GImage n153;

	public GImage n143;

	public GImage n145;

	public GImage n152;

	public GImage n151;

	public GGraph n147;

	public GGraph n148;

	public GGraph n149;

	public GGraph n150;

	public GTextField n4;

	public GTextField n5;

	public GLoader Icon00;

	public GTextField Text00;

	public GLoader Icon01;

	public GTextField Text01;

	public GLoader Icon02;

	public GTextField Text02;

	public GLoader Icon03;

	public GTextField Text03;

	public GLoader Icon04;

	public GTextField Text04;

	public GLoader Icon05;

	public GTextField Text05;

	public GGroup propertiesGroup0;

	public GLoader Icon10;

	public GTextField Text10;

	public GLoader Icon11;

	public GTextField Text11;

	public GLoader Icon12;

	public GTextField Text12;

	public GLoader Icon13;

	public GTextField Text13;

	public GLoader Icon14;

	public GTextField Text14;

	public GLoader Icon15;

	public GTextField Text15;

	public GGroup propertiesGroup1;

	public GLoader Icon20;

	public GTextField Text20;

	public GLoader Icon21;

	public GTextField Text21;

	public GLoader Icon22;

	public GTextField Text22;

	public GLoader Icon23;

	public GTextField Text23;

	public GLoader Icon24;

	public GTextField Text24;

	public GLoader Icon25;

	public GTextField Text25;

	public GGroup propertiesGroup2;

	public GLoader Icon30;

	public GTextField Text30;

	public GLoader Icon31;

	public GTextField Text31;

	public GLoader Icon32;

	public GTextField Text32;

	public GLoader Icon33;

	public GTextField Text33;

	public GLoader Icon34;

	public GTextField Text34;

	public GLoader Icon35;

	public GTextField Text35;

	public GGroup propertiesGroup3;

	public GLoader Icon40;

	public GTextField Text40;

	public GLoader Icon41;

	public GTextField Text41;

	public GLoader Icon42;

	public GTextField Text42;

	public GLoader Icon43;

	public GTextField Text43;

	public GLoader Icon44;

	public GTextField Text44;

	public GLoader Icon45;

	public GTextField Text45;

	public GGroup propertiesGroup4;

	public GLoader Icon50;

	public GTextField Text50;

	public GLoader Icon51;

	public GTextField Text51;

	public GLoader Icon52;

	public GTextField Text52;

	public GLoader Icon53;

	public GTextField Text53;

	public GLoader Icon54;

	public GTextField Text54;

	public GLoader Icon55;

	public GTextField Text55;

	public GGroup propertiesGroup5;

	public GLoader Icon60;

	public GTextField Text60;

	public GLoader Icon61;

	public GTextField Text61;

	public GLoader Icon62;

	public GTextField Text62;

	public GLoader Icon63;

	public GTextField Text63;

	public GLoader Icon64;

	public GTextField Text64;

	public GLoader Icon65;

	public GTextField Text65;

	public GGroup propertiesGroup6;

	public GLoader Icon70;

	public GTextField Text70;

	public GLoader Icon71;

	public GTextField Text71;

	public GLoader Icon72;

	public GTextField Text72;

	public GLoader Icon73;

	public GTextField Text73;

	public GLoader Icon74;

	public GTextField Text74;

	public GLoader Icon75;

	public GTextField Text75;

	public GGroup propertiesGroup7;

	public GLoader mainIcon;

	public GTextField title;

	public GGroup n154;

	public const string URL = "ui://47lbpgx9jgn71l";

	public static string Name = "UI_SpearAndShieldDialog";

	public void SetControllerPageText()
	{
		string text = ((pageController.selectedIndex == 1) ? "1" : "def");
		string id = "ui://47lbpgx9jgn71l".Replace("ui://", "") + "-" + ((GObject)n4).id + "-" + text;
		((GObject)n4).text = LanguagesManager.GetDesc(id);
		string text2 = ((pageController.selectedIndex == 6) ? "6" : "def");
		string id2 = "ui://47lbpgx9jgn71l".Replace("ui://", "") + "-" + ((GObject)n5).id + "-" + text2;
		((GObject)n5).text = LanguagesManager.GetDesc(id2);
	}

	public static string GetURL()
	{
		return "ui://47lbpgx9jgn71l";
	}

	public static UI_SpearAndShieldDialog CreateInstance()
	{
		return (UI_SpearAndShieldDialog)(object)UIPackage.CreateObject("Tips", "SpearAndShieldDialog");
	}

	public static UI_SpearAndShieldDialog CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_SpearAndShieldDialog).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://47lbpgx9jgn71l", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Expected O, but got Unknown
		//IL_003c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0046: Expected O, but got Unknown
		//IL_0052: Unknown result type (might be due to invalid IL or missing references)
		//IL_005c: Expected O, but got Unknown
		//IL_0068: Unknown result type (might be due to invalid IL or missing references)
		//IL_0072: Expected O, but got Unknown
		//IL_007e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0088: Expected O, but got Unknown
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
		//IL_0155: Unknown result type (might be due to invalid IL or missing references)
		//IL_015f: Expected O, but got Unknown
		//IL_01a8: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b2: Expected O, but got Unknown
		//IL_01be: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c8: Expected O, but got Unknown
		//IL_01d4: Unknown result type (might be due to invalid IL or missing references)
		//IL_01de: Expected O, but got Unknown
		//IL_01ea: Unknown result type (might be due to invalid IL or missing references)
		//IL_01f4: Expected O, but got Unknown
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
		//IL_029a: Unknown result type (might be due to invalid IL or missing references)
		//IL_02a4: Expected O, but got Unknown
		//IL_02b0: Unknown result type (might be due to invalid IL or missing references)
		//IL_02ba: Expected O, but got Unknown
		//IL_02c6: Unknown result type (might be due to invalid IL or missing references)
		//IL_02d0: Expected O, but got Unknown
		//IL_02dc: Unknown result type (might be due to invalid IL or missing references)
		//IL_02e6: Expected O, but got Unknown
		//IL_02f2: Unknown result type (might be due to invalid IL or missing references)
		//IL_02fc: Expected O, but got Unknown
		//IL_0308: Unknown result type (might be due to invalid IL or missing references)
		//IL_0312: Expected O, but got Unknown
		//IL_031e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0328: Expected O, but got Unknown
		//IL_0334: Unknown result type (might be due to invalid IL or missing references)
		//IL_033e: Expected O, but got Unknown
		//IL_034a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0354: Expected O, but got Unknown
		//IL_0360: Unknown result type (might be due to invalid IL or missing references)
		//IL_036a: Expected O, but got Unknown
		//IL_0376: Unknown result type (might be due to invalid IL or missing references)
		//IL_0380: Expected O, but got Unknown
		//IL_038c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0396: Expected O, but got Unknown
		//IL_03a2: Unknown result type (might be due to invalid IL or missing references)
		//IL_03ac: Expected O, but got Unknown
		//IL_03b8: Unknown result type (might be due to invalid IL or missing references)
		//IL_03c2: Expected O, but got Unknown
		//IL_03ce: Unknown result type (might be due to invalid IL or missing references)
		//IL_03d8: Expected O, but got Unknown
		//IL_03e4: Unknown result type (might be due to invalid IL or missing references)
		//IL_03ee: Expected O, but got Unknown
		//IL_03fa: Unknown result type (might be due to invalid IL or missing references)
		//IL_0404: Expected O, but got Unknown
		//IL_0410: Unknown result type (might be due to invalid IL or missing references)
		//IL_041a: Expected O, but got Unknown
		//IL_0426: Unknown result type (might be due to invalid IL or missing references)
		//IL_0430: Expected O, but got Unknown
		//IL_043c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0446: Expected O, but got Unknown
		//IL_0452: Unknown result type (might be due to invalid IL or missing references)
		//IL_045c: Expected O, but got Unknown
		//IL_0468: Unknown result type (might be due to invalid IL or missing references)
		//IL_0472: Expected O, but got Unknown
		//IL_047e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0488: Expected O, but got Unknown
		//IL_0494: Unknown result type (might be due to invalid IL or missing references)
		//IL_049e: Expected O, but got Unknown
		//IL_04aa: Unknown result type (might be due to invalid IL or missing references)
		//IL_04b4: Expected O, but got Unknown
		//IL_04c0: Unknown result type (might be due to invalid IL or missing references)
		//IL_04ca: Expected O, but got Unknown
		//IL_04d6: Unknown result type (might be due to invalid IL or missing references)
		//IL_04e0: Expected O, but got Unknown
		//IL_04ec: Unknown result type (might be due to invalid IL or missing references)
		//IL_04f6: Expected O, but got Unknown
		//IL_0502: Unknown result type (might be due to invalid IL or missing references)
		//IL_050c: Expected O, but got Unknown
		//IL_0518: Unknown result type (might be due to invalid IL or missing references)
		//IL_0522: Expected O, but got Unknown
		//IL_052e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0538: Expected O, but got Unknown
		//IL_0544: Unknown result type (might be due to invalid IL or missing references)
		//IL_054e: Expected O, but got Unknown
		//IL_055a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0564: Expected O, but got Unknown
		//IL_0570: Unknown result type (might be due to invalid IL or missing references)
		//IL_057a: Expected O, but got Unknown
		//IL_0586: Unknown result type (might be due to invalid IL or missing references)
		//IL_0590: Expected O, but got Unknown
		//IL_059c: Unknown result type (might be due to invalid IL or missing references)
		//IL_05a6: Expected O, but got Unknown
		//IL_05b2: Unknown result type (might be due to invalid IL or missing references)
		//IL_05bc: Expected O, but got Unknown
		//IL_05c8: Unknown result type (might be due to invalid IL or missing references)
		//IL_05d2: Expected O, but got Unknown
		//IL_05de: Unknown result type (might be due to invalid IL or missing references)
		//IL_05e8: Expected O, but got Unknown
		//IL_05f4: Unknown result type (might be due to invalid IL or missing references)
		//IL_05fe: Expected O, but got Unknown
		//IL_060a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0614: Expected O, but got Unknown
		//IL_0620: Unknown result type (might be due to invalid IL or missing references)
		//IL_062a: Expected O, but got Unknown
		//IL_0636: Unknown result type (might be due to invalid IL or missing references)
		//IL_0640: Expected O, but got Unknown
		//IL_064c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0656: Expected O, but got Unknown
		//IL_0662: Unknown result type (might be due to invalid IL or missing references)
		//IL_066c: Expected O, but got Unknown
		//IL_0678: Unknown result type (might be due to invalid IL or missing references)
		//IL_0682: Expected O, but got Unknown
		//IL_068e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0698: Expected O, but got Unknown
		//IL_06a4: Unknown result type (might be due to invalid IL or missing references)
		//IL_06ae: Expected O, but got Unknown
		//IL_06ba: Unknown result type (might be due to invalid IL or missing references)
		//IL_06c4: Expected O, but got Unknown
		//IL_06d0: Unknown result type (might be due to invalid IL or missing references)
		//IL_06da: Expected O, but got Unknown
		//IL_06e6: Unknown result type (might be due to invalid IL or missing references)
		//IL_06f0: Expected O, but got Unknown
		//IL_06fc: Unknown result type (might be due to invalid IL or missing references)
		//IL_0706: Expected O, but got Unknown
		//IL_0712: Unknown result type (might be due to invalid IL or missing references)
		//IL_071c: Expected O, but got Unknown
		//IL_0728: Unknown result type (might be due to invalid IL or missing references)
		//IL_0732: Expected O, but got Unknown
		//IL_073e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0748: Expected O, but got Unknown
		//IL_0754: Unknown result type (might be due to invalid IL or missing references)
		//IL_075e: Expected O, but got Unknown
		//IL_076a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0774: Expected O, but got Unknown
		//IL_0780: Unknown result type (might be due to invalid IL or missing references)
		//IL_078a: Expected O, but got Unknown
		//IL_0796: Unknown result type (might be due to invalid IL or missing references)
		//IL_07a0: Expected O, but got Unknown
		//IL_07ac: Unknown result type (might be due to invalid IL or missing references)
		//IL_07b6: Expected O, but got Unknown
		//IL_07c2: Unknown result type (might be due to invalid IL or missing references)
		//IL_07cc: Expected O, but got Unknown
		//IL_07d8: Unknown result type (might be due to invalid IL or missing references)
		//IL_07e2: Expected O, but got Unknown
		//IL_07ee: Unknown result type (might be due to invalid IL or missing references)
		//IL_07f8: Expected O, but got Unknown
		//IL_0804: Unknown result type (might be due to invalid IL or missing references)
		//IL_080e: Expected O, but got Unknown
		//IL_081a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0824: Expected O, but got Unknown
		//IL_0830: Unknown result type (might be due to invalid IL or missing references)
		//IL_083a: Expected O, but got Unknown
		//IL_0846: Unknown result type (might be due to invalid IL or missing references)
		//IL_0850: Expected O, but got Unknown
		//IL_085c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0866: Expected O, but got Unknown
		//IL_0872: Unknown result type (might be due to invalid IL or missing references)
		//IL_087c: Expected O, but got Unknown
		//IL_0888: Unknown result type (might be due to invalid IL or missing references)
		//IL_0892: Expected O, but got Unknown
		//IL_089e: Unknown result type (might be due to invalid IL or missing references)
		//IL_08a8: Expected O, but got Unknown
		//IL_08b4: Unknown result type (might be due to invalid IL or missing references)
		//IL_08be: Expected O, but got Unknown
		//IL_08ca: Unknown result type (might be due to invalid IL or missing references)
		//IL_08d4: Expected O, but got Unknown
		//IL_08e0: Unknown result type (might be due to invalid IL or missing references)
		//IL_08ea: Expected O, but got Unknown
		//IL_08f6: Unknown result type (might be due to invalid IL or missing references)
		//IL_0900: Expected O, but got Unknown
		//IL_090c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0916: Expected O, but got Unknown
		//IL_0922: Unknown result type (might be due to invalid IL or missing references)
		//IL_092c: Expected O, but got Unknown
		//IL_0938: Unknown result type (might be due to invalid IL or missing references)
		//IL_0942: Expected O, but got Unknown
		//IL_094e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0958: Expected O, but got Unknown
		//IL_0964: Unknown result type (might be due to invalid IL or missing references)
		//IL_096e: Expected O, but got Unknown
		//IL_097a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0984: Expected O, but got Unknown
		//IL_0990: Unknown result type (might be due to invalid IL or missing references)
		//IL_099a: Expected O, but got Unknown
		//IL_09a6: Unknown result type (might be due to invalid IL or missing references)
		//IL_09b0: Expected O, but got Unknown
		//IL_09bc: Unknown result type (might be due to invalid IL or missing references)
		//IL_09c6: Expected O, but got Unknown
		//IL_09d2: Unknown result type (might be due to invalid IL or missing references)
		//IL_09dc: Expected O, but got Unknown
		//IL_09e8: Unknown result type (might be due to invalid IL or missing references)
		//IL_09f2: Expected O, but got Unknown
		//IL_09fe: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a08: Expected O, but got Unknown
		//IL_0a14: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a1e: Expected O, but got Unknown
		//IL_0a2a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a34: Expected O, but got Unknown
		//IL_0a40: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a4a: Expected O, but got Unknown
		//IL_0a56: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a60: Expected O, but got Unknown
		//IL_0a6c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a76: Expected O, but got Unknown
		//IL_0a82: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a8c: Expected O, but got Unknown
		//IL_0a98: Unknown result type (might be due to invalid IL or missing references)
		//IL_0aa2: Expected O, but got Unknown
		//IL_0aae: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ab8: Expected O, but got Unknown
		//IL_0b01: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b0b: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		pageController = ((GComponent)this).GetController("pageController");
		background = (GImage)((GComponent)this).GetChild("background");
		n153 = (GImage)((GComponent)this).GetChild("n153");
		n143 = (GImage)((GComponent)this).GetChild("n143");
		n145 = (GImage)((GComponent)this).GetChild("n145");
		n152 = (GImage)((GComponent)this).GetChild("n152");
		n151 = (GImage)((GComponent)this).GetChild("n151");
		n147 = (GGraph)((GComponent)this).GetChild("n147");
		n148 = (GGraph)((GComponent)this).GetChild("n148");
		n149 = (GGraph)((GComponent)this).GetChild("n149");
		n150 = (GGraph)((GComponent)this).GetChild("n150");
		n4 = (GTextField)((GComponent)this).GetChild("n4");
		string id = "ui://47lbpgx9jgn71l".Replace("ui://", "") + "-" + ((GObject)n4).id;
		((GObject)n4).text = LanguagesManager.GetDesc(id);
		n5 = (GTextField)((GComponent)this).GetChild("n5");
		string id2 = "ui://47lbpgx9jgn71l".Replace("ui://", "") + "-" + ((GObject)n5).id;
		((GObject)n5).text = LanguagesManager.GetDesc(id2);
		Icon00 = (GLoader)((GComponent)this).GetChild("Icon00");
		Text00 = (GTextField)((GComponent)this).GetChild("Text00");
		Icon01 = (GLoader)((GComponent)this).GetChild("Icon01");
		Text01 = (GTextField)((GComponent)this).GetChild("Text01");
		Icon02 = (GLoader)((GComponent)this).GetChild("Icon02");
		Text02 = (GTextField)((GComponent)this).GetChild("Text02");
		Icon03 = (GLoader)((GComponent)this).GetChild("Icon03");
		Text03 = (GTextField)((GComponent)this).GetChild("Text03");
		Icon04 = (GLoader)((GComponent)this).GetChild("Icon04");
		Text04 = (GTextField)((GComponent)this).GetChild("Text04");
		Icon05 = (GLoader)((GComponent)this).GetChild("Icon05");
		Text05 = (GTextField)((GComponent)this).GetChild("Text05");
		propertiesGroup0 = (GGroup)((GComponent)this).GetChild("propertiesGroup0");
		Icon10 = (GLoader)((GComponent)this).GetChild("Icon10");
		Text10 = (GTextField)((GComponent)this).GetChild("Text10");
		Icon11 = (GLoader)((GComponent)this).GetChild("Icon11");
		Text11 = (GTextField)((GComponent)this).GetChild("Text11");
		Icon12 = (GLoader)((GComponent)this).GetChild("Icon12");
		Text12 = (GTextField)((GComponent)this).GetChild("Text12");
		Icon13 = (GLoader)((GComponent)this).GetChild("Icon13");
		Text13 = (GTextField)((GComponent)this).GetChild("Text13");
		Icon14 = (GLoader)((GComponent)this).GetChild("Icon14");
		Text14 = (GTextField)((GComponent)this).GetChild("Text14");
		Icon15 = (GLoader)((GComponent)this).GetChild("Icon15");
		Text15 = (GTextField)((GComponent)this).GetChild("Text15");
		propertiesGroup1 = (GGroup)((GComponent)this).GetChild("propertiesGroup1");
		Icon20 = (GLoader)((GComponent)this).GetChild("Icon20");
		Text20 = (GTextField)((GComponent)this).GetChild("Text20");
		Icon21 = (GLoader)((GComponent)this).GetChild("Icon21");
		Text21 = (GTextField)((GComponent)this).GetChild("Text21");
		Icon22 = (GLoader)((GComponent)this).GetChild("Icon22");
		Text22 = (GTextField)((GComponent)this).GetChild("Text22");
		Icon23 = (GLoader)((GComponent)this).GetChild("Icon23");
		Text23 = (GTextField)((GComponent)this).GetChild("Text23");
		Icon24 = (GLoader)((GComponent)this).GetChild("Icon24");
		Text24 = (GTextField)((GComponent)this).GetChild("Text24");
		Icon25 = (GLoader)((GComponent)this).GetChild("Icon25");
		Text25 = (GTextField)((GComponent)this).GetChild("Text25");
		propertiesGroup2 = (GGroup)((GComponent)this).GetChild("propertiesGroup2");
		Icon30 = (GLoader)((GComponent)this).GetChild("Icon30");
		Text30 = (GTextField)((GComponent)this).GetChild("Text30");
		Icon31 = (GLoader)((GComponent)this).GetChild("Icon31");
		Text31 = (GTextField)((GComponent)this).GetChild("Text31");
		Icon32 = (GLoader)((GComponent)this).GetChild("Icon32");
		Text32 = (GTextField)((GComponent)this).GetChild("Text32");
		Icon33 = (GLoader)((GComponent)this).GetChild("Icon33");
		Text33 = (GTextField)((GComponent)this).GetChild("Text33");
		Icon34 = (GLoader)((GComponent)this).GetChild("Icon34");
		Text34 = (GTextField)((GComponent)this).GetChild("Text34");
		Icon35 = (GLoader)((GComponent)this).GetChild("Icon35");
		Text35 = (GTextField)((GComponent)this).GetChild("Text35");
		propertiesGroup3 = (GGroup)((GComponent)this).GetChild("propertiesGroup3");
		Icon40 = (GLoader)((GComponent)this).GetChild("Icon40");
		Text40 = (GTextField)((GComponent)this).GetChild("Text40");
		Icon41 = (GLoader)((GComponent)this).GetChild("Icon41");
		Text41 = (GTextField)((GComponent)this).GetChild("Text41");
		Icon42 = (GLoader)((GComponent)this).GetChild("Icon42");
		Text42 = (GTextField)((GComponent)this).GetChild("Text42");
		Icon43 = (GLoader)((GComponent)this).GetChild("Icon43");
		Text43 = (GTextField)((GComponent)this).GetChild("Text43");
		Icon44 = (GLoader)((GComponent)this).GetChild("Icon44");
		Text44 = (GTextField)((GComponent)this).GetChild("Text44");
		Icon45 = (GLoader)((GComponent)this).GetChild("Icon45");
		Text45 = (GTextField)((GComponent)this).GetChild("Text45");
		propertiesGroup4 = (GGroup)((GComponent)this).GetChild("propertiesGroup4");
		Icon50 = (GLoader)((GComponent)this).GetChild("Icon50");
		Text50 = (GTextField)((GComponent)this).GetChild("Text50");
		Icon51 = (GLoader)((GComponent)this).GetChild("Icon51");
		Text51 = (GTextField)((GComponent)this).GetChild("Text51");
		Icon52 = (GLoader)((GComponent)this).GetChild("Icon52");
		Text52 = (GTextField)((GComponent)this).GetChild("Text52");
		Icon53 = (GLoader)((GComponent)this).GetChild("Icon53");
		Text53 = (GTextField)((GComponent)this).GetChild("Text53");
		Icon54 = (GLoader)((GComponent)this).GetChild("Icon54");
		Text54 = (GTextField)((GComponent)this).GetChild("Text54");
		Icon55 = (GLoader)((GComponent)this).GetChild("Icon55");
		Text55 = (GTextField)((GComponent)this).GetChild("Text55");
		propertiesGroup5 = (GGroup)((GComponent)this).GetChild("propertiesGroup5");
		Icon60 = (GLoader)((GComponent)this).GetChild("Icon60");
		Text60 = (GTextField)((GComponent)this).GetChild("Text60");
		Icon61 = (GLoader)((GComponent)this).GetChild("Icon61");
		Text61 = (GTextField)((GComponent)this).GetChild("Text61");
		Icon62 = (GLoader)((GComponent)this).GetChild("Icon62");
		Text62 = (GTextField)((GComponent)this).GetChild("Text62");
		Icon63 = (GLoader)((GComponent)this).GetChild("Icon63");
		Text63 = (GTextField)((GComponent)this).GetChild("Text63");
		Icon64 = (GLoader)((GComponent)this).GetChild("Icon64");
		Text64 = (GTextField)((GComponent)this).GetChild("Text64");
		Icon65 = (GLoader)((GComponent)this).GetChild("Icon65");
		Text65 = (GTextField)((GComponent)this).GetChild("Text65");
		propertiesGroup6 = (GGroup)((GComponent)this).GetChild("propertiesGroup6");
		Icon70 = (GLoader)((GComponent)this).GetChild("Icon70");
		Text70 = (GTextField)((GComponent)this).GetChild("Text70");
		Icon71 = (GLoader)((GComponent)this).GetChild("Icon71");
		Text71 = (GTextField)((GComponent)this).GetChild("Text71");
		Icon72 = (GLoader)((GComponent)this).GetChild("Icon72");
		Text72 = (GTextField)((GComponent)this).GetChild("Text72");
		Icon73 = (GLoader)((GComponent)this).GetChild("Icon73");
		Text73 = (GTextField)((GComponent)this).GetChild("Text73");
		Icon74 = (GLoader)((GComponent)this).GetChild("Icon74");
		Text74 = (GTextField)((GComponent)this).GetChild("Text74");
		Icon75 = (GLoader)((GComponent)this).GetChild("Icon75");
		Text75 = (GTextField)((GComponent)this).GetChild("Text75");
		propertiesGroup7 = (GGroup)((GComponent)this).GetChild("propertiesGroup7");
		mainIcon = (GLoader)((GComponent)this).GetChild("mainIcon");
		title = (GTextField)((GComponent)this).GetChild("title");
		string id3 = "ui://47lbpgx9jgn71l".Replace("ui://", "") + "-" + ((GObject)title).id;
		((GObject)title).text = LanguagesManager.GetDesc(id3);
		n154 = (GGroup)((GComponent)this).GetChild("n154");
	}
}
