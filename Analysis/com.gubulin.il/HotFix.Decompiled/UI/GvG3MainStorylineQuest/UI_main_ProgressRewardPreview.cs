using System.Collections.Generic;
using FairyGUI;
using FairyGUI.Utils;
using HotFix.Sources.Base.Scripts.Helper;
using HotFix.Sources.Base.Sources.Scripts.GvG3UI.Helper;
using HotFix.Sources.Base.Sources.Scripts.GvG3UI.Manager;
using HotFix.Sources.Base.Sources.Scripts.GvG3UI.Model;
using HotFix.Sources.Base.Sources.Scripts.GvG3WorldMap.Helper;
using Shift.Legion.Common.Helpers;
using Shift.Legion.Common.Services;
using Shift.Legion.GvG.Common.Models.GvGMode3.Mission;
using UI.GvGWorldMap3;

namespace UI.GvG3MainStorylineQuest;

public class UI_main_ProgressRewardPreview : GComponent, IUiController
{
	public GGraph back;

	public UI_com_ProgressRewardPreview PopUp;

	public const string URL = "ui://249h3k3dndj6s4f";

	public static string Name = "UI_main_ProgressRewardPreview";

	public static string GetURL()
	{
		return "ui://249h3k3dndj6s4f";
	}

	public static UI_main_ProgressRewardPreview CreateInstance()
	{
		return (UI_main_ProgressRewardPreview)(object)UIPackage.CreateObject("GvG3MainStorylineQuest", "main_ProgressRewardPreview");
	}

	public static UI_main_ProgressRewardPreview CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_main_ProgressRewardPreview).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://249h3k3dndj6s4f", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		back = (GGraph)((GComponent)this).GetChild("back");
		PopUp = (UI_com_ProgressRewardPreview)(object)((GComponent)this).GetChild("PopUp");
	}

	public void BeforeDestroy()
	{
	}

	public void Destroy()
	{
	}

	public void Init(Dictionary<string, object> parameters)
	{
		FGUIManager.SetUiPanelSizeAndXy((GObject)(object)this, scaleAdaption: true);
		object value;
		int lastProgress = (parameters.TryGetValue("CurProgress", out value) ? ((int)value) : 0);
		Render(lastProgress);
	}

	public void OnShow()
	{
	}

	public void RegisterUiEventListeners()
	{
		//IL_0018: Unknown result type (might be due to invalid IL or missing references)
		//IL_0022: Expected O, but got Unknown
		((GObject)PopUp.Close).onClick.Set(new EventCallback0(End));
	}

	public void UnregisterUiEventListeners()
	{
		((GObject)PopUp.Close).onClick.Clear();
	}

	public void End()
	{
		GameController.Contexts.Service<IUiService>().ClosePanel(Name, reservePackageRes: true);
	}

	private void Render(int lastProgress)
	{
		ShowTitle();
		ShowBonuses();
		void ShowBonuses()
		{
			//IL_0047: Unknown result type (might be due to invalid IL or missing references)
			//IL_0051: Expected O, but got Unknown
			//IL_008e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0098: Expected O, but got Unknown
			ProgressSettlementConfig bonusConfig = "GvGMode3ProgressSettlementBonus".ToConfiguration<ProgressSettlementConfig>();
			bonusConfig.Init(lastProgress);
			PopUp.CampBonuses.itemRenderer = new ListItemRenderer(CampBonusRender);
			PopUp.CampBonuses.numItems = bonusConfig.Camp.Count;
			PopUp.FlagShipBonuses.itemRenderer = new ListItemRenderer(FlagShipBonusRender);
			PopUp.FlagShipBonuses.numItems = bonusConfig.FlagShip.Count;
			void CampBonusRender(int index, GObject obj)
			{
				if (!(obj is UI_com_ProgressSettlementDisplayingBonus uI_com_ProgressSettlementDisplayingBonus))
				{
					ILRuntimeDebug.LogError("ProgressSettlement.CampBonusRender:bonusUi is not UI_com_ProgressSettlementDisplayingBonus");
				}
				else
				{
					ProgressSettlementBonus progressSettlementBonus = bonusConfig.Camp[index];
					uI_com_ProgressSettlementDisplayingBonus.BonusIcon.url = "ui://GvGWorldMap3/" + progressSettlementBonus.Icon;
					((GObject)uI_com_ProgressSettlementDisplayingBonus.Desc).text = progressSettlementBonus.DescText(lastProgress);
				}
			}
			void FlagShipBonusRender(int index, GObject obj)
			{
				if (!(obj is UI_com_ProgressSettlementDisplayingBonus uI_com_ProgressSettlementDisplayingBonus))
				{
					ILRuntimeDebug.LogError("ProgressSettlement.FlagShipBonusRender:bonusUi is not UI_com_ProgressSettlementDisplayingBonus");
				}
				else
				{
					ProgressSettlementBonus progressSettlementBonus = bonusConfig.FlagShip[index];
					uI_com_ProgressSettlementDisplayingBonus.BonusIcon.url = "ui://GvGWorldMap3/" + progressSettlementBonus.Icon;
					((GObject)uI_com_ProgressSettlementDisplayingBonus.Desc).text = progressSettlementBonus.DescText(lastProgress);
				}
			}
		}
		void ShowTitle()
		{
			PopUp.Camp.SetSelectedIndex(Singleton<GvGMode3RoomManager>.Instance.ObserverRecord.ObCampId);
			GvGMode3CampProgressConfigModel gvGMode3CampProgressConfigModel = GvG3FlagShipMissionsConfigHelper.CampMainProgressConfig.Find((GvGMode3CampProgressConfigModel mission) => mission.Progress == lastProgress);
			if (gvGMode3CampProgressConfigModel == null)
			{
				ILRuntimeDebug.LogError("ProgressSettlement.ShowTitle:missionConfig is null");
			}
			else
			{
				string name = WorldMapConfigHelper.Configs.TryGetIsland(gvGMode3CampProgressConfigModel.CampControlMoonIsland).Name;
				((GObject)PopUp.Title).text = string.Format("GvGProgressRewardPreviewTitle".ToLanguage(), new object[2] { name, lastProgress });
				PopUp.Progress.SetSelectedIndex(lastProgress - 1);
			}
		}
	}
}
