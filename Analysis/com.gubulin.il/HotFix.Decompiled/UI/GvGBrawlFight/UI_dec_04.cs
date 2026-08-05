using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGBrawlFight;

public class UI_dec_04 : GComponent
{
	public GImage n23;

	public UI_dec_05 n24;

	public const string URL = "ui://hozu168rft1f73";

	public static string Name = "UI_dec_04";

	public static string GetURL()
	{
		return "ui://hozu168rft1f73";
	}

	public static UI_dec_04 CreateInstance()
	{
		return (UI_dec_04)(object)UIPackage.CreateObject("GvGBrawlFight", "dec_04");
	}

	public static UI_dec_04 CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_dec_04).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://hozu168rft1f73", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		n23 = (GImage)((GComponent)this).GetChild("n23");
		n24 = (UI_dec_05)(object)((GComponent)this).GetChild("n24");
	}
}
