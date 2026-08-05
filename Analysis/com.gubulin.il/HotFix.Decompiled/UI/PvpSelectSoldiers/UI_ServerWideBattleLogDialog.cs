using FairyGUI;
using FairyGUI.Utils;

namespace UI.PvpSelectSoldiers;

public class UI_ServerWideBattleLogDialog : GComponent
{
	public GImage Background;

	public GImage n6;

	public UI_LogFilter Filter;

	public GList BattleLogList;

	public GList RoundTabList;

	public const string URL = "ui://82mo10n5m5cgjdv6";

	public static string Name = "UI_ServerWideBattleLogDialog";

	public static string GetURL()
	{
		return "ui://82mo10n5m5cgjdv6";
	}

	public static UI_ServerWideBattleLogDialog CreateInstance()
	{
		return (UI_ServerWideBattleLogDialog)(object)UIPackage.CreateObject("PvpSelectSoldiers", "ServerWideBattleLogDialog");
	}

	public static UI_ServerWideBattleLogDialog CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_ServerWideBattleLogDialog).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://82mo10n5m5cgjdv6", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0035: Expected O, but got Unknown
		//IL_0057: Unknown result type (might be due to invalid IL or missing references)
		//IL_0061: Expected O, but got Unknown
		//IL_006d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0077: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		Background = (GImage)((GComponent)this).GetChild("Background");
		n6 = (GImage)((GComponent)this).GetChild("n6");
		Filter = (UI_LogFilter)(object)((GComponent)this).GetChild("Filter");
		BattleLogList = (GList)((GComponent)this).GetChild("BattleLogList");
		RoundTabList = (GList)((GComponent)this).GetChild("RoundTabList");
	}
}
