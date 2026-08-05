using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.InstanceZones;

public class UI_Com_NeutralMain : GComponent
{
	public Controller c1;

	public GImage n191;

	public GImage n192;

	public GImage n212;

	public GImage n193;

	public GImage n198;

	public GImage n197;

	public GImage n196;

	public GTextField CdTimer;

	public GTextField n206;

	public GLoader n207;

	public GTextField n208;

	public GTextField n209;

	public UI_Com_NeutralLevelCardPanel LevelCardPanel;

	public GGraph level1_pos;

	public GGraph level2_pos;

	public GGraph level3_pos;

	public GGraph level4_pos;

	public GGraph level5_pos;

	public GGraph level6_pos;

	public GGraph level7_pos;

	public GGraph level8_pos;

	public GGraph level9_pos;

	public GGraph level10_pos;

	public GGraph level11_pos;

	public GGraph level12_pos;

	public GImage n195;

	public GImage n194;

	public GTextField n199;

	public GLoader n200;

	public GTextField TicketTip;

	public GTextField ExtraTicketTip;

	public UI_Com_NeutralContractTimes ExtraTicket1;

	public UI_Com_NeutralContractTimes ExtraTicket2;

	public GGroup TicketTipsContainer;

	public GGraph TicketTipsClickCover;

	public const string URL = "ui://f4wr270rgq2l7u";

	public static string Name = "UI_Com_NeutralMain";

	public static string GetURL()
	{
		return "ui://f4wr270rgq2l7u";
	}

	public static UI_Com_NeutralMain CreateInstance()
	{
		return (UI_Com_NeutralMain)(object)UIPackage.CreateObject("InstanceZones", "Com_NeutralMain");
	}

