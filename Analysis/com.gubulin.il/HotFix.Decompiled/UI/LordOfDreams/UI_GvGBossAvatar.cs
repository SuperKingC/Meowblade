using FairyGUI;
using FairyGUI.Utils;

namespace UI.LordOfDreams;

public class UI_GvGBossAvatar : GComponent
{
	public GImage n0;

	public GGraph SpineLoader;

	public const string URL = "ui://0i520nzmp5p0o5f";

	public static string Name = "UI_GvGBossAvatar";

	public static string GetURL()
	{
		return "ui://0i520nzmp5p0o5f";
	}

	public static UI_GvGBossAvatar CreateInstance()
	{
		return (UI_GvGBossAvatar)(object)UIPackage.CreateObject("LordOfDreams", "GvGBossAvatar");
	}

	public static UI_GvGBossAvatar CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_GvGBossAvatar).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://0i520nzmp5p0o5f", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0035: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		n0 = (GImage)((GComponent)this).GetChild("n0");
		SpineLoader = (GGraph)((GComponent)this).GetChild("SpineLoader");
	}
}
