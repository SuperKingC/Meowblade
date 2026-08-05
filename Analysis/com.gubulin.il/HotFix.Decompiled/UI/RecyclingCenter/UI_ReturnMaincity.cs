using FairyGUI;
using FairyGUI.Utils;

namespace UI.RecyclingCenter;

public class UI_ReturnMaincity : GButton
{
	public Controller button;

	public GImage n3;

	public GImage n5;

	public const string URL = "ui://72poq8plkxixz";

	public static string Name = "UI_ReturnMaincity";

	public static string GetURL()
	{
		return "ui://72poq8plkxixz";
	}

	public static UI_ReturnMaincity CreateInstance()
	{
		return (UI_ReturnMaincity)(object)UIPackage.CreateObject("RecyclingCenter", "ReturnMaincity");
	}

	public static UI_ReturnMaincity CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_ReturnMaincity).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://72poq8plkxixz", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Expected O, but got Unknown
		//IL_003c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0046: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		button = ((GComponent)this).GetController("button");
		n3 = (GImage)((GComponent)this).GetChild("n3");
		n5 = (GImage)((GComponent)this).GetChild("n5");
	}
}
