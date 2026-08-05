using FairyGUI;
using FairyGUI.Utils;

namespace UI.UpGrade;

public class UI_workerItem : GButton
{
	public Controller button;

	public GImage normalState;

	public Transition increase;

	public Transition reduce;

	public const string URL = "ui://lrjfe94hheurf";

	public static string Name = "UI_workerItem";

	public static string GetURL()
	{
		return "ui://lrjfe94hheurf";
	}

	public static UI_workerItem CreateInstance()
	{
		return (UI_workerItem)(object)UIPackage.CreateObject("UpGrade", "workerItem");
	}

	public static UI_workerItem CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_workerItem).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://lrjfe94hheurf", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		button = ((GComponent)this).GetController("button");
		normalState = (GImage)((GComponent)this).GetChild("normalState");
		increase = ((GComponent)this).GetTransition("increase");
		reduce = ((GComponent)this).GetTransition("reduce");
	}
}
