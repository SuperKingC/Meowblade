using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGBrawlFight;

public class UI_com_FinalRewardPreview : GComponent
{
	public GList FinalRewards;

	public UI_com_FFAModeInstructions ffaPart;

	public UI_com_FactionWarModeInstructions factionPart;

	public GGroup vGroup;

	public const string URL = "ui://hozu168rniiv6t";

	public static string Name = "UI_com_FinalRewardPreview";

	public static string GetURL()
	{
		return "ui://hozu168rniiv6t";
	}

	public static UI_com_FinalRewardPreview CreateInstance()
	{
		return (UI_com_FinalRewardPreview)(object)UIPackage.CreateObject("GvGBrawlFight", "com_FinalRewardPreview");
	}

	public static UI_com_FinalRewardPreview CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_FinalRewardPreview).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://hozu168rniiv6t", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		//IL_0057: Unknown result type (might be due to invalid IL or missing references)
		//IL_0061: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		FinalRewards = (GList)((GComponent)this).GetChild("FinalRewards");
		ffaPart = (UI_com_FFAModeInstructions)(object)((GComponent)this).GetChild("ffaPart");
		factionPart = (UI_com_FactionWarModeInstructions)(object)((GComponent)this).GetChild("factionPart");
		vGroup = (GGroup)((GComponent)this).GetChild("vGroup");
	}
}
