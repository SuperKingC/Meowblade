using FairyGUI;
using FairyGUI.Utils;

namespace UI.SpecialActivity;

public class UI_ActivityTabBack : GButton
{
	public Controller button;

	public GImage n3;

	public const string URL = "ui://kozswd8hfs5xf24";

	public static string Name = "UI_ActivityTabBack";

	public static string GetURL()
	{
		return "ui://kozswd8hfs5xf24";
	}

	public static UI_ActivityTabBack CreateInstance()
	{
		return (UI_ActivityTabBack)(object)UIPackage.CreateObject("SpecialActivity", "ActivityTabBack");
	}

	public static UI_ActivityTabBack CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_ActivityTabBack).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://kozswd8hfs5xf24", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		button = ((GComponent)this).GetController("button");
		n3 = (GImage)((GComponent)this).GetChild("n3");
	}
}
