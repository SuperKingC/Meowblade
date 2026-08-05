using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.PvpSelectSoldiers;

public class UI_SeasonBuffLabel : GComponent
{
	public GImage n70;

	public UI_com_Ability BuffIcon;

	public GImage n68;

	public GImage n73;

	public GTextField title;

	public const string URL = "ui://82mo10n5hrekjdul";

	public static string Name = "UI_SeasonBuffLabel";

	public static string GetURL()
	{
		return "ui://82mo10n5hrekjdul";
	}

	public static UI_SeasonBuffLabel CreateInstance()
	{
		return (UI_SeasonBuffLabel)(object)UIPackage.CreateObject("PvpSelectSoldiers", "SeasonBuffLabel");
	}

	public static UI_SeasonBuffLabel CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_SeasonBuffLabel).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://82mo10n5hrekjdul", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		//IL_0041: Unknown result type (might be due to invalid IL or missing references)
		//IL_004b: Expected O, but got Unknown
		//IL_0057: Unknown result type (might be due to invalid IL or missing references)
		//IL_0061: Expected O, but got Unknown
		//IL_006d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0077: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		n70 = (GImage)((GComponent)this).GetChild("n70");
		BuffIcon = (UI_com_Ability)(object)((GComponent)this).GetChild("BuffIcon");
		n68 = (GImage)((GComponent)this).GetChild("n68");
		n73 = (GImage)((GComponent)this).GetChild("n73");
		title = (GTextField)((GComponent)this).GetChild("title");
		string id = "ui://82mo10n5hrekjdul".Replace("ui://", "") + "-" + ((GObject)title).id;
		((GObject)title).text = LanguagesManager.GetDesc(id);
	}
}
