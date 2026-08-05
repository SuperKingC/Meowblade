using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.IslandComeAgain;

public class UI_btn_RewardInfo : GButton
{
	public Controller button;

	public GImage n10;

	public GImage n11;

	public GTextField n12;

	public const string URL = "ui://k2sprg26laau6m";

	public static string Name = "UI_btn_RewardInfo";

	public static string GetURL()
	{
		return "ui://k2sprg26laau6m";
	}

	public static UI_btn_RewardInfo CreateInstance()
	{
		return (UI_btn_RewardInfo)(object)UIPackage.CreateObject("IslandComeAgain", "btn_RewardInfo");
	}

	public static UI_btn_RewardInfo CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_btn_RewardInfo).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://k2sprg26laau6m", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		((GComponent)this).ConstructFromXML(xml);
		button = ((GComponent)this).GetController("button");
		n10 = (GImage)((GComponent)this).GetChild("n10");
		n11 = (GImage)((GComponent)this).GetChild("n11");
		n12 = (GTextField)((GComponent)this).GetChild("n12");
		string id = "ui://k2sprg26laau6m".Replace("ui://", "") + "-" + ((GObject)n12).id;
		((GObject)n12).text = LanguagesManager.GetDesc(id);
	}
}
