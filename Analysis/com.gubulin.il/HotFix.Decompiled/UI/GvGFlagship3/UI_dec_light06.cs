using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGFlagship3;

public class UI_dec_light06 : GComponent
{
	public GImage n41;

	public GImage n42;

	public GImage n43;

	public GImage n44;

	public GImage n45;

	public Transition t0;

	public const string URL = "ui://tvr786zlojop3r";

	public static string Name = "UI_dec_light06";

	public static string GetURL()
	{
		return "ui://tvr786zlojop3r";
	}

	public static UI_dec_light06 CreateInstance()
	{
		return (UI_dec_light06)(object)UIPackage.CreateObject("GvGFlagship3", "dec_light06");
	}

	public static UI_dec_light06 CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_dec_light06).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://tvr786zlojop3r", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		//IL_006d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0077: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		n41 = (GImage)((GComponent)this).GetChild("n41");
		n42 = (GImage)((GComponent)this).GetChild("n42");
		n43 = (GImage)((GComponent)this).GetChild("n43");
		n44 = (GImage)((GComponent)this).GetChild("n44");
		n45 = (GImage)((GComponent)this).GetChild("n45");
		t0 = ((GComponent)this).GetTransition("t0");
	}
}
