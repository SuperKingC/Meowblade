using System.Collections.Generic;
using FairyGUI;
using FairyGUI.Utils;
using HotFix.Sources.Base.Sources.Scripts.GvG3UI.Helper;
using HotFix.Sources.Base.Sources.Scripts.GvG3UI.Model;
using Shift.Legion.Common.Services;
using Shift.Legion.GvG.Common.Models.GvGMode3;

namespace UI.GvG3MainStorylineQuest;

public class UI_main_LandOfEternalNightCampBonus : GComponent, IUiController
{
	public GGraph Mask;

	public UI_com_LandOfEternalNightCampBonus PopUp;

	public const string URL = "ui://249h3k3dzit42v";

	public static string Name = "UI_main_LandOfEternalNightCampBonus";

	public static string GetURL()
	{
		return "ui://249h3k3dzit42v";
	}

	public static UI_main_LandOfEternalNightCampBonus CreateInstance()
	{
		return (UI_main_LandOfEternalNightCampBonus)(object)UIPackage.CreateObject("GvG3MainStorylineQuest", "main_LandOfEternalNightCampBonus");
	}

	public static UI_main_LandOfEternalNightCampBonus CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_main_LandOfEternalNightCampBonus).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://249h3k3dzit42v", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		Mask = (GGraph)((GComponent)this).GetChild("Mask");
		PopUp = (UI_com_LandOfEternalNightCampBonus)(object)((GComponent)this).GetChild("PopUp");
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
		eLeaderboardType boardType = (parameters.TryGetValue("LeaderboardType", out value) ? ((eLeaderboardType)value) : eLeaderboardType.BOSS总输出榜_阵营);
		Render(boardType);
	}

	public void OnShow()
	{
	}

	public void RegisterUiEventListeners()
	{
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_001d: Expected O, but got Unknown
		((GObject)Mask).onClick.Set(new EventCallback0(End));
	}

	public void UnregisterUiEventListeners()
	{
		((GObject)Mask).onClick.Clear();
	}

	private void End()
	{
		GameController.Contexts.Service<IUiService>().ClosePanel(Name, reservePackageRes: true);
	}

	private void Render(eLeaderboardType boardType)
	{
		if (!GvG3FlagShipMissionsConfigHelper.IzRankBonusConfigs.TryGetValue(boardType.ToString(), out var value))
		{
			return;
		}
		foreach (RankBonusData item2 in value)
		{
			GObject val = PopUp.RewardsConfig.AddItemFromPool();
			if (val is UI_com_CampBonus uI_com_CampBonus)
			{
				int minRank = item2.MinRank;
				uI_com_CampBonus.RankPage.selectedIndex = minRank - 1;
				RankingBonusRenderer(item2.BonusItems, uI_com_CampBonus);
			}
		}
		void RankingBonusRenderer(Dictionary<string, int> bonus, UI_com_CampBonus campBonusUi)
		{
			//IL_00a2: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ac: Expected O, but got Unknown
			foreach (KeyValuePair<string, int> item in bonus)
			{
				GObject val2 = campBonusUi.Bonus.AddItemFromPool();
				if (val2 is UI_com_Bonus uI_com_Bonus)
				{
					((GObject)uI_com_Bonus.Count).text = item.Value.ToString();
					FGUIManager.Instance.SetItemIconAndFrame(uI_com_Bonus.ItemIcon, item.Key);
					((GObject)uI_com_Bonus).onClick.Set((EventCallback0)delegate
					{
						FGUIManager.Instance.ItemTip(item.Key, ((GObject)this).sortingOrder, noCheckBtn: true);
					});
				}
			}
		}
	}
}
