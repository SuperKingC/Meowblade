using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvG3Leaderboard;

public class UI_com_info02 : GComponent
{
	public Controller HasLogs;

	public GImage n207;

	public GButton Close;

	public GImage n208;

	public GTextField n209;

	public GTextField Time;

	public GTextField n216;

	public GList BattleLog;

	public GTextField n213;

	public const string URL = "ui://ylvfgf90efgy6t";

	public static string Name = "UI_com_info02";

	public static string GetURL()
	{
		return "ui://ylvfgf90efgy6t";
	}

	public static UI_com_info02 CreateInstance()
	{
		return (UI_com_info02)(object)UIPackage.CreateObject("GvG3Leaderboard", "com_info02");
	}

	public static UI_com_info02 CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_info02).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://ylvfgf90efgy6t", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		//IL_0068: Unknown result type (might be due to invalid IL or missing references)
		//IL_0072: Expected O, but got Unknown
		//IL_00bb: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c5: Expected O, but got Unknown
		//IL_00d1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00db: Expected O, but got Unknown
		//IL_0124: Unknown result type (might be due to invalid IL or missing references)
		//IL_012e: Expected O, but got Unknown
		//IL_013a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0144: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		HasLogs = ((GComponent)this).GetController("HasLogs");
		n207 = (GImage)((GComponent)this).GetChild("n207");
		Close = (GButton)((GComponent)this).GetChild("Close");
		n208 = (GImage)((GComponent)this).GetChild("n208");
		n209 = (GTextField)((GComponent)this).GetChild("n209");
		string id = "ui://ylvfgf90efgy6t".Replace("ui://", "") + "-" + ((GObject)n209).id;
		((GObject)n209).text = LanguagesManager.GetDesc(id);
		Time = (GTextField)((GComponent)this).GetChild("Time");
		n216 = (GTextField)((GComponent)this).GetChild("n216");
		string id2 = "ui://ylvfgf90efgy6t".Replace("ui://", "") + "-" + ((GObject)n216).id;
		((GObject)n216).text = LanguagesManager.GetDesc(id2);
		BattleLog = (GList)((GComponent)this).GetChild("BattleLog");
		n213 = (GTextField)((GComponent)this).GetChild("n213");
		string id3 = "ui://ylvfgf90efgy6t".Replace("ui://", "") + "-" + ((GObject)n213).id;
		((GObject)n213).text = LanguagesManager.GetDesc(id3);
	}
}
