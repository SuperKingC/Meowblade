using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGWorldMap3;

public class UI_com_CampShipsSlot : GComponent
{
	public Controller IsExpand;

	public Controller CampId;

	public Controller IsMyCamp;

	public Controller Fighting;

	public GList ShipList;

	public GImage TitleBack;

	public GLoader n1;

	public GImage CampTitle;

	public GTextField ShipCount;

	public GImage ProgressTitle;

	public GTextField Progress;

	public GImage n4;

	public GGraph ToggleBtn;

	public GImage n11;

	public GTextField MyCamp;

	public GGroup n12;

	public GImage n13;

	public GTextField ShipsNumber;

	public GImage n15;

	public Transition expand;

	public Transition reduce;

	public const string URL = "ui://4eq8fgd2bqhp1x";

	public static string Name = "UI_com_CampShipsSlot";

	public static string GetURL()
	{
		return "ui://4eq8fgd2bqhp1x";
	}

	public static UI_com_CampShipsSlot CreateInstance()
	{
		return (UI_com_CampShipsSlot)(object)UIPackage.CreateObject("GvGWorldMap3", "com_CampShipsSlot");
	}

	public static UI_com_CampShipsSlot CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_CampShipsSlot).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://4eq8fgd2bqhp1x", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0059: Unknown result type (might be due to invalid IL or missing references)
		//IL_0063: Expected O, but got Unknown
		//IL_006f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0079: Expected O, but got Unknown
		//IL_0085: Unknown result type (might be due to invalid IL or missing references)
		//IL_008f: Expected O, but got Unknown
		//IL_009b: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a5: Expected O, but got Unknown
		//IL_00b1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bb: Expected O, but got Unknown
		//IL_00c7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d1: Expected O, but got Unknown
		//IL_00dd: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e7: Expected O, but got Unknown
		//IL_00f3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fd: Expected O, but got Unknown
		//IL_0109: Unknown result type (might be due to invalid IL or missing references)
		//IL_0113: Expected O, but got Unknown
		//IL_011f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0129: Expected O, but got Unknown
		//IL_0135: Unknown result type (might be due to invalid IL or missing references)
		//IL_013f: Expected O, but got Unknown
		//IL_0188: Unknown result type (might be due to invalid IL or missing references)
		//IL_0192: Expected O, but got Unknown
		//IL_019e: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a8: Expected O, but got Unknown
		//IL_01b4: Unknown result type (might be due to invalid IL or missing references)
		//IL_01be: Expected O, but got Unknown
		//IL_01ca: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d4: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		IsExpand = ((GComponent)this).GetController("IsExpand");
		CampId = ((GComponent)this).GetController("CampId");
		IsMyCamp = ((GComponent)this).GetController("IsMyCamp");
		Fighting = ((GComponent)this).GetController("Fighting");
		ShipList = (GList)((GComponent)this).GetChild("ShipList");
		TitleBack = (GImage)((GComponent)this).GetChild("TitleBack");
		n1 = (GLoader)((GComponent)this).GetChild("n1");
		CampTitle = (GImage)((GComponent)this).GetChild("CampTitle");
		ShipCount = (GTextField)((GComponent)this).GetChild("ShipCount");
		ProgressTitle = (GImage)((GComponent)this).GetChild("ProgressTitle");
		Progress = (GTextField)((GComponent)this).GetChild("Progress");
		n4 = (GImage)((GComponent)this).GetChild("n4");
		ToggleBtn = (GGraph)((GComponent)this).GetChild("ToggleBtn");
		n11 = (GImage)((GComponent)this).GetChild("n11");
		MyCamp = (GTextField)((GComponent)this).GetChild("MyCamp");
		string id = "ui://4eq8fgd2bqhp1x".Replace("ui://", "") + "-" + ((GObject)MyCamp).id;
		((GObject)MyCamp).text = LanguagesManager.GetDesc(id);
		n12 = (GGroup)((GComponent)this).GetChild("n12");
		n13 = (GImage)((GComponent)this).GetChild("n13");
		ShipsNumber = (GTextField)((GComponent)this).GetChild("ShipsNumber");
		n15 = (GImage)((GComponent)this).GetChild("n15");
		expand = ((GComponent)this).GetTransition("expand");
		reduce = ((GComponent)this).GetTransition("reduce");
	}
}
