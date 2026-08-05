using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.IslandComeAgain;

public class UI_MyBattleRecordInfo : GComponent
{
	public Controller Type;

	public GImage n2;

	public GTextField n3;

	public GLoader n4;

	public GLoader Logo;

	public GTextField n6;

	public GTextField MyRank;

	public GTextField n9;

	public GTextField n10;

	public GTextField n11;

	public GTextField n12;

	public GImage n14;

	public GTextField BestMultiKill;

	public GTextField Reward;

	public GTextField TotalKill;

	public GTextField TotalLoss;

	public GImage n19;

	public GImage n20;

	public GImage n21;

	public const string URL = "ui://k2sprg26uctj84";

	public static string Name = "UI_MyBattleRecordInfo";

	public static string GetURL()
	{
		return "ui://k2sprg26uctj84";
	}

	public static UI_MyBattleRecordInfo CreateInstance()
	{
		return (UI_MyBattleRecordInfo)(object)UIPackage.CreateObject("IslandComeAgain", "MyBattleRecordInfo");
	}

	public static UI_MyBattleRecordInfo CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_MyBattleRecordInfo).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://k2sprg26uctj84", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Expected O, but got Unknown
		//IL_003c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0046: Expected O, but got Unknown
		//IL_008f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0099: Expected O, but got Unknown
		//IL_00a5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00af: Expected O, but got Unknown
		//IL_00bb: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c5: Expected O, but got Unknown
		//IL_010e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0118: Expected O, but got Unknown
		//IL_0124: Unknown result type (might be due to invalid IL or missing references)
		//IL_012e: Expected O, but got Unknown
		//IL_0177: Unknown result type (might be due to invalid IL or missing references)
		//IL_0181: Expected O, but got Unknown
		//IL_01ca: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d4: Expected O, but got Unknown
		//IL_021f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0229: Expected O, but got Unknown
		//IL_0274: Unknown result type (might be due to invalid IL or missing references)
		//IL_027e: Expected O, but got Unknown
		//IL_028a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0294: Expected O, but got Unknown
		//IL_02a0: Unknown result type (might be due to invalid IL or missing references)
		//IL_02aa: Expected O, but got Unknown
		//IL_02b6: Unknown result type (might be due to invalid IL or missing references)
		//IL_02c0: Expected O, but got Unknown
		//IL_02cc: Unknown result type (might be due to invalid IL or missing references)
		//IL_02d6: Expected O, but got Unknown
		//IL_02e2: Unknown result type (might be due to invalid IL or missing references)
		//IL_02ec: Expected O, but got Unknown
		//IL_02f8: Unknown result type (might be due to invalid IL or missing references)
		//IL_0302: Expected O, but got Unknown
		//IL_030e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0318: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		Type = ((GComponent)this).GetController("Type");
		n2 = (GImage)((GComponent)this).GetChild("n2");
		n3 = (GTextField)((GComponent)this).GetChild("n3");
		string id = "ui://k2sprg26uctj84".Replace("ui://", "") + "-" + ((GObject)n3).id;
		((GObject)n3).text = LanguagesManager.GetDesc(id);
		n4 = (GLoader)((GComponent)this).GetChild("n4");
		Logo = (GLoader)((GComponent)this).GetChild("Logo");
		n6 = (GTextField)((GComponent)this).GetChild("n6");
		string id2 = "ui://k2sprg26uctj84".Replace("ui://", "") + "-" + ((GObject)n6).id;
		((GObject)n6).text = LanguagesManager.GetDesc(id2);
		MyRank = (GTextField)((GComponent)this).GetChild("MyRank");
		n9 = (GTextField)((GComponent)this).GetChild("n9");
		string id3 = "ui://k2sprg26uctj84".Replace("ui://", "") + "-" + ((GObject)n9).id;
		((GObject)n9).text = LanguagesManager.GetDesc(id3);
		n10 = (GTextField)((GComponent)this).GetChild("n10");
		string id4 = "ui://k2sprg26uctj84".Replace("ui://", "") + "-" + ((GObject)n10).id;
		((GObject)n10).text = LanguagesManager.GetDesc(id4);
		n11 = (GTextField)((GComponent)this).GetChild("n11");
		string id5 = "ui://k2sprg26uctj84".Replace("ui://", "") + "-" + ((GObject)n11).id;
		((GObject)n11).text = LanguagesManager.GetDesc(id5);
		n12 = (GTextField)((GComponent)this).GetChild("n12");
		string id6 = "ui://k2sprg26uctj84".Replace("ui://", "") + "-" + ((GObject)n12).id;
		((GObject)n12).text = LanguagesManager.GetDesc(id6);
		n14 = (GImage)((GComponent)this).GetChild("n14");
		BestMultiKill = (GTextField)((GComponent)this).GetChild("BestMultiKill");
		Reward = (GTextField)((GComponent)this).GetChild("Reward");
		TotalKill = (GTextField)((GComponent)this).GetChild("TotalKill");
		TotalLoss = (GTextField)((GComponent)this).GetChild("TotalLoss");
		n19 = (GImage)((GComponent)this).GetChild("n19");
		n20 = (GImage)((GComponent)this).GetChild("n20");
		n21 = (GImage)((GComponent)this).GetChild("n21");
	}
}
