using FairyGUI;
using FairyGUI.Utils;

namespace UI.PublicResources;

public class UI_buildingDirectionIndicator : GButton
{
	public Controller button;

	public GImage back;

	public GLoader icon;

	public Transition shakeSelf;

	public Transition zoomSelf;

	public const string URL = "ui://kt6rg65omol0iq";

	public static string Name = "UI_buildingDirectionIndicator";

	public static string GetURL()
	{
		return "ui://kt6rg65omol0iq";
	}

	public static UI_buildingDirectionIndicator CreateInstance()
	{
		return (UI_buildingDirectionIndicator)(object)UIPackage.CreateObject("PublicResources", "buildingDirectionIndicator");
	}

	public static UI_buildingDirectionIndicator CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_buildingDirectionIndicator).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://kt6rg65omol0iq", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		back = (GImage)((GComponent)this).GetChild("back");
		icon = (GLoader)((GComponent)this).GetChild("icon");
		shakeSelf = ((GComponent)this).GetTransition("shakeSelf");
		zoomSelf = ((GComponent)this).GetTransition("zoomSelf");
	}
}
