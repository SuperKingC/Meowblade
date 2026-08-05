using FairyGUI;
using FairyGUI.Utils;

namespace UI.WarOrder;

public class UI_SliderGrip : GButton
{
	public Controller button;

	public GImage n3;

	public const string URL = "ui://ax280w58okbc1l";

	public static string Name = "UI_SliderGrip";

	public static string GetURL()
	{
		return "ui://ax280w58okbc1l";
	}

	public static UI_SliderGrip CreateInstance()
	{
		return (UI_SliderGrip)(object)UIPackage.CreateObject("WarOrder", "SliderGrip");
	}

	public static UI_SliderGrip CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_SliderGrip).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://ax280w58okbc1l", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
