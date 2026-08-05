using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.IslandComeAgain;

public class UI_CampShipsSlot : GComponent
{
	public Controller IsExpand;

	public Controller CampId;

	public GList ShipList;

	public GImage TitleBack;

	public GLoader n1;

	public GTextField CampTitle;

	public GTextField ShipCount;

	public GImage n4;

	public GGraph ToggleBtn;

	public Transition expand;

	public Transition reduce;

	public const string URL = "ui://k2sprg26oc3d8u";

	public static string Name = "UI_CampShipsSlot";

	public static string GetURL()
	{
		return "ui://k2sprg26oc3d8u";
	}

	public static UI_CampShipsSlot CreateInstance()
	{
		return (UI_CampShipsSlot)(object)UIPackage.CreateObject("IslandComeAgain", "CampShipsSlot");
	}

	public static UI_CampShipsSlot CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_CampShipsSlot).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://k2sprg26oc3d8u", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0037: Unknown result type (might be due to invalid IL or missing references)
		//IL_0041: Expected O, but got Unknown
		//IL_004d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0057: Expected O, but got Unknown
		//IL_0063: Unknown result type (might be due to invalid IL or missing references)
		//IL_006d: Expected O, but got Unknown
		//IL_0079: Unknown result type (might be due to invalid IL or missing references)
		//IL_0083: Expected O, but got Unknown
		//IL_00cc: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d6: Expected O, but got Unknown
		//IL_00e2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ec: Expected O, but got Unknown
		//IL_00f8: Unknown result type (might be due to invalid IL or missing references)
		//IL_0102: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		IsExpand = ((GComponent)this).GetController("IsExpand");
		CampId = ((GComponent)this).GetController("CampId");
		ShipList = (GList)((GComponent)this).GetChild("ShipList");
		TitleBack = (GImage)((GComponent)this).GetChild("TitleBack");
		n1 = (GLoader)((GComponent)this).GetChild("n1");
		CampTitle = (GTextField)((GComponent)this).GetChild("CampTitle");
		string id = "ui://k2sprg26oc3d8u".Replace("ui://", "") + "-" + ((GObject)CampTitle).id;
		((GObject)CampTitle).text = LanguagesManager.GetDesc(id);
		ShipCount = (GTextField)((GComponent)this).GetChild("ShipCount");
		n4 = (GImage)((GComponent)this).GetChild("n4");
		ToggleBtn = (GGraph)((GComponent)this).GetChild("ToggleBtn");
		expand = ((GComponent)this).GetTransition("expand");
		reduce = ((GComponent)this).GetTransition("reduce");
	}
}
