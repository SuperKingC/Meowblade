using FairyGUI;
using FairyGUI.Utils;

namespace UI.GiftBag;

public class UI_HelpPanel : GComponent
{
	public GGraph Mask;

	public UI_HelpDialog Dialog;

	public Transition ShowDialog;

	public const string URL = "ui://4fqsd8h6toms1b";

	public static string Name = "UI_HelpPanel";

	public static string GetURL()
	{
		return "ui://4fqsd8h6toms1b";
	}

	public static UI_HelpPanel CreateInstance()
	{
		return (UI_HelpPanel)(object)UIPackage.CreateObject("GiftBag", "HelpPanel");
	}

	public static UI_HelpPanel CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_HelpPanel).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://4fqsd8h6toms1b", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		Mask = (GGraph)((GComponent)this).GetChild("Mask");
		Dialog = (UI_HelpDialog)(object)((GComponent)this).GetChild("Dialog");
		ShowDialog = ((GComponent)this).GetTransition("ShowDialog");
	}
}
