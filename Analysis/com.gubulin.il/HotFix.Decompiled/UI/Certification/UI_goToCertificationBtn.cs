using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.Certification;

public class UI_goToCertificationBtn : GButton
{
	public Controller button;

	public GImage n5;

	public GRichTextField title;

	public const string URL = "ui://56q48tcqjbid6";

	public static string Name = "UI_goToCertificationBtn";

	public static string GetURL()
	{
		return "ui://56q48tcqjbid6";
	}

	public static UI_goToCertificationBtn CreateInstance()
	{
		return (UI_goToCertificationBtn)(object)UIPackage.CreateObject("Certification", "goToCertificationBtn");
	}

	public static UI_goToCertificationBtn CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_goToCertificationBtn).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://56q48tcqjbid6", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		n5 = (GImage)((GComponent)this).GetChild("n5");
		title = (GRichTextField)((GComponent)this).GetChild("title");
		string id = "ui://56q48tcqjbid6".Replace("ui://", "") + "-" + ((GObject)title).id;
		((GObject)title).text = LanguagesManager.GetDesc(id);
	}
}
