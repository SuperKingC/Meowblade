using FairyGUI;
using FairyGUI.Utils;

namespace UI.PublicResources;

public class UI_BuildingTitle7 : GComponent
{
	public Controller Status;

	public GImage back;

	public GLoader icon;

	public GTextField name;

	public GImage note;

	public Transition t0;

	public const string URL = "ui://kt6rg65omm09v4ju";

	public static string Name = "UI_BuildingTitle7";

	public static string GetURL()
	{
		return "ui://kt6rg65omm09v4ju";
	}

	public static UI_BuildingTitle7 CreateInstance()
	{
		return (UI_BuildingTitle7)(object)UIPackage.CreateObject("PublicResources", "BuildingTitle7");
	}

	public static UI_BuildingTitle7 CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_BuildingTitle7).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://kt6rg65omm09v4ju", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		Status = ((GComponent)this).GetController("Status");
		back = (GImage)((GComponent)this).GetChild("back");
		icon = (GLoader)((GComponent)this).GetChild("icon");
		name = (GTextField)((GComponent)this).GetChild("name");
		note = (GImage)((GComponent)this).GetChild("note");
		t0 = ((GComponent)this).GetTransition("t0");
	}
}
