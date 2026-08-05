using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.GVGStore;

public class UI_com_SelectStoneBoxDialog : GComponent
{
	public GImage bg;

	public GList stoneBoxList;

	public GTextField n4;

	public const string URL = "ui://fvc33k3grlgk33";

	public static string Name = "UI_com_SelectStoneBoxDialog";

	public static string GetURL()
	{
		return "ui://fvc33k3grlgk33";
	}

	public static UI_com_SelectStoneBoxDialog CreateInstance()
	{
		return (UI_com_SelectStoneBoxDialog)(object)UIPackage.CreateObject("GVGStore", "com_SelectStoneBoxDialog");
	}

	public static UI_com_SelectStoneBoxDialog CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_SelectStoneBoxDialog).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://fvc33k3grlgk33", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		((GComponent)this).ConstructFromXML(xml);
		bg = (GImage)((GComponent)this).GetChild("bg");
		stoneBoxList = (GList)((GComponent)this).GetChild("stoneBoxList");
		n4 = (GTextField)((GComponent)this).GetChild("n4");
		string id = "ui://fvc33k3grlgk33".Replace("ui://", "") + "-" + ((GObject)n4).id;
		((GObject)n4).text = LanguagesManager.GetDesc(id);
	}
}
