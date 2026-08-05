using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvG3MainStorylineQuest;

public class UI_com_SubmitShadowEnergyBonus : GComponent
{
	public GLoader Icon;

	public GTextField BonusCount;

	public const string URL = "ui://249h3k3dtq2ss5j";

	public static string Name = "UI_com_SubmitShadowEnergyBonus";

	public static string GetURL()
	{
		return "ui://249h3k3dtq2ss5j";
	}

	public static UI_com_SubmitShadowEnergyBonus CreateInstance()
	{
		return (UI_com_SubmitShadowEnergyBonus)(object)UIPackage.CreateObject("GvG3MainStorylineQuest", "com_SubmitShadowEnergyBonus");
	}

	public static UI_com_SubmitShadowEnergyBonus CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_SubmitShadowEnergyBonus).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://249h3k3dtq2ss5j", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0035: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		Icon = (GLoader)((GComponent)this).GetChild("Icon");
		BonusCount = (GTextField)((GComponent)this).GetChild("BonusCount");
	}
}
