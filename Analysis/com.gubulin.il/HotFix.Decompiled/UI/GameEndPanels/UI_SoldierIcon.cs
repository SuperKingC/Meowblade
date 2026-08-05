using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.GameEndPanels;

public class UI_SoldierIcon : GComponent
{
	public Controller Type;

	public Controller MvpStatus;

	public GImage iconBack;

	public UI_DamageSoldierIcon Iconloader;

	public GLoader Frameloader;

	public GImage n9;

	public GTextField EnemyBossIcon;

	public GTextField OurBossIcon;

	public const string URL = "ui://hda5vzklrjqw3j";

	public static string Name = "UI_SoldierIcon";

	public static string GetURL()
	{
		return "ui://hda5vzklrjqw3j";
	}

	public static UI_SoldierIcon CreateInstance()
	{
		return (UI_SoldierIcon)(object)UIPackage.CreateObject("GameEndPanels", "SoldierIcon");
	}

	public static UI_SoldierIcon CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_SoldierIcon).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://hda5vzklrjqw3j", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0037: Unknown result type (might be due to invalid IL or missing references)
		//IL_0041: Expected O, but got Unknown
		//IL_0063: Unknown result type (might be due to invalid IL or missing references)
		//IL_006d: Expected O, but got Unknown
		//IL_0079: Unknown result type (might be due to invalid IL or missing references)
		//IL_0083: Expected O, but got Unknown
		//IL_008f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0099: Expected O, but got Unknown
		//IL_00e2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ec: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		Type = ((GComponent)this).GetController("Type");
		MvpStatus = ((GComponent)this).GetController("MvpStatus");
		iconBack = (GImage)((GComponent)this).GetChild("iconBack");
		Iconloader = (UI_DamageSoldierIcon)(object)((GComponent)this).GetChild("Iconloader");
		Frameloader = (GLoader)((GComponent)this).GetChild("Frameloader");
		n9 = (GImage)((GComponent)this).GetChild("n9");
		EnemyBossIcon = (GTextField)((GComponent)this).GetChild("EnemyBossIcon");
		string id = "ui://hda5vzklrjqw3j".Replace("ui://", "") + "-" + ((GObject)EnemyBossIcon).id;
		((GObject)EnemyBossIcon).text = LanguagesManager.GetDesc(id);
		OurBossIcon = (GTextField)((GComponent)this).GetChild("OurBossIcon");
		string id2 = "ui://hda5vzklrjqw3j".Replace("ui://", "") + "-" + ((GObject)OurBossIcon).id;
		((GObject)OurBossIcon).text = LanguagesManager.GetDesc(id2);
	}
}
