using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGWorldMap3;

public class UI_com_BuySweepCountDialog : GComponent
{
	public Controller AllowToAdd;

	public GImage back;

	public GImage n29;

	public GImage n30;

	public GTextField n14;

	public UI_btn_Plunderyes Confirm;

	public GTextField TodayPurchasedCount;

	public GTextField n28;

	public GLoader CostIcon;

	public GTextField CostNum;

	public GGroup n33;

	public GTextField DailyMaxSweepCountAdd;

	public GTextField n35;

	public GTextField n36;

	public GTextField ContributionAddValue;

	public GGroup n38;

	public const string URL = "ui://4eq8fgd2s80zsag";

	public static string Name = "UI_com_BuySweepCountDialog";

	public static string GetURL()
	{
		return "ui://4eq8fgd2s80zsag";
	}

	public static UI_com_BuySweepCountDialog CreateInstance()
	{
		return (UI_com_BuySweepCountDialog)(object)UIPackage.CreateObject("GvGWorldMap3", "com_BuySweepCountDialog");
	}

	public static UI_com_BuySweepCountDialog CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_BuySweepCountDialog).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://4eq8fgd2s80zsag", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		//IL_00d1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00db: Expected O, but got Unknown
		//IL_00e7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f1: Expected O, but got Unknown
		//IL_013a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0144: Expected O, but got Unknown
		//IL_0150: Unknown result type (might be due to invalid IL or missing references)
		//IL_015a: Expected O, but got Unknown
		//IL_0166: Unknown result type (might be due to invalid IL or missing references)
		//IL_0170: Expected O, but got Unknown
		//IL_017c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0186: Expected O, but got Unknown
		//IL_0192: Unknown result type (might be due to invalid IL or missing references)
		//IL_019c: Expected O, but got Unknown
		//IL_01e5: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ef: Expected O, but got Unknown
		//IL_0238: Unknown result type (might be due to invalid IL or missing references)
		//IL_0242: Expected O, but got Unknown
		//IL_024e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0258: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		AllowToAdd = ((GComponent)this).GetController("AllowToAdd");
		back = (GImage)((GComponent)this).GetChild("back");
		n29 = (GImage)((GComponent)this).GetChild("n29");
		n30 = (GImage)((GComponent)this).GetChild("n30");
		n14 = (GTextField)((GComponent)this).GetChild("n14");
		string id = "ui://4eq8fgd2s80zsag".Replace("ui://", "") + "-" + ((GObject)n14).id;
		((GObject)n14).text = LanguagesManager.GetDesc(id);
		Confirm = (UI_btn_Plunderyes)(object)((GComponent)this).GetChild("Confirm");
		TodayPurchasedCount = (GTextField)((GComponent)this).GetChild("TodayPurchasedCount");
		n28 = (GTextField)((GComponent)this).GetChild("n28");
		string id2 = "ui://4eq8fgd2s80zsag".Replace("ui://", "") + "-" + ((GObject)n28).id;
		((GObject)n28).text = LanguagesManager.GetDesc(id2);
		CostIcon = (GLoader)((GComponent)this).GetChild("CostIcon");
		CostNum = (GTextField)((GComponent)this).GetChild("CostNum");
		n33 = (GGroup)((GComponent)this).GetChild("n33");
		DailyMaxSweepCountAdd = (GTextField)((GComponent)this).GetChild("DailyMaxSweepCountAdd");
		n35 = (GTextField)((GComponent)this).GetChild("n35");
		string id3 = "ui://4eq8fgd2s80zsag".Replace("ui://", "") + "-" + ((GObject)n35).id;
		((GObject)n35).text = LanguagesManager.GetDesc(id3);
		n36 = (GTextField)((GComponent)this).GetChild("n36");
		string id4 = "ui://4eq8fgd2s80zsag".Replace("ui://", "") + "-" + ((GObject)n36).id;
		((GObject)n36).text = LanguagesManager.GetDesc(id4);
		ContributionAddValue = (GTextField)((GComponent)this).GetChild("ContributionAddValue");
		n38 = (GGroup)((GComponent)this).GetChild("n38");
	}
}
