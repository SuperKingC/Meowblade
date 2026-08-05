using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGWorldMap3;

public class UI_btn_DeleteEvent : GButton
{
	public Controller button;

	public GImage n21;

	public const string URL = "ui://4eq8fgd2r5amax";

	public static string Name = "UI_btn_DeleteEvent";

	public static string GetURL()
	{
		return "ui://4eq8fgd2r5amax";
	}

	public static UI_btn_DeleteEvent CreateInstance()
	{
		return (UI_btn_DeleteEvent)(object)UIPackage.CreateObject("GvGWorldMap3", "btn_DeleteEvent");
	}

	public static UI_btn_DeleteEvent CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_btn_DeleteEvent).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://4eq8fgd2r5amax", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		button = ((GComponent)this).GetController("button");
		n21 = (GImage)((GComponent)this).GetChild("n21");
	}
}
