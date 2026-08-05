using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGRandomEvent3;

public class UI_com_OuterTechTelecomBuyDialog : GComponent
{
	public GImage n0;

	public GImage n1;

	public GTextField n13;

	public GButton CheckBox;

	public GGroup DontShowAgain;

	public GTextField n17;

	public GTextField AvailableCount;

	public GGroup n19;

	public GButton Confirm;

	public GButton Cancel;

	public GTextField n20;

	public GImage n4;

	public GTextField n3;

	public GGroup n21;

	public const string URL = "ui://p4ocf6q0tp8c1y";

	public static string Name = "UI_com_OuterTechTelecomBuyDialog";

	public static string GetURL()
	{
		return "ui://p4ocf6q0tp8c1y";
	}

	public static UI_com_OuterTechTelecomBuyDialog CreateInstance()
	{
		return (UI_com_OuterTechTelecomBuyDialog)(object)UIPackage.CreateObject("GvGRandomEvent3", "com_OuterTechTelecomBuyDialog");
	}

	public static UI_com_OuterTechTelecomBuyDialog CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_OuterTechTelecomBuyDialog).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://p4ocf6q0tp8c1y", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		//IL_013f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0149: Expected O, but got Unknown
		//IL_0155: Unknown result type (might be due to invalid IL or missing references)
		//IL_015f: Expected O, but got Unknown
		//IL_016b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0175: Expected O, but got Unknown
		//IL_01be: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c8: Expected O, but got Unknown
		//IL_01d4: Unknown result type (might be due to invalid IL or missing references)
		//IL_01de: Expected O, but got Unknown
		//IL_0227: Unknown result type (might be due to invalid IL or missing references)
		//IL_0231: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		n0 = (GImage)((GComponent)this).GetChild("n0");
		n1 = (GImage)((GComponent)this).GetChild("n1");
		n13 = (GTextField)((GComponent)this).GetChild("n13");
		string id = "ui://p4ocf6q0tp8c1y".Replace("ui://", "") + "-" + ((GObject)n13).id;
		((GObject)n13).text = LanguagesManager.GetDesc(id);
		CheckBox = (GButton)((GComponent)this).GetChild("CheckBox");
		DontShowAgain = (GGroup)((GComponent)this).GetChild("DontShowAgain");
		n17 = (GTextField)((GComponent)this).GetChild("n17");
		string id2 = "ui://p4ocf6q0tp8c1y".Replace("ui://", "") + "-" + ((GObject)n17).id;
		((GObject)n17).text = LanguagesManager.GetDesc(id2);
		AvailableCount = (GTextField)((GComponent)this).GetChild("AvailableCount");
		n19 = (GGroup)((GComponent)this).GetChild("n19");
		Confirm = (GButton)((GComponent)this).GetChild("Confirm");
		Cancel = (GButton)((GComponent)this).GetChild("Cancel");
		n20 = (GTextField)((GComponent)this).GetChild("n20");
		string id3 = "ui://p4ocf6q0tp8c1y".Replace("ui://", "") + "-" + ((GObject)n20).id;
		((GObject)n20).text = LanguagesManager.GetDesc(id3);
		n4 = (GImage)((GComponent)this).GetChild("n4");
		n3 = (GTextField)((GComponent)this).GetChild("n3");
		string id4 = "ui://p4ocf6q0tp8c1y".Replace("ui://", "") + "-" + ((GObject)n3).id;
		((GObject)n3).text = LanguagesManager.GetDesc(id4);
		n21 = (GGroup)((GComponent)this).GetChild("n21");
	}
}
