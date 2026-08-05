using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.SoldierCultivate;

public class UI_CompoundSoulStoneDialog : GComponent
{
	public Controller Status;

	public GImage back;

	public GButton exitBtn;

	public GTextField title;

	public UI_ConfirmForSoulStoneSelect ConfirmBtn;

	public UI_compoundSoulStoneBtn MaxBtn;

	public GTextField title2nd;

	public GImage compoundNumBack;

	public GTextField compoundNum;

	public UI_increaseButton increaseBtn;

	public UI_reduceButton reduceBtn;

	public GButton curSoulStone;

	public GButton aimSoulStone;

	public GTextField tip1;

	public GGraph aimSoulStoneSfxBck;

	public GImage n12;

	public UI_CompoundDialogPageLeftBtn TurnPageLeftBtn;

	public UI_CompoundDialogPageRightBtn TurnPageRightBtn;

	public GTextField curNum;

	public GTextField aimNum;

	public GGraph aimNumSfxBack;

	public GGraph tip1SfxBack;

	public const string URL = "ui://7dantnbibunlt8r";

	public static string Name = "UI_CompoundSoulStoneDialog";

	public static string GetURL()
	{
		return "ui://7dantnbibunlt8r";
	}

	public static UI_CompoundSoulStoneDialog CreateInstance()
	{
		return (UI_CompoundSoulStoneDialog)(object)UIPackage.CreateObject("SoldierCultivate", "CompoundSoulStoneDialog");
	}

	public static UI_CompoundSoulStoneDialog CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_CompoundSoulStoneDialog).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://7dantnbibunlt8r", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Expected O, but got Unknown
		//IL_003c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0046: Expected O, but got Unknown
		//IL_0052: Unknown result type (might be due to invalid IL or missing references)
		//IL_005c: Expected O, but got Unknown
		//IL_00d1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00db: Expected O, but got Unknown
		//IL_0124: Unknown result type (might be due to invalid IL or missing references)
		//IL_012e: Expected O, but got Unknown
		//IL_013a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0144: Expected O, but got Unknown
		//IL_017c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0186: Expected O, but got Unknown
		//IL_0192: Unknown result type (might be due to invalid IL or missing references)
		//IL_019c: Expected O, but got Unknown
		//IL_01a8: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b2: Expected O, but got Unknown
		//IL_01fb: Unknown result type (might be due to invalid IL or missing references)
		//IL_0205: Expected O, but got Unknown
		//IL_0211: Unknown result type (might be due to invalid IL or missing references)
		//IL_021b: Expected O, but got Unknown
		//IL_0253: Unknown result type (might be due to invalid IL or missing references)
		//IL_025d: Expected O, but got Unknown
		//IL_0269: Unknown result type (might be due to invalid IL or missing references)
		//IL_0273: Expected O, but got Unknown
		//IL_027f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0289: Expected O, but got Unknown
		//IL_0295: Unknown result type (might be due to invalid IL or missing references)
		//IL_029f: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		Status = ((GComponent)this).GetController("Status");
		back = (GImage)((GComponent)this).GetChild("back");
		exitBtn = (GButton)((GComponent)this).GetChild("exitBtn");
		title = (GTextField)((GComponent)this).GetChild("title");
		string id = "ui://7dantnbibunlt8r".Replace("ui://", "") + "-" + ((GObject)title).id;
		((GObject)title).text = LanguagesManager.GetDesc(id);
		ConfirmBtn = (UI_ConfirmForSoulStoneSelect)(object)((GComponent)this).GetChild("ConfirmBtn");
		MaxBtn = (UI_compoundSoulStoneBtn)(object)((GComponent)this).GetChild("MaxBtn");
		title2nd = (GTextField)((GComponent)this).GetChild("title2nd");
		string id2 = "ui://7dantnbibunlt8r".Replace("ui://", "") + "-" + ((GObject)title2nd).id;
		((GObject)title2nd).text = LanguagesManager.GetDesc(id2);
		compoundNumBack = (GImage)((GComponent)this).GetChild("compoundNumBack");
		compoundNum = (GTextField)((GComponent)this).GetChild("compoundNum");
		increaseBtn = (UI_increaseButton)(object)((GComponent)this).GetChild("increaseBtn");
		reduceBtn = (UI_reduceButton)(object)((GComponent)this).GetChild("reduceBtn");
		curSoulStone = (GButton)((GComponent)this).GetChild("curSoulStone");
		aimSoulStone = (GButton)((GComponent)this).GetChild("aimSoulStone");
		tip1 = (GTextField)((GComponent)this).GetChild("tip1");
		string id3 = "ui://7dantnbibunlt8r".Replace("ui://", "") + "-" + ((GObject)tip1).id;
		((GObject)tip1).text = LanguagesManager.GetDesc(id3);
		aimSoulStoneSfxBck = (GGraph)((GComponent)this).GetChild("aimSoulStoneSfxBck");
		n12 = (GImage)((GComponent)this).GetChild("n12");
		TurnPageLeftBtn = (UI_CompoundDialogPageLeftBtn)(object)((GComponent)this).GetChild("TurnPageLeftBtn");
		TurnPageRightBtn = (UI_CompoundDialogPageRightBtn)(object)((GComponent)this).GetChild("TurnPageRightBtn");
		curNum = (GTextField)((GComponent)this).GetChild("curNum");
		aimNum = (GTextField)((GComponent)this).GetChild("aimNum");
		aimNumSfxBack = (GGraph)((GComponent)this).GetChild("aimNumSfxBack");
		tip1SfxBack = (GGraph)((GComponent)this).GetChild("tip1SfxBack");
	}
}
