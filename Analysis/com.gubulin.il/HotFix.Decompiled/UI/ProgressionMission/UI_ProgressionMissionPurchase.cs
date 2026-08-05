using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.ProgressionMission;

public class UI_ProgressionMissionPurchase : GComponent
{
	public GGraph Mask;

	public GImage n5;

	public GList ContentList;

	public GTextField n2;

	public GTextField n3;

	public GImage n8;

	public GImage n9;

	public GButton closeBtn;

	public const string URL = "ui://mapat4i5elte88";

	public static string Name = "UI_ProgressionMissionPurchase";

	public static string GetURL()
	{
		return "ui://mapat4i5elte88";
	}

	public static UI_ProgressionMissionPurchase CreateInstance()
	{
		return (UI_ProgressionMissionPurchase)(object)UIPackage.CreateObject("ProgressionMission", "ProgressionMissionPurchase");
	}

	public static UI_ProgressionMissionPurchase CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_ProgressionMissionPurchase).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://mapat4i5elte88", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		//IL_00aa: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b4: Expected O, but got Unknown
		//IL_00fd: Unknown result type (might be due to invalid IL or missing references)
		//IL_0107: Expected O, but got Unknown
		//IL_0113: Unknown result type (might be due to invalid IL or missing references)
		//IL_011d: Expected O, but got Unknown
		//IL_0129: Unknown result type (might be due to invalid IL or missing references)
		//IL_0133: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		Mask = (GGraph)((GComponent)this).GetChild("Mask");
		n5 = (GImage)((GComponent)this).GetChild("n5");
		ContentList = (GList)((GComponent)this).GetChild("ContentList");
		n2 = (GTextField)((GComponent)this).GetChild("n2");
		string id = "ui://mapat4i5elte88".Replace("ui://", "") + "-" + ((GObject)n2).id;
		((GObject)n2).text = LanguagesManager.GetDesc(id);
		n3 = (GTextField)((GComponent)this).GetChild("n3");
		string id2 = "ui://mapat4i5elte88".Replace("ui://", "") + "-" + ((GObject)n3).id;
		((GObject)n3).text = LanguagesManager.GetDesc(id2);
		n8 = (GImage)((GComponent)this).GetChild("n8");
		n9 = (GImage)((GComponent)this).GetChild("n9");
		closeBtn = (GButton)((GComponent)this).GetChild("closeBtn");
	}
}
