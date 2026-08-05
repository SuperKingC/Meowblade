using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.SpecialActivity;

public class UI_btn_RewardDetail : GButton
{
	public GGraph n51;

	public GTextField n50;

	public GButton Help;

	public const string URL = "ui://kozswd8hhbr0f3w";

	public static string Name = "UI_btn_RewardDetail";

	public static string GetURL()
	{
		return "ui://kozswd8hhbr0f3w";
	}

	public static UI_btn_RewardDetail CreateInstance()
	{
		return (UI_btn_RewardDetail)(object)UIPackage.CreateObject("SpecialActivity", "btn_RewardDetail");
	}

	public static UI_btn_RewardDetail CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_btn_RewardDetail).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://kozswd8hhbr0f3w", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		((GComponent)this).ConstructFromXML(xml);
		n51 = (GGraph)((GComponent)this).GetChild("n51");
		n50 = (GTextField)((GComponent)this).GetChild("n50");
		string id = "ui://kozswd8hhbr0f3w".Replace("ui://", "") + "-" + ((GObject)n50).id;
		((GObject)n50).text = LanguagesManager.GetDesc(id);
		Help = (GButton)((GComponent)this).GetChild("Help");
	}
}
