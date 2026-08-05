using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.RecyclingCenter;

public class UI_EquipmentCom : GButton
{
	public Controller Status;

	public Controller RatioStatus;

	public Controller TypeStatus;

	public GImage n36;

	public GImage n37;

	public GImage n38;

	public GImage n39;

	public GImage n40;

	public GImage CardGoldBack;

	public GImage n24;

	public GImage n25;

	public GImage n26;

	public GImage n27;

	public GGroup highlight;

	public GLoader icon;

	public GImage n42;

	public GImage n44;

	public GImage n43;

	public GImage n45;

	public GImage n46;

	public GImage n47;

	public GTextField ratio;

	public GImage n5;

	public GImage n3;

	public GTextField EquipmentName;

	public GTextField num;

	public GTextField price;

	public GGraph strokeSfxBack;

	public Transition Breath;

	public const string URL = "ui://72poq8plkxixk";

	public static string Name = "UI_EquipmentCom";

	public static string GetURL()
	{
		return "ui://72poq8plkxixk";
	}

	public static UI_EquipmentCom CreateInstance()
	{
		return (UI_EquipmentCom)(object)UIPackage.CreateObject("RecyclingCenter", "EquipmentCom");
	}

	public static UI_EquipmentCom CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_EquipmentCom).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://72poq8plkxixk", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0048: Unknown result type (might be due to invalid IL or missing references)
		//IL_0052: Expected O, but got Unknown
		//IL_005e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0068: Expected O, but got Unknown
		//IL_0074: Unknown result type (might be due to invalid IL or missing references)
		//IL_007e: Expected O, but got Unknown
		//IL_008a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0094: Expected O, but got Unknown
		//IL_00a0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00aa: Expected O, but got Unknown
		//IL_00b6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c0: Expected O, but got Unknown
		//IL_00cc: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d6: Expected O, but got Unknown
		//IL_00e2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ec: Expected O, but got Unknown
		//IL_00f8: Unknown result type (might be due to invalid IL or missing references)
		//IL_0102: Expected O, but got Unknown
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
		//IL_0192: Unknown result type (might be due to invalid IL or missing references)
		//IL_019c: Expected O, but got Unknown
		//IL_01a8: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b2: Expected O, but got Unknown
		//IL_01be: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c8: Expected O, but got Unknown
		//IL_01d4: Unknown result type (might be due to invalid IL or missing references)
		//IL_01de: Expected O, but got Unknown
		//IL_0227: Unknown result type (might be due to invalid IL or missing references)
		//IL_0231: Expected O, but got Unknown
		//IL_023d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0247: Expected O, but got Unknown
		//IL_0253: Unknown result type (might be due to invalid IL or missing references)
		//IL_025d: Expected O, but got Unknown
		//IL_02a6: Unknown result type (might be due to invalid IL or missing references)
		//IL_02b0: Expected O, but got Unknown
		//IL_02f9: Unknown result type (might be due to invalid IL or missing references)
		//IL_0303: Expected O, but got Unknown
		//IL_034c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0356: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		Status = ((GComponent)this).GetController("Status");
		RatioStatus = ((GComponent)this).GetController("RatioStatus");
		TypeStatus = ((GComponent)this).GetController("TypeStatus");
		n36 = (GImage)((GComponent)this).GetChild("n36");
		n37 = (GImage)((GComponent)this).GetChild("n37");
		n38 = (GImage)((GComponent)this).GetChild("n38");
		n39 = (GImage)((GComponent)this).GetChild("n39");
		n40 = (GImage)((GComponent)this).GetChild("n40");
		CardGoldBack = (GImage)((GComponent)this).GetChild("CardGoldBack");
		n24 = (GImage)((GComponent)this).GetChild("n24");
		n25 = (GImage)((GComponent)this).GetChild("n25");
		n26 = (GImage)((GComponent)this).GetChild("n26");
		n27 = (GImage)((GComponent)this).GetChild("n27");
		highlight = (GGroup)((GComponent)this).GetChild("highlight");
		icon = (GLoader)((GComponent)this).GetChild("icon");
		n42 = (GImage)((GComponent)this).GetChild("n42");
		n44 = (GImage)((GComponent)this).GetChild("n44");
		n43 = (GImage)((GComponent)this).GetChild("n43");
		n45 = (GImage)((GComponent)this).GetChild("n45");
		n46 = (GImage)((GComponent)this).GetChild("n46");
		n47 = (GImage)((GComponent)this).GetChild("n47");
		ratio = (GTextField)((GComponent)this).GetChild("ratio");
		string id = "ui://72poq8plkxixk".Replace("ui://", "") + "-" + ((GObject)ratio).id;
		((GObject)ratio).text = LanguagesManager.GetDesc(id);
		n5 = (GImage)((GComponent)this).GetChild("n5");
		n3 = (GImage)((GComponent)this).GetChild("n3");
		EquipmentName = (GTextField)((GComponent)this).GetChild("EquipmentName");
		string id2 = "ui://72poq8plkxixk".Replace("ui://", "") + "-" + ((GObject)EquipmentName).id;
		((GObject)EquipmentName).text = LanguagesManager.GetDesc(id2);
		num = (GTextField)((GComponent)this).GetChild("num");
		string id3 = "ui://72poq8plkxixk".Replace("ui://", "") + "-" + ((GObject)num).id;
		((GObject)num).text = LanguagesManager.GetDesc(id3);
		price = (GTextField)((GComponent)this).GetChild("price");
		string id4 = "ui://72poq8plkxixk".Replace("ui://", "") + "-" + ((GObject)price).id;
		((GObject)price).text = LanguagesManager.GetDesc(id4);
		strokeSfxBack = (GGraph)((GComponent)this).GetChild("strokeSfxBack");
		Breath = ((GComponent)this).GetTransition("Breath");
	}
}
