using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.Contract;

public class UI_SoldierFormationInfo : GComponent
{
	public GImage back;

	public GTextField title;

	public UI_SoldierFormationInfoDialog content;

	public const string URL = "ui://avplaivd924qt3y";

	public static string Name = "UI_SoldierFormationInfo";

	public static string GetURL()
	{
		return "ui://avplaivd924qt3y";
	}

	public static UI_SoldierFormationInfo CreateInstance()
	{
		return (UI_SoldierFormationInfo)(object)UIPackage.CreateObject("Contract", "SoldierFormationInfo");
	}

	public static UI_SoldierFormationInfo CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_SoldierFormationInfo).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://avplaivd924qt3y", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0035: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		back = (GImage)((GComponent)this).GetChild("back");
		title = (GTextField)((GComponent)this).GetChild("title");
		string id = "ui://avplaivd924qt3y".Replace("ui://", "") + "-" + ((GObject)title).id;
		((GObject)title).text = LanguagesManager.GetDesc(id);
		content = (UI_SoldierFormationInfoDialog)(object)((GComponent)this).GetChild("content");
	}
}
