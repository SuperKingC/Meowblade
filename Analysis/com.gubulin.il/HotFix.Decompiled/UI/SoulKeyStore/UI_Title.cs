using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.SoulKeyStore;

public class UI_Title : GComponent
{
	public GImage n0;

	public GTextField buildingName;

	public const string URL = "ui://3nd2hqkivzbkj";

	public static string Name = "UI_Title";

	public static string GetURL()
	{
		return "ui://3nd2hqkivzbkj";
	}

	public static UI_Title CreateInstance()
	{
		return (UI_Title)(object)UIPackage.CreateObject("SoulKeyStore", "Title");
	}

	public static UI_Title CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_Title).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://3nd2hqkivzbkj", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0035: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		n0 = (GImage)((GComponent)this).GetChild("n0");
		buildingName = (GTextField)((GComponent)this).GetChild("buildingName");
		string id = "ui://3nd2hqkivzbkj".Replace("ui://", "") + "-" + ((GObject)buildingName).id;
		((GObject)buildingName).text = LanguagesManager.GetDesc(id);
	}
}
