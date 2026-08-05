using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.Tips;

public class UI_LordUpgradeTipDialog : GComponent
{
	public GImage n24;

	public GImage back;

	public GImage n22;

	public GImage n23;

	public GImage n21;

	public GImage n20;

	public GImage n19;

	public GLoader icon;

	public GTextField levelNum;

	public GMovieClip n25;

	public GMovieClip n26;

	public GTextField tip4;

	public GTextField tip2;

	public GImage n9;

	public GTextField tip3;

	public GImage n5;

	public GGroup n27;

	public UI_activate ConfirmBtn;

	public Transition showDial;

	public const string URL = "ui://47lbpgx9xooo48";

	public static string Name = "UI_LordUpgradeTipDialog";

	public static string GetURL()
	{
		return "ui://47lbpgx9xooo48";
	}

	public static UI_LordUpgradeTipDialog CreateInstance()
	{
		return (UI_LordUpgradeTipDialog)(object)UIPackage.CreateObject("Tips", "LordUpgradeTipDialog");
	}

	public static UI_LordUpgradeTipDialog CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_LordUpgradeTipDialog).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://47lbpgx9xooo48", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		//IL_0057: Unknown result type (might be due to invalid IL or missing references)
		//IL_0061: Expected O, but got Unknown
		//IL_006d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0077: Expected O, but got Unknown
		//IL_0083: Unknown result type (might be due to invalid IL or missing references)
		//IL_008d: Expected O, but got Unknown
		//IL_0099: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a3: Expected O, but got Unknown
		//IL_00af: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b9: Expected O, but got Unknown
		//IL_00c5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00cf: Expected O, but got Unknown
		//IL_0118: Unknown result type (might be due to invalid IL or missing references)
		//IL_0122: Expected O, but got Unknown
		//IL_012e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0138: Expected O, but got Unknown
		//IL_0144: Unknown result type (might be due to invalid IL or missing references)
		//IL_014e: Expected O, but got Unknown
		//IL_0197: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a1: Expected O, but got Unknown
		//IL_01ad: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b7: Expected O, but got Unknown
		//IL_01c3: Unknown result type (might be due to invalid IL or missing references)
		//IL_01cd: Expected O, but got Unknown
		//IL_01d9: Unknown result type (might be due to invalid IL or missing references)
		//IL_01e3: Expected O, but got Unknown
		//IL_01ef: Unknown result type (might be due to invalid IL or missing references)
		//IL_01f9: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		n24 = (GImage)((GComponent)this).GetChild("n24");
		back = (GImage)((GComponent)this).GetChild("back");
		n22 = (GImage)((GComponent)this).GetChild("n22");
		n23 = (GImage)((GComponent)this).GetChild("n23");
		n21 = (GImage)((GComponent)this).GetChild("n21");
		n20 = (GImage)((GComponent)this).GetChild("n20");
		n19 = (GImage)((GComponent)this).GetChild("n19");
		icon = (GLoader)((GComponent)this).GetChild("icon");
		levelNum = (GTextField)((GComponent)this).GetChild("levelNum");
		string id = "ui://47lbpgx9xooo48".Replace("ui://", "") + "-" + ((GObject)levelNum).id;
		((GObject)levelNum).text = LanguagesManager.GetDesc(id);
		n25 = (GMovieClip)((GComponent)this).GetChild("n25");
		n26 = (GMovieClip)((GComponent)this).GetChild("n26");
		tip4 = (GTextField)((GComponent)this).GetChild("tip4");
		string id2 = "ui://47lbpgx9xooo48".Replace("ui://", "") + "-" + ((GObject)tip4).id;
		((GObject)tip4).text = LanguagesManager.GetDesc(id2);
		tip2 = (GTextField)((GComponent)this).GetChild("tip2");
		n9 = (GImage)((GComponent)this).GetChild("n9");
		tip3 = (GTextField)((GComponent)this).GetChild("tip3");
		n5 = (GImage)((GComponent)this).GetChild("n5");
		n27 = (GGroup)((GComponent)this).GetChild("n27");
		ConfirmBtn = (UI_activate)(object)((GComponent)this).GetChild("ConfirmBtn");
		showDial = ((GComponent)this).GetTransition("showDial");
	}
}
