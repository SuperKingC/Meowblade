using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGShipPopup;

public class UI_WorkerBackItem : GButton
{
	public Controller button;

	public GImage reduceState;

	public const string URL = "ui://pwrbvhpvlb9h3k";

	public static string Name = "UI_WorkerBackItem";

	public static string GetURL()
	{
		return "ui://pwrbvhpvlb9h3k";
	}

	public static UI_WorkerBackItem CreateInstance()
	{
		return (UI_WorkerBackItem)(object)UIPackage.CreateObject("GvGShipPopup", "WorkerBackItem");
	}

	public static UI_WorkerBackItem CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_WorkerBackItem).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://pwrbvhpvlb9h3k", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		button = ((GComponent)this).GetController("button");
		reduceState = (GImage)((GComponent)this).GetChild("reduceState");
	}
}
