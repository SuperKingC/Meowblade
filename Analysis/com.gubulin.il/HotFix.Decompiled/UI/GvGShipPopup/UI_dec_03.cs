using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGShipPopup;

public class UI_dec_03 : GComponent
{
	public GImage n19;

	public GImage n20;

	public Transition t0;

	public const string URL = "ui://pwrbvhpvkh5k7b";

	public static string Name = "UI_dec_03";

	public static string GetURL()
	{
		return "ui://pwrbvhpvkh5k7b";
	}

	public static UI_dec_03 CreateInstance()
	{
		return (UI_dec_03)(object)UIPackage.CreateObject("GvGShipPopup", "dec_03");
	}

	public static UI_dec_03 CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_dec_03).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://pwrbvhpvkh5k7b", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0035: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		n19 = (GImage)((GComponent)this).GetChild("n19");
		n20 = (GImage)((GComponent)this).GetChild("n20");
		t0 = ((GComponent)this).GetTransition("t0");
	}
}
