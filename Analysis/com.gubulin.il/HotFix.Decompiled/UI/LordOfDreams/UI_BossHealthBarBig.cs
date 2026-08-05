using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.LordOfDreams;

public class UI_BossHealthBarBig : GComponent
{
	public GGraph n0;

	public GTextField BossName;

	public UI_BossHealthProgessBar HealthBar;

	public GList Abilities;

	public GTextField HpText;

	public const string URL = "ui://0i520nzmnmifo8o";

	public static string Name = "UI_BossHealthBarBig";

	public static string GetURL()
	{
		return "ui://0i520nzmnmifo8o";
	}

	public static UI_BossHealthBarBig CreateInstance()
	{
		return (UI_BossHealthBarBig)(object)UIPackage.CreateObject("LordOfDreams", "BossHealthBarBig");
	}

	public static UI_BossHealthBarBig CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_BossHealthBarBig).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://0i520nzmnmifo8o", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0035: Expected O, but got Unknown
		//IL_0057: Unknown result type (might be due to invalid IL or missing references)
		//IL_0061: Expected O, but got Unknown
		//IL_006d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0077: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		n0 = (GGraph)((GComponent)this).GetChild("n0");
		BossName = (GTextField)((GComponent)this).GetChild("BossName");
		HealthBar = (UI_BossHealthProgessBar)(object)((GComponent)this).GetChild("HealthBar");
		Abilities = (GList)((GComponent)this).GetChild("Abilities");
		HpText = (GTextField)((GComponent)this).GetChild("HpText");
		string id = "ui://0i520nzmnmifo8o".Replace("ui://", "") + "-" + ((GObject)HpText).id;
		((GObject)HpText).text = LanguagesManager.GetDesc(id);
	}
}
