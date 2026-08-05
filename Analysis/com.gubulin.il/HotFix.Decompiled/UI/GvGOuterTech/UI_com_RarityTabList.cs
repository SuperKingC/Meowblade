using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGOuterTech;

public class UI_com_RarityTabList : GComponent
{
	public GImage n123;

	public GList List;

	public const string URL = "ui://th385mttrg73y";

	public static string Name = "UI_com_RarityTabList";

	public static string GetURL()
	{
		return "ui://th385mttrg73y";
	}

	public static UI_com_RarityTabList CreateInstance()
	{
		return (UI_com_RarityTabList)(object)UIPackage.CreateObject("GvGOuterTech", "com_RarityTabList");
	}

	public static UI_com_RarityTabList CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_RarityTabList).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://th385mttrg73y", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0035: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		n123 = (GImage)((GComponent)this).GetChild("n123");
		List = (GList)((GComponent)this).GetChild("List");
	}
}
