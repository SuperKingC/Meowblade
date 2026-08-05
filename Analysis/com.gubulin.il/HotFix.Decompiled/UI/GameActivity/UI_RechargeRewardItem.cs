using FairyGUI;
using FairyGUI.Utils;

namespace UI.GameActivity;

public class UI_RechargeRewardItem : GComponent
{
	public GGraph n17;

	public GGraph fxBack;

	public GLoader rewardIcon;

	public GTextField rewardNum;

	public const string URL = "ui://29q48tv6gawy1h";

	public static string Name = "UI_RechargeRewardItem";

	public static string GetURL()
	{
		return "ui://29q48tv6gawy1h";
	}

	public static UI_RechargeRewardItem CreateInstance()
	{
		return (UI_RechargeRewardItem)(object)UIPackage.CreateObject("GameActivity", "RechargeRewardItem");
	}

	public static UI_RechargeRewardItem CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_RechargeRewardItem).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://29q48tv6gawy1h", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0035: Expected O, but got Unknown
		//IL_0041: Unknown result type (might be due to invalid IL or missing references)
		//IL_004b: Expected O, but got Unknown
		//IL_0057: Unknown result type (might be due to invalid IL or missing references)
		//IL_0061: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		n17 = (GGraph)((GComponent)this).GetChild("n17");
		fxBack = (GGraph)((GComponent)this).GetChild("fxBack");
		rewardIcon = (GLoader)((GComponent)this).GetChild("rewardIcon");
		rewardNum = (GTextField)((GComponent)this).GetChild("rewardNum");
	}
}
