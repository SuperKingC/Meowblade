using Assets.Scripts.Managers;
using Assets.Scripts.UI;
using FairyGUI;
using FairyGUI.Utils;
using HotFix.Sources.Base.Sources.Scripts.GvG3.GvG3UI.UI.GvGWorldMapPanel.Model;
using Shift.Legion.Common.Managers;
using Shift.Legion.Common.Models;

namespace UI.GvGWorldMap3;

public class UI_com_ShipPlanSoldier : GComponent
{
	public Controller SoldierNotEnough;

	public GLoader FrameLoader;

	public UI_com_SoldierIconLoader IconLoader;

	public GComponent SoulStoneLevel;

	public GImage RedDot;

	public GTextField Count;

	public const string URL = "ui://4eq8fgd2efz66sd0";

	public static string Name = "UI_com_ShipPlanSoldier";

	public static string GetURL()
	{
		return "ui://4eq8fgd2efz66sd0";
	}

	public static UI_com_ShipPlanSoldier CreateInstance()
	{
		return (UI_com_ShipPlanSoldier)(object)UIPackage.CreateObject("GvGWorldMap3", "com_ShipPlanSoldier");
	}

	public static UI_com_ShipPlanSoldier CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_ShipPlanSoldier).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://4eq8fgd2efz66sd0", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		((GComponent)this).ConstructFromXML(xml);
		SoldierNotEnough = ((GComponent)this).GetController("SoldierNotEnough");
		FrameLoader = (GLoader)((GComponent)this).GetChild("FrameLoader");
		IconLoader = (UI_com_SoldierIconLoader)(object)((GComponent)this).GetChild("IconLoader");
		SoulStoneLevel = (GComponent)((GComponent)this).GetChild("SoulStoneLevel");
		RedDot = (GImage)((GComponent)this).GetChild("RedDot");
		Count = (GTextField)((GComponent)this).GetChild("Count");
		string id = "ui://4eq8fgd2efz66sd0".Replace("ui://", "") + "-" + ((GObject)Count).id;
		((GObject)Count).text = LanguagesManager.GetDesc(id);
	}

	public void RenderSoldier(ShipPlanSoldier soldier)
	{
		Soldier soldier2 = GameManagers.Instance.SoldierManager.Get(soldier.Id);
		string iconFrameBorderSoldier = UiHelper.GetIconFrameBorderSoldier(soldier.PotentialLevel);
		FrameLoader.url = "ui://PublicResources/" + iconFrameBorderSoldier;
		IconLoader.IconLoader.url = "ui://PublicResources/" + UiHelper.GetIconPath(soldier.Id);
		FGUIManager.Instance.SetAlightSoulStoneForSoldierIcon(SoulStoneLevel, soldier.PotentialLevel, soldier2.PotentialProgress);
		((GObject)Count).text = soldier.TotalCount.ToString();
		SoldierNotEnough.SetSelectedIndex(soldier.GetUiControllerSelectIndex());
	}
}
