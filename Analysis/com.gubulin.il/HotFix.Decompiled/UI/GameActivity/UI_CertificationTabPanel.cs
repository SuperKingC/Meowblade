using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.GameActivity;

public class UI_CertificationTabPanel : GComponent
{
	public Controller PageController;

	public GImage n45;

	public GImage n47;

	public GImage n52;

	public GImage n53;

	public GTextField inputRealName;

	public GTextField inputIdCardNumber;

	public UI_CertificationGiftPack CertificationGiftPack;

	public GButton ReceivedBtn;

	public GButton certificationBtn;

	public GTextField n38;

	public GTextField n40;

	public GGraph SfxBack;

	public GTextField n41;

	public GImage n43;

	public GImage n44;

	public GImage n46;

	public GImage n50;

	public GImage n51;

	public const string URL = "ui://29q48tv6jbid1y";

	public static string Name = "UI_CertificationTabPanel";

	public static string GetURL()
	{
		return "ui://29q48tv6jbid1y";
	}

	public static UI_CertificationTabPanel CreateInstance()
	{
		return (UI_CertificationTabPanel)(object)UIPackage.CreateObject("GameActivity", "CertificationTabPanel");
	}

	public static UI_CertificationTabPanel CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_CertificationTabPanel).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://29q48tv6jbid1y", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		//IL_00c0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ca: Expected O, but got Unknown
		//IL_00d6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e0: Expected O, but got Unknown
		//IL_00ec: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f6: Expected O, but got Unknown
		//IL_013f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0149: Expected O, but got Unknown
		//IL_0192: Unknown result type (might be due to invalid IL or missing references)
		//IL_019c: Expected O, but got Unknown
		//IL_01a8: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b2: Expected O, but got Unknown
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
		((GComponent)this).ConstructFromXML(xml);
		PageController = ((GComponent)this).GetController("PageController");
		n45 = (GImage)((GComponent)this).GetChild("n45");
		n47 = (GImage)((GComponent)this).GetChild("n47");
		n52 = (GImage)((GComponent)this).GetChild("n52");
		n53 = (GImage)((GComponent)this).GetChild("n53");
		inputRealName = (GTextField)((GComponent)this).GetChild("inputRealName");
		inputIdCardNumber = (GTextField)((GComponent)this).GetChild("inputIdCardNumber");
		CertificationGiftPack = (UI_CertificationGiftPack)(object)((GComponent)this).GetChild("CertificationGiftPack");
		ReceivedBtn = (GButton)((GComponent)this).GetChild("ReceivedBtn");
		certificationBtn = (GButton)((GComponent)this).GetChild("certificationBtn");
		n38 = (GTextField)((GComponent)this).GetChild("n38");
		string id = "ui://29q48tv6jbid1y".Replace("ui://", "") + "-" + ((GObject)n38).id;
		((GObject)n38).text = LanguagesManager.GetDesc(id);
		n40 = (GTextField)((GComponent)this).GetChild("n40");
		string id2 = "ui://29q48tv6jbid1y".Replace("ui://", "") + "-" + ((GObject)n40).id;
		((GObject)n40).text = LanguagesManager.GetDesc(id2);
		SfxBack = (GGraph)((GComponent)this).GetChild("SfxBack");
		n41 = (GTextField)((GComponent)this).GetChild("n41");
		string id3 = "ui://29q48tv6jbid1y".Replace("ui://", "") + "-" + ((GObject)n41).id;
		((GObject)n41).text = LanguagesManager.GetDesc(id3);
		n43 = (GImage)((GComponent)this).GetChild("n43");
		n44 = (GImage)((GComponent)this).GetChild("n44");
		n46 = (GImage)((GComponent)this).GetChild("n46");
		n50 = (GImage)((GComponent)this).GetChild("n50");
		n51 = (GImage)((GComponent)this).GetChild("n51");
	}
}
