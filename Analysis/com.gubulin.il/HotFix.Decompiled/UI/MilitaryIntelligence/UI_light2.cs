using FairyGUI;
using FairyGUI.Utils;

namespace UI.MilitaryIntelligence;

public class UI_light2 : GComponent
{
	public Controller TypeController;

	public Controller StatusController;

	public GImage n44;

	public Transition t0;

	public const string URL = "ui://nfd5v46ufm8z1i";

	public static string Name = "UI_light2";

	public static string GetURL()
	{
		return "ui://nfd5v46ufm8z1i";
	}

	public static UI_light2 CreateInstance()
	{
		return (UI_light2)(object)UIPackage.CreateObject("MilitaryIntelligence", "light2");
	}

	public static UI_light2 CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_light2).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://nfd5v46ufm8z1i", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0037: Unknown result type (might be due to invalid IL or missing references)
		//IL_0041: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		TypeController = ((GComponent)this).GetController("TypeController");
		StatusController = ((GComponent)this).GetController("StatusController");
		n44 = (GImage)((GComponent)this).GetChild("n44");
		t0 = ((GComponent)this).GetTransition("t0");
	}
}
