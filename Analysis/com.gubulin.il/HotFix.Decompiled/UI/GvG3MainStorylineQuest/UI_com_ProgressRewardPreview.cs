using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvG3MainStorylineQuest;

public class UI_com_ProgressRewardPreview : GComponent
{
	public Controller Camp;

	public Controller Progress;

	public GImage n14;

	public GImage n0;

	public GImage n12;

	public GImage n15;

	public GImage n13;

	public GImage n17;

	public GImage n26;

	public GImage n18;

	public GLoader n1;

	public GTextField Title;

	public GTextField n3;

	public GImage n19;

	public GImage n20;

	public GTextField n4;

	public GImage n22;

	public GImage n23;

	public GTextField n5;

	public GList CampBonuses;

	public GList FlagShipBonuses;

	public UI_btn_ClosePreviewReward Close;

	public GTextField n11;

	public GLoader n28;

	public const string URL = "ui://249h3k3dndj6s4b";

	public static string Name = "UI_com_ProgressRewardPreview";

	public static string GetURL()
	{
		return "ui://249h3k3dndj6s4b";
	}

	public static UI_com_ProgressRewardPreview CreateInstance()
	{
		return (UI_com_ProgressRewardPreview)(object)UIPackage.CreateObject("GvG3MainStorylineQuest", "com_ProgressRewardPreview");
	}

	public static UI_com_ProgressRewardPreview CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_ProgressRewardPreview).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://249h3k3dndj6s4b", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		//IL_0079: Unknown result type (might be due to invalid IL or missing references)
		//IL_0083: Expected O, but got Unknown
		//IL_008f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0099: Expected O, but got Unknown
		//IL_00a5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00af: Expected O, but got Unknown
		//IL_00bb: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c5: Expected O, but got Unknown
		//IL_00d1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00db: Expected O, but got Unknown
		//IL_00e7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f1: Expected O, but got Unknown
		//IL_00fd: Unknown result type (might be due to invalid IL or missing references)
		//IL_0107: Expected O, but got Unknown
		//IL_0113: Unknown result type (might be due to invalid IL or missing references)
		//IL_011d: Expected O, but got Unknown
		//IL_0166: Unknown result type (might be due to invalid IL or missing references)
		//IL_0170: Expected O, but got Unknown
		//IL_017c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0186: Expected O, but got Unknown
		//IL_0192: Unknown result type (might be due to invalid IL or missing references)
		//IL_019c: Expected O, but got Unknown
		//IL_01e5: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ef: Expected O, but got Unknown
		//IL_01fb: Unknown result type (might be due to invalid IL or missing references)
		//IL_0205: Expected O, but got Unknown
		//IL_0211: Unknown result type (might be due to invalid IL or missing references)
		//IL_021b: Expected O, but got Unknown
		//IL_0264: Unknown result type (might be due to invalid IL or missing references)
		//IL_026e: Expected O, but got Unknown
		//IL_027a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0284: Expected O, but got Unknown
		//IL_02a6: Unknown result type (might be due to invalid IL or missing references)
		//IL_02b0: Expected O, but got Unknown
		//IL_02f9: Unknown result type (might be due to invalid IL or missing references)
		//IL_0303: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		Camp = ((GComponent)this).GetController("Camp");
		Progress = ((GComponent)this).GetController("Progress");
		n14 = (GImage)((GComponent)this).GetChild("n14");
		n0 = (GImage)((GComponent)this).GetChild("n0");
		n12 = (GImage)((GComponent)this).GetChild("n12");
		n15 = (GImage)((GComponent)this).GetChild("n15");
		n13 = (GImage)((GComponent)this).GetChild("n13");
		n17 = (GImage)((GComponent)this).GetChild("n17");
		n26 = (GImage)((GComponent)this).GetChild("n26");
		n18 = (GImage)((GComponent)this).GetChild("n18");
		n1 = (GLoader)((GComponent)this).GetChild("n1");
		Title = (GTextField)((GComponent)this).GetChild("Title");
		n3 = (GTextField)((GComponent)this).GetChild("n3");
		string id = "ui://249h3k3dndj6s4b".Replace("ui://", "") + "-" + ((GObject)n3).id;
		((GObject)n3).text = LanguagesManager.GetDesc(id);
		n19 = (GImage)((GComponent)this).GetChild("n19");
		n20 = (GImage)((GComponent)this).GetChild("n20");
		n4 = (GTextField)((GComponent)this).GetChild("n4");
		string id2 = "ui://249h3k3dndj6s4b".Replace("ui://", "") + "-" + ((GObject)n4).id;
		((GObject)n4).text = LanguagesManager.GetDesc(id2);
		n22 = (GImage)((GComponent)this).GetChild("n22");
		n23 = (GImage)((GComponent)this).GetChild("n23");
		n5 = (GTextField)((GComponent)this).GetChild("n5");
		string id3 = "ui://249h3k3dndj6s4b".Replace("ui://", "") + "-" + ((GObject)n5).id;
		((GObject)n5).text = LanguagesManager.GetDesc(id3);
		CampBonuses = (GList)((GComponent)this).GetChild("CampBonuses");
		FlagShipBonuses = (GList)((GComponent)this).GetChild("FlagShipBonuses");
		Close = (UI_btn_ClosePreviewReward)(object)((GComponent)this).GetChild("Close");
		n11 = (GTextField)((GComponent)this).GetChild("n11");
		string id4 = "ui://249h3k3dndj6s4b".Replace("ui://", "") + "-" + ((GObject)n11).id;
		((GObject)n11).text = LanguagesManager.GetDesc(id4);
		n28 = (GLoader)((GComponent)this).GetChild("n28");
	}
}
