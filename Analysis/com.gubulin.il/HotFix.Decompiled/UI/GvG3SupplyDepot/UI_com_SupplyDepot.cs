using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvG3SupplyDepot;

public class UI_com_SupplyDepot : GComponent
{
	public Controller PageController;

	public GImage Background;

	public UI_com_SupplyDepotBG n10;

	public UI_com_FoodSupply FoodStore;

	public UI_ExitAdvancedBtn Close;

	public UI_com_DailyReward DailyReward;

	public GImage n7;

	public UI_btn_DailySupplyBos DailySupplyBoxTab;

	public UI_btn_FoodSupply FoodSupplyTab;

	public GImage n6;

	public GTextField title;

	public const string URL = "ui://pobej4q7uado1";

	public static string Name = "UI_com_SupplyDepot";

	public static string GetURL()
	{
		return "ui://pobej4q7uado1";
	}

	public static UI_com_SupplyDepot CreateInstance()
	{
		return (UI_com_SupplyDepot)(object)UIPackage.CreateObject("GvG3SupplyDepot", "com_SupplyDepot");
	}

	public static UI_com_SupplyDepot CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_SupplyDepot).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://pobej4q7uado1", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Expected O, but got Unknown
		//IL_0094: Unknown result type (might be due to invalid IL or missing references)
		//IL_009e: Expected O, but got Unknown
		//IL_00d6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e0: Expected O, but got Unknown
		//IL_00ec: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f6: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		PageController = ((GComponent)this).GetController("PageController");
		Background = (GImage)((GComponent)this).GetChild("Background");
		n10 = (UI_com_SupplyDepotBG)(object)((GComponent)this).GetChild("n10");
		FoodStore = (UI_com_FoodSupply)(object)((GComponent)this).GetChild("FoodStore");
		Close = (UI_ExitAdvancedBtn)(object)((GComponent)this).GetChild("Close");
		DailyReward = (UI_com_DailyReward)(object)((GComponent)this).GetChild("DailyReward");
		n7 = (GImage)((GComponent)this).GetChild("n7");
		DailySupplyBoxTab = (UI_btn_DailySupplyBos)(object)((GComponent)this).GetChild("DailySupplyBoxTab");
		FoodSupplyTab = (UI_btn_FoodSupply)(object)((GComponent)this).GetChild("FoodSupplyTab");
		n6 = (GImage)((GComponent)this).GetChild("n6");
		title = (GTextField)((GComponent)this).GetChild("title");
		string id = "ui://pobej4q7uado1".Replace("ui://", "") + "-" + ((GObject)title).id;
		((GObject)title).text = LanguagesManager.GetDesc(id);
	}
}
