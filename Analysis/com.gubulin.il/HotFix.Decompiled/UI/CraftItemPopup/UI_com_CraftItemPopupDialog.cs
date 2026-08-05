using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.CraftItemPopup;

public class UI_com_CraftItemPopupDialog : GComponent
{
	public GGraph n17;

	public GImage n19;

	public GImage n18;

	public UI_btn_CraftBtn CraftBtn;

	public UI_com_Content Content;

	public UI_com_ConsumptionRate ConsumptionRate;

	public GTextField n21;

	public GImage n20;

	public GTextField CompoundNum;

	public UI_btn_IncreaseButton IncreaseBtn;

	public UI_btn_ReduceButton ReduceBtn;

	public UI_btn_MaxValueBtn MaxValueBtn;

	public GGroup n16;

	public UI_com_Consumption Consumption;

	public const string URL = "ui://4pn38ozniuise";

	public static string Name = "UI_com_CraftItemPopupDialog";

	public static string GetURL()
	{
		return "ui://4pn38ozniuise";
	}

	public static UI_com_CraftItemPopupDialog CreateInstance()
	{
		return (UI_com_CraftItemPopupDialog)(object)UIPackage.CreateObject("CraftItemPopup", "com_CraftItemPopupDialog");
	}

	public static UI_com_CraftItemPopupDialog CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_CraftItemPopupDialog).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://4pn38ozniuise", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		//IL_0099: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a3: Expected O, but got Unknown
		//IL_00ec: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f6: Expected O, but got Unknown
		//IL_0102: Unknown result type (might be due to invalid IL or missing references)
		//IL_010c: Expected O, but got Unknown
		//IL_015a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0164: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		n17 = (GGraph)((GComponent)this).GetChild("n17");
		n19 = (GImage)((GComponent)this).GetChild("n19");
		n18 = (GImage)((GComponent)this).GetChild("n18");
		CraftBtn = (UI_btn_CraftBtn)(object)((GComponent)this).GetChild("CraftBtn");
		Content = (UI_com_Content)(object)((GComponent)this).GetChild("Content");
		ConsumptionRate = (UI_com_ConsumptionRate)(object)((GComponent)this).GetChild("ConsumptionRate");
		n21 = (GTextField)((GComponent)this).GetChild("n21");
		string id = "ui://4pn38ozniuise".Replace("ui://", "") + "-" + ((GObject)n21).id;
		((GObject)n21).text = LanguagesManager.GetDesc(id);
		n20 = (GImage)((GComponent)this).GetChild("n20");
		CompoundNum = (GTextField)((GComponent)this).GetChild("CompoundNum");
		IncreaseBtn = (UI_btn_IncreaseButton)(object)((GComponent)this).GetChild("IncreaseBtn");
		ReduceBtn = (UI_btn_ReduceButton)(object)((GComponent)this).GetChild("ReduceBtn");
		MaxValueBtn = (UI_btn_MaxValueBtn)(object)((GComponent)this).GetChild("MaxValueBtn");
		n16 = (GGroup)((GComponent)this).GetChild("n16");
		Consumption = (UI_com_Consumption)(object)((GComponent)this).GetChild("Consumption");
	}
}
