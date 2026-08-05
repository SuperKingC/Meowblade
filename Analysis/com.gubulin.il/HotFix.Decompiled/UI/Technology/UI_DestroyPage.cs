using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.Technology;

public class UI_DestroyPage : GComponent
{
	public Controller PageController;

	public GImage n30;

	public GImage n37;

	public GImage glow;

	public GGroup backgroundGroup;

	public UI_DestroyMasterBtn DestroyMasterBtn;

	public UI_DestroyDotBtn DestroyDotBtn12;

	public UI_DestroyDotBtn DestroyDotBtn9;

	public UI_DestroyDotBtn DestroyDotBtn11;

	public UI_DestroyDotBtn DestroyDotBtn8;

	public UI_DestroyDotBtn DestroyDotBtn10;

	public UI_DestroyDotBtn DestroyDotBtn7;

	public UI_DestroyDotBtn DestroyDotBtn6;

	public UI_DestroyDotBtn DestroyDotBtn5;

	public UI_DestroyDotBtn DestroyDotBtn4;

	public UI_DestroyDotBtn DestroyDotBtn3;

	public UI_DestroyDotBtn DestroyDotBtn2;

	public UI_DestroyDotBtn DestroyDotBtn1;

	public GGroup buttons;

	public GTextField tip;

	public GGraph FxWrapper;

	public Transition MasterUpgrade;

	public const string URL = "ui://7ca77a3fty9rl";

	public static string Name = "UI_DestroyPage";

	public static string GetURL()
	{
		return "ui://7ca77a3fty9rl";
	}

	public static UI_DestroyPage CreateInstance()
	{
		return (UI_DestroyPage)(object)UIPackage.CreateObject("Technology", "DestroyPage");
	}

	public static UI_DestroyPage CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_DestroyPage).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://7ca77a3fty9rl", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		n30 = (GImage)((GComponent)this).GetChild("n30");
		n37 = (GImage)((GComponent)this).GetChild("n37");
		glow = (GImage)((GComponent)this).GetChild("glow");
		backgroundGroup = (GGroup)((GComponent)this).GetChild("backgroundGroup");
		DestroyMasterBtn = (UI_DestroyMasterBtn)(object)((GComponent)this).GetChild("DestroyMasterBtn");
		DestroyDotBtn12 = (UI_DestroyDotBtn)(object)((GComponent)this).GetChild("DestroyDotBtn12");
		DestroyDotBtn9 = (UI_DestroyDotBtn)(object)((GComponent)this).GetChild("DestroyDotBtn9");
		DestroyDotBtn11 = (UI_DestroyDotBtn)(object)((GComponent)this).GetChild("DestroyDotBtn11");
		DestroyDotBtn8 = (UI_DestroyDotBtn)(object)((GComponent)this).GetChild("DestroyDotBtn8");
		DestroyDotBtn10 = (UI_DestroyDotBtn)(object)((GComponent)this).GetChild("DestroyDotBtn10");
		DestroyDotBtn7 = (UI_DestroyDotBtn)(object)((GComponent)this).GetChild("DestroyDotBtn7");
		DestroyDotBtn6 = (UI_DestroyDotBtn)(object)((GComponent)this).GetChild("DestroyDotBtn6");
		DestroyDotBtn5 = (UI_DestroyDotBtn)(object)((GComponent)this).GetChild("DestroyDotBtn5");
		DestroyDotBtn4 = (UI_DestroyDotBtn)(object)((GComponent)this).GetChild("DestroyDotBtn4");
		DestroyDotBtn3 = (UI_DestroyDotBtn)(object)((GComponent)this).GetChild("DestroyDotBtn3");
		DestroyDotBtn2 = (UI_DestroyDotBtn)(object)((GComponent)this).GetChild("DestroyDotBtn2");
		DestroyDotBtn1 = (UI_DestroyDotBtn)(object)((GComponent)this).GetChild("DestroyDotBtn1");
		buttons = (GGroup)((GComponent)this).GetChild("buttons");
		tip = (GTextField)((GComponent)this).GetChild("tip");
		string id = "ui://7ca77a3fty9rl".Replace("ui://", "") + "-" + ((GObject)tip).id;
		((GObject)tip).text = LanguagesManager.GetDesc(id);
		FxWrapper = (GGraph)((GComponent)this).GetChild("FxWrapper");
		MasterUpgrade = ((GComponent)this).GetTransition("MasterUpgrade");
	}
}
