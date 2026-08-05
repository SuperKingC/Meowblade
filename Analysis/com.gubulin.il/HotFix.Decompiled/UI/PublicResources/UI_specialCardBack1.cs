using FairyGUI;
using FairyGUI.Utils;

namespace UI.PublicResources;

public class UI_specialCardBack1 : GButton
{
	public Controller button;

	public GImage n17;

	public GImage n14;

	public GMovieClip n16;

	public GImage n15;

	public Transition t0;

	public Transition t1;

	public const string URL = "ui://kt6rg65ovv0uf3";

	public static string Name = "UI_specialCardBack1";

	public static string GetURL()
	{
		return "ui://kt6rg65ovv0uf3";
	}

	public static UI_specialCardBack1 CreateInstance()
	{
		return (UI_specialCardBack1)(object)UIPackage.CreateObject("PublicResources", "specialCardBack1");
	}

	public static UI_specialCardBack1 CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_specialCardBack1).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://kt6rg65ovv0uf3", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Expected O, but got Unknown
		//IL_003c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0046: Expected O, but got Unknown
		//IL_0052: Unknown result type (might be due to invalid IL or missing references)
		//IL_005c: Expected O, but got Unknown
		//IL_0068: Unknown result type (might be due to invalid IL or missing references)
		//IL_0072: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		button = ((GComponent)this).GetController("button");
		n17 = (GImage)((GComponent)this).GetChild("n17");
		n14 = (GImage)((GComponent)this).GetChild("n14");
		n16 = (GMovieClip)((GComponent)this).GetChild("n16");
		n15 = (GImage)((GComponent)this).GetChild("n15");
		t0 = ((GComponent)this).GetTransition("t0");
		t1 = ((GComponent)this).GetTransition("t1");
	}
}
