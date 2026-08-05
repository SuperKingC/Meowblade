using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.WorldMap;

public class UI_earnBtn : GButton
{
	public Controller button;

	public Controller Status;

	public Controller Type;

	public Controller c1;

	public GGraph n13;

	public GImage n10;

	public GImage n11;

	public GImage n12;

	public GLoader icon;

	public GTextField output;

	public GTextField totalNum;

	public GTextField tip1st;

	public GProgressBar ProgressBarForUi;

	public GButton ExclamationMarkBtn;

	public GTextField increment;

	public Transition GetEarnings;

	public const string URL = "ui://c9n2h0ksee14h";

	public static string Name = "UI_earnBtn";

	public static string GetURL()
	{
		return "ui://c9n2h0ksee14h";
	}

	public static UI_earnBtn CreateInstance()
	{
		return (UI_earnBtn)(object)UIPackage.CreateObject("WorldMap", "earnBtn");
	}

	public static UI_earnBtn CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_earnBtn).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://c9n2h0ksee14h", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0059: Unknown result type (might be due to invalid IL or missing references)
		//IL_0063: Expected O, but got Unknown
		//IL_006f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0079: Expected O, but got Unknown
		//IL_0085: Unknown result type (might be due to invalid IL or missing references)
		//IL_008f: Expected O, but got Unknown
		//IL_009b: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a5: Expected O, but got Unknown
		//IL_00b1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bb: Expected O, but got Unknown
		//IL_00c7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d1: Expected O, but got Unknown
		//IL_011a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0124: Expected O, but got Unknown
		//IL_016d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0177: Expected O, but got Unknown
		//IL_01c0: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ca: Expected O, but got Unknown
		//IL_01d6: Unknown result type (might be due to invalid IL or missing references)
		//IL_01e0: Expected O, but got Unknown
		//IL_01ec: Unknown result type (might be due to invalid IL or missing references)
		//IL_01f6: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		button = ((GComponent)this).GetController("button");
		Status = ((GComponent)this).GetController("Status");
		Type = ((GComponent)this).GetController("Type");
		c1 = ((GComponent)this).GetController("c1");
		n13 = (GGraph)((GComponent)this).GetChild("n13");
		n10 = (GImage)((GComponent)this).GetChild("n10");
		n11 = (GImage)((GComponent)this).GetChild("n11");
		n12 = (GImage)((GComponent)this).GetChild("n12");
		icon = (GLoader)((GComponent)this).GetChild("icon");
		output = (GTextField)((GComponent)this).GetChild("output");
		string id = "ui://c9n2h0ksee14h".Replace("ui://", "") + "-" + ((GObject)output).id;
		((GObject)output).text = LanguagesManager.GetDesc(id);
		totalNum = (GTextField)((GComponent)this).GetChild("totalNum");
		string id2 = "ui://c9n2h0ksee14h".Replace("ui://", "") + "-" + ((GObject)totalNum).id;
		((GObject)totalNum).text = LanguagesManager.GetDesc(id2);
		tip1st = (GTextField)((GComponent)this).GetChild("tip1st");
		string id3 = "ui://c9n2h0ksee14h".Replace("ui://", "") + "-" + ((GObject)tip1st).id;
		((GObject)tip1st).text = LanguagesManager.GetDesc(id3);
		ProgressBarForUi = (GProgressBar)((GComponent)this).GetChild("ProgressBarForUi");
		ExclamationMarkBtn = (GButton)((GComponent)this).GetChild("ExclamationMarkBtn");
		increment = (GTextField)((GComponent)this).GetChild("increment");
		string id4 = "ui://c9n2h0ksee14h".Replace("ui://", "") + "-" + ((GObject)increment).id;
		((GObject)increment).text = LanguagesManager.GetDesc(id4);
		GetEarnings = ((GComponent)this).GetTransition("GetEarnings");
	}
}
