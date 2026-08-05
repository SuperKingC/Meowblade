using FairyGUI;
using FairyGUI.Utils;

namespace UI.Technology;

public class UI_DetailactivationPage : GComponent
{
	public GGraph mask;

	public UI_DetailactivationDialog tip;

	public Transition showPopup;

	public const string URL = "ui://7ca77a3fv93k34";

	public static string Name = "UI_DetailactivationPage";

	public static string GetURL()
	{
		return "ui://7ca77a3fv93k34";
	}

	public static UI_DetailactivationPage CreateInstance()
	{
		return (UI_DetailactivationPage)(object)UIPackage.CreateObject("Technology", "DetailactivationPage");
	}

	public static UI_DetailactivationPage CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_DetailactivationPage).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://7ca77a3fv93k34", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		mask = (GGraph)((GComponent)this).GetChild("mask");
		tip = (UI_DetailactivationDialog)(object)((GComponent)this).GetChild("tip");
		showPopup = ((GComponent)this).GetTransition("showPopup");
	}
}
