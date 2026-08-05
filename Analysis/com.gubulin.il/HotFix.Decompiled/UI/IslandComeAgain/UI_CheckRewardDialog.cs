using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.IslandComeAgain;

public class UI_CheckRewardDialog : GComponent
{
	public Controller State;

	public Controller Type;

	public GImage n0;

	public GImage n1;

	public GImage n2;

	public GTextField n3;

	public GImage n4;

	public UI_mc_Slot BigPrize;

	public GImage n5;

	public GTextField BigPrizeName;

	public GTextField n8;

	public GTextField n9;

	public GList PrizesList;

	public GImage n15;

	public const string URL = "ui://k2sprg26x8oa6x";

	public static string Name = "UI_CheckRewardDialog";

	public void SetControllerPageText()
	{
		string id = string.Format("{0}-{1}-{2}", "ui://k2sprg26x8oa6x".Replace("ui://", ""), ((GObject)n3).id, Type.selectedIndex);
		((GObject)n3).text = LanguagesManager.GetDesc(id);
	}

	public static string GetURL()
	{
		return "ui://k2sprg26x8oa6x";
	}

	public static UI_CheckRewardDialog CreateInstance()
	{
		return (UI_CheckRewardDialog)(object)UIPackage.CreateObject("IslandComeAgain", "CheckRewardDialog");
	}

	public static UI_CheckRewardDialog CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_CheckRewardDialog).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://k2sprg26x8oa6x", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		//IL_00bb: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c5: Expected O, but got Unknown
		//IL_00d1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00db: Expected O, but got Unknown
		//IL_00e7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f1: Expected O, but got Unknown
		//IL_013a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0144: Expected O, but got Unknown
		//IL_018d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0197: Expected O, but got Unknown
		//IL_01a3: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ad: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		State = ((GComponent)this).GetController("State");
		Type = ((GComponent)this).GetController("Type");
		n0 = (GImage)((GComponent)this).GetChild("n0");
		n1 = (GImage)((GComponent)this).GetChild("n1");
		n2 = (GImage)((GComponent)this).GetChild("n2");
		n3 = (GTextField)((GComponent)this).GetChild("n3");
		n4 = (GImage)((GComponent)this).GetChild("n4");
		BigPrize = (UI_mc_Slot)(object)((GComponent)this).GetChild("BigPrize");
		n5 = (GImage)((GComponent)this).GetChild("n5");
		BigPrizeName = (GTextField)((GComponent)this).GetChild("BigPrizeName");
		n8 = (GTextField)((GComponent)this).GetChild("n8");
		string id = "ui://k2sprg26x8oa6x".Replace("ui://", "") + "-" + ((GObject)n8).id;
		((GObject)n8).text = LanguagesManager.GetDesc(id);
		n9 = (GTextField)((GComponent)this).GetChild("n9");
		string id2 = "ui://k2sprg26x8oa6x".Replace("ui://", "") + "-" + ((GObject)n9).id;
		((GObject)n9).text = LanguagesManager.GetDesc(id2);
		PrizesList = (GList)((GComponent)this).GetChild("PrizesList");
		n15 = (GImage)((GComponent)this).GetChild("n15");
	}
}
