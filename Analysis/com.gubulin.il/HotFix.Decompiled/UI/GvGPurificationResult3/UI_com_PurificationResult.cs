using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGPurificationResult3;

public class UI_com_PurificationResult : GComponent
{
	public Controller Status;

	public GImage n3;

	public GImage n5;

	public GImage n20;

	public GImage n18;

	public GImage n19;

	public GTextField n7;

	public GLoader CostIcon;

	public GTextField CostNum;

	public GList PurificationList;

	public GTextField n6;

	public GImage n10;

	public GImage n21;

	public GImage n22;

	public GList PollutantList;

	public GTextField n12;

	public GTextField n13;

	public GGroup n15;

	public UI_btn_ConfirmBtn Confirm;

	public GTextField n17;

	public GTextField n1;

	public Transition t0;

	public const string URL = "ui://l9ol6w5fsmdj1";

	public static string Name = "UI_com_PurificationResult";

	public static string GetURL()
	{
		return "ui://l9ol6w5fsmdj1";
	}

	public static UI_com_PurificationResult CreateInstance()
	{
		return (UI_com_PurificationResult)(object)UIPackage.CreateObject("GvGPurificationResult3", "com_PurificationResult");
	}

	public static UI_com_PurificationResult CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_PurificationResult).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://l9ol6w5fsmdj1", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		//IL_00e7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f1: Expected O, but got Unknown
		//IL_00fd: Unknown result type (might be due to invalid IL or missing references)
		//IL_0107: Expected O, but got Unknown
		//IL_0113: Unknown result type (might be due to invalid IL or missing references)
		//IL_011d: Expected O, but got Unknown
		//IL_0129: Unknown result type (might be due to invalid IL or missing references)
		//IL_0133: Expected O, but got Unknown
		//IL_017c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0186: Expected O, but got Unknown
		//IL_0192: Unknown result type (might be due to invalid IL or missing references)
		//IL_019c: Expected O, but got Unknown
		//IL_01a8: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b2: Expected O, but got Unknown
		//IL_01be: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c8: Expected O, but got Unknown
		//IL_01d4: Unknown result type (might be due to invalid IL or missing references)
		//IL_01de: Expected O, but got Unknown
		//IL_0227: Unknown result type (might be due to invalid IL or missing references)
		//IL_0231: Expected O, but got Unknown
		//IL_027a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0284: Expected O, but got Unknown
		//IL_02a6: Unknown result type (might be due to invalid IL or missing references)
		//IL_02b0: Expected O, but got Unknown
		//IL_02fb: Unknown result type (might be due to invalid IL or missing references)
		//IL_0305: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		Status = ((GComponent)this).GetController("Status");
		n3 = (GImage)((GComponent)this).GetChild("n3");
		n5 = (GImage)((GComponent)this).GetChild("n5");
		n20 = (GImage)((GComponent)this).GetChild("n20");
		n18 = (GImage)((GComponent)this).GetChild("n18");
		n19 = (GImage)((GComponent)this).GetChild("n19");
		n7 = (GTextField)((GComponent)this).GetChild("n7");
		string id = "ui://l9ol6w5fsmdj1".Replace("ui://", "") + "-" + ((GObject)n7).id;
		((GObject)n7).text = LanguagesManager.GetDesc(id);
		CostIcon = (GLoader)((GComponent)this).GetChild("CostIcon");
		CostNum = (GTextField)((GComponent)this).GetChild("CostNum");
		PurificationList = (GList)((GComponent)this).GetChild("PurificationList");
		n6 = (GTextField)((GComponent)this).GetChild("n6");
		string id2 = "ui://l9ol6w5fsmdj1".Replace("ui://", "") + "-" + ((GObject)n6).id;
		((GObject)n6).text = LanguagesManager.GetDesc(id2);
		n10 = (GImage)((GComponent)this).GetChild("n10");
		n21 = (GImage)((GComponent)this).GetChild("n21");
		n22 = (GImage)((GComponent)this).GetChild("n22");
		PollutantList = (GList)((GComponent)this).GetChild("PollutantList");
		n12 = (GTextField)((GComponent)this).GetChild("n12");
		string id3 = "ui://l9ol6w5fsmdj1".Replace("ui://", "") + "-" + ((GObject)n12).id;
		((GObject)n12).text = LanguagesManager.GetDesc(id3);
		n13 = (GTextField)((GComponent)this).GetChild("n13");
		string id4 = "ui://l9ol6w5fsmdj1".Replace("ui://", "") + "-" + ((GObject)n13).id;
		((GObject)n13).text = LanguagesManager.GetDesc(id4);
		n15 = (GGroup)((GComponent)this).GetChild("n15");
		Confirm = (UI_btn_ConfirmBtn)(object)((GComponent)this).GetChild("Confirm");
		n17 = (GTextField)((GComponent)this).GetChild("n17");
		string id5 = "ui://l9ol6w5fsmdj1".Replace("ui://", "") + "-" + ((GObject)n17).id;
		((GObject)n17).text = LanguagesManager.GetDesc(id5);
		n1 = (GTextField)((GComponent)this).GetChild("n1");
		string id6 = "ui://l9ol6w5fsmdj1".Replace("ui://", "") + "-" + ((GObject)n1).id;
		((GObject)n1).text = LanguagesManager.GetDesc(id6);
		t0 = ((GComponent)this).GetTransition("t0");
	}
}
