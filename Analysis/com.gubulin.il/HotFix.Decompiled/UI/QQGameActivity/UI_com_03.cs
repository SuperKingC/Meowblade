using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.QQGameActivity;

public class UI_com_03 : GComponent
{
	public Controller c1;

	public GImage n31;

	public GImage n19;

	public GImage n32;

	public GImage n33;

	public GImage n22;

	public GImage n26;

	public GImage n34;

	public GTextField n35;

	public GTextField MoneyText;

	public GTextField n23;

	public GImage n29;

	public GImage n30;

	public GImage n36;

	public Transition t0;

	public const string URL = "ui://r1j1a2l0iian3d";

	public static string Name = "UI_com_03";

	public static string GetURL()
	{
		return "ui://r1j1a2l0iian3d";
	}

	public static UI_com_03 CreateInstance()
	{
		return (UI_com_03)(object)UIPackage.CreateObject("QQGameActivity", "com_03");
	}

	public static UI_com_03 CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_03).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://r1j1a2l0iian3d", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		//IL_0113: Unknown result type (might be due to invalid IL or missing references)
		//IL_011d: Expected O, but got Unknown
		//IL_0129: Unknown result type (might be due to invalid IL or missing references)
		//IL_0133: Expected O, but got Unknown
		//IL_017c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0186: Expected O, but got Unknown
		//IL_0192: Unknown result type (might be due to invalid IL or missing references)
		//IL_019c: Expected O, but got Unknown
		//IL_01a8: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b2: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		c1 = ((GComponent)this).GetController("c1");
		n31 = (GImage)((GComponent)this).GetChild("n31");
		n19 = (GImage)((GComponent)this).GetChild("n19");
		n32 = (GImage)((GComponent)this).GetChild("n32");
		n33 = (GImage)((GComponent)this).GetChild("n33");
		n22 = (GImage)((GComponent)this).GetChild("n22");
		n26 = (GImage)((GComponent)this).GetChild("n26");
		n34 = (GImage)((GComponent)this).GetChild("n34");
		n35 = (GTextField)((GComponent)this).GetChild("n35");
		string id = "ui://r1j1a2l0iian3d".Replace("ui://", "") + "-" + ((GObject)n35).id;
		((GObject)n35).text = LanguagesManager.GetDesc(id);
		MoneyText = (GTextField)((GComponent)this).GetChild("MoneyText");
		n23 = (GTextField)((GComponent)this).GetChild("n23");
		string id2 = "ui://r1j1a2l0iian3d".Replace("ui://", "") + "-" + ((GObject)n23).id;
		((GObject)n23).text = LanguagesManager.GetDesc(id2);
		n29 = (GImage)((GComponent)this).GetChild("n29");
		n30 = (GImage)((GComponent)this).GetChild("n30");
		n36 = (GImage)((GComponent)this).GetChild("n36");
		t0 = ((GComponent)this).GetTransition("t0");
	}
}
