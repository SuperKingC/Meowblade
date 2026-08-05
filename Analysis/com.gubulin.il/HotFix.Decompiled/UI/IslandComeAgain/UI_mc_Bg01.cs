using FairyGUI;
using FairyGUI.Utils;

namespace UI.IslandComeAgain;

public class UI_mc_Bg01 : GComponent
{
	public GGraph n0;

	public const string URL = "ui://k2sprg26laau4b";

	public static string Name = "UI_mc_Bg01";

	public static string GetURL()
	{
		return "ui://k2sprg26laau4b";
	}

	public static UI_mc_Bg01 CreateInstance()
	{
		return (UI_mc_Bg01)(object)UIPackage.CreateObject("IslandComeAgain", "mc_Bg01");
	}

	public static UI_mc_Bg01 CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_mc_Bg01).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://k2sprg26laau4b", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		n0 = (GGraph)((GComponent)this).GetChild("n0");
	}
}
