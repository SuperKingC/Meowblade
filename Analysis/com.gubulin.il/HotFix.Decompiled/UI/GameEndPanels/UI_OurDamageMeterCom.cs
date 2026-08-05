using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.GameEndPanels;

public class UI_OurDamageMeterCom : GComponent
{
	public GTextField Title;

	public UI_OurHealthBar HealthBar;

	public GList SoldierDamageDataList;

	public const string URL = "ui://hda5vzklrjqw3d";

	public static string Name = "UI_OurDamageMeterCom";

	public static string GetURL()
	{
		return "ui://hda5vzklrjqw3d";
	}

	public static UI_OurDamageMeterCom CreateInstance()
	{
		return (UI_OurDamageMeterCom)(object)UIPackage.CreateObject("GameEndPanels", "OurDamageMeterCom");
	}

	public static UI_OurDamageMeterCom CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_OurDamageMeterCom).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://hda5vzklrjqw3d", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		string id = "ui://hda5vzklrjqw3d".Replace("ui://", "") + "-" + ((GObject)Title).id;
		((GObject)Title).text = LanguagesManager.GetDesc(id);
		HealthBar = (UI_OurHealthBar)(object)((GComponent)this).GetChild("HealthBar");
		SoldierDamageDataList = (GList)((GComponent)this).GetChild("SoldierDamageDataList");
	}
}
