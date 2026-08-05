using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGOnIsland3;

public class UI_com_Camp : GComponent
{
	public Controller CampId;

	public GLoader n0;

	public const string URL = "ui://ebc4ciwrs0diq7n";

	public static string Name = "UI_com_Camp";

	public static string GetURL()
	{
		return "ui://ebc4ciwrs0diq7n";
	}

	public static UI_com_Camp CreateInstance()
	{
		return (UI_com_Camp)(object)UIPackage.CreateObject("GvGOnIsland3", "com_Camp");
	}

	public static UI_com_Camp CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_Camp).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://ebc4ciwrs0diq7n", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		CampId = ((GComponent)this).GetController("CampId");
		n0 = (GLoader)((GComponent)this).GetChild("n0");
	}
}
