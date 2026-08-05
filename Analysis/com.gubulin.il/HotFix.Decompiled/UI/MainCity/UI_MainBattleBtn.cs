using FairyGUI;
using FairyGUI.Utils;

namespace UI.MainCity;

public class UI_MainBattleBtn : GButton
{
	public Controller button;

	public GLoader icon;

	public GImage note;

	public const string URL = "ui://j611zmym6wel0";

	public static string Name = "UI_MainBattleBtn";

	public static string GetURL()
	{
		return "ui://j611zmym6wel0";
	}

	public static UI_MainBattleBtn CreateInstance()
	{
		return (UI_MainBattleBtn)(object)UIPackage.CreateObject("MainCity", "MainBattleBtn");
	}

	public static UI_MainBattleBtn CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_MainBattleBtn).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://j611zmym6wel0", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		icon = (GLoader)((GComponent)this).GetChild("icon");
		note = (GImage)((GComponent)this).GetChild("note");
	}
}
