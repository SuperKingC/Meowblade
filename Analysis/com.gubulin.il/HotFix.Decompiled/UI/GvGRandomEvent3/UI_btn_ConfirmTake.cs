using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGRandomEvent3;

public class UI_btn_ConfirmTake : GButton
{
	public Controller button;

	public Controller hasOuterTech;

	public GImage back;

	public GImage n6;

	public GImage n5;

	public GImage n7;

	public const string URL = "ui://p4ocf6q0dc6m6";

	public static string Name = "UI_btn_ConfirmTake";

	public static string GetURL()
	{
		return "ui://p4ocf6q0dc6m6";
	}

	public static UI_btn_ConfirmTake CreateInstance()
	{
		return (UI_btn_ConfirmTake)(object)UIPackage.CreateObject("GvGRandomEvent3", "btn_ConfirmTake");
	}

	public static UI_btn_ConfirmTake CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_btn_ConfirmTake).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://p4ocf6q0dc6m6", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0037: Unknown result type (might be due to invalid IL or missing references)
		//IL_0041: Expected O, but got Unknown
		//IL_004d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0057: Expected O, but got Unknown
		//IL_0063: Unknown result type (might be due to invalid IL or missing references)
		//IL_006d: Expected O, but got Unknown
		//IL_0079: Unknown result type (might be due to invalid IL or missing references)
		//IL_0083: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		button = ((GComponent)this).GetController("button");
		hasOuterTech = ((GComponent)this).GetController("hasOuterTech");
		back = (GImage)((GComponent)this).GetChild("back");
		n6 = (GImage)((GComponent)this).GetChild("n6");
		n5 = (GImage)((GComponent)this).GetChild("n5");
		n7 = (GImage)((GComponent)this).GetChild("n7");
	}
}
