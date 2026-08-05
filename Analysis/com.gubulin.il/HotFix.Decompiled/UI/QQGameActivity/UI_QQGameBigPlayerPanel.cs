using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.QQGameActivity;

public class UI_QQGameBigPlayerPanel : GComponent
{
	public Controller c1;

	public GLoader background;

	public GImage n1;

	public GComponent n2;

	public GComponent n3;

	public GComponent n4;

	public GComponent n5;

	public GComponent n6;

	public GButton BackBtn;

	public UI_Title02 titleCom;

	public GImage n9;

	public GTextField n10;

	public GTextField BigPlayerLevelText;

	public GTextField n12;

	public GTextField BigPlayerScoreText;

	public GGroup n14;

	public GImage n15;

	public GList TabList;

	public UI_btn_01 DescBtn;

	public UI_com_02 RechargeExtra;

	public UI_com_03 WeeklyPack;

	public UI_com_04 tq3;

	public UI_com_05 tq4;

	public UI_com_07 tq5;

	public UI_com_08 tq6;

	public UI_com_06 tq7;

	public GButton RechargeBtn;

	public GImage n23;

	public GTextField n24;

	public const string URL = "ui://r1j1a2l0e3ph1";

	public static string Name = "UI_QQGameBigPlayerPanel";

	public static string GetURL()
	{
		return "ui://r1j1a2l0e3ph1";
	}

	public static UI_QQGameBigPlayerPanel CreateInstance()
	{
		return (UI_QQGameBigPlayerPanel)(object)UIPackage.CreateObject("QQGameActivity", "QQGameBigPlayerPanel");
	}

	public static UI_QQGameBigPlayerPanel CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_QQGameBigPlayerPanel).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://r1j1a2l0e3ph1", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		//IL_00ec: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f6: Expected O, but got Unknown
		//IL_0102: Unknown result type (might be due to invalid IL or missing references)
		//IL_010c: Expected O, but got Unknown
		//IL_0155: Unknown result type (might be due to invalid IL or missing references)
		//IL_015f: Expected O, but got Unknown
		//IL_016b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0175: Expected O, but got Unknown
		//IL_01be: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c8: Expected O, but got Unknown
		//IL_01d4: Unknown result type (might be due to invalid IL or missing references)
		//IL_01de: Expected O, but got Unknown
		//IL_01ea: Unknown result type (might be due to invalid IL or missing references)
		//IL_01f4: Expected O, but got Unknown
		//IL_0200: Unknown result type (might be due to invalid IL or missing references)
		//IL_020a: Expected O, but got Unknown
		//IL_02c6: Unknown result type (might be due to invalid IL or missing references)
		//IL_02d0: Expected O, but got Unknown
		//IL_02dc: Unknown result type (might be due to invalid IL or missing references)
		//IL_02e6: Expected O, but got Unknown
		//IL_02f2: Unknown result type (might be due to invalid IL or missing references)
		//IL_02fc: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		c1 = ((GComponent)this).GetController("c1");
		background = (GLoader)((GComponent)this).GetChild("background");
		n1 = (GImage)((GComponent)this).GetChild("n1");
		n2 = (GComponent)((GComponent)this).GetChild("n2");
		n3 = (GComponent)((GComponent)this).GetChild("n3");
		n4 = (GComponent)((GComponent)this).GetChild("n4");
		n5 = (GComponent)((GComponent)this).GetChild("n5");
		n6 = (GComponent)((GComponent)this).GetChild("n6");
		BackBtn = (GButton)((GComponent)this).GetChild("BackBtn");
		titleCom = (UI_Title02)(object)((GComponent)this).GetChild("titleCom");
		n9 = (GImage)((GComponent)this).GetChild("n9");
		n10 = (GTextField)((GComponent)this).GetChild("n10");
		string id = "ui://r1j1a2l0e3ph1".Replace("ui://", "") + "-" + ((GObject)n10).id;
		((GObject)n10).text = LanguagesManager.GetDesc(id);
		BigPlayerLevelText = (GTextField)((GComponent)this).GetChild("BigPlayerLevelText");
		n12 = (GTextField)((GComponent)this).GetChild("n12");
		string id2 = "ui://r1j1a2l0e3ph1".Replace("ui://", "") + "-" + ((GObject)n12).id;
		((GObject)n12).text = LanguagesManager.GetDesc(id2);
		BigPlayerScoreText = (GTextField)((GComponent)this).GetChild("BigPlayerScoreText");
		n14 = (GGroup)((GComponent)this).GetChild("n14");
		n15 = (GImage)((GComponent)this).GetChild("n15");
		TabList = (GList)((GComponent)this).GetChild("TabList");
		DescBtn = (UI_btn_01)(object)((GComponent)this).GetChild("DescBtn");
		RechargeExtra = (UI_com_02)(object)((GComponent)this).GetChild("RechargeExtra");
		WeeklyPack = (UI_com_03)(object)((GComponent)this).GetChild("WeeklyPack");
		tq3 = (UI_com_04)(object)((GComponent)this).GetChild("tq3");
		tq4 = (UI_com_05)(object)((GComponent)this).GetChild("tq4");
		tq5 = (UI_com_07)(object)((GComponent)this).GetChild("tq5");
		tq6 = (UI_com_08)(object)((GComponent)this).GetChild("tq6");
		tq7 = (UI_com_06)(object)((GComponent)this).GetChild("tq7");
		RechargeBtn = (GButton)((GComponent)this).GetChild("RechargeBtn");
		n23 = (GImage)((GComponent)this).GetChild("n23");
		n24 = (GTextField)((GComponent)this).GetChild("n24");
		string id3 = "ui://r1j1a2l0e3ph1".Replace("ui://", "") + "-" + ((GObject)n24).id;
		((GObject)n24).text = LanguagesManager.GetDesc(id3);
	}
}
