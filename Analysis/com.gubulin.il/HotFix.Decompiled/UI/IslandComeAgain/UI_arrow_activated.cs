using FairyGUI;
using FairyGUI.Utils;

namespace UI.IslandComeAgain;

public class UI_arrow_activated : GButton
{
	public Controller button;

	public GButton n4;

	public const string URL = "ui://k2sprg26in7b3f";

	public static string Name = "UI_arrow_activated";

	public static string GetURL()
	{
		return "ui://k2sprg26in7b3f";
	}

	public static UI_arrow_activated CreateInstance()
	{
		return (UI_arrow_activated)(object)UIPackage.CreateObject("IslandComeAgain", "arrow_activated");
	}

	public static UI_arrow_activated CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_arrow_activated).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://k2sprg26in7b3f", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		button = ((GComponent)this).GetController("button");
		n4 = (GButton)((GComponent)this).GetChild("n4");
	}
}
