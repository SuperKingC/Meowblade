using FairyGUI;
using FairyGUI.Utils;

namespace UI.LegendItemsDraw;

public class UI_curtainTop : GButton
{
	public Controller button;

	public GImage n31;

	public const string URL = "ui://xogvri2hs2vz4";

	public static string Name = "UI_curtainTop";

	public static string GetURL()
	{
		return "ui://xogvri2hs2vz4";
	}

	public static UI_curtainTop CreateInstance()
	{
		return (UI_curtainTop)(object)UIPackage.CreateObject("LegendItemsDraw", "curtainTop");
	}

	public static UI_curtainTop CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_curtainTop).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://xogvri2hs2vz4", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		button = ((GComponent)this).GetController("button");
		n31 = (GImage)((GComponent)this).GetChild("n31");
	}
}
