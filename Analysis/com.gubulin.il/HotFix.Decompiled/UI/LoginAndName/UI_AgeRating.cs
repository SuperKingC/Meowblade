using FairyGUI;
using FairyGUI.Utils;

namespace UI.LoginAndName;

public class UI_AgeRating : GButton
{
	public Controller button;

	public Controller Type;

	public GImage n3;

	public const string URL = "ui://yb3s7uv7p18i3a";

	public static string Name = "UI_AgeRating";

	public static string GetURL()
	{
		return "ui://yb3s7uv7p18i3a";
	}

	public static UI_AgeRating CreateInstance()
	{
		return (UI_AgeRating)(object)UIPackage.CreateObject("LoginAndName", "AgeRating");
	}

	public static UI_AgeRating CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_AgeRating).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://yb3s7uv7p18i3a", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0037: Unknown result type (might be due to invalid IL or missing references)
		//IL_0041: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		button = ((GComponent)this).GetController("button");
		Type = ((GComponent)this).GetController("Type");
		n3 = (GImage)((GComponent)this).GetChild("n3");
	}
}
