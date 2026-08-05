using FairyGUI;
using FairyGUI.Utils;

namespace UI.Technology;

public class UI_DetailInfoPage : GComponent
{
	public GGraph mask;

	public UI_DetailInfoPageDialog tip;

	public Transition showPopup;

	public const string URL = "ui://7ca77a3fty9ri";

	public static string Name = "UI_DetailInfoPage";

	public static string GetURL()
	{
		return "ui://7ca77a3fty9ri";
	}

	public static UI_DetailInfoPage CreateInstance()
	{
		return (UI_DetailInfoPage)(object)UIPackage.CreateObject("Technology", "DetailInfoPage");
	}

	public static UI_DetailInfoPage CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_DetailInfoPage).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://7ca77a3fty9ri", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		mask = (GGraph)((GComponent)this).GetChild("mask");
		tip = (UI_DetailInfoPageDialog)(object)((GComponent)this).GetChild("tip");
		showPopup = ((GComponent)this).GetTransition("showPopup");
	}
}
