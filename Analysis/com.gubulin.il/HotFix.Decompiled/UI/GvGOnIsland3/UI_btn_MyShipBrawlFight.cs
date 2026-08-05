using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGOnIsland3;

public class UI_btn_MyShipBrawlFight : GComponent
{
	public Controller State;

	public Controller scoreType;

	public GLoader n1;

	public GImage n27;

	public GLoader ShipSkin;

	public GTextField DamageText;

	public GLoader n23;

	public GGroup n24;

	public GTextField n25;

	public GTextField ShipName;

	public UI_btn_Strategy CurStrategyBtn;

	public Transition t0;

	public const string URL = "ui://ebc4ciwrj962q6i";

	public static string Name = "UI_btn_MyShipBrawlFight";

	public static string GetURL()
	{
		return "ui://ebc4ciwrj962q6i";
	}

	public static UI_btn_MyShipBrawlFight CreateInstance()
	{
		return (UI_btn_MyShipBrawlFight)(object)UIPackage.CreateObject("GvGOnIsland3", "btn_MyShipBrawlFight");
	}

	public static UI_btn_MyShipBrawlFight CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_btn_MyShipBrawlFight).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://ebc4ciwrj962q6i", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0037: Unknown result type (might be due to invalid IL or missing references)
		//IL_0041: Expected O, but got Unknown
		//IL_004d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0057: Expected O, but got Unknown
		//IL_0063: Unknown result type (might be due to invalid IL or missing references)
		//IL_006d: Expected O, but got Unknown
		//IL_0079: Unknown result type (might be due to invalid IL or missing references)
		//IL_0083: Expected O, but got Unknown
		//IL_008f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0099: Expected O, but got Unknown
		//IL_00a5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00af: Expected O, but got Unknown
		//IL_00bb: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c5: Expected O, but got Unknown
		//IL_010e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0118: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		State = ((GComponent)this).GetController("State");
		scoreType = ((GComponent)this).GetController("scoreType");
		n1 = (GLoader)((GComponent)this).GetChild("n1");
		n27 = (GImage)((GComponent)this).GetChild("n27");
		ShipSkin = (GLoader)((GComponent)this).GetChild("ShipSkin");
		DamageText = (GTextField)((GComponent)this).GetChild("DamageText");
		n23 = (GLoader)((GComponent)this).GetChild("n23");
		n24 = (GGroup)((GComponent)this).GetChild("n24");
		n25 = (GTextField)((GComponent)this).GetChild("n25");
		string id = "ui://ebc4ciwrj962q6i".Replace("ui://", "") + "-" + ((GObject)n25).id;
		((GObject)n25).text = LanguagesManager.GetDesc(id);
		ShipName = (GTextField)((GComponent)this).GetChild("ShipName");
		CurStrategyBtn = (UI_btn_Strategy)(object)((GComponent)this).GetChild("CurStrategyBtn");
		t0 = ((GComponent)this).GetTransition("t0");
	}
}
