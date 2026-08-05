using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.Technology;

public class UI_EnslavePage : GComponent
{
	public Controller PageController;

	public GImage backA;

	public GImage n54;

	public GImage glow;

	public GGroup back;

	public UI_DestroyMasterBtn EnslaveMaster;

	public UI_DestroyDotBtn EnslaveDotBtn12;

	public UI_DestroyDotBtn EnslaveDotBtn9;

	public UI_DestroyDotBtn EnslaveDotBtn8;

	public UI_DestroyDotBtn EnslaveDotBtn7;

	public UI_DestroyDotBtn EnslaveDotBtn6;

	public UI_DestroyDotBtn EnslaveDotBtn4;

	public UI_DestroyDotBtn EnslaveDotBtn11;

	public UI_DestroyDotBtn EnslaveDotBtn10;

	public UI_DestroyDotBtn EnslaveDotBtn5;

	public UI_DestroyDotBtn EnslaveDotBtn3;

	public UI_DestroyDotBtn EnslaveDotBtn2;

	public UI_DestroyDotBtn EnslaveDotBtn1;

	public GGroup buttons;

	public GTextField tip;

	public GGraph FxWrapper;

	public Transition MasterUpgrade;

	public const string URL = "ui://7ca77a3fty9rn";

	public static string Name = "UI_EnslavePage";

	public static string GetURL()
	{
		return "ui://7ca77a3fty9rn";
	}

	public static UI_EnslavePage CreateInstance()
	{
		return (UI_EnslavePage)(object)UIPackage.CreateObject("Technology", "EnslavePage");
	}

	public static UI_EnslavePage CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_EnslavePage).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://7ca77a3fty9rn", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		n54 = (GImage)((GComponent)this).GetChild("n54");
		glow = (GImage)((GComponent)this).GetChild("glow");
		back = (GGroup)((GComponent)this).GetChild("back");
		EnslaveMaster = (UI_DestroyMasterBtn)(object)((GComponent)this).GetChild("EnslaveMaster");
		EnslaveDotBtn12 = (UI_DestroyDotBtn)(object)((GComponent)this).GetChild("EnslaveDotBtn12");
		EnslaveDotBtn9 = (UI_DestroyDotBtn)(object)((GComponent)this).GetChild("EnslaveDotBtn9");
		EnslaveDotBtn8 = (UI_DestroyDotBtn)(object)((GComponent)this).GetChild("EnslaveDotBtn8");
		EnslaveDotBtn7 = (UI_DestroyDotBtn)(object)((GComponent)this).GetChild("EnslaveDotBtn7");
		EnslaveDotBtn6 = (UI_DestroyDotBtn)(object)((GComponent)this).GetChild("EnslaveDotBtn6");
		EnslaveDotBtn4 = (UI_DestroyDotBtn)(object)((GComponent)this).GetChild("EnslaveDotBtn4");
		EnslaveDotBtn11 = (UI_DestroyDotBtn)(object)((GComponent)this).GetChild("EnslaveDotBtn11");
		EnslaveDotBtn10 = (UI_DestroyDotBtn)(object)((GComponent)this).GetChild("EnslaveDotBtn10");
		EnslaveDotBtn5 = (UI_DestroyDotBtn)(object)((GComponent)this).GetChild("EnslaveDotBtn5");
		EnslaveDotBtn3 = (UI_DestroyDotBtn)(object)((GComponent)this).GetChild("EnslaveDotBtn3");
		EnslaveDotBtn2 = (UI_DestroyDotBtn)(object)((GComponent)this).GetChild("EnslaveDotBtn2");
		EnslaveDotBtn1 = (UI_DestroyDotBtn)(object)((GComponent)this).GetChild("EnslaveDotBtn1");
		buttons = (GGroup)((GComponent)this).GetChild("buttons");
		tip = (GTextField)((GComponent)this).GetChild("tip");
		string id = "ui://7ca77a3fty9rn".Replace("ui://", "") + "-" + ((GObject)tip).id;
		((GObject)tip).text = LanguagesManager.GetDesc(id);
		FxWrapper = (GGraph)((GComponent)this).GetChild("FxWrapper");
		MasterUpgrade = ((GComponent)this).GetTransition("MasterUpgrade");
	}
}
