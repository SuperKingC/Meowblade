using FairyGUI;
using FairyGUI.Utils;

namespace UI.PushFirstTopup;

public class UI_com_FirstTopupDialog : GComponent
{
	public Controller BtnStatus;

	public GImage back;

	public GImage n48;

	public UI_RechargeBtn RechargeBtn;

	public UI_RechargeMainReward MainReward;

	public GList rewardList;

	public const string URL = "ui://r9ncs56ehni6v44d";

	public static string Name = "UI_com_FirstTopupDialog";

	public static string GetURL()
	{
		return "ui://r9ncs56ehni6v44d";
	}

	public static UI_com_FirstTopupDialog CreateInstance()
	{
		return (UI_com_FirstTopupDialog)(object)UIPackage.CreateObject("PushFirstTopup", "com_FirstTopupDialog");
	}

	public static UI_com_FirstTopupDialog CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_FirstTopupDialog).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://r9ncs56ehni6v44d", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Expected O, but got Unknown
		//IL_003c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0046: Expected O, but got Unknown
		//IL_007e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0088: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		BtnStatus = ((GComponent)this).GetController("BtnStatus");
		back = (GImage)((GComponent)this).GetChild("back");
		n48 = (GImage)((GComponent)this).GetChild("n48");
		RechargeBtn = (UI_RechargeBtn)(object)((GComponent)this).GetChild("RechargeBtn");
		MainReward = (UI_RechargeMainReward)(object)((GComponent)this).GetChild("MainReward");
		rewardList = (GList)((GComponent)this).GetChild("rewardList");
	}
}
