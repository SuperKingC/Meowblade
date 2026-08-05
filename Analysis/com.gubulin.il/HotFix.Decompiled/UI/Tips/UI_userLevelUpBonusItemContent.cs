using FairyGUI;
using FairyGUI.Utils;

namespace UI.Tips;

public class UI_userLevelUpBonusItemContent : GComponent
{
	public GLoader bonusIcon;

	public GRichTextField title;

	public GGraph SfxBack;

	public const string URL = "ui://47lbpgx9jc6h39";

	public static string Name = "UI_userLevelUpBonusItemContent";

	public static string GetURL()
	{
		return "ui://47lbpgx9jc6h39";
	}

	public static UI_userLevelUpBonusItemContent CreateInstance()
	{
		return (UI_userLevelUpBonusItemContent)(object)UIPackage.CreateObject("Tips", "userLevelUpBonusItemContent");
	}

	public static UI_userLevelUpBonusItemContent CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_userLevelUpBonusItemContent).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://47lbpgx9jc6h39", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		bonusIcon = (GLoader)((GComponent)this).GetChild("bonusIcon");
		title = (GRichTextField)((GComponent)this).GetChild("title");
		SfxBack = (GGraph)((GComponent)this).GetChild("SfxBack");
	}
}
