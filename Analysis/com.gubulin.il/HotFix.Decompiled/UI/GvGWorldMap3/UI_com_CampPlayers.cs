using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGWorldMap3;

public class UI_com_CampPlayers : GComponent
{
	public Controller Camp;

	public GImage n0;

	public GImage n29;

	public GLoader n1;

	public GTextField CampName4;

	public GTextField CampName3;

	public GTextField CampName2;

	public GTextField CampName;

	public GTextField n3;

	public GTextField n10;

	public GList Players;

	public GImage n21;

	public GTextField n4;

	public GTextField PlayerNumber;

	public GLoader n24;

	public GGroup n13;

	public GImage n22;

	public GLoader n25;

	public GTextField n6;

	public GTextField ShipsNumber;

	public GGroup n14;

	public GImage n23;

	public GTextField n8;

	public GTextField IslandNumber;

	public GLoader n26;

	public GImage n19;

	public GImage n20;

	public const string URL = "ui://4eq8fgd2qf7c7v";

	public static string Name = "UI_com_CampPlayers";

	public static string GetURL()
	{
		return "ui://4eq8fgd2qf7c7v";
	}

	public static UI_com_CampPlayers CreateInstance()
	{
		return (UI_com_CampPlayers)(object)UIPackage.CreateObject("GvGWorldMap3", "com_CampPlayers");
	}

	public static UI_com_CampPlayers CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_CampPlayers).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://4eq8fgd2qf7c7v", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		//IL_010e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0118: Expected O, but got Unknown
		//IL_0161: Unknown result type (might be due to invalid IL or missing references)
		//IL_016b: Expected O, but got Unknown
		//IL_01b4: Unknown result type (might be due to invalid IL or missing references)
		//IL_01be: Expected O, but got Unknown
		//IL_0209: Unknown result type (might be due to invalid IL or missing references)
		//IL_0213: Expected O, but got Unknown
		//IL_025e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0268: Expected O, but got Unknown
		//IL_0274: Unknown result type (might be due to invalid IL or missing references)
		//IL_027e: Expected O, but got Unknown
		//IL_028a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0294: Expected O, but got Unknown
		//IL_02df: Unknown result type (might be due to invalid IL or missing references)
		//IL_02e9: Expected O, but got Unknown
		//IL_02f5: Unknown result type (might be due to invalid IL or missing references)
		//IL_02ff: Expected O, but got Unknown
		//IL_030b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0315: Expected O, but got Unknown
		//IL_0321: Unknown result type (might be due to invalid IL or missing references)
		//IL_032b: Expected O, but got Unknown
		//IL_0337: Unknown result type (might be due to invalid IL or missing references)
		//IL_0341: Expected O, but got Unknown
		//IL_034d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0357: Expected O, but got Unknown
		//IL_03a2: Unknown result type (might be due to invalid IL or missing references)
		//IL_03ac: Expected O, but got Unknown
		//IL_03b8: Unknown result type (might be due to invalid IL or missing references)
		//IL_03c2: Expected O, but got Unknown
		//IL_03ce: Unknown result type (might be due to invalid IL or missing references)
		//IL_03d8: Expected O, but got Unknown
		//IL_03e4: Unknown result type (might be due to invalid IL or missing references)
		//IL_03ee: Expected O, but got Unknown
		//IL_0439: Unknown result type (might be due to invalid IL or missing references)
		//IL_0443: Expected O, but got Unknown
		//IL_044f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0459: Expected O, but got Unknown
		//IL_0465: Unknown result type (might be due to invalid IL or missing references)
		//IL_046f: Expected O, but got Unknown
		//IL_047b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0485: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		Camp = ((GComponent)this).GetController("Camp");
		n0 = (GImage)((GComponent)this).GetChild("n0");
		n29 = (GImage)((GComponent)this).GetChild("n29");
		n1 = (GLoader)((GComponent)this).GetChild("n1");
		CampName4 = (GTextField)((GComponent)this).GetChild("CampName4");
		string id = "ui://4eq8fgd2qf7c7v".Replace("ui://", "") + "-" + ((GObject)CampName4).id;
		((GObject)CampName4).text = LanguagesManager.GetDesc(id);
		CampName3 = (GTextField)((GComponent)this).GetChild("CampName3");
		string id2 = "ui://4eq8fgd2qf7c7v".Replace("ui://", "") + "-" + ((GObject)CampName3).id;
		((GObject)CampName3).text = LanguagesManager.GetDesc(id2);
		CampName2 = (GTextField)((GComponent)this).GetChild("CampName2");
		string id3 = "ui://4eq8fgd2qf7c7v".Replace("ui://", "") + "-" + ((GObject)CampName2).id;
		((GObject)CampName2).text = LanguagesManager.GetDesc(id3);
		CampName = (GTextField)((GComponent)this).GetChild("CampName");
		string id4 = "ui://4eq8fgd2qf7c7v".Replace("ui://", "") + "-" + ((GObject)CampName).id;
		((GObject)CampName).text = LanguagesManager.GetDesc(id4);
		n3 = (GTextField)((GComponent)this).GetChild("n3");
		string id5 = "ui://4eq8fgd2qf7c7v".Replace("ui://", "") + "-" + ((GObject)n3).id;
		((GObject)n3).text = LanguagesManager.GetDesc(id5);
		n10 = (GTextField)((GComponent)this).GetChild("n10");
		string id6 = "ui://4eq8fgd2qf7c7v".Replace("ui://", "") + "-" + ((GObject)n10).id;
		((GObject)n10).text = LanguagesManager.GetDesc(id6);
		Players = (GList)((GComponent)this).GetChild("Players");
		n21 = (GImage)((GComponent)this).GetChild("n21");
		n4 = (GTextField)((GComponent)this).GetChild("n4");
		string id7 = "ui://4eq8fgd2qf7c7v".Replace("ui://", "") + "-" + ((GObject)n4).id;
		((GObject)n4).text = LanguagesManager.GetDesc(id7);
		PlayerNumber = (GTextField)((GComponent)this).GetChild("PlayerNumber");
		n24 = (GLoader)((GComponent)this).GetChild("n24");
		n13 = (GGroup)((GComponent)this).GetChild("n13");
		n22 = (GImage)((GComponent)this).GetChild("n22");
		n25 = (GLoader)((GComponent)this).GetChild("n25");
		n6 = (GTextField)((GComponent)this).GetChild("n6");
		string id8 = "ui://4eq8fgd2qf7c7v".Replace("ui://", "") + "-" + ((GObject)n6).id;
		((GObject)n6).text = LanguagesManager.GetDesc(id8);
		ShipsNumber = (GTextField)((GComponent)this).GetChild("ShipsNumber");
		n14 = (GGroup)((GComponent)this).GetChild("n14");
		n23 = (GImage)((GComponent)this).GetChild("n23");
		n8 = (GTextField)((GComponent)this).GetChild("n8");
		string id9 = "ui://4eq8fgd2qf7c7v".Replace("ui://", "") + "-" + ((GObject)n8).id;
		((GObject)n8).text = LanguagesManager.GetDesc(id9);
		IslandNumber = (GTextField)((GComponent)this).GetChild("IslandNumber");
		n26 = (GLoader)((GComponent)this).GetChild("n26");
		n19 = (GImage)((GComponent)this).GetChild("n19");
		n20 = (GImage)((GComponent)this).GetChild("n20");
	}
}
