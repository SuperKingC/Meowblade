using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGShipDetail;

public class UI_MineralItem : GButton
{
	public Controller IsMax;

	public Controller state;

	public GGraph n108;

	public GLoader frame;

	public GLoader icon;

	public GTextField title;

	public GTextField num;

	public GImage selectedNote;

	public GImage n119;

	public GImage max;

	public GTextField GvGStoreHouseStock;

	public GTextField n11;

	public const string URL = "ui://u6x0b1gnlyij2t";

	public static string Name = "UI_MineralItem";

	public int InitState;

	public bool IsSelected => state.selectedIndex != 0;

	public static string GetURL()
	{
		return "ui://u6x0b1gnlyij2t";
	}

	public static UI_MineralItem CreateInstance()
	{
		return (UI_MineralItem)(object)UIPackage.CreateObject("GvGShipDetail", "MineralItem");
	}

	public static UI_MineralItem CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_MineralItem).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://u6x0b1gnlyij2t", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		//IL_010e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0118: Expected O, but got Unknown
		//IL_0124: Unknown result type (might be due to invalid IL or missing references)
		//IL_012e: Expected O, but got Unknown
		//IL_013a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0144: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		IsMax = ((GComponent)this).GetController("IsMax");
		state = ((GComponent)this).GetController("state");
		n108 = (GGraph)((GComponent)this).GetChild("n108");
		frame = (GLoader)((GComponent)this).GetChild("frame");
		icon = (GLoader)((GComponent)this).GetChild("icon");
		title = (GTextField)((GComponent)this).GetChild("title");
		string id = "ui://u6x0b1gnlyij2t".Replace("ui://", "") + "-" + ((GObject)title).id;
		((GObject)title).text = LanguagesManager.GetDesc(id);
		num = (GTextField)((GComponent)this).GetChild("num");
		selectedNote = (GImage)((GComponent)this).GetChild("selectedNote");
		n119 = (GImage)((GComponent)this).GetChild("n119");
		max = (GImage)((GComponent)this).GetChild("max");
		GvGStoreHouseStock = (GTextField)((GComponent)this).GetChild("GvGStoreHouseStock");
		n11 = (GTextField)((GComponent)this).GetChild("n11");
		string id2 = "ui://u6x0b1gnlyij2t".Replace("ui://", "") + "-" + ((GObject)n11).id;
		((GObject)n11).text = LanguagesManager.GetDesc(id2);
	}

	public bool IsStateChange()
	{
		return state.selectedIndex != InitState;
	}
}
