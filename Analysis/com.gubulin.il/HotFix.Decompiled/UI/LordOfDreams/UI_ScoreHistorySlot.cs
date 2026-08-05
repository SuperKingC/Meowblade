using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.LordOfDreams;

public class UI_ScoreHistorySlot : GComponent
{
	public GImage n0;

	public GTextField Date;

	public GTextField Score;

	public const string URL = "ui://0i520nzmh3e5o9a";

	public static string Name = "UI_ScoreHistorySlot";

	public static string GetURL()
	{
		return "ui://0i520nzmh3e5o9a";
	}

	public static UI_ScoreHistorySlot CreateInstance()
	{
		return (UI_ScoreHistorySlot)(object)UIPackage.CreateObject("LordOfDreams", "ScoreHistorySlot");
	}

	public static UI_ScoreHistorySlot CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_ScoreHistorySlot).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://0i520nzmh3e5o9a", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0035: Expected O, but got Unknown
		//IL_007e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0088: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		n0 = (GImage)((GComponent)this).GetChild("n0");
		Date = (GTextField)((GComponent)this).GetChild("Date");
		string id = "ui://0i520nzmh3e5o9a".Replace("ui://", "") + "-" + ((GObject)Date).id;
		((GObject)Date).text = LanguagesManager.GetDesc(id);
		Score = (GTextField)((GComponent)this).GetChild("Score");
		string id2 = "ui://0i520nzmh3e5o9a".Replace("ui://", "") + "-" + ((GObject)Score).id;
		((GObject)Score).text = LanguagesManager.GetDesc(id2);
	}
}
