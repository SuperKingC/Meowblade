using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.GameActivity;

public class UI_btn_FreeGift : GButton
{
	public Controller button;

	public Controller State;

	public Controller WidthController;

	public GImage n11;

	public GImage n12;

	public GImage n17;

	public GImage n16;

	public GTextField n8;

	public GImage n15;

	public GLoader Icon;

	public GTextField Number;

	public GGraph fxPos;

	public GImage n9;

	public GImage n10;

	public GImage n13;

	public Transition t0;

	public Transition t1;

	public const string URL = "ui://29q48tv6jorqb0";

	public static string Name = "UI_btn_FreeGift";

	public static string GetURL()
	{
		return "ui://29q48tv6jorqb0";
	}

	public static UI_btn_FreeGift CreateInstance()
	{
		return (UI_btn_FreeGift)(object)UIPackage.CreateObject("GameActivity", "btn_FreeGift");
	}

	public static UI_btn_FreeGift CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_btn_FreeGift).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://29q48tv6jorqb0", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0048: Unknown result type (might be due to invalid IL or missing references)
		//IL_0052: Expected O, but got Unknown
		//IL_005e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0068: Expected O, but got Unknown
		//IL_0074: Unknown result type (might be due to invalid IL or missing references)
		//IL_007e: Expected O, but got Unknown
		//IL_008a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0094: Expected O, but got Unknown
		//IL_00a0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00aa: Expected O, but got Unknown
		//IL_00f3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fd: Expected O, but got Unknown
		//IL_0109: Unknown result type (might be due to invalid IL or missing references)
		//IL_0113: Expected O, but got Unknown
		//IL_011f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0129: Expected O, but got Unknown
		//IL_0135: Unknown result type (might be due to invalid IL or missing references)
		//IL_013f: Expected O, but got Unknown
		//IL_014b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0155: Expected O, but got Unknown
		//IL_0161: Unknown result type (might be due to invalid IL or missing references)
		//IL_016b: Expected O, but got Unknown
		//IL_0177: Unknown result type (might be due to invalid IL or missing references)
		//IL_0181: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		button = ((GComponent)this).GetController("button");
		State = ((GComponent)this).GetController("State");
		WidthController = ((GComponent)this).GetController("WidthController");
		n11 = (GImage)((GComponent)this).GetChild("n11");
		n12 = (GImage)((GComponent)this).GetChild("n12");
		n17 = (GImage)((GComponent)this).GetChild("n17");
		n16 = (GImage)((GComponent)this).GetChild("n16");
		n8 = (GTextField)((GComponent)this).GetChild("n8");
		string id = "ui://29q48tv6jorqb0".Replace("ui://", "") + "-" + ((GObject)n8).id;
		((GObject)n8).text = LanguagesManager.GetDesc(id);
		n15 = (GImage)((GComponent)this).GetChild("n15");
		Icon = (GLoader)((GComponent)this).GetChild("Icon");
		Number = (GTextField)((GComponent)this).GetChild("Number");
		fxPos = (GGraph)((GComponent)this).GetChild("fxPos");
		n9 = (GImage)((GComponent)this).GetChild("n9");
		n10 = (GImage)((GComponent)this).GetChild("n10");
		n13 = (GImage)((GComponent)this).GetChild("n13");
		t0 = ((GComponent)this).GetTransition("t0");
		t1 = ((GComponent)this).GetTransition("t1");
	}
}
