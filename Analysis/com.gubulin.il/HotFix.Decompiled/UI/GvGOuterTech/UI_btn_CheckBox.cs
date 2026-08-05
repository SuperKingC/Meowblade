using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGOuterTech;

public class UI_btn_CheckBox : GButton
{
	public Controller button;

	public GGraph n6;

	public GImage bg;

	public GImage n5;

	public const string URL = "ui://th385mtty3efn";

	public static string Name = "UI_btn_CheckBox";

	public static string GetURL()
	{
		return "ui://th385mtty3efn";
	}

	public static UI_btn_CheckBox CreateInstance()
	{
		return (UI_btn_CheckBox)(object)UIPackage.CreateObject("GvGOuterTech", "btn_CheckBox");
	}

	public static UI_btn_CheckBox CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_btn_CheckBox).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://th385mtty3efn", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Expected O, but got Unknown
		//IL_003c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0046: Expected O, but got Unknown
		//IL_0052: Unknown result type (might be due to invalid IL or missing references)
		//IL_005c: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		button = ((GComponent)this).GetController("button");
		n6 = (GGraph)((GComponent)this).GetChild("n6");
		bg = (GImage)((GComponent)this).GetChild("bg");
		n5 = (GImage)((GComponent)this).GetChild("n5");
	}
}
