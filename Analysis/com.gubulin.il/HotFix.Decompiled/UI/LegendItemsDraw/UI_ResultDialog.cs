using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.LegendItemsDraw;

public class UI_ResultDialog : GComponent
{
	public GImage back;

	public GTextField title;

	public GList legendItems;

	public UI_again againBtn;

	public UI_exit confirmBtn;

	public const string URL = "ui://xogvri2hs2vzo";

	public static string Name = "UI_ResultDialog";

	public static string GetURL()
	{
		return "ui://xogvri2hs2vzo";
	}

	public static UI_ResultDialog CreateInstance()
	{
		return (UI_ResultDialog)(object)UIPackage.CreateObject("LegendItemsDraw", "ResultDialog");
	}

	public static UI_ResultDialog CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_ResultDialog).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://xogvri2hs2vzo", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0035: Expected O, but got Unknown
		//IL_007e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0088: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		back = (GImage)((GComponent)this).GetChild("back");
		title = (GTextField)((GComponent)this).GetChild("title");
		string id = "ui://xogvri2hs2vzo".Replace("ui://", "") + "-" + ((GObject)title).id;
		((GObject)title).text = LanguagesManager.GetDesc(id);
		legendItems = (GList)((GComponent)this).GetChild("legendItems");
		againBtn = (UI_again)(object)((GComponent)this).GetChild("againBtn");
		confirmBtn = (UI_exit)(object)((GComponent)this).GetChild("confirmBtn");
	}
}
