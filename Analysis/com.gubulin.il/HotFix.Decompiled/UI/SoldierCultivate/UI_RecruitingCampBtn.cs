using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.SoldierCultivate;

public class UI_RecruitingCampBtn : GButton
{
	public Controller button;

	public GImage n3;

	public GTextField title;

	public const string URL = "ui://7dantnbiwee6t9n";

	public static string Name = "UI_RecruitingCampBtn";

	public static string GetURL()
	{
		return "ui://7dantnbiwee6t9n";
	}

	public static UI_RecruitingCampBtn CreateInstance()
	{
		return (UI_RecruitingCampBtn)(object)UIPackage.CreateObject("SoldierCultivate", "RecruitingCampBtn");
	}

	public static UI_RecruitingCampBtn CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_RecruitingCampBtn).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://7dantnbiwee6t9n", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		n3 = (GImage)((GComponent)this).GetChild("n3");
		title = (GTextField)((GComponent)this).GetChild("title");
		string id = "ui://7dantnbiwee6t9n".Replace("ui://", "") + "-" + ((GObject)title).id;
		((GObject)title).text = LanguagesManager.GetDesc(id);
	}
}
