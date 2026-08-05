using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGShipPopup;

public class UI_ReduceWorker : GButton
{
	public Controller button;

	public GImage background;

	public const string URL = "ui://pwrbvhpvlb9h3j";

	public static string Name = "UI_ReduceWorker";

	public static string GetURL()
	{
		return "ui://pwrbvhpvlb9h3j";
	}

	public static UI_ReduceWorker CreateInstance()
	{
		return (UI_ReduceWorker)(object)UIPackage.CreateObject("GvGShipPopup", "ReduceWorker");
	}

	public static UI_ReduceWorker CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_ReduceWorker).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://pwrbvhpvlb9h3j", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
