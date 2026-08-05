using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGPlayerCommand3;

public class UI_com_IssueCommand : GComponent
{
	public Controller CommandType;

	public Controller buffIcon;

	public GImage Background;

	public GImage n25;

	public GImage n26;

	public GImage n27;

	public GImage n28;

	public GTextField n1;

	public GTextField n2;

	public GTextField IslandName;

	public GLoader NewMessage;

	public GImage n33;

	public UI_com_SelectedMessage SelectedMessage;

	public GGroup n34;

	public UI_btn_CommandMessage n5;

	public GList Commands;

	public GTextField n13;

	public GLoader CostIcon;

	public GTextField CurStock;

	public GTextField CostNumber;

	public GButton n35;

	public GGroup n18;

	public UI_btn_ConfirmBtn Issue;

	public GList ContributionPointsAdd;

	public GList TimeAdd;

	public GImage n23;

	public GImage n24;

	public GTextField n8;

	public GTextField n7;

	public GTextField n9;

	public GTextField CommandEffect;

	public GGroup n22;

	public GTextField n29;

	public GTextField n30;

	public const string URL = "ui://vheg8vabeai3d";

	public static string Name = "UI_com_IssueCommand";

	public static string GetURL()
	{
		return "ui://vheg8vabeai3d";
	}

	public static UI_com_IssueCommand CreateInstance()
	{
		return (UI_com_IssueCommand)(object)UIPackage.CreateObject("GvGPlayerCommand3", "com_IssueCommand");
	}

