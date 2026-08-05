using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.PvpSelectSoldiers;

public class UI_ServerWideRewardDialog : GComponent
{
	public GImage Background;

	public GTextField Tips;

	public GTextField title;

	public GList ItemList;

	public const string URL = "ui://82mo10n5svvbjdu6";

	public static string Name = "UI_ServerWideRewardDialog";

	public static string GetURL()
	{
		return "ui://82mo10n5svvbjdu6";
	}

	public static UI_ServerWideRewardDialog CreateInstance()
	{
		return (UI_ServerWideRewardDialog)(object)UIPackage.CreateObject("PvpSelectSoldiers", "ServerWideRewardDialog");
	}

	public static UI_ServerWideRewardDialog CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_ServerWideRewardDialog).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://82mo10n5svvbjdu6", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		//IL_00d1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00db: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		Background = (GImage)((GComponent)this).GetChild("Background");
		Tips = (GTextField)((GComponent)this).GetChild("Tips");
		string id = "ui://82mo10n5svvbjdu6".Replace("ui://", "") + "-" + ((GObject)Tips).id;
		((GObject)Tips).text = LanguagesManager.GetDesc(id);
		title = (GTextField)((GComponent)this).GetChild("title");
		string id2 = "ui://82mo10n5svvbjdu6".Replace("ui://", "") + "-" + ((GObject)title).id;
		((GObject)title).text = LanguagesManager.GetDesc(id2);
		ItemList = (GList)((GComponent)this).GetChild("ItemList");
	}
}
