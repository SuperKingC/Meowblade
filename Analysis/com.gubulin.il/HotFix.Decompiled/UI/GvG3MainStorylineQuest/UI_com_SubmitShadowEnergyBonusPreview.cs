using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvG3MainStorylineQuest;

public class UI_com_SubmitShadowEnergyBonusPreview : GComponent
{
	public GImage n5;

	public GList Bonus;

	public GImage n6;

	public const string URL = "ui://249h3k3dtq2ss5k";

	public static string Name = "UI_com_SubmitShadowEnergyBonusPreview";

	public static string GetURL()
	{
		return "ui://249h3k3dtq2ss5k";
	}

	public static UI_com_SubmitShadowEnergyBonusPreview CreateInstance()
	{
		return (UI_com_SubmitShadowEnergyBonusPreview)(object)UIPackage.CreateObject("GvG3MainStorylineQuest", "com_SubmitShadowEnergyBonusPreview");
	}

	public static UI_com_SubmitShadowEnergyBonusPreview CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_SubmitShadowEnergyBonusPreview).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://249h3k3dtq2ss5k", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		((GComponent)this).ConstructFromXML(xml);
		n5 = (GImage)((GComponent)this).GetChild("n5");
		Bonus = (GList)((GComponent)this).GetChild("Bonus");
		n6 = (GImage)((GComponent)this).GetChild("n6");
	}
}
