using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGShipDetail;

public class UI_com_ShipStatus : GComponent
{
	public Controller Status;

	public GImage n6;

	public GLoader n1;

	public GTextField 飞行文本;

	public GTextField 驻扎文本;

	public GTextField 采集文本;

	public GTextField 战斗文本;

	public GTextField 已就绪文本;

	public GTextField 位置;

	public GTextField IslandName;

	public GImage n10;

	public UI_btn_ToCampBtn ToNearestBtn;

	public UI_btn_LiftoffBtn LiftoffBtn;

	public const string URL = "ui://u6x0b1gnzpu41d";

	public static string Name = "UI_com_ShipStatus";

	public static string GetURL()
	{
		return "ui://u6x0b1gnzpu41d";
	}

	public static UI_com_ShipStatus CreateInstance()
	{
		return (UI_com_ShipStatus)(object)UIPackage.CreateObject("GvGShipDetail", "com_ShipStatus");
	}

	public static UI_com_ShipStatus CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_ShipStatus).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://u6x0b1gnzpu41d", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		//IL_00a5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00af: Expected O, but got Unknown
		//IL_00f8: Unknown result type (might be due to invalid IL or missing references)
		//IL_0102: Expected O, but got Unknown
		//IL_014b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0155: Expected O, but got Unknown
		//IL_019e: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a8: Expected O, but got Unknown
		//IL_01f3: Unknown result type (might be due to invalid IL or missing references)
		//IL_01fd: Expected O, but got Unknown
		//IL_0248: Unknown result type (might be due to invalid IL or missing references)
		//IL_0252: Expected O, but got Unknown
		//IL_025e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0268: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		Status = ((GComponent)this).GetController("Status");
		n6 = (GImage)((GComponent)this).GetChild("n6");
		n1 = (GLoader)((GComponent)this).GetChild("n1");
		飞行文本 = (GTextField)((GComponent)this).GetChild("飞行文本");
		string id = "ui://u6x0b1gnzpu41d".Replace("ui://", "") + "-" + ((GObject)飞行文本).id;
		((GObject)飞行文本).text = LanguagesManager.GetDesc(id);
		驻扎文本 = (GTextField)((GComponent)this).GetChild("驻扎文本");
		string id2 = "ui://u6x0b1gnzpu41d".Replace("ui://", "") + "-" + ((GObject)驻扎文本).id;
		((GObject)驻扎文本).text = LanguagesManager.GetDesc(id2);
		采集文本 = (GTextField)((GComponent)this).GetChild("采集文本");
		string id3 = "ui://u6x0b1gnzpu41d".Replace("ui://", "") + "-" + ((GObject)采集文本).id;
		((GObject)采集文本).text = LanguagesManager.GetDesc(id3);
		战斗文本 = (GTextField)((GComponent)this).GetChild("战斗文本");
		string id4 = "ui://u6x0b1gnzpu41d".Replace("ui://", "") + "-" + ((GObject)战斗文本).id;
		((GObject)战斗文本).text = LanguagesManager.GetDesc(id4);
		已就绪文本 = (GTextField)((GComponent)this).GetChild("已就绪文本");
		string id5 = "ui://u6x0b1gnzpu41d".Replace("ui://", "") + "-" + ((GObject)已就绪文本).id;
		((GObject)已就绪文本).text = LanguagesManager.GetDesc(id5);
		位置 = (GTextField)((GComponent)this).GetChild("位置");
		string id6 = "ui://u6x0b1gnzpu41d".Replace("ui://", "") + "-" + ((GObject)位置).id;
		((GObject)位置).text = LanguagesManager.GetDesc(id6);
		IslandName = (GTextField)((GComponent)this).GetChild("IslandName");
		n10 = (GImage)((GComponent)this).GetChild("n10");
		ToNearestBtn = (UI_btn_ToCampBtn)(object)((GComponent)this).GetChild("ToNearestBtn");
		LiftoffBtn = (UI_btn_LiftoffBtn)(object)((GComponent)this).GetChild("LiftoffBtn");
	}
}
