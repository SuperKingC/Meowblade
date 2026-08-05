using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGWorldMap3;

public class UI_btn_FakeJumpModeSwitch : GButton
{
	public Controller button;

	public const string URL = "ui://4eq8fgd2r0c4d5";

	public static string Name = "UI_btn_FakeJumpModeSwitch";

	public static string GetURL()
	{
		return "ui://4eq8fgd2r0c4d5";
	}

	public static UI_btn_FakeJumpModeSwitch CreateInstance()
	{
		return (UI_btn_FakeJumpModeSwitch)(object)UIPackage.CreateObject("GvGWorldMap3", "btn_FakeJumpModeSwitch");
	}

	public static UI_btn_FakeJumpModeSwitch CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_btn_FakeJumpModeSwitch).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://4eq8fgd2r0c4d5", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		((GComponent)this).ConstructFromXML(xml);
		button = ((GComponent)this).GetController("button");
	}
}
