using FairyGUI;
using FairyGUI.Utils;

namespace UI.UnlockSoldierShow;

public class UI_dec_light02 : GComponent
{
	public GImage n88;

	public Transition t0;

	public const string URL = "ui://ia1am3ehi7qut37";

	public static string Name = "UI_dec_light02";

	public static string GetURL()
	{
		return "ui://ia1am3ehi7qut37";
	}

	public static UI_dec_light02 CreateInstance()
	{
		return (UI_dec_light02)(object)UIPackage.CreateObject("UnlockSoldierShow", "dec_light02");
	}

	public static UI_dec_light02 CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_dec_light02).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://ia1am3ehi7qut37", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		n88 = (GImage)((GComponent)this).GetChild("n88");
		t0 = ((GComponent)this).GetTransition("t0");
	}
}
