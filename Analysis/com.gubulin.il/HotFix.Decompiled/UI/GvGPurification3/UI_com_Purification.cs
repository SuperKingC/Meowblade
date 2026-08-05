using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGPurification3;

public class UI_com_Purification : GComponent
{
	public Controller Status;

	public GImage n0;

	public GImage n15;

	public GList Pollutants;

	public GImage n21;

	public GImage n20;

	public GImage n16;

	public GImage n17;

	public GImage n18;

	public GImage n19;

	public GImage n1;

	public GTextField n2;

	public UI_com_PurifyTip Tip;

	public UI_btn_SelectAll SelectAll;

	public GLoader CostIcon;

	public GTextField n11;

	public GTextField Stock;

	public GTextField CostNumber;

	public UI_btn_Purify Purify;

	public UI_ExitAdvancedBtn Close;

	public Transition t0;

	public Transition t1;

	public const string URL = "ui://v7vqvgvm1146l6";

	public static string Name = "UI_com_Purification";

	public static string GetURL()
	{
		return "ui://v7vqvgvm1146l6";
	}

	public static UI_com_Purification CreateInstance()
	{
		return (UI_com_Purification)(object)UIPackage.CreateObject("GvGPurification3", "com_Purification");
	}

	public static UI_com_Purification CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_Purification).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://v7vqvgvm1146l6", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		//IL_007e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0088: Expected O, but got Unknown
		//IL_0094: Unknown result type (might be due to invalid IL or missing references)
		//IL_009e: Expected O, but got Unknown
		//IL_00aa: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b4: Expected O, but got Unknown
		//IL_00c0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ca: Expected O, but got Unknown
		//IL_00d6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e0: Expected O, but got Unknown
		//IL_00ec: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f6: Expected O, but got Unknown
		//IL_0102: Unknown result type (might be due to invalid IL or missing references)
		//IL_010c: Expected O, but got Unknown
		//IL_0181: Unknown result type (might be due to invalid IL or missing references)
		//IL_018b: Expected O, but got Unknown
		//IL_0197: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a1: Expected O, but got Unknown
		//IL_01ea: Unknown result type (might be due to invalid IL or missing references)
		//IL_01f4: Expected O, but got Unknown
		//IL_0200: Unknown result type (might be due to invalid IL or missing references)
		//IL_020a: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		Status = ((GComponent)this).GetController("Status");
		n0 = (GImage)((GComponent)this).GetChild("n0");
		n15 = (GImage)((GComponent)this).GetChild("n15");
		Pollutants = (GList)((GComponent)this).GetChild("Pollutants");
		n21 = (GImage)((GComponent)this).GetChild("n21");
		n20 = (GImage)((GComponent)this).GetChild("n20");
		n16 = (GImage)((GComponent)this).GetChild("n16");
		n17 = (GImage)((GComponent)this).GetChild("n17");
		n18 = (GImage)((GComponent)this).GetChild("n18");
		n19 = (GImage)((GComponent)this).GetChild("n19");
		n1 = (GImage)((GComponent)this).GetChild("n1");
		n2 = (GTextField)((GComponent)this).GetChild("n2");
		string id = "ui://v7vqvgvm1146l6".Replace("ui://", "") + "-" + ((GObject)n2).id;
		((GObject)n2).text = LanguagesManager.GetDesc(id);
		Tip = (UI_com_PurifyTip)(object)((GComponent)this).GetChild("Tip");
		SelectAll = (UI_btn_SelectAll)(object)((GComponent)this).GetChild("SelectAll");
		CostIcon = (GLoader)((GComponent)this).GetChild("CostIcon");
		n11 = (GTextField)((GComponent)this).GetChild("n11");
		string id2 = "ui://v7vqvgvm1146l6".Replace("ui://", "") + "-" + ((GObject)n11).id;
		((GObject)n11).text = LanguagesManager.GetDesc(id2);
		Stock = (GTextField)((GComponent)this).GetChild("Stock");
		CostNumber = (GTextField)((GComponent)this).GetChild("CostNumber");
		Purify = (UI_btn_Purify)(object)((GComponent)this).GetChild("Purify");
		Close = (UI_ExitAdvancedBtn)(object)((GComponent)this).GetChild("Close");
		t0 = ((GComponent)this).GetTransition("t0");
		t1 = ((GComponent)this).GetTransition("t1");
	}
}
