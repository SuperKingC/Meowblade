using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.LordOfDreams;

public class UI_ScoreHistoryBtn : GButton
{
	public Controller button;

	public GImage n3;

	public GTextField n4;

	public GTextField TotalScore;

	public GImage n6;

	public const string URL = "ui://0i520nzmh3e5o99";

	public static string Name = "UI_ScoreHistoryBtn";

	public static string GetURL()
	{
		return "ui://0i520nzmh3e5o99";
	}

	public static UI_ScoreHistoryBtn CreateInstance()
	{
		return (UI_ScoreHistoryBtn)(object)UIPackage.CreateObject("LordOfDreams", "ScoreHistoryBtn");
	}

	public static UI_ScoreHistoryBtn CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_ScoreHistoryBtn).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://0i520nzmh3e5o99", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Expected O, but got Unknown
		//IL_003c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0046: Expected O, but got Unknown
		//IL_008f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0099: Expected O, but got Unknown
		//IL_00a5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00af: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		button = ((GComponent)this).GetController("button");
		n3 = (GImage)((GComponent)this).GetChild("n3");
		n4 = (GTextField)((GComponent)this).GetChild("n4");
		string id = "ui://0i520nzmh3e5o99".Replace("ui://", "") + "-" + ((GObject)n4).id;
		((GObject)n4).text = LanguagesManager.GetDesc(id);
		TotalScore = (GTextField)((GComponent)this).GetChild("TotalScore");
		n6 = (GImage)((GComponent)this).GetChild("n6");
	}
}
