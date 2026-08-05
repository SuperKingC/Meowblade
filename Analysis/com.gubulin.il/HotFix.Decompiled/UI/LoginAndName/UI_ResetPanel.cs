using FairyGUI;
using FairyGUI.Utils;

namespace UI.LoginAndName;

public class UI_ResetPanel : GComponent
{
	public GGraph Mask;

	public UI_ResetDialog Dialog;

	public Transition ShowDialog;

	public const string URL = "ui://yb3s7uv7p8ap2o";

	public static string Name = "UI_ResetPanel";

	public static string GetURL()
	{
		return "ui://yb3s7uv7p8ap2o";
	}

	public static UI_ResetPanel CreateInstance()
	{
		return (UI_ResetPanel)(object)UIPackage.CreateObject("LoginAndName", "ResetPanel");
	}

	public static UI_ResetPanel CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_ResetPanel).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://yb3s7uv7p8ap2o", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		Mask = (GGraph)((GComponent)this).GetChild("Mask");
		Dialog = (UI_ResetDialog)(object)((GComponent)this).GetChild("Dialog");
		ShowDialog = ((GComponent)this).GetTransition("ShowDialog");
	}
}
