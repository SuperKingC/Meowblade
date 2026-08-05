using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGRandomEvent3;

public class UI_com_NpcDialogContent : GComponent
{
	public GTextField EventDesc;

	public const string URL = "ui://p4ocf6q0ttqh1i";

	public static string Name = "UI_com_NpcDialogContent";

	public static string GetURL()
	{
		return "ui://p4ocf6q0ttqh1i";
	}

	public static UI_com_NpcDialogContent CreateInstance()
	{
		return (UI_com_NpcDialogContent)(object)UIPackage.CreateObject("GvGRandomEvent3", "com_NpcDialogContent");
	}

	public static UI_com_NpcDialogContent CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_NpcDialogContent).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://p4ocf6q0ttqh1i", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		EventDesc = (GTextField)((GComponent)this).GetChild("EventDesc");
	}
}
