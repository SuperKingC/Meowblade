using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGBrawlFight;

public class UI_dec_portal_02 : GComponent
{
	public GImage n45;

	public GImage n44;

	public GImage n46;

	public Transition t0;

	public Transition t1;

	public const string URL = "ui://hozu168rdop77s";

	public static string Name = "UI_dec_portal_02";

	public static string GetURL()
	{
		return "ui://hozu168rdop77s";
	}

	public static UI_dec_portal_02 CreateInstance()
	{
		return (UI_dec_portal_02)(object)UIPackage.CreateObject("GvGBrawlFight", "dec_portal_02");
	}

	public static UI_dec_portal_02 CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_dec_portal_02).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://hozu168rdop77s", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		((GComponent)this).ConstructFromXML(xml);
		n45 = (GImage)((GComponent)this).GetChild("n45");
		n44 = (GImage)((GComponent)this).GetChild("n44");
		n46 = (GImage)((GComponent)this).GetChild("n46");
		t0 = ((GComponent)this).GetTransition("t0");
		t1 = ((GComponent)this).GetTransition("t1");
	}
}
