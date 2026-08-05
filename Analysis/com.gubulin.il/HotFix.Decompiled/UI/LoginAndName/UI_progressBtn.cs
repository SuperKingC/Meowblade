using FairyGUI;
using FairyGUI.Utils;

namespace UI.LoginAndName;

public class UI_progressBtn : GProgressBar
{
	public GGraph back;

	public GImage bar;

	public GGraph SfxBack;

	public const string URL = "ui://yb3s7uv7pg3p38";

	public static string Name = "UI_progressBtn";

	public static string GetURL()
	{
		return "ui://yb3s7uv7pg3p38";
	}

	public static UI_progressBtn CreateInstance()
	{
		return (UI_progressBtn)(object)UIPackage.CreateObject("LoginAndName", "progressBtn");
	}

	public static UI_progressBtn CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_progressBtn).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://yb3s7uv7pg3p38", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0035: Expected O, but got Unknown
		//IL_0041: Unknown result type (might be due to invalid IL or missing references)
		//IL_004b: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		back = (GGraph)((GComponent)this).GetChild("back");
		bar = (GImage)((GComponent)this).GetChild("bar");
		SfxBack = (GGraph)((GComponent)this).GetChild("SfxBack");
	}
}
