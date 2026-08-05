using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.SoldierCultivate;

public class UI_SoldierSoulStonePage : GComponent
{
	public Controller NumStatus;

	public Controller Status;

	public GImage n188;

	public GGraph n189;

	public GGroup backgroup;

	public GList soulStoneSelectList;

	public GTextField title;

	public GTextField title2nd;

	public GButton QuickCompoundBtn;

	public GButton CompoundBtn;

	public UI_SoulStoneForSelectBtn2 soulStone1;

	public UI_SoulStoneForSelectBtn2 soulStone2;

	public UI_SoulStoneForSelectBtn2 soulStone3;

	public UI_SoulStoneForSelectBtn2 aimSoulStone;

	public GImage n217;

	public GImage n218;

	public GImage n219;

	public GGroup soulStoneGroup;

	public UI_SoulStoneForSelectBtn2 CSoulStone;

	public GTextField num;

	public UI_GetNow QuicklyGain;

	public const string URL = "ui://7dantnbiwqizt9p";

	public static string Name = "UI_SoldierSoulStonePage";

	public void SetControllerPageText()
	{
		string id = string.Format("{0}-{1}-{2}", "ui://7dantnbiwqizt9p".Replace("ui://", ""), ((GObject)title2nd).id, Status.selectedIndex);
		((GObject)title2nd).text = LanguagesManager.GetDesc(id);
	}

	public static string GetURL()
	{
		return "ui://7dantnbiwqizt9p";
	}

	public static UI_SoldierSoulStonePage CreateInstance()
	{
		return (UI_SoldierSoulStonePage)(object)UIPackage.CreateObject("SoldierCultivate", "SoldierSoulStonePage");
	}

	public static UI_SoldierSoulStonePage CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_SoldierSoulStonePage).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://7dantnbiwqizt9p", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		//IL_00e2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ec: Expected O, but got Unknown
		//IL_0135: Unknown result type (might be due to invalid IL or missing references)
		//IL_013f: Expected O, but got Unknown
		//IL_014b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0155: Expected O, but got Unknown
		//IL_01b9: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c3: Expected O, but got Unknown
		//IL_01cf: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d9: Expected O, but got Unknown
		//IL_01e5: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ef: Expected O, but got Unknown
		//IL_01fb: Unknown result type (might be due to invalid IL or missing references)
		//IL_0205: Expected O, but got Unknown
		//IL_0227: Unknown result type (might be due to invalid IL or missing references)
		//IL_0231: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		NumStatus = ((GComponent)this).GetController("NumStatus");
		Status = ((GComponent)this).GetController("Status");
		n188 = (GImage)((GComponent)this).GetChild("n188");
		n189 = (GGraph)((GComponent)this).GetChild("n189");
		backgroup = (GGroup)((GComponent)this).GetChild("backgroup");
		soulStoneSelectList = (GList)((GComponent)this).GetChild("soulStoneSelectList");
		title = (GTextField)((GComponent)this).GetChild("title");
		string id = "ui://7dantnbiwqizt9p".Replace("ui://", "") + "-" + ((GObject)title).id;
		((GObject)title).text = LanguagesManager.GetDesc(id);
		title2nd = (GTextField)((GComponent)this).GetChild("title2nd");
		string id2 = "ui://7dantnbiwqizt9p".Replace("ui://", "") + "-" + ((GObject)title2nd).id;
		((GObject)title2nd).text = LanguagesManager.GetDesc(id2);
		QuickCompoundBtn = (GButton)((GComponent)this).GetChild("QuickCompoundBtn");
		CompoundBtn = (GButton)((GComponent)this).GetChild("CompoundBtn");
		soulStone1 = (UI_SoulStoneForSelectBtn2)(object)((GComponent)this).GetChild("soulStone1");
		soulStone2 = (UI_SoulStoneForSelectBtn2)(object)((GComponent)this).GetChild("soulStone2");
		soulStone3 = (UI_SoulStoneForSelectBtn2)(object)((GComponent)this).GetChild("soulStone3");
		aimSoulStone = (UI_SoulStoneForSelectBtn2)(object)((GComponent)this).GetChild("aimSoulStone");
		n217 = (GImage)((GComponent)this).GetChild("n217");
		n218 = (GImage)((GComponent)this).GetChild("n218");
		n219 = (GImage)((GComponent)this).GetChild("n219");
		soulStoneGroup = (GGroup)((GComponent)this).GetChild("soulStoneGroup");
		CSoulStone = (UI_SoulStoneForSelectBtn2)(object)((GComponent)this).GetChild("CSoulStone");
		num = (GTextField)((GComponent)this).GetChild("num");
		QuicklyGain = (UI_GetNow)(object)((GComponent)this).GetChild("QuicklyGain");
	}
}
