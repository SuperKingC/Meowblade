using FairyGUI;
using FairyGUI.Utils;

namespace UI.UpGrade;

public class UI_increase : GButton
{
	public Controller button;

	public GImage background;

	public const string URL = "ui://lrjfe94hheurc";

	public static string Name = "UI_increase";

	public static string GetURL()
	{
		return "ui://lrjfe94hheurc";
	}

	public static UI_increase CreateInstance()
	{
		return (UI_increase)(object)UIPackage.CreateObject("UpGrade", "increase");
	}

	public static UI_increase CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_increase).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://lrjfe94hheurc", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
