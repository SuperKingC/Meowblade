using FairyGUI;
using FairyGUI.Utils;

namespace UI.QuickBattle;

public class UI_TeamRedBtn : GButton
{
	public Controller button;

	public Controller Type;

	public UI_MyIcon Icon;

	public Transition Down;

	public const string URL = "ui://kqd1t06of258x";

	public static string Name = "UI_TeamRedBtn";

	public static string GetURL()
	{
		return "ui://kqd1t06of258x";
	}

	public static UI_TeamRedBtn CreateInstance()
	{
		return (UI_TeamRedBtn)(object)UIPackage.CreateObject("QuickBattle", "TeamRedBtn");
	}

	public static UI_TeamRedBtn CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_TeamRedBtn).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://kqd1t06of258x", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		((GComponent)this).ConstructFromXML(xml);
		button = ((GComponent)this).GetController("button");
		Type = ((GComponent)this).GetController("Type");
		Icon = (UI_MyIcon)(object)((GComponent)this).GetChild("Icon");
		Down = ((GComponent)this).GetTransition("Down");
	}
}
