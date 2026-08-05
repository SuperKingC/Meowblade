using FairyGUI;
using FairyGUI.Utils;

namespace UI.LegendItemBlueprint;

public class UI_content2 : GComponent
{
	public GRichTextField content2;

	public const string URL = "ui://h09dvkcgbpuh5ltg1";

	public static string Name = "UI_content2";

	public static string GetURL()
	{
		return "ui://h09dvkcgbpuh5ltg1";
	}

	public static UI_content2 CreateInstance()
	{
		return (UI_content2)(object)UIPackage.CreateObject("LegendItemBlueprint", "content2");
	}

	public static UI_content2 CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_content2).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://h09dvkcgbpuh5ltg1", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		content2 = (GRichTextField)((GComponent)this).GetChild("content2");
	}
}
