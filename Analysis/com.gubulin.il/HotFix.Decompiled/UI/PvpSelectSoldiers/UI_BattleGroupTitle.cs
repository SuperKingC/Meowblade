using FairyGUI;
using FairyGUI.Utils;

namespace UI.PvpSelectSoldiers;

public class UI_BattleGroupTitle : GButton
{
	public GImage n5;

	public GTextField title;

	public const string URL = "ui://82mo10n5rnlpjdtn";

	public static string Name = "UI_BattleGroupTitle";

	public static string GetURL()
	{
		return "ui://82mo10n5rnlpjdtn";
	}

	public static UI_BattleGroupTitle CreateInstance()
	{
		return (UI_BattleGroupTitle)(object)UIPackage.CreateObject("PvpSelectSoldiers", "BattleGroupTitle");
	}

	public static UI_BattleGroupTitle CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_BattleGroupTitle).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://82mo10n5rnlpjdtn", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0035: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		n5 = (GImage)((GComponent)this).GetChild("n5");
		title = (GTextField)((GComponent)this).GetChild("title");
	}
}
