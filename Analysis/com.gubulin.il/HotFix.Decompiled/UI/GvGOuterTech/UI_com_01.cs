using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGOuterTech;

public class UI_com_01 : GComponent
{
	public GImage n136;

	public GTextField n138;

	public Transition t0;

	public const string URL = "ui://th385mtt7ztlo5p";

	public static string Name = "UI_com_01";

	public static string GetURL()
	{
		return "ui://th385mtt7ztlo5p";
	}

	public static UI_com_01 CreateInstance()
	{
		return (UI_com_01)(object)UIPackage.CreateObject("GvGOuterTech", "com_01");
	}

	public static UI_com_01 CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_01).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://th385mtt7ztlo5p", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0035: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		n136 = (GImage)((GComponent)this).GetChild("n136");
		n138 = (GTextField)((GComponent)this).GetChild("n138");
		string id = "ui://th385mtt7ztlo5p".Replace("ui://", "") + "-" + ((GObject)n138).id;
		((GObject)n138).text = LanguagesManager.GetDesc(id);
		t0 = ((GComponent)this).GetTransition("t0");
	}
}
