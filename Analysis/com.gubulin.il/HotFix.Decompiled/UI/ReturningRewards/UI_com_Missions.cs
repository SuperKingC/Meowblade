using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.ReturningRewards;

public class UI_com_Missions : GComponent
{
	public GImage n6;

	public GImage n5;

	public GList Missions;

	public GTextField n3;

	public UI_exit Close;

	public const string URL = "ui://rx5ntv988vxl1l";

	public static string Name = "UI_com_Missions";

	public static string GetURL()
	{
		return "ui://rx5ntv988vxl1l";
	}

	public static UI_com_Missions CreateInstance()
	{
		return (UI_com_Missions)(object)UIPackage.CreateObject("ReturningRewards", "com_Missions");
	}

	public static UI_com_Missions CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_Missions).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://rx5ntv988vxl1l", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0035: Expected O, but got Unknown
		//IL_0041: Unknown result type (might be due to invalid IL or missing references)
		//IL_004b: Expected O, but got Unknown
		//IL_0057: Unknown result type (might be due to invalid IL or missing references)
		//IL_0061: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		n6 = (GImage)((GComponent)this).GetChild("n6");
		n5 = (GImage)((GComponent)this).GetChild("n5");
		Missions = (GList)((GComponent)this).GetChild("Missions");
		n3 = (GTextField)((GComponent)this).GetChild("n3");
		string id = "ui://rx5ntv988vxl1l".Replace("ui://", "") + "-" + ((GObject)n3).id;
		((GObject)n3).text = LanguagesManager.GetDesc(id);
		Close = (UI_exit)(object)((GComponent)this).GetChild("Close");
	}
}
