using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGShipPopup;

public class UI_dec_light : GComponent
{
	public GImage n136;

	public Transition t0;

	public const string URL = "ui://pwrbvhpvarhu60";

	public static string Name = "UI_dec_light";

	public static string GetURL()
	{
		return "ui://pwrbvhpvarhu60";
	}

	public static UI_dec_light CreateInstance()
	{
		return (UI_dec_light)(object)UIPackage.CreateObject("GvGShipPopup", "dec_light");
	}

	public static UI_dec_light CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_dec_light).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://pwrbvhpvarhu60", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		n136 = (GImage)((GComponent)this).GetChild("n136");
		t0 = ((GComponent)this).GetTransition("t0");
	}
}
