using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGShipDetail;

public class UI_com_MiningStatus : GComponent
{
	public Controller State;

	public GImage n71;

	public UI_com_MiningDetailPages MiningDetailPages;

	public GImage n109;

	public GImage n106;

	public GImage mask;

	public GImage n107;

	public GImage n108;

	public GTextField n1;

	public GImage n120;

	public GTextField statusText1;

	public GTextField statusText2;

	public GTextField n82;

	public GImage n118;

	public GTextField n119;

	public GTextField MiningSpeed1;

	public GGroup MiningGroup1;

	public GGroup n94;

	public const string URL = "ui://u6x0b1gnwb3q2k";

	public static string Name = "UI_com_MiningStatus";

	public static string GetURL()
	{
		return "ui://u6x0b1gnwb3q2k";
	}

	public static UI_com_MiningStatus CreateInstance()
	{
		return (UI_com_MiningStatus)(object)UIPackage.CreateObject("GvGShipDetail", "com_MiningStatus");
	}

	public static UI_com_MiningStatus CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_MiningStatus).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://u6x0b1gnwb3q2k", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		//IL_0129: Unknown result type (might be due to invalid IL or missing references)
		//IL_0133: Expected O, but got Unknown
		//IL_017c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0186: Expected O, but got Unknown
		//IL_01cf: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d9: Expected O, but got Unknown
		//IL_0222: Unknown result type (might be due to invalid IL or missing references)
		//IL_022c: Expected O, but got Unknown
		//IL_0238: Unknown result type (might be due to invalid IL or missing references)
		//IL_0242: Expected O, but got Unknown
		//IL_028d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0297: Expected O, but got Unknown
		//IL_02a3: Unknown result type (might be due to invalid IL or missing references)
		//IL_02ad: Expected O, but got Unknown
		//IL_02b9: Unknown result type (might be due to invalid IL or missing references)
		//IL_02c3: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		State = ((GComponent)this).GetController("State");
		n71 = (GImage)((GComponent)this).GetChild("n71");
		MiningDetailPages = (UI_com_MiningDetailPages)(object)((GComponent)this).GetChild("MiningDetailPages");
		n109 = (GImage)((GComponent)this).GetChild("n109");
		n106 = (GImage)((GComponent)this).GetChild("n106");
		mask = (GImage)((GComponent)this).GetChild("mask");
		n107 = (GImage)((GComponent)this).GetChild("n107");
		n108 = (GImage)((GComponent)this).GetChild("n108");
		n1 = (GTextField)((GComponent)this).GetChild("n1");
		string id = "ui://u6x0b1gnwb3q2k".Replace("ui://", "") + "-" + ((GObject)n1).id;
		((GObject)n1).text = LanguagesManager.GetDesc(id);
		n120 = (GImage)((GComponent)this).GetChild("n120");
		statusText1 = (GTextField)((GComponent)this).GetChild("statusText1");
		string id2 = "ui://u6x0b1gnwb3q2k".Replace("ui://", "") + "-" + ((GObject)statusText1).id;
		((GObject)statusText1).text = LanguagesManager.GetDesc(id2);
		statusText2 = (GTextField)((GComponent)this).GetChild("statusText2");
		string id3 = "ui://u6x0b1gnwb3q2k".Replace("ui://", "") + "-" + ((GObject)statusText2).id;
		((GObject)statusText2).text = LanguagesManager.GetDesc(id3);
		n82 = (GTextField)((GComponent)this).GetChild("n82");
		string id4 = "ui://u6x0b1gnwb3q2k".Replace("ui://", "") + "-" + ((GObject)n82).id;
		((GObject)n82).text = LanguagesManager.GetDesc(id4);
		n118 = (GImage)((GComponent)this).GetChild("n118");
		n119 = (GTextField)((GComponent)this).GetChild("n119");
		string id5 = "ui://u6x0b1gnwb3q2k".Replace("ui://", "") + "-" + ((GObject)n119).id;
		((GObject)n119).text = LanguagesManager.GetDesc(id5);
		MiningSpeed1 = (GTextField)((GComponent)this).GetChild("MiningSpeed1");
		MiningGroup1 = (GGroup)((GComponent)this).GetChild("MiningGroup1");
		n94 = (GGroup)((GComponent)this).GetChild("n94");
	}
}
