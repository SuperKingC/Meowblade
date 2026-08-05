using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGShipOverview;

public class UI_RaceTypeSmall : GButton
{
	public Controller button;

	public GImage n13;

	public GLoader RaceIcon;

	public const string URL = "ui://7ymaonxtlaby36";

	public static string Name = "UI_RaceTypeSmall";

	public static string GetURL()
	{
		return "ui://7ymaonxtlaby36";
	}

	public static UI_RaceTypeSmall CreateInstance()
	{
		return (UI_RaceTypeSmall)(object)UIPackage.CreateObject("GvGShipOverview", "RaceTypeSmall");
	}

	public static UI_RaceTypeSmall CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_RaceTypeSmall).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://7ymaonxtlaby36", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Expected O, but got Unknown
		//IL_003c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0046: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		button = ((GComponent)this).GetController("button");
		n13 = (GImage)((GComponent)this).GetChild("n13");
		RaceIcon = (GLoader)((GComponent)this).GetChild("RaceIcon");
	}
}
