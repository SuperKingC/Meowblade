using FairyGUI;
using FairyGUI.Utils;

namespace UI.UpGrade;

public class UI_reduce : GButton
{
	public Controller button;

	public GImage background;

	public const string URL = "ui://lrjfe94hheurd";

	public static string Name = "UI_reduce";

	public static string GetURL()
	{
		return "ui://lrjfe94hheurd";
	}

	public static UI_reduce CreateInstance()
	{
		return (UI_reduce)(object)UIPackage.CreateObject("UpGrade", "reduce");
	}

	public static UI_reduce CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_reduce).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://lrjfe94hheurd", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