	public static UI_com_IssueCommand CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_IssueCommand).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://vheg8vabeai3d", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		//IL_014b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0155: Expected O, but got Unknown
		//IL_0161: Unknown result type (might be due to invalid IL or missing references)
		//IL_016b: Expected O, but got Unknown
		//IL_0177: Unknown result type (might be due to invalid IL or missing references)
		//IL_0181: Expected O, but got Unknown
		//IL_01a3: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ad: Expected O, but got Unknown
		//IL_01cf: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d9: Expected O, but got Unknown
		//IL_01e5: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ef: Expected O, but got Unknown
		//IL_0238: Unknown result type (might be due to invalid IL or missing references)
		//IL_0242: Expected O, but got Unknown
		//IL_024e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0258: Expected O, but got Unknown
		//IL_0264: Unknown result type (might be due to invalid IL or missing references)
		//IL_026e: Expected O, but got Unknown
		//IL_027a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0284: Expected O, but got Unknown
		//IL_0290: Unknown result type (might be due to invalid IL or missing references)
		//IL_029a: Expected O, but got Unknown
		//IL_02bc: Unknown result type (might be due to invalid IL or missing references)
		//IL_02c6: Expected O, but got Unknown
		//IL_02d2: Unknown result type (might be due to invalid IL or missing references)
		//IL_02dc: Expected O, but got Unknown
		//IL_02e8: Unknown result type (might be due to invalid IL or missing references)
		//IL_02f2: Expected O, but got Unknown
		//IL_02fe: Unknown result type (might be due to invalid IL or missing references)
		//IL_0308: Expected O, but got Unknown
		//IL_0314: Unknown result type (might be due to invalid IL or missing references)
		//IL_031e: Expected O, but got Unknown
		//IL_0367: Unknown result type (might be due to invalid IL or missing references)
		//IL_0371: Expected O, but got Unknown
		//IL_03bc: Unknown result type (might be due to invalid IL or missing references)
		//IL_03c6: Expected O, but got Unknown
		//IL_0411: Unknown result type (might be due to invalid IL or missing references)
		//IL_041b: Expected O, but got Unknown
		//IL_0427: Unknown result type (might be due to invalid IL or missing references)
		//IL_0431: Expected O, but got Unknown
		//IL_043d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0447: Expected O, but got Unknown
		//IL_0492: Unknown result type (might be due to invalid IL or missing references)
		//IL_049c: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		CommandType = ((GComponent)this).GetController("CommandType");
		buffIcon = ((GComponent)this).GetController("buffIcon");
		Background = (GImage)((GComponent)this).GetChild("Background");
		n25 = (GImage)((GComponent)this).GetChild("n25");
		n26 = (GImage)((GComponent)this).GetChild("n26");
		n27 = (GImage)((GComponent)this).GetChild("n27");
		n28 = (GImage)((GComponent)this).GetChild("n28");
		n1 = (GTextField)((GComponent)this).GetChild("n1");
		string id = "ui://vheg8vabeai3d".Replace("ui://", "") + "-" + ((GObject)n1).id;
		((GObject)n1).text = LanguagesManager.GetDesc(id);
		n2 = (GTextField)((GComponent)this).GetChild("n2");
		string id2 = "ui://vheg8vabeai3d".Replace("ui://", "") + "-" + ((GObject)n2).id;
		((GObject)n2).text = LanguagesManager.GetDesc(id2);
		IslandName = (GTextField)((GComponent)this).GetChild("IslandName");
		NewMessage = (GLoader)((GComponent)this).GetChild("NewMessage");
		n33 = (GImage)((GComponent)this).GetChild("n33");
		SelectedMessage = (UI_com_SelectedMessage)(object)((GComponent)this).GetChild("SelectedMessage");
		n34 = (GGroup)((GComponent)this).GetChild("n34");
		n5 = (UI_btn_CommandMessage)(object)((GComponent)this).GetChild("n5");
		Commands = (GList)((GComponent)this).GetChild("Commands");
		n13 = (GTextField)((GComponent)this).GetChild("n13");
		string id3 = "ui://vheg8vabeai3d".Replace("ui://", "") + "-" + ((GObject)n13).id;
		((GObject)n13).text = LanguagesManager.GetDesc(id3);
		CostIcon = (GLoader)((GComponent)this).GetChild("CostIcon");
		CurStock = (GTextField)((GComponent)this).GetChild("CurStock");
		CostNumber = (GTextField)((GComponent)this).GetChild("CostNumber");
		n35 = (GButton)((GComponent)this).GetChild("n35");
		n18 = (GGroup)((GComponent)this).GetChild("n18");
		Issue = (UI_btn_ConfirmBtn)(object)((GComponent)this).GetChild("Issue");
		ContributionPointsAdd = (GList)((GComponent)this).GetChild("ContributionPointsAdd");
		TimeAdd = (GList)((GComponent)this).GetChild("TimeAdd");
		n23 = (GImage)((GComponent)this).GetChild("n23");
		n24 = (GImage)((GComponent)this).GetChild("n24");
		n8 = (GTextField)((GComponent)this).GetChild("n8");
		string id4 = "ui://vheg8vabeai3d".Replace("ui://", "") + "-" + ((GObject)n8).id;
		((GObject)n8).text = LanguagesManager.GetDesc(id4);
		n7 = (GTextField)((GComponent)this).GetChild("n7");
		string id5 = "ui://vheg8vabeai3d".Replace("ui://", "") + "-" + ((GObject)n7).id;
		((GObject)n7).text = LanguagesManager.GetDesc(id5);
		n9 = (GTextField)((GComponent)this).GetChild("n9");
		string id6 = "ui://vheg8vabeai3d".Replace("ui://", "") + "-" + ((GObject)n9).id;
		((GObject)n9).text = LanguagesManager.GetDesc(id6);
		CommandEffect = (GTextField)((GComponent)this).GetChild("CommandEffect");
		n22 = (GGroup)((GComponent)this).GetChild("n22");
		n29 = (GTextField)((GComponent)this).GetChild("n29");
		string id7 = "ui://vheg8vabeai3d".Replace("ui://", "") + "-" + ((GObject)n29).id;
		((GObject)n29).text = LanguagesManager.GetDesc(id7);
		n30 = (GTextField)((GComponent)this).GetChild("n30");
		string id8 = "ui://vheg8vabeai3d".Replace("ui://", "") + "-" + ((GObject)n30).id;
		((GObject)n30).text = LanguagesManager.GetDesc(id8);
	}
}
