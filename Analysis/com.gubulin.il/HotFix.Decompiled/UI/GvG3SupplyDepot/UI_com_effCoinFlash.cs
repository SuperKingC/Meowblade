using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvG3SupplyDepot;

public class UI_com_effCoinFlash : GComponent
{
	public GMovieClip n0;

	public const string URL = "ui://pobej4q7a1l0y1n";

	public static string Name = "UI_com_effCoinFlash";

	public static string GetURL()
	{
		return "ui://pobej4q7a1l0y1n";
	}

	public static UI_com_effCoinFlash CreateInstance()
	{
		return (UI_com_effCoinFlash)(object)UIPackage.CreateObject("GvG3SupplyDepot", "com_effCoinFlash");
	}

	public static UI_com_effCoinFlash CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_effCoinFlash).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://pobej4q7a1l0y1n", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		n0 = (GMovieClip)((GComponent)this).GetChild("n0");
	}
}
