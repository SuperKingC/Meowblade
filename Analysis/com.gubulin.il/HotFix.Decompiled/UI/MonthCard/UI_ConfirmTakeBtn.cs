using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.MonthCard;

public class UI_ConfirmTakeBtn : GButton
{
	public Controller button;

	public Controller RarityController;

	public Controller StatusController;

	public Controller showAssistantBtn;

	public GImage n3;

	public GImage n5;

	public GTextField n6;

	public GTextField n10;

	public GLoader specialRewardIcon;

	public GTextField specialRewardNum;

	public GGroup n9;

	public GGraph effPos1;

	public GGraph effPos2;

	public GGroup toBeClaim;

	public const string URL = "ui://4ctl553sv78k2g";

	public static string Name = "UI_ConfirmTakeBtn";

	public static string GetURL()
	{
		return "ui://4ctl553sv78k2g";
	}

	public static UI_ConfirmTakeBtn CreateInstance()
	{
		return (UI_ConfirmTakeBtn)(object)UIPackage.CreateObject("MonthCard", "ConfirmTakeBtn");
	}

	public static UI_ConfirmTakeBtn CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_ConfirmTakeBtn).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://4ctl553sv78k2g", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0059: Unknown result type (might be due to invalid IL or missing references)
		//IL_0063: Expected O, but got Unknown
		//IL_006f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0079: Expected O, but got Unknown
		//IL_0085: Unknown result type (might be due to invalid IL or missing references)
		//IL_008f: Expected O, but got Unknown
		//IL_00d8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e2: Expected O, but got Unknown
		//IL_012b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0135: Expected O, but got Unknown
		//IL_0141: Unknown result type (might be due to invalid IL or missing references)
		//IL_014b: Expected O, but got Unknown
		//IL_0157: Unknown result type (might be due to invalid IL or missing references)
		//IL_0161: Expected O, but got Unknown
		//IL_016d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0177: Expected O, but got Unknown
		//IL_0183: Unknown result type (might be due to invalid IL or missing references)
		//IL_018d: Expected O, but got Unknown
		//IL_0199: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a3: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		button = ((GComponent)this).GetController("button");
		RarityController = ((GComponent)this).GetController("RarityController");
		StatusController = ((GComponent)this).GetController("StatusController");
		showAssistantBtn = ((GComponent)this).GetController("showAssistantBtn");
		n3 = (GImage)((GComponent)this).GetChild("n3");
		n5 = (GImage)((GComponent)this).GetChild("n5");
		n6 = (GTextField)((GComponent)this).GetChild("n6");
		string id = "ui://4ctl553sv78k2g".Replace("ui://", "") + "-" + ((GObject)n6).id;
		((GObject)n6).text = LanguagesManager.GetDesc(id);
		n10 = (GTextField)((GComponent)this).GetChild("n10");
		string id2 = "ui://4ctl553sv78k2g".Replace("ui://", "") + "-" + ((GObject)n10).id;
		((GObject)n10).text = LanguagesManager.GetDesc(id2);
		specialRewardIcon = (GLoader)((GComponent)this).GetChild("specialRewardIcon");
		specialRewardNum = (GTextField)((GComponent)this).GetChild("specialRewardNum");
		n9 = (GGroup)((GComponent)this).GetChild("n9");
		effPos1 = (GGraph)((GComponent)this).GetChild("effPos1");
		effPos2 = (GGraph)((GComponent)this).GetChild("effPos2");
		toBeClaim = (GGroup)((GComponent)this).GetChild("toBeClaim");
	}
}
