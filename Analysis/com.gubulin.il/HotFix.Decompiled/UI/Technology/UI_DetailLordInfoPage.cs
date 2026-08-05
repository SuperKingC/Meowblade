using FairyGUI;
using FairyGUI.Utils;

namespace UI.Technology;

public class UI_DetailLordInfoPage : GComponent
{
	public GGraph background;

	public GGraph mask;

	public UI_DetailLordInfoDialog tip;

	public Transition showPopup;

	public const string URL = "ui://7ca77a3fbo6w27";

	public static string Name = "UI_DetailLordInfoPage";

	public static string GetURL()
	{
		return "ui://7ca77a3fbo6w27";
	}

	public static UI_DetailLordInfoPage CreateInstance()
	{
		return (UI_DetailLordInfoPage)(object)UIPackage.CreateObject("Technology", "DetailLordInfoPage");
	}

	public static UI_DetailLordInfoPage CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_DetailLordInfoPage).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://7ca77a3fbo6w27", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0035: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		background = (GGraph)((GComponent)this).GetChild("background");
		mask = (GGraph)((GComponent)this).GetChild("mask");
		tip = (UI_DetailLordInfoDialog)(object)((GComponent)this).GetChild("tip");
		showPopup = ((GComponent)this).GetTransition("showPopup");
	}
}
