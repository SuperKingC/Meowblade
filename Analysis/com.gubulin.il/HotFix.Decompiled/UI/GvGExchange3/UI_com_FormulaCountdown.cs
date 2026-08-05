using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGExchange3;

public class UI_com_FormulaCountdown : GComponent
{
	public Controller State;

	public GImage n1;

	public GTextField Countdown;

	public const string URL = "ui://tt2iq07odip34r";

	public static string Name = "UI_com_FormulaCountdown";

	public static string GetURL()
	{
		return "ui://tt2iq07odip34r";
	}

	public static UI_com_FormulaCountdown CreateInstance()
	{
		return (UI_com_FormulaCountdown)(object)UIPackage.CreateObject("GvGExchange3", "com_FormulaCountdown");
	}

	public static UI_com_FormulaCountdown CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_FormulaCountdown).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://tt2iq07odip34r", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Expected O, but got Unknown
		//IL_003c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0046: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		State = ((GComponent)this).GetController("State");
		n1 = (GImage)((GComponent)this).GetChild("n1");
		Countdown = (GTextField)((GComponent)this).GetChild("Countdown");
	}
}
