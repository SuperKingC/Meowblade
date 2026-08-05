using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.ProgressionMission;

public class UI_ProgressionMissionAdvanceItem : GComponent
{
	public Controller Status;

	public Controller isMtg;

	public GGraph size;

	public GImage IconBg;

	public GImage n27;

	public GImage n22;

	public GImage n23;

	public GGroup n24;

	public GImage n20;

	public GLoader rewardIconAdvance;

	public GTextField NumAdvance;

	public GTextField rewardName;

	public UI_btn_Receive purchaseBtn;

	public UI_btn_confirm2 claimBtn;

	public GTextField price;

	public GComponent discount;

	public GImage n21;

	public GTextField MtgPrice;

	public GLoader MtgIcon;

	public Transition t0;

	public const string URL = "ui://mapat4i5nksh9g";

	public static string Name = "UI_ProgressionMissionAdvanceItem";

	public static string GetURL()
	{
		return "ui://mapat4i5nksh9g";
	}

	public static UI_ProgressionMissionAdvanceItem CreateInstance()
	{
		return (UI_ProgressionMissionAdvanceItem)(object)UIPackage.CreateObject("ProgressionMission", "ProgressionMissionAdvanceItem");
	}

	public static UI_ProgressionMissionAdvanceItem CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_ProgressionMissionAdvanceItem).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://mapat4i5nksh9g", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		//IL_017c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0186: Expected O, but got Unknown
		//IL_01cf: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d9: Expected O, but got Unknown
		//IL_01e5: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ef: Expected O, but got Unknown
		//IL_01fb: Unknown result type (might be due to invalid IL or missing references)
		//IL_0205: Expected O, but got Unknown
		//IL_0211: Unknown result type (might be due to invalid IL or missing references)
		//IL_021b: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		Status = ((GComponent)this).GetController("Status");
		isMtg = ((GComponent)this).GetController("isMtg");
		size = (GGraph)((GComponent)this).GetChild("size");
		IconBg = (GImage)((GComponent)this).GetChild("IconBg");
		n27 = (GImage)((GComponent)this).GetChild("n27");
		n22 = (GImage)((GComponent)this).GetChild("n22");
		n23 = (GImage)((GComponent)this).GetChild("n23");
		n24 = (GGroup)((GComponent)this).GetChild("n24");
		n20 = (GImage)((GComponent)this).GetChild("n20");
		rewardIconAdvance = (GLoader)((GComponent)this).GetChild("rewardIconAdvance");
		NumAdvance = (GTextField)((GComponent)this).GetChild("NumAdvance");
		rewardName = (GTextField)((GComponent)this).GetChild("rewardName");
		string id = "ui://mapat4i5nksh9g".Replace("ui://", "") + "-" + ((GObject)rewardName).id;
		((GObject)rewardName).text = LanguagesManager.GetDesc(id);
		purchaseBtn = (UI_btn_Receive)(object)((GComponent)this).GetChild("purchaseBtn");
		claimBtn = (UI_btn_confirm2)(object)((GComponent)this).GetChild("claimBtn");
		price = (GTextField)((GComponent)this).GetChild("price");
		string id2 = "ui://mapat4i5nksh9g".Replace("ui://", "") + "-" + ((GObject)price).id;
		((GObject)price).text = LanguagesManager.GetDesc(id2);
		discount = (GComponent)((GComponent)this).GetChild("discount");
		n21 = (GImage)((GComponent)this).GetChild("n21");
		MtgPrice = (GTextField)((GComponent)this).GetChild("MtgPrice");
		MtgIcon = (GLoader)((GComponent)this).GetChild("MtgIcon");
		t0 = ((GComponent)this).GetTransition("t0");
	}
}
