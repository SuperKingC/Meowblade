using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGBrawlFight;

public class UI_com_RewardsList : GComponent
{
	public Controller type;

	public GImage n5;

	public GLoader Rewards;

	public const string URL = "ui://hozu168rsdaq8n";

	public static string Name = "UI_com_RewardsList";

	public static string GetURL()
	{
		return "ui://hozu168rsdaq8n";
	}

	public static UI_com_RewardsList CreateInstance()
	{
		return (UI_com_RewardsList)(object)UIPackage.CreateObject("GvGBrawlFight", "com_RewardsList");
	}

	public static UI_com_RewardsList CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_RewardsList).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://hozu168rsdaq8n", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Expected O, but got Unknown
		//IL_003c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0046: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		type = ((GComponent)this).GetController("type");
		n5 = (GImage)((GComponent)this).GetChild("n5");
		Rewards = (GLoader)((GComponent)this).GetChild("Rewards");
	}
}
