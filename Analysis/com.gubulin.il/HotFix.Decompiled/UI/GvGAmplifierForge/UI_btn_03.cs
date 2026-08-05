using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGAmplifierForge;

public class UI_btn_03 : GButton
{
	public GImage n180;

	public GTextField n181;

	public const string URL = "ui://fpjheycbgtcxv4gb";

	public static string Name = "UI_btn_03";

	public static string GetURL()
	{
		return "ui://fpjheycbgtcxv4gb";
	}

	public static UI_btn_03 CreateInstance()
	{
		return (UI_btn_03)(object)UIPackage.CreateObject("GvGAmplifierForge", "btn_03");
	}

	public static UI_btn_03 CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_btn_03).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://fpjheycbgtcxv4gb", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0035: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		n180 = (GImage)((GComponent)this).GetChild("n180");
		n181 = (GTextField)((GComponent)this).GetChild("n181");
		string id = "ui://fpjheycbgtcxv4gb".Replace("ui://", "") + "-" + ((GObject)n181).id;
		((GObject)n181).text = LanguagesManager.GetDesc(id);
	}
}
