using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.GameActivity;

public class UI_com_RechargeComboPanel : GComponent
{
	public Controller PageController;

	public Controller RechargeStatus;

	public GImage n38;

	public GImage n39;

	public GTextField n44;

	public GGroup n45;

	public GButton RechargeBtn;

	public GGroup n41;

	public UI_RechargeMainReward MainReward;

	public GList rewardList;

	public GList dayTab;

	public GTextField n42;

	public const string URL = "ui://29q48tv6hvfx7z";

	public static string Name = "UI_com_RechargeComboPanel";

	public void SetButtonTitle()
	{
	}

	public static string GetURL()
	{
		return "ui://29q48tv6hvfx7z";
	}

	public static UI_com_RechargeComboPanel CreateInstance()
	{
		return (UI_com_RechargeComboPanel)(object)UIPackage.CreateObject("GameActivity", "com_RechargeComboPanel");
	}

	public static UI_com_RechargeComboPanel CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_RechargeComboPanel).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://29q48tv6hvfx7z", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		//IL_00b6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c0: Expected O, but got Unknown
		//IL_00cc: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d6: Expected O, but got Unknown
		//IL_00e2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ec: Expected O, but got Unknown
		//IL_010e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0118: Expected O, but got Unknown
		//IL_0124: Unknown result type (might be due to invalid IL or missing references)
		//IL_012e: Expected O, but got Unknown
		//IL_013a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0144: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		PageController = ((GComponent)this).GetController("PageController");
		RechargeStatus = ((GComponent)this).GetController("RechargeStatus");
		n38 = (GImage)((GComponent)this).GetChild("n38");
		n39 = (GImage)((GComponent)this).GetChild("n39");
		n44 = (GTextField)((GComponent)this).GetChild("n44");
		string id = "ui://29q48tv6hvfx7z".Replace("ui://", "") + "-" + ((GObject)n44).id;
		((GObject)n44).text = LanguagesManager.GetDesc(id);
		n45 = (GGroup)((GComponent)this).GetChild("n45");
		RechargeBtn = (GButton)((GComponent)this).GetChild("RechargeBtn");
		n41 = (GGroup)((GComponent)this).GetChild("n41");
		MainReward = (UI_RechargeMainReward)(object)((GComponent)this).GetChild("MainReward");
		rewardList = (GList)((GComponent)this).GetChild("rewardList");
		dayTab = (GList)((GComponent)this).GetChild("dayTab");
		n42 = (GTextField)((GComponent)this).GetChild("n42");
		string id2 = "ui://29q48tv6hvfx7z".Replace("ui://", "") + "-" + ((GObject)n42).id;
		((GObject)n42).text = LanguagesManager.GetDesc(id2);
	}
}
