using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.GameActivity;

public class UI_DailySignPanel : GComponent
{
	public Controller Status;

	public GGraph line;

	public GImage n37;

	public GButton ReceiveClick;

	public GTextField Tip1;

	public GTextField Time;

	public UI_DailySignBtn2 Day0;

	public UI_DailySignBtn1 Day3;

	public UI_DailySignBtn1 Day2;

	public UI_DailySignBtn1 Day4;

	public UI_DailySignBtn1 Day5;

	public UI_DailySignBtn1 Day6;

	public UI_DailySignBtn1 Day1;

	public GImage n34;

	public GImage n35;

	public GImage n36;

	public Transition Move;

	public const string URL = "ui://29q48tv6koyg34";

	public static string Name = "UI_DailySignPanel";

	public static string GetURL()
	{
		return "ui://29q48tv6koyg34";
	}

	public static UI_DailySignPanel CreateInstance()
	{
		return (UI_DailySignPanel)(object)UIPackage.CreateObject("GameActivity", "DailySignPanel");
	}

	public static UI_DailySignPanel CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_DailySignPanel).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://29q48tv6koyg34", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		//IL_00bb: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c5: Expected O, but got Unknown
		//IL_01a8: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b2: Expected O, but got Unknown
		//IL_01be: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c8: Expected O, but got Unknown
		//IL_01d4: Unknown result type (might be due to invalid IL or missing references)
		//IL_01de: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		Status = ((GComponent)this).GetController("Status");
		line = (GGraph)((GComponent)this).GetChild("line");
		n37 = (GImage)((GComponent)this).GetChild("n37");
		ReceiveClick = (GButton)((GComponent)this).GetChild("ReceiveClick");
		Tip1 = (GTextField)((GComponent)this).GetChild("Tip1");
		string id = "ui://29q48tv6koyg34".Replace("ui://", "") + "-" + ((GObject)Tip1).id;
		((GObject)Tip1).text = LanguagesManager.GetDesc(id);
		Time = (GTextField)((GComponent)this).GetChild("Time");
		string id2 = "ui://29q48tv6koyg34".Replace("ui://", "") + "-" + ((GObject)Time).id;
		((GObject)Time).text = LanguagesManager.GetDesc(id2);
		Day0 = (UI_DailySignBtn2)(object)((GComponent)this).GetChild("Day0");
		Day3 = (UI_DailySignBtn1)(object)((GComponent)this).GetChild("Day3");
		Day2 = (UI_DailySignBtn1)(object)((GComponent)this).GetChild("Day2");
		Day4 = (UI_DailySignBtn1)(object)((GComponent)this).GetChild("Day4");
		Day5 = (UI_DailySignBtn1)(object)((GComponent)this).GetChild("Day5");
		Day6 = (UI_DailySignBtn1)(object)((GComponent)this).GetChild("Day6");
		Day1 = (UI_DailySignBtn1)(object)((GComponent)this).GetChild("Day1");
		n34 = (GImage)((GComponent)this).GetChild("n34");
		n35 = (GImage)((GComponent)this).GetChild("n35");
		n36 = (GImage)((GComponent)this).GetChild("n36");
		Move = ((GComponent)this).GetTransition("Move");
	}
}
