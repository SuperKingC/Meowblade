using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGRandomEvent3;

public class UI_com_NpcShop : GComponent
{
	public Controller PageSwitch;

	public Controller hasOuterTech;

	public GList TabListBack;

	public GImage n0;

	public GImage n19;

	public GImage n13;

	public GLoader NpcIcon;

	public GImage n14;

	public GTextField EventName;

	public GTextField NpcText;

	public GTextField Countdown;

	public GTextField n6;

	public GList StoreItems;

	public GImage n15;

	public GTextField n8;

	public GTextField n9;

	public GTextField n10;

	public GTextField n11;

	public GList TabListFront;

	public UI_com_ResTip RpcTip;

	public const string URL = "ui://p4ocf6q0dc6m7";

	public static string Name = "UI_com_NpcShop";

	public static string GetURL()
	{
		return "ui://p4ocf6q0dc6m7";
	}

	public static UI_com_NpcShop CreateInstance()
	{
		return (UI_com_NpcShop)(object)UIPackage.CreateObject("GvGRandomEvent3", "com_NpcShop");
	}

	public static UI_com_NpcShop CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_NpcShop).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://p4ocf6q0dc6m7", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		//IL_0150: Unknown result type (might be due to invalid IL or missing references)
		//IL_015a: Expected O, but got Unknown
		//IL_0166: Unknown result type (might be due to invalid IL or missing references)
		//IL_0170: Expected O, but got Unknown
		//IL_017c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0186: Expected O, but got Unknown
		//IL_01cf: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d9: Expected O, but got Unknown
		//IL_0222: Unknown result type (might be due to invalid IL or missing references)
		//IL_022c: Expected O, but got Unknown
		//IL_0275: Unknown result type (might be due to invalid IL or missing references)
		//IL_027f: Expected O, but got Unknown
		//IL_02ca: Unknown result type (might be due to invalid IL or missing references)
		//IL_02d4: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		PageSwitch = ((GComponent)this).GetController("PageSwitch");
		hasOuterTech = ((GComponent)this).GetController("hasOuterTech");
		TabListBack = (GList)((GComponent)this).GetChild("TabListBack");
		n0 = (GImage)((GComponent)this).GetChild("n0");
		n19 = (GImage)((GComponent)this).GetChild("n19");
		n13 = (GImage)((GComponent)this).GetChild("n13");
		NpcIcon = (GLoader)((GComponent)this).GetChild("NpcIcon");
		n14 = (GImage)((GComponent)this).GetChild("n14");
		EventName = (GTextField)((GComponent)this).GetChild("EventName");
		NpcText = (GTextField)((GComponent)this).GetChild("NpcText");
		Countdown = (GTextField)((GComponent)this).GetChild("Countdown");
		n6 = (GTextField)((GComponent)this).GetChild("n6");
		string id = "ui://p4ocf6q0dc6m7".Replace("ui://", "") + "-" + ((GObject)n6).id;
		((GObject)n6).text = LanguagesManager.GetDesc(id);
		StoreItems = (GList)((GComponent)this).GetChild("StoreItems");
		n15 = (GImage)((GComponent)this).GetChild("n15");
		n8 = (GTextField)((GComponent)this).GetChild("n8");
		string id2 = "ui://p4ocf6q0dc6m7".Replace("ui://", "") + "-" + ((GObject)n8).id;
		((GObject)n8).text = LanguagesManager.GetDesc(id2);
		n9 = (GTextField)((GComponent)this).GetChild("n9");
		string id3 = "ui://p4ocf6q0dc6m7".Replace("ui://", "") + "-" + ((GObject)n9).id;
		((GObject)n9).text = LanguagesManager.GetDesc(id3);
		n10 = (GTextField)((GComponent)this).GetChild("n10");
		string id4 = "ui://p4ocf6q0dc6m7".Replace("ui://", "") + "-" + ((GObject)n10).id;
		((GObject)n10).text = LanguagesManager.GetDesc(id4);
		n11 = (GTextField)((GComponent)this).GetChild("n11");
		string id5 = "ui://p4ocf6q0dc6m7".Replace("ui://", "") + "-" + ((GObject)n11).id;
		((GObject)n11).text = LanguagesManager.GetDesc(id5);
		TabListFront = (GList)((GComponent)this).GetChild("TabListFront");
		RpcTip = (UI_com_ResTip)(object)((GComponent)this).GetChild("RpcTip");
	}
}
