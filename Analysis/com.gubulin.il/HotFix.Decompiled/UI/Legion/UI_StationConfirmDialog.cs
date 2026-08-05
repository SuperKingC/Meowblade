using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.Legion;

public class UI_StationConfirmDialog : GComponent
{
	public Controller PageController;

	public GImage back;

	public GGraph n15;

	public GButton soldierIcon;

	public UI_activate stationBtn;

	public UI_activate replaceAssembledBtn;

	public UI_activate replaceStationedBtn;

	public GButton cancelBtn;

	public GTextField tip1st;

	public GRichTextField tip2nd;

	public GLoader itemIcon;

	public GRichTextField tip3rd;

	public GTextField n11;

	public GList earningsDetailList;

	public GTextField n13;

	public GTextField totalModifier;

	public const string URL = "ui://lrhs6zw7r46h44g";

	public static string Name = "UI_StationConfirmDialog";

	public void SetButtonTitle()
	{
		((GObject)stationBtn.title).text = LanguagesManager.GetDesc("Legion-StationConfirmDialog-stationBtn-title");
		((GObject)replaceAssembledBtn.title).text = LanguagesManager.GetDesc("Legion-StationConfirmDialog-replaceAssembledBtn-title");
		((GObject)replaceStationedBtn.title).text = LanguagesManager.GetDesc("Legion-StationConfirmDialog-replaceStationedBtn-title");
	}

	public static string GetURL()
	{
		return "ui://lrhs6zw7r46h44g";
	}

	public static UI_StationConfirmDialog CreateInstance()
	{
		return (UI_StationConfirmDialog)(object)UIPackage.CreateObject("Legion", "StationConfirmDialog");
	}

	public static UI_StationConfirmDialog CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_StationConfirmDialog).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://lrhs6zw7r46h44g", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		//IL_00aa: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b4: Expected O, but got Unknown
		//IL_00c0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ca: Expected O, but got Unknown
		//IL_0113: Unknown result type (might be due to invalid IL or missing references)
		//IL_011d: Expected O, but got Unknown
		//IL_0166: Unknown result type (might be due to invalid IL or missing references)
		//IL_0170: Expected O, but got Unknown
		//IL_017c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0186: Expected O, but got Unknown
		//IL_01cf: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d9: Expected O, but got Unknown
		//IL_01e5: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ef: Expected O, but got Unknown
		//IL_01fb: Unknown result type (might be due to invalid IL or missing references)
		//IL_0205: Expected O, but got Unknown
		//IL_024e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0258: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		PageController = ((GComponent)this).GetController("PageController");
		back = (GImage)((GComponent)this).GetChild("back");
		n15 = (GGraph)((GComponent)this).GetChild("n15");
		soldierIcon = (GButton)((GComponent)this).GetChild("soldierIcon");
		stationBtn = (UI_activate)(object)((GComponent)this).GetChild("stationBtn");
		replaceAssembledBtn = (UI_activate)(object)((GComponent)this).GetChild("replaceAssembledBtn");
		replaceStationedBtn = (UI_activate)(object)((GComponent)this).GetChild("replaceStationedBtn");
		cancelBtn = (GButton)((GComponent)this).GetChild("cancelBtn");
		tip1st = (GTextField)((GComponent)this).GetChild("tip1st");
		string id = "ui://lrhs6zw7r46h44g".Replace("ui://", "") + "-" + ((GObject)tip1st).id;
		((GObject)tip1st).text = LanguagesManager.GetDesc(id);
		tip2nd = (GRichTextField)((GComponent)this).GetChild("tip2nd");
		string id2 = "ui://lrhs6zw7r46h44g".Replace("ui://", "") + "-" + ((GObject)tip2nd).id;
		((GObject)tip2nd).text = LanguagesManager.GetDesc(id2);
		itemIcon = (GLoader)((GComponent)this).GetChild("itemIcon");
		tip3rd = (GRichTextField)((GComponent)this).GetChild("tip3rd");
		string id3 = "ui://lrhs6zw7r46h44g".Replace("ui://", "") + "-" + ((GObject)tip3rd).id;
		((GObject)tip3rd).text = LanguagesManager.GetDesc(id3);
		n11 = (GTextField)((GComponent)this).GetChild("n11");
		earningsDetailList = (GList)((GComponent)this).GetChild("earningsDetailList");
		n13 = (GTextField)((GComponent)this).GetChild("n13");
		string id4 = "ui://lrhs6zw7r46h44g".Replace("ui://", "") + "-" + ((GObject)n13).id;
		((GObject)n13).text = LanguagesManager.GetDesc(id4);
		totalModifier = (GTextField)((GComponent)this).GetChild("totalModifier");
		string id5 = "ui://lrhs6zw7r46h44g".Replace("ui://", "") + "-" + ((GObject)totalModifier).id;
		((GObject)totalModifier).text = LanguagesManager.GetDesc(id5);
	}
}
