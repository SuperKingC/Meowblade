using FairyGUI;
using FairyGUI.Utils;

namespace UI.Contract;

public class UI_CardCannon : GComponent
{
	public GGraph CannonWrapper;

	public Transition Fire;

	public const string URL = "ui://avplaivdicfotn9";

	public static string Name = "UI_CardCannon";

	public static string GetURL()
	{
		return "ui://avplaivdicfotn9";
	}

	public static UI_CardCannon CreateInstance()
	{
		return (UI_CardCannon)(object)UIPackage.CreateObject("Contract", "CardCannon");
	}

	public static UI_CardCannon CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_CardCannon).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://avplaivdicfotn9", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		CannonWrapper = (GGraph)((GComponent)this).GetChild("CannonWrapper");
		Fire = ((GComponent)this).GetTransition("Fire");
	}
}
