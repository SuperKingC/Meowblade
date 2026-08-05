using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.Battle;

public class UI_EnemyInfomationBar : GComponent
{
	public GImage iconBack;

	public GImage n13;

	public GImage n14;

	public UI_Avatar Avatar;

	public GLoader Frameloader;

	public GTextField ArmyGroupName;

	public UI_EnemyHPbar HPBar;

	public const string URL = "ui://twlbabicwgjl13";

	public static string Name = "UI_EnemyInfomationBar";

	public static string GetURL()
	{
		return "ui://twlbabicwgjl13";
	}

	public static UI_EnemyInfomationBar CreateInstance()
	{
		return (UI_EnemyInfomationBar)(object)UIPackage.CreateObject("Battle", "EnemyInfomationBar");
	}

	public static UI_EnemyInfomationBar CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_EnemyInfomationBar).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://twlbabicwgjl13", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		//IL_006d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0077: Expected O, but got Unknown
		//IL_0083: Unknown result type (might be due to invalid IL or missing references)
		//IL_008d: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		iconBack = (GImage)((GComponent)this).GetChild("iconBack");
		n13 = (GImage)((GComponent)this).GetChild("n13");
		n14 = (GImage)((GComponent)this).GetChild("n14");
		Avatar = (UI_Avatar)(object)((GComponent)this).GetChild("Avatar");
		Frameloader = (GLoader)((GComponent)this).GetChild("Frameloader");
		ArmyGroupName = (GTextField)((GComponent)this).GetChild("ArmyGroupName");
		string id = "ui://twlbabicwgjl13".Replace("ui://", "") + "-" + ((GObject)ArmyGroupName).id;
		((GObject)ArmyGroupName).text = LanguagesManager.GetDesc(id);
		HPBar = (UI_EnemyHPbar)(object)((GComponent)this).GetChild("HPBar");
	}
}
