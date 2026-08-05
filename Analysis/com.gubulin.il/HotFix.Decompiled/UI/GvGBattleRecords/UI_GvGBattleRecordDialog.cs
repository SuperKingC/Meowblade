using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGBattleRecords;

public class UI_GvGBattleRecordDialog : GComponent
{
	public GImage Background;

	public GImage n6;

	public GList BattleLogList;

	public GTextField n9;

	public const string URL = "ui://dxmilktydzls1y";

	public static string Name = "UI_GvGBattleRecordDialog";

	public static string GetURL()
	{
		return "ui://dxmilktydzls1y";
	}

	public static UI_GvGBattleRecordDialog CreateInstance()
	{
		return (UI_GvGBattleRecordDialog)(object)UIPackage.CreateObject("GvGBattleRecords", "GvGBattleRecordDialog");
	}

	public static UI_GvGBattleRecordDialog CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_GvGBattleRecordDialog).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://dxmilktydzls1y", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		//IL_0057: Unknown result type (might be due to invalid IL or missing references)
		//IL_0061: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		Background = (GImage)((GComponent)this).GetChild("Background");
		n6 = (GImage)((GComponent)this).GetChild("n6");
		BattleLogList = (GList)((GComponent)this).GetChild("BattleLogList");
		n9 = (GTextField)((GComponent)this).GetChild("n9");
		string id = "ui://dxmilktydzls1y".Replace("ui://", "") + "-" + ((GObject)n9).id;
		((GObject)n9).text = LanguagesManager.GetDesc(id);
	}
}
