using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGWorldMap3;

public class UI_com_OuterTechI67502Popup : GComponent
{
	public GImage n0;

	public GImage n1;

	public GTextField n3;

	public GImage n4;

	public GTextField n2;

	public GTextField CostTip;

	public GGraph n8;

	public GTextField n7;

	public GLoader CostIcon;

	public GTextField CostCount;

	public GTextField n13;

	public UI_btn_UseOuterTechI67502 努力加餐饭Tip;

	public GTextField n17;

	public GTextField AvailableCount;

	public UI_btn_yes Confirm;

	public UI_btn_Cancel Cancel;

	public const string URL = "ui://4eq8fgd2qqhzs9f";

	public static string Name = "UI_com_OuterTechI67502Popup";

	public static string GetURL()
	{
		return "ui://4eq8fgd2qqhzs9f";
	}

	public static UI_com_OuterTechI67502Popup CreateInstance()
	{
		return (UI_com_OuterTechI67502Popup)(object)UIPackage.CreateObject("GvGWorldMap3", "com_OuterTechI67502Popup");
	}

	public static UI_com_OuterTechI67502Popup CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_OuterTechI67502Popup).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://4eq8fgd2qqhzs9f", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0035: Expected O, but got Unknown
		//IL_0041: Unknown result type (might be due to invalid IL or missing references)
		//IL_004b: Expected O, but got Unknown
		//IL_0094: Unknown result type (might be due to invalid IL or missing references)
		//IL_009e: Expected O, but got Unknown
		//IL_00aa: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b4: Expected O, but got Unknown
		//IL_00fd: Unknown result type (might be due to invalid IL or missing references)
		//IL_0107: Expected O, but got Unknown
		//IL_0113: Unknown result type (might be due to invalid IL or missing references)
		//IL_011d: Expected O, but got Unknown
		//IL_0129: Unknown result type (might be due to invalid IL or missing references)
		//IL_0133: Expected O, but got Unknown
		//IL_017c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0186: Expected O, but got Unknown
		//IL_0192: Unknown result type (might be due to invalid IL or missing references)
		//IL_019c: Expected O, but got Unknown
		//IL_01a8: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b2: Expected O, but got Unknown
		//IL_0211: Unknown result type (might be due to invalid IL or missing references)
		//IL_021b: Expected O, but got Unknown
		//IL_0266: Unknown result type (might be due to invalid IL or missing references)
		//IL_0270: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		n0 = (GImage)((GComponent)this).GetChild("n0");
		n1 = (GImage)((GComponent)this).GetChild("n1");
		n3 = (GTextField)((GComponent)this).GetChild("n3");
		string id = "ui://4eq8fgd2qqhzs9f".Replace("ui://", "") + "-" + ((GObject)n3).id;
		((GObject)n3).text = LanguagesManager.GetDesc(id);
		n4 = (GImage)((GComponent)this).GetChild("n4");
		n2 = (GTextField)((GComponent)this).GetChild("n2");
		string id2 = "ui://4eq8fgd2qqhzs9f".Replace("ui://", "") + "-" + ((GObject)n2).id;
		((GObject)n2).text = LanguagesManager.GetDesc(id2);
		CostTip = (GTextField)((GComponent)this).GetChild("CostTip");
		n8 = (GGraph)((GComponent)this).GetChild("n8");
		n7 = (GTextField)((GComponent)this).GetChild("n7");
		string id3 = "ui://4eq8fgd2qqhzs9f".Replace("ui://", "") + "-" + ((GObject)n7).id;
		((GObject)n7).text = LanguagesManager.GetDesc(id3);
		CostIcon = (GLoader)((GComponent)this).GetChild("CostIcon");
		CostCount = (GTextField)((GComponent)this).GetChild("CostCount");
		n13 = (GTextField)((GComponent)this).GetChild("n13");
		string id4 = "ui://4eq8fgd2qqhzs9f".Replace("ui://", "") + "-" + ((GObject)n13).id;
		((GObject)n13).text = LanguagesManager.GetDesc(id4);
		努力加餐饭Tip = (UI_btn_UseOuterTechI67502)(object)((GComponent)this).GetChild("努力加餐饭Tip");
		n17 = (GTextField)((GComponent)this).GetChild("n17");
		string id5 = "ui://4eq8fgd2qqhzs9f".Replace("ui://", "") + "-" + ((GObject)n17).id;
		((GObject)n17).text = LanguagesManager.GetDesc(id5);
		AvailableCount = (GTextField)((GComponent)this).GetChild("AvailableCount");
		Confirm = (UI_btn_yes)(object)((GComponent)this).GetChild("Confirm");
		Cancel = (UI_btn_Cancel)(object)((GComponent)this).GetChild("Cancel");
	}
}
