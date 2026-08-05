using FairyGUI;
using FairyGUI.Utils;

namespace UI.PvpSelectSoldiers;

public class UI_ResultRewardItem : GComponent
{
	public GLoader icon;

	public GTextField title;

	public const string URL = "ui://82mo10n5o6jgjdqc";

	public static string Name = "UI_ResultRewardItem";

	public static string GetURL()
	{
		return "ui://82mo10n5o6jgjdqc";
	}

	public static UI_ResultRewardItem CreateInstance()
	{
		return (UI_ResultRewardItem)(object)UIPackage.CreateObject("PvpSelectSoldiers", "ResultRewardItem");
	}

	public static UI_ResultRewardItem CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_ResultRewardItem).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://82mo10n5o6jgjdqc", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0035: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		icon = (GLoader)((GComponent)this).GetChild("icon");
		title = (GTextField)((GComponent)this).GetChild("title");
	}
}
