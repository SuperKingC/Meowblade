using FairyGUI;
using FairyGUI.Utils;

namespace UI.LegendItemDungeon;

public class UI_LevelButton : GButton
{
	public Controller button;

	public Controller Type;

	public Controller GrayedController;

	public GImage n6;

	public GImage n7;

	public GMovieClip startWar;

	public const string URL = "ui://2eraz3j9i09e1d";

	public static string Name = "UI_LevelButton";

	public static string GetURL()
	{
		return "ui://2eraz3j9i09e1d";
	}

	public static UI_LevelButton CreateInstance()
	{
		return (UI_LevelButton)(object)UIPackage.CreateObject("LegendItemDungeon", "LevelButton");
	}

	public static UI_LevelButton CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_LevelButton).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://2eraz3j9i09e1d", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0048: Unknown result type (might be due to invalid IL or missing references)
		//IL_0052: Expected O, but got Unknown
		//IL_005e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0068: Expected O, but got Unknown
		//IL_0074: Unknown result type (might be due to invalid IL or missing references)
		//IL_007e: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		button = ((GComponent)this).GetController("button");
		Type = ((GComponent)this).GetController("Type");
		GrayedController = ((GComponent)this).GetController("GrayedController");
		n6 = (GImage)((GComponent)this).GetChild("n6");
		n7 = (GImage)((GComponent)this).GetChild("n7");
		startWar = (GMovieClip)((GComponent)this).GetChild("startWar");
	}
}
