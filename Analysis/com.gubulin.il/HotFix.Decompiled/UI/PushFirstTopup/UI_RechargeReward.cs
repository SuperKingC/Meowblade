using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.PushFirstTopup;

public class UI_RechargeReward : GButton
{
	public Controller button;

	public GImage iconBack;

	public GLoader icon;

	public GTextField num;

	public GTextField price;

	public const string URL = "ui://r9ncs56ehni6v44j";

	public static string Name = "UI_RechargeReward";

	public static string GetURL()
	{
		return "ui://r9ncs56ehni6v44j";
	}

	public static UI_RechargeReward CreateInstance()
	{
		return (UI_RechargeReward)(object)UIPackage.CreateObject("PushFirstTopup", "RechargeReward");
	}

	public static UI_RechargeReward CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_RechargeReward).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://r9ncs56ehni6v44j", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		//IL_00a5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00af: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		button = ((GComponent)this).GetController("button");
		iconBack = (GImage)((GComponent)this).GetChild("iconBack");
		icon = (GLoader)((GComponent)this).GetChild("icon");
		num = (GTextField)((GComponent)this).GetChild("num");
		string id = "ui://r9ncs56ehni6v44j".Replace("ui://", "") + "-" + ((GObject)num).id;
		((GObject)num).text = LanguagesManager.GetDesc(id);
		price = (GTextField)((GComponent)this).GetChild("price");
	}
}
