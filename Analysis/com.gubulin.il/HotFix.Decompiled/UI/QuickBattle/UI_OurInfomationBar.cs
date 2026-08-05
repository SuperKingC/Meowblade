using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.QuickBattle;

public class UI_OurInfomationBar : GComponent
{
	public GLoader Frameloader;

	public UI_Avatar Avatar;

	public GTextField ArmyGroupName;

	public UI_OurHPbar HPBar;

	public const string URL = "ui://kqd1t06of2589";

	public static string Name = "UI_OurInfomationBar";

	public static string GetURL()
	{
		return "ui://kqd1t06of2589";
	}

	public static UI_OurInfomationBar CreateInstance()
	{
		return (UI_OurInfomationBar)(object)UIPackage.CreateObject("QuickBattle", "OurInfomationBar");
	}

	public static UI_OurInfomationBar CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_OurInfomationBar).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://kqd1t06of2589", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		//IL_0041: Unknown result type (might be due to invalid IL or missing references)
		//IL_004b: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		Frameloader = (GLoader)((GComponent)this).GetChild("Frameloader");
		Avatar = (UI_Avatar)(object)((GComponent)this).GetChild("Avatar");
		ArmyGroupName = (GTextField)((GComponent)this).GetChild("ArmyGroupName");
		string id = "ui://kqd1t06of2589".Replace("ui://", "") + "-" + ((GObject)ArmyGroupName).id;
		((GObject)ArmyGroupName).text = LanguagesManager.GetDesc(id);
		HPBar = (UI_OurHPbar)(object)((GComponent)this).GetChild("HPBar");
	}
}
