using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.PvpSelectSoldiers;

public class UI_BetRewardCountLabel : GComponent
{
	public Controller isTotal;

	public GImage n46;

	public GTextField RewardTitle;

	public GLoader RewardItemIcon;

	public GTextField CountText;

	public GGroup TotallyRewardCountGroup;

	public GMovieClip n51;

	public GMovieClip n52;

	public GMovieClip n55;

	public GMovieClip n53;

	public GMovieClip n54;

	public const string URL = "ui://82mo10n5rnlpjdu0";

	public static string Name = "UI_BetRewardCountLabel";

	public static string GetURL()
	{
		return "ui://82mo10n5rnlpjdu0";
	}

	public static UI_BetRewardCountLabel CreateInstance()
	{
		return (UI_BetRewardCountLabel)(object)UIPackage.CreateObject("PvpSelectSoldiers", "BetRewardCountLabel");
	}

	public static UI_BetRewardCountLabel CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_BetRewardCountLabel).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://82mo10n5rnlpjdu0", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		//IL_00d1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00db: Expected O, but got Unknown
		//IL_00e7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f1: Expected O, but got Unknown
		//IL_00fd: Unknown result type (might be due to invalid IL or missing references)
		//IL_0107: Expected O, but got Unknown
		//IL_0113: Unknown result type (might be due to invalid IL or missing references)
		//IL_011d: Expected O, but got Unknown
		//IL_0129: Unknown result type (might be due to invalid IL or missing references)
		//IL_0133: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		isTotal = ((GComponent)this).GetController("isTotal");
		n46 = (GImage)((GComponent)this).GetChild("n46");
		RewardTitle = (GTextField)((GComponent)this).GetChild("RewardTitle");
		string id = "ui://82mo10n5rnlpjdu0".Replace("ui://", "") + "-" + ((GObject)RewardTitle).id;
		((GObject)RewardTitle).text = LanguagesManager.GetDesc(id);
		RewardItemIcon = (GLoader)((GComponent)this).GetChild("RewardItemIcon");
		CountText = (GTextField)((GComponent)this).GetChild("CountText");
		TotallyRewardCountGroup = (GGroup)((GComponent)this).GetChild("TotallyRewardCountGroup");
		n51 = (GMovieClip)((GComponent)this).GetChild("n51");
		n52 = (GMovieClip)((GComponent)this).GetChild("n52");
		n55 = (GMovieClip)((GComponent)this).GetChild("n55");
		n53 = (GMovieClip)((GComponent)this).GetChild("n53");
		n54 = (GMovieClip)((GComponent)this).GetChild("n54");
	}
}
