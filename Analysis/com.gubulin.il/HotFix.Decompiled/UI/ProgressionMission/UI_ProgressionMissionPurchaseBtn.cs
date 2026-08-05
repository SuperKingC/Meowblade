using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.ProgressionMission;

public class UI_ProgressionMissionPurchaseBtn : GComponent
{
	public GImage n2;

	public UI_TakeAll TakeAll;

	public GTextField n5;

	public GTextField TotalPrice;

	public GGroup n6;

	public const string URL = "ui://mapat4i5elte8a";

	public static string Name = "UI_ProgressionMissionPurchaseBtn";

	public static string GetURL()
	{
		return "ui://mapat4i5elte8a";
	}

	public static UI_ProgressionMissionPurchaseBtn CreateInstance()
	{
		return (UI_ProgressionMissionPurchaseBtn)(object)UIPackage.CreateObject("ProgressionMission", "ProgressionMissionPurchaseBtn");
	}

	public static UI_ProgressionMissionPurchaseBtn CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_ProgressionMissionPurchaseBtn).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://mapat4i5elte8a", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		//IL_0041: Unknown result type (might be due to invalid IL or missing references)
		//IL_004b: Expected O, but got Unknown
		//IL_0094: Unknown result type (might be due to invalid IL or missing references)
		//IL_009e: Expected O, but got Unknown
		//IL_00e7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f1: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		n2 = (GImage)((GComponent)this).GetChild("n2");
		TakeAll = (UI_TakeAll)(object)((GComponent)this).GetChild("TakeAll");
		n5 = (GTextField)((GComponent)this).GetChild("n5");
		string id = "ui://mapat4i5elte8a".Replace("ui://", "") + "-" + ((GObject)n5).id;
		((GObject)n5).text = LanguagesManager.GetDesc(id);
		TotalPrice = (GTextField)((GComponent)this).GetChild("TotalPrice");
		string id2 = "ui://mapat4i5elte8a".Replace("ui://", "") + "-" + ((GObject)TotalPrice).id;
		((GObject)TotalPrice).text = LanguagesManager.GetDesc(id2);
		n6 = (GGroup)((GComponent)this).GetChild("n6");
	}
}
