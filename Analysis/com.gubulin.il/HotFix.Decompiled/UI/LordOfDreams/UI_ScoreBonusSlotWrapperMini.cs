using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.LordOfDreams;

public class UI_ScoreBonusSlotWrapperMini : GComponent
{
	public Controller StateController;

	public UI_BonusItem Icon;

	public GTextField n4;

	public GTextField TargetScore;

	public GGroup n17;

	public UI_ClaimBtnMini ClaimBtn;

	public GTextField n19;

	public GTextField Num;

	public const string URL = "ui://0i520nzme91so95";

	public static string Name = "UI_ScoreBonusSlotWrapperMini";

	public static string GetURL()
	{
		return "ui://0i520nzme91so95";
	}

	public static UI_ScoreBonusSlotWrapperMini CreateInstance()
	{
		return (UI_ScoreBonusSlotWrapperMini)(object)UIPackage.CreateObject("LordOfDreams", "ScoreBonusSlotWrapperMini");
	}

	public static UI_ScoreBonusSlotWrapperMini CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_ScoreBonusSlotWrapperMini).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://0i520nzme91so95", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_003c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0046: Expected O, but got Unknown
		//IL_008f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0099: Expected O, but got Unknown
		//IL_00e2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ec: Expected O, but got Unknown
		//IL_010e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0118: Expected O, but got Unknown
		//IL_0161: Unknown result type (might be due to invalid IL or missing references)
		//IL_016b: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		StateController = ((GComponent)this).GetController("StateController");
		Icon = (UI_BonusItem)(object)((GComponent)this).GetChild("Icon");
		n4 = (GTextField)((GComponent)this).GetChild("n4");
		string id = "ui://0i520nzme91so95".Replace("ui://", "") + "-" + ((GObject)n4).id;
		((GObject)n4).text = LanguagesManager.GetDesc(id);
		TargetScore = (GTextField)((GComponent)this).GetChild("TargetScore");
		string id2 = "ui://0i520nzme91so95".Replace("ui://", "") + "-" + ((GObject)TargetScore).id;
		((GObject)TargetScore).text = LanguagesManager.GetDesc(id2);
		n17 = (GGroup)((GComponent)this).GetChild("n17");
		ClaimBtn = (UI_ClaimBtnMini)(object)((GComponent)this).GetChild("ClaimBtn");
		n19 = (GTextField)((GComponent)this).GetChild("n19");
		string id3 = "ui://0i520nzme91so95".Replace("ui://", "") + "-" + ((GObject)n19).id;
		((GObject)n19).text = LanguagesManager.GetDesc(id3);
		Num = (GTextField)((GComponent)this).GetChild("Num");
	}
}
