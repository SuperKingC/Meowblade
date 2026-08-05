using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGShipPopup;

public class UI_dec_01 : GComponent
{
	public GImage n139;

	public GImage n140;

	public Transition t0;

	public const string URL = "ui://pwrbvhpvkh5k79";

	public static string Name = "UI_dec_01";

	public static string GetURL()
	{
		return "ui://pwrbvhpvkh5k79";
	}

	public static UI_dec_01 CreateInstance()
	{
		return (UI_dec_01)(object)UIPackage.CreateObject("GvGShipPopup", "dec_01");
	}

	public static UI_dec_01 CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_dec_01).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://pwrbvhpvkh5k79", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0035: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		n139 = (GImage)((GComponent)this).GetChild("n139");
		n140 = (GImage)((GComponent)this).GetChild("n140");
		t0 = ((GComponent)this).GetTransition("t0");
	}
}
