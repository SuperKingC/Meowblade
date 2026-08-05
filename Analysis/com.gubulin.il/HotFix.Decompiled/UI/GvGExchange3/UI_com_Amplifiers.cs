using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGExchange3;

public class UI_com_Amplifiers : GComponent
{
	public Controller IsEmpty;

	public Controller Selected;

	public GImage Background;

	public GImage n10;

	public GImage n11;

	public UI_com_AmplifierFilter FilterDialog;

	public GList AmplifierList;

	public GButton Close;

	public UI_btn_Confirm Confirm;

	public GTextField n13;

	public UI_com_AmplifierSlot SelectedAmplifier;

	public GTextField n4;

	public GList PropList;

	public GTextField AmpName;

	public GImage n12;

	public GGroup n14;

	public const string URL = "ui://tt2iq07odwxtd";

	public static string Name = "UI_com_Amplifiers";

	public static string GetURL()
	{
		return "ui://tt2iq07odwxtd";
	}

	public static UI_com_Amplifiers CreateInstance()
	{
		return (UI_com_Amplifiers)(object)UIPackage.CreateObject("GvGExchange3", "com_Amplifiers");
	}

	public static UI_com_Amplifiers CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_Amplifiers).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://tt2iq07odwxtd", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		//IL_008f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0099: Expected O, but got Unknown
		//IL_00a5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00af: Expected O, but got Unknown
		//IL_00d1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00db: Expected O, but got Unknown
		//IL_013a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0144: Expected O, but got Unknown
		//IL_018d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0197: Expected O, but got Unknown
		//IL_01a3: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ad: Expected O, but got Unknown
		//IL_01b9: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c3: Expected O, but got Unknown
		//IL_01cf: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d9: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		IsEmpty = ((GComponent)this).GetController("IsEmpty");
		Selected = ((GComponent)this).GetController("Selected");
		Background = (GImage)((GComponent)this).GetChild("Background");
		n10 = (GImage)((GComponent)this).GetChild("n10");
		n11 = (GImage)((GComponent)this).GetChild("n11");
		FilterDialog = (UI_com_AmplifierFilter)(object)((GComponent)this).GetChild("FilterDialog");
		AmplifierList = (GList)((GComponent)this).GetChild("AmplifierList");
		Close = (GButton)((GComponent)this).GetChild("Close");
		Confirm = (UI_btn_Confirm)(object)((GComponent)this).GetChild("Confirm");
		n13 = (GTextField)((GComponent)this).GetChild("n13");
		string id = "ui://tt2iq07odwxtd".Replace("ui://", "") + "-" + ((GObject)n13).id;
		((GObject)n13).text = LanguagesManager.GetDesc(id);
		SelectedAmplifier = (UI_com_AmplifierSlot)(object)((GComponent)this).GetChild("SelectedAmplifier");
		n4 = (GTextField)((GComponent)this).GetChild("n4");
		string id2 = "ui://tt2iq07odwxtd".Replace("ui://", "") + "-" + ((GObject)n4).id;
		((GObject)n4).text = LanguagesManager.GetDesc(id2);
		PropList = (GList)((GComponent)this).GetChild("PropList");
		AmpName = (GTextField)((GComponent)this).GetChild("AmpName");
		n12 = (GImage)((GComponent)this).GetChild("n12");
		n14 = (GGroup)((GComponent)this).GetChild("n14");
	}
}
