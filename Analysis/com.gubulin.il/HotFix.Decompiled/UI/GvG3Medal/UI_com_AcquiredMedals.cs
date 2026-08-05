using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;
using HotFix.Sources.Base.Sources.Scripts.GvG3.GvG3UI.Model.MedalUi;

namespace UI.GvG3Medal;

public class UI_com_AcquiredMedals : GComponent
{
	public Controller Type;

	public GImage n0;

	public GImage n12;

	public GLoader n2;

	public GTextField n3;

	public GTextField AcquiredDiamondMedal;

	public GImage n1;

	public GLoader n5;

	public GLoader n6;

	public GTextField n7;

	public GTextField AcquiredGoldMedal;

	public GTextField n9;

	public GTextField AcquiredSilverMedal;

	public const string URL = "ui://g5hi1peolq584";

	public static string Name = "UI_com_AcquiredMedals";

	public static string GetURL()
	{
		return "ui://g5hi1peolq584";
	}

	public static UI_com_AcquiredMedals CreateInstance()
	{
		return (UI_com_AcquiredMedals)(object)UIPackage.CreateObject("GvG3Medal", "com_AcquiredMedals");
	}

	public static UI_com_AcquiredMedals CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_AcquiredMedals).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://g5hi1peolq584", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		//IL_00d1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00db: Expected O, but got Unknown
		//IL_00e7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f1: Expected O, but got Unknown
		//IL_00fd: Unknown result type (might be due to invalid IL or missing references)
		//IL_0107: Expected O, but got Unknown
		//IL_0113: Unknown result type (might be due to invalid IL or missing references)
		//IL_011d: Expected O, but got Unknown
		//IL_0166: Unknown result type (might be due to invalid IL or missing references)
		//IL_0170: Expected O, but got Unknown
		//IL_017c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0186: Expected O, but got Unknown
		//IL_01cf: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d9: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		Type = ((GComponent)this).GetController("Type");
		n0 = (GImage)((GComponent)this).GetChild("n0");
		n12 = (GImage)((GComponent)this).GetChild("n12");
		n2 = (GLoader)((GComponent)this).GetChild("n2");
		n3 = (GTextField)((GComponent)this).GetChild("n3");
		string id = "ui://g5hi1peolq584".Replace("ui://", "") + "-" + ((GObject)n3).id;
		((GObject)n3).text = LanguagesManager.GetDesc(id);
		AcquiredDiamondMedal = (GTextField)((GComponent)this).GetChild("AcquiredDiamondMedal");
		n1 = (GImage)((GComponent)this).GetChild("n1");
		n5 = (GLoader)((GComponent)this).GetChild("n5");
		n6 = (GLoader)((GComponent)this).GetChild("n6");
		n7 = (GTextField)((GComponent)this).GetChild("n7");
		string id2 = "ui://g5hi1peolq584".Replace("ui://", "") + "-" + ((GObject)n7).id;
		((GObject)n7).text = LanguagesManager.GetDesc(id2);
		AcquiredGoldMedal = (GTextField)((GComponent)this).GetChild("AcquiredGoldMedal");
		n9 = (GTextField)((GComponent)this).GetChild("n9");
		string id3 = "ui://g5hi1peolq584".Replace("ui://", "") + "-" + ((GObject)n9).id;
		((GObject)n9).text = LanguagesManager.GetDesc(id3);
		AcquiredSilverMedal = (GTextField)((GComponent)this).GetChild("AcquiredSilverMedal");
	}

	public void OnRender(MedalSummary summary)
	{
		((GObject)AcquiredDiamondMedal).text = $"{summary.DiamondMedalCnt}/{summary.DiamondMedalTotalCnt}";
		((GObject)AcquiredGoldMedal).text = $"{summary.GoldMedalCnt}/{summary.GoldMedalTotalCnt}";
		((GObject)AcquiredSilverMedal).text = $"{summary.SilverMedalCnt}/{summary.SilverMedalTotalCnt}";
		Type.SetSelectedIndex((summary.DiamondMedalCnt >= summary.DiamondMedalTotalCnt) ? 1 : 0);
	}
}
