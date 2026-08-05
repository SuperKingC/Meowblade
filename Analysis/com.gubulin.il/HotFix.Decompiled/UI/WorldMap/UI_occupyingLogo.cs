using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.WorldMap;

public class UI_occupyingLogo : GButton
{
	public Controller button;

	public GTextField areaName;

	public GMovieClip n4;

	public Transition magnify;

	public Transition shrink;

	public Transition setInitSize;

	public const string URL = "ui://c9n2h0ksee14l";

	public static string Name = "UI_occupyingLogo";

	public static string GetURL()
	{
		return "ui://c9n2h0ksee14l";
	}

	public static UI_occupyingLogo CreateInstance()
	{
		return (UI_occupyingLogo)(object)UIPackage.CreateObject("WorldMap", "occupyingLogo");
	}

	public static UI_occupyingLogo CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_occupyingLogo).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://c9n2h0ksee14l", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Expected O, but got Unknown
		//IL_0079: Unknown result type (might be due to invalid IL or missing references)
		//IL_0083: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		button = ((GComponent)this).GetController("button");
		areaName = (GTextField)((GComponent)this).GetChild("areaName");
		string id = "ui://c9n2h0ksee14l".Replace("ui://", "") + "-" + ((GObject)areaName).id;
		((GObject)areaName).text = LanguagesManager.GetDesc(id);
		n4 = (GMovieClip)((GComponent)this).GetChild("n4");
		magnify = ((GComponent)this).GetTransition("magnify");
		shrink = ((GComponent)this).GetTransition("shrink");
		setInitSize = ((GComponent)this).GetTransition("setInitSize");
	}
}
