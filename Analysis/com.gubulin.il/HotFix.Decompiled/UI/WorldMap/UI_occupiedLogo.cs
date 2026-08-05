using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.WorldMap;

public class UI_occupiedLogo : GButton
{
	public Controller button;

	public GTextField areaName;

	public GTextField n4;

	public GLoader icon;

	public GMovieClip Occupy;

	public GGraph spineBase;

	public GGraph SfxBack;

	public GButton ExclamationTipBtn;

	public Transition magnify;

	public Transition shrink;

	public Transition setInitSize;

	public const string URL = "ui://c9n2h0ksee14m";

	public static string Name = "UI_occupiedLogo";

	public static string GetURL()
	{
		return "ui://c9n2h0ksee14m";
	}

	public static UI_occupiedLogo CreateInstance()
	{
		return (UI_occupiedLogo)(object)UIPackage.CreateObject("WorldMap", "occupiedLogo");
	}

	public static UI_occupiedLogo CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_occupiedLogo).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://c9n2h0ksee14m", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Expected O, but got Unknown
		//IL_0079: Unknown result type (might be due to invalid IL or missing references)
		//IL_0083: Expected O, but got Unknown
		//IL_00cc: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d6: Expected O, but got Unknown
		//IL_00e2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ec: Expected O, but got Unknown
		//IL_00f8: Unknown result type (might be due to invalid IL or missing references)
		//IL_0102: Expected O, but got Unknown
		//IL_010e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0118: Expected O, but got Unknown
		//IL_0124: Unknown result type (might be due to invalid IL or missing references)
		//IL_012e: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		button = ((GComponent)this).GetController("button");
		areaName = (GTextField)((GComponent)this).GetChild("areaName");
		string id = "ui://c9n2h0ksee14m".Replace("ui://", "") + "-" + ((GObject)areaName).id;
		((GObject)areaName).text = LanguagesManager.GetDesc(id);
		n4 = (GTextField)((GComponent)this).GetChild("n4");
		string id2 = "ui://c9n2h0ksee14m".Replace("ui://", "") + "-" + ((GObject)n4).id;
		((GObject)n4).text = LanguagesManager.GetDesc(id2);
		icon = (GLoader)((GComponent)this).GetChild("icon");
		Occupy = (GMovieClip)((GComponent)this).GetChild("Occupy");
		spineBase = (GGraph)((GComponent)this).GetChild("spineBase");
		SfxBack = (GGraph)((GComponent)this).GetChild("SfxBack");
		ExclamationTipBtn = (GButton)((GComponent)this).GetChild("ExclamationTipBtn");
		magnify = ((GComponent)this).GetTransition("magnify");
		shrink = ((GComponent)this).GetTransition("shrink");
		setInitSize = ((GComponent)this).GetTransition("setInitSize");
	}
}
