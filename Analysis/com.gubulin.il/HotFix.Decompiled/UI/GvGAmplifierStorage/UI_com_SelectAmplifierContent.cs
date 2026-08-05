using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGAmplifierStorage;

public class UI_com_SelectAmplifierContent : GComponent
{
	public Controller hasSelectedAmp;

	public Controller hasSelectAmp;

	public GImage n117;

	public GImage n118;

	public GImage n160;

	public GImage n158;

	public GImage n159;

	public GImage n157;

	public GImage n162;

	public GImage n156;

	public GList AmplifierList;

	public GButton confirmBtn;

	public GTextField n152;

	public GTextField countDesc;

	public GGroup n155;

	public UI_AmplifierSlot2 selectAmpIcon;

	public GTextField ampName;

	public GList PropList;

	public GGroup infoGroup;

	public UI_exitBtn BackBtn;

	public GList filterList;

	public GImage n163;

	public GTextField n165;

	public GGroup n166;

	public GImage n167;

	public GImage n168;

	public GTextField n170;

	public GGroup n169;

	public const string URL = "ui://fwpu3639gi5q10";

	public static string Name = "UI_com_SelectAmplifierContent";

	public static string GetURL()
	{
		return "ui://fwpu3639gi5q10";
	}

	public static UI_com_SelectAmplifierContent CreateInstance()
	{
		return (UI_com_SelectAmplifierContent)(object)UIPackage.CreateObject("GvGAmplifierStorage", "com_SelectAmplifierContent");
	}

	public static UI_com_SelectAmplifierContent CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_SelectAmplifierContent).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://fwpu3639gi5q10", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		//IL_00bb: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c5: Expected O, but got Unknown
		//IL_00d1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00db: Expected O, but got Unknown
		//IL_00e7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f1: Expected O, but got Unknown
		//IL_00fd: Unknown result type (might be due to invalid IL or missing references)
		//IL_0107: Expected O, but got Unknown
		//IL_0113: Unknown result type (might be due to invalid IL or missing references)
		//IL_011d: Expected O, but got Unknown
		//IL_0166: Unknown result type (might be due to invalid IL or missing references)
		//IL_0170: Expected O, but got Unknown
		//IL_01b9: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c3: Expected O, but got Unknown
		//IL_01e5: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ef: Expected O, but got Unknown
		//IL_0238: Unknown result type (might be due to invalid IL or missing references)
		//IL_0242: Expected O, but got Unknown
		//IL_024e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0258: Expected O, but got Unknown
		//IL_027a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0284: Expected O, but got Unknown
		//IL_0290: Unknown result type (might be due to invalid IL or missing references)
		//IL_029a: Expected O, but got Unknown
		//IL_02a6: Unknown result type (might be due to invalid IL or missing references)
		//IL_02b0: Expected O, but got Unknown
		//IL_02f9: Unknown result type (might be due to invalid IL or missing references)
		//IL_0303: Expected O, but got Unknown
		//IL_030f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0319: Expected O, but got Unknown
		//IL_0325: Unknown result type (might be due to invalid IL or missing references)
		//IL_032f: Expected O, but got Unknown
		//IL_033b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0345: Expected O, but got Unknown
		//IL_0390: Unknown result type (might be due to invalid IL or missing references)
		//IL_039a: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		hasSelectedAmp = ((GComponent)this).GetController("hasSelectedAmp");
		hasSelectAmp = ((GComponent)this).GetController("hasSelectAmp");
		n117 = (GImage)((GComponent)this).GetChild("n117");
		n118 = (GImage)((GComponent)this).GetChild("n118");
		n160 = (GImage)((GComponent)this).GetChild("n160");
		n158 = (GImage)((GComponent)this).GetChild("n158");
		n159 = (GImage)((GComponent)this).GetChild("n159");
		n157 = (GImage)((GComponent)this).GetChild("n157");
		n162 = (GImage)((GComponent)this).GetChild("n162");
		n156 = (GImage)((GComponent)this).GetChild("n156");
		AmplifierList = (GList)((GComponent)this).GetChild("AmplifierList");
		confirmBtn = (GButton)((GComponent)this).GetChild("confirmBtn");
		n152 = (GTextField)((GComponent)this).GetChild("n152");
		string id = "ui://fwpu3639gi5q10".Replace("ui://", "") + "-" + ((GObject)n152).id;
		((GObject)n152).text = LanguagesManager.GetDesc(id);
		countDesc = (GTextField)((GComponent)this).GetChild("countDesc");
		string id2 = "ui://fwpu3639gi5q10".Replace("ui://", "") + "-" + ((GObject)countDesc).id;
		((GObject)countDesc).text = LanguagesManager.GetDesc(id2);
		n155 = (GGroup)((GComponent)this).GetChild("n155");
		selectAmpIcon = (UI_AmplifierSlot2)(object)((GComponent)this).GetChild("selectAmpIcon");
		ampName = (GTextField)((GComponent)this).GetChild("ampName");
		string id3 = "ui://fwpu3639gi5q10".Replace("ui://", "") + "-" + ((GObject)ampName).id;
		((GObject)ampName).text = LanguagesManager.GetDesc(id3);
		PropList = (GList)((GComponent)this).GetChild("PropList");
		infoGroup = (GGroup)((GComponent)this).GetChild("infoGroup");
		BackBtn = (UI_exitBtn)(object)((GComponent)this).GetChild("BackBtn");
		filterList = (GList)((GComponent)this).GetChild("filterList");
		n163 = (GImage)((GComponent)this).GetChild("n163");
		n165 = (GTextField)((GComponent)this).GetChild("n165");
		string id4 = "ui://fwpu3639gi5q10".Replace("ui://", "") + "-" + ((GObject)n165).id;
		((GObject)n165).text = LanguagesManager.GetDesc(id4);
		n166 = (GGroup)((GComponent)this).GetChild("n166");
		n167 = (GImage)((GComponent)this).GetChild("n167");
		n168 = (GImage)((GComponent)this).GetChild("n168");
		n170 = (GTextField)((GComponent)this).GetChild("n170");
		string id5 = "ui://fwpu3639gi5q10".Replace("ui://", "") + "-" + ((GObject)n170).id;
		((GObject)n170).text = LanguagesManager.GetDesc(id5);
		n169 = (GGroup)((GComponent)this).GetChild("n169");
	}
}
