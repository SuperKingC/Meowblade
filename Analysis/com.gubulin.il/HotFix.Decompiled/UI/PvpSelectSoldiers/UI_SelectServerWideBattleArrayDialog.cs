using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.PvpSelectSoldiers;

public class UI_SelectServerWideBattleArrayDialog : GComponent
{
	public Controller SoldiersStatus;

	public GImage back;

	public GImage n73;

	public GImage n75;

	public GImage n74;

	public GImage n76;

	public GImage n72;

	public GTextField title;

	public UI_ServerWideBattleSketchMap FormationSketchMap;

	public GImage n77;

	public GImage flashImage;

	public GTextField OurCombat;

	public GTextField n47;

	public GGroup PowerMine;

	public GImage SoldiersListBack;

	public UI_OpenSoliders SoldiersSwitch;

	public GList Soliders;

	public GButton ConfirmBtn;

	public GTextField PopupTitle;

	public GTextField PopupTip;

	public GTextField Tips;

	public UI_SeasonBuffLabel SeasonBuffLabel;

	public UI_CurPeakFormation n52;

	public const string URL = "ui://82mo10n5lwk1jdum";

	public static string Name = "UI_SelectServerWideBattleArrayDialog";

	public static string GetURL()
	{
		return "ui://82mo10n5lwk1jdum";
	}

	public static UI_SelectServerWideBattleArrayDialog CreateInstance()
	{
		return (UI_SelectServerWideBattleArrayDialog)(object)UIPackage.CreateObject("PvpSelectSoldiers", "SelectServerWideBattleArrayDialog");
	}

	public static UI_SelectServerWideBattleArrayDialog CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_SelectServerWideBattleArrayDialog).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://82mo10n5lwk1jdum", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		//IL_0068: Unknown result type (might be due to invalid IL or missing references)
		//IL_0072: Expected O, but got Unknown
		//IL_007e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0088: Expected O, but got Unknown
		//IL_0094: Unknown result type (might be due to invalid IL or missing references)
		//IL_009e: Expected O, but got Unknown
		//IL_00aa: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b4: Expected O, but got Unknown
		//IL_0113: Unknown result type (might be due to invalid IL or missing references)
		//IL_011d: Expected O, but got Unknown
		//IL_0129: Unknown result type (might be due to invalid IL or missing references)
		//IL_0133: Expected O, but got Unknown
		//IL_013f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0149: Expected O, but got Unknown
		//IL_0155: Unknown result type (might be due to invalid IL or missing references)
		//IL_015f: Expected O, but got Unknown
		//IL_01a8: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b2: Expected O, but got Unknown
		//IL_01be: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c8: Expected O, but got Unknown
		//IL_01ea: Unknown result type (might be due to invalid IL or missing references)
		//IL_01f4: Expected O, but got Unknown
		//IL_0200: Unknown result type (might be due to invalid IL or missing references)
		//IL_020a: Expected O, but got Unknown
		//IL_0216: Unknown result type (might be due to invalid IL or missing references)
		//IL_0220: Expected O, but got Unknown
		//IL_0269: Unknown result type (might be due to invalid IL or missing references)
		//IL_0273: Expected O, but got Unknown
		//IL_02bc: Unknown result type (might be due to invalid IL or missing references)
		//IL_02c6: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		SoldiersStatus = ((GComponent)this).GetController("SoldiersStatus");
		back = (GImage)((GComponent)this).GetChild("back");
		n73 = (GImage)((GComponent)this).GetChild("n73");
		n75 = (GImage)((GComponent)this).GetChild("n75");
		n74 = (GImage)((GComponent)this).GetChild("n74");
		n76 = (GImage)((GComponent)this).GetChild("n76");
		n72 = (GImage)((GComponent)this).GetChild("n72");
		title = (GTextField)((GComponent)this).GetChild("title");
		string id = "ui://82mo10n5lwk1jdum".Replace("ui://", "") + "-" + ((GObject)title).id;
		((GObject)title).text = LanguagesManager.GetDesc(id);
		FormationSketchMap = (UI_ServerWideBattleSketchMap)(object)((GComponent)this).GetChild("FormationSketchMap");
		n77 = (GImage)((GComponent)this).GetChild("n77");
		flashImage = (GImage)((GComponent)this).GetChild("flashImage");
		OurCombat = (GTextField)((GComponent)this).GetChild("OurCombat");
		n47 = (GTextField)((GComponent)this).GetChild("n47");
		string id2 = "ui://82mo10n5lwk1jdum".Replace("ui://", "") + "-" + ((GObject)n47).id;
		((GObject)n47).text = LanguagesManager.GetDesc(id2);
		PowerMine = (GGroup)((GComponent)this).GetChild("PowerMine");
		SoldiersListBack = (GImage)((GComponent)this).GetChild("SoldiersListBack");
		SoldiersSwitch = (UI_OpenSoliders)(object)((GComponent)this).GetChild("SoldiersSwitch");
		Soliders = (GList)((GComponent)this).GetChild("Soliders");
		ConfirmBtn = (GButton)((GComponent)this).GetChild("ConfirmBtn");
		PopupTitle = (GTextField)((GComponent)this).GetChild("PopupTitle");
		string id3 = "ui://82mo10n5lwk1jdum".Replace("ui://", "") + "-" + ((GObject)PopupTitle).id;
		((GObject)PopupTitle).text = LanguagesManager.GetDesc(id3);
		PopupTip = (GTextField)((GComponent)this).GetChild("PopupTip");
		string id4 = "ui://82mo10n5lwk1jdum".Replace("ui://", "") + "-" + ((GObject)PopupTip).id;
		((GObject)PopupTip).text = LanguagesManager.GetDesc(id4);
		Tips = (GTextField)((GComponent)this).GetChild("Tips");
		string id5 = "ui://82mo10n5lwk1jdum".Replace("ui://", "") + "-" + ((GObject)Tips).id;
		((GObject)Tips).text = LanguagesManager.GetDesc(id5);
		SeasonBuffLabel = (UI_SeasonBuffLabel)(object)((GComponent)this).GetChild("SeasonBuffLabel");
		n52 = (UI_CurPeakFormation)(object)((GComponent)this).GetChild("n52");
	}
}
