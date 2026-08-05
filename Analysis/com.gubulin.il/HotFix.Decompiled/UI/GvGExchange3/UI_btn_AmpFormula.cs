using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGExchange3;

public class UI_btn_AmpFormula : GButton
{
	public Controller button;

	public UI_com_AmplifierSlot Amp;

	public GImage n3;

	public const string URL = "ui://tt2iq07opg601w";

	public static string Name = "UI_btn_AmpFormula";

	public static string GetURL()
	{
		return "ui://tt2iq07opg601w";
	}

	public static UI_btn_AmpFormula CreateInstance()
	{
		return (UI_btn_AmpFormula)(object)UIPackage.CreateObject("GvGExchange3", "btn_AmpFormula");
	}

	public static UI_btn_AmpFormula CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_btn_AmpFormula).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://tt2iq07opg601w", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_003c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0046: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		button = ((GComponent)this).GetController("button");
		Amp = (UI_com_AmplifierSlot)(object)((GComponent)this).GetChild("Amp");
		n3 = (GImage)((GComponent)this).GetChild("n3");
	}
}
