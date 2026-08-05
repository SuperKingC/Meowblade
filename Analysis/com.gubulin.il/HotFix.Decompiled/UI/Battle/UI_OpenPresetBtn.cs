using FairyGUI;
using FairyGUI.Utils;

namespace UI.Battle;

public class UI_OpenPresetBtn : GButton
{
	public Controller button;

	public GImage bg;

	public GImage title;

	public const string URL = "ui://twlbabicii3ejn";

	public static string Name = "UI_OpenPresetBtn";

	public static string GetURL()
	{
		return "ui://twlbabicii3ejn";
	}

	public static UI_OpenPresetBtn CreateInstance()
	{
		return (UI_OpenPresetBtn)(object)UIPackage.CreateObject("Battle", "OpenPresetBtn");
	}

	public static UI_OpenPresetBtn CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_OpenPresetBtn).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://twlbabicii3ejn", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		bg = (GImage)((GComponent)this).GetChild("bg");
		title = (GImage)((GComponent)this).GetChild("title");
	}
}
