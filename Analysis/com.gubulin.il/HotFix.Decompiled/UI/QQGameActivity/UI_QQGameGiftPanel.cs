using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.QQGameActivity;

public class UI_QQGameGiftPanel : GComponent
{
	public GLoader background;

	public GImage n13;

	public GComponent n14;

	public GComponent n15;

	public GComponent n16;

	public GComponent n17;

	public GComponent n18;

	public GImage n20;

	public GTextField n3;

	public GButton BackBtn;

	public UI_Title titleCom;

	public UI_com_01 RegistrationPack;

	public UI_com_01 GrowthPack;

	public UI_com_01 DailyActivePack;

	public const string URL = "ui://r1j1a2l0e3ph0";

	public static string Name = "UI_QQGameGiftPanel";

	public static string GetURL()
	{
		return "ui://r1j1a2l0e3ph0";
	}

	public static UI_QQGameGiftPanel CreateInstance()
	{
		return (UI_QQGameGiftPanel)(object)UIPackage.CreateObject("QQGameActivity", "QQGameGiftPanel");
	}

	public static UI_QQGameGiftPanel CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_QQGameGiftPanel).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://r1j1a2l0e3ph0", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		//IL_00c5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00cf: Expected O, but got Unknown
		//IL_0118: Unknown result type (might be due to invalid IL or missing references)
		//IL_0122: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		background = (GLoader)((GComponent)this).GetChild("background");
		n13 = (GImage)((GComponent)this).GetChild("n13");
		n14 = (GComponent)((GComponent)this).GetChild("n14");
		n15 = (GComponent)((GComponent)this).GetChild("n15");
		n16 = (GComponent)((GComponent)this).GetChild("n16");
		n17 = (GComponent)((GComponent)this).GetChild("n17");
		n18 = (GComponent)((GComponent)this).GetChild("n18");
		n20 = (GImage)((GComponent)this).GetChild("n20");
		n3 = (GTextField)((GComponent)this).GetChild("n3");
		string id = "ui://r1j1a2l0e3ph0".Replace("ui://", "") + "-" + ((GObject)n3).id;
		((GObject)n3).text = LanguagesManager.GetDesc(id);
		BackBtn = (GButton)((GComponent)this).GetChild("BackBtn");
		titleCom = (UI_Title)(object)((GComponent)this).GetChild("titleCom");
		RegistrationPack = (UI_com_01)(object)((GComponent)this).GetChild("RegistrationPack");
		GrowthPack = (UI_com_01)(object)((GComponent)this).GetChild("GrowthPack");
		DailyActivePack = (UI_com_01)(object)((GComponent)this).GetChild("DailyActivePack");
	}
}
