using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.Battle;

public class UI_Mask : GComponent
{
	public GGraph Mask;

	public GTextField tip;

	public const string URL = "ui://twlbabicf4sz3u";

	public static string Name = "UI_Mask";

	public static string GetURL()
	{
		return "ui://twlbabicf4sz3u";
	}

	public static UI_Mask CreateInstance()
	{
		return (UI_Mask)(object)UIPackage.CreateObject("Battle", "Mask");
	}

	public static UI_Mask CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_Mask).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://twlbabicf4sz3u", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0035: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		Mask = (GGraph)((GComponent)this).GetChild("Mask");
		tip = (GTextField)((GComponent)this).GetChild("tip");
		string id = "ui://twlbabicf4sz3u".Replace("ui://", "") + "-" + ((GObject)tip).id;
		((GObject)tip).text = LanguagesManager.GetDesc(id);
	}
}
