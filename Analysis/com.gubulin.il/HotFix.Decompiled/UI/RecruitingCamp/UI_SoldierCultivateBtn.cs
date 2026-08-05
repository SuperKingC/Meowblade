using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.RecruitingCamp;

public class UI_SoldierCultivateBtn : GButton
{
	public Controller button;

	public GImage n6;

	public GRichTextField title;

	public const string URL = "ui://72fujxhkwee62a";

	public static string Name = "UI_SoldierCultivateBtn";

	public static string GetURL()
	{
		return "ui://72fujxhkwee62a";
	}

	public static UI_SoldierCultivateBtn CreateInstance()
	{
		return (UI_SoldierCultivateBtn)(object)UIPackage.CreateObject("RecruitingCamp", "SoldierCultivateBtn");
	}

	public static UI_SoldierCultivateBtn CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_SoldierCultivateBtn).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://72fujxhkwee62a", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		n6 = (GImage)((GComponent)this).GetChild("n6");
		title = (GRichTextField)((GComponent)this).GetChild("title");
		string id = "ui://72fujxhkwee62a".Replace("ui://", "") + "-" + ((GObject)title).id;
		((GObject)title).text = LanguagesManager.GetDesc(id);
	}
}
