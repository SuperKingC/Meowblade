using FairyGUI;
using FairyGUI.Utils;

namespace UI.LegendItemBlueprint;

public class UI_com_LegendItemEntryPreview : GComponent
{
	public UI_com_EntriesPreview Entries;

	public GList Fx;

	public const string URL = "ui://h09dvkcglxbt3z";

	public static string Name = "UI_com_LegendItemEntryPreview";

	public static string GetURL()
	{
		return "ui://h09dvkcglxbt3z";
	}

	public static UI_com_LegendItemEntryPreview CreateInstance()
	{
		return (UI_com_LegendItemEntryPreview)(object)UIPackage.CreateObject("LegendItemBlueprint", "com_LegendItemEntryPreview");
	}

	public static UI_com_LegendItemEntryPreview CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_LegendItemEntryPreview).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://h09dvkcglxbt3z", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0035: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		Entries = (UI_com_EntriesPreview)(object)((GComponent)this).GetChild("Entries");
		Fx = (GList)((GComponent)this).GetChild("Fx");
	}
}
