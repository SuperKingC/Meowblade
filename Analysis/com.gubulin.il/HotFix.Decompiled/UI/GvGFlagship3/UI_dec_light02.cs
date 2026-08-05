using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGFlagship3;

public class UI_dec_light02 : GComponent
{
	public GImage n37;

	public GImage n38;

	public Transition t0;

	public const string URL = "ui://tvr786zlojop3m";

	public static string Name = "UI_dec_light02";

	public static string GetURL()
	{
		return "ui://tvr786zlojop3m";
	}

	public static UI_dec_light02 CreateInstance()
	{
		return (UI_dec_light02)(object)UIPackage.CreateObject("GvGFlagship3", "dec_light02");
	}

	public static UI_dec_light02 CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_dec_light02).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://tvr786zlojop3m", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0035: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		n37 = (GImage)((GComponent)this).GetChild("n37");
		n38 = (GImage)((GComponent)this).GetChild("n38");
		t0 = ((GComponent)this).GetTransition("t0");
	}
}
