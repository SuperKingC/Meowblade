using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvG3SupplyDepot;

public class UI_com_ContributionRewardDetail : GComponent
{
	public Controller Type;

	public GLoader n6;

	public GTextField ContributionScore;

	public GLoader BoxIcon;

	public GList Bonus;

	public GTextField n5;

	public GImage n7;

	public GTextField n8;

	public GGroup n9;

	public GLoader n11;

	public const string URL = "ui://pobej4q7mo53q";

	public static string Name = "UI_com_ContributionRewardDetail";

	public static string GetURL()
	{
		return "ui://pobej4q7mo53q";
	}

	public static UI_com_ContributionRewardDetail CreateInstance()
	{
		return (UI_com_ContributionRewardDetail)(object)UIPackage.CreateObject("GvG3SupplyDepot", "com_ContributionRewardDetail");
	}

	public static UI_com_ContributionRewardDetail CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_ContributionRewardDetail).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://pobej4q7mo53q", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		//IL_00d1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00db: Expected O, but got Unknown
		//IL_00e7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f1: Expected O, but got Unknown
		//IL_013a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0144: Expected O, but got Unknown
		//IL_0150: Unknown result type (might be due to invalid IL or missing references)
		//IL_015a: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		Type = ((GComponent)this).GetController("Type");
		n6 = (GLoader)((GComponent)this).GetChild("n6");
		ContributionScore = (GTextField)((GComponent)this).GetChild("ContributionScore");
		BoxIcon = (GLoader)((GComponent)this).GetChild("BoxIcon");
		Bonus = (GList)((GComponent)this).GetChild("Bonus");
		n5 = (GTextField)((GComponent)this).GetChild("n5");
		string id = "ui://pobej4q7mo53q".Replace("ui://", "") + "-" + ((GObject)n5).id;
		((GObject)n5).text = LanguagesManager.GetDesc(id);
		n7 = (GImage)((GComponent)this).GetChild("n7");
		n8 = (GTextField)((GComponent)this).GetChild("n8");
		string id2 = "ui://pobej4q7mo53q".Replace("ui://", "") + "-" + ((GObject)n8).id;
		((GObject)n8).text = LanguagesManager.GetDesc(id2);
		n9 = (GGroup)((GComponent)this).GetChild("n9");
		n11 = (GLoader)((GComponent)this).GetChild("n11");
	}
}
