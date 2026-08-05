using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.UpgradePotential;

public class UI_SkillHelp : GComponent
{
	public GImage n0;

	public GTextField unLockTitle;

	public GLoader skillIcon;

	public GLoader skillIconFrame;

	public UI_SkillIntorduction skillIntorduction;

	public const string URL = "ui://l5ik1uclpanqtb3";

	public static string Name = "UI_SkillHelp";

	public static string GetURL()
	{
		return "ui://l5ik1uclpanqtb3";
	}

	public static UI_SkillHelp CreateInstance()
	{
		return (UI_SkillHelp)(object)UIPackage.CreateObject("UpgradePotential", "SkillHelp");
	}

	public static UI_SkillHelp CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_SkillHelp).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://l5ik1uclpanqtb3", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		n0 = (GImage)((GComponent)this).GetChild("n0");
		unLockTitle = (GTextField)((GComponent)this).GetChild("unLockTitle");
		string id = "ui://l5ik1uclpanqtb3".Replace("ui://", "") + "-" + ((GObject)unLockTitle).id;
		((GObject)unLockTitle).text = LanguagesManager.GetDesc(id);
		skillIcon = (GLoader)((GComponent)this).GetChild("skillIcon");
		skillIconFrame = (GLoader)((GComponent)this).GetChild("skillIconFrame");
		skillIntorduction = (UI_SkillIntorduction)(object)((GComponent)this).GetChild("skillIntorduction");
	}
}
