using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.Battle;

public class UI_CombatAlert : GButton
{
	public Controller button;

	public GImage back;

	public GTextField tip;

	public const string URL = "ui://twlbabicmol035";

	public static string Name = "UI_CombatAlert";

	public static string GetURL()
	{
		return "ui://twlbabicmol035";
	}

	public static UI_CombatAlert CreateInstance()
	{
		return (UI_CombatAlert)(object)UIPackage.CreateObject("Battle", "CombatAlert");
	}

	public static UI_CombatAlert CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_CombatAlert).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://twlbabicmol035", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Expected O, but got Unknown
		//IL_003c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0046: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		button = ((GComponent)this).GetController("button");
		back = (GImage)((GComponent)this).GetChild("back");
		tip = (GTextField)((GComponent)this).GetChild("tip");
		string id = "ui://twlbabicmol035".Replace("ui://", "") + "-" + ((GObject)tip).id;
		((GObject)tip).text = LanguagesManager.GetDesc(id);
	}
}
