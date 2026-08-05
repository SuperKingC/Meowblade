using FairyGUI;
using FairyGUI.Utils;

namespace UI.GVGStore;

public class UI_com_JumpDialog : GComponent
{
	public GImage back;

	public GList JumpContext;

	public const string URL = "ui://fvc33k3gnf4q18";

	public static string Name = "UI_com_JumpDialog";

	public static string GetURL()
	{
		return "ui://fvc33k3gnf4q18";
	}

	public static UI_com_JumpDialog CreateInstance()
	{
		return (UI_com_JumpDialog)(object)UIPackage.CreateObject("GVGStore", "com_JumpDialog");
	}

	public static UI_com_JumpDialog CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_JumpDialog).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://fvc33k3gnf4q18", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0035: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		back = (GImage)((GComponent)this).GetChild("back");
		JumpContext = (GList)((GComponent)this).GetChild("JumpContext");
	}
}
