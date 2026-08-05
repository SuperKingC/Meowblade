using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGBrawlFight;

public class UI_com_ScoreRanking : GComponent
{
	public Controller RankType;

	public GLoader n1;

	public GTextField Ranking;

	public const string URL = "ui://hozu168rk7me4o";

	public static string Name = "UI_com_ScoreRanking";

	public static string GetURL()
	{
		return "ui://hozu168rk7me4o";
	}

	public static UI_com_ScoreRanking CreateInstance()
	{
		return (UI_com_ScoreRanking)(object)UIPackage.CreateObject("GvGBrawlFight", "com_ScoreRanking");
	}

	public static UI_com_ScoreRanking CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_ScoreRanking).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://hozu168rk7me4o", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Expected O, but got Unknown
		//IL_003c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0046: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		RankType = ((GComponent)this).GetController("RankType");
		n1 = (GLoader)((GComponent)this).GetChild("n1");
		Ranking = (GTextField)((GComponent)this).GetChild("Ranking");
	}
}
