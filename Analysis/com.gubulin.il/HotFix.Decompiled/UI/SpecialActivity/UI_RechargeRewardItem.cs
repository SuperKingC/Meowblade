using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.SpecialActivity;

public class UI_RechargeRewardItem : GComponent
{
	public Controller IsShowContent;

	public Controller ExtraCount;

	public GImage n10;

	public GGraph fxBack;

	public GLoader rewardIcon;

	public GTextField rewardNum;

	public GLoader n61;

	public GLoader n28;

	public GLoader n31;

	public GLoader n33;

	public GLoader n54;

	public GLoader n59;

	public GLoader n63;

	public UI_ExtraContent ExtraContentUp;

	public GGroup UpGroup;

	public GLoader n45;

	public GLoader n46;

	public GLoader n47;

	public GLoader n55;

	public GLoader n58;

	public UI_ExtraContent ExtraContentDown;

	public GGroup DownGroup;

	public const string URL = "ui://kozswd8hqyx61f";

	public static string Name = "UI_RechargeRewardItem";

	public static string GetURL()
	{
		return "ui://kozswd8hqyx61f";
	}

	public static UI_RechargeRewardItem CreateInstance()
	{
		return (UI_RechargeRewardItem)(object)UIPackage.CreateObject("SpecialActivity", "RechargeRewardItem");
	}

	public static UI_RechargeRewardItem CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_RechargeRewardItem).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://kozswd8hqyx61f", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		//IL_00cc: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d6: Expected O, but got Unknown
		//IL_00e2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ec: Expected O, but got Unknown
		//IL_00f8: Unknown result type (might be due to invalid IL or missing references)
		//IL_0102: Expected O, but got Unknown
		//IL_010e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0118: Expected O, but got Unknown
		//IL_0124: Unknown result type (might be due to invalid IL or missing references)
		//IL_012e: Expected O, but got Unknown
		//IL_013a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0144: Expected O, but got Unknown
		//IL_0150: Unknown result type (might be due to invalid IL or missing references)
		//IL_015a: Expected O, but got Unknown
		//IL_017c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0186: Expected O, but got Unknown
		//IL_0192: Unknown result type (might be due to invalid IL or missing references)
		//IL_019c: Expected O, but got Unknown
		//IL_01a8: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b2: Expected O, but got Unknown
		//IL_01be: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c8: Expected O, but got Unknown
		//IL_01d4: Unknown result type (might be due to invalid IL or missing references)
		//IL_01de: Expected O, but got Unknown
		//IL_01ea: Unknown result type (might be due to invalid IL or missing references)
		//IL_01f4: Expected O, but got Unknown
		//IL_0216: Unknown result type (might be due to invalid IL or missing references)
		//IL_0220: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		IsShowContent = ((GComponent)this).GetController("IsShowContent");
		ExtraCount = ((GComponent)this).GetController("ExtraCount");
		n10 = (GImage)((GComponent)this).GetChild("n10");
		fxBack = (GGraph)((GComponent)this).GetChild("fxBack");
		rewardIcon = (GLoader)((GComponent)this).GetChild("rewardIcon");
		rewardNum = (GTextField)((GComponent)this).GetChild("rewardNum");
		string id = "ui://kozswd8hqyx61f".Replace("ui://", "") + "-" + ((GObject)rewardNum).id;
		((GObject)rewardNum).text = LanguagesManager.GetDesc(id);
		n61 = (GLoader)((GComponent)this).GetChild("n61");
		n28 = (GLoader)((GComponent)this).GetChild("n28");
		n31 = (GLoader)((GComponent)this).GetChild("n31");
		n33 = (GLoader)((GComponent)this).GetChild("n33");
		n54 = (GLoader)((GComponent)this).GetChild("n54");
		n59 = (GLoader)((GComponent)this).GetChild("n59");
		n63 = (GLoader)((GComponent)this).GetChild("n63");
		ExtraContentUp = (UI_ExtraContent)(object)((GComponent)this).GetChild("ExtraContentUp");
		UpGroup = (GGroup)((GComponent)this).GetChild("UpGroup");
		n45 = (GLoader)((GComponent)this).GetChild("n45");
		n46 = (GLoader)((GComponent)this).GetChild("n46");
		n47 = (GLoader)((GComponent)this).GetChild("n47");
		n55 = (GLoader)((GComponent)this).GetChild("n55");
		n58 = (GLoader)((GComponent)this).GetChild("n58");
		ExtraContentDown = (UI_ExtraContent)(object)((GComponent)this).GetChild("ExtraContentDown");
		DownGroup = (GGroup)((GComponent)this).GetChild("DownGroup");
	}
}
