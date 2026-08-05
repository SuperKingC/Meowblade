using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.WorldMap;

public class UI_newTotalEarnBtn : GButton
{
	public Controller button;

	public Controller Status;

	public GLoader icon;

	public GTextField totalNum;

	public GTextField increment;

	public GTextField tip1st;

	public GButton ExclamationMarkBtn;

	public GTextField output;

	public GTextField percent;

	public Transition GetEarnings;

	public const string URL = "ui://c9n2h0ksf258a3";

	public static string Name = "UI_newTotalEarnBtn";

	public static string GetURL()
	{
		return "ui://c9n2h0ksf258a3";
	}

	public static UI_newTotalEarnBtn CreateInstance()
	{
		return (UI_newTotalEarnBtn)(object)UIPackage.CreateObject("WorldMap", "newTotalEarnBtn");
	}

	public static UI_newTotalEarnBtn CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_newTotalEarnBtn).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://c9n2h0ksf258a3", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		//IL_00f3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fd: Expected O, but got Unknown
		//IL_0146: Unknown result type (might be due to invalid IL or missing references)
		//IL_0150: Expected O, but got Unknown
		//IL_015c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0166: Expected O, but got Unknown
		//IL_01af: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b9: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		button = ((GComponent)this).GetController("button");
		Status = ((GComponent)this).GetController("Status");
		icon = (GLoader)((GComponent)this).GetChild("icon");
		totalNum = (GTextField)((GComponent)this).GetChild("totalNum");
		string id = "ui://c9n2h0ksf258a3".Replace("ui://", "") + "-" + ((GObject)totalNum).id;
		((GObject)totalNum).text = LanguagesManager.GetDesc(id);
		increment = (GTextField)((GComponent)this).GetChild("increment");
		string id2 = "ui://c9n2h0ksf258a3".Replace("ui://", "") + "-" + ((GObject)increment).id;
		((GObject)increment).text = LanguagesManager.GetDesc(id2);
		tip1st = (GTextField)((GComponent)this).GetChild("tip1st");
		string id3 = "ui://c9n2h0ksf258a3".Replace("ui://", "") + "-" + ((GObject)tip1st).id;
		((GObject)tip1st).text = LanguagesManager.GetDesc(id3);
		ExclamationMarkBtn = (GButton)((GComponent)this).GetChild("ExclamationMarkBtn");
		output = (GTextField)((GComponent)this).GetChild("output");
		string id4 = "ui://c9n2h0ksf258a3".Replace("ui://", "") + "-" + ((GObject)output).id;
		((GObject)output).text = LanguagesManager.GetDesc(id4);
		percent = (GTextField)((GComponent)this).GetChild("percent");
		string id5 = "ui://c9n2h0ksf258a3".Replace("ui://", "") + "-" + ((GObject)percent).id;
		((GObject)percent).text = LanguagesManager.GetDesc(id5);
		GetEarnings = ((GComponent)this).GetTransition("GetEarnings");
	}
}
