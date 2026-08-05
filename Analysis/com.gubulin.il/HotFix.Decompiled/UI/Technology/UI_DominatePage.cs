using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.Technology;

public class UI_DominatePage : GComponent
{
	public Controller PageController;

	public GImage backA;

	public GImage n29;

	public GImage glow;

	public GGroup back;

	public UI_DestroyMasterBtn DominateMasterBtn;

	public UI_DestroyDotBtn DominateDotBtn12;

	public UI_DestroyDotBtn DominateDotBtn11;

	public UI_DestroyDotBtn DominateDotBtn10;

	public UI_DestroyDotBtn DominateDotBtn9;

	public UI_DestroyDotBtn DominateDotBtn8;

	public UI_DestroyDotBtn DominateDotBtn7;

	public UI_DestroyDotBtn DominateDotBtn6;

	public UI_DestroyDotBtn DominateDotBtn5;

	public UI_DestroyDotBtn DominateDotBtn4;

	public UI_DestroyDotBtn DominateDotBtn3;

	public UI_DestroyDotBtn DominateDotBtn2;

	public UI_DestroyDotBtn DominateDotBtn1;

	public GGroup buttons;

	public GTextField tip;

	public GGraph FxWrapper;

	public Transition MasterUpgrade;

	public const string URL = "ui://7ca77a3fty9rm";

	public static string Name = "UI_DominatePage";

	public static string GetURL()
	{
		return "ui://7ca77a3fty9rm";
	}

	public static UI_DominatePage CreateInstance()
	{
		return (UI_DominatePage)(object)UIPackage.CreateObject("Technology", "DominatePage");
	}

	public static UI_DominatePage CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_DominatePage).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://7ca77a3fty9rm", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		//IL_019c: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a6: Expected O, but got Unknown
		//IL_01b2: Unknown result type (might be due to invalid IL or missing references)
		//IL_01bc: Expected O, but got Unknown
		//IL_0205: Unknown result type (might be due to invalid IL or missing references)
		//IL_020f: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		PageController = ((GComponent)this).GetController("PageController");
		backA = (GImage)((GComponent)this).GetChild("backA");
		n29 = (GImage)((GComponent)this).GetChild("n29");
		glow = (GImage)((GComponent)this).GetChild("glow");
		back = (GGroup)((GComponent)this).GetChild("back");
		DominateMasterBtn = (UI_DestroyMasterBtn)(object)((GComponent)this).GetChild("DominateMasterBtn");
		DominateDotBtn12 = (UI_DestroyDotBtn)(object)((GComponent)this).GetChild("DominateDotBtn12");
		DominateDotBtn11 = (UI_DestroyDotBtn)(object)((GComponent)this).GetChild("DominateDotBtn11");
		DominateDotBtn10 = (UI_DestroyDotBtn)(object)((GComponent)this).GetChild("DominateDotBtn10");
		DominateDotBtn9 = (UI_DestroyDotBtn)(object)((GComponent)this).GetChild("DominateDotBtn9");
		DominateDotBtn8 = (UI_DestroyDotBtn)(object)((GComponent)this).GetChild("DominateDotBtn8");
		DominateDotBtn7 = (UI_DestroyDotBtn)(object)((GComponent)this).GetChild("DominateDotBtn7");
		DominateDotBtn6 = (UI_DestroyDotBtn)(object)((GComponent)this).GetChild("DominateDotBtn6");
		DominateDotBtn5 = (UI_DestroyDotBtn)(object)((GComponent)this).GetChild("DominateDotBtn5");
		DominateDotBtn4 = (UI_DestroyDotBtn)(object)((GComponent)this).GetChild("DominateDotBtn4");
		DominateDotBtn3 = (UI_DestroyDotBtn)(object)((GComponent)this).GetChild("DominateDotBtn3");
		DominateDotBtn2 = (UI_DestroyDotBtn)(object)((GComponent)this).GetChild("DominateDotBtn2");
		DominateDotBtn1 = (UI_DestroyDotBtn)(object)((GComponent)this).GetChild("DominateDotBtn1");
		buttons = (GGroup)((GComponent)this).GetChild("buttons");
		tip = (GTextField)((GComponent)this).GetChild("tip");
		string id = "ui://7ca77a3fty9rm".Replace("ui://", "") + "-" + ((GObject)tip).id;
		((GObject)tip).text = LanguagesManager.GetDesc(id);
		FxWrapper = (GGraph)((GComponent)this).GetChild("FxWrapper");
		MasterUpgrade = ((GComponent)this).GetTransition("MasterUpgrade");
	}
}
