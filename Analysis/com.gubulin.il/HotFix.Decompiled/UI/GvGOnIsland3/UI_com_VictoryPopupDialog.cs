using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGOnIsland3;

public class UI_com_VictoryPopupDialog : GComponent
{
	public Controller Type;

	public GImage n1;

	public GImage n3;

	public GImage n13;

	public GImage n22;

	public GImage n21;

	public GImage n20;

	public GImage n19;

	public GImage n4;

	public GGroup n28;

	public GImage n24;

	public GImage n5;

	public GImage n25;

	public GTextField n26;

	public GImage n6;

	public GImage n14;

	public GImage n27;

	public GLoader Player;

	public GImage n17;

	public GImage n16;

	public GTextField namePlayer;

	public GButton ReplayBtn;

	public GButton ExitBtn;

	public Transition t0;

	public Transition t1;

	public const string URL = "ui://ebc4ciwrs0diq7g";

	public static string Name = "UI_com_VictoryPopupDialog";

	public static string GetURL()
	{
		return "ui://ebc4ciwrs0diq7g";
	}

	public static UI_com_VictoryPopupDialog CreateInstance()
	{
		return (UI_com_VictoryPopupDialog)(object)UIPackage.CreateObject("GvGOnIsland3", "com_VictoryPopupDialog");
	}

	public static UI_com_VictoryPopupDialog CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_VictoryPopupDialog).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://ebc4ciwrs0diq7g", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		//IL_0118: Unknown result type (might be due to invalid IL or missing references)
		//IL_0122: Expected O, but got Unknown
		//IL_012e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0138: Expected O, but got Unknown
		//IL_0181: Unknown result type (might be due to invalid IL or missing references)
		//IL_018b: Expected O, but got Unknown
		//IL_0197: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a1: Expected O, but got Unknown
		//IL_01ad: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b7: Expected O, but got Unknown
		//IL_01c3: Unknown result type (might be due to invalid IL or missing references)
		//IL_01cd: Expected O, but got Unknown
		//IL_01d9: Unknown result type (might be due to invalid IL or missing references)
		//IL_01e3: Expected O, but got Unknown
		//IL_01ef: Unknown result type (might be due to invalid IL or missing references)
		//IL_01f9: Expected O, but got Unknown
		//IL_0205: Unknown result type (might be due to invalid IL or missing references)
		//IL_020f: Expected O, but got Unknown
		//IL_021b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0225: Expected O, but got Unknown
		//IL_0231: Unknown result type (might be due to invalid IL or missing references)
		//IL_023b: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		Type = ((GComponent)this).GetController("Type");
		n1 = (GImage)((GComponent)this).GetChild("n1");
		n3 = (GImage)((GComponent)this).GetChild("n3");
		n13 = (GImage)((GComponent)this).GetChild("n13");
		n22 = (GImage)((GComponent)this).GetChild("n22");
		n21 = (GImage)((GComponent)this).GetChild("n21");
		n20 = (GImage)((GComponent)this).GetChild("n20");
		n19 = (GImage)((GComponent)this).GetChild("n19");
		n4 = (GImage)((GComponent)this).GetChild("n4");
		n28 = (GGroup)((GComponent)this).GetChild("n28");
		n24 = (GImage)((GComponent)this).GetChild("n24");
		n5 = (GImage)((GComponent)this).GetChild("n5");
		n25 = (GImage)((GComponent)this).GetChild("n25");
		n26 = (GTextField)((GComponent)this).GetChild("n26");
		string id = "ui://ebc4ciwrs0diq7g".Replace("ui://", "") + "-" + ((GObject)n26).id;
		((GObject)n26).text = LanguagesManager.GetDesc(id);
		n6 = (GImage)((GComponent)this).GetChild("n6");
		n14 = (GImage)((GComponent)this).GetChild("n14");
		n27 = (GImage)((GComponent)this).GetChild("n27");
		Player = (GLoader)((GComponent)this).GetChild("Player");
		n17 = (GImage)((GComponent)this).GetChild("n17");
		n16 = (GImage)((GComponent)this).GetChild("n16");
		namePlayer = (GTextField)((GComponent)this).GetChild("namePlayer");
		ReplayBtn = (GButton)((GComponent)this).GetChild("ReplayBtn");
		ExitBtn = (GButton)((GComponent)this).GetChild("ExitBtn");
		t0 = ((GComponent)this).GetTransition("t0");
		t1 = ((GComponent)this).GetTransition("t1");
	}
}
