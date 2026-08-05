using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGBrawlFight;

public class UI_dec_05 : GComponent
{
	public GImage n24;

	public GImage n25;

	public Transition t0;

	public const string URL = "ui://hozu168rft1f74";

	public static string Name = "UI_dec_05";

	public static string GetURL()
	{
		return "ui://hozu168rft1f74";
	}

	public static UI_dec_05 CreateInstance()
	{
		return (UI_dec_05)(object)UIPackage.CreateObject("GvGBrawlFight", "dec_05");
	}

	public static UI_dec_05 CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_dec_05).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://hozu168rft1f74", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0035: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		n24 = (GImage)((GComponent)this).GetChild("n24");
		n25 = (GImage)((GComponent)this).GetChild("n25");
		t0 = ((GComponent)this).GetTransition("t0");
	}
}
