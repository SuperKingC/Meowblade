using FairyGUI;
using FairyGUI.Utils;

namespace UI.LoginAndName;

public class UI_clear : GButton
{
	public Controller button;

	public GImage back;

	public GImage close;

	public const string URL = "ui://yb3s7uv7op6kx";

	public static string Name = "UI_clear";

	public static string GetURL()
	{
		return "ui://yb3s7uv7op6kx";
	}

	public static UI_clear CreateInstance()
	{
		return (UI_clear)(object)UIPackage.CreateObject("LoginAndName", "clear");
	}

	public static UI_clear CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_clear).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://yb3s7uv7op6kx", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		back = (GImage)((GComponent)this).GetChild("back");
		close = (GImage)((GComponent)this).GetChild("close");
	}
}
