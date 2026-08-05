using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvG3SupplyDepot;

public class UI_com_Contribution : GComponent
{
	public Controller Type;

	public Controller ScoreToday;

	public GImage n13;

	public GImage n32;

	public GImage n33;

	public GImage n19;

	public GImage n36;

	public GTextField n0;

	public GImage n34;

	public GLoader BoxIcon;

	public GGroup n28;

	public UI_btn_BoxDetail BoxDetail;

	public GTextField n4;

	public GLoader Icon;

	public GTextField TotalContribution;

	public UI_btn_Receive Receive;

	public GTextField n10;

	public GList Contributions;

	public UI_com_RewardItem Item0;

	public UI_com_RewardItem Item1;

	public UI_com_RewardItem Item2;

	public UI_com_RewardItem Item3;

	public UI_com_RewardItem Item4;

	public GGroup n25;

	public GTextField n14;

	public GTextField Countdown;

	public GGroup n26;

	public GTextField n30;

	public const string URL = "ui://pobej4q7mo53e";

	public static string Name = "UI_com_Contribution";

	public static string GetURL()
	{
		return "ui://pobej4q7mo53e";
	}

	public static UI_com_Contribution CreateInstance()
	{
		return (UI_com_Contribution)(object)UIPackage.CreateObject("GvG3SupplyDepot", "com_Contribution");
	}

	public static UI_com_Contribution CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_Contribution).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://pobej4q7mo53e", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		//IL_00f8: Unknown result type (might be due to invalid IL or missing references)
		//IL_0102: Expected O, but got Unknown
		//IL_010e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0118: Expected O, but got Unknown
		//IL_0124: Unknown result type (might be due to invalid IL or missing references)
		//IL_012e: Expected O, but got Unknown
		//IL_0150: Unknown result type (might be due to invalid IL or missing references)
		//IL_015a: Expected O, but got Unknown
		//IL_01a3: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ad: Expected O, but got Unknown
		//IL_01b9: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c3: Expected O, but got Unknown
		//IL_01e5: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ef: Expected O, but got Unknown
		//IL_0238: Unknown result type (might be due to invalid IL or missing references)
		//IL_0242: Expected O, but got Unknown
		//IL_02bc: Unknown result type (might be due to invalid IL or missing references)
		//IL_02c6: Expected O, but got Unknown
		//IL_02d2: Unknown result type (might be due to invalid IL or missing references)
		//IL_02dc: Expected O, but got Unknown
		//IL_0325: Unknown result type (might be due to invalid IL or missing references)
		//IL_032f: Expected O, but got Unknown
		//IL_033b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0345: Expected O, but got Unknown
		//IL_0351: Unknown result type (might be due to invalid IL or missing references)
		//IL_035b: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		Type = ((GComponent)this).GetController("Type");
		ScoreToday = ((GComponent)this).GetController("ScoreToday");
		n13 = (GImage)((GComponent)this).GetChild("n13");
		n32 = (GImage)((GComponent)this).GetChild("n32");
		n33 = (GImage)((GComponent)this).GetChild("n33");
		n19 = (GImage)((GComponent)this).GetChild("n19");
		n36 = (GImage)((GComponent)this).GetChild("n36");
		n0 = (GTextField)((GComponent)this).GetChild("n0");
		string id = "ui://pobej4q7mo53e".Replace("ui://", "") + "-" + ((GObject)n0).id;
		((GObject)n0).text = LanguagesManager.GetDesc(id);
		n34 = (GImage)((GComponent)this).GetChild("n34");
		BoxIcon = (GLoader)((GComponent)this).GetChild("BoxIcon");
		n28 = (GGroup)((GComponent)this).GetChild("n28");
		BoxDetail = (UI_btn_BoxDetail)(object)((GComponent)this).GetChild("BoxDetail");
		n4 = (GTextField)((GComponent)this).GetChild("n4");
		string id2 = "ui://pobej4q7mo53e".Replace("ui://", "") + "-" + ((GObject)n4).id;
		((GObject)n4).text = LanguagesManager.GetDesc(id2);
		Icon = (GLoader)((GComponent)this).GetChild("Icon");
		TotalContribution = (GTextField)((GComponent)this).GetChild("TotalContribution");
		Receive = (UI_btn_Receive)(object)((GComponent)this).GetChild("Receive");
		n10 = (GTextField)((GComponent)this).GetChild("n10");
		string id3 = "ui://pobej4q7mo53e".Replace("ui://", "") + "-" + ((GObject)n10).id;
		((GObject)n10).text = LanguagesManager.GetDesc(id3);
		Contributions = (GList)((GComponent)this).GetChild("Contributions");
		Item0 = (UI_com_RewardItem)(object)((GComponent)this).GetChild("Item0");
		Item1 = (UI_com_RewardItem)(object)((GComponent)this).GetChild("Item1");
		Item2 = (UI_com_RewardItem)(object)((GComponent)this).GetChild("Item2");
		Item3 = (UI_com_RewardItem)(object)((GComponent)this).GetChild("Item3");
		Item4 = (UI_com_RewardItem)(object)((GComponent)this).GetChild("Item4");
		n25 = (GGroup)((GComponent)this).GetChild("n25");
		n14 = (GTextField)((GComponent)this).GetChild("n14");
		string id4 = "ui://pobej4q7mo53e".Replace("ui://", "") + "-" + ((GObject)n14).id;
		((GObject)n14).text = LanguagesManager.GetDesc(id4);
		Countdown = (GTextField)((GComponent)this).GetChild("Countdown");
		n26 = (GGroup)((GComponent)this).GetChild("n26");
		n30 = (GTextField)((GComponent)this).GetChild("n30");
		string id5 = "ui://pobej4q7mo53e".Replace("ui://", "") + "-" + ((GObject)n30).id;
		((GObject)n30).text = LanguagesManager.GetDesc(id5);
	}
}
