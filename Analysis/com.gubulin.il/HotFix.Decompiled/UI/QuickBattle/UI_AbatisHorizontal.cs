using FairyGUI;
using FairyGUI.Utils;

namespace UI.QuickBattle;

public class UI_AbatisHorizontal : GButton
{
	public Controller button;

	public Controller Type;

	public GList backList;

	public Transition Down;

	public const string URL = "ui://kqd1t06on4411q";

	public static string Name = "UI_AbatisHorizontal";

	public static string GetURL()
	{
		return "ui://kqd1t06on4411q";
	}

	public static UI_AbatisHorizontal CreateInstance()
	{
		return (UI_AbatisHorizontal)(object)UIPackage.CreateObject("QuickBattle", "AbatisHorizontal");
	}

	public static UI_AbatisHorizontal CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_AbatisHorizontal).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://kqd1t06on4411q", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0037: Unknown result type (might be due to invalid IL or missing references)
		//IL_0041: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		button = ((GComponent)this).GetController("button");
		Type = ((GComponent)this).GetController("Type");
		backList = (GList)((GComponent)this).GetChild("backList");
		Down = ((GComponent)this).GetTransition("Down");
	}
}
