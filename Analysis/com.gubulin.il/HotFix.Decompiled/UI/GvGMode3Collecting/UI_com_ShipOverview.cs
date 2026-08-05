using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGMode3Collecting;

public class UI_com_ShipOverview : GComponent
{
	public Controller Type;

	public GImage n0;

	public GGroup NoShip;

	public GImage n1;

	public GImage n4;

	public GLoader SpineLoader;

	public GGraph CollectingPopLoader;

	public GTextField ShipName;

	public GImage listback;

	public GImage n18;

	public GList CollectingItemList;

	public GImage n7;

	public GImage n6;

	public GTextField islandName;

	public UI_com_ShipCollectingInformation Compliance;

	public UI_com_ShipCollectingInformation WorkerNum;

	public GTextField n19;

	public GGroup ShipStatus;

	public const string URL = "ui://n2y4xuvarxuqb";

	public static string Name = "UI_com_ShipOverview";

	public static string GetURL()
	{
		return "ui://n2y4xuvarxuqb";
	}

	public static UI_com_ShipOverview CreateInstance()
	{
		return (UI_com_ShipOverview)(object)UIPackage.CreateObject("GvGMode3Collecting", "com_ShipOverview");
	}

	public static UI_com_ShipOverview CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_ShipOverview).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://n2y4xuvarxuqb", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		//IL_007e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0088: Expected O, but got Unknown
		//IL_0094: Unknown result type (might be due to invalid IL or missing references)
		//IL_009e: Expected O, but got Unknown
		//IL_00aa: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b4: Expected O, but got Unknown
		//IL_00c0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ca: Expected O, but got Unknown
		//IL_00d6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e0: Expected O, but got Unknown
		//IL_00ec: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f6: Expected O, but got Unknown
		//IL_0102: Unknown result type (might be due to invalid IL or missing references)
		//IL_010c: Expected O, but got Unknown
		//IL_0118: Unknown result type (might be due to invalid IL or missing references)
		//IL_0122: Expected O, but got Unknown
		//IL_012e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0138: Expected O, but got Unknown
		//IL_0170: Unknown result type (might be due to invalid IL or missing references)
		//IL_017a: Expected O, but got Unknown
		//IL_01c3: Unknown result type (might be due to invalid IL or missing references)
		//IL_01cd: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		Type = ((GComponent)this).GetController("Type");
		n0 = (GImage)((GComponent)this).GetChild("n0");
		NoShip = (GGroup)((GComponent)this).GetChild("NoShip");
		n1 = (GImage)((GComponent)this).GetChild("n1");
		n4 = (GImage)((GComponent)this).GetChild("n4");
		SpineLoader = (GLoader)((GComponent)this).GetChild("SpineLoader");
		CollectingPopLoader = (GGraph)((GComponent)this).GetChild("CollectingPopLoader");
		ShipName = (GTextField)((GComponent)this).GetChild("ShipName");
		listback = (GImage)((GComponent)this).GetChild("listback");
		n18 = (GImage)((GComponent)this).GetChild("n18");
		CollectingItemList = (GList)((GComponent)this).GetChild("CollectingItemList");
		n7 = (GImage)((GComponent)this).GetChild("n7");
		n6 = (GImage)((GComponent)this).GetChild("n6");
		islandName = (GTextField)((GComponent)this).GetChild("islandName");
		Compliance = (UI_com_ShipCollectingInformation)(object)((GComponent)this).GetChild("Compliance");
		WorkerNum = (UI_com_ShipCollectingInformation)(object)((GComponent)this).GetChild("WorkerNum");
		n19 = (GTextField)((GComponent)this).GetChild("n19");
		string id = "ui://n2y4xuvarxuqb".Replace("ui://", "") + "-" + ((GObject)n19).id;
		((GObject)n19).text = LanguagesManager.GetDesc(id);
		ShipStatus = (GGroup)((GComponent)this).GetChild("ShipStatus");
	}
}
