using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.PvpSelectSoldiers;

public class UI_PVPSeasonMatchResultDialog : GComponent
{
	public Controller IsFinished;

	public GImage n0;

	public GImage n1;

	public GImage n2;

	public GImage n3;

	public GGroup n5;

	public GTextField SubTitle;

	public GImage Title;

	public GImage n7;

	public GTextField ResultInfo;

	public GImage n11;

	public GTextField RankTitle;

	public GImage n12;

	public GTextField RoundGroup;

	public GTextField RankNumber;

	public GImage n14;

	public GImage n17;

	public GList ResultRewardList;

	public GImage n15;

	public GTextField RewardTitle;

	public GGroup n26;

	public GButton ConfirmButton;

	public Transition t0;

	public const string URL = "ui://82mo10n5o6jgjdq5";

	public static string Name = "UI_PVPSeasonMatchResultDialog";

	public static string GetURL()
	{
		return "ui://82mo10n5o6jgjdq5";
	}

	public static UI_PVPSeasonMatchResultDialog CreateInstance()
	{
		return (UI_PVPSeasonMatchResultDialog)(object)UIPackage.CreateObject("PvpSelectSoldiers", "PVPSeasonMatchResultDialog");
	}

	public static UI_PVPSeasonMatchResultDialog CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_PVPSeasonMatchResultDialog).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://82mo10n5o6jgjdq5", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		//IL_01e5: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ef: Expected O, but got Unknown
		//IL_01fb: Unknown result type (might be due to invalid IL or missing references)
		//IL_0205: Expected O, but got Unknown
		//IL_0211: Unknown result type (might be due to invalid IL or missing references)
		//IL_021b: Expected O, but got Unknown
		//IL_0227: Unknown result type (might be due to invalid IL or missing references)
		//IL_0231: Expected O, but got Unknown
		//IL_023d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0247: Expected O, but got Unknown
		//IL_0253: Unknown result type (might be due to invalid IL or missing references)
		//IL_025d: Expected O, but got Unknown
		//IL_0269: Unknown result type (might be due to invalid IL or missing references)
		//IL_0273: Expected O, but got Unknown
		//IL_02bc: Unknown result type (might be due to invalid IL or missing references)
		//IL_02c6: Expected O, but got Unknown
		//IL_02d2: Unknown result type (might be due to invalid IL or missing references)
		//IL_02dc: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		IsFinished = ((GComponent)this).GetController("IsFinished");
		n0 = (GImage)((GComponent)this).GetChild("n0");
		n1 = (GImage)((GComponent)this).GetChild("n1");
		n2 = (GImage)((GComponent)this).GetChild("n2");
		n3 = (GImage)((GComponent)this).GetChild("n3");
		n5 = (GGroup)((GComponent)this).GetChild("n5");
		SubTitle = (GTextField)((GComponent)this).GetChild("SubTitle");
		string id = "ui://82mo10n5o6jgjdq5".Replace("ui://", "") + "-" + ((GObject)SubTitle).id;
		((GObject)SubTitle).text = LanguagesManager.GetDesc(id);
		Title = (GImage)((GComponent)this).GetChild("Title");
		n7 = (GImage)((GComponent)this).GetChild("n7");
		ResultInfo = (GTextField)((GComponent)this).GetChild("ResultInfo");
		string id2 = "ui://82mo10n5o6jgjdq5".Replace("ui://", "") + "-" + ((GObject)ResultInfo).id;
		((GObject)ResultInfo).text = LanguagesManager.GetDesc(id2);
		n11 = (GImage)((GComponent)this).GetChild("n11");
		RankTitle = (GTextField)((GComponent)this).GetChild("RankTitle");
		string id3 = "ui://82mo10n5o6jgjdq5".Replace("ui://", "") + "-" + ((GObject)RankTitle).id;
		((GObject)RankTitle).text = LanguagesManager.GetDesc(id3);
		n12 = (GImage)((GComponent)this).GetChild("n12");
		RoundGroup = (GTextField)((GComponent)this).GetChild("RoundGroup");
		RankNumber = (GTextField)((GComponent)this).GetChild("RankNumber");
		n14 = (GImage)((GComponent)this).GetChild("n14");
		n17 = (GImage)((GComponent)this).GetChild("n17");
		ResultRewardList = (GList)((GComponent)this).GetChild("ResultRewardList");
		n15 = (GImage)((GComponent)this).GetChild("n15");
		RewardTitle = (GTextField)((GComponent)this).GetChild("RewardTitle");
		string id4 = "ui://82mo10n5o6jgjdq5".Replace("ui://", "") + "-" + ((GObject)RewardTitle).id;
		((GObject)RewardTitle).text = LanguagesManager.GetDesc(id4);
		n26 = (GGroup)((GComponent)this).GetChild("n26");
		ConfirmButton = (GButton)((GComponent)this).GetChild("ConfirmButton");
		t0 = ((GComponent)this).GetTransition("t0");
	}
}
