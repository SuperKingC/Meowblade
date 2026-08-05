using FairyGUI;
using FairyGUI.Utils;

namespace UI.RecyclingCenter;

public class UI_VisitPanel : GComponent
{
	public GGraph Mask;

	public UI_VisitDialog Dialog;

	public const string URL = "ui://72poq8plkxix10";

	public static string Name = "UI_VisitPanel";

	public static string GetURL()
	{
		return "ui://72poq8plkxix10";
	}

	public static UI_VisitPanel CreateInstance()
	{
		return (UI_VisitPanel)(object)UIPackage.CreateObject("RecyclingCenter", "VisitPanel");
	}

	public static UI_VisitPanel CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_VisitPanel).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://72poq8plkxix10", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		Mask = (GGraph)((GComponent)this).GetChild("Mask");
		Dialog = (UI_VisitDialog)(object)((GComponent)this).GetChild("Dialog");
	}
}
