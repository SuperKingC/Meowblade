using FairyGUI;
using FairyGUI.Utils;

namespace UI.RecyclingCenter;

public class UI_VisitorsPanel : GComponent
{
	public GGraph Mask;

	public UI_VisitorsDialog Dialog;

	public const string URL = "ui://72poq8plkxixs";

	public static string Name = "UI_VisitorsPanel";

	public static string GetURL()
	{
		return "ui://72poq8plkxixs";
	}

	public static UI_VisitorsPanel CreateInstance()
	{
		return (UI_VisitorsPanel)(object)UIPackage.CreateObject("RecyclingCenter", "VisitorsPanel");
	}

	public static UI_VisitorsPanel CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_VisitorsPanel).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://72poq8plkxixs", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		Mask = (GGraph)((GComponent)this).GetChild("Mask");
		Dialog = (UI_VisitorsDialog)(object)((GComponent)this).GetChild("Dialog");
	}
}
