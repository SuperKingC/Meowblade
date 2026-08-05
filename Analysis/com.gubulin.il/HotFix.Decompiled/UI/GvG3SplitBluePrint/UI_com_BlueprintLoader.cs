using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvG3SplitBluePrint;

public class UI_com_BlueprintLoader : GComponent
{
	public Controller State;

	public Controller isLocked;

	public GLoader Loader;

	public UI_btn_Enqueue Enqueue;

	public UI_btn_Dequeue Dequeue;

	public const string URL = "ui://7uylntmmju1uk";

	public static string Name = "UI_com_BlueprintLoader";

	public static string GetURL()
	{
		return "ui://7uylntmmju1uk";
	}

	public static UI_com_BlueprintLoader CreateInstance()
	{
		return (UI_com_BlueprintLoader)(object)UIPackage.CreateObject("GvG3SplitBluePrint", "com_BlueprintLoader");
	}

	public static UI_com_BlueprintLoader CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_BlueprintLoader).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://7uylntmmju1uk", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0037: Unknown result type (might be due to invalid IL or missing references)
		//IL_0041: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		State = ((GComponent)this).GetController("State");
		isLocked = ((GComponent)this).GetController("isLocked");
		Loader = (GLoader)((GComponent)this).GetChild("Loader");
		Enqueue = (UI_btn_Enqueue)(object)((GComponent)this).GetChild("Enqueue");
		Dequeue = (UI_btn_Dequeue)(object)((GComponent)this).GetChild("Dequeue");
	}
}
