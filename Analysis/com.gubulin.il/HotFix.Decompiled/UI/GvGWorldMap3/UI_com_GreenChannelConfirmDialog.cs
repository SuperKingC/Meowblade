using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGWorldMap3;

public class UI_com_GreenChannelConfirmDialog : GComponent
{
	public GImage back;

	public GTextField n12;

	public GTextField n13;

	public GTextField n14;

	public GTextField n19;

	public GImage n15;

	public GTextField n20;

	public GGroup n18;

	public GTextField n21;

	public GTextField Count;

	public GGroup n23;

	public UI_btn_Cancel CancelBtn;

	public UI_btn_yes ConfirmBtn;

	public GGraph n25;

	public GGraph n26;

	public const string URL = "ui://4eq8fgd2d0fus9v";

	public static string Name = "UI_com_GreenChannelConfirmDialog";

	public static string GetURL()
	{
		return "ui://4eq8fgd2d0fus9v";
	}

	public static UI_com_GreenChannelConfirmDialog CreateInstance()
	{
		return (UI_com_GreenChannelConfirmDialog)(object)UIPackage.CreateObject("GvGWorldMap3", "com_GreenChannelConfirmDialog");
	}

	public static UI_com_GreenChannelConfirmDialog CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_GreenChannelConfirmDialog).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://4eq8fgd2d0fus9v", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0035: Expected O, but got Unknown
		//IL_007e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0088: Expected O, but got Unknown
		//IL_00d1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00db: Expected O, but got Unknown
		//IL_0124: Unknown result type (might be due to invalid IL or missing references)
		//IL_012e: Expected O, but got Unknown
		//IL_0177: Unknown result type (might be due to invalid IL or missing references)
		//IL_0181: Expected O, but got Unknown
		//IL_018d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0197: Expected O, but got Unknown
		//IL_01e2: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ec: Expected O, but got Unknown
		//IL_01f8: Unknown result type (might be due to invalid IL or missing references)
		//IL_0202: Expected O, but got Unknown
		//IL_024d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0257: Expected O, but got Unknown
		//IL_0263: Unknown result type (might be due to invalid IL or missing references)
		//IL_026d: Expected O, but got Unknown
		//IL_02a5: Unknown result type (might be due to invalid IL or missing references)
		//IL_02af: Expected O, but got Unknown
		//IL_02bb: Unknown result type (might be due to invalid IL or missing references)
		//IL_02c5: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		back = (GImage)((GComponent)this).GetChild("back");
		n12 = (GTextField)((GComponent)this).GetChild("n12");
		string id = "ui://4eq8fgd2d0fus9v".Replace("ui://", "") + "-" + ((GObject)n12).id;
		((GObject)n12).text = LanguagesManager.GetDesc(id);
		n13 = (GTextField)((GComponent)this).GetChild("n13");
		string id2 = "ui://4eq8fgd2d0fus9v".Replace("ui://", "") + "-" + ((GObject)n13).id;
		((GObject)n13).text = LanguagesManager.GetDesc(id2);
		n14 = (GTextField)((GComponent)this).GetChild("n14");
		string id3 = "ui://4eq8fgd2d0fus9v".Replace("ui://", "") + "-" + ((GObject)n14).id;
		((GObject)n14).text = LanguagesManager.GetDesc(id3);
		n19 = (GTextField)((GComponent)this).GetChild("n19");
		string id4 = "ui://4eq8fgd2d0fus9v".Replace("ui://", "") + "-" + ((GObject)n19).id;
		((GObject)n19).text = LanguagesManager.GetDesc(id4);
		n15 = (GImage)((GComponent)this).GetChild("n15");
		n20 = (GTextField)((GComponent)this).GetChild("n20");
		string id5 = "ui://4eq8fgd2d0fus9v".Replace("ui://", "") + "-" + ((GObject)n20).id;
		((GObject)n20).text = LanguagesManager.GetDesc(id5);
		n18 = (GGroup)((GComponent)this).GetChild("n18");
		n21 = (GTextField)((GComponent)this).GetChild("n21");
		string id6 = "ui://4eq8fgd2d0fus9v".Replace("ui://", "") + "-" + ((GObject)n21).id;
		((GObject)n21).text = LanguagesManager.GetDesc(id6);
		Count = (GTextField)((GComponent)this).GetChild("Count");
		n23 = (GGroup)((GComponent)this).GetChild("n23");
		CancelBtn = (UI_btn_Cancel)(object)((GComponent)this).GetChild("CancelBtn");
		ConfirmBtn = (UI_btn_yes)(object)((GComponent)this).GetChild("ConfirmBtn");
		n25 = (GGraph)((GComponent)this).GetChild("n25");
		n26 = (GGraph)((GComponent)this).GetChild("n26");
	}
}
