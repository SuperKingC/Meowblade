using FairyGUI;
using FairyGUI.Utils;

namespace UI.WorldMap;

public class UI_blackHoleBack : GButton
{
	public Controller button;

	public GGraph SfxBack;

	public const string URL = "ui://c9n2h0ksm7wz92";

	public static string Name = "UI_blackHoleBack";

	public static string GetURL()
	{
		return "ui://c9n2h0ksm7wz92";
	}

	public static UI_blackHoleBack CreateInstance()
	{
		return (UI_blackHoleBack)(object)UIPackage.CreateObject("WorldMap", "blackHoleBack");
	}

	public static UI_blackHoleBack CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_blackHoleBack).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://c9n2h0ksm7wz92", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		button = ((GComponent)this).GetController("button");
		SfxBack = (GGraph)((GComponent)this).GetChild("SfxBack");
	}
}
