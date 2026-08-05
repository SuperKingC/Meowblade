using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.ReturningRewards;

public class UI_com_Title : GComponent
{
	public GImage n0;

	public GTextField buildingName;

	public const string URL = "ui://rx5ntv98win2f";

	public static string Name = "UI_com_Title";

	public static string GetURL()
	{
		return "ui://rx5ntv98win2f";
	}

	public static UI_com_Title CreateInstance()
	{
		return (UI_com_Title)(object)UIPackage.CreateObject("ReturningRewards", "com_Title");
	}

	public static UI_com_Title CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_Title).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://rx5ntv98win2f", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		string id = "ui://rx5ntv98win2f".Replace("ui://", "") + "-" + ((GObject)buildingName).id;
		((GObject)buildingName).text = LanguagesManager.GetDesc(id);
	}
}
