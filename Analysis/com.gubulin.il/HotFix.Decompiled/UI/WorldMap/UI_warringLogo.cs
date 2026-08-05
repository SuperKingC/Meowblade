using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.WorldMap;

public class UI_warringLogo : GButton
{
	public Controller button;

	public Controller PageController;

	public GMovieClip n3;

	public GTextField levelName;

	public const string URL = "ui://c9n2h0ksz7z62t";

	public static string Name = "UI_warringLogo";

	public static string GetURL()
	{
		return "ui://c9n2h0ksz7z62t";
	}

	public static UI_warringLogo CreateInstance()
	{
		return (UI_warringLogo)(object)UIPackage.CreateObject("WorldMap", "warringLogo");
	}

	public static UI_warringLogo CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_warringLogo).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://c9n2h0ksz7z62t", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0037: Unknown result type (might be due to invalid IL or missing references)
		//IL_0041: Expected O, but got Unknown
		//IL_004d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0057: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		button = ((GComponent)this).GetController("button");
		PageController = ((GComponent)this).GetController("PageController");
		n3 = (GMovieClip)((GComponent)this).GetChild("n3");
		levelName = (GTextField)((GComponent)this).GetChild("levelName");
		string id = "ui://c9n2h0ksz7z62t".Replace("ui://", "") + "-" + ((GObject)levelName).id;
		((GObject)levelName).text = LanguagesManager.GetDesc(id);
	}
}
