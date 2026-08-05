using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.GVGStore;

public class UI_com_Storeroom : GComponent
{
	public Controller State;

	public GMovieClip n19;

	public GImage n9;

	public GLoader Pack;

	public GMovieClip n21;

	public GImage n10;

	public GTextField PackNum;

	public GTextField n8;

	public GList Materials;

	public UI_btn_SelectStone selectStone;

	public GTextField n0;

	public GTextField ItemNum;

	public UI_dec_Stone01 n11;

	public UI_dec_Stone02 n12;

	public UI_dec_Stone03 n13;

	public GImage n14;

	public GImage n16;

	public GMovieClip n17;

	public GMovieClip n18;

	public Transition t0;

	public Transition t1;

	public Transition t2;

	public Transition t3;

	public Transition t4;

	public Transition changeStoneBox;

	public Transition t6;

	public const string URL = "ui://fvc33k3g7nboo";

	public static string Name = "UI_com_Storeroom";

	public static string GetURL()
	{
		return "ui://fvc33k3g7nboo";
	}

	public static UI_com_Storeroom CreateInstance()
	{
		return (UI_com_Storeroom)(object)UIPackage.CreateObject("GVGStore", "com_Storeroom");
	}

	public static UI_com_Storeroom CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_Storeroom).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://fvc33k3g7nboo", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		//IL_00fd: Unknown result type (might be due to invalid IL or missing references)
		//IL_0107: Expected O, but got Unknown
		//IL_0129: Unknown result type (might be due to invalid IL or missing references)
		//IL_0133: Expected O, but got Unknown
		//IL_017c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0186: Expected O, but got Unknown
		//IL_01d4: Unknown result type (might be due to invalid IL or missing references)
		//IL_01de: Expected O, but got Unknown
		//IL_01ea: Unknown result type (might be due to invalid IL or missing references)
		//IL_01f4: Expected O, but got Unknown
		//IL_0200: Unknown result type (might be due to invalid IL or missing references)
		//IL_020a: Expected O, but got Unknown
		//IL_0216: Unknown result type (might be due to invalid IL or missing references)
		//IL_0220: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		State = ((GComponent)this).GetController("State");
		n19 = (GMovieClip)((GComponent)this).GetChild("n19");
		n9 = (GImage)((GComponent)this).GetChild("n9");
		Pack = (GLoader)((GComponent)this).GetChild("Pack");
		n21 = (GMovieClip)((GComponent)this).GetChild("n21");
		n10 = (GImage)((GComponent)this).GetChild("n10");
		PackNum = (GTextField)((GComponent)this).GetChild("PackNum");
		n8 = (GTextField)((GComponent)this).GetChild("n8");
		string id = "ui://fvc33k3g7nboo".Replace("ui://", "") + "-" + ((GObject)n8).id;
		((GObject)n8).text = LanguagesManager.GetDesc(id);
		Materials = (GList)((GComponent)this).GetChild("Materials");
		selectStone = (UI_btn_SelectStone)(object)((GComponent)this).GetChild("selectStone");
		n0 = (GTextField)((GComponent)this).GetChild("n0");
		string id2 = "ui://fvc33k3g7nboo".Replace("ui://", "") + "-" + ((GObject)n0).id;
		((GObject)n0).text = LanguagesManager.GetDesc(id2);
		ItemNum = (GTextField)((GComponent)this).GetChild("ItemNum");
		n11 = (UI_dec_Stone01)(object)((GComponent)this).GetChild("n11");
		n12 = (UI_dec_Stone02)(object)((GComponent)this).GetChild("n12");
		n13 = (UI_dec_Stone03)(object)((GComponent)this).GetChild("n13");
		n14 = (GImage)((GComponent)this).GetChild("n14");
		n16 = (GImage)((GComponent)this).GetChild("n16");
		n17 = (GMovieClip)((GComponent)this).GetChild("n17");
		n18 = (GMovieClip)((GComponent)this).GetChild("n18");
		t0 = ((GComponent)this).GetTransition("t0");
		t1 = ((GComponent)this).GetTransition("t1");
		t2 = ((GComponent)this).GetTransition("t2");
		t3 = ((GComponent)this).GetTransition("t3");
		t4 = ((GComponent)this).GetTransition("t4");
		changeStoneBox = ((GComponent)this).GetTransition("changeStoneBox");
		t6 = ((GComponent)this).GetTransition("t6");
	}
}
