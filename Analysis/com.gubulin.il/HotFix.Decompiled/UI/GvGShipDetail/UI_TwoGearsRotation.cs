using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGShipDetail;

public class UI_TwoGearsRotation : GComponent
{
	public GImage n95;

	public GImage n94;

	public GGraph n96;

	public Transition t0;

	public const string URL = "ui://u6x0b1gnjuql5d";

	public static string Name = "UI_TwoGearsRotation";

	public static string GetURL()
	{
		return "ui://u6x0b1gnjuql5d";
	}

	public static UI_TwoGearsRotation CreateInstance()
	{
		return (UI_TwoGearsRotation)(object)UIPackage.CreateObject("GvGShipDetail", "TwoGearsRotation");
	}

	public static UI_TwoGearsRotation CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_TwoGearsRotation).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://u6x0b1gnjuql5d", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		n95 = (GImage)((GComponent)this).GetChild("n95");
		n94 = (GImage)((GComponent)this).GetChild("n94");
		n96 = (GGraph)((GComponent)this).GetChild("n96");
		t0 = ((GComponent)this).GetTransition("t0");
	}
}
