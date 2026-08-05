using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGOuterTech;

public class UI_com_TechLotteryEntry : GComponent
{
	public Controller HasEnterIZ;

	public Controller NoticeType;

	public GImage n121;

	public GImage n128;

	public GTextField ItemName;

	public GImage n122;

	public GGraph GotoBtn;

	public GTextField ChipCount;

	public GLoader ChipIcon;

	public GImage n131;

	public GImage n130;

	public GTextField n127;

	public GGroup n132;

	public GImage n135;

	public UI_com_01 n136;

	public GMovieClip n137;

	public UI_com_AccelerateTip AccTip;

	public Transition t0;

	public const string URL = "ui://th385mtty63lk";

	public static string Name = "UI_com_TechLotteryEntry";

	public static string GetURL()
	{
		return "ui://th385mtty63lk";
	}

	public static UI_com_TechLotteryEntry CreateInstance()
	{
		return (UI_com_TechLotteryEntry)(object)UIPackage.CreateObject("GvGOuterTech", "com_TechLotteryEntry");
	}

	public static UI_com_TechLotteryEntry CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_TechLotteryEntry).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://th385mtty63lk", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		//IL_0150: Unknown result type (might be due to invalid IL or missing references)
		//IL_015a: Expected O, but got Unknown
		//IL_0166: Unknown result type (might be due to invalid IL or missing references)
		//IL_0170: Expected O, but got Unknown
		//IL_0192: Unknown result type (might be due to invalid IL or missing references)
		//IL_019c: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		HasEnterIZ = ((GComponent)this).GetController("HasEnterIZ");
		NoticeType = ((GComponent)this).GetController("NoticeType");
		n121 = (GImage)((GComponent)this).GetChild("n121");
		n128 = (GImage)((GComponent)this).GetChild("n128");
		ItemName = (GTextField)((GComponent)this).GetChild("ItemName");
		n122 = (GImage)((GComponent)this).GetChild("n122");
		GotoBtn = (GGraph)((GComponent)this).GetChild("GotoBtn");
		ChipCount = (GTextField)((GComponent)this).GetChild("ChipCount");
		ChipIcon = (GLoader)((GComponent)this).GetChild("ChipIcon");
		n131 = (GImage)((GComponent)this).GetChild("n131");
		n130 = (GImage)((GComponent)this).GetChild("n130");
		n127 = (GTextField)((GComponent)this).GetChild("n127");
		string id = "ui://th385mtty63lk".Replace("ui://", "") + "-" + ((GObject)n127).id;
		((GObject)n127).text = LanguagesManager.GetDesc(id);
		n132 = (GGroup)((GComponent)this).GetChild("n132");
		n135 = (GImage)((GComponent)this).GetChild("n135");
		n136 = (UI_com_01)(object)((GComponent)this).GetChild("n136");
		n137 = (GMovieClip)((GComponent)this).GetChild("n137");
		AccTip = (UI_com_AccelerateTip)(object)((GComponent)this).GetChild("AccTip");
		t0 = ((GComponent)this).GetTransition("t0");
	}
}
