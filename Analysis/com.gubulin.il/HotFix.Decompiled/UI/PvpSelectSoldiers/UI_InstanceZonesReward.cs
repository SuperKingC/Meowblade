using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.PvpSelectSoldiers;

public class UI_InstanceZonesReward : GComponent
{
	public Controller Status;

	public GImage back;

	public GGraph n21;

	public GTextField n39;

	public UI_DropStart MaxLevelUpReward;

	public GTextField MaxLevel;

	public GImage n29;

	public GGroup n16;

	public GImage n18;

	public GTextField LastClass;

	public GTextField CurClass;

	public UI_LevelDiy LastLevel;

	public GLoader ScoreIconFoo;

	public GTextField LastScore;

	public GLoader ScoreIconBar;

	public GTextField CurScore;

	public UI_LevelDiy CurLevel;

	public GImage n25;

	public GTextField n40;

	public GTextField n41;

	public GGroup n42;

	public Transition ChangeStatus;

	public Transition ShowMaxLevelUpReward;

	public const string URL = "ui://82mo10n5hcbs79";

	public static string Name = "UI_InstanceZonesReward";

	public void SetControllerPageText()
	{
		string id = string.Format("{0}-{1}-{2}", "ui://82mo10n5hcbs79".Replace("ui://", ""), ((GObject)n39).id, Status.selectedIndex);
		((GObject)n39).text = LanguagesManager.GetDesc(id);
	}

	public static string GetURL()
	{
		return "ui://82mo10n5hcbs79";
	}

	public static UI_InstanceZonesReward CreateInstance()
	{
		return (UI_InstanceZonesReward)(object)UIPackage.CreateObject("PvpSelectSoldiers", "InstanceZonesReward");
	}

	public static UI_InstanceZonesReward CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_InstanceZonesReward).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://82mo10n5hcbs79", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		//IL_00bb: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c5: Expected O, but got Unknown
		//IL_010e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0118: Expected O, but got Unknown
		//IL_0124: Unknown result type (might be due to invalid IL or missing references)
		//IL_012e: Expected O, but got Unknown
		//IL_013a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0144: Expected O, but got Unknown
		//IL_0150: Unknown result type (might be due to invalid IL or missing references)
		//IL_015a: Expected O, but got Unknown
		//IL_0166: Unknown result type (might be due to invalid IL or missing references)
		//IL_0170: Expected O, but got Unknown
		//IL_0192: Unknown result type (might be due to invalid IL or missing references)
		//IL_019c: Expected O, but got Unknown
		//IL_01a8: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b2: Expected O, but got Unknown
		//IL_01be: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c8: Expected O, but got Unknown
		//IL_01d4: Unknown result type (might be due to invalid IL or missing references)
		//IL_01de: Expected O, but got Unknown
		//IL_0200: Unknown result type (might be due to invalid IL or missing references)
		//IL_020a: Expected O, but got Unknown
		//IL_0216: Unknown result type (might be due to invalid IL or missing references)
		//IL_0220: Expected O, but got Unknown
		//IL_0269: Unknown result type (might be due to invalid IL or missing references)
		//IL_0273: Expected O, but got Unknown
		//IL_02bc: Unknown result type (might be due to invalid IL or missing references)
		//IL_02c6: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		Status = ((GComponent)this).GetController("Status");
		back = (GImage)((GComponent)this).GetChild("back");
		n21 = (GGraph)((GComponent)this).GetChild("n21");
		n39 = (GTextField)((GComponent)this).GetChild("n39");
		string id = "ui://82mo10n5hcbs79".Replace("ui://", "") + "-" + ((GObject)n39).id;
		((GObject)n39).text = LanguagesManager.GetDesc(id);
		MaxLevelUpReward = (UI_DropStart)(object)((GComponent)this).GetChild("MaxLevelUpReward");
		MaxLevel = (GTextField)((GComponent)this).GetChild("MaxLevel");
		string id2 = "ui://82mo10n5hcbs79".Replace("ui://", "") + "-" + ((GObject)MaxLevel).id;
		((GObject)MaxLevel).text = LanguagesManager.GetDesc(id2);
		n29 = (GImage)((GComponent)this).GetChild("n29");
		n16 = (GGroup)((GComponent)this).GetChild("n16");
		n18 = (GImage)((GComponent)this).GetChild("n18");
		LastClass = (GTextField)((GComponent)this).GetChild("LastClass");
		CurClass = (GTextField)((GComponent)this).GetChild("CurClass");
		LastLevel = (UI_LevelDiy)(object)((GComponent)this).GetChild("LastLevel");
		ScoreIconFoo = (GLoader)((GComponent)this).GetChild("ScoreIconFoo");
		LastScore = (GTextField)((GComponent)this).GetChild("LastScore");
		ScoreIconBar = (GLoader)((GComponent)this).GetChild("ScoreIconBar");
		CurScore = (GTextField)((GComponent)this).GetChild("CurScore");
		CurLevel = (UI_LevelDiy)(object)((GComponent)this).GetChild("CurLevel");
		n25 = (GImage)((GComponent)this).GetChild("n25");
		n40 = (GTextField)((GComponent)this).GetChild("n40");
		string id3 = "ui://82mo10n5hcbs79".Replace("ui://", "") + "-" + ((GObject)n40).id;
		((GObject)n40).text = LanguagesManager.GetDesc(id3);
		n41 = (GTextField)((GComponent)this).GetChild("n41");
		string id4 = "ui://82mo10n5hcbs79".Replace("ui://", "") + "-" + ((GObject)n41).id;
		((GObject)n41).text = LanguagesManager.GetDesc(id4);
		n42 = (GGroup)((GComponent)this).GetChild("n42");
		ChangeStatus = ((GComponent)this).GetTransition("ChangeStatus");
		ShowMaxLevelUpReward = ((GComponent)this).GetTransition("ShowMaxLevelUpReward");
	}
}
