using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGShipPopup;

public class UI_dec_04 : GComponent
{
	public GImage n143;

	public Transition t0;

	public const string URL = "ui://pwrbvhpvkh5k7c";

	public static string Name = "UI_dec_04";

	public static string GetURL()
	{
		return "ui://pwrbvhpvkh5k7c";
	}

	public static UI_dec_04 CreateInstance()
	{
		return (UI_dec_04)(object)UIPackage.CreateObject("GvGShipPopup", "dec_04");
	}

	public static UI_dec_04 CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_dec_04).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://pwrbvhpvkh5k7c", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		n143 = (GImage)((GComponent)this).GetChild("n143");
		t0 = ((GComponent)this).GetTransition("t0");
	}
}
