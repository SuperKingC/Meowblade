using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.WorldMap;

public class UI_totalEarnBtn : GButton
{
	public Controller button;

	public Controller Status;

	public GLoader icon;

	public GTextField output;

	public GProgressBar ProgressBarForUi;

	public GTextField totalNum;

	public GTextField increment;

	public GTextField tip1st;

	public GButton ExclamationMarkBtn;

	public Transition GetEarnings;

	public const string URL = "ui://c9n2h0ksr46h32";

	public static string Name = "UI_totalEarnBtn";

	public static string GetURL()
	{
		return "ui://c9n2h0ksr46h32";
	}

	public static UI_totalEarnBtn CreateInstance()
	{
		return (UI_totalEarnBtn)(object)UIPackage.CreateObject("WorldMap", "totalEarnBtn");
	}

	public static UI_totalEarnBtn CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_totalEarnBtn).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://c9n2h0ksr46h32", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0037: Unknown result type (might be due to invalid IL or missing references)
		//IL_0041: Expected O, but got Unknown
		//IL_004d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0057: Expected O, but got Unknown
		//IL_00a0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00aa: Expected O, but got Unknown
		//IL_00b6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c0: Expected O, but got Unknown
		//IL_0109: Unknown result type (might be due to invalid IL or missing references)
		//IL_0113: Expected O, but got Unknown
		//IL_015c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0166: Expected O, but got Unknown
		//IL_01af: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b9: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		button = ((GComponent)this).GetController("button");
		Status = ((GComponent)this).GetController("Status");
		icon = (GLoader)((GComponent)this).GetChild("icon");
		output = (GTextField)((GComponent)this).GetChild("output");
		string id = "ui://c9n2h0ksr46h32".Replace("ui://", "") + "-" + ((GObject)output).id;
		((GObject)output).text = LanguagesManager.GetDesc(id);
		ProgressBarForUi = (GProgressBar)((GComponent)this).GetChild("ProgressBarForUi");
		totalNum = (GTextField)((GComponent)this).GetChild("totalNum");
		string id2 = "ui://c9n2h0ksr46h32".Replace("ui://", "") + "-" + ((GObject)totalNum).id;
		((GObject)totalNum).text = LanguagesManager.GetDesc(id2);
		increment = (GTextField)((GComponent)this).GetChild("increment");
		string id3 = "ui://c9n2h0ksr46h32".Replace("ui://", "") + "-" + ((GObject)increment).id;
		((GObject)increment).text = LanguagesManager.GetDesc(id3);
		tip1st = (GTextField)((GComponent)this).GetChild("tip1st");
		string id4 = "ui://c9n2h0ksr46h32".Replace("ui://", "") + "-" + ((GObject)tip1st).id;
		((GObject)tip1st).text = LanguagesManager.GetDesc(id4);
		ExclamationMarkBtn = (GButton)((GComponent)this).GetChild("ExclamationMarkBtn");
		GetEarnings = ((GComponent)this).GetTransition("GetEarnings");
	}
}
