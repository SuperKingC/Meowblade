using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGShipDetail;

public class UI_com_NavigatingStatus : GComponent
{
	public Controller State;

	public GImage n71;

	public UI_com_OarDeck OarDeck;

	public GImage n77;

	public GImage n88;

	public GImage mask;

	public GImage n74;

	public GImage n76;

	public GTextField n1;

	public GTextField n79;

	public GImage n91;

	public GTextField statusText1;

	public GTextField statusText2;

	public GTextField n89;

	public GImage n82;

	public GTextField n83;

	public GButton SpeedBuff;

	public GTextField ShipSpeed;

	public GTextField n85;

	public GGroup SpeedGroup;

	public GGroup n87;

	public const string URL = "ui://u6x0b1gnwb3q2j";

	public static string Name = "UI_com_NavigatingStatus";

	public static string GetURL()
	{
		return "ui://u6x0b1gnwb3q2j";
	}

	public static UI_com_NavigatingStatus CreateInstance()
	{
		return (UI_com_NavigatingStatus)(object)UIPackage.CreateObject("GvGShipDetail", "com_NavigatingStatus");
	}

	public static UI_com_NavigatingStatus CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_NavigatingStatus).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://u6x0b1gnwb3q2j", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Expected O, but got Unknown
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
		//IL_00c0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ca: Expected O, but got Unknown
		//IL_0113: Unknown result type (might be due to invalid IL or missing references)
		//IL_011d: Expected O, but got Unknown
		//IL_0166: Unknown result type (might be due to invalid IL or missing references)
		//IL_0170: Expected O, but got Unknown
		//IL_017c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0186: Expected O, but got Unknown
		//IL_01cf: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d9: Expected O, but got Unknown
		//IL_0222: Unknown result type (might be due to invalid IL or missing references)
		//IL_022c: Expected O, but got Unknown
		//IL_0277: Unknown result type (might be due to invalid IL or missing references)
		//IL_0281: Expected O, but got Unknown
		//IL_028d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0297: Expected O, but got Unknown
		//IL_02e2: Unknown result type (might be due to invalid IL or missing references)
		//IL_02ec: Expected O, but got Unknown
		//IL_02f8: Unknown result type (might be due to invalid IL or missing references)
		//IL_0302: Expected O, but got Unknown
		//IL_030e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0318: Expected O, but got Unknown
		//IL_0363: Unknown result type (might be due to invalid IL or missing references)
		//IL_036d: Expected O, but got Unknown
		//IL_0379: Unknown result type (might be due to invalid IL or missing references)
		//IL_0383: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		State = ((GComponent)this).GetController("State");
		n71 = (GImage)((GComponent)this).GetChild("n71");
		OarDeck = (UI_com_OarDeck)(object)((GComponent)this).GetChild("OarDeck");
		n77 = (GImage)((GComponent)this).GetChild("n77");
		n88 = (GImage)((GComponent)this).GetChild("n88");
		mask = (GImage)((GComponent)this).GetChild("mask");
		n74 = (GImage)((GComponent)this).GetChild("n74");
		n76 = (GImage)((GComponent)this).GetChild("n76");
		n1 = (GTextField)((GComponent)this).GetChild("n1");
		string id = "ui://u6x0b1gnwb3q2j".Replace("ui://", "") + "-" + ((GObject)n1).id;
		((GObject)n1).text = LanguagesManager.GetDesc(id);
		n79 = (GTextField)((GComponent)this).GetChild("n79");
		string id2 = "ui://u6x0b1gnwb3q2j".Replace("ui://", "") + "-" + ((GObject)n79).id;
		((GObject)n79).text = LanguagesManager.GetDesc(id2);
		n91 = (GImage)((GComponent)this).GetChild("n91");
		statusText1 = (GTextField)((GComponent)this).GetChild("statusText1");
		string id3 = "ui://u6x0b1gnwb3q2j".Replace("ui://", "") + "-" + ((GObject)statusText1).id;
		((GObject)statusText1).text = LanguagesManager.GetDesc(id3);
		statusText2 = (GTextField)((GComponent)this).GetChild("statusText2");
		string id4 = "ui://u6x0b1gnwb3q2j".Replace("ui://", "") + "-" + ((GObject)statusText2).id;
		((GObject)statusText2).text = LanguagesManager.GetDesc(id4);
		n89 = (GTextField)((GComponent)this).GetChild("n89");
		string id5 = "ui://u6x0b1gnwb3q2j".Replace("ui://", "") + "-" + ((GObject)n89).id;
		((GObject)n89).text = LanguagesManager.GetDesc(id5);
		n82 = (GImage)((GComponent)this).GetChild("n82");
		n83 = (GTextField)((GComponent)this).GetChild("n83");
		string id6 = "ui://u6x0b1gnwb3q2j".Replace("ui://", "") + "-" + ((GObject)n83).id;
		((GObject)n83).text = LanguagesManager.GetDesc(id6);
		SpeedBuff = (GButton)((GComponent)this).GetChild("SpeedBuff");
		ShipSpeed = (GTextField)((GComponent)this).GetChild("ShipSpeed");
		n85 = (GTextField)((GComponent)this).GetChild("n85");
		string id7 = "ui://u6x0b1gnwb3q2j".Replace("ui://", "") + "-" + ((GObject)n85).id;
		((GObject)n85).text = LanguagesManager.GetDesc(id7);
		SpeedGroup = (GGroup)((GComponent)this).GetChild("SpeedGroup");
		n87 = (GGroup)((GComponent)this).GetChild("n87");
	}
}
