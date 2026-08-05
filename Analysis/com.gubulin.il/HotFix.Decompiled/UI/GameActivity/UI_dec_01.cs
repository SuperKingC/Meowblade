using FairyGUI;
using FairyGUI.Utils;

namespace UI.GameActivity;

public class UI_dec_01 : GComponent
{
	public GImage lockMask;

	public GImage n40;

	public Transition t0;

	public Transition unlock;

	public const string URL = "ui://29q48tv6cp085f9h";

	public static string Name = "UI_dec_01";

	public static string GetURL()
	{
		return "ui://29q48tv6cp085f9h";
	}

	public static UI_dec_01 CreateInstance()
	{
		return (UI_dec_01)(object)UIPackage.CreateObject("GameActivity", "dec_01");
	}

	public static UI_dec_01 CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_dec_01).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://29q48tv6cp085f9h", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0035: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		lockMask = (GImage)((GComponent)this).GetChild("lockMask");
		n40 = (GImage)((GComponent)this).GetChild("n40");
		t0 = ((GComponent)this).GetTransition("t0");
		unlock = ((GComponent)this).GetTransition("unlock");
	}
}
