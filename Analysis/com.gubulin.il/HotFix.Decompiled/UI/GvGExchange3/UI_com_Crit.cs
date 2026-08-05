using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGExchange3;

public class UI_com_Crit : GComponent
{
	public Controller Color;

	public GImage n0;

	public GTextField CritValue;

	public const string URL = "ui://tt2iq07odip34p";

	public static string Name = "UI_com_Crit";

	public static string GetURL()
	{
		return "ui://tt2iq07odip34p";
	}

	public static UI_com_Crit CreateInstance()
	{
		return (UI_com_Crit)(object)UIPackage.CreateObject("GvGExchange3", "com_Crit");
	}

	public static UI_com_Crit CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_Crit).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://tt2iq07odip34p", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Expected O, but got Unknown
		//IL_003c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0046: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		Color = ((GComponent)this).GetController("Color");
		n0 = (GImage)((GComponent)this).GetChild("n0");
		CritValue = (GTextField)((GComponent)this).GetChild("CritValue");
	}
}
