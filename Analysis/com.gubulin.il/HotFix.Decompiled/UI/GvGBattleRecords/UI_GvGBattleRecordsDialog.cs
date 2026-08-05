using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGBattleRecords;

public class UI_GvGBattleRecordsDialog : GComponent
{
	public GImage Background;

	public GImage n6;

	public GList BattleLogList;

	public const string URL = "ui://dxmilktydzls1x";

	public static string Name = "UI_GvGBattleRecordsDialog";

	public static string GetURL()
	{
		return "ui://dxmilktydzls1x";
	}

	public static UI_GvGBattleRecordsDialog CreateInstance()
	{
		return (UI_GvGBattleRecordsDialog)(object)UIPackage.CreateObject("GvGBattleRecords", "GvGBattleRecordsDialog");
	}

	public static UI_GvGBattleRecordsDialog CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_GvGBattleRecordsDialog).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://dxmilktydzls1x", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0035: Expected O, but got Unknown
		//IL_0041: Unknown result type (might be due to invalid IL or missing references)
		//IL_004b: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		Background = (GImage)((GComponent)this).GetChild("Background");
		n6 = (GImage)((GComponent)this).GetChild("n6");
		BattleLogList = (GList)((GComponent)this).GetChild("BattleLogList");
	}
}
