using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.LegendItemDungeon;

public class UI_SelectPeakBattleArrayDialog : GComponent
{
	public Controller SoldiersStatus;

	public GImage back;

	public GGraph n62;

	public UI_PeakBattleSketchMap FormationSketchMap;

	public GGraph n61;

	public GImage flashImage;

	public GTextField OurCombat;

	public GTextField n47;

	public GGroup PowerMine;

	public GGraph n49;

	public GGraph n63;

	public UI_CurPeakFormation n52;

	public GImage SoldiersListBack;

	public UI_OpenSoliders SoldiersSwitch;

	public GList Soliders;

	public UI_confirm ConfirmBtn;

	public GImage n58;

	public GTextField n59;

	public GTextField n60;

	public const string URL = "ui://2eraz3j9ldt61x";

	public static string Name = "UI_SelectPeakBattleArrayDialog";

	public static string GetURL()
	{
		return "ui://2eraz3j9ldt61x";
	}

	public static UI_SelectPeakBattleArrayDialog CreateInstance()
	{
		return (UI_SelectPeakBattleArrayDialog)(object)UIPackage.CreateObject("LegendItemDungeon", "SelectPeakBattleArrayDialog");
	}

	public static UI_SelectPeakBattleArrayDialog CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_SelectPeakBattleArrayDialog).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://2eraz3j9ldt61x", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Expected O, but got Unknown
		//IL_003c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0046: Expected O, but got Unknown
		//IL_0068: Unknown result type (might be due to invalid IL or missing references)
		//IL_0072: Expected O, but got Unknown
		//IL_007e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0088: Expected O, but got Unknown
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
		//IL_0155: Unknown result type (might be due to invalid IL or missing references)
		//IL_015f: Expected O, but got Unknown
		//IL_0181: Unknown result type (might be due to invalid IL or missing references)
		//IL_018b: Expected O, but got Unknown
		//IL_01ad: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b7: Expected O, but got Unknown
		//IL_01c3: Unknown result type (might be due to invalid IL or missing references)
		//IL_01cd: Expected O, but got Unknown
		//IL_0216: Unknown result type (might be due to invalid IL or missing references)
		//IL_0220: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		SoldiersStatus = ((GComponent)this).GetController("SoldiersStatus");
		back = (GImage)((GComponent)this).GetChild("back");
		n62 = (GGraph)((GComponent)this).GetChild("n62");
		FormationSketchMap = (UI_PeakBattleSketchMap)(object)((GComponent)this).GetChild("FormationSketchMap");
		n61 = (GGraph)((GComponent)this).GetChild("n61");
		flashImage = (GImage)((GComponent)this).GetChild("flashImage");
		OurCombat = (GTextField)((GComponent)this).GetChild("OurCombat");
		n47 = (GTextField)((GComponent)this).GetChild("n47");
		string id = "ui://2eraz3j9ldt61x".Replace("ui://", "") + "-" + ((GObject)n47).id;
		((GObject)n47).text = LanguagesManager.GetDesc(id);
		PowerMine = (GGroup)((GComponent)this).GetChild("PowerMine");
		n49 = (GGraph)((GComponent)this).GetChild("n49");
		n63 = (GGraph)((GComponent)this).GetChild("n63");
		n52 = (UI_CurPeakFormation)(object)((GComponent)this).GetChild("n52");
		SoldiersListBack = (GImage)((GComponent)this).GetChild("SoldiersListBack");
		SoldiersSwitch = (UI_OpenSoliders)(object)((GComponent)this).GetChild("SoldiersSwitch");
		Soliders = (GList)((GComponent)this).GetChild("Soliders");
		ConfirmBtn = (UI_confirm)(object)((GComponent)this).GetChild("ConfirmBtn");
		n58 = (GImage)((GComponent)this).GetChild("n58");
		n59 = (GTextField)((GComponent)this).GetChild("n59");
		string id2 = "ui://2eraz3j9ldt61x".Replace("ui://", "") + "-" + ((GObject)n59).id;
		((GObject)n59).text = LanguagesManager.GetDesc(id2);
		n60 = (GTextField)((GComponent)this).GetChild("n60");
		string id3 = "ui://2eraz3j9ldt61x".Replace("ui://", "") + "-" + ((GObject)n60).id;
		((GObject)n60).text = LanguagesManager.GetDesc(id3);
	}
}
