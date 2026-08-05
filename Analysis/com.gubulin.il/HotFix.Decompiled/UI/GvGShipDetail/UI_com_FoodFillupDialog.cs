using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGShipDetail;

public class UI_com_FoodFillupDialog : GComponent
{
	public GImage n103;

	public GImage n118;

	public GImage n117;

	public GTextField n108;

	public GImage n112;

	public GImage n119;

	public GTextField n111;

	public UI_btn_GotoFlagShip GotoFlagShipBtn;

	public GTextField n109;

	public GImage line1;

	public GList ItemList;

	public UI_btn_Fillup Fillup;

	public UI_btn_FastFillup FastFillup;

	public GImage n116;

	public const string URL = "ui://u6x0b1gnsvf66p";

	public static string Name = "UI_com_FoodFillupDialog";

	public static string GetURL()
	{
		return "ui://u6x0b1gnsvf66p";
	}

	public static UI_com_FoodFillupDialog CreateInstance()
	{
		return (UI_com_FoodFillupDialog)(object)UIPackage.CreateObject("GvGShipDetail", "com_FoodFillupDialog");
	}

	public static UI_com_FoodFillupDialog CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_FoodFillupDialog).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://u6x0b1gnsvf66p", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		//IL_00aa: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b4: Expected O, but got Unknown
		//IL_00c0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ca: Expected O, but got Unknown
		//IL_00d6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e0: Expected O, but got Unknown
		//IL_013f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0149: Expected O, but got Unknown
		//IL_0192: Unknown result type (might be due to invalid IL or missing references)
		//IL_019c: Expected O, but got Unknown
		//IL_01a8: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b2: Expected O, but got Unknown
		//IL_01ea: Unknown result type (might be due to invalid IL or missing references)
		//IL_01f4: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		n103 = (GImage)((GComponent)this).GetChild("n103");
		n118 = (GImage)((GComponent)this).GetChild("n118");
		n117 = (GImage)((GComponent)this).GetChild("n117");
		n108 = (GTextField)((GComponent)this).GetChild("n108");
		string id = "ui://u6x0b1gnsvf66p".Replace("ui://", "") + "-" + ((GObject)n108).id;
		((GObject)n108).text = LanguagesManager.GetDesc(id);
		n112 = (GImage)((GComponent)this).GetChild("n112");
		n119 = (GImage)((GComponent)this).GetChild("n119");
		n111 = (GTextField)((GComponent)this).GetChild("n111");
		string id2 = "ui://u6x0b1gnsvf66p".Replace("ui://", "") + "-" + ((GObject)n111).id;
		((GObject)n111).text = LanguagesManager.GetDesc(id2);
		GotoFlagShipBtn = (UI_btn_GotoFlagShip)(object)((GComponent)this).GetChild("GotoFlagShipBtn");
		n109 = (GTextField)((GComponent)this).GetChild("n109");
		string id3 = "ui://u6x0b1gnsvf66p".Replace("ui://", "") + "-" + ((GObject)n109).id;
		((GObject)n109).text = LanguagesManager.GetDesc(id3);
		line1 = (GImage)((GComponent)this).GetChild("line1");
		ItemList = (GList)((GComponent)this).GetChild("ItemList");
		Fillup = (UI_btn_Fillup)(object)((GComponent)this).GetChild("Fillup");
		FastFillup = (UI_btn_FastFillup)(object)((GComponent)this).GetChild("FastFillup");
		n116 = (GImage)((GComponent)this).GetChild("n116");
	}
}
