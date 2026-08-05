using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.PvpSelectSoldiers;

public class UI_btn_SeasonMissionTab : GButton
{
	public Controller button;

	public GImage n3;

	public GTextField title;

	public const string URL = "ui://82mo10n5g21rdpc";

	public static string Name = "UI_btn_SeasonMissionTab";

	public static string GetURL()
	{
		return "ui://82mo10n5g21rdpc";
	}

	public static UI_btn_SeasonMissionTab CreateInstance()
	{
		return (UI_btn_SeasonMissionTab)(object)UIPackage.CreateObject("PvpSelectSoldiers", "btn_SeasonMissionTab");
	}

	public static UI_btn_SeasonMissionTab CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_btn_SeasonMissionTab).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://82mo10n5g21rdpc", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		string id = "ui://82mo10n5g21rdpc".Replace("ui://", "") + "-" + ((GObject)title).id;
		((GObject)title).text = LanguagesManager.GetDesc(id);
	}
}
