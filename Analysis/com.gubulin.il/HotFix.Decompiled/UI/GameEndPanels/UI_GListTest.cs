using FairyGUI;
using FairyGUI.Utils;

namespace UI.GameEndPanels;

public class UI_GListTest : GComponent
{
	public GLoader DropBg;

	public GList V_DropList;

	public const string URL = "ui://hda5vzklk99f1b";

	public static string Name = "UI_GListTest";

	public static string GetURL()
	{
		return "ui://hda5vzklk99f1b";
	}

	public static UI_GListTest CreateInstance()
	{
		return (UI_GListTest)(object)UIPackage.CreateObject("GameEndPanels", "GListTest");
	}

	public static UI_GListTest CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_GListTest).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://hda5vzklk99f1b", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0035: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		DropBg = (GLoader)((GComponent)this).GetChild("DropBg");
		V_DropList = (GList)((GComponent)this).GetChild("V_DropList");
	}
}
