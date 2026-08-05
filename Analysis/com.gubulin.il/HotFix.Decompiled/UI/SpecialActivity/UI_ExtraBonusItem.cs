using FairyGUI;
using FairyGUI.Utils;

namespace UI.SpecialActivity;

public class UI_ExtraBonusItem : GComponent
{
	public GLoader icon;

	public GTextField num;

	public const string URL = "ui://kozswd8hp9tkf2t";

	public static string Name = "UI_ExtraBonusItem";

	public static string GetURL()
	{
		return "ui://kozswd8hp9tkf2t";
	}

	public static UI_ExtraBonusItem CreateInstance()
	{
		return (UI_ExtraBonusItem)(object)UIPackage.CreateObject("SpecialActivity", "ExtraBonusItem");
	}

	public static UI_ExtraBonusItem CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_ExtraBonusItem).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://kozswd8hp9tkf2t", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0035: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		icon = (GLoader)((GComponent)this).GetChild("icon");
		num = (GTextField)((GComponent)this).GetChild("num");
	}
}
