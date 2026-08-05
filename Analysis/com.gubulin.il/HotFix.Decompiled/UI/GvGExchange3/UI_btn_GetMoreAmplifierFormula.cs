using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGExchange3;

public class UI_btn_GetMoreAmplifierFormula : GButton
{
	public Controller button;

	public GImage background;

	public const string URL = "ui://tt2iq07odip34t";

	public static string Name = "UI_btn_GetMoreAmplifierFormula";

	public static string GetURL()
	{
		return "ui://tt2iq07odip34t";
	}

	public static UI_btn_GetMoreAmplifierFormula CreateInstance()
	{
		return (UI_btn_GetMoreAmplifierFormula)(object)UIPackage.CreateObject("GvGExchange3", "btn_GetMoreAmplifierFormula");
	}

	public static UI_btn_GetMoreAmplifierFormula CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_btn_GetMoreAmplifierFormula).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://tt2iq07odip34t", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		button = ((GComponent)this).GetController("button");
		background = (GImage)((GComponent)this).GetChild("background");
	}
}
