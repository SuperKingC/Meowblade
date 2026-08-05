using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGOuterTech;

public class UI_com_NewCardDescWrapper : GComponent
{
	public UI_com_NewCardDesc NewCardDesc;

	public const string URL = "ui://th385mttk19mo2n";

	public static string Name = "UI_com_NewCardDescWrapper";

	public static string GetURL()
	{
		return "ui://th385mttk19mo2n";
	}

	public static UI_com_NewCardDescWrapper CreateInstance()
	{
		return (UI_com_NewCardDescWrapper)(object)UIPackage.CreateObject("GvGOuterTech", "com_NewCardDescWrapper");
	}

	public static UI_com_NewCardDescWrapper CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_NewCardDescWrapper).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://th385mttk19mo2n", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		((GComponent)this).ConstructFromXML(xml);
		NewCardDesc = (UI_com_NewCardDesc)(object)((GComponent)this).GetChild("NewCardDesc");
	}
}
