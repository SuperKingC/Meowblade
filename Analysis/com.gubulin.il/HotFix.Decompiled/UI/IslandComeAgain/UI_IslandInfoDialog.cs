using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.IslandComeAgain;

public class UI_IslandInfoDialog : GComponent
{
	public Controller IslandType;

	public Controller IslandState;

	public GImage back;

	public GLoader n4;

	public GTextField IslandName;

	public GGraph n3;

	public UI_UserInfoDetail CheckUserInfoDetail;

	public GLoader n7;

	public UI_GoToIsland GoToIsland;

	public GImage n16;

	public GImage n17;

	public GImage n18;

	public GImage n19;

	public GTextField Score;

	public GTextField Time;

	public GTextField n20;

	public GTextField n21;

	public GImage n22;

	public GTextField n25;

	public GTextField Camp1;

	public GTextField Camp2;

	public GTextField Camp3;

	public GTextField Camp4;

	public GTextField n30;

	public const string URL = "ui://k2sprg26jcsv3w";

	public static string Name = "UI_IslandInfoDialog";

	public void SetControllerPageText()
	{
		string id = string.Format("{0}-{1}-{2}", "ui://k2sprg26jcsv3w".Replace("ui://", ""), ((GObject)n20).id, IslandState.selectedIndex);
		((GObject)n20).text = LanguagesManager.GetDesc(id);
		string id2 = string.Format("{0}-{1}-{2}", "ui://k2sprg26jcsv3w".Replace("ui://", ""), ((GObject)n25).id, IslandState.selectedIndex);
		((GObject)n25).text = LanguagesManager.GetDesc(id2, returnKey: false);
	}

	public static string GetURL()
	{
		return "ui://k2sprg26jcsv3w";
	}

	public static UI_IslandInfoDialog CreateInstance()
	{
		return (UI_IslandInfoDialog)(object)UIPackage.CreateObject("IslandComeAgain", "IslandInfoDialog");
	}

	public static UI_IslandInfoDialog CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_IslandInfoDialog).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://k2sprg26jcsv3w", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		//IL_00b6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c0: Expected O, but got Unknown
		//IL_00e2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ec: Expected O, but got Unknown
		//IL_010e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0118: Expected O, but got Unknown
		//IL_0124: Unknown result type (might be due to invalid IL or missing references)
		//IL_012e: Expected O, but got Unknown
		//IL_013a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0144: Expected O, but got Unknown
		//IL_0150: Unknown result type (might be due to invalid IL or missing references)
		//IL_015a: Expected O, but got Unknown
		//IL_0166: Unknown result type (might be due to invalid IL or missing references)
		//IL_0170: Expected O, but got Unknown
		//IL_017c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0186: Expected O, but got Unknown
		//IL_01cf: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d9: Expected O, but got Unknown
		//IL_0222: Unknown result type (might be due to invalid IL or missing references)
		//IL_022c: Expected O, but got Unknown
		//IL_0275: Unknown result type (might be due to invalid IL or missing references)
		//IL_027f: Expected O, but got Unknown
		//IL_028b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0295: Expected O, but got Unknown
		//IL_02e0: Unknown result type (might be due to invalid IL or missing references)
		//IL_02ea: Expected O, but got Unknown
		//IL_02f6: Unknown result type (might be due to invalid IL or missing references)
		//IL_0300: Expected O, but got Unknown
		//IL_030c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0316: Expected O, but got Unknown
		//IL_0322: Unknown result type (might be due to invalid IL or missing references)
		//IL_032c: Expected O, but got Unknown
		//IL_0338: Unknown result type (might be due to invalid IL or missing references)
		//IL_0342: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		IslandType = ((GComponent)this).GetController("IslandType");
		IslandState = ((GComponent)this).GetController("IslandState");
		back = (GImage)((GComponent)this).GetChild("back");
		n4 = (GLoader)((GComponent)this).GetChild("n4");
		IslandName = (GTextField)((GComponent)this).GetChild("IslandName");
		string id = "ui://k2sprg26jcsv3w".Replace("ui://", "") + "-" + ((GObject)IslandName).id;
		((GObject)IslandName).text = LanguagesManager.GetDesc(id);
		n3 = (GGraph)((GComponent)this).GetChild("n3");
		CheckUserInfoDetail = (UI_UserInfoDetail)(object)((GComponent)this).GetChild("CheckUserInfoDetail");
		n7 = (GLoader)((GComponent)this).GetChild("n7");
		GoToIsland = (UI_GoToIsland)(object)((GComponent)this).GetChild("GoToIsland");
		n16 = (GImage)((GComponent)this).GetChild("n16");
		n17 = (GImage)((GComponent)this).GetChild("n17");
		n18 = (GImage)((GComponent)this).GetChild("n18");
		n19 = (GImage)((GComponent)this).GetChild("n19");
		Score = (GTextField)((GComponent)this).GetChild("Score");
		Time = (GTextField)((GComponent)this).GetChild("Time");
		string id2 = "ui://k2sprg26jcsv3w".Replace("ui://", "") + "-" + ((GObject)Time).id;
		((GObject)Time).text = LanguagesManager.GetDesc(id2);
		n20 = (GTextField)((GComponent)this).GetChild("n20");
		string id3 = "ui://k2sprg26jcsv3w".Replace("ui://", "") + "-" + ((GObject)n20).id;
		((GObject)n20).text = LanguagesManager.GetDesc(id3);
		n21 = (GTextField)((GComponent)this).GetChild("n21");
		string id4 = "ui://k2sprg26jcsv3w".Replace("ui://", "") + "-" + ((GObject)n21).id;
		((GObject)n21).text = LanguagesManager.GetDesc(id4);
		n22 = (GImage)((GComponent)this).GetChild("n22");
		n25 = (GTextField)((GComponent)this).GetChild("n25");
		string id5 = "ui://k2sprg26jcsv3w".Replace("ui://", "") + "-" + ((GObject)n25).id;
		((GObject)n25).text = LanguagesManager.GetDesc(id5);
		Camp1 = (GTextField)((GComponent)this).GetChild("Camp1");
		Camp2 = (GTextField)((GComponent)this).GetChild("Camp2");
		Camp3 = (GTextField)((GComponent)this).GetChild("Camp3");
		Camp4 = (GTextField)((GComponent)this).GetChild("Camp4");
		n30 = (GTextField)((GComponent)this).GetChild("n30");
		string id6 = "ui://k2sprg26jcsv3w".Replace("ui://", "") + "-" + ((GObject)n30).id;
		((GObject)n30).text = LanguagesManager.GetDesc(id6);
	}
}
