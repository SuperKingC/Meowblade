using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.PvpSelectSoldiers;

public class UI_btn_SeasonEntranceFunction : GButton
{
	public Controller button;

	public GLoader icon;

	public GTextField title;

	public GImage note;

	public GImage markNew;

	public const string URL = "ui://82mo10n5y310dos";

	public static string Name = "UI_btn_SeasonEntranceFunction";

	public static string GetURL()
	{
		return "ui://82mo10n5y310dos";
	}

	public static UI_btn_SeasonEntranceFunction CreateInstance()
	{
		return (UI_btn_SeasonEntranceFunction)(object)UIPackage.CreateObject("PvpSelectSoldiers", "btn_SeasonEntranceFunction");
	}

	public static UI_btn_SeasonEntranceFunction CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_btn_SeasonEntranceFunction).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://82mo10n5y310dos", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Expected O, but got Unknown
		//IL_003c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0046: Expected O, but got Unknown
		//IL_008f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0099: Expected O, but got Unknown
		//IL_00a5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00af: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		button = ((GComponent)this).GetController("button");
		icon = (GLoader)((GComponent)this).GetChild("icon");
		title = (GTextField)((GComponent)this).GetChild("title");
		string id = "ui://82mo10n5y310dos".Replace("ui://", "") + "-" + ((GObject)title).id;
		((GObject)title).text = LanguagesManager.GetDesc(id);
		note = (GImage)((GComponent)this).GetChild("note");
		markNew = (GImage)((GComponent)this).GetChild("markNew");
	}
}
