using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.Playback;

public class UI_ReplayDetials : GComponent
{
	public Controller Result;

	public GGraph Mask;

	public GImage Back;

	public GGraph n40;

	public GGraph n39;

	public GButton exitBtn;

	public UI_SoldierFormation OurFormation0;

	public UI_SoldierFormation OurFormation1;

	public UI_SoldierFormation OurFormation2;

	public UI_SoldierFormation OurFormation3;

	public UI_SoldierFormation OurFormation4;

	public UI_SoldierFormation OurFormation5;

	public UI_SoldierFormation OurFormation6;

	public UI_SoldierFormation OurFormation7;

	public UI_SoldierFormation OurFormation8;

	public UI_InvitationIcon Icon;

	public GTextField userName;

	public GImage n25;

	public GImage n26;

	public GImage n27;

	public UI_PlayBtn playBtn;

	public GTextField Time;

	public GTextField LevelName;

	public GTextField CombatPower;

	public GImage n33;

	public GTextField n34;

	public GTextField Tip;

	public const string URL = "ui://9u6qpm6pgpwau";

	public static string Name = "UI_ReplayDetials";

	public static string GetURL()
	{
		return "ui://9u6qpm6pgpwau";
	}

	public static UI_ReplayDetials CreateInstance()
	{
		return (UI_ReplayDetials)(object)UIPackage.CreateObject("Playback", "ReplayDetials");
	}

	public static UI_ReplayDetials CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_ReplayDetials).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://9u6qpm6pgpwau", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		//IL_0170: Unknown result type (might be due to invalid IL or missing references)
		//IL_017a: Expected O, but got Unknown
		//IL_01c3: Unknown result type (might be due to invalid IL or missing references)
		//IL_01cd: Expected O, but got Unknown
		//IL_01d9: Unknown result type (might be due to invalid IL or missing references)
		//IL_01e3: Expected O, but got Unknown
		//IL_01ef: Unknown result type (might be due to invalid IL or missing references)
		//IL_01f9: Expected O, but got Unknown
		//IL_021b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0225: Expected O, but got Unknown
		//IL_026e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0278: Expected O, but got Unknown
		//IL_02c1: Unknown result type (might be due to invalid IL or missing references)
		//IL_02cb: Expected O, but got Unknown
		//IL_0314: Unknown result type (might be due to invalid IL or missing references)
		//IL_031e: Expected O, but got Unknown
		//IL_032a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0334: Expected O, but got Unknown
		//IL_037f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0389: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		Result = ((GComponent)this).GetController("Result");
		Mask = (GGraph)((GComponent)this).GetChild("Mask");
		Back = (GImage)((GComponent)this).GetChild("Back");
		n40 = (GGraph)((GComponent)this).GetChild("n40");
		n39 = (GGraph)((GComponent)this).GetChild("n39");
		exitBtn = (GButton)((GComponent)this).GetChild("exitBtn");
		OurFormation0 = (UI_SoldierFormation)(object)((GComponent)this).GetChild("OurFormation0");
		OurFormation1 = (UI_SoldierFormation)(object)((GComponent)this).GetChild("OurFormation1");
		OurFormation2 = (UI_SoldierFormation)(object)((GComponent)this).GetChild("OurFormation2");
		OurFormation3 = (UI_SoldierFormation)(object)((GComponent)this).GetChild("OurFormation3");
		OurFormation4 = (UI_SoldierFormation)(object)((GComponent)this).GetChild("OurFormation4");
		OurFormation5 = (UI_SoldierFormation)(object)((GComponent)this).GetChild("OurFormation5");
		OurFormation6 = (UI_SoldierFormation)(object)((GComponent)this).GetChild("OurFormation6");
		OurFormation7 = (UI_SoldierFormation)(object)((GComponent)this).GetChild("OurFormation7");
		OurFormation8 = (UI_SoldierFormation)(object)((GComponent)this).GetChild("OurFormation8");
		Icon = (UI_InvitationIcon)(object)((GComponent)this).GetChild("Icon");
		userName = (GTextField)((GComponent)this).GetChild("userName");
		string id = "ui://9u6qpm6pgpwau".Replace("ui://", "") + "-" + ((GObject)userName).id;
		((GObject)userName).text = LanguagesManager.GetDesc(id);
		n25 = (GImage)((GComponent)this).GetChild("n25");
		n26 = (GImage)((GComponent)this).GetChild("n26");
		n27 = (GImage)((GComponent)this).GetChild("n27");
		playBtn = (UI_PlayBtn)(object)((GComponent)this).GetChild("playBtn");
		Time = (GTextField)((GComponent)this).GetChild("Time");
		string id2 = "ui://9u6qpm6pgpwau".Replace("ui://", "") + "-" + ((GObject)Time).id;
		((GObject)Time).text = LanguagesManager.GetDesc(id2);
		LevelName = (GTextField)((GComponent)this).GetChild("LevelName");
		string id3 = "ui://9u6qpm6pgpwau".Replace("ui://", "") + "-" + ((GObject)LevelName).id;
		((GObject)LevelName).text = LanguagesManager.GetDesc(id3);
		CombatPower = (GTextField)((GComponent)this).GetChild("CombatPower");
		string id4 = "ui://9u6qpm6pgpwau".Replace("ui://", "") + "-" + ((GObject)CombatPower).id;
		((GObject)CombatPower).text = LanguagesManager.GetDesc(id4);
		n33 = (GImage)((GComponent)this).GetChild("n33");
		n34 = (GTextField)((GComponent)this).GetChild("n34");
		string id5 = "ui://9u6qpm6pgpwau".Replace("ui://", "") + "-" + ((GObject)n34).id;
		((GObject)n34).text = LanguagesManager.GetDesc(id5);
		Tip = (GTextField)((GComponent)this).GetChild("Tip");
		string id6 = "ui://9u6qpm6pgpwau".Replace("ui://", "") + "-" + ((GObject)Tip).id;
		((GObject)Tip).text = LanguagesManager.GetDesc(id6);
	}
}
