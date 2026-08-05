using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvG3LandOfEternalNight;

public class UI_dec_DrawlCloud_02 : GComponent
{
	public GImage n94;

	public Transition t0;

	public const string URL = "ui://amuqyzl8ricp1n";

	public static string Name = "UI_dec_DrawlCloud_02";

	public static string GetURL()
	{
		return "ui://amuqyzl8ricp1n";
	}

	public static UI_dec_DrawlCloud_02 CreateInstance()
	{
		return (UI_dec_DrawlCloud_02)(object)UIPackage.CreateObject("GvG3LandOfEternalNight", "dec_DrawlCloud_02");
	}

	public static UI_dec_DrawlCloud_02 CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_dec_DrawlCloud_02).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://amuqyzl8ricp1n", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		n94 = (GImage)((GComponent)this).GetChild("n94");
		t0 = ((GComponent)this).GetTransition("t0");
	}
}
