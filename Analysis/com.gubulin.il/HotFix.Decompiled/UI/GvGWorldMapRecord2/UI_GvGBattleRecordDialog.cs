using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGWorldMapRecord2;

public class UI_GvGBattleRecordDialog : GComponent
{
	public GImage Background;

	public GImage n6;

	public GList BattleLogList;

	public UI_LogFilter Filter;

	public const string URL = "ui://5xc1njmujjrn3a";

	public static string Name = "UI_GvGBattleRecordDialog";

	public static string GetURL()
	{
		return "ui://5xc1njmujjrn3a";
	}

	public static UI_GvGBattleRecordDialog CreateInstance()
	{
		return (UI_GvGBattleRecordDialog)(object)UIPackage.CreateObject("GvGWorldMapRecord2", "GvGBattleRecordDialog");
	}

	public static UI_GvGBattleRecordDialog CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_GvGBattleRecordDialog).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://5xc1njmujjrn3a", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		Filter = (UI_LogFilter)(object)((GComponent)this).GetChild("Filter");
	}
}
