using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGShipPopup;

public class UI_AddWorker : GButton
{
	public Controller button;

	public GImage background;

	public const string URL = "ui://pwrbvhpvlb9h3i";

	public static string Name = "UI_AddWorker";

	public static string GetURL()
	{
		return "ui://pwrbvhpvlb9h3i";
	}

	public static UI_AddWorker CreateInstance()
	{
		return (UI_AddWorker)(object)UIPackage.CreateObject("GvGShipPopup", "AddWorker");
	}

	public static UI_AddWorker CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_AddWorker).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://pwrbvhpvlb9h3i", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		button = ((GComponent)this).GetController("button");
		background = (GImage)((GComponent)this).GetChild("background");
	}
}
