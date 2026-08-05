using FairyGUI;
using FairyGUI.Utils;

namespace UI.RecruitingCamp;

public class UI_SoldierIconLoader : GComponent
{
	public GImage Mask;

	public GLoader IconLoader;

	public const string URL = "ui://72fujxhkkl9h2z";

	public static string Name = "UI_SoldierIconLoader";

	public static string GetURL()
	{
		return "ui://72fujxhkkl9h2z";
	}

	public static UI_SoldierIconLoader CreateInstance()
	{
		return (UI_SoldierIconLoader)(object)UIPackage.CreateObject("RecruitingCamp", "SoldierIconLoader");
	}

	public static UI_SoldierIconLoader CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_SoldierIconLoader).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://72fujxhkkl9h2z", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0035: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		Mask = (GImage)((GComponent)this).GetChild("Mask");
		IconLoader = (GLoader)((GComponent)this).GetChild("IconLoader");
	}
}
