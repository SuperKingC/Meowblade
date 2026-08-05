using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.LegendItemBlueprint;

public class UI_dec_SelectPopupTop : GComponent
{
	public GImage n18;

	public GTextField n19;

	public const string URL = "ui://h09dvkcgrtmo28";

	public static string Name = "UI_dec_SelectPopupTop";

	public static string GetURL()
	{
		return "ui://h09dvkcgrtmo28";
	}

	public static UI_dec_SelectPopupTop CreateInstance()
	{
		return (UI_dec_SelectPopupTop)(object)UIPackage.CreateObject("LegendItemBlueprint", "dec_SelectPopupTop");
	}

	public static UI_dec_SelectPopupTop CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_dec_SelectPopupTop).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://h09dvkcgrtmo28", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0035: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		n18 = (GImage)((GComponent)this).GetChild("n18");
		n19 = (GTextField)((GComponent)this).GetChild("n19");
		string id = "ui://h09dvkcgrtmo28".Replace("ui://", "") + "-" + ((GObject)n19).id;
		((GObject)n19).text = LanguagesManager.GetDesc(id);
	}
}
