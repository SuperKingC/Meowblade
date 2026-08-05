using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGWorldMap2;

public class UI_SliderGrip : GButton
{
	public Controller button;

	public GImage n3;

	public const string URL = "ui://hd2s9kukursm2r";

	public static string Name = "UI_SliderGrip";

	public static string GetURL()
	{
		return "ui://hd2s9kukursm2r";
	}

	public static UI_SliderGrip CreateInstance()
	{
		return (UI_SliderGrip)(object)UIPackage.CreateObject("GvGWorldMap2", "SliderGrip");
	}

	public static UI_SliderGrip CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_SliderGrip).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://hd2s9kukursm2r", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		button = ((GComponent)this).GetController("button");
		n3 = (GImage)((GComponent)this).GetChild("n3");
	}
}
