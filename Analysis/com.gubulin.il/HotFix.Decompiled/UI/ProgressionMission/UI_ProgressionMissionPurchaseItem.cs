using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.ProgressionMission;

public class UI_ProgressionMissionPurchaseItem : GComponent
{
	public Controller isPurchased;

	public GImage n4;

	public GImage IconBg;

	public GImage n15;

	public GImage n13;

	public GLoader rewardIconAdvance;

	public GTextField NumAdvance;

	public GTextField rewardName;

	public GTextField price;

	public GComponent discount;

	public GGroup grayGroup;

	public GTextField returnDes;

	public GLoader n14;

	public const string URL = "ui://mapat4i5elte89";

	public static string Name = "UI_ProgressionMissionPurchaseItem";

	public static string GetURL()
	{
		return "ui://mapat4i5elte89";
	}

	public static UI_ProgressionMissionPurchaseItem CreateInstance()
	{
		return (UI_ProgressionMissionPurchaseItem)(object)UIPackage.CreateObject("ProgressionMission", "ProgressionMissionPurchaseItem");
	}

	public static UI_ProgressionMissionPurchaseItem CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_ProgressionMissionPurchaseItem).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://mapat4i5elte89", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		//IL_00fd: Unknown result type (might be due to invalid IL or missing references)
		//IL_0107: Expected O, but got Unknown
		//IL_0150: Unknown result type (might be due to invalid IL or missing references)
		//IL_015a: Expected O, but got Unknown
		//IL_0166: Unknown result type (might be due to invalid IL or missing references)
		//IL_0170: Expected O, but got Unknown
		//IL_017c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0186: Expected O, but got Unknown
		//IL_01cf: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d9: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		isPurchased = ((GComponent)this).GetController("isPurchased");
		n4 = (GImage)((GComponent)this).GetChild("n4");
		IconBg = (GImage)((GComponent)this).GetChild("IconBg");
		n15 = (GImage)((GComponent)this).GetChild("n15");
		n13 = (GImage)((GComponent)this).GetChild("n13");
		rewardIconAdvance = (GLoader)((GComponent)this).GetChild("rewardIconAdvance");
		NumAdvance = (GTextField)((GComponent)this).GetChild("NumAdvance");
		rewardName = (GTextField)((GComponent)this).GetChild("rewardName");
		string id = "ui://mapat4i5elte89".Replace("ui://", "") + "-" + ((GObject)rewardName).id;
		((GObject)rewardName).text = LanguagesManager.GetDesc(id);
		price = (GTextField)((GComponent)this).GetChild("price");
		string id2 = "ui://mapat4i5elte89".Replace("ui://", "") + "-" + ((GObject)price).id;
		((GObject)price).text = LanguagesManager.GetDesc(id2);
		discount = (GComponent)((GComponent)this).GetChild("discount");
		grayGroup = (GGroup)((GComponent)this).GetChild("grayGroup");
		returnDes = (GTextField)((GComponent)this).GetChild("returnDes");
		string id3 = "ui://mapat4i5elte89".Replace("ui://", "") + "-" + ((GObject)returnDes).id;
		((GObject)returnDes).text = LanguagesManager.GetDesc(id3);
		n14 = (GLoader)((GComponent)this).GetChild("n14");
	}
}
