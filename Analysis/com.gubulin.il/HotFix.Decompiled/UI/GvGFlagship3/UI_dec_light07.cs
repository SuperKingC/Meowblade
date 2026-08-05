using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGFlagship3;

public class UI_dec_light07 : GComponent
{
	public GImage n46;

	public GImage n47;

	public GImage n48;

	public GImage n49;

	public Transition t0;

	public const string URL = "ui://tvr786zlojop3s";

	public static string Name = "UI_dec_light07";

	public static string GetURL()
	{
		return "ui://tvr786zlojop3s";
	}

	public static UI_dec_light07 CreateInstance()
	{
		return (UI_dec_light07)(object)UIPackage.CreateObject("GvGFlagship3", "dec_light07");
	}

	public static UI_dec_light07 CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_dec_light07).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://tvr786zlojop3s", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0035: Expected O, but got Unknown
		//IL_0041: Unknown result type (might be due to invalid IL or missing references)
		//IL_004b: Expected O, but got Unknown
		//IL_0057: Unknown result type (might be due to invalid IL or missing references)
		//IL_0061: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		n46 = (GImage)((GComponent)this).GetChild("n46");
		n47 = (GImage)((GComponent)this).GetChild("n47");
		n48 = (GImage)((GComponent)this).GetChild("n48");
		n49 = (GImage)((GComponent)this).GetChild("n49");
		t0 = ((GComponent)this).GetTransition("t0");
	}
}
