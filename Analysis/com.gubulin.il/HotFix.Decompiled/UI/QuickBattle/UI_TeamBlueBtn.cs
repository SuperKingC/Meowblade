using FairyGUI;
using FairyGUI.Utils;

namespace UI.QuickBattle;

public class UI_TeamBlueBtn : GButton
{
	public Controller button;

	public Controller Type;

	public UI_EnemyIcon Icon;

	public Transition Down;

	public const string URL = "ui://kqd1t06of2581j";

	public static string Name = "UI_TeamBlueBtn";

	public static string GetURL()
	{
		return "ui://kqd1t06of2581j";
	}

	public static UI_TeamBlueBtn CreateInstance()
	{
		return (UI_TeamBlueBtn)(object)UIPackage.CreateObject("QuickBattle", "TeamBlueBtn");
	}

	public static UI_TeamBlueBtn CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_TeamBlueBtn).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://kqd1t06of2581j", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		((GComponent)this).ConstructFromXML(xml);
		button = ((GComponent)this).GetController("button");
		Type = ((GComponent)this).GetController("Type");
		Icon = (UI_EnemyIcon)(object)((GComponent)this).GetChild("Icon");
		Down = ((GComponent)this).GetTransition("Down");
	}
}
