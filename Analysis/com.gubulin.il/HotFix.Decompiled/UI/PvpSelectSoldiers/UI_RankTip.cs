using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.PvpSelectSoldiers;

public class UI_RankTip : GComponent
{
	public GGraph n49;

	public GTextField n47;

	public GGraph n48;

	public GGroup n50;

	public const string URL = "ui://82mo10n5esrwdnr";

	public static string Name = "UI_RankTip";

	public static string GetURL()
	{
		return "ui://82mo10n5esrwdnr";
	}

	public static UI_RankTip CreateInstance()
	{
		return (UI_RankTip)(object)UIPackage.CreateObject("PvpSelectSoldiers", "RankTip");
	}

	public static UI_RankTip CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_RankTip).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://82mo10n5esrwdnr", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0035: Expected O, but got Unknown
		//IL_007e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0088: Expected O, but got Unknown
		//IL_0094: Unknown result type (might be due to invalid IL or missing references)
		//IL_009e: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		n49 = (GGraph)((GComponent)this).GetChild("n49");
		n47 = (GTextField)((GComponent)this).GetChild("n47");
		string id = "ui://82mo10n5esrwdnr".Replace("ui://", "") + "-" + ((GObject)n47).id;
		((GObject)n47).text = LanguagesManager.GetDesc(id);
		n48 = (GGraph)((GComponent)this).GetChild("n48");
		n50 = (GGroup)((GComponent)this).GetChild("n50");
	}
}
