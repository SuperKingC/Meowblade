using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.Battle;

public class UI_BossAbility : GComponent
{
	public GLoader Icon;

	public GTextField Title;

	public const string URL = "ui://twlbabiccvfml8";

	public static string Name = "UI_BossAbility";

	public static string GetURL()
	{
		return "ui://twlbabiccvfml8";
	}

	public static UI_BossAbility CreateInstance()
	{
		return (UI_BossAbility)(object)UIPackage.CreateObject("Battle", "BossAbility");
	}

	public static UI_BossAbility CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_BossAbility).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://twlbabiccvfml8", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		Title = (GTextField)((GComponent)this).GetChild("Title");
		string id = "ui://twlbabiccvfml8".Replace("ui://", "") + "-" + ((GObject)Title).id;
		((GObject)Title).text = LanguagesManager.GetDesc(id);
	}
}
