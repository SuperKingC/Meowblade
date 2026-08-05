using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvG3Leaderboard;

public class UI_com_Item2 : GComponent
{
	public Controller button;

	public Controller RankingTopThree;

	public GLoader Icon;

	public GTextField Num;

	public const string URL = "ui://ylvfgf90k1k96d";

	public static string Name = "UI_com_Item2";

	public static string GetURL()
	{
		return "ui://ylvfgf90k1k96d";
	}

	public static UI_com_Item2 CreateInstance()
	{
		return (UI_com_Item2)(object)UIPackage.CreateObject("GvG3Leaderboard", "com_Item2");
	}

	public static UI_com_Item2 CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_Item2).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://ylvfgf90k1k96d", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0037: Unknown result type (might be due to invalid IL or missing references)
		//IL_0041: Expected O, but got Unknown
		//IL_004d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0057: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		button = ((GComponent)this).GetController("button");
		RankingTopThree = ((GComponent)this).GetController("RankingTopThree");
		Icon = (GLoader)((GComponent)this).GetChild("Icon");
		Num = (GTextField)((GComponent)this).GetChild("Num");
	}
}
