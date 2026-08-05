using FairyGUI;
using FairyGUI.Utils;

namespace UI.SpecialActivity;

public class UI_ExtraContent : GComponent
{
	public Controller ExtraCount;

	public UI_ExtraBonusItem item0;

	public UI_ExtraBonusItem item1;

	public UI_ExtraBonusItem item2;

	public UI_ExtraBonusItem item3;

	public UI_ExtraBonusItem item4;

	public UI_ExtraBonusItem item5;

	public UI_ExtraBonusItem item6;

	public const string URL = "ui://kozswd8hm9k0f2s";

	public static string Name = "UI_ExtraContent";

	public static string GetURL()
	{
		return "ui://kozswd8hm9k0f2s";
	}

	public static UI_ExtraContent CreateInstance()
	{
		return (UI_ExtraContent)(object)UIPackage.CreateObject("SpecialActivity", "ExtraContent");
	}

	public static UI_ExtraContent CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_ExtraContent).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://kozswd8hm9k0f2s", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		((GComponent)this).ConstructFromXML(xml);
		ExtraCount = ((GComponent)this).GetController("ExtraCount");
		item0 = (UI_ExtraBonusItem)(object)((GComponent)this).GetChild("item0");
		item1 = (UI_ExtraBonusItem)(object)((GComponent)this).GetChild("item1");
		item2 = (UI_ExtraBonusItem)(object)((GComponent)this).GetChild("item2");
		item3 = (UI_ExtraBonusItem)(object)((GComponent)this).GetChild("item3");
		item4 = (UI_ExtraBonusItem)(object)((GComponent)this).GetChild("item4");
		item5 = (UI_ExtraBonusItem)(object)((GComponent)this).GetChild("item5");
		item6 = (UI_ExtraBonusItem)(object)((GComponent)this).GetChild("item6");
	}
}
