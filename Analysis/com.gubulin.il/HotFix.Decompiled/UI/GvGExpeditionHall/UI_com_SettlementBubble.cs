using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGExpeditionHall;

public class UI_com_SettlementBubble : GComponent
{
	public Controller SettlementState;

	public Controller WarOrderState;

	public GImage n148;

	public GTextField n12;

	public GImage n170;

	public GImage n171;

	public GImage n190;

	public GImage n191;

	public GImage n173;

	public GTextField n16;

	public GTextField n192;

	public GTextField n176;

	public GTextField n179;

	public UI_com_CommonGoTo GoToSettlementBtn;

	public GImage n186;

	public GImage n187;

	public GImage n188;

	public GImage n183;

	public GTextField n17;

	public GTextField n193;

	public GTextField n177;

	public GTextField n178;

	public UI_com_CommonGoTo GoToWarOrderBtn;

	public GImage n184;

	public GImage n185;

	public Transition t0;

	public const string URL = "ui://k19peou7p3r7p5z";

	public static string Name = "UI_com_SettlementBubble";

	public static string GetURL()
	{
		return "ui://k19peou7p3r7p5z";
	}

	public static UI_com_SettlementBubble CreateInstance()
	{
		return (UI_com_SettlementBubble)(object)UIPackage.CreateObject("GvGExpeditionHall", "com_SettlementBubble");
	}

	public static UI_com_SettlementBubble CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_SettlementBubble).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://k19peou7p3r7p5z", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0037: Unknown result type (might be due to invalid IL or missing references)
		//IL_0041: Expected O, but got Unknown
		//IL_004d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0057: Expected O, but got Unknown
		//IL_00a0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00aa: Expected O, but got Unknown
		//IL_00b6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c0: Expected O, but got Unknown
		//IL_00cc: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d6: Expected O, but got Unknown
		//IL_00e2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ec: Expected O, but got Unknown
		//IL_00f8: Unknown result type (might be due to invalid IL or missing references)
		//IL_0102: Expected O, but got Unknown
		//IL_010e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0118: Expected O, but got Unknown
		//IL_0161: Unknown result type (might be due to invalid IL or missing references)
		//IL_016b: Expected O, but got Unknown
		//IL_01b4: Unknown result type (might be due to invalid IL or missing references)
		//IL_01be: Expected O, but got Unknown
		//IL_0207: Unknown result type (might be due to invalid IL or missing references)
		//IL_0211: Expected O, but got Unknown
		//IL_0272: Unknown result type (might be due to invalid IL or missing references)
		//IL_027c: Expected O, but got Unknown
		//IL_0288: Unknown result type (might be due to invalid IL or missing references)
		//IL_0292: Expected O, but got Unknown
		//IL_029e: Unknown result type (might be due to invalid IL or missing references)
		//IL_02a8: Expected O, but got Unknown
		//IL_02b4: Unknown result type (might be due to invalid IL or missing references)
		//IL_02be: Expected O, but got Unknown
		//IL_02ca: Unknown result type (might be due to invalid IL or missing references)
		//IL_02d4: Expected O, but got Unknown
		//IL_031f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0329: Expected O, but got Unknown
		//IL_0374: Unknown result type (might be due to invalid IL or missing references)
		//IL_037e: Expected O, but got Unknown
		//IL_03c9: Unknown result type (might be due to invalid IL or missing references)
		//IL_03d3: Expected O, but got Unknown
		//IL_0434: Unknown result type (might be due to invalid IL or missing references)
		//IL_043e: Expected O, but got Unknown
		//IL_044a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0454: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		SettlementState = ((GComponent)this).GetController("SettlementState");
		WarOrderState = ((GComponent)this).GetController("WarOrderState");
		n148 = (GImage)((GComponent)this).GetChild("n148");
		n12 = (GTextField)((GComponent)this).GetChild("n12");
		string id = "ui://k19peou7p3r7p5z".Replace("ui://", "") + "-" + ((GObject)n12).id;
		((GObject)n12).text = LanguagesManager.GetDesc(id);
		n170 = (GImage)((GComponent)this).GetChild("n170");
		n171 = (GImage)((GComponent)this).GetChild("n171");
		n190 = (GImage)((GComponent)this).GetChild("n190");
		n191 = (GImage)((GComponent)this).GetChild("n191");
		n173 = (GImage)((GComponent)this).GetChild("n173");
		n16 = (GTextField)((GComponent)this).GetChild("n16");
		string id2 = "ui://k19peou7p3r7p5z".Replace("ui://", "") + "-" + ((GObject)n16).id;
		((GObject)n16).text = LanguagesManager.GetDesc(id2);
		n192 = (GTextField)((GComponent)this).GetChild("n192");
		string id3 = "ui://k19peou7p3r7p5z".Replace("ui://", "") + "-" + ((GObject)n192).id;
		((GObject)n192).text = LanguagesManager.GetDesc(id3);
		n176 = (GTextField)((GComponent)this).GetChild("n176");
		string id4 = "ui://k19peou7p3r7p5z".Replace("ui://", "") + "-" + ((GObject)n176).id;
		((GObject)n176).text = LanguagesManager.GetDesc(id4);
		n179 = (GTextField)((GComponent)this).GetChild("n179");
		string id5 = "ui://k19peou7p3r7p5z".Replace("ui://", "") + "-" + ((GObject)n179).id;
		((GObject)n179).text = LanguagesManager.GetDesc(id5);
		GoToSettlementBtn = (UI_com_CommonGoTo)(object)((GComponent)this).GetChild("GoToSettlementBtn");
		n186 = (GImage)((GComponent)this).GetChild("n186");
		n187 = (GImage)((GComponent)this).GetChild("n187");
		n188 = (GImage)((GComponent)this).GetChild("n188");
		n183 = (GImage)((GComponent)this).GetChild("n183");
		n17 = (GTextField)((GComponent)this).GetChild("n17");
		string id6 = "ui://k19peou7p3r7p5z".Replace("ui://", "") + "-" + ((GObject)n17).id;
		((GObject)n17).text = LanguagesManager.GetDesc(id6);
		n193 = (GTextField)((GComponent)this).GetChild("n193");
		string id7 = "ui://k19peou7p3r7p5z".Replace("ui://", "") + "-" + ((GObject)n193).id;
		((GObject)n193).text = LanguagesManager.GetDesc(id7);
		n177 = (GTextField)((GComponent)this).GetChild("n177");
		string id8 = "ui://k19peou7p3r7p5z".Replace("ui://", "") + "-" + ((GObject)n177).id;
		((GObject)n177).text = LanguagesManager.GetDesc(id8);
		n178 = (GTextField)((GComponent)this).GetChild("n178");
		string id9 = "ui://k19peou7p3r7p5z".Replace("ui://", "") + "-" + ((GObject)n178).id;
		((GObject)n178).text = LanguagesManager.GetDesc(id9);
		GoToWarOrderBtn = (UI_com_CommonGoTo)(object)((GComponent)this).GetChild("GoToWarOrderBtn");
		n184 = (GImage)((GComponent)this).GetChild("n184");
		n185 = (GImage)((GComponent)this).GetChild("n185");
		t0 = ((GComponent)this).GetTransition("t0");
	}
}