	public static UI_Com_NeutralMain CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_Com_NeutralMain).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://f4wr270rgq2l7u", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		//IL_00c0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ca: Expected O, but got Unknown
		//IL_00d6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e0: Expected O, but got Unknown
		//IL_0129: Unknown result type (might be due to invalid IL or missing references)
		//IL_0133: Expected O, but got Unknown
		//IL_013f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0149: Expected O, but got Unknown
		//IL_0192: Unknown result type (might be due to invalid IL or missing references)
		//IL_019c: Expected O, but got Unknown
		//IL_01fb: Unknown result type (might be due to invalid IL or missing references)
		//IL_0205: Expected O, but got Unknown
		//IL_0211: Unknown result type (might be due to invalid IL or missing references)
		//IL_021b: Expected O, but got Unknown
		//IL_0227: Unknown result type (might be due to invalid IL or missing references)
		//IL_0231: Expected O, but got Unknown
		//IL_023d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0247: Expected O, but got Unknown
		//IL_0253: Unknown result type (might be due to invalid IL or missing references)
		//IL_025d: Expected O, but got Unknown
		//IL_0269: Unknown result type (might be due to invalid IL or missing references)
		//IL_0273: Expected O, but got Unknown
		//IL_027f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0289: Expected O, but got Unknown
		//IL_0295: Unknown result type (might be due to invalid IL or missing references)
		//IL_029f: Expected O, but got Unknown
		//IL_02ab: Unknown result type (might be due to invalid IL or missing references)
		//IL_02b5: Expected O, but got Unknown
		//IL_02c1: Unknown result type (might be due to invalid IL or missing references)
		//IL_02cb: Expected O, but got Unknown
		//IL_02d7: Unknown result type (might be due to invalid IL or missing references)
		//IL_02e1: Expected O, but got Unknown
		//IL_02ed: Unknown result type (might be due to invalid IL or missing references)
		//IL_02f7: Expected O, but got Unknown
		//IL_0303: Unknown result type (might be due to invalid IL or missing references)
		//IL_030d: Expected O, but got Unknown
		//IL_0319: Unknown result type (might be due to invalid IL or missing references)
		//IL_0323: Expected O, but got Unknown
		//IL_032f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0339: Expected O, but got Unknown
		//IL_0382: Unknown result type (might be due to invalid IL or missing references)
		//IL_038c: Expected O, but got Unknown
		//IL_0398: Unknown result type (might be due to invalid IL or missing references)
		//IL_03a2: Expected O, but got Unknown
		//IL_03ae: Unknown result type (might be due to invalid IL or missing references)
		//IL_03b8: Expected O, but got Unknown
		//IL_03f0: Unknown result type (might be due to invalid IL or missing references)
		//IL_03fa: Expected O, but got Unknown
		//IL_0406: Unknown result type (might be due to invalid IL or missing references)
		//IL_0410: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		c1 = ((GComponent)this).GetController("c1");
		n191 = (GImage)((GComponent)this).GetChild("n191");
		n192 = (GImage)((GComponent)this).GetChild("n192");
		n212 = (GImage)((GComponent)this).GetChild("n212");
		n193 = (GImage)((GComponent)this).GetChild("n193");
		n198 = (GImage)((GComponent)this).GetChild("n198");
		n197 = (GImage)((GComponent)this).GetChild("n197");
		n196 = (GImage)((GComponent)this).GetChild("n196");
		CdTimer = (GTextField)((GComponent)this).GetChild("CdTimer");
		n206 = (GTextField)((GComponent)this).GetChild("n206");
		string id = "ui://f4wr270rgq2l7u".Replace("ui://", "") + "-" + ((GObject)n206).id;
		((GObject)n206).text = LanguagesManager.GetDesc(id);
		n207 = (GLoader)((GComponent)this).GetChild("n207");
		n208 = (GTextField)((GComponent)this).GetChild("n208");
		string id2 = "ui://f4wr270rgq2l7u".Replace("ui://", "") + "-" + ((GObject)n208).id;
		((GObject)n208).text = LanguagesManager.GetDesc(id2);
		n209 = (GTextField)((GComponent)this).GetChild("n209");
		string id3 = "ui://f4wr270rgq2l7u".Replace("ui://", "") + "-" + ((GObject)n209).id;
		((GObject)n209).text = LanguagesManager.GetDesc(id3);
		LevelCardPanel = (UI_Com_NeutralLevelCardPanel)(object)((GComponent)this).GetChild("LevelCardPanel");
		level1_pos = (GGraph)((GComponent)this).GetChild("level1_pos");
		level2_pos = (GGraph)((GComponent)this).GetChild("level2_pos");
		level3_pos = (GGraph)((GComponent)this).GetChild("level3_pos");
		level4_pos = (GGraph)((GComponent)this).GetChild("level4_pos");
		level5_pos = (GGraph)((GComponent)this).GetChild("level5_pos");
		level6_pos = (GGraph)((GComponent)this).GetChild("level6_pos");
		level7_pos = (GGraph)((GComponent)this).GetChild("level7_pos");
		level8_pos = (GGraph)((GComponent)this).GetChild("level8_pos");
		level9_pos = (GGraph)((GComponent)this).GetChild("level9_pos");
		level10_pos = (GGraph)((GComponent)this).GetChild("level10_pos");
		level11_pos = (GGraph)((GComponent)this).GetChild("level11_pos");
		level12_pos = (GGraph)((GComponent)this).GetChild("level12_pos");
		n195 = (GImage)((GComponent)this).GetChild("n195");
		n194 = (GImage)((GComponent)this).GetChild("n194");
		n199 = (GTextField)((GComponent)this).GetChild("n199");
		string id4 = "ui://f4wr270rgq2l7u".Replace("ui://", "") + "-" + ((GObject)n199).id;
		((GObject)n199).text = LanguagesManager.GetDesc(id4);
		n200 = (GLoader)((GComponent)this).GetChild("n200");
		TicketTip = (GTextField)((GComponent)this).GetChild("TicketTip");
		ExtraTicketTip = (GTextField)((GComponent)this).GetChild("ExtraTicketTip");
		ExtraTicket1 = (UI_Com_NeutralContractTimes)(object)((GComponent)this).GetChild("ExtraTicket1");
		ExtraTicket2 = (UI_Com_NeutralContractTimes)(object)((GComponent)this).GetChild("ExtraTicket2");
		TicketTipsContainer = (GGroup)((GComponent)this).GetChild("TicketTipsContainer");
		TicketTipsClickCover = (GGraph)((GComponent)this).GetChild("TicketTipsClickCover");
	}
}
