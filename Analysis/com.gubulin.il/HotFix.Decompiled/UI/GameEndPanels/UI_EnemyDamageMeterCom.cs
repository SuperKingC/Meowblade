using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.GameEndPanels;

public class UI_EnemyDamageMeterCom : GComponent
{
	public GTextField Title;

	public UI_EnemyHealthBar HealthBar;

	public GList SoldierDamageDataList;

	public const string URL = "ui://hda5vzklrjqw3l";

	public static string Name = "UI_EnemyDamageMeterCom";

	public static string GetURL()
	{
		return "ui://hda5vzklrjqw3l";
	}

	public static UI_EnemyDamageMeterCom CreateInstance()
	{
		return (UI_EnemyDamageMeterCom)(object)UIPackage.CreateObject("GameEndPanels", "EnemyDamageMeterCom");
	}

	public static UI_EnemyDamageMeterCom CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_EnemyDamageMeterCom).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://hda5vzklrjqw3l", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		//IL_007e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0088: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		Title = (GTextField)((GComponent)this).GetChild("Title");
		string id = "ui://hda5vzklrjqw3l".Replace("ui://", "") + "-" + ((GObject)Title).id;
		((GObject)Title).text = LanguagesManager.GetDesc(id);
		HealthBar = (UI_EnemyHealthBar)(object)((GComponent)this).GetChild("HealthBar");
		SoldierDamageDataList = (GList)((GComponent)this).GetChild("SoldierDamageDataList");
	}
}
