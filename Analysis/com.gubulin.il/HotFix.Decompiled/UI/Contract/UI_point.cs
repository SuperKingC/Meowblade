using FairyGUI;
using FairyGUI.Utils;

namespace UI.Contract;

public class UI_point : GButton
{
	public Controller button;

	public Transition disappear;

	public Transition appear;

	public const string URL = "ui://avplaivdrv9zt6u";

	public static string Name = "UI_point";

	public static string GetURL()
	{
		return "ui://avplaivdrv9zt6u";
	}

	public static UI_point CreateInstance()
	{
		return (UI_point)(object)UIPackage.CreateObject("Contract", "point");
	}

	public static UI_point CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_point).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://avplaivdrv9zt6u", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		((GComponent)this).ConstructFromXML(xml);
		button = ((GComponent)this).GetController("button");
		disappear = ((GComponent)this).GetTransition("disappear");
		appear = ((GComponent)this).GetTransition("appear");
	}
}
