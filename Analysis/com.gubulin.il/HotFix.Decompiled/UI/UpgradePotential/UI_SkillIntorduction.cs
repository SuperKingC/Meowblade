using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.UpgradePotential;

public class UI_SkillIntorduction : GComponent
{
	public GTextField skillIntorduction;

	public const string URL = "ui://l5ik1ucluynqt8f";

	public static string Name = "UI_SkillIntorduction";

	public static string GetURL()
	{
		return "ui://l5ik1ucluynqt8f";
	}

	public static UI_SkillIntorduction CreateInstance()
	{
		return (UI_SkillIntorduction)(object)UIPackage.CreateObject("UpgradePotential", "SkillIntorduction");
	}

	public static UI_SkillIntorduction CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_SkillIntorduction).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://l5ik1ucluynqt8f", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		skillIntorduction = (GTextField)((GComponent)this).GetChild("skillIntorduction");
		string id = "ui://l5ik1ucluynqt8f".Replace("ui://", "") + "-" + ((GObject)skillIntorduction).id;
		((GObject)skillIntorduction).text = LanguagesManager.GetDesc(id);
	}
}
