using System.Collections.Generic;
using FairyGUI;
using FairyGUI.Utils;
using HotFix.Sources.Base.Scripts.Helper;
using HotFix.Sources.Base.Sources.Scripts.GvG3UI.Helper;
using HotFix.Sources.Base.Sources.Scripts.GvG3UI.Manager;
using HotFix.Sources.Base.Sources.Scripts.GvG3UI.Model;
using HotFix.Sources.Base.Sources.Scripts.GvG3WorldMap.Helper;
using HotFix.Sources.Base.Sources.Scripts.GvG3WorldMap.Manager;
using Shift.Legion.Common.Helpers;
using Shift.Legion.Common.Services;
using Shift.Legion.GvG.Common.Models.GvGMode3.Mission;
using UI.GvG3MainStorylineQuest;

namespace UI.GvGWorldMap3;

public class UI_main_ProgressSettlement : GComponent, IUiController
{
	public GGraph back;

	public UI_com_ProgressSettlementBonus PopUp;

	public const string URL = "ui://4eq8fgd2ko68de";

	public static string Name = "UI_main_ProgressSettlement";

	private int _progress;

	public static string GetURL()
	{
		return "ui://4eq8fgd2ko68de";
	}

	public static UI_main_ProgressSettlement CreateInstance()
	{
		return (UI_main_ProgressSettlement)(object)UIPackage.CreateObject("GvGWorldMap3", "main_ProgressSettlement");
	}

	public static UI_main_ProgressSettlement CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_main_ProgressSettlement).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://4eq8fgd2ko68de", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		back = (GGraph)((GComponent)this).GetChild("back");
		PopUp = (UI_com_ProgressSettlementBonus)(object)((GComponent)this).GetChild("PopUp");
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
		_progress = (parameters.TryGetValue("Progress", out var value) ? ((int)value) : GetLastProgress());
	}

	public void OnShow()
	{
		Render();
	}

	public void RegisterUiEventListeners()
	{
		//IL_0018: Unknown result type (might be due to invalid IL or missing references)
		//IL_0022: Expected O, but got Unknown
		//IL_003a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0044: Expected O, but got Unknown
		((GObject)PopUp.Close).onClick.Set(new EventCallback0(End));
		((GObject)PopUp.CheckMissions).onClick.Set(new EventCallback0(GotoFlagshipMissions));
	}

	public void UnregisterUiEventListeners()
	{
		((GObject)PopUp.Close).onClick.Clear();
		((GObject)PopUp.CheckMissions).onClick.Clear();
	}

	public void End()
	{
		GameController.Contexts.Service<IUiService>().ClosePanel(Name, reservePackageRes: true);
	}

	private void GotoFlagshipMissions()
	{
		GameController.Contexts.Service<IUiService>().OpenPanel(UI_main_FlagShipMissions.Name, null);
		End();
	}

	private int GetLastProgress()
	{
		return Singleton<WorldStateManager>.Instance.Data.ProgressData.CampProgress - 1;
	}

	private void Render()
	{
		ShowTitle();
		ShowBonuses();
		void ShowBonuses()
		{
			//IL_0042: Unknown result type (might be due to invalid IL or missing references)
			//IL_004c: Expected O, but got Unknown
			//IL_007f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0089: Expected O, but got Unknown
			ProgressSettlementConfig bonusConfig = "GvGMode3ProgressSettlementBonus".ToConfiguration<ProgressSettlementConfig>();
			bonusConfig.Init(_progress);
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
					((GObject)uI_com_ProgressSettlementDisplayingBonus.Desc).text = progressSettlementBonus.DescText(_progress);
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
					((GObject)uI_com_ProgressSettlementDisplayingBonus.Desc).text = progressSettlementBonus.DescText(_progress);
				}
			}
		}
		void ShowTitle()
		{
			PopUp.Camp.SetSelectedIndex(Singleton<GvGMode3RoomManager>.Instance.ObserverRecord.ObCampId);
			GvGMode3CampProgressConfigModel gvGMode3CampProgressConfigModel = GvG3FlagShipMissionsConfigHelper.CampMainProgressConfig.Find((GvGMode3CampProgressConfigModel mission) => mission.Progress == _progress);
			if (gvGMode3CampProgressConfigModel == null)
			{
				ILRuntimeDebug.LogError("ProgressSettlement.ShowTitle:missionConfig is null");
			}
			else
			{
				string name = WorldMapConfigHelper.Configs.TryGetIsland(gvGMode3CampProgressConfigModel.CampControlMoonIsland).Name;
				string text = WorldMapConfigHelper.TryGetCampPrefabConfig(Singleton<GvGMode3RoomManager>.Instance.ObserverRecord.ObCampId).CampName.ToLanguage();
				((GObject)PopUp.Title).text = string.Format("GvGProgressSettlementTitle".ToLanguage(), new object[3] { text, name, _progress });
				PopUp.ProgressTitle.Progress.SetSelectedIndex(_progress - 1);
			}
		}
	}
}
