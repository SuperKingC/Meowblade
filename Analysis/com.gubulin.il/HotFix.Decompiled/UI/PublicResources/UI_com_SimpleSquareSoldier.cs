using FairyGUI;
using FairyGUI.Utils;

namespace UI.PublicResources;

public class UI_com_SimpleSquareSoldier : GComponent
{
	public Controller PotentialLevel;

	public GImage background;

	public UI_com_SimpleSolierIconWithMask icon;

	public GLoader Frame;

	public const string URL = "ui://kt6rg65ob4vag";

	public static string Name = "UI_com_SimpleSquareSoldier";

	public static string GetURL()
	{
		return "ui://kt6rg65ob4vag";
	}

	public static UI_com_SimpleSquareSoldier CreateInstance()
	{
		return (UI_com_SimpleSquareSoldier)(object)UIPackage.CreateObject("PublicResources", "com_SimpleSquareSoldier");
	}

	public static UI_com_SimpleSquareSoldier CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_SimpleSquareSoldier).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://kt6rg65ob4vag", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Expected O, but got Unknown
		//IL_0052: Unknown result type (might be due to invalid IL or missing references)
		//IL_005c: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		PotentialLevel = ((GComponent)this).GetController("PotentialLevel");
		background = (GImage)((GComponent)this).GetChild("background");
		icon = (UI_com_SimpleSolierIconWithMask)(object)((GComponent)this).GetChild("icon");
		Frame = (GLoader)((GComponent)this).GetChild("Frame");
	}
}
