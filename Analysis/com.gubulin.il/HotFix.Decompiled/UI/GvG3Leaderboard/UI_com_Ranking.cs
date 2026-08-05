using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvG3Leaderboard;

public class UI_com_Ranking : GComponent
{
	public Controller Rank;

	public GImage n4;

	public GImage n5;

	public GImage n6;

	public const string URL = "ui://ylvfgf90ohdk6u";

	public static string Name = "UI_com_Ranking";

	public static string GetURL()
	{
		return "ui://ylvfgf90ohdk6u";
	}

	public static UI_com_Ranking CreateInstance()
	{
		return (UI_com_Ranking)(object)UIPackage.CreateObject("GvG3Leaderboard", "com_Ranking");
	}

	public static UI_com_Ranking CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_Ranking).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://ylvfgf90ohdk6u", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Expected O, but got Unknown
		//IL_003c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0046: Expected O, but got Unknown
		//IL_0052: Unknown result type (might be due to invalid IL or missing references)
		//IL_005c: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		Rank = ((GComponent)this).GetController("Rank");
		n4 = (GImage)((GComponent)this).GetChild("n4");
		n5 = (GImage)((GComponent)this).GetChild("n5");
		n6 = (GImage)((GComponent)this).GetChild("n6");
	}
}
