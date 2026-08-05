using FairyGUI;
using FairyGUI.Utils;

namespace UI.IslandComeAgain;

public class UI_mc_SlotRewardInfo : GComponent
{
	public UI_mc_Slot Item;

	public GTextField PrizeName;

	public const string URL = "ui://k2sprg26x8oa6w";

	public static string Name = "UI_mc_SlotRewardInfo";

	public static string GetURL()
	{
		return "ui://k2sprg26x8oa6w";
	}

	public static UI_mc_SlotRewardInfo CreateInstance()
	{
		return (UI_mc_SlotRewardInfo)(object)UIPackage.CreateObject("IslandComeAgain", "mc_SlotRewardInfo");
	}

	public static UI_mc_SlotRewardInfo CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_mc_SlotRewardInfo).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://k2sprg26x8oa6w", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0035: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		Item = (UI_mc_Slot)(object)((GComponent)this).GetChild("Item");
		PrizeName = (GTextField)((GComponent)this).GetChild("PrizeName");
	}
}
