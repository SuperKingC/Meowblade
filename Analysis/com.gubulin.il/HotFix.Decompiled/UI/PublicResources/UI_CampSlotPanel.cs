using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.PublicResources;

public class UI_CampSlotPanel : GComponent
{
	public GList EquipmentList;

	public UI_ProgressBarForUi ProgressBar;

	public GTextField tip;

	public GImage max;

	public Transition EquipmentListDisappear;

	public const string URL = "ui://kt6rg65oj93uj9";

	public static string Name = "UI_CampSlotPanel";

	public static string GetURL()
	{
		return "ui://kt6rg65oj93uj9";
	}

	public static UI_CampSlotPanel CreateInstance()
	{
		return (UI_CampSlotPanel)(object)UIPackage.CreateObject("PublicResources", "CampSlotPanel");
	}

	public static UI_CampSlotPanel CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_CampSlotPanel).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://kt6rg65oj93uj9", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		((GComponent)this).ConstructFromXML(xml);
		EquipmentList = (GList)((GComponent)this).GetChild("EquipmentList");
		ProgressBar = (UI_ProgressBarForUi)(object)((GComponent)this).GetChild("ProgressBar");
		tip = (GTextField)((GComponent)this).GetChild("tip");
		string id = "ui://kt6rg65oj93uj9".Replace("ui://", "") + "-" + ((GObject)tip).id;
		((GObject)tip).text = LanguagesManager.GetDesc(id);
		max = (GImage)((GComponent)this).GetChild("max");
		EquipmentListDisappear = ((GComponent)this).GetTransition("EquipmentListDisappear");
	}
}
