using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.Battle;

public class UI_OurInfomationBar : GComponent
{
	public GImage iconBack;

	public GImage n9;

	public GImage n10;

	public UI_Avatar Avatar;

	public GLoader Frameloader;

	public GTextField ArmyGroupName;

	public UI_OurHPbar HPBar;

	public GList n8;

	public const string URL = "ui://twlbabicwgjl10";

	public static string Name = "UI_OurInfomationBar";

	public static string GetURL()
	{
		return "ui://twlbabicwgjl10";
	}

	public static UI_OurInfomationBar CreateInstance()
	{
		return (UI_OurInfomationBar)(object)UIPackage.CreateObject("Battle", "OurInfomationBar");
	}

	public static UI_OurInfomationBar CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_OurInfomationBar).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://twlbabicwgjl10", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		//IL_00ec: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f6: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		iconBack = (GImage)((GComponent)this).GetChild("iconBack");
		n9 = (GImage)((GComponent)this).GetChild("n9");
		n10 = (GImage)((GComponent)this).GetChild("n10");
		Avatar = (UI_Avatar)(object)((GComponent)this).GetChild("Avatar");
		Frameloader = (GLoader)((GComponent)this).GetChild("Frameloader");
		ArmyGroupName = (GTextField)((GComponent)this).GetChild("ArmyGroupName");
		string id = "ui://twlbabicwgjl10".Replace("ui://", "") + "-" + ((GObject)ArmyGroupName).id;
		((GObject)ArmyGroupName).text = LanguagesManager.GetDesc(id);
		HPBar = (UI_OurHPbar)(object)((GComponent)this).GetChild("HPBar");
		n8 = (GList)((GComponent)this).GetChild("n8");
	}
}
