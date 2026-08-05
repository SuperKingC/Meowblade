using FairyGUI;
using FairyGUI.Utils;

namespace UI.Collection;

public class UI_MaterialInfoDialog : GComponent
{
	public GGraph clickBack;

	public UI_Dialog tip;

	public Transition showPopup;

	public const string URL = "ui://ehe4tm5zb8ch1m";

	public static string Name = "UI_MaterialInfoDialog";

	public static string GetURL()
	{
		return "ui://ehe4tm5zb8ch1m";
	}

	public static UI_MaterialInfoDialog CreateInstance()
	{
		return (UI_MaterialInfoDialog)(object)UIPackage.CreateObject("Collection", "MaterialInfoDialog");
	}

	public static UI_MaterialInfoDialog CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_MaterialInfoDialog).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://ehe4tm5zb8ch1m", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		clickBack = (GGraph)((GComponent)this).GetChild("clickBack");
		tip = (UI_Dialog)(object)((GComponent)this).GetChild("tip");
		showPopup = ((GComponent)this).GetTransition("showPopup");
	}
}
