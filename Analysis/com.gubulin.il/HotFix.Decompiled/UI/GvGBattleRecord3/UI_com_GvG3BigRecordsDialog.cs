using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGBattleRecord3;

public class UI_com_GvG3BigRecordsDialog : GComponent
{
	public Controller Type;

	public GImage Background;

	public GList BigRecords;

	public GImage n15;

	public UI_com_BigRecordsFilter2 FilrerIsland;

	public UI_com_BigRecordsFilter FilrerShip;

	public GTextField n10;

	public GTextField n11;

	public GTextField n12;

	public GTextField n13;

	public GTextField IslandName;

	public const string URL = "ui://b3fc6085stwv1f";

	public static string Name = "UI_com_GvG3BigRecordsDialog";

	public static string GetURL()
	{
		return "ui://b3fc6085stwv1f";
	}

	public static UI_com_GvG3BigRecordsDialog CreateInstance()
	{
		return (UI_com_GvG3BigRecordsDialog)(object)UIPackage.CreateObject("GvGBattleRecord3", "com_GvG3BigRecordsDialog");
	}

	public static UI_com_GvG3BigRecordsDialog CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_GvG3BigRecordsDialog).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://b3fc6085stwv1f", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		//IL_0094: Unknown result type (might be due to invalid IL or missing references)
		//IL_009e: Expected O, but got Unknown
		//IL_00e7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f1: Expected O, but got Unknown
		//IL_013a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0144: Expected O, but got Unknown
		//IL_018d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0197: Expected O, but got Unknown
		//IL_01e0: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ea: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		Type = ((GComponent)this).GetController("Type");
		Background = (GImage)((GComponent)this).GetChild("Background");
		BigRecords = (GList)((GComponent)this).GetChild("BigRecords");
		n15 = (GImage)((GComponent)this).GetChild("n15");
		FilrerIsland = (UI_com_BigRecordsFilter2)(object)((GComponent)this).GetChild("FilrerIsland");
		FilrerShip = (UI_com_BigRecordsFilter)(object)((GComponent)this).GetChild("FilrerShip");
		n10 = (GTextField)((GComponent)this).GetChild("n10");
		string id = "ui://b3fc6085stwv1f".Replace("ui://", "") + "-" + ((GObject)n10).id;
		((GObject)n10).text = LanguagesManager.GetDesc(id);
		n11 = (GTextField)((GComponent)this).GetChild("n11");
		string id2 = "ui://b3fc6085stwv1f".Replace("ui://", "") + "-" + ((GObject)n11).id;
		((GObject)n11).text = LanguagesManager.GetDesc(id2);
		n12 = (GTextField)((GComponent)this).GetChild("n12");
		string id3 = "ui://b3fc6085stwv1f".Replace("ui://", "") + "-" + ((GObject)n12).id;
		((GObject)n12).text = LanguagesManager.GetDesc(id3);
		n13 = (GTextField)((GComponent)this).GetChild("n13");
		string id4 = "ui://b3fc6085stwv1f".Replace("ui://", "") + "-" + ((GObject)n13).id;
		((GObject)n13).text = LanguagesManager.GetDesc(id4);
		IslandName = (GTextField)((GComponent)this).GetChild("IslandName");
	}
}
