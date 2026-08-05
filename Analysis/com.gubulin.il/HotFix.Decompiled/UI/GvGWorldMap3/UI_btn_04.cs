using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGWorldMap3;

public class UI_btn_04 : GButton
{
	public GImage n40;

	public GTextField n41;

	public const string URL = "ui://4eq8fgd2nt70s7x";

	public static string Name = "UI_btn_04";

	public static string GetURL()
	{
		return "ui://4eq8fgd2nt70s7x";
	}

	public static UI_btn_04 CreateInstance()
	{
		return (UI_btn_04)(object)UIPackage.CreateObject("GvGWorldMap3", "btn_04");
	}

	public static UI_btn_04 CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_btn_04).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://4eq8fgd2nt70s7x", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0035: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		n40 = (GImage)((GComponent)this).GetChild("n40");
		n41 = (GTextField)((GComponent)this).GetChild("n41");
		string id = "ui://4eq8fgd2nt70s7x".Replace("ui://", "") + "-" + ((GObject)n41).id;
		((GObject)n41).text = LanguagesManager.GetDesc(id);
	}
}
