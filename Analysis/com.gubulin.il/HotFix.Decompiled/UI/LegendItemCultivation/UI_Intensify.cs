using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.LegendItemCultivation;

public class UI_Intensify : GComponent
{
	public GList ArmsList;

	public UI_Loack Details;

	public GImage n17;

	public GGraph n18;

	public GTextField Title;

	public GTextField PrimeAttribute;

	public GGraph PrimeAttributeSfxBack;

	public UI_ExperienceProcessBar ExperienceProcessBar;

	public UI_no noBtn;

	public GButton Strengthen;

	public GList filters;

	public UI_yes yesBtn;

	public UI_LegendItemTitle NameCom;

	public GImage n38;

	public GGraph sfxBack;

	public GGraph n45;

	public GTextField nextAttribute;

	public GImage n40;

	public UI_ReforgeCostItemAndNum ConsumptionItem;

	public GList SelectList;

	public GTextField n42;

	public GComponent Stars;

	public const string URL = "ui://b9wlonaqlud8o";

	public static string Name = "UI_Intensify";

	public void SetButtonTitle()
	{
		((GObject)Details.title).text = LanguagesManager.GetDesc("LegendItemCultivation-Intensify-Details-title");
	}

	public static string GetURL()
	{
		return "ui://b9wlonaqlud8o";
	}

	public static UI_Intensify CreateInstance()
	{
		return (UI_Intensify)(object)UIPackage.CreateObject("LegendItemCultivation", "Intensify");
	}

	public static UI_Intensify CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_Intensify).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://b9wlonaqlud8o", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		//IL_0041: Unknown result type (might be due to invalid IL or missing references)
		//IL_004b: Expected O, but got Unknown
		//IL_0057: Unknown result type (might be due to invalid IL or missing references)
		//IL_0061: Expected O, but got Unknown
		//IL_006d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0077: Expected O, but got Unknown
		//IL_00c0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ca: Expected O, but got Unknown
		//IL_00d6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e0: Expected O, but got Unknown
		//IL_0118: Unknown result type (might be due to invalid IL or missing references)
		//IL_0122: Expected O, but got Unknown
		//IL_012e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0138: Expected O, but got Unknown
		//IL_0170: Unknown result type (might be due to invalid IL or missing references)
		//IL_017a: Expected O, but got Unknown
		//IL_0186: Unknown result type (might be due to invalid IL or missing references)
		//IL_0190: Expected O, but got Unknown
		//IL_019c: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a6: Expected O, but got Unknown
		//IL_01b2: Unknown result type (might be due to invalid IL or missing references)
		//IL_01bc: Expected O, but got Unknown
		//IL_01c8: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d2: Expected O, but got Unknown
		//IL_01f4: Unknown result type (might be due to invalid IL or missing references)
		//IL_01fe: Expected O, but got Unknown
		//IL_020a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0214: Expected O, but got Unknown
		//IL_025d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0267: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		ArmsList = (GList)((GComponent)this).GetChild("ArmsList");
		Details = (UI_Loack)(object)((GComponent)this).GetChild("Details");
		n17 = (GImage)((GComponent)this).GetChild("n17");
		n18 = (GGraph)((GComponent)this).GetChild("n18");
		Title = (GTextField)((GComponent)this).GetChild("Title");
		string id = "ui://b9wlonaqlud8o".Replace("ui://", "") + "-" + ((GObject)Title).id;
		((GObject)Title).text = LanguagesManager.GetDesc(id);
		PrimeAttribute = (GTextField)((GComponent)this).GetChild("PrimeAttribute");
		PrimeAttributeSfxBack = (GGraph)((GComponent)this).GetChild("PrimeAttributeSfxBack");
		ExperienceProcessBar = (UI_ExperienceProcessBar)(object)((GComponent)this).GetChild("ExperienceProcessBar");
		noBtn = (UI_no)(object)((GComponent)this).GetChild("noBtn");
		Strengthen = (GButton)((GComponent)this).GetChild("Strengthen");
		filters = (GList)((GComponent)this).GetChild("filters");
		yesBtn = (UI_yes)(object)((GComponent)this).GetChild("yesBtn");
		NameCom = (UI_LegendItemTitle)(object)((GComponent)this).GetChild("NameCom");
		n38 = (GImage)((GComponent)this).GetChild("n38");
		sfxBack = (GGraph)((GComponent)this).GetChild("sfxBack");
		n45 = (GGraph)((GComponent)this).GetChild("n45");
		nextAttribute = (GTextField)((GComponent)this).GetChild("nextAttribute");
		n40 = (GImage)((GComponent)this).GetChild("n40");
		ConsumptionItem = (UI_ReforgeCostItemAndNum)(object)((GComponent)this).GetChild("ConsumptionItem");
		SelectList = (GList)((GComponent)this).GetChild("SelectList");
		n42 = (GTextField)((GComponent)this).GetChild("n42");
		string id2 = "ui://b9wlonaqlud8o".Replace("ui://", "") + "-" + ((GObject)n42).id;
		((GObject)n42).text = LanguagesManager.GetDesc(id2);
		Stars = (GComponent)((GComponent)this).GetChild("Stars");
	}
}
