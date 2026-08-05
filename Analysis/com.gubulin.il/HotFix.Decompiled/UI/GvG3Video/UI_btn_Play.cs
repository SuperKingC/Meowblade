using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvG3Video;

public class UI_btn_Play : GButton
{
	public Controller button;

	public GImage n5;

	public Transition t0;

	public const string URL = "ui://2itu6489ezmi3";

	public static string Name = "UI_btn_Play";

	public static string GetURL()
	{
		return "ui://2itu6489ezmi3";
	}

	public static UI_btn_Play CreateInstance()
	{
		return (UI_btn_Play)(object)UIPackage.CreateObject("GvG3Video", "btn_Play");
	}

	public static UI_btn_Play CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_btn_Play).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://2itu6489ezmi3", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		button = ((GComponent)this).GetController("button");
		n5 = (GImage)((GComponent)this).GetChild("n5");
		t0 = ((GComponent)this).GetTransition("t0");
	}
}
