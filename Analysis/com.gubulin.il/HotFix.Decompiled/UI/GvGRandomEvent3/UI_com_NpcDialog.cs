using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGRandomEvent3;

public class UI_com_NpcDialog : GComponent
{
	public Controller Status;

	public Controller HasLimitedTime;

	public Controller TextColor;

	public Controller RewardDisplayController;

	public Controller hasOuterTech;

	public GImage n0;

	public GImage n19;

	public GImage n17;

	public GImage n23;

	public GImage n28;

	public GImage n29;

	public GImage n31;

	public GImage n25;

	public GImage n32;

	public GImage n18;

	public GTextField EventName;

	public GLoader NpcIcon;

	public GTextField NpcText;

	public UI_com_NpcDialogContent EventDesc;

	public GImage n24;

	public GTextField n6;

	public GList Bonus;

	public UI_btn_ConfirmTake TakeBonus;

	public GLoader CostIcon;

	public GTextField n11;

	public GTextField CostNumber;

	public GGroup n26;

	public GGroup n13;

	public GTextField Countdown;

	public GTextField n15;

	public GGroup n16;

	public GImage n8;

	public GGroup n27;

	public UI_com_ResTip RpcTip;

	public const string URL = "ui://p4ocf6q0dc6m3";

	public static string Name = "UI_com_NpcDialog";

	public static string GetURL()
	{
		return "ui://p4ocf6q0dc6m3";
	}

	public static UI_com_NpcDialog CreateInstance()
	{
		return (UI_com_NpcDialog)(object)UIPackage.CreateObject("GvGRandomEvent3", "com_NpcDialog");
	}

	public static UI_com_NpcDialog CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_NpcDialog).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://p4ocf6q0dc6m3", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_006a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0074: Expected O, but got Unknown
		//IL_0080: Unknown result type (might be due to invalid IL or missing references)
		//IL_008a: Expected O, but got Unknown
		//IL_0096: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a0: Expected O, but got Unknown
		//IL_00ac: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b6: Expected O, but got Unknown
		//IL_00c2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00cc: Expected O, but got Unknown
		//IL_00d8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e2: Expected O, but got Unknown
		//IL_00ee: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f8: Expected O, but got Unknown
		//IL_0104: Unknown result type (might be due to invalid IL or missing references)
		//IL_010e: Expected O, but got Unknown
		//IL_011a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0124: Expected O, but got Unknown
		//IL_0130: Unknown result type (might be due to invalid IL or missing references)
		//IL_013a: Expected O, but got Unknown
		//IL_0146: Unknown result type (might be due to invalid IL or missing references)
		//IL_0150: Expected O, but got Unknown
		//IL_015c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0166: Expected O, but got Unknown
		//IL_0172: Unknown result type (might be due to invalid IL or missing references)
		//IL_017c: Expected O, but got Unknown
		//IL_019e: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a8: Expected O, but got Unknown
		//IL_01b4: Unknown result type (might be due to invalid IL or missing references)
		//IL_01be: Expected O, but got Unknown
		//IL_0207: Unknown result type (might be due to invalid IL or missing references)
		//IL_0211: Expected O, but got Unknown
		//IL_0233: Unknown result type (might be due to invalid IL or missing references)
		//IL_023d: Expected O, but got Unknown
		//IL_0249: Unknown result type (might be due to invalid IL or missing references)
		//IL_0253: Expected O, but got Unknown
		//IL_029c: Unknown result type (might be due to invalid IL or missing references)
		//IL_02a6: Expected O, but got Unknown
		//IL_02b2: Unknown result type (might be due to invalid IL or missing references)
		//IL_02bc: Expected O, but got Unknown
		//IL_02c8: Unknown result type (might be due to invalid IL or missing references)
		//IL_02d2: Expected O, but got Unknown
		//IL_02de: Unknown result type (might be due to invalid IL or missing references)
		//IL_02e8: Expected O, but got Unknown
		//IL_02f4: Unknown result type (might be due to invalid IL or missing references)
		//IL_02fe: Expected O, but got Unknown
		//IL_0347: Unknown result type (might be due to invalid IL or missing references)
		//IL_0351: Expected O, but got Unknown
		//IL_035d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0367: Expected O, but got Unknown
		//IL_0373: Unknown result type (might be due to invalid IL or missing references)
		//IL_037d: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		Status = ((GComponent)this).GetController("Status");
		HasLimitedTime = ((GComponent)this).GetController("HasLimitedTime");
		TextColor = ((GComponent)this).GetController("TextColor");
		RewardDisplayController = ((GComponent)this).GetController("RewardDisplayController");
		hasOuterTech = ((GComponent)this).GetController("hasOuterTech");
		n0 = (GImage)((GComponent)this).GetChild("n0");
		n19 = (GImage)((GComponent)this).GetChild("n19");
		n17 = (GImage)((GComponent)this).GetChild("n17");
		n23 = (GImage)((GComponent)this).GetChild("n23");
		n28 = (GImage)((GComponent)this).GetChild("n28");
		n29 = (GImage)((GComponent)this).GetChild("n29");
		n31 = (GImage)((GComponent)this).GetChild("n31");
		n25 = (GImage)((GComponent)this).GetChild("n25");
		n32 = (GImage)((GComponent)this).GetChild("n32");
		n18 = (GImage)((GComponent)this).GetChild("n18");
		EventName = (GTextField)((GComponent)this).GetChild("EventName");
		NpcIcon = (GLoader)((GComponent)this).GetChild("NpcIcon");
		NpcText = (GTextField)((GComponent)this).GetChild("NpcText");
		EventDesc = (UI_com_NpcDialogContent)(object)((GComponent)this).GetChild("EventDesc");
		n24 = (GImage)((GComponent)this).GetChild("n24");
		n6 = (GTextField)((GComponent)this).GetChild("n6");
		string id = "ui://p4ocf6q0dc6m3".Replace("ui://", "") + "-" + ((GObject)n6).id;
		((GObject)n6).text = LanguagesManager.GetDesc(id);
		Bonus = (GList)((GComponent)this).GetChild("Bonus");
		TakeBonus = (UI_btn_ConfirmTake)(object)((GComponent)this).GetChild("TakeBonus");
		CostIcon = (GLoader)((GComponent)this).GetChild("CostIcon");
		n11 = (GTextField)((GComponent)this).GetChild("n11");
		string id2 = "ui://p4ocf6q0dc6m3".Replace("ui://", "") + "-" + ((GObject)n11).id;
		((GObject)n11).text = LanguagesManager.GetDesc(id2);
		CostNumber = (GTextField)((GComponent)this).GetChild("CostNumber");
		n26 = (GGroup)((GComponent)this).GetChild("n26");
		n13 = (GGroup)((GComponent)this).GetChild("n13");
		Countdown = (GTextField)((GComponent)this).GetChild("Countdown");
		n15 = (GTextField)((GComponent)this).GetChild("n15");
		string id3 = "ui://p4ocf6q0dc6m3".Replace("ui://", "") + "-" + ((GObject)n15).id;
		((GObject)n15).text = LanguagesManager.GetDesc(id3);
		n16 = (GGroup)((GComponent)this).GetChild("n16");
		n8 = (GImage)((GComponent)this).GetChild("n8");
		n27 = (GGroup)((GComponent)this).GetChild("n27");
		RpcTip = (UI_com_ResTip)(object)((GComponent)this).GetChild("RpcTip");
	}
}
