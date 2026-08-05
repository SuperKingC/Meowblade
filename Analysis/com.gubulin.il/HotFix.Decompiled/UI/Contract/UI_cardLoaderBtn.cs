using FairyGUI;
using FairyGUI.Utils;

namespace UI.Contract;

public class UI_cardLoaderBtn : GButton
{
	public Controller button;

	public GLoader icon;

	public GImage newIcon;

	public GImage upLogo;

	public GGraph specialEffectsBack;

	public Transition bounce;

	public Transition overturn0;

	public Transition overturn1;

	public Transition overturn2;

	public Transition ShowUpLogo;

	public const string URL = "ui://avplaivdoppx1m";

	public static string Name = "UI_cardLoaderBtn";

	public static string GetURL()
	{
		return "ui://avplaivdoppx1m";
	}

	public static UI_cardLoaderBtn CreateInstance()
	{
		return (UI_cardLoaderBtn)(object)UIPackage.CreateObject("Contract", "cardLoaderBtn");
	}

	public static UI_cardLoaderBtn CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_cardLoaderBtn).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://avplaivdoppx1m", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		icon = (GLoader)((GComponent)this).GetChild("icon");
		newIcon = (GImage)((GComponent)this).GetChild("newIcon");
		upLogo = (GImage)((GComponent)this).GetChild("upLogo");
		specialEffectsBack = (GGraph)((GComponent)this).GetChild("specialEffectsBack");
		bounce = ((GComponent)this).GetTransition("bounce");
		overturn0 = ((GComponent)this).GetTransition("overturn0");
		overturn1 = ((GComponent)this).GetTransition("overturn1");
		overturn2 = ((GComponent)this).GetTransition("overturn2");
		ShowUpLogo = ((GComponent)this).GetTransition("ShowUpLogo");
	}
}
