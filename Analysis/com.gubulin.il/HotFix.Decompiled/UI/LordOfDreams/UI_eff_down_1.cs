using FairyGUI;
using FairyGUI.Utils;

namespace UI.LordOfDreams;

public class UI_eff_down_1 : GComponent
{
	public GImage arrow1;

	public GImage arrow2;

	public GImage arrow3;

	public Transition Play;

	public const string URL = "ui://0i520nzmdy01ode";

	public static string Name = "UI_eff_down_1";

	public static string GetURL()
	{
		return "ui://0i520nzmdy01ode";
	}

	public static UI_eff_down_1 CreateInstance()
	{
		return (UI_eff_down_1)(object)UIPackage.CreateObject("LordOfDreams", "eff_down_1");
	}

	public static UI_eff_down_1 CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_eff_down_1).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://0i520nzmdy01ode", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0035: Expected O, but got Unknown
		//IL_0041: Unknown result type (might be due to invalid IL or missing references)
		//IL_004b: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		arrow1 = (GImage)((GComponent)this).GetChild("arrow1");
		arrow2 = (GImage)((GComponent)this).GetChild("arrow2");
		arrow3 = (GImage)((GComponent)this).GetChild("arrow3");
		Play = ((GComponent)this).GetTransition("Play");
	}
}
