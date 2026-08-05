using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGBattleRecord3;

public class UI_com_GvG3SmallRecordDialog : GComponent
{
	public GImage Background;

	public GList SmallRecords;

	public GTextField n9;

	public const string URL = "ui://b3fc6085stwv1y";

	public static string Name = "UI_com_GvG3SmallRecordDialog";

	public static string GetURL()
	{
		return "ui://b3fc6085stwv1y";
	}

	public static UI_com_GvG3SmallRecordDialog CreateInstance()
	{
		return (UI_com_GvG3SmallRecordDialog)(object)UIPackage.CreateObject("GvGBattleRecord3", "com_GvG3SmallRecordDialog");
	}

	public static UI_com_GvG3SmallRecordDialog CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_GvG3SmallRecordDialog).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://b3fc6085stwv1y", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		SmallRecords = (GList)((GComponent)this).GetChild("SmallRecords");
		n9 = (GTextField)((GComponent)this).GetChild("n9");
		string id = "ui://b3fc6085stwv1y".Replace("ui://", "") + "-" + ((GObject)n9).id;
		((GObject)n9).text = LanguagesManager.GetDesc(id);
	}
}
