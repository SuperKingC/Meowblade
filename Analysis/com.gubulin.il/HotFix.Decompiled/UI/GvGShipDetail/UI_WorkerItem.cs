using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGShipDetail;

public class UI_WorkerItem : GButton
{
	public Controller button;

	public Controller HasWorker;

	public GImage normalState;

	public GImage increaseState;

	public GImage n5;

	public Transition reduce;

	public Transition increase;

	public const string URL = "ui://u6x0b1gnghds3m";

	public static string Name = "UI_WorkerItem";

	public static string GetURL()
	{
		return "ui://u6x0b1gnghds3m";
	}

	public static UI_WorkerItem CreateInstance()
	{
		return (UI_WorkerItem)(object)UIPackage.CreateObject("GvGShipDetail", "WorkerItem");
	}

	public static UI_WorkerItem CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_WorkerItem).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://u6x0b1gnghds3m", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0037: Unknown result type (might be due to invalid IL or missing references)
		//IL_0041: Expected O, but got Unknown
		//IL_004d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0057: Expected O, but got Unknown
		//IL_0063: Unknown result type (might be due to invalid IL or missing references)
		//IL_006d: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		button = ((GComponent)this).GetController("button");
		HasWorker = ((GComponent)this).GetController("HasWorker");
		normalState = (GImage)((GComponent)this).GetChild("normalState");
		increaseState = (GImage)((GComponent)this).GetChild("increaseState");
		n5 = (GImage)((GComponent)this).GetChild("n5");
		reduce = ((GComponent)this).GetTransition("reduce");
		increase = ((GComponent)this).GetTransition("increase");
	}
}
