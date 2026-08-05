using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGExpeditionHall;

public class UI_com_SpecialBonusDialog : GComponent
{
	public GImage tipBack;

	public GImage n53;

	public GImage n54;

	public GImage n51;

	public GImage n52;

	public GImage n49;

	public GImage n1;

	public GTextField n48;

	public UI_com_SpecialItemList ItemList;

	public UI_com_CheckDropDetialBtn CheckDropDetialBtn;

	public const string URL = "ui://k19peou7qix93g";

	public static string Name = "UI_com_SpecialBonusDialog";

	public static string GetURL()
	{
		return "ui://k19peou7qix93g";
	}

	public static UI_com_SpecialBonusDialog CreateInstance()
	{
		return (UI_com_SpecialBonusDialog)(object)UIPackage.CreateObject("GvGExpeditionHall", "com_SpecialBonusDialog");
	}

	public static UI_com_SpecialBonusDialog CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_SpecialBonusDialog).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://k19peou7qix93g", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0035: Expected O, but got Unknown
		//IL_0041: Unknown result type (might be due to invalid IL or missing references)
		//IL_004b: Expected O, but got Unknown
		//IL_0057: Unknown result type (might be due to invalid IL or missing references)
		//IL_0061: Expected O, but got Unknown
		//IL_006d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0077: Expected O, but got Unknown
		//IL_0083: Unknown result type (might be due to invalid IL or missing references)
		//IL_008d: Expected O, but got Unknown
		//IL_0099: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a3: Expected O, but got Unknown
		//IL_00af: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b9: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		tipBack = (GImage)((GComponent)this).GetChild("tipBack");
		n53 = (GImage)((GComponent)this).GetChild("n53");
		n54 = (GImage)((GComponent)this).GetChild("n54");
		n51 = (GImage)((GComponent)this).GetChild("n51");
		n52 = (GImage)((GComponent)this).GetChild("n52");
		n49 = (GImage)((GComponent)this).GetChild("n49");
		n1 = (GImage)((GComponent)this).GetChild("n1");
		n48 = (GTextField)((GComponent)this).GetChild("n48");
		string id = "ui://k19peou7qix93g".Replace("ui://", "") + "-" + ((GObject)n48).id;
		((GObject)n48).text = LanguagesManager.GetDesc(id);
		ItemList = (UI_com_SpecialItemList)(object)((GComponent)this).GetChild("ItemList");
		CheckDropDetialBtn = (UI_com_CheckDropDetialBtn)(object)((GComponent)this).GetChild("CheckDropDetialBtn");
	}
}
