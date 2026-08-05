using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGShipDetail;

public class UI_btn_AmplifierSumBtn : GButton
{
	public Controller button;

	public GImage n74;

	public GImage n115;

	public GTextField n116;

	public GTextField n112;

	public UI_AmpSummarySlot AmpType1;

	public UI_AmpSummarySlot AmpType2;

	public UI_AmpSummarySlot AmpType3;

	public GTextField AmplifiersCount;

	public GImage n114;

	public GTextField n117;

	public GTextField ampScore;

	public const string URL = "ui://u6x0b1gnbvnu37";

	public static string Name = "UI_btn_AmplifierSumBtn";

	public static string GetURL()
	{
		return "ui://u6x0b1gnbvnu37";
	}

	public static UI_btn_AmplifierSumBtn CreateInstance()
	{
		return (UI_btn_AmplifierSumBtn)(object)UIPackage.CreateObject("GvGShipDetail", "btn_AmplifierSumBtn");
	}

	public static UI_btn_AmplifierSumBtn CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_btn_AmplifierSumBtn).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://u6x0b1gnbvnu37", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		//IL_013a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0144: Expected O, but got Unknown
		//IL_0150: Unknown result type (might be due to invalid IL or missing references)
		//IL_015a: Expected O, but got Unknown
		//IL_0166: Unknown result type (might be due to invalid IL or missing references)
		//IL_0170: Expected O, but got Unknown
		//IL_01b9: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c3: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		button = ((GComponent)this).GetController("button");
		n74 = (GImage)((GComponent)this).GetChild("n74");
		n115 = (GImage)((GComponent)this).GetChild("n115");
		n116 = (GTextField)((GComponent)this).GetChild("n116");
		string id = "ui://u6x0b1gnbvnu37".Replace("ui://", "") + "-" + ((GObject)n116).id;
		((GObject)n116).text = LanguagesManager.GetDesc(id);
		n112 = (GTextField)((GComponent)this).GetChild("n112");
		string id2 = "ui://u6x0b1gnbvnu37".Replace("ui://", "") + "-" + ((GObject)n112).id;
		((GObject)n112).text = LanguagesManager.GetDesc(id2);
		AmpType1 = (UI_AmpSummarySlot)(object)((GComponent)this).GetChild("AmpType1");
		AmpType2 = (UI_AmpSummarySlot)(object)((GComponent)this).GetChild("AmpType2");
		AmpType3 = (UI_AmpSummarySlot)(object)((GComponent)this).GetChild("AmpType3");
		AmplifiersCount = (GTextField)((GComponent)this).GetChild("AmplifiersCount");
		n114 = (GImage)((GComponent)this).GetChild("n114");
		n117 = (GTextField)((GComponent)this).GetChild("n117");
		string id3 = "ui://u6x0b1gnbvnu37".Replace("ui://", "") + "-" + ((GObject)n117).id;
		((GObject)n117).text = LanguagesManager.GetDesc(id3);
		ampScore = (GTextField)((GComponent)this).GetChild("ampScore");
		string id4 = "ui://u6x0b1gnbvnu37".Replace("ui://", "") + "-" + ((GObject)ampScore).id;
		((GObject)ampScore).text = LanguagesManager.GetDesc(id4);
	}
}
