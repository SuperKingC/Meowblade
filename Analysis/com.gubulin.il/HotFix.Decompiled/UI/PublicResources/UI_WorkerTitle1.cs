using FairyGUI;
using FairyGUI.Utils;

namespace UI.PublicResources;

public class UI_WorkerTitle1 : GComponent
{
	public GGraph back;

	public GTextField name;

	public Transition NameMobile;

	public const string URL = "ui://kt6rg65ohkkttf9";

	public static string Name = "UI_WorkerTitle1";

	public static string GetURL()
	{
		return "ui://kt6rg65ohkkttf9";
	}

	public static UI_WorkerTitle1 CreateInstance()
	{
		return (UI_WorkerTitle1)(object)UIPackage.CreateObject("PublicResources", "WorkerTitle1");
	}

	public static UI_WorkerTitle1 CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_WorkerTitle1).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://kt6rg65ohkkttf9", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0035: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		back = (GGraph)((GComponent)this).GetChild("back");
		name = (GTextField)((GComponent)this).GetChild("name");
		NameMobile = ((GComponent)this).GetTransition("NameMobile");
	}
}
