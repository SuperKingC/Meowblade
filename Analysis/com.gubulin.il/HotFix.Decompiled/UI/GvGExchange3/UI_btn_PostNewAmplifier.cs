using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGExchange3;

public class UI_btn_PostNewAmplifier : GButton
{
	public Controller button;

	public GGraph n6;

	public GImage n5;

	public const string URL = "ui://tt2iq07oxxgp56";

	public static string Name = "UI_btn_PostNewAmplifier";

	public static string GetURL()
	{
		return "ui://tt2iq07oxxgp56";
	}

	public static UI_btn_PostNewAmplifier CreateInstance()
	{
		return (UI_btn_PostNewAmplifier)(object)UIPackage.CreateObject("GvGExchange3", "btn_PostNewAmplifier");
	}

	public static UI_btn_PostNewAmplifier CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_btn_PostNewAmplifier).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://tt2iq07oxxgp56", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Expected O, but got Unknown
		//IL_003c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0046: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		button = ((GComponent)this).GetController("button");
		n6 = (GGraph)((GComponent)this).GetChild("n6");
		n5 = (GImage)((GComponent)this).GetChild("n5");
	}
}
